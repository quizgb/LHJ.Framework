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
using LHJ.Practice.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LHJ.Practice
{
    public partial class FrmJson : Form
    {
        //JSON 작업순서
        //1.JSON 문자열을 받아서 클립보드에 복사하고 비쥬얼스튜디오 -> 편집 -> 선택하여 붙여넣기 -> JSON을 클래스로 붙여넣기 선택.
        //2.RootObject 클래스 명칭을 원하는대로 변경 후 JsonConvert.DeserializeObject<클래스명>을 통해 받아오면 끝.

        public FrmJson()
        {
            InitializeComponent();
        }

        private string Request_Json()
        {
            this.listView1.Items.Clear();

            string result = null;
            //string url = "http://www.redmine.org/issues.json";
            //string url = @"http://maps.googleapis.com/maps/api/geocode/json?latlng=37.566535,126.977969&language=ko";
            string url = string.Format(@"http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchDailyBoxOfficeList.json?key={0}&targetDt={1}", "07b59c3c13cc181e4279e43161a6762b", "20150101");

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

            Movie mv = JsonConvert.DeserializeObject<Movie>(json); 
            //GoogleMaps gm = JsonConvert.DeserializeObject<GoogleMaps>(json); 
            //this.listView1.Columns.Add("Subject", 200/*가로사이즈*/, HorizontalAlignment.Left);
            //this.listView1.Columns.Add("Done", 200/*가로사이즈*/, HorizontalAlignment.Left);
            //this.listView1.Columns.Add("Author", 200/*가로사이즈*/, HorizontalAlignment.Left);

            listView1.EndUpdate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ParseJson(this.Request_Json());
        }
    }
}
