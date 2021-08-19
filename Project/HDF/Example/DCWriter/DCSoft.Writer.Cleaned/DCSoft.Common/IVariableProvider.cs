using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       字符串变量提供者接口
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public interface IVariableProvider
	{
		                                                                    /// <summary>
		                                                                    ///       获得所有变量的名称
		                                                                    ///       </summary>
		string[] AllNames
		{
			get;
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否存在指定名称的变量
		                                                                    ///       </summary>
		                                                                    /// <param name="Name">变量名称</param>
		                                                                    /// <returns>是否存在指定名称的变量</returns>
		bool Exists(string Name);

		                                                                    /// <summary>
		                                                                    ///       获得指定名称的变量值
		                                                                    ///       </summary>
		                                                                    /// <param name="Name">变量名称</param>
		                                                                    /// <returns>变量值</returns>
		string Get(string Name);

		                                                                    /// <summary>
		                                                                    ///       设置指定名称的变量值
		                                                                    ///       </summary>
		                                                                    /// <param name="Name">变量名称</param>
		                                                                    /// <param name="Value">变量值</param>
		void Set(string Name, string Value);
	}
}
