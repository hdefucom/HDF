using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表项目
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlType]
	[ComVisible(true)]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComDefaultInterface(typeof(IListItem))]
	[Guid("00012345-6789-ABCD-EF01-234567890031")]
	[ComClass("00012345-6789-ABCD-EF01-234567890031", "1B5A7174-A133-4613-8DE9-BA77C1706664")]
	public class ListItem : ICloneable, IListItem
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890031";

		internal const string CLASSID_Interface = "1B5A7174-A133-4613-8DE9-BA77C1706664";

		private float _DisplayWidth = 0f;

		private string _ID = null;

		private string _EntryID = null;

		private bool _LonelyChecked = false;

		private string _TextInList = null;

		private string _Text = null;

		private string _Text2 = null;

		private string _Value = null;

		private string _Group = null;

		private DateTime _CheckedTime = new DateTime(1900, 1, 1);

		private string _Tag = null;

		private string _SpellCode = null;

		private string _SpellCode2 = null;

		private string _SpellCode3 = null;

		private int _ListIndex = 0;

		[NonSerialized]
		private DataRowState _RecordState = DataRowState.Unchanged;

		/// <summary>
		///       显示宽度
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCInternal]
		public float DisplayWidth
		{
			get
			{
				return _DisplayWidth;
			}
			set
			{
				_DisplayWidth = value;
			}
		}

		/// <summary>
		///       编号
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public virtual string ID
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
		///       对象所属的知识库节点编号
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public virtual string EntryID
		{
			get
			{
				return _EntryID;
			}
			set
			{
				if (_EntryID != value)
				{
					_EntryID = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       孤独勾选模式。当此项被勾选时，其他项目都不能勾选。
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool LonelyChecked
		{
			get
			{
				return _LonelyChecked;
			}
			set
			{
				_LonelyChecked = value;
			}
		}

		/// <summary>
		///       在下拉列表中的文本
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string TextInList
		{
			get
			{
				return _TextInList;
			}
			set
			{
				_TextInList = value;
			}
		}

		/// <summary>
		///       列表文本
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
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
					OnModified();
				}
			}
		}

		/// <summary>
		///       列表文本2，一般用于多语言环境
		///       </summary>
		[DefaultValue(null)]
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
					OnModified();
				}
			}
		}

		/// <summary>
		///       列表项目值
		///       </summary>
		[DefaultValue(null)]
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
		///       分组名称
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string Group
		{
			get
			{
				return _Group;
			}
			set
			{
				if (_Group != value)
				{
					_Group = value;
					OnModified();
				}
			}
		}

		/// <summary>
		///       项目勾选时间
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(typeof(DateTime), "1900-1-1")]
		public DateTime CheckedTime
		{
			get
			{
				return _CheckedTime;
			}
			set
			{
				_CheckedTime = value;
			}
		}

		/// <summary>
		///       运行时使用的数值
		///       </summary>
		[Browsable(false)]
		public string RuntimeValue
		{
			get
			{
				if (string.IsNullOrEmpty(_Value))
				{
					return _Text;
				}
				return _Value;
			}
		}

		/// <summary>
		///       附加数据
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				if (_Tag != value)
				{
					_Tag = value;
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
					OnModified();
				}
			}
		}

		/// <summary>
		///       拼音码2
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
		///       拼音码3
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
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
		[DCInternal]
		[Browsable(false)]
		public string RuntimeSpellCode
		{
			get
			{
				if (string.IsNullOrEmpty(_SpellCode))
				{
					string text = TextInList;
					if (string.IsNullOrEmpty(text))
					{
						text = Text;
					}
					return StringConvertHelper.ToChineseSpell(text);
				}
				return _SpellCode;
			}
		}

		/// <summary>
		///       排序编号
		///       </summary>
		[DefaultValue(0)]
		[DCPublishAPI]
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
		///       记录状态，在DCWriter中没有用处。仅为设计器提供支持。
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(false)]
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
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public ListItem()
		{
		}

		private void OnModified()
		{
			if (_RecordState == DataRowState.Unchanged)
			{
				_RecordState = DataRowState.Modified;
			}
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		[DCInternal]
		public override string ToString()
		{
			return "Text:" + Text + " Value:" + Value;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public ListItem Clone()
		{
			return (ListItem)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
