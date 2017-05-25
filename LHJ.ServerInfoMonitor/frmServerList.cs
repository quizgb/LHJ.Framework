using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.ServerInfoMonitor
{
    public partial class frmServerList : Form
    {
        #region 1.Variable
        private List<ServerListParam> mServerList;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmServerList()
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
            this.lvwServer.FullRowSelect = true;
            this.lvwServer.GridLines = true;
            this.lvwServer.View = View.List;

            this.InitServerList();
        }

        #endregion 5.Set Initialize

        #region 6.Method
        private void InitServerList()
        {
            if (this.mServerList == null)
            {
                this.mServerList = new List<ServerListParam>();
            }

            ServerListParam param = new ServerInfoMonitor.ServerListParam();
            this.propertyGrid1.SelectedObject = param;
        }

        DataTable ConvertToDatatable(List<ServerListParam> aServerList)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SERVER_NAME");

            foreach (ServerListParam param in aServerList)
            {
                DataRow row = dt.NewRow();

                row["SERVER_NAME"] = param.A_서버명칭;

                dt.Rows.Add(row);
            }

            return dt;
        }

        private void dtTolistView(DataTable dt, ListView lvw)
        {
            lvw.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem lvwi = new ListViewItem();
                    lvwi.Text = dr["SERVER_NAME"].ToString();

                    //for (int i = 1; i < dt.Columns.Count; i++)
                    //{
                    //    lvwi.SubItems.Add(dr[i].ToString());
                    //}

                    lvw.Items.Add(lvwi);
                }
            }

            lvw.Sorting = SortOrder.Ascending;
            lvw.Sort();
        }
        #endregion 6.Method

        #region 7.Event
        private void btnInit_Click(object sender, EventArgs e)
        {
            this.InitServerList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServerListParam param = (ServerListParam)this.propertyGrid1.SelectedObject;
            this.mServerList.Add(param);
            //string temp = Newtonsoft.Json.JsonConvert.SerializeObject(param);

            this.dtTolistView(this.ConvertToDatatable(this.mServerList), this.lvwServer);
            this.btnInit.PerformClick();
        }
        #endregion 7.Event
    }
}
