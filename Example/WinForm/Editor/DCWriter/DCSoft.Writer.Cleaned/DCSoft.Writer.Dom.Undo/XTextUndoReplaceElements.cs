using DCSoftDotfuscate;
using System;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoReplaceElements : XTextUndoBase
	{
		private XTextContainerElement xtextContainerElement_0;

		private int int_0;

		private XTextElementList xtextElementList_0;

		private XTextElementList xtextElementList_1;

		/// <summary>
		///       容器元素对象
		///       </summary>
		public XTextContainerElement Container => xtextContainerElement_0;

		/// <summary>
		///       元素序号
		///       </summary>
		public int Index => int_0;

		/// <summary>
		///       对象名称
		///       </summary>
		public override string Name
		{
			get
			{
				if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
				{
					if (xtextElementList_0.Count == 1)
					{
						return string.Format(WriterStringsCore.DeleteElement_Content, xtextElementList_0[0].ToString());
					}
					return string.Format(WriterStringsCore.DeleteElements_Count, xtextElementList_0.Count);
				}
				if (xtextElementList_1 != null && xtextElementList_1.Count > 0)
				{
					if (xtextElementList_1.Count == 1)
					{
						return string.Format(WriterStringsCore.InsertElement_Content, xtextElementList_1[0].ToString());
					}
					return string.Format(WriterStringsCore.InsertElements_Count, xtextElementList_1.Count);
				}
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextUndoReplaceElements()
		{
			xtextContainerElement_0 = null;
			int_0 = 0;
			xtextElementList_0 = new XTextElementList();
			xtextElementList_1 = new XTextElementList();
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="container">容器元素对象</param>
		/// <param name="index">发生操作的序号</param>
		/// <param name="oldElements">旧元素列表</param>
		/// <param name="newElements">新元素列表</param>
		public XTextUndoReplaceElements(XTextContainerElement xtextContainerElement_1, int int_1, XTextElementList xtextElementList_2, XTextElementList xtextElementList_3)
		{
			int num = 14;
			xtextContainerElement_0 = null;
			int_0 = 0;
			xtextElementList_0 = new XTextElementList();
			xtextElementList_1 = new XTextElementList();
			
			if (xtextContainerElement_1 == null)
			{
				throw new ArgumentNullException("container");
			}
			if (int_1 != 0 || xtextContainerElement_1.Elements.Count != 0)
			{
				if (int_1 < 0)
				{
					throw new ArgumentOutOfRangeException("index<0");
				}
				int num2 = xtextContainerElement_1.Elements.Count - 1;
				if (xtextElementList_2 != null)
				{
					num2 += xtextElementList_2.Count;
				}
				if (int_1 > num2)
				{
					throw new ArgumentOutOfRangeException("index>" + num2);
				}
			}
			xtextContainerElement_0 = xtextContainerElement_1;
			int_0 = int_1;
			xtextElementList_0 = xtextElementList_2;
			xtextElementList_1 = xtextElementList_3;
			if (xtextElementList_0 != null && xtextElementList_0.Count == 0)
			{
				xtextElementList_0 = null;
			}
			if (xtextElementList_1 != null && xtextElementList_1.Count == 0)
			{
				xtextElementList_1 = null;
			}
		}

		private XTextElement method_0(XTextElement xtextElement_0)
		{
			XTextContentElement contentElement = xtextContainerElement_0.ContentElement;
			XTextElement xTextElement = xtextElement_0;
			while (true)
			{
				if (xTextElement != null)
				{
					if (contentElement.PrivateContent.Contains(xTextElement))
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				if (xtextElement_0 is XTextSectionElement)
				{
					return xtextElement_0;
				}
				return xtextElement_0.FirstContentElement;
			}
			return xTextElement;
		}

		private void method_1(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			XTextContentElement contentElement = xtextContainerElement_0.ContentElement;
			XTextElementList refreshElements = base.OwnerList.RefreshElements;
			if (!refreshElements.Contains(xtextElement_0))
			{
				refreshElements.Add(xtextElement_0);
			}
			XTextLine xtextLine_ = null;
			while (xtextElement_0 != null)
			{
				if (!contentElement.PrivateContent.Contains(xtextElement_0))
				{
					xtextElement_0 = xtextElement_0.Parent;
					continue;
				}
				xtextLine_ = xtextElement_0.OwnerLine;
				if (!refreshElements.Contains(xtextElement_0))
				{
					refreshElements.Add(xtextElement_0);
				}
				break;
			}
			if (!refreshElements.Contains(xtextElement_1))
			{
				refreshElements.Add(xtextElement_1);
			}
			XTextLine xtextLine_2 = null;
			while (xtextElement_1 != null)
			{
				if (!contentElement.PrivateContent.Contains(xtextElement_1))
				{
					xtextElement_1 = xtextElement_1.Parent;
					continue;
				}
				xtextLine_2 = xtextElement_1.OwnerLine;
				if (!refreshElements.Contains(xtextElement_1))
				{
					refreshElements.Add(xtextElement_1);
				}
				break;
			}
			contentElement.method_29(xtextLine_, xtextLine_2);
		}

		public override void Undo(GEventArgs3 args)
		{
			int num = 14;
			if (xtextContainerElement_0 == null)
			{
				return;
			}
			_ = xtextContainerElement_0.OwnerDocument;
			XTextContentElement contentElement = xtextContainerElement_0.ContentElement;
			args.method_0()["ContentElement"] = contentElement;
			if (xtextElementList_0 != null && xtextElementList_1 == null)
			{
				if (int_0 < 0 || int_0 > xtextContainerElement_0.Elements.Count)
				{
					return;
				}
				xtextContainerElement_0.Elements.method_12(int_0, xtextElementList_0);
				foreach (XTextElement item in xtextElementList_0)
				{
					XTextElement xTextElement = method_0(item);
					if (xTextElement != null && xTextElement.OwnerLine != null)
					{
						xTextElement.OwnerLine.InvalidateState = true;
					}
					item.OwnerLine = null;
					item.Parent = xtextContainerElement_0;
				}
				xtextContainerElement_0.UpdateContentVersion();
				method_1(xtextElementList_0.FirstContentElement, xtextElementList_0.LastContentElement);
			}
			else if (xtextElementList_0 == null && xtextElementList_1 != null)
			{
				int num2 = contentElement.PrivateContent.IndexOf(xtextElementList_1.FirstContentElement);
				int num3 = num2;
				xtextContainerElement_0.Elements.RemoveRange(xtextElementList_1);
				foreach (XTextElement item2 in xtextElementList_1)
				{
					if (item2 is XTextCharElement)
					{
						num3 = Math.Min(num3, item2.ViewIndex);
						if (item2.OwnerLine != null)
						{
							item2.OwnerLine.InvalidateState = true;
							item2.OwnerLine = null;
						}
					}
					else if (item2.FirstContentElementInPublicContent != null)
					{
						num3 = Math.Min(num3, item2.FirstContentElementInPublicContent.ViewIndex);
						if (xtextContainerElement_0.OwnerDocument.HighlightManager != null)
						{
							xtextContainerElement_0.OwnerDocument.HighlightManager.imethod_8(item2);
						}
						XTextElement xTextElement2 = method_0(item2.FirstContentElementInPublicContent);
						XTextElement xTextElement3 = method_0(item2.LastContentElementInPublicContent);
						contentElement.method_29(xTextElement2?.OwnerLine, xTextElement3?.OwnerLine);
						if (item2.OwnerLine != null)
						{
							item2.OwnerLine.InvalidateState = true;
							item2.OwnerLine = null;
						}
					}
				}
				xtextContainerElement_0.UpdateContentVersion();
				base.OwnerList.AddContentRefreshInfo(contentElement, num3);
			}
			else if (xtextElementList_0 != null && xtextElementList_1 != null)
			{
				int num2 = contentElement.PrivateContent.IndexOf(xtextElementList_1.FirstContentElement);
				int num3 = num2;
				xtextContainerElement_0.Elements.RemoveRange(xtextElementList_1);
				foreach (XTextElement item3 in xtextElementList_1)
				{
					if (item3 is XTextCharElement)
					{
						num3 = Math.Min(num3, item3.ViewIndex);
						if (item3.OwnerLine != null)
						{
							item3.OwnerLine.InvalidateState = true;
							item3.OwnerLine = null;
						}
					}
					else if (item3.FirstContentElementInPublicContent != null)
					{
						num3 = Math.Min(num3, item3.FirstContentElementInPublicContent.ViewIndex);
						if (xtextContainerElement_0.OwnerDocument.HighlightManager != null)
						{
							xtextContainerElement_0.OwnerDocument.HighlightManager.imethod_8(item3);
						}
						XTextElement xTextElement2 = method_0(item3.FirstContentElementInPublicContent);
						XTextElement xTextElement3 = method_0(item3.LastContentElementInPublicContent);
						if (xTextElement2 == xTextElement3)
						{
							if (xTextElement2.OwnerLine != null)
							{
								xTextElement2.OwnerLine.InvalidateState = true;
							}
						}
						else
						{
							contentElement.method_29(xTextElement2?.OwnerLine, xTextElement3?.OwnerLine);
						}
						item3.OwnerLine = null;
					}
				}
				base.OwnerList.AddContentRefreshInfo(contentElement, num3);
				if (int_0 < 0 || int_0 > xtextContainerElement_0.Elements.Count)
				{
					return;
				}
				xtextContainerElement_0.Elements.method_12(int_0, xtextElementList_0);
				foreach (XTextElement item4 in xtextElementList_0)
				{
					if (item4.OwnerLine != null)
					{
						item4.OwnerLine.InvalidateState = true;
						item4.OwnerLine = null;
					}
					item4.Parent = xtextContainerElement_0;
				}
				xtextContainerElement_0.UpdateContentVersion();
				base.OwnerList.RefreshElements.Add(method_0(xtextElementList_0.FirstContentElement));
				base.OwnerList.RefreshElements.Add(method_0(xtextElementList_0.LastContentElement));
			}
			if (!base.OwnerList.ContentChangedContainer.Contains(xtextContainerElement_0))
			{
				base.OwnerList.ContentChangedContainer.Add(xtextContainerElement_0);
			}
		}

		public override void Redo(GEventArgs3 args)
		{
			if (xtextContainerElement_0 == null)
			{
				return;
			}
			XTextContentElement contentElement = xtextContainerElement_0.ContentElement;
			if (xtextElementList_0 != null && xtextElementList_1 == null)
			{
				int startIndex = contentElement.PrivateContent.IndexOf(xtextElementList_0.FirstContentElement);
				xtextContainerElement_0.Elements.RemoveRange(xtextElementList_0);
				foreach (XTextElement item in xtextElementList_0)
				{
					XTextElement xTextElement = method_0(item);
					if (xTextElement != null && xTextElement.OwnerLine != null)
					{
						xTextElement.OwnerLine.InvalidateState = true;
					}
					item.OwnerLine = null;
					if (xtextContainerElement_0.OwnerDocument.HighlightManager != null)
					{
						xtextContainerElement_0.OwnerDocument.HighlightManager.imethod_8(item);
					}
				}
				xtextContainerElement_0.UpdateContentVersion();
				base.OwnerList.AddContentRefreshInfo(contentElement, startIndex);
			}
			else if (xtextElementList_0 == null && xtextElementList_1 != null)
			{
				if (int_0 < 0 || int_0 > xtextContainerElement_0.Elements.Count)
				{
					return;
				}
				xtextContainerElement_0.Elements.method_12(int_0, xtextElementList_1);
				foreach (XTextElement item2 in xtextElementList_1)
				{
					XTextElement xTextElement = method_0(item2);
					if (xTextElement != null && xTextElement.OwnerLine != null)
					{
						xTextElement.OwnerLine.InvalidateState = true;
					}
					item2.OwnerLine = null;
				}
				xtextContainerElement_0.UpdateContentVersion();
				method_1(xtextElementList_1.FirstContentElement, xtextElementList_1.LastContentElement);
			}
			else if (xtextElementList_0 != null && xtextElementList_1 != null)
			{
				int startIndex = contentElement.PrivateContent.IndexOf(xtextElementList_0.FirstContentElement);
				xtextContainerElement_0.Elements.RemoveRange(xtextElementList_0);
				foreach (XTextElement item3 in xtextElementList_0)
				{
					XTextElement xTextElement = method_0(item3);
					if (xTextElement != null && xTextElement.OwnerLine != null)
					{
						xTextElement.OwnerLine.InvalidateState = true;
					}
					item3.OwnerLine = null;
					if (xtextContainerElement_0.OwnerDocument.HighlightManager != null)
					{
						xtextContainerElement_0.OwnerDocument.HighlightManager.imethod_8(item3);
					}
				}
				base.OwnerList.AddContentRefreshInfo(contentElement, startIndex);
				if (int_0 < 0 || int_0 > xtextContainerElement_0.Elements.Count)
				{
					return;
				}
				xtextContainerElement_0.Elements.method_12(int_0, xtextElementList_1);
				foreach (XTextElement item4 in xtextElementList_1)
				{
					if (item4.OwnerLine != null)
					{
						item4.OwnerLine.InvalidateState = true;
						item4.OwnerLine = null;
					}
				}
				xtextContainerElement_0.UpdateContentVersion();
				contentElement.vmethod_36(bool_22: true);
				method_1(xtextElementList_1.FirstContentElement, xtextElementList_1.LastContentElement);
			}
			if (!base.OwnerList.ContentChangedContainer.Contains(xtextContainerElement_0))
			{
				base.OwnerList.ContentChangedContainer.Add(xtextContainerElement_0);
			}
		}
	}
}
