
Imports System.IO
Public Class CFile
    Private msFileName As String = "LinkCategories.txt"
    Public Function Save(ByVal sInput As String) As Boolean
        Try

            Dim objStreamWriter As StreamWriter

            objStreamWriter = File.AppendText(msFileName)
            objStreamWriter.WriteLine(sInput)
            objStreamWriter.Close()
            objStreamWriter.Dispose()
            objStreamWriter = Nothing

            Return True

        Catch ex As Exception

            Throw ex

        End Try
    End Function

    '  Public Sub New()
    ' Populate the msFilename on Contruction
    'msFileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments &
    '   "\" & My.Settings.StudentFileLocation

    '    msFileName = My.Settings.Setting


    '   End Sub

    Public Function Load1() As String
        Try
            Dim oStreamReader As System.IO.StreamReader
            Dim sOutput As String

            If File.Exists(msFileName) Then


                oStreamReader = File.OpenText(msFileName)
                sOutput = oStreamReader.ReadToEnd
                oStreamReader.Close()
                oStreamReader = Nothing

            Else

                Dim oExp As New Exception(msFileName & " does not exist.")
                Throw oExp


            End If


            Return sOutput

        Catch ex As Exception

            Throw ex

        End Try
    End Function

    Public Function Delete() As Boolean


        ' Delete the output if it exists
        If File.Exists(msFileName) Then
            File.Delete(msFileName)
        End If
        Return True

    End Function
    Public Sub New(ByVal vsFileName As String)
        msFileName = vsFileName
    End Sub
    Public Sub New()
    End Sub
    Public Function Load() As String
        Try
            Dim oStreamReader As System.IO.StreamReader
            Dim sOutput As String
            oStreamReader = File.OpenText(msFileName)
            sOutput = oStreamReader.ReadToEnd
            oStreamReader.Close()
            oStreamReader = Nothing            Return sOutput
        Catch ex As Exception

        End Try
    End Function

End Class
