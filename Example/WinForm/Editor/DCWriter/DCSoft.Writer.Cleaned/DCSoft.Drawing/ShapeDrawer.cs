using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       图形绘制对象
	///       </summary>
	[ComVisible(false)]
	public class ShapeDrawer
	{
		private RectangleF myBounds = RectangleF.Empty;

		private float fRoundRadio = 0f;

		private ShapeTypes intType = ShapeTypes.Rectangle;

		private Pen myBorderPen = null;

		private Brush myFillBrush = null;

		/// <summary>
		///       对象边框
		///       </summary>
		public RectangleF Bounds
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

		/// <summary>
		///       设置/返回对象左端位置
		///       </summary>
		public float Left
		{
			get
			{
				return myBounds.Left;
			}
			set
			{
				myBounds.X = value;
			}
		}

		/// <summary>
		///       设置/返回对象的顶端位置
		///       </summary>
		public float Top
		{
			get
			{
				return myBounds.Top;
			}
			set
			{
				myBounds.Y = value;
			}
		}

		/// <summary>
		///       设置/返回对象宽度
		///       </summary>
		public float Width
		{
			get
			{
				return myBounds.Width;
			}
			set
			{
				myBounds.Width = value;
			}
		}

		/// <summary>
		///       设置/返回对象高度
		///       </summary>
		public float Height
		{
			get
			{
				return myBounds.Height;
			}
			set
			{
				myBounds.Height = value;
			}
		}

		/// <summary>
		///       圆角半径
		///       </summary>
		public float RoundRadio
		{
			get
			{
				return fRoundRadio;
			}
			set
			{
				fRoundRadio = value;
			}
		}

		/// <summary>
		///       符号类型
		///       </summary>
		public ShapeTypes Type
		{
			get
			{
				return intType;
			}
			set
			{
				intType = value;
			}
		}

		/// <summary>
		///       绘制边框使用的画笔对象
		///       </summary>
		public Pen BorderPen
		{
			get
			{
				return myBorderPen;
			}
			set
			{
				myBorderPen = value;
			}
		}

		/// <summary>
		///       填充对象使用的画刷对象
		///       </summary>
		public Brush FillBrush
		{
			get
			{
				return myFillBrush;
			}
			set
			{
				myFillBrush = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ShapeDrawer()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="rect">矩形对象</param>
		/// <param name="type">图形类型</param>
		/// <param name="BorderColor">边框色</param>
		/// <param name="FillColor">背景色</param>
		public ShapeDrawer(RectangleF rect, ShapeTypes type, Color BorderColor, Color FillColor)
		{
			myBounds = rect;
			intType = type;
			myBorderPen = new Pen(BorderColor);
			myFillBrush = new SolidBrush(FillColor);
		}

		/// <summary>
		///       创新路径对象
		///       </summary>
		/// <returns>
		/// </returns>
		public GraphicsPath CreatePath()
		{
			switch (intType)
			{
			default:
				return null;
			case ShapeTypes.Rectangle:
				return CreateRoundRectanglePath(myBounds, fRoundRadio);
			case ShapeTypes.Square:
				return CreateRoundRectanglePath(GetSquareRect(), fRoundRadio);
			case ShapeTypes.Ellipse:
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddEllipse(myBounds);
				return graphicsPath6;
			}
			case ShapeTypes.Circle:
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddEllipse(GetSquareRect());
				return graphicsPath5;
			}
			case ShapeTypes.Diamond:
				return CreateDiamondPath(myBounds);
			case ShapeTypes.TriangleUp:
				return CreateTrianglePath(myBounds, 0);
			case ShapeTypes.TriangleRight:
				return CreateTrianglePath(myBounds, 1);
			case ShapeTypes.TriangleDown:
				return CreateTrianglePath(myBounds, 2);
			case ShapeTypes.TriangleLeft:
				return CreateTrianglePath(myBounds, 3);
			case ShapeTypes.Cross:
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(myBounds.Left, myBounds.Top + myBounds.Height / 2f, myBounds.Right, myBounds.Top + myBounds.Height / 2f);
				graphicsPath4.AddLine(myBounds.Left + myBounds.Width / 2f, myBounds.Top, myBounds.Left + myBounds.Width / 2f, myBounds.Bottom);
				return graphicsPath4;
			}
			case ShapeTypes.XCross:
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(myBounds.Left, myBounds.Top, myBounds.Right, myBounds.Bottom);
				graphicsPath3.AddLine(myBounds.Right, myBounds.Top, myBounds.Left, myBounds.Bottom);
				return graphicsPath3;
			}
			case ShapeTypes.CircleCross:
			{
				RectangleF squareRect2 = GetSquareRect();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddLine(squareRect2.Left, squareRect2.Top + squareRect2.Height / 2f, squareRect2.Right, squareRect2.Top + squareRect2.Height / 2f);
				graphicsPath2.AddLine(squareRect2.Left + squareRect2.Width / 2f, squareRect2.Top, squareRect2.Left + squareRect2.Width / 2f, squareRect2.Bottom);
				graphicsPath2.AddEllipse(squareRect2);
				return graphicsPath2;
			}
			case ShapeTypes.CircleXCross:
			{
				RectangleF squareRect = GetSquareRect();
				float num = squareRect.Width / 2f;
				float num2 = (int)((double)num * Math.Sin(Math.PI / 4.0));
				GraphicsPath graphicsPath = new GraphicsPath();
				float num3 = myBounds.Left + myBounds.Width / 2f;
				float num4 = myBounds.Top + myBounds.Height / 2f;
				graphicsPath.AddLine(num3 - num2, num4 - num2, num3 + num2, num4 + num2);
				graphicsPath.AddLine(num3 + num2, num4 - num2, num3 - num2, num4 + num2);
				graphicsPath.AddEllipse(squareRect);
				return graphicsPath;
			}
			case ShapeTypes.Default:
				return CreateRoundRectanglePath(myBounds, fRoundRadio);
			}
		}

		/// <summary>
		///       获得居中的正方形
		///       </summary>
		/// <returns>
		/// </returns>
		private RectangleF GetSquareRect()
		{
			if (myBounds.Width > myBounds.Height)
			{
				return new RectangleF(myBounds.Left + (myBounds.Width - myBounds.Height) / 2f, myBounds.Top, myBounds.Height, myBounds.Height);
			}
			return new RectangleF(myBounds.Left, myBounds.Top + (myBounds.Height - myBounds.Width) / 2f, myBounds.Width, myBounds.Width);
		}

		/// <summary>
		///       绘制图形边框 
		///       </summary>
		/// <param name="g">
		/// </param>
		public void DrawBorder(Graphics graphics_0)
		{
			if (myBorderPen == null || graphics_0 == null)
			{
				return;
			}
			switch (intType)
			{
			default:
			{
				GraphicsPath graphicsPath = CreatePath();
				if (graphicsPath != null)
				{
					graphics_0.DrawPath(myBorderPen, graphicsPath);
					graphicsPath.Dispose();
				}
				break;
			}
			case ShapeTypes.Cross:
				graphics_0.DrawLine(myBorderPen, myBounds.Left, myBounds.Top + myBounds.Height / 2f, myBounds.Right, myBounds.Top + myBounds.Height / 2f);
				graphics_0.DrawLine(myBorderPen, myBounds.Left + myBounds.Width / 2f, myBounds.Top, myBounds.Left + myBounds.Width / 2f, myBounds.Bottom);
				break;
			case ShapeTypes.XCross:
				graphics_0.DrawLine(myBorderPen, myBounds.Left, myBounds.Top, myBounds.Right, myBounds.Bottom);
				graphics_0.DrawLine(myBorderPen, myBounds.Right, myBounds.Top, myBounds.Left, myBounds.Bottom);
				break;
			case ShapeTypes.CircleCross:
			{
				RectangleF squareRect2 = GetSquareRect();
				graphics_0.DrawLine(myBorderPen, squareRect2.Left, squareRect2.Top + squareRect2.Height / 2f, squareRect2.Right, squareRect2.Top + squareRect2.Height / 2f);
				graphics_0.DrawLine(myBorderPen, squareRect2.Left + squareRect2.Width / 2f, squareRect2.Top, squareRect2.Left + squareRect2.Width / 2f, squareRect2.Bottom);
				graphics_0.DrawEllipse(myBorderPen, squareRect2);
				break;
			}
			case ShapeTypes.CircleXCross:
			{
				RectangleF squareRect = GetSquareRect();
				float num = squareRect.Width / 2f;
				float num2 = (int)((double)num * Math.Sin(Math.PI / 4.0));
				new GraphicsPath();
				float num3 = myBounds.Left + myBounds.Width / 2f;
				float num4 = myBounds.Top + myBounds.Height / 2f;
				graphics_0.DrawLine(myBorderPen, num3 - num2, num4 - num2, num3 + num2, num4 + num2);
				graphics_0.DrawLine(myBorderPen, num3 + num2, num4 - num2, num3 - num2, num4 + num2);
				graphics_0.DrawEllipse(myBorderPen, squareRect);
				break;
			}
			}
		}

		/// <summary>
		///       填充图形
		///       </summary>
		/// <param name="g">
		/// </param>
		public void Fill(Graphics graphics_0)
		{
			if (myFillBrush == null || graphics_0 == null)
			{
				return;
			}
			switch (intType)
			{
			case ShapeTypes.Cross:
			case ShapeTypes.XCross:
				return;
			case ShapeTypes.CircleCross:
			{
				RectangleF squareRect2 = GetSquareRect();
				graphics_0.FillEllipse(myFillBrush, squareRect2);
				return;
			}
			case ShapeTypes.CircleXCross:
			{
				RectangleF squareRect = GetSquareRect();
				graphics_0.FillEllipse(myFillBrush, squareRect);
				return;
			}
			}
			GraphicsPath graphicsPath = CreatePath();
			if (graphicsPath != null)
			{
				graphics_0.FillPath(myFillBrush, graphicsPath);
				graphicsPath.Dispose();
			}
		}

		/// <summary>
		///       绘制边框并填充内容
		///       </summary>
		/// <param name="g">画布对象</param>
		public void DrawAndFill(Graphics graphics_0)
		{
			if (graphics_0 != null)
			{
				if (myFillBrush != null)
				{
					Fill(graphics_0);
				}
				if (myBorderPen != null)
				{
					DrawBorder(graphics_0);
				}
			}
		}

		/// <summary>
		///       创建一个三角形路径
		///       </summary>
		/// <param name="rect">外切矩形</param>
		/// <param name="direction">三角形方向 0:向上 1:向右 2:向下 3:向左</param>
		/// <returns>创建路径对象</returns>
		public static GraphicsPath CreateTrianglePath(RectangleF rect, int direction)
		{
			int num = 10;
			if (direction < 0 || direction > 3)
			{
				throw new ArgumentOutOfRangeException("direction", "0->3");
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			float num2 = rect.Width / 2f;
			float num3 = rect.Height / 2f;
			switch (direction)
			{
			case 0:
				graphicsPath.AddLine(rect.Left + num2, rect.Top, rect.Right, rect.Bottom);
				graphicsPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
				graphicsPath.AddLine(rect.Left, rect.Bottom, rect.Left + num2, rect.Top);
				break;
			case 1:
				graphicsPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + num3);
				graphicsPath.AddLine(rect.Right, rect.Top + num3, rect.Left, rect.Bottom);
				graphicsPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
				break;
			case 2:
				graphicsPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
				graphicsPath.AddLine(rect.Right, rect.Top, rect.Left + num2, rect.Bottom);
				graphicsPath.AddLine(rect.Left + num2, rect.Bottom, rect.Left, rect.Top);
				break;
			case 3:
				graphicsPath.AddLine(rect.Left, rect.Top + num3, rect.Right, rect.Top);
				graphicsPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
				graphicsPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Top + num3);
				break;
			}
			return graphicsPath;
		}

		/// <summary>
		///       创建一个菱形路径对象
		///       </summary>
		/// <param name="rect">菱形外切矩形</param>
		/// <returns>创建的路径对象</returns>
		public static GraphicsPath CreateDiamondPath(RectangleF rect)
		{
			float num = rect.Width / 2f;
			float num2 = rect.Height / 2f;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(rect.Left + num, rect.Top, rect.Right, rect.Top + num2);
			graphicsPath.AddLine(rect.Right, rect.Top + num2, rect.Left + num, rect.Bottom);
			graphicsPath.AddLine(rect.Left + num, rect.Bottom, rect.Left, rect.Top + num2);
			graphicsPath.AddLine(rect.Left, rect.Top + num2, rect.Left + num, rect.Top);
			return graphicsPath;
		}

		/// <summary>
		///       创建一个圆角矩形路径对象
		///       </summary>
		/// <param name="rect">矩形对象</param>
		/// <param name="radio">圆角半径,若小于等于0则表示矩形</param>
		/// <returns>创建的路径对象</returns>
		public static GraphicsPath CreateRoundRectanglePath(RectangleF rect, float radio)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (radio <= 0f)
			{
				graphicsPath.AddRectangle(rect);
				return graphicsPath;
			}
			graphicsPath.AddArc(rect.Left, rect.Top, radio, radio, 270f, -90f);
			graphicsPath.AddLine(rect.Left, rect.Top + radio / 2f, rect.Left, rect.Bottom - radio / 2f);
			graphicsPath.AddArc(rect.Left, rect.Bottom - radio, radio, radio, 180f, -90f);
			graphicsPath.AddLine(rect.Left + radio / 2f, rect.Bottom, rect.Right - radio / 2f, rect.Bottom);
			graphicsPath.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 90f, -90f);
			graphicsPath.AddLine(rect.Right, rect.Bottom - radio / 2f, rect.Right, rect.Top + radio / 2f);
			graphicsPath.AddArc(rect.Right - radio, rect.Top, radio, radio, 0f, -90f);
			graphicsPath.AddLine(rect.Right - radio / 2f, rect.Top, rect.Left + radio / 2f, rect.Top);
			graphicsPath.CloseAllFigures();
			return graphicsPath;
		}

		/// <summary>
		///       创建一个圆角矩形路径对象
		///       </summary>
		/// <param name="rect">矩形对象</param>
		/// <param name="radio">圆角半径,若小于等于0则表示矩形</param>
		/// <returns>创建的路径对象</returns>
		public static GraphicsPath CreateRoundRectanglePath(Rectangle rect, int radio)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (radio <= 0)
			{
				graphicsPath.AddRectangle(rect);
				return graphicsPath;
			}
			graphicsPath.AddArc(rect.Left, rect.Top, radio, radio, 270f, -90f);
			graphicsPath.AddLine(rect.Left, rect.Top + radio / 2, rect.Left, rect.Bottom - radio / 2);
			graphicsPath.AddArc(rect.Left, rect.Bottom - radio, radio, radio, 180f, -90f);
			graphicsPath.AddLine(rect.Left + radio / 2, rect.Bottom, rect.Right - radio / 2, rect.Bottom);
			graphicsPath.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 90f, -90f);
			graphicsPath.AddLine(rect.Right, rect.Bottom - radio / 2, rect.Right, rect.Top + radio / 2);
			graphicsPath.AddArc(rect.Right - radio, rect.Top, radio, radio, 0f, -90f);
			graphicsPath.AddLine(rect.Right - radio / 2, rect.Top, rect.Left + radio / 2, rect.Top);
			graphicsPath.CloseAllFigures();
			return graphicsPath;
		}
	}
}
