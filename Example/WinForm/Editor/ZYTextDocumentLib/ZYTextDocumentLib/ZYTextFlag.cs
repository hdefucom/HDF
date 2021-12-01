using System.Drawing;

namespace ZYTextDocumentLib
{
	public class ZYTextFlag : ZYTextElement
	{
		public string Text
		{
			get
			{
				return myAttributes.GetString("text");
			}
			set
			{
				myAttributes.SetValue("text", value);
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
			}
		}

		public Font Font
		{
			get
			{
				return myOwnerDocument.View._CreateFont(FontName, FontSize, FontBold, FontItalic, FontUnderLine);
			}
			set
			{
				FontName = value.Name;
				FontSize = value.Size;
				FontItalic = value.Italic;
				FontBold = value.Bold;
				FontUnderLine = value.Underline;
			}
		}

		public override string GetXMLName()
		{
			return "textflag";
		}

		public override bool RefreshSize()
		{
			string text = Text;
			if (text == null || text.Length == 0)
			{
				text = "  ";
			}
			Font font = Font;
			SizeF sizeF = myOwnerDocument.View.MeasureString(text, font);
			Width = (int)sizeF.Width + 12;
			Height = (int)sizeF.Height + 4;
			return true;
		}

		public override bool RefreshView()
		{
			string text = Text;
			Font font = Font;
			Rectangle rectangle = new Rectangle(RealLeft, RealTop, Width, Height);
			myOwnerDocument.View.DrawString(text, font, SystemColors.ControlText, rectangle.X, rectangle.Y);
			return true;
		}

		public override string ToEMRString()
		{
			return Text;
		}
	}
}
