using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextBorder
	{
		public const ButtonBorderStyle DefaultStyle = ButtonBorderStyle.Solid;

		public const int DefaultWidth = 0;

		public const string c_Border_Top_Color = "border-top-color";

		public const string c_Border_Top_Width = "border-top-width";

		public const string c_Border_Top_Style = "border-top-style";

		public const string c_Border_Left_Color = "border-left-color";

		public const string c_Border_Left_Width = "border-left-width";

		public const string c_Border_Left_Style = "border-left-style";

		public const string c_Border_Right_Color = "border-right-color";

		public const string c_Border_Right_Width = "border-right-width";

		public const string c_Border_Right_Style = "border-right-style";

		public const string c_Border_Bottom_Color = "border-bottom-color";

		public const string c_Border_Bottom_Width = "border-bottom-width";

		public const string c_Border_Bottom_Style = "border-bottom-style";

		public const string c_Border_Color = "border-color";

		public const string c_Border_Width = "border-width";

		public const string c_Border_Style = "border-style";

		public const string c_BackGround_Color = "background-color";

		public static Color DefaultColor = Color.Black;

		public static Color DefaultBackColor = Color.White;

		public Color leftColor = DefaultColor;

		public int leftWidth = 0;

		public ButtonBorderStyle leftStyle = ButtonBorderStyle.Solid;

		public Color topColor = DefaultColor;

		public int topWidth = 0;

		public ButtonBorderStyle topStyle = ButtonBorderStyle.Solid;

		public Color rightColor = DefaultColor;

		public int rightWidth = 0;

		public ButtonBorderStyle rightStyle = ButtonBorderStyle.Solid;

		public Color bottomColor = DefaultColor;

		public int bottomWidth = 0;

		public ButtonBorderStyle bottomStyle = ButtonBorderStyle.Solid;

		public Color backColor = DefaultBackColor;

		public bool hasBackGround = false;

		public int BorderWidth
		{
			get
			{
				return leftWidth;
			}
			set
			{
				leftWidth = value;
				topWidth = value;
				rightWidth = value;
				bottomWidth = value;
			}
		}

		public Color BorderColor
		{
			get
			{
				return leftColor;
			}
			set
			{
				leftColor = value;
				topColor = value;
				rightColor = value;
				bottomColor = value;
			}
		}

		public ButtonBorderStyle BorderStyle
		{
			get
			{
				return leftStyle;
			}
			set
			{
				leftStyle = value;
				topStyle = value;
				rightStyle = value;
				bottomStyle = value;
			}
		}

		public ZYTextBorder Clone()
		{
			ZYTextBorder zYTextBorder = new ZYTextBorder();
			zYTextBorder.CopyFrom(this);
			return zYTextBorder;
		}

		public void CopyFrom(ZYTextBorder b)
		{
			if (b != null)
			{
				leftColor = b.leftColor;
				leftStyle = b.leftStyle;
				leftWidth = b.leftWidth;
				topColor = b.topColor;
				topStyle = b.topStyle;
				topWidth = b.topWidth;
				rightColor = b.rightColor;
				rightStyle = b.rightStyle;
				rightWidth = b.rightWidth;
				bottomColor = b.bottomColor;
				bottomStyle = b.bottomStyle;
				bottomWidth = b.bottomWidth;
			}
		}

		public bool EqualBorder(ZYTextBorder b)
		{
			if (this == b)
			{
				return true;
			}
			if (b != null)
			{
				return leftWidth == b.leftWidth && topWidth == b.topWidth && rightWidth == b.rightWidth && bottomWidth == b.bottomWidth && leftStyle.Equals(b.leftStyle) && topStyle.Equals(b.topStyle) && rightStyle.Equals(b.rightStyle) && bottomStyle.Equals(b.bottomStyle) && leftColor.Equals(b.leftColor) && topColor.Equals(b.topColor) && rightColor.Equals(b.rightColor) && bottomColor.Equals(b.bottomColor) && hasBackGround == b.hasBackGround && backColor == b.backColor;
			}
			return false;
		}

		public static bool TestXML(XmlElement myElement)
		{
			if (myElement != null || myElement.HasAttribute("border-color") || myElement.HasAttribute("border-width") || myElement.HasAttribute("border-style") || myElement.HasAttribute("border-left-color") || myElement.HasAttribute("border-left-width") || myElement.HasAttribute("border-left-style") || myElement.HasAttribute("border-top-color") || myElement.HasAttribute("border-top-width") || myElement.HasAttribute("border-top-style") || myElement.HasAttribute("border-right-color") || myElement.HasAttribute("border-right-width") || myElement.HasAttribute("border-right-style") || myElement.HasAttribute("border-bottom-color") || myElement.HasAttribute("border-bottom-width") || myElement.HasAttribute("border-bottom-style") || myElement.HasAttribute("background-color"))
			{
				return true;
			}
			return false;
		}

		public bool FromXML(XmlElement myElement)
		{
			Clear();
			return FromXMLWithoutClear(myElement);
		}

		public bool FromXMLWithoutClear(XmlElement myElement)
		{
			if (myElement != null)
			{
				if (myElement.HasAttribute("border-color"))
				{
					BorderColor = StringCommon.ColorFromHtml(myElement.GetAttribute("border-color"), DefaultColor);
				}
				if (myElement.HasAttribute("border-width"))
				{
					BorderWidth = StringCommon.ToInt32Value(myElement.GetAttribute("border-width"), 0);
				}
				if (myElement.HasAttribute("border-style"))
				{
					BorderStyle = ToBorderStyle(myElement.GetAttribute("border-style"));
				}
				if (myElement.HasAttribute("border-left-color"))
				{
					leftColor = StringCommon.ColorFromHtml(myElement.GetAttribute("border-left-color"), DefaultColor);
				}
				if (myElement.HasAttribute("border-left-width"))
				{
					leftWidth = StringCommon.ToInt32Value(myElement.GetAttribute("border-left-width"), 0);
				}
				if (myElement.HasAttribute("border-left-style"))
				{
					leftStyle = ToBorderStyle(myElement.GetAttribute("border-left-style"));
				}
				if (myElement.HasAttribute("border-top-color"))
				{
					topColor = StringCommon.ColorFromHtml(myElement.GetAttribute("border-top-color"), DefaultColor);
				}
				if (myElement.HasAttribute("border-top-width"))
				{
					topWidth = StringCommon.ToInt32Value(myElement.GetAttribute("border-top-width"), 0);
				}
				if (myElement.HasAttribute("border-top-style"))
				{
					topStyle = ToBorderStyle(myElement.GetAttribute("border-top-style"));
				}
				if (myElement.HasAttribute("border-right-color"))
				{
					rightColor = StringCommon.ColorFromHtml(myElement.GetAttribute("border-right-color"), DefaultColor);
				}
				if (myElement.HasAttribute("border-right-width"))
				{
					rightWidth = StringCommon.ToInt32Value(myElement.GetAttribute("border-right-width"), 0);
				}
				if (myElement.HasAttribute("border-right-style"))
				{
					rightStyle = ToBorderStyle(myElement.GetAttribute("border-right-style"));
				}
				if (myElement.HasAttribute("border-bottom-color"))
				{
					bottomColor = StringCommon.ColorFromHtml(myElement.GetAttribute("border-bottom-color"), DefaultColor);
				}
				if (myElement.HasAttribute("border-bottom-width"))
				{
					bottomWidth = StringCommon.ToInt32Value(myElement.GetAttribute("border-bottom-width"), 0);
				}
				if (myElement.HasAttribute("border-bottom-style"))
				{
					bottomStyle = ToBorderStyle(myElement.GetAttribute("border-bottom-style"));
				}
				hasBackGround = myElement.HasAttribute("background-color");
				if (hasBackGround)
				{
					backColor = StringCommon.ColorFromHtml(myElement.GetAttribute("background-color"), DefaultBackColor);
				}
				else
				{
					backColor = DefaultBackColor;
				}
				return true;
			}
			return false;
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				if (leftColor.Equals(topColor) && topColor.Equals(rightColor) && rightColor.Equals(bottomColor))
				{
					if (!leftColor.Equals(DefaultColor))
					{
						myElement.SetAttribute("border-color", StringCommon.ColorToHtml(leftColor));
					}
				}
				else
				{
					if (!leftColor.Equals(DefaultColor))
					{
						myElement.SetAttribute("border-left-color", StringCommon.ColorToHtml(leftColor));
					}
					if (!topColor.Equals(DefaultColor))
					{
						myElement.SetAttribute("border-top-color", StringCommon.ColorToHtml(topColor));
					}
					if (!rightColor.Equals(DefaultColor))
					{
						myElement.SetAttribute("border-right-color", StringCommon.ColorToHtml(rightColor));
					}
					if (!bottomColor.Equals(DefaultColor))
					{
						myElement.SetAttribute("border-bottom-color", StringCommon.ColorToHtml(bottomColor));
					}
				}
				if (leftWidth == topWidth && topWidth == rightWidth && rightWidth == bottomWidth)
				{
					if (leftWidth != 0)
					{
						myElement.SetAttribute("border-width", leftWidth.ToString());
					}
				}
				else
				{
					if (leftWidth != 0)
					{
						myElement.SetAttribute("border-left-width", leftWidth.ToString());
					}
					if (topWidth != 0)
					{
						myElement.SetAttribute("border-top-width", topWidth.ToString());
					}
					if (rightWidth != 0)
					{
						myElement.SetAttribute("border-right-width", rightWidth.ToString());
					}
					if (bottomWidth != 0)
					{
						myElement.SetAttribute("border-bottom-width", bottomWidth.ToString());
					}
				}
				if (leftStyle == topStyle && topStyle == rightStyle && rightStyle == bottomStyle)
				{
					if (!leftStyle.Equals(ButtonBorderStyle.Solid))
					{
						myElement.SetAttribute("border-style", leftStyle.ToString().ToLower());
					}
				}
				else
				{
					if (leftStyle != ButtonBorderStyle.Solid)
					{
						myElement.SetAttribute("border-left-style", leftStyle.ToString().ToLower());
					}
					if (topStyle != ButtonBorderStyle.Solid)
					{
						myElement.SetAttribute("border-top-style", topStyle.ToString().ToLower());
					}
					if (rightStyle != ButtonBorderStyle.Solid)
					{
						myElement.SetAttribute("border-right-style", rightStyle.ToString().ToLower());
					}
					if (bottomStyle != ButtonBorderStyle.Solid)
					{
						myElement.SetAttribute("border-bottom-style", bottomStyle.ToString().ToLower());
					}
				}
				if (hasBackGround)
				{
					myElement.SetAttribute("background-color", StringCommon.ColorToHtml(backColor));
				}
				return true;
			}
			return false;
		}

		public bool ToXMLEx(XmlElement myElement, ZYTextBorder b)
		{
			if (myElement != null && b != null && b != this)
			{
				if (leftColor.Equals(topColor) && topColor.Equals(rightColor) && rightColor.Equals(bottomColor))
				{
					if (!leftColor.Equals(DefaultColor) && !leftColor.Equals(b.leftColor))
					{
						myElement.SetAttribute("border-color", StringCommon.ColorToHtml(leftColor));
					}
				}
				else
				{
					if (!leftColor.Equals(DefaultColor) && !leftColor.Equals(b.leftColor))
					{
						myElement.SetAttribute("border-left-color", StringCommon.ColorToHtml(leftColor));
					}
					if (!topColor.Equals(DefaultColor) && !topColor.Equals(b.topColor))
					{
						myElement.SetAttribute("border-top-color", StringCommon.ColorToHtml(topColor));
					}
					if (!rightColor.Equals(DefaultColor) && !rightColor.Equals(b.rightColor))
					{
						myElement.SetAttribute("border-right-color", StringCommon.ColorToHtml(rightColor));
					}
					if (!bottomColor.Equals(DefaultColor) && !bottomColor.Equals(b.bottomColor))
					{
						myElement.SetAttribute("border-bottom-color", StringCommon.ColorToHtml(bottomColor));
					}
				}
				if (leftWidth == topWidth && topWidth == rightWidth && rightWidth == bottomWidth)
				{
					if (leftWidth != 0 && leftWidth != b.leftWidth)
					{
						myElement.SetAttribute("border-width", leftWidth.ToString());
					}
				}
				else
				{
					if (leftWidth != 0 && leftWidth != b.leftWidth)
					{
						myElement.SetAttribute("border-left-width", leftWidth.ToString());
					}
					if (topWidth != 0 && topWidth != b.topWidth)
					{
						myElement.SetAttribute("border-top-width", topWidth.ToString());
					}
					if (rightWidth != 0 && rightWidth != b.rightWidth)
					{
						myElement.SetAttribute("border-right-width", rightWidth.ToString());
					}
					if (bottomWidth != 0 && bottomWidth != b.bottomWidth)
					{
						myElement.SetAttribute("border-bottom-width", bottomWidth.ToString());
					}
				}
				if (leftStyle == topStyle && topStyle == rightStyle && rightStyle == bottomStyle)
				{
					if (!leftStyle.Equals(ButtonBorderStyle.Solid) && !leftStyle.Equals(b.leftStyle))
					{
						myElement.SetAttribute("border-style", leftStyle.ToString().ToLower());
					}
				}
				else
				{
					if (leftStyle != ButtonBorderStyle.Solid && leftStyle != b.leftStyle)
					{
						myElement.SetAttribute("border-left-style", leftStyle.ToString().ToLower());
					}
					if (topStyle != ButtonBorderStyle.Solid && topStyle != b.topStyle)
					{
						myElement.SetAttribute("border-top-style", topStyle.ToString().ToLower());
					}
					if (rightStyle != ButtonBorderStyle.Solid && rightStyle != b.rightStyle)
					{
						myElement.SetAttribute("border-right-style", rightStyle.ToString().ToLower());
					}
					if (bottomStyle != ButtonBorderStyle.Solid && bottomStyle != b.bottomStyle)
					{
						myElement.SetAttribute("border-bottom-style", bottomStyle.ToString().ToLower());
					}
				}
				if (hasBackGround && hasBackGround != b.hasBackGround && backColor != b.backColor)
				{
					myElement.SetAttribute("background-color", StringCommon.ColorToHtml(backColor));
				}
				return true;
			}
			return false;
		}

		private static ButtonBorderStyle ToBorderStyle(string strValue)
		{
			try
			{
				return (ButtonBorderStyle)Enum.Parse(ButtonBorderStyle.Solid.GetType(), strValue, ignoreCase: true);
			}
			catch
			{
				return ButtonBorderStyle.Solid;
			}
		}

		public void Clear()
		{
			leftWidth = 0;
			leftStyle = ButtonBorderStyle.Solid;
			topColor = DefaultColor;
			topWidth = 0;
			topStyle = ButtonBorderStyle.Solid;
			rightColor = DefaultColor;
			rightWidth = 0;
			rightStyle = ButtonBorderStyle.Solid;
			bottomColor = DefaultColor;
			bottomWidth = 0;
			bottomStyle = ButtonBorderStyle.Solid;
			hasBackGround = false;
			backColor = DefaultBackColor;
		}

		public void Draw(DocumentView view, Rectangle myRect)
		{
			view.DrawBorder(myRect, leftColor, leftWidth, leftStyle, topColor, topWidth, topStyle, rightColor, rightWidth, rightStyle, bottomColor, bottomWidth, bottomStyle);
		}

		public bool DrawBackGround(Graphics myGraph, Rectangle myRect)
		{
			if (myGraph != null && hasBackGround && !myRect.IsEmpty)
			{
				using (SolidBrush brush = new SolidBrush(backColor))
				{
					myGraph.FillRectangle(brush, myRect);
				}
				return true;
			}
			return false;
		}

		public void Draw(DocumentView view, int left, int top, int width, int height)
		{
			Draw(view, new Rectangle(left, top, width, height));
		}

		public ZYTextBorder()
		{
			Clear();
		}
	}
}
