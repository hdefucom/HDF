using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[DCInternal]
	[ComVisible(false)]
	public class GClass97
	{
		private Dictionary<XTextElement, GClass96> dictionary_0 = new Dictionary<XTextElement, GClass96>();

		private int int_0 = 0;

		public GClass96 method_0(XTextElement xtextElement_0)
		{
			if (xtextElement_0 == null)
			{
				return null;
			}
			GClass96 value = null;
			if (dictionary_0.TryGetValue(xtextElement_0, out value))
			{
				return value;
			}
			return null;
		}

		public bool method_1(XTextElement xtextElement_0)
		{
			return dictionary_0.ContainsKey(xtextElement_0);
		}

		public void method_2(XTextElement xtextElement_0)
		{
			if (dictionary_0.ContainsKey(xtextElement_0))
			{
				dictionary_0.Remove(xtextElement_0);
				method_6();
			}
		}

		public void method_3()
		{
			dictionary_0.Clear();
			method_6();
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_1)
		{
			int_0 = int_1;
		}

		public void method_6()
		{
			int_0++;
		}

		public void method_7(XTextElement xtextElement_0, GClass96 gclass96_0)
		{
			int num = 10;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (gclass96_0 == null)
			{
				if (dictionary_0.ContainsKey(xtextElement_0))
				{
					dictionary_0.Remove(xtextElement_0);
					method_6();
				}
			}
			else
			{
				dictionary_0[xtextElement_0] = gclass96_0;
				method_6();
			}
		}

		public GClass96 method_8(XTextElement xtextElement_0, string string_0)
		{
			return method_9(xtextElement_0, string_0, GEnum4.const_0, GEnum5.const_0);
		}

		public GClass96 method_9(XTextElement xtextElement_0, string string_0, GEnum4 genum4_0, GEnum5 genum5_0)
		{
			int num = 6;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (dictionary_0.ContainsKey(xtextElement_0))
			{
				dictionary_0.Remove(xtextElement_0);
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				GClass96 gClass = new GClass96();
				gClass.method_2(xtextElement_0);
				gClass.method_6(string_0);
				gClass.method_8(genum4_0);
				gClass.method_10(genum5_0);
				dictionary_0[xtextElement_0] = gClass;
				method_6();
				return gClass;
			}
			return null;
		}
	}
}
