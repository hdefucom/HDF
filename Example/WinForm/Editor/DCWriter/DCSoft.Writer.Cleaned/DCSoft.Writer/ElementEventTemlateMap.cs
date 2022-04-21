using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素事件模板字典
	///       </summary>
	
	[ComDefaultInterface(typeof(IElementEventTemlateMap))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("291E3C96-4AEF-4912-A75C-035DC00A4571")]
	[ComVisible(true)]
	
	[ComClass("291E3C96-4AEF-4912-A75C-035DC00A4571", "A06FC173-15D6-4EDF-AAC1-3373216F41E3")]
	public class ElementEventTemlateMap : Dictionary<Type, ElementEventTemplate>, IElementEventTemlateMap
	{
		internal const string CLASSID = "291E3C96-4AEF-4912-A75C-035DC00A4571";

		internal const string CLASSID_Interface = "A06FC173-15D6-4EDF-AAC1-3373216F41E3";

		/// <summary>
		///       判断是否存在指定类型名称的事件模板
		///       </summary>
		/// <param name="typeName">类型名称</param>
		/// <returns>是否存在指定事件模板</returns>
		public bool ContainsByTypeName(string typeName)
		{
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType != null)
			{
				return ContainsKey(controlType);
			}
			return false;
		}

		/// <summary>
		///       根据类型名称设置文档元素事件模板
		///       </summary>
		/// <param name="typeName">类型名称</param>
		/// <param name="eet">元素事件模板</param>
		public void SetEventTemplatesByTypeName(string typeName, ElementEventTemplate elementEventTemplate_0)
		{
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType == null)
			{
				return;
			}
			if (elementEventTemplate_0 == null)
			{
				if (ContainsKey(controlType))
				{
					Remove(controlType);
				}
			}
			else
			{
				base[controlType] = elementEventTemplate_0;
			}
		}

		/// <summary>
		///       获得指定名称的类型的事件模板列表
		///       </summary>
		/// <param name="elementTypeName">文档元素类型</param>
		/// <returns>获得的事件模板列表</returns>
		public ElementEventTemplateList GetEventTemplatesByTypeName(string elementTypeName)
		{
			Type controlType = ControlHelper.GetControlType(elementTypeName, typeof(XTextElement));
			if (controlType == null)
			{
				return null;
			}
			return GetEventTemplates(controlType);
		}

		/// <summary>
		///       获得指定类型使用的事件模板列表
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>获得的事件模板列表</returns>
		public ElementEventTemplateList GetEventTemplates(Type elementType)
		{
			int num = 15;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			ElementEventTemplateList elementEventTemplateList = new ElementEventTemplateList();
			foreach (Type key in base.Keys)
			{
				if (key.IsAssignableFrom(elementType))
				{
					elementEventTemplateList.Add(base[key]);
				}
			}
			return elementEventTemplateList;
		}
	}
}
