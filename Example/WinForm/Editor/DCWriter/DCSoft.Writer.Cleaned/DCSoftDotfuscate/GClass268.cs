using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass268 : ToolStripMenuItem
	{
		public static string string_0 = "Custom...";

		private static Hashtable hashtable_0 = new Hashtable();

		private static Hashtable hashtable_1 = new Hashtable();

		private Color color_0 = Color.Transparent;

		private bool bool_0 = false;

		public static void smethod_0(Color color_1, string string_1)
		{
			hashtable_0[color_1.ToArgb()] = string_1;
		}

		public static Bitmap smethod_1(Color color_1)
		{
			int num = 16;
			Bitmap bitmap = (Bitmap)hashtable_1[color_1];
			if (bitmap != null)
			{
				return bitmap;
			}
			bitmap = new Bitmap(num, num);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				using (SolidBrush brush = new SolidBrush(color_1))
				{
					graphics.FillRectangle(brush, 3, 3, num - 6, num - 6);
				}
				graphics.DrawRectangle(Pens.Black, 3, 3, num - 6, num - 6);
			}
			hashtable_1[color_1] = bitmap;
			return bitmap;
		}

		public static GClass268[] smethod_2(EventHandler eventHandler_0)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new GClass268(Color.Black, "Black", eventHandler_0));
			arrayList.Add(new GClass268(Color.DarkRed, "Bark Red", eventHandler_0));
			arrayList.Add(new GClass268(Color.DarkGreen, "Dark Green", eventHandler_0));
			arrayList.Add(new GClass268(Color.Olive, "Olive", eventHandler_0));
			arrayList.Add(new GClass268(Color.DarkBlue, "Dark Blue", eventHandler_0));
			arrayList.Add(new GClass268(Color.Lavender, "Lavender", eventHandler_0));
			arrayList.Add(new GClass268(Color.SlateBlue, "Slate", eventHandler_0));
			arrayList.Add(new GClass268(Color.LightGray, "Light Gray", eventHandler_0));
			arrayList.Add(new GClass268(Color.DarkGray, "Dark Gray", eventHandler_0));
			arrayList.Add(new GClass268(Color.Red, "Bright Red", eventHandler_0));
			arrayList.Add(new GClass268(Color.Green, "Bright Green", eventHandler_0));
			arrayList.Add(new GClass268(Color.Yellow, "Yellow", eventHandler_0));
			arrayList.Add(new GClass268(Color.Blue, "Bright Blue", eventHandler_0));
			arrayList.Add(new GClass268(Color.Magenta, "Magenta", eventHandler_0));
			arrayList.Add(new GClass268(Color.Cyan, "Cyan", eventHandler_0));
			arrayList.Add(new GClass268(Color.White, "White", eventHandler_0));
			return (GClass268[])arrayList.ToArray(typeof(GClass268));
		}

		public static GClass268 smethod_3(string string_1, Color color_1, EventHandler eventHandler_0)
		{
			GClass268 gClass = new GClass268(color_1, string_1, eventHandler_0);
			gClass.method_3(bool_1: true);
			return gClass;
		}

		public GClass268(Color color_1, string string_1, EventHandler eventHandler_0)
		{
			color_0 = color_1;
			string text = hashtable_0[color_1.ToArgb()] as string;
			if (text == null)
			{
				Text = string_1;
			}
			else
			{
				Text = text;
			}
			if (eventHandler_0 != null)
			{
				base.Click += eventHandler_0;
			}
			Image = smethod_1(color_0);
		}

		public Color method_0()
		{
			return color_0;
		}

		public void method_1(Color color_1)
		{
			color_0 = color_1;
			Image = smethod_1(color_1);
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			if (bool_0)
			{
				using (ColorDialog colorDialog = new ColorDialog())
				{
					colorDialog.Color = color_0;
					colorDialog.FullOpen = true;
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						color_0 = colorDialog.Color;
						base.OnClick(eventArgs_0);
					}
				}
			}
			else
			{
				base.OnClick(eventArgs_0);
			}
		}
	}
}
