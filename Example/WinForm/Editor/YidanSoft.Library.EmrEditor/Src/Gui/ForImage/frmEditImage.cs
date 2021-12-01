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
	/// ��ͼ��༭������
	/// </summary>
	public class frmEditImage : System.Windows.Forms.Form
	{
		private ImageEditControl   pnlImage;
		private System.Windows.Forms.Panel pnlToolBar;
		private System.Windows.Forms.Splitter splitter1;
		/// <summary>
		/// ����������������
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
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			InitClass();
		}



		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.stpMain.Text = "����";
			this.stpMain.Width = 384;
			// 
			// stpSize
			// 
			this.stpSize.Text = "��С";
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
			this.Text = "ͼ��༭";
			this.Load += new System.EventHandler(this.frmEditImage_Load);
			this.pnlToolBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stpMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stpSize)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// ��ť�����
		/// </summary>
		private ZYButtonGroup		myButtons = new ZYButtonGroup();
		/// <summary>
		/// ��ɫѡ�����
		/// </summary>
		private ZYColorSelector		myColorSelector = new ZYColorSelector();
		/// <summary>
		/// �༭��BMPͼƬ����
		/// </summary>
		private System.Drawing.Bitmap myContentBMP = null; 
		/// <summary>
		/// �����Ƿ������������
		/// </summary>
		private bool				bolCaptureMouse = false;
		/// <summary>
		/// ���еĻ�ͼ�����ļ���
		/// </summary>
		private System.Collections.ArrayList myActions = new ArrayList();
		/// <summary>
		/// �㻺����
		/// </summary>
		private PointBuffer			myPointBuffer = new PointBuffer();
		/// <summary>
		/// ��������Ķ�������
		/// </summary>
		private ImageAreaAction		myAreaAction  = new ImageAreaAction();
		/// <summary>
		/// �������Ķ�������
		/// </summary>
		private ImageDistanceAction myDisAction = new ImageDistanceAction();
		/// <summary>
		/// ���һ�������λ��
		/// </summary>
		private System.Drawing.Point LastMousePos = System.Drawing.Point.Empty ;

		/// <summary>
		/// ��ǰѡ�еĶ���
		/// </summary>
		private ImageEditAction myCurrentAction = null;

		///<summary>
		//// X�᷽��ÿ��λ�������ظ���
		///</summary>
		private double    dblXRate        = 37.8 ;

		///<summary>
		//// Y�᷽��ÿ��λ�������ظ���
		///</summary>
		private double    dblYRate        = 37.8 ;

		///<summary>
		//// ��λ�ı�
		///</summary>
		private string    strUnitString   = "����" ;

		
		///<summary>
		//// X�᷽��ÿ��λ�������ظ���
		///</summary>
		public double XRate
		{
			get{ return dblXRate ;}
			set{ dblXRate = value;}
		}

		///<summary>
		//// Y�᷽��ÿ��λ�������ظ���
		///</summary>
		public double YRate
		{
			get{ return dblYRate ;}
			set{ dblYRate = value;}
		}

		///<summary>
		//// ��λ�ı�
		///</summary>
		public string UnitString
		{
			get{ return strUnitString ;}
			set{ strUnitString = value;}
		}


		/// <summary>
		/// ��ǰ�߿��
		/// </summary>
		private int intLineWidth = 1;

		/// <summary>
		/// �����ı�ʱ�Ƿ���͸����
		/// </summary>
		//private bool bolTextTransparent = false;

		/// <summary>
		/// ��ͼ�����й��
		/// </summary>
		private System.Windows.Forms.Cursor myClientCursor = System.Windows.Forms.Cursors.Default ;
	 
		
		public enum ImageEditModeConst
		{
			/// <summary>
			/// �����ڱ༭״̬�������ƶ�ͼƬ
			/// </summary>
			Edit_None = 0 , 
			/// <summary>
			/// ����ѡ��
			/// </summary>
			Edit_RandSelect = 1 ,
			/// <summary>
			/// ����ѡ��
			/// </summary>
			Edit_RectSelect = 2,
			/// <summary>
			/// ��Ƥ��
			/// </summary>
			Edit_Rubber = 3 ,
			/// <summary>
			/// �����ɫ
			/// </summary>
			Edit_Fill = 4 ,
			/// <summary>
			/// ѡȡ��ɫ
			/// </summary>
			Edit_ColorPick = 5 ,
			/// <summary>
			/// ����ͼƬ
			/// </summary>
			Edit_Zoom = 6 ,
			/// <summary>
			/// ����
			/// </summary>
			Edit_Pen = 7 ,
			/// <summary>
			/// ��ˢ
			/// </summary>
			Edit_Brush = 8 ,
			/// <summary>
			/// ����
			/// </summary>
			Edit_Fog = 9 ,
			/// <summary>
			/// ����
			/// </summary>
			Edit_Text= 10 ,
			/// <summary>
			/// ֱ��
			/// </summary>
			Edit_Line = 11 ,
			/// <summary>
			/// ����
			/// </summary>
			Edit_Curve = 12 ,
			/// <summary>
			/// ���α߿�
			/// </summary>
			Edit_Rect = 13 ,
			/// <summary>
			/// ����α߿�
			/// </summary>
			Edit_Poly = 14,
			/// <summary>
			/// Բ������Բ
			/// </summary>
			Edit_Arc = 15 ,
			/// <summary>
			/// Բ�Ǿ���
			/// </summary>
			Edit_RRect = 16 ,
			/// <summary>
			/// ���Ʋ�������
			/// </summary>
			Edit_RectAndFill = 17 ,
			/// <summary>
			/// ������
			/// </summary>
			Edit_FillRect = 18 ,
			/// <summary>
			/// ���Ʋ����Բ�Ǿ���
			/// </summary>
			Edit_RRectAndFill = 19 , 
			/// <summary>
			/// �������
			/// </summary>
			Edit_Area = 25 ,
			/// <summary>
			/// �������
			/// </summary>
			Edit_Distance = 26 ,
			/// <summary>
			/// �����ض�����RGBƽ��ֵ
			/// </summary>
			Edit_RGB = 27 ,
			/// <summary>
			/// ����ͷ���߶�
			/// </summary>
			Edit_ArrowLine = 28 

		}//public enum ImageEditModeConst
		
		/// <summary>
		/// ��ʼ���༭��
		/// </summary>
		public void InitClass()
		{
			// ���ع�����
			myButtons.BindControl(this.pnlToolBar );
			myButtons.DefaultButtonHeight = 25 ;
			myButtons.DefaultButtonWidth = 25 ;
			myButtons.OnClick +=new ZYButtonClickHandler(myButtons_OnClick);
			System.Drawing.Bitmap myBMP =  (System.Drawing.Bitmap) this.picToolbar.Image ;// System.Drawing.Image.FromFile(@"D:\source6\zyclinic\EMRTextDocumentLib\ͼ��\imgtools.bmp");
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
			// ��������ɫѡ����
			myColorSelector.BindControl( this.pnlColorList );
		}

		/// <summary>
		/// ����BMPͼƬ�ļ�
		/// </summary>
		/// <param name="strSrc">ͼƬ�ļ���</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public bool LoadBMPFile( string strSrc)
		{
			this.ContentBMP = (System.Drawing.Bitmap) System.Drawing.Image.FromFile( strSrc );
			return true;
		}
		 
		/// <summary>
		/// ����,���ع��༭��BMPͼƬ����
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
					this.stpMain.Text = "��ʽ:" + myContentBMP.PixelFormat + " ���:" + myContentBMP.Size.Width + " �߶�:" + myContentBMP.Size.Height ;
				}
			}
		}

		/// <summary>
		/// ���ر༭�����BMPͼƬ����
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
		/// ͼƬ�Ƿ����ı�
		/// </summary>
		public bool BMPChanged
		{
			get{ return myActions.Count > 0 ;}
		}
 
		#region �������¼����� ******************************************************************

		/// <summary>
		/// ����������С�ı��¼�����
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
		/// ���������»����¼�����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( myContentBMP == null)
				return ;
			// ����������������
			System.Drawing.Rectangle myRect = System.Drawing.Rectangle.Intersect( e.ClipRectangle  , this.ViewRect );
			System.Drawing.Graphics myGraph = e.Graphics ;
			System.Drawing.Point Origin = this.ViewPointToClient(0,0);
			myGraph.SetClip( this.ViewRect );
			if( myRect.IsEmpty == false)
			{
				// ������ͼ��
				myGraph.DrawImage
					( myContentBMP , 
					myRect , 
					new System.Drawing.Rectangle( PointToView( myRect.Location ) , myRect.Size ) , 
					System.Drawing.GraphicsUnit.Pixel );
				System.Drawing.Rectangle ClipRect = e.ClipRectangle ;
				ClipRect.Location = this.PointToView( ClipRect.Location );
				myGraph.TranslateTransform( this.ViewRect.Left , this.ViewRect.Top );
				// ���»������еĻ�ͼ����
				foreach(ImageEditAction a in this.myActions )
				{
					if( a.Bounds.IntersectsWith( ClipRect ))
						a.Execute( myGraph , ClipRect );
				}
				if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Area )
				{
					// ���Ƽ�������Ķ���
					System.Drawing.Point PointFix = this.ViewPointToClient( 0 , 0 );
					myAreaAction.DrawFix = this.ViewRect.Location ;
					myAreaAction.Execute( myGraph , ClipRect );
				}
				else if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Distance )
				{
					// ���Ƽ������Ķ���
					myDisAction.XRate = dblXRate ;
					myDisAction.YRate = dblYRate ;
					myDisAction.DrawFix = this.ViewRect.Location ;
					myDisAction.Execute( myGraph , ClipRect );
				}
				else
				{
					// �������еĵ�
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
			// ������ͼ������Χ�ı߿�
			myRect = this.ViewRect ;
			myGraph.DrawRectangle( System.Drawing.Pens.Black , myRect );
			System.Drawing.Rectangle[] DragRects = DocumentView.GetDragRects( myRect , 4 , false );
			for(int iCount = 0 ; iCount < DragRects.Length ; iCount ++ )
			{
				DocumentView.DrawDragRect( myGraph , DragRects[iCount] , ( iCount == 3 || iCount == 4 || iCount == 5 ) );
			}
		}

		/// <summary>
		/// ���������갴���¼�����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ��õ�ǰ���λ��
			System.Drawing.Point p = new Point(e.X , e.Y );
			System.Drawing.Point p1 = System.Windows.Forms.Control.MousePosition ;
			System.Drawing.Point p2 = System.Drawing.Point.Empty ;
			
			// ����굱ǰλ������ͼ�����ڲ�����������
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
						// ѡȡ��ɫ
						myColorSelector.CurrentColor = pnlList.BackColor ;
						pnlList.BackColor = this.BackColor ;
						myButtons.CommandID = 0 ;
						break;
					case (int) ImageEditModeConst.Edit_Line :
						// ����ֱ��
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
						// ���ƴ���ͷ��ֱ��
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
						// ���ƾ��η���
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
						// ����������
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
						// ����
						bolCaptureMouse = true;
						break;
					case (int) ImageEditModeConst.Edit_RectAndFill :
						// ���Ʋ�����������
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
						// ���Ʒ�յĶ����
						myPointBuffer.Add( this.ScreenPointToView( p1 ));
						this.pnlImage.Refresh();
						break;
					case (int) ImageEditModeConst.Edit_Area :
						// �������
						myPointBuffer.Clear();
						myAreaAction.Points = null;
						bolCaptureMouse = true;
						pnlImage.Refresh();
						break;
					case (int) ImageEditModeConst.Edit_Distance :
						// �������
						p2 = CaptureDragPoint( p1 , 0x10 , new DragPointHandler( this.CalcutePointDistance ));
						pnlImage.Refresh();
						break;
					case (int) ImageEditModeConst.Edit_Text :
						// �����ı�
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
				// ������ͼ�߿��ϵ�����¼�
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
		/// ������������ƶ��¼�����
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
					case (int) ImageEditModeConst.Edit_None : // �����ק������ͼƬ
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
						// ��̬�ļ��㵱ǰѡ����������
						using(System.Drawing.Graphics g = pnlImage.CreateGraphics())
						{
							myAreaAction.DrawFix = this.ViewRect.Location ;
							myAreaAction.Execute( g , this.ViewRect );
							myPointBuffer.Add( p );
							myAreaAction.Points = myPointBuffer.ToClosedPointArray();
							myAreaAction.Execute( g , this.ViewRect );
						}
						this.stpMain.Text = "��ǰѡ����������:" + myAreaAction.ContainArea.ToString("0.00") + "ƽ��" + strUnitString ;
						break;
					case (int) ImageEditModeConst.Edit_Pen :
						// ��̬�Ļ��Ƶ�ǰ����
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
				// ���ֻ������ͼ�������ƶ�,û���������
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
							// ѡȡ��ɫ
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
		/// ����������갴���ɿ��¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlImage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( bolCaptureMouse == true )
			{

				if( myButtons.CommandID == (int) ImageEditModeConst.Edit_Pen )
				{
					// �������ʶ���
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
//					// ������������Ķ���
//					this.stpMain.Text = "���ڼ���RGBƽ��ֵ...";
//					this.Cursor = System.Windows.Forms.Cursors.WaitCursor ;
//					InitProgress();
//					int[] AvgRGB = myAreaAction.CalcuteAvgRGB( this.myContentBMP , new ZYCommon.ProgressHandler(this.SetProgress ));
//					this.myProgress.Visible = false;
//					this.stpMain.Text = String.Format("���:{0:0.00}ƽ��" + strUnitString + " RGBƽ��ֵ R:{1} G:{2} B:{3}" , myAreaAction.CalcuteArea() , AvgRGB[0],AvgRGB[1],AvgRGB[2]);
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
		/// ��������ť�����¼�����
		/// </summary>
		/// <param name="ButtonGroup">����������</param>
		/// <param name="Button">��ť����</param>
		private void myButtons_OnClick(ZYButtonGroup ButtonGroup, ZYButtonGroup.ZYButton Button)
		{
			// ������һ�ΰ�ť״̬
			switch( myButtons.LastCommandID )
			{
				case (int) ImageEditModeConst.Edit_ColorPick :
					pnlList.BackColor = this.BackColor ;
					break;
				case(int) ImageEditModeConst.Edit_Poly :
					// ����һ�ΰ�ťΪ���ƶ�������������
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
						// ������������Ķ���
						this.stpMain.Text = "���ڼ���RGBƽ��ֵ...";
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor ;
						InitProgress();
						this.pnlToolBar.Refresh();
						System.Drawing.Color AvgColor = myAreaAction.CalcuteAvgColor( myContentBMP , new ZYCommon.ProgressHandler(this.SetProgress ));
						this.myProgress.Visible = false;
						this.stpMain.Text = String.Format("��ǰѡ����������:{0:0.00}ƽ��" + strUnitString + " RGBƽ��ֵ R:{1} G:{2} B:{3}" , myAreaAction.CalcuteArea() , AvgColor.R , AvgColor.G , AvgColor.B );
						this.Cursor = System.Windows.Forms.Cursors.Default ;
						myButtons.CommandID = (int) ImageEditModeConst.Edit_Area ;
					}
					else
					{
						// ������������Ķ���
						myPointBuffer.Clear();
						myAreaAction.Points = null;
						pnlImage.Refresh();
					}
					break;
				case (int) ImageEditModeConst.Edit_Distance :
					// �����������Ķ���
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
						System.Windows.Forms.MessageBox.Show( this , "������ִ�м�������Ĳ���!","ϵͳ��ʾ" );
					}
//					else
//					{
//						// ������������Ķ���
//						this.stpMain.Text = "���ڼ���RGBƽ��ֵ...";
//						this.Cursor = System.Windows.Forms.Cursors.WaitCursor ;
//						InitProgress();
//						System.Drawing.Color AvgColor = myAreaAction.CalcuteAvgColor( myContentBMP , new ZYCommon.ProgressHandler(this.SetProgress ));
//						this.myProgress.Visible = false;
//						this.stpMain.Text = String.Format("��ǰѡ����������:{0:0.00}ƽ��" + strUnitString + " RGBƽ��ֵ R:{1} G:{2} B:{3}" , myAreaAction.CalcuteArea() , AvgColor.R , AvgColor.G , AvgColor.B );
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

		#region ����㻻�㺯��Ⱥ ******************************************************************
		/// <summary>
		/// ������Ļ����������������ͼ�����еķ������
		/// </summary>
		/// <param name="p1">��Ļ�ϵ�һ��������</param>
		/// <param name="p2">��Ļ�ϵڶ���������</param>
		/// <returns>��ͼ�����еķ������</returns>
		public System.Drawing.Rectangle ScreenPointToViewRect( System.Drawing.Point p1 , System.Drawing.Point p2)
		{
			System.Drawing.Rectangle rect = RectangleObject.GetRectangle(p1,p2);
			rect.Location = this.ScreenPointToView( rect.Location );
			return rect ;
		}
		/// <summary>
		/// ����ͼ��������껻���������ͻ����е�����
		/// </summary>
		/// <param name="p">��ͼ�����е�����</param>
		/// <returns>������ͻ����е�����</returns>
		public System.Drawing.Point ViewPointToClient( System.Drawing.Point p )
		{
			return new System.Drawing.Point( p.X + pnlImage.AutoScrollPosition.X + 10 , p.Y + pnlImage.AutoScrollPosition.Y + 10 );
		}
		/// <summary>
		/// ����ͼ��������껻���������ͻ����е�����
		/// </summary>
		/// <param name="x">��ͼ�����е�X����</param>
		/// <param name="y">��ͼ�����е�Y����</param>
		/// <returns>������ͻ����е�����</returns>
		public System.Drawing.Point ViewPointToClient( int x , int y )
		{
			return new System.Drawing.Point( x + pnlImage.AutoScrollPosition.X + 10 , y + pnlImage.AutoScrollPosition.Y + 10 );
		}
		/// <summary>
		/// ���ͻ����е����껻�����ͼ�����е�����
		/// </summary>
		/// <param name="p">�ͻ����е�����</param>
		/// <returns>��ͼ�����е�����</returns>
		public System.Drawing.Point PointToView( System.Drawing.Point p )
		{
			return new System.Drawing.Point( p.X - pnlImage.AutoScrollPosition.X - 10 , p.Y - pnlImage.AutoScrollPosition.Y - 10);
		}
		/// <summary>
		/// ���ͻ����е����껻�����ͼ�����е�����
		/// </summary>
		/// <param name="x">�ͻ����е�X����</param>
		/// <param name="y">�ͻ����е�Y����</param>
		/// <returns>��ͼ�����е�����</returns>
		public System.Drawing.Point PointToView( int x , int y )
		{
			return new System.Drawing.Point( x - pnlImage.AutoScrollPosition.X - 10 ,y - pnlImage.AutoScrollPosition.Y - 10);
		}
		/// <summary>
		/// ����ͼ��������껻�����Ļ����
		/// </summary>
		/// <param name="x">��ͼ����X����</param>
		/// <param name="y">��ͼ����Y����</param>
		/// <returns>��Ļ����</returns>
		public System.Drawing.Point ViewPointToScreen( int x , int y )
		{
			System.Drawing.Point p = this.ViewPointToClient( x ,y );
			return this.pnlImage.PointToScreen(p);
		}
		/// <summary>
		/// ����ͼ��������껻�����Ļ����
		/// </summary>
		/// <param name="p">��ͼ��������</param>
		/// <returns>��Ļ����</returns>
		public System.Drawing.Point ViewPointToScreen( System.Drawing.Point p )
		{
			p = this.ViewPointToClient( p );
			return this.pnlImage.PointToScreen(p);
		}
		/// <summary>
		/// ����Ļ����ת��δ��ͼ��������
		/// </summary>
		/// <param name="p">��Ļ����ֵ</param>
		/// <returns>��ͼ����</returns>
		public System.Drawing.Point ScreenPointToView( System.Drawing.Point p )
		{
			return this.PointToView( this.pnlImage.PointToClient( p ));
		}
		/// <summary>
		/// ����Ļ����ת��δ��ͼ��������
		/// </summary>
		/// <param name="x">��ĻX����</param>
		/// <param name="y">��ĻY����</param>
		/// <returns>��ͼ����</returns>
		public System.Drawing.Point ScreenPointToView( int x , int y )
		{
			return this.PointToView( this.pnlImage.PointToClient( new System.Drawing.Point( x , y )));
		}
		#endregion

		/// <summary>
		/// ������ͼ�����ڿͻ����еķ�Χ
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
		/// ���ݵ�ǰ�����ô���һ�����ʶ���
		/// </summary>
		/// <returns></returns>
		private System.Drawing.Pen CreateCurrentPen()
		{
			return new System.Drawing.Pen( myColorSelector.ForeColor , intLineWidth );
		}
		/// <summary>
		/// �����б����Ƿ���ʾ�߶ο������
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
				this.stpMain.Text = "����: " + myDisAction.Distance.ToString("0.00") + this.strUnitString ;
			}
			return true;
		}
		#region �����ק���Ƶĺ���Ⱥ **************************************************************
		/// <summary>
		/// ��ק�ڵ�ʱ�Ĵ���ί��
		/// </summary>
		public delegate bool DragPointHandler( System.Drawing.Point p1 , System.Drawing.Point p2 );

		/// <summary>
		/// �����ק��
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
				// ����ǰ��ϢΪ��갴���ɿ���Ϣ���˳�ѭ��
				if( Windows32.User32.isMouseUpMessage( msg.message ))
					break;
				if( Windows32.User32.isMouseMoveMessage( msg.message ))
				{
					// ��Ϊ����ƶ���Ϣ����д���
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
						// ������һ�λ��Ƶ�ͼ��
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

						// ���㵱ǰ�������
						CurrentPoint = MousePos ;
//						CurrentPoint.X += MousePos.X - LastMousePos.X ;
//						CurrentPoint.Y += MousePos.Y - LastMousePos.Y ;
						LastMousePos = MousePos ;

						// ���лص�����
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
							// ���е�ǰ�Ļ���
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
				// ���е�ǰ�Ļ���
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
		/// ������겢���о��ε���������
		/// </summary>
		/// <remarks>���ĵ��༭�������������,�����������Ҫʹ�������ק�������ܱ�Ե�ϵ�8�����Ƶ�
		/// �ķ�ʽ���ı�����λ�úʹ�С,��������ר������֧�ָò�����
		/// �������������û������е����ͼ�����Ϣ,�����������ƶ����޸�
		/// ָ���ľ���,ֱ���û��ɿ������߻ص�����ȡ�����β���
		/// DragStyle ����Ϊ��ק��ı�ţ�����Ч��ΧΪ��1��7��������Ϊ
		/// -1 ������ק���α�����ʱ�ƶ���꽫�����ƶ�����
		/// 0  ��ק�������ϽǵĿ��Ƶ㣬�޸ľ��ε����Ͻ�λ�ã����ε����½�λ�ò���,�ᵼ�¾��ε�λ�úʹ�С�ĸı�
		/// 1  ��ק�����ϱ�Ե�м�Ŀ��Ƶ㣬�޸ľ��ε��ϱ�Եλ�ã�����3����Ե��λ�ò��䣬�ᵼ�¾��εĶ���λ�ú͸߶ȵĸı�
		/// 2  ��ק�������ϽǵĿ��Ƶ㣬�޸ľ��ε����Ͻ�λ�ã������½ǵ�λ�ò��䣬�ᵼ�¾��εĶ���λ�úͿ�ȵĸı�
		/// 3  ��ק�����ұ�Ե�м�Ŀ��Ƶ㣬�޸ľ��ε��ұ�Ե��λ�ã�������Եλ�ò��䣬�ᵼ�¾��εĿ�ȵĸı�
		/// 4  ��ק�������½ǵĿ��Ƶ㣬�޸ľ��ε����½ǵ�λ�ã����Ͻǵ�λ�ò��䣬�ᵼ�¾��εĴ�С�ĸı�
		/// 5  ��ק�����±�Ե�м�Ŀ��Ƶ㣬�޸ľ��ε��±�Եλ�ã�������Ե���䣬�ᵼ�¾��εĸ߶ȵĸı�
		/// 6  ��ק�������½ǵĿ��Ƶ㣬�޸ľ��ε����½�λ�ã������Ͻ�λ�ò��䣬�ᵼ�¾��ε����λ�ú͸߶ȵĸı�
		/// 7  ��ק�������Ե�м�Ŀ��Ƶ㣬�޸ľ������Ե��λ�ã�������Ե���䣬�ᵼ�¾��ε����λ�úͿ�ȵĸı�
		/// ����8����ק���Ƶ���μ�<link>ZYCommon.DocumentView.GetDragRects</link></remarks>
		/// <param name="SourceRect">ԭʼ����,����Ϊ��ͼ�����е�����</param>
		/// <param name="DragStyle">��ק���Ƶ�ı��</param>
		/// <param name="DrawFocusRect">����ʱ�Ƿ���ƿ���ת����,����Ϊtrue �����קʱ���Զ����Ƶ�ǰ���εĿ�����α߿�</param>
		/// <param name="WidthHeightRate">�϶�ʱ�߿�Ŀ�Ⱥ͸߶ȵı�������С�ڵ���0.1����������</param>
		/// <param name="ShowSizeInfo" >�϶�ʱ�Ƿ���ʾ��С��Ϣ</param>
		/// <param name="CallBack">�ص�������ί��</param>
		/// <returns>ԭʼ���ν��������������޸ĺ�ľ���,���û�δ�ı�ԭʼ���εĴ�С��ȡ�������򷵻ؿվ���,����Ϊ��ͼ�����е�����</returns>
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
				this.stpSize.Text = "�����ק��ʼ�ı�����С" ;
			}
			while( Windows32.User32.WaitMessage() )
			{
				if(Windows32.User32.PeekMessage(ref msg, 0, 0, 0, (int)Windows32.PeekMessageFlags.PM_NOREMOVE)==false)
					break;
				// ����ǰ��ϢΪ��갴���ɿ���Ϣ���˳�ѭ��
				if( Windows32.User32.isMouseUpMessage( msg.message ))
					break;
				if( Windows32.User32.isMouseMoveMessage( msg.message ))
				{
					// ��Ϊ����ƶ���Ϣ����д���
					System.Drawing.Point MousePos = System.Windows.Forms.Control.MousePosition ;
					if( LastMousePos.Equals( MousePos)==false)
					{
						// ����λ��
						int dx = MousePos.X - LastMousePos.X ;
						int dy = MousePos.Y - LastMousePos.Y ;
						LastMousePos = MousePos ;
						System.Drawing.Point OldPos = CurrentRect.Location ;
						// �м�
						if(DragStyle == -1 )
							CurrentRect.Offset(dx,dy);
						// ���
						if(DragStyle == 0 || DragStyle == 7 || DragStyle == 6)
						{
							CurrentRect.Offset(dx,0);
							CurrentRect.Width = CurrentRect.Width - dx;
						}
						// ����
						if(DragStyle == 0 || DragStyle == 1 || DragStyle == 2)
						{
							CurrentRect.Offset(0,dy);
							CurrentRect.Height = CurrentRect.Height -dy;
						}
						// �ұ�
						if(DragStyle == 2 || DragStyle == 3 || DragStyle == 4 )
						{
							CurrentRect.Width = CurrentRect.Width + dx;
						}
						// �ױ�
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
									// ��������ת����
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
							// ���ƿ���ת����
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
								this.stpSize.Text = "���:" + CurrentRect.Width + " �߶�:" + CurrentRect.Height  ;
								//this.myStatus.Refresh();
							}
							System.Windows.Forms.ControlPaint.DrawReversibleFrame
								( DrawRect ,
								System.Drawing.Color.SkyBlue   ,
								System.Windows.Forms.FrameStyle.Dashed  );
							//myToolTipCtl.SetToolTip( this , "���:" + CurrentRect.Width  + " �߶�:" + CurrentRect.Height );
							//myToolTipCtl.Active = true;
						}
					}// if Equals
				}
				Windows32.User32.GetMessage(ref msg, 0, 0, 0);
			}// while
			if( DrawRect.IsEmpty == false )
			{
				// ��������ת����
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
	/// ͼ��༭�Ķ����Ļ�����
	/// </summary>
	public abstract class ImageEditAction
	{
		/// <summary>
		/// ��������ķ������
		/// </summary>
		protected System.Drawing.Rectangle myBounds = System.Drawing.Rectangle.Empty ;
		/// <summary>
		/// ��������ķ������
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
		public string	FontName = "����";
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
	/// �������Ķ���
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
	/// ��������Ķ���
	/// </summary>
	public class ImageAreaAction : ImageEditAction
	{
		private System.Drawing.Point[] myPoints = null;
		private double dblContainArea = 0 ;
		public System.Drawing.Point DrawFix = System.Drawing.Point.Empty ;

		///<summary>
		//// X�᷽��ÿ��λ�������ظ���
		///</summary>
		private double    dblXRate        = 0 ;

		///<summary>
		//// Y�᷽��ÿ��λ�������ظ���
		///</summary>
		private double    dblYRate        = 0 ;
 

		///<summary>
		//// X�᷽��ÿ��λ�������ظ���
		///</summary>
		public double XRate
		{
			get{ return dblXRate ;}
			set{ dblXRate = value;}
		}

		///<summary>
		//// Y�᷽��ÿ��λ�������ظ���
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
		/// �������ε����
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
		/// ����BMPͼƬ��ѡ���������ɫ��ƽ��ֵ
		/// </summary>
		/// <param name="myBMP">BMPͼƬ����</param>
		/// <param name="vProgress">���ȴ���ί��</param>
		/// <returns>ƽ����ɫ,����������򷵻غ�ɫ</returns>
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
	/// ��ն���εı༭��������
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
                //TODO:�������һ��Convert.ToDouble()
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
	/// ���ʶ�������
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
                //TODO:�������һ��Convert.ToDouble()
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
	/// ���Ʋ�����������Ķ���
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
	/// ���һ����������Ķ���
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
	/// ���Ʒ���������
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
	/// �߶�������
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
	/// Բ�Ǿ��ζ���
	/// </summary>
	public class RoundRectangle
	{
		///<summary>
		//// ���λ��
		///</summary>
		private int    intLeft     = 0 ;

		///<summary>
		//// ����λ��
		///</summary>
		private int    intTop      = 0 ;

		///<summary>
		//// ���
		///</summary>
		private int    intWidth    = 0 ;

		///<summary>
		//// �߶�
		///</summary>
		private int    intHeight   = 0 ;

		///<summary>
		//// Բ�ǰ뾶
		///</summary>
		private int    intRadius   = 0 ;


		///<summary>
		//// ���λ��
		///</summary>
		public int Left
		{
			get{ return intLeft ;}
			set{ intLeft = value;}
		}

		///<summary>
		//// ����λ��
		///</summary>
		public int Top
		{
			get{ return intTop ;}
			set{ intTop = value;}
		}

		///<summary>
		//// ���
		///</summary>
		public int Width
		{
			get{ return intWidth ;}
			set{ intWidth = value;}
		}

		///<summary>
		//// �߶�
		///</summary>
		public int Height
		{
			get{ return intHeight ;}
			set{ intHeight = value;}
		}

		///<summary>
		//// Բ�ǰ뾶
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