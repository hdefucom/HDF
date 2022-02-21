using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档按钮事件参数
	///       </summary>
	
	[ComDefaultInterface(typeof(IWriterButtonClickEventArgs))]
	[DocumentComment]
	[Guid("EBE08785-AF0C-489E-90B0-0219F04D5BB0")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("EBE08785-AF0C-489E-90B0-0219F04D5BB0", "B4CCCC57-E596-49A8-B628-45A2251B04E1")]
	public class WriterButtonClickEventArgs : WriterEventArgs, IWriterButtonClickEventArgs
	{
		internal new const string CLASSID = "EBE08785-AF0C-489E-90B0-0219F04D5BB0";

		internal new const string CLASSID_Interface = "B4CCCC57-E596-49A8-B628-45A2251B04E1";

		private bool _Handled = false;

		/// <summary>
		///       按钮文档元素对象
		///       </summary>
		
		public XTextButtonElement ButtonElement => (XTextButtonElement)base.Element;

		/// <summary>
		///       按钮文档元素编号
		///       </summary>
		
		public string ButtonElementID
		{
			get
			{
				if (base.Element == null)
				{
					return null;
				}
				return base.Element.ID;
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
		///       命令名称
		///       </summary>
		
		public string CommandName => (base.Element as XTextButtonElement)?.CommandName;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="btn">按钮元素对象</param>
		
		public WriterButtonClickEventArgs(WriterControl writerControl_0, XTextButtonElement xtextButtonElement_0)
			: base(writerControl_0, xtextButtonElement_0.OwnerDocument, xtextButtonElement_0)
		{
		}
	}
}
