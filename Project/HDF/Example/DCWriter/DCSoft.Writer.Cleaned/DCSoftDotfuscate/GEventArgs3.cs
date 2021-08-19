using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs3 : EventArgs
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private bool bool_0 = false;

		public Dictionary<string, object> method_0()
		{
			return dictionary_0;
		}

		public void method_1(Dictionary<string, object> dictionary_1)
		{
			dictionary_0 = dictionary_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
