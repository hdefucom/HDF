using System.Drawing;

namespace XDesignerPrinting
{
	public interface IPageDocument
	{
		GraphicsUnit DocumentGraphicsUnit
		{
			get;
			set;
		}

		PrintPageCollection Pages
		{
			get;
			set;
		}

		int PageIndex
		{
			get;
			set;
		}

		void DrawDocument(Graphics g, Rectangle ClipRectangle);

		void DrawHead(Graphics g, Rectangle ClipRectangle);

		void DrawFooter(Graphics g, Rectangle ClipRectangle);
	}
}
