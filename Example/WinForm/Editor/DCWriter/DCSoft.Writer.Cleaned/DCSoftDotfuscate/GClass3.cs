using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public class GClass3
	{
		private int int_0 = 0;

		private int int_1 = 0;

		private string string_0 = null;

		private XTextElement xtextElement_0 = null;

		private Image image_0 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 0f;

		private float float_3 = 0f;

		private Cursor cursor_0 = null;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
		}

		internal int method_2()
		{
			return int_1;
		}

		internal void method_3(int int_2)
		{
			int_1 = int_2;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_1)
		{
			string_0 = string_1;
		}

		public XTextElement method_6()
		{
			return xtextElement_0;
		}

		public void method_7(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}

		public Image method_8()
		{
			return image_0;
		}

		public void method_9(Image image_1)
		{
			image_0 = image_1;
		}

		public float method_10()
		{
			return float_0;
		}

		public void method_11(float float_4)
		{
			float_0 = float_4;
		}

		public float method_12()
		{
			return float_1;
		}

		public void method_13(float float_4)
		{
			float_1 = float_4;
		}

		public float method_14()
		{
			return float_2;
		}

		public void method_15(float float_4)
		{
			float_2 = float_4;
		}

		public float method_16()
		{
			return float_3;
		}

		public void method_17(float float_4)
		{
			float_3 = float_4;
		}

		public RectangleF method_18()
		{
			return new RectangleF(method_10(), method_12(), method_14(), method_16());
		}

		public bool method_19(float float_4, float float_5)
		{
			return method_18().Contains(float_4, float_5);
		}

		public Cursor method_20()
		{
			return cursor_0;
		}

		public void method_21(Cursor cursor_1)
		{
			cursor_0 = cursor_1;
		}

		public virtual void vmethod_0(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			RectangleF rectangleF = new RectangleF(method_10(), method_12(), method_14(), method_16());
			if (documentPaintEventArgs_0.ClipRectangle.IsEmpty || documentPaintEventArgs_0.ClipRectangle.IntersectsWith(rectangleF))
			{
				DrawerUtil.DrawImageUnscaledNearestNeighbor(documentPaintEventArgs_0.Graphics, method_8(), rectangleF, ContentAlignment.MiddleCenter);
			}
		}

		public virtual void vmethod_1(WriterMouseEventArgs writerMouseEventArgs_0)
		{
		}

		public virtual void vmethod_2(WriterMouseEventArgs writerMouseEventArgs_0)
		{
			if (method_18().Contains(writerMouseEventArgs_0.X, writerMouseEventArgs_0.Y))
			{
			}
		}
	}
}
