using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表项目列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[Guid("465F4EE4-5444-415B-A015-5B0992BFD6B1")]
	[Editor(typeof(ListItemCollectionEditor), typeof(UITypeEditor))]
	
	[ComVisible(true)]
	[XmlType("ListItems")]
	[ComClass("465F4EE4-5444-415B-A015-5B0992BFD6B1", "BD892CF8-D290-4F30-8794-160C62B151A4")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IListItemCollection))]
	public class ListItemCollection : List<ListItem>, ICloneable, IDCStringSerializable, IListItemCollection
	{
		private class TimeComparere : IComparer<ListItem>
		{
			public int Compare(ListItem listItem_0, ListItem listItem_1)
			{
				return DateTime.Compare(listItem_0.CheckedTime, listItem_1.CheckedTime);
			}
		}

		internal const string CLASSID = "465F4EE4-5444-415B-A015-5B0992BFD6B1";

		internal const string CLASSID_Interface = "BD892CF8-D290-4F30-8794-160C62B151A4";

		private bool _GenerateTemplate = true;

		/// <summary>
		///       这是临时生成的对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public bool GenerateTemplate
		{
			get
			{
				return _GenerateTemplate;
			}
			set
			{
				_GenerateTemplate = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public ListItemCollection()
		{
		}

		/// <summary>
		///       按照勾选时间进行排序
		///       </summary>
		
		public void SortByCheckedTime()
		{
			Sort(new TimeComparere());
		}

		/// <summary>
		///       添加列表项目
		///       </summary>
		/// <param name="Text">文本值</param>
		/// <param name="Value">数值</param>
		/// <returns>新增的列表项目对象</returns>
		
		public ListItem AddByTextValue(string Text, string Value)
		{
			ListItem listItem = new ListItem();
			listItem.Text = Text;
			listItem.Value = Value;
			Add(listItem);
			return listItem;
		}

		/// <summary>
		///       添加列表项目
		///       </summary>
		/// <param name="text">文本值</param>
		/// <param name="Value">数值</param>
		/// <param name="textInList">在下拉列表中的文本</param>
		/// <returns>新增的列表项目对象</returns>
		
		public ListItem AddByTextValueTextInList(string text, string Value, string textInList)
		{
			ListItem listItem = new ListItem();
			listItem.Text = text;
			listItem.Value = Value;
			listItem.TextInList = textInList;
			Add(listItem);
			return listItem;
		}

		/// <summary>
		///       添加列表项目
		///       </summary>
		/// <param name="text">文本值</param>
		/// <param name="Value">数值</param>
		/// <param name="spellCode">拼音码</param>
		/// <returns>新增的列表项目</returns>
		
		public ListItem AddByTextValueSpellCode(string text, string Value, string spellCode)
		{
			ListItem listItem = new ListItem();
			listItem.Text = text;
			listItem.Value = Value;
			listItem.SpellCode = spellCode;
			Add(listItem);
			return listItem;
		}

		/// <summary>
		///       数值转换为文本
		///       </summary>
		/// <param name="Value">数值</param>
		/// <returns>文本</returns>
		
		public string ValueToText(string Value)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListItem current = enumerator.Current;
					if (current.Value == Value)
					{
						return current.Text;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       将多个数值合并成一个文本
		///       </summary>
		/// <param name="Values">数值</param>
		/// <returns>文本</returns>
		
		public string MultiValuesToText(string Values)
		{
			int num = 2;
			if (string.IsNullOrEmpty(Values))
			{
				return null;
			}
			string[] array = Values.Split(',');
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListItem current = enumerator.Current;
					string[] array2 = array;
					foreach (string b in array2)
					{
						if (current.Value == b)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							stringBuilder.Append(current.Text);
							break;
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       文本转换为数值
		///       </summary>
		/// <param name="Text">文本</param>
		/// <returns>数值</returns>
		
		public string TextToValue(string Text)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListItem current = enumerator.Current;
					if (current.Text == Text)
					{
						return current.Value;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       简单的复制列表，但不复制列表项目实例
		///       </summary>
		/// <returns>复制品</returns>
		
		public ListItemCollection CloneSimple()
		{
			ListItemCollection listItemCollection = new ListItemCollection();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListItem current = enumerator.Current;
					listItemCollection.Add(current);
				}
			}
			return listItemCollection;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public ListItemCollection Clone()
		{
			return (ListItemCollection)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			ListItemCollection listItemCollection = new ListItemCollection();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListItem current = enumerator.Current;
					listItemCollection.Add(current.Clone());
				}
			}
			return listItemCollection;
		}

		
		public override string ToString()
		{
			if (base.Count == 0)
			{
				return "";
			}
			return string.Format(WriterStringsCore.Items_Count, base.Count);
		}

		
		public string DCWriteString()
		{
			int num = 17;
			GClass338 gClass = new GClass338();
			gClass.method_2("GenerateTemplate", GenerateTemplate.ToString());
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListItem current = enumerator.Current;
					gClass.method_2("ItemFlag", "1");
					ValueTypeHelper.GetPropertiesAttributeString(current, detectDefaultValue: true, gClass);
				}
			}
			return gClass.ToString();
		}

		
		public void DCReadString(string text)
		{
			int num = 14;
			Clear();
			GClass340 gClass = new GClass340(text);
			ListItem listItem = null;
			foreach (GClass341 item in gClass)
			{
				if (item.Name == "GenerateTemplate")
				{
					GenerateTemplate = Convert.ToBoolean(item.method_0());
				}
				if (item.Name == "ItemFlag")
				{
					listItem = new ListItem();
					Add(listItem);
				}
				if (listItem != null)
				{
					switch (item.Name)
					{
					case "CheckedTime":
						listItem.CheckedTime = Convert.ToDateTime(item.method_0());
						break;
					case "EntryID":
						listItem.EntryID = item.method_0();
						break;
					case "Group":
						listItem.Group = item.method_0();
						break;
					case "ID":
						listItem.ID = item.method_0();
						break;
					case "ListIndex":
						listItem.ListIndex = Convert.ToInt32(item.method_0());
						break;
					case "SpellCode":
						listItem.SpellCode = item.method_0();
						break;
					case "SpellCode2":
						listItem.SpellCode2 = item.method_0();
						break;
					case "SpellCode3":
						listItem.SpellCode3 = item.method_0();
						break;
					case "Tag":
						listItem.Tag = item.method_0();
						break;
					case "Text":
						listItem.Text = item.method_0();
						break;
					case "Text2":
						listItem.Text2 = item.method_0();
						break;
					case "TextInList":
						listItem.TextInList = item.method_0();
						break;
					case "Value":
						listItem.Value = item.method_0();
						break;
					}
				}
			}
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		
		[ComVisible(true)]
		public ListItem ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		
		[ComVisible(true)]
		public void ComSetItem(int index, ListItem item)
		{
			base[index] = item;
		}
	}
}
