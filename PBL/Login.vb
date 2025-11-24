Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter username and password.")
            Return
        End If

        Try
            If DatabaseHelper.LoginUser(username, password) Then
                ' Login successful
                Dim mainForm As New Main_Menu()
                mainForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password.")
            End If
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim regForm As New Register()
        regForm.ShowDialog()
    End Sub
End Class