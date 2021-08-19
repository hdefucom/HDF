using DCSoft.Common;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       系统消息框显示者
	///       </summary>
	[DCInternal]
	[ComVisible(false)]
	public class MessageBoxShower
	{
		private delegate DialogResult MyShowHandler();

		private IWin32Window _Owner = null;

		private string _Text = null;

		private string _Caption = null;

		private MessageBoxButtons _Buttons = MessageBoxButtons.OK;

		private MessageBoxIcon _Icon = MessageBoxIcon.None;

		private MessageBoxDefaultButton _DefaultButton = MessageBoxDefaultButton.Button1;

		private MessageBoxOptions _Options = (MessageBoxOptions)0;

		private string _HelpFilePath = null;

		private HelpNavigator _Navigator = HelpNavigator.Index;

		public IWin32Window Owner
		{
			get
			{
				return _Owner;
			}
			set
			{
				_Owner = value;
			}
		}

		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		public string Caption
		{
			get
			{
				return _Caption;
			}
			set
			{
				_Caption = value;
			}
		}

		public MessageBoxButtons Buttons
		{
			get
			{
				return _Buttons;
			}
			set
			{
				_Buttons = value;
			}
		}

		public MessageBoxIcon Icon
		{
			get
			{
				return _Icon;
			}
			set
			{
				_Icon = value;
			}
		}

		public MessageBoxDefaultButton DefaultButton
		{
			get
			{
				return _DefaultButton;
			}
			set
			{
				_DefaultButton = value;
			}
		}

		public MessageBoxOptions Options
		{
			get
			{
				return _Options;
			}
			set
			{
				_Options = value;
			}
		}

		public string HelpFilePath
		{
			get
			{
				return _HelpFilePath;
			}
			set
			{
				_HelpFilePath = value;
			}
		}

		public HelpNavigator Navigator
		{
			get
			{
				return _Navigator;
			}
			set
			{
				_Navigator = value;
			}
		}

		public DialogResult ShowWithCheckInvoke()
		{
			if (Owner is Control)
			{
				Control control = (Control)Owner;
				if (control.InvokeRequired)
				{
					return InvokeShow(control);
				}
			}
			return Show();
		}

		public DialogResult Show()
		{
			if (_HelpFilePath != null && _HelpFilePath.Length > 0 && File.Exists(_HelpFilePath))
			{
				return MessageBox.Show(Owner, Text, Caption, Buttons, Icon, DefaultButton, Options, HelpFilePath, Navigator);
			}
			return MessageBox.Show(Owner, Text, Caption, Buttons, Icon, DefaultButton, Options);
		}

		public DialogResult InvokeShow(Control control_0)
		{
			int num = 18;
			if (control_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			return (DialogResult)control_0.Invoke(new MyShowHandler(Show), null);
		}
	}
}
