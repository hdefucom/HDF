using DCSoftDotfuscate;
using System.Collections.Generic;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       撤销、重复设置段落样式的对象
	///       </summary>
	internal class XTextUndoSetElementStyle : XTextUndoBase
	{
		private bool bool_0 = false;

		private bool bool_1 = true;

		private string string_0 = null;

		private Dictionary<XTextElement, int> dictionary_0 = new Dictionary<XTextElement, int>();

		private Dictionary<XTextElement, int> dictionary_1 = new Dictionary<XTextElement, int>();

		/// <summary>
		///       设置段落样式
		///       </summary>
		public bool ParagraphStyle
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public bool CauseUpdateLayout
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		public string CommandName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public void method_0(XTextElement xtextElement_0, int int_0, int int_1)
		{
			dictionary_0[xtextElement_0] = int_0;
			dictionary_1[xtextElement_0] = int_1;
		}

		public override void Redo(GEventArgs3 args)
		{
			if (dictionary_1.Count > 0)
			{
				if (ParagraphStyle)
				{
					base.Document.method_109(dictionary_1, bool_32: false);
				}
				else
				{
					base.Document.EditorSetElementStyle(dictionary_1, logUndo: false, CauseUpdateLayout, string_0);
				}
			}
		}

		public override void Undo(GEventArgs3 args)
		{
			if (dictionary_0.Count > 0)
			{
				if (ParagraphStyle)
				{
					base.Document.method_109(dictionary_0, bool_32: false);
				}
				else
				{
					base.Document.EditorSetElementStyle(dictionary_0, logUndo: false, CauseUpdateLayout, string_0);
				}
			}
		}
	}
}
