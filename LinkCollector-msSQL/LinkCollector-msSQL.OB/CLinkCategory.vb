Imports BookmarSorter.DL

Public Class CLinkCategory
    Private mstrName As String
    Private mstrFileName As String
    Private mstrLinkDefine As String
    Dim msFileName As String = "LinkCategories.txt"
    Public Property Name() As String
        Get
            Return mstrName
        End Get
        Set(ByVal value As String)
            mstrName = value
        End Set
    End Property
    Public Property FileName() As String
        Get
            Return mstrFileName
        End Get
        Set(ByVal value As String)
            mstrFileName = value
        End Set
    End Property
    Public Property LinkDefine() As String
        Get
            Return mstrLinkDefine
        End Get
        Set(ByVal value As String)
            mstrLinkDefine = value
        End Set
    End Property
    Public Sub New(ByVal vsName As String, ByVal vsFileName As String, ByVal vsLinkDefine As String)
        mstrName = vsName
        mstrFileName = vsFileName
        mstrLinkDefine = vsLinkDefine
    End Sub
    Public Sub New()
        mstrName = ""
        mstrFileName = ""
        mstrLinkDefine = ""
    End Sub
    Public Function Save() As Boolean

        Try

            Dim oFiler As New CFile()
            oFiler.Save(mstrName & "|" & mstrFileName & "|" & mstrLinkDefine)
            Return True

        Catch ex As Exception

            Throw ex


        End Try


    End Function
    Public Function Save(ByVal vsFileName As String) As Boolean

        Try

            Dim oFiler As New CFile(vsFileName)
            oFiler.Save(mstrName & "|" & mstrFileName & "|" & mstrLinkDefine)
            Return True

        Catch ex As Exception

            Throw ex


        End Try


    End Function
End Class
