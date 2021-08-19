using System;
using System.Drawing;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class ZYTextChar : ZYTextElement
	{
		private char myChar = ' ';

		private Font myFont = null;

		private Color intForeColor = SystemColors.WindowText;

		private static StringFormat myMeasureFormat = null;

		public Font Font
		{
			get
			{
				if (myFont == null)
				{
					myFont = myOwnerDocument.View._CreateFont(FontName, FontSize, FontBold, FontItalic, FontUnderLine);
				}
				return myFont;
			}
			set
			{
				FontName = value.Name;
				FontSize = value.Size;
				FontBold = value.Bold;
				FontItalic = value.Italic;
				FontUnderLine = value.Underline;
			}
		}

		public override ZYTextDocument OwnerDocument
		{
			get
			{
				return base.OwnerDocument;
			}
			set
			{
				base.OwnerDocument = value;
				myFont = null;
			}
		}

		public string FontName
		{
			get
			{
				return myAttributes.GetString("fontname");
			}
			set
			{
				myAttributes.SetValue("fontname", value);
				myFont = null;
			}
		}

		public float FontSize
		{
			get
			{
				return myAttributes.GetFloat("fontsize");
			}
			set
			{
				myAttributes.SetValue("fontsize", value);
				myFont = null;
			}
		}

		public bool FontBold
		{
			get
			{
				return myAttributes.GetBool("fontbold");
			}
			set
			{
				myAttributes.SetValue("fontbold", value);
				myFont = null;
			}
		}

		public bool FontUnderLine
		{
			get
			{
				return myAttributes.GetBool("fontunderline");
			}
			set
			{
				myAttributes.SetValue("fontunderline", value);
				myFont = null;
			}
		}

		public bool FontItalic
		{
			get
			{
				return myAttributes.GetBool("fontitalic");
			}
			set
			{
				myAttributes.SetValue("fontitalic", value);
				myFont = null;
			}
		}

		public bool Sup
		{
			get
			{
				return myAttributes.GetBool("sup");
			}
			set
			{
				myAttributes.SetValue("sup", value);
				myFont = null;
			}
		}

		public bool Sub
		{
			get
			{
				return myAttributes.GetBool("sub");
			}
			set
			{
				myAttributes.SetValue("sub", value);
				myFont = null;
			}
		}

		public Color ForeColor
		{
			get
			{
				if (myOwnerDocument.Info.Printing)
				{
					return intForeColor;
				}
				if (myOwnerDocument.IsLock(this))
				{
					return ZYTextConst.LockedForeColor;
				}
				return intForeColor;
			}
			set
			{
				myAttributes.SetValue("forecolor", value);
				intForeColor = value;
			}
		}

		public char Char
		{
			get
			{
				return myChar;
			}
			set
			{
				myChar = value;
			}
		}

		internal void ClearFont()
		{
			myFont = null;
		}

		public override string GetXMLName()
		{
			return "span";
		}

		public bool AppendToXML(XmlElement myElement)
		{
			XmlText newChild = myElement.OwnerDocument.CreateTextNode(myChar.ToString());
			myElement.AppendChild(newChild);
			return true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			if (myElement == null)
			{
				return false;
			}
			string text = myElement.InnerText;
			if (text == null || text.Length == 0)
			{
				text = " ";
			}
			myChar = text[0];
			return base.FromXML(myElement);
		}

		public override void UpdateAttrubute()
		{
			intForeColor = myAttributes.GetColor("forecolor");
			ClearFont();
			base.UpdateAttrubute();
		}

		public override bool ToXML(XmlElement myElement)
		{
			if (myElement == null)
			{
				return false;
			}
			switch (myOwnerDocument.Info.SaveMode)
			{
			case 0:
			{
				XmlText newChild2 = myElement.OwnerDocument.CreateTextNode(myChar.ToString());
				myElement.AppendChild(newChild2);
				myAttributes.ToXML(myElement);
				break;
			}
			case 1:
			{
				XmlText newChild = myElement.OwnerDocument.CreateTextNode(myChar.ToString());
				myElement.AppendChild(newChild);
				return true;
			}
			default:
				return false;
			case 2:
				break;
			}
			return true;
		}

		public override bool CanBeLineHead()
		{
			return "!),.:;?]}\u00a8·\u02c7\u02c9―‖’”…∶、。〃\u3005〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠\"'".IndexOf(myChar) < 0;
		}

		public override bool CanBeLineEnd()
		{
			return "([{·‘“〈《「『【〔〖（．［｛￡￥".IndexOf(myChar) < 0;
		}

		public bool IsSymbol()
		{
			return "!),.:;?]}\u00a8·\u02c7\u02c9―‖’”…∶、。〃\u3005〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠\"'".IndexOf(myChar) >= 0 || "([{·‘“〈《「『【〔〖（．［｛￡￥".IndexOf(myChar) >= 0;
		}

		public override bool RefreshSize()
		{
			if (myMeasureFormat == null)
			{
				myMeasureFormat = new StringFormat(StringFormat.GenericTypographic);
				myMeasureFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
			}
			bool sup = Sup;
			bool sub = Sub;
			if (myFont == null)
			{
				myFont = myOwnerDocument.View._CreateFont(FontName, (sub || sup) ? ((float)(int)((double)FontSize * 0.6)) : FontSize, FontBold, FontItalic, FontUnderLine);
			}
			SizeF sizeF = myOwnerDocument.View.Graph.MeasureString(myChar.ToString(), myFont, 10000, myMeasureFormat);
			if (myChar == '\t')
			{
				intWidth = myOwnerDocument.View.GetTabWidth(RealLeft);
			}
			else
			{
				intWidth = (int)sizeF.Width;
			}
			intHeight = (int)Math.Ceiling(myFont.GetHeight(myOwnerDocument.View.Graph));
			if (sub || sup)
			{
				Height = (int)((double)intHeight * 1.9);
			}
			return true;
		}

		public override bool RefreshView()
		{
			if (!myOwnerDocument.isNeedDraw(this))
			{
				return true;
			}
			if (char.IsWhiteSpace(myChar))
			{
				return true;
			}
			int realLeft = RealLeft;
			int realTop = RealTop;
			bool sub = Sub;
			bool sup = Sup;
			if (myFont == null)
			{
				myFont = myOwnerDocument.View._CreateFont(FontName, (sub || sup) ? ((float)(int)((double)FontSize * 0.6)) : FontSize, FontBold, FontItalic, FontUnderLine);
			}
			if (sub || sup)
			{
				SizeF sizeF = myOwnerDocument.View.MeasureChar(myChar, myFont);
				myOwnerDocument.View.DrawChar(myChar, myFont, ForeColor, realLeft, sup ? realTop : (realTop + Height - (int)sizeF.Height));
			}
			else
			{
				myOwnerDocument.View.DrawChar(myChar, myFont, ForeColor, realLeft, realTop);
			}
			return true;
		}

		public override string ToEMRString()
		{
			return myChar.ToString();
		}

		public override string ToString()
		{
			return "ZYTextChar:" + myChar;
		}

		protected ZYTextChar()
		{
		}

		public static ZYTextChar Create(char c)
		{
			ZYTextChar zYTextChar = (c != '\t') ? new ZYTextChar() : new ZYTextCharTab();
			zYTextChar.Char = c;
			return zYTextChar;
		}
	}
}
