Imports System.Text.RegularExpressions
Imports BookmarSorter.DL

Public Class CBookmarkExtractor
    Public Sub ExtractBookmark(ByVal vstrBookmark As String)
        Dim oFile As CFileManager
        oFile = New CFileManager
        Dim mstrBookmark As String
        mstrBookmark = MYIdentifyLinks(vstrBookmark)
        '    Dim intCount As Integer
        '      intCount = vstrBookmark.IndexOf(Chr(34))
        '    If intCount >= 0 Then
        'intCount += 1
        '   For intCount1 As Integer = intCount To (vstrBookmark.Length - 1)
        'If vstrBookmark.Substring(intCount, intCount + 1) = Chr(34) Then
        'intCount = vstrBookmark.Length + 1
        '    Else
        '    mstrBookmark = mstrBookmark & vstrBookmark.Substring(intCount, intCount + 1)
        '    intCount += 1
        '    End If

        '    Next
        oFile.SaveLinks(mstrBookmark)
        '    End If
    End Sub
    ''' <summary>Identifies hyperlinks in HTML text.</summary>
    ''' <param name="htmlText">HTML text to parse.</param>
    ''' <remarks>This method displays the label and destination for
    ''' each link in the input text.</remarks>
    Public Function MYIdentifyLinks(ByVal htmlText As String) As String
        Dim hrefRegex As New Regex(
            "<A[^>]*?HREF\s*=\s*""([^""]+)""[^>]*?>([\s\S]*?)<\/A>",
            RegexOptions.IgnoreCase)
        Dim output As String = ""
        For Each m As Match In hrefRegex.Matches(htmlText)
            '          output &= "Link label: " & m.Groups(2).Value & vbCrLf
            output &= m.Groups(1).Value
            Return output
        Next
    End Function
    ''' <summary>Identifies hyperlinks in HTML text.</summary>
    ''' <param name="htmlText">HTML text to parse.</param>
    ''' <remarks>This method displays the label and destination for
    ''' each link in the input text.</remarks>
    Sub IdentifyLinks(ByVal htmlText As String)
        Dim hrefRegex As New Regex(
            "<A[^>]*?HREF\s*=\s*""([^""]+)""[^>]*?>([\s\S]*?)<\/A>",
            RegexOptions.IgnoreCase)
        Dim output As String = ""
        For Each m As Match In hrefRegex.Matches(htmlText)
            output &= "Link label: " & m.Groups(2).Value & vbCrLf
            output &= "Link destination: " & m.Groups(1).Value & vbCrLf
        Next
        MsgBox(output)
    End Sub
End Class
