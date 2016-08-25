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
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ucDownloadInfoBox()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method
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

        public bool GetCheckState()
        {
            if (this.cbxDownload.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetCheck()
        {
            this.cbxDownload.Checked = true;
        }

        public void SetUnCheck()
        {
            this.cbxDownload.Checked = false;
        }
        #endregion 6.Method


        #region 7.Event
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
        #endregion 7.Event
    }
}
