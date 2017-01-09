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
    public partial class KnowInControl : UserControl
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public KnowInControl()
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
        public void SetValue(KnowIn.KIItem aItm)
        {
            this.lnklblKnowInTitle.Tag = aItm.link;
            this.lnklblKnowInTitle.Text = aItm.title.Replace("<b>", string.Empty).Replace("</b>", string.Empty);
            this.txtBookDesc.Text = aItm.description.Replace("<b>", string.Empty).Replace("</b>", string.Empty);
        }
        #endregion 6.Method


        #region 7.Event
        private void lnklblBookTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lnklblKnowInTitle.Tag != null)
            {
                Process.Start(this.lnklblKnowInTitle.Tag.ToString());
            }
        }
        #endregion 7.Event
    }
}
