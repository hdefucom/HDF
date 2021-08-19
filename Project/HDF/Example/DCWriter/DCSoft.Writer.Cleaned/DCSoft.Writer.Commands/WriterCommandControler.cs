using DCSoft.Common;
using DCSoft.Design;
using DCSoft.Writer.Commands.Design;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       命令控制对象
	///       </summary>
	/// <remarks>本控件用于将用户界面控件的事件转换为对系统命令的调用，并提供设计时的支持。
	///       本对象支持的用户界面控件有Button、TextBox、ComboBox、Menu、ToolStripItem、ToolStripButton、ToolStripTextBox、ToolStripComboBox、ToolSTripMenuItem等等
	///       编写 袁永福</remarks>
	[ProvideProperty("CommandName", typeof(Component))]
	[ToolboxBitmap(typeof(WriterCommandControler))]
	[DCPublishAPI]
	[ToolboxItem(true)]
	[ComVisible(false)]
	[DocumentComment]
	[ProvideProperty("EventName", typeof(Component))]
	public class WriterCommandControler : Component, ISupportInitialize, IExtenderProvider
	{
		private WriterCommandExecuterBase writerCommandExecuterBase_0 = null;

		[NonSerialized]
		private WriterControl writerControl_0 = null;

		private WriterCommandContainer writerCommandContainer_0 = null;

		private GClass126 gclass126_0 = new GClass126();

		private bool bool_0 = false;

		private string string_0 = "Click,SelectedIndexChanged";

		private WriterCommandExecuterBase Executer
		{
			get
			{
				int num = 3;
				if (writerCommandExecuterBase_0 == null)
				{
					Type typeByName = DesignUtils.GetTypeByName("DCSoft.Writer.Commands.WriterCommandExecuter");
					if (typeByName == null)
					{
						return null;
					}
					writerCommandExecuterBase_0 = (WriterCommandExecuterBase)Activator.CreateInstance(typeByName);
				}
				writerCommandExecuterBase_0.Controler = this;
				return writerCommandExecuterBase_0;
			}
		}

		internal bool DesignModePublic => base.DesignMode;

		/// <summary>
		///       文本编辑器控件
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public WriterControl EditControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       正在处理的文档对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextDocument Document
		{
			get
			{
				if (writerControl_0 != null)
				{
					return writerControl_0.Document;
				}
				return null;
			}
		}

		/// <summary>
		///       命令容器对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public WriterCommandContainer CommandContainer
		{
			get
			{
				if (writerCommandContainer_0 == null)
				{
					writerCommandContainer_0 = new WriterCommandContainer();
				}
				return writerCommandContainer_0;
			}
			set
			{
				writerCommandContainer_0 = value;
			}
		}

		/// <summary>
		///       UI控件事件绑定信息对象
		///       </summary>
		internal GClass126 BindingInfos
		{
			get
			{
				if (gclass126_0 == null)
				{
					gclass126_0 = new GClass126();
				}
				return gclass126_0;
			}
		}

		/// <summary>
		///       对象已经被销毁掉了
		///       </summary>
		[Browsable(false)]
		public bool IsDisposed => bool_0;

		/// <summary>
		///       绑定的事件名称
		///       </summary>
		[Browsable(false)]
		[Obsolete("!!!请使用控件附加的EventName属性。")]
		[DefaultValue("Click,SelectedIndexChanged")]
		public string BindingEventNames
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       注入的编辑器命令中的委托对象列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public InjectCommandHandlerList InjectHandlers
		{
			get
			{
				if (Executer != null)
				{
					return Executer.InjectHandlers;
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterCommandControler()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="c">组件容器对象</param>
		public WriterCommandControler(IContainer icontainer_0)
			: this()
		{
			icontainer_0?.Add(this);
		}

		/// <summary>
		///       判断对象能否被添加扩展属性
		///       </summary>
		/// <param name="extendee">要处理的对象</param>
		/// <returns>能否添加扩展属性</returns>
		public bool CanExtend(object extendee)
		{
			if (extendee is WriterCommandControler || extendee is WriterControl)
			{
				return false;
			}
			return extendee is Control || extendee is ToolStripItem || extendee is MenuItem || extendee is Component;
		}

		/// <summary>
		///       获得指定名称的命令对象
		///       </summary>
		/// <param name="name">命令名称</param>
		/// <returns>获得的对象</returns>
		[DCPublishAPI]
		public WriterCommand GetCommand(string name)
		{
			return CommandContainer.GetCommandRaw(name);
		}

		/// <summary>
		///       获得绑定的动作名称
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <returns>获得的动作名称</returns>
		[DCPublishAPI]
		[DefaultValue(null)]
		[Editor(typeof(EventNameUIEditor), typeof(UITypeEditor))]
		public string GetEventName(Component component_0)
		{
			return BindingInfos.method_0(component_0, bool_0: false)?.method_4();
		}

		/// <summary>
		///       设置绑定的动作名称
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="eventName">动作名称</param>
		[DefaultValue(null)]
		[DCPublishAPI]
		[Editor(typeof(EventNameUIEditor), typeof(UITypeEditor))]
		public void SetEventName(Component component_0, string eventName)
		{
			int num = 19;
			if (component_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (eventName != null)
			{
				eventName = eventName.Trim();
			}
			GClass127 gClass = BindingInfos.method_0(component_0, bool_0: true);
			gClass.method_5(eventName);
		}

		/// <summary>
		///       获得绑定的动作名称
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <returns>获得的动作名称</returns>
		[DefaultValue(null)]
		[Editor(typeof(WriterCommandNameDlgEditor), typeof(UITypeEditor))]
		public string GetCommandName(Component component_0)
		{
			return BindingInfos.method_0(component_0, bool_0: false)?.method_2();
		}

		/// <summary>
		///       设置绑定的动作名称
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="commandName">动作名称</param>
		[Editor(typeof(WriterCommandNameDlgEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		[DCPublishAPI]
		public void SetCommandName(Component component_0, string commandName)
		{
			int num = 11;
			if (component_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (commandName != null)
			{
				commandName = commandName.Trim();
			}
			GClass127 gClass = BindingInfos.method_0(component_0, bool_0: false);
			if (string.IsNullOrEmpty(commandName))
			{
				if (gClass != null)
				{
					BindingInfos.Remove(gClass);
				}
				return;
			}
			if (gClass == null)
			{
				gClass = BindingInfos.method_0(component_0, bool_0: true);
			}
			gClass.method_3(commandName);
		}

		/// <summary>
		///       设置绑定的动作名称并绑定事件
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="commandName">动作名称</param>
		public void SetCommandNameAndBindgEvent(Component component_0, string commandName)
		{
			int num = 10;
			if (component_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			SetCommandName(component_0, commandName);
			method_0(component_0, null);
		}

		/// <summary>
		///       设置命令相关的UI元素可见性
		///       </summary>
		/// <param name="commandName">命令名</param>
		/// <param name="visible">可见性</param>
		/// <returns>操作修改了UI元素的个数</returns>
		public int SetCommandUIVisible(string commandName, bool visible)
		{
			if (Executer == null)
			{
				return 0;
			}
			return Executer.SetCommandUIVisible(commandName, visible);
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		/// <param name="disposing">
		/// </param>
		protected override void Dispose(bool disposing)
		{
			bool_0 = true;
			if (gclass126_0 != null && gclass126_0.Count > 0)
			{
				lock (gclass126_0)
				{
					foreach (GClass127 item in gclass126_0)
					{
						method_1(item.method_0(), item);
					}
					gclass126_0.Clear();
				}
			}
			writerCommandContainer_0 = null;
			if (writerCommandExecuterBase_0 != null)
			{
				writerCommandExecuterBase_0.Close();
				writerCommandExecuterBase_0 = null;
			}
			base.Dispose(disposing);
		}

		private void method_0(object object_0, GClass127 gclass127_0)
		{
			if (object_0 != null && Executer != null)
			{
				Executer.BindingEvent(object_0, gclass127_0);
			}
		}

		private void method_1(object object_0, GClass127 gclass127_0)
		{
			if (object_0 != null && writerCommandExecuterBase_0 != null)
			{
				writerCommandExecuterBase_0.UnBindingEvent(object_0, gclass127_0);
			}
		}

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
		[ComVisible(false)]
		public void SetCustomControlEventHandler(string eventName, Delegate handler)
		{
			if (Executer != null)
			{
				Executer.SetCustomControlEventHandler(eventName, handler);
			}
		}

		/// <summary>
		///       判断是否支持指定名称的功能命令
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>是否支持功能命令</returns>
		public bool IsCommandSupported(string commandName)
		{
			if (Executer != null)
			{
				return Executer.IsCommandSupported(commandName);
			}
			return false;
		}

		/// <summary>
		///       判断指定名称的命令是否可用
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>该命令是否可用</returns>
		public bool IsCommandEnabled(string commandName)
		{
			if (Executer != null)
			{
				return Executer.IsCommandEnabled(commandName);
			}
			return false;
		}

		/// <summary>
		///       判断指定名称的命令的状态是否处于选中状态
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>该命令是否处于选中状态</returns>
		public bool IsCommandChecked(string commandName)
		{
			if (Executer != null)
			{
				return Executer.IsCommandChecked(commandName);
			}
			return false;
		}

		/// <summary>
		///       DCWriter内部使用。执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <returns>执行操作后的返回值</returns>
		[DCInternal]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object InnerExecuteCommand(string commandName, bool showUI, object parameter)
		{
			if (Executer != null)
			{
				return Executer.InnerExecuteCommand(commandName, showUI, parameter);
			}
			return null;
		}

		public object method_2(string string_1, bool bool_1, object object_0, bool bool_2)
		{
			if (Executer != null)
			{
				return Executer.ExecuteCommandSpecifyRaiseFromUI(string_1, bool_1, object_0, bool_2);
			}
			return null;
		}

		/// <summary>
		///       启动对象
		///       </summary>
		[DCPublishAPI]
		public void Start()
		{
			if (writerCommandContainer_0 == null)
			{
				writerCommandContainer_0 = WriterAppHost.Default.CommandContainer;
			}
			if (Executer != null)
			{
				Executer.Start();
			}
		}

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		public void UpdateBindingControlStatus()
		{
			UpdateBindingControlStatus(null);
		}

		/// <summary>
		///       更新控件状态
		///       </summary>
		/// <param name="control">
		/// </param>
		public void UpdateBindingControlStatus(object control)
		{
			if (Executer != null)
			{
				Executer.UpdateBindingControlStatus(control);
			}
		}

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		/// <param name="specifyCommandName">指定的编辑器命令名称</param>
		public void UpdateBindingControlStatus(string specifyCommandName)
		{
			if (Executer != null)
			{
				Executer.UpdateBindingControlStatus(specifyCommandName);
			}
		}

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		/// <param name="specifyCommandNames">指定的编辑器命令名称列表</param>
		public void UpdateBindingControlStatusSpecifyCommandNames(List<string> specifyCommandNames)
		{
			if (Executer != null)
			{
				Executer.UpdateBindingControlStatusSpecifyCommandNames(specifyCommandNames);
			}
		}

		/// <summary>
		///       声明指定名称的命令状态无效，需要更新
		///       </summary>
		/// <param name="commandName">命令名称</param>
		public void InvalidateCommandState(string commandName)
		{
			if (Executer != null)
			{
				Executer.InvalidateCommandState(commandName);
			}
		}

		/// <summary>
		///       声明所有的命令的状态无效，需要更新
		///       </summary>
		public void InvalidateCommandState()
		{
			if (Executer != null)
			{
				Executer.InvalidateCommandState();
			}
		}

		/// <summary>
		///       更新所有状态无效的命令的状态
		///       </summary>
		public void UpdateInvalidatedCommandState()
		{
			if (Executer != null)
			{
				Executer.UpdateInvalidatedCommandState();
			}
		}

		/// <summary>
		///       开始初始化对象
		///       </summary>
		public void BeginInit()
		{
		}

		/// <summary>
		///       结束初始化对象
		///       </summary>
		public void EndInit()
		{
		}
	}
}
