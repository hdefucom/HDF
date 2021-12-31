using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_AnimateWindow : Form
    {


        //使用Windows Api AnimateWindow
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_HOR_POSITIVE = 0x00000001;//从左向右显示
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;//从右到左显示
        public const Int32 AW_VER_POSITIVE = 0x00000004;//从上到下显示
        public const Int32 AW_VER_NEGATIVE = 0x00000008;//从下到上显示
        public const Int32 AW_CENTER = 0x00000010;//若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口
        public const Int32 AW_HIDE = 0x00010000;//隐藏窗口，缺省则显示窗口
        public const Int32 AW_ACTIVATE = 0x00020000;//激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        public const Int32 AW_SLIDE = 0x00040000;//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        public const Int32 AW_BLEND = 0x00080000;//透明度从高到低



        public Form_AnimateWindow()
        {
            InitializeComponent();

            //设置窗体的样式为无边框
            this.FormBorderStyle = FormBorderStyle.None;
            //获取屏幕工作区域
            Rectangle rectWork = Screen.GetWorkingArea(this);
            //设置窗体的位置为右下角
            this.Location = new Point(rectWork.Width - this.Width, rectWork.Height - this.Height);
            //窗体的位置由Location属性确定
            //this.StartPosition = FormStartPosition.Manual;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //调用方法实现显示效果
            AnimateWindow(this.Handle, 500, AW_VER_NEGATIVE + AW_VER_POSITIVE); // 自下向上。

        }


    }




}
