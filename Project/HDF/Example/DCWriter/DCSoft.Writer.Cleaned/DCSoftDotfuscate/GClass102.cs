using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DocumentComment]
	[ComVisible(false)]
	public class GClass102
	{
		protected bool bool_0 = false;

		private XTextDocumentList xtextDocumentList_0 = null;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private PointF pointF_0 = PointF.Empty;

		public virtual bool vmethod_0()
		{
			return bool_0;
		}

		public virtual void vmethod_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public XTextDocument method_0()
		{
			if (xtextDocumentList_0 == null)
			{
				return null;
			}
			return xtextDocumentList_0.FirstDocument;
		}

		public void method_1(XTextDocument xtextDocument_0)
		{
			xtextDocumentList_0 = new XTextDocumentList(xtextDocument_0);
		}

		public XTextDocumentList method_2()
		{
			return xtextDocumentList_0;
		}

		public void method_3(XTextDocumentList xtextDocumentList_1)
		{
			xtextDocumentList_0 = xtextDocumentList_1;
		}

		public XTextDocument method_4()
		{
			if (xtextDocumentList_0 == null)
			{
				return null;
			}
			return xtextDocumentList_0.FirstDocument;
		}

		public RectangleF method_5()
		{
			return rectangleF_0;
		}

		public void method_6(RectangleF rectangleF_1)
		{
			rectangleF_0 = rectangleF_1;
		}

		public PointF method_7()
		{
			return pointF_0;
		}

		public void method_8(PointF pointF_1)
		{
			pointF_0 = pointF_1;
		}

		public virtual bool vmethod_2(XTextElement xtextElement_0)
		{
			return true;
		}

		public void method_9(XTextElementList xtextElementList_0)
		{
			foreach (XTextElement item in xtextElementList_0)
			{
				if (vmethod_2(item))
				{
					if (!method_5().IsEmpty)
					{
						if (RectangleF.Intersect(method_5(), item.AbsBounds).Height >= 2f)
						{
							vmethod_3(item);
						}
					}
					else
					{
						vmethod_3(item);
					}
				}
			}
		}

		public virtual void vmethod_3(XTextElement xtextElement_0)
		{
		}
	}
}
