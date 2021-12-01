using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页码标签文本列表
	///       </summary>
	[Serializable]
	[DCPublishAPI]
	[ComClass("FF125BB9-0498-48FF-90C4-158CEEB0CDC3", "A190D93A-F50F-4A36-87BE-863F35186D04")]
	[DocumentComment]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DebuggerDisplay("Count={ Count }")]
	[ComDefaultInterface(typeof(IPageLabelTextList))]
	[Guid("FF125BB9-0498-48FF-90C4-158CEEB0CDC3")]
	public class PageLabelTextList : List<PageLabelText>, IPageLabelTextList
	{
		private class Class19 : IComparer<PageLabelText>
		{
			public int Compare(PageLabelText pageLabelText_0, PageLabelText pageLabelText_1)
			{
				return pageLabelText_0.PageIndex.CompareTo(pageLabelText_1.PageIndex);
			}
		}

		internal const string string_0 = "FF125BB9-0498-48FF-90C4-158CEEB0CDC3";

		internal const string string_1 = "A190D93A-F50F-4A36-87BE-863F35186D04";

		/// <summary>
		///       设置文本
		///       </summary>
		/// <param name="pageIndex">从0开始的页码号</param>
		/// <param name="text">文本值</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SetPageText(int pageIndex, string text)
		{
			PageLabelText pageLabelText = method_0(pageIndex);
			if (string.IsNullOrEmpty(text))
			{
				if (pageLabelText != null)
				{
					Remove(pageLabelText);
				}
				return;
			}
			if (pageLabelText == null)
			{
				pageLabelText = new PageLabelText();
				pageLabelText.PageIndex = pageIndex;
				Add(pageLabelText);
			}
			pageLabelText.Text = text;
		}

		/// <summary>
		///       获得指定页码对应的文本
		///       </summary>
		/// <param name="pageIndex">
		/// </param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public string GetText(int pageIndex, bool strickMatchPageIndex)
		{
			if (strickMatchPageIndex)
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						PageLabelText current = enumerator.Current;
						if (current.PageIndex == pageIndex)
						{
							return current.Text;
						}
					}
				}
				return null;
			}
			Sort(new Class19());
			PageLabelText pageLabelText = null;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageLabelText current = enumerator.Current;
					if (pageIndex < current.PageIndex)
					{
						break;
					}
					pageLabelText = current;
				}
			}
			return pageLabelText?.Text;
		}

		private PageLabelText method_0(int int_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageLabelText current = enumerator.Current;
					if (current.PageIndex == int_0)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCPublishAPI]
		public PageLabelTextList Clone()
		{
			PageLabelTextList pageLabelTextList = new PageLabelTextList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageLabelText current = enumerator.Current;
					pageLabelTextList.Add(current.Clone());
				}
			}
			return pageLabelTextList;
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			int num = 10;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageLabelText current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine(";");
					}
					stringBuilder.Append(current.PageIndex + "=" + current.Text);
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public PageLabelText ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void ComSetItem(int index, PageLabelText item)
		{
			base[index] = item;
		}
	}
}
