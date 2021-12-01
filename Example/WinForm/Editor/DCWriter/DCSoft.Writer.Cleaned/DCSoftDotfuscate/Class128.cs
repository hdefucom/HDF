using DCSoft.Common;
using DCSoft.Writer.Controls;
using System;
using System.Text;

namespace DCSoftDotfuscate
{
	[DCInternal]
	internal class Class128
	{
		private WriterViewControl writerViewControl_0 = null;

		private bool bool_0 = false;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		private int int_0 = 0;

		public Class128(WriterViewControl writerViewControl_1)
		{
			writerViewControl_0 = writerViewControl_1;
		}

		public void method_0()
		{
			writerViewControl_0 = null;
			stringBuilder_0 = null;
		}

		public bool method_1()
		{
			return bool_0;
		}

		public void method_2(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public void method_3(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				stringBuilder_0.Append(string_0);
			}
			method_5(bool_1: true);
		}

		public void method_4()
		{
			method_5(bool_1: true);
		}

		private void method_5(bool bool_1)
		{
			if (stringBuilder_0.Length != 0 && (!bool_1 || Environment.TickCount - int_0 >= 100))
			{
				int_0 = Environment.TickCount;
				stringBuilder_0.ToString();
				stringBuilder_0 = new StringBuilder();
			}
		}
	}
}
