using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form_WebView2 : Form
    {
        public Form_WebView2()
        {


            InitializeComponent();
            //HandleResize();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (int)Keys.Enter)
                return;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;


            webView21.Source = new System.Uri(textBox1.Text);
            //webView21.Focus();

        }



        private void HandleResize()
        {
            // Resize the webview
            //webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);

            //// Move the Events button
            //btnEvents.Left = this.ClientSize.Width - btnEvents.Width;
            //// Move the Go button
            //btnGo.Left = this.btnEvents.Left - btnGo.Size.Width;

            //// Resize the URL textbox
            //txtUrl.Width = btnGo.Left - txtUrl.Left;
        }

        private async void Form_WebView2_Load(object sender, System.EventArgs e)
        {

            //var env = await CoreWebView2Environment.CreateAsync(@"E:\µÂÜ½\Chrome Download\Microsoft.WebView2.FixedVersionRuntime.100.0.1185.29.x64");


            //var webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            //webView21.AllowExternalDrop = true;
            //webView21.CreationProperties = null;
            //webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            //webView21.Location = new System.Drawing.Point(0, 21);
            //webView21.Name = "webView21";
            //webView21.Size = new System.Drawing.Size(800, 429);
            //webView21.TabIndex = 0;
            //webView21.ZoomFactor = 1D;
            //webView21.Dock = DockStyle.Fill;


            //await webView21.EnsureCoreWebView2Async(env);

            //this.Controls.Add(webView21);





            webView21.Source = new System.Uri("https://www.baidu.com/", System.UriKind.Absolute);

        }
    }
}