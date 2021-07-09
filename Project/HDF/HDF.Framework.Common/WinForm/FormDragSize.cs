using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Common.WinForm
{
    public static class FormDragSize
    {
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


        public static void SetDragSize(this Form form, ref Message m, bool isSetDragPostion = false)
        {


            if (form.FormBorderStyle != FormBorderStyle.None)
                return;
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    //必须最后转成int16，多屏幕情况下坐标可能是负数，位运算得到结果是int16，如果使用int32，就无法使溢出的int16得到正确的坐标
                    Point vPoint = new Point(
                        (Int16)((int)m.LParam & 0xFFFF),
                        (Int16)((int)m.LParam >> 16 & 0xFFFF)
                        );
                    vPoint = form.PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= form.ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= form.ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= form.ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= form.ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    else if (isSetDragPostion && (int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    break;
            }

        }
    }
}
