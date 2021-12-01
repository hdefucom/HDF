using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException1 : Exception
	{
		public string string_0;

		public override string Message
		{
			get
			{
				if (string_0 != null)
				{
					return string_0;
				}
				return null;
			}
		}

		public GException1(string string_1)
		{
			string_0 = string_1;
		}
	}
}
