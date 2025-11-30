Public Class Login

    Private isDragging As Boolean = False
    Private dragOffset As Point

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' center panel
        PanelMain.Left = (Me.ClientSize.Width - PanelMain.Width) \ 2
        PanelMain.Top = (Me.ClientSize.Height - PanelMain.Height) \ 2
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        Dim username As String = TextBoxUsername.Text.Trim()
        Dim password As String = TextBoxPassword.Text

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter username and password.")
            Return
        End If

        Try
            If DatabaseHelper.LoginUser(username, password) Then
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

    Private Sub ButtonRegister_Click(sender As Object, e As EventArgs) Handles ButtonRegister.Click
        Dim reg As New Register()
        reg.ShowDialog()
    End Sub

    Private Sub CheckBoxShow_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShow.CheckedChanged
        If CheckBoxShow.Checked Then
            TextBoxPassword.PasswordChar = ControlChars.NullChar
        Else
            TextBoxPassword.PasswordChar = "?"c
        End If
    End Sub

    Private Sub TextBoxes_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUsername.KeyDown, TextBoxPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonLogin.PerformClick()
        End If
    End Sub

    Private Sub ButtonLogin_MouseEnter(sender As Object, e As EventArgs) Handles ButtonLogin.MouseEnter
        ButtonLogin.FlatAppearance.BorderColor = Drawing.Color.FromArgb(200, 200, 255)
    End Sub

    Private Sub ButtonLogin_MouseLeave(sender As Object, e As EventArgs) Handles ButtonLogin.MouseLeave
        ButtonLogin.FlatAppearance.BorderColor = Drawing.Color.White
    End Sub

    Private Sub LinkForgot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkForgot.LinkClicked
        MessageBox.Show("Password recovery not implemented.")
    End Sub

    ' Title bar controls
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Application.Exit()
    End Sub

    Private Sub ButtonMinimize_Click(sender As Object, e As EventArgs) Handles ButtonMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    ' Allow dragging the borderless window
    Private Sub PanelTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTitle.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragOffset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub PanelTitle_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelTitle.MouseMove
        If isDragging Then
            Dim pt As Point = Me.PointToScreen(e.Location)
            Me.Location = New Point(pt.X - dragOffset.X, pt.Y - dragOffset.Y)
        End If
    End Sub

    Private Sub PanelTitle_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelTitle.MouseUp
        isDragging = False
    End Sub

    Private Sub LabelTitle_Click(sender As Object, e As EventArgs) Handles LabelTitle.Click

    End Sub

    Private Sub LabelSubtitle_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelUsername_Click(sender As Object, e As EventArgs) Handles LabelUsername.Click

    End Sub

    Private Sub LabelPassword_Click(sender As Object, e As EventArgs) Handles LabelPassword.Click

    End Sub

    Private Sub PanelMain_Paint(sender As Object, e As PaintEventArgs) Handles PanelMain.Paint

    End Sub
End Class