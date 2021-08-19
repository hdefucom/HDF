using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass524 : UITypeEditor
	{
		private static UITypeEditor uitypeEditor_0 = (UITypeEditor)TypeDescriptor.GetEditor(typeof(Color), typeof(UITypeEditor));

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (uitypeEditor_0 == null)
			{
				return UITypeEditorEditStyle.Modal;
			}
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (uitypeEditor_0 != null)
			{
				Color color = (value as XColorValue)?.Value ?? Color.Empty;
				Color color2 = (Color)uitypeEditor_0.EditValue(context, provider, color);
				if (!color.Equals(color2))
				{
					return new XColorValue(color2);
				}
				return value;
			}
			using (ColorDialog colorDialog = new ColorDialog())
			{
				XColorValue xColorValue = value as XColorValue;
				if (xColorValue != null)
				{
					colorDialog.Color = xColorValue.Value;
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						return new XColorValue(colorDialog.Color);
					}
				}
			}
			return value;
		}

		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs paintValueEventArgs_0)
		{
			XColorValue xColorValue = paintValueEventArgs_0.Value as XColorValue;
			if (xColorValue == null)
			{
				xColorValue = new XColorValue();
			}
			using (SolidBrush brush = new SolidBrush(xColorValue.Value))
			{
				paintValueEventArgs_0.Graphics.FillRectangle(brush, paintValueEventArgs_0.Bounds);
			}
		}
	}
}
