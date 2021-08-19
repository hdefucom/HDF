using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       进度状态
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("961AD5BA-E0FF-478F-805B-0C0053E656D7")]
	public enum DCProgressStates
	{
		                                                                    /// <summary>
		                                                                    ///       开始进行
		                                                                    ///       </summary>
		Begin,
		                                                                    /// <summary>
		                                                                    ///       正在进行
		                                                                    ///       </summary>
		Progress,
		                                                                    /// <summary>
		                                                                    ///       工作结束
		                                                                    ///       </summary>
		Finish
	}
}
