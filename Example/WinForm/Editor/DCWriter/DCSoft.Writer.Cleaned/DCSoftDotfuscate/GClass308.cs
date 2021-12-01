using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	[TypeConverter(typeof(GClass310))]
	public class GClass308 : List<GClass309>
	{
		public override string ToString()
		{
			return base.Count + " items";
		}
	}
}
