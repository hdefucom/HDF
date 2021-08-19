using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("EntryByIndex")]
	public class GClass571 : IEnumerable, IDisposable
	{
		[ComVisible(false)]
		public delegate void GDelegate33(object sender, GEventArgs19 e);

		[ComVisible(false)]
		[Flags]
		private enum Enum29
		{
			flag_0 = 0x1,
			flag_1 = 0x2
		}

		[ComVisible(false)]
		private enum Enum30
		{
			const_0,
			const_1,
			const_2
		}

		[ComVisible(false)]
		private class Class221 : IComparer
		{
			public int Compare(object object_0, object object_1)
			{
				Class222 @class = object_0 as Class222;
				Class222 class2 = object_1 as Class222;
				int num;
				if (@class == null)
				{
					num = ((class2 != null) ? (-1) : 0);
				}
				else if (class2 == null)
				{
					num = 1;
				}
				else
				{
					int num2 = (@class.method_2() != 0 && @class.method_2() != Enum30.const_1) ? 1 : 0;
					int num3 = (class2.method_2() != 0 && class2.method_2() != Enum30.const_1) ? 1 : 0;
					num = num2 - num3;
					if (num == 0)
					{
						long num4 = @class.method_0().method_11() - class2.method_0().method_11();
						num = ((num4 < 0L) ? (-1) : ((num4 != 0L) ? 1 : 0));
					}
				}
				return num;
			}
		}

		[ComVisible(false)]
		private class Class222
		{
			private GClass577 gclass577_0;

			private GClass577 gclass577_1;

			private Enum30 enum30_0;

			private GInterface28 ginterface28_0;

			private string string_0;

			private long long_0 = -1L;

			private long long_1 = -1L;

			private long long_2 = -1L;

			public Class222(string string_1, GClass577 gclass577_2)
			{
				enum30_0 = Enum30.const_2;
				gclass577_0 = gclass577_2;
				string_0 = string_1;
			}

			[Obsolete]
			public Class222(string string_1, string string_2, GEnum94 genum94_0)
			{
				enum30_0 = Enum30.const_2;
				gclass577_0 = new GClass577(string_2);
				gclass577_0.method_37(genum94_0);
				string_0 = string_1;
			}

			[Obsolete]
			public Class222(string string_1, string string_2)
				: this(string_1, string_2, GEnum94.const_1)
			{
			}

			[Obsolete]
			public Class222(GInterface28 ginterface28_1, string string_1, GEnum94 genum94_0)
			{
				enum30_0 = Enum30.const_2;
				gclass577_0 = new GClass577(string_1);
				gclass577_0.method_37(genum94_0);
				ginterface28_0 = ginterface28_1;
			}

			public Class222(GInterface28 ginterface28_1, GClass577 gclass577_2)
			{
				enum30_0 = Enum30.const_2;
				gclass577_0 = gclass577_2;
				ginterface28_0 = ginterface28_1;
			}

			public Class222(GClass577 gclass577_2, GClass577 gclass577_3)
			{
				throw new GException24("Modify not currently supported");
			}

			public Class222(Enum30 enum30_1, GClass577 gclass577_2)
			{
				enum30_0 = enum30_1;
				gclass577_0 = (GClass577)gclass577_2.Clone();
			}

			public Class222(GClass577 gclass577_2)
				: this(Enum30.const_0, gclass577_2)
			{
			}

			public GClass577 method_0()
			{
				return gclass577_0;
			}

			public GClass577 method_1()
			{
				if (gclass577_1 == null)
				{
					gclass577_1 = (GClass577)gclass577_0.Clone();
				}
				return gclass577_1;
			}

			public Enum30 method_2()
			{
				return enum30_0;
			}

			public string method_3()
			{
				return string_0;
			}

			public long method_4()
			{
				return long_0;
			}

			public void method_5(long long_3)
			{
				long_0 = long_3;
			}

			public long method_6()
			{
				return long_1;
			}

			public void method_7(long long_3)
			{
				long_1 = long_3;
			}

			public long method_8()
			{
				return long_2;
			}

			public void method_9(long long_3)
			{
				long_2 = long_3;
			}

			public Stream method_10()
			{
				Stream result = null;
				if (ginterface28_0 != null)
				{
					result = ginterface28_0.imethod_0();
				}
				return result;
			}
		}

		[ComVisible(false)]
		private class Class223
		{
			private string string_0;

			private byte[] byte_0;

			private bool bool_0;

			public Class223(string string_1)
			{
				string_0 = string_1;
				bool_0 = true;
			}

			public Class223(byte[] byte_1)
			{
				byte_0 = byte_1;
			}

			public bool method_0()
			{
				return bool_0;
			}

			public int method_1()
			{
				method_5();
				return byte_0.Length;
			}

			public byte[] method_2()
			{
				method_5();
				return (byte[])byte_0.Clone();
			}

			public void method_3()
			{
				if (bool_0)
				{
					byte_0 = null;
				}
				else
				{
					string_0 = null;
				}
			}

			private void method_4()
			{
				if (string_0 == null)
				{
					string_0 = GClass547.smethod_3(byte_0);
				}
			}

			private void method_5()
			{
				if (byte_0 == null)
				{
					byte_0 = GClass547.smethod_6(string_0);
				}
			}

			public static string smethod_0(Class223 class223_0)
			{
				class223_0.method_4();
				return class223_0.string_0;
			}
		}

		[ComVisible(false)]
		private class Class224 : IEnumerator
		{
			private GClass577[] gclass577_0;

			private int int_0 = -1;

			public object Current => gclass577_0[int_0];

			public Class224(GClass577[] gclass577_1)
			{
				gclass577_0 = gclass577_1;
			}

			public void Reset()
			{
				int_0 = -1;
			}

			public bool MoveNext()
			{
				return ++int_0 < gclass577_0.Length;
			}
		}

		[ComVisible(false)]
		private class Stream1 : Stream
		{
			private Stream stream_0;

			public override bool CanRead => false;

			public override bool CanSeek => false;

			public override bool CanWrite => stream_0.CanWrite;

			public override long Length => 0L;

			public override long Position
			{
				get
				{
					return stream_0.Position;
				}
				set
				{
				}
			}

			public Stream1(Stream stream_1)
			{
				stream_0 = stream_1;
			}

			public override void Close()
			{
			}

			public override void Flush()
			{
				stream_0.Flush();
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				return 0;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				return 0L;
			}

			public override void SetLength(long value)
			{
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				stream_0.Write(buffer, offset, count);
			}
		}

		[ComVisible(false)]
		private class Stream2 : Stream
		{
			private GClass571 gclass571_0;

			private Stream stream_0;

			private long long_0;

			private long long_1;

			private long long_2;

			private long long_3;

			public override bool CanRead => true;

			public override bool CanSeek => true;

			public override bool CanTimeout => stream_0.CanTimeout;

			public override bool CanWrite => false;

			public override long Length => long_1;

			public override long Position
			{
				get
				{
					return long_2 - long_0;
				}
				set
				{
					int num = 15;
					long num2 = long_0 + value;
					if (num2 < long_0)
					{
						throw new ArgumentException("Negative position is invalid");
					}
					if (num2 >= long_3)
					{
						throw new InvalidOperationException("Cannot seek past end");
					}
					long_2 = num2;
				}
			}

			public Stream2(GClass571 gclass571_1, long long_4, long long_5)
			{
				long_0 = long_4;
				long_1 = long_5;
				gclass571_0 = gclass571_1;
				stream_0 = gclass571_0.stream_0;
				long_2 = long_4;
				long_3 = long_4 + long_5;
			}

			public override int ReadByte()
			{
				if (long_2 >= long_3)
				{
					return -1;
				}
				lock (stream_0)
				{
					stream_0.Seek(long_2++, SeekOrigin.Begin);
					return stream_0.ReadByte();
				}
			}

			public override void Close()
			{
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				lock (stream_0)
				{
					if (count > long_3 - long_2)
					{
						count = (int)(long_3 - long_2);
						if (count == 0)
						{
							return 0;
						}
					}
					stream_0.Seek(long_2, SeekOrigin.Begin);
					int num = stream_0.Read(buffer, offset, count);
					if (num > 0)
					{
						long_2 += num;
					}
					return num;
				}
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				int num = 8;
				long num2 = long_2;
				switch (origin)
				{
				case SeekOrigin.Begin:
					num2 = long_0 + offset;
					break;
				case SeekOrigin.Current:
					num2 = long_2 + offset;
					break;
				case SeekOrigin.End:
					num2 = long_3 + offset;
					break;
				}
				if (num2 < long_0)
				{
					throw new ArgumentException("Negative position is invalid");
				}
				if (num2 >= long_3)
				{
					throw new IOException("Cannot seek past end");
				}
				long_2 = num2;
				return long_2;
			}

			public override void Flush()
			{
			}
		}

		private const int int_0 = 4096;

		public GDelegate33 gdelegate33_0;

		private bool bool_0;

		private string string_0;

		private string string_1;

		private string string_2;

		private Stream stream_0;

		private bool bool_1;

		private long long_0;

		private GClass577[] gclass577_0;

		private byte[] byte_0;

		private bool bool_2;

		private GEnum93 genum93_0;

		private ArrayList arrayList_0;

		private long long_1;

		private Hashtable hashtable_0;

		private GInterface30 ginterface30_0;

		private GInterface29 ginterface29_0;

		private bool bool_3;

		private int int_1;

		private byte[] byte_1;

		private Class223 class223_0;

		private bool bool_4;

		private GInterface27 ginterface27_0;

		public string Name => string_0;

		private void method_0(string string_3)
		{
			if (gdelegate33_0 != null)
			{
				GEventArgs19 gEventArgs = new GEventArgs19(string_3, byte_0);
				gdelegate33_0(this, gEventArgs);
				byte_0 = gEventArgs.method_1();
			}
		}

		private byte[] method_1()
		{
			return byte_0;
		}

		private void method_2(byte[] byte_2)
		{
			byte_0 = byte_2;
		}

		public void method_3(string string_3)
		{
			if (string_3 == null || string_3.Length == 0)
			{
				byte_0 = null;
				return;
			}
			string_2 = string_3;
			byte_0 = GClass564.smethod_0(GClass547.smethod_6(string_3));
		}

		private bool method_4()
		{
			return byte_0 != null;
		}

		public GClass571(string string_3)
		{
			int num = 17;
			genum93_0 = GEnum93.const_2;
			int_1 = 4096;
			ginterface27_0 = new GClass578();
			
			if (string_3 == null)
			{
				throw new ArgumentNullException("name");
			}
			string_0 = string_3;
			stream_0 = File.Open(string_3, FileMode.Open, FileAccess.Read, FileShare.Read);
			bool_1 = true;
			try
			{
				method_82();
			}
			catch
			{
				method_77(bool_5: true);
				throw;
			}
		}

		public GClass571(FileStream fileStream_0)
		{
			int num = 9;
			genum93_0 = GEnum93.const_2;
			int_1 = 4096;
			ginterface27_0 = new GClass578();
			
			if (fileStream_0 == null)
			{
				throw new ArgumentNullException("file");
			}
			if (!fileStream_0.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "file");
			}
			stream_0 = fileStream_0;
			string_0 = fileStream_0.Name;
			bool_1 = true;
			try
			{
				method_82();
			}
			catch
			{
				method_77(bool_5: true);
				throw;
			}
		}

		public GClass571(Stream stream_1)
		{
			int num = 18;
			genum93_0 = GEnum93.const_2;
			int_1 = 4096;
			ginterface27_0 = new GClass578();
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream_1.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "stream");
			}
			stream_0 = stream_1;
			bool_1 = true;
			if (stream_0.Length > 0L)
			{
				try
				{
					method_82();
				}
				catch
				{
					method_77(bool_5: true);
					throw;
				}
				return;
			}
			gclass577_0 = new GClass577[0];
			bool_2 = true;
		}

		internal GClass571()
		{
			genum93_0 = GEnum93.const_2;
			int_1 = 4096;
			ginterface27_0 = new GClass578();
			
			gclass577_0 = new GClass577[0];
			bool_2 = true;
		}

		~GClass571()
		{
			vmethod_0(bool_5: false);
		}

		public void method_5()
		{
			method_77(bool_5: true);
			GC.SuppressFinalize(this);
		}

		public static GClass571 smethod_0(string string_3)
		{
			int num = 16;
			if (string_3 == null)
			{
				throw new ArgumentNullException("fileName");
			}
			FileStream fileStream = File.Create(string_3);
			GClass571 gClass = new GClass571();
			gClass.string_0 = string_3;
			gClass.stream_0 = fileStream;
			gClass.bool_1 = true;
			return gClass;
		}

		public static GClass571 smethod_1(Stream stream_1)
		{
			int num = 14;
			if (stream_1 == null)
			{
				throw new ArgumentNullException("outStream");
			}
			if (!stream_1.CanWrite)
			{
				throw new ArgumentException("Stream is not writeable", "outStream");
			}
			if (!stream_1.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "outStream");
			}
			GClass571 gClass = new GClass571();
			gClass.stream_0 = stream_1;
			return gClass;
		}

		public bool method_6()
		{
			return bool_1;
		}

		public void method_7(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public bool method_8()
		{
			return long_0 > 0L;
		}

		public bool method_9()
		{
			return bool_2;
		}

		public string method_10()
		{
			return string_1;
		}

		public int method_11()
		{
			return gclass577_0.Length;
		}

		public long method_12()
		{
			return gclass577_0.Length;
		}

		public GClass577 method_13(int int_2)
		{
			return (GClass577)gclass577_0[int_2].Clone();
		}

		public IEnumerator GetEnumerator()
		{
			int num = 17;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			return new Class224(gclass577_0);
		}

		public int method_14(string string_3, bool bool_5)
		{
			int num = 19;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < gclass577_0.Length)
				{
					if (string.Compare(string_3, gclass577_0[num2].Name, bool_5, CultureInfo.InvariantCulture) == 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}

		public GClass577 method_15(string string_3)
		{
			int num = 14;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			int num2 = method_14(string_3, bool_5: true);
			return (num2 >= 0) ? ((GClass577)gclass577_0[num2].Clone()) : null;
		}

		public Stream method_16(GClass577 gclass577_1)
		{
			int num = 18;
			if (gclass577_1 == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			long num2 = gclass577_1.method_9();
			if (num2 < 0L || num2 >= gclass577_0.Length || gclass577_0[num2].Name != gclass577_1.Name)
			{
				num2 = method_14(gclass577_1.Name, bool_5: true);
				if (num2 < 0L)
				{
					throw new GException24("Entry cannot be found");
				}
			}
			return method_17(num2);
		}

		public Stream method_17(long long_2)
		{
			int num = 18;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			long long_3 = method_83(gclass577_0[long_2]);
			GEnum94 gEnum = gclass577_0[long_2].method_36();
			Stream stream = new Stream2(this, long_3, gclass577_0[long_2].method_32());
			if (gclass577_0[long_2].method_1())
			{
				stream = method_84(stream, gclass577_0[long_2]);
				if (stream == null)
				{
					throw new GException24("Unable to decrypt this entry");
				}
			}
			switch (gEnum)
			{
			default:
				throw new GException24("Unsupported compression method " + gEnum);
			case GEnum94.const_1:
				stream = new GStream2(stream, new GClass587(bool_2: true));
				break;
			case GEnum94.const_0:
				break;
			}
			return stream;
		}

		public bool method_18(bool bool_5)
		{
			return method_19(bool_5, GEnum98.const_0, null);
		}

		public bool method_19(bool bool_5, GEnum98 genum98_0, GDelegate32 gdelegate32_0)
		{
			int num = 4;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			GClass570 gClass = new GClass570(this);
			gdelegate32_0?.Invoke(gClass, null);
			Enum29 enum29_ = bool_5 ? (Enum29.flag_0 | Enum29.flag_1) : Enum29.flag_1;
			bool flag = true;
			try
			{
				int num2 = 0;
				while (flag && num2 < method_12())
				{
					if (gdelegate32_0 != null)
					{
						gClass.method_8(method_13(num2));
						gClass.method_7(GEnum99.const_1);
						gdelegate32_0(gClass, null);
					}
					try
					{
						method_20(method_13(num2), enum29_);
					}
					catch (GException24 gException)
					{
						gClass.method_6();
						gdelegate32_0?.Invoke(gClass, $"Exception during test - '{gException.Message}'");
						if (genum98_0 == GEnum98.const_0)
						{
							flag = false;
						}
					}
					if (flag && bool_5 && method_13(num2).method_51())
					{
						if (gdelegate32_0 != null)
						{
							gClass.method_7(GEnum99.const_2);
							gdelegate32_0(gClass, null);
						}
						GClass548 gClass2 = new GClass548();
						using (Stream stream = method_16(method_13(num2)))
						{
							byte[] array = new byte[4096];
							long num3 = 0L;
							int num4;
							while ((num4 = stream.Read(array, 0, array.Length)) > 0)
							{
								gClass2.imethod_4(array, 0, num4);
								if (gdelegate32_0 != null)
								{
									num3 += num4;
									gClass.method_9(num3);
									gdelegate32_0(gClass, null);
								}
							}
						}
						if (method_13(num2).method_34() != gClass2.imethod_0())
						{
							gClass.method_6();
							gdelegate32_0?.Invoke(gClass, "CRC mismatch");
							if (genum98_0 == GEnum98.const_0)
							{
								flag = false;
							}
						}
						if ((method_13(num2).method_7() & 8) != 0)
						{
							Stream0 stream2 = new Stream0(stream_0);
							GClass551 gClass3 = new GClass551();
							stream2.method_16(method_13(num2).method_24(), gClass3);
							if (method_13(num2).method_34() != gClass3.method_4())
							{
								gClass.method_6();
							}
							if (method_13(num2).method_32() != gClass3.method_0())
							{
								gClass.method_6();
							}
							if (method_13(num2).method_30() != gClass3.method_2())
							{
								gClass.method_6();
							}
						}
					}
					if (gdelegate32_0 != null)
					{
						gClass.method_7(GEnum99.const_3);
						gdelegate32_0(gClass, null);
					}
					num2++;
				}
				if (gdelegate32_0 != null)
				{
					gClass.method_7(GEnum99.const_4);
					gdelegate32_0(gClass, null);
				}
			}
			catch (Exception ex)
			{
				gClass.method_6();
				gdelegate32_0?.Invoke(gClass, $"Exception during test - '{ex.Message}'");
			}
			if (gdelegate32_0 != null)
			{
				gClass.method_7(GEnum99.const_5);
				gClass.method_8(null);
				gdelegate32_0(gClass, null);
			}
			return gClass.method_3() == 0;
		}

		private long method_20(GClass577 gclass577_1, Enum29 enum29_0)
		{
			int num = 9;
			lock (stream_0)
			{
				bool flag = (enum29_0 & Enum29.flag_1) != 0;
				bool flag2 = (enum29_0 & Enum29.flag_0) != 0;
				stream_0.Seek(long_0 + gclass577_1.method_11(), SeekOrigin.Begin);
				if (method_79() != 67324752)
				{
					throw new GException24($"Wrong local header signature @{long_0 + gclass577_1.method_11():X}");
				}
				short num2 = (short)method_78();
				short num3 = (short)method_78();
				short num4 = (short)method_78();
				short num5 = (short)method_78();
				short num6 = (short)method_78();
				uint num7 = method_79();
				long num8 = method_79();
				long num9 = method_79();
				int num10 = method_78();
				int num11 = method_78();
				byte[] array = new byte[num10];
				GClass563.smethod_0(stream_0, array);
				byte[] array2 = new byte[num11];
				GClass563.smethod_0(stream_0, array2);
				GClass585 gClass = new GClass585(array2);
				if (gClass.method_8(1))
				{
					num9 = gClass.method_19();
					num8 = gClass.method_19();
					if ((num3 & 8) != 0)
					{
						if (num9 != -1L && num9 != gclass577_1.method_30())
						{
							throw new GException24("Size invalid for descriptor");
						}
						if (num8 != -1L && num8 != gclass577_1.method_32())
						{
							throw new GException24("Compressed size invalid for descriptor");
						}
					}
				}
				else if (num2 >= 45 && ((int)num9 == -1 || (int)num8 == -1))
				{
					throw new GException24("Required Zip64 extended information missing");
				}
				if (flag2 && gclass577_1.method_51())
				{
					if (!gclass577_1.method_52())
					{
						throw new GException24("Compression method not supported");
					}
					if (num2 > 51 || (num2 > 20 && num2 < 45))
					{
						throw new GException24($"Version required to extract this entry not supported ({num2})");
					}
					if ((num3 & 0x3060) != 0)
					{
						throw new GException24("The library does not support the zip version required to extract this entry");
					}
				}
				if (flag)
				{
					if (num2 <= 63 && num2 != 10 && num2 != 11 && num2 != 20 && num2 != 21 && num2 != 25 && num2 != 27 && num2 != 45 && num2 != 46 && num2 != 50 && num2 != 51 && num2 != 52 && num2 != 61 && num2 != 62 && num2 != 63)
					{
						throw new GException24($"Version required to extract this entry is invalid ({num2})");
					}
					if ((num3 & 0xC010) != 0)
					{
						throw new GException24("Reserved bit flags cannot be set.");
					}
					if ((num3 & 1) != 0 && num2 < 20)
					{
						throw new GException24($"Version required to extract this entry is too low for encryption ({num2})");
					}
					if ((num3 & 0x40) != 0)
					{
						if ((num3 & 1) == 0)
						{
							throw new GException24("Strong encryption flag set but encryption flag is not set");
						}
						if (num2 < 50)
						{
							throw new GException24($"Version required to extract this entry is too low for encryption ({num2})");
						}
					}
					if ((num3 & 0x20) != 0 && num2 < 27)
					{
						throw new GException24($"Patched data requires higher version than ({num2})");
					}
					if (num3 != gclass577_1.method_7())
					{
						throw new GException24("Central header/local header flags mismatch");
					}
					if (gclass577_1.method_36() != (GEnum94)num4)
					{
						throw new GException24("Central header/local header compression method mismatch");
					}
					if (gclass577_1.method_20() != num2)
					{
						throw new GException24("Extract version mismatch");
					}
					if ((num3 & 0x40) != 0 && num2 < 62)
					{
						throw new GException24("Strong encryption flag set but version not high enough");
					}
					if ((num3 & 0x2000) != 0 && (num5 != 0 || num6 != 0))
					{
						throw new GException24("Header masked set but date/time values non-zero");
					}
					if ((num3 & 8) == 0 && num7 != (uint)gclass577_1.method_34())
					{
						throw new GException24("Central header/local header crc mismatch");
					}
					if (num9 == 0L && num8 == 0L && num7 != 0)
					{
						throw new GException24("Invalid CRC for empty entry");
					}
					if (gclass577_1.Name.Length > num10)
					{
						throw new GException24("File name length mismatch");
					}
					string a = GClass547.smethod_5(num3, array);
					if (a != gclass577_1.Name)
					{
						throw new GException24("Central header and local header file name mismatch");
					}
					if (gclass577_1.method_50())
					{
						if (num9 > 0L)
						{
							throw new GException24("Directory cannot have size");
						}
						if (gclass577_1.method_1())
						{
							if (num8 > 14L)
							{
								throw new GException24("Directory compressed size invalid");
							}
						}
						else if (num8 > 2L)
						{
							throw new GException24("Directory compressed size invalid");
						}
					}
					if (!GClass580.smethod_1(a, bool_0: true))
					{
						throw new GException24("Name is invalid");
					}
				}
				if ((num3 & 8) == 0 || num9 > 0L || num8 > 0L)
				{
					if (num9 != gclass577_1.method_30())
					{
						throw new GException24($"Size mismatch between central header({gclass577_1.method_30()}) and local header({num9})");
					}
					if (num8 != gclass577_1.method_32() && num8 != 4294967295L && num8 != -1L)
					{
						throw new GException24($"Compressed size mismatch between central header({gclass577_1.method_32()}) and local header({num8})");
					}
				}
				int num12 = num10 + num11;
				return long_0 + gclass577_1.method_11() + 30L + num12;
			}
		}

		public GInterface26 method_21()
		{
			return ginterface27_0.imethod_4();
		}

		public void method_22(GInterface26 ginterface26_0)
		{
			ginterface27_0.imethod_5(ginterface26_0);
		}

		public GInterface27 method_23()
		{
			return ginterface27_0;
		}

		public void method_24(GInterface27 ginterface27_1)
		{
			if (ginterface27_1 == null)
			{
				ginterface27_0 = new GClass578();
			}
			else
			{
				ginterface27_0 = ginterface27_1;
			}
		}

		public int method_25()
		{
			return int_1;
		}

		public void method_26(int int_2)
		{
			int num = 18;
			if (int_2 < 1024)
			{
				throw new ArgumentOutOfRangeException("value", "cannot be below 1024");
			}
			if (int_1 != int_2)
			{
				int_1 = int_2;
				byte_1 = null;
			}
		}

		public bool method_27()
		{
			return arrayList_0 != null;
		}

		public GEnum93 method_28()
		{
			return genum93_0;
		}

		public void method_29(GEnum93 genum93_1)
		{
			genum93_0 = genum93_1;
		}

		public void method_30(GInterface30 ginterface30_1, GInterface29 ginterface29_1)
		{
			int num = 17;
			if (ginterface30_1 == null)
			{
				throw new ArgumentNullException("archiveStorage");
			}
			if (ginterface29_1 == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			if (method_8())
			{
				throw new GException24("Cannot update embedded/SFX archives");
			}
			ginterface30_0 = ginterface30_1;
			ginterface29_0 = ginterface29_1;
			hashtable_0 = new Hashtable();
			arrayList_0 = new ArrayList(gclass577_0.Length);
			GClass577[] array = gclass577_0;
			foreach (GClass577 gClass in array)
			{
				int num2 = arrayList_0.Add(new Class222(gClass));
				hashtable_0.Add(gClass.Name, num2);
			}
			arrayList_0.Sort(new Class221());
			int num3 = 0;
			foreach (Class222 item in arrayList_0)
			{
				if (num3 == arrayList_0.Count - 1)
				{
					break;
				}
				item.method_9(((Class222)arrayList_0[num3 + 1]).method_0().method_11() - item.method_0().method_11());
				num3++;
			}
			long_1 = arrayList_0.Count;
			bool_3 = false;
			bool_4 = false;
			class223_0 = null;
		}

		public void method_31(GInterface30 ginterface30_1)
		{
			method_30(ginterface30_1, new GClass573());
		}

		public void method_32()
		{
			if (Name == null)
			{
				method_30(new GClass576(), new GClass573());
			}
			else
			{
				method_30(new GClass575(this), new GClass573());
			}
		}

		public void method_33()
		{
			int num = 8;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			method_76();
			try
			{
				hashtable_0.Clear();
				hashtable_0 = null;
				if (bool_3)
				{
					method_75();
				}
				else if (bool_4)
				{
					method_74();
				}
				else if (gclass577_0.Length == 0)
				{
					byte[] array = (class223_0 != null) ? class223_0.method_2() : GClass547.smethod_6(string_1);
					using (Stream0 stream = new Stream0(stream_0))
					{
						stream.method_5(0L, 0L, 0L, array);
					}
				}
			}
			finally
			{
				method_56();
			}
		}

		public void method_34()
		{
			method_56();
		}

		public void method_35(string string_3)
		{
			int num = 6;
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			method_76();
			class223_0 = new Class223(string_3);
			if (class223_0.method_1() > 65535)
			{
				class223_0 = null;
				throw new GException24("Comment length exceeds maximum - 65535");
			}
			bool_4 = true;
		}

		private void method_36(Class222 class222_0)
		{
			bool_3 = true;
			int num = method_66(class222_0.method_0().Name);
			if (num >= 0)
			{
				if (arrayList_0[num] == null)
				{
					long_1++;
				}
				arrayList_0[num] = class222_0;
			}
			else
			{
				num = arrayList_0.Add(class222_0);
				long_1++;
				hashtable_0.Add(class222_0.method_0().Name, num);
			}
		}

		public void method_37(string string_3, GEnum94 genum94_0, bool bool_5)
		{
			int num = 17;
			if (string_3 == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (bool_0)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			if (!GClass577.smethod_0(genum94_0))
			{
				throw new ArgumentOutOfRangeException("compressionMethod");
			}
			method_76();
			bool_3 = true;
			GClass577 gClass = method_23().imethod_0(string_3);
			gClass.method_4(bool_5);
			gClass.method_37(genum94_0);
			method_36(new Class222(string_3, gClass));
		}

		public void method_38(string string_3, GEnum94 genum94_0)
		{
			int num = 7;
			if (string_3 == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (!GClass577.smethod_0(genum94_0))
			{
				throw new ArgumentOutOfRangeException("compressionMethod");
			}
			method_76();
			bool_3 = true;
			GClass577 gClass = method_23().imethod_0(string_3);
			gClass.method_37(genum94_0);
			method_36(new Class222(string_3, gClass));
		}

		public void method_39(string string_3)
		{
			int num = 9;
			if (string_3 == null)
			{
				throw new ArgumentNullException("fileName");
			}
			method_76();
			method_36(new Class222(string_3, method_23().imethod_0(string_3)));
		}

		public void method_40(string string_3, string string_4)
		{
			int num = 1;
			if (string_3 == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (string_4 == null)
			{
				throw new ArgumentNullException("entryName");
			}
			method_76();
			method_36(new Class222(string_3, method_23().imethod_0(string_4)));
		}

		public void method_41(GInterface28 ginterface28_0, string string_3)
		{
			int num = 5;
			if (ginterface28_0 == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (string_3 == null)
			{
				throw new ArgumentNullException("entryName");
			}
			method_76();
			method_36(new Class222(ginterface28_0, method_23().imethod_1(string_3, bool_0: false)));
		}

		public void method_42(GInterface28 ginterface28_0, string string_3, GEnum94 genum94_0)
		{
			int num = 17;
			if (ginterface28_0 == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (string_3 == null)
			{
				throw new ArgumentNullException("entryName");
			}
			method_76();
			GClass577 gClass = method_23().imethod_1(string_3, bool_0: false);
			gClass.method_37(genum94_0);
			method_36(new Class222(ginterface28_0, gClass));
		}

		public void method_43(GInterface28 ginterface28_0, string string_3, GEnum94 genum94_0, bool bool_5)
		{
			int num = 3;
			if (ginterface28_0 == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (string_3 == null)
			{
				throw new ArgumentNullException("entryName");
			}
			method_76();
			GClass577 gClass = method_23().imethod_1(string_3, bool_0: false);
			gClass.method_4(bool_5);
			gClass.method_37(genum94_0);
			method_36(new Class222(ginterface28_0, gClass));
		}

		public void method_44(GClass577 gclass577_1)
		{
			int num = 5;
			if (gclass577_1 == null)
			{
				throw new ArgumentNullException("entry");
			}
			method_76();
			if (gclass577_1.method_30() != 0L || gclass577_1.method_32() != 0L)
			{
				throw new GException24("Entry cannot have any data");
			}
			method_36(new Class222(Enum30.const_2, gclass577_1));
		}

		public void method_45(string string_3)
		{
			int num = 6;
			if (string_3 == null)
			{
				throw new ArgumentNullException("directoryName");
			}
			method_76();
			GClass577 gclass577_ = method_23().imethod_2(string_3);
			method_36(new Class222(Enum30.const_2, gclass577_));
		}

		public bool method_46(string string_3)
		{
			int num = 13;
			if (string_3 == null)
			{
				throw new ArgumentNullException("fileName");
			}
			method_76();
			int num2 = method_66(string_3);
			if (num2 < 0 || arrayList_0[num2] == null)
			{
				throw new GException24("Cannot find entry to delete");
			}
			bool_3 = true;
			arrayList_0[num2] = null;
			long_1--;
			return true;
		}

		public void method_47(GClass577 gclass577_1)
		{
			int num = 4;
			if (gclass577_1 == null)
			{
				throw new ArgumentNullException("entry");
			}
			method_76();
			int num2 = method_65(gclass577_1);
			if (num2 < 0)
			{
				throw new GException24("Cannot find entry to delete");
			}
			bool_3 = true;
			arrayList_0[num2] = null;
			long_1--;
		}

		private void method_48(int int_2)
		{
			stream_0.WriteByte((byte)(int_2 & 0xFF));
			stream_0.WriteByte((byte)((int_2 >> 8) & 0xFF));
		}

		private void method_49(ushort ushort_0)
		{
			stream_0.WriteByte((byte)(ushort_0 & 0xFF));
			stream_0.WriteByte((byte)(ushort_0 >> 8));
		}

		private void method_50(int int_2)
		{
			method_48(int_2 & 0xFFFF);
			method_48(int_2 >> 16);
		}

		private void method_51(uint uint_0)
		{
			method_49((ushort)(uint_0 & 0xFFFF));
			method_49((ushort)(uint_0 >> 16));
		}

		private void method_52(long long_2)
		{
			method_50((int)(long_2 & 0xFFFFFFFF));
			method_50((int)(long_2 >> 32));
		}

		private void method_53(ulong ulong_0)
		{
			method_51((uint)(ulong_0 & 0xFFFFFFFF));
			method_51((uint)(ulong_0 >> 32));
		}

		private void method_54(Class222 class222_0)
		{
			int num = 19;
			GClass577 gClass = class222_0.method_1();
			gClass.method_12(stream_0.Position);
			if (class222_0.method_2() != 0)
			{
				if (gClass.method_36() == GEnum94.const_1)
				{
					if (gClass.method_30() == 0L)
					{
						gClass.method_33(gClass.method_30());
						gClass.method_35(0L);
						gClass.method_37(GEnum94.const_0);
					}
				}
				else if (gClass.method_36() == GEnum94.const_0)
				{
					gClass.method_8(gClass.method_7() & -9);
				}
				if (method_4())
				{
					gClass.method_2(bool_1: true);
					if (gClass.method_34() < 0L)
					{
						gClass.method_8(gClass.method_7() | 8);
					}
				}
				else
				{
					gClass.method_2(bool_1: false);
				}
				switch (genum93_0)
				{
				case GEnum93.const_1:
					gClass.method_22();
					break;
				case GEnum93.const_2:
					if (gClass.method_30() < 0L)
					{
						gClass.method_22();
					}
					break;
				}
			}
			method_50(67324752);
			method_48(gClass.method_20());
			method_48(gClass.method_7());
			method_48((byte)gClass.method_36());
			method_50((int)gClass.method_26());
			if (!gClass.method_0())
			{
				class222_0.method_7(stream_0.Position);
				method_50(0);
			}
			else
			{
				method_50((int)gClass.method_34());
			}
			if (gClass.method_24())
			{
				method_50(-1);
				method_50(-1);
			}
			else
			{
				if (gClass.method_32() < 0L || gClass.method_30() < 0L)
				{
					class222_0.method_5(stream_0.Position);
				}
				method_50((int)gClass.method_32());
				method_50((int)gClass.method_30());
			}
			byte[] array = GClass547.smethod_7(gClass.method_7(), gClass.Name);
			if (array.Length > 65535)
			{
				throw new GException24("Entry name too long.");
			}
			GClass585 gClass2 = new GClass585(gClass.method_39());
			if (gClass.method_24())
			{
				gClass2.method_11();
				gClass2.method_17(gClass.method_30());
				gClass2.method_17(gClass.method_32());
				gClass2.method_12(1);
			}
			else
			{
				gClass2.method_18(1);
			}
			gClass.method_40(gClass2.method_0());
			method_48(array.Length);
			method_48(gClass.method_39().Length);
			if (array.Length > 0)
			{
				stream_0.Write(array, 0, array.Length);
			}
			if (gClass.method_24())
			{
				if (!gClass2.method_8(1))
				{
					throw new GException24("Internal error cannot find extra data");
				}
				class222_0.method_5(stream_0.Position + gClass2.method_6());
			}
			if (gClass.method_39().Length > 0)
			{
				stream_0.Write(gClass.method_39(), 0, gClass.method_39().Length);
			}
		}

		private int method_55(GClass577 gclass577_1)
		{
			int num = 4;
			if (gclass577_1.method_32() < 0L)
			{
				throw new GException24("Attempt to write central directory entry with unknown csize");
			}
			if (gclass577_1.method_30() < 0L)
			{
				throw new GException24("Attempt to write central directory entry with unknown size");
			}
			if (gclass577_1.method_34() < 0L)
			{
				throw new GException24("Attempt to write central directory entry with unknown crc");
			}
			method_50(33639248);
			method_48(51);
			method_48(gclass577_1.method_20());
			method_48(gclass577_1.method_7());
			method_48((byte)gclass577_1.method_36());
			method_50((int)gclass577_1.method_26());
			method_50((int)gclass577_1.method_34());
			if (gclass577_1.method_23() || gclass577_1.method_32() >= 4294967295L)
			{
				method_50(-1);
			}
			else
			{
				method_50((int)(gclass577_1.method_32() & 0xFFFFFFFF));
			}
			if (gclass577_1.method_23() || gclass577_1.method_30() >= 4294967295L)
			{
				method_50(-1);
			}
			else
			{
				method_50((int)gclass577_1.method_30());
			}
			byte[] array = GClass547.smethod_7(gclass577_1.method_7(), gclass577_1.Name);
			if (array.Length > 65535)
			{
				throw new GException24("Entry name is too long.");
			}
			method_48(array.Length);
			GClass585 gClass = new GClass585(gclass577_1.method_39());
			if (gclass577_1.method_25())
			{
				gClass.method_11();
				if (gclass577_1.method_30() >= 4294967295L || genum93_0 == GEnum93.const_1)
				{
					gClass.method_17(gclass577_1.method_30());
				}
				if (gclass577_1.method_32() >= 4294967295L || genum93_0 == GEnum93.const_1)
				{
					gClass.method_17(gclass577_1.method_32());
				}
				if (gclass577_1.method_11() >= 4294967295L)
				{
					gClass.method_17(gclass577_1.method_11());
				}
				gClass.method_12(1);
			}
			else
			{
				gClass.method_18(1);
			}
			byte[] array2 = gClass.method_0();
			method_48(array2.Length);
			method_48((gclass577_1.method_48() != null) ? gclass577_1.method_48().Length : 0);
			method_48(0);
			method_48(0);
			if (gclass577_1.method_13() != -1)
			{
				method_50(gclass577_1.method_13());
			}
			else if (gclass577_1.method_50())
			{
				method_51(16u);
			}
			else
			{
				method_51(0u);
			}
			if (gclass577_1.method_11() >= 4294967295L)
			{
				method_51(uint.MaxValue);
			}
			else
			{
				method_51((uint)gclass577_1.method_11());
			}
			if (array.Length > 0)
			{
				stream_0.Write(array, 0, array.Length);
			}
			if (array2.Length > 0)
			{
				stream_0.Write(array2, 0, array2.Length);
			}
			byte[] array3 = (gclass577_1.method_48() != null) ? Encoding.ASCII.GetBytes(gclass577_1.method_48()) : new byte[0];
			if (array3.Length > 0)
			{
				stream_0.Write(array3, 0, array3.Length);
			}
			return 46 + array.Length + array2.Length + array3.Length;
		}

		private void method_56()
		{
			ginterface29_0 = null;
			arrayList_0 = null;
			hashtable_0 = null;
			if (ginterface30_0 != null)
			{
				ginterface30_0.imethod_5();
				ginterface30_0 = null;
			}
		}

		private string method_57(string string_3)
		{
			GInterface26 gInterface = method_21();
			return (gInterface != null) ? gInterface.imethod_0(string_3) : string_3;
		}

		private string method_58(string string_3)
		{
			GInterface26 gInterface = method_21();
			return (gInterface != null) ? gInterface.imethod_1(string_3) : string_3;
		}

		private byte[] method_59()
		{
			if (byte_1 == null)
			{
				byte_1 = new byte[int_1];
			}
			return byte_1;
		}

		private void method_60(Class222 class222_0, Stream stream_1, Stream stream_2)
		{
			int num = 18;
			int num2 = method_62(class222_0);
			if (num2 <= 0)
			{
				return;
			}
			byte[] array = method_59();
			while (true)
			{
				if (num2 > 0)
				{
					int count = Math.Min(array.Length, num2);
					int num3 = stream_2.Read(array, 0, count);
					if (num3 <= 0)
					{
						break;
					}
					stream_1.Write(array, 0, num3);
					num2 -= num3;
					continue;
				}
				return;
			}
			throw new GException24("Unxpected end of stream");
		}

		private void method_61(Class222 class222_0, Stream stream_1, Stream stream_2, long long_2, bool bool_5)
		{
			int num = 4;
			if (stream_1 == stream_2)
			{
				throw new InvalidOperationException("Destination and source are the same");
			}
			GClass548 gClass = new GClass548();
			byte[] array = method_59();
			long num2 = long_2;
			long num3 = 0L;
			int num5;
			do
			{
				int num4 = array.Length;
				if (long_2 < num4)
				{
					num4 = (int)long_2;
				}
				num5 = stream_2.Read(array, 0, num4);
				if (num5 > 0)
				{
					if (bool_5)
					{
						gClass.imethod_4(array, 0, num5);
					}
					stream_1.Write(array, 0, num5);
					long_2 -= num5;
					num3 += num5;
				}
			}
			while (num5 > 0 && long_2 > 0L);
			if (num3 != num2)
			{
				throw new GException24($"Failed to copy bytes expected {num2} read {num3}");
			}
			if (bool_5)
			{
				class222_0.method_1().method_35(gClass.imethod_0());
			}
		}

		private int method_62(Class222 class222_0)
		{
			int result = 0;
			if ((class222_0.method_0().method_7() & 8) != 0)
			{
				result = 12;
				if (class222_0.method_0().method_24())
				{
					result = 20;
				}
			}
			return result;
		}

		private void method_63(Class222 class222_0, Stream stream_1, ref long long_2, long long_3)
		{
			int num = 18;
			int num2 = method_62(class222_0);
			while (true)
			{
				if (num2 > 0)
				{
					int count = num2;
					byte[] buffer = method_59();
					stream_1.Position = long_3;
					int num3 = stream_1.Read(buffer, 0, count);
					if (num3 <= 0)
					{
						break;
					}
					stream_1.Position = long_2;
					stream_1.Write(buffer, 0, num3);
					num2 -= num3;
					long_2 += num3;
					long_3 += num3;
					continue;
				}
				return;
			}
			throw new GException24("Unxpected end of stream");
		}

		private void method_64(Class222 class222_0, Stream stream_1, bool bool_5, ref long long_2, ref long long_3)
		{
			int num = 5;
			long num2 = class222_0.method_0().method_32();
			GClass548 gClass = new GClass548();
			byte[] array = method_59();
			long num3 = num2;
			long num4 = 0L;
			int num6;
			do
			{
				int num5 = array.Length;
				if (num2 < num5)
				{
					num5 = (int)num2;
				}
				stream_1.Position = long_3;
				num6 = stream_1.Read(array, 0, num5);
				if (num6 > 0)
				{
					if (bool_5)
					{
						gClass.imethod_4(array, 0, num6);
					}
					stream_1.Position = long_2;
					stream_1.Write(array, 0, num6);
					long_2 += num6;
					long_3 += num6;
					num2 -= num6;
					num4 += num6;
				}
			}
			while (num6 > 0 && num2 > 0L);
			if (num4 != num3)
			{
				throw new GException24($"Failed to copy bytes expected {num3} read {num4}");
			}
			if (bool_5)
			{
				class222_0.method_1().method_35(gClass.imethod_0());
			}
		}

		private int method_65(GClass577 gclass577_1)
		{
			int result = -1;
			string key = method_57(gclass577_1.Name);
			if (hashtable_0.ContainsKey(key))
			{
				result = (int)hashtable_0[key];
			}
			return result;
		}

		private int method_66(string string_3)
		{
			int result = -1;
			string key = method_57(string_3);
			if (hashtable_0.ContainsKey(key))
			{
				result = (int)hashtable_0[key];
			}
			return result;
		}

		private Stream method_67(GClass577 gclass577_1)
		{
			int num = 15;
			Stream stream_ = stream_0;
			if (gclass577_1.method_1())
			{
				stream_ = method_85(stream_, gclass577_1);
			}
			switch (gclass577_1.method_36())
			{
			default:
				throw new GException24("Unknown compression method " + gclass577_1.method_36());
			case GEnum94.const_1:
			{
				GStream5 gStream = new GStream5(stream_, new GClass586(9, bool_1: true));
				gStream.method_1(bool_2: false);
				return gStream;
			}
			case GEnum94.const_0:
				return new Stream1(stream_);
			}
		}

		private void method_68(GClass571 gclass571_0, Class222 class222_0)
		{
			int num = 16;
			Stream stream = null;
			if (class222_0.method_0().method_51())
			{
				stream = class222_0.method_10();
				if (stream == null)
				{
					stream = ginterface29_0.imethod_0(class222_0.method_0(), class222_0.method_3());
				}
			}
			if (stream != null)
			{
				using (stream)
				{
					long length = stream.Length;
					if (class222_0.method_1().method_30() < 0L)
					{
						class222_0.method_1().method_31(length);
					}
					else if (class222_0.method_1().method_30() != length)
					{
						throw new GException24("Entry size/stream size mismatch");
					}
					gclass571_0.method_54(class222_0);
					long position = gclass571_0.stream_0.Position;
					using (Stream stream_ = gclass571_0.method_67(class222_0.method_1()))
					{
						method_61(class222_0, stream_, stream, length, bool_5: true);
					}
					long position2 = gclass571_0.stream_0.Position;
					class222_0.method_1().method_33(position2 - position);
					if ((class222_0.method_1().method_7() & 8) == 8)
					{
						Stream0 stream2 = new Stream0(gclass571_0.stream_0);
						stream2.method_15(class222_0.method_1());
					}
				}
				return;
			}
			gclass571_0.method_54(class222_0);
			class222_0.method_1().method_33(0L);
		}

		private void method_69(GClass571 gclass571_0, Class222 class222_0)
		{
			gclass571_0.method_54(class222_0);
			long position = gclass571_0.stream_0.Position;
			if (class222_0.method_0().method_51() && class222_0.method_3() != null)
			{
				using (Stream stream_ = gclass571_0.method_67(class222_0.method_1()))
				{
					using (Stream stream = method_16(class222_0.method_0()))
					{
						method_61(class222_0, stream_, stream, stream.Length, bool_5: true);
					}
				}
			}
			long position2 = gclass571_0.stream_0.Position;
			class222_0.method_0().method_33(position2 - position);
		}

		private void method_70(GClass571 gclass571_0, Class222 class222_0, ref long long_2)
		{
			bool flag = false;
			if (class222_0.method_0().method_11() == long_2)
			{
				flag = true;
			}
			if (!flag)
			{
				stream_0.Position = long_2;
				gclass571_0.method_54(class222_0);
				long_2 = stream_0.Position;
			}
			long num = 0L;
			long num2 = class222_0.method_0().method_11() + 26L;
			stream_0.Seek(num2, SeekOrigin.Begin);
			uint num3 = method_78();
			uint num4 = method_78();
			num = stream_0.Position + num3 + num4;
			if (flag)
			{
				if (class222_0.method_8() != -1L)
				{
					long_2 += class222_0.method_8();
				}
				else
				{
					long_2 += num - num2 + 26L + class222_0.method_0().method_32() + method_62(class222_0);
				}
				return;
			}
			if (class222_0.method_0().method_32() > 0L)
			{
				method_64(class222_0, stream_0, bool_5: false, ref long_2, ref num);
			}
			method_63(class222_0, stream_0, ref long_2, num);
		}

		private void method_71(GClass571 gclass571_0, Class222 class222_0)
		{
			gclass571_0.method_54(class222_0);
			if (class222_0.method_0().method_32() > 0L)
			{
				long offset = class222_0.method_0().method_11() + 26L;
				stream_0.Seek(offset, SeekOrigin.Begin);
				uint num = method_78();
				uint num2 = method_78();
				stream_0.Seek(num + num2, SeekOrigin.Current);
				method_61(class222_0, gclass571_0.stream_0, stream_0, class222_0.method_0().method_32(), bool_5: false);
			}
			method_60(class222_0, gclass571_0.stream_0, stream_0);
		}

		private void method_72(Stream stream_1)
		{
			int num = 11;
			if (stream_1 == null)
			{
				throw new GException24("Failed to reopen archive - no source");
			}
			bool_2 = false;
			stream_0 = stream_1;
			method_82();
		}

		private void method_73()
		{
			int num = 10;
			if (Name == null)
			{
				throw new InvalidOperationException("Name is not known cannot Reopen");
			}
			method_72(File.Open(Name, FileMode.Open, FileAccess.Read, FileShare.Read));
		}

		private void method_74()
		{
			int num = 3;
			long length = stream_0.Length;
			Stream0 stream = null;
			if (ginterface30_0.imethod_0() == GEnum100.const_0)
			{
				Stream stream_ = ginterface30_0.imethod_3(stream_0);
				stream = new Stream0(stream_);
				stream.method_1(bool_1: true);
				stream_0.Close();
				stream_0 = null;
			}
			else if (ginterface30_0.imethod_0() == GEnum100.const_1)
			{
				stream_0 = ginterface30_0.imethod_4(stream_0);
				stream = new Stream0(stream_0);
			}
			else
			{
				stream_0.Close();
				stream_0 = null;
				stream = new Stream0(Name);
			}
			using (stream)
			{
				long num2 = stream.method_3(101010256, length, 22, 65535);
				if (num2 < 0L)
				{
					throw new GException24("Cannot find central directory");
				}
				stream.Position += 16L;
				byte[] array = class223_0.method_2();
				stream.method_9(array.Length);
				stream.Write(array, 0, array.Length);
				stream.SetLength(stream.Position);
			}
			if (ginterface30_0.imethod_0() == GEnum100.const_0)
			{
				method_72(ginterface30_0.imethod_2());
			}
			else
			{
				method_82();
			}
		}

		private void method_75()
		{
			long num = 0L;
			long num2 = 0L;
			bool flag = false;
			long long_ = 0L;
			GClass571 gClass;
			if (method_9())
			{
				gClass = this;
				gClass.stream_0.Position = 0L;
				flag = true;
			}
			else if (ginterface30_0.imethod_0() == GEnum100.const_1)
			{
				gClass = this;
				gClass.stream_0.Position = 0L;
				flag = true;
				arrayList_0.Sort(new Class221());
			}
			else
			{
				gClass = smethod_1(ginterface30_0.imethod_1());
				gClass.method_29(method_28());
				if (byte_0 != null)
				{
					gClass.byte_0 = (byte[])byte_0.Clone();
				}
			}
			try
			{
				foreach (Class222 item in arrayList_0)
				{
					if (item != null)
					{
						switch (item.method_2())
						{
						case Enum30.const_0:
							if (flag)
							{
								method_70(gClass, item, ref long_);
							}
							else
							{
								method_71(gClass, item);
							}
							break;
						case Enum30.const_1:
							method_69(gClass, item);
							break;
						case Enum30.const_2:
							if (!method_9() && flag)
							{
								gClass.stream_0.Position = long_;
							}
							method_68(gClass, item);
							if (flag)
							{
								long_ = gClass.stream_0.Position;
							}
							break;
						}
					}
				}
				if (!method_9() && flag)
				{
					gClass.stream_0.Position = long_;
				}
				long position = gClass.stream_0.Position;
				foreach (Class222 item2 in arrayList_0)
				{
					if (item2 != null)
					{
						num += gClass.method_55(item2.method_1());
					}
				}
				byte[] array = (class223_0 != null) ? class223_0.method_2() : GClass547.smethod_6(string_1);
				using (Stream0 stream = new Stream0(gClass.stream_0))
				{
					stream.method_5(long_1, num, position, array);
				}
				num2 = gClass.stream_0.Position;
				foreach (Class222 item3 in arrayList_0)
				{
					if (item3 != null)
					{
						if (item3.method_6() > 0L && item3.method_1().method_32() > 0L)
						{
							gClass.stream_0.Position = item3.method_6();
							gClass.method_50((int)item3.method_1().method_34());
						}
						if (item3.method_4() > 0L)
						{
							gClass.stream_0.Position = item3.method_4();
							if (item3.method_1().method_24())
							{
								gClass.method_52(item3.method_1().method_30());
								gClass.method_52(item3.method_1().method_32());
							}
							else
							{
								gClass.method_50((int)item3.method_1().method_32());
								gClass.method_50((int)item3.method_1().method_30());
							}
						}
					}
				}
			}
			catch
			{
				gClass.method_5();
				if (!flag && gClass.Name != null)
				{
					File.Delete(gClass.Name);
				}
				throw;
			}
			if (flag)
			{
				gClass.stream_0.SetLength(num2);
				gClass.stream_0.Flush();
				bool_2 = false;
				method_82();
			}
			else
			{
				stream_0.Close();
				method_72(ginterface30_0.imethod_2());
			}
		}

		private void method_76()
		{
			int num = 17;
			if (arrayList_0 == null)
			{
				throw new InvalidOperationException("BeginUpdate has not been called");
			}
		}

		void IDisposable.Dispose()
		{
			method_5();
		}

		private void method_77(bool bool_5)
		{
			if (!bool_0)
			{
				bool_0 = true;
				gclass577_0 = new GClass577[0];
				if (method_6() && stream_0 != null)
				{
					lock (stream_0)
					{
						stream_0.Close();
					}
				}
				method_56();
			}
		}

		protected virtual void vmethod_0(bool bool_5)
		{
			method_77(bool_5);
		}

		private ushort method_78()
		{
			int num = 1;
			int num2 = stream_0.ReadByte();
			if (num2 < 0)
			{
				throw new EndOfStreamException("End of stream");
			}
			int num3 = stream_0.ReadByte();
			if (num3 < 0)
			{
				throw new EndOfStreamException("End of stream");
			}
			return (ushort)((ushort)num2 | (ushort)(num3 << 8));
		}

		private uint method_79()
		{
			return (uint)(method_78() | (method_78() << 16));
		}

		private ulong method_80()
		{
			return method_79() | ((ulong)method_79() << 32);
		}

		private long method_81(int int_2, long long_2, int int_3, int int_4)
		{
			using (Stream0 stream = new Stream0(stream_0))
			{
				return stream.method_3(int_2, long_2, int_3, int_4);
			}
		}

		private void method_82()
		{
			int num = 3;
			if (!stream_0.CanSeek)
			{
				throw new GException24("ZipFile stream must be seekable");
			}
			long num2 = method_81(101010256, stream_0.Length, 22, 65535);
			if (num2 < 0L)
			{
				throw new GException24("Cannot find central directory");
			}
			ushort num3 = method_78();
			ushort num4 = method_78();
			ulong num5 = method_78();
			ulong num6 = method_78();
			ulong num7 = method_79();
			long num8 = method_79();
			uint num9 = method_78();
			if (num9 != 0)
			{
				byte[] array = new byte[num9];
				GClass563.smethod_0(stream_0, array);
				string_1 = GClass547.smethod_3(array);
			}
			else
			{
				string_1 = string.Empty;
			}
			bool flag = false;
			if (num3 == ushort.MaxValue || num4 == ushort.MaxValue || num5 == 65535L || num6 == 65535L || num7 == 4294967295L || num8 == 4294967295L)
			{
				flag = true;
				long num10 = method_81(117853008, num2, 0, 4096);
				if (num10 < 0L)
				{
					throw new GException24("Cannot find Zip64 locator");
				}
				method_79();
				ulong num11 = method_80();
				method_79();
				stream_0.Position = (long)num11;
				long num12 = method_79();
				if (num12 != 101075792L)
				{
					throw new GException24($"Invalid Zip64 Central directory signature at {num11:X}");
				}
				method_80();
				int num13 = method_78();
				int num14 = method_78();
				method_79();
				method_79();
				num5 = method_80();
				num6 = method_80();
				num7 = method_80();
				num8 = (long)method_80();
			}
			gclass577_0 = new GClass577[num5];
			if (!flag && num8 < num2 - (long)(4L + num7))
			{
				long_0 = num2 - ((long)(4L + num7) + num8);
				if (long_0 <= 0L)
				{
					throw new GException24("Invalid embedded zip archive");
				}
			}
			stream_0.Seek(long_0 + num8, SeekOrigin.Begin);
			ulong num15 = 0uL;
			while (true)
			{
				if (num15 < num5)
				{
					if (method_79() != 33639248)
					{
						break;
					}
					int num13 = method_78();
					int num14 = method_78();
					int num16 = method_78();
					int genum94_ = method_78();
					uint num17 = method_79();
					uint num18 = method_79();
					long num19 = method_79();
					long num20 = method_79();
					int num21 = method_78();
					int num22 = method_78();
					int num23 = method_78();
					method_78();
					method_78();
					uint int_ = method_79();
					long num10 = method_79();
					byte[] array2 = new byte[Math.Max(num21, num23)];
					GClass563.smethod_1(stream_0, array2, 0, num21);
					string text = GClass547.smethod_4(num16, array2, num21);
					GClass577 gClass = new GClass577(text, num14, num13, (GEnum94)genum94_);
					gClass.method_35(num18 & 0xFFFFFFFF);
					gClass.method_31(num20 & 0xFFFFFFFF);
					gClass.method_33(num19 & 0xFFFFFFFF);
					gClass.method_8(num16);
					gClass.method_27(num17);
					gClass.method_10((long)num15);
					gClass.method_12(num10);
					gClass.method_14((int)int_);
					if ((num16 & 8) == 0)
					{
						gClass.method_6((byte)(num18 >> 24));
					}
					else
					{
						gClass.method_6((byte)((num17 >> 8) & 0xFF));
					}
					if (num22 > 0)
					{
						byte[] byte_ = new byte[num22];
						GClass563.smethod_0(stream_0, byte_);
						gClass.method_40(byte_);
					}
					gClass.method_46(bool_1: false);
					if (num23 > 0)
					{
						GClass563.smethod_1(stream_0, array2, 0, num23);
						gClass.method_49(GClass547.smethod_4(num16, array2, num23));
					}
					gclass577_0[num15] = gClass;
					num15++;
					continue;
				}
				return;
			}
			throw new GException24("Wrong Central Directory signature");
		}

		private long method_83(GClass577 gclass577_1)
		{
			return method_20(gclass577_1, Enum29.flag_0);
		}

		private Stream method_84(Stream stream_1, GClass577 gclass577_1)
		{
			int num = 14;
			CryptoStream cryptoStream = null;
			if (gclass577_1.method_20() < 50 || (gclass577_1.method_7() & 0x40) == 0)
			{
				GClass565 gClass = new GClass565();
				method_0(gclass577_1.Name);
				if (!method_4())
				{
					throw new GException24("No password available for encrypted stream");
				}
				cryptoStream = new CryptoStream(stream_1, gClass.CreateDecryptor(byte_0, null), CryptoStreamMode.Read);
				smethod_2(cryptoStream, gclass577_1);
			}
			else
			{
				if (gclass577_1.method_20() != 51)
				{
					throw new GException24("Decryption method not supported");
				}
				method_0(gclass577_1.Name);
				if (!method_4())
				{
					throw new GException24("No password available for AES encrypted stream");
				}
				int num2 = gclass577_1.method_44();
				byte[] array = new byte[num2];
				int num3 = stream_1.Read(array, 0, num2);
				if (num3 != num2)
				{
					throw new GException24("AES Salt expected " + num2 + " got " + num3);
				}
				byte[] array2 = new byte[2];
				stream_1.Read(array2, 0, 2);
				int int_ = gclass577_1.method_41() / 8;
				Class225 @class = new Class225(string_2, array, int_, bool_2: false);
				byte[] array3 = @class.method_0();
				if (array3[0] != array2[0] || array3[1] != array2[1])
				{
					throw new Exception("Invalid password for AES");
				}
				cryptoStream = new Stream3(stream_1, @class, CryptoStreamMode.Read);
			}
			return cryptoStream;
		}

		private Stream method_85(Stream stream_1, GClass577 gclass577_1)
		{
			int num = 3;
			CryptoStream cryptoStream = null;
			if (gclass577_1.method_20() < 50 || (gclass577_1.method_7() & 0x40) == 0)
			{
				GClass565 gClass = new GClass565();
				method_0(gclass577_1.Name);
				if (!method_4())
				{
					throw new GException24("No password available for encrypted stream");
				}
				cryptoStream = new CryptoStream(new Stream1(stream_1), gClass.CreateEncryptor(byte_0, null), CryptoStreamMode.Write);
				if (gclass577_1.method_34() < 0L || (gclass577_1.method_7() & 8) != 0)
				{
					smethod_3(cryptoStream, gclass577_1.method_26() << 16);
				}
				else
				{
					smethod_3(cryptoStream, gclass577_1.method_34());
				}
			}
			return cryptoStream;
		}

		private static void smethod_2(CryptoStream cryptoStream_0, GClass577 gclass577_1)
		{
			int num = 9;
			byte[] array = new byte[12];
			GClass563.smethod_0(cryptoStream_0, array);
			if (array[11] != gclass577_1.method_5())
			{
				throw new GException24("Invalid password");
			}
		}

		private static void smethod_3(Stream stream_1, long long_2)
		{
			byte[] array = new byte[12];
			Random random = new Random();
			random.NextBytes(array);
			array[11] = (byte)(long_2 >> 24);
			stream_1.Write(array, 0, array.Length);
		}
	}
}
