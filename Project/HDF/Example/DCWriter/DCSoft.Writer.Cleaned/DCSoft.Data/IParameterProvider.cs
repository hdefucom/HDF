using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       参数供应者接口
	                                                                    ///       </summary>
	[ComVisible(false)]
	public interface IParameterProvider
	{
		                                                                    /// <summary>
		                                                                    ///       获得参数说明
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		ParameterDescriptorList GetDescriptors();

		                                                                    /// <summary>
		                                                                    ///       获得参数值
		                                                                    ///       </summary>
		                                                                    /// <param name="name">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		object GetParameterValue(string name);

		                                                                    /// <summary>
		                                                                    ///       设置参数值
		                                                                    ///       </summary>
		                                                                    /// <param name="name">
		                                                                    /// </param>
		                                                                    /// <param name="newValue">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		bool SetParameterValue(string name, object newValue);

		bool Contains(string name);
	}
}
