Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class MotivationProfileDialog
    Inherits Form

    Private labelTitle As Label
    Private labelDominant As Label
    Private labelScores As Label
    Private labelRekomendasi As Label
    Private rekomendasiGrid As DataGridView
    Private buttonPrint As Button
    Private buttonOK As Button
    Private ReadOnly scoreChart As ScoreChartPanel
    Private ReadOnly printDocument As PrintDocument
    Private ReadOnly previewDialog As PrintPreviewDialog
    Private printRowIndex As Integer

    Public Sub New(dominant As String, scores As Dictionary(Of String, Double), rekomendasi As List(Of String))
        Me.Text = "Profil Motivasi"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(500, 560)
        Me.Font = New Font("Segoe UI", 11.0F)
        Me.BackColor = Color.FromArgb(250, 250, 255)

        printDocument = New PrintDocument()
        printRowIndex = 0
        AddHandler printDocument.PrintPage, AddressOf OnPrintDocumentPage

        previewDialog = New PrintPreviewDialog() With {
            .Document = printDocument,
            .UseAntiAlias = True,
            .WindowState = FormWindowState.Maximized
        }

        labelTitle = New Label() With {
            .Text = "Profil Motivasi",
            .Font = New Font("Segoe UI", 18.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(24, 18),
            .ForeColor = Color.FromArgb(59, 130, 246)
        }
        Me.Controls.Add(labelTitle)

        labelDominant = New Label() With {
            .Text = $"Kategori Dominan: {dominant}",
            .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(24, 65),
            .ForeColor = Color.FromArgb(31, 41, 55)
        }
        Me.Controls.Add(labelDominant)

        labelScores = New Label() With {
            .Text = "Diagram Skor Certainty Factor:",
            .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(24, 105),
            .ForeColor = Color.FromArgb(31, 41, 55)
        }
        Me.Controls.Add(labelScores)

        scoreChart = New ScoreChartPanel() With {
            .Location = New Point(28, 140),
            .Size = New Size(420, 220)
        }
        scoreChart.SetScores(scores)
        Me.Controls.Add(scoreChart)

        Dim rekomendasiY = scoreChart.Bottom + 20

        labelRekomendasi = New Label() With {
            .Text = "Rekomendasi Judul Skripsi:",
            .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(24, rekomendasiY),
            .ForeColor = Color.FromArgb(31, 41, 55)
        }
        Me.Controls.Add(labelRekomendasi)

        rekomendasiGrid = New DataGridView() With {
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToResizeRows = False,
            .BackgroundColor = Me.BackColor,
            .BorderStyle = BorderStyle.None,
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
            .EnableHeadersVisualStyles = False,
            .Font = New Font("Segoe UI", 10.0F),
            .GridColor = Color.FromArgb(203, 213, 225),
            .Location = New Point(28, rekomendasiY + 34),
            .MultiSelect = False,
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .ScrollBars = ScrollBars.Vertical,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
            .ReadOnly = True,
            .Width = 420
        }

        Dim headerStyle = rekomendasiGrid.ColumnHeadersDefaultCellStyle
        headerStyle.BackColor = Color.FromArgb(226, 232, 240)
        headerStyle.ForeColor = Color.FromArgb(31, 41, 55)
        headerStyle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)

        Dim cellStyle = rekomendasiGrid.DefaultCellStyle
        cellStyle.ForeColor = Color.FromArgb(55, 65, 81)
        cellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254)
        cellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138)
        cellStyle.WrapMode = DataGridViewTriState.True

        rekomendasiGrid.Columns.Add("colNo", "No.")
        rekomendasiGrid.Columns.Add("colJudul", "Judul Skripsi")
        rekomendasiGrid.Columns("colNo").FillWeight = 18
        rekomendasiGrid.Columns("colJudul").FillWeight = 82

        Dim index = 1
        For Each item In rekomendasi
            rekomendasiGrid.Rows.Add(index.ToString(), item)
            index += 1
        Next

        Dim contentHeight = rekomendasiGrid.ColumnHeadersHeight
        contentHeight += rekomendasiGrid.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
        contentHeight += rekomendasiGrid.Padding.Vertical + 4
        rekomendasiGrid.Height = Math.Min(Math.Max(contentHeight, 150), 260)

        Me.Controls.Add(rekomendasiGrid)

        buttonPrint = New Button() With {
            .Text = "Cetak",
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .Size = New Size(120, 40),
            .BackColor = Color.FromArgb(37, 99, 235),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        buttonPrint.FlatAppearance.BorderSize = 0
        AddHandler buttonPrint.Click, AddressOf OnPrintButtonClick

        buttonOK = New Button() With {
            .Text = "OK",
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .Size = New Size(120, 40),
            .BackColor = Color.FromArgb(59, 130, 246),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        buttonOK.FlatAppearance.BorderSize = 0
        AddHandler buttonOK.Click, Sub() Me.DialogResult = DialogResult.OK
        Dim buttonTop = rekomendasiGrid.Bottom + 30
        Dim centerX = Me.ClientSize.Width \ 2
        buttonPrint.Location = New Point(centerX - buttonPrint.Width - 10, buttonTop)
        buttonOK.Location = New Point(centerX + 10, buttonTop)
        Me.Controls.Add(buttonPrint)
        Me.Controls.Add(buttonOK)

        Dim newClientHeight = buttonOK.Bottom + 32
        If newClientHeight > Me.ClientSize.Height Then
            Me.ClientSize = New Size(Me.ClientSize.Width, newClientHeight)
        End If
    End Sub
    
    Private Sub OnPrintButtonClick(sender As Object, e As EventArgs)
        Try
            printRowIndex = 0
            previewDialog.Document = printDocument
            Dim control = previewDialog.PrintPreviewControl
            control.AutoZoom = True
            control.Zoom = 1.0
            control.StartPage = 0
            previewDialog.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(Me, $"Pratinjau cetak gagal: {ex.Message}", "Cetak", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnPrintDocumentPage(sender As Object, e As PrintPageEventArgs)
        Dim g = e.Graphics
        Dim bounds = e.MarginBounds
        Dim currentY = bounds.Top

        Using titleFont As New Font("Segoe UI", 18.0F, FontStyle.Bold),
              headingFont As New Font("Segoe UI", 12.0F, FontStyle.Bold),
              textFont As New Font("Segoe UI", 11.0F),
              accentBrush As New SolidBrush(Color.FromArgb(59, 130, 246)),
              headingBrush As New SolidBrush(Color.FromArgb(31, 41, 55)),
              textBrush As New SolidBrush(Color.FromArgb(55, 65, 81)),
              borderPen As New Pen(Color.FromArgb(148, 163, 184)),
              rowPen As New Pen(Color.FromArgb(203, 213, 225))

            g.DrawString(labelTitle.Text, titleFont, accentBrush, bounds.Left, currentY)
            currentY += CInt(titleFont.GetHeight(g)) + 10

            g.DrawString(labelDominant.Text, headingFont, headingBrush, bounds.Left, currentY)
            currentY += CInt(headingFont.GetHeight(g)) + 6

            g.DrawString(labelScores.Text, headingFont, headingBrush, bounds.Left, currentY)
            currentY += CInt(headingFont.GetHeight(g)) + 10

            Using chartBmp As New Bitmap(scoreChart.Width, scoreChart.Height)
                scoreChart.DrawToBitmap(chartBmp, New Rectangle(Point.Empty, scoreChart.Size))
                Dim chartHeight = CInt(bounds.Width * (scoreChart.Height / Math.Max(1.0R, CDbl(scoreChart.Width))))
                Dim chartRect = New Rectangle(bounds.Left, currentY, bounds.Width, chartHeight)
                g.DrawImage(chartBmp, chartRect)
                currentY += chartRect.Height + 16
            End Using

            g.DrawString(labelRekomendasi.Text, headingFont, headingBrush, bounds.Left, currentY)
            currentY += CInt(headingFont.GetHeight(g)) + 12

            Dim noWidth = CInt(bounds.Width * 0.15)
            Dim judulWidth = bounds.Width - noWidth

            Dim headerBackColor = Color.FromArgb(226, 232, 240)
            Dim headerRect = New Rectangle(bounds.Left, currentY, bounds.Width, CInt(textFont.GetHeight(g)) + 12)
            Using headerBrush As New SolidBrush(headerBackColor)
                g.FillRectangle(headerBrush, headerRect)
            End Using
            g.DrawRectangle(borderPen, headerRect)

            Dim textOffset = headerRect.Top + 6
            g.DrawString("No.", headingFont, headingBrush, bounds.Left + 6, textOffset)
            g.DrawString("Judul Skripsi", headingFont, headingBrush, bounds.Left + noWidth + 6, textOffset)

            currentY = headerRect.Bottom

            Dim rowIndex = printRowIndex
            While rowIndex < rekomendasiGrid.Rows.Count
                Dim noValue = rekomendasiGrid.Rows(rowIndex).Cells(0).Value
                Dim judulValue = rekomendasiGrid.Rows(rowIndex).Cells(1).Value
                Dim noText = If(noValue Is Nothing, String.Empty, noValue.ToString())
                Dim judulText = If(judulValue Is Nothing, String.Empty, judulValue.ToString())

                Dim noSize = TextRenderer.MeasureText(noText, textFont)
                Dim judulSize = TextRenderer.MeasureText(judulText, textFont, New Size(judulWidth - 12, Integer.MaxValue), TextFormatFlags.WordBreak)
                Dim rowHeight = Math.Max(noSize.Height, judulSize.Height) + 12

                If currentY + rowHeight > bounds.Bottom Then
                    e.HasMorePages = True
                    Exit While
                End If

                Dim rowRect = New Rectangle(bounds.Left, currentY, bounds.Width, rowHeight)
                g.DrawRectangle(rowPen, rowRect)

                Dim noRect = New Rectangle(bounds.Left + 6, currentY + 6, noWidth - 12, rowHeight - 12)
                Dim judulRect = New Rectangle(bounds.Left + noWidth + 6, currentY + 6, judulWidth - 12, rowHeight - 12)

                g.DrawString(noText, textFont, textBrush, noRect)
                Using format As New StringFormat() With {
                    .Alignment = StringAlignment.Near,
                    .LineAlignment = StringAlignment.Near
                }
                    g.DrawString(judulText, textFont, textBrush, judulRect, format)
                End Using

                currentY += rowHeight
                rowIndex += 1
            End While

            printRowIndex = rowIndex
            If Not e.HasMorePages Then
                printRowIndex = 0
            End If
        End Using
    End Sub
End Class

Friend Class ScoreChartPanel
    Inherits Panel

    Private ReadOnly chartPadding As Padding = New Padding(40, 24, 24, 44)
    Private ReadOnly scoreData As New List(Of ScoreEntry)

    Public Sub New()
        DoubleBuffered = True
        BackColor = Color.WhiteSmoke
        Margin = New Padding(0)
    End Sub

    Public Sub SetScores(source As IEnumerable(Of KeyValuePair(Of String, Double)))
        scoreData.Clear()
        For Each kvp In source
            scoreData.Add(New ScoreEntry(kvp.Key, kvp.Value))
        Next
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        If scoreData.Count = 0 Then
            DrawEmptyMessage(e.Graphics)
            Return
        End If

        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim left = chartPadding.Left
        Dim top = chartPadding.Top
        Dim right = Width - chartPadding.Right
        Dim bottom = Height - chartPadding.Bottom
        If right <= left OrElse bottom <= top Then Return

        Using axisPen As New Pen(Color.FromArgb(148, 163, 184), 1.5F)
            g.DrawLine(axisPen, left, top, left, bottom)
            g.DrawLine(axisPen, left, bottom, right, bottom)
        End Using

        Dim count = scoreData.Count
        Dim availableWidth = right - left
        Dim spacing = Math.Max(14.0F, availableWidth * 0.05F / Math.Max(count, 1))
        Dim barWidth = (availableWidth - spacing * (count + 1)) / Math.Max(count, 1)
        barWidth = Math.Max(28.0F, barWidth)

        Dim chartHeight = bottom - top
        Dim maxValue = 0.0R
        For Each entry In scoreData
            If entry.Value > maxValue Then
                maxValue = entry.Value
            End If
        Next
        If maxValue <= 0 Then maxValue = 0.0001R

        Using barBrush As New SolidBrush(Color.FromArgb(59, 130, 246)),
              axisFont As New Font("Segoe UI", 10.0F),
              valueFont As New Font("Segoe UI", 9.0F, FontStyle.Bold)

            Dim currentX = left + spacing
            For Each entry In scoreData
                Dim normalized = CSng(entry.Value / maxValue)
                Dim barHeight = chartHeight * normalized
                Dim barTop = bottom - barHeight
                Dim percent = entry.Value * 100

                Dim barRect = New RectangleF(currentX, barTop, barWidth, barHeight)
                g.FillRectangle(barBrush, barRect)

                Dim valueText = percent.ToString("0.0'%'")
                Dim valueSize = TextRenderer.MeasureText(valueText, valueFont)
                Dim valuePoint As New Point(CInt(currentX + (barWidth - valueSize.Width) / 2), CInt(Math.Max(top, barTop - valueSize.Height - 4)))
                TextRenderer.DrawText(g, valueText, valueFont, valuePoint, Color.FromArgb(31, 41, 55))

                Dim labelSize = TextRenderer.MeasureText(entry.Label, axisFont)
                Dim labelPoint As New Point(CInt(currentX + (barWidth - labelSize.Width) / 2), bottom + 6)
                TextRenderer.DrawText(g, entry.Label, axisFont, labelPoint, Color.FromArgb(55, 65, 81))

                currentX += barWidth + spacing
            Next
        End Using
    End Sub

    Private Sub DrawEmptyMessage(g As Graphics)
        Dim message = "Tidak ada skor untuk ditampilkan"
        Using infoFont As New Font("Segoe UI", 10.0F, FontStyle.Italic)
            Dim size = TextRenderer.MeasureText(message, infoFont)
            Dim point As New Point((Width - size.Width) \ 2, (Height - size.Height) \ 2)
            TextRenderer.DrawText(g, message, infoFont, point, Color.FromArgb(107, 114, 128))
        End Using
    End Sub

    Private Class ScoreEntry
        Public Sub New(label As String, value As Double)
            Me.Label = label
            Me.Value = value
        End Sub

        Public Property Label As String
        Public Property Value As Double
    End Class
End Class
