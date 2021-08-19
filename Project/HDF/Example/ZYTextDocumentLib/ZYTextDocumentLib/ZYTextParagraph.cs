using System.Drawing;
using XDesignerGUI;

namespace ZYTextDocumentLib
{
	public class ZYTextParagraph : ZYTextElement
	{
		public ParagraphAlignConst Align
		{
			get
			{
				return (ParagraphAlignConst)myAttributes.GetInt32("align");
			}
			set
			{
				myAttributes.SetValue("align", (int)value);
			}
		}

		public bool LeftAlign
		{
			get
			{
				return Align == ParagraphAlignConst.Left;
			}
			set
			{
				Align = ParagraphAlignConst.Left;
			}
		}

		public bool CenterAlign
		{
			get
			{
				return Align == ParagraphAlignConst.Center;
			}
			set
			{
				Align = ParagraphAlignConst.Center;
			}
		}

		public bool RightAlign
		{
			get
			{
				return Align == ParagraphAlignConst.Right;
			}
			set
			{
				Align = ParagraphAlignConst.Right;
			}
		}

		public bool JustifyAlign
		{
			get
			{
				return Align == ParagraphAlignConst.Justify;
			}
			set
			{
				Align = ParagraphAlignConst.Justify;
			}
		}

		public override string GetXMLName()
		{
			return "p";
		}

		public override bool isNewParagraph()
		{
			return true;
		}

		public override bool isNewLine()
		{
			return true;
		}

		public override string ToEMRString()
		{
			return "\r\n";
		}

		public override bool RefreshSize()
		{
			intWidth = myOwnerDocument.PixelToDocumentUnit(11);
			intHeight = myOwnerDocument.DefaultRowHeight;
			return true;
		}

		public override bool RefreshView()
		{
			if (myOwnerDocument.Info.Printing)
			{
				return true;
			}
			if (myOwnerDocument.Info.ShowParagraphFlag)
			{
				myOwnerDocument.View.DrawParagraphFlag(RealLeft, RealTop + Height, GraphicsUnitConvert.GetRate(myOwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel));
			}
			return true;
		}
	}
}
