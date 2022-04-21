using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       导航节点列表
	///       </summary>
	[Guid("018F2C51-DA77-4E16-A92E-C5C1D6D8BA78")]
	
	[ComClass("018F2C51-DA77-4E16-A92E-C5C1D6D8BA78", "2609A1FB-AA59-4BC3-81D7-823A18BBFF44")]
	
	[ComVisible(true)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(INavigateNodeList))]
	[DebuggerDisplay("Count={ Count }")]
	public class NavigateNodeList : List<NavigateNode>, INavigateNodeList
	{
		internal const string CLASSID = "018F2C51-DA77-4E16-A92E-C5C1D6D8BA78";

		internal const string CLASSID_Interface = "2609A1FB-AA59-4BC3-81D7-823A18BBFF44";

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public NavigateNodeList()
		{
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		
		[ComVisible(true)]
		public NavigateNode ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		
		public void ComSetItem(int index, NavigateNode item)
		{
			base[index] = item;
		}
	}
}
