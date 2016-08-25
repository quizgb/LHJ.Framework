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

            if (!string.IsNullOrEmpty(Properties.Settings.Default.LocalDownPath))
            {
                this.tbxDownloadPath.Text = Properties.Settings.Default.LocalDownPath;
            }
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

        private bool CheckLocalPath()
        {
            if (!Directory.Exists(this.tbxDownloadPath.Text))
            {
                this.tbxDownloadPath.Focus();
                MessageBox.Show(this, "올바른 폴더경로를 입력하세요.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Tuple<bool, string> ValidateLink()
        {
            //Contains the normalized URL
            string normalUrl;
            Tuple<bool, string> tuple = null;

            //Checks that a valid folder is entered to store downloaded files
            if (!Directory.Exists(this.tbxDownloadPath.Text))
            {
                if (!this.CheckLocalPath())
                {
                    tuple = Tuple.Create(false, "");
                }
            }
            //Checks that URL entered corresponds to a valid Youtube video
            else if (!(DownloadUrlResolver.TryNormalizeYoutubeUrl(this.tbxYoutubeUrl.Text, out normalUrl)))
            {
                this.tbxYoutubeUrl.Focus();
                MessageBox.Show(this, "올바른 Youtube URL을 입력하세요.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tuple = Tuple.Create(false, "");
            }
            else
            {
                tuple = Tuple.Create(true, normalUrl);
            }

            return tuple;
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

        private void CreateVideoOrAudioObject(string aLink)
        {
            this.Cursor = Cursors.WaitCursor;   

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

                UpdateDownloadList(videoDownloader, aLink);
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

                UpdateDownloadList(audioDownloader, aLink);
            }

            this.Cursor = Cursors.Default;
        }

        private void UpdateDownloadList(YoutubeModel aModel, string aLink)
        {
            ucDownloadInfoBox downInfoBox = new ucDownloadInfoBox();
            downInfoBox.Width = this.flpDownloadList.Width - 20;
            downInfoBox.SetDownloadInfo(aModel, aLink);
            this.flpDownloadList.Controls.Add(downInfoBox);

            //Add item to download to the beginning of the list
            //If you use Add it adds to the end of the list
            this.m_DownloadList.Insert(0, aModel);

            //Reset the textbox where the link was typed in
            this.tbxYoutubeUrl.Text = string.Empty;
        }

        private void SetFavoriteLocalDownPath()
        {
            if (!this.CheckLocalPath())
            {
                return;
            }

            if (MessageBox.Show(this, "입렧하신 다운로드 폴더경로를\r\n기본 다운로드 경로로 지정하시겠습니까?", ConstValue.MSGBOX_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                Properties.Settings.Default.LocalDownPath = this.tbxDownloadPath.Text;
            }
        }

        private bool CheckExistDownloadList()
        {
            int count = 0;
            int checkCnt = 0;

            Control.ControlCollection ctrlColl = this.flpDownloadList.Controls;

            foreach (Control ctrl in ctrlColl)
            {
                if (ctrl.GetType().Equals(typeof(ucDownloadInfoBox)))
                {
                    count++;

                    ucDownloadInfoBox downInfoBox = ctrl as ucDownloadInfoBox;

                    if (downInfoBox.GetCheckState())
                    {
                        checkCnt++;
                    }
                }
            }

            if (count < 1)
            {
                MessageBox.Show(this, "리스트에 추가된 동영상이 존재하지 않습니다.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (checkCnt < 1)
            {
                MessageBox.Show(this, "리스트에 체크된 동영상이 존재하지 않습니다.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion 6.Method


        #region 7.Event
        private void btnAddDownloadList_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnAddDownloadList))
                {
                    var isGoodLink = this.ValidateLink();

                    if (isGoodLink.Item1 == true)
                    {
                        this.CreateVideoOrAudioObject(isGoodLink.Item2);
                    }
                }
                else if (btn.Equals(this.btnFavoriteLocalDownPath))
                {
                    this.SetFavoriteLocalDownPath();
                }
                else if (btn.Equals(this.btnDownloadPath))
                { 
                    
                }
                else if (btn.Equals(this.btnDelDownloadList))
                {
                    if (!this.CheckExistDownloadList())
                    {
                        return;
                    }
                }
                else if (btn.Equals(this.btnDownload))
                { 
                    
                }
            }
        }

        private void flpDownloadList_MouseEnter(object sender, EventArgs e)
        {
            this.flpDownloadList.Focus();
        }

        private void cbxCheckAllDownloadList_CheckedChanged(object sender, EventArgs e)
        {
            Control.ControlCollection ctrlColl = this.flpDownloadList.Controls;

            foreach (Control ctrl in ctrlColl)
            {
                if (ctrl.GetType().Equals(typeof(ucDownloadInfoBox)))
                {
                    ucDownloadInfoBox downInfoBox = ctrl as ucDownloadInfoBox;

                    if (this.cbxCheckAllDownloadList.Checked)
                    {
                        downInfoBox.SetCheck();
                    }
                    else
                    {
                        downInfoBox.SetUnCheck();
                    }
                }
            }
        }
        #endregion 7.Event
    }
}
