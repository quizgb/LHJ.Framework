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
        public Exception ex;
        public string Query;
        public Object Param;

        public frmErrorMsg()
        {
            InitializeComponent();
        }

        private void frmErrorMsg_Load(object sender, EventArgs e)
        {
            this.showMessages();
        }

        private void showMessages()
        {
            this.ShowException();
            this.ShowSQL();
            this.ShowParam();
        }

        private void ShowException()
        {
            this.lblError.Text = ex.Message;
        }

        private void ShowSQL()
        {
            this.txtSQL.Text = this.Query;
        }

        private void ShowParam()
        {
            this.txtParam.Text = this.paramString(this.Param);
        }

        private string paramString(Object aParam)
        {
            StringBuilder str = new StringBuilder("");

            if (aParam == null)
            {
                return "";
            }
            else
            {
                if (aParam.GetType().Equals(typeof(List<ParamInfo>)))
                {
                    List<ParamInfo> param = aParam as List<ParamInfo>;

                    foreach (ParamInfo p in param)
                    {
                        str.AppendLine(string.Format("{0} : {1}", p.ParameterName, p.Value));
                    }
                }
                else if (aParam.GetType().Equals(typeof(Hashtable)))
                {
                    Hashtable param = aParam as Hashtable;

                    foreach (string paramName in param)
                    {
                        str.AppendLine(string.Format("{0} : {1}", paramName, param[paramName]));
                    }
                }

                return str.ToString();
            }
        }

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
    }
}
