using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

            label1.Text = GetCaretBlinkTime() + "毫秒";//显示光标闪烁频率

        }
        //重写API函数
        [DllImport("user32", EntryPoint = "GetCaretBlinkTime")]
        public extern static int GetCaretBlinkTime();


        private void button1_Click(object sender, EventArgs e)
        {
            if (this.CaretCreate(0, 10, 100))
                label1.Text = "光标创建成功";
            else
                label1.Text = "光标创建失败";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CaretShow();
            label1.Text = "显示光标";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.CaretHide();
            label1.Text = "光标隐藏";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.CaretDestroy();
            label1.Text = "光标销毁";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.CaretSetPos(200, 100);
            label1.Text = "设置光标坐标位置【200,100】";

        }


        Form6 ffff = new Form6();
        private void button6_Click(object sender, EventArgs e)
        {
            ffff.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            ffff.Hide();
        }
    }
    public static class EditorCaretExtend
    {
        /// <summary>
        /// 创建光标对象
        /// </summary>
        /// <param name="win"></param>
        /// <param name="bitmap">图片句柄</param>
        /// <param name="width">光标宽度</param>
        /// <param name="height">光标高度</param>
        /// <returns>操作是否成功</returns>
        public static bool CaretCreate(this IWin32Window win, int bitmap, int width, int height) => win == null ? false : CreateCaret(win.Handle, bitmap, width, height);

        /// <summary>
        /// 设置光标位置
        /// </summary>
        /// <param name="win"></param>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <returns>操作是否成功</returns>
        public static bool CaretSetPos(this IWin32Window win, int x, int y) => win == null ? false : SetCaretPos(x, y);

        /// <summary>
        /// 显示光标
        /// </summary>
        /// <returns>操作是否成功</returns>
        public static bool CaretShow(this IWin32Window win) => win == null ? false : ShowCaret(win.Handle);

        /// <summary>
        /// 隐藏光标
        /// </summary>
        /// <returns>操作是否成功</returns>
        public static bool CaretHide(this IWin32Window win) => win == null ? false : HideCaret(win.Handle);

        /// <summary>
        /// 删除光标
        /// </summary>
        /// <returns>操作是否成功</returns>
        public static bool CaretDestroy(this IWin32Window win) => DestroyCaret();


        #region Windows API

        [DllImport("user32.dll")]
        private static extern bool CreateCaret(IntPtr handle, int bitmap, int width, int height);

        [DllImport("user32.dll")]
        private static extern bool SetCaretPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern bool DestroyCaret();

        [DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr handle);

        #endregion





    }





}
