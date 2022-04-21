using DCSoft.Common;
using DCSoft.Writer.Controls;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器控件处理的数据格式功能标记
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Flags]
	[ComVisible(true)]
	
	[Editor(typeof(WriterDataFormatsUIEditor), typeof(UITypeEditor))]
	
	[Guid("00012345-6789-ABCD-EF01-234567890075")]
	public enum WriterDataFormats
	{
		/// <summary>
		///       无任何格式
		///       </summary>
		None = 0x0,
		/// <summary>
		///       普通文本格式
		///       </summary>
		Text = 0x1,
		/// <summary>
		///       RTF格式
		///       </summary>
		RTF = 0x2,
		/// <summary>
		///       HTML格式
		///       </summary>
		Html = 0x4,
		/// <summary>
		///       XML格式
		///       </summary>
		XML = 0x8,
		/// <summary>
		///       图片格式
		///       </summary>
		Image = 0x20,
		/// <summary>
		///       编辑器命令格式
		///       </summary>
		CommandFormat = 0x40,
		/// <summary>
		///       本地文件格式
		///       </summary>
		FileSource = 0x80,
		/// <summary>
		///       知识库节点格式
		///       </summary>
		KBEntry = 0x100,
		/// <summary>
		///       支持所有标准格式
		///       </summary>
		All = 0xFFF
	}
}
