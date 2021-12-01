using DCSoft.Writer.Data;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	[Serializable]
	[XmlType(Namespace = "http://dcwriter.cn")]
	[ComVisible(false)]
	public class WriterControlWebServiceProtocolForJavaListItem
	{
		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string ID
		{
			get;
			set;
		}

		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string EntryID
		{
			get;
			set;
		}

		[DefaultValue(false)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public bool LonelyChecked
		{
			get;
			set;
		}

		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string TextInList
		{
			get;
			set;
		}

		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		[DefaultValue(null)]
		public string Group
		{
			get;
			set;
		}

		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public DateTime CheckedTime
		{
			get;
			set;
		}

		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		[DefaultValue(null)]
		public string Tag
		{
			get;
			set;
		}

		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		[DefaultValue(null)]
		public string SpellCode
		{
			get;
			set;
		}

		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string SpellCode2
		{
			get;
			set;
		}

		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string SpellCode3
		{
			get;
			set;
		}

		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		[DefaultValue(0)]
		public int ListIndex
		{
			get;
			set;
		}

		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string Text
		{
			get;
			set;
		}

		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		[DefaultValue(null)]
		public string Text2
		{
			get;
			set;
		}

		[DefaultValue(null)]
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string Value
		{
			get;
			set;
		}

		internal ListItem CreateItem()
		{
			ListItem listItem = new ListItem();
			listItem.ID = ID;
			listItem.EntryID = EntryID;
			listItem.LonelyChecked = LonelyChecked;
			listItem.Text = Text;
			listItem.TextInList = TextInList;
			listItem.Text2 = Text2;
			listItem.Tag = Tag;
			listItem.CheckedTime = CheckedTime;
			listItem.SpellCode = SpellCode;
			listItem.SpellCode2 = SpellCode2;
			listItem.SpellCode3 = SpellCode3;
			listItem.ListIndex = ListIndex;
			listItem.Value = Value;
			return listItem;
		}
	}
}
