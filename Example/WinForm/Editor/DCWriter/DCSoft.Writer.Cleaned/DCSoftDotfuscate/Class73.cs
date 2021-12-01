using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.Reflection;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	internal class Class73 : List<GClass39>
	{
		public GClass39 method_0(XTextElement xtextElement_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass39 current = enumerator.Current;
					if (current.method_2() == xtextElement_0)
					{
						return current;
					}
				}
			}
			return null;
		}

		public int method_1(XTextElement xtextElement_0)
		{
			int num = 0;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass39 current = enumerator.Current;
					if (current.method_2() != xtextElement_0 && current.method_12(xtextElement_0))
					{
						current.method_15();
						num++;
					}
				}
			}
			return num;
		}

		public bool method_2(XTextElement xtextElement_0)
		{
			return method_0(xtextElement_0) != null;
		}

		public Class73 method_3()
		{
			Class73 @class = new Class73();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass39 current = enumerator.Current;
					@class.Add(current);
				}
			}
			return @class;
		}
	}
}
