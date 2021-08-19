using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       表示可以对第三方公开的编程接口。南京都昌公司对外的技术支持只负责添加该特性的编程接口，
	                                                                    ///       没添加该特性的不推荐客户使用。
	                                                                    ///       </summary>
	[Description("表示可以对第三方公开的编程接口。南京都昌公司对外的技术支持只负责添加该特性的编程接口，没添加该特性的不推荐客户使用。")]
	[DocumentComment]
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class DCPublishAPIAttribute : Attribute
	{
		private bool _ApplyToMembers = false;

		                                                                    /// <summary>
		                                                                    ///       是否应用到类型成员
		                                                                    ///       </summary>
		public bool ApplyToMembers
		{
			get
			{
				return _ApplyToMembers;
			}
			set
			{
				_ApplyToMembers = value;
			}
		}
	}
}
