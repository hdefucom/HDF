
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using SharpDX.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_SharpDX : Form
    {


        public Form_SharpDX()
        {
            InitializeComponent();

            //this.DoubleBuffered = true;


            hwndRenderControl = new RenderControl();
            hwndRenderControl.Dock = DockStyle.Fill;
            this.Controls.Add(hwndRenderControl);

            hwndRenderControl.BringToFront();


            // 创建 Direct2D 单线程工厂。
            Factory factory = new Factory(FactoryType.SingleThreaded);
            // 渲染参数。
            RenderTargetProperties renderProps = new RenderTargetProperties
            {
                //PixelFormat = D2PixelFormat,
                Usage = RenderTargetUsage.None,
                Type = RenderTargetType.Default
            };

            // 渲染目标属性。
            HwndRenderTargetProperties hwndProps = new HwndRenderTargetProperties()
            {
                // 承载控件的句柄。
                Hwnd = hwndRenderControl.Handle,
                // 控件的尺寸。
                PixelSize = new Size2(hwndRenderControl.ClientSize.Width, hwndRenderControl.ClientSize.Height),
                PresentOptions = PresentOptions.None
            };
            // 渲染目标。
            hwndRenderTarget = new WindowRenderTarget(factory, renderProps, hwndProps)
            {
                AntialiasMode = AntialiasMode.PerPrimitive
            };




            hwndRenderControl.Paint += (_, e) =>
            {

                e.Graphics.DrawString("h啊速度hi发sad😂😂😂", new System.Drawing.Font("Segoe UI Emoji", 50f), Brushes.Black, 0, 200);

            };
        }


        RenderControl hwndRenderControl;


        WindowRenderTarget hwndRenderTarget;


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (hwndRenderControl == null)
                return;
            hwndRenderTarget.Resize(new Size2(hwndRenderControl.ClientSize.Width, hwndRenderControl.ClientSize.Height));
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Stopwatch s = new Stopwatch();

            s.Start();

            hwndRenderTarget.BeginDraw();
            hwndRenderTarget.Clear(new RawColor4(this.BackColor.R, this.BackColor.G, this.BackColor.B, 255));



            for (int i = 0; i < 1; i++)
                hwndRenderTarget.DrawText("h啊速度hi发sad😂😂😂",
                    new SharpDX.DirectWrite.TextFormat(new SharpDX.DirectWrite.Factory(), "Segoe UI Emoji", 50f),
                    new RawRectangleF(0, 0, 1000, 1000),
                    new SolidColorBrush(hwndRenderTarget, new RawColor4(0, 0, 0, 255)),
                    DrawTextOptions.EnableColorFont //启用彩色emoji的关键
                    );

            hwndRenderTarget.EndDraw();
            s.Stop();

            hwndRenderControl.Invalidate();

            Console.WriteLine(s.ElapsedMilliseconds);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }







}
