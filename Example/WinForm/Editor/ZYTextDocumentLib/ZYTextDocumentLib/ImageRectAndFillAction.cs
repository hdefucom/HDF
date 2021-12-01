using System;
using System.Drawing;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageRectAndFillAction : ImageEditAction
	{
		public Color BorderColor = Color.Black;

		public Color FillColor = Color.Black;

		public int BorderWidth = 1;

		public override string ActionName => "rectandfill";

		public override bool FromXML(XmlElement myElement)
		{
			BoundsFromXML(myElement);
			BorderColor = StringCommon.ColorFromHtml(myElement.GetAttribute("bordercolor"), Color.Black);
			FillColor = StringCommon.ColorFromHtml(myElement.GetAttribute("fillcolor"), Color.Black);
			BorderWidth = Convert.ToInt32(myElement.GetAttribute("borderwidth"));
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			BoundsToXML(myElement);
			myElement.SetAttribute("bordercolor", StringCommon.ColorToHtml(BorderColor));
			myElement.SetAttribute("fillcolor", StringCommon.ColorToHtml(FillColor));
			myElement.SetAttribute("borderwidth", BorderWidth.ToString());
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			using (SolidBrush brush = new SolidBrush(FillColor))
			{
				g.FillRectangle(brush, myBounds);
			}
			using (Pen pen = new Pen(BorderColor, BorderWidth))
			{
				g.DrawRectangle(pen, myBounds);
			}
			return true;
		}
	}
}
