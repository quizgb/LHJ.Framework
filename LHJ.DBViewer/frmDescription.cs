using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Common.Definition;

namespace LHJ.DBViewer
{
    public partial class frmDescription : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmDescription()
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
        public void Search(Hashtable aHt)
        {
            DataTable dt = DALDataAccess.GetObjectListByObjectName(aHt["USER"].ToString(), aHt["OBJECT_NAME"].ToString());

            this.lblInfo.Text = string.Format("[{0}] Created:{1}   Last DDL:{2}", aHt["OBJECT_NAME"].ToString(), dt.Rows[0]["CREATED"].ToString(), dt.Rows[0]["LAST_DDL_TIME"].ToString());
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
