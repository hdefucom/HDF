using DCSoftDotfuscate;
using System.Collections.Generic;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoHeaderRow : XTextUndoBase
	{
		private XTextTableElement xtextTableElement_0 = null;

		private Dictionary<XTextTableRowElement, bool> dictionary_0 = new Dictionary<XTextTableRowElement, bool>();

		private Dictionary<XTextTableRowElement, bool> dictionary_1 = new Dictionary<XTextTableRowElement, bool>();

		public XTextTableElement Table
		{
			get
			{
				return xtextTableElement_0;
			}
			set
			{
				xtextTableElement_0 = value;
			}
		}

		public Dictionary<XTextTableRowElement, bool> OldHeaderStyles
		{
			get
			{
				return dictionary_0;
			}
			set
			{
				dictionary_0 = value;
			}
		}

		/// <summary>
		///       新标题行样式
		///       </summary>
		public Dictionary<XTextTableRowElement, bool> NewHeaderStyles
		{
			get
			{
				return dictionary_1;
			}
			set
			{
				dictionary_1 = value;
			}
		}

		public override void Undo(GEventArgs3 args)
		{
			Table.EditorSetHeaderRow(OldHeaderStyles, logUndo: false);
		}

		public override void Redo(GEventArgs3 args)
		{
			Table.EditorSetHeaderRow(NewHeaderStyles, logUndo: false);
		}
	}
}
