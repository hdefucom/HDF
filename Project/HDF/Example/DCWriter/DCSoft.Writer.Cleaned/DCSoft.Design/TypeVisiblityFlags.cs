using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Design
{
	/// <summary>
	///       类型过滤器标记
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public enum TypeVisiblityFlags
	{
		/// <summary>
		///       不显示任何类型
		///       </summary>
		None = 0,
		/// <summary>
		///       显示接口类型
		///       </summary>
		InterfaceType = 1,
		/// <summary>
		///       显示结构类型
		///       </summary>
		StructType = 2,
		/// <summary>
		///       显示枚举类型
		///       </summary>
		EnumType = 4,
		/// <summary>
		///       显示委托类型
		///       </summary>
		DelegateType = 8,
		/// <summary>
		///       显示类类型
		///       </summary>
		ClassType = 0x10,
		/// <summary>
		///       显示所有类型
		///       </summary>
		AllType = 0xFFFF
	}
}
