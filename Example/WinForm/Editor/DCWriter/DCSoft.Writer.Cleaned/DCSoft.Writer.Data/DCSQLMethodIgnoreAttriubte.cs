using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       被SQL方法引擎忽略的对象
	///       </summary>
	[ComVisible(false)]
	
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class DCSQLMethodIgnoreAttriubte : Attribute
	{
	}
}
