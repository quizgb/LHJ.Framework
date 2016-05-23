using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.Common.Common.Com
{
    public class Logger
    {
        private log4net.ILog m_Logger = null;

        public Logger()
        {
        }

        public void SetConfigLogger(string pLogFileName)
        {
            m_Logger = log4net.LogManager.GetLogger(string.Format("{0}", pLogFileName));

            #region 로그 설정
            log4net.Repository.Hierarchy.Hierarchy hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
            hierarchy.Configured = true;

            log4net.Appender.RollingFileAppender rollingAppender = new log4net.Appender.RollingFileAppender();
            rollingAppender.File = string.Format(@"{0}\LOG\{1}.log", Application.StartupPath, pLogFileName); // 전체 경로에 생성할 메인 로그 파일 이름  
            rollingAppender.AppendToFile = true;
            rollingAppender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Date;
            rollingAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
            rollingAppender.StaticLogFileName = false;
            rollingAppender.DatePattern = "_yyyy-MM-dd\".log\""; // 날짜가 지나간 경우 이전 로그에 붙을 이름 구성  
            log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("[%d]%n[Type : %p]%nMessage : %m%n%n");
            rollingAppender.Layout = layout;

            hierarchy.Root.AddAppender(rollingAppender);
            rollingAppender.ActivateOptions();

            hierarchy.Root.Level = log4net.Core.Level.All;
            #endregion  
        }

        public void Fatal(System.Reflection.MethodBase pMethodBase, Object message)
        {
            m_Logger.Fatal(message + "\r\n" + this.CreateInfoMsg(pMethodBase));
        }

        public void Fatal(System.Reflection.MethodBase pMethodBase, Object message, Exception exception)
        {
            m_Logger.Fatal(message + "\r\n" + this.CreateInfoMsg(pMethodBase), exception);
        }

        public void Error(System.Reflection.MethodBase pMethodBase, Object message)
        {
            m_Logger.Error(message + "\r\n" + this.CreateInfoMsg(pMethodBase));
        }

        public void Error(System.Reflection.MethodBase pMethodBase, Object message, Exception exception)
        {
            m_Logger.Error(message + "\r\n" + this.CreateInfoMsg(pMethodBase), exception);
        }

        public void Debug(System.Reflection.MethodBase pMethodBase, Object message)
        {
            m_Logger.Debug(message + "\r\n" + this.CreateInfoMsg(pMethodBase));
        }

        public void Info(System.Reflection.MethodBase pMethodBase, Object message)
        {
            m_Logger.Info(message + "\r\n" + this.CreateInfoMsg(pMethodBase));
        }

        private string CreateInfoMsg(System.Reflection.MethodBase pMethodBase)
        {
            return string.Format("[CLASS NAME : {0}.cs]\r\n[METHOD NAME : {1}]\r\n", pMethodBase.ReflectedType.FullName, pMethodBase.Name);
        }
    }
}
