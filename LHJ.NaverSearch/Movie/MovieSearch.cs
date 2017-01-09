using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverSearch.Movie
{
    public partial class MovieSearch : Form, IBookSearch
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public MovieSearch()
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
            this.Icon = Properties.Resources._1483694295_video;
            this.SetFocusTitle();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        public bool CheckBeforeSearch()
        {
            if (string.IsNullOrEmpty(this.tbxMovieTitle.Text))
            {
                this.tbxMovieTitle.Focus();
                MessageBox.Show("영화 제목을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public void SetFocusTitle()
        {
            this.tbxMovieTitle.Focus();
        }

        public void Search(bool aNewSearchState)
        {
            if (!this.CheckBeforeSearch())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ClearSearchBefore(aNewSearchState);

                string subUrl = string.Format("query={0}&display=10&start={1}", this.tbxMovieTitle.Text, (this.ucPaging.CurPage.Equals(1) ? 1 : ((this.ucPaging.CurPage - 1) * 10) + 1));
                string url = "https://openapi.naver.com/v1/search/movie.json?" + subUrl;
                string text = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("X-Naver-Client-Id", Definition.ConstValue.ConstValue.NaverClintInfo.ID);
                request.Headers.Add("X-Naver-Client-Secret", Definition.ConstValue.ConstValue.NaverClintInfo.PASS);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    string status = response.StatusCode.ToString();

                    if (status == "OK")
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                text = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("에러 발생! {0}", status), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MovieSearchRslt msr = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieSearchRslt>(text);

                if (msr.total < 1)
                {
                    MessageBox.Show("검색결과가 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.CreateSearchRsltCtrl(msr);
                this.SetPageing(msr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void ClearSearchBefore(bool aNewSearchState)
        {
            this.ucPaging.Clear(aNewSearchState);
            this.lblSearchRslt.Visible = false;
            this.lblSearchRsltIdx.Visible = false;
            this.flpSearchRslt.Controls.Clear();
        }

        private void SetPageing(MovieSearchRslt aMsr)
        {
            if (aMsr.total < 1)
            {
                this.ucPaging.Visible = false;
            }
            else
            {
                this.ucPaging.Visible = true;
                this.ucPaging.Setting(aMsr.total);
            }
        }

        private void CreateSearchRsltCtrl(MovieSearchRslt aMsr)
        {
            if (aMsr != null)
            {
                this.SetSearchRsltInfo(aMsr.start, aMsr.display, aMsr.total);

                foreach (MovieItem itm in aMsr.items)
                {
                    MovieControl mc = new MovieControl();

                    mc.Width = this.flpSearchRslt.Width - 25;
                    mc.SetValue(itm);

                    this.flpSearchRslt.Controls.Add(mc);
                }
            }
        }

        public void SetSearchRsltInfo(int aStart, int aDisplay, int aTotal)
        {
            this.lblSearchRslt.Visible = true;
            this.lblSearchRsltIdx.Visible = true;

            this.lblSearchRsltIdx.Text = string.Format("({0}-{1} / {2} 건)",
                                                       aStart.ToString(),
                                                       this.ucPaging.CurPage.Equals(this.ucPaging.TotalPageCount) ? aTotal > 100 ? "1000" : aTotal.ToString() : (this.ucPaging.CurPage * aDisplay).ToString(),
                                                       aTotal.ToString());
        }

        public void ResizeSearchRsltCtrl()
        {
            if (this.flpSearchRslt.Controls.Count > 0)
            {
                foreach (Control ctrl in this.flpSearchRslt.Controls)
                {
                    if (ctrl.GetType().Equals(typeof(MovieControl)))
                    {
                        MovieControl mc = ctrl as MovieControl;
                        mc.Width = this.flpSearchRslt.Width - 25;
                    }
                }
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search(true);
        }

        private void tbxMovieTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }

        private void MovieSearch_Shown(object sender, EventArgs e)
        {
            this.SetInitialize();
        }

        private void MovieSearch_Resize(object sender, EventArgs e)
        {
            this.ResizeSearchRsltCtrl();
        }

        private void flpSearchRslt_MouseEnter(object sender, EventArgs e)
        {
            this.flpSearchRslt.Focus();
        }

        private void ucPaging_PageChanged(object sender, ucPaging.PageChangedArgs e)
        {
            this.Search(false);
        }
        #endregion 7.Event
    }
}
