using System;

namespace ZYCommon
{
	public class ConsoleBuffer
	{
		private char[] myBuffer = new char[5000];

		private int intStartIndex = 0;

		private int intDataLength = 0;

		private int intBufferLength = 0;

		public int BufferLength
		{
			get
			{
				return intBufferLength;
			}
			set
			{
				if (value > 0)
				{
					lock (this)
					{
						myBuffer = new char[value];
						intBufferLength = value;
						intStartIndex = 0;
						intDataLength = 0;
					}
				}
			}
		}

		public ConsoleBuffer()
		{
			intBufferLength = myBuffer.Length;
		}

		public void Clear()
		{
			lock (this)
			{
				intStartIndex = 0;
				intDataLength = 0;
				for (int i = 0; i < intBufferLength; i++)
				{
					myBuffer[i] = ' ';
				}
			}
		}

		public override string ToString()
		{
			lock (this)
			{
				if (intStartIndex + intDataLength < intBufferLength)
				{
					return new string(myBuffer, intStartIndex, intDataLength);
				}
				char[] array = new char[intDataLength];
				for (int i = 0; i < intDataLength; i++)
				{
					array[i] = myBuffer[(i + intStartIndex) % intBufferLength];
				}
				return new string(array);
			}
		}

		public void Write(object obj)
		{
			Write(Convert.ToString(obj));
		}

		public void Write(string strText)
		{
			if (strText != null && strText.Length > 0)
			{
				lock (this)
				{
					int length = strText.Length;
					int num = (length > intBufferLength) ? (length - intBufferLength) : 0;
					int num2 = intStartIndex + intDataLength;
					int num3 = num;
					while (num3 < length)
					{
						myBuffer[num2 % intBufferLength] = strText[num3];
						num3++;
						num2++;
					}
					intDataLength += length - num;
					if (intDataLength > intBufferLength)
					{
						intStartIndex = (intStartIndex + (intDataLength - intBufferLength)) % intBufferLength;
						intDataLength = intBufferLength;
					}
				}
			}
		}

		public void WriteLine(string strText)
		{
			Write("\r\n");
			Write(strText);
		}
	}
}
