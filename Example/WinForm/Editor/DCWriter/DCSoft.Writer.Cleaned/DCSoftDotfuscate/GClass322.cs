using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass322 : GClass321
	{
		public GClass322()
		{
			method_7(typeof(ShapeEllipseElement));
			method_8().Align = DocumentContentAlignment.Center;
			method_8().VerticalAlign = VerticalAlignStyle.Middle;
			method_8().BorderColor = Color.Black;
			method_8().BorderWidth = 1f;
			method_8().BorderLeft = true;
			method_8().BorderTop = true;
			method_8().BorderRight = true;
			method_8().BorderBottom = true;
			method_8().Multiline = true;
		}

		public override ShapeElement vmethod_7()
		{
			return (ShapeEllipseElement)base.vmethod_7();
		}
	}
}
