using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            dt.Columns.Add("IP_ADDR");

            foreach (ServerListParam param in aServerList)
            {
                DataRow row = dt.NewRow();

                row["SERVER_NAME"] = param.A_서버명칭;
                row["IP_ADDR"] = param.B_IP주소;

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
                    ListViewItem lvwi = new ListViewItem(dr["SERVER_NAME"].ToString());
                    lvwi.Name = dr["SERVER_NAME"].ToString();

                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        lvwi.SubItems.Add(dr[i].ToString());
                    }

                    lvw.Items.Add(lvwi);
                }
            }

            lvw.Sorting = SortOrder.Ascending;
            lvw.Sort();
        }

        private bool CheckServerList(ServerListParam aParam)
        {
            IEnumerable<ServerListParam> existList = from idx in this.mServerList
                                                     where idx.A_서버명칭.Equals(aParam.A_서버명칭)
                                                     select idx;

            if (existList.Count() > 0)
            {
                MessageBox.Show(this, "서버명칭은 중복될 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(aParam.A_서버명칭))
            {
                MessageBox.Show(this, "서버명칭을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(aParam.B_IP주소))
            {
                MessageBox.Show(this, "IP주소를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(aParam.C_사용자이름))
            {
                MessageBox.Show(this, "사용자이름을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            Regex regex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

            if (!regex.IsMatch(aParam.B_IP주소))
            {
                MessageBox.Show(this, "입력하신 IP주소가 형식에 어긋납니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
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

            if (!this.CheckServerList(param))
            {
                return;
            }

            this.mServerList.Add(param);
            //string temp = Newtonsoft.Json.JsonConvert.SerializeObject(param);

            this.dtTolistView(this.ConvertToDatatable(this.mServerList), this.lvwServer);
            this.btnInit.PerformClick();
        }
        #endregion 7.Event

        private void lvwServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvwServer.Items.Count < 1 || this.lvwServer.SelectedItems.Count != 1)
            {
                return;
            }

            IEnumerable<ServerListParam> existList = from idx in this.mServerList
                                                     where idx.A_서버명칭.Equals(this.lvwServer.SelectedItems[0].Name)
                                                     select idx;

            if (existList.Count() > 0)
            {
                this.propertyGrid1.SelectedObject = existList.ToList()[0];
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.lvwServer.Items.Count < 1 || this.lvwServer.SelectedItems.Count != 1)
            {
                return;
            }

            string serverName = this.lvwServer.SelectedItems[0].Name;

            if (DialogResult.Yes.Equals(MessageBox.Show(this, string.Format("{0} 항목을 삭제하시겠습니까?", serverName), "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                this.lvwServer.SelectedItems[0].Remove();

                if (this.mServerList.Exists(server => server.A_서버명칭.Equals(serverName)))
                {
                    this.mServerList.Remove(this.mServerList.Find(server => server.A_서버명칭.Equals(serverName)));
                }

                this.lvwServer.Sorting = SortOrder.Ascending;
                this.lvwServer.Sort();

                this.btnInit.PerformClick();
            }
        }
    }
}
