using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       命令控制对象
	///       </summary>
	/// <remarks>本控件用于将用户界面控件的事件转换为对系统命令的调用，并提供设计时的支持。
	///       本对象支持的用户界面控件有Button、TextBox、ComboBox、Menu、ToolStripItem、ToolStripButton、
	///       ToolStripTextBox、ToolStripComboBox、ToolSTripMenuItem等等
	///       编写 袁永福</remarks>
	
	[ComVisible(false)]
	public abstract class WriterCommandExecuterBase
	{
		private WriterCommandControler _Controler = null;

		private InjectCommandHandlerList _InjectHandlers = null;

		/// <summary>
		///       命令控制器对象
		///       </summary>
		public WriterCommandControler Controler
		{
			get
			{
				return _Controler;
			}
			set
			{
				_Controler = value;
			}
		}

		/// <summary>
		///       是否处于设计模式 
		///       </summary>
		protected bool DesignMode => _Controler.DesignModePublic;

		/// <summary>
		///       UI控件事件绑定信息对象
		///       </summary>
		protected GClass126 BindingInfos => Controler.BindingInfos;

		/// <summary>
		///       注入的编辑器命令中的委托对象列表
		///       </summary>
		public InjectCommandHandlerList InjectHandlers
		{
			get
			{
				if (_InjectHandlers == null)
				{
					_InjectHandlers = new InjectCommandHandlerList();
				}
				return _InjectHandlers;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterCommandExecuterBase()
		{
		}

		/// <summary>
		///       设置命令相关的UI元素可见性
		///       </summary>
		/// <param name="commandName">命令名</param>
		/// <param name="visible">可见性</param>
		/// <returns>操作修改了UI元素的个数</returns>
		public abstract int SetCommandUIVisible(string commandName, bool visible);

		/// <summary>
		///       关闭对象
		///       </summary>
		public abstract void Close();

		public abstract void BindingEvent(object object_0, GClass127 info);

		public abstract void UnBindingEvent(object object_0, GClass127 info);

		/// <summary>
		///       设置自定义的控件事件处理委托对象,本方法一定要在Start()方法前调用。
		///       </summary>
		/// <param name="eventName">事件名称</param>
		/// <param name="handler">委托对象</param>
		/// <remarks>
		///       比如
		///       DevExpress.XtraBars.ItemClickEventHandler handler = delegate(
		///       object sender2, 
		///          DevExpress.XtraBars.ItemClickEventArgs args2) 
		///          {
		///              writerCommandControler1.HandleControlEvent(sender2, args2);
		///          };
		///       writerCommandControler1.SetCustomControlEventHandler("ItemClick" , handler );
		///       writerCommandControler1.Start();
		///       </remarks>
		public abstract void SetCustomControlEventHandler(string eventName, Delegate handler);

		/// <summary>
		///       判断是否支持指定名称的功能命令
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>是否支持功能命令</returns>
		public abstract bool IsCommandSupported(string commandName);

		/// <summary>
		///       判断指定名称的命令是否可用
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>该命令是否可用</returns>
		public abstract bool IsCommandEnabled(string commandName);

		/// <summary>
		///       判断指定名称的命令的状态是否处于选中状态
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>该命令是否处于选中状态</returns>
		public abstract bool IsCommandChecked(string commandName);

		/// <summary>
		///       DCWriter内部使用。执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <returns>执行操作后的返回值</returns>
		public abstract object InnerExecuteCommand(string commandName, bool showUI, object parameter);

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <param name="raiseFromUI">命令是普通用户界面操作而触发的</param>
		/// <returns>执行操作后的返回值</returns>
		public abstract object ExecuteCommandSpecifyRaiseFromUI(string commandName, bool showUI, object parameter, bool raiseFromUI);

		/// <summary>
		///       启动对象
		///       </summary>
		public abstract void Start();

		/// <summary>
		///       更新控件状态
		///       </summary>
		/// <param name="control">
		/// </param>
		public abstract void UpdateBindingControlStatus(object control);

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		/// <param name="specifyCommandName">指定的编辑器命令名称</param>
		public abstract void UpdateBindingControlStatus(string specifyCommandName);

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		/// <param name="specifyCommandNames">指定的编辑器命令名称列表</param>
		public abstract void UpdateBindingControlStatusSpecifyCommandNames(List<string> specifyCommandNames);

		/// <summary>
		///       声明指定名称的命令状态无效，需要更新
		///       </summary>
		/// <param name="commandName">命令名称</param>
		public abstract void InvalidateCommandState(string commandName);

		/// <summary>
		///       声明所有的命令的状态无效，需要更新
		///       </summary>
		public abstract void InvalidateCommandState();

		/// <summary>
		///       更新所有状态无效的命令的状态
		///       </summary>
		public abstract void UpdateInvalidatedCommandState();
	}
}
