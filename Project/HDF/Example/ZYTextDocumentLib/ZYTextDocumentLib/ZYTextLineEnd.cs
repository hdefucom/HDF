using System.Drawing;
using XDesignerGUI;

namespace ZYTextDocumentLib
{
	public class ZYTextLineEnd : ZYTextElement
	{
		public override bool CanBeLineHead()
		{
			return false;
		}

		public override bool isNewLine()
		{
			return true;
		}

		public override string GetXMLName()
		{
			return "br";
		}

		public override bool RefreshSize()
		{
			intWidth = myOwnerDocument.PixelToDocumentUnit(11);
			intHeight = myOwnerDocument.PixelToDocumentUnit(myOwnerDocument.DefaultRowHeight);
			return true;
		}

		public override string ToEMRString()
		{
			return "\r\n";
		}

		public override bool RefreshView()
		{
			if (myOwnerDocument.Info.Printing)
			{
				return true;
			}
			if (myOwnerDocument.Info.ShowParagraphFlag)
			{
				myOwnerDocument.View.DrawLineFlag(RealLeft, RealTop + Height, GraphicsUnitConvert.GetRate(myOwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel));
			}
			return true;
		}
	}
}
