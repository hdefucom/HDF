using System;
using System.Text;
using System.Windows.Forms;

namespace WXTool.WinClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //����Ӧ�ó������쳣��ʽ��ThreadException����
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //����UI�߳��쳣
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //�����UI�߳��쳣
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            string simpleStr = GetExceptionSimpleMsg(e.Exception, e.ToString());
            MessageBox.Show(simpleStr, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            string simpleStr = GetExceptionSimpleMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(simpleStr, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            WriteLog(str);
        }

        /// <summary>
        /// �����Զ����쳣��Ϣ
        /// </summary>
        /// <param name="ex">�쳣����</param>
        /// <param name="backStr">�����쳣��Ϣ����exΪnullʱ��Ч</param>
        /// <returns>�쳣�ַ����ı�</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************�쳣�ı�****************************");
            sb.AppendLine("������ʱ�䡿��" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("���쳣���͡���" + ex.GetType().Name);
                sb.AppendLine("���쳣��Ϣ����" + ex.Message);
                sb.AppendLine("����ջ���á���" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("��δ�����쳣����" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
        /// <summary>
        /// �����Զ����쳣��Ϣ
        /// </summary>
        /// <param name="ex">�쳣����</param>
        /// <param name="backStr">�����쳣��Ϣ����exΪnullʱ��Ч</param>
        /// <returns>�쳣�ַ����ı�</returns>
        static string GetExceptionSimpleMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************�쳣�ı�****************************");
            sb.AppendLine("�������г����쳣");
            if (ex != null)
            {
                sb.AppendLine("���쳣���͡���" + ex.GetType().Name);
                sb.AppendLine("���쳣��Ϣ����" + ex.Message);
            }
            else
            {
                sb.AppendLine("��δ�����쳣����" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
        static void WriteLog(string log)
        {
            var filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Error.log");
            System.IO.File.AppendAllText(filename, log);
        }

    }
}
