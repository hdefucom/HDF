using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass422
	{
		private string string_0 = null;

		private int int_0 = int.MinValue;

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

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
		}

		public override string ToString()
		{
			return string_0 + "=" + int_0;
		}
	}
}
