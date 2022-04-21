using DCSoft.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       错误信息报告者接口
	///       </summary>
	[Guid("00012345-6789-ABCD-EF01-234567890095")]
	[ComVisible(false)]
	
	public interface IErrorReporter
	{
		/// <summary>
		///       报告错误信息
		///       </summary>
		/// <param name="parentWindow">显示对话框使用的父窗口对象</param>
		/// <param name="message">信息</param>
		/// <param name="details">详细信息</param>
		void ReportError(IWin32Window parentWindow, string message, string details);
	}
}
