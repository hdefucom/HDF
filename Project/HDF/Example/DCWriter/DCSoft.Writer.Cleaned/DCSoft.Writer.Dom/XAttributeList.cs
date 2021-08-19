using DCSoft.Common;
using DCSoft.Writer.Dom.Design;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       属性列表
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-23456789004C")]
	[ComClass("00012345-6789-ABCD-EF01-23456789004C", "2AFDACB6-DDCD-4A96-852A-8B980079E70E")]
	[ComDefaultInterface(typeof(IXAttributeList))]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("Count={ Count }")]
	[DCPublishAPI]
	[DocumentComment]
	[Editor(typeof(XAttributeListEditor), typeof(UITypeEditor))]
	public class XAttributeList : List<XAttribute>, ICloneable, IDCStringSerializable, IXAttributeList
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789004C";

		internal const string CLASSID_Interface = "2AFDACB6-DDCD-4A96-852A-8B980079E70E";

		/// <summary>
		///       获得指定名称的属性对象
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		[DCPublishAPI]
		public XAttribute this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XAttribute current = enumerator.Current;
						if (current.Name == name)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XAttributeList()
		{
		}

		/// <summary>
		///       判断是否存在指定名称的属性
		///       </summary>
		/// <param name="name">指定的属性名</param>
		/// <returns>是否存在指定的属性</returns>
		[DCPublishAPI]
		public bool ContainsByName(string name)
		{
			return this[name] != null;
		}

		/// <summary>
		///       删除指定名称的属性
		///       </summary>
		/// <param name="name">指定的属性名</param>
		[DCPublishAPI]
		public void RemoveByName(string name)
		{
			XAttribute xAttribute = this[name];
			if (xAttribute != null)
			{
				Remove(xAttribute);
			}
		}

		/// <summary>
		///       获得指定名称的属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		[DCPublishAPI]
		public string GetValue(string name)
		{
			return this[name]?.Value;
		}

		/// <summary>
		///       设置指定名称的属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		[DCPublishAPI]
		public void SetValue(string name, string Value)
		{
			XAttribute xAttribute = this[name];
			if (Value == null || Value.Length == 0)
			{
				if (xAttribute != null)
				{
					Remove(xAttribute);
				}
			}
			else if (xAttribute == null)
			{
				xAttribute = new XAttribute(name, Value);
				Add(xAttribute);
			}
			else
			{
				xAttribute.Value = Value;
			}
		}

		[DCInternal]
		object ICloneable.Clone()
		{
			XAttributeList xAttributeList = new XAttributeList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XAttribute current = enumerator.Current;
					xAttributeList.Add(current.Clone());
				}
			}
			return xAttributeList;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public XAttributeList Clone()
		{
			return (XAttributeList)((ICloneable)this).Clone();
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		[DCInternal]
		public override string ToString()
		{
			int num = 12;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XAttribute current = enumerator.Current;
					stringBuilder.Append(current.Name + "=" + current.Value);
					if (stringBuilder.Length > 250)
					{
						break;
					}
				}
			}
			stringBuilder.Insert(0, base.Count + " Items:");
			return stringBuilder.ToString();
		}

		/// <summary>
		///       获得属性列表
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <param name="create">是否自动创建</param>
		/// <returns>获得的属性列表</returns>
		[DCInternal]
		public static XAttributeList GetAttributes(XTextElement element, bool create)
		{
			if (element == null)
			{
				return null;
			}
			if (element is XTextObjectElement)
			{
				XTextObjectElement xTextObjectElement = (XTextObjectElement)element;
				if (create && xTextObjectElement.Attributes == null)
				{
					xTextObjectElement.Attributes = new XAttributeList();
				}
				return xTextObjectElement.Attributes;
			}
			if (element is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)element;
				if (create && xTextContainerElement.Attributes == null)
				{
					xTextContainerElement.Attributes = new XAttributeList();
				}
				return xTextContainerElement.Attributes;
			}
			return null;
		}

		[DCInternal]
		public string DCWriteString()
		{
			GClass338 gClass = new GClass338();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XAttribute current = enumerator.Current;
					gClass.method_2(current.Name, current.Value);
				}
			}
			return gClass.ToString();
		}

		[DCInternal]
		public void DCReadString(string text)
		{
			Clear();
			GClass340 gClass = new GClass340(text);
			foreach (GClass341 item in gClass)
			{
				XAttribute xAttribute = new XAttribute();
				xAttribute.Name = item.Name;
				xAttribute.Value = item.method_0();
				Add(xAttribute);
			}
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XAttribute ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void ComSetItem(int index, XAttribute item)
		{
			base[index] = item;
		}
	}
}
