using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestGlobalEventTemplate : UserControl
    {
        public ctlTestGlobalEventTemplate()
        {
            InitializeComponent();
        }


        private void frmTestGlobalEventTemplate_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }


        private void eetField_ContentChanging(object eventSender, ContentChangingEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + "即将使用的新文本为：" + args.GetContainerNewText());
        }
        private void eetField_ContentChanged(object sender, ContentChangedEventArgs args)
        {
            if (args.LoadingDocument == false)
            {
                txtLog.AppendText(Environment.NewLine + "输入域 " + args.Element.ID + " 内容发生改变!");
            }
            if (args.DeletedElements != null && args.DeletedElements.Count > 0)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine();
                str.Append("删除元素：");
                foreach (XTextElement element in args.DeletedElements)
                {
                    str.Append(element.ToString());
                }
                txtLog.AppendText(str.ToString());
            }
        }



        private void eetField_GotFocus(object sender, ElementEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + "输入域 " + args.Element.ID + " 获得焦点");
        }

        private void eetField_LostFocus(object sender, ElementEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + "输入域 " + args.Element.ID + " 失去焦点");
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnClearField.Checked)
            {
                ElementEventTemplate eet2 = new ElementEventTemplate();
                eet2.ContentChanged += new ContentChangedEventHandler(eet2_ContentChanged);
                myWriterControl.GlobalEventTemplates[typeof( XTextInputFieldElement )]= eet2 ;
            }
            else
            {
                myWriterControl.GlobalEventTemplates[ typeof( XTextInputFieldElement )] = null ;
            }
            myWriterControl.ExecuteCommand("FileOpen", true, null);
        }
         

        void eet2_ContentChanged(object sender, ContentChangedEventArgs args)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)args.Element;
            if (field != null)
            {
                field.EditorTextExt = "";
            }
        }

        private void eetCell_ContentChanged(object sender, ContentChangedEventArgs args)
        {
            if (args.LoadingDocument == false)
            {
                XTextTableCellElement cell = args.Element as XTextTableCellElement;
                if (cell != null)
                {
                    txtLog.AppendText(Environment.NewLine + "单元格 " + cell.CellID + " 内容发生改变");
                }
            }
            if (args.DeletedElements != null && args.DeletedElements.Count > 0)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine();
                str.Append("删除元素：");
                foreach (XTextElement element in args.DeletedElements)
                {
                    str.Append(element.ToString());
                }
                txtLog.AppendText(str.ToString());
            }
        }

        private void eetImage_MouseDblClick(object sender, ElementMouseEventArgs args)
        {
            MessageBox.Show("双击了 " + args.Element.ID + " 图片对象");
        }

        private void eetCell_MouseEnter(object sender, ElementEventArgs args)
        {
            XTextTableCellElement cell = args.Element as XTextTableCellElement;
            if (cell != null)
            {
                txtLog.AppendText(Environment.NewLine + "鼠标进入单元格 " + cell.CellID );
            }
        }

        private void eetCell_MouseLeave(object sender, ElementEventArgs args)
        {
            XTextTableCellElement cell = args.Element as XTextTableCellElement;
            if (cell != null)
            {
                txtLog.AppendText(Environment.NewLine + "鼠标离开单元格 " + cell.CellID);
            }
        }

    }
}
