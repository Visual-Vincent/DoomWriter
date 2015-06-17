' Copyright © Visual Vincent 2014-2015
'
' You may not under any circumstances redistribute a modified version of this code,
' but you may however modify this code in the terms of personal use or (for the author) helpful use
' (such as using it to provide helpful fixes or suggestions).
'
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS", WITHOUT ANY WARRANTY.
' THE AUTHOR OR CONTRIBUTORS SHALL NEVER BE HELD RESPONSIBLE FOR ANY DAMAGES CAUSED BY IT.

Imports System.Threading
Imports System.IO

Public Class Form1

#Region "Char Defines"
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Integer
    Dim bA As New Bitmap(My.Resources.A)
    Dim bB As New Bitmap(My.Resources.B)
    Dim bC As New Bitmap(My.Resources.C)
    Dim bD As New Bitmap(My.Resources.D)
    Dim bEl As New Bitmap(My.Resources.E)
    Dim bF As New Bitmap(My.Resources.F)
    Dim bG As New Bitmap(My.Resources.G)
    Dim bH As New Bitmap(My.Resources.H)
    Dim bIL As New Bitmap(My.Resources.I)
    Dim bJ As New Bitmap(My.Resources.J)
    Dim bK As New Bitmap(My.Resources.K)
    Dim bL As New Bitmap(My.Resources.L)
    Dim bM As New Bitmap(My.Resources.M)
    Dim bN As New Bitmap(My.Resources.N)
    Dim bO As New Bitmap(My.Resources.O)
    Dim bP As New Bitmap(My.Resources.P)
    Dim bQ As New Bitmap(My.Resources.Q)
    Dim bR As New Bitmap(My.Resources.R)
    Dim bS As New Bitmap(My.Resources.S)
    Dim bT As New Bitmap(My.Resources.T)
    Dim _bU As New Bitmap(My.Resources.U)
    Dim bV As New Bitmap(My.Resources.V)
    Dim bW As New Bitmap(My.Resources.W)
    Dim bX As New Bitmap(My.Resources.X)
    Dim bY As New Bitmap(My.Resources.Y)
    Dim bZ As New Bitmap(My.Resources.Z)

    Dim bAu As New Bitmap(My.Resources.Au)
    Dim bBu As New Bitmap(My.Resources.Bu)
    Dim bCu As New Bitmap(My.Resources.Cu)
    Dim bDu As New Bitmap(My.Resources.Du)
    Dim bEu As New Bitmap(My.Resources.Eu)
    Dim bGu As New Bitmap(My.Resources.Gu)
    Dim bHu As New Bitmap(My.Resources.Hu)
    Dim bIu As New Bitmap(My.Resources.Iu)
    Dim bKu As New Bitmap(My.Resources.Ku)
    Dim bLu As New Bitmap(My.Resources.Lu)
    Dim bMu As New Bitmap(My.Resources.Mu)
    Dim bNu As New Bitmap(My.Resources.Nu)
    Dim bOu As New Bitmap(My.Resources.Ou)
    Dim bPu As New Bitmap(My.Resources.Pu)
    Dim bQu As New Bitmap(My.Resources.Qu)
    Dim bRu As New Bitmap(My.Resources.Ru)
    Dim bSu As New Bitmap(My.Resources.Su)
    Dim bTu As New Bitmap(My.Resources.Tu)
    Dim bUu As New Bitmap(My.Resources.Uu)
    Dim bVu As New Bitmap(My.Resources.Vu)
    Dim bWu As New Bitmap(My.Resources.Wu)
    Dim bYu As New Bitmap(My.Resources.Yu)

    Dim b_0 As New Bitmap(My.Resources._0)
    Dim b_1 As New Bitmap(My.Resources._1)
    Dim b_2 As New Bitmap(My.Resources._2)
    Dim b_3 As New Bitmap(My.Resources._3)
    Dim b_4 As New Bitmap(My.Resources._4)
    Dim b_5 As New Bitmap(My.Resources._5)
    Dim b_6 As New Bitmap(My.Resources._6)
    Dim b_7 As New Bitmap(My.Resources._7)
    Dim b_8 As New Bitmap(My.Resources._8)
    Dim b_9 As New Bitmap(My.Resources._9)
    Dim bDot As New Bitmap(My.Resources.Dot)
    Dim bAp As New Bitmap(My.Resources.Apostrophe)
    Dim bAp2 As New Bitmap(My.Resources.Apostrophe2)
    Dim bColon As New Bitmap(My.Resources.Colon)
    Dim bComma As New Bitmap(My.Resources.Comma)
    Dim bDollar As New Bitmap(My.Resources.Dollar)
    Dim bEqual As New Bitmap(My.Resources.Equal)
    Dim bExclamation As New Bitmap(My.Resources.Exclamation)
    Dim bLeftS As New Bitmap(My.Resources.Left)
    Dim bRightS As New Bitmap(My.Resources.Right)
    Dim bMinus As New Bitmap(My.Resources.Minus)
    Dim bMultiply As New Bitmap(My.Resources.Multiply)
    Dim bNumber As New Bitmap(My.Resources.Number)
    Dim bPar As New Bitmap(My.Resources.Par)
    Dim bParF As New Bitmap(My.Resources.ParF)
    Dim bPar2 As New Bitmap(My.Resources.Par2)
    Dim bPar2F As New Bitmap(My.Resources.Par2F)
    Dim bPercent As New Bitmap(My.Resources.Percent)
    Dim bPlus As New Bitmap(My.Resources.Plus)
    Dim bQuestion As New Bitmap(My.Resources.Question)
    Dim bSemicolon As New Bitmap(My.Resources.Semicolon)
    Dim bSlash As New Bitmap(My.Resources.Slash)
    Dim bSlash2 As New Bitmap(My.Resources.Slash2)
    Dim bQuotes As New Bitmap(My.Resources.Quotes)
    Dim bRaise As New Bitmap(My.Resources.Raise)
    Dim bUnder As New Bitmap(My.Resources.Under)

    Dim A As New Bitmap(My.Resources.A)
    Dim B As New Bitmap(My.Resources.B)
    Dim C As New Bitmap(My.Resources.C)
    Dim D As New Bitmap(My.Resources.D)
    Dim El As New Bitmap(My.Resources.E)
    Dim F As New Bitmap(My.Resources.F)
    Dim G As New Bitmap(My.Resources.G)
    Dim H As New Bitmap(My.Resources.H)
    Dim IL As New Bitmap(My.Resources.I)
    Dim J As New Bitmap(My.Resources.J)
    Dim K As New Bitmap(My.Resources.K)
    Dim L As New Bitmap(My.Resources.L)
    Dim M As New Bitmap(My.Resources.M)
    Dim N As New Bitmap(My.Resources.N)
    Dim O As New Bitmap(My.Resources.O)
    Dim P As New Bitmap(My.Resources.P)
    Dim Q As New Bitmap(My.Resources.Q)
    Dim R As New Bitmap(My.Resources.R)
    Dim S As New Bitmap(My.Resources.S)
    Dim T As New Bitmap(My.Resources.T)
    Dim U As New Bitmap(My.Resources.U)
    Dim V As New Bitmap(My.Resources.V)
    Dim W As New Bitmap(My.Resources.W)
    Dim X As New Bitmap(My.Resources.X)
    Dim Y As New Bitmap(My.Resources.Y)
    Dim Z As New Bitmap(My.Resources.Z)

    Dim Au As New Bitmap(My.Resources.Au)
    Dim _2Bu As New Bitmap(My.Resources.Bu)
    Dim Cu As New Bitmap(My.Resources.Cu)
    Dim Du As New Bitmap(My.Resources.Du)
    Dim Eu As New Bitmap(My.Resources.Eu)
    Dim Gu As New Bitmap(My.Resources.Gu)
    Dim Hu As New Bitmap(My.Resources.Hu)
    Dim Iu As New Bitmap(My.Resources.Iu)
    Dim Ku As New Bitmap(My.Resources.Ku)
    Dim Lu As New Bitmap(My.Resources.Lu)
    Dim Mu As New Bitmap(My.Resources.Mu)
    Dim Nu As New Bitmap(My.Resources.Nu)
    Dim Ou As New Bitmap(My.Resources.Ou)
    Dim Pu As New Bitmap(My.Resources.Pu)
    Dim Qu As New Bitmap(My.Resources.Qu)
    Dim Ru As New Bitmap(My.Resources.Ru)
    Dim Su As New Bitmap(My.Resources.Su)
    Dim Tu As New Bitmap(My.Resources.Tu)
    Dim Uu As New Bitmap(My.Resources.Uu)
    Dim Vu As New Bitmap(My.Resources.Vu)
    Dim Wu As New Bitmap(My.Resources.Wu)
    Dim Yu As New Bitmap(My.Resources.Yu)

    Dim _0 As New Bitmap(My.Resources._0)
    Dim _1 As New Bitmap(My.Resources._1)
    Dim _2 As New Bitmap(My.Resources._2)
    Dim _3 As New Bitmap(My.Resources._3)
    Dim _4 As New Bitmap(My.Resources._4)
    Dim _5 As New Bitmap(My.Resources._5)
    Dim _6 As New Bitmap(My.Resources._6)
    Dim _7 As New Bitmap(My.Resources._7)
    Dim _8 As New Bitmap(My.Resources._8)
    Dim _9 As New Bitmap(My.Resources._9)
    Dim Dot As New Bitmap(My.Resources.Dot)
    Dim Ap As New Bitmap(My.Resources.Apostrophe)
    Dim Ap2 As New Bitmap(My.Resources.Apostrophe2)
    Dim Colon As New Bitmap(My.Resources.Colon)
    Dim Comma As New Bitmap(My.Resources.Comma)
    Dim Dollar As New Bitmap(My.Resources.Dollar)
    Dim Equal As New Bitmap(My.Resources.Equal)
    Dim Exclamation As New Bitmap(My.Resources.Exclamation)
    Dim LeftS As New Bitmap(My.Resources.Left)
    Dim RightS As New Bitmap(My.Resources.Right)
    Dim Minus As New Bitmap(My.Resources.Minus)
    Dim Multiply As New Bitmap(My.Resources.Multiply)
    Dim Number As New Bitmap(My.Resources.Number)
    Dim Par As New Bitmap(My.Resources.Par)
    Dim ParF As New Bitmap(My.Resources.ParF)
    Dim Par2 As New Bitmap(My.Resources.Par2)
    Dim Par2F As New Bitmap(My.Resources.Par2F)
    Dim Percent As New Bitmap(My.Resources.Percent)
    Dim Plus As New Bitmap(My.Resources.Plus)
    Dim Question As New Bitmap(My.Resources.Question)
    Dim Semicolon As New Bitmap(My.Resources.Semicolon)
    Dim Slash As New Bitmap(My.Resources.Slash)
    Dim Slash2 As New Bitmap(My.Resources.Slash2)
    Dim Quotes As New Bitmap(My.Resources.Quotes)
    Dim Raise As New Bitmap(My.Resources.Raise)
    Dim Under As New Bitmap(My.Resources.Under)
#End Region

#Region "Additional Defines"
    Public Chart As New Bitmap(My.Resources.CHART_NORMAL)

    Dim OldText As String

    Dim Letters As New ImageList()
    Dim NewGraphic As Graphics
    Dim DrawBitmap As Bitmap
    Dim myBrush As New Drawing.TextureBrush(New Bitmap(My.Resources.A))
    Dim OldWidth As Integer
    Dim AllHeight As Integer
    Dim Index As Integer
    Dim Skip As New Collection()
    Dim FinalHeight As Integer
    Dim FinalWidth As Integer
    Dim Blinks As Integer = 3
    Dim Tics As Integer
    Dim NextOffset As Integer
    Dim Skip2 As New Collection()
    Dim CheckOffsetTimes As Integer
#End Region

    '------------------------------------------------------------------------------------------------------------------'

#Region "Form1 Load"
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Letters.ImageSize = New System.Drawing.Size(My.Resources.A.Width, My.Resources.A.Height)
        Letters.Images.Add(My.Resources.A)
        Letters.Images.Add(My.Resources.B)
        Letters.Images.Add(My.Resources.C)
        Letters.Images.Add(My.Resources.D)
        Letters.Images.Add(My.Resources.E)
        Letters.Images.Add(My.Resources.F)
        Letters.Images.Add(My.Resources.G)
        Letters.Images.Add(My.Resources.H)
        Letters.Images.Add(My.Resources.I)
        Letters.Images.Add(My.Resources.J)
        Letters.Images.Add(My.Resources.K)
        Letters.Images.Add(My.Resources.L)
        Letters.Images.Add(My.Resources.M)
        Letters.Images.Add(My.Resources.N)
        Letters.Images.Add(My.Resources.O)
        Letters.Images.Add(My.Resources.P)
        Letters.Images.Add(My.Resources.Q)
        Letters.Images.Add(My.Resources.R)
        Letters.Images.Add(My.Resources.S)
        Letters.Images.Add(My.Resources.T)
        Letters.Images.Add(My.Resources.U)
        Letters.Images.Add(My.Resources.V)
        Letters.Images.Add(My.Resources.X)
        Letters.Images.Add(My.Resources.Y)
        Letters.Images.Add(My.Resources.Z)
        Skip2.Add(" ")
        Skip2.Add(" ")
        Skip2.Add(" ")
        Skip2.Add(" ")
        Skip2.Add(" ")
        Skip2.Add(" ")
        DrawBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        NewGraphic = Graphics.FromImage(DrawBitmap)
        PictureBox1.Image = DrawBitmap
        NewGraphic.Clear(Color.Cyan)

        LoadChars()

    End Sub
#End Region

#Region "LoadChars()"
    Public Sub LoadChars()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''Char definitions'''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        A = CropBitmap(Chart, 0, 0, bA.Width, bA.Height)
        B = CropBitmap(Chart, 16, 0, bB.Width, bB.Height)
        C = CropBitmap(Chart, 32, 0, bC.Width, bC.Height)
        D = CropBitmap(Chart, 47, 0, bD.Width, bD.Height)
        El = CropBitmap(Chart, 63, 0, bEl.Width, bEl.Height)
        F = CropBitmap(Chart, 78, 0, bF.Width, bF.Height)
        G = CropBitmap(Chart, 91, 0, bG.Width, bG.Height)
        H = CropBitmap(Chart, 108, 0, bH.Width, bH.Height)
        IL = CropBitmap(Chart, 124, 0, bIL.Width, bIL.Height)
        J = CropBitmap(Chart, 131, 0, bJ.Width, bJ.Height)
        K = CropBitmap(Chart, 143, 0, bK.Width, bK.Height)
        L = CropBitmap(Chart, 160, 0, bL.Width, bL.Height)
        M = CropBitmap(Chart, 172, 0, bM.Width, bM.Height)
        N = CropBitmap(Chart, 189, 0, bN.Width, bN.Height)
        O = CropBitmap(Chart, 206, 0, bO.Width, bO.Height)
        P = CropBitmap(Chart, 224, 0, bP.Width, bP.Height)
        Q = CropBitmap(Chart, 239, 0, bQ.Width, bQ.Height)
        R = CropBitmap(Chart, 257, 0, bR.Width, bR.Height)
        S = CropBitmap(Chart, 273, 0, bS.Width, bS.Height)
        T = CropBitmap(Chart, 289, 0, bT.Width, bT.Height)
        U = CropBitmap(Chart, 302, 0, _bU.Width, _bU.Height)
        V = CropBitmap(Chart, 319, 0, bV.Width, bV.Height)
        W = CropBitmap(Chart, 336, 0, bW.Width, bW.Height)
        X = CropBitmap(Chart, 353, 0, bX.Width, bX.Height)
        Y = CropBitmap(Chart, 368, 0, bY.Width, bY.Height)
        Z = CropBitmap(Chart, 385, 0, bZ.Width, bZ.Height)
        Au = CropBitmap(Chart, 0, 13, bAu.Width, bAu.Height)
        bBu = CropBitmap(Chart, 19, 13, bBu.Width, bBu.Height)
        Cu = CropBitmap(Chart, 35, 13, bCu.Width, bCu.Height)
        Du = CropBitmap(Chart, 53, 13, bDu.Width, bDu.Height)
        Eu = CropBitmap(Chart, 70, 13, bEu.Width, bEu.Height)
        Gu = CropBitmap(Chart, 87, 13, bGu.Width, bGu.Height)
        Hu = CropBitmap(Chart, 104, 13, bHu.Width, bHu.Height)
        Iu = CropBitmap(Chart, 121, 13, bIu.Width, bIu.Height)
        Ku = CropBitmap(Chart, 128, 13, bKu.Width, bKu.Height)
        Lu = CropBitmap(Chart, 147, 13, bLu.Width, bLu.Height)
        Mu = CropBitmap(Chart, 164, 13, bMu.Width, bMu.Height)
        Nu = CropBitmap(Chart, 181, 13, bNu.Width, bNu.Height)
        Ou = CropBitmap(Chart, 198, 13, bOu.Width, bOu.Height)
        Pu = CropBitmap(Chart, 217, 13, bPu.Width, bPu.Height)
        Qu = CropBitmap(Chart, 234, 13, bQu.Width, bQu.Height)
        Ru = CropBitmap(Chart, 253, 13, bRu.Width, bRu.Height)
        Su = CropBitmap(Chart, 270, 13, bSu.Width, bSu.Height)
        Tu = CropBitmap(Chart, 287, 13, bTu.Width, bTu.Height)
        Uu = CropBitmap(Chart, 304, 13, bUu.Width, bUu.Height)
        Vu = CropBitmap(Chart, 321, 13, bVu.Width, bVu.Height)
        Wu = CropBitmap(Chart, 338, 13, bWu.Width, bWu.Height)
        Yu = CropBitmap(Chart, 355, 13, bYu.Width, bYu.Height)
        _0 = CropBitmap(Chart, 0, 31, b_0.Width, b_0.Height)
        _1 = CropBitmap(Chart, 12, 31, b_1.Width, b_1.Height)
        _2 = CropBitmap(Chart, 24, 31, b_2.Width, b_2.Height)
        _3 = CropBitmap(Chart, 36, 31, b_3.Width, b_3.Height)
        _4 = CropBitmap(Chart, 48, 31, b_4.Width, b_4.Height)
        _5 = CropBitmap(Chart, 60, 31, b_5.Width, b_5.Height)
        _6 = CropBitmap(Chart, 72, 31, b_6.Width, b_6.Height)
        _7 = CropBitmap(Chart, 84, 31, b_7.Width, b_7.Height)
        _8 = CropBitmap(Chart, 96, 31, b_8.Width, b_8.Height)
        _9 = CropBitmap(Chart, 108, 31, b_9.Width, b_9.Height)
        Dot = CropBitmap(Chart, 237, 44, bDot.Width, bDot.Height)
        Ap = CropBitmap(Chart, 230, 44, bAp.Width, bAp.Height)
        Colon = CropBitmap(Chart, 94, 44, bColon.Width, bColon.Height)
        Comma = CropBitmap(Chart, 244, 44, bComma.Width, bComma.Height)
        Dollar = CropBitmap(Chart, 169, 44, bDollar.Width, bDollar.Height)
        Equal = CropBitmap(Chart, 156, 44, bEqual.Width, bEqual.Height)
        Exclamation = CropBitmap(Chart, 185, 44, bExclamation.Width, bExclamation.Height)
        LeftS = CropBitmap(Chart, 192, 44, bLeftS.Width, bLeftS.Height)
        RightS = CropBitmap(Chart, 204, 44, bRightS.Width, bRightS.Height)
        Minus = CropBitmap(Chart, 143, 44, bMinus.Width, bMinus.Height)
        Multiply = CropBitmap(Chart, 251, 44, bMultiply.Width, bMultiply.Height)
        Number = CropBitmap(Chart, 264, 44, bNumber.Width, bNumber.Height)
        Par = CropBitmap(Chart, 0, 44, bPar.Width, bPar.Height)
        ParF = CropBitmap(Chart, 9, 44, bParF.Width, bParF.Height)
        Par2 = CropBitmap(Chart, 18, 44, bPar2.Width, bPar2.Height)
        Par2F = CropBitmap(Chart, 29, 44, bPar2F.Width, bPar2F.Height)
        Percent = CropBitmap(Chart, 40, 44, bPercent.Width, bPercent.Height)
        Plus = CropBitmap(Chart, 54, 44, bPlus.Width, bPlus.Height)
        Question = CropBitmap(Chart, 67, 44, bQuestion.Width, bQuestion.Height)
        Semicolon = CropBitmap(Chart, 101, 44, bSemicolon.Width, bSemicolon.Height)
        Slash = CropBitmap(Chart, 108, 44, bSlash.Width, bSlash.Height)
        Slash2 = CropBitmap(Chart, 122, 44, bSlash2.Width, bSlash2.Height)
        Quotes = CropBitmap(Chart, 82, 44, bQuotes.Width, bQuotes.Height)
        Raise = CropBitmap(Chart, 216, 44, bRaise.Width, bRaise.Height)
        Under = CropBitmap(Chart, 136, 44, bUnder.Width, bUnder.Height)
    End Sub
#End Region

#Region "Generate button"
    Private Sub ButtonClick()
        If Not RichTextBox1.Text = Nothing Then
            On Error GoTo DisplayError
            NewGraphic.Clear(Color.Cyan)
            PictureBox1.Image = DrawBitmap
            OldWidth = 0
            AllHeight = 0
            Button1.Text = "Generating..."
            Button1.Enabled = False
            RichTextBox1.Enabled = False
            'GenerateTextWithRows(RichTextBox1.Text)
            GenerateText()
        ElseIf RichTextBox1.Text = Nothing Then
            DisplayErrorMessage("The text field is empty.")
        End If
        Exit Sub
DisplayError:
        DisplayErrorMessage(Err.Description)
        Resume Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer2.Start()
    End Sub
#End Region

#Region "Bitmap cropping"
    Private Function CropBitmap(ByRef bmp As Bitmap, ByVal cropX As Integer, ByVal cropY As Integer, ByVal cropWidth As Integer, ByVal cropHeight As Integer) As Bitmap
        On Error GoTo DisplayError
        Dim rect As New Rectangle(cropX, cropY, cropWidth, cropHeight)
        Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
        Return cropped
        Exit Function
DisplayError:
        DisplayErrorMessage(Err.Description)
        Resume Next
    End Function
#End Region

#Region "Status display"
    Public Sub DisplayErrorMessage(ByVal Message As String)
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        StatusLabel.Image = My.Resources._ERROR
        StatusLabel.Text = Message.ToString
        Timer1.Start()
        RichTextBox1.Enabled = True
        Button1.Enabled = True
    End Sub

    Public Sub MakeReady()
        StatusLabel.Image = My.Resources.OK
        StatusLabel.Text = "Ready"
    End Sub

    Public Sub MakeBusy()
        StatusLabel.Image = My.Resources.Working
        StatusLabel.Text = "Working..."
    End Sub
#End Region

#Region "Old/Unused function"
    Public Sub GenerateTextWithRows(ByVal TextToGenerate As String)
        Dim Reader As StringReader
        Reader = New StringReader(TextToGenerate)
        Dim OutputText As String
        While True
            OutputText = Reader.ReadLine()
            If OutputText Is Nothing Then
                OutputText = OutputText & vbCrLf
                Exit While
            Else
                'OutputText = OutputText & TextToGenerate & " "
                GenerateText()
            End If
        End While
    End Sub
#End Region

#Region "GenerateText()"
    Public Sub GenerateText()
        Dim IsQ As Boolean = False
        Dim Rows As Integer = -1
        Dim RowSize As Integer = 0
        Dim Lines As Integer
        Dim AllLines As Integer
        Dim QLine As Integer
        AllLines = 0
        For Each St As String In RichTextBox1.Lines
            Lines += 1
        Next
        AllLines = Lines
        Try
            Index = 0
            FinalHeight = 0
            FinalWidth = 0
            Lines = 0
            NextOffset = 0
            CheckOffsetTimes = 0
            Chart = My.Resources.CHART_NORMAL
            LoadChars()
            For Each Str As String In RichTextBox1.Lines
                Lines += 1
                Rows += 1
                RowSize = (My.Settings.RowSpacing * Rows)

                If IsQ = True Then
                    RowSize = RowSize + 2
                End If

                For Each UpperCh As Char In Str
                    Dim I2 As Image
                    Index = Index + 1
                    CheckColors(Index)
                    Select Case UpperCh
                        Case "A"
                            If Not Skip.Item(3) = "A" Then
                                I2 = Au
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If

                        Case "B"
                            If Not Skip.Item(3) = "B" Then
                                I2 = bBu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If

                        Case "C"
                            If Not Skip.Item(3) = "C" Then
                                I2 = Cu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If

                        Case "D"
                            If Not Skip.Item(3) = "D" Then
                                I2 = Du
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "E"
                            If Not Skip.Item(3) = "E" Then
                                I2 = Eu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "G"
                            If Not Skip.Item(3) = "G" Then
                                I2 = Gu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "H"
                            If Not Skip.Item(3) = "H" Then
                                I2 = Hu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "I"
                            If Not Skip.Item(3) = "I" Then
                                I2 = Iu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "K"
                            If Not Skip.Item(3) = "K" Then
                                I2 = Ku
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "L"
                            If Not Skip.Item(3) = "L" Then
                                I2 = Lu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "M"
                            If Not Skip.Item(3) = "M" Then
                                I2 = Mu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "N"
                            If Not Skip.Item(3) = "N" Then
                                I2 = Nu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "O"
                            If Not Skip.Item(3) = "O" AndAlso Not Skip2.Item(3) = "O" Then
                                I2 = Ou
                                FixHeight(I2)
                            ElseIf Skip.Item(3) = "O" Then
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "P"
                            If Not Skip.Item(3) = "P" Then
                                I2 = Pu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "Q"
                            If Not Skip.Item(3) = "Q" Then
                                I2 = Qu
                                FixQHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "R"
                            If Not Skip.Item(3) = "R" Then
                                I2 = Ru
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "S"
                            If Not Skip.Item(3) = "S" Then
                                I2 = Su
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "T"
                            If Not Skip.Item(3) = "T" Then
                                I2 = Tu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "U"
                            If Not Skip.Item(3) = "U" Then
                                I2 = Uu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "V"
                            If Not Skip.Item(3) = "V" Then
                                I2 = Vu
                                FixHeight(I2)
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If


                        Case "W"
                            I2 = Wu
                            FixHeight(I2)



                        Case "Y"
                            I2 = Yu
                            FixHeight(I2)
                    End Select
                Next
                Index = 0
                'Dim Index As Integer = 0
                OldText = Str.ToString()

                For Each ch As Char In Str
                    Dim I As Image
                    Index = Index + 1
                    SetColors(Str, Index)
                    'MessageBox.Show(Index)
                    Select Case ch
                        Case " "
                            OldWidth = OldWidth + 6
                        Case "a"
                            'SetColors(Index)
                            I = A
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "b"
                            'SetColors(Index)
                            I = B
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "c"
                            'SetColors(Index)
                            If Not Skip.Item(2) = "c" Then
                                I = C
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "d"
                            'SetColors(Index)
                            I = D
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "e"
                            'SetColors(Index)
                            I = El
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "f"
                            'SetColors(Index)
                            I = F
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "g"
                            'SetColors(Index)
                            I = G
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "h"
                            'SetColors(Index)
                            I = H
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "i"
                            'SetColors(Index)
                            I = IL
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "j"
                            'SetColors(Index)
                            I = J
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "k"
                            'SetColors(Index)
                            I = K
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "l"
                            'SetColors(Index)
                            I = L
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "m"
                            'SetColors(Index)
                            I = M
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "n"
                            'SetColors(Index)
                            I = N
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "o"
                            'SetColors(Index)
                            I = O
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "p"
                            'SetColors(Index)
                            I = P
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "q"
                            'SetColors(Index)
                            I = Q
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "r"
                            'SetColors(Index)
                            I = R
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "s"
                            'SetColors(Index)
                            I = S
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "t"
                            'SetColors(Index)
                            I = T
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "u"
                            'SetColors(Index)
                            I = U
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "v"
                            'SetColors(Index)
                            I = V
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "w"
                            I = W
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "x"
                            I = X
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "y"
                            I = Y
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "z"
                            I = Z
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1


                            '* Uppercase letters *'

                        Case "A"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "A" Then
                                I = Au
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "B"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "B" Then
                                I = bBu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "C"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "C" Then
                                I = Cu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "D"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "D" Then
                                I = Du
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "E"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "E" Then
                                I = Eu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "F"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "F" Then

                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "G"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "G" Then
                                I = Gu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "H"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "H" Then
                                I = Hu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "I"
                            If Not Skip.Item(3) = "I" Then
                                'SetColors(Index)
                                I = Iu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "J"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "J" Then

                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "K"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "K" Then
                                I = Ku
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "L"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "L" Then
                                I = Lu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "M"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "M" Then
                                I = Mu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "N"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "N" Then
                                I = Nu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "O"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "O" AndAlso Not Skip2.Item(3) = "O" Then
                                I = Ou
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "P"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "P" Then
                                I = Pu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                If Str.Chars(Index) = "a" Then
                                    OldWidth = (OldWidth + I.Width) - 4
                                Else
                                    OldWidth = (OldWidth + I.Width) - 1
                                End If
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "Q"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "Q" Then
                                I = Qu
                                FixQHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                                QLine = Lines
                                IsQ = True
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "R"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "R" Then
                                I = Ru
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "S"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "S" Then
                                I = Su
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "T"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "T" Then
                                I = Tu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "U"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "U" Then
                                I = Uu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "V"
                            'SetColors(Index)
                            If Not Skip.Item(3) = "V" Then
                                I = Vu
                                FixHeight(I)
                                NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            Else
                                Skip.Clear()
                                Skip.Add(" ")
                                Skip.Add(" ")
                                Skip.Add(" ")
                            End If
                        Case "W"
                            I = Wu
                            FixHeight(I)
                            NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "Y"
                            I = Yu
                            FixHeight(I)
                            NewGraphic.DrawImage(I, OldWidth, RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1


                            '* Signs *'


                        Case "."
                            I = Dot
                            NewGraphic.DrawImage(I, OldWidth + 1, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width)
                        Case ","
                            I = Comma
                            NewGraphic.DrawImage(I, OldWidth + 2, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) + 1
                        Case ":"
                            I = Colon
                            NewGraphic.DrawImage(I, OldWidth + 1, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case ";"
                            I = Semicolon
                            NewGraphic.DrawImage(I, OldWidth + 1, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "<"
                            I = LeftS
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case ">"
                            I = RightS
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "'"
                            I = Ap
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "$"
                            I = Dollar
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "="
                            I = Equal
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "!"
                            I = Exclamation
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "-"
                            I = Minus
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "*"
                            I = Multiply
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "#"
                            I = Number
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "("
                            I = Par
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case ")"
                            I = ParF
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "["
                            If Not Skip2.Item(2) = "[" Then
                                I = Par2
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "]"
                            If Not Skip2.Item(6) = "]" Then
                                I = Par2F
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            ElseIf Skip2.Item(6) = "]" Then
                                CheckOffsetTimes = 1
                                Skip2.Clear()
                                Skip2.Add(" ")
                                Skip2.Add(" ")
                                Skip2.Add(" ")
                                Skip2.Add(" ")
                                Skip2.Add(" ")
                                Skip2.Add(" ")
                            End If
                        Case "%"
                            I = Percent
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "+"
                            I = Plus
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "?"
                            I = Question
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case Chr(34)
                            I = Quotes
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "/"
                            I = Slash
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "\"
                            If Not Skip.Item(1) = "\" AndAlso Not Skip2.Item(1) = "\" Then
                                I = Slash2
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "^"
                            I = Raise
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "_"
                            I = Under
                            NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                            PictureBox1.Image = DrawBitmap
                            OldWidth = (OldWidth + I.Width) - 1
                        Case "0"
                            If Not Skip2.Item(4) = "0" AndAlso Not Skip2.Item(5) = "0" Then
                                I = _0
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "1"
                            If Not Skip2.Item(4) = "1" AndAlso Not Skip2.Item(5) = "1" Then
                                I = _1
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "2"
                            If Not Skip2.Item(4) = "2" AndAlso Not Skip2.Item(5) = "2" Then
                                I = _2
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "3"
                            If Not Skip2.Item(4) = "3" AndAlso Not Skip2.Item(5) = "3" Then
                                I = _3
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "4"
                            If Not Skip2.Item(4) = "4" AndAlso Not Skip2.Item(5) = "4" Then
                                I = _4
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "5"
                            If Not Skip2.Item(4) = "5" AndAlso Not Skip2.Item(5) = "5" Then
                                I = _5
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "6"
                            If Not Skip2.Item(4) = "6" AndAlso Not Skip2.Item(5) = "6" Then
                                I = _6
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "7"
                            If Not Skip2.Item(4) = "7" AndAlso Not Skip2.Item(5) = "7" Then
                                I = _7
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "8"
                            If Not Skip2.Item(4) = "8" AndAlso Not Skip2.Item(5) = "8" Then
                                I = _8
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case "9"
                            If Not Skip2.Item(4) = "9" AndAlso Not Skip2.Item(5) = "9" Then
                                I = _9
                                NewGraphic.DrawImage(I, OldWidth, FixHeight(I) + RowSize, I.Width, I.Height)
                                PictureBox1.Image = DrawBitmap
                                OldWidth = (OldWidth + I.Width) - 1
                            End If
                        Case Else
                            DisplayErrorMessage("'" & ch.ToString & "' is not a supported character.")
                            Button1.Text = "Generate"
                            RichTextBox1.Enabled = True
                            Button1.Enabled = True
                            Exit Sub
                    End Select
                    If NextOffset > 0 AndAlso CheckOffsetTimes = 2 Then
                        RowSize = RowSize + NextOffset
                    End If
                    If CheckOffsetTimes = 1 Then
                        'CheckOffsetTimes = 2
                    End If
                    Try
                        FixFinalHeight(Str, RowSize, IsQ, AllLines, QLine)
                    Catch Ex As Exception
                        DisplayErrorMessage(Ex.Message)
                    End Try
                Next


                Try
                    FixFinalWidth()
                Catch Ex As Exception
                    DisplayErrorMessage(Ex.Message)
                End Try

                OldWidth = 0
            Next
            Index = 0
            Button1.Enabled = True
            Button1.Text = "Generate"
            RichTextBox1.Enabled = True
            Dim NewHeight As Boolean = False
            Dim NewWidth As Boolean = False

            If FinalWidth > PictureBox1.Width Or FinalWidth < PictureBox1.Width AndAlso Not FinalWidth = 0 Then
                NewWidth = True
            End If

            If FinalHeight > PictureBox1.Height Or FinalHeight < PictureBox1.Height AndAlso Not FinalHeight = 0 Then
                NewHeight = True
            End If

            If NewWidth = True Then
                PictureBox1.Width = FinalWidth
            End If

            If NewHeight = True Then
                PictureBox1.Height = FinalHeight
            End If

            If NewWidth = True Or NewHeight = True Then
                ApplyNewSize()
            End If

            If NewWidth = False AndAlso NewHeight = False Then
                MakeReady()
            End If
        Catch Ex As Exception
            DisplayErrorMessage(Ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region "Applying new size"
    Public Sub ApplyNewSize()
        DrawBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        NewGraphic = Graphics.FromImage(DrawBitmap)
        PictureBox1.Image = DrawBitmap
        NewGraphic.Clear(Color.Cyan)
        ButtonClick()
    End Sub
#End Region

#Region "Colorizing"
    Public Sub SetColors(ByVal Text As String, ByVal Indx As Integer)
        For Each St As String In My.Settings.Color
            If Not Indx + 1 = Text.Length Then
                If Text.Chars(Indx - 1) = "\" AndAlso Text.Chars(Indx) = "c" AndAlso Text.Chars(Indx + 1) = St Then
                    Select Case St
                        Case "A"
                            Chart = New Bitmap(My.Resources.CHART_A)
                            LoadChars()

                        Case "a"
                            Chart = New Bitmap(My.Resources.CHART_A)
                            LoadChars()

                        Case "B"
                            Chart = New Bitmap(My.Resources.CHART_B)
                            LoadChars()

                        Case "b"
                            Chart = New Bitmap(My.Resources.CHART_B)
                            LoadChars()

                        Case "C"
                            Chart = New Bitmap(My.Resources.CHART_C)
                            LoadChars()

                        Case "c"
                            Chart = New Bitmap(My.Resources.CHART_C)
                            LoadChars()

                        Case "D"
                            Chart = New Bitmap(My.Resources.CHART_D)
                            LoadChars()

                        Case "d"
                            Chart = New Bitmap(My.Resources.CHART_D)
                            LoadChars()

                        Case "E"
                            Chart = New Bitmap(My.Resources.CHART_E)
                            LoadChars()

                        Case "e"
                            Chart = New Bitmap(My.Resources.CHART_E)
                            LoadChars()

                        Case "F"
                            Chart = New Bitmap(My.Resources.CHART_F)
                            LoadChars()

                        Case "f"
                            Chart = New Bitmap(My.Resources.CHART_F)
                            LoadChars()

                        Case "G"
                            Chart = New Bitmap(My.Resources.CHART_G)
                            LoadChars()

                        Case "g"
                            Chart = New Bitmap(My.Resources.CHART_G)
                            LoadChars()

                        Case "H"
                            Chart = New Bitmap(My.Resources.CHART_H)
                            LoadChars()

                        Case "h"
                            Chart = New Bitmap(My.Resources.CHART_H)
                            LoadChars()

                        Case "I"
                            Chart = New Bitmap(My.Resources.CHART_I)
                            LoadChars()

                        Case "i"
                            Chart = New Bitmap(My.Resources.CHART_I)
                            LoadChars()

                        Case "J"
                            Chart = New Bitmap(My.Resources.CHART_J)
                            LoadChars()

                        Case "j"
                            Chart = New Bitmap(My.Resources.CHART_J)
                            LoadChars()

                        Case "K"
                            Chart = New Bitmap(My.Resources.CHART_K)
                            LoadChars()

                        Case "k"
                            Chart = New Bitmap(My.Resources.CHART_K)
                            LoadChars()

                        Case "L"
                            Chart = New Bitmap(My.Resources.CHART_L)
                            LoadChars()

                        Case "l"
                            Chart = New Bitmap(My.Resources.CHART_L)
                            LoadChars()

                        Case "M"
                            Chart = New Bitmap(My.Resources.CHART_M)
                            LoadChars()

                        Case "m"
                            Chart = New Bitmap(My.Resources.CHART_M)
                            LoadChars()

                        Case "N"
                            Chart = New Bitmap(My.Resources.CHART_N)
                            LoadChars()

                        Case "n"
                            Chart = New Bitmap(My.Resources.CHART_N)
                            LoadChars()

                        Case "O"
                            Chart = New Bitmap(My.Resources.CHART_O)
                            LoadChars()

                        Case "o"
                            Chart = New Bitmap(My.Resources.CHART_O)
                            LoadChars()

                        Case "P"
                            Chart = New Bitmap(My.Resources.CHART_P)
                            LoadChars()

                        Case "p"
                            Chart = New Bitmap(My.Resources.CHART_P)
                            LoadChars()

                        Case "Q"
                            Chart = New Bitmap(My.Resources.CHART_Q)
                            LoadChars()

                        Case "q"
                            Chart = New Bitmap(My.Resources.CHART_Q)
                            LoadChars()

                        Case "R"
                            Chart = New Bitmap(My.Resources.CHART_R)
                            LoadChars()

                        Case "r"
                            Chart = New Bitmap(My.Resources.CHART_R)
                            LoadChars()

                        Case "S"
                            Chart = New Bitmap(My.Resources.CHART_S)
                            LoadChars()

                        Case "s"
                            Chart = New Bitmap(My.Resources.CHART_S)
                            LoadChars()

                        Case "T"
                            Chart = New Bitmap(My.Resources.CHART_T)
                            LoadChars()

                        Case "t"
                            Chart = New Bitmap(My.Resources.CHART_T)
                            LoadChars()

                        Case "U"
                            Chart = New Bitmap(My.Resources.CHART_U)
                            LoadChars()

                        Case "u"
                            Chart = New Bitmap(My.Resources.CHART_U)
                            LoadChars()

                        Case "V"
                            Chart = New Bitmap(My.Resources.CHART_V)
                            LoadChars()

                        Case "v"
                            Chart = New Bitmap(My.Resources.CHART_V)
                            LoadChars()
                    End Select
                    'If TextBox1.Text.Chars(Indx - 1) = "\" AndAlso TextBox1.Text.Chars(Indx) = "c" AndAlso TextBox1.Text.Chars(Indx + 1) = St Then
                    'TextBox1.Text = TextBox1.Text.Remove(Indx - 1, 3)
                    'End If
                    'Dim NewText As String = TextBox1.Text.Remove(Indx - 1, 3)
                    'MessageBox.Show(NewText)
                    Skip.Clear()
                    Skip.Add("\")
                    Skip.Add("c")
                    Skip.Add(St)
                End If
            End If
        Next
    End Sub

    Public Sub CheckColors(ByVal Indx As Integer)
        Skip.Add(" ")
        Skip.Add(" ")
        Skip.Add(" ")
        For Each St As String In My.Settings.Color
            If Not Indx + 1 = RichTextBox1.Text.Length Then
                If RichTextBox1.Text.Chars(Indx - 1) = "\" AndAlso RichTextBox1.Text.Chars(Indx) = "c" AndAlso RichTextBox1.Text.Chars(Indx + 1) = St Then
                    Skip.Clear()
                    Skip.Add("\")
                    Skip.Add("c")
                    Skip.Add(St)
                End If
            End If
        Next
    End Sub
#End Region

#Region "Fixes"
    Function FixHeight(ByVal Which As Image) ', ByVal RowSpace As Integer)
        If Which.Size.Height >= 15 Then
            AllHeight = (Which.Size.Height) - 12
        End If

        Return AllHeight
    End Function

    Function FixQHeight(ByVal Which As Image)
        If Which.Size.Height >= 15 Then
            AllHeight = (Which.Size.Height) - 14
        End If

        Return AllHeight
    End Function

    Public Sub FixFinalHeight(ByVal Text As String, ByVal RowSize As Integer, ByVal IsQ As Boolean, ByVal Lines As Integer, ByVal QLine As Integer)
        If IsQ = False Then
            If (AllHeight + 12) + RowSize > FinalHeight Then
                FinalHeight = (AllHeight + 12) + RowSize
            End If
        End If

        If IsQ = True Then

            If QLine = Lines Then
                If (AllHeight + 14) + RowSize > FinalHeight Then
                    FinalHeight = (AllHeight + 14) + RowSize
                End If
            Else
                If (AllHeight + 12) + RowSize > FinalHeight Then
                    FinalHeight = (AllHeight + 12) + RowSize
                End If
            End If

        End If
    End Sub

    Public Sub FixFinalWidth()
        If OldWidth + 1 > FinalWidth Then
            FinalWidth = OldWidth + 1
        End If
    End Sub
#End Region

#Region "Saving"
    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim DoNotSave As Boolean = False
        Dim Name As String = SaveFileDialog1.FileName.ToString
        If OldWidth = 0 Then
            OldWidth = 1
        End If
        If FinalHeight = 0 Then
            FinalHeight = 1
        End If
        'Dim CrIm As Image = CropBitmap(PictureBox1.Image, 0, 0, OldWidth + 1, FinalHeight)
        Dim BMP As Bitmap = PictureBox1.Image 'CropBitmap(PictureBox1.Image, 0, 0, OldWidth + 1, FinalHeight)

        If My.Settings.Transparency = 0 AndAlso SaveFileDialog1.FilterIndex = 2 Then
            BMP.MakeTransparent(Color.Cyan)
        ElseIf My.Settings.Transparency = 1 Then

        ElseIf My.Settings.Transparency = 2 AndAlso SaveFileDialog1.FilterIndex = 2 Then
            Dim DResult As DialogResult
            DResult = MessageBox.Show("Do you want to save this image with transparent background?", "Doom Writer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If DResult = Windows.Forms.DialogResult.Yes Then
                BMP.MakeTransparent(Color.Cyan)
            ElseIf DResult = Windows.Forms.DialogResult.No Then

            ElseIf DResult = Windows.Forms.DialogResult.Cancel Then
                DoNotSave = True
            End If
        End If

        If DoNotSave = False Then
            Name = Name.ToLower
            If SaveFileDialog1.FilterIndex = 2 Then
                'PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
                BMP.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
            ElseIf SaveFileDialog1.FilterIndex = 1 Then
                'PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                BMP.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
            ElseIf SaveFileDialog1.FilterIndex = 3 Then
                'PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                BMP.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
            ElseIf SaveFileDialog1.FilterIndex = 4 Then
                'PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif)
                BMP.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif)
            End If
        End If
    End Sub
#End Region

#Region "Extras"
    Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Options.Show()
    End Sub

    Private Sub MyDOOMSite2014ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MyDOOMSite2014ToolStripMenuItem.Click
        VisualVincent.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SupportedCharsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupportedCharsToolStripMenuItem.Click
        AChars.Show()
    End Sub

    Private Sub SupportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupportToolStripMenuItem.Click
        Support.Show()
    End Sub

    Private Sub OurWebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OurWebsiteToolStripMenuItem.Click
        Process.Start("http://www.mydoomsite.com/")
    End Sub
#End Region

#Region "Old/Unused"
    Public Sub TryCharts()
        Chart = New Bitmap(My.Resources.CHART_N)
        LoadChars()
        Dim I As Image
        I = A
        NewGraphic.DrawImage(I, OldWidth, FixHeight(I), I.Width, I.Height)
        PictureBox1.Image = DrawBitmap
        OldWidth = (OldWidth + I.Width) - 1
        Chart = New Bitmap(My.Resources.CHART_T)
        LoadChars()
        I = D
        NewGraphic.DrawImage(I, OldWidth, FixHeight(I), I.Width, I.Height)
        PictureBox1.Image = DrawBitmap
        OldWidth = (OldWidth + I.Width) - 1
    End Sub

    Private Sub RichTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim hotkey As Boolean
        hotkey = GetAsyncKeyState(Keys.Enter)
        If hotkey = True Then
            Button1.PerformClick()
        End If
    End Sub
#End Region

#Region "Timers"
    Dim Blink As Integer
    Dim BlinkB As Boolean

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Blink = (Blinks * 2) Then
            Blink = 0
            Timer1.Stop()
        End If

        If BlinkB = False Then
            StatusLabel.Image = My.Resources.EMPTY
            BlinkB = True
            Blink += 1
        ElseIf BlinkB = True Then
            StatusLabel.Image = My.Resources._ERROR
            BlinkB = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If Tics = 1 Then
            MakeBusy()
        End If
        If Tics = 2 Then
            Tics = 0
            ButtonClick()
            Timer2.Stop()
        End If
        Tics += 1
    End Sub
#End Region

End Class
