using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Win32API
{
    /// <summary>
    /// //MessageFilter 也是一种实现方法，但是这样之后，控件之外的窗体事件也被屏蔽了，不好
        //可以使用 WndProc(ref Message m) 
        //但是发现以前是用bolLockingUI 实现的，所以沿用以前方法
    /// </summary>
    class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_RBUTTONDBLCLK = 0x206;
            const int WM_RBUTTONDOWN = 0x204;
            const int WM_RBUTTONUP = 0x205;
            const int WM_KEYDOWN = 0x100;
            const int WM_LBUTTONDBLCLK=0x203;
            switch (m.Msg)
            {
                //过滤掉所有与右键有关的消息 
                case WM_RBUTTONDBLCLK:
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                    //左键双击
                case WM_LBUTTONDBLCLK:
                        return true;
                        break;
                
                case WM_KEYDOWN: //有键盘按下
                        return true;
                        break;
                default:
                        return false;
            }
        }

        //MessageFilter filter = new MessageFilter();
        //Application.AddMessageFilter(filter);
        ////Application.EnableVisualStyles();
        ////Application.SetCompatibleTextRenderingDefault(true);
        //Application.RemoveMessageFilter(filter); 

    }

    /// <summary>
    /// //过滤鼠标键盘事件
    /// </summary>
    /// <param name="m"></param>
    //protected override void WndProc(ref Message m)
    //{
    //    if (bolLockingUI) return ;
            //    const int WM_RBUTTONDBLCLK = 0x206;
            //const int WM_RBUTTONDOWN = 0x204;
            //const int WM_RBUTTONUP = 0x205;
            //const int WM_KEYDOWN = 0x100;
            //const int WM_LBUTTONDBLCLK = 0x203;
    //    if (this.EMRDoc != null ) 
    //    {
    //        if(this.EMRDoc.Info.DocumentModel == DocumentModel.Clear || this.EMRDoc.Info.DocumentModel == DocumentModel.Read)
    //        switch (m.Msg)
    //        {
    //            //过滤掉所有与右键有关的消息 
    //            case WM_RBUTTONDBLCLK:
    //            case WM_RBUTTONDOWN:
    //            case WM_RBUTTONUP:
    //            //左键双击
    //            case WM_LBUTTONDBLCLK:
    //                return;

    //            case WM_KEYDOWN: //有键盘按下
    //                return;
    //        }
    //    }

    //    base.WndProc(ref m);
    //}
}
