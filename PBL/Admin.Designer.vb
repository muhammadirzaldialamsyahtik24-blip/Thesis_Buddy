<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents ButtonHistory As Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        TableLayoutPanelMain = New TableLayoutPanel()
        PanelHeader = New Panel()
        LabelSubtitle = New Label()
        LabelTitle = New Label()
        FlowSummary = New FlowLayoutPanel()
        PanelStatQuestions = New Panel()
        LabelStatQuestionsValue = New Label()
        LabelStatQuestionsTitle = New Label()
        PanelStatActive = New Panel()
        LabelStatActiveValue = New Label()
        LabelStatActiveTitle = New Label()
        PanelStatSynced = New Panel()
        LabelStatSyncedValue = New Label()
        LabelStatSyncedTitle = New Label()
        PanelFilters = New FlowLayoutPanel()
        TextBoxSearch = New TextBox()
        ButtonClearSearch = New Button()
        ButtonRefresh = New Button()
        ButtonSeed = New Button()
        ButtonHistory = New Button()
        GridQuestions = New DataGridView()
        TableLayoutPanelFooter = New TableLayoutPanel()
        LabelStatus = New Label()
        FlowActions = New FlowLayoutPanel()
        ButtonAdd = New Button()
        ButtonEdit = New Button()
        ButtonToggleActive = New Button()
        ButtonClose = New Button()
        TableLayoutPanelMain.SuspendLayout()
        PanelHeader.SuspendLayout()
        FlowSummary.SuspendLayout()
        PanelStatQuestions.SuspendLayout()
        PanelStatActive.SuspendLayout()
        PanelStatSynced.SuspendLayout()
        PanelFilters.SuspendLayout()
        CType(GridQuestions, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanelFooter.SuspendLayout()
        FlowActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanelMain
        ' 
        TableLayoutPanelMain.BackColor = Color.FromArgb(13, 17, 33)
        TableLayoutPanelMain.ColumnCount = 1
        TableLayoutPanelMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanelMain.Controls.Add(PanelHeader, 0, 0)
        TableLayoutPanelMain.Controls.Add(FlowSummary, 0, 1)
        TableLayoutPanelMain.Controls.Add(PanelFilters, 0, 2)
        TableLayoutPanelMain.Controls.Add(GridQuestions, 0, 3)
        TableLayoutPanelMain.Controls.Add(TableLayoutPanelFooter, 0, 4)
        TableLayoutPanelMain.Dock = DockStyle.Fill
        TableLayoutPanelMain.Padding = New Padding(32, 32, 32, 24)
        TableLayoutPanelMain.RowCount = 5
        TableLayoutPanelMain.RowStyles.Add(New RowStyle())
        TableLayoutPanelMain.RowStyles.Add(New RowStyle())
        TableLayoutPanelMain.RowStyles.Add(New RowStyle())
        TableLayoutPanelMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanelMain.RowStyles.Add(New RowStyle())
        TableLayoutPanelMain.Size = New Size(1200, 800)
        TableLayoutPanelMain.TabIndex = 0
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(26, 34, 54)
        PanelHeader.Controls.Add(LabelSubtitle)
        PanelHeader.Controls.Add(LabelTitle)
        PanelHeader.Dock = DockStyle.Fill
        PanelHeader.Margin = New Padding(0, 0, 0, 16)
        PanelHeader.Padding = New Padding(32, 28, 32, 28)
        PanelHeader.Size = New Size(1136, 108)
        PanelHeader.TabIndex = 0
        ' 
        ' LabelSubtitle
        ' 
        LabelSubtitle.AutoSize = True
        LabelSubtitle.Font = New Font("Segoe UI", 11.5F, FontStyle.Italic)
        LabelSubtitle.ForeColor = Color.FromArgb(203, 213, 225)
        LabelSubtitle.Location = New Point(32, 64)
        LabelSubtitle.Name = "LabelSubtitle"
        LabelSubtitle.Size = New Size(415, 19)
        LabelSubtitle.TabIndex = 1
        LabelSubtitle.Text = "Kelola bank pertanyaan, seed data, dan pantau konsultasi terbaru"
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 28.0F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.FromArgb(59, 130, 246)
        LabelTitle.Location = New Point(28, 16)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(281, 41)
        LabelTitle.TabIndex = 0
        LabelTitle.Text = "ThesisBuddy Admin"
        ' 
        ' FlowSummary
        ' 
        FlowSummary.AutoSize = True
        FlowSummary.BackColor = Color.Transparent
        FlowSummary.Controls.Add(PanelStatQuestions)
        FlowSummary.Controls.Add(PanelStatActive)
        FlowSummary.Controls.Add(PanelStatSynced)
        FlowSummary.Dock = DockStyle.Fill
        FlowSummary.FlowDirection = FlowDirection.LeftToRight
        FlowSummary.Location = New Point(32, 140)
        FlowSummary.Margin = New Padding(0, 0, 0, 18)
        FlowSummary.Name = "FlowSummary"
        FlowSummary.Size = New Size(1136, 112)
        FlowSummary.TabIndex = 1
        FlowSummary.WrapContents = False
        ' 
        ' PanelStatQuestions
        ' 
        PanelStatQuestions.BackColor = Color.FromArgb(37, 49, 72)
        PanelStatQuestions.Controls.Add(LabelStatQuestionsValue)
        PanelStatQuestions.Controls.Add(LabelStatQuestionsTitle)
        PanelStatQuestions.Margin = New Padding(0, 0, 18, 0)
        PanelStatQuestions.Padding = New Padding(22, 20, 22, 20)
        PanelStatQuestions.Size = New Size(270, 112)
        PanelStatQuestions.TabIndex = 0
        ' 
        ' LabelStatQuestionsValue
        ' 
        LabelStatQuestionsValue.AutoSize = True
        LabelStatQuestionsValue.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        LabelStatQuestionsValue.ForeColor = Color.FromArgb(96, 165, 250)
        LabelStatQuestionsValue.Location = New Point(20, 46)
        LabelStatQuestionsValue.Name = "LabelStatQuestionsValue"
        LabelStatQuestionsValue.Size = New Size(46, 37)
        LabelStatQuestionsValue.TabIndex = 1
        LabelStatQuestionsValue.Text = "-"
        ' 
        ' LabelStatQuestionsTitle
        ' 
        LabelStatQuestionsTitle.AutoSize = True
        LabelStatQuestionsTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Italic)
        LabelStatQuestionsTitle.ForeColor = Color.FromArgb(203, 213, 225)
        LabelStatQuestionsTitle.Location = New Point(22, 14)
        LabelStatQuestionsTitle.Name = "LabelStatQuestionsTitle"
        LabelStatQuestionsTitle.Size = New Size(128, 19)
        LabelStatQuestionsTitle.TabIndex = 0
        LabelStatQuestionsTitle.Text = "Total Pertanyaan"
        ' 
        ' PanelStatActive
        ' 
        PanelStatActive.BackColor = Color.FromArgb(37, 49, 72)
        PanelStatActive.Controls.Add(LabelStatActiveValue)
        PanelStatActive.Controls.Add(LabelStatActiveTitle)
        PanelStatActive.Margin = New Padding(0, 0, 18, 0)
        PanelStatActive.Padding = New Padding(22, 20, 22, 20)
        PanelStatActive.Size = New Size(270, 112)
        PanelStatActive.TabIndex = 1
        ' 
        ' LabelStatActiveValue
        ' 
        LabelStatActiveValue.AutoSize = True
        LabelStatActiveValue.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        LabelStatActiveValue.ForeColor = Color.FromArgb(96, 165, 250)
        LabelStatActiveValue.Location = New Point(20, 46)
        LabelStatActiveValue.Name = "LabelStatActiveValue"
        LabelStatActiveValue.Size = New Size(46, 37)
        LabelStatActiveValue.TabIndex = 1
        LabelStatActiveValue.Text = "-"
        ' 
        ' LabelStatActiveTitle
        ' 
        LabelStatActiveTitle.AutoSize = True
        LabelStatActiveTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Italic)
        LabelStatActiveTitle.ForeColor = Color.FromArgb(203, 213, 225)
        LabelStatActiveTitle.Location = New Point(22, 14)
        LabelStatActiveTitle.Name = "LabelStatActiveTitle"
        LabelStatActiveTitle.Size = New Size(129, 19)
        LabelStatActiveTitle.TabIndex = 0
        LabelStatActiveTitle.Text = "Pertanyaan Aktif"
        ' 
        ' PanelStatSynced
        ' 
        PanelStatSynced.BackColor = Color.FromArgb(37, 49, 72)
        PanelStatSynced.Controls.Add(LabelStatSyncedValue)
        PanelStatSynced.Controls.Add(LabelStatSyncedTitle)
        PanelStatSynced.Margin = New Padding(0)
        PanelStatSynced.Padding = New Padding(22, 20, 22, 20)
        PanelStatSynced.Size = New Size(356, 112)
        PanelStatSynced.TabIndex = 2
        ' 
        ' LabelStatSyncedValue
        ' 
        LabelStatSyncedValue.AutoSize = True
        LabelStatSyncedValue.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        LabelStatSyncedValue.ForeColor = Color.FromArgb(96, 165, 250)
        LabelStatSyncedValue.Location = New Point(20, 46)
        LabelStatSyncedValue.Name = "LabelStatSyncedValue"
        LabelStatSyncedValue.Size = New Size(46, 37)
        LabelStatSyncedValue.TabIndex = 1
        LabelStatSyncedValue.Text = "-"
        ' 
        ' LabelStatSyncedTitle
        ' 
        LabelStatSyncedTitle.AutoSize = True
        LabelStatSyncedTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Italic)
        LabelStatSyncedTitle.ForeColor = Color.FromArgb(203, 213, 225)
        LabelStatSyncedTitle.Location = New Point(22, 14)
        LabelStatSyncedTitle.Name = "LabelStatSyncedTitle"
        LabelStatSyncedTitle.Size = New Size(158, 19)
        LabelStatSyncedTitle.TabIndex = 0
        LabelStatSyncedTitle.Text = "Sinkronisasi Terakhir"
        ' 
        ' PanelFilters
        ' 
        PanelFilters.AutoSize = True
        PanelFilters.BackColor = Color.Transparent
        PanelFilters.Controls.Add(TextBoxSearch)
        PanelFilters.Controls.Add(ButtonClearSearch)
        PanelFilters.Controls.Add(ButtonRefresh)
        PanelFilters.Controls.Add(ButtonSeed)
        ButtonHistory = New Button()
        ButtonHistory.BackColor = Color.FromArgb(59, 130, 246)
        ButtonHistory.FlatAppearance.BorderSize = 0
        ButtonHistory.FlatStyle = FlatStyle.Flat
        ButtonHistory.ForeColor = Color.White
        ButtonHistory.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonHistory.Location = New Point(736, 0)
        ButtonHistory.Margin = New Padding(12, 0, 0, 0)
        ButtonHistory.Name = "ButtonHistory"
        ButtonHistory.Size = New Size(120, 32)
        ButtonHistory.TabIndex = 4
        ButtonHistory.Text = "Cek History"
        ButtonHistory.UseVisualStyleBackColor = False
        ButtonHistory.Cursor = Cursors.Hand
        PanelFilters.Controls.Add(ButtonHistory)
        PanelFilters.Dock = DockStyle.Fill
        PanelFilters.Location = New Point(32, 270)
        PanelFilters.Margin = New Padding(0, 0, 0, 12)
        PanelFilters.Name = "PanelFilters"
        PanelFilters.Size = New Size(1136, 44)
        PanelFilters.TabIndex = 2
        PanelFilters.WrapContents = False
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.BackColor = Color.FromArgb(30, 41, 59)
        TextBoxSearch.BorderStyle = BorderStyle.FixedSingle
        TextBoxSearch.Font = New Font("Segoe UI", 11.0F)
        TextBoxSearch.ForeColor = Color.White
        TextBoxSearch.Location = New Point(0, 0)
        TextBoxSearch.Margin = New Padding(0, 0, 12, 0)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.PlaceholderText = "Cari qkey, prompt, atau kategori..."
        TextBoxSearch.Size = New Size(340, 27)
        TextBoxSearch.TabIndex = 0
        ' 
        ' ButtonClearSearch
        ' 
        ButtonClearSearch.BackColor = Color.FromArgb(45, 55, 72)
        ButtonClearSearch.FlatAppearance.BorderSize = 0
        ButtonClearSearch.FlatStyle = FlatStyle.Flat
        ButtonClearSearch.ForeColor = Color.FromArgb(226, 232, 240)
        ButtonClearSearch.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonClearSearch.Location = New Point(352, 0)
        ButtonClearSearch.Margin = New Padding(0, 0, 12, 0)
        ButtonClearSearch.Name = "ButtonClearSearch"
        ButtonClearSearch.Size = New Size(90, 32)
        ButtonClearSearch.TabIndex = 1
        ButtonClearSearch.Text = "Bersihkan"
        ButtonClearSearch.UseVisualStyleBackColor = False
        ButtonClearSearch.Cursor = Cursors.Hand
        ' 
        ' ButtonRefresh
        ' 
        ButtonRefresh.BackColor = Color.FromArgb(59, 72, 99)
        ButtonRefresh.FlatAppearance.BorderSize = 0
        ButtonRefresh.FlatStyle = FlatStyle.Flat
        ButtonRefresh.ForeColor = Color.FromArgb(226, 232, 240)
        ButtonRefresh.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonRefresh.Location = New Point(454, 0)
        ButtonRefresh.Margin = New Padding(0, 0, 12, 0)
        ButtonRefresh.Name = "ButtonRefresh"
        ButtonRefresh.Size = New Size(110, 32)
        ButtonRefresh.TabIndex = 2
        ButtonRefresh.Text = "Refresh"
        ButtonRefresh.UseVisualStyleBackColor = False
        ButtonRefresh.Cursor = Cursors.Hand
        ' 
        ' ButtonSeed
        ' 
        ButtonSeed.BackColor = Color.FromArgb(37, 161, 142)
        ButtonSeed.FlatAppearance.BorderSize = 0
        ButtonSeed.FlatStyle = FlatStyle.Flat
        ButtonSeed.ForeColor = Color.White
        ButtonSeed.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonSeed.Location = New Point(576, 0)
        ButtonSeed.Margin = New Padding(0)
        ButtonSeed.Name = "ButtonSeed"
        ButtonSeed.Size = New Size(150, 32)
        ButtonSeed.TabIndex = 3
        ButtonSeed.Text = "Seed Question Bank"
        ButtonSeed.UseVisualStyleBackColor = False
        ButtonSeed.Cursor = Cursors.Hand
        ' 
        ' GridQuestions
        ' 
        GridQuestions.AllowUserToAddRows = False
        GridQuestions.AllowUserToDeleteRows = False
        GridQuestions.AllowUserToResizeRows = False
        GridQuestions.BackgroundColor = Color.FromArgb(24, 32, 52)
        GridQuestions.BorderStyle = BorderStyle.None
        GridQuestions.ColumnHeadersHeight = 40
        GridQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        GridQuestions.Dock = DockStyle.Fill
        GridQuestions.EnableHeadersVisualStyles = False
        GridQuestions.GridColor = Color.FromArgb(59, 130, 246)
        GridQuestions.Location = New Point(32, 326)
        GridQuestions.Margin = New Padding(0, 0, 0, 16)
        GridQuestions.MultiSelect = False
        GridQuestions.Name = "GridQuestions"
        GridQuestions.ReadOnly = True
        GridQuestions.RowHeadersVisible = False
        GridQuestions.RowTemplate.Height = 36
        GridQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        GridQuestions.Size = New Size(1136, 408)
        GridQuestions.TabIndex = 3
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.FromArgb(26, 34, 54)
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(226, 232, 240)
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(79, 70, 229)
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        GridQuestions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(226, 232, 240)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(79, 70, 229)
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        GridQuestions.DefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.BackColor = Color.FromArgb(24, 32, 52)
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(148, 163, 184)
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(79, 70, 229)
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        GridQuestions.RowsDefaultCellStyle = DataGridViewCellStyle3
        GridQuestions.RowTemplate.DefaultCellStyle.Padding = New Padding(6, 0, 6, 0)
        ' 
        ' TableLayoutPanelFooter
        ' 
        TableLayoutPanelFooter.ColumnCount = 2
        TableLayoutPanelFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanelFooter.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanelFooter.Controls.Add(LabelStatus, 0, 0)
        TableLayoutPanelFooter.Controls.Add(FlowActions, 1, 0)
        TableLayoutPanelFooter.Dock = DockStyle.Fill
        TableLayoutPanelFooter.Location = New Point(32, 748)
        TableLayoutPanelFooter.Margin = New Padding(0)
        TableLayoutPanelFooter.Name = "TableLayoutPanelFooter"
        TableLayoutPanelFooter.RowCount = 1
        TableLayoutPanelFooter.RowStyles.Add(New RowStyle())
        TableLayoutPanelFooter.Size = New Size(1136, 36)
        TableLayoutPanelFooter.TabIndex = 4
        ' 
        ' LabelStatus
        ' 
        LabelStatus.AutoSize = True
        LabelStatus.Dock = DockStyle.Fill
        LabelStatus.Font = New Font("Segoe UI", 10.0F, FontStyle.Italic)
        LabelStatus.ForeColor = Color.FromArgb(203, 213, 225)
        LabelStatus.Location = New Point(0, 0)
        LabelStatus.Margin = New Padding(0)
        LabelStatus.Name = "LabelStatus"
        LabelStatus.Padding = New Padding(0, 8, 0, 0)
        LabelStatus.Size = New Size(576, 36)
        LabelStatus.TabIndex = 0
        LabelStatus.Text = "-"
        ' 
        ' FlowActions
        ' 
        FlowActions.AutoSize = True
        FlowActions.BackColor = Color.Transparent
        FlowActions.Controls.Add(ButtonAdd)
        FlowActions.Controls.Add(ButtonEdit)
        FlowActions.Controls.Add(ButtonToggleActive)
        FlowActions.Controls.Add(ButtonClose)
        FlowActions.Dock = DockStyle.Right
        FlowActions.FlowDirection = FlowDirection.RightToLeft
        FlowActions.Location = New Point(704, 0)
        FlowActions.Margin = New Padding(0)
        FlowActions.Name = "FlowActions"
        FlowActions.Size = New Size(444, 36)
        FlowActions.TabIndex = 1
        ' 
        ' ButtonAdd
        ' 
        ButtonAdd.BackColor = Color.FromArgb(59, 130, 246)
        ButtonAdd.FlatAppearance.BorderSize = 0
        ButtonAdd.FlatStyle = FlatStyle.Flat
        ButtonAdd.ForeColor = Color.White
        ButtonAdd.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonAdd.Location = New Point(350, 0)
        ButtonAdd.Margin = New Padding(0, 0, 12, 0)
        ButtonAdd.Name = "ButtonAdd"
        ButtonAdd.Size = New Size(90, 32)
        ButtonAdd.TabIndex = 0
        ButtonAdd.Text = "Tambah"
        ButtonAdd.UseVisualStyleBackColor = False
        ButtonAdd.Cursor = Cursors.Hand
        ' 
        ' ButtonEdit
        ' 
        ButtonEdit.BackColor = Color.FromArgb(37, 99, 235)
        ButtonEdit.FlatAppearance.BorderSize = 0
        ButtonEdit.FlatStyle = FlatStyle.Flat
        ButtonEdit.ForeColor = Color.White
        ButtonEdit.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonEdit.Location = New Point(248, 0)
        ButtonEdit.Margin = New Padding(0, 0, 12, 0)
        ButtonEdit.Name = "ButtonEdit"
        ButtonEdit.Size = New Size(90, 32)
        ButtonEdit.TabIndex = 1
        ButtonEdit.Text = "Edit"
        ButtonEdit.UseVisualStyleBackColor = False
        ButtonEdit.Cursor = Cursors.Hand
        ' 
        ' ButtonToggleActive
        ' 
        ButtonToggleActive.BackColor = Color.FromArgb(45, 55, 72)
        ButtonToggleActive.FlatAppearance.BorderSize = 0
        ButtonToggleActive.FlatStyle = FlatStyle.Flat
        ButtonToggleActive.ForeColor = Color.FromArgb(226, 232, 240)
        ButtonToggleActive.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonToggleActive.Location = New Point(106, 0)
        ButtonToggleActive.Margin = New Padding(0, 0, 12, 0)
        ButtonToggleActive.Name = "ButtonToggleActive"
        ButtonToggleActive.Size = New Size(130, 32)
        ButtonToggleActive.TabIndex = 2
        ButtonToggleActive.Text = "Aktifkan/Nonaktif"
        ButtonToggleActive.UseVisualStyleBackColor = False
        ButtonToggleActive.Cursor = Cursors.Hand
        ' 
        ' ButtonClose
        ' 
        ButtonClose.BackColor = Color.FromArgb(239, 68, 68)
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.ForeColor = Color.White
        ButtonClose.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ButtonClose.Location = New Point(0, 0)
        ButtonClose.Margin = New Padding(0)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(110, 32)
        ButtonClose.TabIndex = 3
        ButtonClose.Text = "Tutup"
        ButtonClose.UseVisualStyleBackColor = False
        ButtonClose.Cursor = Cursors.Hand
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(13, 17, 33)
        ClientSize = New Size(1200, 800)
        Controls.Add(TableLayoutPanelMain)
        Font = New Font("Segoe UI", 10.0F)
        ForeColor = Color.White
        MinimumSize = New Size(1100, 720)
        Name = "Admin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin - ThesisBuddy"
        TableLayoutPanelMain.ResumeLayout(False)
        TableLayoutPanelMain.PerformLayout()
        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        FlowSummary.ResumeLayout(False)
        PanelStatQuestions.ResumeLayout(False)
        PanelStatQuestions.PerformLayout()
        PanelStatActive.ResumeLayout(False)
        PanelStatActive.PerformLayout()
        PanelStatSynced.ResumeLayout(False)
        PanelStatSynced.PerformLayout()
        PanelFilters.ResumeLayout(False)
        PanelFilters.PerformLayout()
        CType(GridQuestions, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanelFooter.ResumeLayout(False)
        TableLayoutPanelFooter.PerformLayout()
        FlowActions.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanelMain As TableLayoutPanel
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents LabelSubtitle As Label
    Friend WithEvents LabelTitle As Label
    Friend WithEvents FlowSummary As FlowLayoutPanel
    Friend WithEvents PanelStatQuestions As Panel
    Friend WithEvents LabelStatQuestionsValue As Label
    Friend WithEvents LabelStatQuestionsTitle As Label
    Friend WithEvents PanelStatActive As Panel
    Friend WithEvents LabelStatActiveValue As Label
    Friend WithEvents LabelStatActiveTitle As Label
    Friend WithEvents PanelStatSynced As Panel
    Friend WithEvents LabelStatSyncedValue As Label
    Friend WithEvents LabelStatSyncedTitle As Label
    Friend WithEvents PanelFilters As FlowLayoutPanel
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents ButtonClearSearch As Button
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents ButtonSeed As Button
    Friend WithEvents GridQuestions As DataGridView
    Friend WithEvents TableLayoutPanelFooter As TableLayoutPanel
    Friend WithEvents LabelStatus As Label
    Friend WithEvents FlowActions As FlowLayoutPanel
    Friend WithEvents ButtonAdd As Button
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents ButtonToggleActive As Button
    Friend WithEvents ButtonClose As Button
End Class
