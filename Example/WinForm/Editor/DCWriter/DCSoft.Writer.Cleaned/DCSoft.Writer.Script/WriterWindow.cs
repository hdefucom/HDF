using DCSoft.Common;
using DCSoft.Script;
using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       编辑器脚本使用的Window对象类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DocumentComment]
	public class WriterWindow : XVBAWindowObject
	{
		private WriterControl _WriterControl = null;

		/// <summary>
		///       文本编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return _WriterControl;
			}
			set
			{
				_WriterControl = value;
				base.parentWindow = value;
			}
		}

		/// <summary>
		///       当前文件名
		///       </summary>
		public string Location
		{
			get
			{
				if (_WriterControl != null)
				{
					return _WriterControl.Document.FileName;
				}
				return null;
			}
		}

		/// <summary>
		///       状态栏文本
		///       </summary>
		public object StatusText
		{
			get
			{
				if (WriterControl != null)
				{
					return WriterControl.StatusText;
				}
				return null;
			}
			set
			{
				if (WriterControl != null)
				{
					WriterControl.SetStatusText(GetDisplayText(value));
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public WriterWindow()
		{
			base.systemName = "DCWriter";
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="showUI">是否显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <returns>返回值</returns>
		public object ExecuteCommand(string commandName, bool showUI, object parameter)
		{
			if (WriterControl == null)
			{
				return null;
			}
			return WriterControl.ExecuteCommand(commandName, showUI, parameter);
		}

		/// <summary>
		///       打印文件
		///       </summary>
		public void Print()
		{
			if (_WriterControl != null)
			{
				_WriterControl.PrintDocument();
			}
		}

		/// <summary>
		///       打开文件
		///       </summary>
		/// <param name="fileName">
		/// </param>
		public void Open(string fileName)
		{
			if (_WriterControl != null)
			{
				_WriterControl.LoadDocument(fileName, null);
			}
		}
	}
}
