using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	internal class Class51 : GInterface2
	{
		private class MyElementEnumer : TreeNodeEnumerable
		{
			public bool bool_0 = false;

			public MyElementEnumer(ArrayList arrayList_0)
				: base(arrayList_0, bool_0: true)
			{
			}

			public override IEnumerable GetChildNodes(object instance)
			{
				XTextElementList xTextElementList = null;
				if (instance is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)instance;
					xTextElementList = xTextFieldElementBase.method_27();
				}
				else
				{
					xTextElementList = ((XTextElement)instance).Elements;
				}
				if (bool_0 && xTextElementList != null)
				{
					return new ListReverseEnumrable(xTextElementList);
				}
				return xTextElementList;
			}
		}

		private XTextDocument xtextDocument_0 = null;

		public Class51(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public bool imethod_0(MoveFocusHotKeys moveFocusHotKeys_0, Keys keys_0)
		{
			if (moveFocusHotKeys_0 != 0 && moveFocusHotKeys_0 != MoveFocusHotKeys.Default)
			{
				bool result = false;
				if (moveFocusHotKeys_0 == MoveFocusHotKeys.Enter && keys_0 == Keys.Return)
				{
					result = true;
				}
				else if (moveFocusHotKeys_0 == MoveFocusHotKeys.Tab && keys_0 == Keys.Tab)
				{
					result = true;
				}
				return result;
			}
			return false;
		}

		public XTextElement imethod_1(XTextElement xtextElement_0, Keys keys_0, bool bool_0, KeyEventArgs keyEventArgs_0)
		{
			XTextContainerElement parent = xtextElement_0.Parent;
			if (xtextElement_0 is XTextFieldBorderElement)
			{
				XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xtextElement_0;
				if (xTextFieldBorderElement.Position == BorderElementPosition.Start)
				{
					parent = xTextFieldBorderElement.Parent.Parent;
				}
			}
			MoveFocusHotKeys moveFocusHotKeys = MoveFocusHotKeys.None;
			while (parent != null)
			{
				if (!parent.AcceptTab || keys_0 != Keys.Tab || bool_0)
				{
					moveFocusHotKeys = parent.RuntimeMoveFocusHotKey;
					if (moveFocusHotKeys != 0)
					{
						break;
					}
					parent = parent.Parent;
					continue;
				}
				return null;
			}
			if (moveFocusHotKeys == MoveFocusHotKeys.None)
			{
				return null;
			}
			GEnum11 gEnum = method_2(moveFocusHotKeys, keys_0, bool_0);
			if (gEnum == GEnum11.const_2 || gEnum == GEnum11.const_1)
			{
				XTextElement xTextElement = imethod_2(xtextElement_0, gEnum == GEnum11.const_1);
				XTextTableCellElement ownerCell = xtextElement_0.OwnerCell;
				if (ownerCell != null && !bool_0)
				{
					XTextTableCellElement xTextTableCellElement = null;
					if (xTextElement != null)
					{
						xTextTableCellElement = xTextElement.OwnerCell;
					}
					if (ownerCell != xTextTableCellElement && method_1(ownerCell, keys_0) && keyEventArgs_0 != null && method_0(ownerCell))
					{
						keyEventArgs_0.Handled = true;
						return null;
					}
				}
				return xTextElement;
			}
			return null;
		}

		private bool method_0(XTextTableCellElement xtextTableCellElement_0)
		{
			int num = 19;
			XTextTableElement ownerTable = xtextTableCellElement_0.OwnerTable;
			WriterControl writerControl = xtextTableCellElement_0.WriterControl;
			if (!writerControl.RuntimeReadonly && ownerTable.RuntimeAllowUserInsertRow && writerControl.DocumentControler.CanModifyContent(ownerTable, DomAccessFlags.Normal))
			{
				XTextElementList xTextElementList = (XTextElementList)writerControl.ExecuteCommandSpecifyRaiseFromUI("Table_InsertRowDown", showUI: false, null, raiseFromUI: true);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[0];
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[0];
					if (xTextTableCellElement.IsOverrided)
					{
						xTextTableCellElement = xTextTableCellElement.OverrideCell;
					}
					writerControl.method_62(new WriterEventArgs(writerControl, xtextDocument_0, ownerTable));
					xTextTableCellElement.Focus();
					return true;
				}
			}
			return false;
		}

		private bool method_1(XTextTableCellElement xtextTableCellElement_0, Keys keys_0)
		{
			if (xtextTableCellElement_0.AcceptTab && keys_0 == Keys.Tab)
			{
				return false;
			}
			if (xtextTableCellElement_0.OwnerDocument != null && xtextTableCellElement_0.OwnerDocument.Options.EditOptions.AutoInsertTableRowWhenMoveToNextCell)
			{
				XTextTableElement ownerTable = xtextTableCellElement_0.OwnerTable;
				if (ownerTable.RuntimeAllowUserInsertRow)
				{
					if (xtextTableCellElement_0.ColIndex + xtextTableCellElement_0.ColSpan != ownerTable.ColumnsCount)
					{
						return false;
					}
					XTextTableRowElement ownerRow = xtextTableCellElement_0.OwnerRow;
					if (ownerRow.AllowInsertRowDownUseHotKey == DCInsertRowDownUseHotKeys.Disable)
					{
						return false;
					}
					if (ownerRow.AllowInsertRowDownUseHotKey == DCInsertRowDownUseHotKeys.EnableOnlyForLastRow)
					{
						if (xtextTableCellElement_0 == ownerTable.LastVisibleCell)
						{
							return true;
						}
						return false;
					}
					return true;
				}
			}
			return false;
		}

		private GEnum11 method_2(MoveFocusHotKeys moveFocusHotKeys_0, Keys keys_0, bool bool_0)
		{
			if (moveFocusHotKeys_0 != 0 && moveFocusHotKeys_0 != MoveFocusHotKeys.Default)
			{
				if (moveFocusHotKeys_0 == MoveFocusHotKeys.Enter && keys_0 == Keys.Return)
				{
					if (bool_0)
					{
						return GEnum11.const_1;
					}
					return GEnum11.const_2;
				}
				if (moveFocusHotKeys_0 == MoveFocusHotKeys.Tab && keys_0 == Keys.Tab)
				{
					if (bool_0)
					{
						return GEnum11.const_1;
					}
					return GEnum11.const_2;
				}
			}
			return GEnum11.const_0;
		}

		public XTextElement imethod_2(XTextElement xtextElement_0, bool bool_0)
		{
			int num = 8;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("srcElement");
			}
			if (xtextElement_0 is XTextFieldBorderElement && !bool_0)
			{
				XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xtextElement_0;
				if (xTextFieldBorderElement.Position == BorderElementPosition.Start && xTextFieldBorderElement.OwnerField != null && xTextFieldBorderElement.OwnerField.RuntimeTabStop)
				{
					return xTextFieldBorderElement.OwnerField;
				}
			}
			ArrayList arrayList = new ArrayList();
			for (XTextElement xTextElement = xtextElement_0; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				arrayList.Insert(0, xTextElement);
				if (xTextElement is XTextDocumentContentElement)
				{
					break;
				}
			}
			if (arrayList.Count == 0)
			{
				return null;
			}
			MyElementEnumer myElementEnumer = new MyElementEnumer(arrayList);
			myElementEnumer.bool_0 = bool_0;
			foreach (XTextElement item in myElementEnumer)
			{
				if (item.RuntimeVisible && !arrayList.Contains(item) && item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					if (xTextContainerElement.RuntimeTabStop && (xtextDocument_0.EditorControl.FormView != FormViewMode.Strict || xTextContainerElement.GetOwnerParent(typeof(XTextInputFieldElementBase), includeThis: true) != null))
					{
						return xTextContainerElement;
					}
				}
			}
			return null;
		}
	}
}
