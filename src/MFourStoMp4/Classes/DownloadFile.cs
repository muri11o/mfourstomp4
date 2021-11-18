/*********************************************************************
 * This project was built by Murillo F. S. Freitas and it is available 
 * for use in https://github.com/muri11o/mfourstomp4
 *
 * Please, don't remove this comment
 *
 * 18/11/2021
 ********************************************************************/

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
