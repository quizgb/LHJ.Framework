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
    public partial class BookControl : UserControl
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public BookControl()
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
        private string SetPriceComma(string aStr)
        {
            string s = aStr;
            string temp = string.Empty;
            int con = 0;

            for (int cnt = s.Length - 1; 0 <= cnt; cnt--)
            {
                temp = s.Substring(cnt, 1) + temp;
                con += 1;

                if (con == 3 && cnt > 0)
                {
                    temp = "," + temp;
                    con = 0;
                }
            }

            return temp;
        }

        public void SetValue(BookItem aItm)
        {
            this.lnklblBookTitle.Tag = aItm.link;
            this.lnklblBookTitle.Text = aItm.title.Replace("<b>", string.Empty).Replace("</b>", string.Empty);
            this.lblBookInfo1.Text = string.Format("{0} 저 | {1} | {2}", 
                                                   aItm.author, 
                                                   aItm.publisher, 
                                                   string.IsNullOrEmpty(aItm.pubdate) ? string.Empty : aItm.pubdate.Insert(4, "-").Insert(7, "-"));
            this.lblBookPrice.Text = string.Format("{0} 원", this.SetPriceComma(aItm.price));
            this.txtBookDesc.Text = aItm.description.Replace("<b>", string.Empty).Replace("</b>", string.Empty);
            this.pbxBookImage.ImageLocation = aItm.image;
        }
        #endregion 6.Method

        #region 7.Event
        private void lnklblBookTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lnklblBookTitle.Tag != null)
            {
                Process.Start(this.lnklblBookTitle.Tag.ToString());
            }
        }
        #endregion 7.Event
    }
}
