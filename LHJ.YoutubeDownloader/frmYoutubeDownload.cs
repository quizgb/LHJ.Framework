using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LHJ.Common.Definition;

using YoutubeExtractor;

namespace LHJ.YoutubeDownloader
{
    public partial class frmYoutubeDownload : Form
    {
        #region 1.Variable
        List<YoutubeModel> m_DownloadList = new List<YoutubeModel>();
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmYoutubeDownload()
        {
            InitializeComponent();

            this.SetInitialize();
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
            this.Icon = Properties.Resources._1472122004_youtube;
            this.tbxDownloadPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.cboDownloadType.DisplayMember = "CODE_NAME";
            this.cboDownloadType.ValueMember = "CODE";
            this.cboDownloadType.DataSource = this.YoutubeDownloader_DownloadType();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private DataTable YoutubeDownloader_DownloadType()
        {
            DataTable dtType = new DataTable();

            dtType.Columns.Add("CODE");
            dtType.Columns.Add("CODE_NAME");

            DataRow dr = dtType.NewRow();

            dr["CODE"] = (int)LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.Video;
            dr["CODE_NAME"] = LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType_DISPLAY.VIDEO;

            dtType.Rows.Add(dr);

            dr = dtType.NewRow();

            dr["CODE"] = (int)LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.MP3;
            dr["CODE_NAME"] = LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType_DISPLAY.MP3;

            dtType.Rows.Add(dr);

            return dtType;
        }

        private Tuple<bool, string> ValidateLink()
        {
            //Contains the normalized URL
            string normalUrl;

            //Checks that a valid folder is entered to store downloaded files
            if (!Directory.Exists(this.tbxDownloadPath.Text))
            {
                this.tbxDownloadPath.Focus();
                MessageBox.Show("올바른 폴더경로를 입력하세요.");
                return Tuple.Create(false, "");
            }
            //Checks that URL entered corresponds to a valid Youtube video
            else if (!(DownloadUrlResolver.TryNormalizeYoutubeUrl(this.tbxYoutubeUrl.Text, out normalUrl)))
            {
                this.tbxYoutubeUrl.Focus();
                MessageBox.Show("올바른 Youtube URL을 입력하세요.");
                return Tuple.Create(false, "");
            }
            else
            {
                return Tuple.Create(true, normalUrl);
            }
        }

        private LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType GetDownloadType()
        {
            LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType downType = 0;

            if (this.cboDownloadType.InvokeRequired)
            {
                this.cboDownloadType.Invoke(new MethodInvoker(delegate()
                {
                    if (Convert.ToInt32(this.cboDownloadType.SelectedValue).Equals(Convert.ToInt32(LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.Video)))
                    {
                        downType = LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.Video;
                    }
                    else
                    {
                        downType = LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.MP3;
                    }
                }));
            }
            else
            {
                if (Convert.ToInt32(this.cboDownloadType.SelectedValue).Equals(Convert.ToInt32(LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.Video)))
                {
                    downType = LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.Video;
                }
                else
                {
                    downType = LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.MP3;
                }
            }

            return downType;
        }

        private void CreateVideoOrAudioObject()
        {
            if (this.GetDownloadType().Equals(LHJ.Common.Definition.ConstValue.YoutubeDownloaderDownloadType.Video))
            {
                //Create new videoDownloader object
                YoutubeVideoModel videoDownloader = new YoutubeVideoModel();

                //Set videoDownloader properties
                videoDownloader.Link = this.tbxYoutubeUrl.Text;
                videoDownloader.FolderPath = this.tbxDownloadPath.Text;

                //Store VideoInfo object in model
                videoDownloader.VideoInfo = FileDownloader.GetVideoInfos(videoDownloader);

                //Stores VideoInfo object in model
                videoDownloader.Video = FileDownloader.GetVideoInfo(videoDownloader);

                UpdateDownloadList(videoDownloader);
            }
            //Create audio object
            else
            {
                //Create new audioDownloader object
                YoutubeAudioModel audioDownloader = new YoutubeAudioModel();

                //Set AudioDownloader properties
                audioDownloader.Link = this.tbxYoutubeUrl.Text;
                audioDownloader.FolderPath = this.tbxDownloadPath.Text;

                //Store VideoInfo object in model
                audioDownloader.VideoInfo = FileDownloader.GetVideoInfos(audioDownloader);

                //Stores VideoInfo object in model
                audioDownloader.Video = FileDownloader.GetVideoInfoAudioOnly(audioDownloader);

                UpdateDownloadList(audioDownloader);
            }
        }

        private void UpdateDownloadList(YoutubeModel model)
        {
            UserControl1 ctrl = new UserControl1();
            ctrl.Width = this.flpDownloadList.Width - 20;
            this.flpDownloadList.Controls.Add(ctrl);

            //Add item to download to the beginning of the list
            //If you use Add it adds to the end of the list
            this.m_DownloadList.Insert(0, model);

            //Reset the textbox where the link was typed in
            this.tbxYoutubeUrl.Text = "";
        }
        #endregion 6.Method


        #region 7.Event
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker bg = new BackgroundWorker();
            var isGoodLink = this.ValidateLink();

            bg.DoWork += (s, args) =>
            {
                if (isGoodLink.Item1 == true)
                {
                    CreateVideoOrAudioObject();
                }
            };

            bg.RunWorkerAsync();
        }

        private void flpDownloadList_MouseEnter(object sender, EventArgs e)
        {
            this.flpDownloadList.Focus();
        }
        #endregion 7.Event
    }
}
