using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Gocent.Library.Editor.Controls
{
    /// <summary>
    ///       带边框的用户控件对象
    ///       </summary>
    /// <remarks>本控件在UserControl的基础上实现了标准下陷的控件边框,并支持滚动事件
    ///       新增属性 BorderStyle 可让控件不显示边框,显示简单的细边框或3D下陷式的粗边框 
    ///       新增事件 Scroll ,当用户滚动控件时会触发该事件</remarks>
    //[Guid("00012345-6789-ABCD-EF01-234567890007")]
    [Browsable(false)]
    [ToolboxItem(false)]
    public class BorderUserControl : UserControl
    {
        private Bitmap _bitmap = null;

        private EventHandler _handler = null;

        private bool bool_1 = false;

        /// <summary>
        /// 启动双缓冲样式
        /// </summary>
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("启动双缓冲样式")]
        public bool DoubleBuffering
        {
            get
            {
                return GetStyle(ControlStyles.DoubleBuffer);
            }
            set
            {
                if (GetStyle(ControlStyles.DoubleBuffer) == value)
                    return;

                if (value)
                {
                    SetStyle(ControlStyles.UserPaint, value: true);
                    SetStyle(ControlStyles.DoubleBuffer, value: true);
                    SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
                }
                else
                {
                    SetStyle(ControlStyles.DoubleBuffer, value: false);
                }
                UpdateStyles();
                Invalidate();

            }
        }

        /// <summary>
        /// 正在冻结用户界面
        /// </summary>
        [Browsable(false)]
        public bool IsFreezeUI => _bitmap != null;

        /// <summary>
        /// 发生滚动时的处理
        /// </summary>
        public event EventHandler XScroll;

        /// <summary>
        /// 初始化对象
        /// </summary>
        public BorderUserControl()
        {
            AutoScroll = true;
            SetStyle(ControlStyles.ResizeRedraw, value: true);
            SetStyle(ControlStyles.Selectable, value: true);

            if (this.DoubleBuffering)
            {
                SetStyle(ControlStyles.UserPaint, value: true);
                SetStyle(ControlStyles.DoubleBuffer, value: true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
            }
        }

        /// <summary>
        /// 冻结用户界面
        /// </summary>
        public void FreezeUI()
        {
            if (_bitmap == null)
            {
                Bitmap image = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.Clear(BackColor);
                    PaintEventArgs e = new PaintEventArgs(graphics, new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height));
                    OnPaint(e);
                }
                _bitmap = image;
            }
        }

        /// <summary>
        /// 解冻用户界面
        /// </summary>
        public void UnFreezeUI()
        {
            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
                Invalidate();
            }
        }

        protected void Render(PaintEventArgs args)
        {
            if (_bitmap != null)
            {
                args.Graphics.DrawImage(_bitmap,
                    args.ClipRectangle.Left,
                    args.ClipRectangle.Top,
                    new RectangleF(args.ClipRectangle.Left, args.ClipRectangle.Top, args.ClipRectangle.Width, args.ClipRectangle.Height),
                    GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// 绘制控件内容
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnPaint(PaintEventArgs args)
        {
            if (IsFreezeUI)
                Render(args);
            else
                base.OnPaint(args);
        }

        /// <summary>
        /// 销毁对象
        /// </summary>
        /// <param name="disposing">
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
            }
            base.Dispose(disposing);
        }



        protected virtual void OnXScroll() => XScroll?.Invoke(this, null);

        /// <summary>
        /// 用于键盘滚动视图
        /// </summary>
        public void CallOnXScroll() => OnXScroll();


        public void SetHScroll(bool flag) => base.HScroll = flag;
        public void SetVScroll(bool flag) => base.VScroll = flag;


        /// <summary>
        /// 已重载:处理Windows底层消息,此处用于判断是否触发 Scroll 滚动事件
        /// </summary>
        /// <param name="m">Windows消息结构体</param>
        protected override void WndProc(ref Message msg)
        {
            if (!base.IsHandleCreated)
            {
                base.WndProc(ref msg);
                return;
            }
            if (msg.Msg == 522)
            {
                OnXScroll();
            }
            else if (msg.HWnd == base.Handle)
            {

                if (msg.Msg == 276 || msg.Msg == 277)
                {
                    int num = msg.WParam.ToInt32();
                    if ((num & 0xF) == 5)
                    {
                        base.WndProc(ref msg);
                        if (!bool_1)
                        {
                            num--;
                            msg.WParam = new IntPtr(num);
                            base.WndProc(ref msg);
                        }
                        OnXScroll();
                    }
                    else
                    {
                        base.WndProc(ref msg);
                        OnXScroll();
                    }
                    return;
                }
                if (msg.Msg == 15)
                {
                }
            }
            base.WndProc(ref msg);
        }

        protected override void OnHandleCreated(EventArgs eventArgs_0)
        {
            bool_1 = smethod_1();

            base.OnHandleCreated(eventArgs_0);
        }


        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern bool SystemParametersInfo_2(uint genum67_0, uint uint_0, ref bool bool_0, uint uint_1);

        public static bool smethod_1()
        {
            bool bool_ = false;
            if (SystemParametersInfo_2(38u, 0u, ref bool_, 0u))
            {
                return bool_;
            }
            return false;
        }
    }
}
