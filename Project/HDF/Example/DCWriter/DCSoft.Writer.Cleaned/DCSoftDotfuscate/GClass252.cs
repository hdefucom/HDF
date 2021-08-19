using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	public sealed class GClass252
	{
		public delegate string GDelegate9(string string_0);

		public static GDelegate9 gdelegate9_0 = null;

		private static DialogResult dialogResult_0 = DialogResult.OK;

		private static string string_0 = "系统提示";

		private static IWin32Window iwin32Window_0 = null;

		private static string smethod_0(string string_1)
		{
			if (gdelegate9_0 == null)
			{
				return string_1;
			}
			return gdelegate9_0(string_1);
		}

		public static DialogResult smethod_1()
		{
			return dialogResult_0;
		}

		public static string smethod_2()
		{
			return string_0;
		}

		public static void smethod_3(string string_1)
		{
			string_0 = string_1;
		}

		public static IWin32Window smethod_4()
		{
			return iwin32Window_0;
		}

		public static void smethod_5(IWin32Window iwin32Window_1)
		{
			iwin32Window_0 = iwin32Window_1;
		}

		public static void smethod_6(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public static void smethod_7(IWin32Window iwin32Window_1, string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_1, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public static void smethod_8(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static void smethod_9(IWin32Window iwin32Window_1, string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_1, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static void smethod_10(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public static bool smethod_11(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return dialogResult_0 == DialogResult.Yes;
		}

		public static bool smethod_12(IWin32Window iwin32Window_1, string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_1, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return dialogResult_0 == DialogResult.Yes;
		}

		public static DialogResult smethod_13(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			return dialogResult_0;
		}

		public static bool smethod_14(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
			return dialogResult_0 == DialogResult.Retry;
		}

		public static DialogResult smethod_15(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
			return dialogResult_0;
		}

		public static DialogResult smethod_16(string string_1)
		{
			dialogResult_0 = MessageBox.Show(iwin32Window_0, smethod_0(string_1), smethod_0(string_0), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			return dialogResult_0;
		}

		private GClass252()
		{
		}
	}
}
