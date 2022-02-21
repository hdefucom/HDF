using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       自定义输入域数值编辑器事件参数
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	
	public class InputFieldElementEditorEventArgs
	{
		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextInputFieldElement _Element = null;

		private TextWindowsFormsEditorHost _EditorHost = null;

		private ElementValueEditContext _Context = null;

		private ElementValueEditResult _Result = ElementValueEditResult.None;

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document => _Document;

		/// <summary>
		///       输入域元素对象
		///       </summary>
		public XTextInputFieldElement Element => _Element;

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		public TextWindowsFormsEditorHost EditorHost => _EditorHost;

		/// <summary>
		///       上下文信息对象
		///       </summary>
		public ElementValueEditContext Context => _Context;

		/// <summary>
		///       操作结果
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

		
		public InputFieldElementEditorEventArgs(WriterControl writerControl_0, XTextDocument xtextDocument_0, XTextInputFieldElement field, ElementValueEditContext context)
		{
			_WriterControl = writerControl_0;
			_Document = xtextDocument_0;
			_Element = field;
			_EditorHost = writerControl_0.EditorHost;
			_Context = context;
		}

		/// <summary>
		///       关闭下拉列表界面
		///       </summary>
		public void CloseDropDown()
		{
			_EditorHost.CloseDropDown();
		}
	}
}
