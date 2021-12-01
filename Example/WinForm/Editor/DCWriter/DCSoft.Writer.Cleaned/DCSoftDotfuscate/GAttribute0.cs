using DCSoft.Writer.Dom;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Class)]
	public class GAttribute0 : Attribute
	{
		private Type type_0 = null;

		public Type method_0()
		{
			return type_0;
		}

		public void method_1(Type type_1)
		{
			type_0 = type_1;
		}

		public static GAttribute0 smethod_0(Type type_1)
		{
			int num = 5;
			if (type_1 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!type_1.Equals(typeof(XTextElement)) && !type_1.IsSubclassOf(typeof(XTextElement)))
			{
				throw new ArgumentOutOfRangeException(type_1.FullName);
			}
			return (GAttribute0)Attribute.GetCustomAttribute(type_1, typeof(GAttribute0), inherit: true);
		}
	}
}
