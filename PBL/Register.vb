Public Class Register

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text
        Dim confirmPassword As String = TextBox3.Text

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match.")
            Return
        End If

        ' Check if user already exists
        Dim usersFile As String = "users.txt"
        If System.IO.File.Exists(usersFile) Then
            Dim lines As String() = System.IO.File.ReadAllLines(usersFile)
            For Each line As String In lines
                If line.StartsWith(username & ":") Then
                    MessageBox.Show("Username already exists.")
                    Return
                End If
            Next
        End If

        ' Save user
        Using writer As New System.IO.StreamWriter(usersFile, True)
            writer.WriteLine(username & ":" & password)
        End Using

        MessageBox.Show("Registration successful!")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class