using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass678
	{
		private sbyte[] sbyte_0;

		private string string_0;

		private ArrayList arrayList_0;

		private GClass636 gclass636_0;

		public sbyte[] method_0()
		{
			return sbyte_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public ArrayList method_2()
		{
			return arrayList_0;
		}

		public GClass636 method_3()
		{
			return gclass636_0;
		}

		public GClass678(sbyte[] sbyte_1, string string_1, ArrayList arrayList_1, GClass636 gclass636_1)
		{
			if (sbyte_1 == null && string_1 == null)
			{
				throw new ArgumentException();
			}
			sbyte_0 = sbyte_1;
			string_0 = string_1;
			arrayList_0 = arrayList_1;
			gclass636_0 = gclass636_1;
		}
	}
}
