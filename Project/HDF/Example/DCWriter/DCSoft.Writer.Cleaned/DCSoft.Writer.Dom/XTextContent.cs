using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Security;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档内容管理对象
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890051")]
	[DCInternal]
	[ComClass("00012345-6789-ABCD-EF01-234567890051", "89D2B286-781C-42A1-8DBF-81AFECFAA950")]
	[DebuggerDisplay("Count={ Count }")]
	[ComDefaultInterface(typeof(IXTextContent))]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(true)]
	[DocumentComment]
	public class XTextContent : XTextElementList, IXTextContent
	{
		private enum Enum1
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		internal const string string_2 = "00012345-6789-ABCD-EF01-234567890051";

		internal const string string_3 = "89D2B286-781C-42A1-8DBF-81AFECFAA950";

		private XTextDocument xtextDocument_0 = null;

		private XTextDocumentContentElement xtextDocumentContentElement_0 = null;

		private bool bool_1 = false;

		private int int_0 = int.MinValue;

		/// <summary>
		/// AutoClearSelection
		/// </summary>
		private bool bool_2 = true;

		private bool bool_3 = true;

		private int int_1 = -1;

		private float float_0 = -1f;

		/// <summary>
		///       对象所属的文档对象
		///       </summary>
		public virtual XTextDocument OwnerDocument
		{
			get
			{
				return xtextDocument_0;
			}
			internal set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       对象所属的文档区域对象
		///       </summary>
		public XTextDocumentContentElement DocumentContentElement
		{
			get
			{
				return xtextDocumentContentElement_0;
			}
			internal set
			{
				xtextDocumentContentElement_0 = value;
			}
		}

		/// <summary>
		///       光标在行尾标记
		///       </summary>
		public bool LineEndFlag
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
				if (bool_1)
				{
				}
			}
		}

		/// <summary>
		///       有效的锁定位置序号
		///       </summary>
		public int LockIndex
		{
			get
			{
				if (int_0 == int.MinValue)
				{
					int_0 = -1;
					int currentPermissionLevel = OwnerDocument.UserHistories.CurrentPermissionLevel;
					for (int num = base.Count - 1; num >= 0; num--)
					{
						if (base[num] is XTextSignElement)
						{
							int creatorPermessionLevel = base[num].CreatorPermessionLevel;
							if (OwnerDocument.Options.SecurityOptions.PowerfulSignDocument)
							{
								int_0 = num;
								break;
							}
							if (creatorPermessionLevel >= currentPermissionLevel)
							{
								int_0 = num;
								break;
							}
						}
					}
				}
				return int_0;
			}
		}

		/// <summary>
		///       选中区域
		///       </summary>
		public XTextSelection Selection => xtextDocumentContentElement_0.Selection;

		/// <summary>
		///       选择区域开始位置
		///       </summary>
		public int SelectionStartIndex => xtextDocumentContentElement_0.Selection.StartIndex;

		/// <summary>
		///       选择区域长度
		///       </summary>
		public int SelectionLength => xtextDocumentContentElement_0.Selection.Length;

		/// <summary>
		///       是否自动清除选择状态,若为True则插入点位置修改时会自动设置SelectionLength属性，否则会根据
		///       旧的插入点的位置计算SelectionLength长度
		///       </summary>
		[DCInternal]
		public bool AutoClearSelection
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       判断能否删除被选中的元素
		///       </summary>
		[DCInternal]
		public bool CanDeleteSelection
		{
			get
			{
				if (base.Count == 0)
				{
					return false;
				}
				if (SelectionLength == 0)
				{
					return false;
				}
				DocumentControler documentControler = OwnerDocument.DocumentControler;
				foreach (XTextElement contentElement in Selection.ContentElements)
				{
					if (!documentControler.method_18(contentElement))
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       选择区域中的第一个元素作为当前元素
		///       </summary>
		internal bool SelectionStartElementAsCurrentElement
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		/// <summary>
		///       获得当前元素
		///       </summary>
		public XTextElement CurrentElement
		{
			get
			{
				if (base.Count == 0)
				{
					return null;
				}
				if (Selection.AbsStartIndex >= 0 && Selection.AbsStartIndex < base.Count)
				{
					if (SelectionStartElementAsCurrentElement)
					{
						return SafeGet(Selection.StartIndex);
					}
					return SafeGet(Selection.StartIndex + Selection.Length);
				}
				return SafeGet(base.Count - 1);
			}
			set
			{
				int num = method_8(value);
				if (num >= 0)
				{
					MoveToPosition(num);
				}
			}
		}

		/// <summary>
		///       当前段落结束标记对象
		///       </summary>
		public XTextParagraphFlagElement CurrentParagraphEOF => method_41(CurrentElement);

		/// <summary>
		///       获得当前选中的元素,若文档中选择了一个元素则该属性返回这个元素,
		///       若没有选中元素或选中多个元素则返回空
		///       </summary>
		public XTextElement CurrentSelectElement
		{
			get
			{
				if (base.Count == 0 || Math.Abs(Selection.Length) != 1)
				{
					return null;
				}
				return Selection.FirstElement;
			}
		}

		/// <summary>
		///       获得当前位置的前一个元素
		///       </summary>
		public XTextElement PreElement
		{
			get
			{
				int selectionStartIndex = SelectionStartIndex;
				if (base.Count > 0 && selectionStartIndex > 0 && selectionStartIndex < base.Count)
				{
					return base[selectionStartIndex - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       当前文档内容布局方向
		///       </summary>
		public ContentLayoutDirectionStyle CurrentLayoutDirection => CurrentLine?.RuntimeLayoutDirection ?? ContentLayoutDirectionStyle.LeftToRight;

		/// <summary>
		///       当前文本行对象
		///       </summary>
		public XTextLine CurrentLine
		{
			get
			{
				if (base.Count == 0)
				{
					return null;
				}
				if (CurrentElement != null)
				{
					XTextLine ownerLine = CurrentElement.OwnerLine;
					if (ownerLine != null)
					{
						if (bool_1)
						{
							int num = DocumentContentElement.Lines.IndexOf(ownerLine);
							if (num > 0)
							{
								return DocumentContentElement.Lines[num - 1];
							}
						}
						return ownerLine;
					}
				}
				int selectionStartIndex = SelectionStartIndex;
				if (selectionStartIndex >= 0 && selectionStartIndex < base.Count)
				{
					XTextLine ownerLine = base[selectionStartIndex].OwnerLine;
					if (bool_1 && DocumentContentElement.Lines.IndexOf(ownerLine) > 0)
					{
						return DocumentContentElement.Lines[DocumentContentElement.Lines.IndexOf(ownerLine) - 1];
					}
					return ownerLine;
				}
				return base.LastElement.OwnerLine;
			}
		}

		/// <summary>
		///       用户界面是否被锁定了。
		///       </summary>
		private bool UIIsUpdating
		{
			get
			{
				if (xtextDocument_0 != null && xtextDocument_0.EditorControl != null && xtextDocument_0.EditorControl.IsUpdating)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       开始鼠标拖拽选择时的插入点位置
		///       </summary>
		internal int StartDragPosition
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
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XTextContent()
		{
		}

		[DCInternal]
		public void method_16()
		{
			Clear();
			int_0 = int.MinValue;
			bool_2 = true;
			bool_1 = false;
		}

		public bool method_17(int int_2)
		{
			if (int_0 >= 0)
			{
				return int_2 <= int_0;
			}
			return false;
		}

		internal void method_18(ref int index, ref int len)
		{
			if (base.Count == 0)
			{
				index = 0;
				len = 0;
				return;
			}
			int num = index + len;
			if (index >= base.Count)
			{
				index = base.Count - 1;
			}
			if (index < 0)
			{
				index = 0;
			}
			if (num >= base.Count)
			{
				num = base.Count - 1;
			}
			if (num < 0)
			{
				num = 0;
			}
			len = num - index;
		}

		/// <summary>
		///       获得当前插入点的信息
		///       </summary>
		/// <param name="container">插入点所在的容器对象</param>
		/// <param name="elementIndex">插入点所在的容器元素子元素列表中的序号</param>
		public void GetCurrentPositionInfo(out XTextContainerElement container, out int elementIndex)
		{
			method_20(Selection.StartIndex, out container, out elementIndex, LineEndFlag);
		}

		public int method_19(XTextContainerElement xtextContainerElement_1, int int_2, bool bool_4)
		{
			int num = 17;
			if (xtextContainerElement_1 == null)
			{
				throw new ArgumentNullException("container");
			}
			if (int_2 <= 0)
			{
				int_2 = xtextContainerElement_1.FirstContentElement.ViewIndex;
			}
			else if (int_2 >= xtextContainerElement_1.Elements.Count)
			{
				int_2 = xtextContainerElement_1.LastContentElement.ViewIndex;
			}
			else
			{
				XTextElement xTextElement = xtextContainerElement_1.Elements[int_2];
				int_2 = ((!(xTextElement is XTextParagraphFlagElement)) ? xTextElement.FirstContentElement.ViewIndex : method_8(xTextElement));
			}
			return int_2;
		}

		public void method_20(int int_2, out XTextContainerElement xtextContainerElement_1, out int int_3, bool bool_4)
		{
			int num = 1;
			if (base.Count == 0)
			{
				xtextContainerElement_1 = null;
				int_3 = 0;
				return;
			}
			if (int_2 < 0)
			{
				int_2 = 0;
			}
			if (int_2 >= base.Count)
			{
				int_2 = base.Count - 1;
			}
			if (int_2 < 0 || int_2 > base.Count)
			{
				throw new ArgumentOutOfRangeException("contentIndex=" + int_2);
			}
			if (int_2 >= base.Count)
			{
				xtextContainerElement_1 = DocumentContentElement;
				int_3 = DocumentContentElement.Elements.Count;
				return;
			}
			XTextElement xTextElement = base[int_2];
			xtextContainerElement_1 = xTextElement.Parent;
			int_3 = xtextContainerElement_1.Elements.method_9(xTextElement);
			if (xtextContainerElement_1 is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xtextContainerElement_1;
				if (xTextFieldElementBase.StartElement == xTextElement)
				{
					xtextContainerElement_1 = xTextFieldElementBase.Parent;
					xTextElement = xTextFieldElementBase;
					int_3 = xtextContainerElement_1.Elements.method_9(xTextFieldElementBase);
				}
				else if (xTextFieldElementBase.EndElement == xTextElement)
				{
					xtextContainerElement_1 = xTextFieldElementBase;
					int_3 = xTextFieldElementBase.Elements.Count;
				}
				else if (int_3 < 0)
				{
					int_3 = 0;
				}
			}
			else
			{
				if (!bool_4)
				{
					return;
				}
				if (int_2 == 0)
				{
					int_2 = 1;
				}
				XTextElement xTextElement2 = base[int_2 - 1];
				xtextContainerElement_1 = xTextElement2.Parent;
				if (xtextContainerElement_1 is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xtextContainerElement_1;
					if (xTextFieldElementBase.EndElement == xTextElement2)
					{
						xtextContainerElement_1 = xTextFieldElementBase.Parent;
						int_3 = xtextContainerElement_1.Elements.method_9(xTextFieldElementBase) + 1;
						return;
					}
					if (int_3 < 0)
					{
						int_3 = 0;
					}
				}
				int_3 = xtextContainerElement_1.Elements.method_9(xTextElement2) + 1;
			}
		}

		public XTextCharElement method_21()
		{
			int num = (SelectionStartIndex == 0 && base.Count > 1) ? 1 : (SelectionStartIndex - 1);
			while (true)
			{
				if (num >= 0)
				{
					if (base[num] is XTextCharElement)
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return (XTextCharElement)base[num];
		}

		public int method_22()
		{
			return method_24(SafeGet(SelectionStartIndex), bool_4: false, bool_5: true);
		}

		public int method_23(XTextElement xtextElement_0)
		{
			return method_24(xtextElement_0, bool_4: false, bool_5: true);
		}

		public int method_24(XTextElement xtextElement_0, bool bool_4, bool bool_5)
		{
			int result = -1;
			if (xtextElement_0 == null || !Contains(xtextElement_0))
			{
				return -1;
			}
			XTextLine ownerLine = xtextElement_0.OwnerLine;
			int num = method_8(xtextElement_0) - 1;
			while (num >= 0 && (!bool_5 || base[num].OwnerLine == ownerLine) && base[num] is XTextCharElement)
			{
				char charValue = (base[num] as XTextCharElement).CharValue;
				if (char.IsLetter(charValue))
				{
					result = num;
				}
				else
				{
					if (!bool_4 || !StringConvertHelper.IsChineseCharacter(charValue))
					{
						break;
					}
					result = num;
				}
				num--;
			}
			return result;
		}

		public string method_25()
		{
			return method_26(SafeGet(SelectionStartIndex), bool_4: false, bool_5: true);
		}

		public string method_26(XTextElement xtextElement_0, bool bool_4, bool bool_5)
		{
			int num = method_24(xtextElement_0, bool_4, bool_5);
			StringBuilder stringBuilder = new StringBuilder();
			XTextCharElement xTextCharElement = null;
			if (num >= 0)
			{
				for (int i = num; i < SelectionStartIndex; i++)
				{
					xTextCharElement = (base[i] as XTextCharElement);
					if (xTextCharElement == null || !char.IsLetter(xTextCharElement.CharValue))
					{
						break;
					}
					stringBuilder.Append(xTextCharElement.CharValue);
				}
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		public string method_27(XTextElement xtextElement_0)
		{
			int num = method_23(xtextElement_0);
			StringBuilder stringBuilder = new StringBuilder();
			XTextCharElement xTextCharElement = null;
			if (num >= 0)
			{
				for (int i = num; i < base.Count; i++)
				{
					xTextCharElement = (base[i] as XTextCharElement);
					if (xTextCharElement == null || !char.IsLetter(xTextCharElement.CharValue))
					{
						break;
					}
					stringBuilder.Append(xTextCharElement.CharValue);
				}
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		private XTextParagraphFlagElement[] method_28()
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = null;
			XTextParagraphFlagElement xTextParagraphFlagElement2 = null;
			if (Selection.Length == 0)
			{
				return null;
			}
			XTextElement firstElement = Selection.FirstElement;
			XTextElement lastElement = Selection.LastElement;
			if (firstElement != null && lastElement != null)
			{
				xTextParagraphFlagElement = firstElement.OwnerParagraphEOF;
				xTextParagraphFlagElement2 = lastElement.OwnerParagraphEOF;
				if (xTextParagraphFlagElement != xTextParagraphFlagElement2)
				{
					return new XTextParagraphFlagElement[2]
					{
						xTextParagraphFlagElement,
						xTextParagraphFlagElement2
					};
				}
			}
			return null;
		}

		public int method_29(bool bool_4)
		{
			if (UIIsUpdating)
			{
				return -1;
			}
			if (base.Count == 0)
			{
				return -1;
			}
			XTextElement currentElement = CurrentElement;
			XTextElement firstElement = currentElement.ContentElement.PrivateContent.FirstElement;
			if (firstElement == currentElement && !LineEndFlag)
			{
				return -1;
			}
			if (currentElement.IsRightToLeft)
			{
				currentElement = currentElement.OwnerLine.GetPreElement(currentElement);
				if (currentElement == null)
				{
					currentElement = PreElement;
				}
			}
			else
			{
				currentElement = PreElement;
			}
			if (currentElement == null)
			{
				return -1;
			}
			XTextContentElement contentElement = currentElement.ContentElement;
			if (!OwnerDocument.DocumentControler.method_18(currentElement))
			{
				OwnerDocument.DocumentControler.method_23(OwnerDocument.ContentProtectedInfos);
				return -1;
			}
			XTextParagraphFlagElement xtextParagraphFlagElement_ = method_41(currentElement);
			XTextParagraphFlagElement xtextParagraphFlagElement_2 = method_41(CurrentElement);
			XTextContainerElement parent = currentElement.Parent;
			int int_ = contentElement.PrivateContent.method_9(currentElement);
			XTextElement currentElement2 = CurrentElement;
			ContentChangedEventArgs contentChangedEventArgs_ = new ContentChangedEventArgs();
			bool bool_5 = false;
			if (method_31(parent, currentElement, bool_4, ref contentChangedEventArgs_, ref bool_5))
			{
				LineEndFlag = false;
				xtextDocument_0.Modified = true;
				method_33(xtextParagraphFlagElement_, xtextParagraphFlagElement_2);
				XTextContentElement.Class11 @class = new XTextContentElement.Class11();
				@class.method_11(bool_5: true);
				@class.method_5(bool_5: false);
				@class.method_7(bool_5: true);
				@class.method_1(currentElement is XTextCharElement);
				contentElement.vmethod_37(@class);
				OwnerDocument.ContentStyles.method_4();
				contentElement.vmethod_39(int_, -1, bool_22: false, bool_23: false);
				if (currentElement is XTextParagraphFlagElement)
				{
					DocumentContentElement.SetSelection(Selection.StartIndex - 1, 0);
				}
				else if (bool_5 && method_8(currentElement) >= 0)
				{
					int startIndex = method_8(currentElement);
					DocumentContentElement.SetSelection(startIndex, 0);
				}
				else if (currentElement2 != null && method_8(currentElement2) >= 0)
				{
					int startIndex = method_8(currentElement2);
					OwnerDocument.bool_26 = true;
					DocumentContentElement.SetSelection(startIndex, 0);
					OwnerDocument.bool_26 = false;
				}
				else
				{
					DocumentContentElement.SetSelection(Selection.StartIndex - 1, 0);
				}
				OwnerDocument.CommentManager.imethod_6(bool_0: true);
				parent.method_23(contentChangedEventArgs_);
				if (base[Selection.StartIndex] is XTextFieldBorderElement)
				{
					XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)base[Selection.StartIndex];
					XTextInputFieldElementBase xTextInputFieldElementBase = xTextFieldBorderElement.Parent as XTextInputFieldElementBase;
					if (xTextInputFieldElementBase != null && xTextInputFieldElementBase.EndElement == xTextFieldBorderElement && xTextInputFieldElementBase.method_32(bool_20: true, bool_21: true))
					{
					}
				}
				return Selection.StartIndex;
			}
			return -1;
		}

		private bool method_30(XTextElement xtextElement_0)
		{
			RuntimeDocumentContentStyle runtimeStyle = xtextElement_0.RuntimeStyle;
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			bool result = false;
			if (xtextElement_0.Parent.RuntimeEnablePermission && ownerDocument.Options.SecurityOptions.EnableLogicDelete)
			{
				if (runtimeStyle.CreatorIndex == ownerDocument.UserHistories.CurrentIndex)
				{
					result = false;
				}
				else
				{
					result = true;
					if (ownerDocument.Options.SecurityOptions.RealDeleteOwnerContent)
					{
						UserHistoryInfo info = ownerDocument.UserHistories.GetInfo(runtimeStyle.CreatorIndex);
						UserHistoryInfo currentInfo = ownerDocument.UserHistories.CurrentInfo;
						if (info != null && currentInfo != null && info.ID == currentInfo.ID)
						{
							result = false;
						}
					}
				}
			}
			return result;
		}

		private bool method_31(XTextContainerElement xtextContainerElement_1, XTextElement xtextElement_0, bool bool_4, ref ContentChangedEventArgs contentChangedEventArgs_0, ref bool bool_5)
		{
			int elementIndex = xtextContainerElement_1.Elements.FastIndexOf(xtextElement_0);
			if (bool_4)
			{
				ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
				contentChangingEventArgs.Document = OwnerDocument;
				contentChangingEventArgs.Element = xtextContainerElement_1;
				contentChangingEventArgs.ElementIndex = elementIndex;
				contentChangingEventArgs.DeletingElements = new XTextElementList();
				contentChangingEventArgs.DeletingElements.Add(xtextElement_0);
				xtextContainerElement_1.method_22(contentChangingEventArgs);
				if (contentChangingEventArgs.Cancel)
				{
					return false;
				}
			}
			XTextUndoReplaceElements xTextUndoReplaceElements = null;
			bool flag = false;
			if (method_30(xtextElement_0))
			{
				DocumentContentStyle documentContentStyle = xtextElement_0.RuntimeStyle.CloneParent();
				documentContentStyle.DisableDefaultValue = true;
				documentContentStyle.DeleterIndex = OwnerDocument.UserHistories.CurrentIndex;
				int styleIndex = OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
				if (OwnerDocument.CanLogUndo)
				{
					OwnerDocument.UndoList.AddStyleIndex(xtextElement_0, xtextElement_0.StyleIndex, styleIndex);
				}
				xtextElement_0.StyleIndex = styleIndex;
				flag = true;
				bool_5 = true;
			}
			else
			{
				if (OwnerDocument.CanLogUndo)
				{
					XTextElementList xTextElementList = new XTextElementList();
					xTextElementList.Add(xtextElement_0);
					xTextUndoReplaceElements = new XTextUndoReplaceElements(xtextContainerElement_1, elementIndex, xTextElementList, null);
					xTextUndoReplaceElements.Document = OwnerDocument;
					xTextUndoReplaceElements.InGroup = true;
				}
				if (flag = xtextContainerElement_1.RemoveChild(xtextElement_0))
				{
					bool_5 = false;
				}
			}
			if (flag)
			{
				xtextContainerElement_1.DocumentContentElement.method_55();
				if (xtextElement_0 is XTextParagraphFlagElement && xtextElement_0.RuntimeStyle.IsListNumberStyle)
				{
					xtextContainerElement_1.DocumentContentElement.ParagraphTreeInvalidte = true;
					if (OwnerDocument.CanLogUndo)
					{
						OwnerDocument.UndoList.AddMethod(UndoMethodTypes.RefreshParagraphTree);
					}
				}
				OwnerDocument.ContentSnapshot.method_8(xtextElement_0);
				if (OwnerDocument.HighlightManager != null)
				{
					OwnerDocument.HighlightManager.imethod_8(xtextElement_0);
				}
				if (OwnerDocument.EditorControl != null && OwnerDocument.EditorControl.ControlHostManger != null)
				{
					OwnerDocument.EditorControl.ControlHostManger.RemoveDeletedHostControl();
				}
				xtextContainerElement_1.UpdateContentVersion();
				if (xTextUndoReplaceElements != null && OwnerDocument.CanLogUndo)
				{
					OwnerDocument.UndoList.method_14(xTextUndoReplaceElements);
				}
				if (contentChangedEventArgs_0 != null)
				{
					contentChangedEventArgs_0.Document = OwnerDocument;
					contentChangedEventArgs_0.Element = xtextContainerElement_1;
					contentChangedEventArgs_0.ElementIndex = elementIndex;
					contentChangedEventArgs_0.DeletedElements = new XTextElementList();
					contentChangedEventArgs_0.DeletedElements.Add(xtextElement_0);
				}
				return true;
			}
			return false;
		}

		public int method_32(bool bool_4)
		{
			if (UIIsUpdating)
			{
				return -1;
			}
			if (base.Count == 0)
			{
				return -1;
			}
			XTextElement currentElement = CurrentElement;
			if (currentElement == null)
			{
				return -1;
			}
			XTextContentElement contentElement = currentElement.ContentElement;
			if (!OwnerDocument.DocumentControler.method_18(currentElement))
			{
				OwnerDocument.DocumentControler.method_23(OwnerDocument.ContentProtectedInfos);
				return -1;
			}
			if (contentElement.PrivateContent.LastElement == currentElement)
			{
				return -1;
			}
			XTextParagraphFlagElement ownerParagraphEOF = currentElement.OwnerParagraphEOF;
			XTextContainerElement parent = currentElement.Parent;
			int int_ = contentElement.PrivateContent.method_9(currentElement);
			XTextElement xTextElement = currentElement.OwnerLine.GetNextElement(currentElement);
			if (xTextElement == null)
			{
				xTextElement = GetNextElement(currentElement);
			}
			if (xTextElement == null)
			{
				xTextElement = base.LastElement;
			}
			ContentChangedEventArgs contentChangedEventArgs_ = new ContentChangedEventArgs();
			bool bool_5 = false;
			if (method_31(parent, currentElement, bool_4, ref contentChangedEventArgs_, ref bool_5))
			{
				LineEndFlag = false;
				XTextElement xTextElement2 = SafeGet(Selection.StartIndex + 1);
				if (xTextElement2 != null)
				{
					method_33(ownerParagraphEOF, xTextElement2.OwnerParagraphEOF);
				}
				xtextDocument_0.Modified = true;
				XTextContentElement.Class11 @class = new XTextContentElement.Class11();
				@class.method_11(bool_5: true);
				@class.method_5(bool_5: false);
				@class.method_7(bool_5: true);
				@class.method_1(currentElement is XTextCharElement);
				contentElement.vmethod_37(@class);
				if (!OwnerDocument.CommentManager.imethod_6(bool_0: true))
				{
				}
				contentElement.method_31(int_);
				if (bool_4)
				{
					parent.method_23(contentChangedEventArgs_);
				}
				if (xTextElement != null && Contains(xTextElement))
				{
					DocumentContentElement.SetSelection(method_8(xTextElement), 0);
				}
				else
				{
					DocumentContentElement.SetSelection(Selection.StartIndex, 0);
				}
				return Selection.StartIndex;
			}
			return -1;
		}

		private void method_33(XTextParagraphFlagElement xtextParagraphFlagElement_0, XTextParagraphFlagElement xtextParagraphFlagElement_1)
		{
			if (xtextParagraphFlagElement_0 != xtextParagraphFlagElement_1 && xtextParagraphFlagElement_0 != null && xtextParagraphFlagElement_1 != null && xtextParagraphFlagElement_0.RuntimeStyle.CreatorIndex < 0 && xtextParagraphFlagElement_0.RuntimeStyle.DeleterIndex < 0)
			{
				if (OwnerDocument.CanLogUndo)
				{
					OwnerDocument.UndoList.AddStyleIndex(xtextParagraphFlagElement_1, xtextParagraphFlagElement_1.StyleIndex, xtextParagraphFlagElement_0.StyleIndex);
				}
				xtextParagraphFlagElement_1.StyleIndex = xtextParagraphFlagElement_0.StyleIndex;
			}
		}

		private int method_34(XTextContainerElement xtextContainerElement_1, Dictionary<XTextContentElement, int> dictionary_0, bool bool_4, XTextSelection xtextSelection_0, List<ContentChangedEventArgs> list_0)
		{
			XTextContentElement xTextContentElement = xtextContainerElement_1.ContentElement;
			if (xtextContainerElement_1 is XTextContentElement)
			{
				xTextContentElement = (XTextContentElement)xtextContainerElement_1;
			}
			XTextElementList privateContent = xTextContentElement.PrivateContent;
			XTextElementList contentElements = xtextSelection_0.ContentElements;
			DocumentControler documentControler = OwnerDocument.DocumentControler;
			new XTextElementList();
			Enum1[] array = new Enum1[xtextContainerElement_1.Elements.Count];
			int num = 0;
			XTextElement xTextElement = contentElements[0];
			while (xTextElement != null)
			{
				if (xTextElement.Parent != xtextContainerElement_1)
				{
					xTextElement = xTextElement.Parent;
					continue;
				}
				num = xtextContainerElement_1.Elements.IndexOf(xTextElement);
				if (num < 0)
				{
					num = 0;
				}
				break;
			}
			int num2 = xtextContainerElement_1.Elements.Count - 1;
			xTextElement = contentElements.LastElement;
			while (xTextElement != null)
			{
				if (xTextElement.Parent != xtextContainerElement_1)
				{
					xTextElement = xTextElement.Parent;
					continue;
				}
				num2 = xtextContainerElement_1.Elements.IndexOf(xTextElement);
				if (num2 < 0)
				{
					num2 = xtextContainerElement_1.Elements.Count - 1;
				}
				break;
			}
			int num3 = num;
			while (true)
			{
				if (num3 <= num2)
				{
					XTextElement xTextElement2 = xtextContainerElement_1.Elements[num3];
					bool flag;
					if (flag = documentControler.method_18(xTextElement2))
					{
						if (xTextElement2 is XTextContainerElement && ((XTextContainerElement)xTextElement2).vmethod_27(OwnerDocument.ContentProtectedInfos, 100))
						{
							flag = false;
						}
					}
					else
					{
						documentControler.method_23(OwnerDocument.ContentProtectedInfos);
					}
					if (flag)
					{
						if (contentElements.Contains(xTextElement2))
						{
							array[num3] = Enum1.const_0;
						}
						else if (xTextElement2 is XTextContainerElement)
						{
							array[num3] = method_37((XTextContainerElement)xTextElement2, xtextSelection_0);
						}
						else
						{
							array[num3] = Enum1.const_2;
						}
						if (bool_4 && (array[num3] == Enum1.const_0 || array[num3] == Enum1.const_1))
						{
							break;
						}
					}
					else
					{
						array[num3] = Enum1.const_2;
					}
					num3++;
					continue;
				}
				if (bool_4)
				{
					documentControler.method_23(null);
					OwnerDocument.ContentProtectedInfos.Clear();
					return 0;
				}
				for (num3 = num; num3 <= num2; num3++)
				{
					if (array[num3] != Enum1.const_3)
					{
						continue;
					}
					bool flag2 = false;
					Enum1 @enum = Enum1.const_2;
					int num4 = num3 - 1;
					while (num4 >= num2)
					{
						if (array[num4] == Enum1.const_3)
						{
							num4--;
							continue;
						}
						@enum = array[num4];
						flag2 = true;
						break;
					}
					bool flag3 = false;
					Enum1 enum2 = Enum1.const_2;
					for (num4 = num3 + 1; num4 <= num2; num4++)
					{
						if (array[num4] != Enum1.const_3)
						{
							enum2 = array[num4];
							flag3 = true;
							break;
						}
					}
					if (@enum != Enum1.const_2 && enum2 != Enum1.const_2)
					{
						array[num3] = Enum1.const_0;
					}
					if (!flag2)
					{
						array[num3] = enum2;
					}
					else if (!flag3)
					{
						array[num3] = @enum;
					}
					else
					{
						array[num3] = Enum1.const_2;
					}
				}
				int num5 = 0;
				int num6 = privateContent.Count;
				XTextElement xTextElement3 = null;
				XTextElement xTextElement4 = null;
				new List<XTextUndoReplaceElements>();
				Dictionary<XTextElement, Enum1> dictionary = new Dictionary<XTextElement, Enum1>();
				for (num3 = num; num3 <= num2; num3++)
				{
					dictionary[xtextContainerElement_1.Elements[num3]] = array[num3];
				}
				bool flag4 = xtextContainerElement_1.RuntimeEnablePermission && OwnerDocument.Options.SecurityOptions.EnableLogicDelete;
				int num7 = -1;
				_ = OwnerDocument.UserHistories.CurrentIndex;
				for (num3 = num; num3 < xtextContainerElement_1.Elements.Count && num3 <= num2; num3++)
				{
					XTextElement xTextElement2 = xtextContainerElement_1.Elements[num3];
					if (dictionary[xTextElement2] == Enum1.const_0)
					{
						xTextElement4 = xtextContainerElement_1.Elements[num3];
						if (xTextElement3 == null)
						{
							xTextElement3 = xTextElement4;
						}
						int num8 = privateContent.method_9(xTextElement3.FirstContentElement);
						if (num8 >= 0 && num6 > num8)
						{
							num6 = num8;
						}
						if (!flag4)
						{
							continue;
						}
						int creatorIndex = xTextElement4.FirstContentElement.RuntimeStyle.CreatorIndex;
						if (creatorIndex != num7)
						{
							XTextElement preElement = xtextContainerElement_1.Elements.GetPreElement(xTextElement4);
							int num9 = method_35(xtextContainerElement_1, xTextElement3, preElement, bool_4: true, list_0);
							num5 += Math.Abs(num9);
							if (num9 > 0)
							{
								num2 -= num9;
								num3 -= num9;
							}
							xTextElement4 = xtextContainerElement_1.Elements[num3];
							xTextElement3 = xTextElement4;
							num7 = creatorIndex;
						}
						continue;
					}
					if (xTextElement3 != null)
					{
						int num9 = method_35(xtextContainerElement_1, xTextElement3, xTextElement4, bool_4: true, list_0);
						if (num9 > 0)
						{
							num2 -= num9;
							num3 -= num9;
						}
						xTextElement3 = null;
						xTextElement4 = null;
						num5 += Math.Abs(num9);
					}
					if (dictionary[xTextElement2] == Enum1.const_1)
					{
						num5 += method_34((XTextContainerElement)xTextElement2, dictionary_0, bool_4, xtextSelection_0, list_0);
					}
				}
				if (xTextElement3 != null)
				{
					int num8 = privateContent.method_9(xTextElement3);
					if (num8 >= 0 && num6 > num8)
					{
						num6 = num8;
					}
					int num9 = method_35(xtextContainerElement_1, xTextElement3, xTextElement4, bool_4: true, list_0);
					num5 += Math.Abs(num9);
				}
				if (xTextContentElement.DocumentContentElement != null)
				{
					xTextContentElement.DocumentContentElement.method_55();
				}
				if (dictionary_0.ContainsKey(xTextContentElement))
				{
					dictionary_0[xTextContentElement] = Math.Min(dictionary_0[xTextContentElement], num6);
				}
				else
				{
					dictionary_0[xTextContentElement] = num6;
				}
				return num5;
			}
			documentControler.method_23(null);
			OwnerDocument.ContentProtectedInfos.Clear();
			return 1;
		}

		private int method_35(XTextContainerElement xtextContainerElement_1, XTextElement xtextElement_0, XTextElement xtextElement_1, bool bool_4, List<ContentChangedEventArgs> list_0)
		{
			if (UIIsUpdating)
			{
				return 0;
			}
			try
			{
				int num = xtextContainerElement_1.Elements.IndexOf(xtextElement_0);
				int num2 = xtextContainerElement_1.Elements.IndexOf(xtextElement_1);
				XTextParagraphFlagElement xTextParagraphFlagElement = method_41(xtextElement_0);
				XTextParagraphFlagElement xTextParagraphFlagElement2 = null;
				if (xtextContainerElement_1.Elements.LastElement != xtextElement_1)
				{
					xTextParagraphFlagElement2 = method_41(xtextContainerElement_1.Elements.GetNextElement(xtextElement_1));
				}
				XTextElementList range = xtextContainerElement_1.Elements.GetRange(num, num2 - num + 1);
				if (range.Count == 0)
				{
					return 0;
				}
				foreach (XTextElement item in range)
				{
					if (item is XTextParagraphFlagElement && item.RuntimeStyle.IsListNumberStyle)
					{
						DocumentContentElement.ParagraphTreeInvalidte = true;
						if (OwnerDocument.CanLogUndo)
						{
							OwnerDocument.UndoList.AddMethod(UndoMethodTypes.RefreshParagraphTree);
						}
						break;
					}
				}
				if (bool_4)
				{
					ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
					contentChangingEventArgs.Document = OwnerDocument;
					contentChangingEventArgs.Element = xtextContainerElement_1;
					contentChangingEventArgs.ElementIndex = num;
					contentChangingEventArgs.DeletingElements = range;
					xtextContainerElement_1.method_22(contentChangingEventArgs);
					if (contentChangingEventArgs.Cancel)
					{
						return 0;
					}
				}
				bool flag;
				if (flag = method_30(xtextContainerElement_1.Elements[num]))
				{
					method_36(xtextContainerElement_1, num, num2);
				}
				else
				{
					if (OwnerDocument.CanLogUndo)
					{
						OwnerDocument.UndoList.AddRemoveElements(xtextContainerElement_1, xtextContainerElement_1.Elements.IndexOf(xtextElement_0), range);
					}
					xtextContainerElement_1.Elements.RemoveRange(num, num2 - num + 1);
				}
				OwnerDocument.ContentSnapshot.method_9(range);
				if (OwnerDocument.HighlightManager != null)
				{
					foreach (XTextElement item2 in range)
					{
						if (!(item2 is XTextCharElement))
						{
							OwnerDocument.HighlightManager.imethod_8(item2);
						}
					}
				}
				xtextContainerElement_1.UpdateContentVersion();
				if (OwnerDocument.CommentManager != null)
				{
					OwnerDocument.CommentManager.imethod_6(bool_0: true);
				}
				foreach (XTextElement item3 in range)
				{
					if (item3.OwnerLine != null)
					{
						item3.OwnerLine.InvalidateState = true;
					}
					else if (item3 is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)item3;
						XTextElementList xTextElementList = new XTextElementList();
						xTextContainerElement.vmethod_32(xTextElementList, bool_17: false);
						if (xTextElementList.Count > 0)
						{
							foreach (XTextElement item4 in xTextElementList)
							{
								if (item4.OwnerLine != null)
								{
									item4.OwnerLine.InvalidateState = true;
								}
							}
						}
					}
				}
				if (bool_4)
				{
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = OwnerDocument;
					contentChangedEventArgs.Element = xtextContainerElement_1;
					contentChangedEventArgs.ElementIndex = num;
					contentChangedEventArgs.DeletedElements = range;
					list_0.Add(contentChangedEventArgs);
				}
				if (xTextParagraphFlagElement != xTextParagraphFlagElement2 && xTextParagraphFlagElement2 != null)
				{
					method_33(xTextParagraphFlagElement, xTextParagraphFlagElement2);
				}
				if (flag)
				{
					return -range.Count;
				}
				return range.Count;
			}
			finally
			{
			}
		}

		private void method_36(XTextContainerElement xtextContainerElement_1, int int_2, int int_3)
		{
			XTextDocument ownerDocument = OwnerDocument;
			for (int i = int_2; i <= int_3; i++)
			{
				XTextElement xTextElement = xtextContainerElement_1.Elements[i];
				DocumentContentStyle documentContentStyle = xTextElement.RuntimeStyle.CloneParent();
				documentContentStyle.DisableDefaultValue = true;
				documentContentStyle.DeleterIndex = ownerDocument.UserHistories.CurrentIndex;
				int styleIndex = ownerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
				if (OwnerDocument.CanLogUndo)
				{
					ownerDocument.UndoList.AddStyleIndex(xTextElement, xTextElement.StyleIndex, styleIndex);
				}
				xTextElement.StyleIndex = styleIndex;
				if (xTextElement is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
					method_36(xTextContainerElement, 0, xTextContainerElement.Elements.Count - 1);
				}
			}
		}

		private Enum1 method_37(XTextContainerElement xtextContainerElement_1, XTextSelection xtextSelection_0)
		{
			if (xtextSelection_0 == null)
			{
				xtextSelection_0 = Selection;
			}
			bool flag = false;
			bool flag2 = false;
			if (xtextContainerElement_1 is XTextTableElement && xtextSelection_0.Mode == ContentRangeMode.Cell)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)xtextContainerElement_1;
				foreach (XTextTableCellElement visibleCell in xTextTableElement.VisibleCells)
				{
					if (xtextSelection_0.Cells.Contains(visibleCell))
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						break;
					}
				}
			}
			else
			{
				int tickCount = Environment.TickCount;
				XTextElementList xTextElementList = new XTextElementList();
				xtextContainerElement_1.vmethod_32(xTextElementList, bool_17: true);
				if (xTextElementList.Count == 0)
				{
					return Enum1.const_3;
				}
				foreach (XTextElement item in xTextElementList)
				{
					if (xtextSelection_0.method_8(item))
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						break;
					}
				}
				tickCount = Math.Abs(Environment.TickCount - tickCount);
			}
			Enum1 result = Enum1.const_2;
			if (flag && flag2)
			{
				result = Enum1.const_1;
			}
			else if (flag && !flag2)
			{
				result = Enum1.const_0;
				if (xtextContainerElement_1 is XTextTableCellElement || xtextContainerElement_1 is XTextTableRowElement)
				{
					result = Enum1.const_1;
				}
			}
			else if (!flag && flag2)
			{
				result = Enum1.const_2;
			}
			return result;
		}

		/// <summary>
		///       已删除文档树结构的方式来删除选中的元素
		///       </summary>
		/// <param name="raiseEvent">是否触发文档ContentChanging , ContentChanged事件</param>
		/// <param name="detect">检测是否可以执行删除元素操作,但不真的进行删除</param>
		/// <param name="fastMode">快速模式，不更新用户界面，不更新内容元素列表</param>
		/// <returns>删除的文档元素对象个数</returns>
		public int DeleteSelection(bool raiseEvent, bool detect, bool fastMode)
		{
			return DeleteSelection(raiseEvent, detect, fastMode, null);
		}

		/// <summary>
		///       已删除文档树结构的方式来删除选中的元素
		///       </summary>
		/// <param name="raiseEvent">是否触发文档ContentChanging , ContentChanged事件</param>
		/// <param name="detect">检测是否可以执行删除元素操作,但不真的进行删除</param>
		/// <param name="fastMode">快速模式，不更新用户界面，不更新内容元素列表</param>
		/// <param name="specifySelection">指定的选择区域</param>
		/// <returns>删除的文档元素对象个数</returns>
		public int DeleteSelection(bool raiseEvent, bool detect, bool fastMode, XTextSelection specifySelection)
		{
			if (UIIsUpdating)
			{
				return -1;
			}
			if (base.Count == 0)
			{
				return -1;
			}
			if (specifySelection == null)
			{
				specifySelection = Selection;
			}
			if (specifySelection.Length == 0)
			{
				return -1;
			}
			XTextContainerElement xTextContainerElement = null;
			XTextElementList xTextElementList = WriterUtils.smethod_58(specifySelection.ContentElements.FirstElement);
			XTextElementList xTextElementList2 = WriterUtils.smethod_58(specifySelection.ContentElements.LastElement);
			for (int i = 0; i < xTextElementList.Count; i++)
			{
				if (!xTextElementList2.Contains(xTextElementList[i]))
				{
					continue;
				}
				xTextContainerElement = (XTextContainerElement)xTextElementList[i];
				if (xTextContainerElement is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextContainerElement;
					if (specifySelection.ContentElements.FirstElement == xTextFieldElementBase.StartElement && specifySelection.ContentElements.LastElement == xTextFieldElementBase.EndElement)
					{
						xTextContainerElement = xTextContainerElement.Parent;
					}
				}
				break;
			}
			if (!(xTextContainerElement is XTextContentElement) && xTextContainerElement.Parent != null && method_37(xTextContainerElement, specifySelection) == Enum1.const_0)
			{
				xTextContainerElement = xTextContainerElement.Parent;
			}
			Dictionary<XTextContentElement, int> dictionary = new Dictionary<XTextContentElement, int>();
			int int_ = method_8(specifySelection.ContentElements[0]);
			XTextElement xTextElement = SafeGet(specifySelection.AbsEndIndex);
			if (xTextElement == null)
			{
				xTextElement = base.LastElement;
			}
			List<ContentChangedEventArgs> list = new List<ContentChangedEventArgs>();
			int num = method_34(xTextContainerElement, dictionary, detect, specifySelection, list);
			if (detect)
			{
				return num;
			}
			if (num > 0 && !fastMode)
			{
				LineEndFlag = false;
				xtextDocument_0.Modified = true;
				bool flag = false;
				foreach (XTextContentElement key in dictionary.Keys)
				{
					int int_2 = dictionary[key];
					key.vmethod_36(bool_22: false);
					key.vmethod_38(int_2, -1, bool_22: true);
					if (key.bool_19)
					{
						flag = true;
					}
				}
				DocumentContentElement.vmethod_36(bool_22: false);
				DocumentContentElement.method_61();
				if (OwnerDocument.CommentManager.imethod_6(bool_0: true))
				{
					flag = true;
				}
				if (list.Count > 0)
				{
					for (int i = list.Count - 1; i >= 0; i--)
					{
						ContentChangedEventArgs contentChangedEventArgs = list[i];
						(contentChangedEventArgs.Element as XTextContainerElement)?.method_23(contentChangedEventArgs);
					}
				}
				if (flag)
				{
					OwnerDocument.RefreshPages();
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.UpdatePages();
						OwnerDocument.EditorControl.UpdateTextCaret();
						OwnerDocument.EditorControl.InnerViewControl.Invalidate();
					}
				}
				else if (OwnerDocument != null && OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.UpdateTextCaret();
					OwnerDocument.EditorControl.Update();
				}
				if (specifySelection == Selection)
				{
					if (xTextElement != null && Contains(xTextElement))
					{
						method_47(method_8(xTextElement), 0);
					}
					else
					{
						method_47(int_, 0);
					}
				}
				if (OwnerDocument.EditorControl != null && OwnerDocument.EditorControl.ControlHostManger != null)
				{
					OwnerDocument.EditorControl.ControlHostManger.RemoveDeletedHostControl();
				}
			}
			return num;
		}

		public int method_38(bool bool_4)
		{
			if (UIIsUpdating)
			{
				return -1;
			}
			if (base.Count == 0)
			{
				return -1;
			}
			if (SelectionLength == 0)
			{
				return -1;
			}
			DocumentControler documentControler = OwnerDocument.DocumentControler;
			XTextElement xTextElement = null;
			XTextElement element = null;
			XTextContainerElement xTextContainerElement = null;
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextElement contentElement2 in Selection.ContentElements)
			{
				if (documentControler.method_18(contentElement2))
				{
					if (xTextElement == null || contentElement2.Parent != xTextContainerElement)
					{
						xTextElement = contentElement2;
						xTextContainerElement = contentElement2.Parent;
					}
					element = contentElement2;
				}
				else if (xTextElement != null)
				{
					if (xTextElement != null)
					{
						xTextElementList.Add(xTextElement);
						xTextElementList.Add(element);
					}
					xTextElement = null;
					element = null;
				}
			}
			if (xTextElement != null)
			{
				xTextElementList.Add(xTextElement);
				xTextElementList.Add(element);
			}
			if (xTextElementList.Count == 0)
			{
				return -1;
			}
			int int_ = method_8(xTextElementList[0]);
			bool flag = false;
			Dictionary<XTextContentElement, int> dictionary = new Dictionary<XTextContentElement, int>();
			for (int i = 0; i < xTextElementList.Count; i += 2)
			{
				xTextElement = xTextElementList[i];
				element = xTextElementList[i + 1];
				XTextContentElement contentElement = xTextElement.ContentElement;
				int num = contentElement.PrivateContent.IndexOf(xTextElement);
				if (dictionary.ContainsKey(contentElement))
				{
					if (dictionary[contentElement] > num)
					{
						dictionary[contentElement] = num;
					}
				}
				else
				{
					dictionary[contentElement] = num;
				}
				xTextContainerElement = xTextElement.Parent;
				try
				{
					int num2 = xTextContainerElement.Elements.IndexOf(xTextElement);
					int num3 = xTextContainerElement.Elements.IndexOf(element);
					XTextParagraphFlagElement xTextParagraphFlagElement = method_41(xTextElement);
					XTextParagraphFlagElement xTextParagraphFlagElement2 = null;
					XTextElementList range = xTextContainerElement.Elements.GetRange(num2, num3 - num2 + 1);
					if (xTextContainerElement.Elements.LastElement != element)
					{
						xTextParagraphFlagElement2 = method_41(xTextContainerElement.Elements.GetNextElement(element));
					}
					if (OwnerDocument.CanLogUndo)
					{
						OwnerDocument.UndoList.AddRemoveElements(xTextContainerElement, xTextContainerElement.Elements.IndexOf(xTextElement), range);
					}
					XTextElementList range2 = xTextContainerElement.Elements.GetRange(num2, num3 - num2 + 1);
					if (!bool_4)
					{
						goto IL_029e;
					}
					ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
					contentChangingEventArgs.Document = OwnerDocument;
					contentChangingEventArgs.Element = xTextContainerElement;
					contentChangingEventArgs.ElementIndex = num2;
					contentChangingEventArgs.DeletingElements = range2;
					xTextContainerElement.method_22(contentChangingEventArgs);
					if (!contentChangingEventArgs.Cancel)
					{
						goto IL_029e;
					}
					goto end_IL_01a0;
					IL_029e:
					xTextContainerElement.Elements.RemoveRange(num2, num3 - num2 + 1);
					xTextContainerElement.UpdateContentVersion();
					foreach (XTextElement item in range)
					{
						if (item.OwnerLine != null)
						{
							item.OwnerLine.InvalidateState = true;
						}
					}
					if (bool_4)
					{
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = OwnerDocument;
						contentChangedEventArgs.Element = xTextContainerElement;
						contentChangedEventArgs.ElementIndex = num2;
						contentChangedEventArgs.DeletedElements = range2;
						xTextContainerElement.method_23(contentChangedEventArgs);
					}
					flag = true;
					if (xTextParagraphFlagElement != xTextParagraphFlagElement2 && xTextParagraphFlagElement2 != null)
					{
						method_33(xTextParagraphFlagElement, xTextParagraphFlagElement2);
					}
					end_IL_01a0:;
				}
				finally
				{
				}
			}
			if (flag)
			{
				LineEndFlag = false;
				xtextDocument_0.Modified = true;
				foreach (XTextContentElement key in dictionary.Keys)
				{
					int num = dictionary[key];
					key.vmethod_36(bool_22: false);
					key.method_31(num);
				}
				DocumentContentElement.vmethod_36(bool_22: false);
				method_47(int_, 0);
				return Selection.StartIndex;
			}
			return -1;
		}

		public XTextLine method_39(bool bool_4)
		{
			XTextLine currentLine = CurrentLine;
			XTextLine ownerLine;
			if (currentLine[0].OwnerCell != null)
			{
				XTextTableCellElement ownerCell = currentLine[0].OwnerCell;
				if (ownerCell.PrivateLines[0] == currentLine)
				{
					XTextTableElement ownerTable = ownerCell.OwnerTable;
					if (ownerCell.RowIndex == 0)
					{
						XTextTableCellElement cell = ownerTable.GetCell(0, 0, throwException: true);
						int num = DocumentContentElement.Content.IndexOf(cell.PrivateContent[0]) - 1;
						if (num >= 0)
						{
							ownerLine = DocumentContentElement.Content[num].OwnerLine;
							if (ownerLine.Contains(ownerTable))
							{
								int num2 = DocumentContentElement.Content.IndexOf(ownerLine[0]);
								if (num2 > 0)
								{
									ownerLine = DocumentContentElement.Content[num2 - 1].OwnerLine;
								}
							}
							return ownerLine;
						}
						return null;
					}
					XTextTableCellElement xTextTableCellElement = ownerTable.GetCell(ownerCell.RowIndex - 1, ownerCell.ColIndex, throwException: true);
					if (xTextTableCellElement.IsOverrided)
					{
						xTextTableCellElement = xTextTableCellElement.OverrideCell;
					}
					return xTextTableCellElement.PrivateLines.LastLine;
				}
			}
			int num3;
			if (DocumentContentElement.Lines.IndexOf(currentLine) > 0)
			{
				num3 = SelectionStartIndex - 1;
				while (true)
				{
					if (num3 >= 0)
					{
						ownerLine = base[num3].OwnerLine;
						if (ownerLine != currentLine && !ownerLine.IsTableLine && !ownerLine.IsExpendedSectionLine)
						{
							break;
						}
						num3--;
						continue;
					}
					return null;
				}
				return ownerLine;
			}
			num3 = SelectionStartIndex - 1;
			while (true)
			{
				if (num3 >= 0)
				{
					ownerLine = base[num3].OwnerLine;
					if (ownerLine != currentLine && !ownerLine.IsTableLine && !ownerLine.IsExpendedSectionLine)
					{
						break;
					}
					num3--;
					continue;
				}
				return currentLine;
			}
			return ownerLine;
		}

		public XTextLine method_40()
		{
			if (UIIsUpdating)
			{
				return null;
			}
			XTextLine currentLine = CurrentLine;
			if (currentLine[0].OwnerCell != null)
			{
				XTextTableCellElement ownerCell = currentLine[0].OwnerCell;
				if (ownerCell.PrivateLines.LastLine == currentLine)
				{
					XTextTableElement ownerTable = ownerCell.OwnerTable;
					XTextTableCellElement xTextTableCellElement = ownerTable.GetCell(ownerCell.RowIndex + ownerCell.RowSpan, ownerCell.ColIndex, throwException: false);
					if (xTextTableCellElement == null)
					{
						XTextTableCellElement xTextTableCellElement2 = ownerTable.GetCell(ownerTable.RuntimeRows.Count - 1, ownerTable.Columns.Count - 1, throwException: true);
						if (xTextTableCellElement2.IsOverrided)
						{
							xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
							if (xTextTableCellElement2.RowSpan > 1)
							{
								XTextElementList cells = ownerTable.Cells;
								int num = cells.Count - 1;
								while (num >= 0)
								{
									XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)cells[num];
									if (xTextTableCellElement3.IsOverrided)
									{
										num--;
										continue;
									}
									xTextTableCellElement2 = xTextTableCellElement3;
									break;
								}
							}
						}
						int index = DocumentContentElement.Content.IndexOf(xTextTableCellElement2.PrivateContent.LastElement) + 1;
						XTextLine ownerLine = DocumentContentElement.Content[index].OwnerLine;
						if (ownerLine.Contains(xTextTableCellElement2.OwnerTable))
						{
							int num2 = DocumentContentElement.Content.IndexOf(ownerLine.LastElement);
							if (num2 > 0 && num2 < DocumentContentElement.Content.Count - 1)
							{
								ownerLine = DocumentContentElement.Content[num2 + 1].OwnerLine;
							}
						}
						return ownerLine;
					}
					if (xTextTableCellElement.OverrideCell != null)
					{
						xTextTableCellElement = xTextTableCellElement.OverrideCell;
					}
					XTextLine xTextLine = xTextTableCellElement.PrivateLines[0];
					while (xTextLine.IsTableLine)
					{
						XTextTableElement tableElement = xTextLine.TableElement;
						XTextTableCellElement cell = tableElement.GetCell(0, 0, throwException: false);
						if (cell != null)
						{
							xTextLine = cell.PrivateLines[0];
						}
					}
					return xTextLine;
				}
			}
			if (DocumentContentElement.Lines.IndexOf(currentLine) < DocumentContentElement.Lines.Count - 1)
			{
				int num = SelectionStartIndex + 1;
				XTextLine ownerLine;
				while (true)
				{
					if (num < base.Count)
					{
						ownerLine = base[num].OwnerLine;
						if (ownerLine != currentLine && !ownerLine.IsTableLine && !ownerLine.IsExpendedSectionLine)
						{
							break;
						}
						num++;
						continue;
					}
					return null;
				}
				return ownerLine;
			}
			return currentLine;
		}

		public XTextParagraphFlagElement method_41(XTextElement xtextElement_0)
		{
			if (UIIsUpdating)
			{
				return null;
			}
			if (xtextElement_0 == null)
			{
				return null;
			}
			if (xtextElement_0 is XTextParagraphFlagElement)
			{
				return (XTextParagraphFlagElement)xtextElement_0;
			}
			int num = method_8(xtextElement_0);
			if (num >= 0)
			{
				for (int i = num; i < base.Count; i++)
				{
					if (base[i] is XTextParagraphFlagElement)
					{
						return (XTextParagraphFlagElement)base[i];
					}
				}
			}
			return null;
		}

		/// <summary>
		///       选择所有的元素
		///       </summary>
		public void SelectAll()
		{
			if (UIIsUpdating || base.Count < 1)
			{
				return;
			}
			if (OwnerDocument.DocumentControler.FormView == FormViewMode.Strict)
			{
				int index = FixIndexForStrictFormViewMode(SelectionStartIndex, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true);
				XTextElement xTextElement = base[index];
				XTextInputFieldElementBase xTextInputFieldElementBase = null;
				while (xTextElement != null)
				{
					if (xTextElement is XTextInputFieldElementBase)
					{
						xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement;
					}
					xTextElement = xTextElement.Parent;
				}
				if (xTextInputFieldElementBase != null)
				{
					int num = method_8(xTextInputFieldElementBase.StartElement);
					int num2 = method_8(xTextInputFieldElementBase.EndElement);
					method_47(num + 1, num2 - num);
				}
			}
			else
			{
				method_47(base.Count - 1, 1 - base.Count);
			}
		}

		/// <summary>
		///       移动位置
		///       </summary>
		/// <param name="target">
		/// </param>
		public void MoveToTarget(MoveTarget target)
		{
			if (UIIsUpdating)
			{
				return;
			}
			switch (target)
			{
			case MoveTarget.None:
				break;
			case MoveTarget.DocumentHome:
				MoveToPosition(FixIndexForStrictFormViewMode(0, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			case MoveTarget.DocumentEnd:
			{
				int num = base.Count - 1;
				num = FixElementIndex(num);
				MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			}
			case MoveTarget.CellHome:
			{
				XTextTableCellElement ownerCell = CurrentElement.OwnerCell;
				if (ownerCell != null)
				{
					int num = method_8(ownerCell.FirstContentElement);
					MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.CellEnd:
			{
				XTextTableCellElement ownerCell = CurrentElement.OwnerCell;
				if (ownerCell != null)
				{
					int num = method_8(ownerCell.LastContentElement);
					MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.PreCell:
			{
				XTextTableCellElement ownerCell = CurrentElement.OwnerCell;
				if (ownerCell != null)
				{
					XTextElementList visibleCells = ownerCell.OwnerTable.VisibleCells;
					((XTextTableCellElement)visibleCells.GetPreElement(ownerCell))?.Focus();
				}
				break;
			}
			case MoveTarget.NextCell:
			{
				XTextTableCellElement ownerCell = CurrentElement.OwnerCell;
				if (ownerCell != null)
				{
					XTextElementList visibleCells = ownerCell.OwnerTable.VisibleCells;
					((XTextTableCellElement)visibleCells.GetNextElement(ownerCell))?.Focus();
				}
				break;
			}
			case MoveTarget.BeforeTable:
			{
				XTextTableElement xTextTableElement = (XTextTableElement)GetCurrentContainer(typeof(XTextTableElement));
				if (xTextTableElement == null || xTextTableElement.FirstCell == null)
				{
					break;
				}
				int num = method_8(xTextTableElement.FirstCell.FirstContentElement);
				if (num > 0)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num - 1, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.AfterTable:
			{
				XTextTableElement xTextTableElement = (XTextTableElement)GetCurrentContainer(typeof(XTextTableElement));
				if (xTextTableElement == null || xTextTableElement.LastVisibleCell == null)
				{
					break;
				}
				int num = method_8(xTextTableElement.LastVisibleCell.LastContentElement);
				if (num > 0)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num + 1, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.BeforeField:
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)GetCurrentContainer(typeof(XTextInputFieldElementBase));
				if (xTextFieldElementBase == null)
				{
					break;
				}
				int num = method_8(xTextFieldElementBase.StartElement);
				if (num < 0)
				{
					num = method_8(xTextFieldElementBase);
				}
				if (num >= 0)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.AfterField:
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)GetCurrentContainer(typeof(XTextInputFieldElementBase));
				if (xTextFieldElementBase == null)
				{
					break;
				}
				int num = method_8(xTextFieldElementBase.EndElement);
				if (num < 0)
				{
					num = method_8(xTextFieldElementBase);
				}
				if (num >= 0)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num + 1, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.ParagraphHome:
			{
				int num = 0;
				int i = SelectionStartIndex - 1;
				while (i >= 0)
				{
					if (!(base[i] is XTextParagraphFlagElement))
					{
						i--;
						continue;
					}
					num = i + 1;
					break;
				}
				MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			}
			case MoveTarget.ParagraphEnd:
			{
				int num = SelectionStartIndex;
				for (int i = SelectionStartIndex; i < base.Count; i++)
				{
					if (base[i] is XTextParagraphFlagElement)
					{
						num = i;
						break;
					}
				}
				MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true));
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			}
			case MoveTarget.PreLine:
				MoveUpOneLine();
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			case MoveTarget.NextLine:
				MoveDownOneLine();
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			case MoveTarget.FieldHome:
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)GetCurrentContainer(typeof(XTextInputFieldElementBase));
				if (xTextFieldElementBase == null)
				{
					break;
				}
				int num = method_8(xTextFieldElementBase.StartElement);
				if (num >= 0)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num + 1, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.FieldEnd:
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)GetCurrentContainer(typeof(XTextInputFieldElementBase));
				if (xTextFieldElementBase == null)
				{
					break;
				}
				int num = method_8(xTextFieldElementBase.EndElement);
				if (num >= 0)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.Home:
				MoveHome();
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			case MoveTarget.End:
				MoveEnd();
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
				break;
			case MoveTarget.PageHome:
			{
				int selectionStartIndex = SelectionStartIndex;
				int num2 = 0;
				PrintPage ownerPage = CurrentElement.OwnerLine.OwnerPage;
				int i = selectionStartIndex - 1;
				while (i >= 0)
				{
					XTextElement xTextElement = base[i];
					if (xTextElement.OwnerLine.OwnerPage == ownerPage)
					{
						i--;
						continue;
					}
					num2 = i + 1;
					break;
				}
				if (num2 != selectionStartIndex)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num2, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.PageEnd:
			{
				int selectionStartIndex = SelectionStartIndex;
				int num2 = base.Count - 1;
				PrintPage ownerPage = CurrentElement.OwnerLine.OwnerPage;
				for (int i = selectionStartIndex + 1; i < base.Count; i++)
				{
					XTextElement xTextElement = base[i];
					if (xTextElement.OwnerLine.OwnerPage != ownerPage)
					{
						num2 = i - 1;
						break;
					}
				}
				if (num2 != selectionStartIndex)
				{
					MoveToPosition(FixIndexForStrictFormViewMode(num2, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true));
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.ScrollToCaret();
					}
				}
				break;
			}
			case MoveTarget.ViewHome:
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.InnerViewControl.AutoScrollPosition = new Point(0, 0);
				}
				break;
			case MoveTarget.ViewEnd:
				if (OwnerDocument.EditorControl != null)
				{
					WriterViewControl innerViewControl = OwnerDocument.EditorControl.InnerViewControl;
					innerViewControl.AutoScrollPosition = new Point(0, innerViewControl.AutoScrollMinSize.Height);
				}
				break;
			}
		}

		/// <summary>
		///       获得当前光标所在的指定类型的容器元素对象
		///       </summary>
		/// <param name="containerType">元素类型</param>
		/// <returns>获得的元素对象</returns>
		public XTextElement GetCurrentContainer(Type containerType)
		{
			int num = 11;
			if (containerType == null)
			{
				throw new ArgumentNullException("containerType");
			}
			XTextContainerElement container = null;
			int elementIndex = -1;
			GetCurrentPositionInfo(out container, out elementIndex);
			while (true)
			{
				if (container != null)
				{
					if (containerType.IsInstanceOfType(container))
					{
						break;
					}
					container = container.Parent;
					continue;
				}
				return null;
			}
			return container;
		}

		/// <summary>
		///       将插入点向上移动一行
		///       </summary>
		public void MoveUpOneLine()
		{
			if (UIIsUpdating)
			{
				return;
			}
			method_42();
			XTextLine xTextLine = method_39(bool_4: true);
			if (xTextLine != null)
			{
				if (float_0 <= 0f)
				{
					XTextElement xTextElement = base[FixElementIndex(SelectionStartIndex)];
					float_0 = xTextElement.AbsLeft;
				}
				XTextElement xTextElement2 = null;
				if (xTextLine.RuntimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					foreach (XTextElement item in xTextLine)
					{
						if (item.AbsLeft <= float_0)
						{
							xTextElement2 = item;
							break;
						}
					}
				}
				else
				{
					foreach (XTextElement item2 in xTextLine)
					{
						if (item2.AbsLeft >= float_0)
						{
							xTextElement2 = item2;
							break;
						}
					}
				}
				if (xTextElement2 == null)
				{
					xTextElement2 = ((xTextLine.RuntimeLayoutDirection != ContentLayoutDirectionStyle.RightToLeft) ? xTextLine.LastElement : xTextLine.FirstElement);
				}
				if (xTextElement2 is XTextParagraphListItemElement)
				{
					xTextElement2 = xTextLine.GetNextElement(xTextElement2);
				}
				int num = method_8(xTextElement2.FirstContentElementInPublicContent);
				if (num >= 0)
				{
					num = FixIndexForStrictFormViewMode(num, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true);
					MoveToPosition(num);
				}
			}
		}

		/// <summary>
		///       将插入点向下移动一行
		///       </summary>
		public void MoveDownOneLine()
		{
			if (UIIsUpdating)
			{
				return;
			}
			method_42();
			XTextLine xTextLine = method_40();
			if (xTextLine != null)
			{
				if (float_0 <= 0f)
				{
					XTextElement xTextElement = base[FixElementIndex(SelectionStartIndex)];
					float_0 = xTextElement.AbsLeft;
				}
				XTextElement xTextElement2 = null;
				if (xTextLine.RuntimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					foreach (XTextElement item in xTextLine)
					{
						if (!(item is XTextParagraphListItemElement) && item.AbsLeft <= float_0)
						{
							xTextElement2 = item;
							break;
						}
					}
				}
				else
				{
					foreach (XTextElement item2 in xTextLine)
					{
						if (!(item2 is XTextParagraphListItemElement) && item2.AbsLeft >= float_0)
						{
							xTextElement2 = item2;
							break;
						}
					}
				}
				if (xTextElement2 == null)
				{
					xTextElement2 = ((xTextLine.RuntimeLayoutDirection != ContentLayoutDirectionStyle.RightToLeft) ? xTextLine.LastElement : xTextLine.FirstElement);
				}
				int num = method_8(xTextElement2.FirstContentElementInPublicContent);
				if (xTextElement2 is XTextParagraphFlagElement)
				{
					num = method_8(xTextElement2);
				}
				if (num >= 0)
				{
					num = FixIndexForStrictFormViewMode(num, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
					MoveToPosition(num);
				}
			}
		}

		/// <summary>
		///       将插入点先左移动一个元素
		///       </summary>
		public void MoveLeft()
		{
			if (UIIsUpdating)
			{
				return;
			}
			method_42();
			float_0 = -1f;
			if (AutoClearSelection && SelectionLength != 0)
			{
				int num = SelectionStartIndex;
				if (SelectionLength < 0)
				{
					num = SelectionStartIndex + SelectionLength;
				}
				if (num < 0)
				{
					num = 0;
				}
				num = FixIndexForStrictFormViewMode(num, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true);
				MoveToPosition(num);
			}
			else if (SelectionStartIndex > 0)
			{
				int index = SelectionStartIndex - 1;
				index = FixIndexForStrictFormViewMode(index, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true);
				MoveToPosition(index);
			}
		}

		/// <summary>
		///       将插入点向右移动一个元素
		///       </summary>
		public void MoveRight()
		{
			if (UIIsUpdating)
			{
				return;
			}
			method_42();
			float_0 = -1f;
			if (AutoClearSelection && SelectionLength != 0)
			{
				int num = SelectionStartIndex;
				if (SelectionLength > 0)
				{
					num = SelectionStartIndex + SelectionLength;
				}
				if (num >= base.Count)
				{
					num = base.Count - 1;
				}
				num = FixIndexForStrictFormViewMode(num, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
				MoveToPosition(num);
			}
			else if (SelectionStartIndex < base.Count - 1)
			{
				int index = SelectionStartIndex + 1;
				index = FixIndexForStrictFormViewMode(index, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
				MoveToPosition(index);
			}
		}

		/// <summary>
		///       将插入点移动到当前行的最后一个元素处
		///       </summary>
		public void MoveEnd()
		{
			if (!UIIsUpdating)
			{
				try
				{
					XTextLine currentLine = CurrentLine;
					if (currentLine != null && !bool_1)
					{
						float_0 = -1f;
						CurrentElement = currentLine.LastElement;
						if (OwnerDocument.DocumentControler.vmethod_9(currentLine.LastElement))
						{
							int num = method_8(currentLine.LastElement);
							if (num >= 0)
							{
								num = FixIndexForStrictFormViewMode(num, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true);
								MoveToPosition(num);
							}
						}
						else
						{
							int num = method_8(currentLine.LastElement) + 1;
							int num2 = FixIndexForStrictFormViewMode(num, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true);
							if (num != num2)
							{
								MoveToPosition(num2);
							}
							else
							{
								MoveToPosition(num);
								bool_1 = true;
							}
						}
					}
				}
				catch
				{
				}
			}
		}

		/// <summary>
		///       移动插入点到当前行的行首
		///       </summary>
		public void MoveHome()
		{
			if (UIIsUpdating)
			{
				return;
			}
			method_42();
			XTextLine currentLine = CurrentLine;
			if (currentLine != null)
			{
				float_0 = -1f;
				int num = method_8(currentLine.FirstElement);
				int num2 = 0;
				foreach (XTextElement item in currentLine)
				{
					XTextCharElement xTextCharElement = item as XTextCharElement;
					if (xTextCharElement == null || !char.IsWhiteSpace(xTextCharElement.CharValue))
					{
						num2 = currentLine.IndexOf(item);
						break;
					}
				}
				if (num2 == 0 || Selection.StartIndex == num + num2)
				{
					num = FixIndexForStrictFormViewMode(num, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
					MoveToPosition(num);
				}
				else
				{
					int index = num + num2;
					index = FixIndexForStrictFormViewMode(index, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
					MoveToPosition(index);
				}
			}
		}

		/// <summary>
		///       移动当前插入点的位置
		///       </summary>
		/// <param name="index">插入点的新的位置</param>
		/// <returns>操作是否成功</returns>
		public bool MoveToPosition(int index)
		{
			if (UIIsUpdating)
			{
				return false;
			}
			method_42();
			index = FixElementIndex(index);
			index = FixIndexForStrictFormViewMode(index, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true);
			int int_ = 0;
			if (!bool_2)
			{
				int_ = SelectionLength + (SelectionStartIndex - index);
			}
			SelectionStartElementAsCurrentElement = true;
			return method_47(index, int_);
		}

		/// <summary>
		///       将插入点移动到指定元素前面
		///       </summary>
		/// <param name="element">指定的元素</param>
		/// <returns>操作是否成功</returns>
		public bool MoveToElement(XTextElement element)
		{
			if (UIIsUpdating)
			{
				return false;
			}
			int num = method_8(element);
			if (num >= 0)
			{
				return MoveToPosition(num);
			}
			return false;
		}

		/// <summary>
		///       垂直方向移动插入点指定距离
		///       </summary>
		/// <param name="Step">移动距离</param>
		public void MoveStep(float Step)
		{
			if (!UIIsUpdating)
			{
				method_42();
				bool_1 = false;
				XTextElement currentElement = CurrentElement;
				if (currentElement != null)
				{
					MoveToPoint(currentElement.AbsLeft, currentElement.AbsTop + Step);
				}
			}
		}

		private void method_42()
		{
			if (bool_1)
			{
				bool_1 = false;
			}
		}

		public XTextLine method_43(float float_1, float float_2, bool bool_4)
		{
			if (UIIsUpdating)
			{
				return null;
			}
			if (xtextDocument_0 == null)
			{
				return null;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			XTextContentElement xTextContentElement = DocumentContentElement;
			XTextElementList xTextElementList = OwnerDocument.TypedElements.method_5(DocumentContentElement, typeof(XTextTableElement));
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				xTextElementList = xTextElementList.Clone();
				xTextElementList.Reverse();
				foreach (XTextTableElement item in xTextElementList)
				{
					XTextTableCellElement xTextTableCellElement = item.method_42(float_1, float_2);
					if (xTextTableCellElement != null)
					{
						xTextContentElement = xTextTableCellElement;
						break;
					}
				}
				xTextElementList.Clear();
				xTextElementList = null;
			}
			if (xTextContentElement == DocumentContentElement)
			{
				XTextElementList xTextElementList2 = OwnerDocument.TypedElements.method_5(DocumentContentElement, typeof(XTextContentElement));
				int num = xTextElementList2.Count - 1;
				while (num >= 0)
				{
					XTextContentElement xTextContentElement2 = (XTextContentElement)xTextElementList2[num];
					if (xTextContentElement2 is XTextTableCellElement || xTextContentElement2.IsInCollapsedSection || (xTextContentElement2 is XTextSectionElement && ((XTextSectionElement)xTextContentElement2).RuntimeIsCollapsed) || !xTextContentElement2.AbsBounds.Contains(float_1, float_2))
					{
						num--;
						continue;
					}
					xTextContentElement = xTextContentElement2;
					break;
				}
			}
			XTextLine xTextLine = xTextContentElement.method_27(float_1, float_2, bool_4);
			if (xTextLine != null && (xTextLine.IsExpendedSectionLine || xTextLine.IsTableLine) && xTextLine.LastElement is XTextParagraphFlagElement && ((float_1 < xTextLine.AbsLeft && xTextLine.RuntimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft) || (float_1 > xTextLine.AbsLeft + xTextLine.Width && xTextLine.RuntimeLayoutDirection == ContentLayoutDirectionStyle.LeftToRight)))
			{
				return xTextLine;
			}
			if (xTextLine != null && xTextLine.IsExpendedSectionLine)
			{
				XTextSectionElement sectionElement = xTextLine.SectionElement;
				xTextLine = sectionElement.method_27(float_1, float_2, bool_4);
				if (xTextLine == null)
				{
					xTextLine = sectionElement.PrivateLines.LastLine;
				}
			}
			if (xTextLine != null && xTextLine.IsTableLine)
			{
				XTextTableElement xTextTableElement = xTextLine.TableElement;
				RectangleF absBounds = xTextTableElement.AbsBounds;
				XTextTableRowElement xTextTableRowElement = null;
				foreach (XTextTableRowElement runtimeRow in xTextTableElement.RuntimeRows)
				{
					if (absBounds.Top + runtimeRow.Top + runtimeRow.Height >= float_2)
					{
						xTextTableRowElement = runtimeRow;
						break;
					}
				}
				if (xTextTableRowElement == null)
				{
					xTextTableRowElement = (XTextTableRowElement)xTextTableElement.RuntimeRows.LastElement;
				}
				if (xTextTableRowElement == null)
				{
					return null;
				}
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.Cells.LastElement;
				if (float_1 <= absBounds.Left)
				{
					xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.Cells[0];
				}
				else if (float_1 >= absBounds.Right)
				{
					xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.Cells.LastElement;
				}
				if (xTextTableCellElement2.IsOverrided)
				{
					xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
				}
				xTextLine = xTextTableCellElement2.method_27(float_1, float_2, bool_4);
				if (xTextLine == null)
				{
					xTextLine = xTextTableCellElement2.PrivateLines.LastLine;
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			return xTextLine;
		}

		public XTextElement GetElementAt(float x, float y, bool bool_4)
		{
			if (xtextDocument_0 == null)
			{
				return null;
			}
			XTextDocumentContentElement documentContentElement = DocumentContentElement;
			if (documentContentElement.HasSpecifyLayoutElements)
			{
				XTextElement xTextElement = documentContentElement.method_56(x, y, ElementZOrderStyle.InFrontOfText);
				if (xTextElement != null)
				{
					return xTextElement;
				}
			}
			XTextLine xTextLine = method_43(x, y, bool_4);
			if (xTextLine == null)
			{
				return documentContentElement.method_56(x, y, ElementZOrderStyle.UnderText);
			}
			ContentLayoutDirectionStyle runtimeLayoutDirection = xTextLine.RuntimeLayoutDirection;
			if (runtimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
			{
				x -= xTextLine.AbsLeft;
				if (bool_4)
				{
					if (x >= 0f && x <= xTextLine.Width)
					{
						foreach (XTextElement item in xTextLine)
						{
							if (!(item is XTextParagraphListItemElement) && x >= item.Left && x <= item.Left + item.LayoutWidth + item.WidthFix)
							{
								return item;
							}
						}
					}
					return documentContentElement.method_56(x, y, ElementZOrderStyle.UnderText);
				}
				if (x < 0f)
				{
					return xTextLine.FirstElement;
				}
				foreach (XTextElement item2 in xTextLine)
				{
					if (!(item2 is XTextParagraphListItemElement) && x < item2.Left + item2.LayoutWidth)
					{
						return item2;
					}
				}
				return xTextLine.LastElement;
			}
			x -= xTextLine.AbsLeft;
			if (bool_4)
			{
				if (x >= 0f && x <= xTextLine.Width)
				{
					foreach (XTextElement item3 in xTextLine)
					{
						if (!(item3 is XTextParagraphListItemElement) && x >= item3.Left && x <= item3.Left + item3.LayoutWidth + item3.WidthFix)
						{
							return item3;
						}
					}
				}
				return documentContentElement.method_56(x, y, ElementZOrderStyle.UnderText);
			}
			if (x < 0f)
			{
				return xTextLine.FirstElement;
			}
			foreach (XTextElement item4 in xTextLine)
			{
				if (!(item4 is XTextParagraphListItemElement) && x < item4.Left + item4.LayoutWidth)
				{
					return item4;
				}
			}
			return xTextLine.LastElement;
		}

		/// <summary>
		///       将插入点尽量移动到指定位置
		///       </summary>
		/// <param name="x">指定位置的X坐标</param>
		/// <param name="y">指定位置的Y坐标</param>
		public void MoveToPoint(float x, float y)
		{
			if (UIIsUpdating || OwnerDocument == null)
			{
				return;
			}
			float_0 = -1f;
			XTextLine xTextLine = method_43(x, y, bool_4: false);
			if (xTextLine == null)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			x -= xTextLine.AbsLeft;
			XTextElement xTextElement = null;
			ContentLayoutDirectionStyle runtimeLayoutDirection = xTextLine.RuntimeLayoutDirection;
			if (runtimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
			{
				foreach (XTextElement item in xTextLine)
				{
					if (!(item is XTextParagraphListItemElement) && !(x < item.Left))
					{
						float num2 = item.Left + item.LayoutWidth / 2f;
						if (item is XTextFieldBorderElement)
						{
							XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)item;
							if (xTextFieldBorderElement.Position == BorderElementPosition.End)
							{
								float val = item.Left + (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
								num2 = Math.Min(num2, val);
							}
						}
						if (!item.IsRightToLeft)
						{
							xTextElement = ((!(x > num2)) ? item : xTextLine.GetPreElement(item));
							break;
						}
						if (!(x < num2))
						{
							xTextElement = item;
							break;
						}
					}
				}
			}
			else
			{
				foreach (XTextElement item2 in xTextLine)
				{
					if (!(item2 is XTextParagraphListItemElement) && x < item2.Left + item2.LayoutWidth)
					{
						float num3 = item2.Left + item2.LayoutWidth / 2f;
						if (item2 is XTextFieldBorderElement)
						{
							XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)item2;
							if (xTextFieldBorderElement.Position == BorderElementPosition.End)
							{
								float val = item2.Left + item2.LayoutWidth - (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
								num3 = Math.Max(num3, val);
							}
						}
						if (!(x > num3))
						{
							xTextElement = item2;
							break;
						}
					}
				}
			}
			float num4 = 0f;
			if (xTextElement == null)
			{
				num4 = ((runtimeLayoutDirection != ContentLayoutDirectionStyle.RightToLeft) ? (x - xTextLine.LastElement.Left - xTextLine.LastElement.LayoutWidth) : (xTextLine.LastElement.Left - x));
				if (AutoClearSelection && xTextLine.HasLineEndElement)
				{
					num = method_8(xTextLine.LastElement);
				}
				else if (xTextLine.LastElement is XTextParagraphFlagElement)
				{
					XTextElement xTextElement2 = SafeGet(Selection.AbsStartIndex);
					if (xTextElement2 != null && xTextElement2.OwnerLine == xTextLine && num4 > xTextLine.LastElement.LayoutWidth * 2f)
					{
						num = method_8(xTextLine.LastElement);
						flag = false;
					}
					else if (AutoClearSelection)
					{
						num = method_8(xTextLine.LastElement);
						flag = false;
					}
					else
					{
						XTextContentElement ownerContentElement = xTextLine.OwnerContentElement;
						if (base.Count == 1)
						{
							num = method_8(xTextLine.LastElement);
							flag = false;
						}
						else if (ownerContentElement.PrivateContent.Count == 1 || ownerContentElement is XTextTableCellElement)
						{
							num = method_8(xTextLine.LastElement);
							flag = false;
						}
						else
						{
							num = method_8(xTextLine.LastElement) + 1;
							flag = true;
						}
					}
				}
				else if (runtimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					num = method_8(xTextLine.LastElement) + 1;
					if ((xTextLine.LastElement is XTextParagraphFlagElement || xTextLine.LastElement is XTextLineBreakElement) && AutoClearSelection)
					{
						num = method_8(xTextLine.LastElement);
						flag = false;
					}
					else if (num >= base.Count - 1)
					{
						flag = false;
						num = method_8(xTextLine.LastElement);
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					num = method_8(xTextLine.LastElement) + 1;
					if ((xTextLine.LastElement is XTextParagraphFlagElement || xTextLine.LastElement is XTextLineBreakElement) && AutoClearSelection)
					{
						num = method_8(xTextLine.LastElement);
						flag = false;
					}
					else if (num >= base.Count - 1)
					{
						flag = false;
						num = method_8(xTextLine.LastElement);
					}
					else
					{
						flag = true;
					}
				}
			}
			else
			{
				num = method_8(xTextElement);
				flag = false;
			}
			if (num < 0)
			{
				return;
			}
			if (num > base.Count)
			{
				num = base.Count - 1;
				flag = false;
			}
			if (num < 0)
			{
				num = 0;
				flag = false;
			}
			num = FixElementIndex(num);
			int num5 = 0;
			if (!AutoClearSelection)
			{
				XTextContentElement contentElement = base[Selection.NativeStartIndex].ContentElement;
				XTextContentElement ownerContentElement2 = xTextLine.OwnerContentElement;
				SelectionStartElementAsCurrentElement = false;
				num5 = num - Selection.NativeStartIndex;
				num = Selection.NativeStartIndex;
				if (contentElement != ownerContentElement2 && (contentElement is XTextTableCellElement || ownerContentElement2 is XTextTableCellElement) && num5 > 0)
				{
					num5++;
				}
			}
			bool flag2 = false;
			int num6 = FixIndexForStrictFormViewMode(num, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true);
			if (num6 != num)
			{
				if (OwnerDocument.Options.BehaviorOptions.LockScrollPositionWhenStrictFormViewMode)
				{
					flag2 = true;
				}
				num = num6;
				num5 = 0;
			}
			if (num5 != 0 && OwnerDocument.DocumentControler.FormView == FormViewMode.Strict)
			{
				XTextContainerElement xtextContainerElement_ = null;
				int int_ = 0;
				method_20(num, out xtextContainerElement_, out int_, bool_4: false);
				for (XTextElement xTextElement3 = xtextContainerElement_; xTextElement3 != null; xTextElement3 = xTextElement3.Parent)
				{
					if (xTextElement3 is XTextInputFieldElementBase)
					{
						xtextContainerElement_ = (XTextInputFieldElementBase)xTextElement3;
					}
				}
				XTextContainerElement xtextContainerElement_2 = null;
				int int_2 = 0;
				method_20(num + num5, out xtextContainerElement_2, out int_2, bool_4: false);
				for (XTextElement xTextElement3 = xtextContainerElement_2; xTextElement3 != null; xTextElement3 = xTextElement3.Parent)
				{
					if (xTextElement3 is XTextInputFieldElementBase)
					{
						xtextContainerElement_2 = (XTextInputFieldElementBase)xTextElement3;
					}
				}
				XTextElement xTextElement4 = WriterUtils.smethod_63(xtextContainerElement_, xtextContainerElement_2);
				if (xTextElement4.GetOwnerParent(typeof(XTextInputFieldElementBase), includeThis: true) == null)
				{
					if (num5 > 0)
					{
						num5 = xtextContainerElement_.LastContentElement.ViewIndex - num;
					}
					else if (num5 < 0)
					{
						num5 = xtextContainerElement_.FirstContentElement.ViewIndex - num + 1;
					}
					if (num == 0)
					{
						num5 = 0;
					}
				}
			}
			if (flag && num5 == 0 && num > 1 && base[num - 1] is XTextParagraphFlagElement)
			{
				flag = false;
			}
			LineEndFlag = flag;
			if (num5 == 0)
			{
			}
			if (flag2)
			{
				OwnerDocument.EditorControl.InnerViewControl.LockScrollPositionOnce = true;
			}
			method_47(num, num5);
			if (xtextDocument_0.EditorControl != null)
			{
			}
		}

		private XTextInputFieldElementBase method_45(int int_2, bool bool_4)
		{
			XTextContainerElement xtextContainerElement_ = null;
			int int_3 = 0;
			method_20(int_2, out xtextContainerElement_, out int_3, bool_4);
			return WriterUtils.smethod_46(xtextContainerElement_);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool method_46()
		{
			if (OwnerDocument != null && OwnerDocument.DocumentControler != null && OwnerDocument.DocumentControler.FormView == FormViewMode.Strict)
			{
				int num = FixIndexForStrictFormViewMode(SelectionStartIndex, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true);
				if (num != SelectionStartIndex)
				{
					method_47(num, 0);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       根据表单视图状态修正插入点位置
		///       </summary>
		/// <param name="index">要修正的插入点位置编号</param>
		/// <param name="direction">修正方向</param>
		/// <param name="enableSetAutoClearSelectionFlag">是否允许设置AutoClearSelectionFlag标记</param>
		/// <returns>修正后的插入点位置</returns>
		public int FixIndexForStrictFormViewMode(int index, FixIndexDirection direction, bool enableSetAutoClearSelectionFlag)
		{
			if (OwnerDocument == null || OwnerDocument.EditorControl == null)
			{
				return index;
			}
			if (OwnerDocument.EditorControl.FormView == FormViewMode.Strict)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = method_45(index, LineEndFlag);
				if (xTextInputFieldElementBase == null)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase2 = null;
					for (int num = index; num >= 0; num--)
					{
						xTextInputFieldElementBase2 = method_45(num, bool_4: false);
						if (xTextInputFieldElementBase2 != null)
						{
							break;
						}
					}
					XTextInputFieldElementBase xTextInputFieldElementBase3 = null;
					if (direction != 0 || xTextInputFieldElementBase2 == null)
					{
						for (int num = index; num < base.Count; num++)
						{
							xTextInputFieldElementBase3 = method_45(num, bool_4: false);
							if (xTextInputFieldElementBase3 != null)
							{
								break;
							}
						}
					}
					if (xTextInputFieldElementBase2 == null && xTextInputFieldElementBase3 == null)
					{
						return 0;
					}
					XTextInputFieldElementBase xTextInputFieldElementBase4 = null;
					switch (direction)
					{
					case FixIndexDirection.Forward:
						xTextInputFieldElementBase4 = xTextInputFieldElementBase2;
						break;
					case FixIndexDirection.Back:
						xTextInputFieldElementBase4 = xTextInputFieldElementBase3;
						break;
					case FixIndexDirection.Both:
						if (xTextInputFieldElementBase2 != null && xTextInputFieldElementBase3 != null)
						{
							RectangleF absBounds = xTextInputFieldElementBase2.LastContentElement.AbsBounds;
							RectangleF absBounds2 = xTextInputFieldElementBase3.FirstContentElement.AbsBounds;
							RectangleF absBounds3 = base[index].AbsBounds;
							float distance = RectangleCommon.GetDistance(absBounds3.X, absBounds3.Y, absBounds);
							float distance2 = RectangleCommon.GetDistance(absBounds3.Right, absBounds3.Bottom, absBounds2);
							xTextInputFieldElementBase4 = ((!(distance > distance2)) ? xTextInputFieldElementBase2 : xTextInputFieldElementBase3);
						}
						break;
					}
					if (xTextInputFieldElementBase4 == null)
					{
						xTextInputFieldElementBase4 = ((xTextInputFieldElementBase2 == null) ? xTextInputFieldElementBase3 : xTextInputFieldElementBase2);
					}
					if (xTextInputFieldElementBase4 != null)
					{
						index = ((xTextInputFieldElementBase4 != xTextInputFieldElementBase2) ? (method_8(xTextInputFieldElementBase3.FirstContentElement) + 1) : method_8(xTextInputFieldElementBase2.LastContentElement));
					}
					if (enableSetAutoClearSelectionFlag)
					{
						AutoClearSelection = true;
					}
				}
			}
			return index;
		}

		public bool method_47(int index, int len)
		{
			if (UIIsUpdating)
			{
				return false;
			}
			method_18(ref index, ref len);
			return DocumentContentElement.SetSelection(index, len);
		}

		/// <summary>
		///       选择插入点所在的段落
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool SelectParagraph()
		{
			if (base.Count == 0)
			{
				return false;
			}
			bool flag = OwnerDocument.DocumentControler.FormView == FormViewMode.Strict;
			XTextElement currentElement = CurrentElement;
			if (currentElement != null)
			{
				int num = method_8(currentElement);
				int num2 = 0;
				int num3 = base.Count - 1;
				int num4 = num - 1;
				while (num4 >= 0)
				{
					if (!(base[num4] is XTextParagraphFlagElement))
					{
						if (!flag || !(base[num4] is XTextFieldBorderElement))
						{
							num4--;
							continue;
						}
						num2 = num4 + 1;
						break;
					}
					num2 = num4 + 1;
					break;
				}
				for (int i = num; i < base.Count; i++)
				{
					if (!(base[i] is XTextParagraphFlagElement))
					{
						if (flag && base[i] is XTextFieldBorderElement)
						{
							num3 = i;
							break;
						}
						continue;
					}
					num3 = i;
					break;
				}
				bool_1 = false;
				method_47(num2, num3 - num2 + 1);
				bool_2 = true;
				return true;
			}
			return false;
		}

		/// <summary>
		///       选择插入点处的连续的字母和数字
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool SelectWord()
		{
			if (UIIsUpdating)
			{
				return false;
			}
			if (base.Count == 0)
			{
				return false;
			}
			XTextContainerElement xTextContainerElement = null;
			int num = -1;
			for (int num2 = Math.Min(SelectionStartIndex, base.Count - 1); num2 >= 0; num2--)
			{
				if (xTextContainerElement == null)
				{
					xTextContainerElement = base[num2].Parent;
				}
				XTextCharElement xTextCharElement = base[num2] as XTextCharElement;
				if (xTextCharElement == null || xTextCharElement.Parent != xTextContainerElement || (!char.IsLetter(xTextCharElement.CharValue) && !char.IsDigit(xTextCharElement.CharValue)))
				{
					break;
				}
				num = num2;
			}
			if (num >= 0)
			{
				int num3 = -1;
				for (int num2 = SelectionStartIndex; num2 < base.Count; num2++)
				{
					if (xTextContainerElement == null)
					{
						xTextContainerElement = base[num2].Parent;
					}
					XTextCharElement xTextCharElement = base[num2] as XTextCharElement;
					if (xTextCharElement == null || xTextCharElement.Parent != xTextContainerElement || (!char.IsLetter(xTextCharElement.CharValue) && !char.IsDigit(xTextCharElement.CharValue)))
					{
						break;
					}
					num3 = num2;
				}
				if (num3 != -1)
				{
					bool_1 = false;
					method_47(num, num3 - num + 1);
					return true;
				}
			}
			return false;
		}

		public int method_48(int int_2, string string_4, bool bool_4, bool bool_5)
		{
			if (UIIsUpdating)
			{
				return -1;
			}
			if (string_4 == null || string_4.Length == 0)
			{
				return -1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (int_2 < 0)
			{
				int_2 = 0;
			}
			for (int i = int_2; i < base.Count; i++)
			{
				XTextCharElement xTextCharElement = base[i] as XTextCharElement;
				if (xTextCharElement == null)
				{
					stringBuilder.Append('\0');
				}
				else
				{
					stringBuilder.Append(xTextCharElement.CharValue);
				}
			}
			string text = stringBuilder.ToString();
			int num = 0;
			num = ((!bool_4) ? text.IndexOf(string_4) : text.IndexOf(string_4, StringComparison.CurrentCultureIgnoreCase));
			if (num >= 0)
			{
				num += int_2;
				if (bool_5)
				{
					method_47(num, string_4.Length);
				}
				return num;
			}
			return -1;
		}

		internal void method_49()
		{
			method_16();
			xtextDocumentContentElement_0 = null;
			xtextDocument_0 = null;
		}
	}
}
