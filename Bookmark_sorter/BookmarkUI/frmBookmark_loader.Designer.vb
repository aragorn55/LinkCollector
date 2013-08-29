<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookmark_loader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.btnHtml = New System.Windows.Forms.Button()
        Me.txtHtml = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(26, 162)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Open file"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(188, 162)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(12, 55)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(106, 13)
        Me.lblPath.TabIndex = 3
        Me.lblPath.Text = "Bookmark file to sort:"
        '
        'lblFilePath
        '
        Me.lblFilePath.BackColor = System.Drawing.Color.White
        Me.lblFilePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFilePath.Location = New System.Drawing.Point(124, 54)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(139, 23)
        Me.lblFilePath.TabIndex = 4
        '
        'btnHtml
        '
        Me.btnHtml.Location = New System.Drawing.Point(15, 90)
        Me.btnHtml.Name = "btnHtml"
        Me.btnHtml.Size = New System.Drawing.Size(75, 23)
        Me.btnHtml.TabIndex = 5
        Me.btnHtml.Text = "Button1"
        Me.btnHtml.UseVisualStyleBackColor = True
        '
        'txtHtml
        '
        Me.txtHtml.Location = New System.Drawing.Point(124, 93)
        Me.txtHtml.Name = "txtHtml"
        Me.txtHtml.Size = New System.Drawing.Size(100, 20)
        Me.txtHtml.TabIndex = 6
        '
        'frmBookmark_loader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.txtHtml)
        Me.Controls.Add(Me.btnHtml)
        Me.Controls.Add(Me.lblFilePath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOpen)
        Me.Name = "frmBookmark_loader"
        Me.Text = "frmBookmark_loader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents btnHtml As System.Windows.Forms.Button
    Friend WithEvents txtHtml As System.Windows.Forms.TextBox
End Class
