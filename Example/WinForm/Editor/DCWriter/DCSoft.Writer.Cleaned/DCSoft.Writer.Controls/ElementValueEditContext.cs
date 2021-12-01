using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       元素属性值编辑相关的上下文
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class ElementValueEditContext
	{
		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private string _PropertyName = null;

		private ElementValueEditor _Editor = null;

		private ElementValueEditorEditStyle _EditStyle = ElementValueEditorEditStyle.None;

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
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				if (_Document == null)
				{
					return null;
				}
				return _Document.EditorControl;
			}
		}

		/// <summary>
		///       当前编辑的元素对象
		///       </summary>
		public XTextElement Element
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
		///       编辑的属性名
		///       </summary>
		public string PropertyName
		{
			get
			{
				return _PropertyName;
			}
			set
			{
				_PropertyName = value;
			}
		}

		/// <summary>
		///       正在运行的文档元素值编辑器
		///       </summary>
		public ElementValueEditor Editor
		{
			get
			{
				return _Editor;
			}
			set
			{
				_Editor = value;
			}
		}

		/// <summary>
		///       正在使用的编辑器编辑样式
		///       </summary>
		public ElementValueEditorEditStyle EditStyle
		{
			get
			{
				return _EditStyle;
			}
			set
			{
				_EditStyle = value;
			}
		}
	}
}
