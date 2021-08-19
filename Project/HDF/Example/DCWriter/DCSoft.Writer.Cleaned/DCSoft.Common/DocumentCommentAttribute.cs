using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       文档注释输出属性
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[ComVisible(false)]
	public class DocumentCommentAttribute : Attribute
	{
		private int intLevel = 5;

		                                                                    /// <summary>
		                                                                    ///       输出等级
		                                                                    ///       </summary>
		public int Level
		{
			get
			{
				return intLevel;
			}
			set
			{
				intLevel = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public DocumentCommentAttribute()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="level">输出等级</param>
		public DocumentCommentAttribute(int level)
		{
			intLevel = level;
		}
	}
}
