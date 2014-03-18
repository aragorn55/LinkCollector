Public Class CBookmark
    Private msURL As String
    Private msCategory As String
    Public Property BookmarkURL() As String
        Get
            Return msURL
        End Get
        Set(ByVal value As String)
            msURL = value

        End Set
    End Property
    Public Property BookmarkCategory() As String
        Get
            Return msCategory
        End Get
        Set(ByVal value As String)
            msCategory = value

        End Set
    End Property
End Class
