using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档区域对象
	///       </summary>
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890018")]
	[ComClass("00012345-6789-ABCD-EF01-234567890018", "CD19358D-3EC4-4175-8ADF-489B694AC039")]
	
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("StartIndex={StartIndex},Length={Length}")]
	
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComDefaultInterface(typeof(IXTextSelection))]
	public class XTextSelection : IEnumerable, IXTextSelection
	{
		private class Class20
		{
			public XTextSelection xtextSelection_0 = null;

			public XTextElement xtextElement_0 = null;

			public XTextElement xtextElement_1 = null;
		}

		internal const string string_0 = "00012345-6789-ABCD-EF01-234567890018";

		internal const string string_1 = "CD19358D-3EC4-4175-8ADF-489B694AC039";

		private ContentRangeMode contentRangeMode_0 = ContentRangeMode.Content;

		private XTextDocumentContentElement xtextDocumentContentElement_0 = null;

		private XTextElementList xtextElementList_0 = new XTextElementList();

		private XTextElementList xtextElementList_1 = new XTextElementList();

		private XTextElementList xtextElementList_2 = null;

		private int nativeStartIndex = 0;

		private int nativeLength = 0;

		private int startIndex = 0;

		private int length = 0;

		private int int_4 = 0;

		private int int_5 = 0;

		private bool bool_0 = false;

		private XTextElement xtextElement_0 = null;

		private XTextElement xtextElement_1 = null;

		private int int_6 = 0;

		/// <summary>
		///       选择的内容的模式
		///       </summary>
		public ContentRangeMode Mode => contentRangeMode_0;

		/// <summary>
		///       所属的文档容器元素对象
		///       </summary>
		
		public XTextDocumentContentElement DocumentContent => xtextDocumentContentElement_0;

		/// <summary>
		///       所属的文档对象
		///       </summary>
		public XTextDocument Document => xtextDocumentContentElement_0.OwnerDocument;

		/// <summary>
		///       内容容器
		///       </summary>
		private XTextContent Content => xtextDocumentContentElement_0.Content;

		/// <summary>
		///       对象包含的单元格对象列表，该列表包括被合并而隐藏的单元格
		///       </summary>
		
		public XTextElementList Cells => xtextElementList_0;

		/// <summary>
		///       对象包含的单元格对象列表，该列表不包含合并而隐藏的单元格
		///       </summary>
		
		public XTextElementList CellsWithoutOverried
		{
			get
			{
				if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
				{
					XTextElementList xTextElementList = new XTextElementList();
					foreach (XTextTableCellElement cell in Cells)
					{
						if (!cell.IsOverrided)
						{
							xTextElementList.Add(cell);
						}
					}
					return xTextElementList;
				}
				return null;
			}
		}

		/// <summary>
		///       内容元素列表
		///       </summary>
		
		public XTextElementList ContentElements => xtextElementList_1;

		/// <summary>
		///       被选择的段落标记符号元素
		///       </summary>
		public XTextElementList SelectionParagraphFlags
		{
			get
			{
				if (xtextElementList_2 == null)
				{
					xtextElementList_2 = new XTextElementList();
					if (xtextElementList_1 != null && xtextElementList_1.Count > 0)
					{
						foreach (XTextElement item in xtextElementList_1)
						{
							if (item is XTextParagraphFlagElement)
							{
								xtextElementList_2.Add(item);
							}
						}
						XTextElement lastElement = xtextElementList_1.LastElement;
						if (!(lastElement is XTextParagraphFlagElement))
						{
							XTextElementList privateContent = lastElement.ContentElement.PrivateContent;
							for (int i = privateContent.IndexOf(lastElement) + 1; i < privateContent.Count; i++)
							{
								if (privateContent[i] is XTextParagraphFlagElement)
								{
									xtextElementList_2.Add(privateContent[i]);
									break;
								}
							}
						}
					}
				}
				return xtextElementList_2;
			}
		}

		/// <summary>
		///       区域中第一个文档内容元素
		///       </summary>
		public XTextElement FirstElement
		{
			get
			{
				if (xtextElementList_1 == null)
				{
					return null;
				}
				return xtextElementList_1.FirstElement;
			}
		}

		/// <summary>
		///       区域中最后一个文档内容元素
		///       </summary>
		public XTextElement LastElement
		{
			get
			{
				if (xtextElementList_1 == null)
				{
					return null;
				}
				return xtextElementList_1.LastElement;
			}
		}

		/// <summary>
		///       原始的起始位置
		///       </summary>
		public int NativeStartIndex => nativeStartIndex;

		/// <summary>
		///       原始的区域长度
		///       </summary>
		public int NativeLength => nativeLength;

		/// <summary>
		///       实际的起始位置
		///       </summary>
		
		public int StartIndex => startIndex;

		/// <summary>
		///       实际的区域长度
		///       </summary>
		
		public int Length => length;

		/// <summary>
		///       区域的绝对的开始位置
		///       </summary>
		public int AbsStartIndex
		{
			get
			{
				if (length >= 0)
				{
					return startIndex;
				}
				return startIndex + length;
			}
		}

		/// <summary>
		///       绝对的结束位置
		///       </summary>
		public int AbsEndIndex
		{
			get
			{
				if (length >= 0)
				{
					return startIndex + length;
				}
				return startIndex;
			}
		}

		/// <summary>
		///       选择区域的长度的绝对值
		///       </summary>
		public int AbsLength => Math.Abs(length);

		/// <summary>
		///       选择状态版本号，没修改一次选择状态则该版本号就会增加1
		///       </summary>
		public int SelectionVersion => int_4;

		/// <summary>
		///       对象状态版本号，只要修改了选择区域该版本号就会自增1。
		///       </summary>
		public int StateVersion
		{
			get
			{
				return int_6;
			}
			set
			{
				int_6 = value;
			}
		}

		/// <summary>
		///       获得纯文本内容
		///       </summary>
		
		public string Text
		{
			get
			{
				int num = 10;
				if (xtextElementList_1 == null)
				{
					return "";
				}
				StringBuilder stringBuilder = new StringBuilder();
				if (Mode == ContentRangeMode.Cell)
				{
					XTextTableRowElement xTextTableRowElement = null;
					foreach (XTextTableCellElement cell in Cells)
					{
						if (!cell.IsOverrided)
						{
							if (xTextTableRowElement != null && cell.OwnerRow != xTextTableRowElement)
							{
								stringBuilder.AppendLine();
							}
							if (cell.OwnerRow == xTextTableRowElement)
							{
								stringBuilder.Append("   ");
							}
							stringBuilder.Append(cell.Text);
							xTextTableRowElement = cell.OwnerRow;
						}
					}
				}
				else
				{
					int index = 0;
					foreach (XTextElement item in xtextElementList_1)
					{
						if (item is XTextParagraphFlagElement)
						{
							XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
							if (xTextParagraphFlagElement.ListItemElement != null)
							{
								stringBuilder.Insert(index, xTextParagraphFlagElement.ListItemElement.Text);
							}
						}
						stringBuilder.Append(item.ToPlaintString());
						if (item is XTextParagraphFlagElement)
						{
							index = stringBuilder.Length;
						}
					}
				}
				return stringBuilder.ToString();
			}
		}

		
		public string TextExcludeLogicDeleted
		{
			get
			{
				int num = 9;
				if (xtextElementList_1 == null)
				{
					return "";
				}
				StringBuilder stringBuilder = new StringBuilder();
				if (Mode == ContentRangeMode.Cell)
				{
					XTextTableRowElement xTextTableRowElement = null;
					foreach (XTextTableCellElement cell in Cells)
					{
						if (!cell.IsOverrided)
						{
							if (xTextTableRowElement != null && cell.OwnerRow != xTextTableRowElement)
							{
								stringBuilder.AppendLine();
							}
							if (cell.OwnerRow == xTextTableRowElement)
							{
								stringBuilder.Append("   ");
							}
							stringBuilder.Append(cell.Text);
							xTextTableRowElement = cell.OwnerRow;
						}
					}
				}
				else
				{
					int index = 0;
					foreach (XTextElement item in xtextElementList_1)
					{
						if (!item.IsLogicDeleted)
						{
							if (item is XTextParagraphFlagElement)
							{
								XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
								if (xTextParagraphFlagElement.ListItemElement != null)
								{
									stringBuilder.Insert(index, xTextParagraphFlagElement.ListItemElement.Text);
								}
								if (item.Parent is XTextTableCellElement)
								{
									XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)item.Parent;
									if (xTextTableCellElement.LastChild == item)
									{
										XTextElement nextElement = xtextElementList_1.GetNextElement(item);
										if (nextElement != null)
										{
											XTextTableCellElement ownerCell = nextElement.OwnerCell;
											if (ownerCell != null && ownerCell.OwnerRow == xTextTableCellElement.OwnerRow)
											{
												stringBuilder.Append('\t');
												index = stringBuilder.Length;
												continue;
											}
										}
									}
								}
							}
							stringBuilder.Append(item.ToPlaintString());
							if (item is XTextParagraphFlagElement)
							{
								index = stringBuilder.Length;
							}
						}
					}
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       获得表示内容的XML文本
		///       </summary>
		
		public string XMLText => GetContentText("xml");

		/// <summary>
		///       获得表示内容的RTF文本
		///       </summary>
		
		public string RTFText => GetRTFText(excludeLogicDeleted: false);

		/// <summary>
		///       获得区间包含的段落对象列表
		///       </summary>
		public XTextElementList ParagraphsEOFs
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				if (Length != 0)
				{
					foreach (XTextElement item in xtextElementList_1)
					{
						if (item is XTextParagraphFlagElement)
						{
							xTextElementList.Add(item);
						}
					}
					if (!(xtextElementList_1.LastElement is XTextParagraphFlagElement))
					{
						xTextElementList.Add(xtextElementList_1.LastElement.OwnerParagraphEOF);
					}
				}
				else
				{
					XTextElement current = Content.SafeGet(StartIndex);
					if (current != null)
					{
						xTextElementList.Add(current.OwnerParagraphEOF);
					}
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextSelection(XTextDocumentContentElement xtextDocumentContentElement_1)
		{
			xtextDocumentContentElement_0 = xtextDocumentContentElement_1;
		}

		/// <summary>
		///       判断视图元素编号是否包含内容中
		///       </summary>
		/// <param name="viewIndex">视图元素编号</param>
		/// <returns>是否包含</returns>
		public bool ContainsViewIndex(int viewIndex)
		{
			if (viewIndex >= 0)
			{
				return viewIndex >= ContentElements.FirstElement.ViewIndex && viewIndex <= ContentElements.LastElement.ViewIndex;
			}
			return false;
		}

		/// <summary>
		///       判断元素是否包含在区域中
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>是否包含在区域中</returns>
		
		public bool Contains(XTextElement element)
		{
			if (element == null)
			{
				return false;
			}
			if (element is XTextTableCellElement)
			{
				return xtextElementList_0 != null && xtextElementList_0.Contains(element);
			}
			return xtextElementList_1.Contains(element);
		}

		internal bool method_0(XTextTableCellElement xtextTableCellElement_0)
		{
			if (xtextElementList_0 != null && xtextElementList_0.Contains(xtextTableCellElement_0))
			{
				return true;
			}
			return false;
		}

		internal bool method_1(XTextElement xtextElement_2)
		{
			if (xtextElement_2 == null)
			{
				return false;
			}
			if (xtextElement_2 is XTextTableCellElement)
			{
				if (xtextElementList_0 != null && xtextElementList_0.Contains(xtextElement_2))
				{
					return true;
				}
			}
			else if (xtextElement_2 is XTextTableElement)
			{
				if (xtextElementList_0 != null)
				{
					foreach (XTextTableCellElement item in xtextElementList_0)
					{
						if (item.OwnerTable == xtextElement_2)
						{
							return true;
						}
					}
				}
				XTextElement xTextElement = xtextElement_2;
				while (xTextElement != null)
				{
					if (!xtextElementList_1.Contains(xTextElement))
					{
						if (xtextElementList_0 == null || !xtextElementList_0.Contains(xTextElement))
						{
							xTextElement = xTextElement.Parent;
							continue;
						}
						return true;
					}
					return true;
				}
			}
			else if (xtextElementList_1.Contains(xtextElement_2))
			{
				return true;
			}
			foreach (XTextElement item2 in xtextElementList_1)
			{
				if (item2.IsParentOrSupParent(xtextElement_2))
				{
					return true;
				}
			}
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				foreach (XTextElement item3 in xtextElementList_0)
				{
					if (item3.IsParentOrSupParent(xtextElement_2))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal bool method_2(int index, int len)
		{
			if (nativeStartIndex == index && nativeLength == len && DocumentContent.OwnerDocument.ContentVersion == int_5 && Content.LineEndFlag == bool_0)
			{
				return false;
			}
			return true;
		}

		internal bool method_3(XTextTableCellElement xtextTableCellElement_0, XTextTableCellElement xtextTableCellElement_1)
		{
			int num = 3;
			if (xtextTableCellElement_0 == null)
			{
				throw new ArgumentNullException("firstCell");
			}
			if (xtextTableCellElement_1 == null)
			{
				xtextTableCellElement_1 = xtextTableCellElement_0;
			}
			XTextTableElement ownerTable = xtextTableCellElement_0.OwnerTable;
			if (ownerTable == null)
			{
				throw new ArgumentNullException("firstCell.OwnerTable");
			}
			if (xtextTableCellElement_1.OwnerTable != ownerTable)
			{
				throw new ArgumentException("不是同一个表格");
			}
			xtextElementList_1 = new XTextElementList();
			xtextElementList_0 = new XTextElementList();
			contentRangeMode_0 = ContentRangeMode.Cell;
			xtextElementList_0 = ownerTable.GetSelectionCells(xtextTableCellElement_0.RowIndex, xtextTableCellElement_0.ColIndex, xtextTableCellElement_1.RowIndex, xtextTableCellElement_1.ColIndex);
			foreach (XTextTableCellElement item in xtextElementList_0)
			{
				if (!item.IsOverrided)
				{
					method_7(xtextElementList_1, item.PrivateContent);
				}
			}
			if (xtextElementList_1.Count > 0)
			{
				startIndex = xtextElementList_1[0].ViewIndex;
				length = xtextElementList_1.Count;
				nativeStartIndex = startIndex;
				nativeLength = length;
				int_5 = DocumentContent.OwnerDocument.ContentVersion;
				bool_0 = false;
				xtextElementList_2 = null;
				int_4++;
				return true;
			}
			return false;
		}

		
		public void method_4()
		{
			method_6(nativeStartIndex, nativeLength, bool_1: true);
		}

		private void method_5()
		{
			xtextElement_0 = Content.SafeGet(startIndex);
			xtextElement_1 = Content.SafeGet(startIndex + length);
		}

		/// <summary>
		///       更新文内容选择状态
		///       </summary>
		/// <param name="startIndex">选择区域的起始位置</param>
		/// <param name="length">选择区域的包含文档内容元素的个数</param>
		/// <returns>成功的改变了选择区域状态</returns>
		
		public bool Refresh(int startIndex, int length)
		{
			return method_6(startIndex, length, bool_1: false);
		}

		internal bool method_6(int index, int len, bool bool_1)
		{
			int num = 17;
			if (!bool_1 && nativeStartIndex == index && nativeLength == len && DocumentContent.OwnerDocument.ContentVersion == int_5 && Content.LineEndFlag == bool_0)
			{
				return false;
			}
			if (Document.UIIsUpdating)
			{
				return false;
			}
			if (Document != null && Document.EditorControl != null)
			{
				Document.EditorControl.method_10();
				Document.EditorControl.CommandStateNeedRefreshFlag = true;
				if (Document.EditorControl.InnerViewControl != null && Document.EditorControl.InnerViewControl.ViewHandleManager != null)
				{
				}
			}
			int_6++;
			if (index == 0 || index + len == 0)
			{
				Console.Write("");
			}
			if (Math.Abs(len) <= 10)
			{
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex=" + index);
			}
			if (index >= Content.Count)
			{
				index = Content.Count - 1;
			}
			if (index + len >= Content.Count)
			{
				len = Content.Count - index;
			}
			if (index + len < 0)
			{
				len = -index;
			}
			if (len == 0)
			{
			}
			int_4++;
			if (Document.EditorControl != null && !Document.EditorControl.InnerViewControl.bool_30)
			{
				Document.EditorControl.InnerViewControl.method_166();
			}
			Document.CurrentStyleInfo = null;
			XTextElementList xTextElementList = xtextElementList_1.Clone();
			xtextElementList_1 = new XTextElementList();
			xtextElementList_2 = null;
			XTextElementList xTextElementList2 = xtextElementList_0.Clone();
			xtextElementList_0 = new XTextElementList();
			int_5 = DocumentContent.OwnerDocument.ContentVersion;
			if (index == 0 && len == 0)
			{
				nativeStartIndex = 0;
				nativeLength = 0;
				startIndex = 0;
				length = 0;
				method_5();
				bool_0 = Content.LineEndFlag;
				contentRangeMode_0 = ContentRangeMode.Content;
				xtextElementList_1 = new XTextElementList();
				xtextElementList_0 = new XTextElementList();
				xtextElement_0 = Content.SafeGet(nativeStartIndex);
				xtextElement_1 = Content.SafeGet(nativeStartIndex + nativeLength);
			}
			else
			{
				nativeStartIndex = index;
				nativeLength = len;
				bool_0 = Content.LineEndFlag;
				Content.SafeGet(nativeStartIndex)?.method_11(bool_5: true, bool_6: true);
				XTextContent content = Content;
				contentRangeMode_0 = ContentRangeMode.Content;
				XTextElementList xTextElementList3 = new XTextElementList();
				XTextTableCellElement xTextTableCellElement = null;
				XTextTableCellElement xTextTableCellElement2 = null;
				int num2 = 0;
				bool flag = false;
				int num3 = (len > 0) ? index : (index + len);
				int num4 = Math.Abs(len);
				int num5 = 1;
				num5 = ((!content.LineEndFlag || len >= 0) ? 0 : 0);
				float tickCountFloat = CountDown.GetTickCountFloat();
				for (int i = 0; i < num4 + num5 && num3 + i < content.Count; i++)
				{
					XTextElement xTextElement = content[num3 + i];
					if (xTextElement.Parent == DocumentContent)
					{
						xTextElementList3.AddRaw(xTextElement);
						flag = true;
						continue;
					}
					XTextTableCellElement ownerCell = xTextElement.OwnerCell;
					if (ownerCell != null)
					{
						if (ownerCell != xTextTableCellElement2)
						{
							xTextElementList3.AddRaw(ownerCell);
							num2++;
						}
						if (xTextTableCellElement == null)
						{
							xTextTableCellElement = ownerCell;
						}
						if (xTextTableCellElement2 != ownerCell)
						{
							xTextTableCellElement2 = ownerCell;
						}
					}
					else
					{
						xTextElementList3.AddRaw(xTextElement);
						flag = true;
					}
				}
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				XTextTableCellElement ownerCell2 = content[index].OwnerCell;
				if (ownerCell2 != null && !xTextElementList3.Contains(ownerCell2))
				{
					if (xTextTableCellElement == null)
					{
						xTextTableCellElement = ownerCell2;
					}
					if (len < 0 || xTextTableCellElement2 == null)
					{
						xTextTableCellElement2 = ownerCell2;
					}
					xTextElementList3.Add(ownerCell2);
					num2++;
				}
				contentRangeMode_0 = ContentRangeMode.Content;
				if (!flag && num2 == 1)
				{
					if (num3 == xTextTableCellElement.PrivateContent[0].ViewIndex && num4 == xTextTableCellElement.PrivateContent.Count)
					{
						contentRangeMode_0 = ContentRangeMode.Cell;
					}
					else
					{
						contentRangeMode_0 = ContentRangeMode.Content;
					}
				}
				else if ((flag && num2 > 0) || num2 > 1)
				{
					XTextTableElement ownerTable = xTextTableCellElement.OwnerTable;
					if (flag)
					{
						contentRangeMode_0 = ContentRangeMode.Mixed;
					}
					else
					{
						contentRangeMode_0 = ContentRangeMode.Cell;
						foreach (XTextElement item in xTextElementList3)
						{
							if (item is XTextTableCellElement && ((XTextTableCellElement)item).OwnerTable != ownerTable)
							{
								contentRangeMode_0 = ContentRangeMode.Mixed;
								break;
							}
						}
					}
				}
				if (contentRangeMode_0 == ContentRangeMode.Content)
				{
					xtextElementList_1 = content.GetRange(num3, num4);
					startIndex = index;
					length = len;
					method_5();
				}
				else
				{
					xtextElementList_1 = new XTextElementList();
					XTextTableElement ownerTable = xTextTableCellElement.OwnerTable;
					if (contentRangeMode_0 == ContentRangeMode.Cell)
					{
						xtextElementList_0 = ownerTable.GetSelectionCells(xTextTableCellElement.RowIndex, xTextTableCellElement.ColIndex, xTextTableCellElement2.RowIndex, xTextTableCellElement2.ColIndex);
						foreach (XTextTableCellElement item2 in xtextElementList_0)
						{
							if (!item2.IsOverrided)
							{
								method_7(xtextElementList_1, item2.PrivateContent);
							}
						}
					}
					else if (contentRangeMode_0 == ContentRangeMode.Mixed)
					{
						xtextElementList_0 = new XTextElementList();
						XTextTableRowElement xTextTableRowElement = null;
						XTextTableRowElement xTextTableRowElement2 = null;
						for (int i = 0; i < xTextElementList3.Count; i++)
						{
							XTextElement current = xTextElementList3[i];
							if (current is XTextTableCellElement)
							{
								XTextTableCellElement ownerCell = (XTextTableCellElement)current;
								if (xTextTableRowElement == null)
								{
									xTextTableRowElement = ownerCell.OwnerRow;
								}
								if (ownerCell.OwnerTable == xTextTableRowElement.OwnerTable)
								{
									xTextTableRowElement2 = ownerCell.OwnerRow;
									continue;
								}
								XTextElementList selectionCells = xTextTableRowElement.OwnerTable.GetSelectionCells(xTextTableRowElement.Index, 0, xTextTableRowElement2.Index, xTextTableRowElement2.Cells.Count - 1);
								foreach (XTextTableCellElement item3 in selectionCells)
								{
									if (!item3.IsOverrided)
									{
										method_7(xtextElementList_1, item3.PrivateContent);
									}
								}
								xtextElementList_0.AddRange(selectionCells);
								xTextTableRowElement = ownerCell.OwnerRow;
								xTextTableRowElement2 = ownerCell.OwnerRow;
							}
							else
							{
								if (xTextTableRowElement != null)
								{
									XTextElementList selectionCells = xTextTableRowElement.OwnerTable.GetSelectionCells(xTextTableRowElement.Index, 0, xTextTableRowElement2.Index, xTextTableRowElement2.Cells.Count - 1);
									foreach (XTextTableCellElement item4 in selectionCells)
									{
										if (!item4.IsOverrided)
										{
											method_7(xtextElementList_1, item4.PrivateContent);
										}
									}
									xtextElementList_0.AddRange(selectionCells);
									xTextTableRowElement = null;
									xTextTableRowElement2 = null;
								}
								xtextElementList_1.Add(current);
							}
						}
						if (xTextTableRowElement != null)
						{
							XTextElementList selectionCells = xTextTableRowElement.OwnerTable.GetSelectionCells(xTextTableRowElement.Index, 0, xTextTableRowElement2.Index, xTextTableRowElement2.Cells.Count - 1);
							foreach (XTextTableCellElement item5 in selectionCells)
							{
								if (!item5.IsOverrided)
								{
									method_7(xtextElementList_1, item5.PrivateContent);
								}
							}
							xtextElementList_0.AddRange(selectionCells);
						}
					}
				}
				if (len == 0 || xtextElementList_1.Count == 0)
				{
					startIndex = index;
					length = len;
					method_5();
				}
				else
				{
					if (len > 0)
					{
						startIndex = xtextElementList_1[0].ViewIndex;
						length = xtextElementList_1.Count;
						method_5();
						content.LineEndFlag = false;
					}
					else
					{
						startIndex = xtextElementList_1.LastElement.ViewIndex + 1;
						length = -xtextElementList_1.Count;
						method_5();
						if (xtextElementList_1.LastElement.OwnerCell != null)
						{
							DocumentContent.Content.LineEndFlag = true;
							bool_0 = true;
						}
						else
						{
							Console.Write("");
						}
					}
					bool_0 = content.LineEndFlag;
				}
			}
			GClass437 gClass = new GClass437();
			XTextDocument document = Document;
			float tickCountFloat2 = CountDown.GetTickCountFloat();
			if (xTextElementList2 != null && xTextElementList2.Count > 0)
			{
				foreach (XTextTableCellElement item6 in xTextElementList2)
				{
					if (xtextElementList_0 == null || !xtextElementList_0.Contains(item6))
					{
						RectangleF rectangleF_ = document.method_68(item6);
						if (!rectangleF_.IsEmpty)
						{
							gClass.method_1(rectangleF_);
						}
					}
				}
			}
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				foreach (XTextTableCellElement item7 in xtextElementList_0)
				{
					if (!(xTextElementList2?.Contains(item7) ?? false))
					{
						RectangleF rectangleF_ = document.method_68(item7);
						if (!rectangleF_.IsEmpty)
						{
							gClass.method_1(rectangleF_);
						}
					}
				}
			}
			if (Mode == ContentRangeMode.Content || Mode == ContentRangeMode.Mixed)
			{
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					foreach (XTextElement item8 in xTextElementList)
					{
						if (!xtextElementList_1.Contains(item8) || xtextElementList_1.FirstElement == item8 || xtextElementList_1.LastElement == item8)
						{
							RectangleF rectangleF_ = document.method_68(item8);
							if (!rectangleF_.IsEmpty)
							{
								gClass.method_1(rectangleF_);
							}
						}
					}
				}
				if (xtextElementList_1.Count > 0)
				{
					foreach (XTextElement item9 in xtextElementList_1)
					{
						if (xTextElementList == null || !xTextElementList.Contains(item9) || xTextElementList.FirstElement == item9 || xTextElementList.LastElement == item9)
						{
							RectangleF rectangleF_ = document.method_68(item9);
							if (!rectangleF_.IsEmpty)
							{
								gClass.method_1(rectangleF_);
							}
						}
					}
				}
			}
			tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
			if (!gClass.method_3() && Document.EditorControl != null)
			{
				RectangleF rectangleF_ = gClass.method_4();
				Document.EditorControl.ViewInvalidate(rectangleF_, DocumentContent.ContentPartyStyle);
			}
			if (Document.EditorControl == null || Document.EditorControl.InnerViewControl == null || Document.EditorControl.InnerViewControl.ViewHandleManager == null)
			{
			}
			if (StartIndex != -1)
			{
			}
			return true;
		}

		private void method_7(XTextElementList xtextElementList_3, XTextElementList xtextElementList_4)
		{
			foreach (XTextElement item in xtextElementList_4)
			{
				if (item is XTextCharElement || item is XTextParagraphFlagElement)
				{
					xtextElementList_3.AddRaw(item);
				}
				else if (item is XTextTableElement)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)item;
					foreach (XTextTableCellElement cell in xTextTableElement.Cells)
					{
						if (!cell.IsOverrided)
						{
							method_7(xtextElementList_3, cell.PrivateContent);
						}
					}
				}
				else
				{
					if (xtextElementList_3.Contains(item))
					{
						break;
					}
					xtextElementList_3.AddRaw(item);
				}
			}
		}

		public bool method_8(XTextElement xtextElement_2)
		{
			int num = 5;
			if (xtextElement_2 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextElementList_1.Count == 0)
			{
				return false;
			}
			if (contentRangeMode_0 == ContentRangeMode.Content)
			{
				int num2 = xtextElement_2.ContentIndex - xtextElementList_1[0].ContentIndex;
				if (num2 >= 0 && num2 < xtextElementList_1.Count && xtextElementList_1[num2] == xtextElement_2)
				{
					return true;
				}
				return false;
			}
			if (contentRangeMode_0 == ContentRangeMode.Cell)
			{
				XTextElement xTextElement = xtextElement_2;
				while (true)
				{
					if (xTextElement != null)
					{
						if (xTextElement is XTextTableCellElement && xtextElementList_0.Contains(xTextElement))
						{
							break;
						}
						xTextElement = xTextElement.Parent;
						continue;
					}
					return false;
				}
				return true;
			}
			if (contentRangeMode_0 == ContentRangeMode.Mixed)
			{
				XTextElement xTextElement = xtextElement_2;
				while (true)
				{
					if (xTextElement != null)
					{
						if (xTextElement is XTextTableCellElement && xtextElementList_0.Contains(xTextElement))
						{
							break;
						}
						xTextElement = xTextElement.Parent;
						continue;
					}
					return xtextElementList_1.Contains(xtextElement_2);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得元素枚举器
		///       </summary>
		/// <returns>
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			if (xtextElementList_1 == null)
			{
				return null;
			}
			return xtextElementList_1.GetEnumerator();
		}

		/// <summary>
		///       获得指定格式的表示对象内容的文本值
		///       </summary>
		/// <param name="format">文件格式</param>
		/// <returns>文本值</returns>
		
		public string GetContentText(string format)
		{
			XTextDocument xTextDocument = CreateDocument();
			StringWriter stringWriter = new StringWriter();
			xTextDocument.Save(stringWriter, format);
			xTextDocument.Dispose();
			return stringWriter.ToString();
		}

		/// <summary>
		///       获得表示内容的RTF文本
		///       </summary>
		/// <param name="excludeLogicDeleted">不包含逻辑删除的内容</param>
		/// <returns>获得的RTF字符串</returns>
		
		public string GetRTFText(bool excludeLogicDeleted)
		{
			if (length == 0)
			{
				return "";
			}
			XTextDocument ownerDocument = xtextDocumentContentElement_0.OwnerDocument;
			StringWriter stringWriter = new StringWriter();
			GClass103 gClass = new GClass103();
			gClass.vmethod_4(stringWriter);
			gClass.method_1(ownerDocument);
			gClass.method_29();
			gClass.method_13(excludeLogicDeleted);
			gClass.method_32(ownerDocument);
			if (Mode == ContentRangeMode.Content)
			{
				gClass.vmethod_1(bool_1: false);
				XTextElementList xTextElementList = ownerDocument.CreateParagraphs(this);
				foreach (XTextParagraphElement item in xTextElementList)
				{
					WriterUtils.RemoveLogicDeletedElements(item.Elements);
				}
				if (xTextElementList == null || xTextElementList.Count == 0)
				{
					return "";
				}
				gClass.method_9(xTextElementList);
			}
			else
			{
				gClass.vmethod_1(bool_1: true);
				DocumentContent.vmethod_19(gClass);
			}
			gClass.method_34();
			gClass.vmethod_6();
			return stringWriter.ToString();
		}

		/// <summary>
		///       设置段落样式
		///       </summary>
		/// <param name="newStyle">
		/// </param>
		/// <returns>
		/// </returns>
		
		public XTextElementList SetParagraphStyle(DocumentContentStyle newStyle)
		{
			XTextDocument ownerDocument = xtextDocumentContentElement_0.OwnerDocument;
			Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
			if (Document.Options.SecurityOptions.EnablePermission)
			{
				newStyle.DisableDefaultValue = true;
				newStyle.CreatorIndex = Document.UserHistories.CurrentIndex;
				newStyle.DeleterIndex = -1;
			}
			else
			{
				newStyle.DisableDefaultValue = true;
				newStyle.CreatorIndex = -1;
				newStyle.DeleterIndex = -1;
			}
			foreach (XTextParagraphFlagElement paragraphsEOF in ParagraphsEOFs)
			{
				if (ownerDocument.DocumentControler.CanModify(paragraphsEOF))
				{
					DocumentContentStyle documentContentStyle = paragraphsEOF.RuntimeStyle.CloneParent();
					if (XDependencyObject.smethod_7(newStyle, documentContentStyle, bool_3: true) > 0)
					{
						int styleIndex = ownerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
						if (styleIndex != paragraphsEOF.StyleIndex)
						{
							dictionary[paragraphsEOF] = styleIndex;
						}
					}
				}
			}
			if (dictionary.Count > 0)
			{
				return ownerDocument.method_109(dictionary, bool_32: true);
			}
			return null;
		}

		/// <summary>
		///       设置文档元素的样式
		///       </summary>
		/// <param name="newStyle">新样式</param>
		/// <param name="causeUpdateLayout">操作是否导致刷新文档布局</param>
		/// <param name="includeCells">包含单元格</param>
		/// <param name="commandName">命令名称</param>
		/// <returns>是否修改了文档内容</returns>
		
		public bool SetElementStyle(DocumentContentStyle newStyle, bool causeUpdateLayout, bool includeCells, string commandName)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (ContentElements != null)
			{
				xTextElementList.AddRange(ContentElements);
			}
			if (includeCells && Cells != null)
			{
				xTextElementList.AddRange(Cells);
			}
			for (int num = xTextElementList.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = xTextElementList[num];
				if (xTextElement is XTextFieldBorderElement)
				{
					XTextFieldElementBase item = (XTextFieldElementBase)xTextElement.Parent;
					if (!xTextElementList.Contains(item))
					{
						xTextElementList.method_13(num, item);
					}
				}
			}
			if (xTextElementList.Count == 0)
			{
				return false;
			}
			return smethod_0(newStyle, newStyle, newStyle, xtextDocumentContentElement_0.OwnerDocument, xTextElementList, causeUpdateLayout, commandName, bool_2: true);
		}

		
		public static bool smethod_0(DocumentContentStyle documentContentStyle_0, DocumentContentStyle documentContentStyle_1, DocumentContentStyle documentContentStyle_2, XTextDocument xtextDocument_0, IEnumerable ienumerable_0, bool bool_1, string string_2, bool bool_2)
		{
			int num = 19;
			if (documentContentStyle_0 == null)
			{
				throw new ArgumentNullException("newStyle");
			}
			if (xtextDocument_0 == null)
			{
				throw new ArgumentNullException("document");
			}
			if (ienumerable_0 == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (documentContentStyle_1 == null)
			{
				documentContentStyle_1 = documentContentStyle_0;
			}
			if (documentContentStyle_2 == null)
			{
				documentContentStyle_2 = documentContentStyle_0;
			}
			documentContentStyle_0.ValueLocked = false;
			if (xtextDocument_0.Options.SecurityOptions.EnablePermission)
			{
				bool flag = true;
				if (!xtextDocument_0.Options.BehaviorOptions.InsertCommentBindingUserTrack && WriterUtils.smethod_19(string_2))
				{
					flag = false;
				}
				if (flag)
				{
					XDependencyObject.smethod_8(documentContentStyle_0, "DeleterIndex");
					documentContentStyle_0.CreatorIndex = xtextDocument_0.UserHistories.CurrentIndex;
					XDependencyObject.smethod_8(documentContentStyle_1, "DeleterIndex");
					documentContentStyle_1.CreatorIndex = xtextDocument_0.UserHistories.CurrentIndex;
					XDependencyObject.smethod_8(documentContentStyle_2, "DeleterIndex");
					documentContentStyle_2.CreatorIndex = xtextDocument_0.UserHistories.CurrentIndex;
				}
			}
			else
			{
				XDependencyObject.smethod_8(documentContentStyle_0, "CreatorIndex");
				XDependencyObject.smethod_8(documentContentStyle_0, "DeleterIndex");
				XDependencyObject.smethod_8(documentContentStyle_1, "CreatorIndex");
				XDependencyObject.smethod_8(documentContentStyle_1, "DeleterIndex");
				XDependencyObject.smethod_8(documentContentStyle_2, "CreatorIndex");
				XDependencyObject.smethod_8(documentContentStyle_2, "DeleterIndex");
			}
			Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextElement item in ienumerable_0)
			{
				_ = item.Parent;
				bool flag2 = false;
				if (item.Parent is XTextFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item.Parent;
					if (xTextInputFieldElementBase.IsBackgroundTextElement(item) || item is XTextFieldBorderElement)
					{
						flag2 = true;
					}
				}
				if (flag2 && !xTextElementList.Contains(item.Parent))
				{
					xTextElementList.Add(item.Parent);
				}
				DocumentContentStyle documentContentStyle = documentContentStyle_0;
				if (item is XTextParagraphFlagElement)
				{
					documentContentStyle = documentContentStyle_1;
				}
				else if (item is XTextTableCellElement)
				{
					documentContentStyle = documentContentStyle_2;
				}
				if (documentContentStyle == null)
				{
					documentContentStyle = documentContentStyle_0;
				}
				bool flag3 = false;
				DocumentContentStyle documentContentStyle2 = item.RuntimeStyle.CloneParent();
				if (string_2 == "ClearFormat" || string_2 == "FormatBrush")
				{
					if (flag3 = (item.StyleIndex != xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle)))
					{
						documentContentStyle2 = (DocumentContentStyle)documentContentStyle.Clone();
					}
				}
				else if (XDependencyObject.smethod_7(documentContentStyle, documentContentStyle2, bool_3: true) > 0)
				{
					flag3 = true;
				}
				if (flag3)
				{
					if (documentContentStyle2.HasTitleLevel)
					{
						xtextDocument_0.bool_22 = true;
					}
					int styleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle2);
					if (styleIndex != item.StyleIndex)
					{
						dictionary[item] = styleIndex;
					}
					if (item.ShadowElement != null && styleIndex != item.ShadowElement.StyleIndex)
					{
						dictionary[item.ShadowElement] = styleIndex;
					}
				}
			}
			if (xTextElementList.Count > 0)
			{
				foreach (XTextElement item2 in xTextElementList)
				{
					DocumentContentStyle documentContentStyle2 = item2.RuntimeStyle.CloneParent();
					if (XDependencyObject.smethod_7(documentContentStyle_0, documentContentStyle2, bool_3: true) > 0)
					{
						if (documentContentStyle2.HasTitleLevel)
						{
							xtextDocument_0.bool_22 = true;
						}
						int styleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle2);
						if (styleIndex != item2.StyleIndex)
						{
							dictionary[item2] = styleIndex;
						}
					}
				}
			}
			if (dictionary.Count > 0)
			{
				XTextElementList xTextElementList2 = xtextDocument_0.EditorSetElementStyle(dictionary, bool_2, bool_1, string_2);
				if (xTextElementList2 != null && xTextElementList2.Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       根据内容创建一个新的文档对象
		///       </summary>
		/// <returns>创建的文档对象</returns>
		
		public XTextDocument CreateDocument()
		{
			return CreateDocument(Document.Options.EditOptions.CloneWithoutLogicDeletedContent);
		}

		/// <summary>
		///       根据内容创建一个新的文档对象
		///       </summary>
		/// <param name="excludeLogicDeleted">不包含逻辑删除的内容</param>
		/// <returns>创建的文档对象</returns>
		
		public XTextDocument CreateDocument(bool excludeLogicDeleted)
		{
			int num = 2;
			XTextDocument xTextDocument = (XTextDocument)Document.Clone(Deeply: false);
			xTextDocument.ContentStyles = (DocumentContentStyleContainer)Document.ContentStyles.method_2();
			_ = Document;
			XTextContainerElement xtextContainerElement_ = xTextDocument.Body;
			if (ContentElements == null || ContentElements.Count == 0)
			{
				return xTextDocument;
			}
			XTextElementList xTextElementList = WriterUtils.smethod_58(ContentElements.FirstElement);
			XTextElementList xTextElementList2 = WriterUtils.smethod_58(ContentElements.LastElement);
			foreach (XTextContainerElement item in xTextElementList)
			{
				if (xTextElementList2.Contains(item) && !(item is XTextTableRowElement) && !(item is XTextTableElement))
				{
					_ = item.ContentElement;
					method_10(item, ref xtextContainerElement_);
					break;
				}
			}
			if (excludeLogicDeleted)
			{
				foreach (XTextElement element in xTextDocument.Elements)
				{
					WriterUtils.RemoveLogicDeletedElements(element.Elements);
				}
			}
			if (Document.Options.EditOptions.CloneWithoutElementBorderStyle)
			{
				foreach (XTextElement item2 in xTextDocument.GetElementsByType(typeof(XTextElement)))
				{
					if (item2 is XTextCharElement || item2 is XTextObjectElement || item2 is XTextFieldElementBase || item2 is XTextParagraphFlagElement)
					{
						item2.OwnerDocument = xTextDocument;
						item2.Style.method_29("BorderStyle");
						item2.Style.method_29("BorderWidth");
						item2.Style.method_29("BorderTop");
						item2.Style.method_29("BorderLeft");
						item2.Style.method_29("BorderRight");
						item2.Style.method_29("BorderBottom");
						item2.Style.method_29("BorderTopColor");
						item2.Style.method_29("BorderLeftColor");
						item2.Style.method_29("BorderRightColor");
						item2.Style.method_29("BorderBottomColor");
						item2.Style.method_29("RoundRadio");
					}
				}
			}
			foreach (DocumentContentStyle style in xTextDocument.ContentStyles.Styles)
			{
				style.CreatorIndex = -1;
				style.DeleterIndex = -1;
			}
			xTextDocument.UserHistories.Clear();
			if (Document.Comments != null)
			{
				xTextDocument.Comments = Document.Comments.Clone(deeply: true);
			}
			xTextDocument.method_111();
			xTextDocument.EditorControl = null;
			xTextDocument.DocumentControler = null;
			xTextDocument.HighlightManager = null;
			xTextDocument.CurrentStyleInfo = null;
			xTextDocument.HoverElement = null;
			if (xTextDocument.UndoList != null)
			{
				xTextDocument.EndLogUndo();
				xTextDocument.UndoList.Clear();
			}
			xTextDocument.FixDomState();
			return xTextDocument;
		}

		private void method_9(object sender, ElementEnumerateEventArgs e)
		{
			if (e.Element is XTextTableElement)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)e.Element;
				xTextTableElement.method_35();
				e.CancelChild = true;
			}
		}

		private int method_10(XTextContainerElement xtextContainerElement_0, ref XTextContainerElement xtextContainerElement_1)
		{
			int num = 0;
			if (xtextContainerElement_0 is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xtextContainerElement_0;
				if (ContentElements.Contains(xTextFieldElementBase.StartElement) && ContentElements.Contains(xTextFieldElementBase.EndElement))
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xtextContainerElement_0.Clone(Deeply: true);
					if (xtextContainerElement_1 == null)
					{
						xtextContainerElement_1 = xTextContainerElement;
					}
					else
					{
						xtextContainerElement_1.AppendChildElement(xTextContainerElement);
					}
					return 1;
				}
			}
			Dictionary<XTextContentElement, XTextElement> dictionary = new Dictionary<XTextContentElement, XTextElement>();
			foreach (XTextElement element in xtextContainerElement_0.Elements)
			{
				if (element.RuntimeStyle.DeleterIndex < 0)
				{
					if (ContentElements.Contains(element) || Cells.Contains(element))
					{
						if (xtextContainerElement_1 == null)
						{
							xtextContainerElement_1 = (XTextContainerElement)xtextContainerElement_0.Clone(Deeply: false);
							xtextContainerElement_1.OwnerLine = null;
							num++;
						}
						num++;
						xtextContainerElement_1.AppendChildElement(element.Clone(Deeply: true));
						if (xtextContainerElement_1 is XTextContentElement)
						{
							dictionary[(XTextContentElement)xtextContainerElement_1] = element;
						}
					}
					else if (element is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement2 = (XTextContainerElement)element;
						XTextContainerElement xtextContainerElement_2 = null;
						if (method_10(xTextContainerElement2, ref xtextContainerElement_2) == 0 && element is XTextContainerElement)
						{
							XTextContainerElement xTextContainerElement3 = (XTextContainerElement)element;
							if (xTextContainerElement2.Elements.Count == 0)
							{
								XTextElementList xTextElementList = new XTextElementList();
								xTextContainerElement3.vmethod_32(xTextElementList, bool_17: true);
								foreach (XTextElement item in xTextElementList)
								{
									if (ContentElements.Contains(item) && xtextContainerElement_2 == null)
									{
										xtextContainerElement_2 = (XTextContainerElement)xTextContainerElement2.Clone(Deeply: false);
										xtextContainerElement_2.OwnerLine = null;
										break;
									}
								}
							}
						}
						if (xtextContainerElement_2 != null)
						{
							if (xtextContainerElement_1 == null)
							{
								num++;
								xtextContainerElement_1 = (XTextContainerElement)xtextContainerElement_0.Clone(Deeply: false);
								xtextContainerElement_1.OwnerLine = null;
							}
							xtextContainerElement_1.AppendChildElement(xtextContainerElement_2);
						}
					}
				}
			}
			if (dictionary.Count > 0)
			{
				foreach (XTextContentElement key in dictionary.Keys)
				{
					XTextElement xTextElement = dictionary[key];
					if (!(xTextElement is XTextParagraphFlagElement))
					{
						XTextParagraphFlagElement ownerParagraphEOF = xTextElement.OwnerParagraphEOF;
						if (ownerParagraphEOF != null && !ownerParagraphEOF.AutoCreate && ownerParagraphEOF.StyleIndex >= 0)
						{
							key.AppendChildElement(ownerParagraphEOF.Clone(Deeply: true));
						}
					}
				}
			}
			if (xtextContainerElement_1 != null && xtextContainerElement_1 is XTextTableElement)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)xtextContainerElement_1;
				XTextTableElement xTextTableElement2 = (XTextTableElement)xtextContainerElement_0;
				int num2 = 10000;
				int num3 = 0;
				foreach (XTextTableCellElement cell in Cells)
				{
					if (cell.OwnerTable == xTextTableElement2 && !cell.IsOverrided)
					{
						if (cell.ColIndex < num2)
						{
							num2 = cell.ColIndex;
						}
						if (cell.ColIndex + cell.ColSpan > num3)
						{
							num3 = cell.ColIndex + cell.ColSpan;
						}
					}
				}
				num3 = Math.Min(num3, xTextTableElement2.Columns.Count);
				for (int i = num2; i < num3; i++)
				{
					XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)xTextTableElement2.Columns[i].Clone(Deeply: false);
					xTextTableColumnElement.Parent = xTextTableElement;
					xTextTableElement.Columns.Add(xTextTableColumnElement);
				}
				xTextTableElement.method_40();
				xTextTableElement.method_35();
			}
			return num;
		}

		internal void method_11()
		{
			xtextElement_0 = null;
			xtextElement_1 = null;
			if (xtextElementList_0 != null)
			{
				xtextElementList_0.Clear();
				xtextElementList_0 = null;
			}
			if (xtextElementList_1 != null)
			{
				xtextElementList_1.Clear();
				xtextElementList_1 = null;
			}
			xtextDocumentContentElement_0 = null;
			if (xtextElementList_2 != null)
			{
				xtextElementList_2.Clear();
				xtextElementList_2 = null;
			}
		}

		public object method_12()
		{
			Class20 @class = new Class20();
			@class.xtextSelection_0 = this;
			@class.xtextElement_0 = xtextElement_0;
			@class.xtextElement_1 = xtextElement_1;
			return @class;
		}

		public bool method_13(object object_0)
		{
			Class20 @class = object_0 as Class20;
			if (@class == null || @class.xtextSelection_0 != this || @class.xtextElement_0 == null || @class.xtextElement_1 == null)
			{
				return false;
			}
			int num = Content.FastIndexOf(@class.xtextElement_0);
			int num2 = Content.FastIndexOf(@class.xtextElement_1);
			if (num >= 0 && num2 >= 0)
			{
				startIndex = num;
				length = num2 - num;
				nativeStartIndex = startIndex;
				nativeLength = length;
				return true;
			}
			return false;
		}
	}
}
