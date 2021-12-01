using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlFilterValue : UserControl
    {
        public ctlFilterValue()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        /// <summary>
        /// 处理数据过滤事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_FilterValue(object sender, FilterValueEventArgs args)
        {
            if (args.Type == InputValueType.Dom)
            {
                XTextElementList list = (XTextElementList)args.Value;
                if (list != null && list.Count > 0)
                {
                    // 清空原始数据中所有文本输入域的内容
                    ClearFieldContent(list);
                }
            }
        }

        private void ClearFieldContent(XTextElementList list)
        {
            // 清空所有输入域的内容
            foreach (XTextElement element in list)
            {
                if (element is XTextInputFieldElement)
                {
                    XTextInputFieldElement field = (XTextInputFieldElement)element;
                    if (field.Attributes == null)
                    {
                        field.Attributes = new XAttributeList();
                    }
                    field.Attributes.SetValue("插入时间", DateTime.Now.ToString());
                    field.Elements.Clear();
                    field.InnerValue = null;
                }
                else if (element is XTextContainerElement)
                {
                    XTextContainerElement c = (XTextContainerElement)element;
                    if (c.Elements != null && c.Elements.Count > 0)
                    {
                        ClearFieldContent(c.Elements);
                    }
                }
            }
        }
    }
}