using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;

namespace WinFormsApp1
{
    public partial class Form_DrawReversible2 : Form
    {
        public Form_DrawReversible2()
        {
            InitializeComponent();

            this.DoubleBuffered = true;



        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }





        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            Draw(new Rectangle(e.X - 10, e.Y - 10, 20, 20));

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);


            if (e.Button != MouseButtons.Left)
                return;


            if (!LastRect.IsEmpty)
                Draw(LastRect);

            Draw(new Rectangle(e.X - 10, e.Y - 10, 20, 20));

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left || LastRect.IsEmpty)
                return;
            Draw(LastRect);
        }

        Rectangle LastRect;


        private void Draw(Rectangle rect)
        {
            LastRect = rect;
            rect = this.RectangleToScreen(rect);

            ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);

            ////当前窗体的句柄
            //var hwnd = this.Handle;

            ////窗体DC
            //var hdc = GetDC(hwnd);

            ////创建画笔
            //var pen = CreatePen(2, 1, ColorTranslator.ToWin32(Color.Red));

            //int old = SetROP2(hdc, 7);

            //var NULL_BRUSH = GetStockObject(5);

            //IntPtr oldb = SelectObject(hdc, NULL_BRUSH);
            //IntPtr penobj = SelectObject(hdc, pen);

            //Rectangle(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom);

            //SelectObject(hdc, oldb);
            //SelectObject(hdc, penobj);

            //SetROP2(hdc, old);



            //ReleaseDC(hwnd, hdc);

            //DeleteObject(pen);


            //LastRect = rect;

        }



        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);



            //var p = this.PointToClient(MousePosition);

            //e.Graphics.DrawLine(Pens.Black, p.X, 0, p.X, this.Height);
            //e.Graphics.DrawLine(Pens.Black, 0, p.Y, this.Width, p.Y);


        }



        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern bool DeleteDC(IntPtr hDC);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateDC(string strDriver, string strDevice, int Output, int InitData);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);




        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern int DeleteObject(System.IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern int SetROP2(System.IntPtr hDC, int DrawMode);


        [DllImport("gdi32")]
        private static extern IntPtr GetStockObject(int fnObject);

        private enum _StockObjectType
        {
            WHITE_BRUSH = 0,
            LTGRAY_BRUSH = 1,
            GRAY_BRUSH = 2,
            DKGRAY_BRUSH = 3,
            BLACK_BRUSH = 4,
            NULL_BRUSH = 5,
            HOLLOW_BRUSH = 5,
            WHITE_PEN = 6,
            BLACK_PEN = 7,
            NULL_PEN = 8,
            OEM_FIXED_FONT = 10,
            ANSI_FIXED_FONT = 11,
            ANSI_VAR_FONT = 12,
            SYSTEM_FONT = 13,
            DEVICE_DEFAULT_FONT = 14,
            DEFAULT_PALETTE = 15,
            SYSTEM_FIXED_FONT = 16,
            DEFAULT_GUI_FONT = 17,
            DC_BRUSH = 18,
            DC_PEN = 19
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern bool Rectangle(System.IntPtr hDC, int left, int top, int right, int bottom);


        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreatePen(int PenStyle, int Width, int Color);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern bool LineTo(IntPtr hDC, int X, int Y);

    }

















}
