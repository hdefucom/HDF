using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	[ComVisible(false)]
	public class GAttribute5 : Attribute
	{
		private string string_0 = null;

		public GAttribute5(string string_1)
		{
			string_0 = string_1;
		}

		public string method_0()
		{
			return string_0;
		}

		internal static string smethod_0(Type type_0)
		{
			int num = 19;
			if (type_0 == null)
			{
				throw new ArgumentNullException("ObjectType");
			}
			GAttribute5 gAttribute;
			while (true)
			{
				if (type_0 != null && !type_0.Equals(typeof(object)))
				{
					gAttribute = (GAttribute5)Attribute.GetCustomAttribute(type_0, typeof(GAttribute5), inherit: true);
					if (gAttribute != null)
					{
						break;
					}
					type_0 = type_0.BaseType;
					continue;
				}
				return null;
			}
			return gAttribute.string_0;
		}
	}
}
