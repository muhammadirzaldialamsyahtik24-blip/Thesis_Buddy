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

    Private answers As New Dictionary(Of String, Object)()
    Private currentStep As Integer = 1

    Private Sub Question_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rounded card and position
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

        ' Adjust logo size to fit panel left
        Try
            If PictureLogo.Image IsNot Nothing Then
                PictureLogo.SizeMode = PictureBoxSizeMode.Zoom
                ' ensure it fits within padding
                Dim pad = PanelLeft.Padding.All
                PictureLogo.Width = Math.Max(100, PanelLeft.ClientSize.Width - pad * 2)
                PictureLogo.Height = Math.Max(100, PanelLeft.ClientSize.Height - pad * 2)
                PictureLogo.Left = PanelLeft.Padding.Left
                PictureLogo.Top = PanelLeft.Padding.Top
            End If
        Catch
        End Try

        ' Make FlowLayoutPanel resize with card
        FlowLayoutPanelQuestions.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        DatabaseHelper.EnsureQuestionsTable()
        currentStep = 1
        ShowQuestionsForStep(currentStep)
    End Sub

    Private Function ControlWidth() As Integer
        Dim w = FlowLayoutPanelQuestions.ClientSize.Width - FlowLayoutPanelQuestions.Padding.Horizontal - 10
        If w < 100 Then w = 100
        Return w
    End Function

    Private Sub ShowQuestionsForStep(step As Integer)
        FlowLayoutPanelQuestions.Controls.Clear()
        PanelNav.Controls.Clear()

        Dim questions = DatabaseHelper.GetQuestionsByStep(step)
        If questions Is Nothing OrElse questions.Count = 0 Then
            Dim lbl As New Label With {.Text = "Tidak ada pertanyaan di langkah ini.", .ForeColor = Color.LightGray, .AutoSize = True}
            FlowLayoutPanelQuestions.Controls.Add(lbl)
        Else
            For Each q In questions
                Dim lbl As New Label With {.Text = q.Prompt, .ForeColor = Color.LightGray, .AutoSize = False, .Width = ControlWidth(), .Height = 20}
                FlowLayoutPanelQuestions.Controls.Add(lbl)

                Dim typ = If(q.QType, "text").ToLower()
                Select Case typ
                    Case "text", "string"
                        Dim tb As New TextBox With {.Width = ControlWidth()}
                        FlowLayoutPanelQuestions.Controls.Add(tb)
                        AddHandler tb.LostFocus, Sub(s, ev) answers(q.QKey) = tb.Text

                    Case "number"
                        Dim tbn As New TextBox With {.Width = ControlWidth()}
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
                        Dim tbk As New TextBox With {.Width = ControlWidth()}
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
                        Dim cb As New ComboBox With {.Width = ControlWidth()}
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
                        Dim tbf As New TextBox With {.Width = ControlWidth()}
                        FlowLayoutPanelQuestions.Controls.Add(tbf)
                        AddHandler tbf.LostFocus, Sub(s, ev) answers(q.QKey) = tbf.Text
                End Select

                Dim spacer As New Label With {.Height = 8, .AutoSize = False}
                FlowLayoutPanelQuestions.Controls.Add(spacer)
            Next
        End If

        ' Navigation
        If step > 1 Then
            Dim btnPrev As New Button With {.Text = "Previous", .Width = 120}
            AddHandler btnPrev.Click, Sub(s, ev)
                                          currentStep = Math.Max(1, currentStep - 1)
                                          ShowQuestionsForStep(currentStep)
                                      End Sub
            btnPrev.Margin = New Padding(6)
            PanelNav.Controls.Add(btnPrev)
        End If

        Dim nextQuestions = DatabaseHelper.GetQuestionsByStep(step + 1)
        If nextQuestions IsNot Nothing AndAlso nextQuestions.Count > 0 Then
            Dim btnNext As New Button With {.Text = "Next", .Width = 120}
            AddHandler btnNext.Click, Sub(s, ev)
                                          currentStep += 1
                                          ShowQuestionsForStep(currentStep)
                                      End Sub
            btnNext.Margin = New Padding(6)
            PanelNav.Controls.Add(btnNext)
        Else
            Dim btnSubmit As New Button With {.Text = "Submit", .Width = 120}
            AddHandler btnSubmit.Click, AddressOf ButtonSubmit_Click
            btnSubmit.Margin = New Padding(6)
            PanelNav.Controls.Add(btnSubmit)
        End If

        ' Align nav to right
        PanelNav.Controls.Add(New Label() With {.Width = Math.Max(0, PanelNav.Width - PanelNav.Controls.Cast(Of Control)().Sum(Function(c) c.Width + c.Margin.Horizontal))})

    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs)
        If Not answers.ContainsKey("interests") Then
            MessageBox.Show("Silakan isi minat terlebih dahulu.")
            Return
        End If
        If Not answers.ContainsKey("skills") Then
            MessageBox.Show("Silakan isi skill terlebih dahulu.")
            Return
        End If

        Dim username As String = Environment.UserName
        Dim recs = ExpertEngine.Evaluate(answers)
        ExpertEngine.SaveConsultationToDb(username, answers, recs)

        Dim sb As New StringBuilder()
        sb.AppendLine("Rekomendasi:")
        For Each r In recs
            sb.AppendLine("- " & r)
        Next
        MessageBox.Show(sb.ToString(), "Hasil")
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

End Class