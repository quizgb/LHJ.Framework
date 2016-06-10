using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace LHJ.Practice
{
    public partial class FrmJson : Form
    {
        public class Issue
        {
            public string Subject { get; set; }
            public string Done { get; set; }
            public string Author { get; set; }
        }

        public FrmJson()
        {
            InitializeComponent();
        }

        private string Request_Json()
        {
            this.listView1.Items.Clear();

            string result = null;
            string url = "http://www.redmine.org/issues.json";
            Console.WriteLine("url : " + url);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        private void ParseJson(String json)
        {
            listView1.BeginUpdate();

            List<Issue> issues = new List<Issue>();
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["issues"].ToString());

            foreach (JObject itemObj in array)
            {
                Issue issue = new Issue();
                issue.Subject = itemObj["subject"].ToString();
                issue.Done = itemObj["done_ratio"].ToString();
                issue.Author = itemObj["author"]["name"].ToString();
                issues.Add(issue);
            }

            foreach(Issue isu in issues)
            {
                ListViewItem lvi = new ListViewItem(isu.Subject);
                lvi.SubItems.Add(isu.Done);
                lvi.SubItems.Add(isu.Author);

                listView1.Items.Add(lvi);
            }

            this.listView1.Columns.Add("Subject",  200/*가로사이즈*/, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Done", 200/*가로사이즈*/, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Author", 200/*가로사이즈*/, HorizontalAlignment.Left);

            listView1.EndUpdate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ParseJson(this.Request_Json());
        }
    }
}
