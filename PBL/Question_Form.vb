Imports System.Collections
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.Json

Public Class Question_Form
    ' legacy step-based method removed in favor of pagination
    Private Const QUESTIONS_PER_PAGE As Integer = 10
    Private Const SB_VERT As Integer = 1
    Private Const SB_BOTH As Integer = 3
    Private Const GWL_STYLE As Integer = -16
    Private Const WS_VSCROLL As Integer = &H200000
    Private Const WS_HSCROLL As Integer = &H100000
    Private ReadOnly disableCustomScroll As Boolean = True

    Private Shared ReadOnly YESNO_OPTIONS As String() = {"Ya", "Tidak"}
    Private Shared ReadOnly LANGUAGE_LIST As String() = {
        "Bahasa Indonesia",
        "English",
        "Mandarin",
        "Japanese",
        "Korean",
        "German",
        "French",
        "Arabic",
        "Spanish",
        "Other"
    }

    Private Shared ReadOnly THEME_TEXT As Color = Color.FromArgb(30, 41, 59)
    Private Shared ReadOnly THEME_MUTED_TEXT As Color = Color.FromArgb(100, 116, 139)
    Private Shared ReadOnly THEME_PRIMARY As Color = Color.FromArgb(37, 99, 235)
    Private Shared ReadOnly THEME_PRIMARY_ALT As Color = Color.FromArgb(59, 130, 246)
    Private Shared ReadOnly THEME_DANGER As Color = Color.FromArgb(239, 68, 68)
    Private Shared ReadOnly THEME_CARD As Color = Color.White
    Private Shared ReadOnly THEME_CARD_GLOW As Color = Color.FromArgb(229, 240, 255)
    Private Shared ReadOnly THEME_BORDER As Color = Color.FromArgb(203, 213, 225)
    Private Shared ReadOnly THEME_BORDER_LIGHT As Color = Color.FromArgb(226, 232, 240)
    Private Shared ReadOnly THEME_INPUT_BG As Color = Color.White
    Private Shared ReadOnly THEME_INPUT_FOCUS As Color = Color.FromArgb(219, 234, 254)
    Private Shared ReadOnly THEME_SURFACE As Color = Color.FromArgb(248, 250, 252)
    Private Shared ReadOnly THEME_SUCCESS As Color = Color.FromArgb(34, 197, 94)
    Private Shared ReadOnly THEME_SUCCESS_SOFT As Color = Color.FromArgb(220, 252, 231)
    Private Shared ReadOnly THEME_PENDING_SOFT As Color = Color.FromArgb(254, 226, 226)
    Private Shared ReadOnly THEME_PENDING_TEXT As Color = Color.FromArgb(239, 68, 68)

    Private allQuestions As List(Of QuestionModel) = New List(Of QuestionModel)()
    Private ReadOnly answers As Dictionary(Of String, Object) = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
    Private currentPageIndex As Integer
    Private totalPages As Integer

    Private questionLayoutHandlerAttached As Boolean
    Private scrollEventsAttached As Boolean
    Private handleCreatedHooked As Boolean
    Private thumbDragging As Boolean
    Private thumbDragOffsetY As Integer
    Private isSyncingScroll As Boolean
    Private logoContainerConfigured As Boolean

    <DllImport("user32.dll")>
    Private Shared Function ShowScrollBar(hWnd As IntPtr, wBar As Integer, bShow As Boolean) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SetWindowLong(hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
    End Function

    Private Sub Question_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.DoubleBuffered = True
            Me.WindowState = FormWindowState.Maximized
            ConfigureLogoContainer()
            AttachQuestionLayoutHandler()
            ConfigureCustomScrollSystem()
            LoadQuestionsAndRender()
        Catch ex As Exception
            MessageBox.Show($"Terjadi kesalahan saat memuat pertanyaan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadQuestionsAndRender()
        Try
            Dim fetched = DatabaseHelper.GetAllActiveQuestions()
            allQuestions = If(fetched, New List(Of QuestionModel)())
        Catch ex As Exception
            allQuestions = New List(Of QuestionModel)()
            MessageBox.Show($"Gagal mengambil daftar pertanyaan dari database: {ex.Message}", "Database", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        If allQuestions Is Nothing Then
            allQuestions = New List(Of QuestionModel)()
        End If

        allQuestions = allQuestions.
            Where(Function(q) q IsNot Nothing AndAlso q.Active).
            OrderBy(Function(q) q.QStep).
            ThenBy(Function(q) q.Id).
            ToList()

        answers.Clear()
        totalPages = If(allQuestions.Count = 0, 0, CInt(Math.Ceiling(allQuestions.Count / CDbl(QUESTIONS_PER_PAGE))))
        EnsureCurrentPageWithinBounds()
        RenderCurrentPage()
    End Sub

    Private Sub EnsureCurrentPageWithinBounds()
        If totalPages <= 0 Then
            currentPageIndex = 0
        Else
            currentPageIndex = Math.Max(0, Math.Min(currentPageIndex, totalPages - 1))
        End If
    End Sub

    Private Function GetPageQuestions() As List(Of QuestionModel)
        If allQuestions Is Nothing OrElse allQuestions.Count = 0 Then
            Return New List(Of QuestionModel)()
        End If

        Dim startIndex = currentPageIndex * QUESTIONS_PER_PAGE
        Return allQuestions.Skip(startIndex).Take(QUESTIONS_PER_PAGE).ToList()
    End Function

    Private Sub RenderCurrentPage()
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionsPanel Is Nothing Then Return
        EnsureCurrentPageWithinBounds()

        Dim baseTextColor = THEME_TEXT
        Dim mutedTextColor = THEME_MUTED_TEXT
        Dim primaryColor = THEME_PRIMARY
        Dim inputMargin = New Padding(0, 0, 0, 12)

        questionsPanel.SuspendLayout()
        questionsPanel.Controls.Clear()

        Dim currentPageQuestions = GetPageQuestions()
        If currentPageQuestions.Count = 0 Then
            questionsPanel.Controls.Add(BuildEmptyStateCard())
        Else
            For i As Integer = 0 To currentPageQuestions.Count - 1
                Dim questionNumber = currentPageIndex * QUESTIONS_PER_PAGE + i + 1
                Dim card = CreateQuestionCard(currentPageQuestions(i), baseTextColor, mutedTextColor, primaryColor, inputMargin, questionNumber)
                questionsPanel.Controls.Add(card)
            Next
        End If

        questionsPanel.ResumeLayout()
        ApplyQuestionCardWidth()
        UpdateSubtitleForPage()
        RenderNavigationControls()
        UpdateCustomScrollBar()
    End Sub

    Private Function BuildEmptyStateCard() As Control
        Dim panel As New Panel()
        panel.AutoSize = True
        panel.Padding = New Padding(12, 32, 12, 32)
        panel.Margin = New Padding(0)

        Dim lbl As New Label()
        lbl.AutoSize = True
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.Text = "Pertanyaan belum tersedia atau tidak aktif."
        lbl.Font = New Font("Segoe UI", 11.0F, FontStyle.Italic)
        lbl.ForeColor = THEME_MUTED_TEXT

        panel.Controls.Add(lbl)
        Return panel
    End Function

    Private Function ResolveQuestionsPanel() As FlowLayoutPanel
        Return FlowLayoutPanelQuestions
    End Function

    Private Function ResolveQuestionsHost() As Panel
        Return PanelQuestionsHost
    End Function

    Private Function ResolveScrollTrack() As Panel
        Return PanelScrollTrack
    End Function

    Private Function ResolveScrollThumb() As Panel
        Return PanelScrollThumb
    End Function

    Private Function IsLastPage() As Boolean
        If totalPages <= 0 Then Return True
        Return currentPageIndex >= totalPages - 1
    End Function

    Private Function ValidateCurrentPage() As Boolean
        If allQuestions Is Nothing OrElse allQuestions.Count = 0 Then Return True
        Dim pageQuestions = GetPageQuestions()
        For Each q In pageQuestions
            If q IsNot Nothing AndAlso q.Active AndAlso Not HasAnswerForQuestion(q.QKey) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function HasAnswerForQuestion(qKey As String) As Boolean
        If String.IsNullOrWhiteSpace(qKey) Then Return False
        If answers Is Nothing OrElse Not answers.ContainsKey(qKey) Then Return False
        Dim raw = answers(qKey)
        If raw Is Nothing Then Return False

        If TypeOf raw Is String Then
            Return Not String.IsNullOrWhiteSpace(Convert.ToString(raw))
        End If

        If TypeOf raw Is Boolean Then Return True

        If TypeOf raw Is IConvertible Then
            Return True
        End If

        Dim dict = TryCast(raw, Collections.IDictionary)
        If dict IsNot Nothing Then
            If dict.Count = 0 Then Return False
            For Each key As Object In dict.Keys
                Dim value = dict(key)
                If value Is Nothing Then Continue For
                Dim numericValue As Double
                If Double.TryParse(Convert.ToString(value), numericValue) Then
                    If numericValue > 0 Then
                        Return True
                    End If
                Else
                    Return True
                End If
            Next
            Return False
        End If

        Dim enumerable = TryCast(raw, IEnumerable)
        If enumerable IsNot Nothing Then
            Return enumerable.Cast(Of Object)().Any()
        End If

        Return True
    End Function

    Private Sub RenderNavigationControls()
        If PanelNav Is Nothing Then Return
        PanelNav.SuspendLayout()
        PanelNav.Controls.Clear()
        PanelNav.Visible = True
        PanelNav.BringToFront()

        Dim baseTextColor = THEME_TEXT
        Dim primaryColor = THEME_PRIMARY
        Dim accentDanger = THEME_DANGER

        Dim btnPrev As New Button()
        btnPrev.Text = "Previous"
        btnPrev.Width = 130
        btnPrev.Enabled = currentPageIndex > 0
        btnPrev.Visible = totalPages > 1
        AddHandler btnPrev.Click, Sub(s, e) NavigatePrevious()
        btnPrev.Height = 42
        btnPrev.Margin = New Padding(0, 0, 16, 0)
        btnPrev.FlatStyle = FlatStyle.Flat
        btnPrev.ForeColor = baseTextColor
        btnPrev.BackColor = THEME_INPUT_BG
        btnPrev.FlatAppearance.BorderColor = THEME_BORDER
        btnPrev.FlatAppearance.BorderSize = 1
        btnPrev.FlatAppearance.MouseOverBackColor = THEME_INPUT_FOCUS
        btnPrev.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240)
        PanelNav.Controls.Add(btnPrev)

        Dim btnNext As New Button()
        btnNext.Text = If(IsLastPage(), "Submit", "Next")
        btnNext.Width = 130
        AddHandler btnNext.Click, Sub(s, e) NavigateNextOrSubmit()
        btnNext.Height = 42
        btnNext.Margin = New Padding(0, 0, 16, 0)
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.ForeColor = Color.White
        btnNext.BackColor = primaryColor
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216)
        btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 64, 175)
        PanelNav.Controls.Add(btnNext)

        Dim btnCancelNav As New Button()
        btnCancelNav.Text = "Cancel"
        btnCancelNav.Width = 130
        AddHandler btnCancelNav.Click, Sub(s, e) Me.Close()
        btnCancelNav.Height = 42
        btnCancelNav.Margin = New Padding(24, 0, 0, 0)
        btnCancelNav.ForeColor = accentDanger
        btnCancelNav.BackColor = THEME_INPUT_BG
        btnCancelNav.FlatStyle = FlatStyle.Flat
        btnCancelNav.FlatAppearance.BorderColor = accentDanger
        btnCancelNav.FlatAppearance.BorderSize = 1
        btnCancelNav.FlatAppearance.MouseOverBackColor = THEME_INPUT_FOCUS
        btnCancelNav.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 226, 226)
        PanelNav.Controls.Add(btnCancelNav)

        PanelNav.ResumeLayout()
    End Sub

    Private Sub UpdateSubtitleForPage()
        If LabelSubtitle Is Nothing Then Return
        Dim total = If(allQuestions Is Nothing, 0, allQuestions.Count)
        If total = 0 Then
            LabelSubtitle.Text = "Tidak ada pertanyaan aktif."
            Return
        End If

        Dim startNumber = currentPageIndex * QUESTIONS_PER_PAGE + 1
        Dim endNumber = Math.Min(total, startNumber + QUESTIONS_PER_PAGE - 1)
        LabelSubtitle.Text = $"Pertanyaan {startNumber}-{endNumber} dari {total}"
    End Sub

    Private Sub NavigatePrevious()
        NavigateToPage(currentPageIndex - 1)
    End Sub

    Private Sub NavigateNextOrSubmit()
        If Not ValidateCurrentPage() Then
            MessageBox.Show("Pastikan semua pertanyaan di halaman ini sudah dijawab.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If IsLastPage() Then
            ButtonSubmit_Click(Me, EventArgs.Empty)
        Else
            NavigateToPage(currentPageIndex + 1)
        End If
    End Sub

    Private Sub NavigateToPage(targetIndex As Integer)
        If totalPages <= 0 Then Return
        Dim clamped = Math.Max(0, Math.Min(totalPages - 1, targetIndex))
        If clamped = currentPageIndex Then Return
        currentPageIndex = clamped
        RenderCurrentPage()
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionsPanel IsNot Nothing Then
            questionsPanel.AutoScrollPosition = New Point(0, 0)
        End If
    End Sub

    ' legacy ShowQuestionsForStep removed

    Private Sub ConfigureCustomScrollSystem()
        Dim panel = ResolveQuestionsPanel()
        Dim track = ResolveScrollTrack()
        Dim thumb = ResolveScrollThumb()
        If panel Is Nothing OrElse track Is Nothing OrElse thumb Is Nothing Then Return

        Dim host = ResolveQuestionsHost()
        EnableDoubleBuffer(panel)
        If host IsNot Nothing Then
            EnableDoubleBuffer(host)
        End If

        panel.AutoScroll = True
        panel.AutoScrollMargin = New Size(0, 12)

        If disableCustomScroll Then
            track.Visible = False
            ShowNativeScrollbars(panel)
            Return
        End If

        panel.HorizontalScroll.Enabled = False
        panel.HorizontalScroll.Visible = False
        panel.VerticalScroll.Visible = False

        If Not scrollEventsAttached Then
            AddHandler panel.Scroll, AddressOf QuestionsPanel_Scrolled
            AddHandler panel.ControlAdded, AddressOf QuestionsPanel_ControlChanged
            AddHandler panel.ControlRemoved, AddressOf QuestionsPanel_ControlChanged
            AddHandler panel.Layout, AddressOf QuestionsPanel_LayoutChanged
            If host IsNot Nothing Then
                AddHandler host.Resize, AddressOf QuestionsHost_Resized
            End If
            AddHandler track.MouseDown, AddressOf ScrollTrack_MouseDown
            AddHandler thumb.MouseDown, AddressOf ScrollThumb_MouseDown
            AddHandler thumb.MouseMove, AddressOf ScrollThumb_MouseMove
            AddHandler thumb.MouseUp, AddressOf ScrollThumb_MouseUp
            scrollEventsAttached = True
        End If

        If Not handleCreatedHooked Then
            AddHandler panel.HandleCreated, AddressOf QuestionsPanel_HandleCreated
            handleCreatedHooked = True
        End If

        HideNativeScrollbars(panel)
        UpdateCustomScrollBar()
    End Sub

    Private Sub AttachQuestionLayoutHandler()
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionLayoutHandlerAttached OrElse questionsPanel Is Nothing Then Return
        AddHandler questionsPanel.SizeChanged, Sub(sender As Object, e As EventArgs) ApplyQuestionCardWidth()
        questionLayoutHandlerAttached = True
    End Sub

    Private Sub ApplyQuestionCardWidth()
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionsPanel Is Nothing Then Return
        Dim availableWidth = questionsPanel.ClientSize.Width - questionsPanel.Padding.Horizontal
        If availableWidth <= 0 Then Return
        For Each ctrl As Control In questionsPanel.Controls
            If TypeOf ctrl Is Panel AndAlso ctrl.Tag IsNot Nothing AndAlso ctrl.Tag.ToString().StartsWith("question-card") Then
                Dim targetWidth = Math.Max(availableWidth, 320)
                ctrl.SuspendLayout()
                ctrl.AutoSize = False
                ctrl.MinimumSize = New Size(targetWidth, 0)
                ctrl.MaximumSize = New Size(targetWidth, Integer.MaxValue)
                ctrl.Width = targetWidth
                Dim preferred = ctrl.GetPreferredSize(New Size(targetWidth, 0))
                If preferred.Height > 0 Then
                    ctrl.Height = preferred.Height
                End If
                ctrl.ResumeLayout(True)
            End If
        Next
    End Sub

    Private Sub HideNativeScrollbars(panel As ScrollableControl)
        If panel Is Nothing OrElse Not panel.IsHandleCreated Then Return
        ShowScrollBar(panel.Handle, SB_VERT, False)
        ShowScrollBar(panel.Handle, SB_BOTH, False)
        Dim style = GetWindowLong(panel.Handle, GWL_STYLE)
        Dim newStyle = style And Not (WS_VSCROLL Or WS_HSCROLL)
        If newStyle <> style Then
            SetWindowLong(panel.Handle, GWL_STYLE, newStyle)
        End If
        panel.HorizontalScroll.Enabled = False
        panel.HorizontalScroll.Visible = False
        panel.VerticalScroll.Visible = False
    End Sub

    Private Sub ShowNativeScrollbars(panel As ScrollableControl)
        If panel Is Nothing OrElse Not panel.IsHandleCreated Then Return
        ShowScrollBar(panel.Handle, SB_VERT, True)
        ShowScrollBar(panel.Handle, SB_BOTH, True)
        Dim style = GetWindowLong(panel.Handle, GWL_STYLE)
        Dim newStyle = style Or WS_VSCROLL
        If newStyle <> style Then
            SetWindowLong(panel.Handle, GWL_STYLE, newStyle)
        End If
        panel.HorizontalScroll.Enabled = False
        panel.HorizontalScroll.Visible = False
        panel.VerticalScroll.Visible = True
    End Sub

    Private Sub QuestionsPanel_HandleCreated(sender As Object, e As EventArgs)
        Dim scrollable = TryCast(sender, ScrollableControl)
        If disableCustomScroll Then
            ShowNativeScrollbars(scrollable)
        Else
            HideNativeScrollbars(scrollable)
        End If
    End Sub

    Private Sub QuestionsPanel_Scrolled(sender As Object, e As ScrollEventArgs)
        If isSyncingScroll Then Return
        UpdateCustomScrollBar()
        Dim ctrl = TryCast(sender, Control)
        If ctrl IsNot Nothing Then
            ctrl.Invalidate()
        End If
    End Sub

    Private Sub QuestionsPanel_ControlChanged(sender As Object, e As ControlEventArgs)
        UpdateCustomScrollBar()
    End Sub

    Private Sub QuestionsPanel_LayoutChanged(sender As Object, e As LayoutEventArgs)
        UpdateCustomScrollBar()
    End Sub

    Private Sub QuestionsHost_Resized(sender As Object, e As EventArgs)
        UpdateCustomScrollBar()
    End Sub

    Private Sub UpdateCustomScrollBar()
        If disableCustomScroll Then Return
        Dim panel = ResolveQuestionsPanel()
        Dim track = ResolveScrollTrack()
        Dim thumb = ResolveScrollThumb()
        If panel Is Nothing OrElse track Is Nothing OrElse thumb Is Nothing Then Return

        Dim viewport = panel.ClientSize.Height
        Dim content = panel.DisplayRectangle.Height
        Dim maxOffset = Math.Max(0, content - viewport)
        Dim hasScroll = maxOffset > 2

        track.Visible = hasScroll
        thumb.Visible = hasScroll
        If Not hasScroll Then
            thumb.Top = track.Padding.Top
            thumbDragging = False
            HideNativeScrollbars(panel)
            Return
        End If

        Dim innerHeight = Math.Max(1, track.Height - track.Padding.Vertical)
        Dim thumbHeight = Math.Max(32, CInt(innerHeight * (viewport / Math.Max(viewport, content))))
        thumb.Height = Math.Min(innerHeight, thumbHeight)

        Dim trackRange = Math.Max(1, innerHeight - thumb.Height)
        Dim currentOffset = Math.Max(0, -panel.AutoScrollPosition.Y)
        Dim thumbOffset = CInt(trackRange * (currentOffset / Math.Max(1, maxOffset)))
        thumb.Top = track.Padding.Top + thumbOffset

        HideNativeScrollbars(panel)
    End Sub

    Private Sub ScrollTrack_MouseDown(sender As Object, e As MouseEventArgs)
        If disableCustomScroll Then Return
        If e.Button <> MouseButtons.Left Then Return
        Dim thumb = ResolveScrollThumb()
        Dim halfHeight = If(thumb IsNot Nothing, thumb.Height \ 2, 0)
        ApplyThumbPositionAndScroll(e.Y - halfHeight)
    End Sub

    Private Sub ScrollThumb_MouseDown(sender As Object, e As MouseEventArgs)
        If disableCustomScroll Then Return
        If e.Button <> MouseButtons.Left Then Return
        thumbDragging = True
        thumbDragOffsetY = e.Y
        Dim thumb = ResolveScrollThumb()
        If thumb IsNot Nothing Then
            thumb.Capture = True
        End If
    End Sub

    Private Sub ScrollThumb_MouseMove(sender As Object, e As MouseEventArgs)
        If disableCustomScroll Then Return
        If Not thumbDragging Then Return
        Dim thumb = ResolveScrollThumb()
        If thumb Is Nothing Then Return
        Dim delta = e.Y - thumbDragOffsetY
        ApplyThumbPositionAndScroll(thumb.Top + delta)
    End Sub

    Private Sub ScrollThumb_MouseUp(sender As Object, e As MouseEventArgs)
        If disableCustomScroll Then Return
        If e.Button <> MouseButtons.Left Then Return
        thumbDragging = False
        Dim thumb = ResolveScrollThumb()
        If thumb IsNot Nothing Then
            thumb.Capture = False
        End If
    End Sub

    Private Sub ApplyThumbPositionAndScroll(requestedTop As Integer)
        If disableCustomScroll Then Return
        Dim panel = ResolveQuestionsPanel()
        Dim track = ResolveScrollTrack()
        Dim thumb = ResolveScrollThumb()
        If panel Is Nothing OrElse track Is Nothing OrElse thumb Is Nothing Then Return

        Dim innerTop = track.Padding.Top
        Dim innerBottom = track.Height - track.Padding.Bottom
        Dim maxTop = innerBottom - thumb.Height
        Dim clampedTop = Math.Max(innerTop, Math.Min(maxTop, requestedTop))
        thumb.Top = clampedTop

        Dim viewport = panel.ClientSize.Height
        Dim content = panel.DisplayRectangle.Height
        Dim maxOffset = Math.Max(0, content - viewport)
        If maxOffset <= 0 Then
            isSyncingScroll = True
            panel.AutoScrollPosition = New Point(0, 0)
            isSyncingScroll = False
            Return
        End If

        Dim travelRange = Math.Max(1, (innerBottom - innerTop) - thumb.Height)
        Dim relativeTop = clampedTop - innerTop
        Dim scrollFraction = relativeTop / CDbl(travelRange)
        Dim targetOffset = CInt(scrollFraction * maxOffset)

        isSyncingScroll = True
        panel.AutoScrollPosition = New Point(0, targetOffset)
        isSyncingScroll = False
        panel.Invalidate()
        UpdateCustomScrollBar()
    End Sub

    Private Sub EnableDoubleBuffer(ctrl As Control)
        If ctrl Is Nothing Then Return
        Dim prop = GetType(Control).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        If prop IsNot Nothing Then
            prop.SetValue(ctrl, True, Nothing)
        End If
    End Sub

    Private Function CreateQuestionCard(question As QuestionModel, baseTextColor As Color, mutedTextColor As Color, primaryColor As Color, inputMargin As Padding, questionNumber As Integer) As Control
        Dim card As New Panel()
        Dim accentColor = If(questionNumber Mod 2 = 0, THEME_PRIMARY, THEME_PRIMARY_ALT)
        card.Tag = $"question-card|{question.QKey}|{accentColor.ToArgb()}"
        card.BackColor = THEME_CARD
        card.Padding = New Padding(24, 20, 24, 20)
        card.Margin = New Padding(0, 0, 0, 18)
        card.AutoSize = True
        card.AutoSizeMode = AutoSizeMode.GrowAndShrink
        card.MinimumSize = New Size(0, 90)
        card.BorderStyle = BorderStyle.None
        AddHandler card.Paint, AddressOf Card_Paint
        EnableDoubleBuffer(card)

        Dim container As New TableLayoutPanel()
        container.ColumnCount = 1
        container.RowCount = 3
        container.Dock = DockStyle.Fill
        container.AutoSize = True
        container.AutoSizeMode = AutoSizeMode.GrowAndShrink
        container.Padding = New Padding(0)
        container.Margin = New Padding(0)
        container.RowStyles.Clear()
        container.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        container.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        container.RowStyles.Add(New RowStyle(SizeType.AutoSize))

        Dim header As New FlowLayoutPanel()
        header.AutoSize = True
        header.Margin = New Padding(0, 0, 0, 6)
        header.Padding = New Padding(0)
        header.WrapContents = False

        Dim questionLabel = questionNumber.ToString("00")
        Dim numberBadge As New Label()
        numberBadge.Text = $"Q{questionLabel}"
        numberBadge.AutoSize = True
        numberBadge.Padding = New Padding(10, 4, 10, 4)
        numberBadge.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        numberBadge.ForeColor = Color.White
        numberBadge.BackColor = accentColor
        numberBadge.Margin = New Padding(0, 0, 8, 0)
        header.Controls.Add(numberBadge)

        Dim keyBadge As New Label()
        Dim keyText = If(String.IsNullOrWhiteSpace(question.QKey), "QUESTION", question.QKey)
        keyBadge.Text = keyText.ToUpperInvariant()
        keyBadge.AutoSize = True
        keyBadge.Padding = New Padding(8, 4, 8, 4)
        keyBadge.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        keyBadge.ForeColor = accentColor
        keyBadge.BackColor = Color.FromArgb(219, 234, 254)
        keyBadge.Margin = New Padding(0, 0, 8, 0)
        header.Controls.Add(keyBadge)

        Dim categoryText = If(String.IsNullOrWhiteSpace(question.Category), "General", question.Category)
        Dim categoryBadge As New Label()
        categoryBadge.Text = categoryText.ToUpperInvariant()
        categoryBadge.AutoSize = True
        categoryBadge.Padding = New Padding(8, 4, 8, 4)
        categoryBadge.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        categoryBadge.ForeColor = THEME_MUTED_TEXT
        categoryBadge.BackColor = Color.FromArgb(241, 245, 249)
        header.Controls.Add(categoryBadge)

        Dim statusBadge As New Label()
        statusBadge.Name = "LabelAnsweredStatus"
        statusBadge.AutoSize = True
        statusBadge.Padding = New Padding(8, 4, 8, 4)
        statusBadge.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        statusBadge.Margin = New Padding(8, 0, 0, 0)
        header.Controls.Add(statusBadge)
        ApplyAnsweredBadgeStyle(statusBadge, HasAnswerForQuestion(question.QKey))

        Dim promptText As String = question.Prompt
        If Not String.IsNullOrWhiteSpace(question.QKey) Then
            promptText = $"[{question.QKey}] {question.Prompt}"
        End If

        Dim lbl As New Label()
        lbl.Text = promptText
        lbl.ForeColor = baseTextColor
        lbl.AutoSize = True
        lbl.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lbl.Margin = New Padding(0, 4, 0, 14)
        lbl.MaximumSize = New Size(820, 0)

        Dim inputControl = BuildInputControl(question, baseTextColor, primaryColor, inputMargin)

        container.Controls.Add(header, 0, 0)
        container.Controls.Add(lbl, 0, 1)
        container.Controls.Add(inputControl, 0, 2)

        card.Controls.Add(container)

        Return card
    End Function

    Private Function BuildInputControl(question As QuestionModel, baseTextColor As Color, primaryColor As Color, inputMargin As Padding) As Control
        Dim typ As String = If(question.QType, String.Empty).ToLowerInvariant()
        Dim preferredWidth = ComputeInputWidth()

        Select Case typ
            Case "text", "string"
                Dim tb As New TextBox()
                tb.Width = preferredWidth
                tb.MinimumSize = New Size(preferredWidth, tb.Height)
                tb.Anchor = AnchorStyles.Left Or AnchorStyles.Right
                tb.ForeColor = baseTextColor
                tb.BackColor = THEME_INPUT_BG
                tb.BorderStyle = BorderStyle.FixedSingle
                tb.Padding = New Padding(6)
                tb.Margin = inputMargin
                If answers.ContainsKey(question.QKey) Then
                    tb.Text = Convert.ToString(answers(question.QKey))
                End If
                AddHandler tb.TextChanged,
                    Sub(s, ev)
                        answers(question.QKey) = tb.Text
                        UpdateAnsweredStateFor(question.QKey)
                    End Sub
                Return WrapInput(tb)

            Case "number"
                Dim tbn As New TextBox()
                tbn.Width = Math.Max(200, preferredWidth \ 2)
                tbn.MinimumSize = New Size(Math.Max(200, preferredWidth \ 2), tbn.Height)
                tbn.Anchor = AnchorStyles.Left Or AnchorStyles.Right
                tbn.ForeColor = baseTextColor
                tbn.BackColor = THEME_INPUT_BG
                tbn.BorderStyle = BorderStyle.FixedSingle
                tbn.Padding = New Padding(6)
                tbn.Margin = inputMargin
                If answers.ContainsKey(question.QKey) Then
                    tbn.Text = Convert.ToString(answers(question.QKey))
                End If
                AddHandler tbn.TextChanged,
                    Sub(s, ev)
                        If String.IsNullOrWhiteSpace(tbn.Text) Then
                            If answers.ContainsKey(question.QKey) Then
                                answers.Remove(question.QKey)
                            End If
                        Else
                            Dim d As Double
                            If Double.TryParse(tbn.Text, d) Then
                                answers(question.QKey) = d
                            ElseIf answers.ContainsKey(question.QKey) Then
                                answers.Remove(question.QKey)
                            End If
                        End If
                        UpdateAnsweredStateFor(question.QKey)
                    End Sub
                Return WrapInput(tbn)

            Case "kvlist"
                Dim cols As Integer = 3
                Dim tlp As New TableLayoutPanel()
                tlp.AutoSize = True
                tlp.ColumnCount = cols
                tlp.RowCount = CInt(Math.Ceiling(LANGUAGE_LIST.Length / CDbl(cols)))
                tlp.Padding = New Padding(0)
                tlp.Margin = inputMargin
                tlp.GrowStyle = TableLayoutPanelGrowStyle.AddRows
                tlp.Tag = $"kvlist|{question.QKey}"
                tlp.MaximumSize = New Size(preferredWidth, 0)

                For i As Integer = 0 To cols - 1
                    tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, CSng(100.0 / cols)))
                Next

                Dim idx As Integer = 0
                For Each lang In LANGUAGE_LIST
                    Dim r = idx \ cols
                    Dim c = idx Mod cols

                    Dim itemPanel As New Panel()
                    itemPanel.AutoSize = True
                    itemPanel.Padding = New Padding(2)

                    Dim l As New Label()
                    l.Text = lang
                    l.ForeColor = baseTextColor
                    l.AutoSize = True
                    l.Top = 2
                    l.Left = 2
                    itemPanel.Controls.Add(l)

                    Dim nud As New NumericUpDown()
                    nud.Minimum = CDec(0)
                    nud.Maximum = CDec(5)
                    nud.DecimalPlaces = 1
                    nud.Increment = CDec(0.1)
                    nud.Value = CDec(0)
                    nud.Width = 90
                    nud.Top = l.Bottom + 6
                    nud.Left = 2
                    nud.ForeColor = baseTextColor
                    nud.BackColor = THEME_INPUT_BG
                    nud.Tag = lang

                    AddHandler nud.ValueChanged, AddressOf LanguageNumeric_ValueChanged
                    AddHandler nud.GotFocus, AddressOf LanguageNumeric_GotFocus
                    AddHandler nud.LostFocus, AddressOf LanguageNumeric_LostFocus

                    itemPanel.Controls.Add(nud)

                    Dim placeholder As New Panel()
                    placeholder.AutoSize = True
                    placeholder.Controls.Add(itemPanel)

                    While tlp.RowCount <= r
                        tlp.RowCount += 1
                        tlp.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                    End While

                    tlp.Controls.Add(placeholder, c, r)
                    idx += 1
                Next

                UpdateKvlistAnswers(tlp, question.QKey)
                UpdateAnsweredStateFor(question.QKey)
                Return WrapInput(tlp)

            Case "select"
                Dim separators = New String() {",", "|", ";", Environment.NewLine}
                Dim rawOptions = If(question.Options, String.Empty)
                Dim optionList = rawOptions.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                Dim cleaned = optionList.Select(Function(opt) opt.Trim()).Where(Function(opt) Not String.IsNullOrWhiteSpace(opt)).ToList()
                If cleaned.Count = 0 Then Exit Select
                Dim radioGroup = BuildRadioOptionGroup(question.QKey, cleaned, baseTextColor, primaryColor, inputMargin, preferredWidth)
                Return radioGroup

            Case "yesno"
                Dim yesNoList = YESNO_OPTIONS.Select(Function(opt) opt).ToList()
                Dim yesNoGroup = BuildRadioOptionGroup(question.QKey, yesNoList, baseTextColor, primaryColor, inputMargin, Math.Max(260, preferredWidth \ 2))
                Return yesNoGroup

            Case Else
                Dim tbf As New TextBox()
                tbf.Width = preferredWidth
                tbf.MinimumSize = New Size(preferredWidth, tbf.Height)
                tbf.Anchor = AnchorStyles.Left Or AnchorStyles.Right
                tbf.ForeColor = baseTextColor
                tbf.BackColor = THEME_INPUT_BG
                tbf.BorderStyle = BorderStyle.FixedSingle
                tbf.Padding = New Padding(6)
                tbf.Margin = inputMargin
                If answers.ContainsKey(question.QKey) Then
                    tbf.Text = Convert.ToString(answers(question.QKey))
                End If
                AddHandler tbf.TextChanged,
                    Sub(s, ev)
                        answers(question.QKey) = tbf.Text
                        UpdateAnsweredStateFor(question.QKey)
                    End Sub
                Return WrapInput(tbf)
        End Select

        Dim fallback As New TextBox()
        fallback.Width = preferredWidth
        fallback.MinimumSize = New Size(preferredWidth, fallback.Height)
        fallback.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fallback.ForeColor = baseTextColor
        fallback.BackColor = THEME_INPUT_BG
        fallback.BorderStyle = BorderStyle.FixedSingle
        fallback.Padding = New Padding(6)
        fallback.Margin = inputMargin
        If answers.ContainsKey(question.QKey) Then
            fallback.Text = Convert.ToString(answers(question.QKey))
        End If
        AddHandler fallback.TextChanged,
            Sub(s, ev)
                answers(question.QKey) = fallback.Text
                UpdateAnsweredStateFor(question.QKey)
            End Sub
        Return WrapInput(fallback)
    End Function

    Private Function WrapInput(control As Control) As Control
        If TypeOf control Is TableLayoutPanel Then
            control.Margin = New Padding(0)
            Return control
        End If

        Dim wrapper As New Panel()
        Dim savedMargin = control.Margin
        control.Margin = New Padding(0)
        wrapper.AutoSize = True
        wrapper.AutoSizeMode = AutoSizeMode.GrowAndShrink
        wrapper.Padding = New Padding(0)
        wrapper.Margin = savedMargin
        wrapper.Controls.Add(control)
        Return wrapper
    End Function

    Private Sub ApplyAnsweredBadgeStyle(badge As Label, isAnswered As Boolean)
        If badge Is Nothing Then Return
        If isAnswered Then
            badge.Text = "Sudah dijawab"
            badge.ForeColor = THEME_SUCCESS
            badge.BackColor = THEME_SUCCESS_SOFT
        Else
            badge.Text = "Belum dijawab"
            badge.ForeColor = THEME_PENDING_TEXT
            badge.BackColor = THEME_PENDING_SOFT
        End If
    End Sub

    Private Sub UpdateAnsweredStateFor(qKey As String)
        If String.IsNullOrWhiteSpace(qKey) Then Return
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionsPanel Is Nothing Then Return
        For Each ctrl As Control In questionsPanel.Controls
            If ctrl Is Nothing OrElse ctrl.Tag Is Nothing Then Continue For
            Dim tagParts = ctrl.Tag.ToString().Split("|"c)
            If tagParts.Length >= 2 AndAlso String.Equals(tagParts(1), qKey, StringComparison.OrdinalIgnoreCase) Then
                Dim badge = FindAnsweredBadge(ctrl)
                If badge IsNot Nothing Then
                    ApplyAnsweredBadgeStyle(badge, HasAnswerForQuestion(qKey))
                End If
                Exit For
            End If
        Next
    End Sub

    Private Function FindAnsweredBadge(parent As Control) As Label
        If parent Is Nothing Then Return Nothing
        For Each child As Control In parent.Controls
            Dim lbl = TryCast(child, Label)
            If lbl IsNot Nothing AndAlso String.Equals(lbl.Name, "LabelAnsweredStatus", StringComparison.Ordinal) Then
                Return lbl
            End If
            Dim nested = FindAnsweredBadge(child)
            If nested IsNot Nothing Then
                Return nested
            End If
        Next
        Return Nothing
    End Function

    Private Function BuildRadioOptionGroup(qKey As String, options As IEnumerable(Of String), baseTextColor As Color, primaryColor As Color, inputMargin As Padding, preferredWidth As Integer) As Control
        Dim optionItems = options?.Where(Function(opt) Not String.IsNullOrWhiteSpace(opt)).Select(Function(opt) opt.Trim()).ToList()
        Dim group As New FlowLayoutPanel()
        group.AutoSize = True
        group.AutoSizeMode = AutoSizeMode.GrowAndShrink
        group.FlowDirection = FlowDirection.LeftToRight
        group.WrapContents = True
        group.Padding = New Padding(0)
        group.Margin = inputMargin
        group.MaximumSize = New Size(preferredWidth, 0)

        Dim existingValue As String = Nothing
        If answers.ContainsKey(qKey) Then
            existingValue = Convert.ToString(answers(qKey))
        End If

        If optionItems Is Nothing OrElse optionItems.Count = 0 Then
            Return group
        End If

        For Each opt In optionItems
                Dim radio As New RadioButton()
                radio.Appearance = Appearance.Button
                radio.AutoSize = True
                radio.Text = opt
                radio.Cursor = Cursors.Hand
                radio.FlatStyle = FlatStyle.Flat
                radio.FlatAppearance.BorderSize = 1
                radio.FlatAppearance.BorderColor = THEME_BORDER
                radio.FlatAppearance.CheckedBackColor = THEME_INPUT_FOCUS
                radio.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 242, 254)
                radio.Margin = New Padding(0, 0, 10, 10)
                radio.Padding = New Padding(16, 10, 16, 10)
                radio.TextAlign = ContentAlignment.MiddleCenter
            radio.Checked = String.Equals(existingValue, opt, StringComparison.OrdinalIgnoreCase)
            UpdateRadioVisualState(radio, radio.Checked, primaryColor, baseTextColor)
            AddHandler radio.CheckedChanged,
                Sub(sender, args)
                    Dim rb = DirectCast(sender, RadioButton)
                    UpdateRadioVisualState(rb, rb.Checked, primaryColor, baseTextColor)
                    If rb.Checked Then
                        answers(qKey) = rb.Text
                        UpdateAnsweredStateFor(qKey)
                    ElseIf Not group.Controls.OfType(Of RadioButton)().Any(Function(r) r.Checked)
                        If answers.ContainsKey(qKey) Then
                            answers.Remove(qKey)
                        End If
                        UpdateAnsweredStateFor(qKey)
                    End If
                End Sub
            group.Controls.Add(radio)
        Next

        Return group
    End Function

    Private Sub UpdateRadioVisualState(radio As RadioButton, isChecked As Boolean, primaryColor As Color, baseTextColor As Color)
        Dim borderColor = THEME_BORDER
        Dim checkedBg As Color = THEME_INPUT_FOCUS
        radio.BackColor = If(isChecked, checkedBg, THEME_INPUT_BG)
        radio.FlatAppearance.BorderColor = If(isChecked, THEME_PRIMARY, borderColor)
        radio.ForeColor = If(isChecked, THEME_PRIMARY, baseTextColor)
    End Sub

    Private Sub LanguageNumeric_ValueChanged(sender As Object, e As EventArgs)
        Dim nud = TryCast(sender, NumericUpDown)
        If nud Is Nothing Then Return


        Dim tlp = FindParentOfType(nud, GetType(TableLayoutPanel))
        If tlp IsNot Nothing Then

            UpdateAllKvlistAnswers()
            Dim tagValue = Convert.ToString(tlp.Tag)
            If Not String.IsNullOrWhiteSpace(tagValue) AndAlso tagValue.StartsWith("kvlist|") Then
                Dim qKey = tagValue.Substring(7)
                UpdateAnsweredStateFor(qKey)
            End If
        End If
    End Sub

    Private Sub LanguageNumeric_GotFocus(sender As Object, e As EventArgs)
        Dim nud = TryCast(sender, NumericUpDown)
        If nud IsNot Nothing Then
            nud.BackColor = THEME_INPUT_FOCUS
        End If
    End Sub

    Private Sub LanguageNumeric_LostFocus(sender As Object, e As EventArgs)
        Dim nud = TryCast(sender, NumericUpDown)
        If nud IsNot Nothing Then
            nud.BackColor = THEME_INPUT_BG
        End If
    End Sub

    Private Sub UpdateKvlistAnswers(tlp As TableLayoutPanel, qKey As String)
        Try
            Dim dict As New Dictionary(Of String, Double)()
            For Each ctrl As Control In tlp.Controls
                For Each inner As Control In ctrl.Controls
                    For Each child As Control In inner.Controls
                        If TypeOf child Is NumericUpDown Then
                            Dim nud As NumericUpDown = DirectCast(child, NumericUpDown)
                            Dim lang = Convert.ToString(nud.Tag)
                            If Not String.IsNullOrWhiteSpace(lang) Then
                                Dim normalized As Double = CDbl(nud.Value) / 5.0
                                dict(lang) = ExpertEngine.Normalize(normalized)
                            End If
                        End If
                    Next
                Next
            Next
            answers(qKey) = dict
        Catch
        End Try
    End Sub

    Private Sub UpdateAllKvlistAnswers()
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionsPanel Is Nothing Then Return
        For Each tlp As TableLayoutPanel In EnumerateDescendants(Of TableLayoutPanel)(questionsPanel)
            Dim tagValue = Convert.ToString(tlp.Tag)
            If String.IsNullOrWhiteSpace(tagValue) OrElse Not tagValue.StartsWith("kvlist|") Then Continue For
            Dim qKey = tagValue.Substring(7)
            UpdateKvlistAnswers(tlp, qKey)
            UpdateAnsweredStateFor(qKey)
        Next
    End Sub

    Private Iterator Function EnumerateDescendants(Of T As Control)(parent As Control) As IEnumerable(Of T)
        If parent Is Nothing Then Return
        For Each child As Control In parent.Controls
            If TypeOf child Is T Then
                Yield DirectCast(child, T)
            End If
            For Each nested In EnumerateDescendants(Of T)(child)
                Yield nested
            Next
        Next
    End Function

    Private Function ComputeInputWidth() As Integer
        Dim questionsPanel = ResolveQuestionsPanel()
        If questionsPanel Is Nothing Then Return 420
        Dim width = questionsPanel.ClientSize.Width - questionsPanel.Padding.Horizontal - 60
        Return Math.Max(width, 220)
    End Function

    Private Sub Card_Paint(sender As Object, e As PaintEventArgs)
        Dim card = TryCast(sender, Panel)
        If card Is Nothing Then Return
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = card.ClientRectangle
        If rect.Width <= 0 OrElse rect.Height <= 0 Then Return
        rect.Inflate(-1, -1)
        Dim accentColor = THEME_PRIMARY
        If card.Tag IsNot Nothing Then
            Dim tagParts = card.Tag.ToString().Split("|"c)
            If tagParts.Length >= 3 Then
                Dim accentArgb As Integer
                If Integer.TryParse(tagParts(2), accentArgb) Then
                    accentColor = Color.FromArgb(accentArgb)
                End If
            End If
        End If

        Using path = BuildRoundedPath(rect, 18)
            Dim topColor = THEME_CARD
            Dim bottomColor = THEME_CARD_GLOW
            Using fillBrush As New LinearGradientBrush(rect, topColor, bottomColor, LinearGradientMode.Vertical)
                e.Graphics.FillPath(fillBrush, path)
            End Using

            Using borderPen As New Pen(THEME_BORDER)
                e.Graphics.DrawPath(borderPen, path)
            End Using

            Dim accentRect = rect
            accentRect.Height = Math.Min(5, rect.Height)
            Using accentBrush As New LinearGradientBrush(accentRect, accentColor, Color.FromArgb(150, accentColor), LinearGradientMode.Horizontal)
                e.Graphics.FillRectangle(accentBrush, accentRect.Left + 8, accentRect.Top + 6, accentRect.Width - 16, 2)
            End Using
        End Using
    End Sub

    Private Function BuildRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter = radius * 2
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Function FindParentOfType(child As Control, t As Type) As Control
        Dim p = child.Parent
        While p IsNot Nothing
            If p.GetType() Is t OrElse p.GetType().IsSubclassOf(t) Then Return p
            p = p.Parent
        End While
        Return Nothing
    End Function

    Private Sub ConfigureLogoContainer()
        If logoContainerConfigured Then Return
        Dim found = Me.Controls.Find("PanelLogoContainer", True)
        If found Is Nothing OrElse found.Length = 0 Then Return

        Dim container As Panel = TryCast(found(0), Panel)
        If container Is Nothing Then Return

        container.BackColor = Color.White
        container.BringToFront()
        Dim parentCard = TryCast(container.Parent, Panel)
        If parentCard IsNot Nothing Then
            parentCard.Controls.SetChildIndex(container, parentCard.Controls.Count - 1)
            AddHandler parentCard.Layout, AddressOf PanelCard_Layout
            PanelCard_Layout(parentCard, EventArgs.Empty)
        End If
        UpdateLogoContainerShape(container)

        AddHandler container.Resize, AddressOf LogoContainer_Resize
        AddHandler container.Paint, AddressOf LogoContainer_Paint

        logoContainerConfigured = True
    End Sub

    Private Sub LogoContainer_Resize(sender As Object, e As EventArgs)
        Dim panel = TryCast(sender, Panel)
        If panel Is Nothing Then Return
        UpdateLogoContainerShape(panel)
        panel.Invalidate()
    End Sub

    Private Sub LogoContainer_Paint(sender As Object, e As PaintEventArgs)
        Dim panel = TryCast(sender, Panel)
        If panel Is Nothing Then Return

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = panel.ClientRectangle
        rect.Inflate(-1, -1)

        Dim shadowRect = Rectangle.Inflate(rect, -2, -2)
        shadowRect.Offset(4, 4)

        Using shadowPath As New GraphicsPath()
            shadowPath.AddEllipse(shadowRect)
            Using shadowBrush As New PathGradientBrush(shadowPath)
                shadowBrush.CenterColor = Color.FromArgb(40, 15, 23, 42)
                shadowBrush.SurroundColors = {Color.FromArgb(0, 15, 23, 42)}
                e.Graphics.FillPath(shadowBrush, shadowPath)
            End Using
        End Using

        Using brush As New LinearGradientBrush(rect, Color.FromArgb(250, 253, 255), Color.FromArgb(229, 240, 255), LinearGradientMode.ForwardDiagonal)
            e.Graphics.FillEllipse(brush, rect)
        End Using

        Using pen As New Pen(Color.FromArgb(96, 165, 250), 2)
            e.Graphics.DrawEllipse(pen, rect)
        End Using
    End Sub

    Private Sub UpdateLogoContainerShape(panel As Panel)
        Dim rect = panel.ClientRectangle
        rect.Inflate(-1, -1)

        Using path As New GraphicsPath()
            path.AddEllipse(rect)
            panel.Region = New Region(path)
        End Using
    End Sub

    Private Sub PanelCard_Layout(sender As Object, e As EventArgs)
        Dim card = TryCast(sender, Panel)
        If card Is Nothing Then Return

        Dim logoPanel = card.Controls.OfType(Of Panel)().FirstOrDefault(Function(p) p.Name = "PanelLogoContainer")
        If logoPanel Is Nothing Then Return

        Dim title = card.Controls.OfType(Of Label)().FirstOrDefault(Function(lbl) lbl.Name = "LabelTitle")
        If title Is Nothing Then Return

        Dim topAlign = title.Top + ((title.Height - logoPanel.Height) \ 2)
        If topAlign < card.Padding.Top Then
            topAlign = card.Padding.Top
        End If

        logoPanel.Top = topAlign
        logoPanel.Left = card.Padding.Left

        If title.Left < logoPanel.Right + 16 Then
            title.Left = logoPanel.Right + 24
        End If

        If LabelSubtitle IsNot Nothing Then
            LabelSubtitle.Left = title.Left
        End If
    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click
        Dim questionBank = allQuestions
        If questionBank Is Nothing OrElse questionBank.Count = 0 Then
            questionBank = DatabaseHelper.GetAllActiveQuestions()
        End If

        If questionBank Is Nothing OrElse questionBank.Count = 0 Then
            MessageBox.Show("Daftar pertanyaan belum tersedia. Pastikan koneksi database aktif.")
            Return
        End If

        Dim unanswered = questionBank.Where(Function(q) q IsNot Nothing AndAlso q.Active AndAlso Not HasAnswerForQuestion(q.QKey)).ToList()
        If unanswered.Count > 0 Then
            Dim firstMissing = unanswered.First()
            Dim keyInfo = If(firstMissing IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(firstMissing.QKey), firstMissing.QKey, "pertanyaan belum terjawab")
            MessageBox.Show($"Masih ada {unanswered.Count} pertanyaan yang belum dijawab. Contoh: {keyInfo}", "Lengkapi Jawaban", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim username As String = Environment.UserName
        Dim profile = ExpertEngine.Evaluate(answers, questionBank)
        ExpertEngine.SaveConsultationToDb(username, answers, profile)

        ' Tampilkan hasil dengan MotivationProfileDialog (UI modern)
        Dim rekomList As New List(Of String)(profile.Recommendations)
        Dim skorDict As New Dictionary(Of String, Double)(profile.Scores)
        Using dlg As New MotivationProfileDialog(profile.PrimaryCategory, skorDict, rekomList)
            dlg.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub PictureLogo_Click(sender As Object, e As EventArgs) Handles PictureLogo.Click

    End Sub
End Class