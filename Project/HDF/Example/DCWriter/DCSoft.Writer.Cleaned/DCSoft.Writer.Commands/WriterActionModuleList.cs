using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       功能模块列表
	///       </summary>
	[ComVisible(false)]
	public class WriterActionModuleList : IEnumerable
	{
		private List<WriterCommandModule> _Modules = new List<WriterCommandModule>();

		private Dictionary<string, WriterCommand> _Commands = null;

		/// <summary>
		///       添加编辑器命令模块
		///       </summary>
		/// <param name="mdl">模块对象</param>
		public void AddModule(WriterCommandModule writerCommandModule_0)
		{
			int num = 18;
			if (writerCommandModule_0 == null)
			{
				throw new ArgumentNullException("mdl");
			}
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					WriterCommandModule writerCommandModule = (WriterCommandModule)enumerator.Current;
					if (writerCommandModule.GetType().Equals(writerCommandModule_0.GetType()))
					{
						return;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			_Modules.Add(writerCommandModule_0);
			_Commands = null;
		}

		/// <summary>
		///       不区分大小写的获得指定名称的命令对象
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>获得的命令对象</returns>
		internal WriterCommand GetCommandIgnorecase(string commandName)
		{
			if (_Commands == null)
			{
				_Commands = new Dictionary<string, WriterCommand>();
				{
					IEnumerator enumerator = GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							WriterCommandModule writerCommandModule = (WriterCommandModule)enumerator.Current;
							foreach (WriterCommand command in writerCommandModule.Commands)
							{
								string name = command.Name;
								if (!string.IsNullOrEmpty(name))
								{
									_Commands[name.ToLower()] = command;
								}
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(commandName))
			{
				WriterCommand current = null;
				if (_Commands.TryGetValue(commandName.ToLower(), out current))
				{
					return current;
				}
			}
			return null;
		}

		public IEnumerator GetEnumerator()
		{
			return _Modules.GetEnumerator();
		}
	}
}
