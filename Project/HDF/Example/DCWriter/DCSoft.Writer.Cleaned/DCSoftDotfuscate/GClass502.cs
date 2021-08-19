using DCSoft.Drawing;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass502
	{
		public const int int_0 = 16;

		private static Dictionary<FormButtonStyle, Image> dictionary_0 = null;

		private static Dictionary<FormButtonStyle, Image> dictionary_1 = null;

		public static void smethod_0(DCGraphics dcgraphics_0, RectangleF rectangleF_0, FormButtonStyle formButtonStyle_0, bool bool_0)
		{
			switch (formButtonStyle_0)
			{
			case FormButtonStyle.Button:
			{
				Image image_ = smethod_1(FormButtonStyle.Button, bool_0);
				DrawerUtil.DrawImageNearestNeighbor(dcgraphics_0, image_, rectangleF_0);
				break;
			}
			case FormButtonStyle.FloatButton:
			{
				Image image_ = smethod_1(FormButtonStyle.FloatButton, bool_0);
				DrawerUtil.DrawImageNearestNeighbor(dcgraphics_0, image_, rectangleF_0);
				break;
			}
			case FormButtonStyle.ComboBoxButton:
			{
				if (bool_0)
				{
					dcgraphics_0.DrawRectangle(Color.FromArgb(60, 127, 177), rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
				}
				PointF[] array = new PointF[4]
				{
					new PointF(rectangleF_0.Left + rectangleF_0.Width * 0.1875f, rectangleF_0.Top + rectangleF_0.Height * 0.25f),
					new PointF(rectangleF_0.Left + rectangleF_0.Width * 0.75f, rectangleF_0.Top + rectangleF_0.Height * 0.25f),
					new PointF(rectangleF_0.Left + rectangleF_0.Width * (15f / 32f), rectangleF_0.Top + rectangleF_0.Height * 0.6875f),
					new PointF(0f, 0f)
				};
				array[3] = array[0];
				SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
				dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				dcgraphics_0.FillPolygon(Color.Black, array);
				dcgraphics_0.SmoothingMode = smoothingMode;
				break;
			}
			case FormButtonStyle.DateTimePicker:
			{
				Image image_ = smethod_1(FormButtonStyle.DateTimePicker, bool_0);
				DrawerUtil.DrawImageNearestNeighbor(dcgraphics_0, image_, rectangleF_0);
				break;
			}
			}
		}

		public static Image smethod_1(FormButtonStyle formButtonStyle_0, bool bool_0)
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<FormButtonStyle, Image>();
				Bitmap browseButtonIcon = DrawingResources.BrowseButtonIcon;
				dictionary_0[FormButtonStyle.Button] = browseButtonIcon;
				browseButtonIcon = DrawingResources.FloatBrowseButtonIcon;
				dictionary_0[FormButtonStyle.FloatButton] = browseButtonIcon;
				browseButtonIcon = DrawingResources.CalenderButtonIcon;
				dictionary_0[FormButtonStyle.DateTimePicker] = browseButtonIcon;
				browseButtonIcon = DrawingResources.ComboBoxButtonNormal;
				dictionary_0[FormButtonStyle.ComboBoxButton] = browseButtonIcon;
				dictionary_1 = new Dictionary<FormButtonStyle, Image>();
				browseButtonIcon = DrawingResources.ComboBoxButtonActive;
				dictionary_1[FormButtonStyle.ComboBoxButton] = browseButtonIcon;
			}
			if (bool_0 && dictionary_1.ContainsKey(formButtonStyle_0))
			{
				return dictionary_1[formButtonStyle_0];
			}
			if (dictionary_0.ContainsKey(formButtonStyle_0))
			{
				return dictionary_0[formButtonStyle_0];
			}
			return null;
		}
	}
}
