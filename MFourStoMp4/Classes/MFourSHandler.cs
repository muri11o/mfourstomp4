﻿using MFourS.Enumerables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            int numberOfSegmentAudio = GetNumberOfSegment(_lastAudioUri);
            int numberOfSegmentVideo = GetNumberOfSegment(_lastVideoUri);

            if (numberOfSegmentAudio == 0 || numberOfSegmentVideo == 0)
                throw new Exception("Invalid uris");

            urisAudio = CreateUris(_lastAudioUri, numberOfSegmentAudio);
            urisVideo = CreateUris(_lastVideoUri, numberOfSegmentVideo);

        }

        private int GetNumberOfSegment(string str)
        {
            string _str = str;

            if (String.IsNullOrEmpty(_str))
                return 0;

            var match = Regex.Match(_str, @"[#][0-9]+[#]");

            var subStr = match.Groups[0].ToString();

            if (String.IsNullOrEmpty(subStr))
                return 0;

            bool result = int.TryParse(subStr.Substring(1, subStr.Length - 2), out int number);

            if (result)
                return number;
            else
                return 0;

        }

        private Stack<DownloadFile> CreateUris(string str, int numberSegment)
        {
            int cont = numberSegment;
            string _str = str;

            Stack<DownloadFile> uris = new Stack<DownloadFile>();

            while (cont > 0)
            {
                string result = _str.Replace($"#{numberSegment}#", $"{cont}");
                uris.Push(new DownloadFile(result, cont.ToString()));
                cont--;
            }

            return uris;
        }

        public void CreateTemporaryFolder(string directory, string folderName)
        {
            string path = $@"{directory}\{folderName}";

            if (Directory.Exists(path))
                return;

            Directory.CreateDirectory(path);
        }

        public void ConcatenateFiles(string path, FileTypeEnum fileType)
        {

            var files = GetFiles(path);
            var orderedFiles = OrderFiles(files, path);
            var filebat = CreateAndWriteBatFile(orderedFiles, path, fileType);
            ExecuteBatFile(filebat);
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

                orderedFiles[index - 1] = Path.Combine(path, $"_{vNameFile[0]}_{vNameFile[1]}_{vNameFile[2]}.m4s");
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

        private void ExecuteBatFile(string path)
        {
            System.Diagnostics.Process.Start(path);
        }
    }
}
