using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       设计器使用的设计元素类型转换器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class DCDescriptionComponentTypeConverter : TypeConverter
	{
		private static string[] myHiddenProperties = null;

		                                                                    /// <summary>
		                                                                    ///       隐藏的属性名称
		                                                                    ///       </summary>
		public static string[] HiddenProperties
		{
			get
			{
				return myHiddenProperties;
			}
			set
			{
				myHiddenProperties = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       支持获得属性描述对象
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
		                                                                    ///       获得属性描述对象
		                                                                    ///       </summary>
		                                                                    /// <param name="context">
		                                                                    /// </param>
		                                                                    /// <param name="Value">
		                                                                    /// </param>
		                                                                    /// <param name="attributes">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			int num = 5;
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(Value, attributes);
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null, readOnly: false);
			foreach (PropertyDescriptor item in properties)
			{
				if (myHiddenProperties != null && myHiddenProperties.Length > 0)
				{
					string text = null;
					text = ((Value == null) ? (item.ComponentType.FullName + "." + item.Name) : (Value.GetType().FullName + "." + item.Name));
					string[] array = myHiddenProperties;
					int num2 = 0;
					while (num2 < array.Length)
					{
						string strA = array[num2];
						if (string.Compare(strA, text, ignoreCase: true) != 0)
						{
							num2++;
							continue;
						}
						goto IL_00df;
					}
				}
				propertyDescriptorCollection.Add(new GClass360(item));
				IL_00df:;
			}
			return propertyDescriptorCollection;
		}
	}
}
