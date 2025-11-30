Imports System.Text
Imports System.Text.Json
Imports System.Drawing.Drawing2D
Imports System.IO

Public Class Question_Form

    Private Shared ReadOnly PRODI_OPTIONS As String() = {"TI", "TMJ", "TMD", "Lainnya"}
    Private Shared ReadOnly PS_OPTIONS As String() = {"0.0", "0.2", "0.4", "0.6", "0.8", "1.0"}
    Private Shared ReadOnly WORK_OPTIONS As String() = {"Individu", "Kelompok"}
    Private Shared ReadOnly DOMAIN_OPTIONS As String() = {"Algoritmik", "Desain kreatif", "Perangkat keras"}
    Private Shared ReadOnly METHOD_OPTIONS As String() = {"Experimental", "R&D", "Case Study", "Simulation"}
    Private Shared ReadOnly OUTPUT_OPTIONS As String() = {"Aplikasi", "Game", "IoT Device", "Model AI", "Other"}
    Private Shared ReadOnly YESNO_OPTIONS As String() = {"Ya", "Tidak"}

    Private ReadOnly questionsOrder As New List(Of String) From {
        "prodi", "ipk", "core_course", "weak_course", "problem_solving", "work_pref",
        "domain_pref", "research_product_pref", "industry_academic", "publication_goal", "startup_interest",
        "interests", "top_interest_reason", "project_type", "devices", "dataset", "manual_data",
        "duration", "risks", "test_physical", "methods", "output_type", "usability_test", "perf_test", "security_test",
        "skills"
    }

    Private answers As New Dictionary(Of String, Object)()
    Private currentStep As Integer = 1

    Private Sub Question_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Position card and rounded corners similar to other forms
        Dim found = Me.Controls.Find("PanelCard", True)
        If found.Length > 0 Then
            Dim panelCard As Panel = DirectCast(found(0), Panel)
            Dim leftFound = Me.Controls.Find("PanelLeft", True)
            If leftFound.Length > 0 Then
                Dim panelLeft As Panel = DirectCast(leftFound(0), Panel)
                Dim margin As Integer = 30
                panelCard.Left = panelLeft.Right + margin
                panelCard.Top = (Me.ClientSize.Height - panelCard.Height) \ 2
            End If
            Try
                Dim r As Integer = 16
                Dim rect As Rectangle = panelCard.ClientRectangle
                Dim path As New Drawing2D.GraphicsPath()
                path.AddArc(rect.X, rect.Y, r, r, 180, 90)
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90)
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90)
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90)
                path.CloseFigure()
                panelCard.Region = New Region(path)
            Catch
            End Try
        End If

        ' Load logo if available
        Try
            Dim candidates = New String() {Path.Combine(Application.StartupPath, "thesisbuddy_logo.png"), Path.Combine(Application.StartupPath, "logo.png"), Path.Combine(Application.StartupPath, "assets", "logo.png")}
            For Each p As String In candidates
                If File.Exists(p) Then
                    Using src As Image = Image.FromFile(p)
                        PictureLogo.Image = New Bitmap(src)
                    End Using
                    PictureLogo.SizeMode = PictureBoxSizeMode.Zoom
                    Exit For
                End If
            Next
        Catch
        End Try

        ' Ensure questions table exists
        DatabaseHelper.EnsureQuestionsTable()

        ' Show step 1
        currentStep = 1
        ShowQuestionsForStep(currentStep)
    End Sub

    Private Sub ShowQuestionsForStep(step As Integer)
        FlowLayoutPanelQuestions.Controls.Clear()

        Dim questions = DatabaseHelper.GetQuestionsByStep(step)

        If questions Is Nothing OrElse questions.Count = 0 Then
            ' nothing for this step; show message and a Next/Submit
            Dim lbl As New Label With {.Text = "No questions configured for this step.", .ForeColor = Color.LightGray}
            FlowLayoutPanelQuestions.Controls.Add(lbl)
        Else
            For Each q In questions
                Dim lbl As New Label With {.Text = q.Prompt, .ForeColor = Color.LightGray}
                FlowLayoutPanelQuestions.Controls.Add(lbl)

                Dim typ = If(q.QType, "text").ToLower()
                Select Case typ
                    Case "text", "string"
                        Dim tb As New TextBox With {.Width = 360}
                        FlowLayoutPanelQuestions.Controls.Add(tb)
                        AddHandler tb.LostFocus, Sub(s, ev) answers(q.QKey) = tb.Text

                    Case "number"
                        Dim tbn As New TextBox With {.Width = 360}
                        FlowLayoutPanelQuestions.Controls.Add(tbn)
                        AddHandler tbn.LostFocus, Sub(s, ev)
                                                      Dim d As Double
                                                      If Double.TryParse(tbn.Text, d) Then
                                                          answers(q.QKey) = d
                                                      Else
                                                          answers(q.QKey) = 0.0
                                                      End If
                                                  End Sub

                    Case "kvlist"
                        ' key:value comma separated (used for interests/skills)
                        Dim tbk As New TextBox With {.Width = 360}
                        FlowLayoutPanelQuestions.Controls.Add(tbk)
                        AddHandler tbk.LostFocus, Sub(s, ev)
                                                      Dim dict As New Dictionary(Of String, Double)()
                                                      For Each part In tbk.Text.Split(","c)
                                                          Dim kv = part.Split({":"c}, 2)
                                                          If kv.Length = 2 Then
                                                              Dim k = kv(0).Trim()
                                                              Dim v As Double
                                                              If Double.TryParse(kv(1).Trim(), v) Then
                                                                  dict(k) = ExpertEngine.Normalize(v)
                                                              End If
                                                          End If
                                                      Next
                                                      answers(q.QKey) = dict
                                                  End Sub

                    Case "select"
                        Dim cb As New ComboBox With {.Width = 360}
                        If Not String.IsNullOrWhiteSpace(q.Options) Then
                            cb.Items.AddRange(q.Options.Split({","c}, StringSplitOptions.RemoveEmptyEntries))
                        End If
                        FlowLayoutPanelQuestions.Controls.Add(cb)
                        AddHandler cb.SelectedIndexChanged, Sub(s, ev) If cb.SelectedItem IsNot Nothing Then answers(q.QKey) = cb.SelectedItem.ToString()

                    Case "yesno"
                        Dim cbyn As New ComboBox With {.Width = 120}
                        cbyn.Items.AddRange(YESNO_OPTIONS)
                        FlowLayoutPanelQuestions.Controls.Add(cbyn)
                        AddHandler cbyn.SelectedIndexChanged, Sub(s, ev) If cbyn.SelectedItem IsNot Nothing Then answers(q.QKey) = cbyn.SelectedItem.ToString()

                    Case Else
                        ' fallback to text
                        Dim tbf As New TextBox With {.Width = 360}
                        FlowLayoutPanelQuestions.Controls.Add(tbf)
                        AddHandler tbf.LostFocus, Sub(s, ev) answers(q.QKey) = tbf.Text
                End Select
            Next
        End If

        ' Navigation controls
        Dim nav As New FlowLayoutPanel With {.FlowDirection = FlowDirection.LeftToRight, .Width = FlowLayoutPanelQuestions.Width}
        If step > 1 Then
            Dim btnPrev As New Button With {.Text = "Previous", .Width = 120}
            AddHandler btnPrev.Click, Sub(s, ev)
                                          currentStep = Math.Max(1, currentStep - 1)
                                          ShowQuestionsForStep(currentStep)
                                      End Sub
            nav.Controls.Add(btnPrev)
        End If

        ' Determine if there are next step questions
        Dim nextQuestions = DatabaseHelper.GetQuestionsByStep(step + 1)
        If nextQuestions IsNot Nothing AndAlso nextQuestions.Count > 0 Then
            Dim btnNext As New Button With {.Text = "Next", .Width = 120}
            AddHandler btnNext.Click, Sub(s, ev)
                                          currentStep += 1
                                          ShowQuestionsForStep(currentStep)
                                      End Sub
            nav.Controls.Add(btnNext)
        Else
            ' show submit
            Dim btnSubmit As New Button With {.Text = "Submit", .Width = 120}
            AddHandler btnSubmit.Click, AddressOf ButtonSubmit_Click
            nav.Controls.Add(btnSubmit)
        End If

        FlowLayoutPanelQuestions.Controls.Add(nav)
    End Sub

    Private Sub Skills_Changed(sender As Object, e As EventArgs)
        ' retained for backward compatibility if used
    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click
        ' Final gather: ensure necessary fields present
        If Not answers.ContainsKey("interests") Then
            MessageBox.Show("Please enter interests before submit.")
            Return
        End If
        If Not answers.ContainsKey("skills") Then
            MessageBox.Show("Please enter skills before submit.")
            Return
        End If

        Dim username As String = Environment.UserName
        Dim recs = ExpertEngine.Evaluate(answers)
        ExpertEngine.SaveConsultationToDb(username, answers, recs)

        ' Show results in a messagebox
        Dim sb As New StringBuilder()
        sb.AppendLine("Recommendations:")
        For Each r In recs
            sb.AppendLine("- " & r)
        Next
        MessageBox.Show(sb.ToString(), "Results")
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

End Class