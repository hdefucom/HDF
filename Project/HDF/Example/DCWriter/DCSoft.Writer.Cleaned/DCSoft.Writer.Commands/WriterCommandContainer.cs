using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器命令容器对象
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class WriterCommandContainer
	{
		private class CommandNameComparer : IComparer<WriterCommand>
		{
			public int Compare(WriterCommand writerCommand_0, WriterCommand writerCommand_1)
			{
				return string.Compare(writerCommand_0.Name, writerCommand_1.Name, ignoreCase: true);
			}
		}

		private WriterActionModuleList _Modules = new WriterActionModuleList();

		private WriterCommandList _Commands = new WriterCommandList();

		/// <summary>
		///       模块列表
		///       </summary>
		public WriterActionModuleList Modules => _Modules;

		/// <summary>
		///       动作列表
		///       </summary>
		public WriterCommandList Commands => _Commands;

		/// <summary>
		///       容器中所有的命令组成的列表，该列表是动态生成的对象实例.
		///       </summary>
		/// <remarks>
		///       该列表是动态生成的对象实例，也就是说即使是调用两次本属性获得的值其引用是不一样的。
		///       </remarks>
		public WriterCommandList AllCommands
		{
			get
			{
				WriterCommandList writerCommandList = new WriterCommandList();
				foreach (WriterCommandModule module in Modules)
				{
					foreach (WriterCommand command in module.Commands)
					{
						writerCommandList.AddCommand(command);
					}
				}
				if (Commands != null)
				{
					foreach (WriterCommand command2 in Commands)
					{
						writerCommandList.AddCommand(command2);
					}
				}
				writerCommandList.Sort(new CommandNameComparer());
				return writerCommandList;
			}
		}

		/// <summary>
		///       获得指定名称的动作对象
		///       </summary>
		/// <param name="commandName">
		/// </param>
		/// <returns>
		/// </returns>
		public WriterCommand GetCommandRaw(string commandName)
		{
			if (string.IsNullOrEmpty(commandName))
			{
				return null;
			}
			foreach (WriterCommand command in Commands)
			{
				if (string.Compare(command.Name, commandName, ignoreCase: true) == 0)
				{
					return command;
				}
			}
			foreach (WriterCommandModule module in Modules)
			{
				foreach (WriterCommand command2 in module.Commands)
				{
					if (string.Compare(command2.Name, commandName, ignoreCase: true) == 0)
					{
						return command2;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       获得指定名称的动作对象
		///       </summary>
		/// <param name="commandName">
		/// </param>
		/// <returns>
		/// </returns>
		public WriterCommand GetCommand(string commandName)
		{
			if (string.IsNullOrEmpty(commandName))
			{
				return null;
			}
			WriterCommand writerCommand = null;
			foreach (WriterCommand command in Commands)
			{
				if (string.Compare(command.Name, commandName, ignoreCase: true) == 0 && (writerCommand == null || writerCommand.Priority > command.Priority))
				{
					writerCommand = command;
				}
			}
			WriterCommand commandIgnorecase = Modules.GetCommandIgnorecase(commandName);
			if (writerCommand == null || writerCommand.Priority > commandIgnorecase.Priority)
			{
				writerCommand = commandIgnorecase;
			}
			return writerCommand;
		}

		/// <summary>
		///       根据键盘事件来获得被激活的动作对象
		///       </summary>
		/// <param name="editControl">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public WriterCommand Active(WriterControl editControl, XTextDocument document, KeyEventArgs args)
		{
			WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(editControl, document, WriterCommandEventMode.QueryState, null);
			writerCommandEventArgs.AltKey = args.Alt;
			writerCommandEventArgs.ShiftKey = args.Shift;
			writerCommandEventArgs.CtlKey = args.Control;
			writerCommandEventArgs.KeyCode = args.KeyCode;
			foreach (WriterCommand command in Commands)
			{
				if (command.EnableHotKey)
				{
					writerCommandEventArgs.Parameter = null;
					if (command.ShortcutKey != 0)
					{
						GClass111 gClass = new GClass111(command.ShortcutKey);
						if (gClass.method_2() == args.Alt && gClass.method_4() == args.Shift && gClass.method_0() == args.Control && gClass.method_6() == args.KeyCode)
						{
							writerCommandEventArgs.Enabled = true;
							writerCommandEventArgs.Actived = true;
							command.Invoke(writerCommandEventArgs);
							if (writerCommandEventArgs.Actived && writerCommandEventArgs.Enabled)
							{
								return command;
							}
						}
					}
					writerCommandEventArgs.Actived = false;
					command.Invoke(writerCommandEventArgs);
					if (writerCommandEventArgs.Enabled && writerCommandEventArgs.Actived)
					{
						return command;
					}
				}
			}
			foreach (WriterCommandModule module in Modules)
			{
				foreach (WriterCommand command2 in module.Commands)
				{
					if (command2.EnableHotKey)
					{
						writerCommandEventArgs.Parameter = null;
						if (command2.ShortcutKey != 0)
						{
							GClass111 gClass = new GClass111(command2.ShortcutKey);
							if (gClass.method_2() == args.Alt && gClass.method_4() == args.Shift && gClass.method_0() == args.Control && gClass.method_6() == args.KeyCode)
							{
								writerCommandEventArgs.Enabled = true;
								writerCommandEventArgs.Actived = true;
								command2.Invoke(writerCommandEventArgs);
								if (writerCommandEventArgs.Enabled && writerCommandEventArgs.Actived)
								{
									return command2;
								}
							}
						}
						writerCommandEventArgs.Actived = false;
						writerCommandEventArgs.Enabled = true;
						command2.Invoke(writerCommandEventArgs);
						if (writerCommandEventArgs.Enabled && writerCommandEventArgs.Actived)
						{
							return command2;
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		///       创建源代码
		///       </summary>
		/// <param name="fileName">
		/// </param>
		public void BuildWrapperSourceCode(string fileName)
		{
			int num = 3;
			using (StreamWriter streamWriter = new StreamWriter(fileName, append: false, Encoding.Default))
			{
				streamWriter.WriteLine("using System;\r\nusing System.Text;\r\nusing DCSoft.Writer.Controls;\r\nusing DCSoft.Writer.Commands;\r\nusing DCSoft.Writer;\r\n\r\nnamespace DCSoft.Writer.Extension\r\n{\r\n    /// <summary>\r\n    /// 编辑器控件命令包装器\r\n    /// </summary>\r\n    /// <remarks>本类型是编辑器控件ExecuteCommand方法的封装</remarks>\r\n    public class WriterCommandWrapper\r\n    {\r\n        /// <summary>\r\n        /// 初始化对象\r\n        /// </summary>\r\n        /// <param name='ctl'>编辑器控件</param>\r\n        public WriterCommandWrapper(WriterControl ctl)\r\n        {\r\n            if (ctl == null)\r\n            {\r\n                throw new ArgumentException('ctl');\r\n            }\r\n            _WriterControl = ctl;\r\n        }\r\n\r\n        private WriterControl _WriterControl = null;\r\n        /// <summary>\r\n        /// 编辑器控件\r\n        /// </summary>\r\n        public WriterControl WriterControl\r\n        {\r\n            get\r\n            {\r\n                return _WriterControl; \r\n            }\r\n        }");
				foreach (WriterCommand allCommand in AllCommands)
				{
					streamWriter.WriteLine("");
					streamWriter.WriteLine("public bool Is" + allCommand.Name + "Enabled{get{ return this.WriterControl.IsCommandEnabled(\"" + allCommand.Name + "\");}}");
					streamWriter.WriteLine("public bool Is" + allCommand.Name + "Checked{get{ return this.WriterControl.IsCommandChecked(\"" + allCommand.Name + "\");}}");
					streamWriter.WriteLine("public void " + allCommand.Name + "()\r\n{");
					streamWriter.WriteLine("this.WriterControl.ExecuteCommand(\"" + allCommand.Name + "\", true, null);");
					streamWriter.WriteLine("}");
				}
				streamWriter.WriteLine("\r\n    }\r\n}");
			}
		}
	}
}
