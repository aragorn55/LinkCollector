Imports System.IO
Public Class CLinkFiler

    Private oDbBookmarks As BookmarkDBDataSet
    Dim oBookmarkTables As CDatabaseControl
    Dim oDataTableReader As DataTableReader
    Private obbTable1 As DataTable
    ' Public Sub FileLink(ByVal vsURL As String, ByVal vsTableName As String, ByVal vsLinkDefine As String)
    'Dimension a new instance of the datacontext variable
    '    oDbBookmarks = New BookmarDatabaseDataSet

    '    Dim oBookmark As CBookmark
    ' With oBookmark
    '.BookmarkCategory = vsTableName
    '  .BookmarkURL = vsURL
    '   End With
    'select the data
    '  Dim oCustomers = From oCustomer In oDb.Customers
    '      Where oCustomer.City = "London" And
    '      oCustomer.CustomerID = "EASTC"
    '        Select oCustomer.CustomerID,
    '        oCustomer.ContactName,
    '            oCustomer.CompanyName

    'Bind the grid
    '  Me.DataGridView1.DataSource = oCustomers

    '    lblResults.Text = "Customers : " & oCustomers.Count

    '  oDb.Customers.InsertOnSubmit(oCustomer)
    '     oDb.SubmitChanges()
    '  End Sub
    'Public Sub SaveFF_net(ByVal voBookmark As CBookmark)
    ' oDbBookmarks.Tables.

    '  obbTable1 = BookmarDatabaseDataSet

    '  End Sub
    Public Sub New()
        oDbBookmarks = New BookmarkDBDataSet

        oBookmarkTables = New CDatabaseControl
        oDataTableReader = oDbBookmarks.CreateDataReader()
        obbTable1.Load(oDbBookmarks.CreateDataReader())
        oBookmarkTables.Add(obbTable1)

    End Sub


    ' Public Sub Add(ByVal oBookmarkTable As CLinkCategory)

    '    MyBase.List.Add(oLinkCategory)

    ' End Sub
    '   Public Overloads Sub RemoveAt(ByVal viIndex As Integer)

    '      MyBase.List.RemoveAt(viIndex)

    ' End Sub

    '  Default Public ReadOnly Property Item(ByVal viIndex As Integer) As CLinkCategory
    '     Get
    '         Return CType(MyBase.List.Item(viIndex), CLinkCategory)
    '      End Get
    '  End Property

    ' Public Function Load() As Boolean

    '        Dim oLinkCategoryRecord() As String
    '       Dim oFile As New CFile()

    'Try

    '        Dim sInput As String = oFile.Load()

    'oLinkCategoryRecord = sInput.Split(CChar(vbCrLf))

    'For Each LinkRow As String In oLinkCategoryRecord
    '
    '     If LinkRow.Trim.Length > 3 Then

    ' Process a student record
    '   Dim oLinkCategory As New CLinkCategory
    '  Dim sLinkFields() As String

    '       sLinkFields = LinkRow.Split("|"c)

    '      With oLinkCategory
    '.Name = sLinkFields(1)
    '     .FileName = sLinkFields(2)
    '     .LinkDefine = sLinkFields(3)
    '      End With
    '     Add(oLinkCategory)
    '
    '    End If

    '   Next
    '    Return True

    '    Catch ex As Exception

    'Throw ex
    '    End Try

    ' End Function

    'Public Function Save() As Boolean





    ' Delete the output file
    '      Dim oFile As New CFile
    '     oFile.Delete()
    '       oFile = Nothing


    '    For Each oLinkCategory As CLinkCategory In Me
    'oLinkCategory.Save()
    '   Next
    '
    '      Return True

    '  End Function
End Class
