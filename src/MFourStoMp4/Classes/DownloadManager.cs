/*********************************************************************
 * This project was built by Murillo F. S. Freitas and it is available 
 * for use in https://github.com/muri11o/mfourstomp4
 *
 * Please, don't remove this comment
 *
 * 18/11/2021
 ********************************************************************/

using MFourS.Enumerables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MFourS.Classes
{
    public class DownloadManager
    {
        private int _maxNumberDownloads { get; set; }

        public DownloadManager()
        {
            _maxNumberDownloads = 6;
        }
        public DownloadManager(int maxNumberDownloads)
        {
            if (maxNumberDownloads < 1 || maxNumberDownloads > 6)
                throw new Exception("The maximum number of simultaneous downloads must be between 1 and 6");

            _maxNumberDownloads = maxNumberDownloads;
        }

        public async Task StartDownloadAsync(Stack<DownloadFile> downloadFileStack, string directory, FileTypeEnum fileType)
        {
            var _downloadFileStack = downloadFileStack;

            if (_downloadFileStack.Count == 0)
                throw new Exception("Download stack is empty");

            if (_downloadFileStack.Count <= _maxNumberDownloads)
                _maxNumberDownloads = _downloadFileStack.Count;

            List<Task> uriDownloadTasks= new List<Task>(_maxNumberDownloads);    

            for (int i = 1; i <= _maxNumberDownloads; i++ )
            {
                var downloadTask = DownloadAsync(_downloadFileStack.Pop(), directory, fileType);
                uriDownloadTasks.Add(downloadTask);
            }

            while (uriDownloadTasks.Count > 0)
            {
                Task downloadTaskFinished = await Task.WhenAny(uriDownloadTasks);

                if (_downloadFileStack.Count > 0)
                {
                    var downloadTask = DownloadAsync(_downloadFileStack.Pop(), directory, fileType);
                    uriDownloadTasks.Add(downloadTask);
                }

                uriDownloadTasks.Remove(downloadTaskFinished);
            }

        }

        private async Task DownloadAsync(DownloadFile downloadFile, string directory, FileTypeEnum fileType)
        {
            using (var client = new WebClient())
            {
                var nameFile = $"_mfourstomp4_{Enum.GetName(typeof(FileTypeEnum), fileType) }_{ downloadFile.Segment}";
                var pathFile = Path.Combine(directory, $"{nameFile}.m4s");
                await client.DownloadFileTaskAsync(downloadFile.Uri, pathFile);
            }
        }
    }
}
