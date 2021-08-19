using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass478
	{
		private class Class212 : IComparable<Class212>
		{
			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;

			public int CompareTo(Class212 other)
			{
				return int_1 - other.int_1;
			}

			public override string ToString()
			{
				return int_1 + "->" + int_2 + " Range:" + Convert.ToString(int_2 - int_1) + " Width:" + int_0;
			}
		}

		private GClass496 gclass496_0;

		private GClass486 gclass486_0;

		private GClass488 gclass488_0;

		private GClass481 gclass481_0;

		private GClass483 gclass483_0;

		private GClass484 gclass484_0;

		private GClass485 gclass485_0;

		private GClass482 gclass482_0;

		private GClass490 gclass490_0;

		private GClass489 gclass489_0;

		private GClass491 gclass491_0;

		private GClass487 gclass487_0;

		private GClass487 gclass487_1;

		private GClass487 gclass487_2;

		public GClass491 Name => gclass491_0;

		public static GClass478 smethod_0(byte[] byte_0, string string_0)
		{
			int num = 4;
			if (byte_0 == null || byte_0.Length < 100)
			{
				return null;
			}
			MemoryStream memoryStream = new MemoryStream(byte_0);
			byte[] array = new byte[4];
			memoryStream.Read(array, 0, array.Length);
			if (Encoding.ASCII.GetString(array) != "ttcf")
			{
				throw new Exception("不是 ttcf 头");
			}
			memoryStream.Position += 4L;
			int num2 = smethod_3(memoryStream);
			int[] array2 = new int[num2];
			int i;
			for (i = 0; i < num2; i++)
			{
				array2[i] = smethod_3(memoryStream);
			}
			i = 0;
			while (true)
			{
				if (i < num2)
				{
					memoryStream.Position = array2[i];
					int num3 = smethod_3(memoryStream);
					if (num3 == 65536 || num3 == 83182916)
					{
						int num4 = smethod_2(memoryStream);
						memoryStream.Position += 6L;
						Hashtable hashtable = new Hashtable();
						for (int j = 0; j < num4; j++)
						{
							memoryStream.Read(array, 0, array.Length);
							string @string = Encoding.ASCII.GetString(array);
							memoryStream.Position += 4L;
							hashtable[@string] = new int[2]
							{
								smethod_3(memoryStream),
								smethod_3(memoryStream)
							};
						}
						int[] array3 = (int[])hashtable["name"];
						if (array3 == null)
						{
							break;
						}
						memoryStream.Position = array3[0] + 2;
						int num5 = smethod_2(memoryStream);
						int num6 = smethod_2(memoryStream);
						new ArrayList();
						for (int k = 0; k < num5; k++)
						{
							int num7 = smethod_2(memoryStream);
							int num8 = smethod_2(memoryStream);
							smethod_2(memoryStream);
							int num9 = smethod_2(memoryStream);
							int num10 = smethod_2(memoryStream);
							int num11 = smethod_2(memoryStream);
							if (num9 == 4)
							{
								_ = memoryStream.Position;
								long position = memoryStream.Position;
								memoryStream.Position = array3[0] + num6 + num11;
								int num12;
								switch (num7)
								{
								case 2:
									num12 = ((num8 != 1) ? 1 : 0);
									break;
								default:
									num12 = 1;
									break;
								case 0:
								case 3:
									num12 = 0;
									break;
								}
								string @string;
								if (num12 == 0)
								{
									@string = smethod_1(memoryStream, num10);
								}
								else
								{
									byte[] array4 = new byte[num10];
									memoryStream.Read(array4, 0, array4.Length);
									@string = Encoding.ASCII.GetString(array4);
								}
								if (@string == string_0)
								{
									int int_ = array2[i];
									GClass478 gClass = new GClass478();
									gClass.method_4(byte_0, int_);
									return gClass;
								}
								memoryStream.Position = position;
							}
						}
						i++;
						continue;
					}
					throw new Exception("错误的ttf格式");
				}
				return null;
			}
			throw new Exception("没有 name 项目");
		}

		private static string smethod_1(Stream stream_0, int int_0)
		{
			int num = 19;
			int num2 = int_0 / 2;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < num2; i++)
			{
				int num3 = stream_0.ReadByte();
				int num4 = stream_0.ReadByte();
				if ((num3 | num4) >= 0)
				{
					stringBuilder.Append((char)((num3 << 8) + num4));
					continue;
				}
				throw new Exception("EOF");
			}
			return stringBuilder.ToString();
		}

		private static int smethod_2(Stream stream_0)
		{
			int num = 13;
			int num2 = stream_0.ReadByte();
			int num3 = stream_0.ReadByte();
			if ((num2 | num3) < 0)
			{
				throw new Exception("EOF");
			}
			return (num2 << 8) + num3;
		}

		private static int smethod_3(Stream stream_0)
		{
			int num = 6;
			int num2 = stream_0.ReadByte();
			int num3 = stream_0.ReadByte();
			int num4 = stream_0.ReadByte();
			int num5 = stream_0.ReadByte();
			if ((num2 | num3 | num4 | num5) < 0)
			{
				throw new Exception("EOF");
			}
			return (num2 << 24) + (num3 << 16) + (num4 << 8) + num5;
		}

		public GClass478()
		{
			gclass496_0 = new GClass496(this);
			gclass481_0 = new GClass481(this);
			gclass482_0 = new GClass482(this);
			gclass483_0 = new GClass483(this);
			gclass484_0 = new GClass484(this);
			gclass490_0 = new GClass490(this);
			gclass489_0 = new GClass489(this);
			gclass485_0 = new GClass485(this);
			gclass488_0 = new GClass488(this);
			gclass486_0 = new GClass486(this);
			gclass491_0 = new GClass491(this);
			gclass487_0 = new GClass487(this, "prep");
			gclass487_1 = new GClass487(this, "cvt ");
			gclass487_2 = new GClass487(this, "fpgm");
		}

		private void method_0(ushort ushort_0, GClass495 gclass495_0)
		{
			if (!gclass495_0.method_0(ushort_0))
			{
				return;
			}
			GClass492 gClass = method_19().method_9()[ushort_0];
			if (gClass != null && gClass.method_3() is GClass494)
			{
				GClass494 gClass2 = gClass.method_3() as GClass494;
				for (int i = 0; i < gClass2.method_3(); i++)
				{
					method_0(gClass2.method_4(i), gclass495_0);
				}
			}
		}

		private void method_1(GClass478 gclass478_0, GClass479 gclass479_0)
		{
			method_19().method_3(gclass478_0.method_19(), gclass479_0);
			method_18().method_2(gclass478_0.method_18());
			method_12().method_2(gclass478_0.method_12());
			method_13().method_2(gclass478_0.method_13());
			method_14().method_2(gclass478_0.method_14());
			method_15().method_2(gclass478_0.method_15());
			method_21().method_2(gclass478_0.method_21());
			method_22().method_2(gclass478_0.method_22());
			method_23().method_2(gclass478_0.method_23());
			gclass496_0.method_7(gclass478_0.method_11());
		}

		private void method_2(GClass498 gclass498_0)
		{
			gclass496_0.method_3(gclass498_0);
			method_12().method_1(gclass498_0);
			method_14().method_1(gclass498_0);
			method_13().method_1(gclass498_0);
			method_15().method_1(gclass498_0);
			method_18().method_1(gclass498_0);
			method_19().method_1(gclass498_0);
			method_21().method_1(gclass498_0);
			method_22().method_1(gclass498_0);
			method_23().method_1(gclass498_0);
			gclass498_0.method_25();
			gclass496_0.method_5(gclass498_0);
			gclass496_0.method_6(gclass498_0);
			method_12().method_6(gclass498_0);
		}

		public void method_3(byte[] byte_0)
		{
			method_4(byte_0, 0);
		}

		public void method_4(byte[] byte_0, int int_0)
		{
			GClass498 gclass498_ = new GClass500(byte_0);
			gclass496_0.method_2(gclass498_, int_0);
			gclass481_0.method_0(gclass498_);
			gclass483_0.method_0(gclass498_);
			gclass482_0.method_0(gclass498_);
			gclass484_0.method_0(gclass498_);
			gclass485_0.method_0(gclass498_);
			gclass488_0.method_0(gclass498_);
			gclass487_0.method_0(gclass498_);
			gclass487_1.method_0(gclass498_);
			gclass487_2.method_0(gclass498_);
			gclass489_0.method_0(gclass498_);
			gclass490_0.method_0(gclass498_);
			gclass491_0.method_0(gclass498_);
			gclass486_0.method_0(gclass498_);
		}

		public void method_5(Stream stream_0, char[] char_0, string string_0)
		{
			GClass478 gClass = new GClass478();
			GClass479 gClass2 = new GClass479();
			gClass2.char_0 = char_0;
			gClass2.ushort_0 = method_10(char_0);
			gClass2.string_0 = string_0;
			gClass.method_1(this, gClass2);
			gClass.method_2(new GClass499(stream_0));
		}

		public int[] method_6()
		{
			List<Class212> list = new List<Class212>();
			for (int i = 0; i < method_20().ushort_2.Length; i++)
			{
				int num = method_20().ushort_3[i];
				int num2 = method_20().ushort_2[i];
				int num3 = 0;
				Class212 @class = new Class212();
				@class.int_1 = num;
				list.Add(@class);
				for (int j = num; j <= num2; j++)
				{
					int ushort_ = method_15().method_7(method_20().method_17((ushort)j)).ushort_0;
					if (j == num)
					{
						@class.int_0 = ushort_;
						@class.int_1 = num;
					}
					else if (num3 != ushort_)
					{
						@class.int_2 = j - 1;
						@class = new Class212();
						@class.int_1 = j;
						@class.int_0 = ushort_;
						list.Add(@class);
					}
					num3 = ushort_;
				}
				@class.int_2 = num2;
			}
			list.Sort();
			for (int i = list.Count - 2; i >= 0; i--)
			{
				Class212 class2 = list[i];
				Class212 class3 = list[i + 1];
				if (class2.int_2 == class3.int_1 && class2.int_0 == class3.int_0)
				{
					class2.int_2 = class3.int_2;
					list.RemoveAt(i + 1);
				}
			}
			int[] array = new int[list.Count * 2];
			for (int i = 0; i < list.Count; i++)
			{
				array[i * 2] = list[i].int_1;
				array[i * 2 + 1] = list[i].int_2;
			}
			return array;
		}

		public ushort method_7(char char_0)
		{
			return method_8(method_20().method_17(Convert.ToUInt16(char_0)));
		}

		public ushort method_8(ushort ushort_0)
		{
			return method_15().method_7(ushort_0).ushort_0;
		}

		public ushort method_9(char char_0)
		{
			return method_20().method_17(char_0);
		}

		public ushort[] method_10(char[] char_0)
		{
			GClass495 gClass = new GClass495();
			method_0(0, gClass);
			for (int i = 0; i < char_0.Length; i++)
			{
				method_0(method_20().method_17(Convert.ToUInt16(char_0[i])), gClass);
			}
			return gClass.method_4();
		}

		public GClass496 method_11()
		{
			return gclass496_0;
		}

		public GClass481 method_12()
		{
			return gclass481_0;
		}

		public GClass482 method_13()
		{
			return gclass482_0;
		}

		public GClass483 method_14()
		{
			return gclass483_0;
		}

		public GClass484 method_15()
		{
			return gclass484_0;
		}

		public GClass490 method_16()
		{
			return gclass490_0;
		}

		public GClass489 method_17()
		{
			return gclass489_0;
		}

		public GClass485 method_18()
		{
			return gclass485_0;
		}

		public GClass488 method_19()
		{
			return gclass488_0;
		}

		public GClass486 method_20()
		{
			return gclass486_0;
		}

		public GClass487 method_21()
		{
			return gclass487_0;
		}

		public GClass487 method_22()
		{
			return gclass487_1;
		}

		public GClass487 method_23()
		{
			return gclass487_2;
		}

		public bool method_24()
		{
			return method_17().method_7() != 2;
		}
	}
}
