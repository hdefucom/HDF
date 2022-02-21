using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       自动更新管理器
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	
	public interface IAutoSaveManager
	{
		/// <summary>
		///       判断是否存在自动保存的文件
		///       </summary>
		/// <param name="fileID">文件编号</param>
		/// <param name="confirm">是否让用户确认操作</param>
		/// <returns>是否存在自动保存的文件</returns>
		
		bool Exists(string fileID, bool confirm);

		/// <summary>
		///       读取自动保存的文件内容
		///       </summary>
		/// <param name="fileID">
		/// </param>
		/// <returns>
		/// </returns>
		
		byte[] ReadContent(string fileID);

		/// <summary>
		///       为自动保存而保存文件内容到临时文件
		///       </summary>
		/// <param name="fileID">
		/// </param>
		/// <param name="content">
		/// </param>
		/// <returns>
		/// </returns>
		
		bool SaveContent(string fileID, byte[] content);

		/// <summary>
		///       删除临时保存的文件内容
		///       </summary>
		/// <param name="fileID">
		/// </param>
		
		void Delete(string fileID);
	}
}
