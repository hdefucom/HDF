using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass291
	{
		private static Hashtable hashtable_0 = new Hashtable();

		public static Cursor smethod_0()
		{
			return smethod_16("SelectCell.cur");
		}

		public static Cursor smethod_1()
		{
			return smethod_16("FormatBrush.cur");
		}

		public static Cursor smethod_2()
		{
			return smethod_16("FormatBrush2.cur");
		}

		public static Cursor smethod_3()
		{
			return smethod_16("Right.cur");
		}

		public static Cursor smethod_4()
		{
			return smethod_16("HandDragUp.cur");
		}

		public static Cursor smethod_5()
		{
			return smethod_16("HandDragDown.cur");
		}

		public static Cursor smethod_6()
		{
			return smethod_16("Black.cur");
		}

		public static Cursor smethod_7()
		{
			return smethod_16("RightArrow.cur");
		}

		public static Cursor smethod_8()
		{
			return smethod_16("ZoomIn.cur");
		}

		public static Cursor smethod_9()
		{
			return smethod_16("ZoomOut.cur");
		}

		public static Cursor smethod_10()
		{
			return smethod_16("DragCopy.cur");
		}

		public static Cursor smethod_11()
		{
			return smethod_16("DragLink.cur");
		}

		public static Cursor smethod_12()
		{
			return smethod_16("DragMove.cur");
		}

		public static Cursor smethod_13()
		{
			return smethod_16("DragNo.cur");
		}

		public static Cursor smethod_14()
		{
			return smethod_16("DragPage.cur");
		}

		public static Cursor smethod_15()
		{
			return smethod_16("DragPageNo.cur");
		}

		private static Cursor smethod_16(string string_0)
		{
			Cursor cursor = hashtable_0[string_0] as Cursor;
			if (cursor == null)
			{
				Assembly assembly = typeof(GClass291).Assembly;
				string[] manifestResourceNames = assembly.GetManifestResourceNames();
				string[] array = manifestResourceNames;
				foreach (string text in array)
				{
					if (text == string_0 || text.EndsWith(string_0))
					{
						using (Stream stream = assembly.GetManifestResourceStream(text))
						{
							cursor = new Cursor(stream);
							hashtable_0[string_0] = cursor;
						}
						break;
					}
				}
			}
			return cursor;
		}

		private GClass291()
		{
		}
	}
}
