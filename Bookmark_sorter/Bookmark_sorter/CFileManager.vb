Imports System.IO

Public Class CFileManager
    Public Sub SaveFF_net(ByVal sInput As String)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = File.AppendText("fanfiction.net.txt")
        objStreamWriter.WriteLine(sInput)
        objStreamWriter.Close()
        objStreamWriter.Dispose()
        objStreamWriter = Nothing
    End Sub
    Public Sub SaveAddv(ByVal sInput As String)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = File.AppendText("Addventure.txt")
        objStreamWriter.WriteLine(sInput)
        objStreamWriter.Close()
        objStreamWriter.Dispose()
        objStreamWriter = Nothing
    End Sub
    Public Sub SaveOtherBkmk(ByVal sInput As String)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = File.AppendText("OtherBookmarks.txt")
        objStreamWriter.WriteLine(sInput)
        objStreamWriter.Close()
        objStreamWriter.Dispose()
        objStreamWriter = Nothing
    End Sub
    Public Sub SaveLinks(ByVal sInput As String)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = File.AppendText("Links.txt")
        objStreamWriter.WriteLine(sInput)
        objStreamWriter.Close()
        objStreamWriter.Dispose()
        objStreamWriter = Nothing
    End Sub
End Class
