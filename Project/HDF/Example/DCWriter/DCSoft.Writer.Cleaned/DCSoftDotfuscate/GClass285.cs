using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	public class GClass285 : TextBox
	{
		private char[] char_0 = null;

		private char[] char_1 = null;

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = method_5(value);
			}
		}

		public char[] method_0()
		{
			return char_0;
		}

		public void method_1(char[] char_2)
		{
			char_0 = char_2;
		}

		public char[] method_2()
		{
			return char_1;
		}

		public void method_3(char[] char_2)
		{
			char_1 = char_2;
		}

		private bool method_4(char char_2)
		{
			if (char_0 != null)
			{
				char[] array = char_0;
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						char c = array[num];
						if (char_2 == c)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			if (char_1 != null)
			{
				char[] array = char_1;
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						char c = array[num];
						if (char_2 == c)
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return true;
		}

		private string method_5(string string_0)
		{
			if (char_0 != null || char_1 != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (char c in string_0)
				{
					if (method_4(c))
					{
						stringBuilder.Append(c);
					}
				}
				return stringBuilder.ToString();
			}
			return string_0;
		}

		protected override bool ProcessKeyEventArgs(ref Message message_0)
		{
			if (message_0.Msg == 258)
			{
				char c = (char)(int)message_0.WParam;
				if (c != '\b' && !method_4(c))
				{
					return true;
				}
			}
			return base.ProcessKeyEventArgs(ref message_0);
		}

		protected override void OnTextChanged(EventArgs eventArgs_0)
		{
			if (char_0 != null || char_1 != null)
			{
				string text = Text;
				string text2 = method_5(text);
				if (text != text2)
				{
					int selectionStart = base.SelectionStart;
					int selectionLength = SelectionLength;
					Text = text2;
					base.SelectionStart = selectionStart;
					SelectionLength = selectionLength;
				}
			}
			base.OnTextChanged(eventArgs_0);
		}
	}
}
