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

        Try
            If DatabaseHelper.RegisterUser(username, password) Then
                MessageBox.Show("Registration successful!")
                Me.Close()
            Else
                MessageBox.Show("Username already exists.")
            End If
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class