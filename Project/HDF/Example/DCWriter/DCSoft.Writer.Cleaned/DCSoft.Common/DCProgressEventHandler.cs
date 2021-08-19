using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       进度事件委托类型
	                                                                    ///       </summary>
	                                                                    /// <param name="sender">参数</param>
	                                                                    /// <param name="args">参数</param>
	                                                                    /// <remarks>袁永福到此一游</remarks>
	[ComVisible(true)]
	[Guid("D815F467-69C6-45D9-ACE7-CC13F5F37216")]
	[DocumentComment]
	public delegate void DCProgressEventHandler(object sender, DCProgressEventArgs e);
}
