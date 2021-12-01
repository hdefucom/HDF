using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass401 : GClass383
	{
		private string string_0 = null;

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

		public override string ToString()
		{
			return "BookMark:" + string_0;
		}
	}
}
