using DCSoft.Common;
using DCSoft.Writer.Dom.Design;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内容元素类型
	///       </summary>
	[Guid("00012345-6789-ABCD-EF01-234567890111")]
	
	[Flags]
	[ComVisible(true)]
	
	[Editor(typeof(ElementTypeEditor), typeof(UITypeEditor))]
	public enum ElementType
	{
		/// <summary>
		///       无效类型
		///       </summary>
		[DCDescription(typeof(ElementType), "None")]
		None = 0x0,
		/// <summary>
		///       文本元素
		///       </summary>
		[DCDescription(typeof(ElementType), "Text")]
		Text = 0x1,
		/// <summary>
		///       字段元素
		///       </summary>
		[DCDescription(typeof(ElementType), "Field")]
		Field = 0x2,
		/// <summary>
		///       输入框元素
		///       </summary>
		[DCDescription(typeof(ElementType), "InputField")]
		InputField = 0x4,
		/// <summary>
		///       表格元素
		///       </summary>
		[DCDescription(typeof(ElementType), "Table")]
		Table = 0x8,
		/// <summary>
		///       表格行
		///       </summary>
		[DCDescription(typeof(ElementType), "TableRow")]
		TableRow = 0x10,
		/// <summary>
		///       表格列
		///       </summary>
		[DCDescription(typeof(ElementType), "TableColumn")]
		TableColumn = 0x20,
		/// <summary>
		///       表格单元格
		///       </summary>
		[DCDescription(typeof(ElementType), "TableCell")]
		TableCell = 0x40,
		/// <summary>
		///       嵌入的对象
		///       </summary>
		[DCDescription(typeof(ElementType), "Object")]
		Object = 0x80,
		/// <summary>
		///       换行
		///       </summary>
		[DCDescription(typeof(ElementType), "LineBreak")]
		LineBreak = 0x100,
		/// <summary>
		///       分页符号
		///       </summary>
		[DCDescription(typeof(ElementType), "PageBreak")]
		PageBreak = 0x200,
		/// <summary>
		///       段落标记
		///       </summary>
		[DCDescription(typeof(ElementType), "ParagraphFlag")]
		ParagraphFlag = 0x400,
		/// <summary>
		///       单复选框
		///       </summary>
		[DCDescription(typeof(ElementType), "CheckRadioBox")]
		CheckRadioBox = 0x800,
		/// <summary>
		///       复选框，仅供兼容使用。
		///       </summary>
		CheckBox = 0x800,
		/// <summary>
		///       图片元素
		///       </summary>
		[DCDescription(typeof(ElementType), "Image")]
		Image = 0x1000,
		/// <summary>
		///       文档对象
		///       </summary>
		[DCDescription(typeof(ElementType), "Document")]
		Document = 0x2000,
		/// <summary>
		///       按钮
		///       </summary>
		Button = 0x4000,
		/// <summary>
		///       容器元素
		///       </summary>
		Container = 0x8000,
		/// <summary>
		///       所有类型
		///       </summary>
		[DCDescription(typeof(ElementType), "All")]
		All = 0xFFFFFF
	}
}
