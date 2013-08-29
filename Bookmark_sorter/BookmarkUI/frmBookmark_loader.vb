Imports System.IO
Imports System.Windows.Forms
Imports Bookmark_sorter

Public Class frmBookmark_loader

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim oBkSorter As CBookmarkSorter
        Dim oFile As StreamReader
        Dim sPath As String = "c:\fileio\flatfile.txt"
        Dim icnt As Integer = 0
        Dim strBookmark As String
        oBkSorter = New CBookmarkSorter

        Dim ofdOpenDlg As New OpenFileDialog

        ofdOpenDlg.InitialDirectory = "C:\FileIO"
        ofdOpenDlg.Title = "Pick a file to Open"
        ofdOpenDlg.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*"

        If ofdOpenDlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Open the file that the user picked

            sPath = ofdOpenDlg.FileName
            Me.Text = sPath
            If File.Exists(sPath) Then

                oFile = File.OpenText(sPath)

                Do While oFile.Peek <> -1
                    icnt += 1
                    strBookmark = oFile.ReadLine
                    oBkSorter.SortBookmark(strBookmark)
                Loop

                ' Cleanup the variables
                oFile.Close()
                oFile.Dispose()

            Else

                MessageBox.Show("File doeesn't exist.")

            End If

        End If
        oFile = Nothing


    End Sub

    Private Sub btnHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHtml.Click
        Dim oBkExtractor As CBookmarkExtractor
        Dim oFile As StreamReader
        Dim sPath As String = "c:\fileio\flatfile.txt"
        Dim icnt As Integer = 0
        Dim strBookmark As String
        oBkExtractor = New CBookmarkExtractor

        Dim ofdOpenDlg As New OpenFileDialog

        ofdOpenDlg.InitialDirectory = "C:\FileIO"
        ofdOpenDlg.Title = "Pick a file to Open"
        ofdOpenDlg.Filter = "Text files (*.html)|*.txt|All Files (*.*)|*.*"

        If ofdOpenDlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Open the file that the user picked

            sPath = ofdOpenDlg.FileName
            Me.Text = sPath
            If File.Exists(sPath) Then

                oFile = File.OpenText(sPath)

                Do While oFile.Peek <> -1
                    icnt += 1
                    strBookmark = oFile.ReadLine
                    oBkExtractor.ExtractBookmark(strBookmark)
                Loop

                ' Cleanup the variables
                oFile.Close()
                oFile.Dispose()

            Else

                MessageBox.Show("File doeesn't exist.")

            End If

        End If
        oFile = Nothing


    End Sub
End Class