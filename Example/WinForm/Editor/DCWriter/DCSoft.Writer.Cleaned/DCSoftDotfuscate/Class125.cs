using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class125
	{
		internal static XTextElementList smethod_0(XTextDocument xtextDocument_0, bool bool_0, bool bool_1, bool bool_2, DocumentControler documentControler_0)
		{
			if (documentControler_0 == null)
			{
				documentControler_0 = xtextDocument_0.DocumentControler;
			}
			XTextElementList xTextElementList = new XTextElementList();
			if (bool_0 && xtextDocument_0 != null && xtextDocument_0.Selection.Length != 0)
			{
				foreach (XTextElement contentElement in xtextDocument_0.Selection.ContentElements)
				{
					if (documentControler_0.CanModify(contentElement))
					{
						xTextElementList.Add(contentElement);
					}
				}
			}
			if (bool_1)
			{
				if (xtextDocument_0.Selection.Length == 0)
				{
					XTextParagraphFlagElement currentParagraphEOF = xtextDocument_0.CurrentParagraphEOF;
					if (documentControler_0.CanModify(currentParagraphEOF))
					{
						xTextElementList.Add(currentParagraphEOF);
					}
				}
				else
				{
					foreach (XTextElement selectionParagraphFlag in xtextDocument_0.Selection.SelectionParagraphFlags)
					{
						if (documentControler_0.CanModify(selectionParagraphFlag))
						{
							xTextElementList.Add(selectionParagraphFlag);
						}
					}
				}
			}
			if (bool_2)
			{
				if (xtextDocument_0.Selection.Cells != null && xtextDocument_0.Selection.Cells.Count > 0)
				{
					foreach (XTextElement cell in xtextDocument_0.Selection.Cells)
					{
						if (documentControler_0.CanModify(cell))
						{
							xTextElementList.Add(cell);
						}
					}
				}
				else
				{
					XTextElement currentElement = xtextDocument_0.CurrentElement;
					XTextTableCellElement ownerCell = currentElement.OwnerCell;
					if (ownerCell != null && documentControler_0.CanModify(ownerCell))
					{
						xTextElementList.Add(ownerCell);
					}
				}
			}
			if (xTextElementList.Count > 0)
			{
				return xTextElementList;
			}
			return null;
		}
	}
}
