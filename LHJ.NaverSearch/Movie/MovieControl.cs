using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LHJ.NaverSearch
{
    public partial class MovieControl : UserControl
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public MovieControl()
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
        public void SetValue(Movie.MovieItem aItm)
        {
            this.lnklblMvTitle.Tag = aItm.link;
            this.lnklblMvTitle.Text = aItm.title.Replace("<b>", string.Empty).Replace("</b>", string.Empty);

            if (!string.IsNullOrEmpty(aItm.subtitle))
            {
                this.lnklblMvTitle.Text += string.Format("<{0}>", aItm.subtitle);
            }

            this.lblMvInfo1.Text = string.Format("감독 : {0} 배우 : {1} 제작년도 : {2}",
                                                   aItm.director,
                                                   aItm.actor,
                                                   string.IsNullOrEmpty(aItm.pubDate) ? string.Empty : aItm.pubDate);

            this.lblRating.Text = string.Format("평점 : {0} / 10", aItm.userRating);
            this.pbxMvImage.ImageLocation = aItm.image;
        }
        #endregion 6.Method


        #region 7.Event
        private void lnklblBookTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lnklblMvTitle.Tag != null)
            {
                Process.Start(this.lnklblMvTitle.Tag.ToString());
            }
        }
        #endregion 7.Event
    }
}
