using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑文档元素属性事件参数
	///       </summary>
	[ComVisible(false)]
	
	
	public class ElementPropertiesEditEventArgs : EventArgs
	{
		private bool _SimpleElementProperties = false;

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private WriterAppHost _Host = null;

		private XTextElementList _Elements = new XTextElementList();

		private bool _LogUndo = true;

		private ElementPropertiesEditMethod _Method = ElementPropertiesEditMethod.Insert;

		private IWin32Window _ParentWindow = null;

		private bool _UpdateExpressionResult = false;

		private ContentEffects _ContentEffect = ContentEffects.None;

		/// <summary>
		///       简洁的编辑元素属性
		///       </summary>
		public bool SimpleElementProperties
		{
			get
			{
				return _SimpleElementProperties;
			}
			set
			{
				_SimpleElementProperties = value;
			}
		}

		/// <summary>
		///       编辑器控件
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
		///       编辑器宿主对象
		///       </summary>
		public WriterAppHost Host
		{
			get
			{
				return _Host;
			}
			set
			{
				_Host = value;
			}
		}

		/// <summary>
		///       正在编辑的文档元素对象
		///       </summary>
		public XTextElement Element
		{
			get
			{
				if (_Elements != null && _Elements.Count > 0)
				{
					return _Elements[0];
				}
				return null;
			}
			set
			{
				_Elements = new XTextElementList();
				if (value != null)
				{
					_Elements.Add(value);
				}
			}
		}

		/// <summary>
		///       正在编辑的文档元素对象列表
		///       </summary>
		public XTextElementList Elements
		{
			get
			{
				return _Elements;
			}
			set
			{
				_Elements = value;
			}
		}

		/// <summary>
		///       是否记录重做、撤销操作信息。
		///       </summary>
		public bool LogUndo
		{
			get
			{
				return _LogUndo;
			}
			set
			{
				_LogUndo = value;
			}
		}

		/// <summary>
		///       操作模式
		///       </summary>
		public ElementPropertiesEditMethod Method
		{
			get
			{
				return _Method;
			}
			set
			{
				_Method = value;
			}
		}

		/// <summary>
		///       父窗体对象
		///       </summary>
		public IWin32Window ParentWindow
		{
			get
			{
				return _ParentWindow;
			}
			set
			{
				_ParentWindow = value;
			}
		}

		/// <summary>
		///       从新计算表达式的结果
		///       </summary>
		public bool UpdateExpressionResult
		{
			get
			{
				return _UpdateExpressionResult;
			}
			set
			{
				_UpdateExpressionResult = value;
			}
		}

		/// <summary>
		///       操作对文档视图的影响
		///       </summary>
		public ContentEffects ContentEffect
		{
			get
			{
				return _ContentEffect;
			}
			set
			{
				_ContentEffect = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public ElementPropertiesEditEventArgs()
		{
		}

		/// <summary>
		///       设置影响状态
		///       </summary>
		/// <param name="efc">新状态</param>
		public void SetContentEffect(ContentEffects contentEffects_0)
		{
			if (contentEffects_0 > _ContentEffect)
			{
				_ContentEffect = contentEffects_0;
			}
		}
	}
}
