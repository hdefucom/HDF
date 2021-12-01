using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoInvalidateElements : XTextUndoBase
	{
		private XTextElementList xtextElementList_0 = null;

		public XTextUndoInvalidateElements(XTextElementList xtextElementList_1)
		{
			xtextElementList_0 = xtextElementList_1;
		}

		public XTextUndoInvalidateElements(XTextElement xtextElement_0)
		{
			if (xtextElement_0 != null)
			{
				xtextElementList_0 = new XTextElementList(xtextElement_0);
			}
		}

		public override void Undo(GEventArgs3 args)
		{
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				foreach (XTextElement item in xtextElementList_0)
				{
					item.InvalidateView();
				}
			}
		}

		public override void Redo(GEventArgs3 args)
		{
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				foreach (XTextElement item in xtextElementList_0)
				{
					item.InvalidateView();
				}
			}
		}
	}
}
