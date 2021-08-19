using DCSoftDotfuscate;
using System;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       椭圆对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeEllipseElement : ShapeRectangleElement
	{
		public override void vmethod_1(GClass328 gclass328_0)
		{
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(0f, 0f, base.Width, base.Height);
				if (graphicsPath.IsVisible(gclass328_0.method_4(), gclass328_0.method_6()))
				{
					gclass328_0.method_9(GEnum73.const_2);
				}
				else
				{
					gclass328_0.method_9(GEnum73.const_0);
				}
			}
		}

		public override GraphicsPath vmethod_5()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(0f, 0f, base.Width, base.Height);
			return graphicsPath;
		}
	}
}
