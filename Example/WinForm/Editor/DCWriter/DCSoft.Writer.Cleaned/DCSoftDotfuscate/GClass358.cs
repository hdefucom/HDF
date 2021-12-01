using DCSoft.Common;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DocumentComment]
	public class GClass358 : TraceListener
	{
		private delegate void Delegate6(string string_0);

		private TextBox textBox_0;

		private bool bool_0;

		private bool bool_1;

		private string string_0;

		private bool bool_2;

		private volatile Delegate6 delegate6_0;

		public GClass358(TextBox textBox_1)
		{
			int num = 6;
			textBox_0 = null;
			bool_0 = true;
			bool_1 = false;
			string_0 = "HH:mm:ss.fff|";
			bool_2 = false;
			delegate6_0 = null;
			
			if (textBox_1 == null)
			{
				throw new ArgumentNullException("txt");
			}
			textBox_0 = textBox_1;
			textBox_0.Disposed += textBox_0_Disposed;
		}

		private void textBox_0_Disposed(object sender, EventArgs e)
		{
			if (method_2())
			{
				method_1(bool_3: false);
			}
		}

		public bool method_0()
		{
			return Debug.Listeners.Contains(this);
		}

		public void method_1(bool bool_3)
		{
			if (Debug.Listeners.Contains(this) != bool_3)
			{
				if (bool_3)
				{
					Debug.Listeners.Add(this);
				}
				else
				{
					Debug.Listeners.Remove(this);
				}
			}
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public string method_6()
		{
			return string_0;
		}

		public void method_7(string string_1)
		{
			string_0 = string_1;
		}

		private void method_8()
		{
			if (bool_2)
			{
				if (method_4() && !string.IsNullOrEmpty(method_6()))
				{
					method_9(Environment.NewLine + DateTime.Now.ToString(method_6()));
				}
				else
				{
					method_9(Environment.NewLine);
				}
				bool_2 = false;
			}
		}

		public override void Write(string message)
		{
			if (textBox_0 != null && textBox_0.IsHandleCreated)
			{
				method_8();
				method_9(message);
			}
		}

		public override void WriteLine(string message)
		{
			if (textBox_0 != null && textBox_0.IsHandleCreated)
			{
				method_8();
				if (!string.IsNullOrEmpty(message))
				{
					method_9(message);
				}
				bool_2 = true;
			}
		}

		private void method_9(string string_1)
		{
			if (string.IsNullOrEmpty(string_1) || textBox_0.IsDisposed || textBox_0 == null)
			{
				return;
			}
			if (textBox_0.InvokeRequired)
			{
				if (delegate6_0 == null)
				{
					delegate6_0 = delegate(string string_1)
					{
						textBox_0.AppendText(string_1);
					};
				}
				textBox_0.BeginInvoke(delegate6_0, string_1);
			}
			else
			{
				textBox_0.AppendText(string_1);
			}
		}

		[CompilerGenerated]
		private void method_10(string string_1)
		{
			textBox_0.AppendText(string_1);
		}
	}
}
