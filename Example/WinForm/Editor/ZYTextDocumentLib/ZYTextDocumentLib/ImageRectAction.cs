using System;
using System.Drawing;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageRectAction : ImageEditAction
	{
		public Color BorderColor = Color.Black;

		public int BorderWidth = 1;

		public override string ActionName => "rect";

		public override bool FromXML(XmlElement myElement)
		{
			BoundsFromXML(myElement);
			BorderColor = StringCommon.ColorFromHtml(myElement.GetAttribute("color"), Color.Black);
			BorderWidth = Convert.ToInt32(myElement.GetAttribute("borderwidth"));
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			BoundsToXML(myElement);
			myElement.SetAttribute("color", StringCommon.ColorToHtml(BorderColor));
			myElement.SetAttribute("borderwidth", BorderWidth.ToString());
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			using (Pen pen = new Pen(BorderColor, BorderWidth))
			{
				g.DrawRectangle(pen, myBounds);
			}
			return true;
		}
	}
}
