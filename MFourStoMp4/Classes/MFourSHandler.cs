using MFourS.Enumerables;
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
        public Stack<DownloadFile> urisVideo{ get; set; } 
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

            var match = Regex.Match(_str, "[#][0-9]+[#]");

            var subStr = match.Groups[0].ToString();

            if (String.IsNullOrEmpty(subStr))
                return 0;

            bool result = int.TryParse(subStr.Substring(1, subStr.Length-2), out int number);

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

        public void ConcatenateFiles(string directory)
        {
            var _path = directory;
            string[] files = Directory.GetFiles(_path);
        }
    }
}
