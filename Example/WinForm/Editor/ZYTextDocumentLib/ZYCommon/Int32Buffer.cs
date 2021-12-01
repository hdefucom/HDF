using System;
using System.Text;

namespace ZYCommon
{
	public class Int32Buffer
	{
		private int[] vBuffer = new int[16];

		private int intCount = 0;

		public int Count => intCount;

		public int LastByte
		{
			get
			{
				if (intCount > 0)
				{
					return vBuffer[intCount - 1];
				}
				return 0;
			}
		}

		public int FirstByte
		{
			get
			{
				if (intCount > 0)
				{
					return vBuffer[0];
				}
				return 0;
			}
		}

		public void Clear()
		{
			lock (this)
			{
				vBuffer = new int[16];
				intCount = 0;
			}
		}

		public void Append(int vData)
		{
			lock (this)
			{
				if (intCount >= vBuffer.Length)
				{
					int[] array = new int[(int)((double)intCount * 1.5)];
					for (int i = 0; i < vBuffer.Length; i++)
					{
						array[i] = vBuffer[i];
					}
					vBuffer = array;
				}
				vBuffer[intCount] = vData;
				intCount++;
			}
		}

		public int[] ToArray()
		{
			int[] array = null;
			if (intCount > 0)
			{
				lock (this)
				{
					array = new int[intCount];
					for (int i = 0; i < intCount; i++)
					{
						array[i] = vBuffer[i];
					}
				}
			}
			return array;
		}

		public string ToStringList(char SplitChar)
		{
			if (intCount > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				lock (this)
				{
					for (int i = 0; i < intCount; i++)
					{
						if (i != 0)
						{
							stringBuilder.Append(SplitChar);
						}
						stringBuilder.Append(Convert.ToString(vBuffer[i]));
					}
				}
				return stringBuilder.ToString();
			}
			return null;
		}
	}
}
