using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverSearch
{
    public partial class BookSearch : Form
    {
        public class BookSearchRslt
        {
            public string lastBuildDate { get; set; }
            public int total { get; set; }
            public int start { get; set; }
            public int display { get; set; }
            public Item[] items { get; set; }
        }

        public class Item
        {
            public string title { get; set; }
            public string link { get; set; }
            public string image { get; set; }
            public string author { get; set; }
            public string price { get; set; }
            public string discount { get; set; }
            public string publisher { get; set; }
            public string pubdate { get; set; }
            public string isbn { get; set; }
            public string description { get; set; }
        }

        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public BookSearch()
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

        #endregion 6.Method


        #region 7.Event
        private void button1_Click(object sender, EventArgs e)
        {
            string subUrl = string.Format("query={0}&d_titl={1}", string.Empty, "어린왕자");
            string url = "https://openapi.naver.com/v1/search/book_adv.json?" + subUrl;
            string text = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", Definition.ConstValue.ConstValue.NaverClintInfo.ID);
            request.Headers.Add("X-Naver-Client-Secret", Definition.ConstValue.ConstValue.NaverClintInfo.PASS);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                string status = response.StatusCode.ToString();

                if (status == "OK")
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            text = reader.ReadToEnd();
                        }
                    }

                    BookSearchRslt ts = JsonConvert.DeserializeObject<BookSearchRslt>(text);
                }
                else
                {
                    Console.WriteLine("Error 발생=" + status);
                }
            }
        }
        #endregion 7.Event
    }
}
