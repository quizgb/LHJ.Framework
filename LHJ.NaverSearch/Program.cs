using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverSearch
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ///어셈블리 로드가 실패 하였을 경우 해당 이벤트가 발생됨
            ///컴파일 시 또는 실행시 해당 응용 프로그램의 리소스에 포함되어 있는 dll을 가져와 로드 시킴
            AppDomain.CurrentDomain.AssemblyResolve += (sender, bargs) =>
            {
                string dllName = new AssemblyName(bargs.Name).Name + ".dll";
                var assem = Assembly.GetExecutingAssembly();
                string resourceName = null;

                foreach (string str in assem.GetManifestResourceNames())
                {
                    if (str.ToUpper().Contains(dllName.ToUpper()))
                    {
                        resourceName = str;
                        break;
                    }
                }

                if (resourceName == null) return null;

                using (var stream = assem.GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string sMethodNm = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string meessage = "프로그램에 문제가 있어 비 정상적으로 종료 되었습니다.\n" +
                             "아래 내용을 개발자에게 전달 바랍니다.\nquizgb@naver.com\n\n\n";
            string[] call_stacks;

            Exception exc = (Exception)e.ExceptionObject;

            call_stacks = exc.StackTrace.Split(new string[] { "\r\n" },
                                  StringSplitOptions.RemoveEmptyEntries);

            meessage += "■ Error:\n    " + exc.Message + "\n\n";
            meessage += "■ Location:\n"; ;

            foreach (string line in call_stacks)
            {
                if (line.Contains(".cs"))
                {
                    meessage += line + "\n\n";
                }
            }

            MessageBox.Show(meessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(101); //오류 보고 다이얼로그 표시하지 않고 종료 시키기 for WINDOWS 7
        }
    }
}
