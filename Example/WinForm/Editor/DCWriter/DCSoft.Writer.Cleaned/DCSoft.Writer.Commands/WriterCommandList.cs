using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文本编辑器动作列表
	///       </summary>
	
	[ComVisible(false)]
	
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class WriterCommandList : List<WriterCommand>
	{
		/// <summary>
		///       获得指定名称的动作对象,名称比较不区分大小写
		///       </summary>
		public WriterCommand this[string name]
		{
			get
			{
				if (name == null)
				{
					return null;
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						WriterCommand current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: true) == 0)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       添加动作,添加前会删除列表中相同名称的动作
		///       </summary>
		/// <param name="a">动作对象</param>
		/// <returns>动作在列表中的需要</returns>
		public int AddCommand(WriterCommand writerCommand_0)
		{
			WriterCommand writerCommand = this[writerCommand_0.Name];
			if (writerCommand != null)
			{
				Remove(writerCommand);
			}
			Add(writerCommand_0);
			return base.Count - 1;
		}

		/// <summary>
		///       激活动作
		///       </summary>
		/// <param name="args">文档事件参数</param>
		/// <returns>激活的动作对象</returns>
		public WriterCommand Active(DocumentEventArgs args)
		{
			WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(args.Document.EditorControl, args.Document, WriterCommandEventMode.QueryState, null);
			writerCommandEventArgs.CtlKey = args.CtlKey;
			writerCommandEventArgs.ShiftKey = args.ShiftKey;
			writerCommandEventArgs.AltKey = args.AltKey;
			writerCommandEventArgs.KeyCode = args.KeyCode;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					WriterCommand current = enumerator.Current;
					current.Invoke(writerCommandEventArgs);
					if (writerCommandEventArgs.Enabled && writerCommandEventArgs.Actived)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
