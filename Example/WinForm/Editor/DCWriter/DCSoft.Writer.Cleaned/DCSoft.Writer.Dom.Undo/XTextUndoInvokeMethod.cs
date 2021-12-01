using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoInvokeMethod : XTextUndoBase
	{
		private UndoMethodTypes undoMethodTypes_0 = UndoMethodTypes.None;

		public XTextUndoInvokeMethod(UndoMethodTypes undoMethodTypes_1)
		{
			undoMethodTypes_0 = undoMethodTypes_1;
		}

		public override void Redo(GEventArgs3 args)
		{
			base.OwnerList.NeedInvokeMethods = (base.OwnerList.NeedInvokeMethods | undoMethodTypes_0);
		}

		public override void Undo(GEventArgs3 args)
		{
			base.OwnerList.NeedInvokeMethods = (base.OwnerList.NeedInvokeMethods | undoMethodTypes_0);
		}
	}
}
