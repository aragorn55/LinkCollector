Imports System.Text.RegularExpressions
Public Class CBookmarkExtractor
    Public Sub ExtractBookmark(ByVal vstrBookmark As String)
        Dim oFile As CFileManager
        oFile = New CFileManager
        Dim mstrBookmark As String
        mstrBookmark = MYIdentifyLinks(vstrBookmark)     
        oFile.SaveLinks(mstrBookmark)
    End Sub

    Public Function MYIdentifyLinks(ByVal htmlText As String) As String
        Dim hrefRegex As New Regex(
            "<A[^>]*?HREF\s*=\s*""([^""]+)""[^>]*?>([\s\S]*?)<\/A>",
            RegexOptions.IgnoreCase)
        Dim output As String = ""
        For Each m As Match In hrefRegex.Matches(htmlText)       '          
            output &= m.Groups(1).Value
            Return output
        Next
    End Function
End Class
