using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass645
	{
		private string string_0;

		private sbyte[] sbyte_0;

		private GClass639[] gclass639_0;

		private BarcodeFormat barcodeFormat_0;

		private Hashtable hashtable_0;

		public string method_0()
		{
			return string_0;
		}

		public sbyte[] method_1()
		{
			return sbyte_0;
		}

		public GClass639[] method_2()
		{
			return gclass639_0;
		}

		public BarcodeFormat method_3()
		{
			return barcodeFormat_0;
		}

		public Hashtable method_4()
		{
			return hashtable_0;
		}

		public GClass645(string string_1, sbyte[] sbyte_1, GClass639[] gclass639_1, BarcodeFormat barcodeFormat_1)
		{
			int num = 9;
			
			if (string_1 == null && sbyte_1 == null)
			{
				throw new ArgumentException("Text and bytes are null");
			}
			string_0 = string_1;
			sbyte_0 = sbyte_1;
			gclass639_0 = gclass639_1;
			barcodeFormat_0 = barcodeFormat_1;
			hashtable_0 = null;
		}

		public void method_5(GClass664 gclass664_0, object object_0)
		{
			if (hashtable_0 == null)
			{
				hashtable_0 = Hashtable.Synchronized(new Hashtable(3));
			}
			hashtable_0[gclass664_0] = object_0;
		}

		public override string ToString()
		{
			int num = 13;
			if (string_0 == null)
			{
				return "[" + sbyte_0.Length + " bytes]";
			}
			return string_0;
		}
	}
}
