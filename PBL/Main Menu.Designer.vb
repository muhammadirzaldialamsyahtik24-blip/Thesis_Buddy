<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Menu
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
        ButtonStart = New Button()
        ButtonAbout = New Button()
        ButtonExit = New Button()
        PanelLeft.SuspendLayout()
        CType(PictureLogo, ComponentModel.ISupportInitialize).BeginInit()
        PanelCard.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelLeft
        ' 
        PanelLeft.BackColor = Color.FromArgb(CByte(12), CByte(18), CByte(25))
        PanelLeft.Controls.Add(PictureLogo)
        PanelLeft.Dock = DockStyle.Left
        PanelLeft.Location = New Point(0, 0)
        PanelLeft.Name = "PanelLeft"
        PanelLeft.Size = New Size(360, 520)
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
        PanelCard.BackColor = Color.FromArgb(CByte(24), CByte(30), CByte(36))
        PanelCard.Controls.Add(LabelTitle)
        PanelCard.Controls.Add(ButtonStart)
        PanelCard.Controls.Add(ButtonAbout)
        PanelCard.Controls.Add(ButtonExit)
        PanelCard.Location = New Point(400, 80)
        PanelCard.Name = "PanelCard"
        PanelCard.Size = New Size(460, 360)
        PanelCard.TabIndex = 2
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(17, 11)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(149, 32)
        LabelTitle.TabIndex = 3
        LabelTitle.Text = "ThesisBuddy"
        ' 
        ' ButtonStart
        ' 
        ButtonStart.BackColor = Color.FromArgb(CByte(24), CByte(30), CByte(36))
        ButtonStart.FlatAppearance.BorderColor = Color.White
        ButtonStart.FlatAppearance.BorderSize = 2
        ButtonStart.FlatStyle = FlatStyle.Flat
        ButtonStart.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        ButtonStart.ForeColor = Color.White
        ButtonStart.Location = New Point(17, 286)
        ButtonStart.Name = "ButtonStart"
        ButtonStart.Size = New Size(153, 57)
        ButtonStart.TabIndex = 4
        ButtonStart.Text = "Start"
        ButtonStart.UseVisualStyleBackColor = False
        ' 
        ' ButtonAbout
        ' 
        ButtonAbout.BackColor = Color.FromArgb(CByte(24), CByte(30), CByte(36))
        ButtonAbout.FlatAppearance.BorderColor = Color.White
        ButtonAbout.FlatAppearance.BorderSize = 2
        ButtonAbout.FlatStyle = FlatStyle.Flat
        ButtonAbout.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        ButtonAbout.ForeColor = Color.White
        ButtonAbout.Location = New Point(307, 304)
        ButtonAbout.Name = "ButtonAbout"
        ButtonAbout.Size = New Size(61, 39)
        ButtonAbout.TabIndex = 5
        ButtonAbout.Text = "About"
        ButtonAbout.UseVisualStyleBackColor = False
        ' 
        ' ButtonExit
        ' 
        ButtonExit.BackColor = Color.FromArgb(CByte(24), CByte(30), CByte(36))
        ButtonExit.FlatAppearance.BorderColor = Color.White
        ButtonExit.FlatAppearance.BorderSize = 2
        ButtonExit.FlatStyle = FlatStyle.Flat
        ButtonExit.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        ButtonExit.ForeColor = Color.White
        ButtonExit.Location = New Point(383, 304)
        ButtonExit.Name = "ButtonExit"
        ButtonExit.Size = New Size(61, 39)
        ButtonExit.TabIndex = 6
        ButtonExit.Text = "Exit"
        ButtonExit.UseVisualStyleBackColor = False
        ' 
        ' Main_Menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(24), CByte(31))
        ClientSize = New Size(900, 520)
        Controls.Add(PanelCard)
        Controls.Add(PanelLeft)
        Font = New Font("Segoe UI", 10F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Main_Menu"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Main Menu - ThesisBuddy"
        PanelLeft.ResumeLayout(False)
        CType(PictureLogo, ComponentModel.ISupportInitialize).EndInit()
        PanelCard.ResumeLayout(False)
        PanelCard.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents PanelLeft As Panel
    Friend WithEvents PictureLogo As PictureBox
    Friend WithEvents PanelCard As Panel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents ButtonStart As Button
    Friend WithEvents ButtonAbout As Button
    Friend WithEvents ButtonExit As Button
End Class
