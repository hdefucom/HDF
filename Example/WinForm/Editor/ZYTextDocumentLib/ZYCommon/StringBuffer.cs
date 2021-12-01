using System.Text;

namespace ZYCommon
{
	public class StringBuffer
	{
		private string[] vBuffer = new string[16];

		private int intCount = 0;

		public int Count => intCount;

		public string LastItem
		{
			get
			{
				if (intCount > 0)
				{
					return vBuffer[intCount - 1];
				}
				return null;
			}
		}

		public string FirstItem
		{
			get
			{
				if (intCount > 0)
				{
					return vBuffer[0];
				}
				return null;
			}
		}

		public void Clear()
		{
			lock (this)
			{
				vBuffer = new string[16];
				intCount = 0;
			}
		}

		public void Append(string vData)
		{
			lock (this)
			{
				if (intCount >= vBuffer.Length)
				{
					string[] array = new string[(int)((double)intCount * 1.5)];
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

		public string[] ToArray()
		{
			string[] array = null;
			if (intCount > 0)
			{
				lock (this)
				{
					array = new string[intCount];
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
						stringBuilder.Append(vBuffer[i]);
					}
				}
				return stringBuilder.ToString();
			}
			return null;
		}
	}
}
