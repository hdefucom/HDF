using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoTableColumnWidth : XTextUndoBase
	{
		private XTextTableColumnElement xtextTableColumnElement_0 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private bool bool_0 = true;

		public XTextUndoTableColumnWidth(XTextTableColumnElement xtextTableColumnElement_1, float float_2, float float_3, bool bool_1)
		{
			xtextTableColumnElement_0 = xtextTableColumnElement_1;
			float_0 = float_2;
			float_1 = float_3;
			bool_0 = bool_1;
		}

		public override void Undo(GEventArgs3 args)
		{
			xtextTableColumnElement_0.method_13(float_0, bool_7: false, bool_0);
		}

		public override void Redo(GEventArgs3 args)
		{
			xtextTableColumnElement_0.method_13(float_1, bool_7: false, bool_0);
		}
	}
}
