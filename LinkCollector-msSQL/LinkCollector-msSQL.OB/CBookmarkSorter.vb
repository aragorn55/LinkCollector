Imports BookmarSorter.DL
Imports System.IO

Public Class CBookmarkSorter
    Private msFileName As String = "LinkCategories.txt"
    Private oLinkCategories As CLinkCategories
    Public Sub SortBookmark(ByVal vstrBookmark As String)
        Dim oFile As CFileManager
        oFile = New CFileManager

        Dim intCount As Integer

        For intSearched As Integer = 0 To (oLinkCategories.Count - 1)
            Dim oLinkCategory As CLinkCategory
            oLinkCategory = CType(oLinkCategories.Item(intSearched), CLinkCategory)
            intCount = vstrBookmark.IndexOf(oLinkCategory.LinkDefine)
            If intCount >= 0 Then
                oFile.SaveLink(vstrBookmark, oLinkCategory.FileName)
            End If
        Next

        
        oFile.SaveLink(vstrBookmark, "miscBookmarks.txt")



    End Sub
    Public Sub New()
        oLinkCategories = New CLinkCategories
        oLinkCategories.Load()


    End Sub
    Public Sub SortBookmarkDB(ByVal vstrBookmark As String)
        Dim oFile As CFileManager
        oFile = New CFileManager

        Dim intCount As Integer

        For intSearched As Integer = 0 To (oLinkCategories.Count - 1)
            Dim oLinkCategory As CLinkCategory
            oLinkCategory = CType(oLinkCategories.Item(intSearched), CLinkCategory)
            intCount = vstrBookmark.IndexOf(oLinkCategory.LinkDefine)
            If intCount >= 0 Then
                oFile.SaveLink(vstrBookmark, oLinkCategory.FileName)
            End If
        Next


        oFile.SaveLink(vstrBookmark, "miscBookmarks.txt")



    End Sub
End Class
