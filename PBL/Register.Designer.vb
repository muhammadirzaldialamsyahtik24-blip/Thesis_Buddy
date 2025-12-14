<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PanelLeft = New Panel()
        PictureLogo = New PictureBox()
        PanelCard = New Panel()
        LabelTitle = New Label()
        LabelSubtitle = New Label()
        LabelUsername = New Label()
        TextBoxUsername = New TextBox()
        LabelPassword = New Label()
        TextBoxPassword = New TextBox()
        LabelConfirm = New Label()
        TextBoxConfirm = New TextBox()
        CheckBoxShow = New CheckBox()
        ButtonRegister = New Button()
        ButtonBack = New Button()
        PanelLeft.SuspendLayout()
        CType(PictureLogo, ComponentModel.ISupportInitialize).BeginInit()
        PanelCard.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelLeft
        ' 
        PanelLeft.BackColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        PanelLeft.Controls.Add(PictureLogo)
        PanelLeft.Dock = DockStyle.Left
        PanelLeft.Location = New Point(0, 0)
        PanelLeft.Name = "PanelLeft"
        PanelLeft.Size = New Size(380, 600)
        PanelLeft.TabIndex = 0
        ' 
        ' PictureLogo
        ' 
        PictureLogo.Image = My.Resources.Resources.thesisbuddy_logo
        PictureLogo.Location = New Point(-20, 23)
        PictureLogo.Name = "PictureLogo"
        PictureLogo.Size = New Size(405, 473)
        PictureLogo.SizeMode = PictureBoxSizeMode.Zoom
        PictureLogo.TabIndex = 1
        PictureLogo.TabStop = False
        ' 
        ' PanelCard
        ' 
        PanelCard.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        PanelCard.Controls.Add(LabelTitle)
        PanelCard.Controls.Add(LabelSubtitle)
        PanelCard.Controls.Add(LabelUsername)
        PanelCard.Controls.Add(TextBoxUsername)
        PanelCard.Controls.Add(LabelPassword)
        PanelCard.Controls.Add(TextBoxPassword)
        PanelCard.Controls.Add(LabelConfirm)
        PanelCard.Controls.Add(TextBoxConfirm)
        PanelCard.Controls.Add(CheckBoxShow)
        PanelCard.Controls.Add(ButtonRegister)
        PanelCard.Controls.Add(ButtonBack)
        PanelCard.Location = New Point(440, 70)
        PanelCard.Padding = New Padding(32, 36, 32, 32)
        PanelCard.BorderStyle = BorderStyle.FixedSingle
        PanelCard.Name = "PanelCard"
        PanelCard.Size = New Size(490, 460)
        PanelCard.TabIndex = 2
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 26.0F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        LabelTitle.Location = New Point(36, 28)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(190, 45)
        LabelTitle.TabIndex = 3
        LabelTitle.Text = "Get Started"
        ' 
        ' LabelSubtitle
        ' 
        LabelSubtitle.AutoSize = True
        LabelSubtitle.Font = New Font("Segoe UI", 12.0F)
        LabelSubtitle.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        LabelSubtitle.Location = New Point(36, 84)
        LabelSubtitle.Name = "LabelSubtitle"
        LabelSubtitle.Size = New Size(317, 20)
        LabelSubtitle.TabIndex = 4
        LabelSubtitle.Text = "Create your account to start using ThesisBuddy"
        ' 
        ' LabelUsername
        ' 
        LabelUsername.AutoSize = True
        LabelUsername.Font = New Font("Segoe UI", 9.0F)
        LabelUsername.ForeColor = Color.DimGray
        LabelUsername.Location = New Point(40, 148)
        LabelUsername.Name = "LabelUsername"
        LabelUsername.Size = New Size(60, 15)
        LabelUsername.TabIndex = 5
        LabelUsername.Text = "Username"
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.BackColor = Color.White
        TextBoxUsername.BorderStyle = BorderStyle.FixedSingle
        TextBoxUsername.Font = New Font("Segoe UI", 11.5F)
        TextBoxUsername.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        TextBoxUsername.Location = New Point(40, 178)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.PlaceholderText = "Masukkan username"
        TextBoxUsername.Size = New Size(400, 28)
        TextBoxUsername.TabIndex = 6
        ' 
        ' LabelPassword
        ' 
        LabelPassword.AutoSize = True
        LabelPassword.Font = New Font("Segoe UI", 9.0F)
        LabelPassword.ForeColor = Color.DimGray
        LabelPassword.Location = New Point(40, 230)
        LabelPassword.Name = "LabelPassword"
        LabelPassword.Size = New Size(57, 15)
        LabelPassword.TabIndex = 7
        LabelPassword.Text = "Password"
        ' 
        ' TextBoxPassword
        ' 
        TextBoxPassword.BackColor = Color.White
        TextBoxPassword.BorderStyle = BorderStyle.FixedSingle
        TextBoxPassword.Font = New Font("Segoe UI", 11.5F)
        TextBoxPassword.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        TextBoxPassword.Location = New Point(40, 260)
        TextBoxPassword.Name = "TextBoxPassword"
        TextBoxPassword.PasswordChar = "●"c
        TextBoxPassword.PlaceholderText = "Masukkan password"
        TextBoxPassword.Size = New Size(378, 28)
        TextBoxPassword.TabIndex = 8
        ' 
        ' LabelConfirm
        ' 
        LabelConfirm.AutoSize = True
        LabelConfirm.Font = New Font("Segoe UI", 9.0F)
        LabelConfirm.ForeColor = Color.DimGray
        LabelConfirm.Location = New Point(40, 314)
        LabelConfirm.Name = "LabelConfirm"
        LabelConfirm.Size = New Size(104, 15)
        LabelConfirm.TabIndex = 9
        LabelConfirm.Text = "Confirm Password"
        ' 
        ' TextBoxConfirm
        ' 
        TextBoxConfirm.BackColor = Color.White
        TextBoxConfirm.BorderStyle = BorderStyle.FixedSingle
        TextBoxConfirm.Font = New Font("Segoe UI", 11.5F)
        TextBoxConfirm.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        TextBoxConfirm.Location = New Point(40, 342)
        TextBoxConfirm.Name = "TextBoxConfirm"
        TextBoxConfirm.PasswordChar = "●"c
        TextBoxConfirm.PlaceholderText = "Konfirmasi password"
        TextBoxConfirm.Size = New Size(400, 28)
        TextBoxConfirm.TabIndex = 9
        ' 
        ' CheckBoxShow
        ' 
        CheckBoxShow.AutoSize = True
        CheckBoxShow.ForeColor = Color.LightGray
        CheckBoxShow.Location = New Point(425, 278)
        CheckBoxShow.Name = "CheckBoxShow"
        CheckBoxShow.Size = New Size(15, 14)
        CheckBoxShow.TabIndex = 11
        CheckBoxShow.UseVisualStyleBackColor = True
        ' 
        ' ButtonRegister
        ' 
        ButtonRegister.BackColor = Color.FromArgb(CByte(37), CByte(161), CByte(142))
        ButtonRegister.Cursor = Cursors.Hand
        ButtonRegister.FlatAppearance.BorderSize = 0
        ButtonRegister.FlatStyle = FlatStyle.Flat
        ButtonRegister.Font = New Font("Segoe UI", 12.5F, FontStyle.Bold)
        ButtonRegister.ForeColor = Color.White
        ButtonRegister.Location = New Point(40, 395)
        ButtonRegister.Name = "ButtonRegister"
        ButtonRegister.Size = New Size(400, 54)
        ButtonRegister.TabIndex = 12
        ButtonRegister.Text = "Create Account"
        ButtonRegister.UseVisualStyleBackColor = False
        ' 
        ' ButtonBack
        ' 
        ButtonBack.BackColor = Color.Transparent
        ButtonBack.Cursor = Cursors.Hand
        ButtonBack.FlatAppearance.BorderSize = 0
        ButtonBack.FlatStyle = FlatStyle.Flat
        ButtonBack.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        ButtonBack.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        ButtonBack.Location = New Point(404, 12)
        ButtonBack.Name = "ButtonBack"
        ButtonBack.Size = New Size(70, 36)
        ButtonBack.TabIndex = 11
        ButtonBack.Text = "← Back"
        ButtonBack.UseVisualStyleBackColor = False
        ' 
        ' Register
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        ClientSize = New Size(1020, 620)
        Controls.Add(PanelCard)
        Controls.Add(PanelLeft)
        Font = New Font("Segoe UI", 10F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Register"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Register - ThesisBuddy"
        PanelLeft.ResumeLayout(False)
        CType(PictureLogo, ComponentModel.ISupportInitialize).EndInit()
        PanelCard.ResumeLayout(False)
        PanelCard.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents PanelLeft As Panel
    Friend WithEvents PictureLogo As PictureBox
    Friend WithEvents PanelCard As Panel
    Friend WithEvents LabelSubtitle As Label
    Friend WithEvents LabelTitle As Label
    Friend WithEvents ButtonBack As Button
    Friend WithEvents ButtonRegister As Button
    Friend WithEvents CheckBoxShow As CheckBox
    Friend WithEvents TextBoxConfirm As TextBox
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelConfirm As Label
    Friend WithEvents LabelPassword As Label
    Friend WithEvents LabelUsername As Label
End Class