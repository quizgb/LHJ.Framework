using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("서버리스트 항목이 더블클릭될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.ServerListDoubleClickEventHandler ServerItemDoubleClicked;
        #endregion 1.Variable


        #region 2.Property
        public List<ServerListParam> ServerList
        {
            get { return this.mServerList; }
        }
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

            this.LoadServerList();
        }

        #endregion 5.Set Initialize

        
        #region 6.Method
        private void SetServerItemDoubleClicked(object aServerListParam)
        {
            if (ServerItemDoubleClicked != null)
            {
                Common.Definition.EventHandler.ServerListDoubleClickEventArgs e = new Common.Definition.EventHandler.ServerListDoubleClickEventArgs(aServerListParam);
                ServerItemDoubleClicked(this, e);
            }
        }

        public void SaveServerList()
        {
            StreamWriter sw = null;
            this.SetEncryptPassword();

            if (this.mServerList.Count > 0)
            {
                string list = Newtonsoft.Json.JsonConvert.SerializeObject(this.mServerList);

                try
                {
                    sw = new StreamWriter((Stream)File.Create(Application.StartupPath + @"\" + LHJ.Common.Definition.ConstValue.ServerInfoMonitorServerListFileName));
                    sw.Write(list);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
        }

        private void LoadServerList()
        {
            if (File.Exists(Application.StartupPath + @"\" + LHJ.Common.Definition.ConstValue.ServerInfoMonitorServerListFileName))
            {
                string list = string.Empty;

                foreach (string line in File.ReadAllLines(Application.StartupPath + @"\" + LHJ.Common.Definition.ConstValue.ServerInfoMonitorServerListFileName))
                {
                    list += line;
                }

                this.mServerList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerListParam>>(list);
                this.SetDecryptPassword();
                this.dtTolistView(this.ConvertToDatatable(this.mServerList), this.lvwServer);
            }

            this.InitServerList();
        }

        private void InitServerList()
        {
            if (this.mServerList == null)
            {
                this.mServerList = new List<ServerListParam>();
            }

            ServerListParam param = new ServerInfoMonitor.ServerListParam();
            this.propertyGridEx1.SelectedObject = param;
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
            if (this.mServerList.Count > 0)
            {
                IEnumerable<ServerListParam> existList = from idx in this.mServerList
                                                         where idx.A_서버명칭.Equals(aParam.A_서버명칭)
                                                         select idx;

                if (existList.Count() > 0)
                {
                    MessageBox.Show(this, "서버명칭은 중복될 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
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

        public void SetEncryptPassword()
        {
            if (this.mServerList.Count > 0)
            {
                foreach (ServerListParam param in this.mServerList)
                {
                    param.D_비밀번호 = LHJ.Common.Common.Com.Cryptography.FN_ENCRPT(param.D_비밀번호);
                }
            }
        }

        public void SetDecryptPassword()
        {
            if (this.mServerList.Count > 0)
            {
                foreach (ServerListParam param in this.mServerList)
                {
                    param.D_비밀번호 = LHJ.Common.Common.Com.Cryptography.FN_DECRPT(param.D_비밀번호);
                }
            }
        }
        #endregion 6.Method

        #region 7.Event
        private void btnInit_Click(object sender, EventArgs e)
        {
            this.InitServerList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServerListParam param = (ServerListParam)this.propertyGridEx1.SelectedObject;

            if (!this.CheckServerList(param))
            {
                return;
            }

            this.mServerList.Add(param);
            this.dtTolistView(this.ConvertToDatatable(this.mServerList), this.lvwServer);
            this.btnInit.PerformClick();
        }

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
                this.propertyGridEx1.SelectedObject = existList.ToList()[0];
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
        #endregion 7.Event

        private void lvwServer_DoubleClick(object sender, EventArgs e)
        {
            string serverName = this.lvwServer.SelectedItems[0].Name;

            if (this.mServerList.Exists(server => server.A_서버명칭.Equals(serverName)))
            {
                ServerListParam param = this.mServerList.Find(server => server.A_서버명칭.Equals(serverName));
                this.SetServerItemDoubleClicked(param);
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxPing.Text))
            {
                MessageBox.Show(this, "Ping Test IP주소를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Regex regex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

            if (!regex.IsMatch(this.tbxPing.Text))
            {
                this.tbxPing.Focus();
                MessageBox.Show(this, "입력하신 Ping Test IP주소가\r\n형식에 어긋납니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (LHJ.Common.Common.Com.Util.PingTest(this.tbxPing.Text))
            {
                MessageBox.Show(this, "Ping을 정상적으로 보냈습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Ping을 보내지 못했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
