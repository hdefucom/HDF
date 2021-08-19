using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       知识库节点存储操作提供者
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DocumentComment]
	public interface IKBStoreProvider
	{
		/// <summary>
		///       新增知识库节点对象
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		bool Insert(KBStoreEventArgs args);

		/// <summary>
		///       删除知识库节点对象
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		bool Delete(KBStoreEventArgs args);

		/// <summary>
		///       更新知识库节点对象
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		bool Update(KBStoreEventArgs args);
	}
}
