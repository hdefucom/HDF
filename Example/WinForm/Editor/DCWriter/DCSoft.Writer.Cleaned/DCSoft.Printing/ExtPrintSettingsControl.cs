using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印设置对话框扩展控件
	///       </summary>
	
	[ComVisible(false)]
	[ToolboxItem(false)]
	
	public class ExtPrintSettingsControl : UserControl
	{
		private static DCPrintMode dcprintMode_0 = DCPrintMode.Normal;

		private IContainer icontainer_0 = null;

		private Label label1;

		private ComboBox cboPrintMode;

		/// <summary>
		///       当前选择的打印模式
		///       </summary>
		[Browsable(false)]
		public DCPrintMode SelectedPrintMode
		{
			get
			{
				return (DCPrintMode)cboPrintMode.SelectedIndex;
			}
			set
			{
				if (value >= DCPrintMode.Normal && (int)value < cboPrintMode.Items.Count)
				{
					cboPrintMode.SelectedIndex = (int)value;
				}
			}
		}

		/// <summary>
		///       最后一次选择的打印类型
		///       </summary>
		public static DCPrintMode LastSelectedPrintMode
		{
			get
			{
				return dcprintMode_0;
			}
			set
			{
				dcprintMode_0 = value;
			}
		}

		public ExtPrintSettingsControl()
		{
			InitializeComponent();
		}

		private void ExtPrintSettingsControl_Load(object sender, EventArgs e)
		{
			cboPrintMode.SelectedIndex = 0;
		}

		public void method_0(int int_0)
		{
			string item = string.Format(PrintingResources.PrintCurrentPage_PageIndex, int_0 + 1);
			cboPrintMode.Items.Add(item);
		}

		private void cboPrintMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			dcprintMode_0 = (DCPrintMode)cboPrintMode.SelectedIndex;
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.ExtPrintSettingsControl));
			label1 = new System.Windows.Forms.Label();
			cboPrintMode = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cboPrintMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPrintMode.FormattingEnabled = true;
			cboPrintMode.Items.AddRange(new object[4]
			{
				resources.GetString("cboPrintMode.Items"),
				resources.GetString("cboPrintMode.Items1"),
				resources.GetString("cboPrintMode.Items2"),
				resources.GetString("cboPrintMode.Items3")
			});
			resources.ApplyResources(cboPrintMode, "cboPrintMode");
			cboPrintMode.Name = "cboPrintMode";
			cboPrintMode.SelectedIndexChanged += new System.EventHandler(cboPrintMode_SelectedIndexChanged);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			base.Controls.Add(cboPrintMode);
			base.Controls.Add(label1);
			base.Name = "ExtPrintSettingsControl";
			base.Load += new System.EventHandler(ExtPrintSettingsControl_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
