using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       输入的数据类型
	///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("DBDB030A-DA13-46C7-8642-EA5B41DEE065")]
	[DCPublishAPI]
	public enum InputValueType
	{
		/// <summary>
		///       纯文本数据
		///       </summary>
		Text,
		/// <summary>
		///       RTF文档数据
		///       </summary>
		RTF,
		/// <summary>
		///       Html文档数据
		///       </summary>
		Html,
		/// <summary>
		///       图片数据
		///       </summary>
		Image,
		/// <summary>
		///       拖拽的文件名
		///       </summary>
		FileName,
		/// <summary>
		///       文档DOM数据
		///       </summary>
		Dom
	}
}
