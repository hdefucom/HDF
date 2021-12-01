using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	public class GClass260 : ComboBox
	{
		public class GClass261
		{
			public string string_0 = null;

			public object object_0 = null;

			public Color color_0 = SystemColors.WindowText;

			public Color color_1 = SystemColors.Window;

			internal GClass261()
			{
			}

			public override string ToString()
			{
				return string_0;
			}
		}

		public GClass260()
		{
			base.DrawMode = DrawMode.OwnerDrawFixed;
		}

		protected override void OnDrawItem(DrawItemEventArgs args)
		{
			try
			{
				if (args.Index >= 0 && args.Index < base.Items.Count)
				{
					GClass261 gClass = (GClass261)base.Items[args.Index];
					Color color = gClass.color_1;
					Color color2 = gClass.color_0;
					if (Int32Styles.GetStyle((int)args.State, 1))
					{
						color = SystemColors.Highlight;
						color2 = SystemColors.HighlightText;
					}
					using (SolidBrush brush = new SolidBrush(color))
					{
						args.Graphics.FillRectangle(brush, args.Bounds);
					}
					if (gClass.string_0 != null)
					{
						using (SolidBrush brush = new SolidBrush(color2))
						{
							args.Graphics.DrawString(gClass.string_0, args.Font, brush, new RectangleF(args.Bounds.Left, args.Bounds.Top, args.Bounds.Width, args.Bounds.Height), StringFormat.GenericDefault);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public GClass261 method_0(int int_0)
		{
			return (GClass261)base.Items[int_0];
		}

		public string method_1(int int_0)
		{
			return ((GClass261)base.Items[int_0]).string_0;
		}

		public GClass261 method_2(string string_0, object object_0, Color color_0, Color color_1)
		{
			GClass261 gClass = new GClass261();
			gClass.string_0 = string_0;
			gClass.object_0 = object_0;
			gClass.color_0 = color_0;
			gClass.color_1 = color_1;
			base.Items.Add(gClass);
			return gClass;
		}

		public GClass261 method_3(string string_0, Color color_0)
		{
			GClass261 gClass = new GClass261();
			gClass.string_0 = string_0;
			gClass.color_1 = color_0;
			base.Items.Add(gClass);
			return gClass;
		}

		public GClass261 method_4(string string_0)
		{
			GClass261 gClass = new GClass261();
			gClass.string_0 = string_0;
			base.Items.Add(gClass);
			return gClass;
		}
	}
}
