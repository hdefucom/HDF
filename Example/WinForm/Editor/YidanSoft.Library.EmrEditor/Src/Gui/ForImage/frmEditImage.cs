using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using XDesignerCommon ;
using ZYCommon;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace ZYTextDocumentLib
{
	
	/// <summary>
	/// 简单图像编辑器窗口
	/// </summary>
	public class frmEditImage : System.Windows.Forms.Form
	{
		private ImageEditControl   pnlImage;
		private System.Windows.Forms.Panel pnlToolBar;
		private System.Windows.Forms.Splitter splitter1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel pnlColorList;
		private System.Windows.Forms.StatusBarPanel stpMain;
		private System.Windows.Forms.StatusBarPanel stpSize;
		private System.Windows.Forms.Panel pnlList;
		private System.Windows.Forms.ProgressBar myProgress;
		private System.Windows.Forms.PictureBox picToolbar;
		private System.Windows.Forms.StatusBar myStatus;

		public frmEditImage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			InitClass();
		}



		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			myButtons.Dispose();
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEditImage));
			this.pnlImage = new ZYTextDocumentLib.ImageEditControl();
			this.pnlToolBar = new System.Windows.Forms.Panel();
			this.pnlList = new System.Windows.Forms.Panel();
			this.myStatus = new System.Windows.Forms.StatusBar();
			this.stpMain = new System.Windows.Forms.StatusBarPanel();
			this.stpSize = new System.Windows.Forms.StatusBarPanel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlColorList = new System.Windows.Forms.Panel();
			this.myProgress = new System.Windows.Forms.ProgressBar();
			this.picToolbar = new System.Windows.Forms.PictureBox();
			this.pnlToolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stpMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stpSize)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlImage
			// 
			this.pnlImage.AutoScroll = true;
			this.pnlImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlImage.Location = new System.Drawing.Point(149, 0);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.Size = new System.Drawing.Size(451, 391);
			this.pnlImage.TabIndex = 0;
			this.pnlImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseUp);
			this.pnlImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImage_Paint);
			this.pnlImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseMove);
			this.pnlImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseDown);
			// 
			// pnlToolBar
			// 
			this.pnlToolBar.BackColor = System.Drawing.SystemColors.Control;
			this.pnlToolBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlToolBar.Controls.Add(this.pnlList);
			this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
			this.pnlToolBar.Name = "pnlToolBar";
			this.pnlToolBar.Size = new System.Drawing.Size(144, 391);
			this.pnlToolBar.TabIndex = 1;
			this.pnlToolBar.Resize += new System.EventHandler(this.pnlToolBar_Resize);
			// 
			// pnlList
			// 
			this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlList.Location = new System.Drawing.Point(32, 144);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(56, 120);
			this.pnlList.TabIndex = 0;
			this.pnlList.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlList_Paint);
			this.pnlList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlList_MouseDown);
			// 
			// myStatus
			// 
			this.myStatus.Location = new System.Drawing.Point(0, 423);
			this.myStatus.Name = "myStatus";
			this.myStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						this.stpMain,
																						this.stpSize});
			this.myStatus.ShowPanels = true;
			this.myStatus.Size = new System.Drawing.Size(600, 22);
			this.myStatus.TabIndex = 2;
			// 
			// stpMain
			// 
			this.stpMain.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.stpMain.Text = "就绪";
			this.stpMain.Width = 384;
			// 
			// stpSize
			// 
			this.stpSize.Text = "大小";
			this.stpSize.Width = 200;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(144, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 391);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// pnlColorList
			// 
			this.pnlColorList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlColorList.Location = new System.Drawing.Point(0, 391);
			this.pnlColorList.Name = "pnlColorList";
			this.pnlColorList.Size = new System.Drawing.Size(600, 32);
			this.pnlColorList.TabIndex = 4;
			// 
			// myProgress
			// 
			this.myProgress.Location = new System.Drawing.Point(392, 424);
			this.myProgress.Name = "myProgress";
			this.myProgress.Size = new System.Drawing.Size(192, 16);
			this.myProgress.TabIndex = 0;
			this.myProgress.Visible = false;
			// 
			// picToolbar
			// 
			this.picToolbar.Image = ((System.Drawing.Image)(resources.GetObject("picToolbar.Image")));
			this.picToolbar.Location = new System.Drawing.Point(96, 416);
			this.picToolbar.Name = "picToolbar";
			this.picToolbar.Size = new System.Drawing.Size(464, 16);
			this.picToolbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picToolbar.TabIndex = 5;
			this.picToolbar.TabStop = false;
			this.picToolbar.Visible = false;
			// 
			// frmEditImage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(600, 445);
			this.Controls.Add(this.picToolbar);
			this.Controls.Add(this.myProgress);
			this.Controls.Add(this.pnlImage);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlToolBar);
			this.Controls.Add(this.pnlColorList);
			this.Controls.Add(this.myStatus);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEditImage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "图像编辑";
			this.Load += new System.EventHandler(this.frmEditImage_Load);
			this.pnlToolBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stpMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stpSize)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 按钮组对象
		/// </summary>
		private ZYButtonGroup		myButtons = new ZYButtonGroup();
		/// <summary>
		/// 颜色选择对象
		/// </summary>
		private ZYColorSelector		myColorSelector = new ZYColorSelector();
		/// <summary>
		/// 编辑的BMP图片内容
		/// </summary>
		private System.Drawing.Bitmap myContentBMP = null; 
		/// <summary>
		/// 程序是否正在锁定鼠标
		/// </summary>
		private bool				bolCaptureMouse = false;
		/// <summary>
		/// 所有的绘图动作的集合
		/// </summary>
		private System.Collections.ArrayList myActions = new ArrayList();
		/// <summary>
		/// 点缓冲区
		/// </summary>
		private PointBuffer			myPointBuffer = new PointBuffer();
		/// <summary>
		/// 计算面积的动作对象
		/// </summary>
		private ImageAreaAction		myAreaAction  = new ImageAreaAction();
		/// <summary>
		/// 计算距离的动作对象
		/// </summary>
		private ImageDistanceAction myDisAction = new ImageDistanceAction();
		/// <summary>
		/// 最后一次鼠标光标位置
		/// </summary>
		private System.Drawing.Point LastMousePos = System.Drawing.Point.Empty ;

		/// <summary>
		/// 当前选中的动作
		/// </summary>
		private ImageEditAction myCurrentAction = null;

		///<summary>
		//// X轴方向每单位距离象素个数
		///</summary>
		private double    dblXRate        = 37.8 ;

		///<summary>
		//// Y轴方向每单位距离象素个数
		///</summary>
		private double    dblYRate        = 37.8 ;

		///<summary>
		//// 单位文本
		///</summary>
		private string    strUnitString   = "厘米" ;

		
		///<summary>
		//// X轴方向每单位距离象素个数
		///</summary>
		public double XRate
		{
			get{ return dblXRate ;}
			set{ dblXRate = value;}
		}

		///<summary>
		//// Y轴方向每单位距离象素个数
		///</summary>
		public double YRate
		{
			get{ return dblYRate ;}
			set{ dblYRate = value;}
		}

		///<summary>
		//// 单位文本
		///</summary>
		public string UnitString
		{
			get{ return strUnitString ;}
			set{ strUnitString = value;}
		}


		/// <summary>
		/// 当前线宽度
		/// </summary>
		private int intLineWidth = 1;

		/// <summary>
		/// 绘制文本时是否是透明的
		/// </summary>
		//private bool bolTextTransparent = false;

		/// <summary>
		/// 视图区域中光标
		/// </summary>
		private System.Windows.Forms.Cursor myClientCursor = System.Windows.Forms.Cursors.Default ;
	 
		
		public enum ImageEditModeConst
		{
			/// <summary>
			/// 不处于编辑状态，可以移动图片
			/// </summary>
			Edit_None = 0 , 
			/// <summary>
			/// 随意选择
			/// </summary>
			Edit_RandSelect = 1 ,
			/// <summary>
			/// 矩形选择
			/// </summary>
			Edit_RectSelect = 2,
			/// <summary>
			/// 橡皮擦
			/// </summary>
			Edit_Rubber = 3 ,
			/// <summary>
			/// 填充颜色
			/// </summary>
			Edit_Fill = 4 ,
			/// <summary>
			/// 选取颜色
			/// </summary>
			Edit_ColorPick = 5 ,
			/// <summary>
			/// 缩放图片
			/// </summary>
			Edit_Zoom = 6 ,
			/// <summary>
			/// 画笔
			/// </summary>
			Edit_Pen = 7 ,
			/// <summary>
			/// 画刷
			/// </summary>
			Edit_Brush = 8 ,
			/// <summary>
			/// 喷雾
			/// </summary>
			Edit_Fog = 9 ,
			/// <summary>
			/// 文字
			/// </summary>
			Edit_Text= 10 ,
			/// <summary>
			/// 直线
			/// </summary>
			Edit_Line = 11 ,
			/// <summary>
			/// 曲线
			/// </summary>
			Edit_Curve = 12 ,
			/// <summary>
			/// 矩形边框
			/// </summary>
			Edit_Rect = 13 ,
			/// <summary>
			/// 多边形边框
			/// </summary>
			Edit_Poly = 14,
			/// <summary>
			/// 圆或者椭圆
			/// </summary>
			Edit_Arc = 15 ,
			/// <summary>
			/// 圆角矩形
			/// </summary>
			Edit_RRect = 16 ,
			/// <summary>
			/// 绘制并填充矩形
			/// </summary>
			Edit_RectAndFill = 17 ,
			/// <summary>
			/// 填充矩形
			/// </summary>
			Edit_FillRect = 18 ,
			/// <summary>
			/// 绘制并填充圆角矩形
			/// </summary>
			Edit_RRectAndFill = 19 , 
			/// <summary>
			/// 计算面积
			/// </summary>
			Edit_Area = 25 ,
			/// <summary>
			/// 计算距离
			/// </summary>
			Edit_Distance = 26 ,
			/// <summary>
			/// 计算特定区域RGB平均值
			/// </summary>
			Edit_RGB = 27 ,
			/// <summary>
			/// 带箭头的线段
			/// </summary>
			Edit_ArrowLine = 28 

		}//public enum ImageEditModeConst
		
		/// <summary>
		/// 初始化编辑器
		/// </summary>
		public void InitClass()
		{
			// 加载工具栏
			myButtons.BindControl(this.pnlToolBar );
			myButtons.DefaultButtonHeight = 25 ;
			myButtons.DefaultButtonWidth = 25 ;
			myButtons.OnClick +=new ZYButtonClickHandler(myButtons_OnClick);
			System.Drawing.Bitmap myBMP =  (System.Drawing.Bitmap) this.picToolbar.Image ;// System.Drawing.Image.FromFile(@"D:\source6\zyclinic\EMRTextDocumentLib\图标\imgtools.bmp");
			myBMP.MakeTransparent( System.Drawing.Color.Red );
			myButtons.SetButtonImage( myBMP , 16 , 16 );
			for(int iCount = 0 ;iCount < 29 ; iCount ++ )
			{
				ZYButtonGroup.ZYButton myButton = myButtons.AddButton( iCount , iCount );
				myButton.Visible = (
					iCount == (int) ImageEditModeConst.Edit_None  
					|| iCount == (int) ImageEditModeConst.Edit_Pen 
					|| iCount == (int) ImageEditModeConst.Edit_Area
					|| iCount == (int) ImageEditModeConst.Edit_ColorPick 
					|| iCount == (int) ImageEditModeConst.Edit_Distance 
					|| iCount == (int) ImageEditModeConst.Edit_FillRect 
					|| iCount == (int) ImageEditModeConst.Edit_Line 
					|| iCount == (int) ImageEditModeConst.Edit_Poly 
					|| iCount == (int) ImageEditModeConst.Edit_Rect 
					|| iCount == (int) ImageEditModeConst.Edit_RectAndFill 
					|| iCount == (int) ImageEditModeConst.Edit_Text 
					|| iCount == (int) ImageEditModeConst.Edit_ArrowLine 
					|| iCount == (int) ImageEditModeConst.Edit_Zoom 
					//|| iCount == (int) ImageEditModeConst.Edit_RGB 
					//|| iCount == (int) ImageEditModeConst.Edit_Arc 
					);
			}
			myButtons.ClientRect  = pnlToolBar.ClientRectangle ; 
			myButtons.RefreshSize();
			myButtons.CommandID = 0 ;
			// 出世化颜色选择器
			myColorSelector.BindControl( this.pnlColorList );
		}

		/// <summary>
		/// 加载BMP图片文件
		/// </summary>
		/// <param name="strSrc">图片文件名</param>
		/// <returns>加载是否成功</returns>
		public bool LoadBMPFile( string strSrc)
		{
			this.ContentBMP = (System.Drawing.Bitmap) System.Drawing.Image.FromFile( strSrc );
			return true;
		}
		 
		/// <summary>
		/// 设置,返回供编辑的BMP图片对象
		/// </summary>
		public System.Drawing.Bitmap ContentBMP
		{
			get{ return myContentBMP ;}
			set
			{
				myContentBMP = value;
				if( myContentBMP != null)
				{
					this.pnlImage.AutoScrollMinSize = new Size( myContentBMP.Size.Width + 20 , myContentBMP.Size.Height + 20) ;
					this.stpMain.Text = "格式:" + myContentBMP.PixelFormat + " 宽度:" + myContentBMP.Size.Width + " 高度:" + myContentBMP.Size.Height ;
				}
			}
		}

		/// <summary>
		/// 返回编辑过后的BMP图片对象
		/// </summary>
		public System.Drawing.Bitmap EditedBMP
		{
			get
			{
				System.Drawing.Bitmap myBMP = new System.Drawing.Bitmap( myContentBMP );
				using(System.Drawing.Graphics g = System.Drawing.Graphics.FromImage( myBMP ))
				{
					System.Drawing.Rectangle ClipRect = new System.Drawing.Rectangle( 0 , 0 , myBMP.Size.Width , myBMP.Size.Height );
					foreach( ImageEditAction a in myActions)
					{
						a.Execute( g , ClipRect );
					}
				}
				return myBMP ;
			}
		}

		/// <summary>
		/// 图片是否发生改变
		/// </summary>
		public bool BMPChanged
		{
			get{ return myActions.Count > 0 ;}
		}
 
		#region 设计面板事件处理 ******************************************************************

		/// <summary>
		/// 工具栏面板大小改变事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlToolBar_Resize(object sender, System.EventArgs e)
		{
			//if( pnlToolBar.ClientRectangle.Width != myButtons.Width )
			{
				//myButtons.Top = 10 ;
				myButtons.ClientRect  = pnlToolBar.ClientRectangle ; 
				myButtons.Top = 10 ;
				myButtons.RefreshSize();
				myButtons.Left = ( pnlToolBar.ClientSize.Width - myButtons.PerformWidth ) / 2 ;
				pnlList.Top = myButtons.Top + myButtons.PerformHeight + 5 ;
				pnlList.Left = ( pnlToolBar.ClientSize.Width - pnlList.Width )/2 ;
				pnlToolBar.Refresh();
			}
		}

		/// <summary>
		/// 设计面板重新绘制事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( myContentBMP == null)
				return ;
			// 计算绘制区域的坐标
			System.Drawing.Rectangle myRect = System.Drawing.Rectangle.Intersect( e.ClipRectangle  , this.ViewRect );
			System.Drawing.Graphics myGraph = e.Graphics ;
			System.Drawing.Point Origin = this.ViewPointToClient(0,0);
			myGraph.SetClip( this.ViewRect );
			if( myRect.IsEmpty == false)
			{
				// 绘制主图象
				myGraph.DrawImage
					( myContentBMP , 
					myRect , 
					new System.Drawing.Rectangle( PointToView( myRect.Location ) , myRect.Size ) , 
					System.Drawing.GraphicsUnit.Pixel );
				System.Drawing.Rectangle ClipRect = e.ClipRectangle ;
				ClipRect.Location = this.PointToView( ClipRect.Location );
				myGraph.TranslateTransform( this.ViewRect.Left , this.ViewRect.Top );
				// 重新绘制所有的绘图动作
				foreach(ImageEditAction a in this.myActions )
				{
					if( a.Bounds.IntersectsWith( ClipRect ))
						a.Execute( myGraph , ClipRect );
				}
				if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Area )
				{
					// 绘制计算面积的动作
					System.Drawing.Point PointFix = this.ViewPointToClient( 0 , 0 );
					myAreaAction.DrawFix = this.ViewRect.Location ;
					myAreaAction.Execute( myGraph , ClipRect );
				}
				else if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Distance )
				{
					// 绘制计算距离的动作
					myDisAction.XRate = dblXRate ;
					myDisAction.YRate = dblYRate ;
					myDisAction.DrawFix = this.ViewRect.Location ;
					myDisAction.Execute( myGraph , ClipRect );
				}
				else
				{
					// 绘制所有的点
					if( myPointBuffer.Count > 1 )
					{
						using(System.Drawing.Pen myPen = this.CreateCurrentPen())
						{
							myGraph.DrawLines( myPen , myPointBuffer.ToPointArray());
						}
					}
				}
				if( myCurrentAction != null)
				{
					myGraph.DrawRectangle( System.Drawing.Pens.Black , myCurrentAction.Bounds );
					System.Drawing.Rectangle[] dr = myCurrentAction.GetDragRects();
					myGraph.FillRectangles( System.Drawing.Brushes.DarkBlue , dr );
					myGraph.DrawRectangles( System.Drawing.Pens.White , dr );
				}
			}
			myGraph.ResetClip();
			myGraph.ResetTransform();
			// 绘制视图区域周围的边框
			myRect = this.ViewRect ;
			myGraph.DrawRectangle( System.Drawing.Pens.Black , myRect );
			System.Drawing.Rectangle[] DragRects = DocumentView.GetDragRects( myRect , 4 , false );
			for(int iCount = 0 ; iCount < DragRects.Length ; iCount ++ )
			{
				DocumentView.DrawDragRect( myGraph , DragRects[iCount] , ( iCount == 3 || iCount == 4 || iCount == 5 ) );
			}
		}

		/// <summary>
		/// 设置面板鼠标按下事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// 获得当前鼠标位置
			System.Drawing.Point p = new Point(e.X , e.Y );
			System.Drawing.Point p1 = System.Windows.Forms.Control.MousePosition ;
			System.Drawing.Point p2 = System.Drawing.Point.Empty ;
			
			// 若鼠标当前位置在视图区域内部则进行命令处理
			if( this.ViewRect.Contains( p ))
			{
				switch( myButtons.CommandID )
				{
					case (int) ImageEditModeConst.Edit_None :
						p1 = this.PointToView( e.X , e.Y );
						bool bolMatch = false;
						for(int iCount = myActions.Count -1  ; iCount >= 0 ; iCount --)
						{
							ImageEditAction a = ( ImageEditAction ) myActions[iCount];
							if( a.Selectable && a.Bounds.Contains( p1 ) )
							{
								bolMatch = true;
								if( myCurrentAction != a )
								{
									myCurrentAction = a ;
									this.pnlImage.Refresh();
								}
								break;
							}
						}//for
						if( bolMatch == false && myCurrentAction != null)
						{
							myCurrentAction = null;
							pnlImage.Refresh();
						}
						if( myCurrentAction != null && myCurrentAction.Bounds.Contains( p1 ) )
						{
							System.Drawing.Rectangle[] dr = myCurrentAction.GetDragRects();
							System.Drawing.Rectangle myRect = myCurrentAction.Bounds ;
							myRect.Location = this.ViewPointToScreen( myRect.Location );
							bool bolChanged = false;
							for(int iCount = 0 ; iCount < dr.Length ; iCount ++)
							{
								if( dr[iCount].Contains( p1 ))
								{
									myRect = this.CaptureDragRect( myRect , iCount , true , 0 , true , null);
									bolChanged = true;
									break;
								}
							}
							if( bolChanged == false)
							{
								myRect = this.CaptureDragRect( myRect , -1 , true , 0 , true , null);
								bolChanged = true;
							}
							if( bolChanged && myRect.IsEmpty == false)
							{
								myRect.Location = this.ScreenPointToView( myRect.Location );
								myCurrentAction.DesignChangeBounds( myRect );// .Bounds = myRect ;
								pnlImage.Refresh();
							}
							bolCaptureMouse = false;
						}//if
						else
						{
							bolCaptureMouse = true;
							LastMousePos = new System.Drawing.Point(e.X , e.Y );
						}
						break;
					case (int) ImageEditModeConst.Edit_ColorPick :
						// 选取颜色
						myColorSelector.CurrentColor = pnlList.BackColor ;
						pnlList.BackColor = this.BackColor ;
						myButtons.CommandID = 0 ;
						break;
					case (int) ImageEditModeConst.Edit_Line :
						// 绘制直线
						p2 = CaptureDragPoint( p1 , 0x11  , null);
						if( p1.Equals(p2)==false)
						{
							ImageLineAction LineAction = new ImageLineAction();
							LineAction.p1 = this.ScreenPointToView( p1 );
							LineAction.p2 = this.ScreenPointToView( p2 );
							LineAction.Color = myColorSelector.ForeColor ;
							LineAction.Width = intLineWidth ;
							myActions.Add( LineAction );
							pnlImage.Refresh();
						}
						bolCaptureMouse = false;
						break;
					case (int) ImageEditModeConst.Edit_ArrowLine :
						// 绘制带箭头的直线
						p2 = CaptureDragPoint( p1 , 0x11  , null);
						if( p1.Equals(p2)==false)
						{
							ImageLineAction LineAction = new ImageLineAction();
							LineAction.p1 = this.ScreenPointToView( p1 );
							LineAction.p2 = this.ScreenPointToView( p2 );
							LineAction.Color = myColorSelector.ForeColor ;
							LineAction.Width = intLineWidth ;
							LineAction.Arrow = true;
							myActions.Add( LineAction );
							pnlImage.Refresh();
						}
						bolCaptureMouse = false;
						break;
					case (int) ImageEditModeConst.Edit_Rect :
						// 绘制矩形方框
						p2 = CaptureDragPoint( p1 , 2 , null);
						if( p1.Equals( p2 ) == false)
						{
							ImageRectAction RectAction = new ImageRectAction();
							RectAction.Bounds = this.ScreenPointToViewRect(p1,p2);
							RectAction.BorderColor = myColorSelector.ForeColor ;
							RectAction.BorderWidth = intLineWidth ;
							myActions.Add( RectAction );
							pnlImage.Refresh();
						}
						bolCaptureMouse = false;
						break;
					case (int) ImageEditModeConst.Edit_FillRect :
						// 填充矩形区域
						p2 = CaptureDragPoint( p1 , 3 , null);
						if( p1.Equals(p2 )== false )
						{
							ImageFillRectAction FillAction = new ImageFillRectAction();
							FillAction.Bounds = this.ScreenPointToViewRect(p1,p2);
							FillAction.FillColor = myColorSelector.BackColor ;
							myActions.Add( FillAction );
							pnlImage.Refresh();
						}
						break;
					case (int) ImageEditModeConst.Edit_Pen :
						// 画笔
						bolCaptureMouse = true;
						break;
					case (int) ImageEditModeConst.Edit_RectAndFill :
						// 绘制并填充矩形区域
						p2 = CaptureDragPoint( p1 , 3 , null);
						if( p1.Equals(p2)==false)
						{
							ImageRectAndFillAction RFAction = new ImageRectAndFillAction();
							RFAction.Bounds = this.ScreenPointToViewRect(p1,p2);
							RFAction.FillColor = myColorSelector.BackColor ;
							RFAction.BorderColor = myColorSelector.ForeColor ;
							RFAction.BorderWidth = intLineWidth ;
							myActions.Add( RFAction );
							pnlImage.Refresh();
						}
						bolCaptureMouse = false;
						break;
					case (int) ImageEditModeConst.Edit_Poly :
						// 绘制封闭的多边形
						myPointBuffer.Add( this.ScreenPointToView( p1 ));
						this.pnlImage.Refresh();
						break;
					case (int) ImageEditModeConst.Edit_Area :
						// 计算面积
						myPointBuffer.Clear();
						myAreaAction.Points = null;
						bolCaptureMouse = true;
						pnlImage.Refresh();
						break;
					case (int) ImageEditModeConst.Edit_Distance :
						// 计算距离
						p2 = CaptureDragPoint( p1 , 0x10 , new DragPointHandler( this.CalcutePointDistance ));
						pnlImage.Refresh();
						break;
					case (int) ImageEditModeConst.Edit_Text :
						// 绘制文本
						p2 = CaptureDragPoint( p1 , 2 , null);
						if( p1.Equals(p2) == false)
						{
							using( dlgInputFormatText dlg = new dlgInputFormatText())
							{
								if( dlg.ShowDialog( this) == System.Windows.Forms.DialogResult.OK )
								{
									if( StringCommon.HasContent( dlg.InputText ))
									{
										ImageTextAction TextAction = new ImageTextAction();
										TextAction.Bounds		= this.ScreenPointToViewRect( p1 , p2 );
										TextAction.ForeColor	= myColorSelector.ForeColor ;
										TextAction.Text			= dlg.InputText  ;
										TextAction.FontName		= dlg.InputFontName  ;
										TextAction.FontSize		= dlg.InputFontSize ;
										TextAction.Bold			= dlg.InputFontBold ;
										TextAction.Italic		= dlg.InputFontItalic ;
										myActions.Add( TextAction );
										pnlImage.Refresh();
									}
								}
							}//using
						}
						myButtons.CommandID = 0 ;
						bolCaptureMouse = false;
						break;
				}//switch
			}
			else
			{
				// 处理视图边框上的鼠标事件
				System.Drawing.Rectangle[] DragRects = DocumentView.GetDragRects( this.ViewRect , 4 , false );
				for(int iCount = 0 ; iCount < DragRects.Length ; iCount ++ )
				{
					if( DragRects[iCount].Contains( p ) && ( iCount == 3 || iCount == 4 || iCount == 5 ))
					{
						System.Drawing.Rectangle DescRect = this.ViewRect ;
						DescRect.Location = this.ViewPointToScreen( 0 , 0 );
						DescRect = CaptureDragRect( DescRect , iCount , true , 0 , true , null);
						break;
					}
				}
			}
			
		}

		/// <summary>
		/// 设计面板上鼠标移动事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( bolCaptureMouse )
			{
				System.Drawing.Point p = this.PointToView( e.X , e.Y );
				switch( myButtons.CommandID )
				{
					case (int) ImageEditModeConst.Edit_None : // 鼠标拖拽来滚动图片
						if( pnlImage.AutoScrollMinSize.Width > pnlImage.ClientSize.Width || pnlImage.AutoScrollMinSize.Height > pnlImage.ClientSize.Height )
						{
							System.Drawing.Point NewPos = pnlImage.AutoScrollPosition ;
							NewPos.X = 0 - NewPos.X ;
							NewPos.Y = 0 - NewPos.Y ;
							NewPos.Offset( this.LastMousePos.X - e.X , this.LastMousePos.Y - e.Y );
							pnlImage.AutoScrollPosition = NewPos ;
							LastMousePos = new System.Drawing.Point(e.X ,e.Y );
						}
						break;
					case (int) ImageEditModeConst.Edit_Area :
						// 动态的计算当前选择区域的面积
						using(System.Drawing.Graphics g = pnlImage.CreateGraphics())
						{
							myAreaAction.DrawFix = this.ViewRect.Location ;
							myAreaAction.Execute( g , this.ViewRect );
							myPointBuffer.Add( p );
							myAreaAction.Points = myPointBuffer.ToClosedPointArray();
							myAreaAction.Execute( g , this.ViewRect );
						}
						this.stpMain.Text = "当前选中区域的面积:" + myAreaAction.ContainArea.ToString("0.00") + "平方" + strUnitString ;
						break;
					case (int) ImageEditModeConst.Edit_Pen :
						// 动态的绘制当前画笔
						if( myPointBuffer.Count > 0 )
						{
							using(System.Drawing.Graphics g = pnlImage.CreateGraphics())
							{
								using(System.Drawing.Pen myPen = this.CreateCurrentPen())
								{
									g.DrawLine( myPen , this.ViewPointToClient( myPointBuffer.LastPoint ) , this.ViewPointToClient( p ));
								}
							}
						}
						myPointBuffer.Add( p );
						break;
				}//switch
			}
			else
			{
				// 鼠标只是在视图区域中移动,没有锁定鼠标
				System.Drawing.Point p = new Point(e.X , e.Y );
				if( this.ViewRect.Contains( p ))
				{
					pnlImage.Cursor = myClientCursor;
					p = this.PointToView(p);
					bool bolStatus = false;
					this.stpSize.Text = "X:" + p.X  + " Y:" + p.Y ;
					switch( myButtons.CommandID )
					{
						case (int) ImageEditModeConst.Edit_None :
							if( myCurrentAction != null && myCurrentAction.Bounds.Contains( p ))
							{
								System.Drawing.Rectangle[] DR = myCurrentAction.GetDragRects();
								for(int iCount = 0 ; iCount < DR.Length ;iCount ++)
								{
									if( DR[iCount].Contains(p))
									{
										pnlImage.Cursor = DocumentView.GetDragRectCursor( iCount );
									}
								}
							}
							break;
						case (int)ImageEditModeConst.Edit_ColorPick :
							// 选取颜色
							System.Drawing.Color iColor = myContentBMP.GetPixel( p.X , p.Y );
							this.pnlList.BackColor = iColor ;
							//this.myColorSelector.CurrentColor =   myContentBMP.GetPixel( p.X , p.Y );
							this.stpSize.Text = "X:" + p.X  + " Y:" + p.Y + "  " + StringCommon.ColorToHtml( iColor );
							bolStatus = true;
							break;
					}
					if( bolStatus == false)
					{
						this.stpSize.Text = "X:" + p.X  + " Y:" + p.Y ;
					}
				}
				else
				{
					this.stpSize.Text = "";
					//p = this.PointToView( p );
					System.Drawing.Rectangle[] DragRects = DocumentView.GetDragRects( this.ViewRect , 4 , false );
					bool bolSet = false;
					for(int iCount = 0 ; iCount < DragRects.Length ;iCount ++ )
					{
						if( DragRects[iCount].Contains( p ) && ( iCount == 3 || iCount == 4 || iCount == 5 ))
						{
							pnlImage.Cursor = DocumentView.GetDragRectCursor( iCount );
							bolSet = true;
							break;
						}
					}
					if( bolSet == false )
						pnlImage.Cursor = System.Windows.Forms.Cursors.Default ;
				}
			}
		}

		/// <summary>
		/// 设计面板中鼠标按键松开事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( bolCaptureMouse == true )
			{

				if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Pen )
				{
					// 结束画笔动作
					if( myPointBuffer.Count > 0 )
					{
						ImagePenAction PenAction = new ImagePenAction();
						PenAction.Points = myPointBuffer.ToPointArray();
						PenAction.ForeColor = myColorSelector.ForeColor ;
						PenAction.LineWidth = intLineWidth ;
						myActions.Add( PenAction );
						myPointBuffer.Clear();
						pnlImage.Refresh();
					}
				}
				else if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Area )
				{
//					// 结束计算面积的动作
//					this.stpMain.Text = "正在计算RGB平均值...";
//					this.Cursor = System.Windows.Forms.Cursors.WaitCursor ;
//					InitProgress();
//					int[] AvgRGB = myAreaAction.CalcuteAvgRGB( this.myContentBMP , new ZYCommon.ProgressHandler(this.SetProgress ));
//					this.myProgress.Visible = false;
//					this.stpMain.Text = String.Format("面积:{0:0.00}平方" + strUnitString + " RGB平均值 R:{1} G:{2} B:{3}" , myAreaAction.CalcuteArea() , AvgRGB[0],AvgRGB[1],AvgRGB[2]);
//					this.Cursor = System.Windows.Forms.Cursors.Default ;
				}
			}
			bolCaptureMouse = false;
		}

		private void InitProgress()
		{
			myProgress.Bounds = new Rectangle( this.stpMain.Width + 2 , this.myStatus.Top + 2 ,  this.stpSize.Width - 2 , this.myStatus.Height - 2  );
			myProgress.Visible = true;
			//this.Refresh();
		}
		
		private void SetProgress( int Completed , int vTotal)
		{
			if( vTotal != myProgress.Maximum )
				myProgress.Maximum = vTotal;
			myProgress.Value = Completed ;
		}
		
		 
		#endregion

		/// <summary>
		/// 工具栏按钮按下事件处理
		/// </summary>
		/// <param name="ButtonGroup">工具栏对象</param>
		/// <param name="Button">按钮对象</param>
		private void myButtons_OnClick(ZYButtonGroup ButtonGroup, ZYButtonGroup.ZYButton Button)
		{
			// 处理上一次按钮状态
			switch( myButtons.LastCommandID )
			{
				case (int) ImageEditModeConst.Edit_ColorPick :
					pnlList.BackColor = this.BackColor ;
					break;
				case(int) ImageEditModeConst.Edit_Poly :
					// 若上一次按钮为绘制多边形则结束动作
					if( myPointBuffer.Count > 1)
					{
						ImagePolyAction PA = new ImagePolyAction();
						PA.Points = myPointBuffer.ToClosedPointArray();
						myPointBuffer.Clear();
						PA.LineWidth = intLineWidth ;
						PA.ForeColor = myColorSelector.ForeColor ;
						myActions.Add( PA );
						pnlImage.Refresh();
					}
					break;
				case (int) ImageEditModeConst.Edit_Area :
					if( myButtons.CommandID == (int) ImageEditModeConst.Edit_RGB )
					{
						// 结束计算面积的动作
						this.stpMain.Text = "正在计算RGB平均值...";
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor ;
						InitProgress();
						this.pnlToolBar.Refresh();
						System.Drawing.Color AvgColor = myAreaAction.CalcuteAvgColor( myContentBMP , new ZYCommon.ProgressHandler(this.SetProgress ));
						this.myProgress.Visible = false;
						this.stpMain.Text = String.Format("当前选中区域的面积:{0:0.00}平方" + strUnitString + " RGB平均值 R:{1} G:{2} B:{3}" , myAreaAction.CalcuteArea() , AvgColor.R , AvgColor.G , AvgColor.B );
						this.Cursor = System.Windows.Forms.Cursors.Default ;
						myButtons.CommandID = (int) ImageEditModeConst.Edit_Area ;
					}
					else
					{
						// 结束计算面积的动作
						myPointBuffer.Clear();
						myAreaAction.Points = null;
						pnlImage.Refresh();
					}
					break;
				case (int) ImageEditModeConst.Edit_Distance :
					// 结束计算距离的动作
					myDisAction.Clear();
					pnlImage.Refresh();
					break;
			}//switch

			myColorSelector.ShowBackColor = true;
			myColorSelector.ShowForeColor = true;
			switch( Button.CommandID )
			{
				case (int)ImageEditModeConst.Edit_None :
					SetClientCursor( System.Windows.Forms.Cursors.Default );
					break;
				case (int) ImageEditModeConst.Edit_ColorPick :
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					break;
				case (int) ImageEditModeConst.Edit_Curve :
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					myColorSelector.ShowBackColor = false;
					break;
				case (int) ImageEditModeConst.Edit_Line :
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					myColorSelector.ShowBackColor = false;
					break;
				case (int) ImageEditModeConst.Edit_Rect :
					SetClientCursor ( System.Windows.Forms.Cursors.Cross );
					myColorSelector.ShowBackColor = false;
					break;
				case (int) ImageEditModeConst.Edit_Fill :
					SetClientCursor ( System.Windows.Forms.Cursors.Cross );
					myColorSelector.ShowForeColor = false;
					break;
				case (int) ImageEditModeConst.Edit_FillRect :
					SetClientCursor ( System.Windows.Forms.Cursors.Cross );
					myColorSelector.ShowForeColor = false;
					break;
				case (int) ImageEditModeConst.Edit_RectAndFill :
					SetClientCursor ( System.Windows.Forms.Cursors.Cross );
					break;
				case (int) ImageEditModeConst.Edit_Pen :
					SetClientCursor( System.Windows.Forms.Cursors.Arrow );
					myColorSelector.ShowBackColor = false;
					break;
				case (int) ImageEditModeConst.Edit_Poly :
					myPointBuffer.Clear();
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					myColorSelector.ShowBackColor = false;
					break;
				case (int) ImageEditModeConst.Edit_Area :
					myPointBuffer.Clear();
					myAreaAction.XRate = dblXRate ;
					myAreaAction.YRate = dblYRate ;
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					break;
				case (int) ImageEditModeConst.Edit_Distance :
					myPointBuffer.Clear();
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					myDisAction.Clear();
					break;
				case (int) ImageEditModeConst.Edit_Text :
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					break;
				case (int) ImageEditModeConst.Edit_ArrowLine :
					SetClientCursor( System.Windows.Forms.Cursors.Cross );
					break;
				case (int) ImageEditModeConst.Edit_RGB :
					if( myButtons.LastCommandID != (int) ImageEditModeConst.Edit_Area )
					{
						System.Windows.Forms.MessageBox.Show( this , "请首先执行计算面积的操作!","系统提示" );
					}
//					else
//					{
//						// 结束计算面积的动作
//						this.stpMain.Text = "正在计算RGB平均值...";
//						this.Cursor = System.Windows.Forms.Cursors.WaitCursor ;
//						InitProgress();
//						System.Drawing.Color AvgColor = myAreaAction.CalcuteAvgColor( myContentBMP , new ZYCommon.ProgressHandler(this.SetProgress ));
//						this.myProgress.Visible = false;
//						this.stpMain.Text = String.Format("当前选中区域的面积:{0:0.00}平方" + strUnitString + " RGB平均值 R:{1} G:{2} B:{3}" , myAreaAction.CalcuteArea() , AvgColor.R , AvgColor.G , AvgColor.B );
//						this.Cursor = System.Windows.Forms.Cursors.Default ;
//					}
//					myButtons.CommandID = (int) ImageEditModeConst.Edit_Area ;
					break;
			}
			pnlList.Refresh();
		}
		public void SetClientCursor( System.Windows.Forms.Cursor c )
		{
			myClientCursor = c ;
			UpdateClientCursor();
		}

		private void UpdateClientCursor()
		{
			if( this.ViewRect.Contains( this.pnlImage.PointToClient( System.Windows.Forms.Control.MousePosition )))
			{
				pnlImage.Cursor = myClientCursor ;
			}
		}

		#region 坐标点换算函数群 ******************************************************************
		/// <summary>
		/// 根据屏幕上两点坐标生成视图区域中的方框对象
		/// </summary>
		/// <param name="p1">屏幕上第一个点坐标</param>
		/// <param name="p2">屏幕上第二个点坐标</param>
		/// <returns>视图区域中的方框对象</returns>
		public System.Drawing.Rectangle ScreenPointToViewRect( System.Drawing.Point p1 , System.Drawing.Point p2)
		{
			System.Drawing.Rectangle rect = RectangleObject.GetRectangle(p1,p2);
			rect.Location = this.ScreenPointToView( rect.Location );
			return rect ;
		}
		/// <summary>
		/// 将视图区域的坐标换算成设计面板客户区中的坐标
		/// </summary>
		/// <param name="p">视图区域中的坐标</param>
		/// <returns>设计面板客户区中的坐标</returns>
		public System.Drawing.Point ViewPointToClient( System.Drawing.Point p )
		{
			return new System.Drawing.Point( p.X + pnlImage.AutoScrollPosition.X + 10 , p.Y + pnlImage.AutoScrollPosition.Y + 10 );
		}
		/// <summary>
		/// 将视图区域的坐标换算成设计面板客户区中的坐标
		/// </summary>
		/// <param name="x">视图区域中的X坐标</param>
		/// <param name="y">视图区域中的Y坐标</param>
		/// <returns>设计面板客户区中的坐标</returns>
		public System.Drawing.Point ViewPointToClient( int x , int y )
		{
			return new System.Drawing.Point( x + pnlImage.AutoScrollPosition.X + 10 , y + pnlImage.AutoScrollPosition.Y + 10 );
		}
		/// <summary>
		/// 将客户区中的坐标换算成视图区域中的坐标
		/// </summary>
		/// <param name="p">客户区中的坐标</param>
		/// <returns>视图区域中的坐标</returns>
		public System.Drawing.Point PointToView( System.Drawing.Point p )
		{
			return new System.Drawing.Point( p.X - pnlImage.AutoScrollPosition.X - 10 , p.Y - pnlImage.AutoScrollPosition.Y - 10);
		}
		/// <summary>
		/// 将客户区中的坐标换算成视图区域中的坐标
		/// </summary>
		/// <param name="x">客户区中的X坐标</param>
		/// <param name="y">客户区中的Y坐标</param>
		/// <returns>视图区域中的坐标</returns>
		public System.Drawing.Point PointToView( int x , int y )
		{
			return new System.Drawing.Point( x - pnlImage.AutoScrollPosition.X - 10 ,y - pnlImage.AutoScrollPosition.Y - 10);
		}
		/// <summary>
		/// 将视图区域的坐标换算成屏幕坐标
		/// </summary>
		/// <param name="x">视图区域X坐标</param>
		/// <param name="y">视图区域Y坐标</param>
		/// <returns>屏幕坐标</returns>
		public System.Drawing.Point ViewPointToScreen( int x , int y )
		{
			System.Drawing.Point p = this.ViewPointToClient( x ,y );
			return this.pnlImage.PointToScreen(p);
		}
		/// <summary>
		/// 将视图区域的坐标换算成屏幕坐标
		/// </summary>
		/// <param name="p">视图区域坐标</param>
		/// <returns>屏幕坐标</returns>
		public System.Drawing.Point ViewPointToScreen( System.Drawing.Point p )
		{
			p = this.ViewPointToClient( p );
			return this.pnlImage.PointToScreen(p);
		}
		/// <summary>
		/// 将屏幕坐标转换未视图区域坐标
		/// </summary>
		/// <param name="p">屏幕坐标值</param>
		/// <returns>视图坐标</returns>
		public System.Drawing.Point ScreenPointToView( System.Drawing.Point p )
		{
			return this.PointToView( this.pnlImage.PointToClient( p ));
		}
		/// <summary>
		/// 将屏幕坐标转换未视图区域坐标
		/// </summary>
		/// <param name="x">屏幕X坐标</param>
		/// <param name="y">屏幕Y坐标</param>
		/// <returns>视图坐标</returns>
		public System.Drawing.Point ScreenPointToView( int x , int y )
		{
			return this.PointToView( this.pnlImage.PointToClient( new System.Drawing.Point( x , y )));
		}
		#endregion

		/// <summary>
		/// 返回视图区域在客户区中的范围
		/// </summary>
		public System.Drawing.Rectangle ViewRect
		{
			get
			{
				if( myContentBMP != null)
					return new System.Drawing.Rectangle( pnlImage.AutoScrollPosition.X + 10 , pnlImage.AutoScrollPosition.Y + 10 , myContentBMP.Size.Width , myContentBMP.Size.Height ) ; 
				else
					return System.Drawing.Rectangle.Empty ;
			}
		}

		/// <summary>
		/// 根据当前的设置创建一个画笔对象
		/// </summary>
		/// <returns></returns>
		private System.Drawing.Pen CreateCurrentPen()
		{
			return new System.Drawing.Pen( myColorSelector.ForeColor , intLineWidth );
		}
		/// <summary>
		/// 设置列表中是否显示线段宽度属性
		/// </summary>
		/// <returns></returns>
		private bool IsListLineWidth()
		{
			return ( myButtons.CommandID == (int) ImageEditModeConst.Edit_Pen 
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_Line 
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_Poly 
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_Rect 
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_Curve
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_Arc 
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_RRect
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_RectAndFill 
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_RRectAndFill
				|| myButtons.CommandID == (int) ImageEditModeConst.Edit_ArrowLine );
		}

		private void pnlList_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( IsListLineWidth())
			{
				System.Drawing.Rectangle ItemRect = new System.Drawing.Rectangle( 3 , 2 , pnlList.ClientSize.Width - 6 , 14 );
				for(int iCount = 1 ; iCount < 9 ; iCount ++ )
				{
					if( iCount == this.intLineWidth )
					{
						e.Graphics.FillRectangle( System.Drawing.SystemBrushes.Highlight , ItemRect );
						using(System.Drawing.Pen myPen = new Pen( System.Drawing.SystemColors.HighlightText , iCount ))
						{
							e.Graphics.DrawLine( myPen , ItemRect.Left + 2 , ItemRect.Top + 7 , ItemRect.Right - 5 , ItemRect.Top + 7);
						}
					}
					else
					{
						using(System.Drawing.Pen myPen = new Pen(System.Drawing.Color.Black , iCount))
						{
							e.Graphics.DrawLine( myPen , ItemRect.Left + 2 , ItemRect.Top + 7 , ItemRect.Right - 5 , ItemRect.Top + 7);
						}
					}//if
					ItemRect.Y = ItemRect.Bottom ;
				}//for
			}//if
		}//private void pnlList_Paint() 

		private void pnlList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( IsListLineWidth())
			{
				int vWidth = 1 + (int)System.Math.Floor( ( e.Y - 2)/ 14.0);
				if( vWidth >= 1 && vWidth <  9 )
				{
					this.intLineWidth = vWidth ;
					pnlList.Refresh();
				}
			}
		}

		private void frmEditImage_Load(object sender, System.EventArgs e)
		{
			pnlToolBar_Resize(null,null);
		}

		private bool CalcutePointDistance( System.Drawing.Point p1 , System.Drawing.Point p2 )
		{
			myDisAction.DrawFix = this.ViewRect.Location ;
			myDisAction.XRate = dblXRate ;
			myDisAction.YRate = dblYRate ;
			//if( myDisAction.p1.Equals( myDisAction.p2 ))
			{
				using(System.Drawing.Graphics g = pnlImage.CreateGraphics())
				{
					myDisAction.Execute( g , this.ViewRect );
					myDisAction.p1 = this.ScreenPointToView( p1 ) ;
					myDisAction.p2 = this.ScreenPointToView( p2 ) ;
					myDisAction.Execute( g , this.ViewRect );
				}
				this.stpMain.Text = "距离: " + myDisAction.Distance.ToString("0.00") + this.strUnitString ;
			}
			return true;
		}
		#region 鼠标拖拽控制的函数群 **************************************************************
		/// <summary>
		/// 拖拽节点时的处理委托
		/// </summary>
		public delegate bool DragPointHandler( System.Drawing.Point p1 , System.Drawing.Point p2 );

		/// <summary>
		/// 鼠标拖拽点
		/// </summary>
		/// <param name="SourcePoint"></param>
		/// <param name="DrawStyle"></param>
		/// <param name="CallBack"></param>
		/// <returns></returns>
		public static  System.Drawing.Point CaptureDragPoint(
			System.Drawing.Point SourcePoint , 
			int DrawStyle ,
			DragPointHandler CallBack )
		{
			Windows32.MSG msg	= new Windows32.MSG();
			System.Drawing.Point CurrentPoint = SourcePoint ;
			System.Drawing.Point LastPoint = SourcePoint ;
			System.Drawing.Point LastMousePos = System.Windows.Forms.Control.MousePosition ;
			bool bolHasDraw = false;
			System.Drawing.Rectangle myRect = System.Drawing.Rectangle.Empty ;
			while( Windows32.User32.WaitMessage() )
			{
				if(Windows32.User32.PeekMessage(ref msg, 0, 0, 0, (int)Windows32.PeekMessageFlags.PM_NOREMOVE)==false)
					break;
				// 若当前消息为鼠标按键松开消息则退出循环
				if( Windows32.User32.isMouseUpMessage( msg.message ))
					break;
				if( Windows32.User32.isMouseMoveMessage( msg.message ))
				{
					// 若为鼠标移动消息则进行处理
					System.Drawing.Point MousePos = System.Windows.Forms.Control.MousePosition ;
					if( LastMousePos.Equals( MousePos)==false)
					{
						if( MathCommon.GetIntAttribute( DrawStyle,  0x10 ))
						{
							if( MathCommon.GetIntAttribute( (int) System.Windows.Forms.Control.ModifierKeys , (int) System.Windows.Forms.Keys.Shift ))
							{
								if( SourcePoint.X != MousePos.X && SourcePoint.Y != MousePos.Y )
								{
									double dblAngle = MathCommon.Angle( SourcePoint.X , SourcePoint.Y , MousePos.X , MousePos.Y );
									int intArea = (int)System.Math.Round( ( dblAngle )/45.0) % 8 ;
									if( intArea == 0 || intArea == 4 )
									{
										MousePos.Y = 0 ;
									}
									if( intArea == 2 || intArea == 6 )
									{
										MousePos.Y -= SourcePoint.Y ;
										MousePos.X = SourcePoint.X ;
									}
									if( intArea == 3 || intArea == 7 )
									{
										MousePos.Y = SourcePoint.X - MousePos.X ;
									}
									if( intArea == 5 || intArea == 1 )
										MousePos.Y = MousePos.X - SourcePoint.X ;
									MousePos.Y += SourcePoint.Y ;
								}
							}
						}
						// 擦除上一次绘制的图形
						if( bolHasDraw )
						{
							switch( DrawStyle & 0xf )
							{
								case 1:
									System.Windows.Forms.ControlPaint.DrawReversibleLine( SourcePoint , CurrentPoint , System.Drawing.Color.Black );
									bolHasDraw = false ;
									break;
								case 2:
									myRect = RectangleObject.GetRectangle( SourcePoint ,CurrentPoint );
									System.Windows.Forms.ControlPaint.DrawReversibleFrame
										( myRect ,
										System.Drawing.Color.SkyBlue   ,
										System.Windows.Forms.FrameStyle.Dashed  );
									bolHasDraw = false ;
									break;
								case 3:
									myRect = RectangleObject.GetRectangle( SourcePoint ,CurrentPoint );
									System.Windows.Forms.ControlPaint.FillReversibleRectangle 
										( myRect ,
										System.Drawing.Color.Black   );
									bolHasDraw = false ;
									break;
							}
						}

						// 计算当前点的坐标
						CurrentPoint = MousePos ;
//						CurrentPoint.X += MousePos.X - LastMousePos.X ;
//						CurrentPoint.Y += MousePos.Y - LastMousePos.Y ;
						LastMousePos = MousePos ;

						// 进行回调处理
						if( CallBack != null)
						{
							if( CallBack( SourcePoint , CurrentPoint ) == false)
							{
								if( bolHasDraw )
								{
								}
								return System.Drawing.Point.Empty ;
							}
						}
						if( CurrentPoint.Equals( SourcePoint ) == false)
						{
							// 进行当前的绘制
							switch( DrawStyle & 0xf )
							{
								case 1:
									System.Windows.Forms.ControlPaint.DrawReversibleLine( SourcePoint , CurrentPoint , System.Drawing.Color.Black );
									bolHasDraw = true;
									break;
								case 2:
									myRect = RectangleObject.GetRectangle( SourcePoint ,CurrentPoint );
									System.Windows.Forms.ControlPaint.DrawReversibleFrame
										( myRect ,
										System.Drawing.Color.SkyBlue   ,
										System.Windows.Forms.FrameStyle.Dashed  );
									bolHasDraw = true;
									break;
								case 3:
									myRect = RectangleObject.GetRectangle( SourcePoint ,CurrentPoint );
									System.Windows.Forms.ControlPaint.FillReversibleRectangle 
										( myRect ,
										System.Drawing.Color.Black  );
									bolHasDraw = true ;
									break;
							}
						}
					}// if Equals
				}
				Windows32.User32.GetMessage(ref msg, 0, 0, 0);
			}// while
			if( bolHasDraw )
			{
				// 进行当前的绘制
				switch( DrawStyle & 0xf )
				{
					case 1:
						System.Windows.Forms.ControlPaint.DrawReversibleLine( SourcePoint , CurrentPoint , System.Drawing.Color.Black );
						bolHasDraw = true;
						break;
					case 2:
						myRect = RectangleObject.GetRectangle( SourcePoint ,CurrentPoint );
						System.Windows.Forms.ControlPaint.DrawReversibleFrame
							( myRect ,
							System.Drawing.Color.SkyBlue   ,
							System.Windows.Forms.FrameStyle.Dashed  );
						bolHasDraw = true;
						break;
					case 3:
						myRect = RectangleObject.GetRectangle( SourcePoint ,CurrentPoint );
						System.Windows.Forms.ControlPaint.FillReversibleRectangle 
							( myRect ,
							System.Drawing.Color.Black  );
						bolHasDraw = true ;
						break;
				}
			}
			return CurrentPoint ;
		}//public static System.Drawing.Point CaptureDragPoint()

		/// <summary>
		/// 锁定鼠标并进行矩形的拖拉操作
		/// </summary>
		/// <remarks>在文档编辑或其他设计器中,经常会出现需要使用鼠标拖拽对象四周边缘上的8个控制点
		/// 的方式来改变对象的位置和大小,本函数则专门用于支持该操作。
		/// 本函数会锁定用户的所有的鼠标和键盘消息,并根据鼠标的移动来修改
		/// 指定的矩形,直到用户松开鼠标或者回调函数取消本次操作
		/// DragStyle 参数为拖拽点的编号，其有效范围为－1至7，其意义为
		/// -1 正在拖拽矩形本身，此时移动鼠标将整体移动矩形
		/// 0  拖拽矩形左上角的控制点，修改矩形的左上角位置，矩形的右下角位置不变,会导致矩形的位置和大小的改变
		/// 1  拖拽矩形上边缘中间的控制点，修改矩形的上边缘位置，其他3个边缘的位置不变，会导致矩形的顶端位置和高度的改变
		/// 2  拖拽矩形右上角的控制点，修改矩形的右上角位置，其左下角的位置不变，会导致矩形的顶端位置和宽度的改变
		/// 3  拖拽矩形右边缘中间的控制点，修改矩形的右边缘的位置，其他边缘位置不变，会导致矩形的宽度的改变
		/// 4  拖拽矩形右下角的控制点，修改矩形的右下角的位置，左上角的位置不变，会导致矩形的大小的改变
		/// 5  拖拽矩形下边缘中间的控制点，修改矩形的下边缘位置，其他边缘不变，会导致矩形的高度的改变
		/// 6  拖拽矩形左下角的控制点，修改矩形的左下角位置，其右上角位置不变，会导致矩形的左端位置和高度的改变
		/// 7  拖拽矩形左边缘中间的控制点，修改矩形左边缘的位置，其他边缘不变，会导致矩形的左端位置和宽度的改变
		/// 关于8个拖拽控制点请参见<link>ZYCommon.DocumentView.GetDragRects</link></remarks>
		/// <param name="SourceRect">原始矩形,坐标为视图区域中的坐标</param>
		/// <param name="DragStyle">拖拽控制点的编号</param>
		/// <param name="DrawFocusRect">拖拉时是否绘制可逆转矩形,若设为true 则会拖拽时会自动绘制当前矩形的可逆矩形边框</param>
		/// <param name="WidthHeightRate">拖动时边框的宽度和高度的比例，若小于等于0.1则不作该设置</param>
		/// <param name="ShowSizeInfo" >拖动时是否显示大小信息</param>
		/// <param name="CallBack">回调函数的委托</param>
		/// <returns>原始矩形进行拖拉操作后修改后的矩形,若用户未改变原始矩形的大小或取消操作则返回空矩形,坐标为视图区域中的坐标</returns>
		/// <seealso>ZYCommon.CaptureDragRectangleHandler</seealso>
		public System.Drawing.Rectangle CaptureDragRect
			(System.Drawing.Rectangle SourceRect ,
			int		DragStyle , 
			bool		DrawFocusRect ,
			double		WidthHeightRate ,
			bool		ShowSizeInfo ,
			CaptureDragRectangleHandler CallBack  )
		{
			Windows32.MSG msg	= new Windows32.MSG();
			System.Drawing.Point LastMousePos = System.Windows.Forms.Control.MousePosition ;
			System.Drawing.Rectangle CurrentRect = SourceRect ;
			System.Drawing.Rectangle DrawRect = System.Drawing.Rectangle.Empty ;

			if( ShowSizeInfo)
			{
				System.Drawing.Point InfoPos = System.Drawing.Point.Empty ;
				this.stpSize.Text = "鼠标拖拽开始改变对象大小" ;
			}
			while( Windows32.User32.WaitMessage() )
			{
				if(Windows32.User32.PeekMessage(ref msg, 0, 0, 0, (int)Windows32.PeekMessageFlags.PM_NOREMOVE)==false)
					break;
				// 若当前消息为鼠标按键松开消息则退出循环
				if( Windows32.User32.isMouseUpMessage( msg.message ))
					break;
				if( Windows32.User32.isMouseMoveMessage( msg.message ))
				{
					// 若为鼠标移动消息则进行处理
					System.Drawing.Point MousePos = System.Windows.Forms.Control.MousePosition ;
					if( LastMousePos.Equals( MousePos)==false)
					{
						// 计算位移
						int dx = MousePos.X - LastMousePos.X ;
						int dy = MousePos.Y - LastMousePos.Y ;
						LastMousePos = MousePos ;
						System.Drawing.Point OldPos = CurrentRect.Location ;
						// 中间
						if(DragStyle == -1 )
							CurrentRect.Offset(dx,dy);
						// 左边
						if(DragStyle == 0 || DragStyle == 7 || DragStyle == 6)
						{
							CurrentRect.Offset(dx,0);
							CurrentRect.Width = CurrentRect.Width - dx;
						}
						// 顶边
						if(DragStyle == 0 || DragStyle == 1 || DragStyle == 2)
						{
							CurrentRect.Offset(0,dy);
							CurrentRect.Height = CurrentRect.Height -dy;
						}
						// 右边
						if(DragStyle == 2 || DragStyle == 3 || DragStyle == 4 )
						{
							CurrentRect.Width = CurrentRect.Width + dx;
						}
						// 底边
						if(DragStyle == 4 || DragStyle == 5 || DragStyle == 6 )
						{
							CurrentRect.Height = CurrentRect.Height + dy;
							//if( DragStyle == 
						}
						if( CallBack != null)
						{
							if( CallBack(SourceRect,ref CurrentRect, DragStyle) == false)
							{
								if( DrawRect.IsEmpty == false )
								{
									// 擦除可逆转矩形
									System.Windows.Forms.ControlPaint.DrawReversibleFrame
										( DrawRect ,
										System.Drawing.Color.SkyBlue   ,
										System.Windows.Forms.FrameStyle.Dashed  );
								}
								bolCaptureMouse = false;
								return System.Drawing.Rectangle.Empty ;
							}
						}
						if( WidthHeightRate >= 0.1)
						{
							if( DragStyle == 1 || DragStyle == 5 )
							{
								CurrentRect.Width = (int) ( CurrentRect.Height * WidthHeightRate );
							}
							else
							{
								int OldTop = CurrentRect.Top ;
								int OldBottom = CurrentRect.Bottom ;
								CurrentRect.Height = (int)( CurrentRect.Width / WidthHeightRate ) ;
								if( DragStyle == 6 || DragStyle == 4 )
									CurrentRect.Y  = OldTop ;
								else
									CurrentRect.Y = OldBottom - CurrentRect.Height ;
							}
						}
						if( DrawFocusRect )
						{
							// 绘制可逆转矩形
							if( DrawRect.IsEmpty == false )
							{
								System.Windows.Forms.ControlPaint.DrawReversibleFrame
									( DrawRect ,
									System.Drawing.Color.SkyBlue   ,
									System.Windows.Forms.FrameStyle.Dashed  );
							}
							else
							{
								//DrawRect.Location = this.ViewPointToScreen( SourceRect.X , SourceRect.Y );
							}
							
							DrawRect.Offset( CurrentRect.X - OldPos.X , CurrentRect.Y - OldPos.Y );
							//DrawRect.X += ( CurrentRect.X - OldPos.X);
							//DrawRect.Y += ( CurrentRect.Y - OldPos.Y );
							//DrawRect.Location = this.ViewPointToScreen( CurrentRect.X , CurrentRect.Y );
							DrawRect.Size = CurrentRect.Size ;
							DrawRect = CurrentRect;
							if( ShowSizeInfo  )
							{
								this.stpSize.Text = "宽度:" + CurrentRect.Width + " 高度:" + CurrentRect.Height  ;
								//this.myStatus.Refresh();
							}
							System.Windows.Forms.ControlPaint.DrawReversibleFrame
								( DrawRect ,
								System.Drawing.Color.SkyBlue   ,
								System.Windows.Forms.FrameStyle.Dashed  );
							//myToolTipCtl.SetToolTip( this , "宽度:" + CurrentRect.Width  + " 高度:" + CurrentRect.Height );
							//myToolTipCtl.Active = true;
						}
					}// if Equals
				}
				Windows32.User32.GetMessage(ref msg, 0, 0, 0);
			}// while
			if( DrawRect.IsEmpty == false )
			{
				// 擦除可逆转矩形
				System.Windows.Forms.ControlPaint.DrawReversibleFrame
					( DrawRect ,
					System.Drawing.Color.SkyBlue   ,
					System.Windows.Forms.FrameStyle.Dashed  );
			}
			bolCaptureMouse = false;
			if( CurrentRect.Equals( SourceRect ))
				return System.Drawing.Rectangle.Empty ;
			else
				return CurrentRect ;
		}// CaptureDragRect
		#endregion



	}//public class frmEditImage

	//*********************************************************************************************
	//*********************************************************************************************
	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 图象编辑的动作的基本类
	/// </summary>
	public abstract class ImageEditAction
	{
		/// <summary>
		/// 包含对象的方框对象
		/// </summary>
		protected System.Drawing.Rectangle myBounds = System.Drawing.Rectangle.Empty ;
		/// <summary>
		/// 包含对象的方框对象
		/// </summary>
		public virtual System.Drawing.Rectangle Bounds
		{
			get{ return myBounds;}
			set{ myBounds = value;}
		}

		public virtual bool DesignChangeBounds( System.Drawing.Rectangle NewBounds)
		{
			Bounds = NewBounds ;
			return true;
		}
		public virtual string ActionName
		{
			get{ return null ;}
		}
		public virtual bool FromXML( System.Xml.XmlElement myElement )
		{
			return false;
		}
		public virtual bool ToXML( System.Xml.XmlElement myElement )
		{
			return false;
		}
		public virtual bool Execute( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRect )
		{
			return false;
		}
		public virtual bool IsVisible( System.Drawing.Rectangle ClipRect)
		{
			return true;
		}
		public virtual bool Selectable
		{
			get{ return true ;}
		}
		public bool BoundsFromXML( System.Xml.XmlElement myElement )
		{
			myBounds = new System.Drawing.Rectangle(
				Convert.ToInt32( myElement.GetAttribute("left")) , 
				Convert.ToInt32( myElement.GetAttribute("top")), 
				Convert.ToInt32( myElement.GetAttribute("width")) ,
				Convert.ToInt32( myElement.GetAttribute("height")));
			return true;
		}
		public bool BoundsToXML( System.Xml.XmlElement myElement )
		{
			myElement.SetAttribute("left"	, myBounds.Left.ToString());
			myElement.SetAttribute("top"	, myBounds.Top.ToString());
			myElement.SetAttribute("width"	, myBounds.Width.ToString());
			myElement.SetAttribute("height" , myBounds.Height.ToString());
			return true;
		}
		public System.Drawing.Rectangle[] GetDragRects()
		{
			return DocumentView.GetDragRects( this.Bounds , 4 , true );
		}
	}//public abstract class ImageEditAction

	//*********************************************************************************************
	//*********************************************************************************************
	
	public class ImageRectSelectAction : ImageEditAction
	{
		public override string ActionName
		{
			get{ return "rectselect"; }
		}
		public override bool Selectable
		{
			get{ return false; }
		}

	}

	//*********************************************************************************************
	//*********************************************************************************************

	public class ImageTextAction : ImageEditAction
	{
		public string	FontName = "宋体";
		public float	FontSize = 10 ;
		public bool		Bold	= false;
		public bool		Italic	= false;
		public string	Text	= null;
		public System.Drawing.Color ForeColor = System.Drawing.Color.Black ;
		public System.Drawing.Rectangle Rect = System.Drawing.Rectangle.Empty ;
		public override string ActionName
		{
			get { return "text"; }
		}
		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if( Text != null && Text.Length > 0 )
			{
				using(System.Drawing.Font myFont = new System.Drawing.Font( FontName , FontSize , DocumentView.GetFontStyle( Bold , Italic , false)))
				{
					using(System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush( ForeColor))
					{
						using(System.Drawing.StringFormat myFormat = new System.Drawing.StringFormat( ))
						{
							myFormat.Alignment = System.Drawing.StringAlignment.Center ;
							myFormat.LineAlignment = System.Drawing.StringAlignment.Center ;
							g.DrawString( Text , myFont , myBrush ,  new System.Drawing.RectangleF( myBounds.Left , myBounds.Top , myBounds.Width , myBounds.Height ) , myFormat );
						}//using
					}//using
				}//using
			}//if
			return true;
		}
	}//public class ImageTextAction

	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 计算距离的动作
	/// </summary>
	public class ImageDistanceAction : ImageEditAction
	{
		public System.Drawing.Point p1 = System.Drawing.Point.Empty ;
		public System.Drawing.Point p2 = System.Drawing.Point.Empty ;
		public double XRate = 1 ;
		public double YRate = 1 ;
		public System.Drawing.Point DrawFix = System.Drawing.Point.Empty ;

		public void Clear()
		{
			p1 = System.Drawing.Point.Empty ;
			p2 = System.Drawing.Point.Empty ;
		}
		public double Distance
		{
			get
			{
				if( XRate * YRate != 0)
				{
					double dx = ( p1.X - p2.X ) / XRate ;
					double dy = ( p1.Y - p2.Y ) / YRate ;
					return System.Math.Sqrt( dx * dx + dy * dy );
				}
				else
					return 0 ;
			}
		}
		public override Rectangle Bounds
		{
			get{ return RectangleObject.GetRectangle( p1 , p2 ) ;}
			set{ ; }
		}
		public override string ActionName
		{
			get{ return "distance"; }
		}
		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			int hDC = g.GetHdc().ToInt32();
			int OR = Windows32.Gdi32.GetROP2( hDC );
			int intPen = Windows32.Gdi32.CreatePen( 0 , 1 , 0xffffff );
			int OldPen = Windows32.Gdi32.SelectObject( hDC , intPen );
			Windows32.Gdi32.SetROP2( hDC , (int) Windows32.DCRasterOperations.R2_XORPEN  );

			Windows32.Gdi32.MoveToEx( hDC , p1.X + DrawFix.X  , p1.Y + DrawFix.Y  , 0 );
			Windows32.Gdi32.LineTo( hDC  , p2.X + DrawFix.X  , p2.Y + DrawFix.Y  );
			if( this.Distance > 1 )
			{
				double dblLen =  this.Distance ;
				int vWidth  = ( p2.X - p1.X )  ;
				int vHeight = ( p2.Y - p1.Y )  ;
				int dx = (int)( vHeight * 20 / ( dblLen * XRate )) ;
				int dy = (int)( vWidth  * 20 / ( dblLen * YRate ));
				for(double dblCount = 0 ; dblCount <= dblLen ; dblCount += 1 )
				{
					double x = DrawFix.X + p1.X + ( dblCount * vWidth / dblLen )   ;
					double y = DrawFix.Y + p1.Y + ( dblCount * vHeight / dblLen )   ;
					Windows32.Gdi32.MoveToEx( hDC , (int)x , (int)y , 0) ;
					Windows32.Gdi32.LineTo( hDC , (int)x + dx , (int)y - dy );
				}
			}
			Windows32.Gdi32.SelectObject( hDC , OldPen );
			Windows32.Gdi32.DeleteObject( intPen );
			Windows32.Gdi32.SetROP2( hDC , OR );
			g.ReleaseHdc( new System.IntPtr( hDC ));
			return true;
		}
	}//public class ImageDistanceAction : ImageEditAction

	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 计算面积的动作
	/// </summary>
	public class ImageAreaAction : ImageEditAction
	{
		private System.Drawing.Point[] myPoints = null;
		private double dblContainArea = 0 ;
		public System.Drawing.Point DrawFix = System.Drawing.Point.Empty ;

		///<summary>
		//// X轴方向每单位距离象素个数
		///</summary>
		private double    dblXRate        = 0 ;

		///<summary>
		//// Y轴方向每单位距离象素个数
		///</summary>
		private double    dblYRate        = 0 ;
 

		///<summary>
		//// X轴方向每单位距离象素个数
		///</summary>
		public double XRate
		{
			get{ return dblXRate ;}
			set{ dblXRate = value;}
		}

		///<summary>
		//// Y轴方向每单位距离象素个数
		///</summary>
		public double YRate
		{
			get{ return dblYRate ;}
			set{ dblYRate = value;}
		}

		public System.Drawing.Point[] Points
		{
			get{ return myPoints ;}
			set
			{
				myPoints = value; 
				dblContainArea = CalcuteArea();
				myBounds = PointBuffer.GetBounds( myPoints ) ; 
			}
		}
		public override Rectangle Bounds
		{
			get	{ return myBounds ;	}
			set	{ ;	}
		}
		public double ContainArea
		{
			get{ return dblContainArea ;}
		}
		/// <summary>
		/// 计算多边形的面积
		/// </summary>
		/// <returns></returns>
		public double CalcuteArea()
		{
			if( myPoints == null || myPoints.Length < 3 || dblXRate == 0 || dblYRate == 0 )
				return 0 ;
			double dblArea = 0 ;
			for(int iCount = 0 ; iCount < myPoints.Length - 2; iCount ++ )
			{
				double dxArea = myPoints[0].X * myPoints[iCount].Y ;
				dxArea += myPoints[iCount].X * myPoints[iCount+1].Y  ;
				dxArea += myPoints[iCount+1].X * myPoints[0].Y ;
				dxArea -= myPoints[0].X * myPoints[iCount+1].Y ;
				dxArea -= myPoints[iCount].X * myPoints[0].Y ;
				dxArea -= myPoints[iCount+1].X * myPoints[iCount].Y ;

				dblArea += dxArea / 2.0 ;
			}
			return System.Math.Abs( dblArea / ( dblXRate * dblYRate ) );
		}

		/// <summary>
		/// 计算BMP图片中选中区域的颜色的平均值
		/// </summary>
		/// <param name="myBMP">BMP图片对象</param>
		/// <param name="vProgress">进度处理委托</param>
		/// <returns>平均颜色,若计算错误则返回黑色</returns>
		public System.Drawing.Color CalcuteAvgColor( System.Drawing.Bitmap myBMP , ProgressHandler vProgress )
		{
			int[] intReturn = new int[3];
			if( myPoints != null && myPoints.Length > 3 )
			{
				System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
				myPath.AddPolygon( myPoints);
				double RCount = 0 ;
				double GCount = 0 ;
				double BCount = 0 ;
				int PointCount = 0 ;
				System.Drawing.Rectangle myBounds = RectangleObject.ConvertToRectangle( myPath.GetBounds());
				//myBounds.Offset( 0 - DrawFix.X , 0 - DrawFix.Y );
				myBounds = System.Drawing.Rectangle.Intersect( myBounds , new System.Drawing.Rectangle( 0 , 0 , myBMP.Size.Width , myBMP.Size.Height ));
				int XMax = myBounds.Right ;
				int YMax = myBounds.Bottom ;
				for(int x = myBounds.Left ; x < XMax ; x ++)
				{
					for(int y = myBounds.Top ; y < YMax ; y ++ )
					{
						if( myPath.IsVisible( x  , y ))
						{
							System.Drawing.Color intColor = myBMP.GetPixel( x , y );
							RCount += intColor.R ;
							GCount += intColor.G ;
							BCount += intColor.B ;
							PointCount ++ ;
						}
					}
					if( vProgress != null)
					{
						vProgress( x - myBounds.Left , XMax - myBounds.Left );
					}
				}
				if( PointCount > 0 )
				{
					return System.Drawing.Color.FromArgb( (int)( RCount / PointCount) , (int)( GCount / PointCount),(int)( BCount / PointCount));
				}
			}
			return System.Drawing.Color.Black ;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if( myPoints != null && myPoints.Length > 3 && g != null )
			{
				int hDC = g.GetHdc().ToInt32();
				int OR = Windows32.Gdi32.GetROP2( hDC );
				int intPen = Windows32.Gdi32.CreatePen( 0 , 1 , 0xffffff );
				int OldPen = Windows32.Gdi32.SelectObject( hDC , intPen );
				Windows32.Gdi32.SetROP2( hDC , (int) Windows32.DCRasterOperations.R2_XORPEN  );
				Windows32.Gdi32.MoveToEx( hDC , myPoints[0].X + DrawFix.X  , myPoints[0].Y + DrawFix.Y  , 0 );
				for(int iCount = 1 ; iCount < myPoints.Length  ; iCount ++ )
				{
					Windows32.Gdi32.LineTo( hDC , myPoints[iCount].X + DrawFix.X   , myPoints[iCount].Y + DrawFix.Y  );
				}
				Windows32.Gdi32.SelectObject( hDC , OldPen );
				Windows32.Gdi32.DeleteObject( intPen );
				Windows32.Gdi32.SetROP2( hDC , OR );
				g.ReleaseHdc( new System.IntPtr( hDC ));
				return true;
			}
			return false;
		}
	}//public class ImageAreaAction

	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 封闭多变形的编辑动作对象
	/// </summary>
	public class ImagePolyAction : ImageEditAction
	{
		public System.Drawing.Color ForeColor = System.Drawing.Color.Black ;
		public int LineWidth = 1 ;
		private System.Drawing.Point[] myPoints = null;
		public System.Drawing.Point[] Points
		{
			get{ return myPoints ;}
			set{ myPoints = value; myBounds = PointBuffer.GetBounds( value );}
		}

		public override Rectangle Bounds
		{
			get{ return myBounds ;}
			set{ ;		}
		}
		public override bool DesignChangeBounds(Rectangle NewBounds)
		{
			System.Drawing.Rectangle OldBounds = this.Bounds ;
			int dx = NewBounds.X - OldBounds.X ;
			int dy = NewBounds.Y - OldBounds.Y ;
			for(int iCount = 0 ; iCount < myPoints.Length ; iCount ++ )
			{
				myPoints[iCount].Offset( dx , dy );
			}
			myBounds = PointBuffer.GetBounds( myPoints );
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if( Points != null)
			{
				using(System.Drawing.Pen myPen = new System.Drawing.Pen( ForeColor , LineWidth ))
				{
					g.DrawLines( myPen , Points );
				}
				return true;
			}
			return false;
		}
		public override string ActionName
		{
			get{ return "poly"; }
		}
		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			myElement.SetAttribute("color" , StringCommon.ColorToHtml( ForeColor ));
			myElement.SetAttribute("linewidth" , LineWidth.ToString());
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			for(int iCount = 0 ; iCount < Points.Length ; iCount ++ )
			{
				myStr.Append( Points[iCount].X.ToString());
				myStr.Append(",");
				myStr.Append( Points[iCount].Y.ToString());
				if( iCount != Points.Length - 1 )
					myStr.Append(",");
			}
			myElement.SetAttribute("points" , myStr.ToString());
			return true;
		}

		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			ForeColor = StringCommon.ColorFromHtml( myElement.GetAttribute("color") , System.Drawing.Color.Black );
			LineWidth = Convert.ToInt32( myElement.GetAttribute("linewidth"));
			string strPoint = myElement.GetAttribute("points");
			string[] strItems = strPoint.Split(",".ToCharArray());
			Points = null;
			if( strItems != null && strItems.Length > 0 )
			{
                //TODO:这里加了一个Convert.ToDouble()
				Points = new Point[ (int) System.Math.Floor( Convert.ToDouble(strItems.Length / 2) )  ];
				for(int iCount = 0 ; iCount < Points.Length ; iCount ++ )
				{
					Points[iCount].X = Convert.ToInt32( strItems[ iCount * 2 ] );
					Points[iCount].Y = Convert.ToInt32( strItems[ iCount * 2 + 1 ]);
				}
				myBounds = PointBuffer.GetBounds( Points );
			}
			return true;
		}
	}//public class ImagePolyAction

	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 画笔动作对象
	/// </summary>
	public class ImagePenAction : ImageEditAction
	{
		public System.Drawing.Color ForeColor = System.Drawing.Color.Black ;
		public int LineWidth = 1 ;
		private System.Drawing.Point[] myPoints = null;
		public System.Drawing.Point[] Points
		{
			get{ return myPoints ;}
			set{ myPoints = value; myBounds = PointBuffer.GetBounds( value );}
		}
		public override Rectangle Bounds
		{
			get{ return myBounds ;}
			set{ ;	}
		}
		public override bool DesignChangeBounds(Rectangle NewBounds)
		{
			System.Drawing.Rectangle OldBounds = this.Bounds ;
			int dx = NewBounds.X - OldBounds.X ;
			int dy = NewBounds.Y - OldBounds.Y ;
			for(int iCount = 0 ; iCount < myPoints.Length ; iCount ++ )
			{
				myPoints[iCount].Offset( dx , dy );
			}
			myBounds = PointBuffer.GetBounds( myPoints );
			return true;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if( Points != null)
			{
				using(System.Drawing.Pen myPen = new System.Drawing.Pen( ForeColor , LineWidth ))
				{
					g.DrawLines( myPen , Points );
				}
				return true;
			}
			return false;
		}
		public override string ActionName
		{
			get{ return "point"; }
		}
		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			myElement.SetAttribute("color" , StringCommon.ColorToHtml( ForeColor ));
			myElement.SetAttribute("linewidth" , LineWidth.ToString());
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			for(int iCount = 0 ; iCount < Points.Length ; iCount ++ )
			{
				myStr.Append( Points[iCount].X.ToString());
				myStr.Append(",");
				myStr.Append( Points[iCount].Y.ToString());
				if( iCount != Points.Length - 1 )
					myStr.Append(",");
			}
			myElement.SetAttribute("points" , myStr.ToString());
			return true;
		}
		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			ForeColor = StringCommon.ColorFromHtml( myElement.GetAttribute("color") , System.Drawing.Color.Black );
			LineWidth = Convert.ToInt32( myElement.GetAttribute("linewidth"));
			string strPoint = myElement.GetAttribute("points");
			string[] strItems = strPoint.Split(",".ToCharArray());
			Points = null;
			if( strItems != null && strItems.Length > 0 )
			{
                //TODO:这里加了一个Convert.ToDouble()
				Points = new Point[ (int) System.Math.Floor( Convert.ToDouble(strItems.Length / 2) )  ];
				for(int iCount = 0 ; iCount < Points.Length ; iCount ++ )
				{
					Points[iCount].X = Convert.ToInt32( strItems[ iCount * 2 ] );
					Points[iCount].Y = Convert.ToInt32( strItems[ iCount * 2 + 1 ]);
				}
				myBounds = PointBuffer.GetBounds( Points );
			}
			return true;
		}
	}//public class ImagePenAction

	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 绘制并填充矩形区域的动作
	/// </summary>
	public class ImageRectAndFillAction : ImageEditAction
	{
		public System.Drawing.Color BorderColor = System.Drawing.Color.Black ;
		public System.Drawing.Color FillColor = System.Drawing.Color.Black ;
		public int BorderWidth = 1 ;

		public override string ActionName
		{
			get{ return "rectandfill"; }
		}
		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			base.BoundsFromXML( myElement );
			BorderColor = StringCommon.ColorFromHtml( myElement.GetAttribute("bordercolor" ) ,System.Drawing.Color.Black );
			FillColor = StringCommon.ColorFromHtml( myElement.GetAttribute("fillcolor") , System.Drawing.Color.Black );
			BorderWidth = Convert.ToInt32( myElement.GetAttribute("borderwidth"));
			return true;
		}
		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			base.BoundsToXML( myElement );
			myElement.SetAttribute("bordercolor" , StringCommon.ColorToHtml( BorderColor ));
			myElement.SetAttribute("fillcolor" , StringCommon.ColorToHtml( FillColor ));
			myElement.SetAttribute("borderwidth" , BorderWidth.ToString());
			return true;
		}
		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			using(System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush( FillColor ))
			{
				g.FillRectangle( myBrush , myBounds );
			}
			using(System.Drawing.Pen myPen = new System.Drawing.Pen( BorderColor , BorderWidth ))
			{
				g.DrawRectangle( myPen , myBounds );
			}
			return true;
		}
	}//public class ImageRectAndFillAction

	//*********************************************************************************************
	//*********************************************************************************************


	/// <summary>
	/// 填充一个矩形区域的动作
	/// </summary>
	public class ImageFillRectAction : ImageEditAction
	{
		public System.Drawing.Color FillColor = System.Drawing.Color.Black ;
		public override string ActionName
		{
			get
			{
				return "fillRect";
			}
		}
		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			base.BoundsFromXML( myElement );
			FillColor = StringCommon.ColorFromHtml( myElement.GetAttribute("color") , System.Drawing.Color.Black );
			return true;
		}
		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			base.BoundsToXML( myElement );
			myElement.SetAttribute("color" , StringCommon.ColorToHtml( FillColor ));
			return true;
		}
		public override bool Execute( Graphics g, Rectangle ClipRect)
		{
			using(System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush( FillColor ))
			{
				g.FillRectangle( myBrush , myBounds );
			}
			return true;
		}
	}
	
	//*********************************************************************************************
	//*********************************************************************************************


	/// <summary>
	/// 绘制方框动作对象
	/// </summary>
	public class ImageRectAction : ImageEditAction
	{
		public System.Drawing.Color BorderColor = System.Drawing.Color.Black ;
		public int BorderWidth = 1 ;
		public override string ActionName
		{
			get{ return "rect"; }
		}
		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			base.BoundsFromXML( myElement );
			BorderColor = StringCommon.ColorFromHtml( myElement.GetAttribute("color") , System.Drawing.Color.Black );
			BorderWidth = Convert.ToInt32( myElement.GetAttribute("borderwidth"));
			return true;
		}
		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			base.BoundsToXML( myElement );
			myElement.SetAttribute("color" , StringCommon.ColorToHtml( BorderColor ));
			myElement.SetAttribute("borderwidth" , BorderWidth.ToString());
			return true;
		}
		public override bool Execute( Graphics g , Rectangle ClipRect)
		{
			using(System.Drawing.Pen myPen = new System.Drawing.Pen( BorderColor , BorderWidth ))
			{
				g.DrawRectangle( myPen , myBounds );
			}
			return true;
		}
	}// public class ImageRectAction : ImageEditAction

	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 线动作对象
	/// </summary>
	public class ImageLineAction : ImageEditAction
	{
		public System.Drawing.Point p1 ;
		public System.Drawing.Point p2 ;
		public System.Drawing.Color Color = System.Drawing.Color.Black ;
		public bool Arrow = false ;
		public int Width = 1 ;
		public override Rectangle Bounds
		{
			get{ return RectangleObject.GetRectangle(p1 , p2 );	}
			set{  ; }
		}
		public override bool DesignChangeBounds(Rectangle NewBounds)
		{
			System.Drawing.Rectangle OldBounds = this.Bounds ;
			p1 = RectangleObject.GetAcmePos ( NewBounds , RectangleObject.GetAcmeIndex( OldBounds , p1 ));
			p2 = RectangleObject.GetAcmePos ( NewBounds , RectangleObject.GetAcmeIndex( OldBounds , p2 ));
			return true;
		}
		public override string ActionName
		{
			get{ return "line"; }
		}
		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			p1 = new Point( Convert.ToInt32( myElement.GetAttribute("x1") ) , Convert.ToInt32( myElement.GetAttribute("y1")));
			p2 = new Point( Convert.ToInt32( myElement.GetAttribute("x2") ) , Convert.ToInt32( myElement.GetAttribute("y2")));
			Width = Convert.ToInt32( myElement.GetAttribute("width"));
			Color = StringCommon.ColorFromHtml( myElement.GetAttribute("color"), System.Drawing.Color.Black );
			Arrow = (myElement.GetAttribute("arrow") == "1" );
			return true;
		}

		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			myElement.SetAttribute("x1" , p1.X.ToString());
			myElement.SetAttribute("y1" , p1.Y.ToString());
			myElement.SetAttribute("x2" , p2.X.ToString());
			myElement.SetAttribute("y2" , p2.Y.ToString());
			myElement.SetAttribute("width" , Width.ToString());
			myElement.SetAttribute("color" , StringCommon.ColorToHtml( Color ));
			myElement.SetAttribute("arrow" , Arrow ? "1" : "0");
			return true;
		}
		public override bool Execute( Graphics g  , System.Drawing.Rectangle ClipRect)
		{
			using(System.Drawing.Pen myPen = new System.Drawing.Pen( Color , Width ))
			{
				if( Arrow )
				{
					using(System.Drawing.Drawing2D.AdjustableArrowCap myCap = new System.Drawing.Drawing2D.AdjustableArrowCap( 4 ,4))
					{
						myPen.CustomEndCap = myCap ;
						g.DrawLine( myPen , p1 , p2 );
					}
				}
				else
					g.DrawLine( myPen , p1 ,p2 );
			}
			return true;
		}
		public override bool IsVisible( Rectangle ClipRect)
		{
			return RectangleObject.GetRectangle(p1,p2).IntersectsWith( ClipRect );
		}
	}//public class ImageLineAction

	//*********************************************************************************************
	//*********************************************************************************************


	//*********************************************************************************************
	//*********************************************************************************************

	/// <summary>
	/// 圆角矩形对象
	/// </summary>
	public class RoundRectangle
	{
		///<summary>
		//// 左端位置
		///</summary>
		private int    intLeft     = 0 ;

		///<summary>
		//// 顶端位置
		///</summary>
		private int    intTop      = 0 ;

		///<summary>
		//// 宽度
		///</summary>
		private int    intWidth    = 0 ;

		///<summary>
		//// 高度
		///</summary>
		private int    intHeight   = 0 ;

		///<summary>
		//// 圆角半径
		///</summary>
		private int    intRadius   = 0 ;


		///<summary>
		//// 左端位置
		///</summary>
		public int Left
		{
			get{ return intLeft ;}
			set{ intLeft = value;}
		}

		///<summary>
		//// 顶端位置
		///</summary>
		public int Top
		{
			get{ return intTop ;}
			set{ intTop = value;}
		}

		///<summary>
		//// 宽度
		///</summary>
		public int Width
		{
			get{ return intWidth ;}
			set{ intWidth = value;}
		}

		///<summary>
		//// 高度
		///</summary>
		public int Height
		{
			get{ return intHeight ;}
			set{ intHeight = value;}
		}

		///<summary>
		//// 圆角半径
		///</summary>
		public int Radius
		{
			get{ return intRadius ;}
			set{ intRadius = value;}
		}
	}//public class RoundRectangle

	public class ImageEditControl : System.Windows.Forms.UserControl 
	{
		protected override System.Windows.Forms.CreateParams CreateParams
		{
			get
			{
				System.Windows.Forms.CreateParams p = base.CreateParams ;
				p.ExStyle = p.ExStyle | (int)Windows32.WindowExStyles.WS_EX_CLIENTEDGE ;
				return p;
			}
		}
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			System.Drawing.Point p = this.AutoScrollPosition ;
			p.X = 0 - p.X ;//+ e.Delta * 10;
			p.Y = 0 - p.Y - e.Delta ;
			this.AutoScrollPosition = p ;
			base.OnMouseWheel (e);
		}

	}//public class ImageEditControl
}