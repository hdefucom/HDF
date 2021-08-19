using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace DCSoft.WinForms.Design
{
	public class DescriptionFieldEnumValueEditor : CustomDrawValueListBoxEditor
	{
		public class GClass10 : GClass9
		{
			private class Class38
			{
				public string string_0 = null;

				public object object_0 = null;

				public override string ToString()
				{
					return string_0;
				}
			}

			public override IEnumerable vmethod_3()
			{
				ArrayList arrayList = new ArrayList();
				Type propertyType = method_5().PropertyDescriptor.PropertyType;
				if (propertyType.IsEnum)
				{
					FieldInfo[] fields = propertyType.GetFields(BindingFlags.Static | BindingFlags.Public);
					foreach (FieldInfo fieldInfo in fields)
					{
						Class38 @class = new Class38();
						@class.object_0 = fieldInfo.GetValue(null);
						DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
						if (descriptionAttribute != null)
						{
							@class.string_0 = descriptionAttribute.Description;
						}
						if (@class.string_0 == null || @class.string_0.Trim().Length == 0)
						{
							@class.string_0 = fieldInfo.Name;
						}
						arrayList.Add(@class);
					}
				}
				return arrayList;
			}

			public override string vmethod_6(object object_1)
			{
				return ((Class38)object_1).string_0;
			}

			public override object vmethod_5(object object_1)
			{
				return ((Class38)object_1).object_0;
			}
		}

		public DescriptionFieldEnumValueEditor()
		{
			base.Provider = new GClass10();
		}
	}
}
