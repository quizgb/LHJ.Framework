using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LHJ.DBViewer
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            bool bNew;
            Mutex mutex = new Mutex(true, "LHJ.DBViewer", out bNew);

            if (bNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());

                // 뮤텍스 릴리즈                 
                mutex.ReleaseMutex();
            }
            else
            {
                // 소유권이 부여되지 않음                 
                MessageBox.Show("프로그램이 이미 실행중 입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
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
