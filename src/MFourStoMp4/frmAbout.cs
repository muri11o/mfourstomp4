using System;
using System.IO;
using System.Windows.Forms;

namespace MFourStoMp4
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            picImageAbout.LoadAsync(Path.Combine(AppContext.BaseDirectory, "images", "ico1.png"));
        }
    }
}
