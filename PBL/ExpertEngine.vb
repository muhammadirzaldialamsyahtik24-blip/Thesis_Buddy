Imports System.Text.Json
Imports System.Text

Public Module ExpertEngine

    Public Class Consultation
        Public Property Username As String
        Public Property Timestamp As DateTime
        Public Property Answers As Dictionary(Of String, Object)
        Public Property Recommendations As List(Of String)
    End Class

    ' Normalize a 0-1 value
    Public Function Normalize(value As Double) As Double
        If value < 0 Then Return 0
        If value > 1 Then Return 1
        Return value
    End Function

    ' Hitung skor bunga tertimbang (contoh: rata-rata sederhana)
    Public Function ComputeInterestScore(interests As Dictionary(Of String, Double)) As Double
        If interests.Count = 0 Then Return 0
        Dim sum As Double = 0
        For Each kvp In interests
            sum += kvp.Value
        Next
        Return sum / interests.Count
    End Function

    ' Evaluasi aturan buat menghasilkan rekomendasi
    Public Function Evaluate(answers As Dictionary(Of String, Object)) As List(Of String)
        Dim recs As New List(Of String)()

        ' Ekstrak nilai dengan aman
        Dim prodi As String = If(answers.ContainsKey("prodi"), Convert.ToString(answers("prodi")), "")
        Dim interests As Dictionary(Of String, Double) = If(answers.ContainsKey("interests"), DirectCast(answers("interests"), Dictionary(Of String, Double)), New Dictionary(Of String, Double)())
        Dim skills As Dictionary(Of String, Double) = If(answers.ContainsKey("skills"), DirectCast(answers("skills"), Dictionary(Of String, Double)), New Dictionary(Of String, Double)())
        Dim durationMonths As Double = If(answers.ContainsKey("duration"), Convert.ToDouble(answers("duration")), 3)
        Dim hasIoT As Boolean = If(answers.ContainsKey("devices"), Convert.ToString(answers("devices")).ToLower().Contains("esp") Or Convert.ToString(answers("devices")).ToLower().Contains("rpi"), False)

        ' Normalize inputs
        For Each k In interests.Keys.ToList()
            interests(k) = Normalize(interests(k))
        Next
        For Each k In skills.Keys.ToList()
            skills(k) = Normalize(skills(k))
        Next

        ' contoh rules
        If prodi.ToLower().Contains("ti") AndAlso interests.ContainsKey("AI/ML") AndAlso interests("AI/ML") >= 0.6 AndAlso skills.ContainsKey("Python") AndAlso skills("Python") >= 0.6 Then
            recs.Add("AI analytic: predictive modeling for academic datasets")
        End If

        If prodi.ToLower().Contains("tmj") AndAlso interests.ContainsKey("Game") AndAlso interests("Game") >= 0.6 AndAlso skills.ContainsKey("3D") AndAlso skills("3D") >= 0.6 Then
            recs.Add("Game education: educational game with 3D models")
        End If

        If prodi.ToLower().Contains("tmd") AndAlso hasIoT AndAlso durationMonths >= 4 Then
            recs.Add("IoT high complexity: Smart monitoring with ESP32 and cloud integration")
        End If

        ' Fallback dan prioritas tambahan
        If recs.Count = 0 Then
            ' Gunakan minat teratas (cadangan)
            Dim top = interests.OrderByDescending(Function(p) p.Value).FirstOrDefault()
            If Not top.Key Is Nothing Then
                recs.Add($"Project based on top interest: {top.Key}")
            Else
                recs.Add("General low-complexity project: Web/Mobile app with simple backend")
            End If
        End If

        ' Limit to 3
        Return recs.Take(3).ToList()
    End Function

    Public Function SaveConsultationToDb(username As String, answers As Dictionary(Of String, Object), recommendations As List(Of String)) As Boolean
        Try
            Dim cons As New Consultation()
            cons.Username = username
            cons.Timestamp = DateTime.Now
            cons.Answers = answers
            cons.Recommendations = recommendations
            Dim answersJson As String = JsonSerializer.Serialize(answers)
            Dim recsJson As String = JsonSerializer.Serialize(recommendations)
            Return DatabaseHelper.SaveConsultation(username, answersJson, recsJson)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
