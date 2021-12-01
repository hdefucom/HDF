using DCSoft.ShapeEditor.Dom;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass333
	{
		private ShapeDocument shapeDocument_0 = null;

		private GControl9 gcontrol9_0 = null;

		public ShapeDocument method_0()
		{
			return shapeDocument_0;
		}

		public void method_1(ShapeDocument shapeDocument_1)
		{
			shapeDocument_0 = shapeDocument_1;
		}

		public GControl9 method_2()
		{
			return gcontrol9_0;
		}

		public void method_3(GControl9 gcontrol9_1)
		{
			gcontrol9_0 = gcontrol9_1;
		}

		public virtual bool vmethod_0(ShapeContainerElement shapeContainerElement_0, ShapeElement shapeElement_0)
		{
			return vmethod_1(shapeContainerElement_0, shapeElement_0.GetType());
		}

		public virtual bool vmethod_1(ShapeContainerElement shapeContainerElement_0, Type type_0)
		{
			if (shapeContainerElement_0 is ShapeDocument)
			{
				if (type_0.Equals(typeof(ShapeDocumentPage)) || type_0.IsSubclassOf(typeof(ShapeDocumentPage)))
				{
					return true;
				}
				return false;
			}
			return true;
		}
	}
}
