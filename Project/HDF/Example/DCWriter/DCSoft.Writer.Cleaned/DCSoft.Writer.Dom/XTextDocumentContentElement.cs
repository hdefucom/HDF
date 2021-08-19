using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档级内容对象
	///       </summary>
	[Serializable]
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-23456789000B")]
	public class XTextDocumentContentElement : XTextContentElement
	{
		[NonSerialized]
		private XTextElementList xtextElementList_4 = null;

		[NonSerialized]
		private XTextParagraphFlagElement xtextParagraphFlagElement_0 = null;

		[NonSerialized]
		private List<List<XTextParagraphFlagElement>> list_2 = null;

		[NonSerialized]
		private bool bool_22 = true;

		[NonSerialized]
		private XTextContent xtextContent_0 = new XTextContent();

		[NonSerialized]
		private XTextElementList xtextElementList_5 = null;

		[NonSerialized]
		private XTextSelection xtextSelection_0 = null;

		[NonSerialized]
		private XTextLineList xtextLineList_1 = null;

		private float float_9 = 0f;

		/// <summary>
		///       特别布局的文档元素，指浮于文字之上或沉于文字之下的图片元素。
		///       </summary>
		internal XTextElementList SpecifyLayoutElements
		{
			get
			{
				if (xtextElementList_4 == null)
				{
					XTextContent content = Content;
					xtextElementList_4 = new XTextElementList();
					foreach (XTextElement item in content)
					{
						if (item is XTextObjectElement)
						{
							XTextObjectElement xTextObjectElement = (XTextObjectElement)item;
							if (xTextObjectElement.RuntimeZOrderStyle == ElementZOrderStyle.InFrontOfText || xTextObjectElement.RuntimeZOrderStyle == ElementZOrderStyle.UnderText)
							{
								xtextElementList_4.Add(xTextObjectElement);
							}
						}
					}
				}
				return xtextElementList_4;
			}
			set
			{
				xtextElementList_4 = value;
			}
		}

		internal bool HasSpecifyLayoutElements
		{
			get
			{
				XTextElementList specifyLayoutElements = SpecifyLayoutElements;
				return specifyLayoutElements != null && specifyLayoutElements.Count > 0;
			}
		}

		/// <summary>
		///       无条件接受Tab字符
		///       </summary>
		[DefaultValue(true)]
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		public override bool AcceptTab
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// <summary>
		///       返回空
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public override DCGridLineInfo GridLine
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       宽度
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (base.Width != value)
				{
					base.Width = value;
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。段落树状列表的根段落对象
		///       </summary>
		[ComVisible(false)]
		[DCInternal]
		[Browsable(false)]
		[XmlIgnore]
		public XTextParagraphFlagElement RootParagraphFlag => xtextParagraphFlagElement_0;

		/// <summary>
		///       游离的段落列表组
		///       </summary>
		internal List<List<XTextParagraphFlagElement>> FreeParagraphFlagGroups
		{
			get
			{
				return list_2;
			}
			set
			{
				list_2 = value;
			}
		}

		/// <summary>
		///       段落树状结构无效标记
		///       </summary>
		internal bool ParagraphTreeInvalidte
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		/// <summary>
		///       文档内容管理对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextContent Content
		{
			get
			{
				if (xtextContent_0 == null)
				{
					xtextContent_0 = new XTextContent();
				}
				if (xtextContent_0.Count == 0)
				{
					method_61();
					method_57(bool_23: true, bool_24: true);
				}
				return xtextContent_0;
			}
		}

		/// <summary>
		///       所有的可承载内容的容器元素列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public XTextElementList ContentElements
		{
			get
			{
				if (xtextElementList_5 == null)
				{
					xtextElementList_5 = new XTextElementList();
					xtextElementList_5.AddRaw(this);
					method_64(this, xtextElementList_5);
				}
				return xtextElementList_5;
			}
		}

		/// <summary>
		///       当前选择区域信息对象
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextSelection Selection
		{
			get
			{
				if (xtextSelection_0 == null)
				{
					xtextSelection_0 = new XTextSelection(this);
				}
				return xtextSelection_0;
			}
		}

		/// <summary>
		///       判断是否存在被用户选择的内容元素
		///       </summary>
		[Browsable(false)]
		public new bool HasSelection => Selection.Length != 0;

		/// <summary>
		///       判断是否存在没有被逻辑删除的被选择的元素内容
		///       </summary>
		public bool HasSelectionWithouLogicDeleted
		{
			get
			{
				if (Selection.Length != 0)
				{
					foreach (XTextElement contentElement in Selection.ContentElements)
					{
						if (contentElement.RuntimeStyle.DeleterIndex < 0)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       当前行
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextLine CurrentLine => Content.CurrentLine;

		/// <summary>
		///       当前元素
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DCPublishAPI]
		public XTextElement CurrentElement
		{
			get
			{
				if (OwnerDocument.WebClientCurrentElement != null)
				{
					if (OwnerDocument.WebClientCurrentElement.DocumentContentElement == this)
					{
						return OwnerDocument.WebClientCurrentElement;
					}
					return null;
				}
				if (xtextContent_0 == null || xtextContent_0.Count == 0)
				{
					return null;
				}
				return xtextContent_0.CurrentElement;
			}
		}

		/// <summary>
		///       当前段落对象
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextParagraphFlagElement CurrentParagraphEOF => Content.CurrentParagraphEOF;

		/// <summary>
		///       文本行列表
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		public XTextLineList Lines
		{
			get
			{
				if (xtextLineList_1 == null)
				{
					xtextLineList_1 = new XTextLineList();
					method_72(this, xtextLineList_1);
				}
				return xtextLineList_1;
			}
		}

		/// <summary>
		///       内容视图宽度
		///       </summary>
		public override float ViewWidth => float_9;

		[Browsable(false)]
		[Obsolete]
		private new XTextTableCellElement OwnerCell => null;

		[Obsolete]
		[Browsable(false)]
		private new XTextElement PreviousElement => null;

		[Browsable(false)]
		[Obsolete]
		private new DocumentContentStyle RuntimeStyle => null;

		[Browsable(false)]
		[Obsolete]
		private new DocumentContentStyle Style => null;

		/// <summary>
		///       废除
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[Obsolete]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int StyleIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		[Obsolete]
		[Browsable(false)]
		private new int ViewIndex => 0;

		[Browsable(false)]
		[Obsolete]
		private new int ColumnIndex => 0;

		[Browsable(false)]
		[Obsolete]
		private new int ElementIndex => 0;

		/// <summary>
		///       返回内容部分所属样式
		///       </summary>
		[Browsable(false)]
		public virtual PageContentPartyStyle PagePartyStyle => PageContentPartyStyle.Body;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		protected XTextDocumentContentElement()
		{
			xtextSelection_0 = new XTextSelection(this);
			xtextContent_0.DocumentContentElement = this;
		}

		public void method_55()
		{
			if (xtextElementList_4 != null)
			{
				xtextElementList_4.Clear();
				xtextElementList_4 = null;
			}
		}

		internal XTextElement method_56(float float_10, float float_11, ElementZOrderStyle elementZOrderStyle_0)
		{
			if (HasSpecifyLayoutElements)
			{
				foreach (XTextElement specifyLayoutElement in SpecifyLayoutElements)
				{
					if (specifyLayoutElement.RuntimeZOrderStyle == elementZOrderStyle_0 && specifyLayoutElement.AbsBounds.Contains(float_10, float_11))
					{
						return specifyLayoutElement;
					}
				}
			}
			return null;
		}

		internal void method_57(bool bool_23, bool bool_24)
		{
			if (!bool_23 || bool_22)
			{
				bool_22 = false;
				OwnerDocument.ResetOutlineNodes();
				list_2 = new List<List<XTextParagraphFlagElement>>();
				if (xtextParagraphFlagElement_0 == null)
				{
					xtextParagraphFlagElement_0 = new XTextParagraphFlagElement();
				}
				else
				{
					xtextParagraphFlagElement_0.ChildParagraphs.Clear();
				}
				xtextParagraphFlagElement_0.IsRootLevelElement = true;
				Stack<XTextParagraphFlagElement> stack = new Stack<XTextParagraphFlagElement>();
				stack.Push(xtextParagraphFlagElement_0);
				XTextParagraphFlagElement xTextParagraphFlagElement = null;
				foreach (XTextElement item in Content)
				{
					if (item is XTextParagraphFlagElement)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)item;
						xTextParagraphFlagElement2.ParentParagraph = null;
						ParagraphListStyle listStyle = xTextParagraphFlagElement2.ListStyle;
						if (xTextParagraphFlagElement2.OutlineLevel >= 0)
						{
							xTextParagraphFlagElement2.ListIndex = 0;
							xTextParagraphFlagElement2.ParentParagraph = null;
							xTextParagraphFlagElement2.MaxListIndex = 0;
							xTextParagraphFlagElement2.ChildParagraphs.Clear();
							if (stack.Count == 1)
							{
								stack.Peek().method_13(xTextParagraphFlagElement2);
							}
							else
							{
								while (stack.Count > 0)
								{
									XTextParagraphFlagElement xTextParagraphFlagElement3 = stack.Peek();
									if (stack.Count == 1 || xTextParagraphFlagElement3.OutlineLevel < xTextParagraphFlagElement2.OutlineLevel)
									{
										xTextParagraphFlagElement3.method_13(xTextParagraphFlagElement2);
										break;
									}
									if (stack.Count == 1)
									{
										break;
									}
									stack.Pop();
								}
							}
							stack.Push(xTextParagraphFlagElement2);
						}
						if (xTextParagraphFlagElement2.ParentParagraph == null && listStyle != 0)
						{
							List<XTextParagraphFlagElement> list = null;
							if (!xTextParagraphFlagElement2.ResetListIndexFlag)
							{
								if (list_2.Count > 0)
								{
									list = list_2[list_2.Count - 1];
								}
								if (xTextParagraphFlagElement != null && (xTextParagraphFlagElement.ParentParagraph != null || xTextParagraphFlagElement.ListStyle != xTextParagraphFlagElement2.ListStyle))
								{
									list = null;
								}
							}
							if (list == null)
							{
								list = new List<XTextParagraphFlagElement>();
								list_2.Add(list);
							}
							list.Add(xTextParagraphFlagElement2);
						}
						xTextParagraphFlagElement = xTextParagraphFlagElement2;
					}
				}
				stack.Clear();
				stack = null;
				if (bool_24)
				{
					method_58(xtextParagraphFlagElement_0);
					foreach (List<XTextParagraphFlagElement> item2 in list_2)
					{
						for (int i = 0; i < item2.Count; i++)
						{
							XTextParagraphFlagElement xTextParagraphFlagElement2 = item2[i];
							xTextParagraphFlagElement2.ListIndex = i + 1;
							xTextParagraphFlagElement2.MaxListIndex = item2.Count;
						}
					}
				}
			}
		}

		private void method_58(XTextParagraphFlagElement xtextParagraphFlagElement_1)
		{
			int num = 1;
			ParagraphListStyle paragraphListStyle = ParagraphListStyle.None;
			List<XTextParagraphFlagElement> list = new List<XTextParagraphFlagElement>();
			foreach (XTextParagraphFlagElement childParagraph in xtextParagraphFlagElement_1.ChildParagraphs)
			{
				childParagraph.ParentParagraph = xtextParagraphFlagElement_1;
				if (GClass470.smethod_7(childParagraph.ListStyle))
				{
					if (num == 0)
					{
						paragraphListStyle = childParagraph.ListStyle;
					}
					if (childParagraph.ListStyle != paragraphListStyle || childParagraph.ResetListIndexFlag)
					{
						num = 0;
						if (list.Count > 0)
						{
							foreach (XTextParagraphFlagElement item in list)
							{
								item.MaxListIndex = list.Count;
							}
						}
						list.Clear();
					}
					list.Add(childParagraph);
					paragraphListStyle = childParagraph.ListStyle;
					childParagraph.ListIndex = num + 1;
					num++;
				}
				if (childParagraph.ChildParagraphs.Count > 0)
				{
					method_58(childParagraph);
				}
			}
			if (list.Count > 0)
			{
				foreach (XTextParagraphFlagElement item2 in list)
				{
					item2.MaxListIndex = list.Count + 1;
				}
			}
			list.Clear();
			list = null;
		}

		internal void method_59(ref XTextElement xtextElement_0, ref XTextElement xtextElement_1)
		{
			if (xtextContent_0 != null && xtextSelection_0 != null)
			{
				xtextElement_0 = xtextContent_0.SafeGet(xtextSelection_0.StartIndex);
				xtextElement_1 = xtextContent_0.SafeGet(xtextSelection_0.StartIndex + xtextSelection_0.Length);
				if (xtextElement_0 == null)
				{
					xtextElement_0 = xtextElement_1;
				}
				if (xtextElement_1 == null)
				{
					xtextElement_1 = xtextElement_0;
				}
			}
		}

		internal void method_60(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			if (xtextElement_0 == null && xtextElement_1 == null)
			{
				return;
			}
			if (xtextElement_0 == null)
			{
				xtextElement_0 = xtextElement_1;
			}
			if (xtextElement_1 == null)
			{
				xtextElement_1 = xtextElement_0;
			}
			if (xtextContent_0 == null || xtextContent_0.Count <= 0)
			{
				return;
			}
			int num = xtextContent_0.IndexOf(xtextElement_0);
			int num2 = xtextContent_0.IndexOf(xtextElement_1);
			bool flag = false;
			if (num < 0 || num2 < 0)
			{
				if (WriterUtils.smethod_2(xtextElement_0, xtextElement_1) > 0)
				{
					flag = true;
					XTextElement xTextElement = xtextElement_0;
					xtextElement_0 = xtextElement_1;
					xtextElement_1 = xTextElement;
				}
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
				domTreeNodeEnumerable.ExcludeCharElement = false;
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				int num3 = -1;
				bool flag2 = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (num3 < 0)
					{
						if (item != xtextContent_0[0])
						{
							continue;
						}
						num3 = 0;
					}
					if (num < 0 && item == xtextElement_0)
					{
						XTextElement xTextElement3 = xtextContent_0.SafeGet(num3 + 1);
						num = ((xTextElement3 == null || xTextElement3.ContentElement != xtextContent_0[num3].ContentElement) ? num3 : (num3 + 1));
						if (xtextElement_0 == xtextElement_1)
						{
							num2 = num;
							break;
						}
					}
					bool flag3;
					if (flag3 = (item == xtextContent_0.SafeGet(num3 + 1)))
					{
						num3++;
					}
					else if (item.ViewIndex >= 0 && item == xtextContent_0.SafeGet(item.ViewIndex))
					{
						flag3 = true;
						num3 = item.ViewIndex;
					}
					if (num2 < 0)
					{
						if (!flag2 && item == xtextElement_1)
						{
							flag2 = true;
						}
						if (flag2 && flag3)
						{
							num2 = num3;
						}
					}
					if (num >= 0 && num2 >= 0)
					{
						break;
					}
				}
			}
			if (num >= 0 && num2 >= 0)
			{
				if (flag)
				{
					SetSelection(num2, num - num2);
				}
				else
				{
					SetSelection(num, num2 - num);
				}
			}
		}

		internal void method_61()
		{
			method_55();
			OwnerDocument.method_44();
			xtextContent_0.method_16();
			xtextContent_0.OwnerDocument = OwnerDocument;
			xtextContent_0.DocumentContentElement = this;
			vmethod_32(xtextContent_0, bool_17: false);
			int num = 0;
			foreach (XTextElement item in xtextContent_0)
			{
				item.int_2 = num;
				num++;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		[DCInternal]
		public override XTextElement Clone(bool Deeply)
		{
			XTextDocumentContentElement xTextDocumentContentElement = (XTextDocumentContentElement)base.Clone(Deeply);
			xTextDocumentContentElement.xtextContent_0 = null;
			xTextDocumentContentElement.xtextLineList_1 = null;
			xTextDocumentContentElement.dictionary_0 = null;
			xTextDocumentContentElement.xtextElementList_5 = null;
			xTextDocumentContentElement.xtextSelection_0 = null;
			xTextDocumentContentElement.list_2 = null;
			xTextDocumentContentElement.xtextParagraphFlagElement_0 = null;
			xTextDocumentContentElement.bool_22 = true;
			xTextDocumentContentElement.xtextElementList_4 = null;
			return xTextDocumentContentElement;
		}

		internal void method_62(Class11 class11_0)
		{
			base.vmethod_37(class11_0);
		}

		internal override void vmethod_37(Class11 class11_0)
		{
			if (class11_0.method_0())
			{
				OwnerDocument.TypedElements.method_1(bool_1: true);
			}
			OwnerDocument.method_44();
			_ = Elements.Count;
			xtextElementList_5 = null;
			if (xtextContent_0 == null)
			{
				xtextContent_0 = new XTextContent();
			}
			xtextContent_0.DocumentContentElement = this;
			xtextContent_0.OwnerDocument = OwnerDocument;
			xtextContent_0.method_16();
			xtextLineList_1 = null;
			base.vmethod_37(class11_0);
			if (!class11_0.method_4())
			{
				if (OwnerDocument.HighlightManager != null)
				{
					OwnerDocument.HighlightManager.imethod_7();
				}
				if (OwnerDocument.Options.ViewOptions.EnableRightToLeft)
				{
					_ = Content;
				}
			}
			if (class11_0.method_0())
			{
				OwnerDocument.TypedElements.method_1(bool_1: false);
				OwnerDocument.TypedElements.method_2();
			}
		}

		internal void method_63()
		{
			xtextElementList_5 = null;
		}

		private void method_64(XTextContainerElement xtextContainerElement_1, XTextElementList xtextElementList_6)
		{
			foreach (XTextElement element in xtextContainerElement_1.Elements)
			{
				if (element is XTextContainerElement && element.RuntimeVisible)
				{
					if (element is XTextTableElement)
					{
						XTextTableElement xTextTableElement = (XTextTableElement)element;
						foreach (XTextTableRowElement row in xTextTableElement.Rows)
						{
							if (row.RuntimeVisible)
							{
								foreach (XTextTableCellElement cell in row.Cells)
								{
									if (cell.RuntimeVisible)
									{
										xtextElementList_6.AddRaw(cell);
										method_64(cell, xtextElementList_6);
									}
								}
							}
						}
					}
					else
					{
						if (element is XTextContentElement)
						{
							xtextElementList_6.AddRaw(element);
						}
						method_64((XTextContainerElement)element, xtextElementList_6);
					}
				}
			}
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象,对文档块元素该参数无意义</param>
		/// <returns>创建的文档对象</returns>
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			XTextElementList xtextElementList_ = Elements.CloneDeeply();
			return WriterUtils.smethod_32(OwnerDocument, xtextElementList_, bool_2: false);
		}

		/// <summary>
		///       元素是否处于选择状态
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>是否选择</returns>
		[DCPublishAPI]
		public virtual bool IsSelected(XTextElement element)
		{
			if (xtextSelection_0 == null)
			{
				return false;
			}
			return xtextSelection_0.Contains(element);
		}

		/// <summary>
		///       获得焦点
		///       </summary>
		[DCPublishAPI]
		public override void Focus()
		{
			XTextDocument ownerDocument = OwnerDocument;
			if (ownerDocument != null && ownerDocument.EditorControl != null)
			{
				ownerDocument.EditorControl.method_7(this);
			}
			else if (ownerDocument.CurrentContentElement != this)
			{
				ownerDocument.CurrentContentElement = this;
			}
		}

		public XTextSelection method_65(int int_13, int int_14)
		{
			XTextSelection xTextSelection = new XTextSelection(this);
			xTextSelection.Refresh(int_13, int_14);
			return xTextSelection;
		}

		/// <summary>
		///       设置选择区域
		///       </summary>
		/// <param name="firstIndex">开始序号</param>
		/// <param name="lastIndex">结束序号</param>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		public bool SetSelectionRange(int firstIndex, int lastIndex)
		{
			if (firstIndex >= 0 && lastIndex >= 0)
			{
				int num = Content.FixIndexForStrictFormViewMode(firstIndex, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: true);
				int num2 = Content.FixIndexForStrictFormViewMode(lastIndex, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
				if (num != firstIndex || num2 != lastIndex)
				{
					return base.DocumentContentElement.SetSelection(num, 0);
				}
				return base.DocumentContentElement.SetSelection(firstIndex, lastIndex - firstIndex + 1);
			}
			return false;
		}

		internal bool method_66(XTextTableCellElement xtextTableCellElement_0, XTextTableCellElement xtextTableCellElement_1)
		{
			int num = 9;
			if (Content.Count == 0)
			{
				return false;
			}
			if (xtextTableCellElement_0 == null)
			{
				throw new ArgumentNullException("firstCell");
			}
			if (xtextTableCellElement_1 == null)
			{
				xtextTableCellElement_1 = xtextTableCellElement_0;
			}
			if (!xtextTableCellElement_0.RuntimeVisible || !xtextTableCellElement_1.RuntimeVisible || xtextTableCellElement_0.FirstContentElementInPublicContent == null || xtextTableCellElement_1.FirstContentElementInPublicContent == null)
			{
				return false;
			}
			int int_ = Selection.StartIndex;
			int int_2 = Selection.Length;
			Content.method_18(ref int_, ref int_2);
			SelectionChangingEventArgs selectionChangingEventArgs = new SelectionChangingEventArgs();
			selectionChangingEventArgs.Documnent = OwnerDocument;
			selectionChangingEventArgs.OldSelectionIndex = Selection.StartIndex;
			selectionChangingEventArgs.OldSelectionLength = Selection.Length;
			selectionChangingEventArgs.NewSelectionIndex = xtextTableCellElement_0.FirstContentElementInPublicContent.ViewIndex;
			selectionChangingEventArgs.NewSelectionLength = xtextTableCellElement_1.LastContentElementInPublicContent.ViewIndex - xtextTableCellElement_0.FirstContentElement.ViewIndex;
			OwnerDocument.method_28(selectionChangingEventArgs);
			if (selectionChangingEventArgs.Cancel)
			{
				return false;
			}
			if (Selection.method_3(xtextTableCellElement_0, xtextTableCellElement_1))
			{
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.UpdateTextCaret();
				}
				_ = Content[int_];
				method_67(Content.SafeGet(int_), Content.SafeGet(Selection.StartIndex));
				OwnerDocument.OnSelectionChanged();
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.InnerViewControl.Invalidate();
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       更新文内容选择状态
		///       </summary>
		/// <param name="startIndex">选择区域的起始位置</param>
		/// <param name="length">选择区域的包含文档内容元素的个数</param>
		public bool SetSelection(int startIndex, int length)
		{
			if (Content.Count == 0)
			{
				return false;
			}
			if (UIIsUpdating)
			{
				return false;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			if (startIndex < 0)
			{
				startIndex = 0;
			}
			int int_ = Selection.StartIndex;
			int int_2 = Selection.Length;
			Content.method_18(ref int_, ref int_2);
			if (Selection.method_2(startIndex, length))
			{
				SelectionChangingEventArgs selectionChangingEventArgs = new SelectionChangingEventArgs();
				selectionChangingEventArgs.Documnent = OwnerDocument;
				selectionChangingEventArgs.OldSelectionIndex = Selection.StartIndex;
				selectionChangingEventArgs.OldSelectionLength = Selection.Length;
				selectionChangingEventArgs.NewSelectionIndex = startIndex;
				selectionChangingEventArgs.NewSelectionLength = length;
				OwnerDocument.method_28(selectionChangingEventArgs);
				if (selectionChangingEventArgs.Cancel)
				{
					return false;
				}
				startIndex = selectionChangingEventArgs.NewSelectionIndex;
				length = selectionChangingEventArgs.NewSelectionLength;
				if (Selection.Refresh(startIndex, length))
				{
					if (OwnerDocument.EditorControl != null && !OwnerDocument.EditorControl.InvokeRequired)
					{
						OwnerDocument.EditorControl.UpdateTextCaret();
					}
					_ = Content[int_];
					method_67(Content.SafeGet(int_), Content.SafeGet(Selection.StartIndex));
					OwnerDocument.OnSelectionChanged();
					tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
					return true;
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			return false;
		}

		internal void method_67(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			if (OwnerDocument.bool_26)
			{
				OwnerDocument.bool_26 = false;
				return;
			}
			XTextElementList xTextElementList = (xtextElement_0 == null) ? new XTextElementList() : WriterUtils.smethod_57(xtextElement_0);
			if (OwnerDocument.Options.BehaviorOptions.WidelyRaiseFocusEvent)
			{
				xTextElementList = ((xtextElement_0 == null) ? new XTextElementList() : WriterUtils.smethod_58(xtextElement_0));
			}
			if (xtextElement_0 != null)
			{
				xTextElementList.method_13(0, xtextElement_0);
			}
			XTextElementList xTextElementList2 = (xtextElement_1 == null) ? new XTextElementList() : WriterUtils.smethod_57(xtextElement_1);
			if (OwnerDocument.Options.BehaviorOptions.WidelyRaiseFocusEvent)
			{
				xTextElementList2 = ((xtextElement_1 == null) ? new XTextElementList() : WriterUtils.smethod_58(xtextElement_1));
			}
			if (xtextElement_1 != null)
			{
				xTextElementList2.method_13(0, xtextElement_1);
			}
			foreach (XTextElement item in xTextElementList)
			{
				if (!xTextElementList2.Contains(item))
				{
					DocumentEventArgs documentEventArgs = new DocumentEventArgs(OwnerDocument, item, DocumentEventStyles.LostFocus);
					item.HandleDocumentEvent(documentEventArgs);
					documentEventArgs.intStyle = DocumentEventStyles.LostFocusExt;
					item.HandleDocumentEvent(documentEventArgs);
					if (WriterControl != null && WriterControl.EnabledEventMessage && item is XTextContainerElement)
					{
						WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ElementLostFocus);
						writerControlEventMessage.SrcElement = item;
						writerControlEventMessage.ToElement = item;
						WriterControl.method_49(writerControlEventMessage);
					}
				}
			}
			foreach (XTextElement item2 in xTextElementList2)
			{
				if (!xTextElementList.Contains(item2))
				{
					DocumentEventArgs documentEventArgs = new DocumentEventArgs(OwnerDocument, item2, DocumentEventStyles.GotFocus);
					item2.HandleDocumentEvent(documentEventArgs);
					if (WriterControl != null && WriterControl.EnabledEventMessage && item2 is XTextContainerElement)
					{
						WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ElementFocus);
						writerControlEventMessage.SrcElement = item2;
						writerControlEventMessage.ToElement = item2;
						WriterControl.method_49(writerControlEventMessage);
					}
				}
			}
		}

		/// <summary>
		///       返回指定区域的文档区域
		///       </summary>
		/// <param name="StartIndex">区域开始位置</param>
		/// <param name="EndIndex">区域结束位置</param>
		/// <returns>区域对象</returns>
		public virtual XTextRange GetRange(int StartIndex, int EndIndex)
		{
			return new XTextRange(this, StartIndex, EndIndex);
		}

		/// <summary>
		///       获得所有的文档行对象，包括子容器元素的文档行
		///       </summary>
		/// <remarks>获得的文档行对象列表</remarks>
		[DCPublishAPI]
		public XTextLineList GetAllLines()
		{
			XTextLineList xTextLineList = new XTextLineList();
			method_68(this, xTextLineList);
			return xTextLineList;
		}

		private void method_68(XTextContentElement xtextContentElement_0, XTextLineList xtextLineList_2)
		{
			if (xtextContentElement_0.PrivateLines != null)
			{
				foreach (XTextLine privateLine in xtextContentElement_0.PrivateLines)
				{
					xtextLineList_2.Add(privateLine);
					if (privateLine.IsSectionLine)
					{
						XTextSectionElement sectionElement = privateLine.SectionElement;
						method_68(sectionElement, xtextLineList_2);
					}
					else if (privateLine.IsTableLine)
					{
						XTextTableElement tableElement = privateLine.TableElement;
						foreach (XTextTableCellElement cell in tableElement.Cells)
						{
							if (!cell.IsOverrided)
							{
								method_68(cell, xtextLineList_2);
							}
						}
					}
				}
			}
		}

		internal void method_69()
		{
			if (OwnerDocument.Pages != null && OwnerDocument.Pages.Count != 0)
			{
				method_28(1);
				PrintPage printPage = null;
				int num = 0;
				foreach (XTextLine line in Lines)
				{
					if (line.OwnerPage != printPage)
					{
						printPage = line.OwnerPage;
						num = line.GlobalIndex;
					}
					line.IndexInPage = line.GlobalIndex - num + 1;
				}
				printPage = null;
				num = 0;
				int num2 = 0;
				foreach (XTextLine privateLine in base.PrivateLines)
				{
					if (privateLine.OwnerPage != printPage)
					{
						printPage = privateLine.OwnerPage;
						num = num2;
					}
					privateLine.PrivateIndexInPage = num2 - num + 1;
					num2++;
				}
			}
		}

		internal override bool vmethod_42(Class121 class121_0)
		{
			bool result = base.vmethod_42(class121_0);
			xtextLineList_1 = null;
			Height = base.ContentHeightExcludeLastLineAdditionHeight;
			if (!(this is XTextDocumentHeaderElement) && !(this is XTextDocumentFooterElement))
			{
			}
			float num = Width;
			foreach (XTextLine privateLine in base.PrivateLines)
			{
				float num2 = privateLine.Left + privateLine.ViewWidth;
				if (num2 > num)
				{
					num = num2;
				}
			}
			if (HasSpecifyLayoutElements)
			{
				float absLeft = AbsLeft;
				float absTop = AbsTop;
				float num3 = Height;
				foreach (XTextElement specifyLayoutElement in SpecifyLayoutElements)
				{
					RectangleF absBounds = specifyLayoutElement.AbsBounds;
					if (num + absLeft < absBounds.Right)
					{
						num = absBounds.Right - absLeft;
					}
					if (num3 + absTop < absBounds.Bottom)
					{
						num3 = absBounds.Bottom - absTop;
					}
				}
				Height = num3;
			}
			float_9 = num;
			method_69();
			return result;
		}

		internal void method_70()
		{
			xtextLineList_1 = null;
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (HasSpecifyLayoutElements)
			{
				method_71(ElementZOrderStyle.UnderText, args);
				base.DrawContent(args);
				method_71(ElementZOrderStyle.InFrontOfText, args);
			}
			else
			{
				base.DrawContent(args);
			}
		}

		private void method_71(ElementZOrderStyle elementZOrderStyle_0, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			bool flag;
			if ((flag = OwnerDocument.Options.SecurityOptions.ShowPermissionMark) && !XTextDocument.smethod_13(GEnum6.const_118))
			{
				flag = false;
			}
			RectangleF clipRectangle = documentPaintEventArgs_0.ClipRectangle;
			RectangleF absBounds = AbsBounds;
			absBounds.Width = ViewWidth;
			clipRectangle = RectangleF.Intersect(clipRectangle, absBounds);
			foreach (XTextElement specifyLayoutElement in SpecifyLayoutElements)
			{
				if (specifyLayoutElement.RuntimeZOrderStyle == elementZOrderStyle_0 && documentPaintEventArgs_0.IsVisible(specifyLayoutElement.RuntimeStyle.Visibility))
				{
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && specifyLayoutElement is XTextObjectElement)
					{
						XTextObjectElement xTextObjectElement = (XTextObjectElement)specifyLayoutElement;
						if (xTextObjectElement.PrintVisibility != 0)
						{
							continue;
						}
					}
					RectangleF absBounds2 = specifyLayoutElement.AbsBounds;
					RectangleF rectangleF = absBounds2;
					if (!clipRectangle.IsEmpty)
					{
						rectangleF = RectangleF.Intersect(clipRectangle, absBounds2);
					}
					if (!rectangleF.IsEmpty)
					{
						OwnerDocument.method_88(absBounds2);
						documentPaintEventArgs_0.Element = specifyLayoutElement;
						documentPaintEventArgs_0.Style = specifyLayoutElement.RuntimeStyle;
						documentPaintEventArgs_0.ViewBounds = absBounds2;
						documentPaintEventArgs_0.ClientViewBounds = documentPaintEventArgs_0.Style.GetClientRectangleF(absBounds2);
						if (flag)
						{
							documentPaintEventArgs_0.Render.vmethod_0(specifyLayoutElement, documentPaintEventArgs_0, bool_2: true);
						}
						WriterUtils.smethod_29(this, specifyLayoutElement, documentPaintEventArgs_0);
						specifyLayoutElement.Draw(documentPaintEventArgs_0);
						WriterUtils.smethod_28(this, specifyLayoutElement, documentPaintEventArgs_0);
						if (flag)
						{
							documentPaintEventArgs_0.Render.vmethod_0(specifyLayoutElement, documentPaintEventArgs_0, bool_2: true);
						}
						if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && documentPaintEventArgs_0.ActiveMode && documentContentElement.IsSelected(specifyLayoutElement))
						{
							OwnerDocument.EditorControl.AddSelectionAreaRectangle(Rectangle.Ceiling(absBounds2));
						}
					}
				}
			}
		}

		private void method_72(XTextContentElement xtextContentElement_0, XTextLineList xtextLineList_2)
		{
			int num = 17;
			foreach (XTextLine privateLine in xtextContentElement_0.PrivateLines)
			{
				if (privateLine.Count == 0)
				{
					throw new InvalidOperationException("line count = 0 ");
				}
				if (privateLine.IsTableLine)
				{
					XTextTableElement tableElement = privateLine.TableElement;
					foreach (XTextTableRowElement row in tableElement.Rows)
					{
						if (row.RuntimeVisible)
						{
							foreach (XTextTableCellElement cell in row.Cells)
							{
								if (cell.RuntimeVisible)
								{
									method_72(cell, xtextLineList_2);
								}
							}
						}
					}
				}
				else if (privateLine.IsSectionLine)
				{
					XTextSectionElement sectionElement = privateLine.SectionElement;
					method_72(sectionElement, xtextLineList_2);
				}
				else
				{
					xtextLineList_2.Add(privateLine);
				}
			}
		}

		/// <summary>
		///       在编辑器中更新文档视图
		///       </summary>
		/// <param name="fastMode">快速模式</param>
		public override void EditorRefreshViewExt(bool fastMode)
		{
			SizeInvalid = true;
			FixDomState();
			vmethod_36(bool_22: true);
			InvalidateView();
			using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
			{
				DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_);
				documentPaintEventArgs.RenderMode = DocumentRenderMode.Paint;
				documentPaintEventArgs.ActiveMode = false;
				documentPaintEventArgs.Element = this;
				if (!fastMode)
				{
					documentPaintEventArgs.CheckSizeInvalidateWhenRefreshSize = true;
				}
				RefreshSize(documentPaintEventArgs);
			}
			vmethod_36(bool_22: true);
			XTextElementList xtextElementList_ = new XTextElementList(this);
			foreach (XTextElement item in new DomTreeNodeEnumerable(xtextElementList_))
			{
				method_9(item, !fastMode);
			}
			vmethod_44(bool_22: false);
			method_31(0);
			InvalidateView();
			Selection.method_4();
		}

		/// <summary>
		///       加载文档后的处理
		///       </summary>
		[DCInternal]
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			xtextContent_0 = null;
			xtextElementList_5 = null;
			xtextLineList_1 = null;
			bool_22 = true;
			base.AfterLoad(args);
		}

		/// <summary>
		///       清空文档内容
		///       </summary>
		[DCPublishAPI]
		public override void Clear()
		{
			OwnerDocument.method_44();
			Elements.Clear();
			Elements.Add(OwnerDocument.CreateElementByType(typeof(XTextParagraphFlagElement)));
			vmethod_36(bool_22: true);
			ExecuteLayout();
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			gclass103_0.bool_4 = true;
			gclass103_0.method_6(new RectangleF(0f, 0f, OwnerDocument.Width, Height));
			base.vmethod_19(gclass103_0);
			gclass103_0.bool_4 = false;
		}

		[DCInternal]
		public float method_73(int int_13)
		{
			GClass128 gClass = new GClass128();
			gClass.float_3 = int_13;
			gClass.method_21(0f);
			gClass.method_17(bool_5: false);
			method_42(gClass);
			return gClass.method_23();
		}

		private void method_74(bool bool_23)
		{
			throw new NotSupportedException("EditorDelete");
		}

		public override void Dispose()
		{
			base.Dispose();
			method_55();
			if (xtextContent_0 != null)
			{
				xtextContent_0.method_49();
				xtextContent_0 = null;
			}
			if (xtextElementList_5 != null)
			{
				xtextElementList_5.Clear();
				xtextElementList_5 = null;
			}
			if (dictionary_0 != null)
			{
				dictionary_0.Clear();
				dictionary_0 = null;
			}
			if (list_2 != null)
			{
				list_2.Clear();
				list_2 = null;
			}
			if (xtextLineList_1 != null)
			{
				xtextLineList_1.method_2();
				xtextLineList_1 = null;
			}
			if (xtextParagraphFlagElement_0 != null)
			{
				xtextParagraphFlagElement_0 = null;
			}
			if (xtextSelection_0 != null)
			{
				xtextSelection_0.method_11();
				xtextSelection_0 = null;
			}
		}
	}
}
