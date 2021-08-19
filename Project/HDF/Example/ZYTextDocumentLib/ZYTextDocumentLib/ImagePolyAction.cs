using System;
using System.Drawing;
using System.Text;
using System.Xml;
using XDesignerCommon;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImagePolyAction : ImageEditAction
	{
		public Color ForeColor = Color.Black;

		public int LineWidth = 1;

		private Point[] myPoints = null;

		public Point[] Points
		{
			get
			{
				return myPoints;
			}
			set
			{
				myPoints = value;
				myBounds = PointBuffer.GetBounds(value);
			}
		}

		public override Rectangle Bounds
		{
			get
			{
				return myBounds;
			}
			set
			{
			}
		}

		public override string ActionName => "poly";

		public override bool DesignChangeBounds(Rectangle NewBounds)
		{
			Rectangle bounds = Bounds;
			int dx = NewBounds.X - bounds.X;
			int dy = NewBounds.Y - bounds.Y;
			for (int i = 0; i < myPoints.Length; i++)
			{
				myPoints[i].Offset(dx, dy);
			}
			myBounds = PointBuffer.GetBounds(myPoints);
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if (Points != null)
			{
				using (Pen pen = new Pen(ForeColor, LineWidth))
				{
					g.DrawLines(pen, Points);
				}
				return true;
			}
			return false;
		}

		public override bool ToXML(XmlElement myElement)
		{
			myElement.SetAttribute("color", StringCommon.ColorToHtml(ForeColor));
			myElement.SetAttribute("linewidth", LineWidth.ToString());
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Points.Length; i++)
			{
				stringBuilder.Append(Points[i].X.ToString());
				stringBuilder.Append(",");
				stringBuilder.Append(Points[i].Y.ToString());
				if (i != Points.Length - 1)
				{
					stringBuilder.Append(",");
				}
			}
			myElement.SetAttribute("points", stringBuilder.ToString());
			return true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			ForeColor = StringCommon.ColorFromHtml(myElement.GetAttribute("color"), Color.Black);
			LineWidth = Convert.ToInt32(myElement.GetAttribute("linewidth"));
			string attribute = myElement.GetAttribute("points");
			string[] array = attribute.Split(",".ToCharArray());
			Points = null;
			if (array != null && array.Length > 0)
			{
				Points = new Point[(int)Math.Floor((double)array.Length / 2.0)];
				for (int i = 0; i < Points.Length; i++)
				{
					Points[i].X = Convert.ToInt32(array[i * 2]);
					Points[i].Y = Convert.ToInt32(array[i * 2 + 1]);
				}
				myBounds = PointBuffer.GetBounds(Points);
			}
			return true;
		}
	}
}
