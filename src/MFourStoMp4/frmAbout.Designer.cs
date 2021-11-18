namespace MFourStoMp4
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.picImageAbout = new System.Windows.Forms.PictureBox();
            this.lblAbout1 = new System.Windows.Forms.Label();
            this.lblAbout2 = new System.Windows.Forms.Label();
            this.lblAbout3 = new System.Windows.Forms.Label();
            this.lblAbout4 = new System.Windows.Forms.Label();
            this.lblAbout5 = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblSiteFfmpeg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImageAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // picImageAbout
            // 
            this.picImageAbout.Location = new System.Drawing.Point(12, 12);
            this.picImageAbout.Name = "picImageAbout";
            this.picImageAbout.Size = new System.Drawing.Size(128, 101);
            this.picImageAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImageAbout.TabIndex = 0;
            this.picImageAbout.TabStop = false;
            // 
            // lblAbout1
            // 
            this.lblAbout1.AutoSize = true;
            this.lblAbout1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAbout1.Location = new System.Drawing.Point(142, 12);
            this.lblAbout1.Name = "lblAbout1";
            this.lblAbout1.Size = new System.Drawing.Size(202, 37);
            this.lblAbout1.TabIndex = 1;
            this.lblAbout1.Text = "MFourStoMp4";
            // 
            // lblAbout2
            // 
            this.lblAbout2.AutoSize = true;
            this.lblAbout2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAbout2.Location = new System.Drawing.Point(264, 52);
            this.lblAbout2.Name = "lblAbout2";
            this.lblAbout2.Size = new System.Drawing.Size(72, 13);
            this.lblAbout2.TabIndex = 2;
            this.lblAbout2.Text = "Version: 1.0.0";
            // 
            // lblAbout3
            // 
            this.lblAbout3.AutoSize = true;
            this.lblAbout3.Location = new System.Drawing.Point(12, 133);
            this.lblAbout3.Name = "lblAbout3";
            this.lblAbout3.Size = new System.Drawing.Size(181, 15);
            this.lblAbout3.TabIndex = 4;
            this.lblAbout3.Text = "Developed by Murillo F. S. Freitas";
            // 
            // lblAbout4
            // 
            this.lblAbout4.AutoSize = true;
            this.lblAbout4.Location = new System.Drawing.Point(12, 148);
            this.lblAbout4.Name = "lblAbout4";
            this.lblAbout4.Size = new System.Drawing.Size(166, 15);
            this.lblAbout4.TabIndex = 5;
            this.lblAbout4.Text = "E-mail: murillofsf@gmail.com";
            // 
            // lblAbout5
            // 
            this.lblAbout5.AutoSize = true;
            this.lblAbout5.Location = new System.Drawing.Point(12, 175);
            this.lblAbout5.Name = "lblAbout5";
            this.lblAbout5.Size = new System.Drawing.Size(332, 30);
            this.lblAbout5.TabIndex = 6;
            this.lblAbout5.Text = "MFourStoMp4 makes use of FFmpeg to convert files to .mp4, \r\nand in addition to jo" +
    "ining audio and video files.";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(146, 69);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(196, 15);
            this.lblSite.TabIndex = 8;
            this.lblSite.Text = "github.com/muri11o/mfourstomp4";
            // 
            // lblSiteFfmpeg
            // 
            this.lblSiteFfmpeg.AutoSize = true;
            this.lblSiteFfmpeg.Location = new System.Drawing.Point(12, 205);
            this.lblSiteFfmpeg.Name = "lblSiteFfmpeg";
            this.lblSiteFfmpeg.Size = new System.Drawing.Size(67, 15);
            this.lblSiteFfmpeg.TabIndex = 9;
            this.lblSiteFfmpeg.Text = "ffmpeg.org";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 231);
            this.Controls.Add(this.lblSiteFfmpeg);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.lblAbout5);
            this.Controls.Add(this.lblAbout4);
            this.Controls.Add(this.lblAbout3);
            this.Controls.Add(this.lblAbout2);
            this.Controls.Add(this.lblAbout1);
            this.Controls.Add(this.picImageAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Text = "MFourStoMp4 - About";
            ((System.ComponentModel.ISupportInitialize)(this.picImageAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImageAbout;
        private System.Windows.Forms.Label lblAbout1;
        private System.Windows.Forms.Label lblAbout2;
        private System.Windows.Forms.Label lblAbout3;
        private System.Windows.Forms.Label lblAbout4;
        private System.Windows.Forms.Label lblAbout5;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblSiteFfmpeg;
    }
}