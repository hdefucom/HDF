using DCSoftDotfuscate;
using System;
using System.Collections.Generic;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoCharValue : XTextUndoBase
	{
		private class Class40
		{
			public XTextCharElement xtextCharElement_0 = null;

			public char char_0 = '\0';

			public char char_1 = '\0';

			public bool bool_0 = false;
		}

		private List<Class40> list_0 = new List<Class40>();

		public int Count => list_0.Count;

		public void method_0(XTextCharElement xtextCharElement_0, char char_0, char char_1, bool bool_0)
		{
			int num = 2;
			if (xtextCharElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			Class40 @class = new Class40();
			@class.xtextCharElement_0 = xtextCharElement_0;
			@class.char_0 = char_0;
			@class.char_1 = char_1;
			@class.bool_0 = bool_0;
			list_0.Add(@class);
		}

		public override void Undo(GEventArgs3 args)
		{
			method_1(bool_0: true);
		}

		public override void Redo(GEventArgs3 args)
		{
			method_1(bool_0: false);
		}

		private void method_1(bool bool_0)
		{
			foreach (Class40 item in list_0)
			{
				if (bool_0)
				{
					item.xtextCharElement_0.CharValue = item.char_0;
				}
				else
				{
					item.xtextCharElement_0.CharValue = item.char_1;
				}
				item.xtextCharElement_0.SizeInvalid = item.bool_0;
				if (item.bool_0)
				{
				}
			}
			if (list_0.Count > 0)
			{
				XTextCharElement xtextCharElement_ = list_0[0].xtextCharElement_0;
				if (xtextCharElement_.OwnerDocument != null && xtextCharElement_.OwnerDocument.EditorControl != null)
				{
					xtextCharElement_.OwnerDocument.EditorControl.InnerViewControl.Invalidate();
				}
			}
		}
	}
}
