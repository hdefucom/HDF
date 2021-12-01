using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass531 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.None;
		}

		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs paintValueEventArgs_0)
		{
			XPenStyle xPenStyle = paintValueEventArgs_0.Value as XPenStyle;
			Color color = Color.Black;
			if (xPenStyle != null)
			{
				color = xPenStyle.Color;
			}
			using (SolidBrush brush = new SolidBrush(color))
			{
				paintValueEventArgs_0.Graphics.FillRectangle(brush, paintValueEventArgs_0.Bounds);
			}
		}
	}
}
