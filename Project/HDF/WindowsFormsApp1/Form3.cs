using DevExpress.XtraEditors;
using Gocent.GTCMCDS.WinClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : XtraForm
    {
        public Form3()
        {
            InitializeComponent();
            FormPrintShadow.SetShadows(this);//弹窗边框阴影效果
        }

        #region 模拟窗体的大小缩放
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;      //左边界
        const int HTRIGHT = 11;     //右边界
        const int HTTOP = 12;       //上边界
        const int HTTOPLEFT = 13;   //左上角
        const int HTTOPRIGHT = 14;  //右上角
        const int HTBOTTOM = 15;    //下边界
        const int HTBOTTOMLEFT = 0x10;    //左下角
        const int HTBOTTOMRIGHT = 17;     //右下角



        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


            if (this.FormBorderStyle != FormBorderStyle.None)
                return;
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    Point vPoint = new Point(
                        (Int16)m.LParam,
                        (Int16)(m.LParam.ToInt32() >> 16)
                        );
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    else if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;


                    break;
            }
        }


        #endregion



    }
}
