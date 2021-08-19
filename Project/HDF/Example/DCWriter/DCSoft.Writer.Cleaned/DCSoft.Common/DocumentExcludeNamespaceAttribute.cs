using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       声明命名空间不列在文档中的特性
	                                                                    ///       </summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[ComVisible(false)]
	public class DocumentExcludeNamespaceAttribute : Attribute
	{
		private string _Namespace = null;

		                                                                    /// <summary>
		                                                                    ///       命名空间
		                                                                    ///       </summary>
		public string Namespace
		{
			get
			{
				return _Namespace;
			}
			set
			{
				_Namespace = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="ns">
		                                                                    /// </param>
		public DocumentExcludeNamespaceAttribute(string string_0)
		{
			_Namespace = string_0;
		}

		public override string ToString()
		{
			return _Namespace;
		}
	}
}
