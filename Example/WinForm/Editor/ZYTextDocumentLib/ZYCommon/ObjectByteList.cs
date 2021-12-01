using System;
using System.Collections;
using System.IO;
using System.Text;

namespace ZYCommon
{
	public abstract class ObjectByteList : ArrayList
	{
		private byte[] bytBuffer = new byte[100];

		private int intDataLength = 0;

		private Encoding myEncode = Encoding.UTF8;

		private int intForecastCount = 0;

		private bool bolEncryptString = true;

		protected bool bolFilterNullObject = false;

		public bool EncryptString
		{
			get
			{
				return bolEncryptString;
			}
			set
			{
				bolEncryptString = value;
			}
		}

		public virtual int DataHeadFlag => 90233;

		public int ForecastCount => intForecastCount;

		public bool FilterNullObject
		{
			get
			{
				return bolFilterNullObject;
			}
			set
			{
				bolFilterNullObject = value;
			}
		}

		public void AppendBytes(byte[] bytData, int StartIndex, int Length)
		{
			if (bytData != null && StartIndex >= 0 && Length > 0 && StartIndex + Length <= bytData.Length)
			{
				lock (this)
				{
					if (intDataLength + Length >= bytBuffer.Length)
					{
						byte[] array = new byte[(int)((double)(intDataLength + Length) * 1.5)];
						for (int i = 0; i < bytBuffer.Length; i++)
						{
							array[i] = bytBuffer[i];
						}
						bytBuffer = array;
					}
					for (int i = 0; i < Length; i++)
					{
						bytBuffer[i + intDataLength] = bytData[i];
					}
					intDataLength += Length;
				}
			}
		}

		public void AppendBytes(byte[] bytData)
		{
			AppendBytes(bytData, 0, bytData.Length);
		}

		public void AppendObjectData(string strData)
		{
			if (strData == null)
			{
				AppendBytes(BitConverter.GetBytes(0));
				return;
			}
			byte[] bytes = myEncode.GetBytes(strData);
			if (bolEncryptString)
			{
				byte b = (byte)(bytes.Length & 0xFF);
				for (int i = 0; i < bytes.Length; i++)
				{
					bytes[i] = (byte)(bytes[i] ^ b);
				}
			}
			AppendBytes(BitConverter.GetBytes(bytes.Length));
			AppendBytes(bytes);
		}

		public void AppendObjectData(byte[] bytData)
		{
			if (bytData == null)
			{
				AppendBytes(BitConverter.GetBytes(0));
				return;
			}
			AppendBytes(BitConverter.GetBytes(bytData.Length));
			AppendBytes(bytData);
		}

		public void AppendObjectData(int intData)
		{
			AppendBytes(BitConverter.GetBytes(intData));
		}

		public byte[] ReadBytes()
		{
			int num = ReadInt32();
			if (num <= 0)
			{
				return null;
			}
			return ReadBytes(num);
		}

		public byte[] ReadBytes(int Length)
		{
			lock (this)
			{
				if (intDataLength >= Length)
				{
					byte[] array = new byte[Length];
					for (int i = 0; i < Length; i++)
					{
						array[i] = bytBuffer[i];
					}
					for (int i = Length; i < intDataLength; i++)
					{
						bytBuffer[i - Length] = bytBuffer[i];
					}
					intDataLength -= Length;
					return array;
				}
			}
			return null;
		}

		public string ReadString()
		{
			byte[] array = ReadBytes(4);
			if (array != null)
			{
				int num = BitConverter.ToInt32(array, 0);
				if (num == 0)
				{
					return null;
				}
				array = ReadBytes(num);
				if (array == null)
				{
					return null;
				}
				if (bolEncryptString)
				{
					byte b = (byte)(num & 0xFF);
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = (byte)(array[i] ^ b);
					}
				}
				return myEncode.GetString(array);
			}
			return null;
		}

		public int ReadInt32()
		{
			byte[] array = ReadBytes(4);
			if (array != null)
			{
				return BitConverter.ToInt32(array, 0);
			}
			return -1;
		}

		public int Save(Stream myStream)
		{
			int num = 0;
			int ClassID = 0;
			myStream.Write(BitConverter.GetBytes(DataHeadFlag), 0, 4);
			myStream.WriteByte((byte)(bolEncryptString ? 1 : 0));
			myStream.Write(BitConverter.GetBytes(Count), 0, 4);
			if (bolEncryptString)
			{
				myEncode = Encoding.UTF8;
			}
			else
			{
				myEncode = Encoding.GetEncoding(936);
			}
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					intDataLength = 0;
					if (ObjectToBytes(current, ref ClassID) && intDataLength > 0)
					{
						myStream.Write(BitConverter.GetBytes(ClassID), 0, 4);
						myStream.Write(BitConverter.GetBytes(intDataLength), 0, 4);
						myStream.Write(bytBuffer, 0, intDataLength);
						num += intDataLength;
					}
					else if (!bolFilterNullObject)
					{
						myStream.Write(BitConverter.GetBytes(-1), 0, 4);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return num;
		}

		public int Save(string strFileName)
		{
			FileStream fileStream = null;
			int num = 0;
			try
			{
				fileStream = new FileStream(strFileName, FileMode.Create, FileAccess.Write);
				num = Save(fileStream);
				fileStream.Close();
				return num;
			}
			catch (Exception ex)
			{
				fileStream?.Close();
				throw ex;
			}
		}

		public int Load(Stream myStream)
		{
			byte[] array = new byte[4];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (myStream.CanRead)
			{
				num2 = myStream.Read(array, 0, 4);
				if (num2 != 4 || DataHeadFlag != BitConverter.ToInt32(array, 0))
				{
					throw new Exception("文件格式不对");
				}
			}
			if (myStream.CanRead)
			{
				if (myStream.ReadByte() == 0)
				{
					bolEncryptString = false;
					myEncode = Encoding.GetEncoding(936);
				}
				else
				{
					bolEncryptString = true;
					myEncode = Encoding.UTF8;
				}
			}
			if (myStream.CanRead)
			{
				num2 = myStream.Read(array, 0, 4);
				if (num2 != 4)
				{
					return 0;
				}
				intForecastCount = BitConverter.ToInt32(array, 0);
				while (myStream.CanRead)
				{
					num2 = myStream.Read(array, 0, 4);
					if (num2 != 4)
					{
						break;
					}
					num = BitConverter.ToInt32(array, 0);
					if (num == -1)
					{
						if (!bolFilterNullObject)
						{
							Add(null);
							num3++;
						}
						continue;
					}
					num2 = myStream.Read(array, 0, 4);
					if (num2 != 4)
					{
						break;
					}
					intDataLength = BitConverter.ToInt32(array, 0);
					bytBuffer = new byte[intDataLength];
					num2 = myStream.Read(bytBuffer, 0, intDataLength);
					if (num2 != intDataLength)
					{
						break;
					}
					object obj = BytesToObject(num);
					if (bolFilterNullObject)
					{
						if (obj != null)
						{
							Add(obj);
							num3++;
						}
					}
					else
					{
						Add(obj);
						num3++;
					}
				}
				OnAfterLoad();
				return num3;
			}
			return 0;
		}

		public int Load(string strFileName)
		{
			using (FileStream myStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
			{
				return Load(myStream);
			}
		}

		public virtual object BytesToObject(int ClassID)
		{
			return null;
		}

		public virtual bool ObjectToBytes(object objData, ref int ClassID)
		{
			return false;
		}

		public virtual void OnAfterLoad()
		{
		}
	}
}
