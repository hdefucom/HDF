using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Design
{
	/// <summary>
	///       加载类型信息的标记
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	[Flags]
	public enum DCTypeLoadFlags
	{
		/// <summary>
		///       无标记
		///       </summary>
		None = 0x0,
		/// <summary>
		///       加载相关联的程序集信息
		///       </summary>
		LoadRelationAssembly = 0x1,
		/// <summary>
		///       只加载类型声明的成员
		///       </summary>
		LoadDeclaredOnlyMember = 0x2,
		/// <summary>
		///       只加载公开和受保护的类型和成员
		///       </summary>
		LoadPublicProtectOnly = 0x4,
		/// <summary>
		///       忽略掉枚举类型
		///       </summary>
		ExcludeEnumType = 0x8,
		/// <summary>
		///       忽略掉接口类型
		///       </summary>
		ExcludeInterfaceType = 0x10,
		/// <summary>
		///       忽略掉数值类型
		///       </summary>
		ExcludeValueType = 0x20,
		/// <summary>
		///       忽略掉标准程序集
		///       </summary>
		ExcludeStdAssembly = 0x40,
		/// <summary>
		///       忽略掉资源程序集
		///       </summary>
		ExcludeResourceAssembly = 0x80,
		/// <summary>
		///       忽略掉数组类型
		///       </summary>
		ExcludeArrayType = 0x100,
		/// <summary>
		///       忽略掉委托类型
		///       </summary>
		ExcludeDelegateType = 0x200,
		/// <summary>
		///       忽略掉类型成员属性
		///       </summary>
		ExcludeMemberProperty = 0x400,
		/// <summary>
		///       忽略掉类型成员事件
		///       </summary>
		ExcludeMemberEvent = 0x800,
		/// <summary>
		///       忽略掉类型成员方法
		///       </summary>
		ExcludeMemberMethod = 0x1000,
		/// <summary>
		///       忽略掉类型成员字段
		///       </summary>
		ExcludeMemberField = 0x2000,
		/// <summary>
		///       忽略掉WinForm/ASP.NET控件
		///       </summary>
		ExcludeWinFormASPControl = 0x4000,
		/// <summary>
		///       忽略掉所有类型成员
		///       </summary>
		ExcludeTypeMember = 0x8000
	}
}
