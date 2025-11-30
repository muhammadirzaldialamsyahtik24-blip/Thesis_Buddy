Public Class Register

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelMain.Left = (Me.ClientSize.Width - PanelMain.Width) \ 2
        PanelMain.Top = (Me.ClientSize.Height - PanelMain.Height) \ 2
    End Sub

    Private Sub ButtonRegister_Click(sender As Object, e As EventArgs) Handles ButtonRegister.Click
        Dim username As String = TextBoxUsername.Text.Trim()
        Dim password As String = TextBoxPassword.Text
        Dim confirm As String = TextBoxConfirm.Text

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        If password <> confirm Then
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

    Private Sub ButtonBack_Click(sender As Object, e As EventArgs) Handles ButtonBack.Click
        Me.Close()
    End Sub

    Private Sub LabelSubtitle_Click(sender As Object, e As EventArgs) Handles LabelSubtitle.Click

    End Sub
End Class