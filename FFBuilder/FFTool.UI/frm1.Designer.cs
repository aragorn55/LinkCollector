namespace FFTool.UI
{
    partial class frm1
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
            this.btnCollectLinks = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.btnFileChooser = new System.Windows.Forms.Button();
            this.btnCMarksExtractor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCollectLinks
            // 
            this.btnCollectLinks.Location = new System.Drawing.Point(378, 37);
            this.btnCollectLinks.Name = "btnCollectLinks";
            this.btnCollectLinks.Size = new System.Drawing.Size(75, 23);
            this.btnCollectLinks.TabIndex = 0;
            this.btnCollectLinks.Text = "button1";
            this.btnCollectLinks.UseVisualStyleBackColor = true;
            this.btnCollectLinks.Click += new System.EventHandler(this.btnCollectLinks_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(105, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label1";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(378, 66);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(375, 96);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Test";
            // 
            // lblTest2
            // 
            this.lblTest2.AutoSize = true;
            this.lblTest2.Location = new System.Drawing.Point(375, 118);
            this.lblTest2.Name = "lblTest2";
            this.lblTest2.Size = new System.Drawing.Size(23, 13);
            this.lblTest2.TabIndex = 5;
            this.lblTest2.Text = "lbl2";
            // 
            // btnFileChooser
            // 
            this.btnFileChooser.Location = new System.Drawing.Point(52, 186);
            this.btnFileChooser.Name = "btnFileChooser";
            this.btnFileChooser.Size = new System.Drawing.Size(75, 23);
            this.btnFileChooser.TabIndex = 7;
            this.btnFileChooser.Text = "FileChooser";
            this.btnFileChooser.UseVisualStyleBackColor = true;
            this.btnFileChooser.Click += new System.EventHandler(this.btnFileChooser_Click);
            // 
            // btnCMarksExtractor
            // 
            this.btnCMarksExtractor.Location = new System.Drawing.Point(323, 198);
            this.btnCMarksExtractor.Name = "btnCMarksExtractor";
            this.btnCMarksExtractor.Size = new System.Drawing.Size(112, 23);
            this.btnCMarksExtractor.TabIndex = 8;
            this.btnCMarksExtractor.Text = "btnCMarksExtractor";
            this.btnCMarksExtractor.UseVisualStyleBackColor = true;
            this.btnCMarksExtractor.Click += new System.EventHandler(this.btnCMarksExtractor_Click);
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 331);
            this.Controls.Add(this.btnCMarksExtractor);
            this.Controls.Add(this.btnFileChooser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTest2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCollectLinks);
            this.Name = "frm1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCollectLinks;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTest2;
        private System.Windows.Forms.Button btnFileChooser;
        private System.Windows.Forms.Button btnCMarksExtractor;
    }
}

