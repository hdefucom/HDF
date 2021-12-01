#define DEBUG
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器调试器
	///       </summary>
	[ComVisible(false)]
	public class WriterDebugger
	{
		private bool _Enabled = true;

		/// <summary>
		///       处于允许状态
		///       </summary>
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       输出文本并换行
		///       </summary>
		/// <param name="text">文本值</param>
		public void WriteLine(string text)
		{
			if (Enabled)
			{
				Debug.WriteLine(text);
			}
		}

		/// <summary>
		///       输出文本
		///       </summary>
		/// <param name="text">文本值</param>
		public void Write(string text)
		{
			if (Enabled)
			{
				Debug.Write(text);
			}
		}

		/// <summary>
		///       输出加载文件的调试信息
		///       </summary>
		/// <param name="fileName">文件名</param>
		public void DebugLoadingFile(string fileName)
		{
			if (Enabled)
			{
				Debug.WriteLine(string.Format(WriterStringsCore.Loading_FileName, fileName));
			}
		}

		/// <summary>
		///       输出加载文件完成的调试信息
		///       </summary>
		/// <param name="size">加载的数据字节数</param>
		public void DebugLoadFileComplete(int size)
		{
			if (Enabled)
			{
				Debug.WriteLine(string.Format(WriterStringsCore.LoadComplete_Size, WriterUtils.smethod_44(size)));
			}
		}
	}
}
