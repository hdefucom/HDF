using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ctlCustomEditorControlEditorControl : UserControl, DCSoft.Writer.Controls.IInputFieldElementEditorControl
    {
        public ctlCustomEditorControlEditorControl()
        {
            InitializeComponent();
        }

        private void ctlCustomEditorControlEditorControl_Load(object sender, EventArgs e)
        {
            foreach (string fileName in System.IO.Directory.GetFiles(Application.StartupPath))
            {
                string fn = System.IO.Path.GetFileName(fileName);
                lstFile.Items.Add(fn);
                if (_InputArgs != null && _InputArgs.Element != null && _InputArgs.Element.Text == fn)
                {
                    lstFile.SelectedIndex = lstFile.Items.Count - 1;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)_InputArgs.Element;
            field.EditorTextExt = lstFile.Text;
            _InputArgs.Result = ElementValueEditResult.UserAccept;
            _InputArgs.CloseDropDown();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _InputArgs.CloseDropDown();
            _InputArgs.Result = ElementValueEditResult.UserCancel;
        }

        private InputFieldElementEditorEventArgs _InputArgs = null;

        /// <summary>
        /// 定义IInputFieldElementEditorControl.EditorInitalize函数
        /// </summary>
        /// <param name="args"></param>
        void IInputFieldElementEditorControl.EditorInitalize(InputFieldElementEditorEventArgs args)
        {
            _InputArgs = args;
            string txt = args.Element.Text;
            // 设置当前列表项目
            this.lstFile.Text = txt ;
        }

        /// <summary>
        /// 返回控件首先大小。编辑器弹出自定义控件时会调用该方法获得弹出的自定义控件所要显示的首选大小。
        /// </summary>
        /// <remarks>
        /// 如果不重载该方法，则弹出的列表控件大小是不可预计的，可能大可能小。
        /// </remarks>
        /// <param name="proposedSize"></param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            return new System.Drawing.Size(436, 323);
        }

        private void lstFile_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }
    }
}
