/*********************************************************************
 * This project was built by Murillo F. S. Freitas and it is available 
 * for use in https://github.com/muri11o/mfourstomp4
 *
 * Please, don't remove this comment
 *
 * 18/11/2021
 ********************************************************************/

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
