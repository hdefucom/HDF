using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑文档元素数值事件参数
	///       </summary>
	[ComClass("CB56C0AC-FB30-44EF-8067-9AD1726BC6BF", "61814E57-A693-4A00-BA18-CF959E2C68D0")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterEditElementValueEventArgs))]
	
	[DocumentComment]
	[Guid("CB56C0AC-FB30-44EF-8067-9AD1726BC6BF")]
	[ComVisible(true)]
	public class WriterEditElementValueEventArgs : WriterEventArgs, IWriterEditElementValueEventArgs
	{
		internal new const string CLASSID = "CB56C0AC-FB30-44EF-8067-9AD1726BC6BF";

		internal new const string CLASSID_Interface = "61814E57-A693-4A00-BA18-CF959E2C68D0";

		private ElementValueEditor _Editor = null;

		private bool _Handled = false;

		private ElementValueEditResult _Result = ElementValueEditResult.None;

		/// <summary>
		///       标配的元素数值编辑器
		///       </summary>
		
		public ElementValueEditor Editor => _Editor;

		/// <summary>
		///       输入域文档元素对象
		///       </summary>
		
		public XTextInputFieldElement FieldElement => base.Element as XTextInputFieldElement;

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
		///       处理结果
		///       </summary>
		
		public ElementValueEditResult Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="editor">编辑器对象</param>
		
		public WriterEditElementValueEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, ElementValueEditor editor)
			: base(writerControl_0, document, element)
		{
			_Editor = editor;
		}
	}
}
