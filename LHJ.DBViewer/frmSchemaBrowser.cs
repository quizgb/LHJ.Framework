using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.DBViewer
{
    public partial class frmSchemaBrowser : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmSchemaBrowser()
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
            frmDescription descFrm = new frmDescription();
            descFrm.Dock = DockStyle.Fill;
            descFrm.TopLevel = false;
            descFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.splitContainer1.Panel2.Controls.Add(descFrm);

            descFrm.Show();
        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event
        private void ucObject21_SelectedObjChanged(object sender, Common.Definition.EventHandler.SelectedObjChangedEventArgs e)
        {
            frmDescription descFrm = this.splitContainer1.Panel2.Controls[0] as frmDescription;
            descFrm.Search(e.Ht);
        }
        #endregion 7.Event
    }
}
