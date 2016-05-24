using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LHJ.DBService
{
    public partial class frmErrorMsg : Form
    {
        #region 1.Variable
        private Exception m_Ex;
        private string m_Query;
        private Object m_Param;
        #endregion 1.Variable


        #region 2.Property
        public Exception Ex { get; set; }
        public string Query { get; set; }
        public Object Param { get; set; }
        #endregion 2.Property


        #region 3.Constructor
        public frmErrorMsg()
        {
            InitializeComponent();

            this.SetInitialize();
        }
        #endregion 3.Constructor


        #region 4.Override Method
        private void frmErrorMsg_Load(object sender, EventArgs e)
        {
            this.showMessages();
        }
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
        private void showMessages()
        {
            this.ShowException();
            this.ShowSQL();
            this.ShowParam();

            this.txtSQL.SelectAll();
        }

        private void ShowException()
        {
            this.lblError.Text = Ex.Message;
        }

        private void ShowSQL()
        {
            this.txtSQL.Text = Query.Replace("\n", "\r\n");
        }

        private void ShowParam()
        {
            this.txtParam.Text = this.paramString();
        }

        private string paramString()
        {
            StringBuilder str = new StringBuilder("");

            if (Param == null)
            {
                return "";
            }
            else
            {
                if (Param.GetType().Equals(typeof(List<ParamInfo>)))
                {
                    List<ParamInfo> param = Param as List<ParamInfo>;

                    foreach (ParamInfo p in param)
                    {
                        str.AppendLine(string.Format("{0} : {1}", p.ParameterName, p.Value));
                    }
                }
                else if (Param.GetType().Equals(typeof(Hashtable)))
                {
                    Hashtable param = Param as Hashtable;

                    foreach (string paramName in param)
                    {
                        str.AppendLine(string.Format("{0} : {1}", paramName, param[paramName]));
                    }
                }

                return str.ToString();
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void txtSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 7.Event
    }
}
