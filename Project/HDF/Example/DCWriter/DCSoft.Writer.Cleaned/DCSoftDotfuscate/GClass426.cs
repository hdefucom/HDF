using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass426
	{
		private string string_0 = null;

		private string string_1 = null;

		[DefaultValue(null)]
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

		public string method_0()
		{
			return string_1;
		}

		public void method_1(string string_2)
		{
			string_1 = string_2;
		}

		public override string ToString()
		{
			return string_0 + "=" + string_1;
		}
	}
}
