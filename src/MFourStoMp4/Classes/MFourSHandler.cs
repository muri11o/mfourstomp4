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
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFourS.Classes
{
    public class MFourSHandler
    {
        private readonly string _lastAudioUri;
        private readonly string _lastVideoUri;
        public Stack<DownloadFile> urisAudio { get; set; }
        public Stack<DownloadFile> urisVideo { get; set; }
        public MFourSHandler(string audio, string video)
        {
            _lastAudioUri = audio;
            _lastVideoUri = video;
            urisAudio = new Stack<DownloadFile>();
            urisVideo = new Stack<DownloadFile>();

            FillUriStackForDownload();
        }

        private void FillUriStackForDownload()
        {
            if (!new FileInfo(Path.Combine(AppContext.BaseDirectory, "ffmpeg.exe")).Exists)
                throw new Exception("ffmpeg.exe file not found");

            int numberSegmentAudio = GetNumberSegment(_lastAudioUri);
            int numberSegmentVideo = GetNumberSegment(_lastVideoUri);

            if (numberSegmentAudio == -1 || numberSegmentVideo == -1)
                throw new Exception("The maximum number of segments must be between # and #. Example: example-segment-#10#.m4s");

            urisAudio = CreateUris(_lastAudioUri, numberSegmentAudio);
            urisVideo = CreateUris(_lastVideoUri, numberSegmentVideo);

        }

        private int GetNumberSegment(string str)
        {
            string _str = str;

            if (String.IsNullOrEmpty(_str))
                return -1;

            var match = Regex.Match(_str, @"[#][0-9]+[#]");

            var subStr = match.Groups[0].ToString();

            if (String.IsNullOrEmpty(subStr))
                return -1;

            bool result = int.TryParse(subStr.Substring(1, subStr.Length - 2), out int number);

            if (result)
                return number;
            else
                return -1;

        }

        private Stack<DownloadFile> CreateUris(string str, int numberSegment)
        {
            int cont = numberSegment;
            string _str = str;

            Stack<DownloadFile> uris = new Stack<DownloadFile>();

            while (cont >= 0)
            {
                string result = _str.Replace($"#{numberSegment}#", $"{cont}");
                uris.Push(new DownloadFile(result, cont.ToString()));
                cont--;
            }

            return uris;
        }

        public void CreateTemporaryFolder(string directory, string folderName)
        {
            string path = Path.Combine(directory, folderName);

            if (Directory.Exists(path))
                return;

            Directory.CreateDirectory(path);
        }

        public async Task ConcatenateFiles(string path, FileTypeEnum fileType)
        {
            var files = GetFiles(path);
            var orderedFiles = OrderFiles(files, path);
            var filebat = CreateAndWriteBatFile(orderedFiles, path, fileType);
            await ExecuteBatFile(filebat);

            if (Directory.Exists($"{Path.Combine(path, $"{Enum.GetName(typeof(FileTypeEnum), fileType)}.m4s")}"))
                throw new Exception($"File not found: {Path.Combine(path, $"{Enum.GetName(typeof(FileTypeEnum), fileType)}.m4s")}");

            if (new FileInfo($"{Path.Combine(path, $"{Enum.GetName(typeof(FileTypeEnum), fileType)}.m4s")}").Length <= 0)
                throw new Exception("The downloaded file is invalid");
        }

        public string[] GetFiles(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            List<string> listFileTemporary = new List<string>();

            for (int i = 0; i < allFiles.Length; i++)
            {
                if (allFiles[i].Contains("_mfourstomp4_"))
                    listFileTemporary.Add(allFiles[i]);
            }

            var files = new string[listFileTemporary.Count];

            for (int i = 0; i < listFileTemporary.Count; i++)
            {
                files[i] = listFileTemporary[i];
            }

            return files;
        }

        private string[] OrderFiles(string[] files, string path)
        {
            var _files = files;
            var orderedFiles = new string[_files.Length];

            foreach (var file in _files)
            {
                var nameFile = Regex.Match(file, @"[_mfourstomp4_][\w]+[.]").Groups[0].ToString();
                nameFile = nameFile.Substring(1, nameFile.Length - 2);

                var vNameFile = nameFile.Split('_');

                if (!int.TryParse(vNameFile[2], out int index))
                    throw new Exception("Error");

                orderedFiles[index] = Path.Combine(path, $"_{vNameFile[0]}_{vNameFile[1]}_{vNameFile[2]}.m4s");
            }

            return orderedFiles;
        }

        private string CreateAndWriteBatFile(string[] files, string path, FileTypeEnum fileType)
        {
            string fileBat = Path.Combine(path, $"{Enum.GetName(typeof(FileTypeEnum), fileType)}.bat");
            File.Create(fileBat).Dispose();

            using (StreamWriter sw = new StreamWriter(fileBat))
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (i == 0)
                        sw.WriteLine($"type {files[i]} > {Path.Combine(path, $"{Enum.GetName(typeof(FileTypeEnum), fileType)}.m4s")}");
                    else
                        sw.WriteLine($"type {files[i]} >> {Path.Combine(path, $"{Enum.GetName(typeof(FileTypeEnum), fileType)}.m4s")}");
                }
            }

            return fileBat;
        }

        private async Task ExecuteBatFile(string path)
        {
            await Task.Run(() =>
            {
                var startInfo = new ProcessStartInfo("cmd.exe", "/c " + path);
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = true;

                using (var process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();
                }
            });
        }

        public async Task<string> ConvertAndJoinFiles(string pathVideo, string pathAudio, string folder)
        {
            var pathVideoFineshed = Path.Combine(folder, $"{Guid.NewGuid()}.mp4");

            await Task.Run(() =>
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(AppContext.BaseDirectory, "ffmpeg.exe"),
                    Arguments = $"-y -i \"{pathVideo}\" -i \"{pathAudio}\" \"{pathVideoFineshed}\"",
                    WorkingDirectory = AppContext.BaseDirectory,
                    CreateNoWindow = true,
                    UseShellExecute = true
                };

                using (var process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();
                }
            });

            return pathVideoFineshed;
        }

        public static void DeleteTemporaryFolder(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }
    }
}
