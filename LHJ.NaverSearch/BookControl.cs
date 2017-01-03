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
        public void SetValue(Item aItm)
        {
            this.lnklblBookTitle.Text = aItm.title;
            //this.lnklblBookTitle.Text = aItm.title.Replace("<b>", string.Empty).Replace("</b>", string.Empty);
            this.lblBookInfo1.Text = string.Format("{0} 저 | {1} | {2}", aItm.author, aItm.publisher, aItm.pubdate.Insert(4, "-").Insert(7, "-"));
            this.lblBookPrice.Text = string.Format("{0} 원", aItm.price);
            this.lblBookDesc.Text = aItm.description;       
        }
        #endregion 6.Method

        #region 7.Event
        private void richLabel1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        #endregion 7.Event
    }
}
