Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Module DatabaseHelper

    Private connectionString As String = "server=localhost;userid=root;password=;database=thesis_buddy;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim salt As String = "ThesisBuddySalt" ' Simple salt, in production use random salt
            Dim combined As String = password & salt
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(combined)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Public Function LoginUser(username As String, password As String) As Boolean
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Dim query As String = "SELECT password FROM users WHERE username = @username"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Dim hashedPassword As String = Convert.ToString(cmd.ExecuteScalar())
                If String.IsNullOrEmpty(hashedPassword) Then Return False
                Return hashedPassword = HashPassword(password)
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
            ' Hash password
            Dim hashedPassword As String = HashPassword(password)
            ' Insert
            Dim insertQuery As String = "INSERT INTO users (username, password) VALUES (@username, @password)"
            Using insertCmd As New MySqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@username", username)
                insertCmd.Parameters.AddWithValue("@password", hashedPassword)
                insertCmd.ExecuteNonQuery()
                Return True
            End Using
        End Using
    End Function
End Module