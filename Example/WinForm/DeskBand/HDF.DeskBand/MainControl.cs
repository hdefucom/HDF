using Baidu;
using CSDeskBand;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HDF.DeskBand
{


    public partial class MainControl : UserControl, IDisposable
    {
        public MainControl()
        {
            InitializeComponent();

            var path = Path.GetDirectoryName(this.GetType().Assembly.Location);

            path = Path.Combine(path, "config");

            if (File.Exists(path))
            {
                var config = File.ReadAllLines(path);
                if ((config?.Length ?? 0) < 2)
                {
                    txt_Key.Text = "程序配置错误";
                    return;
                }
                BaiduTranslate.AppID = config[0];
                BaiduTranslate.SecretKey = config[1];
            }
            else
            {
                txt_Key.Text = "请先配置API接口信息";
                return;
            }

            Log.Write("进行构造：" + DateTime.Now.ToString());

            new HotKey[]
            {
                new HotKey(Keys.W, KeyModifiers.Control),//打开详情
                new HotKey(Keys.Q, KeyModifiers.Control),//输入
                new HotKey(Keys.B, KeyModifiers.Control),//百度
                new HotKey(Keys.G, KeyModifiers.Control),//谷歌
            }
            .Select(h => new { Res = WindowsAPI.RegisterHotKey(this.Handle, h), HotKey = h })
            .ToList()
            .ForEach(r => Log.Write($"热键注册：【{r.HotKey.Modifier}+{r.HotKey.Key}:{r.Res}】"));


            var res = WindowsAPI.AddClipboardFormatListener(this.Handle);
            Log.Write($"添加剪切板监听：【{res}】");
        }

        private MainForm _form;


        private MainForm DetailForm
        {
            get
            {
                if (_form?.IsDisposed ?? true)
                    _form = new MainForm();
                return _form;
            }
        }



        public Edge TaskbarEdge { get; set; }


        public event EventHandler ClipboardUpdate;

        public void OnClipboardUpdate()
        {
            ClipboardUpdate?.Invoke(this, null);

            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                text = text.Trim();
                if (string.IsNullOrEmpty(text))
                    return;
                var res = BaiduTranslate.Translate(text);
                if (res != null && res.error_code == null)
                {
                    var str = string.Join(Environment.NewLine, res.trans_result.Select(r => r.dst));
                    this.txt_Key.Text = str;
                    DetailForm.TxtKey.Text = text;
                    DetailForm.TxtDetail.Text = str;
                }
            }
        }


        private int lastTickCount;


        const int WM_CLIPBOARDUPDATE = 0x031D;
        const int WM_HOTKEY = 0x0312; //如果m.Msg的值为0x0312那么表示用户按下了热键

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                var key = (Keys)((m.LParam.ToInt32() >> 16) & 0xFFFF);
                var flag = (KeyModifiers)(m.LParam.ToInt32() & 0xFFFF);
                Log.Write($"热键触发:【{key}+{flag}】");

                if (flag == KeyModifiers.Control)
                {
                    if (key == Keys.W)
                    {
                        DetailForm.ShowOrHide(this.TaskbarEdge, this.PointToScreen(Point.Empty), this.Size);
                    }
                    else if (key == Keys.Q)
                    {
                        if (DetailForm.Visible)
                        {
                            DetailForm.Activate();
                            DetailForm.TxtKey.Text = "";
                            DetailForm.TxtKey.Focus();
                        }
                        else
                        {
                            WindowsAPI.SetForeground("Shell_TrayWnd");
                            this.Focus();
                            txt_Key.Text = "";
                            txt_Key.Focus();
                        }
                    }
                }
            }
            else if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (Environment.TickCount - this.lastTickCount >= 200)
                    OnClipboardUpdate();
                this.lastTickCount = Environment.TickCount;
                m.Result = IntPtr.Zero;
            }
            base.WndProc(ref m);
        }

        public new void Dispose()
        {
            Log.Write("开始释放");

            DetailForm?.Close();
            DetailForm?.Dispose();

            var res = WindowsAPI.RemoveClipboardFormatListener(this.Handle);
            Log.Write($"删除剪切板监听：【{res}】");

            new HotKey[]
            {
                new HotKey(Keys.W, KeyModifiers.Control),//打开详情
                new HotKey(Keys.Q, KeyModifiers.Control),//输入
                new HotKey(Keys.B, KeyModifiers.Control),//百度
                new HotKey(Keys.G, KeyModifiers.Control),//谷歌
            }
            .Select(h => new { Res = WindowsAPI.UnregisterHotKey(this.Handle, h), HotKey = h })
            .ToList()
            .ForEach(r => Log.Write($"热键注销：【{r.HotKey.Modifier}+{r.HotKey.Key}:{r.Res}】"));

            base.Dispose();
        }


        private void MainControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                var text = txt_Key.Text.Trim();
                if (string.IsNullOrEmpty(text))
                    return;
                var res = BaiduTranslate.Translate(text);
                if (res != null && res.error_code == null)
                {
                    var str = string.Join(Environment.NewLine, res.trans_result.Select(r => r.dst));
                    this.txt_Key.Text = str;
                    DetailForm.TxtKey.Text = text;
                    DetailForm.TxtDetail.Text = str;
                }
            }
        }


    }
}
