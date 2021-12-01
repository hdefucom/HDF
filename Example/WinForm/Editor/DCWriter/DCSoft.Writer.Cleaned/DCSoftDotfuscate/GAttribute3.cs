using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Guid("5D3C9445-3D81-4d23-86C9-3F051737E3A1")]
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public class GAttribute3 : Attribute
	{
		private string string_0 = null;

		private int int_0 = 0;

		private int int_1 = -1;

		public string Name => string_0;

		public GAttribute3(string string_1, int int_2, int int_3)
		{
			string_0 = string_1;
			int_0 = int_2;
			int_1 = int_3;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public GAttribute3[] method_2(Assembly assembly_0)
		{
			ArrayList arrayList = new ArrayList();
			Attribute[] customAttributes = Attribute.GetCustomAttributes(assembly_0, typeof(GAttribute3));
			foreach (Attribute value in customAttributes)
			{
				arrayList.Add(value);
			}
			return (GAttribute3[])arrayList.ToArray(typeof(GAttribute3));
		}
	}
}
