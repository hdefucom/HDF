using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素编辑器
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public abstract class ElementPropertiesEditor
	{
		/// <summary>
		///       判断指定类型的编辑操作是否支持
		///       </summary>
		/// <param name="method">编辑操作的方法</param>
		/// <returns>是否支持</returns>
		public abstract bool IsSupportMethod(ElementPropertiesEditMethod method);

		/// <summary>
		///       编辑文档元素内容
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否修改了文档元素的内容</returns>
		public abstract bool Edit(ElementPropertiesEditEventArgs args);
	}
}
