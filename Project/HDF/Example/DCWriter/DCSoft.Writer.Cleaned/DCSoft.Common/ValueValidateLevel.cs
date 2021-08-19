using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       数据校验无效等级
	                                                                    ///       </summary>
	[Guid("840F7766-5459-407E-8A68-260382AE3AAB")]
	[ComVisible(true)]
	public enum ValueValidateLevel
	{
		                                                                    /// <summary>
		                                                                    ///       错误
		                                                                    ///       </summary>
		Error,
		                                                                    /// <summary>
		                                                                    ///       警告
		                                                                    ///       </summary>
		Warring,
		                                                                    /// <summary>
		                                                                    ///       只是提醒
		                                                                    ///       </summary>
		Info
	}
}
