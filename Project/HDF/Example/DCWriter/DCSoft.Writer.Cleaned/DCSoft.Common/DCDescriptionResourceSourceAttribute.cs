using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       属性名称资源来源特性
	                                                                    ///       </summary>
	[AttributeUsage(AttributeTargets.Class)]
	[ComVisible(false)]
	public class DCDescriptionResourceSourceAttribute : Attribute
	{
		private string _ResourceName = null;

		                                                                    /// <summary>
		                                                                    ///       资源名
		                                                                    ///       </summary>
		public string ResourceName
		{
			get
			{
				return _ResourceName;
			}
			set
			{
				_ResourceName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="resourceName">资源名称</param>
		public DCDescriptionResourceSourceAttribute(string resourceName)
		{
			_ResourceName = resourceName;
		}
	}
}
