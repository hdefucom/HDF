using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass320
	{
		private GControl9 gcontrol9_0 = null;

		private ShapeDocument shapeDocument_0 = null;

		private ShapeContainerElement shapeContainerElement_0 = null;

		private Type type_0 = typeof(ShapeElement);

		private ContentStyle contentStyle_0 = new ContentStyle();

		private ShapeElement shapeElement_0 = null;

		private bool bool_0 = false;

		public GControl9 method_0()
		{
			return gcontrol9_0;
		}

		public void method_1(GControl9 gcontrol9_1)
		{
			gcontrol9_0 = gcontrol9_1;
		}

		public ShapeDocument method_2()
		{
			return shapeDocument_0;
		}

		public void method_3(ShapeDocument shapeDocument_1)
		{
			shapeDocument_0 = shapeDocument_1;
		}

		public ShapeContainerElement method_4()
		{
			return shapeContainerElement_0;
		}

		public void method_5(ShapeContainerElement shapeContainerElement_1)
		{
			shapeContainerElement_0 = shapeContainerElement_1;
		}

		public Type method_6()
		{
			return type_0;
		}

		public void method_7(Type type_1)
		{
			type_0 = type_1;
		}

		public ContentStyle method_8()
		{
			return contentStyle_0;
		}

		public void method_9(ContentStyle contentStyle_1)
		{
			contentStyle_0 = contentStyle_1;
		}

		public ShapeElement method_10()
		{
			return shapeElement_0;
		}

		public void method_11(ShapeElement shapeElement_1)
		{
			shapeElement_0 = shapeElement_1;
		}

		public virtual void vmethod_0()
		{
			method_13(bool_1: false);
		}

		public bool method_12()
		{
			return bool_0;
		}

		public void method_13(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public virtual GEnum75 vmethod_1(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
			return GEnum75.const_1;
		}

		public virtual GEnum75 vmethod_2(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
			return GEnum75.const_1;
		}

		public virtual GEnum75 vmethod_3(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
			return GEnum75.const_1;
		}

		public virtual GEnum75 vmethod_4(KeyEventArgs keyEventArgs_0)
		{
			return GEnum75.const_1;
		}

		public virtual GEnum75 vmethod_5(KeyPressEventArgs keyPressEventArgs_0)
		{
			return GEnum75.const_1;
		}

		public virtual GEnum75 vmethod_6(KeyEventArgs keyEventArgs_0)
		{
			return GEnum75.const_1;
		}

		public virtual ShapeElement vmethod_7()
		{
			return (ShapeElement)Activator.CreateInstance(method_6());
		}
	}
}
