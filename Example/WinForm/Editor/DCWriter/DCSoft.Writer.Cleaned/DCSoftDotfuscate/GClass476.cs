using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass476 : IDisposable
	{
		public const float float_0 = 300f;

		private GClass460 gclass460_0;

		private GClass478 gclass478_0;

		private float float_1;

		private GClass475 gclass475_0 = new GClass475();

		private Font font_0;

		private bool bool_0 = true;

		private string string_0;

		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public GClass476(Font font_1)
		{
			font_0 = font_1;
			method_7();
		}

		protected internal GClass514 method_0()
		{
			return (gclass460_0 != null) ? gclass460_0.method_3() : null;
		}

		protected internal GClass478 method_1()
		{
			return gclass478_0;
		}

		protected internal float method_2()
		{
			return float_1;
		}

		protected internal GClass475 method_3()
		{
			return gclass475_0;
		}

		public Font method_4()
		{
			return font_0;
		}

		public bool method_5()
		{
			return bool_0;
		}

		private void method_6(byte[] byte_0)
		{
			gclass478_0 = new GClass478();
			gclass478_0.method_3(byte_0);
			float_1 = 1000f / (float)(int)gclass478_0.method_12().method_7();
		}

		private void method_7()
		{
			int num = 2;
			using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
			{
				IntPtr hdc = graphics.GetHdc();
				try
				{
					Class210.SelectObject(hdc, font_0.ToHfont());
					uint fontData = Class210.GetFontData(hdc, 1717793908u, 0u, null, 0u);
					if (fontData == uint.MaxValue)
					{
						fontData = Class210.GetFontData(hdc, 0u, 0u, null, 0u);
						if (fontData == uint.MaxValue)
						{
							Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
							throw new GException18("Error when reading font file, name:" + font_0.Name + " , message:" + ex.Message);
						}
						byte[] array = new byte[fontData];
						fontData = Class210.GetFontData(hdc, 0u, 0u, array, fontData);
						if (fontData != array.Length)
						{
							Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
							throw new GException18("Error when reading font file, name:" + font_0.Name + " , message:" + ex.Message);
						}
						method_6(array);
					}
					else
					{
						byte[] array = new byte[fontData];
						fontData = Class210.GetFontData(hdc, 1717793908u, 0u, array, fontData);
						if (fontData != array.Length)
						{
							Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
							throw new GException18("Error when reading font file, name:" + font_0.Name + " , message:" + ex.Message);
						}
						if (font_0.Bold)
						{
							gclass478_0 = GClass478.smethod_0(array, font_0.Name + " Bold");
						}
						if (gclass478_0 == null)
						{
							gclass478_0 = GClass478.smethod_0(array, font_0.Name);
						}
						if (gclass478_0 != null)
						{
							float_1 = 1000f / (float)(int)gclass478_0.method_12().method_7();
						}
					}
				}
				finally
				{
					graphics.ReleaseHdc(hdc);
				}
			}
		}

		protected internal void method_8()
		{
			if (bool_0)
			{
				gclass460_0 = new GClass461(this);
			}
			else
			{
				gclass460_0 = new GClass462(this);
			}
		}

		protected internal void method_9(Stream stream_0)
		{
			gclass478_0.method_5(stream_0, gclass475_0.method_4(), Class211.smethod_0(font_0, bool_0: true));
		}

		public float method_10(char char_0)
		{
			return (float)(int)gclass478_0.method_7(char_0) * float_1;
		}

		public float method_11(ushort ushort_0)
		{
			return (float)(int)gclass478_0.method_8(ushort_0) * float_1;
		}

		public int[] method_12()
		{
			return gclass478_0.method_6();
		}

		public bool method_13(string string_1)
		{
			if (!string.IsNullOrEmpty(string_1) && gclass478_0 != null && gclass478_0.method_20() != null)
			{
				foreach (char ushort_ in string_1)
				{
					if (!gclass478_0.method_20().method_6(ushort_))
					{
						return false;
					}
				}
			}
			return true;
		}

		public string method_14(string string_1)
		{
			int num = 9;
			if (gclass460_0 == null)
			{
				throw new GException18("The inner font doesn't specified yet");
			}
			return gclass460_0.vmethod_3(string_1);
		}

		public void method_15(char char_0)
		{
			gclass475_0.method_0(char_0);
			if (bool_0 && Convert.ToUInt16(char_0) > 127)
			{
				bool_0 = false;
			}
		}

		public void method_16(string string_1)
		{
			for (int i = 0; i < string_1.Length; i++)
			{
				method_15(string_1[i]);
			}
		}

		public void method_17(GClass540 gclass540_0)
		{
			if (gclass460_0 != null)
			{
				gclass460_0.method_1(gclass540_0);
			}
		}

		public void method_18(StreamWriter streamWriter_0)
		{
			if (gclass460_0 != null)
			{
				gclass460_0.method_2(streamWriter_0);
			}
		}

		public void method_19()
		{
			if (gclass460_0 != null)
			{
				gclass460_0.vmethod_2();
			}
		}

		public void Dispose()
		{
		}
	}
}
