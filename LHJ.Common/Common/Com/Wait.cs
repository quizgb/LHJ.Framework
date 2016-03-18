using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LHJ.Common.Control;

namespace LHJ.Common.Com
{
    public class Wait
    {
        private FrmSplash m_frmSplash = new FrmSplash();
        private bool m_isAlive = false;

        public void Show()
        {
            if (!m_isAlive)
            {
                m_frmSplash = new FrmSplash();
                m_frmSplash.Show();

                m_isAlive = true;
            }
        }

        public void Close()
        {
            m_isAlive = false;

            m_frmSplash.Close();
            m_frmSplash.Dispose();
        }

        public void Show(int aInterval)
        {
            if (!m_isAlive)
            {
                m_frmSplash.Show();

                if (aInterval > 0)
                {
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = aInterval;

                    //무명매서드를 통해서 정해진 시간에 실행될 명령어를 선언했다.
                    timer.Tick += new EventHandler
                        (
                            delegate (object sender, EventArgs e)
                            {
                                m_isAlive = false; m_frmSplash.Close(); timer.Stop(); timer.Dispose(); m_frmSplash.Dispose();
                            }
                        );

                    timer.Start();
                }
            }
        }
    }
}
