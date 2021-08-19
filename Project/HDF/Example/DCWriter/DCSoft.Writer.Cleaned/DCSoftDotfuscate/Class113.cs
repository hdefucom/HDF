using DCSoft.Writer.Dom;
using System;

namespace DCSoftDotfuscate
{
	internal class Class113
	{
		private XTextElement[] xtextElement_0;

		private int int_0;

		public Class113(XTextElementList xtextElementList_0, int int_1, int int_2)
		{
			int num = 2;
			int_0 = 0;
			
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("index:" + int_1);
			}
			if (int_2 <= 0)
			{
				throw new ArgumentOutOfRangeException("length:" + int_2);
			}
			if (int_1 + int_2 > xtextElementList_0.Count)
			{
				throw new ArgumentOutOfRangeException("index+length:" + Convert.ToString(int_1 + int_2));
			}
			xtextElement_0 = new XTextElement[int_2];
			for (int i = 0; i < int_2; i++)
			{
				xtextElement_0[int_2 - i - 1] = xtextElementList_0[int_1 + i];
			}
			int_0 = xtextElement_0.Length - 1;
		}

		public void method_0(XTextElement xtextElement_1)
		{
			int_0++;
			xtextElement_0[int_0] = xtextElement_1;
		}

		public XTextElement method_1()
		{
			if (int_0 < xtextElement_0.Length - 1 && int_0 >= 0)
			{
				return xtextElement_0[int_0 + 1];
			}
			return null;
		}

		public XTextElement method_2()
		{
			if (int_0 >= 0)
			{
				XTextElement result = xtextElement_0[int_0];
				int_0--;
				return result;
			}
			return null;
		}

		public int method_3()
		{
			return int_0 + 1;
		}

		public XTextElement method_4()
		{
			if (int_0 >= 0)
			{
				return xtextElement_0[int_0];
			}
			return null;
		}
	}
}
