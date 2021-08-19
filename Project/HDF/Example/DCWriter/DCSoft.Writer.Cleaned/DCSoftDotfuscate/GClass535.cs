using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DocumentComment]
	[ComVisible(false)]
	public class GClass535
	{
		private bool bool_0 = false;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private float float_0 = 0f;

		private Color color_0 = Color.Black;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public DashStyle method_2()
		{
			return dashStyle_0;
		}

		public void method_3(DashStyle dashStyle_1)
		{
			dashStyle_0 = dashStyle_1;
		}

		public float method_4()
		{
			return float_0;
		}

		public void method_5(float float_1)
		{
			float_0 = float_1;
		}

		public Color method_6()
		{
			return color_0;
		}

		public void method_7(Color color_1)
		{
			color_0 = color_1;
		}

		public void method_8(string string_0)
		{
			int num = 17;
			if (string.Compare(string_0, "none", ignoreCase: true) == 0 || string.IsNullOrEmpty(string_0))
			{
				method_3(DashStyle.Solid);
				method_7(Color.Black);
				method_1(bool_1: false);
				method_5(0f);
				return;
			}
			method_1(bool_1: true);
			string[] array = string_0.Split(' ', ',', '\t', ';');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (text.Length != 0)
				{
					if (text.Equals("solid", StringComparison.CurrentCultureIgnoreCase))
					{
						method_3(DashStyle.Solid);
					}
					else if (text.Equals("dashed", StringComparison.CurrentCultureIgnoreCase))
					{
						method_3(DashStyle.Dash);
					}
					else if (text.Equals("dotted", StringComparison.CurrentCultureIgnoreCase))
					{
						method_3(DashStyle.Dot);
					}
					else if (text.StartsWith("#"))
					{
						method_7(ColorTranslator.FromHtml(text));
					}
					else if (char.IsNumber(text[0]))
					{
						method_5((float)GraphicsUnitConvert.ParseCSSLength(text, GraphicsUnit.Document, 0.0));
					}
					else
					{
						try
						{
							method_7(ColorTranslator.FromHtml(text));
						}
						catch
						{
						}
					}
				}
			}
		}
	}
}
