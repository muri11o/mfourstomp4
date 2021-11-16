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
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblLastAudioUri = new System.Windows.Forms.Label();
            this.lblLastVideoUri = new System.Windows.Forms.Label();
            this.txtLastAudioUri = new System.Windows.Forms.TextBox();
            this.txtLastVideoUri = new System.Windows.Forms.TextBox();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.lblSelectSaveTo = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(480, 99);
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
            this.txtLastAudioUri.Size = new System.Drawing.Size(456, 23);
            this.txtLastAudioUri.TabIndex = 3;
            // 
            // txtLastVideoUri
            // 
            this.txtLastVideoUri.Location = new System.Drawing.Point(99, 45);
            this.txtLastVideoUri.Name = "txtLastVideoUri";
            this.txtLastVideoUri.Size = new System.Drawing.Size(456, 23);
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
            this.lblSelectSaveTo.Size = new System.Drawing.Size(0, 15);
            this.lblSelectSaveTo.TabIndex = 6;
            this.lblSelectSaveTo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectSaveTo_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 157);
            this.Controls.Add(this.lblSelectSaveTo);
            this.Controls.Add(this.lblSaveTo);
            this.Controls.Add(this.txtLastVideoUri);
            this.Controls.Add(this.txtLastAudioUri);
            this.Controls.Add(this.lblLastVideoUri);
            this.Controls.Add(this.lblLastAudioUri);
            this.Controls.Add(this.btnProcess);
            this.Name = "frmMain";
            this.Text = "MFourS to MP4";
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
    }
}