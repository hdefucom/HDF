using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       重复/撤销设置元素的可见性
	///       </summary>
	internal class XTextUndoElementVisible : XTextUndoBase
	{
		private XTextElement xtextElement_0 = null;

		private bool bool_0 = false;

		private bool bool_1 = false;

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextUndoElementVisible()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">操作的文档元素</param>
		/// <param name="newVisible">旧的可见性</param>
		/// <param name="oldVisible">新的可见性</param>
		public XTextUndoElementVisible(XTextElement xtextElement_1, bool bool_2, bool bool_3)
		{
			xtextElement_0 = xtextElement_1;
			bool_0 = bool_2;
			bool_1 = bool_3;
		}

		public override void Undo(GEventArgs3 args)
		{
			xtextElement_0.EditorSetVisibleExt(bool_0, logUndo: false, fastMode: false);
			base.OwnerList.RefreshElements.Add(xtextElement_0);
		}

		public override void Redo(GEventArgs3 args)
		{
			xtextElement_0.EditorSetVisibleExt(bool_1, logUndo: false, fastMode: false);
			base.OwnerList.RefreshElements.Add(xtextElement_0);
		}
	}
}
