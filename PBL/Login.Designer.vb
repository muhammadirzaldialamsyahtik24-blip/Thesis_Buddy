<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        PanelTitle = New Panel()
        LabelAppTitle = New Label()
        ButtonMinimize = New Button()
        ButtonClose = New Button()
        PanelMain = New Panel()
        LabelTitle = New Label()
        LabelSubtitle = New Label()
        LabelUsername = New Label()
        TextBoxUsername = New TextBox()
        LabelPassword = New Label()
        TextBoxPassword = New TextBox()
        CheckBoxShow = New CheckBox()
        LinkForgot = New LinkLabel()
        ButtonLogin = New Button()
        ButtonRegister = New Button()
        PanelTitle.SuspendLayout()
        PanelMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelTitle
        ' 
        PanelTitle.BackColor = Color.FromArgb(CByte(6), CByte(30), CByte(70))
        PanelTitle.Controls.Add(LabelAppTitle)
        PanelTitle.Controls.Add(ButtonMinimize)
        PanelTitle.Controls.Add(ButtonClose)
        PanelTitle.Dock = DockStyle.Top
        PanelTitle.Location = New Point(0, 0)
        PanelTitle.Margin = New Padding(3, 2, 3, 2)
        PanelTitle.Name = "PanelTitle"
        PanelTitle.Size = New Size(540, 35)
        PanelTitle.TabIndex = 0
        ' 
        ' LabelAppTitle
        ' 
        LabelAppTitle.AutoSize = True
        LabelAppTitle.FlatStyle = FlatStyle.Popup
        LabelAppTitle.Font = New Font("Orbitron", 11.2499981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelAppTitle.ForeColor = Color.White
        LabelAppTitle.Location = New Point(7, 8)
        LabelAppTitle.Name = "LabelAppTitle"
        LabelAppTitle.Size = New Size(119, 18)
        LabelAppTitle.TabIndex = 1
        LabelAppTitle.Text = "Thesis Buddy"
        ' 
        ' ButtonMinimize
        ' 
        ButtonMinimize.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonMinimize.BackColor = Color.Transparent
        ButtonMinimize.FlatAppearance.BorderSize = 0
        ButtonMinimize.FlatStyle = FlatStyle.Flat
        ButtonMinimize.ForeColor = Color.White
        ButtonMinimize.Location = New Point(1013, 3)
        ButtonMinimize.Margin = New Padding(3, 2, 3, 2)
        ButtonMinimize.Name = "ButtonMinimize"
        ButtonMinimize.Size = New Size(26, 21)
        ButtonMinimize.TabIndex = 2
        ButtonMinimize.Text = "—"
        ButtonMinimize.UseVisualStyleBackColor = True
        ' 
        ' ButtonClose
        ' 
        ButtonClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonClose.BackColor = Color.Transparent
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.ForeColor = Color.White
        ButtonClose.Location = New Point(1042, 3)
        ButtonClose.Margin = New Padding(3, 2, 3, 2)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(26, 21)
        ButtonClose.TabIndex = 3
        ButtonClose.Text = "X"
        ButtonClose.UseVisualStyleBackColor = True
        ' 
        ' PanelMain
        ' 
        PanelMain.Anchor = AnchorStyles.None
        PanelMain.BackColor = Color.FromArgb(CByte(12), CByte(44), CByte(93))
        PanelMain.Controls.Add(LabelTitle)
        PanelMain.Controls.Add(LabelSubtitle)
        PanelMain.Controls.Add(LabelUsername)
        PanelMain.Controls.Add(TextBoxUsername)
        PanelMain.Controls.Add(LabelPassword)
        PanelMain.Controls.Add(TextBoxPassword)
        PanelMain.Controls.Add(CheckBoxShow)
        PanelMain.Controls.Add(LinkForgot)
        PanelMain.Controls.Add(ButtonLogin)
        PanelMain.Controls.Add(ButtonRegister)
        PanelMain.Location = New Point(29, 72)
        PanelMain.Margin = New Padding(3, 2, 3, 2)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(471, 248)
        PanelMain.TabIndex = 1
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(52, 22)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(220, 32)
        LabelTitle.TabIndex = 1
        LabelTitle.Text = "Here you can login"
        ' 
        ' LabelSubtitle
        ' 
        LabelSubtitle.AutoSize = True
        LabelSubtitle.Font = New Font("Segoe UI", 9.0F)
        LabelSubtitle.ForeColor = Color.LightGray
        LabelSubtitle.Location = New Point(52, 54)
        LabelSubtitle.Name = "LabelSubtitle"
        LabelSubtitle.Size = New Size(139, 15)
        LabelSubtitle.TabIndex = 2
        LabelSubtitle.Text = "We are glad to see you : )"
        ' 
        ' LabelUsername
        ' 
        LabelUsername.AutoSize = True
        LabelUsername.BackColor = Color.Transparent
        LabelUsername.Font = New Font("Segoe UI", 9.0F)
        LabelUsername.ForeColor = Color.Transparent
        LabelUsername.Location = New Point(52, 112)
        LabelUsername.Name = "LabelUsername"
        LabelUsername.Size = New Size(69, 15)
        LabelUsername.TabIndex = 3
        LabelUsername.Text = "Username : "
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.BackColor = Color.White
        TextBoxUsername.BorderStyle = BorderStyle.FixedSingle
        TextBoxUsername.Font = New Font("Segoe UI", 10.0F)
        TextBoxUsername.ForeColor = Color.Black
        TextBoxUsername.Location = New Point(133, 108)
        TextBoxUsername.Margin = New Padding(3, 2, 3, 2)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(315, 25)
        TextBoxUsername.TabIndex = 4
        ' 
        ' LabelPassword
        ' 
        LabelPassword.AutoSize = True
        LabelPassword.BackColor = Color.Transparent
        LabelPassword.Font = New Font("Segoe UI", 9.0F)
        LabelPassword.ForeColor = Color.Transparent
        LabelPassword.Location = New Point(52, 154)
        LabelPassword.Name = "LabelPassword"
        LabelPassword.Size = New Size(63, 15)
        LabelPassword.TabIndex = 5
        LabelPassword.Text = "Password :"
        ' 
        ' TextBoxPassword
        ' 
        TextBoxPassword.BackColor = Color.White
        TextBoxPassword.BorderStyle = BorderStyle.FixedSingle
        TextBoxPassword.Font = New Font("Segoe UI", 10.0F)
        TextBoxPassword.ForeColor = Color.Black
        TextBoxPassword.Location = New Point(133, 150)
        TextBoxPassword.Margin = New Padding(3, 2, 3, 2)
        TextBoxPassword.Name = "TextBoxPassword"
        TextBoxPassword.PasswordChar = "?"c
        TextBoxPassword.Size = New Size(273, 25)
        TextBoxPassword.TabIndex = 6
        ' 
        ' CheckBoxShow
        ' 
        CheckBoxShow.AutoSize = True
        CheckBoxShow.ForeColor = Color.LightGray
        CheckBoxShow.Location = New Point(433, 161)
        CheckBoxShow.Margin = New Padding(3, 2, 3, 2)
        CheckBoxShow.Name = "CheckBoxShow"
        CheckBoxShow.Size = New Size(15, 14)
        CheckBoxShow.TabIndex = 7
        CheckBoxShow.UseVisualStyleBackColor = True
        ' 
        ' LinkForgot
        ' 
        LinkForgot.ActiveLinkColor = Color.LightGray
        LinkForgot.AutoSize = True
        LinkForgot.LinkColor = Color.LightGray
        LinkForgot.Location = New Point(133, 190)
        LinkForgot.Name = "LinkForgot"
        LinkForgot.Size = New Size(100, 15)
        LinkForgot.TabIndex = 8
        LinkForgot.TabStop = True
        LinkForgot.Text = "Forgot password?"
        ' 
        ' ButtonLogin
        ' 
        ButtonLogin.BackColor = Color.FromArgb(CByte(93), CByte(64), CByte(199))
        ButtonLogin.FlatAppearance.BorderColor = Color.White
        ButtonLogin.FlatAppearance.BorderSize = 2
        ButtonLogin.FlatStyle = FlatStyle.Flat
        ButtonLogin.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        ButtonLogin.ForeColor = Color.White
        ButtonLogin.Location = New Point(360, 210)
        ButtonLogin.Margin = New Padding(3, 2, 3, 2)
        ButtonLogin.Name = "ButtonLogin"
        ButtonLogin.Size = New Size(88, 26)
        ButtonLogin.TabIndex = 9
        ButtonLogin.Text = "Login"
        ButtonLogin.UseVisualStyleBackColor = False
        ' 
        ' ButtonRegister
        ' 
        ButtonRegister.BackColor = Color.FromArgb(CByte(60), CByte(60), CByte(70))
        ButtonRegister.FlatAppearance.BorderColor = Color.White
        ButtonRegister.FlatStyle = FlatStyle.Flat
        ButtonRegister.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        ButtonRegister.ForeColor = Color.White
        ButtonRegister.Location = New Point(266, 210)
        ButtonRegister.Margin = New Padding(3, 2, 3, 2)
        ButtonRegister.Name = "ButtonRegister"
        ButtonRegister.Size = New Size(88, 26)
        ButtonRegister.TabIndex = 10
        ButtonRegister.Text = "Register"
        ButtonRegister.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(10), CByte(25), CByte(56))
        ClientSize = New Size(540, 360)
        Controls.Add(PanelMain)
        Controls.Add(PanelTitle)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        PanelTitle.ResumeLayout(False)
        PanelTitle.PerformLayout()
        PanelMain.ResumeLayout(False)
        PanelMain.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTitle As Panel
    Friend WithEvents LabelAppTitle As Label
    Friend WithEvents ButtonMinimize As Button
    Friend WithEvents ButtonClose As Button
    Friend WithEvents PanelMain As Panel
    Friend WithEvents LabelSubtitle As Label
    Friend WithEvents LabelTitle As Label
    Friend WithEvents LinkForgot As LinkLabel
    Friend WithEvents CheckBoxShow As CheckBox
    Friend WithEvents ButtonLogin As Button
    Friend WithEvents ButtonRegister As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelPassword As Label
    Friend WithEvents LabelUsername As Label
End Class