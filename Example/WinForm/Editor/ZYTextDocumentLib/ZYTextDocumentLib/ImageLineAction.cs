using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageLineAction : ImageEditAction
	{
		public Point p1;

		public Point p2;

		public Color Color = Color.Black;

		public bool Arrow = false;

		public int Width = 1;

		public override Rectangle Bounds
		{
			get
			{
				return RectangleObject.GetRectangle(p1, p2);
			}
			set
			{
			}
		}

		public override string ActionName => "line";

		public override bool DesignChangeBounds(Rectangle NewBounds)
		{
			Rectangle bounds = Bounds;
			p1 = RectangleObject.GetAcmePos(NewBounds, RectangleObject.GetAcmeIndex(bounds, p1));
			p2 = RectangleObject.GetAcmePos(NewBounds, RectangleObject.GetAcmeIndex(bounds, p2));
			return true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			p1 = new Point(Convert.ToInt32(myElement.GetAttribute("x1")), Convert.ToInt32(myElement.GetAttribute("y1")));
			p2 = new Point(Convert.ToInt32(myElement.GetAttribute("x2")), Convert.ToInt32(myElement.GetAttribute("y2")));
			Width = Convert.ToInt32(myElement.GetAttribute("width"));
			Color = StringCommon.ColorFromHtml(myElement.GetAttribute("color"), Color.Black);
			Arrow = (myElement.GetAttribute("arrow") == "1");
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			myElement.SetAttribute("x1", p1.X.ToString());
			myElement.SetAttribute("y1", p1.Y.ToString());
			myElement.SetAttribute("x2", p2.X.ToString());
			myElement.SetAttribute("y2", p2.Y.ToString());
			myElement.SetAttribute("width", Width.ToString());
			myElement.SetAttribute("color", StringCommon.ColorToHtml(Color));
			myElement.SetAttribute("arrow", Arrow ? "1" : "0");
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			using (Pen pen = new Pen(Color, Width))
			{
				if (Arrow)
				{
					using (AdjustableArrowCap customEndCap = new AdjustableArrowCap(4f, 4f))
					{
						pen.CustomEndCap = customEndCap;
						g.DrawLine(pen, p1, p2);
					}
				}
				else
				{
					g.DrawLine(pen, p1, p2);
				}
			}
			return true;
		}

		public override bool IsVisible(Rectangle ClipRect)
		{
			return RectangleObject.GetRectangle(p1, p2).IntersectsWith(ClipRect);
		}
	}
}
