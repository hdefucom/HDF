using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       注入到命令系统的委托信息
	///       </summary>
	[ComVisible(false)]
	public class InjectCommandHandlerInfo
	{
		private string _CommandName = null;

		private WriterCommandEventHandler _BeforeExecuteHandler = null;

		private WriterCommandEventHandler _AfterExecuteHandler = null;

		/// <summary>
		///       编辑器命令名称
		///       </summary>
		public string CommandName
		{
			get
			{
				return _CommandName;
			}
			set
			{
				_CommandName = value;
			}
		}

		/// <summary>
		///       在执行命令之前运行的委托
		///       </summary>
		public WriterCommandEventHandler BeforeExecuteHandler
		{
			get
			{
				return _BeforeExecuteHandler;
			}
			set
			{
				_BeforeExecuteHandler = value;
			}
		}

		/// <summary>
		///       在执行命令之后运行的委托
		///       </summary>
		public WriterCommandEventHandler AfterExecuteHandler
		{
			get
			{
				return _AfterExecuteHandler;
			}
			set
			{
				_AfterExecuteHandler = value;
			}
		}
	}
}
