using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       实现了数据源绑定机制的接口
	///       </summary>
	[ComVisible(false)]
	public interface IUpdateDataBindingExt
	{
		/// <summary>
		///       更新数据源
		///       </summary>
		/// <param name="dataSource">绑定的数据源对象</param>
		/// <param name="fastMode">快速模式</param>
		/// <returns>操作是否导致了文档内容发生改变的处数</returns>
		int UpdateDataBindingExt(UpdateDataBindingArgs args);
	}
}
