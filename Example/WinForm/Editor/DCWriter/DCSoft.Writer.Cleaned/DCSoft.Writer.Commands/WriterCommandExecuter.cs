#define DEBUG
using DCSoft.Common;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器命令功能执行对象
	///       </summary>
	/// <remarks>本控件用于将用户界面控件的事件转换为对系统命令的调用，并提供设计时的支持。
	///       本对象支持的用户界面控件有Button、TextBox、ComboBox、Menu、ToolStripItem、ToolStripButton、ToolStripTextBox、ToolStripComboBox、ToolSTripMenuItem等等
	///       编写 袁永福</remarks>
	[DCInternal]
	[ComVisible(false)]
	public class WriterCommandExecuter : WriterCommandExecuterBase
	{
		private EventHandler _ControlEventHandler = null;

		private EventHandler _ControlValueChangedHandler = null;

		private KeyEventHandler _ControlKeyDownEventHandler = null;

		private EventHandler _ControlValidateHandler = null;

		private EventHandler _ControlDropDownOpeningHandler = null;

		private bool _IsDisposed = false;

		/// <summary>
		///       已经绑定了事件的控件对象列表
		///       </summary>
		private ArrayList _BindingEventControls = new ArrayList();

		private Dictionary<string, Delegate> _CustomEventHandlers = new Dictionary<string, Delegate>();

		/// <summary>
		///       数值发生改变的控件列表
		///       </summary>
		private ArrayList _ValueModifiedControls = new ArrayList();

		/// <summary>
		///       正在处理用户界面事件的控件列表，使用本列表是为了防止递归调用
		///       </summary>
		private ArrayList _HandlingEventControls = new ArrayList();

		private bool _IsExecutingCommand = false;

		private bool bolIsUpdatingBindControlStatus = false;

		/// <summary>
		///       正在更新绑定命令的控件的状态
		///       </summary>
		private bool _UpdatingControlStates = false;

		/// <summary>
		///       文本编辑器控件
		///       </summary>
		private WriterControl EditControl => base.Controler.EditControl;

		/// <summary>
		///       正在处理的文档对象
		///       </summary>
		private XTextDocument Document => base.Controler.Document;

		/// <summary>
		///       命令容器对象
		///       </summary>
		private WriterCommandContainer CommandContainer => base.Controler.CommandContainer;

		/// <summary>
		///       对象已经被销毁掉了
		///       </summary>
		[Browsable(false)]
		public bool IsDisposed => _IsDisposed;

		private string BindingEventNames
		{
			get
			{
				return base.Controler.BindingEventNames;
			}
			set
			{
				base.Controler.BindingEventNames = value;
			}
		}

		/// <summary>
		///       正在执行命令功能
		///       </summary>
		private bool IsExecutingCommand => _IsExecutingCommand;

		/// <summary>
		///       正在更新用户界面控件状态
		///       </summary>
		private bool IsUpdatingBindControlStatus => bolIsUpdatingBindControlStatus;

		/// <summary>
		///       是否自动更新控件可见性
		///       </summary>
		private bool AutoUpdateButtonVisible
		{
			get
			{
				if (EditControl == null)
				{
					return true;
				}
				return EditControl.DocumentOptions.BehaviorOptions.AutoUpdateButtonVisible;
			}
		}

		/// <summary>
		///       允许启用无效命令延迟更新模式
		///       </summary>
		private bool EnableInvalidateMode
		{
			get
			{
				if (EditControl != null && WinFormUtils.GetApplicationStyle(EditControl) == GEnum65.const_1)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterCommandExecuter()
		{
			_ControlEventHandler = HandleControlExecuteCommandEvent;
			_ControlKeyDownEventHandler = HandleKeyDownEvent;
			_ControlValueChangedHandler = HandleControlValueChangedEvent;
			_ControlValidateHandler = HandleValidateEvent;
			_ControlDropDownOpeningHandler = HandleControlDropDownOpeningEvent;
		}

		/// <summary>
		///       设置命令相关的UI元素可见性
		///       </summary>
		/// <param name="commandName">命令名</param>
		/// <param name="visible">可见性</param>
		/// <returns>操作修改了UI元素的个数</returns>
		public override int SetCommandUIVisible(string commandName, bool visible)
		{
			int num = 1;
			if (string.IsNullOrEmpty(commandName))
			{
				return 0;
			}
			int num2 = 0;
			foreach (GClass127 bindingInfo in base.BindingInfos)
			{
				object obj = bindingInfo.method_0();
				if (obj != null && string.Compare(commandName, bindingInfo.method_2(), ignoreCase: true) == 0)
				{
					if (obj is Control)
					{
						Control control = (Control)obj;
						if (!control.IsDisposed)
						{
							control.Visible = visible;
							num2++;
						}
					}
					else if (obj is ToolStripItem)
					{
						ToolStripItem toolStripItem = (ToolStripItem)obj;
						if (!toolStripItem.IsDisposed)
						{
							toolStripItem.Visible = visible;
							num2++;
						}
					}
					else
					{
						try
						{
							PropertyInfo property = obj.GetType().GetProperty("Visible", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
							if (property != null)
							{
								property.SetValue(obj, visible, null);
								num2++;
							}
						}
						catch (Exception ex)
						{
							Debug.WriteLine("SetCommandUIVisible:" + ex.Message);
						}
					}
				}
			}
			return num2;
		}

		/// <summary>
		///       关闭对象
		///       </summary>
		public override void Close()
		{
			if (_HandlingEventControls != null)
			{
				_HandlingEventControls.Clear();
			}
			if (_ValueModifiedControls != null)
			{
				_ValueModifiedControls.Clear();
			}
			_CustomEventHandlers = null;
			_ControlEventHandler = null;
			_ControlKeyDownEventHandler = null;
			_ControlValidateHandler = null;
			_ControlValueChangedHandler = null;
		}

		public override void BindingEvent(object object_0, GClass127 info)
		{
			int num = 9;
			if (base.DesignMode)
			{
				return;
			}
			if (object_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (_BindingEventControls.Contains(object_0))
			{
				return;
			}
			_BindingEventControls.Add(object_0);
			if (info != null && !string.IsNullOrEmpty(info.method_4()))
			{
				EventInfo @event = object_0.GetType().GetEvent(info.method_4(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
				if (@event != null)
				{
					Delegate @delegate = GClass109.smethod_0(_ControlEventHandler, @event.EventHandlerType);
					info.method_9(@delegate);
					if ((object)@delegate != null)
					{
						@event.AddEventHandler(object_0, @delegate);
					}
				}
				else
				{
					Debug.WriteLine(object_0.GetType().FullName + " 不存在事件 " + info.method_4());
				}
				return;
			}
			if (_CustomEventHandlers.Count > 0)
			{
				bool flag = false;
				foreach (string key in _CustomEventHandlers.Keys)
				{
					EventInfo @event = object_0.GetType().GetEvent(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (@event != null)
					{
						Delegate @delegate = _CustomEventHandlers[key];
						if (@event.EventHandlerType.Equals(@delegate.GetType()))
						{
							@event.AddEventHandler(object_0, @delegate);
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					return;
				}
			}
			if (object_0 is ComboBox)
			{
				ComboBox comboBox = (ComboBox)object_0;
				comboBox.SelectedIndexChanged += _ControlEventHandler;
				comboBox.KeyDown += _ControlKeyDownEventHandler;
				comboBox.Validated += _ControlValidateHandler;
				comboBox.SelectedValueChanged += _ControlValueChangedHandler;
				comboBox.TextChanged += _ControlValueChangedHandler;
			}
			else if (object_0 is TextBox)
			{
				TextBox textBox = (TextBox)object_0;
				if (!textBox.Multiline)
				{
					textBox.KeyDown += _ControlKeyDownEventHandler;
				}
				textBox.Validated += _ControlValidateHandler;
				textBox.TextChanged += _ControlValueChangedHandler;
			}
			else if (object_0 is Button)
			{
				((Button)object_0).Click += _ControlEventHandler;
			}
			else if (object_0 is Control)
			{
				((Control)object_0).Click += _ControlEventHandler;
			}
			else if (object_0 is ToolStripComboBox)
			{
				ToolStripComboBox toolStripComboBox = (ToolStripComboBox)object_0;
				toolStripComboBox.SelectedIndexChanged += _ControlEventHandler;
				toolStripComboBox.KeyDown += _ControlKeyDownEventHandler;
				toolStripComboBox.Validated += _ControlValidateHandler;
				toolStripComboBox.ComboBox.SelectedValueChanged += _ControlValueChangedHandler;
				toolStripComboBox.TextChanged += _ControlValueChangedHandler;
			}
			else if (object_0 is ToolStripTextBox)
			{
				ToolStripTextBox toolStripTextBox = (ToolStripTextBox)object_0;
				toolStripTextBox.KeyDown += _ControlKeyDownEventHandler;
				toolStripTextBox.Validated += _ControlValidateHandler;
				toolStripTextBox.TextChanged += _ControlValueChangedHandler;
			}
			else if (object_0 is ToolStripItem)
			{
				((ToolStripItem)object_0).Click += _ControlEventHandler;
			}
			else if (object_0 is MenuItem)
			{
				((MenuItem)object_0).Click += _ControlEventHandler;
			}
			else
			{
				DynamicBindingEvent(object_0, binding: true);
			}
		}

		public override void UnBindingEvent(object object_0, GClass127 info)
		{
			if (object_0 != null)
			{
				try
				{
					if (info != null && !string.IsNullOrEmpty(info.method_4()))
					{
						EventInfo @event = object_0.GetType().GetEvent(info.method_4(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
						if (@event != null && (object)info.method_8() != null)
						{
							@event.RemoveEventHandler(object_0, info.method_8());
						}
					}
					else if (_BindingEventControls.Contains(object_0))
					{
						_BindingEventControls.Remove(object_0);
						if (_CustomEventHandlers.Count <= 0)
						{
							goto IL_0118;
						}
						bool flag = false;
						foreach (string key in _CustomEventHandlers.Keys)
						{
							EventInfo @event = object_0.GetType().GetEvent(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
							if (@event != null)
							{
								Delegate @delegate = _CustomEventHandlers[key];
								if (@event.EventHandlerType.Equals(@delegate.GetType()))
								{
									@event.RemoveEventHandler(object_0, @delegate);
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							goto IL_0118;
						}
					}
					goto end_IL_000c;
					IL_0118:
					if (object_0 is ComboBox)
					{
						ComboBox comboBox = (ComboBox)object_0;
						comboBox.SelectedIndexChanged -= _ControlEventHandler;
						comboBox.KeyDown -= _ControlKeyDownEventHandler;
						comboBox.Validated -= _ControlValidateHandler;
						comboBox.SelectedValueChanged -= _ControlValueChangedHandler;
						comboBox.TextChanged -= _ControlValueChangedHandler;
					}
					else if (object_0 is TextBox)
					{
						TextBox textBox = (TextBox)object_0;
						if (!textBox.Multiline)
						{
							textBox.KeyDown -= _ControlKeyDownEventHandler;
						}
						textBox.Validated -= _ControlValidateHandler;
						textBox.TextChanged -= _ControlValueChangedHandler;
					}
					else if (object_0 is Control)
					{
						((Control)object_0).Click -= _ControlEventHandler;
					}
					else if (object_0 is ToolStripTextBox)
					{
						ToolStripTextBox toolStripTextBox = (ToolStripTextBox)object_0;
						toolStripTextBox.KeyDown -= _ControlKeyDownEventHandler;
						toolStripTextBox.Validated -= _ControlValidateHandler;
						toolStripTextBox.TextChanged -= _ControlValueChangedHandler;
					}
					else if (object_0 is ToolStripComboBox)
					{
						ToolStripComboBox toolStripComboBox = (ToolStripComboBox)object_0;
						toolStripComboBox.SelectedIndexChanged -= _ControlEventHandler;
						toolStripComboBox.KeyDown -= _ControlKeyDownEventHandler;
						toolStripComboBox.Validated -= _ControlValidateHandler;
						if (toolStripComboBox.ComboBox != null)
						{
							toolStripComboBox.ComboBox.SelectedValueChanged -= _ControlValueChangedHandler;
						}
						toolStripComboBox.TextChanged -= _ControlValueChangedHandler;
					}
					else if (object_0 is ToolStripItem)
					{
						((ToolStripItem)object_0).Click -= _ControlEventHandler;
					}
					else if (object_0 is MenuItem)
					{
						((MenuItem)object_0).Click -= _ControlEventHandler;
					}
					else
					{
						DynamicBindingEvent(object_0, binding: false);
					}
					end_IL_000c:;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
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
		public override void SetCustomControlEventHandler(string eventName, Delegate handler)
		{
			int num = 10;
			if ((object)handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentNullException("eventName");
			}
			_CustomEventHandlers[eventName] = handler;
		}

		/// <summary>
		///       处理控件事件
		///       </summary>
		/// <param name="sender">事件发起者</param>
		/// <param name="args">事件参数</param>
		private void HandleControlEvent(object sender, EventArgs e)
		{
			_ControlEventHandler(sender, e);
		}

		/// <summary>
		///       动态绑定对象事件
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="binding">
		/// </param>
		/// <returns>
		/// </returns>
		private bool DynamicBindingEvent(object object_0, bool binding)
		{
			int num = 10;
			if (object_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (!string.IsNullOrEmpty(BindingEventNames))
			{
				string[] array = BindingEventNames.Split(',');
				string[] array2 = array;
				foreach (string name in array2)
				{
					bool flag = false;
					Type type = object_0.GetType();
					while (type != null)
					{
						EventInfo @event = type.GetEvent(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
						if (@event == null)
						{
							type = type.BaseType;
							continue;
						}
						if (@event.EventHandlerType.Equals(typeof(EventHandler)))
						{
							if (binding)
							{
								@event.AddEventHandler(object_0, _ControlEventHandler);
							}
							else
							{
								@event.RemoveEventHandler(object_0, _ControlEventHandler);
							}
							flag = true;
						}
						break;
					}
					if (flag)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       处理控件内容发生改变事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void HandleControlValueChangedEvent(object sender, EventArgs e)
		{
			if (sender != null && !_ValueModifiedControls.Contains(sender))
			{
				_ValueModifiedControls.Add(sender);
			}
		}

		/// <summary>
		///       处理显示子菜单事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void HandleControlDropDownOpeningEvent(object sender, EventArgs e)
		{
		}

		/// <summary>
		///       处理验证控件数据内容事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void HandleValidateEvent(object sender, EventArgs e)
		{
			if (sender != null && _ValueModifiedControls.Contains(sender))
			{
				_ValueModifiedControls.Remove(sender);
				HandleControlExecuteCommandEvent(sender, e);
			}
		}

		/// <summary>
		///       处理控件按键按下事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void HandleKeyDownEvent(object sender, KeyEventArgs e)
		{
			if (sender != null && e != null && e.KeyCode == Keys.Return && !_HandlingEventControls.Contains(sender))
			{
				_HandlingEventControls.Add(sender);
				try
				{
					InnerExecuteControlCommand(sender, e);
				}
				finally
				{
					_HandlingEventControls.Remove(sender);
				}
			}
		}

		/// <summary>
		///       判断控件是否已经被销毁了
		///       </summary>
		/// <param name="control">控件对象</param>
		/// <returns>是否已经销毁了</returns>
		internal static bool IsControlDisposed(object control)
		{
			if (control is Control)
			{
				return ((Control)control).IsDisposed;
			}
			if (control is ToolStripItem)
			{
				return ((ToolStripItem)control).IsDisposed;
			}
			return false;
		}

		private GClass127 UIGetBindingInfo(object eventSender, EventArgs args)
		{
			int num = 12;
			GClass127 gClass = base.BindingInfos.method_0(eventSender, bool_0: false);
			if (gClass == null)
			{
				Type type = args.GetType();
				if (type.Namespace != null && type.Namespace.StartsWith("DevExpress."))
				{
					PropertyInfo property = type.GetProperty("Item", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (property != null)
					{
						object value = property.GetValue(args, null);
						gClass = base.BindingInfos.method_0(value, bool_0: false);
					}
				}
			}
			return gClass;
		}

		/// <summary>
		///       处理控件执行动作事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void HandleControlExecuteCommandEvent(object sender, EventArgs e)
		{
			if (_UpdatingControlStates || sender == null)
			{
				return;
			}
			GClass127 gClass = UIGetBindingInfo(sender, e);
			if (gClass != null)
			{
				if (IsControlDisposed(sender))
				{
					UnBindingEvent(sender, gClass);
					base.BindingInfos.Remove(gClass);
				}
				else if (!_HandlingEventControls.Contains(sender))
				{
					_HandlingEventControls.Add(sender);
					try
					{
						InnerExecuteControlCommand(sender, e);
					}
					finally
					{
						_HandlingEventControls.Remove(sender);
					}
				}
			}
		}

		/// <summary>
		///       执行指定的控件绑定的动作
		///       </summary>
		/// <param name="control">控件对象</param>
		private void ExecuteControlCommand(object control)
		{
			int num = 4;
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (base.BindingInfos.method_0(control, bool_0: false) != null)
			{
				InnerExecuteControlCommand(control, null);
			}
		}

		/// <summary>
		///       内部的执行控件绑定的动作对象
		///       </summary>
		/// <param name="eventSender">控件对象</param>
		/// <param name="args">用户界面事件参数</param>
		private void InnerExecuteControlCommand(object sender, EventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			if (_ValueModifiedControls.Contains(sender))
			{
				_ValueModifiedControls.Remove(sender);
			}
			GClass127 gClass = UIGetBindingInfo(sender, e);
			if (gClass == null)
			{
				return;
			}
			string text = gClass.method_2();
			text = text.Trim();
			if (text.Length != 0 && CommandContainer != null && !IsUpdatingBindControlStatus)
			{
				WriterCommand command = CommandContainer.GetCommand(text);
				if (command != null && command.Enable)
				{
					InnerExecuteCommand(command, sender, e, showUI: true, null, raiseFromUI: true);
				}
			}
		}

		private object InnerExecuteCommand(WriterCommand writerCommand_0, object uiControl, EventArgs eventArgs, bool showUI, object parameter, bool raiseFromUI)
		{
			if (writerCommand_0.FunctionID != 0 && !XTextDocument.smethod_13(writerCommand_0.FunctionID))
			{
				if (writerCommand_0.Descriptor != null)
				{
					return writerCommand_0.Descriptor.method_22();
				}
				return null;
			}
			WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(EditControl, Document, WriterCommandEventMode.QueryState, base.Controler);
			if (EditControl != null)
			{
				writerCommandEventArgs.Host = EditControl.AppHost;
			}
			else
			{
				writerCommandEventArgs.Host = WriterAppHost.Default;
			}
			writerCommandEventArgs.RaiseFromUI = raiseFromUI;
			writerCommandEventArgs.Name = writerCommand_0.Name;
			writerCommandEventArgs.UIElement = uiControl;
			writerCommandEventArgs.UIEventArgs = eventArgs;
			writerCommandEventArgs.ShowUI = showUI;
			writerCommandEventArgs.Parameter = parameter;
			writerCommandEventArgs.RaiseFromUI = raiseFromUI;
			writerCommandEventArgs.Mode = WriterCommandEventMode.QueryState;
			writerCommand_0.Invoke(writerCommandEventArgs);
			if (writerCommandEventArgs.UIElement != null)
			{
				ReadControlState(writerCommand_0.Name, writerCommandEventArgs);
			}
			if (writerCommandEventArgs.Enabled)
			{
				_IsExecutingCommand = true;
				writerCommandEventArgs.Mode = WriterCommandEventMode.Invoke;
				writerCommandEventArgs.Cancel = false;
				if (writerCommand_0.Descriptor != null)
				{
					writerCommandEventArgs.Result = writerCommand_0.Descriptor.method_22();
				}
				if (EditControl == null)
				{
					try
					{
						base.InjectHandlers.ExecuteBefore(writerCommand_0.Name, uiControl, writerCommandEventArgs);
						if (!writerCommandEventArgs.Cancel)
						{
							writerCommand_0.Invoke(writerCommandEventArgs);
							base.InjectHandlers.ExecuteAfter(writerCommand_0.Name, uiControl, writerCommandEventArgs);
						}
					}
					finally
					{
						_IsExecutingCommand = false;
					}
				}
				else if (EditControl.DocumentOptions.BehaviorOptions.HandleCommandException)
				{
					try
					{
						EditControl.vmethod_53(writerCommandEventArgs);
						if (writerCommandEventArgs.Cancel)
						{
							return writerCommandEventArgs.Result;
						}
						base.InjectHandlers.ExecuteBefore(writerCommand_0.Name, uiControl, writerCommandEventArgs);
						if (!writerCommandEventArgs.Cancel)
						{
							writerCommand_0.Invoke(writerCommandEventArgs);
							base.InjectHandlers.ExecuteAfter(writerCommand_0.Name, uiControl, writerCommandEventArgs);
						}
						EditControl.vmethod_52(writerCommandEventArgs);
					}
					catch (Exception exception_)
					{
						EditControl.vmethod_54(writerCommand_0, writerCommandEventArgs, exception_);
					}
					finally
					{
						_IsExecutingCommand = false;
					}
				}
				else
				{
					try
					{
						EditControl.vmethod_53(writerCommandEventArgs);
						if (writerCommandEventArgs.Cancel)
						{
							return writerCommandEventArgs.Result;
						}
						base.InjectHandlers.ExecuteBefore(writerCommand_0.Name, uiControl, writerCommandEventArgs);
						if (!writerCommandEventArgs.Cancel)
						{
							writerCommand_0.Invoke(writerCommandEventArgs);
							base.InjectHandlers.ExecuteAfter(writerCommand_0.Name, uiControl, writerCommandEventArgs);
						}
						EditControl.vmethod_52(writerCommandEventArgs);
					}
					finally
					{
						_IsExecutingCommand = false;
					}
				}
				if (writerCommandEventArgs.RefreshLevel == UIStateRefreshLevel.Current)
				{
					if (EditControl != null)
					{
						EditControl.CommandStateNeedRefreshFlag = true;
					}
					InvalidateCommandState(writerCommand_0.Name);
				}
				else if (writerCommandEventArgs.RefreshLevel == UIStateRefreshLevel.All)
				{
					if (EditControl != null)
					{
						EditControl.CommandStateNeedRefreshFlag = true;
						EditControl.DocumentControler.method_25();
					}
					InvalidateCommandState();
				}
				return writerCommandEventArgs.Result;
			}
			if (writerCommand_0.Descriptor != null)
			{
				return writerCommand_0.Descriptor.method_22();
			}
			return writerCommandEventArgs.Result;
		}

		/// <summary>
		///       判断是否支持指定名称的功能命令
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>是否支持功能命令</returns>
		public override bool IsCommandSupported(string commandName)
		{
			WriterCommand commandRaw = CommandContainer.GetCommandRaw(commandName);
			return commandRaw != null;
		}

		/// <summary>
		///       判断指定名称的命令是否可用
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>该命令是否可用</returns>
		public override bool IsCommandEnabled(string commandName)
		{
			WriterCommand command = CommandContainer.GetCommand(commandName);
			if (command != null)
			{
				WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(EditControl, Document, WriterCommandEventMode.QueryState, base.Controler);
				writerCommandEventArgs.ShowUI = true;
				command.Invoke(writerCommandEventArgs);
				return writerCommandEventArgs.Enabled;
			}
			return false;
		}

		/// <summary>
		///       判断指定名称的命令的状态是否处于选中状态
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <returns>该命令是否处于选中状态</returns>
		public override bool IsCommandChecked(string commandName)
		{
			WriterCommand command = CommandContainer.GetCommand(commandName);
			if (command != null)
			{
				WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(EditControl, Document, WriterCommandEventMode.QueryState, base.Controler);
				writerCommandEventArgs.ShowUI = true;
				command.Invoke(writerCommandEventArgs);
				return writerCommandEventArgs.Checked;
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
		public override object InnerExecuteCommand(string commandName, bool showUI, object parameter)
		{
			int num = 14;
			WriterCommand writerCommand = CommandContainer.GetCommand(commandName);
			if (writerCommand == null && EditControl != null)
			{
				writerCommand = EditControl.method_65();
			}
			if (writerCommand == null)
			{
				if (EditControl != null)
				{
					WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(EditControl, Document, WriterCommandEventMode.Invoke, base.Controler);
					writerCommandEventArgs.Name = commandName;
					WriterCommand writerCommand2 = new WriterCommandDelegate();
					writerCommand2.Name = commandName;
					if (string.IsNullOrEmpty(commandName))
					{
						EditControl.vmethod_54(writerCommand2, writerCommandEventArgs, new ArgumentNullException("commandName"));
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						foreach (WriterCommand allCommand in CommandContainer.AllCommands)
						{
							if (commandName.IndexOf(allCommand.Name, StringComparison.CurrentCultureIgnoreCase) >= 0 || allCommand.Name.IndexOf(commandName, StringComparison.CurrentCultureIgnoreCase) >= 0)
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append(",");
								}
								stringBuilder.Append(allCommand.Name);
							}
						}
						string message = string.Format(WriterStrings.InvalidateCommandName_Name_SimiliarNames, commandName, stringBuilder.ToString());
						EditControl.vmethod_54(writerCommand2, writerCommandEventArgs, new ArgumentException(message));
					}
				}
			}
			else if (writerCommand.Enable)
			{
				return InnerExecuteCommand(writerCommand, null, null, showUI, parameter, raiseFromUI: false);
			}
			return null;
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <param name="raiseFromUI">命令是普通用户界面操作而触发的</param>
		/// <returns>执行操作后的返回值</returns>
		public override object ExecuteCommandSpecifyRaiseFromUI(string commandName, bool showUI, object parameter, bool raiseFromUI)
		{
			WriterCommand writerCommand = CommandContainer.GetCommand(commandName);
			if (writerCommand == null && EditControl != null)
			{
				writerCommand = EditControl.method_65();
			}
			if (writerCommand != null)
			{
				return InnerExecuteCommand(writerCommand, null, null, showUI, parameter, raiseFromUI);
			}
			return null;
		}

		/// <summary>
		///       启动对象
		///       </summary>
		public override void Start()
		{
			if (!base.DesignMode)
			{
				WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(EditControl, Document, WriterCommandEventMode.QueryState, base.Controler);
				if (Document != null)
				{
					Document.FixDomState();
				}
				foreach (GClass127 bindingInfo in base.BindingInfos)
				{
					string text = bindingInfo.method_2();
					if (text != null && text.Trim().Length != 0)
					{
						text = text.Trim();
						if (!_BindingEventControls.Contains(bindingInfo.method_0()))
						{
							BindingEvent(bindingInfo.method_0(), bindingInfo);
						}
						WriterCommand command = CommandContainer.GetCommand(text);
						if (command != null)
						{
							writerCommandEventArgs.UIElement = bindingInfo.method_0();
							writerCommandEventArgs.Mode = WriterCommandEventMode.InitalizeUIElement;
							command.Invoke(writerCommandEventArgs);
						}
					}
				}
				InvalidateCommandState();
				if (EditControl == null)
				{
					UpdateBindingControlStatus(null);
				}
			}
		}

		/// <summary>
		///       读取控件状态
		///       </summary>
		/// <param name="commandName">
		/// </param>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		private bool ReadControlState(string commandName, WriterCommandEventArgs args)
		{
			if (EditControl == null || EditControl.InDesignMode)
			{
				return false;
			}
			WriterCommand command = CommandContainer.GetCommand(commandName);
			if (command == null)
			{
				return false;
			}
			bool result = false;
			object obj = args.UIElement;
			if (obj == null)
			{
				foreach (GClass127 bindingInfo in base.BindingInfos)
				{
					if (string.Compare(bindingInfo.method_2(), commandName, ignoreCase: true) == 0)
					{
						obj = bindingInfo.method_0();
					}
				}
			}
			if (obj != null)
			{
				args.Checked = WinFormUtils.smethod_13(obj);
				if (args.EnableSetUITextAsParamter)
				{
					args.Parameter = WinFormUtils.smethod_12(obj);
				}
			}
			return result;
		}

		/// <summary>
		///       更新控件状态
		///       </summary>
		/// <param name="control">
		/// </param>
		public override void UpdateBindingControlStatus(object control)
		{
			if (control == null)
			{
				return;
			}
			GClass127 gClass = base.BindingInfos.method_0(control, bool_0: false);
			if (gClass != null && !IsControlDisposed(control))
			{
				string commandName = gClass.method_2();
				WriterCommand command = CommandContainer.GetCommand(commandName);
				if (command != null)
				{
					try
					{
						bolIsUpdatingBindControlStatus = true;
						UpdateControlStates(control, command);
					}
					finally
					{
						bolIsUpdatingBindControlStatus = false;
					}
				}
			}
		}

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		/// <param name="specifyCommandName">指定的编辑器命令名称</param>
		public override void UpdateBindingControlStatus(string specifyCommandName = null)
		{
			try
			{
				bolIsUpdatingBindControlStatus = true;
				if (specifyCommandName != null)
				{
					specifyCommandName = specifyCommandName.Trim();
					if (specifyCommandName.Length == 0)
					{
						specifyCommandName = null;
					}
				}
				for (int num = base.BindingInfos.Count - 1; num >= 0; num--)
				{
					GClass127 gClass = base.BindingInfos[num];
					if (specifyCommandName != null)
					{
						if (string.Compare(gClass.method_2(), specifyCommandName, ignoreCase: true) == 0)
						{
							UpdateBindingControlStatusByInfo(gClass);
						}
					}
					else
					{
						UpdateBindingControlStatusByInfo(gClass);
					}
				}
			}
			finally
			{
				bolIsUpdatingBindControlStatus = false;
			}
		}

		/// <summary>
		///       更新绑定的控件的状态
		///       </summary>
		/// <param name="specifyCommandNames">指定的编辑器命令名称列表</param>
		public override void UpdateBindingControlStatusSpecifyCommandNames(List<string> specifyCommandNames)
		{
			if (specifyCommandNames != null && specifyCommandNames.Count != 0)
			{
				try
				{
					bolIsUpdatingBindControlStatus = true;
					for (int num = base.BindingInfos.Count - 1; num >= 0; num--)
					{
						GClass127 gClass = base.BindingInfos[num];
						foreach (string specifyCommandName in specifyCommandNames)
						{
							if (string.Compare(gClass.method_2(), specifyCommandName, ignoreCase: true) == 0)
							{
								UpdateBindingControlStatusByInfo(gClass);
								break;
							}
						}
					}
				}
				finally
				{
					bolIsUpdatingBindControlStatus = false;
				}
			}
		}

		private void UpdateBindingControlStatusByInfo(GClass127 info)
		{
			if (info == null)
			{
				return;
			}
			if (IsControlDisposed(info.method_0()))
			{
				base.BindingInfos.Remove(info);
				return;
			}
			info.method_7(bool_1: false);
			WriterCommand command = CommandContainer.GetCommand(info.method_2());
			if (command != null)
			{
				UpdateControlStates(info.method_0(), command);
			}
		}

		/// <summary>
		///       声明指定名称的命令状态无效，需要更新
		///       </summary>
		/// <param name="commandName">命令名称</param>
		public override void InvalidateCommandState(string commandName)
		{
			if (commandName != null)
			{
				commandName = commandName.Trim();
			}
			if (EnableInvalidateMode)
			{
				foreach (GClass127 bindingInfo in base.BindingInfos)
				{
					if (string.Compare(bindingInfo.method_2(), commandName, ignoreCase: true) == 0)
					{
						bindingInfo.method_7(bool_1: true);
					}
				}
			}
			else
			{
				UpdateBindingControlStatus(commandName);
			}
		}

		/// <summary>
		///       声明所有的命令的状态无效，需要更新
		///       </summary>
		public override void InvalidateCommandState()
		{
			if (EnableInvalidateMode && EditControl != null)
			{
				foreach (GClass127 bindingInfo in base.BindingInfos)
				{
					bindingInfo.method_7(bool_1: true);
				}
			}
			else
			{
				UpdateBindingControlStatus(null);
			}
		}

		/// <summary>
		///       更新所有状态无效的命令的状态
		///       </summary>
		public override void UpdateInvalidatedCommandState()
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			for (int num = base.BindingInfos.Count - 1; num >= 0; num--)
			{
				GClass127 gClass = base.BindingInfos[num];
				if (gClass.method_6())
				{
					UpdateBindingControlStatusByInfo(gClass);
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void UpdateControlStates(object control, WriterCommand command)
		{
			int num = 5;
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			try
			{
				_UpdatingControlStates = true;
				WriterCommandEventArgs writerCommandEventArgs = new WriterCommandEventArgs(EditControl, Document, WriterCommandEventMode.QueryState, base.Controler);
				writerCommandEventArgs.UIElement = control;
				command.Invoke(writerCommandEventArgs);
				if (command == null)
				{
					WinFormUtils.smethod_7(control, bool_0: false);
				}
				else
				{
					WinFormUtils.smethod_7(control, writerCommandEventArgs.Enabled);
					WinFormUtils.smethod_14(control, writerCommandEventArgs.Checked);
					if (writerCommandEventArgs.SetParameterToUIText)
					{
						WinFormUtils.smethod_11(control, Convert.ToString(writerCommandEventArgs.Parameter));
					}
				}
				writerCommandEventArgs.Mode = WriterCommandEventMode.UpdateUIElement;
				writerCommandEventArgs.UIElement = control;
				command.Invoke(writerCommandEventArgs);
			}
			finally
			{
				_UpdatingControlStates = false;
			}
		}

		private void UpdateCustomControlState(object control, WriterCommand command, WriterCommandEventArgs args)
		{
			int num = 8;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = command.Name != "FontName" && command.Name != "FontSize";
			Type type = control.GetType();
			while (type != null)
			{
				PropertyInfo propertyInfo = null;
				if (!flag)
				{
					propertyInfo = type.GetProperty("Enabled", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (propertyInfo != null && propertyInfo.CanWrite)
					{
						propertyInfo.SetValue(control, args.Enabled, null);
						flag = true;
					}
				}
				if (!flag2 && AutoUpdateButtonVisible)
				{
					propertyInfo = type.GetProperty("Visible", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (propertyInfo != null && propertyInfo.CanWrite)
					{
						propertyInfo.SetValue(control, args.Visible, null);
						flag2 = true;
					}
				}
				if (!flag3)
				{
					propertyInfo = type.GetProperty("Checked", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (propertyInfo != null && propertyInfo.CanWrite)
					{
						propertyInfo.SetValue(control, args.Checked, null);
						flag3 = true;
					}
				}
				if (!flag4)
				{
					propertyInfo = type.GetProperty("Text", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (propertyInfo != null && propertyInfo.CanWrite)
					{
						propertyInfo.SetValue(control, Convert.ToString(args.Parameter), null);
						flag4 = true;
					}
				}
				if (!flag || !flag2 || !flag3 || !flag4)
				{
					type = type.BaseType;
					continue;
				}
				break;
			}
		}
	}
}
