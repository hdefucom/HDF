using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       表示内部使用的功能模块的特性。第三方开发者不应该使用该特性附加的功能模块。
	                                                                    ///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class DCInternalAttribute : Attribute
	{
	}
}
