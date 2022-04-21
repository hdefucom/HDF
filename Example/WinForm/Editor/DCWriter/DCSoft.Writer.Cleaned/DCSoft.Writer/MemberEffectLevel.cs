using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       类型成员影响等级特性
	///       </summary>
	[ComVisible(false)]
	
	public enum MemberEffectLevel
	{
		/// <summary>
		///       只修改DOM结构，不影响文档视图
		///       </summary>
		DOM,
		/// <summary>
		///       影响本元素的文档视图。
		///       </summary>
		ElementView,
		/// <summary>
		///       影响本元素的文档排版和视图
		///       </summary>
		ElementLayout,
		/// <summary>
		///       影响父元素的文档视图
		///       </summary>
		ParentElementLayout,
		/// <summary>
		///       影响容器元素的文档视图
		///       </summary>
		ContentElementLayout,
		/// <summary>
		///       影响整个文档视图
		///       </summary>
		DocumentLayout
	}
}
