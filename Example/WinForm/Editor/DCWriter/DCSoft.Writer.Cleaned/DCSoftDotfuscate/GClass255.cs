using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	
	[ComVisible(false)]
	public class GClass255 : List<Form>
	{
		public Form method_0(Type type_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Form current = enumerator.Current;
					if (type_0.IsInstanceOfType(current))
					{
						if (current.IsDisposed)
						{
							Remove(current);
							return null;
						}
						return current;
					}
				}
			}
			return null;
		}

		public void method_1()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Form current = enumerator.Current;
					if (!(current?.IsDisposed ?? true))
					{
						current.Dispose();
					}
				}
			}
			Clear();
		}
	}
}
