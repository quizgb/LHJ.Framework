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
using LHJ.NaverSearch.Definition.ConstValue;

namespace LHJ.NaverSearch
{
    public partial class ShopControl : UserControl
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ShopControl()
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

        public string GetProductType(string aProductType)
        {
            string temp = string.Empty;

            List<DataRow> procudtList = (from DataRow row in ConstValue.ProductInfoTable().Rows
                                         where row["CODE"].ToString().Equals(aProductType)
                                         select row).ToList();

            if (procudtList.Count > 0)
            {
                temp = procudtList[0]["CODE_NAME"].ToString();
            }

            return temp;
        }

        public void SetValue(Shopping.ShopItem aItm)
        {
            this.lnklblShopTitle.Tag = aItm.link;
            this.lnklblShopTitle.Text = aItm.title.Replace("<b>", string.Empty).Replace("</b>", string.Empty);
            this.lblShopInfo1.Text = string.Format("가격 : {0} ~ {1}", this.SetPriceComma(aItm.lprice), this.SetPriceComma(aItm.hprice));
            this.lblShopInfo2.Text = string.Format("판매처 : {0}", aItm.mallName);
            this.lblShopInfo3.Text = this.GetProductType(aItm.productType);
            this.pbxShopImage.ImageLocation = aItm.image;
        }
        #endregion 6.Method


        #region 7.Event
        private void lnklblBookTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lnklblShopTitle.Tag != null)
            {
                Process.Start(this.lnklblShopTitle.Tag.ToString());
            }
        }
        #endregion 7.Event
    }
}
