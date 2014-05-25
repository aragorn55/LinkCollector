using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
namespace BookmarkUI
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class frmBookmark_loader : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.lblPath = new System.Windows.Forms.Label();
			this.lblFilePath = new System.Windows.Forms.Label();
			this.btnHtml = new System.Windows.Forms.Button();
			this.txtHtml = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			//btnOpen
			//
			this.btnOpen.Location = new System.Drawing.Point(26, 162);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open file";
			this.btnOpen.UseVisualStyleBackColor = true;
			//
			//btnExit
			//
			this.btnExit.Location = new System.Drawing.Point(188, 162);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "exit";
			this.btnExit.UseVisualStyleBackColor = true;
			//
			//lblPath
			//
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(12, 55);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(106, 13);
			this.lblPath.TabIndex = 3;
			this.lblPath.Text = "Bookmark file to sort:";
			//
			//lblFilePath
			//
			this.lblFilePath.BackColor = System.Drawing.Color.White;
			this.lblFilePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFilePath.Location = new System.Drawing.Point(124, 54);
			this.lblFilePath.Name = "lblFilePath";
			this.lblFilePath.Size = new System.Drawing.Size(139, 23);
			this.lblFilePath.TabIndex = 4;
			//
			//btnHtml
			//
			this.btnHtml.Location = new System.Drawing.Point(15, 90);
			this.btnHtml.Name = "btnHtml";
			this.btnHtml.Size = new System.Drawing.Size(75, 23);
			this.btnHtml.TabIndex = 5;
			this.btnHtml.Text = "Button1";
			this.btnHtml.UseVisualStyleBackColor = true;
			//
			//txtHtml
			//
			this.txtHtml.Location = new System.Drawing.Point(124, 93);
			this.txtHtml.Name = "txtHtml";
			this.txtHtml.Size = new System.Drawing.Size(100, 20);
			this.txtHtml.TabIndex = 6;
			//
			//frmBookmark_loader
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.txtHtml);
			this.Controls.Add(this.btnHtml);
			this.Controls.Add(this.lblFilePath);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnOpen);
			this.Name = "frmBookmark_loader";
			this.Text = "frmBookmark_loader";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button withEventsField_btnOpen;
		internal System.Windows.Forms.Button btnOpen {
			get { return withEventsField_btnOpen; }
			set {
				if (withEventsField_btnOpen != null) {
					withEventsField_btnOpen.Click -= btnOpen_Click;
				}
				withEventsField_btnOpen = value;
				if (withEventsField_btnOpen != null) {
					withEventsField_btnOpen.Click += btnOpen_Click;
				}
			}
		}
		internal System.Windows.Forms.Button btnExit;
		internal System.Windows.Forms.Label lblPath;
		internal System.Windows.Forms.Label lblFilePath;
		private System.Windows.Forms.Button withEventsField_btnHtml;
		internal System.Windows.Forms.Button btnHtml {
			get { return withEventsField_btnHtml; }
			set {
				if (withEventsField_btnHtml != null) {
					withEventsField_btnHtml.Click -= btnHtml_Click;
				}
				withEventsField_btnHtml = value;
				if (withEventsField_btnHtml != null) {
					withEventsField_btnHtml.Click += btnHtml_Click;
				}
			}
		}
		internal System.Windows.Forms.TextBox txtHtml;
		public frmBookmark_loader()
		{
			InitializeComponent();
		}
	}
}
