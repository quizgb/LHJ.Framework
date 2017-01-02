using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
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
        //3.XML을 가져왔을때는 XmlDocument 객체 생성 후 XmlToJSON 메소드를 통해 JSON으로 변환하면 된다.

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
            //string url = string.Format(@"http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchDailyBoxOfficeList.json?key={0}&targetDt={1}", "07b59c3c13cc181e4279e43161a6762b", "20150101");
            string url = string.Format(@"http://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage={0}&countPerPage={1}&keyword={2}&confmKey={3}", "1", "10", "송포로", "TESTJUSOGOKR");

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
            File.WriteAllText(@"C:\test.xml", json);
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\test.xml");

            string temp = XmlToJSON(doc);

            listView1.BeginUpdate();

            Movie mv = JsonConvert.DeserializeObject<Movie>(json); 
            //GoogleMaps gm = JsonConvert.DeserializeObject<GoogleMaps>(json); 

            //this.listView1.Columns.Add("Subject", 200/*가로사이즈*/, HorizontalAlignment.Left);
            //this.listView1.Columns.Add("Done", 200/*가로사이즈*/, HorizontalAlignment.Left);
            //this.listView1.Columns.Add("Author", 200/*가로사이즈*/, HorizontalAlignment.Left);

            listView1.EndUpdate();
        }

        private static string XmlToJSON(XmlDocument xmlDoc)
        {
            StringBuilder sbJSON = new StringBuilder();
            sbJSON.Append("{ ");
            XmlToJSONnode(sbJSON, xmlDoc.DocumentElement, true);
            sbJSON.Append("}");
            return sbJSON.ToString();
        }

        //  XmlToJSONnode:  Output an XmlElement, possibly as part of a higher array
        private static void XmlToJSONnode(StringBuilder sbJSON, XmlElement node, bool showNodeName)
        {
            if (showNodeName)
                sbJSON.Append("\"" + SafeJSON(node.Name) + "\": ");
            sbJSON.Append("{");
            // Build a sorted list of key-value pairs
            //  where   key is case-sensitive nodeName
            //          value is an ArrayList of string or XmlElement
            //  so that we know whether the nodeName is an array or not.
            SortedList childNodeNames = new SortedList();

            //  Add in all node attributes
            if (node.Attributes != null)
                foreach (XmlAttribute attr in node.Attributes)
                    StoreChildNode(childNodeNames, attr.Name, attr.InnerText);

            //  Add in all nodes
            foreach (XmlNode cnode in node.ChildNodes)
            {
                if (cnode is XmlText)
                    StoreChildNode(childNodeNames, "value", cnode.InnerText);
                else if (cnode is XmlElement)
                    StoreChildNode(childNodeNames, cnode.Name, cnode);
            }

            // Now output all stored info
            foreach (string childname in childNodeNames.Keys)
            {
                ArrayList alChild = (ArrayList)childNodeNames[childname];
                if (alChild.Count == 1)
                    OutputNode(childname, alChild[0], sbJSON, true);
                else
                {
                    sbJSON.Append(" \"" + SafeJSON(childname) + "\": [ ");
                    foreach (object Child in alChild)
                        OutputNode(childname, Child, sbJSON, false);
                    sbJSON.Remove(sbJSON.Length - 2, 2);
                    sbJSON.Append(" ], ");
                }
            }
            sbJSON.Remove(sbJSON.Length - 2, 2);
            sbJSON.Append(" }");
        }

        //  StoreChildNode: Store data associated with each nodeName
        //                  so that we know whether the nodeName is an array or not.
        private static void StoreChildNode(SortedList childNodeNames, string nodeName, object nodeValue)
        {
            // Pre-process contraction of XmlElement-s
            if (nodeValue is XmlElement)
            {
                // Convert  <aa></aa> into "aa":null
                //          <aa>xx</aa> into "aa":"xx"
                XmlNode cnode = (XmlNode)nodeValue;
                if (cnode.Attributes.Count == 0)
                {
                    XmlNodeList children = cnode.ChildNodes;
                    if (children.Count == 0)
                        nodeValue = null;
                    else if (children.Count == 1 && (children[0] is XmlText))
                        nodeValue = ((XmlText)(children[0])).InnerText;
                }
            }
            // Add nodeValue to ArrayList associated with each nodeName
            // If nodeName doesn't exist then add it
            object oValuesAL = childNodeNames[nodeName];
            ArrayList ValuesAL;
            if (oValuesAL == null)
            {
                ValuesAL = new ArrayList();
                childNodeNames[nodeName] = ValuesAL;
            }
            else
                ValuesAL = (ArrayList)oValuesAL;
            ValuesAL.Add(nodeValue);
        }

        private static void OutputNode(string childname, object alChild, StringBuilder sbJSON, bool showNodeName)
        {
            if (alChild == null)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                sbJSON.Append("null");
            }
            else if (alChild is string)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                string sChild = (string)alChild;
                sChild = sChild.Trim();
                sbJSON.Append("\"" + SafeJSON(sChild) + "\"");
            }
            else
                XmlToJSONnode(sbJSON, (XmlElement)alChild, showNodeName);
            sbJSON.Append(", ");
        }

        // Make a string safe for JSON
        private static string SafeJSON(string sIn)
        {
            StringBuilder sbOut = new StringBuilder(sIn.Length);
            foreach (char ch in sIn)
            {
                if (Char.IsControl(ch) || ch == '\'')
                {
                    int ich = (int)ch;
                    sbOut.Append(@"\u" + ich.ToString("x4"));
                    continue;
                }
                else if (ch == '\"' || ch == '\\' || ch == '/')
                {
                    sbOut.Append('\\');
                }
                sbOut.Append(ch);
            }
            return sbOut.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ParseJson(this.Request_Json());
        }
    }
}
