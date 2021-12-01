using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass34
	{
		private string string_0 = null;

		private Type type_0 = typeof(string);

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
	}
}
