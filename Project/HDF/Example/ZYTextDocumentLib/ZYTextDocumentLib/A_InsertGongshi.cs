using System.Drawing;
using XDesignerGUI;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_InsertGongshi : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertgongshi";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool UIExecute()
		{
			string[] array = inputBox4.InputBox4();
			if (array == null)
			{
				return false;
			}
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			string text4 = array[3];
			Font font = new Font("仿宋_GB2312", 12f);
			StringFormat stringFormat = new StringFormat();
			stringFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
			SizeF sizeF = default(SizeF);
			SizeF sizeF2 = default(SizeF);
			SizeF sizeF3 = default(SizeF);
			SizeF sizeF4 = default(SizeF);
			sizeF = base.OwnerDocument.View.Graph.MeasureString(text, font, 10000, stringFormat);
			sizeF = GraphicsUnitConvert.Convert(sizeF, GraphicsUnit.Document, GraphicsUnit.Pixel);
			sizeF2 = base.OwnerDocument.View.Graph.MeasureString(text2, font, 10000, stringFormat);
			sizeF2 = GraphicsUnitConvert.Convert(sizeF2, GraphicsUnit.Document, GraphicsUnit.Pixel);
			sizeF3 = base.OwnerDocument.View.Graph.MeasureString(text3, font, 10000, stringFormat);
			sizeF3 = GraphicsUnitConvert.Convert(sizeF3, GraphicsUnit.Document, GraphicsUnit.Pixel);
			sizeF4 = base.OwnerDocument.View.Graph.MeasureString(text4, font, 10000, stringFormat);
			sizeF4 = GraphicsUnitConvert.Convert(sizeF4, GraphicsUnit.Document, GraphicsUnit.Pixel);
			float num = (sizeF.Width > sizeF2.Width) ? sizeF.Width : sizeF2.Width;
			float num2 = num + sizeF3.Width + sizeF4.Width;
			Bitmap bitmap = new Bitmap((int)num2, (int)sizeF.Height + (int)sizeF2.Height + 1);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawString(text, font, Brushes.Black, new PointF((float)((int)(num - sizeF.Width) / 2) + sizeF3.Width, 0f));
			Pen pen = new Pen(Color.Black, 1f);
			graphics.DrawLine(pen, new Point((int)sizeF3.Width, bitmap.Height / 2), new Point((int)(sizeF3.Width + num), bitmap.Height / 2));
			graphics.DrawString(text2, font, Brushes.Black, new PointF((float)((int)(num - sizeF2.Width) / 2) + sizeF3.Width, bitmap.Height / 2 + 1));
			graphics.DrawString(text3, font, Brushes.Black, new PointF(0f, ((float)bitmap.Height - sizeF3.Height) / 2f));
			graphics.DrawString(text4, font, Brushes.Black, new PointF((float)bitmap.Width - sizeF4.Width, ((float)bitmap.Height - sizeF4.Height) / 2f));
			ZYTextImage zYTextImage = new ZYTextImage();
			zYTextImage.SaveInFile = true;
			zYTextImage.ImageType = "";
			zYTextImage.Image = bitmap;
			if (zYTextImage.Image != null)
			{
				zYTextImage.Width = base.OwnerDocument.PixelToDocumentUnit(zYTextImage.Image.Width);
				zYTextImage.Height = base.OwnerDocument.PixelToDocumentUnit(zYTextImage.Image.Height);
			}
			myOwnerDocument._InsertElement(zYTextImage);
			return false;
		}
	}
}
