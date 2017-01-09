using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverSearch
{
    public partial class frmMain : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
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
            this.Icon = Properties.Resources._1483694358_naver;
            this.SetScreen();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetScreen()
        {
            TabPage tp = new TabPage();
            tp.Text = "책 검색";

            BookSearch bs = new BookSearch();
            bs.TopLevel = false;
            tp.Controls.Add(bs);
            bs.Dock = DockStyle.Fill;
            bs.FormBorderStyle = FormBorderStyle.None;
            bs.Show();

            this.tabControl1.TabPages.Add(tp);

            tp = new TabPage();
            tp.Text = "영화 검색";

            Movie.MovieSearch ms = new Movie.MovieSearch();
            ms.TopLevel = false;
            tp.Controls.Add(ms);
            ms.Dock = DockStyle.Fill;
            ms.FormBorderStyle = FormBorderStyle.None;
            ms.Show();

            this.tabControl1.TabPages.Add(tp);

            tp = new TabPage();
            tp.Text = "쇼핑 검색";

            Shopping.ShopSearch ss = new Shopping.ShopSearch();
            ss.TopLevel = false;
            tp.Controls.Add(ss);
            ss.Dock = DockStyle.Fill;
            ss.FormBorderStyle = FormBorderStyle.None;
            ss.Show();

            this.tabControl1.TabPages.Add(tp);

            tp = new TabPage();
            tp.Text = "지식인 검색";

            KnowIn.KnowInSearch kis = new KnowIn.KnowInSearch();
            kis.TopLevel = false;
            tp.Controls.Add(kis);
            kis.Dock = DockStyle.Fill;
            kis.FormBorderStyle = FormBorderStyle.None;
            kis.Show();

            this.tabControl1.TabPages.Add(tp);

            this.tabControl1_SelectedIndexChanged(this.tabControl1, null);
        }
        #endregion 6.Method

        #region 7.Event
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBookSearch ibs = this.tabControl1.SelectedTab.Controls[0] as IBookSearch;
            ibs.SetFocusTitle();
        }
        #endregion 7.Event
    }
}
