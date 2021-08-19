using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       设置文档属性
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	internal class XTextUndoSetDocumentProperty : XTextUndoBase
	{
		private XTextDocument xtextDocument_0 = null;

		private string string_0 = null;

		private object object_0 = null;

		private object object_1 = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="propertyName">属性名称</param>
		/// <param name="oldValue">旧属性值</param>
		/// <param name="newValue">新属性值</param>
		public XTextUndoSetDocumentProperty(XTextDocument xtextDocument_1, string string_1, object object_2, object object_3)
		{
			xtextDocument_0 = xtextDocument_1;
			string_0 = string_1;
			object_1 = object_2;
			object_0 = object_3;
		}

		public override void Undo(GEventArgs3 args)
		{
			int num = 2;
			string text = string_0;
			if (text != null && text == "DefaultStyle")
			{
				xtextDocument_0.EditorSetDefaultStyle((DocumentContentStyle)object_1, logUndo: false);
			}
		}

		public override void Redo(GEventArgs3 args)
		{
			int num = 8;
			string text = string_0;
			if (text != null && text == "DefaultStyle")
			{
				xtextDocument_0.EditorSetDefaultStyle((DocumentContentStyle)object_0, logUndo: false);
			}
		}
	}
}
