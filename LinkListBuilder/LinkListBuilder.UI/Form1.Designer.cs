namespace LinkListBuilder.UI
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
            this.btnCollectLinksFromFolder = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnMergeLinkFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCollectLinksFromFolder
            // 
            this.btnCollectLinksFromFolder.Location = new System.Drawing.Point(61, 75);
            this.btnCollectLinksFromFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCollectLinksFromFolder.Name = "btnCollectLinksFromFolder";
            this.btnCollectLinksFromFolder.Size = new System.Drawing.Size(249, 28);
            this.btnCollectLinksFromFolder.TabIndex = 0;
            this.btnCollectLinksFromFolder.Text = "CollectLinksFromFolder";
            this.btnCollectLinksFromFolder.UseVisualStyleBackColor = true;
            this.btnCollectLinksFromFolder.Click += new System.EventHandler(this.btnCollectLinksFromFolder_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOutput.Location = new System.Drawing.Point(13, 298);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(1034, 29);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "label1";
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(61, 142);
            this.btnSort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(249, 28);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "SortLinks";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnMergeLinkFiles
            // 
            this.btnMergeLinkFiles.Location = new System.Drawing.Point(337, 75);
            this.btnMergeLinkFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMergeLinkFiles.Name = "btnMergeLinkFiles";
            this.btnMergeLinkFiles.Size = new System.Drawing.Size(249, 28);
            this.btnMergeLinkFiles.TabIndex = 3;
            this.btnMergeLinkFiles.Text = "Merge Link Files";
            this.btnMergeLinkFiles.UseVisualStyleBackColor = true;
            this.btnMergeLinkFiles.Click += new System.EventHandler(this.btnMergeLinkFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 336);
            this.Controls.Add(this.btnMergeLinkFiles);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnCollectLinksFromFolder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCollectLinksFromFolder;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnMergeLinkFiles;
    }
}

