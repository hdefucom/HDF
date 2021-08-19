using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       默认的错误报告者
	///       </summary>
	[ComVisible(false)]
	public class DefaultErrorReporter : IErrorReporter
	{
		/// <summary>
		///       报告错误信息
		///       </summary>
		/// <param name="parentWindow">显示对话框使用的父窗口对象</param>
		/// <param name="message">信息</param>
		/// <param name="details">详细信息</param>
		public void ReportError(IWin32Window parentWindow, string message, string details)
		{
			ErrorReporter.ReportError(parentWindow, message, details);
		}
	}
}
