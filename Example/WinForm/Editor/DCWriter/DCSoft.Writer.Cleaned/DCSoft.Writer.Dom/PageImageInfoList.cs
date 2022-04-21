using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页码图片信息对象列表
	///       </summary>
	[Serializable]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("E91BCB9D-9FD4-4478-8779-C7F37966C4B6", "26CA71E1-18BD-4532-A9BD-A1111A93F003")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[ComDefaultInterface(typeof(IPageImageInfoList))]
	[Guid("E91BCB9D-9FD4-4478-8779-C7F37966C4B6")]
	[ComVisible(true)]
	public class PageImageInfoList : List<PageImageInfo>, IPageImageInfoList
	{
		internal const string string_0 = "E91BCB9D-9FD4-4478-8779-C7F37966C4B6";

		internal const string string_1 = "26CA71E1-18BD-4532-A9BD-A1111A93F003";

		/// <summary>
		///       设置图片值
		///       </summary>
		/// <param name="pageIndex">从0开始的页码号</param>
		/// <param name="img">图片值</param>
		[ComVisible(true)]
		public void SetImage(int pageIndex, XImageValue ximageValue_0)
		{
			PageImageInfo pageImageInfo = method_0(pageIndex);
			if (ximageValue_0 == null)
			{
				if (pageImageInfo != null)
				{
					Remove(pageImageInfo);
				}
				return;
			}
			if (pageImageInfo == null)
			{
				pageImageInfo = new PageImageInfo();
				pageImageInfo.PageIndex = pageIndex;
				Add(pageImageInfo);
			}
			pageImageInfo.Image = ximageValue_0;
		}

		/// <summary>
		///       获得指定页码对应的图片
		///       </summary>
		/// <param name="pageIndex">
		/// </param>
		/// <returns>
		/// </returns>
		public XImageValue GetImage(int pageIndex)
		{
			return method_0(pageIndex)?.Image;
		}

		private PageImageInfo method_0(int int_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageImageInfo current = enumerator.Current;
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
		public PageImageInfoList Clone()
		{
			PageImageInfoList pageImageInfoList = new PageImageInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageImageInfo current = enumerator.Current;
					pageImageInfoList.Add(current.Clone());
				}
			}
			return pageImageInfoList;
		}
	}
}
