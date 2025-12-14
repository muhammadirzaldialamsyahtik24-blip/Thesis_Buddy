Imports System.ComponentModel
Imports System.Linq

Public Class Admin
    Private showingHistory As Boolean = False
    Private consults As List(Of ConsultationRow) = New List(Of ConsultationRow)()
    Private Sub ButtonHistory_Click(sender As Object, e As EventArgs) Handles ButtonHistory.Click
        If showingHistory Then
            ShowQuestionsTable()
        Else
            ShowHistoryTable()
        End If
    End Sub

    Private Sub ShowHistoryTable()
        consults = DatabaseHelper.GetAllConsultations()
        showingHistory = True
        ConfigureHistoryGrid()
        Dim rows = consults.Select(Function(c) New ConsultationGridRow(c)).ToList()
        gridBinding.DataSource = rows
        LabelStatus.Text = $"{rows.Count} konsultasi ditampilkan"
        ButtonHistory.Text = "Lihat Pertanyaan"
    End Sub

    Private Sub ShowQuestionsTable()
        showingHistory = False
        ConfigureGrid()
        ApplyFilter()
        ButtonHistory.Text = "Cek History"
    End Sub

    Private Sub ConfigureHistoryGrid()
        GridQuestions.AutoGenerateColumns = False
        GridQuestions.Columns.Clear()
        GridQuestions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
        GridQuestions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        GridQuestions.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        GridQuestions.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        GridQuestions.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240)
        GridQuestions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246)
        GridQuestions.DefaultCellStyle.SelectionForeColor = Color.White
        GridQuestions.DefaultCellStyle.Font = New Font("Segoe UI", 10.0F)

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Id",
            .HeaderText = "ID",
            .Width = 60
        })
        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Username",
            .HeaderText = "Username",
            .Width = 120
        })
        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "TimestampStr",
            .HeaderText = "Waktu Konsultasi",
            .Width = 160
        })
        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Answers",
            .HeaderText = "Jawaban",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        })
        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Recommendations",
            .HeaderText = "Rekomendasi",
            .Width = 200
        })
    End Sub

    Private Class ConsultationGridRow
        Public Sub New(model As ConsultationRow)
            Id = model.Id
            Username = model.Username
            TimestampStr = model.Timestamp.ToString("dd MMM yyyy HH:mm")
            Answers = model.Answers
            Recommendations = model.Recommendations
        End Sub
        Public Property Id As Integer
        Public Property Username As String
        Public Property TimestampStr As String
        Public Property Answers As String
        Public Property Recommendations As String
    End Class
    Private questions As List(Of QuestionModel) = New List(Of QuestionModel)()
    Private ReadOnly gridBinding As New BindingSource()
    Private lastSync As DateTime?

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        ConfigureGrid()
        LoadQuestionsData()
    End Sub

    Private Sub ConfigureGrid()
        GridQuestions.AutoGenerateColumns = False
        GridQuestions.Columns.Clear()
        GridQuestions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
        GridQuestions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        GridQuestions.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        GridQuestions.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        GridQuestions.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240)
        GridQuestions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246)
        GridQuestions.DefaultCellStyle.SelectionForeColor = Color.White
        GridQuestions.DefaultCellStyle.Font = New Font("Segoe UI", 10.0F)

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "QKey",
            .HeaderText = "QKey",
            .Width = 110
        })

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Prompt",
            .HeaderText = "Prompt",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        })

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Category",
            .HeaderText = "Kategori",
            .Width = 110
        })

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "QuestionType",
            .HeaderText = "Tipe",
            .Width = 80
        })

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "StepLabel",
            .HeaderText = "Step",
            .Width = 60
        })

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Certainty",
            .HeaderText = "CF",
            .Width = 70
        })

        GridQuestions.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "ActiveText",
            .HeaderText = "Status",
            .Width = 90
        })

        GridQuestions.DataSource = gridBinding
    End Sub

    Private Sub LoadQuestionsData()
        Try
            questions = DatabaseHelper.GetAllQuestions()
            lastSync = DateTime.Now
            UpdateSummary()
            ApplyFilter()
        Catch ex As Exception
            MessageBox.Show($"Gagal memuat data: {ex.Message}", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error)
            questions = New List(Of QuestionModel)()
            gridBinding.DataSource = Nothing
        End Try
    End Sub

    Private Sub UpdateSummary()
        Dim total = questions.Count
        Dim active = questions.Where(Function(q) q.Active).Count()
        LabelStatQuestionsValue.Text = total.ToString("N0")
        LabelStatActiveValue.Text = active.ToString("N0")
        LabelStatSyncedValue.Text = If(lastSync.HasValue, lastSync.Value.ToString("dd MMM yyyy HH:mm"), "-")
    End Sub

    Private Sub ApplyFilter()
        Dim keyword = TextBoxSearch.Text.Trim()
        Dim filtered = questions

        If Not String.IsNullOrWhiteSpace(keyword) Then
            filtered = filtered.Where(Function(q) MatchesKeyword(q, keyword)).ToList()
        End If

        Dim rows = filtered.Select(Function(q) New QuestionRow(q)).ToList()
        gridBinding.DataSource = rows
        LabelStatus.Text = $"{rows.Count} pertanyaan ditampilkan"
    End Sub

    Private Function MatchesKeyword(q As QuestionModel, keyword As String) As Boolean
        Return (Not String.IsNullOrWhiteSpace(q.QKey) AndAlso q.QKey.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
               (Not String.IsNullOrWhiteSpace(q.Prompt) AndAlso q.Prompt.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
               (Not String.IsNullOrWhiteSpace(q.Category) AndAlso q.Category.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
    End Function

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub ButtonClearSearch_Click(sender As Object, e As EventArgs) Handles ButtonClearSearch.Click
        TextBoxSearch.Clear()
        TextBoxSearch.Focus()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        LoadQuestionsData()
    End Sub

    Private Sub ButtonSeed_Click(sender As Object, e As EventArgs) Handles ButtonSeed.Click
        Dim confirm = MessageBox.Show("Seed ulang bank pertanyaan McClelland? Data lama dengan rule_code akan ditimpa.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Cursor = Cursors.WaitCursor
        ButtonSeed.Enabled = False
        Try
            DatabaseHelper.SeedMcClellandQuestionnaire(True)
            MessageBox.Show("Seed selesai.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Seed gagal: {ex.Message}", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            ButtonSeed.Enabled = True
            LoadQuestionsData()
        End Try
    End Sub

    Private Sub ButtonToggleActive_Click(sender As Object, e As EventArgs) Handles ButtonToggleActive.Click
        Dim selected = GetSelectedQuestion()
        If selected Is Nothing Then
            MessageBox.Show("Pilih pertanyaan terlebih dahulu.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim target = Not selected.Active
        If DatabaseHelper.SetQuestionActiveState(selected.Id, target) Then
            LoadQuestionsData()
            MessageBox.Show($"Pertanyaan {selected.QKey} {(If(target, "diaktifkan", "dinonaktifkan"))}.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Gagal memperbarui status pertanyaan.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Application.Exit()
    End Sub

    Private Sub Admin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        MessageBox.Show("Fitur tambah pertanyaan manual akan tersedia pada iterasi berikutnya.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        Dim selected = GetSelectedQuestion()
        If selected Is Nothing Then
            MessageBox.Show("Pilih pertanyaan yang ingin diedit.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        MessageBox.Show($"Edit cepat belum tersedia. Gunakan seed file untuk memperbarui pertanyaan {selected.QKey}.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function GetSelectedQuestion() As QuestionModel
        If GridQuestions.CurrentRow Is Nothing Then Return Nothing
        Dim row = TryCast(GridQuestions.CurrentRow.DataBoundItem, QuestionRow)
        If row Is Nothing Then Return Nothing
        Return questions.FirstOrDefault(Function(q) q.Id = row.Id)
    End Function

    Private Class QuestionRow
        Public Sub New(model As QuestionModel)
            Id = model.Id
            QKey = model.QKey
            Prompt = model.Prompt
            QuestionType = If(String.IsNullOrWhiteSpace(model.QType), "-", model.QType)
            StepLabel = If(model.QStep = 0, "-", model.QStep.ToString())
            Category = If(String.IsNullOrWhiteSpace(model.Category), "-", model.Category)
            ActiveText = If(model.Active, "Aktif", "Nonaktif")
            Certainty = If(model.CertaintyFactor = 0, "-", model.CertaintyFactor.ToString("0.00"))
        End Sub

        Public Property Id As Integer
        Public Property QKey As String
        Public Property Prompt As String
        Public Property QuestionType As String
        Public Property StepLabel As String
        Public Property Category As String
        Public Property ActiveText As String
        Public Property Certainty As String
    End Class
End Class