using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverSearch
{
    public partial class ucPaging : UserControl
    {
        public class PageChangedArgs : EventArgs
        {
            public int Page = 0;

            public PageChangedArgs(int aPage)
            {
                this.Page = aPage;
            }
        }

        #region 1.Variable
        public delegate void PageChangedEventHandler(object sender, PageChangedArgs e);

        [Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("페이지가 변경되면 발생합니다.")]
        public event PageChangedEventHandler PageChanged;

        private int mTotalItmCount = 0;
        private int mItemsPerPage = 10;
        private int mCurPage = 1;
        #endregion 1.Variable


        #region 2.Property
        public int TotalItmCount
        {
            get { return this.mTotalItmCount; }
            set { this.mTotalItmCount = value; }
        }

        public int TotalPageCount
        {
            get { return this.GetTotalPageCount(); }
        }

        public int CurPage
        {
            get { return this.mCurPage.Equals(0) ? 1 : this.mCurPage; }
        }
        #endregion 2.Property


        #region 3.Constructor
        public ucPaging()
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
        private int GetTotalPageCount()
        {
            int cnt = this.mTotalItmCount / this.mItemsPerPage + ((this.TotalItmCount % this.mItemsPerPage) == 0 ? 0 : 1);

            if (cnt > 100)
            {
                cnt = 100;
            }

            return cnt;
        }
        
        public void Clear(bool aNewSearchState)
        {
            this.flpPage.Controls.Clear();
            this.Width = 117;

            this.btnHome.Enabled = false;
            this.btnPrev.Enabled = false;

            this.btnEnd.Enabled = false;
            this.btnNext.Enabled = false;

            if (aNewSearchState)
            {
                this.mCurPage = 1;
            }
        }

        private void SetBtnEnabled()
        {
            if (CurPage.Equals(1))
            {
                if (TotalPageCount.Equals(1))
                {
                    this.btnHome.Enabled = false;
                    this.btnPrev.Enabled = false;

                    this.btnEnd.Enabled = false;
                    this.btnNext.Enabled = false;
                }
                else
                {
                    this.btnHome.Enabled = false;
                    this.btnPrev.Enabled = false;

                    this.btnEnd.Enabled = true;
                    this.btnNext.Enabled = true;
                }
            }
            else if (CurPage.Equals(TotalPageCount))
            {
                this.btnHome.Enabled = true;
                this.btnPrev.Enabled = true;

                this.btnEnd.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                this.btnHome.Enabled = true;
                this.btnPrev.Enabled = true;

                this.btnEnd.Enabled = true;
                this.btnNext.Enabled = true;
            }
        }

        private void SetPageChanged(int aPage)
        {
            this.mCurPage = aPage;
            this.SetBtnEnabled();

            if (PageChanged != null)
            {
                PageChangedArgs e = new PageChangedArgs(aPage);
                PageChanged(this, e);
            }
        }

        public void Setting(int aTotCount)
        {
            this.mTotalItmCount = aTotCount;
            int maxCnt = 0;
            int startCnt = 0;

            if (CurPage > 5 && CurPage + 4 < TotalPageCount)
            {
                maxCnt = CurPage + 4;
                startCnt = CurPage - 6;
            }
            else if (CurPage + 4 >= TotalPageCount && TotalPageCount > 10)
            {
                maxCnt = TotalPageCount;
                startCnt = TotalPageCount - 10;
            }
            else
            {
                if (TotalPageCount > 10)
                {
                    maxCnt = 10;
                    startCnt = 0;
                }
                else
                {
                    maxCnt = TotalPageCount;
                    startCnt = 0;
                }
            }

            for (int cnt = startCnt; cnt < maxCnt; cnt++)
            {
                LinkLabel lbl = new LinkLabel();
                lbl.LinkClicked += this.lnklbl_LinkClicked;
                lbl.AutoSize = true;
                lbl.Text = (cnt + 1).ToString();
                lbl.Dock = DockStyle.Left;
                lbl.Visible = true;

                if ((cnt + 1).Equals(this.mCurPage))
                {
                    lbl.Font = new Font("맑은 고딕", 10f, FontStyle.Bold);
                }
                else
                {
                    lbl.Font = new Font("맑은 고딕", 9.5f, FontStyle.Regular);
                }

                if (lbl.Width > lbl.PreferredWidth)
                {
                    lbl.Width = lbl.PreferredWidth;
                }

                this.Width += lbl.Width + 6;

                if ((cnt + 1) <= TotalPageCount)
                {
                    this.flpPage.Controls.Add(lbl);
                }
            }

            this.SetBtnEnabled();
        }
        #endregion 6.Method


        #region 7.Event
        private void lnklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnklbl = sender as LinkLabel;

            if (lnklbl != null)
            {
                int page = 0;
                int.TryParse(lnklbl.Text, out page);

                this.SetPageChanged(page);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnHome))
                {
                    this.SetPageChanged(1);
                }
                else if (btn.Equals(this.btnPrev))
                {
                    this.SetPageChanged(CurPage - 1);
                }
                else if (btn.Equals(this.btnNext))
                {
                    this.SetPageChanged(CurPage + 1);
                }
                else if (btn.Equals(this.btnEnd))
                {
                    this.SetPageChanged(TotalPageCount);
                }
            }
        }
        #endregion 7.Event
    }
}
