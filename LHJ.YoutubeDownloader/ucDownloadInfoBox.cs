using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace LHJ.YoutubeDownloader
{
    public partial class ucDownloadInfoBox : UserControl
    {
        public ucDownloadInfoBox()
        {
            InitializeComponent();
        }

        public void SetDownloadInfo(YoutubeModel aYoutubeModel, string aLink)
        {
            this.lblTitle.Text = aYoutubeModel.Video.Title;
            string youtubeCode = aLink.Substring(aLink.Length - 11, 11);

            string imageLink1 = "http://img.youtube.com/vi/" + youtubeCode + "/1.jpg";

            using (var client = new WebClient())
            {
                client.DownloadFile(imageLink1, "1.jpg");
            }

            this.pbxPreview.ImageLocation = "1.jpg";
        }

        private void cbxDownload_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxDownload.Checked)
            {
                this.lblTitle.Font = new Font("굴림", 9, FontStyle.Bold);
            }
            else
            {
                this.lblTitle.Font = new Font("굴림", 9);
            }
        }

        private void ucDownloadInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.cbxDownload.Checked)
            {
                this.cbxDownload.Checked = false;
            }
            else
            {
                this.cbxDownload.Checked = true;
            }
        }
    }
}
