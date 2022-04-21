using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       显示对话框事件参数
	///       </summary>
	
	[Guid("6FC8E3C7-4987-499C-A1D1-9BCBC40E425B")]
	[ComClass("6FC8E3C7-4987-499C-A1D1-9BCBC40E425B", "F3ADC9B8-DFEE-4497-A454-74698A62051D")]
	
	[ComDefaultInterface(typeof(IWriterShowDialogEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public class WriterShowDialogEventArgs : WriterEventArgs, IWriterShowDialogEventArgs
	{
		internal new const string CLASSID = "6FC8E3C7-4987-499C-A1D1-9BCBC40E425B";

		internal new const string CLASSID_Interface = "F3ADC9B8-DFEE-4497-A454-74698A62051D";

		private Form _Dialog = null;

		private bool _Handled = false;

		private DialogResult _DialogResult = DialogResult.Cancel;

		/// <summary>
		///       对话框对象
		///       </summary>
		[ComVisible(false)]
		
		public Form Dialog => _Dialog;

		/// <summary>
		///       对话框类型名称
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		
		public string DialogTypeName
		{
			get
			{
				if (_Dialog == null)
				{
					return null;
				}
				return _Dialog.GetType().Name;
			}
		}

		/// <summary>
		///       事件已经处理了，无需后续处理
		///       </summary>
		
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       对话框返回状态
		///       </summary>
		
		public DialogResult DialogResult
		{
			get
			{
				return _DialogResult;
			}
			set
			{
				_DialogResult = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="dlg">对话框对象</param>
		
		public WriterShowDialogEventArgs(WriterControl writerControl_0, Form form_0, XTextDocument docuemnt, XTextElement element)
			: base(writerControl_0, docuemnt, element)
		{
			_Dialog = form_0;
		}

		/// <summary>
		///       设置返回结果为确定
		///       </summary>
		
		public void SetOKDialogResult()
		{
			_DialogResult = DialogResult.OK;
		}

		/// <summary>
		///       设置返回结果为取消
		///       </summary>
		
		public void SetCancelDialogResult()
		{
			_DialogResult = DialogResult.Cancel;
		}
	}
}
