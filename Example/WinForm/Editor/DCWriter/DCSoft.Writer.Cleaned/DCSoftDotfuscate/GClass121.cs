using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass121
	{
		private const byte byte_0 = 98;

		private const byte byte_1 = 100;

		private const byte byte_2 = 102;

		private const byte byte_3 = 104;

		private const byte byte_4 = 106;

		private const byte byte_5 = 108;

		private const byte byte_6 = 110;

		private const byte byte_7 = 112;

		private const byte byte_8 = 114;

		private const byte byte_9 = 116;

		public void method_0(XTextContentElement xtextContentElement_0, GClass378 gclass378_0)
		{
			gclass378_0.method_11(100);
			gclass378_0.method_13(xtextContentElement_0.PrivateContent.Count);
			gclass378_0.method_13(xtextContentElement_0.PrivateLines.Count);
			gclass378_0.method_18(xtextContentElement_0.Left);
			gclass378_0.method_18(xtextContentElement_0.Top);
			gclass378_0.method_18(xtextContentElement_0.Width);
			gclass378_0.method_18(xtextContentElement_0.Height);
			foreach (XTextLine privateLine in xtextContentElement_0.PrivateLines)
			{
				method_1(xtextContentElement_0, privateLine, gclass378_0);
			}
			gclass378_0.method_11(116);
			if (xtextContentElement_0.HasFreeLayoutElements)
			{
				gclass378_0.method_13(xtextContentElement_0.FreeLayoutElements.Count);
				foreach (XTextElement freeLayoutElement in xtextContentElement_0.FreeLayoutElements)
				{
					_ = freeLayoutElement;
				}
			}
			else
			{
				gclass378_0.method_13(0);
			}
			gclass378_0.method_13(117);
			gclass378_0.method_13(101);
		}

		public void method_1(XTextContentElement xtextContentElement_0, XTextLine xtextLine_0, GClass378 gclass378_0)
		{
			gclass378_0.method_11(114);
			gclass378_0.method_18(xtextLine_0.Left);
			gclass378_0.method_18(xtextLine_0.Top);
			gclass378_0.method_18(xtextLine_0.Height);
			gclass378_0.method_13(xtextContentElement_0.PrivateContent.IndexOf(xtextLine_0[0]));
			gclass378_0.method_13(xtextContentElement_0.PrivateContent.IndexOf(xtextLine_0.LastElement));
			gclass378_0.method_13(xtextLine_0.Count);
			foreach (XTextElement item in xtextLine_0)
			{
				gclass378_0.method_18(item.Left);
				gclass378_0.method_18(item.Top);
				gclass378_0.method_18(item.Width);
				gclass378_0.method_18(item.Height);
				gclass378_0.method_18(item.WidthFix);
				if (item is XTextTableElement)
				{
					method_2((XTextTableElement)item, gclass378_0);
				}
				else if (item is XTextSectionElement)
				{
					gclass378_0.method_11(108);
					XTextSectionElement xtextContentElement_ = (XTextSectionElement)item;
					method_0(xtextContentElement_, gclass378_0);
					gclass378_0.method_13(109);
				}
				else
				{
					gclass378_0.method_11(98);
				}
			}
			gclass378_0.method_13(115);
		}

		private void method_2(XTextTableElement xtextTableElement_0, GClass378 gclass378_0)
		{
			gclass378_0.method_11(102);
			foreach (XTextTableRowElement row in xtextTableElement_0.Rows)
			{
				gclass378_0.method_11(104);
				gclass378_0.method_18(row.Height);
				foreach (XTextTableCellElement cell in row.Cells)
				{
					gclass378_0.method_11(106);
					gclass378_0.method_13(cell.RowIndex);
					gclass378_0.method_13(cell.ColIndex);
					gclass378_0.method_18(cell.Width);
					gclass378_0.method_18(cell.Height);
					gclass378_0.method_20(cell.IsOverrided);
					if (!cell.IsOverrided)
					{
						method_0(cell, gclass378_0);
					}
					gclass378_0.method_13(107);
				}
				gclass378_0.method_13(105);
			}
			gclass378_0.method_13(103);
		}
	}
}
