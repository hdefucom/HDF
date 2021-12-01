using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       虚拟文件系统接口
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	[DCInternal]
	[ComVisible(false)]
	[Obsolete("!!!请使用WriterControl.EventReadFileContent,EventSaveFileContent事件")]
	[Guid("00012345-6789-ABCD-EF01-234567890023")]
	public interface IFileSystem
	{
		/// <summary>
		///       打开文件
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>读取的文件二进制内容，若失败则返回空引用</returns>
		byte[] Read(VFileSystemEventArgs args);

		/// <summary>
		///       保存文件
		///       </summary>
		/// <param name="args">参数</param>
		/// <param name="content">要保存的内容</param>
		/// <returns>操作是否成功</returns>
		bool Write(VFileSystemEventArgs args, byte[] content);

		/// <summary>
		///       获得指定文件名的文件信息
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>获得的文件信息</returns>
		VFileInfo GetFileInfo(VFileSystemEventArgs args);

		/// <summary>
		///       为读取文件而显示浏览选择文件的对话框
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		VFileInfo BrowseForRead(VFileSystemEventArgs args);

		/// <summary>
		///       为保存文件而显示浏览选择文件的对话框
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		VFileInfo BrowseForWrite(VFileSystemEventArgs args);
	}
}
