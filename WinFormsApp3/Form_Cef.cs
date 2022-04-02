using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form_Cef : Form
    {
        public Form_Cef()
        {
            InitializeComponent();

            chromiumWebBrowser1.LoadUrl("https://www.baidu.com");
        }
    }
}
