using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_WindowsMessage_Key : Form
    {
        public Form_WindowsMessage_Key()
        {
            InitializeComponent();

            //this.DoubleBuffered = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            testPanel1.Invalidate();
        }

    }




    public class TestPanel : ScrollableControl
    {
        public TestPanel()
        {
            SetStyle(ControlStyles.Selectable, true);
            this.DoubleBuffered = true;
            this.AutoScrollMinSize = new Size(200, 400);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1; i++)
            {
                e.Graphics.DrawString("HDF", this.Font, Brushes.Black, new Point(10, 10));
            }
            watch.Stop();
            Debug.WriteLine("aaaaaaaa:" + watch.ElapsedMilliseconds);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }



        /*
         OnPreviewKeyDown
        ---------------------------

         ProcessCmdKey
         IsInputKey
         ProcessDialogKey

         IsInputKey
         OnKeyDown

        ---------------------------

         IsInputChar
         ProcessDialogChar

         IsInputChar
         OnKeyPress

        ----------------------------
         OnKeyUp

         */

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Debug.WriteLine($"OnKeyDown==>KeyCode:{e.KeyCode},,,KeyData:{e.KeyData},,,KeyValue:{e.KeyValue}");
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Debug.WriteLine($"OnKeyPress==>KeyChar:{e.KeyChar}");
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        private static readonly Keys[] inputKeys = {
            Keys.Left,
            Keys.Up,
            Keys.Right,
            Keys.Down,
            Keys.Tab,
            Keys.Enter,
            //Keys.ShiftKey,
            Keys.Shift,
            Keys.Control,
        };


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Debug.WriteLine($"ProcessCmdKey==>keyData:{keyData}");
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            Debug.WriteLine($"ProcessDialogKey==>keyData:{keyData}");
            if (keyData == Keys.Tab && !false)
                return base.ProcessDialogKey(keyData);
            //foreach (var item in inputKeys)
            //{
            //    if ((keyData & item) == item)
            //        return true;
            //}
            return base.ProcessDialogKey(keyData);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            Debug.WriteLine($"IsInputKey==>keyData:{keyData}");
            return base.IsInputKey(keyData);
        }

        protected override bool ProcessDialogChar(char charCode)
        {
            Debug.WriteLine($"ProcessDialogChar==>charCode:{charCode}");
            return base.ProcessDialogChar(charCode);
        }

        protected override bool IsInputChar(char charCode)
        {
            Debug.WriteLine($"IsInputChar==>charCode:{charCode}");

            foreach (var item in inputKeys)
            {
                if (((int)charCode & (int)item) == (int)item)
                    return false;
            }
            return base.IsInputChar(charCode);
        }


        /// <summary>
        /// 是否结束输入法中文输入
        /// </summary>
        private bool IMEInsertIsEnd = true;
        /// <summary>
        /// 中文输入法输入文字
        /// </summary>
        private string IMEInsertString;

        protected override void WndProc(ref Message m)
        {
            //该方法目的：
            //1.拼音输入字符，会拦截键盘消息然后一次性发送，导致界面字符刷新有延迟，此方法拦截后一次插入文档，不会有明显延迟
            //2.输入法模式问题，例如微软拼音输入时，拼音会展示在输入框，并且会触发插入字符，而有些输入法会拦截消息，将拼音展示在自己的GUI界面上，输入框为空
            //Debug.WriteLine(m.Msg);
            const int WM_IME_ENDCOMPOSITION = 0x010E; // //组合键输入结束
            const int WM_IME_COMPOSITION = 0x010F; // 组合键输入开始

            switch (m.Msg)
            {
                case WM_IME_COMPOSITION:
                    IMEInsertIsEnd = false;
                    IMEInsertString = string.Empty;
                    break;
                case WM_IME_ENDCOMPOSITION:
                    Debug.WriteLine($"WndProc==>{IMEInsertString}");
                    IMEInsertString = string.Empty;
                    IMEInsertIsEnd = true;
                    break;
            }
            base.WndProc(ref m);
        }

    }


















}
