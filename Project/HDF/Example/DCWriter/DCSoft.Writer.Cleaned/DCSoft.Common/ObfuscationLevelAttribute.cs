using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       .NET代码混淆等级特性
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[ComVisible(false)]
	public class ObfuscationLevelAttribute : Attribute
	{
		private ObfuscationLevelConst intLevel = ObfuscationLevelConst.ExcludePulibc;

		                                                                    /// <summary>
		                                                                    ///       混淆等级
		                                                                    ///       </summary>
		public ObfuscationLevelConst Level => intLevel;

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public ObfuscationLevelAttribute()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="level">混淆等级</param>
		public ObfuscationLevelAttribute(ObfuscationLevelConst level)
		{
			intLevel = level;
		}
	}
}
