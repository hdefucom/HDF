using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gocent.GTCMCDS.WinClient.Utils
{
    public static class FormShiftPosition
    {
        /// <summary>
        /// 绑定移动窗体位置的控件
        /// 请勿传入Form本身
        /// </summary>
        /// <param name="controls"></param>
        public static void BindShiftPosition(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;
            }
        }

        private static Dictionary<Form, Point> dict = new Dictionary<Form, Point>();



        private static void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;

            var form = c.FindForm();
            if (form == null)
                throw new Exception("请先把控件绑定到窗体");

            //dict.TryAddOrUpdate(form, new Point(-e.X - c.Location.X, -e.Y - c.Location.Y));
            if (dict.ContainsKey(form))
            {
                dict[form] = new Point(-e.X - c.Location.X, -e.Y - c.Location.Y);
            }
            else
            {
                dict.Add(form, new Point(-e.X - c.Location.X, -e.Y - c.Location.Y));
            }
        }
        private static void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Point newPoint = Control.MousePosition;

            var form = ((Control)sender).FindForm();
            if (form == null)
                throw new Exception("请先把控件绑定到窗体");

            newPoint.Offset(dict[form]);

            form.Location = newPoint;
        }


        public static class WindowsApi
        {
            private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
            private const int HTCLIENT = 0x1;
            private const int HTCAPTION = 0x2;



            /// <summary>
            /// 设置鼠标拖动客户区移动位置
            /// 重写WndProc，在base.WndProc()后调用
            /// </summary>
            /// <param name="m"></param>
            public static void SetDrag(ref Message m)
            {
                //1鼠标位置为客户区
                //2鼠标位置为标题栏
                if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                    m.Result = (IntPtr)HTCAPTION;
            }

        }

    }



}