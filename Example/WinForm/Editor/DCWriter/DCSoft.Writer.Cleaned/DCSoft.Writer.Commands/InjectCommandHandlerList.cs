using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       注入到命令系统的处理委托对象列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	
	[ComVisible(false)]
	public class InjectCommandHandlerList
	{
		private List<InjectCommandHandlerInfo> _infos = new List<InjectCommandHandlerInfo>();

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public InjectCommandHandlerList()
		{
		}

		/// <summary>
		///       添加执行前运行的委托对象
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="handler">委托对象</param>
		
		public void AddBefore(string commandName, WriterCommandEventHandler handler)
		{
			InjectCommandHandlerInfo info = GetInfo(commandName, create: true);
			info.BeforeExecuteHandler = handler;
		}

		/// <summary>
		///       添加执行后运行的委托对象
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="handler">委托对象</param>
		
		public void AddAfter(string commandName, WriterCommandEventHandler handler)
		{
			InjectCommandHandlerInfo info = GetInfo(commandName, create: true);
			info.AfterExecuteHandler = handler;
		}

		/// <summary>
		///       执行前置注入的委托
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		public void ExecuteBefore(string commandName, object eventSender, WriterCommandEventArgs args)
		{
			GetBeforeHandler(commandName)?.Invoke(eventSender, args);
		}

		/// <summary>
		///       执行后置注入的委托
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		public void ExecuteAfter(string commandName, object eventSender, WriterCommandEventArgs args)
		{
			GetAfterHandler(commandName)?.Invoke(eventSender, args);
		}

		/// <summary>
		///       获得执行命令前运行的委托对象
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>获得的委托对象</returns>
		public WriterCommandEventHandler GetBeforeHandler(string commandName)
		{
			return GetInfo(commandName, create: false)?.BeforeExecuteHandler;
		}

		/// <summary>
		///       获得执行命令后运行的委托对象
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>获得的委托对象</returns>
		public WriterCommandEventHandler GetAfterHandler(string commandName)
		{
			return GetInfo(commandName, create: false)?.AfterExecuteHandler;
		}

		/// <summary>
		///       删除所有注入的委托对象
		///       </summary>
		
		public void Clear()
		{
			_infos.Clear();
		}

		/// <summary>
		///       获得指定命令名称的信息对象，命令名称不区分大小写
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="create">若未找到是否创建对象</param>
		/// <returns>找到的对象</returns>
		public InjectCommandHandlerInfo GetInfo(string commandName, bool create)
		{
			foreach (InjectCommandHandlerInfo info in _infos)
			{
				if (string.Compare(info.CommandName, commandName, ignoreCase: true) == 0)
				{
					return info;
				}
			}
			if (create)
			{
				InjectCommandHandlerInfo current = new InjectCommandHandlerInfo();
				current.CommandName = commandName;
				_infos.Add(current);
				return current;
			}
			return null;
		}
	}
}
