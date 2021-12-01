using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       输入设置
	///       </summary>
	[Serializable]
	[ComClass("3D3A82BF-14AB-4560-A022-C3C88C7377E4", "6C95AC4B-26D3-4EAA-9C1E-4F0B015E8CE5")]
	[Guid("3D3A82BF-14AB-4560-A022-C3C88C7377E4")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[DCPublishAPI]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IInputFieldSettings))]
	[DocumentComment]
	public class InputFieldSettings : ICloneable, IInputFieldSettings
	{
		internal const string CLASSID = "3D3A82BF-14AB-4560-A022-C3C88C7377E4";

		internal const string CLASSID_Interface = "6C95AC4B-26D3-4EAA-9C1E-4F0B015E8CE5";

		private static string[] _SupportCustomListSourceNames = null;

		private bool _GetValueOrderByTime = false;

		private InputFieldEditStyle _EditStyle = InputFieldEditStyle.Text;

		private bool _MultiColumn = false;

		private bool _RepulsionForGroup = false;

		private bool _MultiSelect = false;

		private bool _DynamicListItems = false;

		private ListSourceInfo _ListSource = null;

		private string _ListValueFormatString = null;

		private string _ListValueSeparatorChar = ",";

		[NonSerialized]
		private bool _EnableCustomListItems = true;

		[NonSerialized]
		private string _CustomListSource = null;

		[NonSerialized]
		private InputFieldListItemList _ListItems = new InputFieldListItemList();

		/// <summary>
		///       支持的自定义列表来源名称
		///       </summary>
		[DCPublishAPI]
		public static string[] SupportCustomListSourceNames
		{
			get
			{
				return _SupportCustomListSourceNames;
			}
			set
			{
				_SupportCustomListSourceNames = value;
			}
		}

		/// <summary>
		///       从弹出式列表中获得数值时进行勾选操作时间排序
		///       </summary>
		/// <remarks>
		///       在多选下拉列表中，为了用户可以勾选多个项目，若设置这个属性值为true，则文档中显示的多个项目
		///       会按照勾选操作的时间上的先后顺序进行排序，而不是列表中是上下顺序进行排序。
		///       </remarks>
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool GetValueOrderByTime
		{
			get
			{
				return _GetValueOrderByTime;
			}
			set
			{
				_GetValueOrderByTime = value;
			}
		}

		/// <summary>
		///       输入方式
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(InputFieldEditStyle.Text)]
		public InputFieldEditStyle EditStyle
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

		internal InputFieldEditStyle RuntimeEditStyle
		{
			get
			{
				if ((_EditStyle == InputFieldEditStyle.Date || _EditStyle == InputFieldEditStyle.DateTime || _EditStyle == InputFieldEditStyle.DateTimeWithoutSecond || _EditStyle == InputFieldEditStyle.Time) && !XTextDocument.smethod_13(GEnum6.const_173))
				{
					return InputFieldEditStyle.Text;
				}
				if (_EditStyle == InputFieldEditStyle.Numeric && !XTextDocument.smethod_13(GEnum6.const_174))
				{
					return InputFieldEditStyle.Text;
				}
				if (_EditStyle == InputFieldEditStyle.DropdownList && !XTextDocument.smethod_13(GEnum6.const_172))
				{
					return InputFieldEditStyle.Text;
				}
				return _EditStyle;
			}
		}

		/// <summary>
		///       多列项目
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool MultiColumn
		{
			get
			{
				return _MultiColumn;
			}
			set
			{
				_MultiColumn = value;
			}
		}

		/// <summary>
		///       列表项目分组互斥
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool RepulsionForGroup
		{
			get
			{
				return _RepulsionForGroup;
			}
			set
			{
				_RepulsionForGroup = value;
			}
		}

		/// <summary>
		///       允许多选列表项目
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool MultiSelect
		{
			get
			{
				return _MultiSelect;
			}
			set
			{
				_MultiSelect = value;
			}
		}

		/// <summary>
		///       动态加载列表项目
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool DynamicListItems
		{
			get
			{
				return _DynamicListItems;
			}
			set
			{
				_DynamicListItems = value;
			}
		}

		/// <summary>
		///       列表内容来源
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public ListSourceInfo ListSource
		{
			get
			{
				if (_ListSource == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					_ListSource = new ListSourceInfo();
				}
				return _ListSource;
			}
			set
			{
				_ListSource = value;
			}
		}

		/// <summary>
		///       列表数值格式化字符串
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ListValueFormatString
		{
			get
			{
				return _ListValueFormatString;
			}
			set
			{
				_ListValueFormatString = value;
			}
		}

		/// <summary>
		///       列表值之间的分隔字符
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(",")]
		public string ListValueSeparatorChar
		{
			get
			{
				return _ListValueSeparatorChar;
			}
			set
			{
				_ListValueSeparatorChar = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。
		///       </summary>
		[DCInternal]
		public string RuntimeListValueSeparator => StringConvertHelper.ParseCStyleEscapedString(ListValueSeparatorChar);

		/// <summary>
		///       是否允许使用自定义列表项目,已过时，不再使用。
		///       </summary>
		[DefaultValue(true)]
		[Obsolete("本属性仅为保留向前兼容性，不再使用！！！")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableCustomListItems
		{
			get
			{
				return _EnableCustomListItems;
			}
			set
			{
				_EnableCustomListItems = value;
			}
		}

		/// <summary>
		///       自定义的下列表数据源的名称,已过时，不再使用。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★★★本属性仅为保留向前兼容性，不再使用！！！")]
		[DefaultValue(null)]
		public string CustomListSource
		{
			get
			{
				return _CustomListSource;
			}
			set
			{
				_CustomListSource = value;
			}
		}

		/// <summary>
		///       列表项目,已过时，不再使用。
		///       </summary>
		[DCInternal]
		[XmlArrayItem("Item", typeof(InputFieldListItem))]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(null)]
		public InputFieldListItemList ListItems
		{
			get
			{
				return _ListItems;
			}
			set
			{
				_ListItems = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public InputFieldSettings()
		{
		}

		/// <summary>
		///       为了程序兼容性而修正相关的设置
		///       </summary>
		public void FixListSourceSettings()
		{
			if (_ListSource == null)
			{
				_ListSource = new ListSourceInfo();
			}
			string customListSource = CustomListSource;
			if (!string.IsNullOrEmpty(customListSource))
			{
				ListSource.SourceName = customListSource;
			}
			CustomListSource = null;
			if (ListItems != null && ListItems.Count > 0)
			{
				if (ListSource.Items == null)
				{
					ListSource.Items = new ListItemCollection();
				}
				foreach (InputFieldListItem listItem2 in ListItems)
				{
					ListItem listItem = new ListItem();
					listItem.Text = listItem2.Text;
					listItem.Value = listItem2.Value;
					listItem.Tag = listItem2.Tag;
					ListSource.Items.Add(listItem);
				}
			}
			ListItems = null;
			if (_ListSource.IsEmpty)
			{
				_ListSource = null;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public InputFieldSettings Clone()
		{
			return (InputFieldSettings)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			InputFieldSettings inputFieldSettings = (InputFieldSettings)MemberwiseClone();
			if (_ListSource != null)
			{
				inputFieldSettings._ListSource = _ListSource.Clone();
			}
			return inputFieldSettings;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 9;
			if (EditStyle == InputFieldEditStyle.Text)
			{
				return "Text";
			}
			if (EditStyle == InputFieldEditStyle.DropdownList)
			{
				if (ListSource == null)
				{
					return "None list item";
				}
				return "List:" + ListSource.ToString();
			}
			if (EditStyle == InputFieldEditStyle.Date)
			{
				return "DateTime ";
			}
			return "";
		}
	}
}
