using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印页面信息列表
	///       </summary>
	[ComDefaultInterface(typeof(IPrintPageResultList))]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("5B4C4495-4625-4982-A53E-1D2AA773255E")]
	[ComVisible(true)]
	public class PrintPageResultList : List<PrintPageResult>, IPrintPageResultList
	{
		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public PrintPageResult ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void ComSetItem(int index, PrintPageResult item)
		{
			base[index] = item;
		}
	}
}
