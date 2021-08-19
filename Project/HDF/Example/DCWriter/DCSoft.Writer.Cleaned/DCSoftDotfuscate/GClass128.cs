using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass128
	{
		private List<XTextPageBreakElement> list_0 = null;

		private bool bool_0 = false;

		private XTextElement xtextElement_0 = null;

		private XTextElementList xtextElementList_0 = new XTextElementList();

		private XPageSettings xpageSettings_0 = null;

		private float float_0 = 0f;

		private float float_1 = 50f;

		private PageViewMode pageViewMode_0 = PageViewMode.Page;

		private bool bool_1 = false;

		private int int_0 = 0;

		private float float_2 = 0f;

		internal float float_3 = 0f;

		private XTextElementList xtextElementList_1 = null;

		private bool bool_2 = false;

		internal bool bool_3 = false;

		private bool bool_4 = false;

		public List<XTextPageBreakElement> method_0()
		{
			return list_0;
		}

		public void method_1(List<XTextPageBreakElement> list_1)
		{
			list_0 = list_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_5)
		{
			bool_0 = bool_5;
		}

		public XTextElement method_4()
		{
			return xtextElement_0;
		}

		public void method_5(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
			if (xtextElement_1 != null && !xtextElementList_0.Contains(xtextElement_1))
			{
				if (xtextElement_1.ContentElement != null)
				{
				}
				xtextElementList_0.Add(xtextElement_1);
			}
		}

		public XTextElementList method_6()
		{
			return xtextElementList_0;
		}

		public void method_7(XTextElementList xtextElementList_2)
		{
			xtextElementList_0 = xtextElementList_2;
		}

		public XPageSettings method_8()
		{
			return xpageSettings_0;
		}

		public void method_9(XPageSettings xpageSettings_1)
		{
			xpageSettings_0 = xpageSettings_1;
		}

		public float method_10()
		{
			return float_0;
		}

		public void method_11(float float_4)
		{
			float_0 = float_4;
		}

		public float method_12()
		{
			return float_1;
		}

		public void method_13(float float_4)
		{
			float_1 = float_4;
		}

		public PageViewMode method_14()
		{
			return pageViewMode_0;
		}

		public void method_15(PageViewMode pageViewMode_1)
		{
			pageViewMode_0 = pageViewMode_1;
		}

		public bool method_16()
		{
			return bool_1;
		}

		public void method_17(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public int method_18()
		{
			return int_0;
		}

		public void method_19(int int_1)
		{
			int_0 = int_1;
		}

		public float method_20()
		{
			return float_2;
		}

		public void method_21(float float_4)
		{
			float_2 = float_4;
		}

		public XTextLine method_22()
		{
			if (xtextElement_0 == null)
			{
				return null;
			}
			return xtextElement_0.OwnerLine;
		}

		public float method_23()
		{
			return float_3;
		}

		public void method_24(float float_4)
		{
			if (float_3 > float_4)
			{
				float_3 = float_4;
				bool_2 = true;
			}
		}

		internal XTextElementList method_25()
		{
			if (xtextElementList_1 == null)
			{
				xtextElementList_1 = new XTextElementList();
			}
			return xtextElementList_1;
		}

		internal void method_26(XTextElementList xtextElementList_2)
		{
			xtextElementList_1 = xtextElementList_2;
		}

		public bool method_27()
		{
			return bool_2;
		}

		public void method_28(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public bool method_29()
		{
			return bool_4;
		}

		public void method_30(bool bool_5)
		{
			bool_4 = bool_5;
		}

		public GClass128 method_31()
		{
			return (GClass128)MemberwiseClone();
		}
	}
}
