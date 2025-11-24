Imports MySql.Data.MySqlClient

Public Module DatabaseHelper

    Private connectionString As String = "server=localhost;userid=root;password=;database=thesis_buddy;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    Public Function LoginUser(username As String, password As String) As Boolean
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Public Function RegisterUser(username As String, password As String) As Boolean
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            ' Check if exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
            Using checkCmd As New MySqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@username", username)
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If count > 0 Then Return False
            End Using
            ' Insert
            Dim insertQuery As String = "INSERT INTO users (username, password) VALUES (@username, @password)"
            Using insertCmd As New MySqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@username", username)
                insertCmd.Parameters.AddWithValue("@password", password)
                insertCmd.ExecuteNonQuery()
                Return True
            End Using
        End Using
    End Function
End Module