namespace ASCIIArtMaker
{
    partial class frmASCII
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
            this.rtbASCII = new System.Windows.Forms.RichTextBox();
            this.picPicture = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.btnASCII = new System.Windows.Forms.Button();
            this.sldTolerance = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbASCII
            // 
            this.rtbASCII.Location = new System.Drawing.Point(16, 15);
            this.rtbASCII.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbASCII.Name = "rtbASCII";
            this.rtbASCII.Size = new System.Drawing.Size(1227, 842);
            this.rtbASCII.TabIndex = 0;
            this.rtbASCII.Text = "";
            // 
            // picPicture
            // 
            this.picPicture.Location = new System.Drawing.Point(1252, 15);
            this.picPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPicture.Name = "picPicture";
            this.picPicture.Size = new System.Drawing.Size(169, 146);
            this.picPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPicture.TabIndex = 1;
            this.picPicture.TabStop = false;
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(1283, 169);
            this.btnPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(100, 28);
            this.btnPicture.TabIndex = 2;
            this.btnPicture.Text = "Select Pic";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // btnASCII
            // 
            this.btnASCII.Location = new System.Drawing.Point(1283, 204);
            this.btnASCII.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnASCII.Name = "btnASCII";
            this.btnASCII.Size = new System.Drawing.Size(100, 28);
            this.btnASCII.TabIndex = 3;
            this.btnASCII.Text = "getASCII";
            this.btnASCII.UseVisualStyleBackColor = true;
            this.btnASCII.Click += new System.EventHandler(this.btnASCII_Click);
            // 
            // sldTolerance
            // 
            this.sldTolerance.Location = new System.Drawing.Point(16, 865);
            this.sldTolerance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sldTolerance.Maximum = 1000;
            this.sldTolerance.Name = "sldTolerance";
            this.sldTolerance.Size = new System.Drawing.Size(1405, 56);
            this.sldTolerance.TabIndex = 4;
            this.sldTolerance.Scroll += new System.EventHandler(this.sldTolerance_Changed);
            this.sldTolerance.ValueChanged += new System.EventHandler(this.sldTolerance_Changed);
            // 
            // frmASCII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 918);
            this.Controls.Add(this.sldTolerance);
            this.Controls.Add(this.btnASCII);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.picPicture);
            this.Controls.Add(this.rtbASCII);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmASCII";
            this.Text = "ASCII Maker";
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbASCII;
        private System.Windows.Forms.PictureBox picPicture;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Button btnASCII;
        private System.Windows.Forms.TrackBar sldTolerance;
    }
}

