using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFourS.Classes;
using MFourS.Enumerables;

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
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            var audioFolderName = Guid.NewGuid().ToString();
            var videoFolderName = Guid.NewGuid().ToString();
            var urlAudio = txtLastAudioUri.Text;
            var urlVideo = txtLastVideoUri.Text;

            try
            {
                btnProcess.Enabled = false;

                if (String.IsNullOrEmpty(_selectedFolder))
                    throw new Exception("Select a folder to save the file");

                MFourSHandler mfsHandler = new MFourSHandler(urlAudio, urlVideo);
                mfsHandler.CreateTemporaryFolder(_selectedFolder, audioFolderName);
                mfsHandler.CreateTemporaryFolder(_selectedFolder, videoFolderName);

                DownloadManager downloadManager = new DownloadManager();
                await downloadManager.StartDownloadAsync(mfsHandler.urisAudio, $@"{_selectedFolder}\{audioFolderName}", FileTypeEnum.Audio);
                await downloadManager.StartDownloadAsync(mfsHandler.urisVideo, $@"{_selectedFolder}\{videoFolderName}", FileTypeEnum.Video);

                btnProcess.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ops...Something went wrong :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnProcess.Enabled = true;
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

    }


}
