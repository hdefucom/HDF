using DCSoftDotfuscate;
using System;
using System.Collections.Generic;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       撤销表格单元格合并拆分操作
	///       </summary>
	internal class XTextUndoCellSpan : XTextUndoBase
	{
		private XTextTableCellElement xtextTableCellElement_0 = null;

		private int int_0 = 1;

		private int int_1 = 1;

		private int int_2 = 1;

		private int int_3 = 1;

		private Dictionary<XTextTableCellElement, XTextElementList> dictionary_0 = new Dictionary<XTextTableCellElement, XTextElementList>();

		private Dictionary<XTextTableCellElement, XTextElementList> dictionary_1 = new Dictionary<XTextTableCellElement, XTextElementList>();

		/// <summary>
		///       单元格对象
		///       </summary>
		public XTextTableCellElement CellElement
		{
			get
			{
				return xtextTableCellElement_0;
			}
			set
			{
				xtextTableCellElement_0 = value;
			}
		}

		/// <summary>
		///       单元格旧的跨行数
		///       </summary>
		public int OldRowSpan
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       单元格旧的跨列数
		///       </summary>
		public int OldColSpan
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		/// <summary>
		///       单元格新的跨行数
		///       </summary>
		public int NewRowSpan
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		/// <summary>
		///       单元格新的跨列数
		///       </summary>
		public int NewColSpan
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		public XTextUndoCellSpan(XTextTableCellElement xtextTableCellElement_1, int int_4, int int_5)
		{
			xtextTableCellElement_0 = xtextTableCellElement_1;
			XTextTableElement ownerTable = xtextTableCellElement_1.OwnerTable;
			int_0 = xtextTableCellElement_1.RowSpan;
			int_1 = xtextTableCellElement_1.ColSpan;
			int_2 = int_4;
			int_3 = int_5;
			XTextElementList range = ownerTable.GetRange(xtextTableCellElement_1.RowIndex, xtextTableCellElement_1.ColIndex, Math.Max(int_0, int_2), Math.Max(int_1, int_3), includeOverriedCell: true);
			foreach (XTextTableCellElement item in range)
			{
				dictionary_0[item] = item.Elements.Clone();
			}
		}

		internal void method_0()
		{
			XTextElementList range = xtextTableCellElement_0.OwnerTable.GetRange(xtextTableCellElement_0.RowIndex, xtextTableCellElement_0.ColIndex, Math.Max(int_0, int_2), Math.Max(int_1, int_3), includeOverriedCell: true);
			foreach (XTextTableCellElement item in range)
			{
				dictionary_1[item] = item.Elements.Clone();
			}
		}

		private void method_1(Dictionary<XTextTableCellElement, XTextElementList> dictionary_2)
		{
		}

		public override void Undo(GEventArgs3 args)
		{
			method_2(bool_0: true);
		}

		public override void Redo(GEventArgs3 args)
		{
			method_2(bool_0: false);
		}

		private void method_2(bool bool_0)
		{
			if (xtextTableCellElement_0 == null || (int_0 == int_2 && int_1 == int_3))
			{
				return;
			}
			if (bool_0)
			{
				if (int_0 >= 1 && int_1 >= 1)
				{
					xtextTableCellElement_0.method_70(int_0, int_1, bool_26: false, dictionary_0);
				}
			}
			else if (int_2 >= 1 && int_3 >= 1)
			{
				xtextTableCellElement_0.method_70(int_2, int_3, bool_26: false, dictionary_1);
			}
		}
	}
}
