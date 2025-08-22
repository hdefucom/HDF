using HDF.Common.Windows;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            height = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;


            InitializeComponent();



        }



        int height;




        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);






        protected override CreateParams CreateParams
        {
            get
            {

                var cp = base.CreateParams;


                // Use unchecked to handle the constant value that exceeds the range of int
                //cp.Style |= unchecked((int)0x40000000L);//0x40000000L


                //cp.Param = this.Handle;




                return cp;
            }
        }



        private int lastTickCount;//防止api调用过快，
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x031D)//WM_CLIPBOARDUPDATE
            {
                if (Environment.TickCount - this.lastTickCount >= 200)
                    OnClipboardUpdate();
                this.lastTickCount = Environment.TickCount;
                m.Result = IntPtr.Zero;
            }
            else if (m.Msg != 0xA3)
                base.WndProc(ref m);

            this.SetDragPosition(ref m);
        }


        public void OnClipboardUpdate()
        {
            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                text = text.Trim();
                if (string.IsNullOrEmpty(text))
                    return;
                if (text.Length > 1000)
                    text = text.Substring(0, 1000);
                try
                {
                    textBox1.Text = text;
                }
                catch (Exception ex)
                {
                    textBox1.Text = "又出Bug了！~(￣▽￣)~*";
                    //txt_Target.Text = ex.ToString();
                }
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            var parent = FindWindow("Shell_TrayWnd", null);

            //cp.Parent = parent;

            SetParent(this.Handle, parent);



            SetWindowPos(this.Handle, new IntPtr(0), 500, 0,
                this.Width, height, 0x2000);

            this.TopMost = true;


            AddClipboardFormatListener(this.Handle);


        }



        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            RemoveClipboardFormatListener(this.Handle);
        }



        /// <summary>
        /// 添加剪切板监听
        /// </summary>
        /// <param name="hwnd">关联的</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// 移除剪切板监听
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);



    }
}
