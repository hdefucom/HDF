using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       元素对象列表
	///       </summary>
	/// <remarks>
	///       本列表专门用于放置若干个文本文档元素对象
	///       编制 袁永福 2006-11-13
	///       </remarks>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-23456789000D")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComDefaultInterface(typeof(IXTextElementList))]
	[ComVisible(true)]
	[ComClass("00012345-6789-ABCD-EF01-23456789000D", "F8FC43D5-EE32-3BE2-86E3-30332E3AFBA7")]
	
	[DebuggerDisplay("Count={ Count }")]
	public class XTextElementList : List<XTextElement>, IEnumerable, ICloneable, IXTextElementList
	{
		internal const string string_0 = "00012345-6789-ABCD-EF01-23456789000D";

		internal const string string_1 = "F8FC43D5-EE32-3BE2-86E3-30332E3AFBA7";

		[NonSerialized]
		internal bool bool_0;

		private XTextContainerElement xtextContainerElement_0;

		/// <summary>
		///       本文本行行尾是不是行结束类型的元素
		///       </summary>
		public bool HasLineEndElement
		{
			get
			{
				if (base.Count > 0)
				{
					XTextElement xTextElement = base[base.Count - 1];
					if (xTextElement is XTextEOFElement)
					{
						return true;
					}
					if (xTextElement.OwnerDocument.DocumentControler.vmethod_9(xTextElement))
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       列表所属容器元素
		///       </summary>
		public XTextContainerElement OwnerElement => xtextContainerElement_0;

		/// <summary>
		///       列表中的第一个元素
		///       </summary>
		
		public XTextElement FirstElement
		{
			get
			{
				if (base.Count > 0)
				{
					return base[0];
				}
				return null;
			}
		}

		/// <summary>
		///       列表中的最后一个元素
		///       </summary>
		
		public XTextElement LastElement
		{
			get
			{
				int count = base.Count;
				if (count > 0)
				{
					return base[count - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       DCWriter内部使用。元素列表中第一个显示在文档视图中的元素
		///       </summary>
		public XTextElement FirstContentElement
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XTextElement current = enumerator.Current;
						if (current is XTextTableElement)
						{
							XTextTableElement xTextTableElement = (XTextTableElement)current;
							if (xTextTableElement.FirstCell != null)
							{
								return xTextTableElement.FirstCell.FirstContentElement;
							}
						}
						else if (current is XTextSectionElement)
						{
							XTextSectionElement xTextSectionElement = (XTextSectionElement)current;
							return xTextSectionElement.Elements.FirstContentElement;
						}
						XTextElement firstContentElement = current.FirstContentElement;
						if (firstContentElement != null)
						{
							return firstContentElement;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       DCWriter内部使用。元素列表中最后一个显示在文档视图中的元素
		///       </summary>
		public XTextElement LastContentElement
		{
			get
			{
				int num = base.Count - 1;
				XTextElement lastContentElement;
				while (true)
				{
					if (num >= 0)
					{
						lastContentElement = base[num].LastContentElement;
						if (lastContentElement != null)
						{
							break;
						}
						num--;
						continue;
					}
					return null;
				}
				return lastContentElement;
			}
		}

		/// <summary>
		///       初始化对象 
		///       </summary>
		public XTextElementList()
		{
			bool_0 = false;
			xtextContainerElement_0 = null;
			
		}

		public void method_0(bool bool_1)
		{
			if (base.Count > 0)
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XTextElement current = enumerator.Current;
						current.vmethod_0(bool_1);
					}
				}
			}
		}

		public int method_1(XTextElement xtextElement_0)
		{
			int num = base.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (base[num] == xtextElement_0)
					{
						break;
					}
					num--;
					continue;
				}
				return -1;
			}
			return num;
		}

		public IEnumerable method_2()
		{
			return new DomTreeNodeEnumerable(this);
		}

		/// <summary>
		///       获得本文档元素容器包含的所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementType">元素类型</param>
		/// <returns>获得的元素列表</returns>
		[ComVisible(false)]
		public XTextElementList GetElementsByTypeDeeply(Type elementType)
		{
			int num = 12;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new InvalidCastException(elementType.FullName);
			}
			XTextElementList xTextElementList = new XTextElementList();
			if (elementType.Equals(typeof(XTextCharElement)))
			{
				method_3(this, xTextElementList, elementType);
			}
			else
			{
				method_4(this, xTextElementList, elementType);
			}
			return xTextElementList;
		}

		private void method_3(XTextElementList xtextElementList_0, XTextElementList xtextElementList_1, Type type_0)
		{
			bool flag = type_0.Equals(typeof(XTextCharElement));
			foreach (XTextElement item in xtextElementList_0)
			{
				if (flag || !(item is XTextCharElement))
				{
					if (type_0.IsInstanceOfType(item))
					{
						xtextElementList_1.Add(item);
					}
					if (item is XTextContainerElement)
					{
						method_3(item.Elements, xtextElementList_1, type_0);
					}
				}
			}
		}

		private void method_4(XTextElementList xtextElementList_0, XTextElementList xtextElementList_1, Type type_0)
		{
			foreach (XTextElement item in xtextElementList_0)
			{
				if (!(item is XTextCharElement) && !(item is XTextParagraphFlagElement))
				{
					if (type_0.IsInstanceOfType(item))
					{
						xtextElementList_1.Add(item);
					}
					if (item is XTextContainerElement)
					{
						method_4(item.Elements, xtextElementList_1, type_0);
					}
				}
			}
		}

		/// <summary>
		///       获得对象
		///       </summary>
		/// <param name="index">
		/// </param>
		/// <returns>
		/// </returns>
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public XTextElement GetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       获得所有元素的指定名称的属性值
		///       </summary>
		/// <param name="propertyName">属性名</param>
		/// <returns>属性值数组</returns>
		public object[] GetPropertyValues(string propertyName)
		{
			int num = 10;
			ArrayList arrayList = new ArrayList();
			Type type = null;
			PropertyInfo propertyInfo = null;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextElement current = enumerator.Current;
					if (type == null || !current.GetType().Equals(type))
					{
						type = current.GetType();
						propertyInfo = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						if (propertyInfo != null && !propertyInfo.CanRead)
						{
							propertyInfo = null;
						}
						if (propertyInfo != null)
						{
							ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
							if (indexParameters != null && indexParameters.Length > 0)
							{
								propertyInfo = null;
							}
						}
					}
					if (propertyInfo == null)
					{
						arrayList.Add(">_<");
					}
					else
					{
						arrayList.Add(propertyInfo.GetValue(current, Type.EmptyTypes));
					}
				}
			}
			return arrayList.ToArray();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">默认就包含的元素</param>
		public XTextElementList(XTextElement xtextElement_0)
		{
			int num = 19;
			bool_0 = false;
			xtextContainerElement_0 = null;
			
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			Add(xtextElement_0);
		}

		public XTextElement method_5(Type type_0)
		{
			int num = 7;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextElement current = enumerator.Current;
					if (type_0.IsInstanceOfType(current))
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       移动元素位置
		///       </summary>
		/// <param name="oldIndex">旧位置</param>
		/// <param name="newIndex">新位置</param>
		/// <returns>操作是否成功</returns>
		public bool MoveElement(int oldIndex, int newIndex)
		{
			if (oldIndex == newIndex)
			{
				return false;
			}
			XTextElement xtextElement_ = base[oldIndex];
			RemoveAt(oldIndex);
			method_13(newIndex, xtextElement_);
			return true;
		}

		/// <summary>
		///       进行元素位置的交换
		///       </summary>
		/// <param name="index1">序号1</param>
		/// <param name="index2">序号2</param>
		/// <returns>操作是否修改了列表</returns>
		public bool SwapElement(int index1, int index2)
		{
			int num = 11;
			if (index1 == index2)
			{
				return false;
			}
			if (index1 < 0 || index1 >= base.Count)
			{
				throw new ArgumentOutOfRangeException("index1:" + index1);
			}
			if (index2 < 0 || index2 >= base.Count)
			{
				throw new ArgumentOutOfRangeException("index2:" + index2);
			}
			XTextElement value = base[index1];
			base[index1] = base[index2];
			base[index2] = value;
			return true;
		}

		/// <summary>
		///       修正元素序号以保证需要在元素列表的范围内
		///       </summary>
		/// <param name="index">原始的序号</param>
		/// <returns>修正后的序号</returns>
		public int FixElementIndex(int index)
		{
			if (index <= 0)
			{
				return 0;
			}
			if (index >= base.Count)
			{
				return base.Count - 1;
			}
			return index;
		}

		/// <summary>
		///       检查元素序号是否合法
		///       </summary>
		/// <param name="index">元素序号</param>
		/// <returns>是否合法</returns>
		public bool CheckElementIndex(int index)
		{
			return index >= 0 && index < base.Count - 1;
		}

		internal void method_6(XTextContainerElement xtextContainerElement_1)
		{
			xtextContainerElement_0 = xtextContainerElement_1;
		}

		private void method_7()
		{
		}

		/// <summary>
		///       安全的获得指定序号的元素,若序号超出范围则返回空引用
		///       </summary>
		/// <param name="index">序号</param>
		/// <returns>获得的元素对象</returns>
		public XTextElement SafeGet(int index)
		{
			if (index >= 0 && index < base.Count)
			{
				return base[index];
			}
			return null;
		}

		internal int method_8(XTextElement xtextElement_0)
		{
			int contentIndex = xtextElement_0.ContentIndex;
			if (contentIndex >= 0 && contentIndex < base.Count && base[contentIndex] == xtextElement_0)
			{
				return contentIndex;
			}
			return IndexOf(xtextElement_0);
		}

		internal int method_9(XTextElement xtextElement_0)
		{
			int privateContentIndex = xtextElement_0.PrivateContentIndex;
			if (privateContentIndex >= 0 && privateContentIndex < base.Count && base[privateContentIndex] == xtextElement_0)
			{
				return privateContentIndex;
			}
			return IndexOf(xtextElement_0);
		}

		internal int method_10(XTextElement xtextElement_0)
		{
			int count = base.Count;
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					XTextElement xTextElement = base[num];
					if (xTextElement == xtextElement_0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		internal XTextParagraphFlagElement method_11(int int_0)
		{
			int count = base.Count;
			int num = int_0;
			while (true)
			{
				if (num < count)
				{
					if (base[num] is XTextParagraphFlagElement)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return (XTextParagraphFlagElement)base[num];
		}

		/// <summary>
		///       快速的获得对象在列表中的序号
		///       </summary>
		/// <param name="element">对象</param>
		/// <returns>序号</returns>
		public int FastIndexOf(XTextElement element)
		{
			if (element == null)
			{
				return -1;
			}
			if (this is XTextContent)
			{
				int contentIndex = element.ContentIndex;
				if (contentIndex >= 0 && contentIndex < base.Count && base[contentIndex] == element)
				{
					return contentIndex;
				}
			}
			return IndexOf(element);
		}

		/// <summary>
		///       获得子列表
		///       </summary>
		/// <param name="startIndex">开始区域位置</param>
		/// <param name="length">长度</param>
		/// <returns>子列表</returns>
		public new XTextElementList GetRange(int startIndex, int length)
		{
			if (length == 0)
			{
				return new XTextElementList();
			}
			List<XTextElement> range = base.GetRange(startIndex, length);
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.AddRange(range);
			return xTextElementList;
		}

		/// <summary>
		///       获得区域中的元素
		///       </summary>
		/// <param name="startIndex">开始序号</param>
		/// <param name="length">长度</param>
		/// <returns>获得的元素列表</returns>
		public XTextElementList SafeGetRange(int startIndex, int length)
		{
			if (length < 0)
			{
				length = 0;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
			}
			if (startIndex >= base.Count)
			{
				startIndex = base.Count - 1;
			}
			int num = startIndex + length - 1;
			if (num >= base.Count)
			{
				num = base.Count - 1;
			}
			XTextElementList xTextElementList = new XTextElementList();
			for (int i = startIndex; i <= num; i++)
			{
				xTextElementList.Add(base[i]);
			}
			return xTextElementList;
		}

		public void method_12(int int_0, IEnumerable<XTextElement> ienumerable_0)
		{
			foreach (XTextElement item in ienumerable_0)
			{
				if (item == null)
				{
				}
			}
			InsertRange(int_0, ienumerable_0);
			bool_0 = false;
			method_7();
		}

		public void method_13(int int_0, XTextElement xtextElement_0)
		{
			if (xtextContainerElement_0 != null)
			{
				xtextElement_0.Parent = xtextContainerElement_0;
			}
			Insert(int_0, xtextElement_0);
			if (xtextElement_0 is XTextStringElement)
			{
				bool_0 = false;
			}
			method_7();
		}

		/// <summary>
		///       向列表添加对象
		///       </summary>
		/// <param name="element">对象</param>
		
		public new void Add(XTextElement element)
		{
			if (element != null)
			{
			}
			if (xtextContainerElement_0 != null)
			{
				element.Parent = xtextContainerElement_0;
			}
			base.Add(element);
			if (element is XTextStringElement)
			{
				bool_0 = false;
			}
			method_7();
		}

		/// <summary>
		///       删除元素
		///       </summary>
		/// <param name="element">
		/// </param>
		public new void Remove(XTextElement element)
		{
			base.Remove(element);
			method_7();
		}

		/// <summary>
		///       向列表添加对象，若已经存在该对象则不添加
		///       </summary>
		/// <param name="element">对象</param>
		public void AddCheckContains(XTextElement element)
		{
			if (!Contains(element))
			{
				base.Add(element);
			}
		}

		/// <summary>
		///       直接添加元素
		///       </summary>
		/// <param name="element">元素对象</param>
		public void AddRaw(XTextElement element)
		{
			base.Add(element);
		}

		public void AddRangeRaw(XTextElementList elements)
		{
			AddRange(elements);
		}

		public void AddRange(XTextElement[] elements)
		{
			foreach (XTextElement xTextElement in elements)
			{
				if (xTextElement != null)
				{
				}
			}
			if (elements != null && elements.Length > 0)
			{
				AddRange((IEnumerable<XTextElement>)elements);
				method_7();
			}
		}

		internal virtual void vmethod_0(int int_0)
		{
			if (int_0 < base.Count)
			{
				RemoveRange(int_0, base.Count - int_0);
			}
		}

		/// <summary>
		///       删除多个元素
		///       </summary>
		/// <param name="elements">
		/// </param>
		public void RemoveRange(XTextElementList elements)
		{
			if (elements == null || elements.Count <= 0)
			{
				return;
			}
			bool flag = false;
			int num = IndexOf(elements[0]);
			int num2 = IndexOf(elements.LastElement);
			if (num < 0 || num2 < 0)
			{
				return;
			}
			if (num2 - num + 1 == elements.Count)
			{
				flag = true;
				int num3 = num;
				foreach (XTextElement element in elements)
				{
					if (element != base[num3])
					{
						flag = false;
						break;
					}
					num3++;
				}
			}
			if (flag)
			{
				RemoveRange(num, elements.Count);
			}
			else
			{
				for (int num4 = elements.Count - 1; num4 >= 0; num4--)
				{
					Remove(elements[num4]);
				}
			}
			method_7();
		}

		internal void method_14(XTextElement xtextElement_0)
		{
			base.Remove(xtextElement_0);
		}

		internal void method_15(int int_0)
		{
			RemoveAt(int_0);
		}

		/// <summary>
		///       在指定的元素前面插入新的元素
		///       </summary>
		/// <param name="OldElement">指定的元素</param>
		/// <param name="NewElement">要插入的新的元素</param>
		/// <returns>操作是否成功</returns>
		public bool InsertBefore(XTextElement OldElement, XTextElement NewElement)
		{
			int num = 8;
			if (OldElement == null)
			{
				throw new ArgumentNullException("未指定元素");
			}
			if (NewElement == null)
			{
				throw new ArgumentNullException("未指定新元素");
			}
			int num2 = IndexOf(OldElement);
			if (num2 >= 0)
			{
				method_13(num2, NewElement);
				return true;
			}
			return false;
		}

		/// <summary>
		///       在指定的元素后面插入新的元素
		///       </summary>
		/// <param name="OldElement">指定的元素</param>
		/// <param name="NewElement">要插入的新的元素</param>
		/// <returns>操作是否成功</returns>
		public bool InsertAfter(XTextElement OldElement, XTextElement NewElement)
		{
			int num = 19;
			if (OldElement == null)
			{
				throw new ArgumentNullException("未指定元素");
			}
			if (NewElement == null)
			{
				throw new ArgumentNullException("未指定新元素");
			}
			int num2 = IndexOf(OldElement);
			if (num2 >= 0)
			{
				method_13(num2 + 1, NewElement);
				return true;
			}
			return false;
		}

		/// <summary>
		///       在指定元素前面插入多个元素
		///       </summary>
		/// <param name="OldElement">指定的元素</param>
		/// <param name="list">要插入的新元素列表</param>
		public void InsertRangeBefore(XTextElement OldElement, XTextElementList list)
		{
			int num = IndexOf(OldElement);
			if (num >= 0)
			{
				foreach (XTextElement item in list)
				{
					if (item == null)
					{
					}
				}
				method_12(num, list);
			}
		}

		/// <summary>
		///       获得子列表
		///       </summary>
		/// <param name="startIndex">开始元素的序号</param>
		/// <param name="length">元素的个数</param>
		/// <returns>获得的子列表</returns>
		public XTextElementList GetElements(int startIndex, int length)
		{
			int num = 18;
			if (startIndex < 0)
			{
				throw new ArgumentException("startIndex=" + startIndex);
			}
			XTextElementList xTextElementList = new XTextElementList();
			int num2 = Math.Min(base.Count - 1, startIndex + length - 1);
			for (int i = startIndex; i <= num2; i++)
			{
				xTextElementList.Add(base[i]);
			}
			return xTextElementList;
		}

		/// <summary>
		///       获得指定元素前面的一个元素
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>该元素的前一个元素对象</returns>
		public XTextElement GetPreElement(XTextElement element)
		{
			int num = FastIndexOf(element);
			if (num > 0)
			{
				return base[num - 1];
			}
			return null;
		}

		/// <summary>
		///       获得指定元素后面的一个元素
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>该元素后面的一个元素</returns>
		public XTextElement GetNextElement(XTextElement element)
		{
			int num = FastIndexOf(element);
			if (num >= 0 && num < base.Count - 1)
			{
				return base[num + 1];
			}
			return null;
		}

		/// <summary>
		///       删除元素列表中指定序号后面的元素,并将删除的元素放置到一个新的元素列表中 
		///       </summary>
		/// <param name="index">指定删除开始的序号</param>
		/// <returns>放置删除的元素的元素列表</returns>
		public XTextElementList Split(int index)
		{
			XTextElementList xTextElementList = new XTextElementList();
			int num = base.Count - 1;
			for (int num2 = num; num2 >= index; num2--)
			{
				xTextElementList.method_13(0, base[num2]);
				RemoveAt(num2);
			}
			return xTextElementList;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextElement current = enumerator.Current;
					stringBuilder.Append(current.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       获得内置的文本
		///       </summary>
		/// <returns>获得的文本</returns>
		public string GetInnerText()
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextElement current = enumerator.Current;
					stringBuilder.Append(current.Text);
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       进行深度复制
		///       </summary>
		/// <returns>复制品</returns>
		[ComVisible(true)]
		public XTextElementList CloneDeeply()
		{
			XTextElementList xTextElementList = new XTextElementList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextElement current = enumerator.Current;
					xTextElementList.Add(current.Clone(Deeply: true));
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       比较两个列表的元素清单是否一致
		///       </summary>
		/// <param name="list">元素列表</param>
		/// <returns>两个对象的元素清单是否一致</returns>
		public bool EqualsElements(XTextElementList list)
		{
			if (list != null && list.Count == base.Count)
			{
				int num = 0;
				while (true)
				{
					if (num < base.Count)
					{
						XTextElement xTextElement = base[num];
						if (list[num] != xTextElement)
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		object ICloneable.Clone()
		{
			XTextElementList xTextElementList = null;
			xTextElementList = ((this is XTextLine) ? new XTextLine() : ((!(this is XTextContent)) ? new XTextElementList() : new XTextContent()));
			xTextElementList.AddRange(this);
			return xTextElementList;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[ComVisible(true)]
		public XTextElementList Clone()
		{
			XTextElementList xTextElementList = null;
			xTextElementList = ((this is XTextLine) ? new XTextLine() : ((this is XTextContent) ? new XTextContent() : ((this == null) ? ((XTextElementList)Activator.CreateInstance(GetType())) : new XTextElementList())));
			xTextElementList.AddRange(this);
			return xTextElementList;
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		
		[ComVisible(true)]
		public XTextElement ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		
		public void ComSetItem(int index, XTextElement item)
		{
			base[index] = item;
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		
		public void ComAddItem(XTextElement item)
		{
			Add(item);
		}
	}
}
