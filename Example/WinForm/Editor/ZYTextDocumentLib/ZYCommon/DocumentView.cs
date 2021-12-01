using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using Windows32;

namespace ZYCommon
{
	public class DocumentView : IDisposable
	{
		public enum GDICommandConst
		{
			ClearGDIOjbects,
			CreateBrush,
			CreateFont,
			CreatePen,
			DrawExpendHandle,
			DrawRectangle,
			FillRectangle,
			DrawFillRectangle,
			DrawSingleLine,
			DrawSingleLine2,
			DrawTriangle,
			DrawSelectionFrame,
			DrawBorder,
			DrawChar,
			DrawString,
			DrawLine,
			DrawLine2,
			DrawParagraphFlag,
			DrawLineFlag,
			DrawDragRect,
			DrawImage,
			DrawFieldBackGround,
			DrawDeleteLine,
			DrawBackGround,
			DrawHighlightBackGround,
			TranslateTransform,
			Page
		}

		public const int c_ComBoxSize = 16;

		public const int c_ExpendBoxSize = 8;

		public const int ParaGraphFlagWidth = 11;

		public const int LineFlagWidth = 11;

		public Font myDefaultFont = new Font(ZYFont.GetFontNameForCurrentSystem("宋体"), 12f);

		private Color myDefaultColor = SystemColors.WindowText;

		private Brush myFieldBrush = new SolidBrush(Color.Silver);

		private Brush myNewBrush = new SolidBrush(Color.FromArgb(255, 238, 238));

		private Pen myDeletePen = new Pen(Color.Red);

		private StringFormat mySingleLineFormat = new StringFormat();

		private Graphics myGraph = null;

		private Rectangle myViewRect = Rectangle.Empty;

		private Brush myCurrentBrush = null;

		private ArrayList myFontList = new ArrayList();

		private Font myCurrentFont = null;

		private bool bolDrawAll = false;

		private int intLeft = 0;

		private int intTop = 0;

		private int intWidth = 300;

		private int intHeight = 100;

		private int intTabStep = 0;

		private int intContainerIndent = 5;

		private Rectangle myInvalidlyRect = Rectangle.Empty;

		private CommandLine myCommandOutPut = null;

		private ArrayList myGDIObjects = new ArrayList();

		private static StringFormat mySingleLineFormat2 = null;

		public CommandLine CommandOutPut
		{
			get
			{
				return myCommandOutPut;
			}
			set
			{
				myCommandOutPut = value;
			}
		}

		public int ContainerIndent
		{
			get
			{
				return intContainerIndent;
			}
			set
			{
				intContainerIndent = value;
			}
		}

		public bool DrawAll
		{
			get
			{
				return bolDrawAll;
			}
			set
			{
				bolDrawAll = value;
			}
		}

		public int Left
		{
			get
			{
				return intLeft;
			}
			set
			{
				intLeft = value;
			}
		}

		public int Top
		{
			get
			{
				return intTop;
			}
			set
			{
				intTop = value;
			}
		}

		public int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
			}
		}

		public int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
			}
		}

		public GraphicsUnit GraphicsUnit
		{
			get
			{
				if (myGraph == null)
				{
					return GraphicsUnit.Display;
				}
				return myGraph.PageUnit;
			}
			set
			{
				if (myGraph != null)
				{
					myGraph.PageUnit = value;
				}
			}
		}

		public Graphics Graph
		{
			get
			{
				return myGraph;
			}
			set
			{
				myGraph = value;
				if (myGraph != null)
				{
					intTabStep = (int)MeasureString("____", myDefaultFont).Width;
				}
			}
		}

		public double TwipsPerPixelX
		{
			get
			{
				if (myGraph == null)
				{
					return 1.0;
				}
				int num = (int)myGraph.GetHdc();
				double num2 = Gdi32.GetDeviceCaps(num, 88);
				myGraph.ReleaseHdc(new IntPtr(num));
				if (num2 > 0.0)
				{
					return 1440.0 / num2;
				}
				return 1.0;
			}
		}

		public double TwipsPerPixelY
		{
			get
			{
				if (myGraph == null)
				{
					return 1.0;
				}
				int num = (int)myGraph.GetHdc();
				double num2 = Gdi32.GetDeviceCaps(num, 90);
				myGraph.ReleaseHdc(new IntPtr(num));
				if (num2 > 0.0)
				{
					return 1440.0 / num2;
				}
				return 1.0;
			}
		}

		public Font DefaultFont
		{
			get
			{
				return myDefaultFont;
			}
			set
			{
				myDefaultFont = value;
			}
		}

		public int DefaultRowPixelHeight => (int)myDefaultFont.GetHeight();

		public Brush FieldBrush
		{
			get
			{
				return myFieldBrush;
			}
			set
			{
				myFieldBrush = value;
			}
		}

		public Brush NewBrush
		{
			get
			{
				return myNewBrush;
			}
			set
			{
				myNewBrush = value;
			}
		}

		public Pen DeletePen
		{
			get
			{
				return myDeletePen;
			}
			set
			{
				myDeletePen = value;
			}
		}

		public Rectangle ViewRect
		{
			get
			{
				return myViewRect;
			}
			set
			{
				myViewRect = value;
			}
		}

		public DocumentView()
		{
			myCurrentFont = myDefaultFont;
			mySingleLineFormat.Trimming = StringTrimming.EllipsisCharacter;
			mySingleLineFormat.FormatFlags = StringFormatFlags.NoWrap;
		}

		public void ClearGDIObjects()
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.Write("clearobjects");
			}
			foreach (IDisposable myGDIObject in myGDIObjects)
			{
				myGDIObject.Dispose();
			}
			myGDIObjects.Clear();
		}

		public void WriteCreateCommand()
		{
			if (myCommandOutPut == null)
			{
				return;
			}
			for (int i = 0; i < myGDIObjects.Count; i++)
			{
				object obj = myGDIObjects[i];
				if (obj is SolidBrush)
				{
					SolidBrush solidBrush = (SolidBrush)obj;
					myCommandOutPut.CommandName = "createbrush";
					myCommandOutPut.SetColor(solidBrush.Color);
					myCommandOutPut.Write();
				}
				else if (obj is Pen)
				{
					Pen pen = (Pen)obj;
					myCommandOutPut.CommandName = "createpen";
					myCommandOutPut.SetColor(pen.Color);
					myCommandOutPut.SetWidth((int)pen.Width);
					myCommandOutPut.Write();
				}
				else if (obj is Font)
				{
					Font font = (Font)obj;
					myCommandOutPut.CommandName = "createfont";
					myCommandOutPut.SetValue("name", font.Name);
					myCommandOutPut.SetValue("size", font.Size.ToString());
					myCommandOutPut.SetBoolean("bold", font.Bold);
					myCommandOutPut.SetBoolean("italic", font.Italic);
					myCommandOutPut.SetBoolean("underline", font.Underline);
					myCommandOutPut.Write();
				}
			}
		}

		private int GetPenIndex(Color c)
		{
			return GetPenIndex(c, 1);
		}

		private int GetPenIndex(Color c, int vWidth)
		{
			int num = 0;
			foreach (object myGDIObject in myGDIObjects)
			{
				if (myGDIObject is Pen)
				{
					Pen pen = (Pen)myGDIObject;
					if (pen.Color == c && (int)pen.Width == vWidth)
					{
						return num;
					}
				}
				num++;
			}
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "createpen";
				myCommandOutPut.SetColor(c);
				myCommandOutPut.SetWidth(vWidth);
				myCommandOutPut.Write();
			}
			Pen value = new Pen(c, vWidth);
			myGDIObjects.Add(value);
			return myGDIObjects.Count - 1;
		}

		private int GetFontIndex(string FontName, float FontSize, bool Bold, bool Italic, bool UnderLine)
		{
			int num = 0;
			foreach (object myGDIObject in myGDIObjects)
			{
				if (myGDIObject is Font)
				{
					Font font = (Font)myGDIObject;
					if (font.Name == FontName && font.Size == FontSize && font.Bold == Bold && font.Italic == Italic && font.Underline == UnderLine)
					{
						return num;
					}
				}
				num++;
			}
			if (myCommandOutPut != null && myCommandOutPut.CanWrite())
			{
				myCommandOutPut.CommandName = "createfont";
				myCommandOutPut.SetValue("name", FontName);
				myCommandOutPut.SetValue("size", FontSize.ToString());
				myCommandOutPut.SetBoolean("bold", Bold);
				myCommandOutPut.SetBoolean("italic", Italic);
				myCommandOutPut.SetBoolean("underline", UnderLine);
				myCommandOutPut.Write();
			}
			Font value = new Font(FontName, FontSize, GetFontStyle(Bold, Italic, UnderLine));
			myGDIObjects.Add(value);
			return myGDIObjects.Count - 1;
		}

		private int GetBrushIndex(Color c)
		{
			int num = 0;
			foreach (object myGDIObject in myGDIObjects)
			{
				if (myGDIObject is SolidBrush)
				{
					SolidBrush solidBrush = (SolidBrush)myGDIObject;
					if (solidBrush.Color == c)
					{
						return num;
					}
				}
				num++;
			}
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "createbrush";
				myCommandOutPut.SetColor(c);
				myCommandOutPut.Write();
			}
			SolidBrush value = new SolidBrush(c);
			myGDIObjects.Add(value);
			return myGDIObjects.Count - 1;
		}

		public SolidBrush _CreateBrush(Color c)
		{
			return (SolidBrush)myGDIObjects[GetBrushIndex(c)];
		}

		public Font _CreateFont(string FontName, float FontSize, bool Bold, bool Italic, bool UnderLine)
		{
			return myGDIObjects[GetFontIndex(FontName, FontSize, Bold, Italic, UnderLine)] as Font;
		}

		public Pen _CreatePen(Color c, int vWidth)
		{
			return (Pen)myGDIObjects[GetPenIndex(c, vWidth)];
		}

		public Pen _CreatePen(Color c)
		{
			return _CreatePen(c, 1);
		}

		public void DrawExpendHandle(int x, int y, int height, bool bolExpended)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawexpendhandle";
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetHeight(height);
				myCommandOutPut.SetBoolean("expended", bolExpended);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				Rectangle expendHandleRect = GetExpendHandleRect(x, y, height);
				StaticDrawExpendHandle(myGraph, expendHandleRect, bolExpended);
			}
		}

		public static void StaticDrawExpendHandle(Graphics g, Rectangle BoxRect, bool bolExpended)
		{
			if (g != null)
			{
				g.FillRectangle(SystemBrushes.Window, BoxRect);
				g.DrawRectangle(SystemPens.WindowText, BoxRect);
				g.DrawLine(SystemPens.WindowText, BoxRect.X + 2, (int)((double)BoxRect.Y + (double)BoxRect.Height / 2.0), BoxRect.X + BoxRect.Width - 2, (int)((double)BoxRect.Y + (double)BoxRect.Height / 2.0));
				if (!bolExpended)
				{
					g.DrawLine(SystemPens.WindowText, (int)((double)BoxRect.X + (double)BoxRect.Width / 2.0), BoxRect.Y + 2, (int)((double)BoxRect.X + (double)BoxRect.Width / 2.0), BoxRect.Y + BoxRect.Height - 2);
				}
			}
		}

		public void DrawRectangle(Color vColor, Rectangle vRect)
		{
			if (vRect.Width >= 0 && vRect.Height >= 0)
			{
				int penIndex = GetPenIndex(vColor);
				if (myCommandOutPut != null)
				{
					myCommandOutPut.CommandName = "drawrectangle";
					myCommandOutPut.SetPenIndex(penIndex);
					myCommandOutPut.SetRectangle(vRect);
					myCommandOutPut.Write();
				}
				if (myGraph != null)
				{
					myGraph.DrawRectangle((Pen)myGDIObjects[penIndex], vRect);
				}
			}
		}

		public void FillRectangle(Color vColor, Rectangle vRect)
		{
			if (vRect.Width >= 0 && vRect.Height >= 0)
			{
				int brushIndex = GetBrushIndex(vColor);
				if (myCommandOutPut != null)
				{
					myCommandOutPut.CommandName = "fillrectangle";
					myCommandOutPut.SetBrushIndex(brushIndex);
					myCommandOutPut.SetRectangle(vRect);
					myCommandOutPut.Write();
				}
				if (myGraph != null)
				{
					myGraph.FillRectangle((Brush)myGDIObjects[brushIndex], vRect);
				}
			}
		}

		public void FillRectangle(Color vColor, int vLeft, int vTop, int vWidth, int vHeight)
		{
			FillRectangle(vColor, new Rectangle(vLeft, vTop, vWidth, vHeight));
		}

		public void DrawFillRectangle(Color BorderColor, Color FillColor, Rectangle vRect)
		{
			if (vRect.Width < 0 || vRect.Height < 0)
			{
				return;
			}
			int penIndex = GetPenIndex(BorderColor);
			int brushIndex = GetBrushIndex(FillColor);
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawfillrectangle";
				myCommandOutPut.SetPenIndex(penIndex);
				myCommandOutPut.SetBrushIndex(brushIndex);
				myCommandOutPut.SetRectangle(vRect);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				if (vRect.Width > 0 && vRect.Height > 0)
				{
					myGraph.FillRectangle((Brush)myGDIObjects[brushIndex], vRect);
				}
				myGraph.DrawRectangle((Pen)myGDIObjects[penIndex], vRect);
			}
		}

		public void DrawSingleLine(string strText, Color ForeColor, int x, int y, int width)
		{
			int brushIndex = GetBrushIndex(ForeColor);
			if (myCommandOutPut != null && width >= 0)
			{
				myCommandOutPut.CommandName = "drawsingleline";
				myCommandOutPut.SetBrushIndex(brushIndex);
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetWidth(width);
				myCommandOutPut.SetValue("text", strText);
			}
			if (myGraph != null && width >= 0)
			{
				RectangleF layoutRectangle = new RectangleF(x, y, width, 100f);
				myGraph.DrawString(strText, myDefaultFont, (Brush)myGDIObjects[brushIndex], layoutRectangle, mySingleLineFormat);
			}
		}

		public void DrawSingleLine2(string strText, Color ForeColor, int x, int y, int width)
		{
			if (myCommandOutPut != null && width >= 0)
			{
				myCommandOutPut.CommandName = "drawsingleline2";
				myCommandOutPut.SetColor(ForeColor);
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetWidth(width);
				myCommandOutPut.SetValue("text", strText);
				myCommandOutPut.Write();
			}
			if (myGraph != null && width >= 0)
			{
				if (mySingleLineFormat2 == null)
				{
					mySingleLineFormat2 = new StringFormat(StringFormat.GenericTypographic);
					mySingleLineFormat2.FormatFlags = StringFormatFlags.NoWrap;
					mySingleLineFormat2.Alignment = StringAlignment.Center;
				}
				RectangleF layoutRectangle = new RectangleF(x, y, width, 100f);
				using (SolidBrush brush = new SolidBrush(ForeColor))
				{
					myGraph.DrawString(strText, myDefaultFont, brush, layoutRectangle, mySingleLineFormat2);
				}
			}
		}

		public void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Color BorderColor, Color BackColor)
		{
			Point[] array = new Point[4];
			array[0].X = x1;
			array[0].Y = y1;
			array[1].X = x2 + x1;
			array[1].Y = y2 + y1;
			array[2].X = x3 + x1;
			array[2].Y = y3 + y1;
			array[3] = array[0];
			using (Pen pen = new Pen(BorderColor))
			{
				myGraph.DrawLines(pen, array);
			}
			using (SolidBrush brush = new SolidBrush(BackColor))
			{
				myGraph.FillPolygon(brush, array);
			}
		}

		public void DrawSelectionFrame(Rectangle myBounds)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "selectionframe";
				myCommandOutPut.SetRectangle(myBounds);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				ControlPaint.DrawSelectionFrame(myGraph, active: false, myBounds, Rectangle.Empty, SystemColors.Highlight);
			}
		}

		public void DrawBorder(Rectangle myRect, Color leftColor, int leftWidth, ButtonBorderStyle leftStyle, Color topColor, int topWidth, ButtonBorderStyle topStyle, Color rightColor, int rightWidth, ButtonBorderStyle rightStyle, Color bottomColor, int bottomWidth, ButtonBorderStyle bottomStyle)
		{
			ControlPaint.DrawBorder(myGraph, myRect, leftColor, leftWidth, leftStyle, topColor, topWidth, topStyle, rightColor, rightWidth, rightStyle, bottomColor, bottomWidth, bottomStyle);
		}

		public void DrawChar(char myChar, Font myFont, Color ForeColor, int x, int y)
		{
			int brushIndex = GetBrushIndex(ForeColor);
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "char";
				myCommandOutPut.SetValue("f", myGDIObjects.IndexOf(myFont).ToString());
				myCommandOutPut.SetColor(ForeColor);
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetValue("ch", myChar.ToString());
				myCommandOutPut.Write();
			}
			if (myGraph != null && myFont != null)
			{
				myGraph.DrawString(myChar.ToString(), myFont, (Brush)myGDIObjects[brushIndex], x, y, StringFormat.GenericTypographic);
			}
		}

		public void DrawString(string strText, Font myFont, Color ForeColor, int x, int y)
		{
			if (myFont == null)
			{
				myFont = DefaultFont;
			}
			int brushIndex = GetBrushIndex(ForeColor);
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "string";
				myCommandOutPut.SetValue("f", myGDIObjects.IndexOf(myFont).ToString());
				myCommandOutPut.SetColor(ForeColor);
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetValue("text", strText);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				myGraph.DrawString(strText, myFont, (Brush)myGDIObjects[brushIndex], x, y);
			}
		}

		public void DrawString(string strText, int x, int y, int width, int height)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawstring2";
				myCommandOutPut.SetRectangle(x, y, width, height);
				myCommandOutPut.SetValue("text", strText);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				myGraph.DrawString(strText, DefaultFont, SystemBrushes.WindowText, new RectangleF(x, y, width, height));
			}
		}

		public void DrawLine(Color ForeColor, int x, int y, int x2, int y2)
		{
			int penIndex = GetPenIndex(ForeColor);
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawline";
				myCommandOutPut.SetPenIndex(penIndex);
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetPoint2(x2, y2);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				myGraph.DrawLine((Pen)myGDIObjects[penIndex], x, y, x2, y2);
			}
		}

		public void DrawLine(Pen myPen, int x, int y, int x2, int y2)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawline2";
				myCommandOutPut.SetValue("pen", myGDIObjects.IndexOf(myPen).ToString());
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.SetPoint2(x2, y2);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				myGraph.DrawLine(myPen, x, y, x2, y2);
			}
		}

		public void DrawParagraphFlag(int x, int y, double rate)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawparagraph";
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				int[] array = new int[24]
				{
					0,
					-3,
					2,
					-1,
					0,
					-3,
					2,
					-5,
					2,
					-1,
					2,
					-4,
					0,
					-3,
					5,
					-3,
					5,
					-3,
					6,
					-4,
					6,
					-4,
					6,
					-7
				};
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (int)((double)array[i] * rate);
				}
				Pen controlDark = SystemPens.ControlDark;
				for (int i = 0; i < array.Length; i += 4)
				{
					myGraph.DrawLine(controlDark, x + array[i], y + array[i + 1], x + array[i + 2], y + array[i + 3]);
				}
			}
		}

		public void DrawLineFlag(int x, int y, double rate)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawlineflag";
				myCommandOutPut.SetPoint(x, y);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				int[] array = new int[16]
				{
					0,
					-2,
					2,
					0,
					0,
					-2,
					4,
					-2,
					2,
					0,
					4,
					-2,
					2,
					0,
					2,
					-7
				};
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (int)((double)array[i] * rate);
				}
				Pen controlDark = SystemPens.ControlDark;
				for (int i = 0; i < array.Length; i += 4)
				{
					myGraph.DrawLine(controlDark, x + array[i], y + array[i + 1] - 2, x + array[i + 2], y + array[i + 3] - 2);
				}
			}
		}

		public void DrawDragRect(Rectangle myRect, int DragRectSize, bool InnerDragRect, Color BorderColor, Color BackColor)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawgragrect";
				myCommandOutPut.SetRectangle(myRect);
				myCommandOutPut.SetValue("dragsize", DragRectSize.ToString());
				myCommandOutPut.SetBoolean("innerdragrect", InnerDragRect);
				myCommandOutPut.SetColor("border", BorderColor);
				myCommandOutPut.SetColor("fill", BackColor);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				Rectangle[] dragRects = GetDragRects(myRect, DragRectSize, InnerDragRect);
				using (SolidBrush brush = new SolidBrush(BackColor))
				{
					myGraph.FillRectangles(brush, dragRects);
				}
				using (Pen pen = new Pen(BorderColor))
				{
					myGraph.DrawRectangles(pen, dragRects);
				}
			}
		}

		public void DrawImage(Image myImage, int x, int y, int width, int height)
		{
			if (myImage != null)
			{
				if (myCommandOutPut != null)
				{
					myCommandOutPut.CommandName = "drawimage";
					myCommandOutPut.SetRectangle(x, y, width, height);
					myCommandOutPut.SetValue("image", StringCommon.ImageToBase64String(myImage, ImageFormat.Jpeg));
					myCommandOutPut.Write();
				}
				if (myGraph != null)
				{
					myGraph.DrawImage(myImage, x, y, width, height);
				}
			}
		}

		public void DrawFieldBackGround(int x, int y, int width, int height)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawfieldback";
				myCommandOutPut.SetRectangle(x, y, width, height);
				myCommandOutPut.Write();
			}
			if (myGraph != null && myFieldBrush != null)
			{
				myGraph.FillRectangle(myFieldBrush, x, y, width, height);
			}
		}

		public void DrawDeleteLine(int x, int y, int width, int height, int linenum)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawdeleteline";
				myCommandOutPut.SetRectangle(x, y, width, height);
				myCommandOutPut.SetValue("line", linenum.ToString());
				myCommandOutPut.Write();
			}
			if (myGraph != null && myDeletePen != null)
			{
				if (linenum == 1)
				{
					myGraph.DrawLine(myDeletePen, x, y + (int)((double)height * 0.5), x + width, y + (int)((double)height * 0.5));
				}
				if (linenum == 2)
				{
					myGraph.DrawLine(myDeletePen, x, y + (int)((double)height * 0.3), x + width, y + (int)((double)height * 0.3));
					myGraph.DrawLine(myDeletePen, x, y + (int)((double)height * 0.6), x + width, y + (int)((double)height * 0.6));
				}
			}
		}

		public void DrawBackGround(int x, int y, int width, int height)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "drawback";
				myCommandOutPut.SetRectangle(x, y, width, height);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				myGraph.FillRectangle(SystemBrushes.Window, x, y, width, height);
			}
		}

		public void InvertRect(int x, int y, int width, int height)
		{
			if (myGraph != null)
			{
				int num = (int)myGraph.Transform.OffsetX;
				int num2 = (int)myGraph.Transform.OffsetY;
				int num3 = (int)myGraph.GetHdc();
				User32.InvertRect(num3, num + x, num2 + y, width, height);
				myGraph.ReleaseHdc(new IntPtr(num3));
			}
		}

		public void InvertRect(Rectangle rect)
		{
			InvertRect(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public Bitmap GetBitmap(BoolNoParameterHandler CalcuteSize, BoolNoParameterHandler DrawAllHandler, int intImgWidth, int intImgHeight)
		{
			if (DrawAllHandler == null)
			{
				return null;
			}
			Graphics graphics = myGraph;
			myGraph = null;
			Bitmap bitmap = null;
			try
			{
				if (CalcuteSize != null)
				{
					bitmap = new Bitmap(10, 10);
					myGraph = Graphics.FromImage(bitmap);
					if (graphics != null)
					{
						myGraph.PageUnit = graphics.PageUnit;
					}
					if (!CalcuteSize())
					{
						myGraph.Dispose();
						bitmap.Dispose();
						return null;
					}
					myGraph.Dispose();
					bitmap.Dispose();
				}
				if (myCommandOutPut != null)
				{
					myCommandOutPut.CommandName = "page";
					myCommandOutPut.SetSize(intWidth, intHeight);
					myCommandOutPut.Write();
				}
				if (intImgWidth > 0)
				{
					intWidth = intImgWidth;
				}
				if (intImgHeight > 0)
				{
					intHeight = intImgHeight;
				}
				bitmap = new Bitmap(intWidth, intHeight);
				myGraph = Graphics.FromImage(bitmap);
				myGraph.Clear(SystemColors.Window);
				bolDrawAll = true;
				if (myCommandOutPut != null)
				{
					myCommandOutPut.TwipsPerPixelX = TwipsPerPixelX;
					myCommandOutPut.TwipsPerPixelY = TwipsPerPixelY;
				}
				if (DrawAllHandler())
				{
					myGraph.Dispose();
					myGraph = graphics;
					bolDrawAll = false;
					return bitmap;
				}
			}
			catch (Exception ex)
			{
				if (myGraph != null)
				{
					using (Font font = new Font("Arial", 13f))
					{
						myGraph.DrawString(ex.ToString(), font, SystemBrushes.WindowText, 0f, 0f, StringFormat.GenericTypographic);
					}
				}
				bitmap?.Dispose();
			}
			if (graphics != null)
			{
				myGraph = graphics;
			}
			bolDrawAll = false;
			return null;
		}

		public void TranslateTransform(int dx, int dy)
		{
			if (myCommandOutPut != null)
			{
				myCommandOutPut.CommandName = "transtorm";
				myCommandOutPut.SetPoint(dx, dy);
				myCommandOutPut.Write();
			}
			if (myGraph != null)
			{
				myGraph.TranslateTransform(dx, dy);
			}
		}

		public static FontStyle GetFontStyle(bool Bold, bool Italic, bool UnderLine)
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (Italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (UnderLine)
			{
				fontStyle |= FontStyle.Underline;
			}
			return fontStyle;
		}

		public void AddInvalidlyRect(int vLeft, int vTop, int vWidth, int vHeight)
		{
			if (myInvalidlyRect.IsEmpty)
			{
				myInvalidlyRect = new Rectangle(vLeft, vTop, vWidth, vHeight);
			}
			else
			{
				myInvalidlyRect = Rectangle.Union(myInvalidlyRect, new Rectangle(vLeft, vTop, vWidth, vHeight));
			}
		}

		public void AddInvalidlyRect(Rectangle vRect)
		{
			if (myInvalidlyRect.IsEmpty)
			{
				myInvalidlyRect = vRect;
			}
			else
			{
				myInvalidlyRect = Rectangle.Union(myInvalidlyRect, vRect);
			}
		}

		public void MoveTo(int x, int y)
		{
			intLeft = x;
			intTop = y;
		}

		public Graphics GetInnerGraph()
		{
			return myGraph;
		}

		public Rectangle GetExpendHandleRect(int x, int y, int height)
		{
			if (height <= 8)
			{
				height = 8;
			}
			return new Rectangle(x - intLeft - 8 - 2, y - intTop + (int)((double)(height - 8) / 2.0), 8, 8);
		}

		public static Rectangle StaticGetExpendHandleRect(int x, int y, int height)
		{
			if (height <= 8)
			{
				height = 8;
			}
			return new Rectangle(x - 8 - 2, y - (int)((double)(height - 8) / 2.0), 8, 8);
		}

		public static Rectangle StaticGetExpendHandleRect2(int x, int y, int height)
		{
			return new Rectangle(x, y + (int)((double)(height - 8) / 2.0), 8, 8);
		}

		public static Rectangle[] GetDragRects(Rectangle myRect, int DragRectSize, bool InnerDragRect)
		{
			Rectangle[] array = new Rectangle[8];
			if (InnerDragRect)
			{
				array[0] = new Rectangle(myRect.X, myRect.Y, DragRectSize, DragRectSize);
				array[1] = new Rectangle(myRect.X + (myRect.Width - DragRectSize) / 2, myRect.Y, DragRectSize, DragRectSize);
				array[2] = new Rectangle(myRect.Right - DragRectSize, myRect.Y, DragRectSize, DragRectSize);
				array[3] = new Rectangle(myRect.Right - DragRectSize, myRect.Y + (myRect.Height - DragRectSize) / 2, DragRectSize, DragRectSize);
				array[4] = new Rectangle(myRect.Right - DragRectSize, myRect.Bottom - DragRectSize, DragRectSize, DragRectSize);
				array[5] = new Rectangle(myRect.X + (myRect.Width - DragRectSize) / 2, myRect.Bottom - DragRectSize, DragRectSize, DragRectSize);
				array[6] = new Rectangle(myRect.X, myRect.Bottom - DragRectSize, DragRectSize, DragRectSize);
				array[7] = new Rectangle(myRect.X, myRect.Y + (myRect.Height - DragRectSize) / 2, DragRectSize, DragRectSize);
			}
			else
			{
				array[0] = new Rectangle(myRect.X - DragRectSize, myRect.Y - DragRectSize, DragRectSize, DragRectSize);
				array[1] = new Rectangle(myRect.X + (myRect.Width - DragRectSize) / 2, myRect.Y - DragRectSize, DragRectSize, DragRectSize);
				array[2] = new Rectangle(myRect.Right, myRect.Y - DragRectSize, DragRectSize, DragRectSize);
				array[3] = new Rectangle(myRect.Right, myRect.Y + (myRect.Height - DragRectSize) / 2, DragRectSize, DragRectSize);
				array[4] = new Rectangle(myRect.Right, myRect.Bottom, DragRectSize, DragRectSize);
				array[5] = new Rectangle(myRect.X + (myRect.Width - DragRectSize) / 2, myRect.Bottom, DragRectSize, DragRectSize);
				array[6] = new Rectangle(myRect.X - DragRectSize, myRect.Bottom, DragRectSize, DragRectSize);
				array[7] = new Rectangle(myRect.X - DragRectSize, myRect.Y + (myRect.Height - DragRectSize) / 2, DragRectSize, DragRectSize);
			}
			return array;
		}

		public static Cursor GetDragRectCursor(int index)
		{
			switch (index)
			{
			case 0:
				return System.Windows.Forms.Cursors.SizeNWSE;
			case 1:
				return System.Windows.Forms.Cursors.SizeNS;
			case 2:
				return System.Windows.Forms.Cursors.SizeNESW;
			case 3:
				return System.Windows.Forms.Cursors.SizeWE;
			case 4:
				return System.Windows.Forms.Cursors.SizeNWSE;
			case 5:
				return System.Windows.Forms.Cursors.SizeNS;
			case 6:
				return System.Windows.Forms.Cursors.SizeNESW;
			case 7:
				return System.Windows.Forms.Cursors.SizeWE;
			default:
				return null;
			}
		}

		public static bool DrawDragRect(Graphics g, Rectangle vRect, bool HeightLight)
		{
			if (g != null && !vRect.IsEmpty)
			{
				if (HeightLight)
				{
					g.FillRectangle(Brushes.DarkBlue, vRect);
					g.DrawRectangle(Pens.White, vRect);
				}
				else
				{
					g.FillRectangle(Brushes.White, vRect);
					g.DrawRectangle(Pens.Black, vRect);
				}
				return true;
			}
			return false;
		}

		public SizeF MeasureChar(char myChar, Font myFont)
		{
			SizeF result = new Size(0, 0);
			if (myFont == null)
			{
				myFont = myDefaultFont;
			}
			if (myGraph != null && myFont != null)
			{
				myGraph.TextRenderingHint = TextRenderingHint.AntiAlias;
				result = ((myChar != ' ' && myChar != '\b') ? myGraph.MeasureString(myChar.ToString(), myFont, 10000, StringFormat.GenericTypographic) : myGraph.MeasureString(myChar.ToString(), myFont, 10000, StringFormat.GenericDefault));
			}
			return result;
		}

		public SizeF MeasureString(string strText, Font myFont)
		{
			SizeF result = new SizeF(0f, 0f);
			if (myGraph != null)
			{
				if (myFont == null)
				{
					myFont = myDefaultFont;
				}
				return myGraph.MeasureString(strText, myFont, 10000, StringFormat.GenericTypographic);
			}
			return result;
		}

		public bool isNeedDraw(int x, int y, int width, int height)
		{
			if (bolDrawAll || myViewRect.IsEmpty)
			{
				return true;
			}
			return myViewRect.IntersectsWith(new Rectangle(x, y, width, height));
		}

		public bool isNeedDrawX(int intLeft, int intWidth)
		{
			if (bolDrawAll || myViewRect.IsEmpty)
			{
				return true;
			}
			return intLeft < myViewRect.Right && myViewRect.Left < intLeft + intWidth;
		}

		public bool isNeedDrawY(int intTop, int intHeight)
		{
			if (bolDrawAll || myViewRect.IsEmpty)
			{
				return true;
			}
			return intTop < myViewRect.Bottom && myViewRect.Top < intTop + intHeight;
		}

		public bool isNeedDraw(Rectangle myRect)
		{
			if (bolDrawAll)
			{
				return true;
			}
			if (myViewRect.IsEmpty)
			{
				return true;
			}
			return myViewRect.IntersectsWith(myRect);
		}

		public int GetTabWidth(int Pos)
		{
			int num = intTabStep;
			if (intTabStep > 0)
			{
				num = intTabStep * (int)Math.Ceiling((double)Pos / (double)intTabStep) - Pos;
				if (num == 0)
				{
					num = intTabStep;
				}
			}
			return num;
		}

		public void Dispose()
		{
			myDefaultFont.Dispose();
			myFieldBrush.Dispose();
			myNewBrush.Dispose();
			if (myCurrentBrush != null)
			{
				myCurrentBrush.Dispose();
			}
			ClearGDIObjects();
			mySingleLineFormat.Dispose();
		}
	}
}
