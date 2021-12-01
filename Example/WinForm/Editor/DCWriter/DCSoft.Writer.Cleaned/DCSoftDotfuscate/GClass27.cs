using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass27 : GInterface6
	{
		private XTextDocument xtextDocument_0 = null;

		[NonSerialized]
		private HighlightInfo highlightInfo_0 = null;

		[NonSerialized]
		private HighlightInfoList highlightInfoList_0 = null;

		[NonSerialized]
		private HighlightInfoList highlightInfoList_1 = null;

		[NonSerialized]
		private XTextElementList xtextElementList_0 = new XTextElementList();

		private Dictionary<XTextElement, HighlightInfo> dictionary_0 = null;

		public GClass27(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		private XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		private void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public HighlightInfo imethod_0()
		{
			return highlightInfo_0;
		}

		public void imethod_1(HighlightInfo highlightInfo_1)
		{
			highlightInfo_0 = highlightInfo_1;
		}

		public HighlightInfoList imethod_2()
		{
			return highlightInfoList_0;
		}

		public void imethod_3(HighlightInfoList highlightInfoList_2)
		{
			highlightInfoList_0 = highlightInfoList_2;
		}

		public void imethod_4()
		{
			highlightInfoList_0 = null;
			highlightInfo_0 = null;
			highlightInfoList_1 = null;
			xtextElementList_0 = null;
			dictionary_0 = null;
		}

		public HighlightInfo imethod_5()
		{
			if (highlightInfoList_0 == null || highlightInfoList_0.Count == 0)
			{
				return null;
			}
			return highlightInfoList_0[0];
		}

		public void imethod_6(HighlightInfo highlightInfo_1)
		{
			if (highlightInfoList_0 == null)
			{
				highlightInfoList_0 = new HighlightInfoList();
			}
			highlightInfoList_0.Clear();
			if (highlightInfo_1 != null)
			{
				highlightInfoList_0.Add(highlightInfo_1);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public void imethod_7()
		{
			lock (this)
			{
				highlightInfoList_1 = null;
				if (imethod_2() != null)
				{
					foreach (HighlightInfo item in imethod_2())
					{
						if (item.Range != null)
						{
							item.Range.method_3();
						}
					}
				}
				highlightInfo_0 = null;
			}
		}

		public virtual void imethod_8(XTextElement xtextElement_0)
		{
			int num = 10;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (!method_0().IsLoadingDocument)
			{
				lock (this)
				{
					if (highlightInfoList_1 != null && highlightInfoList_1.Count > 0)
					{
						method_2(highlightInfoList_1, xtextElement_0);
					}
					if (highlightInfoList_0 != null && highlightInfoList_0.Count > 0)
					{
						method_2(highlightInfoList_0, xtextElement_0);
					}
					if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
					{
						for (int num2 = xtextElementList_0.Count - 1; num2 >= 0; num2--)
						{
							XTextElement xTextElement = xtextElementList_0[num2];
							if (xTextElement == xtextElement_0 || xTextElement.IsParentOrSupParent(xtextElement_0))
							{
								xtextElementList_0.RemoveAt(num2);
							}
						}
					}
				}
			}
		}

		private void method_2(HighlightInfoList highlightInfoList_2, XTextElement xtextElement_0)
		{
			lock (this)
			{
				for (int num = highlightInfoList_2.Count - 1; num >= 0; num--)
				{
					HighlightInfo highlightInfo = highlightInfoList_2[num];
					bool flag = false;
					if (highlightInfo.OwnerElement == xtextElement_0)
					{
						flag = true;
					}
					else if (highlightInfo.OwnerElement != null && highlightInfo.OwnerElement.IsParentOrSupParent(xtextElement_0))
					{
						flag = true;
					}
					if (flag)
					{
						if (highlightInfo.Range != null)
						{
							method_0().method_71(highlightInfo.Range);
						}
						highlightInfoList_2.RemoveAt(num);
						dictionary_0 = null;
					}
				}
			}
		}

		public void imethod_9(XTextElement xtextElement_0)
		{
			if (method_0().IsLoadingDocument || xtextElement_0 is XTextCharElement)
			{
				return;
			}
			dictionary_0 = null;
			if (highlightInfoList_1 == null)
			{
				return;
			}
			if (xtextElementList_0 == null)
			{
				xtextElementList_0 = new XTextElementList();
			}
			if (xtextElementList_0.Contains(xtextElement_0))
			{
				return;
			}
			xtextElementList_0.Add(xtextElement_0);
			for (int num = highlightInfoList_1.Count - 1; num >= 0; num--)
			{
				HighlightInfo highlightInfo = highlightInfoList_1[num];
				if (highlightInfo.OwnerElement == xtextElement_0)
				{
					highlightInfoList_1.RemoveAt(num);
				}
			}
		}

		internal HighlightInfoList method_3()
		{
			if (highlightInfoList_1 == null)
			{
				dictionary_0 = null;
				if (highlightInfoList_1 != null)
				{
					highlightInfoList_1.ClearContent();
				}
				highlightInfoList_1 = new HighlightInfoList();
				float tickCountFloat = CountDown.GetTickCountFloat();
				XTextElementList xTextElementList = method_0().TypedElements.method_5(method_0(), typeof(XTextContainerElement));
				XTextElement xTextElement = null;
				foreach (XTextContainerElement item in xTextElementList)
				{
					if (!(item is XTextTableCellElement))
					{
						if (xTextElement != null)
						{
							if (item.IsParentOrSupParent(xTextElement))
							{
								continue;
							}
							xTextElement = null;
						}
						if (!item.RuntimeVisible)
						{
							xTextElement = item;
						}
						else
						{
							if (item is XTextSectionElement)
							{
								XTextSectionElement xTextSectionElement = (XTextSectionElement)item;
								if (xTextSectionElement.RuntimeIsCollapsed)
								{
									xTextElement = xTextSectionElement;
									continue;
								}
							}
							HighlightInfoList highlightInfoList = item.vmethod_20();
							if (highlightInfoList != null && highlightInfoList.Count > 0)
							{
								foreach (HighlightInfo item2 in highlightInfoList)
								{
									if (item2.OwnerElement != null && item2.Range != null && item2.Range.method_5(bool_1: false))
									{
										highlightInfoList_1.Add(item2);
									}
								}
							}
						}
					}
				}
				xtextElementList_0 = null;
				highlightInfoList_1.UpdatePureInputFieldElementFlag();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			}
			else if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				dictionary_0 = null;
				foreach (XTextElement item3 in xtextElementList_0)
				{
					bool flag = false;
					for (XTextElement xTextElement2 = item3; xTextElement2 != null; xTextElement2 = xTextElement2.Parent)
					{
						if (!xTextElement2.RuntimeVisible)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						HighlightInfoList highlightInfoList = item3.vmethod_20();
						if (highlightInfoList != null && highlightInfoList.Count > 0)
						{
							foreach (HighlightInfo item4 in highlightInfoList)
							{
								if ((item4.OwnerElement == null || !highlightInfoList_1.ContainsOwnerElement(item4.OwnerElement)) && item4.Range != null && item4.Range.method_5(bool_1: false))
								{
									highlightInfoList_1.Add(item4);
								}
							}
						}
					}
				}
				xtextElementList_0 = null;
				highlightInfoList_1.SortInfo();
				highlightInfoList_1.UpdatePureInputFieldElementFlag();
			}
			return highlightInfoList_1;
		}

		public virtual HighlightInfo imethod_10(XTextElement xtextElement_0)
		{
			if (xtextElement_0 == null)
			{
				return null;
			}
			if (highlightInfo_0 != null && highlightInfo_0.Contains(xtextElement_0))
			{
				return highlightInfo_0;
			}
			if (imethod_2() != null && imethod_2().Count > 0)
			{
				HighlightInfo highlightInfo = imethod_2()[xtextElement_0];
				if (highlightInfo != null)
				{
					return highlightInfo;
				}
			}
			if (method_3() != null)
			{
				return method_3()[xtextElement_0];
			}
			return null;
		}

		private void method_4(Dictionary<XTextElement, HighlightInfo> dictionary_1, HighlightInfoList highlightInfoList_2)
		{
			if (highlightInfoList_2 != null && highlightInfoList_2.Count > 0)
			{
				foreach (HighlightInfo item in highlightInfoList_2)
				{
					if (item.Range.method_5(bool_1: true))
					{
						XTextRange range = item.Range;
						for (int i = 0; i < range.Length; i++)
						{
							XTextElement xTextElement = range.Elements.SafeGet(i + range.StartIndex);
							if (xTextElement != null)
							{
								dictionary_1[xTextElement] = item;
							}
						}
					}
				}
			}
		}
	}
}
