using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容来源类型
	///       </summary>
	
	[Guid("7C8C595D-9625-437A-926C-75B9A477E8C1")]
	
	[ComVisible(true)]
	public enum DocumentContentSourceTypes
	{
		/// <summary>
		///       未知类型
		///       </summary>
		Unknown,
		/// <summary>
		///       无来源
		///       </summary>
		None,
		/// <summary>
		///       使用NewFile创建的文档
		///       </summary>
		NewFile,
		/// <summary>
		///       来自文本读取器
		///       </summary>
		TextReader,
		/// <summary>
		///       来自文件流
		///       </summary>
		Stream,
		/// <summary>
		///       来自文件
		///       </summary>
		File
	}
}
