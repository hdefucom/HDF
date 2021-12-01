using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Windows32;
using XDesignerCommon;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class frmEditImage : Form
	{
		public enum ImageEditModeConst
		{
			Edit_None = 0,
			Edit_RandSelect = 1,
			Edit_RectSelect = 2,
			Edit_Rubber = 3,
			Edit_Fill = 4,
			Edit_ColorPick = 5,
			Edit_Zoom = 6,
			Edit_Pen = 7,
			Edit_Brush = 8,
			Edit_Fog = 9,
			Edit_Text = 10,
			Edit_Line = 11,
			Edit_Curve = 12,
			Edit_Rect = 13,
			Edit_Poly = 14,
			Edit_Arc = 0xF,
			Edit_RRect = 0x10,
			Edit_RectAndFill = 17,
			Edit_FillRect = 18,
			Edit_RRectAndFill = 19,
			Edit_Area = 25,
			Edit_Distance = 26,
			Edit_RGB = 27,
			Edit_ArrowLine = 28
		}

		public delegate bool DragPointHandler(Point p1, Point p2);

		private ImageEditControl pnlImage;

		private Panel pnlToolBar;

		private Splitter splitter1;

		private Container components = null;

		private Panel pnlColorList;

		private StatusBarPanel stpMain;

		private StatusBarPanel stpSize;

		private Panel pnlList;

		private ProgressBar myProgress;

		private PictureBox picToolbar;

		private Button button1;

		private StatusBar myStatus;

		private ZYButtonGroup myButtons = new ZYButtonGroup();

		private ZYColorSelector myColorSelector = new ZYColorSelector();

		private Bitmap myContentBMP = null;

		private Bitmap tempBMP = null;

		private bool bolCaptureMouse = false;

		private ArrayList myActions = new ArrayList();

		private PointBuffer myPointBuffer = new PointBuffer();

		private ImageAreaAction myAreaAction = new ImageAreaAction();

		private ImageDistanceAction myDisAction = new ImageDistanceAction();

		private Point LastMousePos = Point.Empty;

		private ImageEditAction myCurrentAction = null;

		private double dblXRate = 37.8;

		private double dblYRate = 37.8;

		private string strUnitString = "厘米";

		private int intLineWidth = 1;

		private Cursor myClientCursor = System.Windows.Forms.Cursors.Default;

		public double XRate
		{
			get
			{
				return dblXRate;
			}
			set
			{
				dblXRate = value;
			}
		}

		public double YRate
		{
			get
			{
				return dblYRate;
			}
			set
			{
				dblYRate = value;
			}
		}

		public string UnitString
		{
			get
			{
				return strUnitString;
			}
			set
			{
				strUnitString = value;
			}
		}

		public Bitmap ContentBMP
		{
			get
			{
				return myContentBMP;
			}
			set
			{
				myContentBMP = value;
				tempBMP = value;
				if (myContentBMP != null)
				{
					pnlImage.AutoScrollMinSize = new Size(myContentBMP.Size.Width + 20, myContentBMP.Size.Height + 20);
					stpMain.Text = string.Concat("格式:", myContentBMP.PixelFormat, " 宽度:", myContentBMP.Size.Width, " 高度:", myContentBMP.Size.Height);
				}
			}
		}

		public Bitmap EditedBMP
		{
			get
			{
				Bitmap bitmap = new Bitmap(myContentBMP);
				using (Graphics g = Graphics.FromImage(bitmap))
				{
					Rectangle clipRect = new Rectangle(0, 0, bitmap.Size.Width, bitmap.Size.Height);
					foreach (ImageEditAction myAction in myActions)
					{
						myAction.Execute(g, clipRect);
					}
				}
				return bitmap;
			}
		}

		public bool BMPChanged => myActions.Count > 0;

		public Rectangle ViewRect
		{
			get
			{
				if (myContentBMP != null)
				{
					return new Rectangle(pnlImage.AutoScrollPosition.X + 10, pnlImage.AutoScrollPosition.Y + 10, myContentBMP.Size.Width, myContentBMP.Size.Height);
				}
				return Rectangle.Empty;
			}
		}

		public frmEditImage()
		{
			InitializeComponent();
			InitClass();
		}

		protected override void Dispose(bool disposing)
		{
			myButtons.Dispose();
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(ZYTextDocumentLib.frmEditImage));
			pnlImage = new ZYTextDocumentLib.ImageEditControl();
			pnlToolBar = new System.Windows.Forms.Panel();
			pnlList = new System.Windows.Forms.Panel();
			myStatus = new System.Windows.Forms.StatusBar();
			stpMain = new System.Windows.Forms.StatusBarPanel();
			stpSize = new System.Windows.Forms.StatusBarPanel();
			splitter1 = new System.Windows.Forms.Splitter();
			pnlColorList = new System.Windows.Forms.Panel();
			myProgress = new System.Windows.Forms.ProgressBar();
			picToolbar = new System.Windows.Forms.PictureBox();
			button1 = new System.Windows.Forms.Button();
			pnlToolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)stpMain).BeginInit();
			((System.ComponentModel.ISupportInitialize)stpSize).BeginInit();
			SuspendLayout();
			pnlImage.AutoScroll = true;
			pnlImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
			pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlImage.Location = new System.Drawing.Point(149, 0);
			pnlImage.Name = "pnlImage";
			pnlImage.Size = new System.Drawing.Size(451, 391);
			pnlImage.TabIndex = 0;
			pnlImage.MouseUp += new System.Windows.Forms.MouseEventHandler(pnlImage_MouseUp);
			pnlImage.Paint += new System.Windows.Forms.PaintEventHandler(pnlImage_Paint);
			pnlImage.MouseMove += new System.Windows.Forms.MouseEventHandler(pnlImage_MouseMove);
			pnlImage.MouseDown += new System.Windows.Forms.MouseEventHandler(pnlImage_MouseDown);
			pnlToolBar.BackColor = System.Drawing.SystemColors.Control;
			pnlToolBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			pnlToolBar.Controls.Add(button1);
			pnlToolBar.Controls.Add(pnlList);
			pnlToolBar.Dock = System.Windows.Forms.DockStyle.Left;
			pnlToolBar.Location = new System.Drawing.Point(0, 0);
			pnlToolBar.Name = "pnlToolBar";
			pnlToolBar.Size = new System.Drawing.Size(144, 391);
			pnlToolBar.TabIndex = 1;
			pnlToolBar.Resize += new System.EventHandler(pnlToolBar_Resize);
			pnlList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			pnlList.Location = new System.Drawing.Point(32, 144);
			pnlList.Name = "pnlList";
			pnlList.Size = new System.Drawing.Size(56, 120);
			pnlList.TabIndex = 0;
			pnlList.Paint += new System.Windows.Forms.PaintEventHandler(pnlList_Paint);
			pnlList.MouseDown += new System.Windows.Forms.MouseEventHandler(pnlList_MouseDown);
			myStatus.Location = new System.Drawing.Point(0, 423);
			myStatus.Name = "myStatus";
			myStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[2]
			{
				stpMain,
				stpSize
			});
			myStatus.ShowPanels = true;
			myStatus.Size = new System.Drawing.Size(600, 22);
			myStatus.TabIndex = 2;
			stpMain.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			stpMain.Text = "就绪";
			stpMain.Width = 384;
			stpSize.Text = "大小";
			stpSize.Width = 200;
			splitter1.Location = new System.Drawing.Point(144, 0);
			splitter1.Name = "splitter1";
			splitter1.Size = new System.Drawing.Size(5, 391);
			splitter1.TabIndex = 3;
			splitter1.TabStop = false;
			pnlColorList.Dock = System.Windows.Forms.DockStyle.Bottom;
			pnlColorList.Location = new System.Drawing.Point(0, 391);
			pnlColorList.Name = "pnlColorList";
			pnlColorList.Size = new System.Drawing.Size(600, 32);
			pnlColorList.TabIndex = 4;
			myProgress.Location = new System.Drawing.Point(392, 424);
			myProgress.Name = "myProgress";
			myProgress.Size = new System.Drawing.Size(192, 16);
			myProgress.TabIndex = 0;
			myProgress.Visible = false;
			picToolbar.Image = (System.Drawing.Image)resourceManager.GetObject("picToolbar.Image");
			picToolbar.Location = new System.Drawing.Point(96, 416);
			picToolbar.Name = "picToolbar";
			picToolbar.Size = new System.Drawing.Size(464, 16);
			picToolbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			picToolbar.TabIndex = 5;
			picToolbar.TabStop = false;
			picToolbar.Visible = false;
			button1.Location = new System.Drawing.Point(40, 304);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(48, 24);
			button1.TabIndex = 1;
			button1.Text = "撤销";
			button1.Click += new System.EventHandler(button1_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(600, 445);
			base.Controls.Add(picToolbar);
			base.Controls.Add(myProgress);
			base.Controls.Add(pnlImage);
			base.Controls.Add(splitter1);
			base.Controls.Add(pnlToolBar);
			base.Controls.Add(pnlColorList);
			base.Controls.Add(myStatus);
			base.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.Name = "frmEditImage";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "图像编辑";
			base.Load += new System.EventHandler(frmEditImage_Load);
			pnlToolBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)stpMain).EndInit();
			((System.ComponentModel.ISupportInitialize)stpSize).EndInit();
			ResumeLayout(false);
		}

		public void InitClass()
		{
			myButtons.BindControl(pnlToolBar);
			myButtons.DefaultButtonHeight = 25;
			myButtons.DefaultButtonWidth = 25;
			myButtons.OnClick += myButtons_OnClick;
			Bitmap bitmap = (Bitmap)picToolbar.Image;
			bitmap.MakeTransparent(Color.Red);
			myButtons.SetButtonImage(bitmap, 16, 16);
			for (int i = 0; i < 29; i++)
			{
				ZYButtonGroup.ZYButton zYButton = myButtons.AddButton(i, i);
				zYButton.Visible = (i == 0 || i == 7 || i == 25 || i == 5 || i == 26 || i == 18 || i == 11 || i == 14 || i == 13 || i == 17 || i == 10 || i == 28 || i == 6);
			}
			myButtons.ClientRect = pnlToolBar.ClientRectangle;
			myButtons.RefreshSize();
			myButtons.CommandID = 0;
			myColorSelector.BindControl(pnlColorList);
		}

		public bool LoadBMPFile(string strSrc)
		{
			ContentBMP = (Bitmap)Image.FromFile(strSrc);
			return true;
		}

		private void pnlToolBar_Resize(object sender, EventArgs e)
		{
			myButtons.ClientRect = pnlToolBar.ClientRectangle;
			myButtons.Top = 10;
			myButtons.RefreshSize();
			myButtons.Left = (pnlToolBar.ClientSize.Width - myButtons.PerformWidth) / 2;
			pnlList.Top = myButtons.Top + myButtons.PerformHeight + 5;
			pnlList.Left = (pnlToolBar.ClientSize.Width - pnlList.Width) / 2;
			pnlToolBar.Refresh();
		}

		private void pnlImage_Paint(object sender, PaintEventArgs e)
		{
			if (myContentBMP == null)
			{
				return;
			}
			Rectangle destRect = Rectangle.Intersect(e.ClipRectangle, ViewRect);
			Graphics graphics = e.Graphics;
			Point point = ViewPointToClient(0, 0);
			graphics.SetClip(ViewRect);
			if (!destRect.IsEmpty)
			{
				graphics.DrawImage(myContentBMP, destRect, new Rectangle(PointToView(destRect.Location), destRect.Size), GraphicsUnit.Pixel);
				Rectangle clipRectangle = e.ClipRectangle;
				clipRectangle.Location = PointToView(clipRectangle.Location);
				graphics.TranslateTransform(ViewRect.Left, ViewRect.Top);
				foreach (ImageEditAction myAction in myActions)
				{
					if (myAction.Bounds.IntersectsWith(clipRectangle))
					{
						myAction.Execute(graphics, clipRectangle);
					}
				}
				if (myButtons.CommandID == 25)
				{
					Point point2 = ViewPointToClient(0, 0);
					myAreaAction.DrawFix = ViewRect.Location;
					myAreaAction.Execute(graphics, clipRectangle);
				}
				else if (myButtons.CommandID == 26)
				{
					myDisAction.XRate = dblXRate;
					myDisAction.YRate = dblYRate;
					myDisAction.DrawFix = ViewRect.Location;
					myDisAction.Execute(graphics, clipRectangle);
				}
				else if (myPointBuffer.Count > 1)
				{
					using (Pen pen = CreateCurrentPen())
					{
						graphics.DrawLines(pen, myPointBuffer.ToPointArray());
					}
				}
				if (myCurrentAction != null)
				{
					graphics.DrawRectangle(Pens.Black, myCurrentAction.Bounds);
					Rectangle[] dragRects = myCurrentAction.GetDragRects();
					graphics.FillRectangles(Brushes.DarkBlue, dragRects);
					graphics.DrawRectangles(Pens.White, dragRects);
				}
			}
			graphics.ResetClip();
			graphics.ResetTransform();
			destRect = ViewRect;
			graphics.DrawRectangle(Pens.Black, destRect);
			Rectangle[] dragRects2 = DocumentView.GetDragRects(destRect, 4, InnerDragRect: false);
			for (int i = 0; i < dragRects2.Length; i++)
			{
				DocumentView.DrawDragRect(graphics, dragRects2[i], i == 3 || i == 4 || i == 5);
			}
		}

		private void pnlImage_MouseDown(object sender, MouseEventArgs e)
		{
			Point pt = new Point(e.X, e.Y);
			Point mousePosition = Control.MousePosition;
			Point empty = Point.Empty;
			int num;
			if (ViewRect.Contains(pt))
			{
				switch (myButtons.CommandID)
				{
				case 0:
				{
					mousePosition = PointToView(e.X, e.Y);
					bool flag = false;
					for (num = myActions.Count - 1; num >= 0; num--)
					{
						ImageEditAction imageEditAction = (ImageEditAction)myActions[num];
						if (imageEditAction.Selectable && imageEditAction.Bounds.Contains(mousePosition))
						{
							flag = true;
							if (myCurrentAction != imageEditAction)
							{
								myCurrentAction = imageEditAction;
								pnlImage.Refresh();
							}
							break;
						}
					}
					if (!flag && myCurrentAction != null)
					{
						myCurrentAction = null;
						pnlImage.Refresh();
					}
					if (myCurrentAction != null && myCurrentAction.Bounds.Contains(mousePosition))
					{
						Rectangle[] dragRects = myCurrentAction.GetDragRects();
						Rectangle rectangle = myCurrentAction.Bounds;
						rectangle.Location = ViewPointToScreen(rectangle.Location);
						bool flag2 = false;
						for (num = 0; num < dragRects.Length; num++)
						{
							if (dragRects[num].Contains(mousePosition))
							{
								rectangle = CaptureDragRect(rectangle, num, DrawFocusRect: true, 0.0, ShowSizeInfo: true, null);
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							rectangle = CaptureDragRect(rectangle, -1, DrawFocusRect: true, 0.0, ShowSizeInfo: true, null);
							flag2 = true;
						}
						if (flag2 && !rectangle.IsEmpty)
						{
							rectangle.Location = ScreenPointToView(rectangle.Location);
							myCurrentAction.DesignChangeBounds(rectangle);
							pnlImage.Refresh();
						}
						bolCaptureMouse = false;
					}
					else
					{
						bolCaptureMouse = true;
						LastMousePos = new Point(e.X, e.Y);
					}
					break;
				}
				case 5:
					myColorSelector.CurrentColor = pnlList.BackColor;
					pnlList.BackColor = BackColor;
					myButtons.CommandID = 0;
					break;
				case 11:
					empty = CaptureDragPoint(mousePosition, 17, null);
					if (!mousePosition.Equals(empty))
					{
						ImageLineAction imageLineAction = new ImageLineAction();
						imageLineAction.p1 = ScreenPointToView(mousePosition);
						imageLineAction.p2 = ScreenPointToView(empty);
						imageLineAction.Color = myColorSelector.ForeColor;
						imageLineAction.Width = intLineWidth;
						myActions.Add(imageLineAction);
						pnlImage.Refresh();
					}
					bolCaptureMouse = false;
					break;
				case 28:
					empty = CaptureDragPoint(mousePosition, 17, null);
					if (!mousePosition.Equals(empty))
					{
						ImageLineAction imageLineAction = new ImageLineAction();
						imageLineAction.p1 = ScreenPointToView(mousePosition);
						imageLineAction.p2 = ScreenPointToView(empty);
						imageLineAction.Color = myColorSelector.ForeColor;
						imageLineAction.Width = intLineWidth;
						imageLineAction.Arrow = true;
						myActions.Add(imageLineAction);
						pnlImage.Refresh();
					}
					bolCaptureMouse = false;
					break;
				case 13:
					empty = CaptureDragPoint(mousePosition, 2, null);
					if (!mousePosition.Equals(empty))
					{
						ImageRectAction imageRectAction = new ImageRectAction();
						imageRectAction.Bounds = ScreenPointToViewRect(mousePosition, empty);
						imageRectAction.BorderColor = myColorSelector.ForeColor;
						imageRectAction.BorderWidth = intLineWidth;
						myActions.Add(imageRectAction);
						pnlImage.Refresh();
					}
					bolCaptureMouse = false;
					break;
				case 18:
					empty = CaptureDragPoint(mousePosition, 3, null);
					if (!mousePosition.Equals(empty))
					{
						ImageFillRectAction imageFillRectAction = new ImageFillRectAction();
						imageFillRectAction.Bounds = ScreenPointToViewRect(mousePosition, empty);
						imageFillRectAction.FillColor = myColorSelector.BackColor;
						myActions.Add(imageFillRectAction);
						pnlImage.Refresh();
					}
					break;
				case 7:
					bolCaptureMouse = true;
					break;
				case 17:
					empty = CaptureDragPoint(mousePosition, 3, null);
					if (!mousePosition.Equals(empty))
					{
						ImageRectAndFillAction imageRectAndFillAction = new ImageRectAndFillAction();
						imageRectAndFillAction.Bounds = ScreenPointToViewRect(mousePosition, empty);
						imageRectAndFillAction.FillColor = myColorSelector.BackColor;
						imageRectAndFillAction.BorderColor = myColorSelector.ForeColor;
						imageRectAndFillAction.BorderWidth = intLineWidth;
						myActions.Add(imageRectAndFillAction);
						pnlImage.Refresh();
					}
					bolCaptureMouse = false;
					break;
				case 14:
					myPointBuffer.Add(ScreenPointToView(mousePosition));
					pnlImage.Refresh();
					break;
				case 25:
					myPointBuffer.Clear();
					myAreaAction.Points = null;
					bolCaptureMouse = true;
					pnlImage.Refresh();
					break;
				case 26:
					empty = CaptureDragPoint(mousePosition, 16, CalcutePointDistance);
					pnlImage.Refresh();
					break;
				case 10:
					empty = CaptureDragPoint(mousePosition, 2, null);
					if (!mousePosition.Equals(empty))
					{
						using (dlgInputFormatText dlgInputFormatText = new dlgInputFormatText())
						{
							if (dlgInputFormatText.ShowDialog(this) == DialogResult.OK && StringCommon.HasContent(dlgInputFormatText.InputText))
							{
								ImageTextAction imageTextAction = new ImageTextAction();
								imageTextAction.Bounds = ScreenPointToViewRect(mousePosition, empty);
								imageTextAction.ForeColor = myColorSelector.ForeColor;
								imageTextAction.Text = dlgInputFormatText.InputText;
								imageTextAction.FontName = dlgInputFormatText.InputFontName;
								imageTextAction.FontSize = dlgInputFormatText.InputFontSize;
								imageTextAction.Bold = dlgInputFormatText.InputFontBold;
								imageTextAction.Italic = dlgInputFormatText.InputFontItalic;
								myActions.Add(imageTextAction);
								pnlImage.Refresh();
							}
						}
					}
					myButtons.CommandID = 0;
					bolCaptureMouse = false;
					break;
				}
				return;
			}
			Rectangle[] dragRects2 = DocumentView.GetDragRects(ViewRect, 4, InnerDragRect: false);
			num = 0;
			while (true)
			{
				if (num < dragRects2.Length)
				{
					if (dragRects2[num].Contains(pt) && (num == 3 || num == 4 || num == 5))
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			Rectangle viewRect = ViewRect;
			viewRect.Location = ViewPointToScreen(0, 0);
			viewRect = CaptureDragRect(viewRect, num, DrawFocusRect: true, 0.0, ShowSizeInfo: true, null);
		}

		private void pnlImage_MouseMove(object sender, MouseEventArgs e)
		{
			Point p;
			if (bolCaptureMouse)
			{
				p = PointToView(e.X, e.Y);
				switch (myButtons.CommandID)
				{
				case 0:
					if (pnlImage.AutoScrollMinSize.Width > pnlImage.ClientSize.Width || pnlImage.AutoScrollMinSize.Height > pnlImage.ClientSize.Height)
					{
						Point autoScrollPosition = pnlImage.AutoScrollPosition;
						autoScrollPosition.X = -autoScrollPosition.X;
						autoScrollPosition.Y = -autoScrollPosition.Y;
						autoScrollPosition.Offset(LastMousePos.X - e.X, LastMousePos.Y - e.Y);
						pnlImage.AutoScrollPosition = autoScrollPosition;
						LastMousePos = new Point(e.X, e.Y);
					}
					break;
				case 25:
				{
					using (Graphics graphics = pnlImage.CreateGraphics())
					{
						myAreaAction.DrawFix = ViewRect.Location;
						myAreaAction.Execute(graphics, ViewRect);
						myPointBuffer.Add(p);
						myAreaAction.Points = myPointBuffer.ToClosedPointArray();
						myAreaAction.Execute(graphics, ViewRect);
					}
					stpMain.Text = "当前选中区域的面积:" + myAreaAction.ContainArea.ToString("0.00") + "平方" + strUnitString;
					break;
				}
				case 7:
					if (myPointBuffer.Count > 0)
					{
						using (Graphics graphics = pnlImage.CreateGraphics())
						{
							using (Pen pen = CreateCurrentPen())
							{
								graphics.DrawLine(pen, ViewPointToClient(myPointBuffer.LastPoint), ViewPointToClient(p));
							}
						}
					}
					myPointBuffer.Add(p);
					break;
				}
				return;
			}
			p = new Point(e.X, e.Y);
			if (ViewRect.Contains(p))
			{
				pnlImage.Cursor = myClientCursor;
				p = PointToView(p);
				bool flag = false;
				stpSize.Text = "X:" + p.X + " Y:" + p.Y;
				switch (myButtons.CommandID)
				{
				case 0:
				{
					if (myCurrentAction == null || !myCurrentAction.Bounds.Contains(p))
					{
						break;
					}
					Rectangle[] dragRects = myCurrentAction.GetDragRects();
					for (int i = 0; i < dragRects.Length; i++)
					{
						if (dragRects[i].Contains(p))
						{
							pnlImage.Cursor = DocumentView.GetDragRectCursor(i);
						}
					}
					break;
				}
				case 5:
				{
					Color pixel = myContentBMP.GetPixel(p.X, p.Y);
					pnlList.BackColor = pixel;
					stpSize.Text = "X:" + p.X + " Y:" + p.Y + "  " + StringCommon.ColorToHtml(pixel);
					flag = true;
					break;
				}
				}
				if (!flag)
				{
					stpSize.Text = "X:" + p.X + " Y:" + p.Y;
				}
				return;
			}
			stpSize.Text = "";
			Rectangle[] dragRects2 = DocumentView.GetDragRects(ViewRect, 4, InnerDragRect: false);
			bool flag2 = false;
			for (int i = 0; i < dragRects2.Length; i++)
			{
				if (dragRects2[i].Contains(p) && (i == 3 || i == 4 || i == 5))
				{
					pnlImage.Cursor = DocumentView.GetDragRectCursor(i);
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				pnlImage.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void pnlImage_MouseUp(object sender, MouseEventArgs e)
		{
			if (bolCaptureMouse)
			{
				if (myButtons.CommandID == 7)
				{
					if (myPointBuffer.Count > 0)
					{
						ImagePenAction imagePenAction = new ImagePenAction();
						imagePenAction.Points = myPointBuffer.ToPointArray();
						imagePenAction.ForeColor = myColorSelector.ForeColor;
						imagePenAction.LineWidth = intLineWidth;
						myActions.Add(imagePenAction);
						myPointBuffer.Clear();
						pnlImage.Refresh();
					}
				}
				else if (myButtons.CommandID != 25)
				{
				}
			}
			bolCaptureMouse = false;
		}

		private void InitProgress()
		{
			myProgress.Bounds = new Rectangle(stpMain.Width + 2, myStatus.Top + 2, stpSize.Width - 2, myStatus.Height - 2);
			myProgress.Visible = true;
		}

		private void SetProgress(int Completed, int vTotal)
		{
			if (vTotal != myProgress.Maximum)
			{
				myProgress.Maximum = vTotal;
			}
			myProgress.Value = Completed;
		}

		private void myButtons_OnClick(ZYButtonGroup ButtonGroup, ZYButtonGroup.ZYButton Button)
		{
			switch (myButtons.LastCommandID)
			{
			case 5:
				pnlList.BackColor = BackColor;
				break;
			case 14:
				if (myPointBuffer.Count > 1)
				{
					ImagePolyAction imagePolyAction = new ImagePolyAction();
					imagePolyAction.Points = myPointBuffer.ToClosedPointArray();
					myPointBuffer.Clear();
					imagePolyAction.LineWidth = intLineWidth;
					imagePolyAction.ForeColor = myColorSelector.ForeColor;
					myActions.Add(imagePolyAction);
					pnlImage.Refresh();
				}
				break;
			case 25:
				if (myButtons.CommandID == 27)
				{
					stpMain.Text = "正在计算RGB平均值...";
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					InitProgress();
					pnlToolBar.Refresh();
					Color color = myAreaAction.CalcuteAvgColor(myContentBMP, SetProgress);
					myProgress.Visible = false;
					stpMain.Text = string.Format("当前选中区域的面积:{0:0.00}平方" + strUnitString + " RGB平均值 R:{1} G:{2} B:{3}", myAreaAction.CalcuteArea(), color.R, color.G, color.B);
					Cursor = System.Windows.Forms.Cursors.Default;
					myButtons.CommandID = 25;
				}
				else
				{
					myPointBuffer.Clear();
					myAreaAction.Points = null;
					pnlImage.Refresh();
				}
				break;
			case 26:
				myDisAction.Clear();
				pnlImage.Refresh();
				break;
			}
			myColorSelector.ShowBackColor = true;
			myColorSelector.ShowForeColor = true;
			switch (Button.CommandID)
			{
			case 0:
				SetClientCursor(System.Windows.Forms.Cursors.Default);
				break;
			case 5:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				break;
			case 12:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myColorSelector.ShowBackColor = false;
				break;
			case 11:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myColorSelector.ShowBackColor = false;
				break;
			case 13:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myColorSelector.ShowBackColor = false;
				break;
			case 4:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myColorSelector.ShowForeColor = false;
				break;
			case 18:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myColorSelector.ShowForeColor = false;
				break;
			case 17:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				break;
			case 7:
				SetClientCursor(System.Windows.Forms.Cursors.Arrow);
				myColorSelector.ShowBackColor = false;
				break;
			case 14:
				myPointBuffer.Clear();
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myColorSelector.ShowBackColor = false;
				break;
			case 25:
				myPointBuffer.Clear();
				myAreaAction.XRate = dblXRate;
				myAreaAction.YRate = dblYRate;
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				break;
			case 26:
				myPointBuffer.Clear();
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				myDisAction.Clear();
				break;
			case 10:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				break;
			case 28:
				SetClientCursor(System.Windows.Forms.Cursors.Cross);
				break;
			case 27:
				if (myButtons.LastCommandID != 25)
				{
					MessageBox.Show(this, "请首先执行计算面积的操作!", "系统提示");
				}
				break;
			}
			pnlList.Refresh();
		}

		public void SetClientCursor(Cursor c)
		{
			myClientCursor = c;
			UpdateClientCursor();
		}

		private void UpdateClientCursor()
		{
			if (ViewRect.Contains(pnlImage.PointToClient(Control.MousePosition)))
			{
				pnlImage.Cursor = myClientCursor;
			}
		}

		public Rectangle ScreenPointToViewRect(Point p1, Point p2)
		{
			Rectangle rectangle = RectangleObject.GetRectangle(p1, p2);
			rectangle.Location = ScreenPointToView(rectangle.Location);
			return rectangle;
		}

		public Point ViewPointToClient(Point p)
		{
			return new Point(p.X + pnlImage.AutoScrollPosition.X + 10, p.Y + pnlImage.AutoScrollPosition.Y + 10);
		}

		public Point ViewPointToClient(int x, int y)
		{
			return new Point(x + pnlImage.AutoScrollPosition.X + 10, y + pnlImage.AutoScrollPosition.Y + 10);
		}

		public Point PointToView(Point p)
		{
			return new Point(p.X - pnlImage.AutoScrollPosition.X - 10, p.Y - pnlImage.AutoScrollPosition.Y - 10);
		}

		public Point PointToView(int x, int y)
		{
			return new Point(x - pnlImage.AutoScrollPosition.X - 10, y - pnlImage.AutoScrollPosition.Y - 10);
		}

		public Point ViewPointToScreen(int x, int y)
		{
			Point p = ViewPointToClient(x, y);
			return pnlImage.PointToScreen(p);
		}

		public Point ViewPointToScreen(Point p)
		{
			p = ViewPointToClient(p);
			return pnlImage.PointToScreen(p);
		}

		public Point ScreenPointToView(Point p)
		{
			return PointToView(pnlImage.PointToClient(p));
		}

		public Point ScreenPointToView(int x, int y)
		{
			return PointToView(pnlImage.PointToClient(new Point(x, y)));
		}

		private Pen CreateCurrentPen()
		{
			return new Pen(myColorSelector.ForeColor, intLineWidth);
		}

		private bool IsListLineWidth()
		{
			return myButtons.CommandID == 7 || myButtons.CommandID == 11 || myButtons.CommandID == 14 || myButtons.CommandID == 13 || myButtons.CommandID == 12 || myButtons.CommandID == 15 || myButtons.CommandID == 16 || myButtons.CommandID == 17 || myButtons.CommandID == 19 || myButtons.CommandID == 28;
		}

		private void pnlList_Paint(object sender, PaintEventArgs e)
		{
			if (!IsListLineWidth())
			{
				return;
			}
			Rectangle rect = new Rectangle(3, 2, pnlList.ClientSize.Width - 6, 14);
			for (int i = 1; i < 9; i++)
			{
				if (i == intLineWidth)
				{
					e.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
					using (Pen pen = new Pen(SystemColors.HighlightText, i))
					{
						e.Graphics.DrawLine(pen, rect.Left + 2, rect.Top + 7, rect.Right - 5, rect.Top + 7);
					}
				}
				else
				{
					using (Pen pen = new Pen(Color.Black, i))
					{
						e.Graphics.DrawLine(pen, rect.Left + 2, rect.Top + 7, rect.Right - 5, rect.Top + 7);
					}
				}
				rect.Y = rect.Bottom;
			}
		}

		private void pnlList_MouseDown(object sender, MouseEventArgs e)
		{
			if (IsListLineWidth())
			{
				int num = 1 + (int)Math.Floor((double)(e.Y - 2) / 14.0);
				if (num >= 1 && num < 9)
				{
					intLineWidth = num;
					pnlList.Refresh();
				}
			}
		}

		private void frmEditImage_Load(object sender, EventArgs e)
		{
			pnlToolBar_Resize(null, null);
		}

		private bool CalcutePointDistance(Point p1, Point p2)
		{
			myDisAction.DrawFix = ViewRect.Location;
			myDisAction.XRate = dblXRate;
			myDisAction.YRate = dblYRate;
			using (Graphics g = pnlImage.CreateGraphics())
			{
				myDisAction.Execute(g, ViewRect);
				myDisAction.p1 = ScreenPointToView(p1);
				myDisAction.p2 = ScreenPointToView(p2);
				myDisAction.Execute(g, ViewRect);
			}
			stpMain.Text = "距离: " + myDisAction.Distance.ToString("0.00") + strUnitString;
			return true;
		}

		public static Point CaptureDragPoint(Point SourcePoint, int DrawStyle, DragPointHandler CallBack)
		{
			MSG msg = default(MSG);
			Point point = SourcePoint;
			Point point2 = SourcePoint;
			Point point3 = Control.MousePosition;
			bool flag = false;
			Rectangle empty = Rectangle.Empty;
			while (User32.WaitMessage() && User32.PeekMessage(ref msg, 0, 0u, 0u, 0u) && !User32.isMouseUpMessage(msg.message))
			{
				if (User32.isMouseMoveMessage(msg.message))
				{
					Point mousePosition = Control.MousePosition;
					if (!point3.Equals(mousePosition))
					{
						if (MathCommon.GetIntAttribute(DrawStyle, 16) && MathCommon.GetIntAttribute((int)Control.ModifierKeys, 65536) && SourcePoint.X != mousePosition.X && SourcePoint.Y != mousePosition.Y)
						{
							double num = MathCommon.Angle(SourcePoint.X, SourcePoint.Y, mousePosition.X, mousePosition.Y);
							int num2 = (int)Math.Round(num / 45.0) % 8;
							if (num2 == 0 || num2 == 4)
							{
								mousePosition.Y = 0;
							}
							if (num2 == 2 || num2 == 6)
							{
								mousePosition.Y -= SourcePoint.Y;
								mousePosition.X = SourcePoint.X;
							}
							if (num2 == 3 || num2 == 7)
							{
								mousePosition.Y = SourcePoint.X - mousePosition.X;
							}
							if (num2 == 5 || num2 == 1)
							{
								mousePosition.Y = mousePosition.X - SourcePoint.X;
							}
							mousePosition.Y += SourcePoint.Y;
						}
						if (flag)
						{
							switch (DrawStyle & 0xF)
							{
							case 1:
								ControlPaint.DrawReversibleLine(SourcePoint, point, Color.Black);
								flag = false;
								break;
							case 2:
								empty = RectangleObject.GetRectangle(SourcePoint, point);
								ControlPaint.DrawReversibleFrame(empty, Color.SkyBlue, FrameStyle.Dashed);
								flag = false;
								break;
							case 3:
								empty = RectangleObject.GetRectangle(SourcePoint, point);
								ControlPaint.FillReversibleRectangle(empty, Color.Black);
								flag = false;
								break;
							}
						}
						point = mousePosition;
						point3 = mousePosition;
						if (CallBack != null && !CallBack(SourcePoint, point))
						{
							if (flag)
							{
							}
							return Point.Empty;
						}
						if (!point.Equals(SourcePoint))
						{
							switch (DrawStyle & 0xF)
							{
							case 1:
								ControlPaint.DrawReversibleLine(SourcePoint, point, Color.Black);
								flag = true;
								break;
							case 2:
								empty = RectangleObject.GetRectangle(SourcePoint, point);
								ControlPaint.DrawReversibleFrame(empty, Color.SkyBlue, FrameStyle.Dashed);
								flag = true;
								break;
							case 3:
								empty = RectangleObject.GetRectangle(SourcePoint, point);
								ControlPaint.FillReversibleRectangle(empty, Color.Black);
								flag = true;
								break;
							}
						}
					}
				}
				User32.GetMessage(ref msg, 0, 0u, 0u);
			}
			if (flag)
			{
				switch (DrawStyle & 0xF)
				{
				case 1:
					ControlPaint.DrawReversibleLine(SourcePoint, point, Color.Black);
					flag = true;
					break;
				case 2:
					empty = RectangleObject.GetRectangle(SourcePoint, point);
					ControlPaint.DrawReversibleFrame(empty, Color.SkyBlue, FrameStyle.Dashed);
					flag = true;
					break;
				case 3:
					empty = RectangleObject.GetRectangle(SourcePoint, point);
					ControlPaint.FillReversibleRectangle(empty, Color.Black);
					flag = true;
					break;
				}
			}
			return point;
		}

		public Rectangle CaptureDragRect(Rectangle SourceRect, int DragStyle, bool DrawFocusRect, double WidthHeightRate, bool ShowSizeInfo, CaptureDragRectangleHandler CallBack)
		{
			MSG msg = default(MSG);
			Point point = Control.MousePosition;
			Rectangle CurrentRect = SourceRect;
			Rectangle rectangle = Rectangle.Empty;
			if (ShowSizeInfo)
			{
				Point empty = Point.Empty;
				stpSize.Text = "鼠标拖拽开始改变对象大小";
			}
			while (User32.WaitMessage() && User32.PeekMessage(ref msg, 0, 0u, 0u, 0u) && !User32.isMouseUpMessage(msg.message))
			{
				if (User32.isMouseMoveMessage(msg.message))
				{
					Point mousePosition = Control.MousePosition;
					if (!point.Equals(mousePosition))
					{
						int num = mousePosition.X - point.X;
						int num2 = mousePosition.Y - point.Y;
						point = mousePosition;
						Point location = CurrentRect.Location;
						if (DragStyle == -1)
						{
							CurrentRect.Offset(num, num2);
						}
						if (DragStyle == 0 || DragStyle == 7 || DragStyle == 6)
						{
							CurrentRect.Offset(num, 0);
							CurrentRect.Width -= num;
						}
						if (DragStyle == 0 || DragStyle == 1 || DragStyle == 2)
						{
							CurrentRect.Offset(0, num2);
							CurrentRect.Height -= num2;
						}
						if (DragStyle == 2 || DragStyle == 3 || DragStyle == 4)
						{
							CurrentRect.Width += num;
						}
						if (DragStyle == 4 || DragStyle == 5 || DragStyle == 6)
						{
							CurrentRect.Height += num2;
						}
						if (CallBack != null && !CallBack(SourceRect, ref CurrentRect, DragStyle))
						{
							if (!rectangle.IsEmpty)
							{
								ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Dashed);
							}
							bolCaptureMouse = false;
							return Rectangle.Empty;
						}
						if (WidthHeightRate >= 0.1)
						{
							if (DragStyle == 1 || DragStyle == 5)
							{
								CurrentRect.Width = (int)((double)CurrentRect.Height * WidthHeightRate);
							}
							else
							{
								int top = CurrentRect.Top;
								int bottom = CurrentRect.Bottom;
								CurrentRect.Height = (int)((double)CurrentRect.Width / WidthHeightRate);
								if (DragStyle == 6 || DragStyle == 4)
								{
									CurrentRect.Y = top;
								}
								else
								{
									CurrentRect.Y = bottom - CurrentRect.Height;
								}
							}
						}
						if (DrawFocusRect)
						{
							if (!rectangle.IsEmpty)
							{
								ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Dashed);
							}
							rectangle.Offset(CurrentRect.X - location.X, CurrentRect.Y - location.Y);
							rectangle.Size = CurrentRect.Size;
							rectangle = CurrentRect;
							if (ShowSizeInfo)
							{
								stpSize.Text = "宽度:" + CurrentRect.Width + " 高度:" + CurrentRect.Height;
							}
							ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Dashed);
						}
					}
				}
				User32.GetMessage(ref msg, 0, 0u, 0u);
			}
			if (!rectangle.IsEmpty)
			{
				ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Dashed);
			}
			bolCaptureMouse = false;
			if (CurrentRect.Equals(SourceRect))
			{
				return Rectangle.Empty;
			}
			return CurrentRect;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (myActions.Count > 0)
			{
				myActions.RemoveAt(myActions.Count - 1);
				pnlImage.Refresh();
			}
		}
	}
}
