using MFourS.Classes;
using MFourS.Enumerables;
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
            lblProccesing.Text = "Processing...";
            picImageProcessing.LoadAsync(Path.Combine(AppContext.BaseDirectory, "processing.gif"));
            InvisibleProcessing();
            btnCancel.Enabled = false;

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
                VisibleProcessing();

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

                txtStatus.AppendText(Environment.NewLine + "Converting video .m4s to video .mp4...");
                var pathVideo = await mfsHandler.ConvertFile(Path.Combine(_selectedFolder, videoFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Video)}.m4s"), Path.Combine(_selectedFolder, videoFolderName));
                txtStatus.AppendText(Environment.NewLine + "Conversion finished");

                txtStatus.AppendText(Environment.NewLine + "Joining .mp4 video file with .m4s audio file...");
                var pathVideoFineshed = await mfsHandler.JoinFiles(pathVideo, Path.Combine(_selectedFolder, audioFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Audio)}.m4s"), _selectedFolder);
                txtStatus.AppendText(Environment.NewLine + "Joining finished");

                txtStatus.AppendText(Environment.NewLine + "Deleting temporary files...");
                mfsHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, audioFolderName));
                mfsHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, videoFolderName));
                txtStatus.AppendText(Environment.NewLine + "Temporary files deleted");

                txtStatus.AppendText(Environment.NewLine + $"Your video is ready :D   >> {pathVideoFineshed}");
                MessageBox.Show($"{pathVideoFineshed}", "Your video is ready :D", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableControls();
                InvisibleProcessing();
                

            }
            catch (Exception ex)
            {
                txtStatus.AppendText(Environment.NewLine + $"Ops...Something went wrong :(   >> {ex.Message}");
                MessageBox.Show($"{ex.Message}", "Ops...Something went wrong :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableControls();
                InvisibleProcessing();
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
            EnableButtonCancel();
        }

        private void EnableControls()
        {
            txtLastAudioUri.Enabled = true;
            txtLastVideoUri.Enabled = true;
            DisableButtonCancel();
        }

        private void VisibleProcessing()
        {
            lblProccesing.Visible = true;
            picImageProcessing.Visible = true;
        }

        private void InvisibleProcessing()
        {
            lblProccesing.Visible = false;
            picImageProcessing.Visible = false;
        }

        private void EnableButtonCancel()
        {
            btnCancel.Enabled = true;
            btnProcess.Enabled = false;
            btnCleanAll.Enabled = false;
        }

        private void DisableButtonCancel()
        {
            btnCancel.Enabled = false;
            btnProcess.Enabled = true;
            btnCleanAll.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            txtLastAudioUri.Text = "";
            txtLastVideoUri.Text = "";
            txtStatus.Text = "";
        }
    }


}
