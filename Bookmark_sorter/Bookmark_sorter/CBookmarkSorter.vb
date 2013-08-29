Public Class CBookmarkSorter
    Public Sub SortBookmark(ByVal vstrBookmark As String)
        Dim oFile As CFileManager
        oFile = New CFileManager
        Dim intCount As Integer
        intCount = vstrBookmark.IndexOf("fanfiction.net")
        If intCount >= 0 Then
            oFile.SaveFF_net(vstrBookmark)
        ElseIf vstrBookmark.IndexOf("addventure") >= 0 Then
            oFile.SaveAddv(vstrBookmark)
        Else
            oFile.SaveOtherBkmk(vstrBookmark)

        End If
    End Sub
End Class
