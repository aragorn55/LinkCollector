Imports System.IO
Imports BookmarSorter.DL
Imports System.Windows.Forms

Public Class CLinkCategories
    Inherits CollectionBase
    Dim msFileName As String = "LinkCategories.txt"

    Public Sub Add(ByVal oLinkCategory As CLinkCategory)

        MyBase.List.Add(oLinkCategory)

    End Sub
    Public Overloads Sub RemoveAt(ByVal viIndex As Integer)

        MyBase.List.RemoveAt(viIndex)

    End Sub

    Default Public ReadOnly Property Item(ByVal viIndex As Integer) As CLinkCategory
        Get
            Return CType(MyBase.List.Item(viIndex), CLinkCategory)
        End Get
    End Property

    Public Function Load1() As Boolean
        Dim oLinkCategoryRecord() As String
        Dim oFiler As StreamReader
        Dim sPath As String
        Dim sReadLine As String
        sPath = msFileName
        Dim icnt As Integer = 0

        ' Open the file that the user picked



        If File.Exists(sPath) Then

            oFiler = File.OpenText(sPath)

            Do While oFiler.Peek <> -1
                icnt += 1
                sReadLine = oFiler.ReadLine

                oLinkCategoryRecord = sReadLine.Split(CChar(vbCrLf))

                For Each LinkRow As String In oLinkCategoryRecord

                    If LinkRow.Trim.Length > 3 Then

                        ' Process a student record
                        Dim oLinkCategory As New CLinkCategory
                        Dim sLinkFields() As String

                        sLinkFields = LinkRow.Split("|"c)

                        With oLinkCategory
                            .Name = sLinkFields(1)
                            .FileName = sLinkFields(2)
                            .LinkDefine = sLinkFields(3)
                        End With
                        Add(oLinkCategory)

                    End If

                Next
                Return True
            Loop
            Try



            Catch ex As Exception

                Throw ex
            End Try



            ' Cleanup the variables
            oFiler.Close()
            oFiler.Dispose()

        Else

            File.Create("LinkCategories.txt")

            If File.Exists(sPath) Then

                oFiler = File.OpenText(sPath)

                Do While oFiler.Peek <> -1
                    icnt += 1
                    sReadLine = oFiler.ReadLine

                    oLinkCategoryRecord = sReadLine.Split(CChar(vbCrLf))

                    For Each LinkRow As String In oLinkCategoryRecord

                        If LinkRow.Trim.Length > 3 Then

                            ' Process a student record
                            Dim oLinkCategory As New CLinkCategory
                            Dim sLinkFields() As String

                            sLinkFields = LinkRow.Split("|"c)

                            With oLinkCategory
                                .Name = sLinkFields(1)
                                .FileName = sLinkFields(2)
                                .LinkDefine = sLinkFields(3)
                            End With
                            Add(oLinkCategory)

                        End If

                    Next
                    Return True
                Loop
                Try



                Catch ex As Exception

                    Throw ex
                End Try



                ' Cleanup the variables
                oFiler.Close()
                oFiler.Dispose()



                MessageBox.Show("File doeesn't exist.")

            End If

            oFiler = Nothing
        End If



    End Function

    Public Function Save1() As Boolean





        ' Delete the output file
        Dim oFile As New CFile
        oFile.Delete()
        oFile = Nothing


        For Each oLinkCategory As CLinkCategory In Me
            oLinkCategory.Save()
        Next

        Return True

    End Function
    Public Function Save() As Boolean





        ' Delete the output file
        Dim oFile As New CFile
        oFile.Delete()
        oFile = Nothing


        For Each oLinkCategory As CLinkCategory In Me
            oLinkCategory.Save(msFileName)
        Next

        Return True

    End Function
    Public Function Load() As Boolean
        If File.Exists(msFileName) Then
            Dim oLinkCatRecord() As String
            Dim oFile As New CFile(msFileName)

            Try

                Dim sInput As String = oFile.Load()

                oLinkCatRecord = sInput.Split(CChar(vbCrLf))

                For Each linkRow As String In oLinkCatRecord

                    If linkRow.Trim.Length > 3 Then

                        ' Process a student record
                        Dim oLinkCategory As New CLinkCategory
                        Dim sLinkFields() As String

                        sLinkFields = linkRow.Split("|"c)

                        With oLinkCategory

                            .Name = sLinkFields(0)
                            .FileName = sLinkFields(1)
                            .LinkDefine = sLinkFields(2)
                        End With
                        Add(oLinkCategory)

                    End If

                Next
                Return True

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        Else
            File.Create("LinkCategories.txt")
            Load()
        End If

    End Function
End Class
