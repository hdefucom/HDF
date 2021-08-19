using System.Drawing;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageFillRectAction : ImageEditAction
	{
		public Color FillColor = Color.Black;

		public override string ActionName => "fillRect";

		public override bool FromXML(XmlElement myElement)
		{
			BoundsFromXML(myElement);
			FillColor = StringCommon.ColorFromHtml(myElement.GetAttribute("color"), Color.Black);
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			BoundsToXML(myElement);
			myElement.SetAttribute("color", StringCommon.ColorToHtml(FillColor));
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			using (SolidBrush brush = new SolidBrush(FillColor))
			{
				g.FillRectangle(brush, myBounds);
			}
			return true;
		}
	}
}
