using MFourS.Classes;
using MFourS.Enumerables;
using MFourStoMp4;
using System;
using System.IO;
using System.Windows.Forms;

namespace MFourS
{
    public partial class frmMain : Form
    {
        private string _selectedFolder;

        public frmMain()
        {
            InitializeComponent();
            _selectedFolder = "";
            lblSelectSaveTo.Text = "select folder";
            NotProcessing();
            chkDeleteTemporaryFiles.Checked = true;
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            var audioFolderName = Guid.NewGuid().ToString();
            var videoFolderName = Guid.NewGuid().ToString();
            var urlAudio = txtLastAudioUri.Text;
            var urlVideo = txtLastVideoUri.Text;

            try
            {
                DisableControls();
                Processing();

                if (String.IsNullOrEmpty(_selectedFolder))
                    throw new Exception("Select a folder to save the file");

                MFourSHandler mfsHandler = new MFourSHandler(urlAudio, urlVideo);

                mfsHandler.CreateTemporaryFolder(_selectedFolder, audioFolderName);
                mfsHandler.CreateTemporaryFolder(_selectedFolder, videoFolderName);

                txtStatus.AppendText(Environment.NewLine + "Download started...");
                DownloadManager downloadManager = new DownloadManager();
                await downloadManager.StartDownloadAsync(mfsHandler.urisAudio, Path.Combine(_selectedFolder, audioFolderName), FileTypeEnum.Audio);
                await downloadManager.StartDownloadAsync(mfsHandler.urisVideo, Path.Combine(_selectedFolder, videoFolderName), FileTypeEnum.Video);
                txtStatus.AppendText(Environment.NewLine + "Download finished");

                txtStatus.AppendText(Environment.NewLine + "Concatenating files...");
                await mfsHandler.ConcatenateFiles(Path.Combine(_selectedFolder, audioFolderName), FileTypeEnum.Audio);
                await mfsHandler.ConcatenateFiles(Path.Combine(_selectedFolder, videoFolderName), FileTypeEnum.Video);
                txtStatus.AppendText(Environment.NewLine + "Concatenation finished");

                txtStatus.AppendText(Environment.NewLine + "Converting and joining files...");
                var pathVideoFineshed = await mfsHandler.ConvertAndJoinFiles(Path.Combine(_selectedFolder, videoFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Video)}.m4s"), Path.Combine(_selectedFolder, audioFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Audio)}.m4s"), _selectedFolder);
                txtStatus.AppendText(Environment.NewLine + "Converting and Joining finished");

                if (chkDeleteTemporaryFiles.Checked)
                {
                    txtStatus.AppendText(Environment.NewLine + "Deleting temporary files...");
                    MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, audioFolderName));
                    MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, videoFolderName));
                    txtStatus.AppendText(Environment.NewLine + "Temporary files deleted");
                }

                txtStatus.AppendText(Environment.NewLine + $"Your video is ready :D   >> {pathVideoFineshed}");
                MessageBox.Show($"{pathVideoFineshed}", "Your video is ready :D", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableControls();
                NotProcessing();
            }
            catch (Exception ex)
            {
                txtStatus.AppendText(Environment.NewLine + $"Ops...Something went wrong :(   >> {ex.Message}");
                EnableControls();
                NotProcessing();
                MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, audioFolderName));
                MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, videoFolderName));
                MessageBox.Show($"{ex.Message}", "Ops...Something went wrong :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblSelectSaveTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {

                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _selectedFolder = fbd.SelectedPath;
                    lblSelectSaveTo.Text = String.IsNullOrEmpty(_selectedFolder) ? "select folder" : _selectedFolder;
                }
            }
        }

        private void DisableControls()
        {
            txtLastAudioUri.Enabled = false;
            txtLastVideoUri.Enabled = false;
            EnableButtons();
        }

        private void EnableControls()
        {
            txtLastAudioUri.Enabled = true;
            txtLastVideoUri.Enabled = true;
            DisableButtons();
        }

        private void NotProcessing()
        {
            lblProccesing.Text = "MFourStoMp4";
            picImage.LoadAsync(Path.Combine(AppContext.BaseDirectory, "images", "ico1.png"));
        }

        private void Processing()
        {
            lblProccesing.Text = "Processing...";
            picImage.LoadAsync(Path.Combine(AppContext.BaseDirectory, "images", "processing.gif"));
        }

        private void EnableButtons()
        {
            btnProcess.Enabled = false;
            btnCleanAll.Enabled = false;
        }

        private void DisableButtons()
        {
            btnProcess.Enabled = true;
            btnCleanAll.Enabled = true;
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            txtLastAudioUri.Text = "";
            txtLastVideoUri.Text = "";
            txtStatus.Text = "";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var myForm = new frmAbout();
            myForm.ShowDialog();
        }

    }


}
