using DCSoft.Writer.Dom;
using System;

namespace DCSoftDotfuscate
{
	internal class Class136
	{
		private XTextDocument xtextDocument_0;

		private XTextElementList xtextElementList_0;

		private XTextElementList xtextElementList_1;

		private XTextElementList xtextElementList_2;

		private XTextElementList xtextElementList_3;

		public Class136(XTextDocument xtextDocument_1)
		{
			int num = 7;
			xtextDocument_0 = null;
			xtextElementList_0 = null;
			xtextElementList_1 = null;
			xtextElementList_2 = null;
			xtextElementList_3 = null;
			
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextElementList method_0()
		{
			if (xtextElementList_0 == null)
			{
				xtextElementList_0 = xtextDocument_0.GetElementsByType(typeof(XTextTableElement));
			}
			return xtextElementList_0;
		}

		public void method_1(XTextElementList xtextElementList_4)
		{
			xtextElementList_0 = xtextElementList_4;
		}

		public XTextElementList method_2()
		{
			if (xtextElementList_1 == null)
			{
				xtextElementList_1 = xtextDocument_0.GetElementsByType(typeof(XTextFieldElementBase));
			}
			return xtextElementList_1;
		}

		public void method_3(XTextElementList xtextElementList_4)
		{
			xtextElementList_1 = xtextElementList_4;
		}

		public XTextElementList method_4()
		{
			if (xtextElementList_2 == null)
			{
				xtextElementList_2 = xtextDocument_0.GetElementsByType(typeof(XTextImageElement));
			}
			return xtextElementList_2;
		}

		public void method_5(XTextElementList xtextElementList_4)
		{
			xtextElementList_2 = xtextElementList_4;
		}

		public XTextElementList method_6()
		{
			if (xtextElementList_3 == null)
			{
				xtextElementList_3 = xtextDocument_0.GetElementsByType(typeof(XTextSectionElement));
			}
			return xtextElementList_3;
		}

		public void method_7(XTextElementList xtextElementList_4)
		{
			xtextElementList_3 = xtextElementList_4;
		}

		public void method_8(XTextElement xtextElement_0)
		{
			if (xtextElement_0 != null)
			{
				if (xtextElement_0 is XTextImageElement)
				{
					xtextElementList_2 = null;
				}
				else if (xtextElement_0 is XTextFieldElementBase)
				{
					xtextElementList_1 = null;
				}
				else if (xtextElement_0 is XTextTableElement)
				{
					xtextElementList_0 = null;
				}
			}
		}

		public void method_9(XTextElementList xtextElementList_4)
		{
			if (xtextElementList_4 != null)
			{
				foreach (XTextElement item in xtextElementList_4)
				{
					if (item is XTextImageElement)
					{
						xtextElementList_2 = null;
					}
					else if (item is XTextFieldElementBase)
					{
						xtextElementList_1 = null;
					}
					else if (item is XTextTableElement)
					{
						xtextElementList_0 = null;
					}
				}
			}
		}
	}
}
