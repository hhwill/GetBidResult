namespace TesseractOCR
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLang = new System.Windows.Forms.TextBox();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDoOCR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLang);
            this.panel1.Controls.Add(this.btnSetPath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnDoOCR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSelectImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 60);
            this.panel1.TabIndex = 0;
            // 
            // txtLang
            // 
            this.txtLang.Location = new System.Drawing.Point(142, 6);
            this.txtLang.Name = "txtLang";
            this.txtLang.Size = new System.Drawing.Size(58, 20);
            this.txtLang.TabIndex = 8;
            // 
            // btnSetPath
            // 
            this.btnSetPath.Location = new System.Drawing.Point(622, 5);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(32, 23);
            this.btnSetPath.TabIndex = 7;
            this.btnSetPath.Text = "...";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tessdata path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(290, 7);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(326, 20);
            this.txtPath.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(93, 35);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // btnDoOCR
            // 
            this.btnDoOCR.Location = new System.Drawing.Point(12, 34);
            this.btnDoOCR.Name = "btnDoOCR";
            this.btnDoOCR.Size = new System.Drawing.Size(75, 23);
            this.btnDoOCR.TabIndex = 3;
            this.btnDoOCR.Text = "Do OCR";
            this.btnDoOCR.UseVisualStyleBackColor = true;
            this.btnDoOCR.Click += new System.EventHandler(this.btnDoOCR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lang";
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(3, 4);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(92, 23);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "Select image...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // lstResult
            // 
            this.lstResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(0, 60);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(145, 394);
            this.lstResult.TabIndex = 1;
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image|*.*";
            this.openFileDialog1.Title = "Select image";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(145, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 395);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 455);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Tesseract OCR .NET Wrapper demo";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btnDoOCR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSetPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtLang;
    }
}

