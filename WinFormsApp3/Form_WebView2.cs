using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form_WebView2 : Form
    {
        public Form_WebView2()
        {
            InitializeComponent();
            HandleResize();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (int)Keys.Enter)
                return;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;


            webView21.Source = new System.Uri(textBox1.Text);
            //webView21.CoreWebView2.Navigate(textBox1.Text);
            webView21.Focus();

        }



        private void HandleResize()
        {
            // Resize the webview
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);

            //// Move the Events button
            //btnEvents.Left = this.ClientSize.Width - btnEvents.Width;
            //// Move the Go button
            //btnGo.Left = this.btnEvents.Left - btnGo.Size.Width;

            //// Resize the URL textbox
            //txtUrl.Width = btnGo.Left - txtUrl.Left;
        }














    }
}