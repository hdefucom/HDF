using System;
using System.Drawing;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public abstract class ImageEditAction
	{
		protected Rectangle myBounds = Rectangle.Empty;

		public virtual Rectangle Bounds
		{
			get
			{
				return myBounds;
			}
			set
			{
				myBounds = value;
			}
		}

		public virtual string ActionName => null;

		public virtual bool Selectable => true;

		public virtual bool DesignChangeBounds(Rectangle NewBounds)
		{
			Bounds = NewBounds;
			return true;
		}

		public virtual bool FromXML(XmlElement myElement)
		{
			return false;
		}

		public virtual bool ToXML(XmlElement myElement)
		{
			return false;
		}

		public virtual bool Execute(Graphics g, Rectangle ClipRect)
		{
			return false;
		}

		public virtual bool IsVisible(Rectangle ClipRect)
		{
			return true;
		}

		public bool BoundsFromXML(XmlElement myElement)
		{
			myBounds = new Rectangle(Convert.ToInt32(myElement.GetAttribute("left")), Convert.ToInt32(myElement.GetAttribute("top")), Convert.ToInt32(myElement.GetAttribute("width")), Convert.ToInt32(myElement.GetAttribute("height")));
			return true;
		}

		public bool BoundsToXML(XmlElement myElement)
		{
			myElement.SetAttribute("left", myBounds.Left.ToString());
			myElement.SetAttribute("top", myBounds.Top.ToString());
			myElement.SetAttribute("width", myBounds.Width.ToString());
			myElement.SetAttribute("height", myBounds.Height.ToString());
			return true;
		}

		public Rectangle[] GetDragRects()
		{
			return DocumentView.GetDragRects(Bounds, 4, InnerDragRect: true);
		}
	}
}
