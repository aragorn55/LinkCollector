namespace BookmarkSorted2.UI
{
    partial class frmBookmarks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btnHtml = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(191, 103);
            this.txtHtml.Margin = new System.Windows.Forms.Padding(4);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(185, 22);
            this.txtHtml.TabIndex = 12;
            // 
            // btnHtml
            // 
            this.btnHtml.Location = new System.Drawing.Point(25, 252);
            this.btnHtml.Margin = new System.Windows.Forms.Padding(4);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(100, 28);
            this.btnHtml.TabIndex = 11;
            this.btnHtml.Text = "HTML";
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.BackColor = System.Drawing.Color.White;
            this.lblFilePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFilePath.Location = new System.Drawing.Point(191, 45);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(185, 28);
            this.lblFilePath.TabIndex = 10;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(33, 46);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(141, 17);
            this.lblPath.TabIndex = 9;
            this.lblPath.Text = "Bookmark file to sort:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(450, 252);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(234, 252);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 28);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 398);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnHtml);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.Name = "frmBookmarks";
            this.Text = "frmBookmarks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtHtml;
        internal System.Windows.Forms.Button btnHtml;
        internal System.Windows.Forms.Label lblFilePath;
        internal System.Windows.Forms.Label lblPath;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnOpen;
    }
}