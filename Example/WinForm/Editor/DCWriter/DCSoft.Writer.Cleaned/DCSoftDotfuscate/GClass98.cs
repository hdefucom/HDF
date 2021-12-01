using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass98
	{
		private XTextDocument xtextDocument_0 = null;

		private Stack<GClass99> stack_0 = new Stack<GClass99>();

		public GClass98(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public GClass99 method_0()
		{
			return stack_0.Peek();
		}

		public int method_1()
		{
			return stack_0.Count;
		}

		public void method_2(XTextElement xtextElement_0, string string_0)
		{
			GClass99 gClass = method_0();
			GClass99 gClass2 = new GClass99();
			gClass2.method_8(xtextElement_0);
			if (gClass == null)
			{
				gClass2.method_1(xtextDocument_0.Parameters);
				return;
			}
			DataBindingPathProvider dataBindingPathProvider = xtextDocument_0.AppHost.DataBindingPathProvider;
			DataBindingPathEventArgs args = new DataBindingPathEventArgs(string_0, gClass.method_4(), null, throwException: false);
			gClass2.method_1(dataBindingPathProvider.ReadValue(args));
			gClass2.method_6(string_0);
			method_3(gClass2);
		}

		public void method_3(GClass99 gclass99_0)
		{
			int num = 0;
			if (gclass99_0 == null)
			{
				throw new ArgumentNullException("info");
			}
			stack_0.Push(gclass99_0);
		}

		public void method_4(XTextElement xtextElement_0)
		{
			int num = 16;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			while (true)
			{
				if (stack_0.Count > 0)
				{
					if (stack_0.Peek().method_7() == xtextElement_0)
					{
						break;
					}
					stack_0.Pop();
					continue;
				}
				return;
			}
			stack_0.Pop();
		}
	}
}
