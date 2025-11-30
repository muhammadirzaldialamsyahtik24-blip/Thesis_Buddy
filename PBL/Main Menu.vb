Imports System.Drawing.Drawing2D
Imports System.IO

Public Class Main_Menu

    Private Sub Main_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Position card relative to left panel
        Dim found = Me.Controls.Find("PanelCard", True)
        If found.Length > 0 Then
            Dim panelCard As Panel = DirectCast(found(0), Panel)
            Dim leftFound = Me.Controls.Find("PanelLeft", True)
            If leftFound.Length > 0 Then
                Dim panelLeft As Panel = DirectCast(leftFound(0), Panel)
                Dim margin As Integer = 30
                panelCard.Left = panelLeft.Right + margin
                panelCard.Top = (Me.ClientSize.Height - panelCard.Height) \ 2
            Else
                panelCard.Left = (Me.ClientSize.Width - panelCard.Width) \ 2
                panelCard.Top = (Me.ClientSize.Height - panelCard.Height) \ 2
            End If

            ' Rounded corners
            Try
                Dim r As Integer = 16
                Dim rect As Rectangle = panelCard.ClientRectangle
                Dim path As New GraphicsPath()
                path.AddArc(rect.X, rect.Y, r, r, 180, 90)
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90)
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90)
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90)
                path.CloseFigure()
                panelCard.Region = New Region(path)
            Catch ex As Exception
            End Try
        End If

        ' Load logo if available
        Try
            Dim candidates = New String() {Path.Combine(Application.StartupPath, "thesisbuddy_logo.png"), Path.Combine(Application.StartupPath, "logo.png"), Path.Combine(Application.StartupPath, "assets", "logo.png")}
            For Each p As String In candidates
                If File.Exists(p) Then
                    Using src As Image = Image.FromFile(p)
                        PictureLogo.Image = New Bitmap(src)
                    End Using
                    PictureLogo.SizeMode = PictureBoxSizeMode.Zoom
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        ' Open question form (assumes Question_Form exists)
        Dim qf As New Question_Form()
        qf.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonAbout_Click(sender As Object, e As EventArgs) Handles ButtonAbout.Click
        MessageBox.Show("ThesisBuddy v1.0" & vbCrLf & "Sistem rekomendasi topik skripsi.")
    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        Application.Exit()
    End Sub
End Class