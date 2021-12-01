using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       撤销操作列表
	///       </summary>
	[ComVisible(false)]
	public class XTextDocumentUndoList : GClass14
	{
		private UndoMethodTypes undoMethodTypes_0 = UndoMethodTypes.None;

		private XTextElementList xtextElementList_0 = new XTextElementList();

		private XTextElementList xtextElementList_1 = new XTextElementList();

		internal Dictionary<XTextContentElement, int> dictionary_0 = new Dictionary<XTextContentElement, int>();

		private int int_2 = 0;

		private int int_3 = 0;

		private int int_4 = 0;

		private int int_5 = 0;

		protected XTextDocument xtextDocument_0 = null;

		/// <summary>
		///       强制使用撤销对象组操作
		///       </summary>
		protected override bool ForceUseGroup => true;

		/// <summary>
		///       执行撤销和重做操作后执行的方法
		///       </summary>
		public UndoMethodTypes NeedInvokeMethods
		{
			get
			{
				return undoMethodTypes_0;
			}
			set
			{
				undoMethodTypes_0 = value;
			}
		}

		/// <summary>
		///       状态发生改变的元素列表
		///       </summary>
		internal XTextElementList RefreshElements => xtextElementList_0;

		/// <summary>
		///       内容发生改变的容器元素对象
		///       </summary>
		public XTextElementList ContentChangedContainer => xtextElementList_1;

		/// <summary>
		///       本对象所属的文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">
		/// </param>
		public XTextDocumentUndoList(XTextDocument xtextDocument_1)
		{
			Document = xtextDocument_1;
		}

		/// <summary>
		///       内容清空事件
		///       </summary>
		protected override void OnClear()
		{
			if (xtextElementList_1 != null)
			{
				xtextElementList_1.Clear();
			}
			if (dictionary_0 != null)
			{
				dictionary_0.Clear();
			}
			if (xtextElementList_0 != null)
			{
				xtextElementList_0.Clear();
			}
			if (base.Count > 0)
			{
				base.OnClear();
			}
		}

		protected override GClass113 vmethod_3()
		{
			Class130 @class = new Class130(xtextDocument_0);
			@class.method_4(int_2);
			@class.method_6(int_3);
			@class.method_8(int_4);
			@class.method_10(int_5);
			return @class;
		}

		/// <summary>
		///       添加刷新的区域信息
		///       </summary>
		/// <param name="contentElement">
		/// </param>
		/// <param name="startIndex">
		/// </param>
		public void AddContentRefreshInfo(XTextContentElement contentElement, int startIndex)
		{
			if (dictionary_0.ContainsKey(contentElement))
			{
				dictionary_0[contentElement] = Math.Min(dictionary_0[contentElement], startIndex);
			}
			else
			{
				dictionary_0[contentElement] = startIndex;
			}
		}

		public override bool vmethod_1()
		{
			if (base.vmethod_1())
			{
				xtextElementList_0.Clear();
				int_2 = Document.CurrentContentElement.Selection.StartIndex;
				int_3 = Document.CurrentContentElement.Selection.Length;
				return true;
			}
			return false;
		}

		public override void vmethod_2()
		{
			base.vmethod_2();
			xtextElementList_0.Clear();
		}

		public override bool vmethod_4()
		{
			xtextElementList_0.Clear();
			if (Document != null && Document.CurrentContentElement != null && Document.CurrentContentElement.Selection != null)
			{
				int_4 = Document.CurrentContentElement.Selection.StartIndex;
				int_5 = Document.CurrentContentElement.Selection.Length;
			}
			else
			{
				int_4 = 0;
				int_5 = 0;
			}
			if (method_13() != null && method_13().Count > 0)
			{
				foreach (object item in method_13())
				{
					if (item is XTextUndoBase)
					{
						XTextUndoBase xTextUndoBase = (XTextUndoBase)item;
						xTextUndoBase.Document = Document;
					}
				}
			}
			return base.vmethod_4();
		}

		public void method_16(XTextElement xtextElement_0)
		{
			if (xtextElement_0 != null && method_15())
			{
				XTextUndoInvalidateElements ginterface1_ = new XTextUndoInvalidateElements(xtextElement_0);
				method_14(ginterface1_);
			}
		}

		public void method_17(XTextElementList xtextElementList_2)
		{
			if (xtextElementList_2 != null && method_15())
			{
				XTextUndoInvalidateElements ginterface1_ = new XTextUndoInvalidateElements(xtextElementList_2);
				method_14(ginterface1_);
			}
		}

		/// <summary>
		///       添加额外执行的方法
		///       </summary>
		/// <param name="method">方法类型</param>
		public void AddMethod(UndoMethodTypes method)
		{
			if (method_15())
			{
				XTextUndoInvokeMethod ginterface1_ = new XTextUndoInvokeMethod(method);
				method_14(ginterface1_);
			}
		}

		/// <summary>
		///       添加一个插入元素操作信息
		///       </summary>
		/// <param name="c">容器元素</param>
		/// <param name="index">插入的序号</param>
		/// <param name="element">插入的元素</param>
		public void AddInsertElement(XTextContainerElement xtextContainerElement_0, int index, XTextElement element)
		{
			if (method_15())
			{
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.Add(element);
				XTextUndoReplaceElements xTextUndoReplaceElements = new XTextUndoReplaceElements(xtextContainerElement_0, index, null, xTextElementList);
				xTextUndoReplaceElements.Document = Document;
				xTextUndoReplaceElements.InGroup = true;
				method_14(xTextUndoReplaceElements);
			}
		}

		/// <summary>
		///       添加删除一个元素的操作信息
		///       </summary>
		/// <param name="c">容器元素</param>
		/// <param name="index">子元素在容器元素中的序号</param>
		/// <param name="element">子元素对象</param>
		public void AddRemoveElement(XTextContainerElement xtextContainerElement_0, int index, XTextElement element)
		{
			if (method_15())
			{
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.Add(element);
				XTextUndoReplaceElements xTextUndoReplaceElements = new XTextUndoReplaceElements(xtextContainerElement_0, index, xTextElementList, null);
				xTextUndoReplaceElements.Document = Document;
				xTextUndoReplaceElements.InGroup = true;
				method_14(xTextUndoReplaceElements);
			}
		}

		/// <summary>
		///       添加一个插入多个元素的撤销信息
		///       </summary>
		/// <param name="c">容器对象</param>
		/// <param name="index">开始插入区域序号</param>
		/// <param name="list">插入的元素</param>
		public void AddInsertElements(XTextContainerElement xtextContainerElement_0, int index, XTextElementList list)
		{
			if (method_15())
			{
				XTextUndoReplaceElements xTextUndoReplaceElements = new XTextUndoReplaceElements(xtextContainerElement_0, index, null, list);
				xTextUndoReplaceElements.Document = Document;
				xTextUndoReplaceElements.InGroup = true;
				method_14(xTextUndoReplaceElements);
			}
		}

		/// <summary>
		///       添加一个删除多个元素的撤销信息
		///       </summary>
		/// <param name="c">容器对象</param>
		/// <param name="index">删除区域开始编号</param>
		/// <param name="list">删除的元素</param>
		public void AddRemoveElements(XTextContainerElement xtextContainerElement_0, int index, XTextElementList list)
		{
			if (method_15())
			{
				XTextUndoReplaceElements xTextUndoReplaceElements = new XTextUndoReplaceElements(xtextContainerElement_0, index, list, null);
				xTextUndoReplaceElements.Document = Document;
				xTextUndoReplaceElements.InGroup = true;
				method_14(xTextUndoReplaceElements);
			}
		}

		/// <summary>
		///       添加一个替换多个元素的撤销信息
		///       </summary>
		/// <param name="container">容器对象</param>
		/// <param name="index">操作区域开始编号</param>
		/// <param name="oldElements">旧元素列表</param>
		/// <param name="newElements">新元素列表</param>
		public void AddReplaceElements(XTextContainerElement container, int index, XTextElementList oldElements, XTextElementList newElements)
		{
			if (method_15())
			{
				XTextUndoReplaceElements xTextUndoReplaceElements = new XTextUndoReplaceElements(container, index, oldElements, newElements);
				xTextUndoReplaceElements.Document = Document;
				xTextUndoReplaceElements.InGroup = true;
				method_14(xTextUndoReplaceElements);
			}
		}

		/// <summary>
		///       添加一个项目
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <param name="oldStyleIndex">旧的样式编号</param>
		/// <param name="newStyleIndex">新的样式编号</param>
		public void AddStyleIndex(XTextElement element, int oldStyleIndex, int newStyleIndex)
		{
			XTextUndoStyleIndex xTextUndoStyleIndex = new XTextUndoStyleIndex(element, oldStyleIndex, newStyleIndex);
			xTextUndoStyleIndex.Document = xtextDocument_0;
			xTextUndoStyleIndex.InGroup = true;
			method_14(xTextUndoStyleIndex);
		}

		/// <summary>
		///       添加一个项目
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <param name="oldVisible">旧的可见性</param>
		/// <param name="newVisible">新的可见性</param>
		public void AddVisible(XTextElement element, bool oldVisible, bool newVisible)
		{
			XTextUndoElementVisible xTextUndoElementVisible = new XTextUndoElementVisible(element, oldVisible, newVisible);
			xTextUndoElementVisible.Document = xtextDocument_0;
			xTextUndoElementVisible.InGroup = true;
			method_14(xTextUndoElementVisible);
		}

		public void AddProperty(GEnum18 style, object vOldValue, object vNewValue, XTextElement element)
		{
			XTextUndoProperty xTextUndoProperty = new XTextUndoProperty(style, vOldValue, vNewValue, element);
			xTextUndoProperty.Document = xtextDocument_0;
			xTextUndoProperty.InGroup = true;
			method_14(xTextUndoProperty);
		}

		/// <summary>
		///       添加设置对象属性值的撤销信息
		///       </summary>
		/// <param name="PropertyName">属性名称,不区分大小写</param>
		/// <param name="OldValue">旧的属性值</param>
		/// <param name="NewValue">新的属性值</param>
		/// <param name="ObjectInstance">对象实例</param>
		public void AddProperty(string PropertyName, object OldValue, object NewValue, object ObjectInstance)
		{
			int num = 9;
			if (PropertyName == null || PropertyName.Length == 0)
			{
				throw new ArgumentNullException("PropertyName");
			}
			if (ObjectInstance == null)
			{
				throw new ArgumentNullException("ObjectInstance");
			}
			Type type = ObjectInstance.GetType();
			PropertyInfo property = type.GetProperty(PropertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				throw new Exception(string.Format(WriterStringsCore.MissProperty_Name, PropertyName));
			}
			ParameterInfo[] indexParameters = property.GetIndexParameters();
			if (indexParameters != null && indexParameters.Length > 0)
			{
				throw new Exception(string.Format(WriterStringsCore.PropertyCannotHasParameter_Name, PropertyName));
			}
			if (!property.CanWrite)
			{
				throw new Exception(string.Format(WriterStringsCore.PropertyIsReadonly_Name, PropertyName));
			}
			Type propertyType = property.PropertyType;
			if (OldValue != null)
			{
				Type type2 = OldValue.GetType();
				if (!type2.Equals(propertyType) && !type2.IsSubclassOf(propertyType))
				{
					throw new Exception("旧数据值类型不匹配");
				}
			}
			if (NewValue != null)
			{
				Type type2 = NewValue.GetType();
				if (!type2.Equals(propertyType) && !type2.IsSubclassOf(propertyType))
				{
					throw new Exception("新数值类型不匹配");
				}
			}
			XTextUndoNameProperty xTextUndoNameProperty = new XTextUndoNameProperty(ObjectInstance, property, OldValue, NewValue);
			xTextUndoNameProperty.Document = xtextDocument_0;
			xTextUndoNameProperty.InGroup = true;
			method_14(xTextUndoNameProperty);
		}

		/// <summary>
		///       添加设置对象属性值的撤销信息
		///       </summary>
		/// <param name="PropertyName">属性名称,不区分大小写</param>
		/// <param name="OldValue">旧的属性值</param>
		/// <param name="NewValue">新的属性值</param>
		/// <param name="ObjectInstance">对象实例</param>
		public void AddProperty(PropertyDescriptor property, object OldValue, object NewValue, object ObjectInstance)
		{
			int num = 10;
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			if (ObjectInstance == null)
			{
				throw new ArgumentNullException("ObjectInstance");
			}
			if (property.IsReadOnly)
			{
				throw new Exception(string.Format(WriterStringsCore.PropertyIsReadonly_Name, property.Name));
			}
			Type propertyType = property.PropertyType;
			if (OldValue != null)
			{
				Type type = OldValue.GetType();
				if (!type.Equals(propertyType) && !type.IsSubclassOf(propertyType))
				{
					throw new Exception("旧数据值类型不匹配");
				}
			}
			if (NewValue != null)
			{
				Type type = NewValue.GetType();
				if (!type.Equals(propertyType) && !type.IsSubclassOf(propertyType))
				{
					throw new Exception("新数值类型不匹配");
				}
			}
			XTextUndoNameProperty xTextUndoNameProperty = new XTextUndoNameProperty(ObjectInstance, property, OldValue, NewValue);
			xTextUndoNameProperty.Document = xtextDocument_0;
			xTextUndoNameProperty.InGroup = true;
			method_14(xTextUndoNameProperty);
		}

		/// <summary>
		///       添加设置表格行用户指定高度的操作
		///       </summary>
		/// <param name="row">表格行对象</param>
		/// <param name="oldSpecifyHeight">旧高度</param>
		public void AddRowSpecifyHeight(XTextTableRowElement xtextTableRowElement_0, float oldSpecifyHeight)
		{
			if (xtextTableRowElement_0 != null && oldSpecifyHeight != xtextTableRowElement_0.SpecifyHeight)
			{
				method_14(new XTextUndoProperty(GEnum18.const_3, oldSpecifyHeight, xtextTableRowElement_0.SpecifyHeight, xtextTableRowElement_0));
			}
		}
	}
}
