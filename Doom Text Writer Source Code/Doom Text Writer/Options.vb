' Copyright © Visual Vincent 2014-2015
'
' You may not under any circumstances redistribute a modified version of this code,
' but you may however modify this code in the terms of personal use or (for the author) helpful use
' (such as using it to provide helpful fixes or suggestions).
'
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS", WITHOUT ANY WARRANTY.
' THE AUTHOR OR CONTRIBUTORS SHALL NEVER BE HELD RESPONSIBLE FOR ANY DAMAGES CAUSED BY IT.

Public Class Options
    'Old code used before "\c#".
    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Select Case True 'ComboBox1.SelectedItem
            Case "Red (Normal)"
                Form1.Chart = New Bitmap(My.Resources.CHART_NORMAL)
            Case "Orange"
                Form1.Chart = New Bitmap(My.Resources.CHART_I)
            Case "Gold"
                Form1.Chart = New Bitmap(My.Resources.CHART_F)
            Case "Green"
                Form1.Chart = New Bitmap(My.Resources.CHART_D)
            Case "Dark Green"
                Form1.Chart = New Bitmap(My.Resources.CHART_Q)
            Case "Blue"
                Form1.Chart = New Bitmap(My.Resources.CHART_H)
            Case "Light Blue"
                Form1.Chart = New Bitmap(My.Resources.CHART_N)
            Case "Gray"
                Form1.Chart = New Bitmap(My.Resources.CHART_U)
            Case "Dark Gray (Black)"
                Form1.Chart = New Bitmap(My.Resources.CHART_M)
            Case "White"
                Form1.Chart = New Bitmap(My.Resources.CHART_J)
        End Select

        Form1.LoadChars()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Options_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.RowSpacing = NumericUpDown1.Value
        My.Settings.Save()
    End Sub

    Private Sub Options_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If My.Settings.Transparency = 0 Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RadioButton3.Checked = False
        ElseIf My.Settings.Transparency = 1 Then
            RadioButton2.Checked = True
            RadioButton1.Checked = False
            RadioButton3.Checked = False
        ElseIf My.Settings.Transparency = 2 Then
            RadioButton3.Checked = True
            RadioButton1.Checked = False
            RadioButton2.Checked = False
        End If
        NumericUpDown1.Value = My.Settings.RowSpacing
    End Sub

#Region "Transparency Settings"
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            My.Settings.Transparency = 2
            My.Settings.Save()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            My.Settings.Transparency = 1
            My.Settings.Save()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            My.Settings.Transparency = 0
            My.Settings.Save()
        End If
    End Sub
#End Region

End Class