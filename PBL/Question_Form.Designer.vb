<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Question_Form
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

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelLogoContainer = New Panel()
        PictureLogo = New PictureBox()
        PanelCard = New Panel()
        PanelQuestionsHost = New Panel()
        PanelScrollTrack = New Panel()
        PanelScrollThumb = New Panel()
        FlowLayoutPanelQuestions = New BufferedFlowLayoutPanel()
        LabelTitle = New Label()
        LabelSubtitle = New Label()
        PanelNav = New FlowLayoutPanel()
        ButtonSubmit = New Button()
        ButtonCancel = New Button()
        PanelLogoContainer.SuspendLayout()
        CType(PictureLogo, ComponentModel.ISupportInitialize).BeginInit()
        PanelCard.SuspendLayout()
        PanelQuestionsHost.SuspendLayout()
        PanelScrollTrack.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelLogoContainer
        ' 
        PanelLogoContainer.BackColor = Color.White
        PanelLogoContainer.Controls.Add(PictureLogo)
        PanelLogoContainer.Location = New Point(40, 24)
        PanelLogoContainer.Name = "PanelLogoContainer"
        PanelLogoContainer.Padding = New Padding(16)
        PanelLogoContainer.Size = New Size(112, 112)
        PanelLogoContainer.TabIndex = 1
        ' 
        ' PictureLogo
        ' 
        PictureLogo.BackColor = Color.Transparent
        PictureLogo.Dock = DockStyle.Fill
        PictureLogo.Image = My.Resources.Resources.thesisbuddy_logo
        PictureLogo.Name = "PictureLogo"
        PictureLogo.Size = New Size(80, 80)
        PictureLogo.SizeMode = PictureBoxSizeMode.Zoom
        PictureLogo.TabIndex = 0
        PictureLogo.TabStop = False
        ' 
        ' PanelCard
        ' 
        PanelCard.Dock = DockStyle.Fill
        PanelCard.BackColor = Color.White
        PanelCard.Controls.Add(PanelQuestionsHost)
        PanelCard.Controls.Add(LabelTitle)
        PanelCard.Controls.Add(LabelSubtitle)
        PanelCard.Controls.Add(ButtonSubmit)
        PanelCard.Controls.Add(ButtonCancel)
        PanelCard.Controls.Add(PanelNav)
        PanelCard.Controls.Add(PanelLogoContainer)
        PanelCard.Location = New Point(0, 0)
        PanelCard.Name = "PanelCard"
        PanelCard.Padding = New Padding(40, 32, 40, 32)
        PanelCard.Size = New Size(967, 640)
        PanelCard.TabIndex = 2
        ' 
        ' PanelQuestionsHost
        ' 
        PanelQuestionsHost.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PanelQuestionsHost.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        PanelQuestionsHost.Controls.Add(FlowLayoutPanelQuestions)
        PanelQuestionsHost.Controls.Add(PanelScrollTrack)
        PanelQuestionsHost.Location = New Point(56, 156)
        PanelQuestionsHost.Name = "PanelQuestionsHost"
        PanelQuestionsHost.Padding = New Padding(0)
        PanelQuestionsHost.Margin = New Padding(0, 0, 0, 16)
        PanelQuestionsHost.Size = New Size(855, 380)
        PanelQuestionsHost.TabIndex = 8
        ' 
        ' PanelScrollTrack
        ' 
        PanelScrollTrack.BackColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        PanelScrollTrack.Controls.Add(PanelScrollThumb)
        PanelScrollTrack.Dock = DockStyle.Right
        PanelScrollTrack.Location = New Point(835, 0)
        PanelScrollTrack.Name = "PanelScrollTrack"
        PanelScrollTrack.Padding = New Padding(3, 20, 3, 20)
        PanelScrollTrack.Size = New Size(20, 408)
        PanelScrollTrack.Visible = False
        PanelScrollTrack.TabIndex = 1
        ' 
        ' PanelScrollThumb
        ' 
        PanelScrollThumb.BackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        PanelScrollThumb.BorderStyle = BorderStyle.None
        PanelScrollThumb.Cursor = Cursors.Hand
        PanelScrollThumb.Location = New Point(4, 20)
        PanelScrollThumb.Name = "PanelScrollThumb"
        PanelScrollThumb.Size = New Size(12, 90)
        PanelScrollThumb.TabIndex = 0
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 26.0F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.FromArgb(CByte(37), CByte(99), CByte(235))
        LabelTitle.Location = New Point(156, 32)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(345, 41)
        LabelTitle.TabIndex = 3
        LabelTitle.Text = "Motivation Assessment"
        ' 
        ' LabelSubtitle
        ' 
        LabelSubtitle.AutoSize = True
        LabelSubtitle.BackColor = Color.Transparent
        LabelSubtitle.Font = New Font("Segoe UI", 12.0F)
        LabelSubtitle.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        LabelSubtitle.Location = New Point(156, 86)
        LabelSubtitle.Name = "LabelSubtitle"
        LabelSubtitle.Size = New Size(380, 21)
        LabelSubtitle.TabIndex = 4
        LabelSubtitle.Text = "Answer all questions to get your thesis recommendation"
        ' 
        ' FlowLayoutPanelQuestions
        ' 
        FlowLayoutPanelQuestions.Dock = DockStyle.Fill
        FlowLayoutPanelQuestions.AutoScroll = True
        FlowLayoutPanelQuestions.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        FlowLayoutPanelQuestions.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanelQuestions.Name = "FlowLayoutPanelQuestions"
        FlowLayoutPanelQuestions.Padding = New Padding(24, 20, 12, 20)
        FlowLayoutPanelQuestions.Size = New Size(835, 408)
        FlowLayoutPanelQuestions.TabIndex = 5
        FlowLayoutPanelQuestions.WrapContents = False
        ' 
        ' PanelNav
        ' 
        PanelNav.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        PanelNav.Dock = DockStyle.Bottom
        PanelNav.FlowDirection = FlowDirection.LeftToRight
        PanelNav.Location = New Point(40, 552)
        PanelNav.Margin = New Padding(0)
        PanelNav.Name = "PanelNav"
        PanelNav.Padding = New Padding(16, 12, 16, 12)
        PanelNav.Size = New Size(887, 88)
        PanelNav.TabIndex = 7
        PanelNav.WrapContents = False
        ' 
        ' ButtonSubmit
        ' 
        ButtonSubmit.BackColor = Color.FromArgb(CByte(37), CByte(99), CByte(235))
        ButtonSubmit.Cursor = Cursors.Hand
        ButtonSubmit.FlatAppearance.BorderSize = 0
        ButtonSubmit.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(64), CByte(175))
        ButtonSubmit.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(29), CByte(78), CByte(216))
        ButtonSubmit.FlatStyle = FlatStyle.Flat
        ButtonSubmit.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ButtonSubmit.ForeColor = Color.White
        ButtonSubmit.Location = New Point(600, 576)
        ButtonSubmit.Name = "ButtonSubmit"
        ButtonSubmit.Size = New Size(196, 52)
        ButtonSubmit.TabIndex = 6
        ButtonSubmit.Text = "Submit Answers"
        ButtonSubmit.UseVisualStyleBackColor = False
        ButtonSubmit.Visible = False
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.BackColor = Color.White
        ButtonCancel.Cursor = Cursors.Hand
        ButtonCancel.FlatAppearance.BorderColor = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        ButtonCancel.FlatAppearance.BorderSize = 2
        ButtonCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(254), CByte(226), CByte(226))
        ButtonCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(254), CByte(242), CByte(242))
        ButtonCancel.FlatStyle = FlatStyle.Flat
        ButtonCancel.Font = New Font("Segoe UI", 12.5F, FontStyle.Bold)
        ButtonCancel.ForeColor = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        ButtonCancel.Location = New Point(56, 576)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(196, 52)
        ButtonCancel.TabIndex = 7
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = False
        ButtonCancel.Visible = False
        ' 
        ' Question_Form
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(229), CByte(231), CByte(235))
        ClientSize = New Size(1280, 820)
        Controls.Add(PanelCard)
        Padding = New Padding(32, 24, 32, 24)
        Font = New Font("Segoe UI", 10.0F)
        FormBorderStyle = FormBorderStyle.Sizable
        MaximizeBox = True
        MinimumSize = New Size(1100, 720)
        Name = "Question_Form"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Question Form - ThesisBuddy"
        WindowState = FormWindowState.Maximized
        CType(PictureLogo, ComponentModel.ISupportInitialize).EndInit()
        PanelCard.ResumeLayout(False)
        PanelCard.PerformLayout()
        PanelLogoContainer.ResumeLayout(False)
        PanelQuestionsHost.ResumeLayout(False)
        PanelScrollTrack.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents PanelLogoContainer As Panel
    Friend WithEvents PictureLogo As PictureBox
    Friend WithEvents PanelCard As Panel
    Friend WithEvents PanelQuestionsHost As Panel
    Friend WithEvents PanelScrollTrack As Panel
    Friend WithEvents PanelScrollThumb As Panel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents LabelSubtitle As Label
    Friend WithEvents FlowLayoutPanelQuestions As BufferedFlowLayoutPanel
    Friend WithEvents PanelNav As FlowLayoutPanel
    Friend WithEvents ButtonSubmit As Button
    Friend WithEvents ButtonCancel As Button

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
