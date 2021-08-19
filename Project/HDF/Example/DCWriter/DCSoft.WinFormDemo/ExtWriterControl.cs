using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Commands;

namespace DCSoft.Writer.WinFormDemo
{
    /// <summary>
    /// 扩展文本编辑器，带有标准工具条
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ExtWriterControl : UserControl
    {
        public ExtWriterControl()
        {
            InitializeComponent();
        }

        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RTFText
        {
            get
            {
                return this.myEditControl.RTFText;
            }
            set
            {
                myEditControl.RTFText = value;
            }
        }

        /// <summary>
        /// XML文本
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string XMLText
        {
            get
            {
                return myEditControl.XMLText;
            }
            set
            {
                myEditControl.XMLText = value;
            }
        }

        /// <summary>
		/// 控件数据
		/// </summary>
        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return myEditControl.Text;
            }
            set
            {
                myEditControl.Text = value;
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            if (this.DesignMode == false)
            {
                myEditControl.CommandControler = myCommandControler;
                myCommandControler.Start();
                if (this.myEditControl.Document == null)
                {
                    myEditControl.ExecuteCommand(StandardCommandNames.FileNew, false, null);
                }
            }
            base.OnLoad(e);
        }
    }
}
