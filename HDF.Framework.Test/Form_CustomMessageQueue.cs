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
    public partial class Form_CustomMessageQueue : Form
    {
        public Form_CustomMessageQueue()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myMsgQueue = new CustomMessageQueue();
            myMsgQueue.StartThread();
            myMsgQueue.PerTranslateMessage = new CustomMessageQueue.PerTranslateMessageHandler(CustomMessageProc);

        }



        private CustomMessageQueue myMsgQueue;
        private bool CustomMessageProc(ref CustomMessage m)
        {
            if (m.Message == 1)
            {
                MessageBox.Show("我拦截到 id = 1 的消息了。并且，就到此为止了。呵呵");
                return true;
            }
            else
            {
                MessageBox.Show(m.Message.ToString());
            }
            return false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CustomMessage msg = new CustomMessage();
            msg.Message = 1;
            msg.param = "我的自定义消息 ID:1";
            CustomMessageQueue.PostMessage(ref myMsgQueue, ref msg);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CustomMessage msg = new CustomMessage();
            msg.Message = 2;
            myMsgQueue.PostMessage(ref msg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myMsgQueue.PostQuitMessage();
        }
    }

    #region 自定义消息队列线程
    public struct CustomMessage
    {
        public int Message;
        public Object param;
    }

    public class CustomMessageQueue
    {
        private System.Threading.Thread th;
        public CustomMessage Msg = new CustomMessage();
        public delegate bool PerTranslateMessageHandler(ref CustomMessage m);
        public PerTranslateMessageHandler PerTranslateMessage;

        public static void PostMessage(ref CustomMessageQueue msgQueue, ref CustomMessage m)
        {
            msgQueue.Msg = m;
            System.Threading.Monitor.Enter(msgQueue);
            System.Threading.Monitor.Pulse(msgQueue);
            System.Threading.Monitor.Exit(msgQueue);
        }

        public void PostMessage(ref CustomMessage m)
        {
            Msg = m;
            System.Threading.Monitor.Enter(this);
            System.Threading.Monitor.Pulse(this);
            System.Threading.Monitor.Exit(this);
        }

        public void PostQuitMessage()
        {
            Msg.Message = -1;
            System.Threading.Monitor.Enter(this);
            System.Threading.Monitor.Pulse(this);
            System.Threading.Monitor.Exit(this);
        }

        private void ThreadProc()
        {
            while (Msg.Message != -1) //enum -1 for exit thread
            {
                if (Msg.Message != 0)
                {
                    if (PerTranslateMessage != null)
                    {
                        if (PerTranslateMessage.Invoke(ref Msg))
                        {
                            Msg.Message = 0; //Set message to unused
                            System.Threading.Monitor.Enter(this);
                            System.Threading.Monitor.Wait(this);
                            System.Threading.Monitor.Exit(this);
                            continue;
                        }
                    }
                    DefaultMessageTranslate();
                }
                System.Threading.Monitor.Enter(this);
                System.Threading.Monitor.Wait(this);
                System.Threading.Monitor.Exit(this);
            }
        }

        private void DefaultMessageTranslate()
        {
            //以下可以定义默认的消息处理，可以封装成自己要用的
            switch (Msg.Message)
            {
                case 1: //我自己定义，1表示显示消息号或消息的解释
                    if (Msg.param != null)
                    {
                        if (Msg.param is string)
                        {
                            MessageBox.Show(Msg.param as string);
                        }
                    }
                    else
                    {
                        string strMsg = string.Format("{0:d}", Msg.Message);
                        MessageBox.Show(strMsg);
                    }
                    break;
            }
            Msg.Message = 0; //Set message to unused
        }

        public CustomMessageQueue()
        {
            th = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            PerTranslateMessage = null;
        }

        public void StartThread()
        {
            try
            {
                th.Start();
            }
            catch
            {
                int nLayer = GC.GetGeneration(th);
                GC.Collect(nLayer);
                th = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                th.Start();
            }
        }
    }
    #endregion





































}
