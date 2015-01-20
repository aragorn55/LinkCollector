namespace BookmarkCollector.UI
{
    partial class Form1
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
            this.txtTextInputPath = new System.Windows.Forms.TextBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTextLinkLoad = new System.Windows.Forms.Button();
            this.btnHtml = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btnSqlite = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSqlite = new System.Windows.Forms.TextBox();
            this.btnChrome = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChrome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTextInputPath
            // 
            this.txtTextInputPath.Location = new System.Drawing.Point(131, 39);
            this.txtTextInputPath.Name = "txtTextInputPath";
            this.txtTextInputPath.Size = new System.Drawing.Size(115, 22);
            this.txtTextInputPath.TabIndex = 7;
            this.txtTextInputPath.Text = "in.txt";
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 16;
            this.lstItems.Location = new System.Drawing.Point(131, 207);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(301, 132);
            this.lstItems.TabIndex = 6;
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(163, 122);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(207, 22);
            this.txtFileType.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(443, 121);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "text url list";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // btnTextLinkLoad
            // 
            this.btnTextLinkLoad.Location = new System.Drawing.Point(277, 33);
            this.btnTextLinkLoad.Name = "btnTextLinkLoad";
            this.btnTextLinkLoad.Size = new System.Drawing.Size(75, 23);
            this.btnTextLinkLoad.TabIndex = 11;
            this.btnTextLinkLoad.Text = "Text";
            this.btnTextLinkLoad.UseVisualStyleBackColor = true;
            this.btnTextLinkLoad.Click += new System.EventHandler(this.btnTextLinkLoad_Click);
            // 
            // btnHtml
            // 
            this.btnHtml.Location = new System.Drawing.Point(277, 72);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(75, 23);
            this.btnHtml.TabIndex = 14;
            this.btnHtml.Text = "html";
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Html url list";
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(131, 78);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(115, 22);
            this.txtHtml.TabIndex = 12;
            this.txtHtml.Text = "in.txt";
            // 
            // btnSqlite
            // 
            this.btnSqlite.Location = new System.Drawing.Point(665, 27);
            this.btnSqlite.Name = "btnSqlite";
            this.btnSqlite.Size = new System.Drawing.Size(75, 23);
            this.btnSqlite.TabIndex = 17;
            this.btnSqlite.Text = "Sqlite";
            this.btnSqlite.UseVisualStyleBackColor = true;
            this.btnSqlite.Click += new System.EventHandler(this.btnSqlite_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Sqlite url list";
            // 
            // txtSqlite
            // 
            this.txtSqlite.Location = new System.Drawing.Point(519, 33);
            this.txtSqlite.Name = "txtSqlite";
            this.txtSqlite.Size = new System.Drawing.Size(115, 22);
            this.txtSqlite.TabIndex = 15;
            this.txtSqlite.Text = "in.txt";
            // 
            // btnChrome
            // 
            this.btnChrome.Location = new System.Drawing.Point(665, 74);
            this.btnChrome.Name = "btnChrome";
            this.btnChrome.Size = new System.Drawing.Size(75, 24);
            this.btnChrome.TabIndex = 20;
            this.btnChrome.Text = "Chrome";
            this.btnChrome.UseVisualStyleBackColor = true;
            this.btnChrome.Click += new System.EventHandler(this.btnChrome_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Chrome url list";
            // 
            // txtChrome
            // 
            this.txtChrome.Location = new System.Drawing.Point(519, 80);
            this.txtChrome.Name = "txtChrome";
            this.txtChrome.Size = new System.Drawing.Size(115, 22);
            this.txtChrome.TabIndex = 18;
            this.txtChrome.Text = "in.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 489);
            this.Controls.Add(this.btnChrome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtChrome);
            this.Controls.Add(this.btnSqlite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSqlite);
            this.Controls.Add(this.btnHtml);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnTextLinkLoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTextInputPath);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.txtFileType);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTextInputPath;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTextLinkLoad;
        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.Button btnSqlite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSqlite;
        private System.Windows.Forms.Button btnChrome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChrome;
    }
}

