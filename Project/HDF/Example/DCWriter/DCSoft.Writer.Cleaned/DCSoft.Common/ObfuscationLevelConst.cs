using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       .NET代码混淆等级
	                                                                    ///       </summary>
	[Flags]
	[ComVisible(false)]
	public enum ObfuscationLevelConst
	{
		                                                                    /// <summary>
		                                                                    ///       无作用
		                                                                    ///       </summary>
		None = 0x0,
		                                                                    /// <summary>
		                                                                    ///       混淆所有成员
		                                                                    ///       </summary>
		Both = 0x1,
		                                                                    /// <summary>
		                                                                    ///       不混淆公开成员
		                                                                    ///       </summary>
		ExcludePulibc = 0x2,
		                                                                    /// <summary>
		                                                                    ///       不混淆公开的或受保护的成员
		                                                                    ///       </summary>
		ExcludePublicProtected = 0x4,
		                                                                    /// <summary>
		                                                                    ///       所有成员都不混淆
		                                                                    ///       </summary>
		ExcludeAll = 0x8,
		                                                                    /// <summary>
		                                                                    ///       单独的
		                                                                    ///       </summary>
		Alone = 0x100
	}
}
