using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表数据源信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[Editor(typeof(ListSourceInfoEditor), typeof(UITypeEditor))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890032")]
	[DocumentComment]
	[DCPublishAPI]
	[ComClass("00012345-6789-ABCD-EF01-234567890032", "C3F5C68B-53B5-48D5-A352-46ADD435CC72")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IListSourceInfo))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	public sealed class ListSourceInfo : ICloneable, IListSourceInfo
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890032";

		internal const string CLASSID_Interface = "C3F5C68B-53B5-48D5-A352-46ADD435CC72";

		private static string[] _SupportSourceNames = null;

		private string _Name = null;

		private string _SourceName = null;

		private string _DisplayPath = null;

		private string _ValuePath = null;

		private ListItemCollection _Items = null;

		private bool _BufferItems = true;

		[NonSerialized]
		private ListItemCollection _RuntimeItems = null;

		/// <summary>
		///       设计器支持的数据源名称数组
		///       </summary>
		public static string[] SupportSourceNames
		{
			get
			{
				return _SupportSourceNames;
			}
			set
			{
				_SupportSourceNames = value;
			}
		}

		/// <summary>
		///       对象内容是否为空
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public bool IsEmpty
		{
			get
			{
				if (Items != null && Items.Count > 0)
				{
					return false;
				}
				if (RuntimeItems != null && RuntimeItems.Count > 0)
				{
					return false;
				}
				return string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(SourceName);
			}
		}

		/// <summary>
		///       列表数据源名称
		///       </summary>
		[DefaultValue(null)]
		[Obsolete("无效属性")]
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
		///       来源名称
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string SourceName
		{
			get
			{
				return _SourceName;
			}
			set
			{
				_SourceName = value;
			}
		}

		/// <summary>
		///       过时的属性，DCWriter已经不使用了。
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string DisplayPath
		{
			get
			{
				return _DisplayPath;
			}
			set
			{
				_DisplayPath = value;
			}
		}

		/// <summary>
		///       过时的属性，DCWriter已经不使用了。
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string ValuePath
		{
			get
			{
				return _ValuePath;
			}
			set
			{
				_ValuePath = value;
			}
		}

		/// <summary>
		///       内置的列表项目
		///       </summary>
		[XmlArrayItem("Item", typeof(ListItem))]
		[DCPublishAPI]
		public ListItemCollection Items
		{
			get
			{
				if (_Items == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					_Items = new ListItemCollection();
				}
				if (_Items != null)
				{
					_Items.GenerateTemplate = false;
				}
				return _Items;
			}
			set
			{
				_Items = value;
			}
		}

		/// <summary>
		///       是否缓存列表项目
		///       </summary>
		[DefaultValue(true)]
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
		///       实际运行中的列表项目集合,只有当BufferItems=true时该属性才可能有内容。
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DCInternal]
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

		public static ListItemCollection smethod_0(WriterControl writerControl_0, XTextElement xtextElement_0, WriterAppHost writerAppHost_0, ListSourceInfo listSourceInfo_0, IListSourceProvider ilistSourceProvider_0, object object_0, string string_0, bool bool_0, string string_1)
		{
			int num = 0;
			bool flag = true;
			if (xtextElement_0 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xtextElement_0;
				if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.DynamicListItems)
				{
					flag = false;
				}
			}
			if (flag && listSourceInfo_0 != null && listSourceInfo_0.BufferItems && listSourceInfo_0.RuntimeItems != null)
			{
				return listSourceInfo_0.RuntimeItems;
			}
			if (flag && listSourceInfo_0 != null && listSourceInfo_0.Items != null && listSourceInfo_0.Items.Count > 0)
			{
				return listSourceInfo_0.Items;
			}
			if (object_0 == null)
			{
				if (writerControl_0 != null && xtextElement_0 != null)
				{
					QueryListItemsEventArgs queryListItemsEventArgs = new QueryListItemsEventArgs(writerControl_0, xtextElement_0.OwnerDocument, xtextElement_0);
					queryListItemsEventArgs.RaiseEvent = bool_0;
					queryListItemsEventArgs.SpellCode = string_0;
					queryListItemsEventArgs.SpecifyValue = string_1;
					if (listSourceInfo_0 != null)
					{
						queryListItemsEventArgs.ListSourceName = listSourceInfo_0.SourceName;
					}
					KBLibrary kBLibrary = null;
					if (writerControl_0 != null)
					{
						kBLibrary = writerControl_0.KBLibrary;
					}
					if (kBLibrary == null)
					{
						kBLibrary = writerAppHost_0.KBLibrary;
					}
					if (kBLibrary != null && listSourceInfo_0 != null)
					{
						KBEntry kBEntry2 = queryListItemsEventArgs.KBEntry = kBLibrary.SearchKBEntry(listSourceInfo_0.SourceName);
						if (kBEntry2 != null && kBEntry2.Style == KBEntryStyle.List)
						{
							queryListItemsEventArgs.Result = kBEntry2.ListItems;
						}
					}
					if (queryListItemsEventArgs.Result == null || queryListItemsEventArgs.Result.Count == 0)
					{
						writerControl_0.OnQueryListItems(queryListItemsEventArgs);
					}
					if (queryListItemsEventArgs.Handled || (queryListItemsEventArgs.Result != null && queryListItemsEventArgs.Result.Count > 0))
					{
						return queryListItemsEventArgs.Result;
					}
				}
				if (object_0 == null && ilistSourceProvider_0 != null)
				{
					ListSourceEventArgs args = new ListSourceEventArgs(writerAppHost_0, writerAppHost_0.Services, listSourceInfo_0);
					object_0 = ilistSourceProvider_0.GetListSource(args);
				}
			}
			if (object_0 == null)
			{
				return null;
			}
			ListItemCollection listItemCollection = null;
			listItemCollection = new ListItemCollection();
			IEnumerable enumerable = null;
			if (object_0 is IEnumerable)
			{
				enumerable = (IEnumerable)object_0;
			}
			else if (object_0 is IListSource)
			{
				enumerable = ((IListSource)object_0).GetList();
			}
			else if (object_0 is XmlNode)
			{
				enumerable = ((XmlNode)object_0).ChildNodes;
			}
			if (enumerable != null)
			{
				XDataBindingProvider bindingProvider = (XDataBindingProvider)writerAppHost_0.Services.GetService(typeof(XDataBindingProvider));
				foreach (object item in enumerable)
				{
					if (item is ListItem)
					{
						listItemCollection.Add((ListItem)item);
					}
					else
					{
						ListItem listItem = new ListItem();
						if (ilistSourceProvider_0 == null)
						{
							listItem.Text = StdGetDisplayText(item, listSourceInfo_0, bindingProvider);
							listItem.Value = StdGetValue(item, listSourceInfo_0, bindingProvider);
							listItem.Tag = StdGetTag(item, listSourceInfo_0, bindingProvider);
						}
						else
						{
							ListSourceEventArgs listSourceEventArgs = new ListSourceEventArgs(writerAppHost_0, writerAppHost_0.Services, listSourceInfo_0);
							listSourceEventArgs.Value = item;
							listItem.Text = ilistSourceProvider_0.GetDisplayText(listSourceEventArgs);
							listItem.Value = ilistSourceProvider_0.GetValue(listSourceEventArgs);
							listItem.Tag = ilistSourceProvider_0.GetTag(listSourceEventArgs);
						}
						listItemCollection.Add(listItem);
					}
				}
			}
			if (listSourceInfo_0 != null && listSourceInfo_0.BufferItems)
			{
				listSourceInfo_0.RuntimeItems = listItemCollection;
			}
			if (writerAppHost_0.Debuger != null)
			{
				writerAppHost_0.Debuger.WriteLine(string.Format(WriterStringsCore.LoadListItems_ProviderType_Name_Num, (ilistSourceProvider_0 == null) ? "NULL" : ilistSourceProvider_0.GetType().Name, (listSourceInfo_0 == null) ? "" : listSourceInfo_0.SourceName, (listItemCollection == null) ? "NULL" : listItemCollection.Count.ToString()));
			}
			return listItemCollection;
		}

		/// <summary>
		///       获得标准的显示文本,DCWriter内部使用.
		///       </summary>
		/// <param name="Value">要显示的数据</param>
		/// <param name="info">信息对象</param>
		/// <param name="bindingProvider">提供者</param>
		/// <returns>显示的文本</returns>
		[DCInternal]
		public static string StdGetDisplayText(object Value, ListSourceInfo info, XDataBindingProvider bindingProvider)
		{
			return smethod_1(Value, info, 0, bindingProvider);
		}

		/// <summary>
		///       获得后台数据,DCWriter内部使用.
		///       </summary>
		/// <param name="Value">数值对象</param>
		/// <param name="info">信息对象</param>
		/// <param name="bindingProvider">提供者</param>
		/// <returns>后台数据</returns>
		[DCInternal]
		public static string StdGetValue(object Value, ListSourceInfo info, XDataBindingProvider bindingProvider)
		{
			return smethod_1(Value, info, 1, bindingProvider);
		}

		/// <summary>
		///       获得标记数据,DCWriter内部使用.
		///       </summary>
		/// <param name="Value">数据对象</param>
		/// <param name="info">信息对象</param>
		/// <param name="bindingProvider">提供者</param>
		/// <returns>后台数据</returns>
		[DCInternal]
		public static string StdGetTag(object Value, ListSourceInfo info, XDataBindingProvider bindingProvider)
		{
			if (Value is ListItem)
			{
				ListItem listItem = (ListItem)Value;
				return listItem.Tag;
			}
			return null;
		}

		private static string smethod_1(object object_0, ListSourceInfo listSourceInfo_0, int int_0, XDataBindingProvider xdataBindingProvider_0)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return null;
			}
			string value = null;
			switch (int_0)
			{
			case 0:
				value = listSourceInfo_0.DisplayPath;
				break;
			case 1:
				value = listSourceInfo_0.ValuePath;
				break;
			}
			if (object_0 is ListItem)
			{
				ListItem listItem = (ListItem)object_0;
				switch (int_0)
				{
				case 0:
					if (string.IsNullOrEmpty(listSourceInfo_0.DisplayPath))
					{
						return listItem.Text;
					}
					break;
				case 1:
					if (string.IsNullOrEmpty(listSourceInfo_0.ValuePath))
					{
						return listItem.Value;
					}
					break;
				}
			}
			object obj;
			if (string.IsNullOrEmpty(value))
			{
				obj = null;
				if (object_0 is IList)
				{
					IList list = (IList)object_0;
					obj = ((list.Count <= int_0) ? list[0] : list[int_0]);
					return Convert.ToString(obj);
				}
				if (object_0 is IDataRecord)
				{
					IDataRecord dataRecord = (IDataRecord)object_0;
					obj = ((dataRecord.FieldCount <= int_0) ? dataRecord.GetValue(0) : dataRecord.GetValue(int_0));
				}
				else if (object_0 is DataRow)
				{
					DataRow dataRow = (DataRow)object_0;
					obj = ((dataRow.Table.Columns.Count <= int_0) ? dataRow[0] : dataRow[int_0]);
				}
				else if (object_0 is DataRowView)
				{
					DataRowView dataRowView = (DataRowView)object_0;
					obj = ((dataRowView.Row.Table.Columns.Count <= int_0) ? dataRowView[0] : dataRowView[int_0]);
				}
				else
				{
					obj = object_0;
				}
				if (obj == null || DBNull.Value.Equals(obj))
				{
					return null;
				}
				return Convert.ToString(obj);
			}
			GClass114 gClass = GClass114.smethod_1(object_0.GetType(), (int_0 == 0) ? listSourceInfo_0.DisplayPath : listSourceInfo_0.ValuePath, bool_1: false);
			if (gClass == null)
			{
				return null;
			}
			obj = object_0;
			obj = XDataBindingProvider.StdReadValue(gClass, object_0, null, throwException: false, xdataBindingProvider_0);
			if (obj == null || DBNull.Value.Equals(obj))
			{
				return null;
			}
			return Convert.ToString(obj);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public ListSourceInfo()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public ListSourceInfo Clone()
		{
			return (ListSourceInfo)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			ListSourceInfo listSourceInfo = (ListSourceInfo)MemberwiseClone();
			if (_Items != null)
			{
				listSourceInfo._Items = new ListItemCollection();
				foreach (ListItem item in _Items)
				{
					listSourceInfo._Items.Add(item.Clone());
				}
			}
			return listSourceInfo;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 10;
			if (Items != null && Items.Count > 0)
			{
				return Items.Count + " items";
			}
			return SourceName;
		}
	}
}
