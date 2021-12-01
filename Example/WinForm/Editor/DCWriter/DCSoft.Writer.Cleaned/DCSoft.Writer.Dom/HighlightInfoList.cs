using DCSoft.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       高亮度显示区域列表
	///       </summary>
	[DocumentComment]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	public class HighlightInfoList : List<HighlightInfo>
	{
		/// <summary>
		///       两个高亮度显示区域位置的比较器
		///       </summary>
		[DocumentComment]
		private class HighlighInfoComparer : IComparer<HighlightInfo>
		{
			public int Compare(HighlightInfo highlightInfo_0, HighlightInfo highlightInfo_1)
			{
				return WriterUtils.smethod_2(highlightInfo_0.OwnerElement, highlightInfo_1.OwnerElement);
			}
		}

		private bool _PureInputFieldElementFlag = false;

		/// <summary>
		///       最后一次检索的元素对象
		///       </summary>
		private XTextElement _LastElement = null;

		/// <summary>
		///       最后一次检索的值
		///       </summary>
		private HighlightInfo _LastValue = null;

		/// <summary>
		///       查找包含自定元素的
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		public HighlightInfo this[XTextElement element]
		{
			get
			{
				if (element.ContentIndex < 0)
				{
					return null;
				}
				if (_LastElement == element)
				{
					return _LastValue;
				}
				_LastElement = element;
				_LastValue = null;
				XTextElement ownerParent = element.GetOwnerParent(typeof(XTextInputFieldElement), includeThis: false);
				int num;
				HighlightInfo highlightInfo;
				if (ownerParent != null)
				{
					num = base.Count - 1;
					while (num >= 0)
					{
						highlightInfo = base[num];
						if (highlightInfo.xtextElement_0 != ownerParent || !highlightInfo.Contains(element))
						{
							num--;
							continue;
						}
						_LastValue = highlightInfo;
						return highlightInfo;
					}
				}
				if (_PureInputFieldElementFlag)
				{
					return null;
				}
				XTextElementList xTextElementList = new XTextElementList();
				XTextElement xTextElement = element;
				if (element is XTextCharElement || element is XTextParagraphFlagElement)
				{
					xTextElement = element.Parent;
				}
				while (xTextElement != null && !(xTextElement is XTextDocumentContentElement))
				{
					xTextElementList.Add(xTextElement);
					xTextElement = xTextElement.Parent;
				}
				if (xTextElementList.Count == 0)
				{
					return null;
				}
				num = base.Count - 1;
				while (true)
				{
					if (num >= 0)
					{
						highlightInfo = base[num];
						if (highlightInfo.OwnerElement != null && xTextElementList.Contains(highlightInfo.OwnerElement) && highlightInfo.OwnerElement == element.Parent && highlightInfo.Contains(element))
						{
							break;
						}
						num--;
						continue;
					}
					num = base.Count - 1;
					while (true)
					{
						if (num >= 0)
						{
							highlightInfo = base[num];
							if (highlightInfo.OwnerElement == null && base[num].Contains(element))
							{
								break;
							}
							num--;
							continue;
						}
						return null;
					}
					_LastValue = base[num];
					return base[num];
				}
				_LastValue = highlightInfo;
				return highlightInfo;
			}
		}

		[DCInternal]
		public void ClearContent()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HighlightInfo current = enumerator.Current;
					current.method_0();
				}
			}
			_LastElement = null;
			_LastValue = null;
			Clear();
		}

		public HighlightInfo GetInfoForContent(XTextElement element)
		{
			_ = element.DocumentContentElement;
			for (int num = base.Count - 1; num >= 0; num--)
			{
			}
			return null;
		}

		public void UpdatePureInputFieldElementFlag()
		{
			_PureInputFieldElementFlag = true;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HighlightInfo current = enumerator.Current;
					if (!(current.OwnerElement is XTextInputFieldElement))
					{
						_PureInputFieldElementFlag = false;
						break;
					}
				}
			}
			_LastElement = null;
			_LastValue = null;
		}

		/// <summary>
		///       判断是否存在指定元素的高亮度显示信息
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>是否包含指定的元素相关的信息</returns>
		public bool ContainsOwnerElement(XTextElement element)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HighlightInfo current = enumerator.Current;
					if (current.OwnerElement == element)
					{
						return true;
					}
				}
			}
			return false;
		}

		[DCInternal]
		public void SortInfo()
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			_LastElement = null;
			_LastValue = null;
			Sort(new HighlighInfoComparer());
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}
	}
}
