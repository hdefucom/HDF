using CefSharp;
using CefSharp.WinForms;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form_Cef : Form
    {
        public Form_Cef()
        {


            //https://github.com/cefsharp/CefSharp/issues/1714
            //如需支持AnyCpu，可采用调用前连接
            //添加项目文件配置<CefSharpAnyCpuSupport>true</CefSharpAnyCpuSupport>和下面这行代码


            CefRuntime.SubscribeAnyCpuAssemblyResolver();


            //LoadApp();


            InitializeComponent();

            chromiumWebBrowser1.LoadUrl("https://baidu.com");
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings();

            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            //Application.Run(new Form_Cef());
        }

    }
}
