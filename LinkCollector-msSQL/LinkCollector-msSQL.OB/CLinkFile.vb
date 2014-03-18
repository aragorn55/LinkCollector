Public Class CLinkFile
    Private msFileName As String
    Private msFilePath As String
    Private mblnSorted As Boolean


    Public Property FileName() As String
        Get
            Return msFileName
        End Get
        Set(ByVal value As String)
            msFileName = value

        End Set
    End Property
    Public Property FilePath() As String
        Get
            Return msFilePath
        End Get
        Set(ByVal value As String)
            msFilePath = value

        End Set
    End Property
    Public Property Sorted() As Boolean
        Get
            Return mblnSorted
        End Get
        Set(ByVal value As Boolean)
            mblnSorted = value

        End Set
    End Property
    Public Sub New()
        mblnSorted = False

    End Sub
End Class
