using DCSoft.Writer.Dom;
using System.Collections.Generic;

namespace DCSoftDotfuscate
{
	internal class Class116
	{
		private int int_0 = -1;

		private XTextTableElement xtextTableElement_0 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 0f;

		private List<Class118> list_0 = new List<Class118>();

		private List<Class117> list_1 = new List<Class117>();

		public Class116()
		{
		}

		public Class116(XTextTableElement xtextTableElement_1)
		{
			method_14(xtextTableElement_1, bool_0: false);
		}

		public Class116(XTextTableElement xtextTableElement_1, bool bool_0)
		{
			method_14(xtextTableElement_1, bool_0);
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
		}

		public XTextTableElement method_2()
		{
			return xtextTableElement_0;
		}

		public void method_3(XTextTableElement xtextTableElement_1)
		{
			xtextTableElement_0 = xtextTableElement_1;
		}

		public float method_4()
		{
			return float_0;
		}

		public void method_5(float float_3)
		{
			float_0 = float_3;
		}

		public float method_6()
		{
			return float_1;
		}

		public void method_7(float float_3)
		{
			float_1 = float_3;
		}

		public float method_8()
		{
			return float_2;
		}

		public void method_9(float float_3)
		{
			float_2 = float_3;
		}

		internal List<Class118> method_10()
		{
			return list_0;
		}

		internal void method_11(List<Class118> list_2)
		{
			list_0 = list_2;
		}

		internal List<Class117> method_12()
		{
			return list_1;
		}

		internal void method_13(List<Class117> list_2)
		{
			list_1 = list_2;
		}

		public void method_14(XTextTableElement xtextTableElement_1, bool bool_0)
		{
			method_1(xtextTableElement_1.OwnerDocument.Selection.StartIndex);
			method_3(xtextTableElement_1);
			method_7(xtextTableElement_1.Width);
			method_9(xtextTableElement_1.Height);
			method_5(xtextTableElement_1.LeftIndent);
			method_10().Clear();
			foreach (XTextTableColumnElement column in xtextTableElement_1.Columns)
			{
				Class118 @class = new Class118();
				@class.method_3(column.Left);
				@class.method_5(column.Width);
				@class.method_1(column);
				method_10().Add(@class);
			}
			method_12().Clear();
			foreach (XTextTableRowElement row in xtextTableElement_1.Rows)
			{
				Class117 class2 = new Class117();
				class2.method_3(row.SpecifyHeight);
				class2.method_5(row.Top);
				class2.method_7(row.Height);
				class2.method_1(row);
				foreach (XTextTableCellElement cell in row.Cells)
				{
					Class119 class3 = new Class119();
					class3.method_5(cell.RowSpan);
					class3.method_7(cell.ColSpan);
					class3.method_1(cell);
					class3.method_3(cell.OverrideCell);
					class3.method_9(cell.Left);
					class3.method_11(cell.Top);
					class3.method_13(cell.Width);
					class3.method_15(cell.Height);
					class3.method_19(cell.ValueExpression);
					class2.method_8().Add(class3);
					if (bool_0)
					{
						class3.method_17(cell.Elements.ToArray());
					}
				}
				method_12().Add(class2);
			}
		}

		public void method_15(XTextTableElement xtextTableElement_1, bool bool_0)
		{
			xtextTableElement_1.Width = method_6();
			xtextTableElement_1.Height = method_8();
			xtextTableElement_1.LeftIndent = method_4();
			xtextTableElement_1.Columns.Clear();
			foreach (Class118 item in method_10())
			{
				XTextTableColumnElement xTextTableColumnElement = item.method_0();
				xTextTableColumnElement.Width = item.method_4();
				xTextTableColumnElement.Left = item.method_2();
				xTextTableColumnElement.Parent = xtextTableElement_1;
				xtextTableElement_1.Columns.Add(xTextTableColumnElement);
			}
			xtextTableElement_1.Rows.Clear();
			if (xtextTableElement_1.RuntimeRows != null)
			{
				xtextTableElement_1.RuntimeRows.Clear();
			}
			foreach (Class117 item2 in method_12())
			{
				XTextTableRowElement xTextTableRowElement = item2.method_0();
				xtextTableElement_1.Rows.Add(xTextTableRowElement);
				xTextTableRowElement.SpecifyHeight = item2.method_2();
				xTextTableRowElement.Top = item2.method_4();
				xTextTableRowElement.Height = item2.method_6();
				xTextTableRowElement.Parent = xtextTableElement_1;
				xTextTableRowElement.Cells.Clear();
				foreach (Class119 item3 in item2.method_8())
				{
					XTextTableCellElement xTextTableCellElement = item3.method_0();
					xTextTableCellElement.method_61(item3.method_4());
					xTextTableCellElement.method_60(item3.method_6());
					xTextTableCellElement.method_57(item3.method_2());
					xTextTableCellElement.Left = item3.method_8();
					xTextTableCellElement.Top = item3.method_10();
					xTextTableCellElement.Width = item3.method_12();
					xTextTableCellElement.Height = item3.method_14();
					xTextTableCellElement.ValueExpression = item3.method_18();
					xTextTableCellElement.Parent = xTextTableRowElement;
					xTextTableRowElement.Cells.Add(xTextTableCellElement);
					if (item3.method_16() != null)
					{
						xTextTableCellElement.Elements.Clear();
						xTextTableCellElement.Elements.AddRange(item3.method_16());
						xTextTableCellElement.vmethod_36(bool_22: true);
					}
					if (bool_0 && xTextTableCellElement.OverrideCell == null)
					{
						xTextTableCellElement.ExecuteLayout();
						xTextTableCellElement.method_40();
					}
				}
			}
			xtextTableElement_1.method_31(bool_26: false);
		}
	}
}
