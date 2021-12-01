using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档和被承载的对象交互时使用的参数
	///       </summary>
	[ComVisible(false)]
	public class DocumentHostElementEventArgs : EventArgs
	{
		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XMLViewStateBag _ViewState = null;

		private XTextControlHostElement _Element = null;

		private bool _Cancel = false;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return _WriterControl;
			}
			set
			{
				_WriterControl = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		/// <summary>
		///       视图状态容器
		///       </summary>
		public XMLViewStateBag ViewState
		{
			get
			{
				return _ViewState;
			}
			set
			{
				_ViewState = value;
			}
		}

		/// <summary>
		///       承载控件的元素对象
		///       </summary>
		public XTextControlHostElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       是否取消事件
		///       </summary>
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}
	}
}
