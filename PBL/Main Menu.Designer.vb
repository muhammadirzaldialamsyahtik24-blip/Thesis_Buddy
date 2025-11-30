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
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.LabelAppName = New System.Windows.Forms.Label()
        Me.PictureLogo = New System.Windows.Forms.PictureBox()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonAbout = New System.Windows.Forms.Button()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.PanelHeader.SuspendLayout()
        CType(Me.PictureLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        ' Main_Menu (Form)
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(800, 500)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.PanelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Main_Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThesisBuddy - Main Menu"
        '
        ' PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(3, 58, 115) ' dark blue
        Me.PanelHeader.Controls.Add(Me.PictureLogo)
        Me.PanelHeader.Controls.Add(Me.LabelAppName)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Height = 100
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.TabIndex = 0
        '
        ' PictureLogo
        '
        Me.PictureLogo.Location = New System.Drawing.Point(24, 12)
        Me.PictureLogo.Name = "PictureLogo"
        Me.PictureLogo.Size = New System.Drawing.Size(76, 76)
        Me.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureLogo.TabIndex = 1
        Me.PictureLogo.TabStop = False
        '
        ' LabelAppName
        '
        Me.LabelAppName.AutoSize = True
        Me.LabelAppName.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LabelAppName.ForeColor = System.Drawing.Color.White
        Me.LabelAppName.Location = New System.Drawing.Point(120, 30)
        Me.LabelAppName.Name = "LabelAppName"
        Me.LabelAppName.Size = New System.Drawing.Size(180, 32)
        Me.LabelAppName.TabIndex = 2
        Me.LabelAppName.Text = "ThesisBuddy"
        '
        ' PanelMain
        '
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelMain.Controls.Add(Me.ButtonExit)
        Me.PanelMain.Controls.Add(Me.ButtonAbout)
        Me.PanelMain.Controls.Add(Me.ButtonStart)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.TabIndex = 3
        '
        ' ButtonStart
        '
        Me.ButtonStart.BackColor = System.Drawing.Color.FromArgb(3, 58, 115)
        Me.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStart.FlatAppearance.BorderSize = 0
        Me.ButtonStart.ForeColor = System.Drawing.Color.White
        Me.ButtonStart.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonStart.Location = New System.Drawing.Point(260, 140)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(280, 60)
        Me.ButtonStart.TabIndex = 0
        Me.ButtonStart.Text = "Mulai Konsultasi"
        Me.ButtonStart.UseVisualStyleBackColor = False
        '
        ' ButtonAbout
        '
        Me.ButtonAbout.BackColor = System.Drawing.Color.FromArgb(255, 165, 0) ' orange
        Me.ButtonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAbout.FlatAppearance.BorderSize = 0
        Me.ButtonAbout.ForeColor = System.Drawing.Color.White
        Me.ButtonAbout.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonAbout.Location = New System.Drawing.Point(260, 220)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(280, 50)
        Me.ButtonAbout.TabIndex = 1
        Me.ButtonAbout.Text = "Tentang Sistem"
        Me.ButtonAbout.UseVisualStyleBackColor = False
        '
        ' ButtonExit
        '
        Me.ButtonExit.BackColor = System.Drawing.Color.LightGray
        Me.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExit.FlatAppearance.BorderSize = 0
        Me.ButtonExit.ForeColor = System.Drawing.Color.FromArgb(3, 58, 115)
        Me.ButtonExit.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonExit.Location = New System.Drawing.Point(260, 290)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(280, 40)
        Me.ButtonExit.TabIndex = 2
        Me.ButtonExit.Text = "Keluar"
        Me.ButtonExit.UseVisualStyleBackColor = False
        '
        CType(Me.PictureLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents PictureLogo As PictureBox
    Friend WithEvents LabelAppName As Label
    Friend WithEvents PanelMain As Panel
    Friend WithEvents ButtonStart As Button
    Friend WithEvents ButtonAbout As Button
    Friend WithEvents ButtonExit As Button
End Class
