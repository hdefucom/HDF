#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace DCSoftDotfuscate
{
	internal class Class105 : IDisposable
	{
		private class Class106
		{
			public string string_0 = null;

			public GClass267 gclass267_0 = null;

			public float float_0 = 0f;

			public float float_1 = 0f;

			public float float_2 = 0f;

			public float float_3 = 0f;

			public bool bool_0 = false;

			public Dictionary<char, float> dictionary_0 = null;

			private FontWidthStyle fontWidthStyle_0 = FontWidthStyle.Proportional;

			private List<Class108> list_0 = null;

			private int int_0 = 0;

			public override string ToString()
			{
				return string_0 + " " + method_0();
			}

			public FontWidthStyle method_0()
			{
				return fontWidthStyle_0;
			}

			public void method_1(FontWidthStyle fontWidthStyle_1)
			{
				fontWidthStyle_0 = fontWidthStyle_1;
			}

			public List<Class108> method_2()
			{
				return list_0;
			}

			public void method_3(List<Class108> list_1)
			{
				list_0 = list_1;
			}

			public Class108 method_4(char char_0)
			{
				if (list_0 != null)
				{
					int_0++;
					int num = 0;
					foreach (Class108 item in list_0)
					{
						if (item.method_0() <= char_0 && char_0 <= item.method_2())
						{
							item.int_0++;
							if (num > 4 && item.int_0 > 10)
							{
								list_0.RemoveAt(num);
								list_0.Insert(0, item);
							}
							if (int_0 > 4000)
							{
								int_0 = 0;
								list_0.Sort(new Class107());
							}
							return item;
						}
						num++;
					}
				}
				return null;
			}
		}

		private class Class107 : IComparer<Class108>
		{
			public int Compare(Class108 class108_0, Class108 class108_1)
			{
				return class108_1.int_0 - class108_0.int_0;
			}
		}

		private class Class108 : IComparable<Class108>
		{
			internal int int_0 = 0;

			internal float float_0 = 0f;

			private int int_1 = 0;

			private int int_2 = 0;

			public int method_0()
			{
				return int_1;
			}

			public void method_1(int int_3)
			{
				int_1 = int_3;
			}

			public int method_2()
			{
				return int_2;
			}

			public void method_3(int int_3)
			{
				int_2 = int_3;
			}

			public int CompareTo(Class108 other)
			{
				int num = method_2() - method_0();
				int num2 = other.method_2() - other.method_0();
				return num - num2;
			}

			public override string ToString()
			{
				return method_0() + "->" + method_2() + " R:" + Convert.ToString(method_2() - method_0() + 1) + " W:" + float_0;
			}
		}

		private float float_0 = 5f;

		private MeasureMode measureMode_0 = MeasureMode.Default;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private static Dictionary<string, List<Class108>> dictionary_0 = new Dictionary<string, List<Class108>>();

		private static StringFormat stringFormat_0 = null;

		private bool bool_0 = false;

		private List<Class106> list_0 = new List<Class106>();

		private int int_0 = -1;

		private static bool smethod_0(char char_0)
		{
			int num = 6;
			if ('一' <= char_0 && char_0 < '龥')
			{
				return true;
			}
			if ("‘’“”‘、，。？".IndexOf(char_0) >= 0)
			{
				return true;
			}
			return false;
		}

		public Class105()
		{
			if (stringFormat_0 == null)
			{
				stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
				stringFormat_0.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
			}
		}

		public float method_0()
		{
			return float_0;
		}

		public void method_1(float float_1)
		{
			float_0 = float_1;
		}

		private void method_2()
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				if (list_0[i] != null && list_0[i].gclass267_0 != null)
				{
					list_0[i].gclass267_0.Dispose();
				}
			}
			list_0.Clear();
		}

		public MeasureMode method_3()
		{
			return measureMode_0;
		}

		public void method_4(MeasureMode measureMode_1)
		{
			if (measureMode_0 != measureMode_1)
			{
				measureMode_0 = measureMode_1;
				method_2();
			}
		}

		public GraphicsUnit method_5()
		{
			return graphicsUnit_0;
		}

		public void method_6(GraphicsUnit graphicsUnit_1)
		{
			if (graphicsUnit_0 != graphicsUnit_1)
			{
				graphicsUnit_0 = graphicsUnit_1;
				method_2();
			}
		}

		public static void smethod_1(string string_0)
		{
			smethod_2(string_0);
		}

		private static List<Class108> smethod_2(string string_0)
		{
			int num = 1;
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			List<Class108> list = new List<Class108>();
			string path = "dcwriter.CharRange." + FileHelper.FixFileName(string_0, '_') + ".dat";
			path = Path.Combine(Path.GetTempPath(), path);
			int num2 = 4;
			try
			{
				if (File.Exists(path))
				{
					DateTime creationTime = File.GetCreationTime(path);
					if (DateTime.Now.Subtract(creationTime).TotalDays < 10.0)
					{
						byte[] array = new byte[num2 * 2];
						using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
						{
							while (true)
							{
								int num3 = fileStream.Read(array, 0, array.Length);
								if (num3 <= 0)
								{
									break;
								}
								Class108 @class = new Class108();
								@class.method_1(BitConverter.ToInt32(array, 0));
								@class.method_3(BitConverter.ToInt32(array, num2));
								list.Add(@class);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				path = null;
				Debug.WriteLine(ex.Message);
			}
			if (list.Count == 0)
			{
				try
				{
					long tickCountExt = CountDown.GetTickCountExt();
					MemoryStream stream_ = new MemoryStream();
					XFontValue xFontValue = new XFontValue(string_0, 9f);
					using (GClass519 gClass = new GClass519(stream_))
					{
						GClass476 gClass2 = gClass.method_8().method_8(xFontValue.Value);
						int[] array2 = gClass2.method_12();
						if (array2 != null && array2.Length > 0)
						{
							for (int i = 0; i < array2.Length; i += 2)
							{
								Class108 class2 = new Class108();
								class2.method_1(array2[i]);
								class2.method_3(array2[i + 1]);
								list.Add(class2);
							}
							list.Sort();
							list.Reverse();
						}
					}
					tickCountExt = CountDown.GetTickCountExt() - tickCountExt;
				}
				catch (Exception ex)
				{
					list = new List<Class108>();
					Debug.WriteLine(ex.Message);
				}
				if (list.Count > 0 && path != null)
				{
					try
					{
						using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
						{
							foreach (Class108 item in list)
							{
								byte[] array = BitConverter.GetBytes(item.method_0());
								fileStream.Write(array, 0, array.Length);
								array = BitConverter.GetBytes(item.method_2());
								fileStream.Write(array, 0, array.Length);
							}
						}
					}
					catch (Exception ex)
					{
						path = null;
						Debug.WriteLine(ex.Message);
					}
				}
			}
			dictionary_0[string_0] = list;
			return list;
		}

		public bool method_7()
		{
			return bool_0;
		}

		public void method_8(bool bool_1)
		{
			if (bool_0 != bool_1)
			{
				bool_0 = bool_1;
				method_2();
			}
		}

		private Class106 method_9(XFontValue xfontValue_0, Graphics graphics_0)
		{
			int num = 5;
			if (int_0 != XFontValue.BufferClearCount)
			{
				int_0 = XFontValue.BufferClearCount;
				method_2();
			}
			int rawFontIndex = xfontValue_0.RawFontIndex;
			if (rawFontIndex < 0)
			{
				throw new ArgumentOutOfRangeException(rawFontIndex.ToString());
			}
			if (rawFontIndex >= list_0.Count)
			{
				for (int i = list_0.Count; i <= rawFontIndex; i++)
				{
					list_0.Add(null);
				}
			}
			Class106 @class = list_0[rawFontIndex];
			if (@class == null)
			{
				@class = new Class106();
				@class.string_0 = xfontValue_0.Name;
				@class.method_1(FontWidthStyle.Proportional);
				StringFormat genericTypographic = stringFormat_0;
				if (method_3() == MeasureMode.OldCompatibility)
				{
					genericTypographic = StringFormat.GenericTypographic;
				}
				SizeF sizeF = graphics_0.MeasureString("W", xfontValue_0.Value, 10000, genericTypographic);
				SizeF sizeF2 = graphics_0.MeasureString("i", xfontValue_0.Value, 10000, genericTypographic);
				if (sizeF.Width == sizeF2.Width)
				{
					@class.method_1(FontWidthStyle.Monospaced);
				}
				if (@class.method_0() == FontWidthStyle.Monospaced)
				{
					@class.float_0 = sizeF.Width;
				}
				@class.float_1 = graphics_0.MeasureString("袁", xfontValue_0.Value, 10000, genericTypographic).Width;
				@class.float_2 = graphics_0.MeasureString(" ", xfontValue_0.Value, 1000, genericTypographic).Width;
				if ((double)@class.float_2 < 0.1)
				{
					@class.float_2 = graphics_0.MeasureString("i", xfontValue_0.Value, 1000, genericTypographic).Width;
				}
				if (method_3() == MeasureMode.RichTextBoxCompatibility)
				{
					@class.gclass267_0 = new GClass267(xfontValue_0.Name, (int)GraphicsUnitConvert.Convert(xfontValue_0.Size, GraphicsUnit.Point, GraphicsUnit.Document), xfontValue_0.Bold, xfontValue_0.Italic, xfontValue_0.Underline, xfontValue_0.Strikeout);
					Size[] array = @class.gclass267_0.method_20(graphics_0, " W袁");
					@class.float_2 = array[0].Width;
					if (xfontValue_0.Name == "Times New Roman")
					{
						@class.float_2 *= 1.28f;
					}
					@class.float_0 = array[1].Width;
					@class.float_1 = array[2].Width;
				}
				if (method_3() == MeasureMode.Default)
				{
					if (method_7())
					{
						@class.float_2 = graphics_0.MeasureString(" ", xfontValue_0.Value, 10000, StringFormat.GenericDefault).Width * 0.57f;
					}
					else
					{
						@class.float_2 = graphics_0.MeasureString(" ", xfontValue_0.Value, 10000, genericTypographic).Width;
					}
				}
				@class.float_3 = xfontValue_0.Value.GetHeight(graphics_0);
				List<Class108> list = smethod_2(xfontValue_0.Name);
				if (list != null && list.Count > 0)
				{
					@class.method_3(new List<Class108>());
					foreach (Class108 item in list)
					{
						Class108 class2 = new Class108();
						class2.method_1(item.method_0());
						class2.method_3(item.method_2());
						SizeF sizeF3 = graphics_0.MeasureString(((char)class2.method_0()).ToString(), xfontValue_0.Value, 10000, genericTypographic);
						if ((double)sizeF3.Width > 0.01)
						{
							class2.float_0 = sizeF3.Width;
							@class.method_2().Add(class2);
						}
						if (class2.method_0() == 19968 && class2.method_2() == 40869 && (double)Math.Abs(class2.float_0 - @class.float_1) < 0.01)
						{
							@class.bool_0 = true;
						}
					}
				}
				list_0[rawFontIndex] = @class;
			}
			return @class;
		}

		public SizeF method_10(XFontValue xfontValue_0, char char_0, Graphics graphics_0, GraphicsUnit graphicsUnit_1)
		{
			int num = 2;
			SizeF result = SizeF.Empty;
			method_6(graphicsUnit_1);
			Class106 @class = method_9(xfontValue_0, graphics_0);
			result.Height = @class.float_3;
			if (char_0 == ' ' || char_0 == '\t')
			{
				result.Width = @class.float_2;
			}
			else
			{
				bool flag = false;
				if (@class.bool_0 && '一' <= char_0 && char_0 < '龥')
				{
					result.Width = @class.float_1;
					flag = true;
				}
				if (!flag && @class.method_2() != null)
				{
					Class108 class2 = @class.method_4(char_0);
					if (class2 == null)
					{
						flag = false;
					}
					else
					{
						flag = true;
						result.Width = class2.float_0;
					}
				}
				if (!flag)
				{
					if (smethod_0(char_0))
					{
						result.Width = @class.float_1;
					}
					else
					{
						bool flag2 = false;
						if (@class.method_0() == FontWidthStyle.Monospaced && char_0 >= '!' && char_0 <= '~')
						{
							result.Width = @class.float_0;
							flag2 = true;
						}
						if (!flag2)
						{
							graphics_0.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
							if (method_3() == MeasureMode.OldCompatibility)
							{
								result = graphics_0.MeasureString(char_0.ToString(), xfontValue_0.Value, 1000, StringFormat.GenericTypographic);
								if (result.Width == 0f)
								{
									result = graphics_0.MeasureString("_", xfontValue_0.Value, 1000, StringFormat.GenericTypographic);
								}
							}
							else if (method_3() == MeasureMode.RichTextBoxCompatibility)
							{
								Size[] array = @class.gclass267_0.method_20(graphics_0, char_0.ToString());
								result.Width = array[0].Width;
							}
							else
							{
								result = graphics_0.MeasureString(char_0.ToString(), xfontValue_0.Value, 1000, stringFormat_0);
							}
						}
					}
				}
			}
			result.Height += float_0;
			return result;
		}

		public SizeF method_11(XFontValue xfontValue_0, string string_0, Graphics graphics_0, GraphicsUnit graphicsUnit_1)
		{
			int num = 13;
			if (string.IsNullOrEmpty(string_0))
			{
				return SizeF.Empty;
			}
			SizeF result = SizeF.Empty;
			method_6(graphicsUnit_1);
			Class106 @class = method_9(xfontValue_0, graphics_0);
			result.Height = @class.float_3;
			float num2 = 0f;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c == ' ' || c == '\t')
				{
					num2 += @class.float_2;
					continue;
				}
				bool flag = false;
				if (@class.bool_0 && '一' <= c && c < '龥')
				{
					num2 += @class.float_1;
					flag = true;
				}
				if (!flag && @class.method_2() != null)
				{
					Class108 class2 = @class.method_4(c);
					if (class2 == null)
					{
						flag = false;
					}
					else
					{
						flag = true;
						num2 += class2.float_0;
					}
				}
				if (flag)
				{
					continue;
				}
				if (smethod_0(c))
				{
					num2 += @class.float_1;
					continue;
				}
				bool flag2 = false;
				if (@class.method_0() == FontWidthStyle.Monospaced && c >= '!' && c <= '~')
				{
					num2 += @class.float_0;
					flag2 = true;
				}
				if (flag2)
				{
					continue;
				}
				graphics_0.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
				if (method_3() == MeasureMode.OldCompatibility)
				{
					result = graphics_0.MeasureString(c.ToString(), xfontValue_0.Value, 1000, StringFormat.GenericTypographic);
					if (result.Width == 0f)
					{
						result = graphics_0.MeasureString("_", xfontValue_0.Value, 1000, StringFormat.GenericTypographic);
					}
					num2 += result.Width;
				}
				else if (method_3() == MeasureMode.RichTextBoxCompatibility)
				{
					Size[] array = @class.gclass267_0.method_20(graphics_0, c.ToString());
					num2 += (float)array[0].Width;
				}
				else
				{
					result = graphics_0.MeasureString(c.ToString(), xfontValue_0.Value, 1000, stringFormat_0);
					num2 += result.Width;
				}
			}
			result.Width = num2;
			result.Height += float_0;
			return result;
		}

		public void Dispose()
		{
			if (list_0 != null)
			{
				foreach (Class106 item in list_0)
				{
					if (item != null && item.gclass267_0 != null)
					{
						item.gclass267_0.Dispose();
					}
				}
				list_0 = null;
			}
		}
	}
}
