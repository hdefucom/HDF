using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页面内容版本号信息列表
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[DocumentComment]
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("3603B80D-916C-42E2-B607-D64002C4FC39")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComDefaultInterface(typeof(IPageContentVersionInfoList))]
	[ComClass("3603B80D-916C-42E2-B607-D64002C4FC39", "370C8B59-4ECB-4573-B420-30491BDBDE51")]
	[DebuggerDisplay("Count={ Count }")]
	public class PageContentVersionInfoList : List<PageContentVersionInfo>, IPageContentVersionInfoList
	{
		internal const string CLASSID = "3603B80D-916C-42E2-B607-D64002C4FC39";

		internal const string CLASSID_Interface = "370C8B59-4ECB-4573-B420-30491BDBDE51";

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public PageContentVersionInfoList()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public PageContentVersionInfoList Clone()
		{
			PageContentVersionInfoList pageContentVersionInfoList = new PageContentVersionInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageContentVersionInfo current = enumerator.Current;
					pageContentVersionInfoList.Add(current.Clone());
				}
			}
			return pageContentVersionInfoList;
		}
	}
}
