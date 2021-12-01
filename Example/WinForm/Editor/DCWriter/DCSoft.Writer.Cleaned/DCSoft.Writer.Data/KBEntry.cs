using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识库条目
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("00012345-6789-ABCD-EF01-234567890027", "04459E25-93E0-4256-8F3D-E7B1F4B1BD1D")]
	[Guid("00012345-6789-ABCD-EF01-234567890027")]
	[XmlType]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IKBEntry))]
	[ComVisible(true)]
	public class KBEntry : IKBEntry
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890027";

		internal const string CLASSID_Interface = "04459E25-93E0-4256-8F3D-E7B1F4B1BD1D";

		/// <summary>
		///       表示空节点的知识点对象
		///       </summary>
		public static readonly KBEntry NullKBEntry = new KBEntry();

		private bool _CopyListItems = false;

		private XAttributeList _Attributes = null;

		private string _ID = null;

		private string _Name = null;

		private int _RangeMask = 0;

		private KBEntry _Parent = null;

		private string _ParentID = null;

		private string _SpellCode = null;

		private string _SpellCode2 = null;

		private string _SpellCode3 = null;

		private string _RuntimeSpellCode = null;

		private string _Text = null;

		private string _Text2 = null;

		private string _Value = null;

		private string _EntryTemplateContent = null;

		private KBEntryList _SubEntries = null;

		private KBEntryStyle _Style = KBEntryStyle.List;

		private string _ListItemsSource = null;

		private int _ListIndex = 0;

		private bool _Visible = true;

		[NonSerialized]
		private object _Tag = null;

		[NonSerialized]
		private DataRowState _RecordState = DataRowState.Unchanged;

		private ListItemCollection _RuntimeItems = null;

		private ListItemCollection _ListItems = null;

		private EntryOwnerLevel _OwnerLevel = EntryOwnerLevel.Global;

		private string _OwnerID = null;

		private bool _BufferItems = true;

		/// <summary>
		///       插入知识节点时是否复制列表项目到输入域元素中
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool CopyListItems
		{
			get
			{
				return _CopyListItems;
			}
			set
			{
				_CopyListItems = value;
			}
		}

		/// <summary>
		///       用户自定义属性列表
		///       </summary>
		[Browsable(true)]
		[XmlArrayItem("Attribute", typeof(XAttribute))]
		[DefaultValue(null)]
		[DCPublishAPI]
		public XAttributeList Attributes
		{
			get
			{
				if (_Attributes == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					_Attributes = new XAttributeList();
				}
				return _Attributes;
			}
			set
			{
				_Attributes = value;
			}
		}

		/// <summary>
		///       编号
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				if (_ID != value)
				{
					_ID = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       节点名称
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       应用范围掩码
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(0)]
		public int RangeMask
		{
			get
			{
				return _RangeMask;
			}
			set
			{
				_RangeMask = value;
			}
		}

		/// <summary>
		///       父节点
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public KBEntry Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				if (_Parent != value)
				{
					_Parent = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       父节点编号,DCWriter并不使用本属性，主要供应用程序组织成树状结构时临时使用,本属性值不保存到文件中。
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public string ParentID
		{
			get
			{
				if (_Parent != null)
				{
					return _Parent.ID;
				}
				return _ParentID;
			}
			set
			{
				if (_ParentID != value)
				{
					_ParentID = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       拼音码
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string SpellCode
		{
			get
			{
				return _SpellCode;
			}
			set
			{
				if (_SpellCode != value)
				{
					_SpellCode = value;
					_RuntimeSpellCode = null;
					OnModified();
				}
			}
		}

		/// <summary>
		///       拼音码
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string SpellCode2
		{
			get
			{
				return _SpellCode2;
			}
			set
			{
				if (_SpellCode2 != value)
				{
					_SpellCode2 = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       拼音码
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string SpellCode3
		{
			get
			{
				return _SpellCode3;
			}
			set
			{
				if (_SpellCode3 != value)
				{
					_SpellCode3 = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       自动生成的拼音码
		///       </summary>
		internal string RuntimeSpellCode
		{
			get
			{
				if (string.IsNullOrEmpty(_SpellCode))
				{
					if (_RuntimeSpellCode == null)
					{
						_RuntimeSpellCode = StringConvertHelper.ToChineseSpell(Text);
					}
					return _RuntimeSpellCode;
				}
				return _SpellCode;
			}
		}

		/// <summary>
		///       文本值
		///       </summary>
		[DCPublishAPI]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				if (_Text != value)
				{
					_Text = value;
					_RuntimeSpellCode = null;
					OnModified();
				}
			}
		}

		/// <summary>
		///       文本值2，一般用于多语言环境
		///       </summary>
		[DCPublishAPI]
		public string Text2
		{
			get
			{
				return _Text2;
			}
			set
			{
				if (_Text2 != value)
				{
					_Text2 = value;
					_RuntimeSpellCode = null;
					OnModified();
				}
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[DCPublishAPI]
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (_Value != value)
				{
					_Value = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       作废
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string EntryTemplateContent
		{
			get
			{
				return _EntryTemplateContent;
			}
			set
			{
				_EntryTemplateContent = value;
			}
		}

		/// <summary>
		///       子节点
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[XmlArrayItem("Entry", typeof(KBEntry))]
		public KBEntryList SubEntries
		{
			get
			{
				if (_SubEntries == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					_SubEntries = new KBEntryList();
				}
				return _SubEntries;
			}
			set
			{
				if (_SubEntries != value)
				{
					_SubEntries = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       知识点样式
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(KBEntryStyle.List)]
		public KBEntryStyle Style
		{
			get
			{
				return _Style;
			}
			set
			{
				if (_Style != value)
				{
					_Style = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       列表项目XML定义文件来源
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ListItemsSource
		{
			get
			{
				return _ListItemsSource;
			}
			set
			{
				if (_ListItemsSource != value)
				{
					_ListItemsSource = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       列表序号
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(0)]
		public int ListIndex
		{
			get
			{
				return _ListIndex;
			}
			set
			{
				if (_ListIndex != value)
				{
					_ListIndex = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       对象是否可见
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				if (_Visible != value)
				{
					_Visible = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       附加数据
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public object Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       记录状态，在DCWriter中没有用处。仅为设计器提供支持。
		///       </summary>
		[DCPublishAPI]
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		public DataRowState RecordState
		{
			get
			{
				return _RecordState;
			}
			set
			{
				_RecordState = value;
			}
		}

		/// <summary>
		///       运行时使用的列表项目
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public ListItemCollection RuntimeItems
		{
			get
			{
				return _RuntimeItems;
			}
			set
			{
				_RuntimeItems = value;
			}
		}

		/// <summary>
		///       列表项目
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[XmlArrayItem("Item", typeof(ListItem))]
		public ListItemCollection ListItems
		{
			get
			{
				if (_ListItems == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					_ListItems = new ListItemCollection();
				}
				return _ListItems;
			}
			set
			{
				if (_ListItems != value)
				{
					_ListItems = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       表示列表项目的文本,内部使用
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string ListItemsText
		{
			get
			{
				if (_ListItems == null || _ListItems.Count == 0)
				{
					return "";
				}
				return _ListItems.Count.ToString();
			}
		}

		/// <summary>
		///       标准图标序号
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public int StdImageIndex
		{
			get
			{
				if (Style == KBEntryStyle.Template)
				{
					return 1;
				}
				if (Style == KBEntryStyle.ListSQL)
				{
					return 5;
				}
				if (SubEntries != null && SubEntries.Count > 0)
				{
					return 0;
				}
				return 2;
			}
		}

		/// <summary>
		///       知识节点拥有者等级
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(EntryOwnerLevel.Global)]
		public EntryOwnerLevel OwnerLevel
		{
			get
			{
				return _OwnerLevel;
			}
			set
			{
				if (_OwnerLevel != value)
				{
					_OwnerLevel = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       知识库节点拥有者编号
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string OwnerID
		{
			get
			{
				return _OwnerID;
			}
			set
			{
				if (_OwnerID != value)
				{
					_OwnerID = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       是否缓存列表数据
		///       </summary>
		[DefaultValue(true)]
		[DCPublishAPI]
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
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public KBEntry()
		{
		}

		[ComVisible(false)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private void OnModified()
		{
			if (_RecordState == DataRowState.Unchanged)
			{
				_RecordState = DataRowState.Modified;
			}
		}
	}
}
