namespace MFourS.Classes
{
    public class DownloadFile
    {
        public string Uri { get; set; }
        public string Segment { get; set; }

        public DownloadFile(string Uri, string Segment)
        {
            this.Uri = Uri;
            this.Segment = Segment;
        }
    }
}
