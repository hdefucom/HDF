using DCSoft.Common;
using DCSoft.Design;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       控件类型相关的帮助功能模块
	///       </summary>
	[ComVisible(false)]
	public static class ControlHelper
	{
		/// <summary>
		///       获得属性
		///       </summary>
		/// <param name="ctl">对象</param>
		/// <param name="propertyName">属性名</param>
		/// <returns>获得的属性描述对象</returns>
		public static PropertyDescriptor GetProperty(object object_0, string propertyName)
		{
			if (propertyName == null || propertyName.Trim().Length == 0)
			{
				return null;
			}
			propertyName = propertyName.Trim();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(object_0);
			if (properties != null && properties.Count > 0)
			{
				foreach (PropertyDescriptor item in properties)
				{
					if (string.Equals(item.Name, propertyName, StringComparison.CurrentCultureIgnoreCase))
					{
						return item;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       设置控件数据
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="propertyName">属性名</param>
		/// <param name="text">属性值</param>
		/// <returns>操作是否成功</returns>
		public static bool SetControlValue(object object_0, string propertyName, string text)
		{
			return ValueTypeHelper.SetPropertyValue(object_0, propertyName, text, throwException: false);
		}

		/// <summary>
		///       获得控件属性值
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="propertyName">属性名</param>
		/// <returns>获得的属性值</returns>
		public static string GetControlValue(object object_0, string propertyName)
		{
			PropertyDescriptor property = GetProperty(object_0, propertyName);
			if (property == null)
			{
				return null;
			}
			object value = property.GetValue(object_0);
			if (value is string)
			{
				return (string)value;
			}
			if (property.Converter != null)
			{
				return property.Converter.ConvertToString(value);
			}
			return Convert.ToString(value);
		}

		/// <summary>
		///       试图设置控件大小
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="ctl">控件对象</param>
		/// <param name="viewWidth">视图宽度</param>
		/// <param name="viewHeight">视图高度</param>
		/// <returns>设置后的控件大小</returns>
		public static SizeF TrySetControlSize(XTextControlHostElement element, Control control_0, float viewWidth, float viewHeight)
		{
			if (control_0 != null)
			{
				if (control_0.IsDisposed)
				{
					return SizeF.Empty;
				}
				if (!control_0.IsHandleCreated)
				{
					control_0.CreateControl();
				}
				float num = (float)GraphicsUnitConvert.GetRate(element.OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
				Size size = new Size((int)((viewWidth - (float)(XTextObjectElement.int_6 * 2)) / num), (int)((viewHeight - (float)(XTextObjectElement.int_6 * 2)) / num));
				if (size.Width <= 0)
				{
					size.Width = 1;
				}
				if (size.Height <= 0)
				{
					size.Height = 1;
				}
				if (!control_0.Size.Equals(size))
				{
					control_0.Size = size;
					if (!control_0.Size.Equals(size))
					{
						return new SizeF((float)control_0.Width * num + (float)(XTextObjectElement.int_6 * 2), (float)control_0.Height * num + (float)(XTextObjectElement.int_6 * 2));
					}
				}
			}
			return SizeF.Empty;
		}

		internal static Size GetControlSize(XTextControlHostElement element)
		{
			float num = (float)GraphicsUnitConvert.GetRate(GraphicsUnit.Pixel, element.OwnerDocument.DocumentGraphicsUnit);
			_ = element.RuntimeStyle;
			return new Size((int)(element.ClientWidth * num), (int)(element.ClientHeight * num));
		}

		/// <summary>
		///       获得类型的全名
		///       </summary>
		/// <param name="type">类型对象</param>
		/// <returns>全名</returns>
		public static string GetControlFullTypeName(Type type)
		{
			return DesignUtils.GetTypeFullName(type);
		}

		/// <summary>
		///       获得控件类型
		///       </summary>
		/// <param name="typeName">类型名称</param>
		/// <param name="specifyBaseType">指定的基础类型</param>
		/// <returns>获得的控件类型</returns>
		public static Type GetControlType(string typeName, Type specifyBaseType)
		{
			Type typeByName = DesignUtils.GetTypeByName(typeName);
			if (typeByName != null && specifyBaseType != null && !specifyBaseType.IsAssignableFrom(typeByName))
			{
				return null;
			}
			return typeByName;
		}

		/// <summary>
		///       将WPF元素转换为图片对象
		///       </summary>
		/// <param name="wpfElement">WPF元素</param>
		/// <returns>图片对象</returns>
		public static Image WPFElementToImage(object wpfElement)
		{
			return null;
		}
	}
}
