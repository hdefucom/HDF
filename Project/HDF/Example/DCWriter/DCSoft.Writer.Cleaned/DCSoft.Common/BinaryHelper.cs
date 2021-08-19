using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       二进制数据处理的例程
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class BinaryHelper
	{
		private static int Supportmemcmp = -1;

		private static char[] Hexs = "0123456789ABCDEF".ToCharArray();

		                                                                    /// <summary>
		                                                                    ///       比较两个字节数组内容是否一致
		                                                                    ///       </summary>
		                                                                    /// <param name="bs1">字节数组1</param>
		                                                                    /// <param name="bs2">字节数组2</param>
		                                                                    /// <returns>两个字节数组内容是否一致</returns>
		public static bool Equals(byte[] byte_0, byte[] byte_1)
		{
			int num = 2;
			if (byte_0 == byte_1)
			{
				return true;
			}
			if (byte_0 == null || byte_1 == null)
			{
				return true;
			}
			if (byte_0.Length != byte_1.Length)
			{
				return false;
			}
			int num2 = byte_0.Length;
			if (Supportmemcmp == 1)
			{
				IntPtr value = memcmp(byte_0, byte_1, new IntPtr(num2));
				return value == IntPtr.Zero;
			}
			if (Supportmemcmp == -1)
			{
				try
				{
					string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "msvcrt.dll");
					if (File.Exists(path))
					{
						IntPtr value = memcmp(byte_0, byte_1, new IntPtr(num2));
						Supportmemcmp = 1;
						return value == IntPtr.Zero;
					}
					Supportmemcmp = 0;
				}
				catch (Exception)
				{
					Supportmemcmp = 0;
				}
			}
			int num3 = 0;
			while (true)
			{
				if (num3 < num2)
				{
					if (byte_0[num3] != byte_1[num3])
					{
						break;
					}
					num3++;
					continue;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       memcmp API
		                                                                    ///       </summary>
		                                                                    /// <param name="b1">字节数组1</param>
		                                                                    /// <param name="b2">字节数组2</param>
		                                                                    /// <returns>如果两个数组相同，返回0；如果数组1小于数组2，返回小于0的值；如果数组1大于数组2，返回大于0的值。</returns>
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr memcmp(byte[] byte_0, byte[] byte_1, IntPtr count);

		                                                                    /// <summary>
		                                                                    ///       复制一个字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始数组</param>
		                                                                    /// <returns>复制后的字节数组</returns>
		public static byte[] Clone(byte[] byte_0)
		{
			if (byte_0 == null)
			{
				return null;
			}
			if (byte_0.Length == 0)
			{
				return new byte[0];
			}
			byte[] array = new byte[byte_0.Length];
			Array.Copy(byte_0, 0, array, 0, byte_0.Length);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定区域的字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始字节数组</param>
		                                                                    /// <param name="StartIndex">指定区域的开始序号</param>
		                                                                    /// <param name="Length">指定区域的长度</param>
		                                                                    /// <returns>获得的字节数组</returns>
		public static byte[] GetSubBytes(byte[] byte_0, int StartIndex, int Length)
		{
			int num = 9;
			if (StartIndex < 0 || StartIndex >= byte_0.Length)
			{
				throw new IndexOutOfRangeException("StartIndex");
			}
			if (Length < 0)
			{
				throw new IndexOutOfRangeException("Length");
			}
			if (StartIndex + Length >= byte_0.Length)
			{
				throw new IndexOutOfRangeException("StartIndex+Length");
			}
			byte[] array = new byte[Length];
			Array.Copy(byte_0, StartIndex, array, 0, Length);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       获得字节数组的开始子数组
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始字节数组</param>
		                                                                    /// <param name="Length">指定子区域的长度</param>
		                                                                    /// <returns>获得的字节数组</returns>
		public static byte[] GetSubBytes(byte[] byte_0, int StartIndex)
		{
			byte[] array = new byte[byte_0.Length - StartIndex];
			Array.Copy(byte_0, StartIndex, array, 0, array.Length);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       获得字节数组的最后的一段数据
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始字节数组</param>
		                                                                    /// <param name="Length">指定子区域的长度</param>
		                                                                    /// <returns>获得的字节数组</returns>
		public static byte[] GetLastBytes(byte[] byte_0, int Length)
		{
			byte[] array = new byte[Length];
			Array.Copy(byte_0, byte_0.Length - Length, array, 0, Length);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字节数组是以另一个数组开始的
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <param name="bs2">另一个数组</param>
		                                                                    /// <returns>是否以另一个数组开始的</returns>
		public static bool StartsWith(byte[] byte_0, byte[] byte_1)
		{
			if (byte_0 == null || byte_1 == null)
			{
				return false;
			}
			if (byte_1.Length == 0)
			{
				return true;
			}
			if (byte_0.Length < byte_1.Length)
			{
				return false;
			}
			int num = byte_1.Length;
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (byte_0[num2] != byte_1[num2])
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字节数组是否以另一个字节数据结尾的
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <param name="bs2">另一个字节数组</param>
		                                                                    /// <returns>是否以另一个数组位结尾</returns>
		public static bool EndWith(byte[] byte_0, byte[] byte_1)
		{
			if (byte_0 == null || byte_1 == null)
			{
				return false;
			}
			if (byte_1.Length == 0)
			{
				return true;
			}
			if (byte_0.Length < byte_1.Length)
			{
				return false;
			}
			int num = byte_1.Length;
			int num2 = byte_0.Length - byte_1.Length;
			int num3 = 0;
			while (true)
			{
				if (num3 < num)
				{
					if (byte_0[num3 + num2] != byte_1[num3])
					{
						break;
					}
					num3++;
					continue;
				}
				return true;
			}
			return false;
		}

		public static string GetXORString(byte[] byte_0, byte Key)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			int num = byte_0.Length;
			for (int i = 0; i < num; i++)
			{
				byte_0[i] = (byte)(byte_0[i] ^ Key);
			}
			return Encoding.UTF8.GetString(byte_0);
		}

		                                                                    /// <summary>
		                                                                    ///       对字节数组的指定区域进行异或操作
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <param name="StartIndex">区域开始序号</param>
		                                                                    /// <param name="Length">处理的区域的长度</param>
		                                                                    /// <param name="Key">异或操作键值</param>
		public static void XORBytes(byte[] byte_0, int StartIndex, int Length, byte Key)
		{
			for (int i = 0; i < Length; i++)
			{
				byte_0[i + StartIndex] = (byte)(byte_0[i + StartIndex] ^ Key);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对字节数组进行异或操作
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <param name="Key">异或操作键值</param>
		public static void XORBytes(byte[] byte_0, byte Key)
		{
			int num = byte_0.Length;
			for (int i = 0; i < num; i++)
			{
				byte_0[i] = (byte)(byte_0[i] ^ Key);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对字节值
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">
		                                                                    /// </param>
		                                                                    /// <param name="Key">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static byte XORByte(byte byte_0, byte Key)
		{
			return (byte)(byte_0 ^ Key);
		}

		                                                                    /// <summary>
		                                                                    ///       对单个字节进行循环移位操作
		                                                                    ///       </summary>
		                                                                    /// <param name="vValue">字节值</param>
		                                                                    /// <param name="Step">移位量</param>
		                                                                    /// <returns>处理后的数据值</returns>
		public static byte ByteRound(byte vValue, int Step)
		{
			byte b;
			if (Step > 0)
			{
				b = (byte)(vValue << 8 - Step);
				vValue = (byte)(vValue >> Step);
				return (byte)(b + vValue);
			}
			b = (byte)(vValue >> 8 + Step);
			vValue = (byte)(vValue << -Step);
			return (byte)(b + vValue);
		}

		                                                                    /// <summary>
		                                                                    ///       对字节数组整体进行循环移位操作
		                                                                    ///       </summary>
		                                                                    /// <param name="vValue">字节值</param>
		                                                                    /// <param name="Step">移位量</param>
		                                                                    /// <returns>处理后的数据值</returns>
		public static void ByteRound(byte[] byte_0, int Step)
		{
			int num;
			byte b;
			byte b2;
			if (Step > 0)
			{
				num = 8 - Step;
				b = (byte)(byte_0[byte_0.Length - 1] << num);
				b2 = 0;
				for (int i = 0; i < byte_0.Length; i++)
				{
					byte b3 = byte_0[i];
					b2 = (byte)(b3 << num);
					b3 = (byte)(b3 >> Step);
					byte_0[i] = (byte)(b3 + b);
					b = b2;
				}
				return;
			}
			Step = -Step;
			num = 8 - Step;
			b = (byte)(byte_0[0] >> num);
			b2 = 0;
			for (int i = byte_0.Length - 1; i >= 0; i--)
			{
				byte b3 = byte_0[i];
				b2 = (byte)(b3 >> num);
				b3 = (byte)(b3 << Step);
				byte_0[i] = (byte)(b3 + b);
				b = b2;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       检测一个字节数组的MD5编码和指定的字节数组一致
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始数据</param>
		                                                                    /// <param name="md5">要比较的MD5字节数组</param>
		                                                                    /// <returns>两个数据是否一致</returns>
		public static bool CheckMD5(byte[] byte_0, byte[] md5Bytes)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] byte_ = mD5CryptoServiceProvider.ComputeHash(byte_0);
			return Equals(byte_, md5Bytes);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定数据的MD5编码
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <returns>获得的MD5编码</returns>
		public static byte[] GetMD5(byte[] byte_0)
		{
			using (MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
			{
				return mD5CryptoServiceProvider.ComputeHash(byte_0);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定数据的MD5编码
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <param name="StartIndex">开始区域的序号</param>
		                                                                    /// <param name="Length">区域的长度</param>
		                                                                    /// <returns>获得的MD5编码</returns>
		public static byte[] GetMD5(byte[] byte_0, int StartIndex, int Length)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return mD5CryptoServiceProvider.ComputeHash(byte_0, StartIndex, Length);
		}

		                                                                    /// <summary>
		                                                                    ///       获得字符串数据使用UTF8格式后的MD5编码值
		                                                                    ///       </summary>
		                                                                    /// <param name="txt">字符串数据</param>
		                                                                    /// <returns>获得的MD5编码数据</returns>
		public static byte[] GetStringMD5(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			return GetMD5(bytes);
		}

		                                                                    /// <summary>
		                                                                    ///       获得一个文件的MD5编码值
		                                                                    ///       </summary>
		                                                                    /// <param name="FileName">文件名</param>
		                                                                    /// <returns>获得的MD5编码值</returns>
		public static byte[] GetFileMD5(string FileName)
		{
			if (FileName == null)
			{
				return null;
			}
			if (File.Exists(FileName))
			{
				using (MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
				{
					using (FileStream inputStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
					{
						return mD5CryptoServiceProvider.ComputeHash(inputStream);
					}
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       获得一个流的MD5编码值
		                                                                    ///       </summary>
		                                                                    /// <param name="stream">流对象</param>
		                                                                    /// <returns>获得的MD5编码值</returns>
		public static byte[] GetStreamMD5(Stream stream)
		{
			if (stream == null)
			{
				return null;
			}
			using (MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
			{
				return mD5CryptoServiceProvider.ComputeHash(stream);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       产生一个包含随机内容的字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="Length">字节数组长度</param>
		                                                                    /// <returns>产生的字节数组</returns>
		public byte[] Random(int Length)
		{
			byte[] array = new byte[Length];
			Random random = new Random();
			random.NextBytes(array);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       合并两个字节数组为一个字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="bs1">字节数组1</param>
		                                                                    /// <param name="bs2">字节数组2</param>
		                                                                    /// <returns>合并后的字节数组</returns>
		public byte[] Concat(byte[] byte_0, byte[] byte_1)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return byte_1;
			}
			if (byte_1 == null || byte_1.Length == 0)
			{
				return byte_0;
			}
			byte[] array = new byte[byte_0.Length + byte_1.Length];
			Array.Copy(byte_0, 0, array, 0, byte_0.Length);
			Array.Copy(byte_1, 0, array, byte_0.Length, byte_1.Length);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       合并三个字节数组为一个字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="bs1">字节数组1</param>
		                                                                    /// <param name="bs2">字节数组2</param>
		                                                                    /// <param name="bs3">字节数组3</param>
		                                                                    /// <returns>合并后的字节数组</returns>
		public byte[] Concat(byte[] byte_0, byte[] byte_1, byte[] byte_2)
		{
			int num = 0;
			if (byte_0 != null || byte_0.Length > 0)
			{
				num = byte_0.Length;
			}
			if (byte_1 != null || byte_1.Length > 0)
			{
				num += byte_1.Length;
			}
			if (byte_2 != null || byte_2.Length > 0)
			{
				num += byte_2.Length;
			}
			if (num == 0)
			{
				return null;
			}
			byte[] array = new byte[num];
			int num2 = 0;
			if (byte_0 != null || byte_0.Length > 0)
			{
				Array.Copy(byte_0, 0, array, num2, byte_0.Length);
				num2 += byte_0.Length;
			}
			if (byte_1 != null || byte_1.Length > 0)
			{
				Array.Copy(byte_1, 0, array, num2, byte_1.Length);
				num2 += byte_1.Length;
			}
			if (byte_2 != null || byte_2.Length > 0)
			{
				Array.Copy(byte_2, 0, array, num2, byte_2.Length);
			}
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       为 Rijndael 算法而生成随机的键值
		                                                                    ///       </summary>
		                                                                    /// <returns>键值数据</returns>
		public static byte[] RijndaelGenerateIV()
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.GenerateIV();
			return rijndaelManaged.IV;
		}

		                                                                    /// <summary>
		                                                                    ///       为 Rijndael 算法而生成随机的初始化向量
		                                                                    ///       </summary>
		                                                                    /// <returns>初始化向量数据</returns>
		public static byte[] RijndaelGenerateKey()
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.GenerateKey();
			return rijndaelManaged.Key;
		}

		                                                                    /// <summary>
		                                                                    ///       使用 Rijndael 算法进行加密
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始数据</param>
		                                                                    /// <param name="Key">键值</param>
		                                                                    /// <param name="IV">初始化向量</param>
		                                                                    /// <returns>加密后的值</returns>
		public static byte[] RijndaelEncrypt(byte[] byte_0, byte[] Key, byte[] IV)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(Key, IV);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			cryptoTransform.Dispose();
			return memoryStream.ToArray();
		}

		                                                                    /// <summary>
		                                                                    ///       使用 Rijndael 算法进行解密
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始数据</param>
		                                                                    /// <param name="Key">键值</param>
		                                                                    /// <param name="IV">初始化向量</param>
		                                                                    /// <returns>加密后的值</returns>
		public static byte[] RijndaelDecrypt(byte[] byte_0, byte[] Key, byte[] IV)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(Key, IV);
			MemoryStream stream = new MemoryStream(byte_0);
			CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			byte[] array = new byte[2048];
			MemoryStream memoryStream = new MemoryStream();
			while (true)
			{
				int num = cryptoStream.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			return memoryStream.ToArray();
		}

		                                                                    /// <summary>
		                                                                    ///       字节替换
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">原始字节数据</param>
		                                                                    /// <param name="OldValue">旧数据</param>
		                                                                    /// <param name="NewValue">新数据</param>
		                                                                    /// <returns>操作是否改变了原始数据</returns>
		public static bool Replace(byte[] byte_0, byte OldValue, byte NewValue)
		{
			int num = 2;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("bs");
			}
			if (OldValue == NewValue)
			{
				return false;
			}
			bool result = false;
			if (byte_0 != null && byte_0.Length > 0)
			{
				for (int i = 0; i < byte_0.Length; i++)
				{
					if (byte_0[i] == OldValue)
					{
						byte_0[i] = NewValue;
						result = true;
					}
				}
			}
			return result;
		}

		public static string ToFormatedHexString(byte[] byte_0, int GroupSize, int LineGroup)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return "";
			}
			return ToFormatedHexString(byte_0, 0, byte_0.Length, GroupSize, LineGroup);
		}

		public static string ToFormatedHexString(byte[] byte_0, int StartIndex, int Length, int GroupSize, int LineGroup)
		{
			int num = 0;
			if (byte_0 == null)
			{
				return "";
			}
			if (GroupSize <= 0)
			{
				throw new ArgumentException(" GroupSize 必须大于0");
			}
			if (LineGroup <= 0)
			{
				throw new ArgumentException(" LineGroup 必须大于 0 ");
			}
			if (StartIndex < 0 || StartIndex >= byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("StartIndex");
			}
			if (Length < 0)
			{
				throw new ArgumentOutOfRangeException("Length", "不得小于0");
			}
			if (Length == 0)
			{
				return "";
			}
			int num2 = StartIndex + Length - 1;
			if (num2 >= byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("EndIndex");
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = 0;
			for (int i = StartIndex; i < num2; i += GroupSize)
			{
				if (num3 == LineGroup)
				{
					stringBuilder.Append(Environment.NewLine);
					num3 = 0;
				}
				num3++;
				if (num3 > 0)
				{
					stringBuilder.Append(" ");
				}
				int num4 = GroupSize;
				if (i + num4 >= num2)
				{
					num4 = num2 - i - 1;
				}
				for (int j = i; j <= i + num4; j++)
				{
					byte b = byte_0[j];
					stringBuilder.Append(Hexs[b >> 4]);
					stringBuilder.Append(Hexs[b & 0xF]);
				}
			}
			return stringBuilder.ToString();
		}

		public static string ToFormatedBase64String(byte[] byte_0, int GroupSize, int LineGroup)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return "";
			}
			return ToFormatedBase64String(byte_0, 0, byte_0.Length, GroupSize, LineGroup);
		}

		public static string ToFormatedBase64String(byte[] byte_0, int StartIndex, int Length, int GroupSize, int LineGroup)
		{
			int num = 12;
			if (byte_0 == null)
			{
				return "";
			}
			if (GroupSize <= 0 || GroupSize % 3 != 0)
			{
				throw new ArgumentException(" GroupSize 必须大于0而且为4的倍数");
			}
			if (LineGroup <= 0)
			{
				throw new ArgumentException(" LineGroup 必须大于 0 ");
			}
			if (StartIndex < 0 || StartIndex >= byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("StartIndex");
			}
			if (Length < 0)
			{
				throw new ArgumentOutOfRangeException("Length", "不得小于0");
			}
			if (Length == 0)
			{
				return "";
			}
			int num2 = StartIndex + Length - 1;
			if (num2 >= byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("EndIndex");
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = 0;
			for (int i = StartIndex; i <= num2; i += GroupSize)
			{
				if (num3 == LineGroup)
				{
					stringBuilder.Append(Environment.NewLine);
					num3 = 0;
				}
				num3++;
				if (num3 > 0)
				{
					stringBuilder.Append(" ");
				}
				int num4 = GroupSize;
				if (i + num4 > num2 + 1)
				{
					num4 = num2 - i + 1;
				}
				string value = Convert.ToBase64String(byte_0, i, num4);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       将字节数组转换为16进制字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <returns>16进制字符串</returns>
		public static string ToHexString(byte[] byte_0)
		{
			int num = 7;
			if (byte_0 == null || byte_0.Length == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = byte_0.Length;
			for (int i = 0; i < num2; i++)
			{
				byte b = byte_0[i];
				stringBuilder.Append("0123456789ABCDEF"[b >> 4]);
				stringBuilder.Append("0123456789ABCDEF"[b & 0xF]);
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       将16进制字符串转换为字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">16进制字符串</param>
		                                                                    /// <returns>字节数组</returns>
		public static byte[] FromHexString(string strText)
		{
			int num = 5;
			MemoryStream memoryStream = new MemoryStream();
			int num2 = 0;
			int num3 = 0;
			foreach (char c in strText)
			{
				int num4 = "0123456789ABCDEF".IndexOf(char.ToUpper(c));
				if (num4 >= 0)
				{
					if (num2 % 2 == 0)
					{
						num3 = num4;
					}
					else
					{
						num3 <<= 4 + num4;
						memoryStream.WriteByte((byte)num3);
					}
					num2++;
				}
			}
			if (num2 > 0 && num2 % 2 == 0)
			{
				memoryStream.WriteByte((byte)num3);
			}
			return memoryStream.ToArray();
		}

		                                                                    /// <summary>
		                                                                    ///       将字节数组转换为C语言样式的定义字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="bs">字节数组</param>
		                                                                    /// <returns>字符串</returns>
		public static string ToCDefineString(byte[] byte_0)
		{
			int num = 2;
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < byte_0.Length; i++)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" , ");
				}
				stringBuilder.Append("0x");
				stringBuilder.Append(byte_0[i].ToString("x"));
			}
			return stringBuilder.ToString();
		}

		private BinaryHelper()
		{
		}
	}
}
