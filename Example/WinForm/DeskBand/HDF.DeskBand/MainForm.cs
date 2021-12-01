using CSDeskBand;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HDF.DeskBand
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetShadows(this);
        }

        #region 边框阴影

        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        [DllImport("dwmapi.dll")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public static void SetShadows(Form form)
        {
            if (form.FormBorderStyle != FormBorderStyle.None)
                return;

            var v = 2;

            DwmSetWindowAttribute(form.Handle, 2, ref v, 4);

            MARGINS margins = new MARGINS()
            {
                bottomHeight = 1,
                leftWidth = 0,
                rightWidth = 0,
                topHeight = 0
            };

            DwmExtendFrameIntoClientArea(form.Handle, ref margins);
        }

        #endregion

        #region 窗口控制

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //case 0x4e:
                //case 0xd:
                //case 0xe:
                //case 0x14:
                //    base.WndProc(ref m);
                //    break;
                case 0x84://鼠标点任意位置后可以拖动窗体
                    this.DefWndProc(ref m);
                    if (m.Result.ToInt32() == 0x01)
                    {
                        m.Result = new IntPtr(0x02);
                    }
                    break;
                case 0xA3://禁止双击最大化
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            if (!IsFixed)
                this.Visible = false;
        }

        #endregion


        public bool IsFixed => cb_Fixed.Checked;

        public TextBox TxtKey => txt_Key;
        public TextBox TxtDetail => txt_Target;




        public void ShowOrHide(Edge edge, Point p, Size s)
        {
            this.Visible = !this.Visible;
            if (this.Visible)
            {
                switch (edge)
                {
                    case Edge.Left:
                        this.Left = s.Width;
                        this.Top = p.Y - this.Height;
                        break;
                    case Edge.Top:
                        this.Left = p.X + s.Width - this.Width;
                        this.Top = s.Height;
                        break;
                    case Edge.Right:
                        this.Left = p.X - this.Width;
                        this.Top = p.Y - this.Height;
                        break;
                    case Edge.Bottom:
                        this.Left = p.X + s.Width - this.Width;
                        this.Top = p.Y - this.Height;
                        break;
                }
                this.Activate();
                this.Focus();
                this.TxtKey.Focus();
            }
        }


        private void txt_Key_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var str = txt_Key.Text.Trim();
                if (string.IsNullOrEmpty(str))
                    return;

                Clipboard.SetText(str);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Visible = !this.Visible;
            }
        }






    }
}
