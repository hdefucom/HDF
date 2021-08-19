using System;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       Web控件中加载文档时的选项
	///       </summary>
	[Flags]
	internal enum WebWriterControlLoadDocumentOptions
	{
		None = 0x0,
		DoubleCompressWhitespace = 0x1,
		CompressSessionData = 0x2
	}
}
