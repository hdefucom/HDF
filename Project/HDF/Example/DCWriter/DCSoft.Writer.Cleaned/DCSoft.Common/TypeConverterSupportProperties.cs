using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       支持展现属性的类型转换器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class TypeConverterSupportProperties : TypeConverter
	{
		                                                                    /// <summary>
		                                                                    ///       支持获得属性
		                                                                    ///       </summary>
		                                                                    /// <param name="context">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       获得属性
		                                                                    ///       </summary>
		                                                                    /// <param name="context">
		                                                                    /// </param>
		                                                                    /// <param name="value">
		                                                                    /// </param>
		                                                                    /// <param name="attributes">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(value, attributes);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return false;
			}
			return base.CanConvertTo(context, destinationType);
		}
	}
}
