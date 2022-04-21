using DCSoft.Common;
using DCSoft.WinForms.Controls;
using DCSoft.WinForms.Native;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       用户界面工具箱
	///       </summary>
	[ComVisible(false)]
	
	public class DCUITools
	{
		/// <summary>
		///       修正父窗体对象
		///       </summary>
		/// <param name="parent">
		/// </param>
		/// <returns>
		/// </returns>
		private IWin32Window FixParent(IWin32Window parent)
		{
			if (parent == null)
			{
				return null;
			}
			if (parent is Control)
			{
				Control control = (Control)parent;
				if (control.IsDisposed)
				{
					return null;
				}
			}
			return parent;
		}

		/// <summary>
		///       显示一个文本对话框
		///       </summary>
		/// <param name="parent">对话框父窗体</param>
		/// <param name="txt">文本值</param>
		/// <param name="title">标题</param>
		public virtual void ShowTextDialog(IWin32Window parent, string string_0, string title)
		{
			using (dlgMultiLines dlgMultiLines = new dlgMultiLines())
			{
				if (!string.IsNullOrEmpty(title))
				{
					dlgMultiLines.Text = title;
				}
				dlgMultiLines.InputText = string_0;
				dlgMultiLines.ShowDialog(FixParent(parent));
			}
		}

		/// <summary>
		///       输入一个URL地址
		///       </summary>
		/// <param name="parent">
		/// </param>
		/// <param name="title">
		/// </param>
		/// <param name="defaultUrl">
		/// </param>
		/// <returns>
		/// </returns>
		public virtual string InputURL(IWin32Window parent, string title, string defaultUrl)
		{
			using (dlgInputUrl dlgInputUrl = new dlgInputUrl())
			{
				dlgInputUrl.InputURL = defaultUrl;
				if (!string.IsNullOrEmpty(title))
				{
					dlgInputUrl.Text = title;
				}
				if (dlgInputUrl.ShowDialog(FixParent(parent)) == DialogResult.OK)
				{
					return dlgInputUrl.InputURL;
				}
			}
			return null;
		}

		/// <summary>
		///       显示一个单行文本输入框让用户输入。
		///       </summary>
		/// <param name="parent">对话框父窗体</param>
		/// <param name="msg">提示文本</param>
		/// <param name="defaultValue">默认值</param>
		/// <returns>用户输入的值</returns>
		public virtual string InputBox(IWin32Window parent, string string_0, string defaultValue)
		{
			return dlgInputBox.InputBox(FixParent(parent), WinFormsResources.SystemAlert, string_0, defaultValue);
		}

		/// <summary>
		///       显示一个对话框，然用户选择是或者否
		///       </summary>
		/// <param name="parent">对话框的父窗体</param>
		/// <param name="msg">提示文本</param>
		/// <returns>用户选择是则返回true，选择否则返回false。</returns>
		public virtual bool Confirm(IWin32Window parent, string string_0)
		{
			return MessageBox.Show(FixParent(parent), string_0, WinFormsResources.SystemAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		/// <summary>
		///       显示一个对话框，然用户选择是或者否,而且默认按钮是否。
		///       </summary>
		/// <param name="parent">对话框的父窗体</param>
		/// <param name="msg">提示文本</param>
		/// <returns>用户选择是则返回true，选择否则返回false。</returns>
		public virtual bool ConfirmDefaultNo(IWin32Window parent, string string_0)
		{
			return MessageBox.Show(FixParent(parent), string_0, WinFormsResources.SystemAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
		}

		/// <summary>
		///       显示包含是、否、取消三个按钮的消息框
		///       </summary>
		/// <param name="parent">消息框父窗体</param>
		/// <param name="msg">提示文本</param>
		/// <returns>用户选择项目</returns>
		public virtual DialogResult ShowYesNoCancelMessageBox(IWin32Window parent, string string_0)
		{
			return MessageBox.Show(FixParent(parent), string_0, WinFormsResources.SystemAlert, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
		}

		/// <summary>
		///       显示一个普通的消息框
		///       </summary>
		/// <param name="parent">父窗体</param>
		/// <param name="msg">消息文本</param>
		public virtual void ShowMessageBox(IWin32Window parent, string string_0)
		{
			MessageBox.Show(FixParent(parent), string_0, WinFormsResources.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		/// <summary>
		///       显示一个警告的消息框
		///       </summary>
		/// <param name="parent">父窗体</param>
		/// <param name="msg">消息文本</param>
		public virtual void ShowWarringMessageBox(IWin32Window parent, string string_0)
		{
			MessageBox.Show(FixParent(parent), string_0, WinFormsResources.SystemWarring, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		/// <summary>
		///       显示一个错误的消息框
		///       </summary>
		/// <param name="parent">父窗体</param>
		/// <param name="msg">消息文本</param>
		public virtual void ShowErrorMessageBox(IWin32Window parent, string string_0)
		{
			MessageBox.Show(FixParent(parent), string_0, WinFormsResources.SystemError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		/// <summary>
		///       显示一个颜色选择对话框来选择颜色值
		///       </summary>
		/// <param name="parent">父窗体</param>
		/// <param name="colorValue">颜色值</param>
		/// <returns>操作是否成功</returns>
		public virtual bool PickColor(IWin32Window parent, ref Color colorValue)
		{
			using (dlgDCColor dlgDCColor = new dlgDCColor())
			{
				dlgDCColor.ColorValue = colorValue;
				if (dlgDCColor.ShowDialog(FixParent(parent)) == DialogResult.OK)
				{
					colorValue = dlgDCColor.ColorValue;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       获得指定UI元素的合适的弹出位置，这个位置采用屏幕坐标
		///       </summary>
		/// <param name="uiElement">UI元素</param>
		/// <returns>弹出位置</returns>
		public virtual Point GetPopupPosition(object uiElement)
		{
			Point p;
			if (uiElement is Control)
			{
				Control control = (Control)uiElement;
				p = new Point(0, control.Height);
				return control.PointToScreen(p);
			}
			if (uiElement is ToolStripButton)
			{
				ToolStripButton toolStripButton = (ToolStripButton)uiElement;
				Control control = toolStripButton.GetCurrentParent();
				p = new Point(toolStripButton.Bounds.Left, toolStripButton.Bounds.Bottom);
				return control.PointToScreen(p);
			}
			return Point.Empty;
		}

		public void SetStatusText(string string_0)
		{
			WindowStatusInfo windowStatusInfo = new WindowStatusInfo();
			windowStatusInfo.Text = string_0;
			SetStatus(windowStatusInfo);
		}

		/// <summary>
		///       设置主窗体状态栏
		///       </summary>
		/// <param name="status">
		/// </param>
		public virtual void SetStatus(WindowStatusInfo status)
		{
		}
	}
}
