using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            chromiumWebBrowser1.LoadUrl("https://www.baidu.com");
        }
    }
}
