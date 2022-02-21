using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文档参数提供者接口 
	///       </summary>
	[DocumentComment]
	
	[ComVisible(false)]
	public interface IDocumentParameterProvider
	{
		/// <summary>
		///       判断是否包含指定名称的参数
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>是否包含</returns>
		bool Contains(string name);

		/// <summary>
		///       获得指定名称的参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		object GetValue(string name);

		/// <summary>
		///       设置指定名称的参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">参数值</param>
		/// <returns>操作是否成功</returns>
		bool SetValue(string name, object Value);
	}
}
