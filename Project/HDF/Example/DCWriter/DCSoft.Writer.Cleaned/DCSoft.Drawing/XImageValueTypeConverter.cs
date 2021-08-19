using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       图片数据类型转换器,设计器内部使用
	///       </summary>
	[ComVisible(false)]
	public class XImageValueTypeConverter : TypeConverter
	{
		/// <summary>
		///       判断能否将指定类型的数据转换为图片
		///       </summary>
		/// <param name="context">上下文</param>
		/// <param name="sourceType">指定的数据类型</param>
		/// <returns>能否转换</returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(byte[]) || sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		/// <summary>
		///       判断能否将图片转换为指定的类型
		///       </summary>
		/// <param name="context">上下文</param>
		/// <param name="destinationType">指定的数据类型</param>
		/// <returns>能否转换</returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == null)
			{
				return false;
			}
			return destinationType.Equals(typeof(byte[])) || destinationType.Equals(typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType);
		}

		/// <summary>
		///       将指定的数据转换为图片对象
		///       </summary>
		/// <param name="context">上下文</param>
		/// <param name="culture">区域信息</param>
		/// <param name="Value">要转换的数据</param>
		/// <returns>转换结果</returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			int num = 19;
			if (Value is byte[])
			{
				return new XImageValue((byte[])Value);
			}
			if (Value is string)
			{
				string text = (string)Value;
				if (text == null || text.Trim().Length == 0)
				{
					return new XImageValue();
				}
				string text2 = text;
				int num2 = 0;
				while (true)
				{
					if (num2 < text2.Length)
					{
						char value = text2[num2];
						if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/= \r\n\t".IndexOf(value) < 0)
						{
							break;
						}
						num2++;
						continue;
					}
					byte[] byte_ = Convert.FromBase64String(text);
					return new XImageValue(byte_);
				}
				return new XImageValue();
			}
			return base.ConvertFrom(context, culture, Value);
		}

		/// <summary>
		///       将图片转换为指定类型的数据
		///       </summary>
		/// <param name="context">上下文</param>
		/// <param name="culture">区域信息</param>
		/// <param name="Value">图片数据</param>
		/// <param name="destinationType">指定的类型</param>
		/// <returns>转换结果</returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			int num = 17;
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			XImageValue xImageValue = (XImageValue)Value;
			if (xImageValue == null)
			{
				return "[NULL]";
			}
			if (destinationType == typeof(string))
			{
				return xImageValue.ToString();
			}
			if (destinationType == typeof(byte[]))
			{
				return xImageValue.ImageData;
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				byte[] imageData = xImageValue.ImageData;
				if (imageData == null || imageData.Length == 0)
				{
					return new InstanceDescriptor(typeof(XImageValue).GetConstructor(new Type[0]), new object[0]);
				}
				MemberInfo constructor = typeof(XImageValue).GetConstructor(new Type[1]
				{
					typeof(byte[])
				});
				return new InstanceDescriptor(constructor, new object[1]
				{
					xImageValue.ImageData
				});
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}

		/// <summary>
		///       获得图片对象的属性
		///       </summary>
		/// <param name="context">上下文</param>
		/// <param name="Value">图片数据</param>
		/// <param name="attributes">特性</param>
		/// <returns>属性列表</returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			int num = 13;
			return TypeDescriptor.GetProperties((Value == null) ? typeof(XImageValue) : Value.GetType(), attributes).Sort(new string[3]
			{
				"Width",
				"Height",
				"RawFormat"
			});
		}

		/// <summary>
		///       支持获得图片对象的属性
		///       </summary>
		/// <param name="context">上下文</param>
		/// <returns>是否支持获得属性</returns>
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
