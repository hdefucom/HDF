using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       访问文档对象模型时的标记
	///       </summary>
	[Flags]
	[Guid("A41F518E-269C-4E18-B444-CFA723A00998")]
	[ComVisible(true)]
	
	
	public enum DomAccessFlags
	{
		/// <summary>
		///       没有任何标记
		///       </summary>
		None = 0x0,
		/// <summary>
		///       检查控件是否只读
		///       </summary>
		CheckControlReadonly = 0x1,
		/// <summary>
		///       是否检查用户可直接编辑设置
		///       </summary>
		CheckUserEditable = 0x2,
		/// <summary>
		///       检查输入域是否只读
		///       </summary>
		CheckReadonly = 0x4,
		/// <summary>
		///       检查用户权限限制
		///       </summary>
		CheckPermission = 0x8,
		/// <summary>
		///       检查表单视图模式
		///       </summary>
		CheckFormView = 0x10,
		/// <summary>
		///       检查文档锁定状态
		///       </summary>
		CheckLock = 0x20,
		/// <summary>
		///       检查内容保护状态
		///       </summary>
		CheckContentProtect = 0x40,
		/// <summary>
		///       检查容器元素是否只读状态
		///       </summary>
		CheckContainerReadonly = 0x80,
		/// <summary>
		///       所有的标记
		///       </summary>
		Normal = 0xFF
	}
}
