using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageTextAction : ImageEditAction
	{
		public string FontName = "宋体";

		public float FontSize = 10f;

		public bool Bold = false;

		public bool Italic = false;

		public string Text = null;

		public Color ForeColor = Color.Black;

		public Rectangle Rect = Rectangle.Empty;

		public override string ActionName => "text";

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if (Text != null && Text.Length > 0)
			{
				using (Font font = new Font(FontName, FontSize, DocumentView.GetFontStyle(Bold, Italic, UnderLine: false)))
				{
					using (SolidBrush brush = new SolidBrush(ForeColor))
					{
						using (StringFormat stringFormat = new StringFormat())
						{
							stringFormat.Alignment = StringAlignment.Center;
							stringFormat.LineAlignment = StringAlignment.Center;
							g.DrawString(Text, font, brush, new RectangleF(myBounds.Left, myBounds.Top, myBounds.Width, myBounds.Height), stringFormat);
						}
					}
				}
			}
			return true;
		}
	}
}
