using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器命令事件参数
	///       </summary>
	
	[ComClass("6AD3FF4B-9742-46A9-8136-ACCCF5F37825", "BFEFA60E-5F2D-4590-B8AA-5B9C9EF0D198")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterCommandEventArgs))]
	[Guid("6AD3FF4B-9742-46A9-8136-ACCCF5F37825")]
	
	public class WriterCommandEventArgs : EventArgs, IWriterCommandEventArgs
	{
		internal const string CLASSID = "6AD3FF4B-9742-46A9-8136-ACCCF5F37825";

		internal const string CLASSID_Interface = "BFEFA60E-5F2D-4590-B8AA-5B9C9EF0D198";

		private WriterCommandControler _CommandControler = null;

		private bool _RaiseFromUI = false;

		private string _Name = null;

		private WriterAppHost _Host = null;

		private XTextDocument _Document = null;

		[NonSerialized]
		private WriterControl _EditorControl = null;

		private WriterCommandEventMode _Mode = WriterCommandEventMode.QueryState;

		private bool bolAltKey = false;

		private bool bolCtlKey = false;

		private bool bolShiftKey = false;

		private Keys intKeyCode = Keys.None;

		internal char intKeyChar = '\0';

		private XTextElement _SourceElement = null;

		private bool _EnableSetUITextAsParamter = false;

		private bool _SetParameterToUIText = false;

		private object _Parameter = null;

		private bool _ShowUI = true;

		private object _UIElement = null;

		private object _UIEventArgs = null;

		private bool _Enabled = true;

		private bool _Visible = true;

		private bool _Checked = false;

		private bool _Actived = false;

		private bool _Cancel = false;

		private object _Result = null;

		private UIStateRefreshLevel _RefreshLevel = UIStateRefreshLevel.Current;

		/// <summary>
		///       命令控制器
		///       </summary>
		
		public WriterCommandControler CommandControler => _CommandControler;

		/// <summary>
		///       由于用户界面菜单按钮操作而触发命令
		///       </summary>
		
		public bool RaiseFromUI
		{
			get
			{
				return _RaiseFromUI;
			}
			set
			{
				_RaiseFromUI = value;
			}
		}

		/// <summary>
		///       命令名称
		///       </summary>
		
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		
		public WriterAppHost Host
		{
			get
			{
				return _Host;
			}
			set
			{
				_Host = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档内容控制器
		///       </summary>
		
		public DocumentControler DocumentControler
		{
			get
			{
				if (_EditorControl != null)
				{
					return _EditorControl.DocumentControler;
				}
				if (_Document != null)
				{
					return _Document.DocumentControler;
				}
				return null;
			}
		}

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		
		public WriterControl EditorControl => _EditorControl;

		/// <summary>
		///       命令回话容器对象
		///       </summary>
		
		public Dictionary<string, object> Session
		{
			get
			{
				if (_EditorControl == null)
				{
					return null;
				}
				return _EditorControl.method_8(Name);
			}
		}

		/// <summary>
		///       参数模式
		///       </summary>
		
		public WriterCommandEventMode Mode
		{
			get
			{
				return _Mode;
			}
			set
			{
				_Mode = value;
			}
		}

		/// <summary>
		///       用户是否按下了 Alt 键
		///       </summary>
		
		public bool AltKey
		{
			get
			{
				return bolAltKey;
			}
			set
			{
				bolAltKey = value;
			}
		}

		/// <summary>
		///       用户是否按下的 Ctl 键
		///       </summary>
		
		public bool CtlKey
		{
			get
			{
				return bolCtlKey;
			}
			set
			{
				bolCtlKey = value;
			}
		}

		/// <summary>
		///       用户是否按下了 Shift 键
		///       </summary>
		
		public bool ShiftKey
		{
			get
			{
				return bolShiftKey;
			}
			set
			{
				bolShiftKey = value;
			}
		}

		/// <summary>
		///       键盘按键值
		///       </summary>
		
		[ComVisible(false)]
		public Keys KeyCode
		{
			get
			{
				return intKeyCode;
			}
			set
			{
				intKeyCode = value;
			}
		}

		/// <summary>
		///       KeyCode的COM接口
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		
		public int KeyCodeValue
		{
			get
			{
				return (int)intKeyCode;
			}
			set
			{
				intKeyCode = (Keys)value;
			}
		}

		/// <summary>
		///       键盘字符值
		///       </summary>
		
		public char KeyChar => intKeyChar;

		/// <summary>
		///       执行动作相关的元素对象
		///       </summary>
		
		public XTextElement SourceElement
		{
			get
			{
				return _SourceElement;
			}
			set
			{
				_SourceElement = value;
			}
		}

		/// <summary>
		///       能否将用户界面元素的文本当做命令参数
		///       </summary>
		
		public bool EnableSetUITextAsParamter
		{
			get
			{
				return _EnableSetUITextAsParamter;
			}
			set
			{
				_EnableSetUITextAsParamter = value;
			}
		}

		/// <summary>
		///       是否将命令参数设置到UI界面元素的文本值
		///       </summary>
		
		public bool SetParameterToUIText
		{
			get
			{
				return _SetParameterToUIText;
			}
			set
			{
				_SetParameterToUIText = value;
			}
		}

		/// <summary>
		///       相关参数对象
		///       </summary>
		
		public object Parameter
		{
			get
			{
				return _Parameter;
			}
			set
			{
				_Parameter = value;
			}
		}

		/// <summary>
		///       允许显示图形化用户界面
		///       </summary>
		
		public bool ShowUI
		{
			get
			{
				return _ShowUI;
			}
			set
			{
				_ShowUI = value;
			}
		}

		/// <summary>
		///       触发动作的用户界面控件对象
		///       </summary>
		
		public object UIElement
		{
			get
			{
				return _UIElement;
			}
			set
			{
				_UIElement = value;
			}
		}

		/// <summary>
		///       触发动作时的用户界面事件参数对象
		///       </summary>
		
		public object UIEventArgs
		{
			get
			{
				return _UIEventArgs;
			}
			set
			{
				_UIEventArgs = value;
			}
		}

		/// <summary>
		///       动作是否可用
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
		///       对象是否可见
		///       </summary>
		
		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				_Visible = value;
			}
		}

		/// <summary>
		///       动作是否处于选择状态
		///       </summary>
		
		public bool Checked
		{
			get
			{
				return _Checked;
			}
			set
			{
				_Checked = value;
			}
		}

		/// <summary>
		///       动作是否处于激活状态
		///       </summary>
		
		public bool Actived
		{
			get
			{
				return _Actived;
			}
			set
			{
				_Actived = value;
			}
		}

		/// <summary>
		///       取消操作
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		/// <summary>
		///       命令返回值
		///       </summary>
		
		public object Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       用户界面命令控件刷新等级
		///       </summary>
		
		public UIStateRefreshLevel RefreshLevel
		{
			get
			{
				return _RefreshLevel;
			}
			set
			{
				_RefreshLevel = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="mode">命令模式</param>
		/// <param name="cmdCtl">控制器对象</param>
		
		public WriterCommandEventArgs(WriterControl writerControl_0, XTextDocument document, WriterCommandEventMode mode, WriterCommandControler cmdCtl)
		{
			_CommandControler = cmdCtl;
			_EditorControl = writerControl_0;
			if (_EditorControl != null)
			{
				_CommandControler = _EditorControl.CommandControler;
				_Host = _EditorControl.AppHost;
			}
			_Document = document;
			_Mode = mode;
		}

		/// <summary>
		///       编辑器控件的开始启用UI层编辑内容
		///       </summary>
		/// <returns>启动是否成功</returns>
		
		public bool UIStartEditContent()
		{
			return _EditorControl != null && _EditorControl.UIStartEditContent();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public WriterCommandEventArgs Clone()
		{
			return (WriterCommandEventArgs)MemberwiseClone();
		}
	}
}
