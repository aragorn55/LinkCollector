Imports System.IO
Imports System.Data.Common
Imports System.Data.OleDb

Public Class CDatabaseControl


    Inherits CollectionBase
    Private moBookmarkDB As BookmarkDBDataSet
    Private moBookmarkController As DataAdapter
    Public Sub New()
        '    moBookmarkController = New DataAdapter
        moBookmarkDB = New BookmarkDBDataSet

    End Sub



    Public Sub Add(ByVal oBookmarkTable As DataTable)

        MyBase.List.Add(oBookmarkTable)

    End Sub
    Public Overloads Sub RemoveAt(ByVal viIndex As Integer)

        MyBase.List.RemoveAt(viIndex)

    End Sub

    Default Public ReadOnly Property Item(ByVal viIndex As Integer) As DataTable
        Get
            Return CType(MyBase.List.Item(viIndex), DataTable)
        End Get
    End Property

    '   Public Function Load() As Boolean

    ' Dim oLinkCategoryRecord() As String
    '   Dim oFile As New CFile()

    '    Try

    ' Dim sInput As String = oFile.Load()

    '        oLinkCategoryRecord = sInput.Split(CChar(vbCrLf))
    '
    '      For Each LinkRow As String In oLinkCategoryRecord

    '        If LinkRow.Trim.Length > 3 Then

    ' Process a student record
    '   Dim oLinkCategory As New DataTable
    '  Dim sLinkFields() As String

    '        sLinkFields = LinkRow.Split("|"c)

    '        With oLinkCategory
    '           .Name = sLinkFields(1)
    '           .FileName = sLinkFields(2)
    '           .LinkDefine = sLinkFields(3)
    '        End With
    '        Add(oLinkCategory)

    '     End If

    '  Next
    '  Return True

    '   Catch ex As Exception

    '       Throw ex
    ' End Try

    '  End Function

    '  Public Function Save() As Boolean





    ' Delete the output file
    '      Dim oFile As New CFile
    '      oFile.Delete()
    '      oFile = Nothing


    '    For Each oLinkCategory As DataTable In Me
    '     oLinkCategory.Save()
    '     Next

    '     Return True

    '  End Function
    Public Sub AddRecord(ByVal sInputLink As String, ByVal sInputFileName As String)

    End Sub

    Public Sub InsertRow(ByVal connectionString As String, _
        ByVal insertSQL As String)

        Using connection As New OleDbConnection(connectionString)
            ' The insertSQL string contains a SQL statement that
            ' inserts a new row in the source table.
            Dim command As New OleDbCommand(insertSQL)

            ' Set the Connection to the new OleDbConnection.
            command.Connection = connection

            ' Open the connection and execute the insert command.
            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            ' The connection is automatically closed when the
            ' code exits the Using block.
        End Using
    End Sub


End Class
