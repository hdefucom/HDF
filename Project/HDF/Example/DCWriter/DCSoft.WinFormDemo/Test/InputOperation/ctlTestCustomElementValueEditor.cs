using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestCustomElementValueEditor : UserControl
    {
        public ctlTestCustomElementValueEditor()
        {
            InitializeComponent();
        }

        private void frmTestCustomElementValueEditor_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            //add by ld 
            this.btnInsertField_Click(null, null);
        }

        private void btnInsertField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "文件名";
            field.SetInnerTextFast(Application.ExecutablePath);
            field.CustomValueEditorType = typeof(FileNameValueEditor);
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        /// <summary>
        /// 自定义的文档元素数据编辑器
        /// </summary>
        public class FileNameValueEditor : ElementValueEditor
        {
            /// <summary>
            /// 采用对话框的模式录入数据
            /// </summary>
            /// <param name="host"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public override ElementValueEditorEditStyle GetEditStyle(
                TextWindowsFormsEditorHost host,
                ElementValueEditContext context)
            {
                // 将采用对话框的模式运行编辑器
                return ElementValueEditorEditStyle.Modal;
            }
            /// <summary>
            /// 编辑数据
            /// </summary>
            /// <param name="host"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public override ElementValueEditResult EditValue(
                TextWindowsFormsEditorHost host,
                ElementValueEditContext context)
            {
                XTextInputFieldElement field = (XTextInputFieldElement)context.Element;
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.FileName = field.Text;
                    if (dlg.ShowDialog(host.EditControl) == DialogResult.OK)
                    {
                        // 设置文档元素内容
                        field.SetEditorTextExt(dlg.FileName, DomAccessFlags.Normal, false , true );
                        // 返回用户确认操作状态
                        return ElementValueEditResult.UserAccept;
                    }
                }
                // 返回用户取消操作状态
                return ElementValueEditResult.UserCancel;
            }
        }
    }
}