using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑文档元素属性的操作模式
	///       </summary>
	[DCPublishAPI]
	[Guid("8B3654D5-CE8E-4E54-A85C-C4478F5563BD")]
	[DocumentComment]
	[ComVisible(false)]
	public enum ElementPropertiesEditMethod
	{
		/// <summary>
		///       新增元素时编辑文档元素属性
		///       </summary>
		Insert,
		/// <summary>
		///       编辑元素时编辑文档元素属性
		///       </summary>
		Edit
	}
}
