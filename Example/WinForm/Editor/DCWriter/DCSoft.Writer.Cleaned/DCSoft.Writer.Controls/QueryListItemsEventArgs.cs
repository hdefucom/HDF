using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       查询列表项目事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	
	[ComVisible(true)]
	
	[ComDefaultInterface(typeof(IQueryListItemsEventArgs))]
	[Guid("71E132AA-7B9A-4268-8500-580CD14FE145")]
	[ComClass("71E132AA-7B9A-4268-8500-580CD14FE145", "4D942086-7734-4F28-98AB-AA2069DDA552")]
	public class QueryListItemsEventArgs : EventArgs, IQueryListItemsEventArgs
	{
		internal const string CLASSID = "71E132AA-7B9A-4268-8500-580CD14FE145";

		internal const string CLASSID_Interface = "4D942086-7734-4F28-98AB-AA2069DDA552";

		private string _PageName = null;

		private string _ControlName = null;

		private bool _RaiseEvent = true;

		[NonSerialized]
		private KBEntry _KBEntry = null;

		[NonSerialized]
		private WriterControl _WriterControl = null;

		[NonSerialized]
		private XTextDocument _Document = null;

		[NonSerialized]
		private XTextElement _Element = null;

		private string _ListSourceName = null;

		private string _SpellCode = null;

		private string _PreText = null;

		private string _SpecifyValue = null;

		private bool _BufferItems = true;

		private ListItemCollection _Result = null;

		private bool _Handled = false;

		/// <summary>
		///       发出请求的页面名称
		///       </summary>
		
		public string PageName
		{
			get
			{
				if (_WriterControl != null)
				{
					Form form = _WriterControl.FindForm();
					if (form != null)
					{
						return form.GetType().FullName;
					}
				}
				return _PageName;
			}
			set
			{
				_PageName = value;
			}
		}

		/// <summary>
		///       发出请求的控件名称
		///       </summary>
		
		public string ControlName
		{
			get
			{
				if (_WriterControl != null)
				{
					return _WriterControl.Name;
				}
				return _ControlName;
			}
			set
			{
				_ControlName = value;
			}
		}

		/// <summary>
		///       是否触发事件
		///       </summary>
		[DefaultValue(true)]
		internal bool RaiseEvent
		{
			get
			{
				return _RaiseEvent;
			}
			set
			{
				_RaiseEvent = value;
			}
		}

		/// <summary>
		///       关联的知识节点
		///       </summary>
		[XmlIgnore]
		
		public KBEntry KBEntry
		{
			get
			{
				return _KBEntry;
			}
			set
			{
				_KBEntry = value;
			}
		}

		/// <summary>
		///       编辑器控件
		///       </summary>
		[XmlIgnore]
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		[XmlIgnore]
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档元素对象
		///       </summary>
		[XmlIgnore]
		
		public XTextElement Element => _Element;

		/// <summary>
		///       列表来源名称
		///       </summary>
		[DefaultValue(null)]
		
		[XmlElement]
		public string ListSourceName
		{
			get
			{
				return _ListSourceName;
			}
			set
			{
				_ListSourceName = value;
			}
		}

		/// <summary>
		///       当前使用的拼音码
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		
		public string SpellCode
		{
			get
			{
				return _SpellCode;
			}
			set
			{
				_SpellCode = value;
			}
		}

		/// <summary>
		///       要查询的列表项目的前缀文本
		///       </summary>
		[XmlElement]
		
		[DefaultValue(null)]
		public string PreText
		{
			get
			{
				return _PreText;
			}
			set
			{
				_PreText = value;
			}
		}

		/// <summary>
		///       指定的要查询的项目的后台数值
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		
		public string SpecifyValue
		{
			get
			{
				return _SpecifyValue;
			}
			set
			{
				_SpecifyValue = value;
			}
		}

		/// <summary>
		///       是否缓存数据
		///       </summary>
		[DefaultValue(true)]
		
		[XmlElement]
		public bool BufferItems
		{
			get
			{
				return _BufferItems;
			}
			set
			{
				_BufferItems = value;
			}
		}

		/// <summary>
		///       列表对象
		///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		
		public ListItemCollection Result
		{
			get
			{
				if (_Result == null)
				{
					_Result = new ListItemCollection();
				}
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       本事件已经处理了，无需后续处理
		///       </summary>
		[XmlElement]
		
		[DefaultValue(false)]
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
		///       无参数的构造函数
		///       </summary>
		
		public QueryListItemsEventArgs()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="element">
		/// </param>
		public QueryListItemsEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element)
		{
			_WriterControl = writerControl_0;
			_Document = document;
			_Element = element;
		}

		
		public void AddResultItem(ListItem item)
		{
			if (_Result == null)
			{
				_Result = new ListItemCollection();
			}
			_Result.Add(item);
		}

		
		public void AddResultItemByTextValue(string strText, string strValue)
		{
			ListItem listItem = new ListItem();
			listItem.Text = strText;
			listItem.Value = strValue;
			if (_Result == null)
			{
				_Result = new ListItemCollection();
			}
			_Result.Add(listItem);
		}

		
		public void AddResultItemByTextValueTextInList(string strText, string strValue, string strTextInList)
		{
			ListItem listItem = new ListItem();
			listItem.Text = strText;
			listItem.Value = strValue;
			listItem.TextInList = strTextInList;
			if (_Result == null)
			{
				_Result = new ListItemCollection();
			}
			_Result.Add(listItem);
		}
	}
}
