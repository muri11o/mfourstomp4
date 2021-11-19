namespace MFourS
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblLastAudioUri = new System.Windows.Forms.Label();
            this.lblLastVideoUri = new System.Windows.Forms.Label();
            this.txtLastAudioUri = new System.Windows.Forms.TextBox();
            this.txtLastVideoUri = new System.Windows.Forms.TextBox();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.lblSelectSaveTo = new System.Windows.Forms.LinkLabel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProccesing = new System.Windows.Forms.Label();
            this.btnCleanAll = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.chkDeleteTemporaryFiles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(1003, 102);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblLastAudioUri
            // 
            this.lblLastAudioUri.AutoSize = true;
            this.lblLastAudioUri.Location = new System.Drawing.Point(12, 22);
            this.lblLastAudioUri.Name = "lblLastAudioUri";
            this.lblLastAudioUri.Size = new System.Drawing.Size(81, 15);
            this.lblLastAudioUri.TabIndex = 1;
            this.lblLastAudioUri.Text = "Last audio uri:";
            // 
            // lblLastVideoUri
            // 
            this.lblLastVideoUri.AutoSize = true;
            this.lblLastVideoUri.Location = new System.Drawing.Point(13, 53);
            this.lblLastVideoUri.Name = "lblLastVideoUri";
            this.lblLastVideoUri.Size = new System.Drawing.Size(80, 15);
            this.lblLastVideoUri.TabIndex = 2;
            this.lblLastVideoUri.Text = "Last video uri:";
            // 
            // txtLastAudioUri
            // 
            this.txtLastAudioUri.Location = new System.Drawing.Point(99, 14);
            this.txtLastAudioUri.Name = "txtLastAudioUri";
            this.txtLastAudioUri.Size = new System.Drawing.Size(1059, 23);
            this.txtLastAudioUri.TabIndex = 3;
            // 
            // txtLastVideoUri
            // 
            this.txtLastVideoUri.Location = new System.Drawing.Point(99, 45);
            this.txtLastVideoUri.Name = "txtLastVideoUri";
            this.txtLastVideoUri.Size = new System.Drawing.Size(1060, 23);
            this.txtLastVideoUri.TabIndex = 4;
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.AutoSize = true;
            this.lblSaveTo.Location = new System.Drawing.Point(45, 82);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(48, 15);
            this.lblSaveTo.TabIndex = 5;
            this.lblSaveTo.Text = "Save to:";
            // 
            // lblSelectSaveTo
            // 
            this.lblSelectSaveTo.AutoSize = true;
            this.lblSelectSaveTo.Location = new System.Drawing.Point(99, 82);
            this.lblSelectSaveTo.Name = "lblSelectSaveTo";
            this.lblSelectSaveTo.Size = new System.Drawing.Size(37, 15);
            this.lblSelectSaveTo.TabIndex = 6;
            this.lblSelectSaveTo.TabStop = true;
            this.lblSelectSaveTo.Text = "select";
            this.lblSelectSaveTo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectSaveTo_LinkClicked);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStatus.Location = new System.Drawing.Point(13, 160);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(969, 212);
            this.txtStatus.TabIndex = 7;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(1016, 204);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(118, 105);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 9;
            this.picImage.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // lblProccesing
            // 
            this.lblProccesing.AutoSize = true;
            this.lblProccesing.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProccesing.Location = new System.Drawing.Point(1016, 312);
            this.lblProccesing.Name = "lblProccesing";
            this.lblProccesing.Size = new System.Drawing.Size(142, 25);
            this.lblProccesing.TabIndex = 11;
            this.lblProccesing.Text = "MFoursToMp4";
            // 
            // btnCleanAll
            // 
            this.btnCleanAll.Location = new System.Drawing.Point(1084, 102);
            this.btnCleanAll.Name = "btnCleanAll";
            this.btnCleanAll.Size = new System.Drawing.Size(75, 23);
            this.btnCleanAll.TabIndex = 13;
            this.btnCleanAll.Text = "Clean all";
            this.btnCleanAll.UseVisualStyleBackColor = true;
            this.btnCleanAll.Click += new System.EventHandler(this.btnCleanAll_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(1083, 347);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 14;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // chkDeleteTemporaryFiles
            // 
            this.chkDeleteTemporaryFiles.AutoSize = true;
            this.chkDeleteTemporaryFiles.Location = new System.Drawing.Point(99, 104);
            this.chkDeleteTemporaryFiles.Name = "chkDeleteTemporaryFiles";
            this.chkDeleteTemporaryFiles.Size = new System.Drawing.Size(141, 19);
            this.chkDeleteTemporaryFiles.TabIndex = 15;
            this.chkDeleteTemporaryFiles.Text = "Delete temporary files";
            this.chkDeleteTemporaryFiles.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 384);
            this.Controls.Add(this.chkDeleteTemporaryFiles);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnCleanAll);
            this.Controls.Add(this.lblProccesing);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblSelectSaveTo);
            this.Controls.Add(this.lblSaveTo);
            this.Controls.Add(this.txtLastVideoUri);
            this.Controls.Add(this.txtLastAudioUri);
            this.Controls.Add(this.lblLastVideoUri);
            this.Controls.Add(this.lblLastAudioUri);
            this.Controls.Add(this.btnProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MFourS to MP4";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblLastAudioUri;
        private System.Windows.Forms.Label lblLastVideoUri;
        private System.Windows.Forms.TextBox txtLastAudioUri;
        private System.Windows.Forms.TextBox txtLastVideoUri;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.LinkLabel lblSelectSaveTo;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProccesing;
        private System.Windows.Forms.Button btnCleanAll;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkDeleteTemporaryFiles;
    }
}