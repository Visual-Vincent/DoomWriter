' Copyright © Visual Vincent 2014-2015
'
' You may not under any circumstances redistribute a modified version of this code,
' but you may however modify this code in the terms of personal use or (for the author) helpful use
' (such as using it to provide helpful fixes or suggestions).
'
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS", WITHOUT ANY WARRANTY.
' THE AUTHOR OR CONTRIBUTORS SHALL NEVER BE HELD RESPONSIBLE FOR ANY DAMAGES CAUSED BY IT.

Public Class VisualVincent

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start("http://www.mydoomsite.com/userpages/VisualVincent.html")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Process.Start("http://zandronum.com/forum/member.php?action=profile&uid=1597")
        Me.Close()
    End Sub
End Class