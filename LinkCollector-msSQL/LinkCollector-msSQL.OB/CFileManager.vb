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
    Public Sub SaveLink(ByVal sInputLink As String, ByVal sInputFileName As String)
        Dim objStreamWriter As StreamWriter

        objStreamWriter = File.AppendText(sInputFileName)
        objStreamWriter.WriteLine(sInputLink)
        objStreamWriter.Close()
        objStreamWriter.Dispose()
        objStreamWriter = Nothing
    End Sub
    Public Function Load(ByVal vsFileName As String) As String
        Try
            Dim oStreamReader As System.IO.StreamReader
            Dim sOutput As String

            If File.Exists(vsFileName) Then


                oStreamReader = File.OpenText(vsFileName)
                sOutput = oStreamReader.ReadToEnd
                oStreamReader.Close()
                oStreamReader = Nothing

            Else

                Dim oExp As New Exception(vsFileName & " does not exist.")
                Throw oExp


            End If


            Return sOutput

        Catch ex As Exception

            Throw ex

        End Try
    End Function
End Class
