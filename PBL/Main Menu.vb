Public Class Main_Menu

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        Application.Exit()
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
End Class