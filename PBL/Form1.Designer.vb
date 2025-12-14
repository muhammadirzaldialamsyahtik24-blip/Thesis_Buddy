<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Label1 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        Panel3 = New Panel()
        Button1 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 30.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(59, 130, 246)
        Label1.Location = New Point(120, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(809, 62)
        Label1.TabIndex = 3
        Label1.Text = "Sistem Pakar Penentu Topik Skripsi"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.5F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(100, 116, 139)
        Label2.Location = New Point(28, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(196, 25)
        Label2.TabIndex = 4
        Label2.Text = "© 2025 – Thesis Buddy"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.BackColor = Color.FromArgb(248, 250, 252)
        Panel1.Location = New Point(1, 565)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1040, 57)
        Panel1.TabIndex = 5
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label1)
        Panel3.BackColor = Color.FromArgb(248, 250, 252)
        Panel3.Location = New Point(1, 1)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1040, 120)
        Panel3.TabIndex = 7
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(59, 130, 246)
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 12.5F, FontStyle.Bold)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(182, 297)
        Button1.Name = "Button1"
        Button1.Size = New Size(200, 62)
        Button1.TabIndex = 0
        Button1.Text = "Mulai Konsultasi →"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.White
        Button3.FlatAppearance.BorderColor = Color.FromArgb(239, 68, 68)
        Button3.FlatAppearance.BorderSize = 2
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Segoe UI", 12.5F, FontStyle.Bold)
        Button3.ForeColor = Color.FromArgb(239, 68, 68)
        Button3.Location = New Point(741, 297)
        Button3.Name = "Button3"
        Button3.Size = New Size(200, 62)
        Button3.TabIndex = 2
        Button3.Text = "Keluar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.White
        Button2.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246)
        Button2.FlatAppearance.BorderSize = 2
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 12.5F, FontStyle.Bold)
        Button2.ForeColor = Color.FromArgb(59, 130, 246)
        Button2.Location = New Point(443, 297)
        Button2.Name = "Button2"
        Button2.Size = New Size(200, 62)
        Button2.TabIndex = 1
        Button2.Text = "Tentang Sistem"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(24, 140)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(200, 120)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(226, 232, 240)
        ClientSize = New Size(1060, 640)
        Controls.Add(PictureBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Panel3)
        Controls.Add(Button1)
        Controls.Add(Panel1)
        ForeColor = SystemColors.ActiveCaptionText
        Name = "Form1"
        Text = "Dashboard"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox

End Class
