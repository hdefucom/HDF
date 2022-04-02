using CefSharp;
using CefSharp.WinForms;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WinFormsApp3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            {

                //https://github.com/cefsharp/CefSharp/issues/1714
                //����֧��AnyCpu���ɲ��õ���ǰ����
                //�����Ŀ�ļ�����<CefSharpAnyCpuSupport>true</CefSharpAnyCpuSupport>���������д���
                CefRuntime.SubscribeAnyCpuAssemblyResolver();


                LoadApp();
            }


            if (false)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Form_WebView2());
            }




        }





        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings();

            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            Application.Run(new Form_Cef());
        }






    }
}