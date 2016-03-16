using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace LHJ.Common
{
    public class ClsGetSlnCodeLine
    {
        public static string[] GetCsproj(string slnDirect)
        {
            StreamReader sr = new StreamReader(slnDirect);
            string[] parsed = sr.ReadToEnd().Split(new string[] { "Project(" }, StringSplitOptions.None);
            string[] projects = new string[(parsed.Length + 1) / 2];

            int i = 0;

            foreach (string s in parsed)
            {
                if (i++ == 0) continue;
                string result = Path.GetDirectoryName(slnDirect) + "\\" + s.Split('"')[5];
                projects[(i - 1) / 2] = result;
            }

            return projects;
        }

        public static string[] GetCodelist(string csprojDirect, bool includeDesigner)
        {
            XmlReader xml = XmlReader.Create(csprojDirect);
            List<string> codes = new List<string>();

            while (xml.Read())
            {
                if (xml.Name.StartsWith("Compile"))
                {
                    if (xml.MoveToFirstAttribute())
                    {
                        string code = xml.Value;

                        if (!includeDesigner && code.EndsWith(".Designer.cs"))
                        {
                            continue;
                        }

                        if (code.EndsWith("AssemblyInfo.cs"))
                        {
                            continue;
                        }

                        codes.Add(Path.GetDirectoryName(csprojDirect) + "\\" + code);
                    }
                }
            }

            return codes.ToArray();
        }
    }
}
