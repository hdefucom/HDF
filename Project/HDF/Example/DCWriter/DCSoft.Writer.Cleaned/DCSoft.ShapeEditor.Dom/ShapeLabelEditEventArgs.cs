using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       标签编辑事件参数
	///       </summary>
	[ComVisible(false)]
	public class ShapeLabelEditEventArgs : EventArgs
	{
		private ShapeDocument _Document = null;

		private ShapeElement _Element = null;

		private ContentStyle _ContentStyle = null;

		private string _Text = null;

		private string _NewText = null;

		private RectangleF _EditAreaBounds = RectangleF.Empty;

		private bool _Cancel = false;

		private Control _EditorControl = null;

		private LabelEditorControlType _ControlType = LabelEditorControlType.TextBox;

		/// <summary>
		///       文档对象
		///       </summary>
		public ShapeDocument Document
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
		///       文档元素对象
		///       </summary>
		public ShapeElement Element
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
		///       内容样式
		///       </summary>
		public ContentStyle ContentStyle
		{
			get
			{
				return _ContentStyle;
			}
			set
			{
				_ContentStyle = value;
			}
		}

		/// <summary>
		///       文本
		///       </summary>
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       用户输入的新文本
		///       </summary>
		public string NewText
		{
			get
			{
				return _NewText;
			}
			set
			{
				_NewText = value;
			}
		}

		/// <summary>
		///       编辑区域边界
		///       </summary>
		public RectangleF EditAreaBounds
		{
			get
			{
				return _EditAreaBounds;
			}
			set
			{
				_EditAreaBounds = value;
			}
		}

		/// <summary>
		///       取消操作
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

		/// <summary>
		///       编辑器控件
		///       </summary>
		public Control EditorControl
		{
			get
			{
				return _EditorControl;
			}
			set
			{
				_EditorControl = value;
			}
		}

		/// <summary>
		///       编辑内容使用的控件的类型
		///       </summary>
		public LabelEditorControlType ControlType
		{
			get
			{
				return _ControlType;
			}
			set
			{
				_ControlType = value;
			}
		}
	}
}
