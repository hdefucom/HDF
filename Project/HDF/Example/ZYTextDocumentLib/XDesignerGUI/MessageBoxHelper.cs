using System.Windows.Forms;

namespace XDesignerGUI
{
	public sealed class MessageBoxHelper
	{
		public delegate string TranslateDelegate(string strText);

		public static TranslateDelegate TranslateHandler = null;

		private static DialogResult intLastResult = DialogResult.OK;

		private static string strTitle = "系统提示";

		private static IWin32Window myOwnerWindow = null;

		public static DialogResult LastResult => intLastResult;

		public static string Title
		{
			get
			{
				return strTitle;
			}
			set
			{
				strTitle = value;
			}
		}

		public static IWin32Window OwnerWindow
		{
			get
			{
				return myOwnerWindow;
			}
			set
			{
				myOwnerWindow = value;
			}
		}

		private static string Translate(string txt)
		{
			if (TranslateHandler == null)
			{
				return txt;
			}
			return TranslateHandler(txt);
		}

		public static void Alert(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public static void Alert(IWin32Window OwnerForm, string txt)
		{
			intLastResult = MessageBox.Show(OwnerForm, Translate(txt), Translate(strTitle), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public static void AlertExclamation(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static void AlertExclamation(IWin32Window OwnerForm, string txt)
		{
			intLastResult = MessageBox.Show(OwnerForm, Translate(txt), Translate(strTitle), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static void AlertStop(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public static bool ConFirm(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return intLastResult == DialogResult.Yes;
		}

		public static DialogResult Question(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			return intLastResult;
		}

		public static bool Retry(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
			return intLastResult == DialogResult.Retry;
		}

		public static DialogResult AbortRetryIgnore(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
			return intLastResult;
		}

		public static DialogResult YesNoCancel(string txt)
		{
			intLastResult = MessageBox.Show(myOwnerWindow, Translate(txt), Translate(strTitle), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			return intLastResult;
		}

		private MessageBoxHelper()
		{
		}
	}
}
