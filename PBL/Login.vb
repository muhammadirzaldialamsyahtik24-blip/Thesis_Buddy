Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter username and password.")
            Return
        End If

        Dim usersFile As String = "users.txt"
        If System.IO.File.Exists(usersFile) Then
            Dim lines As String() = System.IO.File.ReadAllLines(usersFile)
            For Each line As String In lines
                Dim parts As String() = line.Split(":"c)
                If parts.Length = 2 AndAlso parts(0) = username AndAlso parts(1) = password Then
                    ' Login successful
                    Dim mainForm As New Main_Menu()
                    mainForm.Show()
                    Me.Hide()
                    Return
                End If
            Next
        End If

        MessageBox.Show("Invalid username or password.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim regForm As New Register()
        regForm.ShowDialog()
    End Sub
End Class