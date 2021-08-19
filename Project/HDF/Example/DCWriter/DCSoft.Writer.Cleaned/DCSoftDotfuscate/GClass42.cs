using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass42
	{
		private string string_0 = null;

		private Type type_0 = null;

		private string string_1 = null;

		private GClass42 gclass42_0 = null;

		private List<GClass41> list_0 = new List<GClass41>();

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_2)
		{
			string_0 = string_2;
		}

		public Type method_2()
		{
			return type_0;
		}

		public void method_3(Type type_1)
		{
			type_0 = type_1;
		}

		public string method_4()
		{
			return string_1;
		}

		public void method_5(string string_2)
		{
			string_1 = string_2;
		}

		public GClass42 method_6()
		{
			return gclass42_0;
		}

		public void method_7(GClass42 gclass42_1)
		{
			gclass42_0 = gclass42_1;
		}

		public List<GClass41> method_8()
		{
			return list_0;
		}

		public void method_9(List<GClass41> list_1)
		{
			list_0 = list_1;
		}

		public override string ToString()
		{
			return method_4() + " " + method_8().Count + " 个属性";
		}
	}
}
