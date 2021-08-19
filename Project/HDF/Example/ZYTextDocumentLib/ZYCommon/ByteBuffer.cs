namespace ZYCommon
{
	public class ByteBuffer
	{
		private byte[] bytBytes = new byte[16];

		private int intCount = 0;

		public int Count => intCount;

		public byte LastByte
		{
			get
			{
				if (intCount > 0)
				{
					return bytBytes[intCount - 1];
				}
				return 0;
			}
		}

		public byte FirstByte
		{
			get
			{
				if (intCount > 0)
				{
					return bytBytes[0];
				}
				return 0;
			}
		}

		public void Clear()
		{
			lock (this)
			{
				bytBytes = new byte[16];
				intCount = 0;
			}
		}

		public void Append(byte bytData)
		{
			lock (this)
			{
				if (intCount >= bytBytes.Length)
				{
					byte[] array = new byte[(int)((double)intCount * 1.5)];
					for (int i = 0; i < bytBytes.Length; i++)
					{
						array[i] = bytBytes[i];
					}
					bytBytes = array;
				}
				bytBytes[intCount] = bytData;
				intCount++;
			}
		}

		public byte[] ToByteArray()
		{
			byte[] array = null;
			lock (this)
			{
				array = new byte[intCount];
				for (int i = 0; i < intCount; i++)
				{
					array[i] = bytBytes[i];
				}
			}
			return array;
		}
	}
}
