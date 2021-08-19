using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass115
	{
		private Type type_0 = null;

		private PropertyDescriptor propertyDescriptor_0 = null;

		private string string_0 = null;

		private GEnum16 genum16_0 = GEnum16.const_4;

		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public Type method_0()
		{
			return type_0;
		}

		public void method_1(Type type_1)
		{
			type_0 = type_1;
		}

		public PropertyDescriptor method_2()
		{
			return propertyDescriptor_0;
		}

		public void method_3(PropertyDescriptor propertyDescriptor_1)
		{
			propertyDescriptor_0 = propertyDescriptor_1;
		}

		public GEnum16 method_4()
		{
			return genum16_0;
		}

		public void method_5(GEnum16 genum16_1)
		{
			genum16_0 = genum16_1;
		}
	}
}
