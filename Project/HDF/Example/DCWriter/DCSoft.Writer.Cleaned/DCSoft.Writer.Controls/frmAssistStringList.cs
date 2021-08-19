using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
    /// <summary>
    ///       显示辅助输入的窗口,DCWriter内部使用。
    ///       </summary>
    [ComVisible(false)]
    internal class frmAssistStringList : GForm0, GInterface19
    {
        private GClass124 gclass124_0;

        private GClass124 gclass124_1;

        private volatile string string_0;

        private bool bool_4;

        private WriterControl writerControl_0;

        private GControl5 gcontrol5_0;

        private static volatile List<string> list_0 = new List<string>();

        private volatile XTextElement xtextElement_0;

        private volatile XTextContainerElement xtextContainerElement_0;

        private volatile bool bool_5;

        private volatile int int_0;

        private bool bool_6;

        /// <summary>
        ///       字典条码个数
        ///       </summary>
        public int Count => list_0.Count;

        /// <summary>
        ///       正在加载列表
        ///       </summary>
        public bool LoadingList => bool_5;

        /// <summary>
        ///       初始化对象
        ///       </summary>
        internal frmAssistStringList(WriterControl writerControl_1)
        {
            int num = 10;
            gclass124_0 = null;
            gclass124_1 = null;
            string_0 = null;
            bool_4 = false;
            writerControl_0 = null;
            gcontrol5_0 = null;
            xtextElement_0 = null;
            xtextContainerElement_0 = null;
            bool_5 = false;
            int_0 = 0;
            bool_6 = false;
            //
            if (writerControl_1 == null)
            {
                throw new ArgumentNullException("ctl");
            }
            writerControl_0 = writerControl_1;
            gcontrol5_0 = new GControl5();
            gcontrol5_0.Dock = DockStyle.Fill;
            gcontrol5_0.method_28(bool_14: false);
            gcontrol5_0.method_15(bool_14: false);
            gcontrol5_0.vmethod_7(bool_14: false);
            gcontrol5_0.method_110(bool_14: false);
            gcontrol5_0.method_11(bool_14: false);
            gcontrol5_0.method_21(method_26);
            gcontrol5_0.method_125(bool_14: false);
            base.Controls.Add(gcontrol5_0);
            method_15(writerControl_1);
            gclass124_1 = new GClass124();
            gclass124_1.method_3(writerControl_0);
            GClass124 gClass = gclass124_1;
            gClass.method_9((GDelegate7)Delegate.Combine(gClass.method_8(), new GDelegate7(method_25)));
            GClass124 gClass2 = gclass124_1;
            gClass2.method_11((GDelegate7)Delegate.Combine(gClass2.method_10(), new GDelegate7(method_24)));
        }

        private void method_24(object object_0, GClass125 gclass125_0)
        {
            if (writerControl_0 != null && writerControl_0.InnerViewControl != null)
            {
                List<string> list = gclass125_0.method_1() as List<string>;
                if (list != null && list.Count > 0)
                {
                    bool_5 = true;
                    try
                    {
                        writerControl_0.InnerViewControl.method_226(gcontrol5_0, bool_47: true);
                        gcontrol5_0.method_8().Clear();
                        foreach (string item in list)
                        {
                            GClass290 gClass = new GClass290();
                            gClass.method_3(item);
                            gClass.method_42(bool_5: false);
                            gcontrol5_0.method_8().Add(gClass);
                        }
                        gcontrol5_0.method_68(-1);
                        gcontrol5_0.method_97();
                        Size preferredSize = gcontrol5_0.GetPreferredSize(Size.Empty);
                        preferredSize.Height = Math.Min(preferredSize.Height, (int)((double)Screen.GetWorkingArea(writerControl_0).Height * 0.4));
                        writerControl_0.EditorHost.method_1(this, preferredSize);
                        gcontrol5_0.method_100();
                        gcontrol5_0.method_101();
                        method_8(bool_4: false);
                        writerControl_0.EditorHost.method_4(this, (xtextElement_0 == null) ? writerControl_0.CurrentElement : xtextElement_0);
                        writerControl_0.InnerViewControl.Focus();
                        writerControl_0.Document.MouseCapture = null;
                        writerControl_0.InnerViewControl.UpdateTextCaret();
                        gcontrol5_0.method_117(bool_14: true);
                        if (!bool_6)
                        {
                            bool_6 = true;
                            writerControl_0.LocalMessageFilters.Attach(gcontrol5_0);
                        }
                    }
                    finally
                    {
                        bool_5 = false;
                    }
                }
                else
                {
                    imethod_6();
                }
            }
        }

        private void method_25(object object_0, GClass125 gclass125_0)
        {
            GClass124 gClass = gclass125_0.method_0();
            int num = int_0;
            List<string> list = new List<string>();
            WriterQueryAssistInputItemsEventArgs writerQueryAssistInputItemsEventArgs = new WriterQueryAssistInputItemsEventArgs(writerControl_0, writerControl_0.Document, xtextContainerElement_0, string_0, list);
            writerControl_0.method_57(writerQueryAssistInputItemsEventArgs);
            if (writerQueryAssistInputItemsEventArgs.Cancel || num != int_0 || gClass.method_13())
            {
                return;
            }
            if (list.Count == 0)
            {
                if (list_0.Count == 0)
                {
                    return;
                }
                if (list_0.Count > 0)
                {
                    bool flag = false;
                    foreach (string item in list_0)
                    {
                        if (item.StartsWith(string_0))
                        {
                            list.Add(item);
                            flag = true;
                        }
                        else if (flag)
                        {
                            break;
                        }
                        if (num != int_0)
                        {
                            return;
                        }
                    }
                }
            }
            if (list.Count > 0)
            {
                gclass125_0.method_2(list);
            }
        }

        private void method_26(object sender, EventArgs e)
        {
            if (writerControl_0 == null || writerControl_0.InnerViewControl == null)
            {
                return;
            }
            imethod_6();
            if (gcontrol5_0.method_78() == null)
            {
                return;
            }
            string text = gcontrol5_0.method_78().method_2();
            if (!string.IsNullOrEmpty(text))
            {
                if (string_0 != null && text.Length > string_0.Length)
                {
                    text = text.Substring(string_0.Length);
                }
                bool_4 = true;
                try
                {
                    XTextDocument.smethod_8(writerControl_0, GEnum6.const_152, "");
                    writerControl_0.DocumentControler.InsertString(text);
                    writerControl_0.InnerViewControl.method_175(20);
                }
                finally
                {
                    bool_4 = false;
                }
            }
        }

        public void imethod_0(string string_1)
        {
            if (string_1 != null)
            {
                string_1 = string_1.Trim();
                if (string_1.Length > 0 && !list_0.Contains(string_1))
                {
                    list_0.Add(string_1);
                }
            }
        }

        public int imethod_1(string string_1)
        {
            int num = 13;
            if (string.IsNullOrEmpty(string_1))
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(string_1))
            {
                throw new FileNotFoundException(string_1);
            }
            using (FileStream stream_ = new FileStream(string_1, FileMode.Open, FileAccess.Read))
            {
                return imethod_2(stream_);
            }
        }

        public int imethod_2(Stream stream_0)
        {
            int num = 15;
            if (stream_0 == null)
            {
                throw new ArgumentNullException("stream");
            }
            int num2 = 0;
            using (StreamReader streamReader = new StreamReader(stream_0, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
            {
                for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
                {
                    text = text.Trim();
                    if (text.Length > 0)
                    {
                        string item = text.Trim();
                        if (!list_0.Contains(item))
                        {
                            list_0.Add(item);
                            num2++;
                        }
                    }
                }
                list_0.Sort();
                return num2;
            }
        }

        public int imethod_3(string string_1)
        {
            if (string.IsNullOrEmpty(string_1))
            {
                return 0;
            }
            int num = 0;
            string[] lines = StringFormatHelper.GetLines(string_1);
            string[] array = lines;
            foreach (string text in array)
            {
                if (text.Trim().Length > 0)
                {
                    string item = text.Trim();
                    if (!list_0.Contains(item))
                    {
                        list_0.Add(item);
                        num++;
                    }
                }
            }
            list_0.Sort();
            return num;
        }

        public void imethod_4()
        {
            list_0.Sort();
        }

        public void imethod_5()
        {
            list_0.Clear();
        }

        public void imethod_6()
        {
            int_0++;
            if (base.Visible)
            {
                if (bool_6)
                {
                    bool_6 = false;
                    writerControl_0.LocalMessageFilters.Remove(gcontrol5_0);
                }
                if (gclass124_1 != null)
                {
                    gclass124_1.method_15();
                }
                Hide();
            }
        }

        public void imethod_7()
        {
            int_0++;
            xtextElement_0 = null;
            if (!base.Enabled || bool_4 || writerControl_0 == null || writerControl_0.InnerViewControl == null)
            {
                imethod_6();
                return;
            }
            if (!writerControl_0.UIStartEditContent())
            {
                imethod_6();
                return;
            }
            XTextDocument document = writerControl_0.Document;
            XTextContent content = document.Content;
            StringBuilder stringBuilder = new StringBuilder();
            XTextContainerElement xTextContainerElement = null;
            for (int num = content.SelectionStartIndex - 1; num >= 0; num--)
            {
                XTextElement xTextElement = content[num];
                if (!(xTextElement is XTextCharElement))
                {
                    break;
                }
                if (xTextContainerElement == null)
                {
                    xTextContainerElement = xTextElement.Parent;
                }
                else if (xTextContainerElement != xTextElement.Parent)
                {
                    break;
                }
                char charValue = ((XTextCharElement)xTextElement).CharValue;
                if (!char.IsLetterOrDigit(charValue) && !StringConvertHelper.IsChineseCharacter(charValue))
                {
                    break;
                }
                stringBuilder.Insert(0, charValue);
                xtextElement_0 = xTextElement;
            }
            if (stringBuilder.Length == 0)
            {
                imethod_6();
                return;
            }
            int autoAssistInsertStringDetectTextLength = writerControl_0.DocumentOptions.BehaviorOptions.AutoAssistInsertStringDetectTextLength;
            if (autoAssistInsertStringDetectTextLength > 0 && stringBuilder.Length < autoAssistInsertStringDetectTextLength)
            {
                imethod_6();
                return;
            }
            string_0 = stringBuilder.ToString();
            xtextContainerElement_0 = xTextContainerElement;
            gclass124_1.method_12();
        }

        /// <summary>
        ///       销毁窗体
        ///       </summary>
        /// <param name="disposing">
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (bool_6)
            {
                bool_6 = false;
                writerControl_0.LocalMessageFilters.Remove(gcontrol5_0);
            }
            if (gclass124_1 != null)
            {
                gclass124_1.method_15();
                gclass124_1 = null;
            }
            base.Dispose(disposing);
        }

        bool GInterface19.Visible
        {
            get => base.Visible;
            set => base.Visible = value;
        }


    }
}
