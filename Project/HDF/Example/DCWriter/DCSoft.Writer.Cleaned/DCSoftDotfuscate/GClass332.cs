using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass332
	{
		private GClass320 gclass320_0 = null;

		private Dictionary<Type, GClass320> dictionary_0 = new Dictionary<Type, GClass320>();

		public GClass320 method_0()
		{
			return gclass320_0;
		}

		public void method_1(GClass320 gclass320_1)
		{
			gclass320_0 = gclass320_1;
		}

		public GClass320 method_2(Type type_0)
		{
			GClass320 gClass = dictionary_0[type_0];
			if (gClass != null)
			{
				gclass320_0 = gClass;
				return gClass;
			}
			return null;
		}

		public Dictionary<Type, GClass320> method_3()
		{
			return dictionary_0;
		}

		public void method_4(Dictionary<Type, GClass320> dictionary_1)
		{
			dictionary_0 = dictionary_1;
		}

		public void method_5(Type type_0, GClass320 gclass320_1)
		{
			int num = 5;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (gclass320_1 == null)
			{
				if (dictionary_0.ContainsKey(type_0))
				{
					dictionary_0.Remove(type_0);
				}
			}
			else
			{
				dictionary_0[type_0] = gclass320_1;
			}
		}

		public GClass320 method_6(Type type_0)
		{
			int num = 11;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			foreach (Type key in dictionary_0.Keys)
			{
				if (key.Equals(type_0))
				{
					return dictionary_0[key];
				}
			}
			return null;
		}
	}
}
