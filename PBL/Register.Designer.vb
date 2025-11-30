<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Register
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelMain = New Panel()
        LabelTitle = New Label()
        LabelSubtitle = New Label()
        LabelUsername = New Label()
        TextBoxUsername = New TextBox()
        LabelPassword = New Label()
        TextBoxPassword = New TextBox()
        LabelConfirm = New Label()
        TextBoxConfirm = New TextBox()
        ButtonRegister = New Button()
        ButtonBack = New Button()
        PanelMain.SuspendLayout()
        SuspendLayout()
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
        PanelMain.Controls.Add(LabelConfirm)
        PanelMain.Controls.Add(TextBoxConfirm)
        PanelMain.Controls.Add(ButtonRegister)
        PanelMain.Controls.Add(ButtonBack)
        PanelMain.Location = New Point(140, 45)
        PanelMain.Margin = New Padding(3, 2, 3, 2)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(420, 248)
        PanelMain.TabIndex = 0
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(52, 6)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(213, 32)
        LabelTitle.TabIndex = 1
        LabelTitle.Text = "Create an account"
        ' 
        ' LabelSubtitle
        ' 
        LabelSubtitle.AutoSize = True
        LabelSubtitle.Font = New Font("Segoe UI", 9F)
        LabelSubtitle.ForeColor = Color.LightGray
        LabelSubtitle.Location = New Point(52, 47)
        LabelSubtitle.Name = "LabelSubtitle"
        LabelSubtitle.Size = New Size(119, 15)
        LabelSubtitle.TabIndex = 2
        LabelSubtitle.Text = "Isi Yang bener Bujank"
        ' 
        ' LabelUsername
        ' 
        LabelUsername.AutoSize = True
        LabelUsername.Font = New Font("Segoe UI", 9F)
        LabelUsername.ForeColor = Color.LightGray
        LabelUsername.Location = New Point(52, 74)
        LabelUsername.Name = "LabelUsername"
        LabelUsername.Size = New Size(60, 15)
        LabelUsername.TabIndex = 3
        LabelUsername.Text = "Username"
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.BackColor = Color.FromArgb(CByte(22), CByte(48), CByte(88))
        TextBoxUsername.BorderStyle = BorderStyle.FixedSingle
        TextBoxUsername.Font = New Font("Segoe UI", 10F)
        TextBoxUsername.ForeColor = Color.White
        TextBoxUsername.Location = New Point(52, 92)
        TextBoxUsername.Margin = New Padding(3, 2, 3, 2)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(315, 25)
        TextBoxUsername.TabIndex = 4
        ' 
        ' LabelPassword
        ' 
        LabelPassword.AutoSize = True
        LabelPassword.Font = New Font("Segoe UI", 9F)
        LabelPassword.ForeColor = Color.LightGray
        LabelPassword.Location = New Point(52, 122)
        LabelPassword.Name = "LabelPassword"
        LabelPassword.Size = New Size(57, 15)
        LabelPassword.TabIndex = 5
        LabelPassword.Text = "Password"
        ' 
        ' TextBoxPassword
        ' 
        TextBoxPassword.BackColor = Color.FromArgb(CByte(22), CByte(48), CByte(88))
        TextBoxPassword.BorderStyle = BorderStyle.FixedSingle
        TextBoxPassword.Font = New Font("Segoe UI", 10F)
        TextBoxPassword.ForeColor = Color.White
        TextBoxPassword.Location = New Point(52, 141)
        TextBoxPassword.Margin = New Padding(3, 2, 3, 2)
        TextBoxPassword.Name = "TextBoxPassword"
        TextBoxPassword.PasswordChar = "?"c
        TextBoxPassword.Size = New Size(315, 25)
        TextBoxPassword.TabIndex = 6
        ' 
        ' LabelConfirm
        ' 
        LabelConfirm.AutoSize = True
        LabelConfirm.Font = New Font("Segoe UI", 9F)
        LabelConfirm.ForeColor = Color.LightGray
        LabelConfirm.Location = New Point(52, 171)
        LabelConfirm.Name = "LabelConfirm"
        LabelConfirm.Size = New Size(104, 15)
        LabelConfirm.TabIndex = 7
        LabelConfirm.Text = "Confirm Password"
        ' 
        ' TextBoxConfirm
        ' 
        TextBoxConfirm.BackColor = Color.FromArgb(CByte(22), CByte(48), CByte(88))
        TextBoxConfirm.BorderStyle = BorderStyle.FixedSingle
        TextBoxConfirm.Font = New Font("Segoe UI", 10F)
        TextBoxConfirm.ForeColor = Color.White
        TextBoxConfirm.Location = New Point(52, 190)
        TextBoxConfirm.Margin = New Padding(3, 2, 3, 2)
        TextBoxConfirm.Name = "TextBoxConfirm"
        TextBoxConfirm.PasswordChar = "?"c
        TextBoxConfirm.Size = New Size(315, 25)
        TextBoxConfirm.TabIndex = 8
        ' 
        ' ButtonRegister
        ' 
        ButtonRegister.BackColor = Color.FromArgb(CByte(93), CByte(64), CByte(199))
        ButtonRegister.FlatAppearance.BorderColor = Color.White
        ButtonRegister.FlatAppearance.BorderSize = 2
        ButtonRegister.FlatStyle = FlatStyle.Flat
        ButtonRegister.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        ButtonRegister.ForeColor = Color.White
        ButtonRegister.Location = New Point(280, 220)
        ButtonRegister.Margin = New Padding(3, 2, 3, 2)
        ButtonRegister.Name = "ButtonRegister"
        ButtonRegister.Size = New Size(88, 26)
        ButtonRegister.TabIndex = 9
        ButtonRegister.Text = "Register"
        ButtonRegister.UseVisualStyleBackColor = False
        ' 
        ' ButtonBack
        ' 
        ButtonBack.BackColor = Color.Transparent
        ButtonBack.FlatStyle = FlatStyle.Flat
        ButtonBack.Font = New Font("Segoe UI", 9F)
        ButtonBack.ForeColor = Color.LightGray
        ButtonBack.Location = New Point(52, 220)
        ButtonBack.Margin = New Padding(3, 2, 3, 2)
        ButtonBack.Name = "ButtonBack"
        ButtonBack.Size = New Size(66, 26)
        ButtonBack.TabIndex = 10
        ButtonBack.Text = "Back"
        ButtonBack.UseVisualStyleBackColor = False
        ' 
        ' Register
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(10), CByte(25), CByte(56))
        ClientSize = New Size(700, 338)
        Controls.Add(PanelMain)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        Name = "Register"
        Text = "Register"
        PanelMain.ResumeLayout(False)
        PanelMain.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMain As Panel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents LabelSubtitle As Label
    Friend WithEvents LabelUsername As Label
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelPassword As Label
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents LabelConfirm As Label
    Friend WithEvents TextBoxConfirm As TextBox
    Friend WithEvents ButtonRegister As Button
    Friend WithEvents ButtonBack As Button
End Class