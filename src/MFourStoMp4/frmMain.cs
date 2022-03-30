/*********************************************************************
 * This project was built by Murillo F. S. Freitas and it is available 
 * for use in https://github.com/muri11o/mfourstomp4
 *
 * Please, don't remove this comment
 *
 * 18/11/2021
 ********************************************************************/

using MFourS.Classes;
using MFourS.Enumerables;
using MFourStoMp4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MFourS
{
    public partial class frmMain : Form
    {
        private string _selectedFolder;
        private List<DownloadFileList> _listDownload;

        public frmMain()
        {
            InitializeComponent();
            _selectedFolder = "";
            lblSelectSaveTo.Text = "select folder";
            NotProcessing();
            chkDeleteTemporaryFiles.Checked = true;
            _listDownload = new List<DownloadFileList>();
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
                var pathVideoFineshed = await mfsHandler.ConvertAndJoinFiles(Path.Combine(_selectedFolder, videoFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Video)}.m4s"), Path.Combine(_selectedFolder, audioFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Audio)}.m4s"), _selectedFolder, txtNameVideo.Text);
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
                txtNameVideo.Text = "";

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
            txtNameVideo.Enabled = false;
            EnableButtons();
        }

        private void EnableControls()
        {
            txtLastAudioUri.Enabled = true;
            txtLastVideoUri.Enabled = true;
            txtNameVideo.Enabled = true;
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
            btnProcessList.Enabled = false;
            btnLoadList.Enabled = false;
        }

        private void DisableButtons()
        {
            btnProcess.Enabled = true;
            btnCleanAll.Enabled = true;
            btnProcessList.Enabled = true;
            btnLoadList.Enabled = true;
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            txtLastAudioUri.Text = "";
            txtLastVideoUri.Text = "";
            txtStatus.Text = "";
            txtNameVideo.Text = "";
            lblNumbr.Text = "Number:";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var myForm = new frmAbout();
            myForm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private async void btnProcessList_Click(object sender, EventArgs e)
        {
            foreach (var item in _listDownload)
            {
                var audioFolderName = Guid.NewGuid().ToString();
                var videoFolderName = Guid.NewGuid().ToString();
                var urlAudio = item.UrlAudio;
                var urlVideo = item.UrlVideo;

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
                    var pathVideoFineshed = await mfsHandler.ConvertAndJoinFiles(Path.Combine(_selectedFolder, videoFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Video)}.m4s"), Path.Combine(_selectedFolder, audioFolderName, $"{Enum.GetName(typeof(FileTypeEnum), FileTypeEnum.Audio)}.m4s"), _selectedFolder, item.NameVideo);
                    txtStatus.AppendText(Environment.NewLine + "Converting and Joining finished");

                    if (chkDeleteTemporaryFiles.Checked)
                    {
                        txtStatus.AppendText(Environment.NewLine + "Deleting temporary files...");
                        MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, audioFolderName));
                        MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, videoFolderName));
                        txtStatus.AppendText(Environment.NewLine + "Temporary files deleted");
                    }

                    txtStatus.AppendText(Environment.NewLine + $"Your video is ready :D   >> {pathVideoFineshed}");
                    
                }
                catch (Exception ex)
                {
                    txtStatus.AppendText(Environment.NewLine + $"Ops...Something went wrong :(   >> {ex.Message}");
                    MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, audioFolderName));
                    MFourSHandler.DeleteTemporaryFolder(Path.Combine(_selectedFolder, videoFolderName));
                }   
            }

            MessageBox.Show($"Download your videos are finished", "Yours videos are ready :D", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNameVideo.Text = "";
            _listDownload = new List<DownloadFileList>();
            lblNumbr.Text = "Number:";

            EnableControls();
            NotProcessing();
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text | *.txt";
            ofd.ShowDialog();

            var pathFile = ofd.FileName;

            try
            {
                 _listDownload = MFourSHandler.LoadList(pathFile);

                if (_listDownload == null || _listDownload.Count == 0)
                {
                    _listDownload = new List<DownloadFileList>();

                    MessageBox.Show($"List invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lblNumbr.Text = $"Number: {_listDownload.Count}";
                }
            }
            catch
            {
                _listDownload = new List<DownloadFileList>();
                MessageBox.Show($"List invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }


}
