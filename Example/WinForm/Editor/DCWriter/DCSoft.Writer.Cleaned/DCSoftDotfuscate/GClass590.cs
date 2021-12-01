using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass590 : IDisposable
	{
		private GDelegate34 gdelegate34_0;

		private bool bool_0;

		private bool bool_1;

		private int int_0;

		private string string_0;

		private int int_1;

		private string string_1;

		private string string_2;

		private string string_3;

		private bool bool_2;

		private GStream9 gstream9_0;

		private GStream1 gstream1_0;

		private bool bool_3;

		public void method_0(GDelegate34 gdelegate34_1)
		{
			GDelegate34 gDelegate = gdelegate34_0;
			GDelegate34 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate34 value = (GDelegate34)Delegate.Combine(gDelegate2, gdelegate34_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate34_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_1(GDelegate34 gdelegate34_1)
		{
			GDelegate34 gDelegate = gdelegate34_0;
			GDelegate34 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate34 value = (GDelegate34)Delegate.Remove(gDelegate2, gdelegate34_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate34_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		protected virtual void vmethod_0(GClass558 gclass558_0, string string_4)
		{
			gdelegate34_0?.Invoke(this, gclass558_0, string_4);
		}

		protected GClass590()
		{
			string_0 = string.Empty;
			string_1 = string.Empty;
			
		}

		protected GClass590(GStream9 gstream9_1)
		{
			int num = 4;
			string_0 = string.Empty;
			string_1 = string.Empty;
			
			if (gstream9_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			gstream9_0 = gstream9_1;
		}

		protected GClass590(GStream1 gstream1_1)
		{
			int num = 1;
			string_0 = string.Empty;
			string_1 = string.Empty;
			
			if (gstream1_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			gstream1_0 = gstream1_1;
		}

		public static GClass590 smethod_0(Stream stream_0)
		{
			int num = 15;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			GStream9 gStream = stream_0 as GStream9;
			if (gStream != null)
			{
				return new GClass590(gStream);
			}
			return smethod_1(stream_0, 20);
		}

		public static GClass590 smethod_1(Stream stream_0, int int_2)
		{
			int num = 1;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (stream_0 is GStream9)
			{
				throw new ArgumentException("TarInputStream not valid");
			}
			return new GClass590(new GStream9(stream_0, int_2));
		}

		public static GClass590 smethod_2(Stream stream_0)
		{
			int num = 17;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			GStream1 gStream = stream_0 as GStream1;
			if (gStream != null)
			{
				return new GClass590(gStream);
			}
			return smethod_3(stream_0, 20);
		}

		public static GClass590 smethod_3(Stream stream_0, int int_2)
		{
			int num = 2;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (stream_0 is GStream1)
			{
				throw new ArgumentException("TarOutputStream is not valid");
			}
			return new GClass590(new GStream1(stream_0, int_2));
		}

		public void method_2(bool bool_4)
		{
			int num = 4;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			bool_0 = bool_4;
		}

		public bool method_3()
		{
			int num = 5;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return bool_1;
		}

		public void method_4(bool bool_4)
		{
			int num = 17;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			bool_1 = bool_4;
		}

		[Obsolete("Use the AsciiTranslate property")]
		public void method_5(bool bool_4)
		{
			int num = 12;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			bool_1 = bool_4;
		}

		public string method_6()
		{
			int num = 6;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_3;
		}

		public void method_7(string string_4)
		{
			int num = 16;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			string_3 = string_4;
		}

		public string method_8()
		{
			int num = 12;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_2;
		}

		public void method_9(string string_4)
		{
			int num = 9;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			string_2 = string_4;
		}

		public void method_10(int int_2, string string_4, int int_3, string string_5)
		{
			int num = 19;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			int_0 = int_2;
			string_0 = string_4;
			int_1 = int_3;
			string_1 = string_5;
			bool_2 = true;
		}

		public bool method_11()
		{
			int num = 9;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return bool_2;
		}

		public void method_12(bool bool_4)
		{
			int num = 12;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			bool_2 = bool_4;
		}

		public int method_13()
		{
			int num = 15;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return int_0;
		}

		public string method_14()
		{
			int num = 11;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_0;
		}

		public int method_15()
		{
			int num = 16;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return int_1;
		}

		public string method_16()
		{
			int num = 10;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_1;
		}

		public int method_17()
		{
			int num = 13;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			if (gstream9_0 != null)
			{
				return gstream9_0.method_3();
			}
			if (gstream1_0 != null)
			{
				return gstream1_0.method_3();
			}
			return 10240;
		}

		public void method_18(bool bool_4)
		{
			if (gstream9_0 != null)
			{
				gstream9_0.method_1(bool_4);
			}
			else
			{
				gstream1_0.method_1(bool_4);
			}
		}

		[Obsolete("Use Close instead")]
		public void method_19()
		{
			vmethod_2();
		}

		public void method_20()
		{
			int num = 19;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			while (true)
			{
				GClass558 gClass = gstream9_0.method_10();
				if (gClass != null)
				{
					vmethod_0(gClass, null);
					continue;
				}
				break;
			}
		}

		public void method_21(string string_4)
		{
			int num = 7;
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			while (true)
			{
				GClass558 gClass = gstream9_0.method_10();
				if (gClass != null)
				{
					method_22(string_4, gClass);
					continue;
				}
				break;
			}
		}

		private void method_22(string string_4, GClass558 gclass558_0)
		{
			int num = 9;
			vmethod_0(gclass558_0, null);
			string text = gclass558_0.Name;
			if (Path.IsPathRooted(text))
			{
				text = text.Substring(Path.GetPathRoot(text).Length);
			}
			text = text.Replace('/', Path.DirectorySeparatorChar);
			string text2 = Path.Combine(string_4, text);
			if (gclass558_0.method_17())
			{
				smethod_4(text2);
				return;
			}
			string directoryName = Path.GetDirectoryName(text2);
			smethod_4(directoryName);
			bool flag = true;
			FileInfo fileInfo = new FileInfo(text2);
			if (fileInfo.Exists)
			{
				if (bool_0)
				{
					vmethod_0(gclass558_0, "Destination file already exists");
					flag = false;
				}
				else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != 0)
				{
					vmethod_0(gclass558_0, "Destination file already exists, and is read-only");
					flag = false;
				}
			}
			if (!flag)
			{
				return;
			}
			bool flag2 = false;
			Stream stream = File.Create(text2);
			if (bool_1)
			{
				flag2 = !smethod_5(text2);
			}
			StreamWriter streamWriter = null;
			if (flag2)
			{
				streamWriter = new StreamWriter(stream);
			}
			byte[] array = new byte[32768];
			while (true)
			{
				int num2 = gstream9_0.Read(array, 0, array.Length);
				if (num2 <= 0)
				{
					break;
				}
				if (flag2)
				{
					int num3 = 0;
					for (int i = 0; i < num2; i++)
					{
						if (array[i] == 10)
						{
							string @string = Encoding.ASCII.GetString(array, num3, i - num3);
							streamWriter.WriteLine(@string);
							num3 = i + 1;
						}
					}
				}
				else
				{
					stream.Write(array, 0, num2);
				}
			}
			if (flag2)
			{
				streamWriter.Close();
			}
			else
			{
				stream.Close();
			}
		}

		public void method_23(GClass558 gclass558_0, bool bool_4)
		{
			int num = 5;
			if (gclass558_0 == null)
			{
				throw new ArgumentNullException("sourceEntry");
			}
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			try
			{
				if (bool_4)
				{
					GClass560.smethod_0(gclass558_0.method_2(), gclass558_0.method_6(), gclass558_0.method_4(), gclass558_0.method_8());
				}
				method_24(gclass558_0, bool_4);
			}
			finally
			{
				if (bool_4)
				{
					GClass560.smethod_1();
				}
			}
		}

		private void method_24(GClass558 gclass558_0, bool bool_4)
		{
			int num = 12;
			string text = null;
			string text2 = gclass558_0.method_14();
			GClass558 gClass = (GClass558)gclass558_0.Clone();
			if (bool_2)
			{
				gClass.method_5(int_1);
				gClass.method_9(string_1);
				gClass.method_3(int_0);
				gClass.method_7(string_0);
			}
			vmethod_0(gClass, null);
			if (bool_1 && !gClass.method_17() && !smethod_5(text2))
			{
				text = Path.GetTempFileName();
				using (StreamReader streamReader = File.OpenText(text2))
				{
					using (Stream stream = File.Create(text))
					{
						while (true)
						{
							string text3 = streamReader.ReadLine();
							if (text3 == null)
							{
								break;
							}
							byte[] bytes = Encoding.ASCII.GetBytes(text3);
							stream.Write(bytes, 0, bytes.Length);
							stream.WriteByte(10);
						}
						stream.Flush();
					}
				}
				gClass.method_16(new FileInfo(text).Length);
				text2 = text;
			}
			string text4 = null;
			if (string_2 != null && gClass.Name.StartsWith(string_2))
			{
				text4 = gClass.Name.Substring(string_2.Length + 1);
			}
			if (string_3 != null)
			{
				text4 = ((text4 == null) ? (string_3 + "/" + gClass.Name) : (string_3 + "/" + text4));
			}
			if (text4 != null)
			{
				gClass.Name = text4;
			}
			gstream1_0.method_6(gClass);
			if (gClass.method_17())
			{
				if (bool_4)
				{
					GClass558[] array = gClass.method_19();
					for (int i = 0; i < array.Length; i++)
					{
						method_24(array[i], bool_4);
					}
				}
			}
			else
			{
				using (Stream stream2 = File.OpenRead(text2))
				{
					byte[] array2 = new byte[32768];
					while (true)
					{
						int num2 = stream2.Read(array2, 0, array2.Length);
						if (num2 <= 0)
						{
							break;
						}
						gstream1_0.Write(array2, 0, num2);
					}
				}
				if (text != null && text.Length > 0)
				{
					File.Delete(text);
				}
				gstream1_0.method_7();
			}
		}

		public void Dispose()
		{
			vmethod_1(bool_4: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void vmethod_1(bool bool_4)
		{
			if (bool_3)
			{
				return;
			}
			bool_3 = true;
			if (bool_4)
			{
				if (gstream1_0 != null)
				{
					gstream1_0.Flush();
					gstream1_0.Close();
				}
				if (gstream9_0 != null)
				{
					gstream9_0.Close();
				}
			}
		}

		public virtual void vmethod_2()
		{
			vmethod_1(bool_4: true);
		}

		~GClass590()
		{
			vmethod_1(bool_4: false);
		}

		private static void smethod_4(string string_4)
		{
			int num = 10;
			if (!Directory.Exists(string_4))
			{
				try
				{
					Directory.CreateDirectory(string_4);
				}
				catch (Exception ex)
				{
					throw new GException20("Exception creating directory '" + string_4 + "', " + ex.Message, ex);
				}
			}
		}

		private static bool smethod_5(string string_4)
		{
			using (FileStream fileStream = File.OpenRead(string_4))
			{
				int num = Math.Min(4096, (int)fileStream.Length);
				byte[] array = new byte[num];
				int num2 = fileStream.Read(array, 0, num);
				for (int i = 0; i < num2; i++)
				{
					byte b = array[i];
					if (b < 8 || (b > 13 && b < 32) || b == byte.MaxValue)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
