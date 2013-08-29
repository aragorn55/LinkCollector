
Option Explicit On
Option Strict On

Imports System



<System.ComponentModel.ToolboxItem(true)>  _
Public Class GtkBookmarkLoader
	Inherits Gtk.DrawingArea
	
	Public Sub New()
		MyBase.New
		'Insert initialization code here.
	End Sub
	
	Protected Overrides Function OnButtonPressEvent(ByVal ev As Gdk.EventButton) As Boolean
		'Insert button press handling code here.
		Return MyBase.OnButtonPressEvent(ev)
	End Function
	
	Protected Overrides Function OnExposeEvent(ByVal ev As Gdk.EventExpose) As Boolean
		MyBase.OnExposeEvent(ev)
		'Insert drawing code here.
		Return true
	End Function
	
	Protected Overrides Sub OnSizeAllocated(ByVal allocation As Gdk.Rectangle)
		MyBase.OnSizeAllocated(allocation)
		'Insert layout code here.
	End Sub
	
	Protected Overrides Sub OnSizeRequested(ByRef requisition As Gtk.Requisition)
		'Calculate desired size here.
		requisition.Height = 50
		requisition.Width = 50
	End Sub
End Class

