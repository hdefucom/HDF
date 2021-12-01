using System;
using System.Runtime.InteropServices;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace Windows32
{
	/// <summary>
	/// ����ͼ����ʽ
	/// </summary>
	public enum ReversibleShapeStyle
	{
		/// <summary>
		/// �����ֱ��
		/// </summary>
		Line  ,
		/// <summary>
		/// ������α߿�
		/// </summary>
		Rectangle ,
		/// <summary>
		/// ��������ľ���
		/// </summary>
		FillRectangle ,
		/// <summary>
		/// �Զ���
		/// </summary>
		Custom 
	}

	public delegate void CaptureMouseMoveEventHandler ( object sender , CaptureMouseMoveEventArgs e );
	/// <summary>
	/// �����ק�¼���Ϣ����
	/// </summary>
	public class CaptureMouseMoveEventArgs : System.EventArgs
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="sender">��Ϣ������</param>
		/// <param name="sp">��ʼ������</param>
		/// <param name="cp">��ǰ������</param>
		public CaptureMouseMoveEventArgs( MouseCapturer sender , System.Drawing.Point sp ,System.Drawing.Point cp )
		{
			this.mySender = sender ;
			this.myStartPosition = sp ;
			this.myCurrentPosition = cp ;
			this.bolCancel = false ;
		}
		private MouseCapturer mySender = null;
		/// <summary>
		/// ��Ϣ������
		/// </summary>
		public MouseCapturer Sender
		{
			get{ return mySender ;}
		}
		private System.Drawing.Point myStartPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// ��꿪ʼ��ק�ĵ�����
		/// </summary>
		public System.Drawing.Point StartPosition
		{
			get{ return myStartPosition ;}
			set{ myStartPosition = value;}
		}

		private System.Drawing.Point myCurrentPosition = System.Drawing .Point.Empty ;
		/// <summary>
		/// ��굱ǰ������
		/// </summary>
		public System.Drawing.Point CurrentPosition
		{
			get{ return myCurrentPosition ; }
			set{ myCurrentPosition = value; }
		}
		public int DX
		{
			get{ return myCurrentPosition.X - myStartPosition.X ;}
		}
		public int DY
		{
			get{ return myCurrentPosition.Y - myStartPosition.Y ;}
		}

		private bool bolCancel = false;
		/// <summary>
		/// �Ƿ�ȡ����ק
		/// </summary>
		public bool Cancel
		{
			get{ return bolCancel ;}
			set{ bolCancel = value;}
		}
	}//public class CaptureMouseMoveEventArgs

	/// <summary>
	/// ���ƾ��ε������ק����
	/// </summary>
	public class RectangleMouseCapturer : MouseCapturer 
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public RectangleMouseCapturer()
		{
		}
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="ctl">���������ק�Ŀؼ�����</param>
		public RectangleMouseCapturer( System.Windows.Forms.Control ctl )
		{
			myBindControl = ctl ;
		}
		protected int intDragStyle = 0 ;
		/// <summary>
		/// ��ק����
		/// </summary>
		public int DragStyle
		{
			get{ return intDragStyle ;}
			set{ intDragStyle = value;}
		}
		protected System.Drawing.Rectangle mySourceRectangle = System.Drawing.Rectangle.Empty ;
		public System.Drawing.Rectangle SourceRectangle
		{
			get{ return mySourceRectangle ;}
			set{ mySourceRectangle = value;}
		}

		protected System.Drawing.Rectangle myDescRectangle = System.Drawing.Rectangle.Empty ;
		public System.Drawing.Rectangle DescRectangle
		{
			get{ return myDescRectangle ;}
			set{ myDescRectangle = value;}
		}

		protected bool bolCustomAction = false;
		public bool CustomAction
		{
			get{ return bolCustomAction ;}
			set{ bolCustomAction = value;}
		}

		public System.Drawing.Rectangle UpdateRectangle( System.Drawing.Rectangle rect , int dx , int dy )
		{
			// �м�
			if(intDragStyle == -1 )
				rect.Offset(dx,dy);
			// ���
			if(intDragStyle == 0 || intDragStyle == 7 || intDragStyle == 6)
			{
				rect.Offset(dx,0);
				rect.Width = rect.Width - dx;
			}
			// ����
			if(intDragStyle == 0 || intDragStyle == 1 || intDragStyle == 2)
			{
				rect.Offset(0,dy);
				rect.Height = rect.Height -dy;
			}
			// �ұ�
			if(intDragStyle == 2 || intDragStyle == 3 || intDragStyle == 4 )
			{
				rect.Width = rect.Width + dx;
			}
			// �ױ�
			if(intDragStyle == 4 || intDragStyle == 5 || intDragStyle == 6 )
			{
				rect.Height = rect.Height + dy;
			}
			return rect ;
		}

		protected override void OnDraw()
		{
			base.OnDraw ();
			if( bolCustomAction )
				return ;
			ReversibleDrawer drawer = null ;
			if( myBindControl != null )
				drawer = ReversibleDrawer.FromHwnd( myBindControl.Handle );
			else
				drawer = ReversibleDrawer.FromScreen();
			drawer.DrawRectangle( myDescRectangle );
			drawer.Dispose();
		}
		public System.Drawing.Rectangle CurrentRectangle
		{
			get
			{
				return RectangleCommon.GetRectangle( this.StartPosition , this.CurrentPosition );
			}
		}

		protected override void OnMouseMove()
		{
			base.OnMouseMove();
			if( bolCustomAction )
				return ;
			int dx = base.CurrentPosition.X - base.StartPosition.X ;
			int dy = base.CurrentPosition.Y - base.StartPosition.Y ;
			this.myDescRectangle = UpdateRectangle( this.mySourceRectangle , dx , dy );
		}
	}

	/// <summary>
	/// ��������ģ��
	/// </summary>
	public class MouseCapturer
	{
		/// <summary>
		/// ����Ϊ�ĳ�ʼ������
		/// </summary>
		public MouseCapturer()
		{
		}
		/// <summary>
		/// ��ʼ���������ð󶨵Ŀؼ�
		/// </summary>
		/// <param name="ctl">�󶨵Ŀؼ�</param>
		public MouseCapturer( System.Windows.Forms.Control ctl )
		{
			myBindControl = ctl ;
		}
 
		protected System.Windows.Forms.Control myBindControl = null;
		/// <summary>
		/// ����󶨵Ŀؼ�,���ÿؼ���Ч����������ÿؼ��ͻ�������,���������Ļ����
		/// </summary>
		public System.Windows.Forms.Control BindControl
		{
			get{ return myBindControl;}
			set{ myBindControl = value;}
		}
		private System.Drawing.Point myInitStartPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// ��ʼ��ʱ����꿪ʼλ��
		/// </summary>
		public System.Drawing.Point InitStartPosition
		{
			get{ return this.myInitStartPosition ;}
			set{ this.myInitStartPosition = value;}
		}
		private System.Drawing.Point myStartPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// ��ʼ����ʱ��������λ��
		/// </summary>
		public System.Drawing.Point StartPosition
		{
			get{ return myStartPosition  ;}
		}
		private System.Drawing.Point myEndPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// ��������ʱ�����λ��
		/// </summary>
		public System.Drawing.Point EndPosition
		{
			get{ return myEndPosition  ;}
		}
		private System.Drawing.Point myLastPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// ��һ�δ���ʱ�����λ��
		/// </summary>
		public System.Drawing.Point LastPosition
		{
			get{ return myLastPosition  ;}
		}
		private System.Drawing.Point myCurrentPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// ��ǰ������λ��
		/// </summary>
		public System.Drawing.Point CurrentPosition 
		{
			get{ return myCurrentPosition ;}
		}
		private System.Drawing.Size myMoveSize = System.Drawing.Size.Empty ;
		/// <summary>
		/// ��������������ƶ��ľ���,���Ե�Widthֵ��ʾ�������ƶ��ľ���,Heightֵ��ʾ�����ƶ�����
		/// </summary>
		public System.Drawing.Size MoveSize
		{
			get{ return myMoveSize ;}
			set{ myMoveSize = value ;}
		}
		/// <summary>
		/// �����������������ƶ�����
		/// </summary>
		public int DX
		{
			get{ return this.myEndPosition.X - this.myStartPosition.X ;}
		}
		/// <summary>
		/// ������������������ƶ�����
		/// </summary>
		public int DY
		{
			get{ return this.myEndPosition.Y - this.myStartPosition.Y ;}
		}
		/// <summary>
		/// ����ƶ������յ���ɵľ�������
		/// </summary>
		public System.Drawing.Rectangle CaptureRectagle
		{
			get
			{
				System.Drawing.Rectangle rect =  RectangleCommon.GetRectangle( this.myStartPosition  , this.myEndPosition );
				rect.Location = this.FixPointForControl( rect.Location );
				return rect ;
			}
		}
		private System.Drawing.Rectangle myClipRectangle = System.Drawing.Rectangle.Empty ;
		/// <summary>
		/// �����Ļ��Χ
		/// </summary>
		public System.Drawing.Rectangle ClipRectangle
		{
			get{ return myClipRectangle ;}
			set{ myClipRectangle = value;}
		}

		protected virtual CaptureMouseMoveEventArgs CreateArgs()
		{
			CaptureMouseMoveEventArgs e = new CaptureMouseMoveEventArgs( this , this.myStartPosition ,this.myCurrentPosition );
			return e ;
		}
		

		/// <summary>
		/// ��겶���ڼ��ƶ�ʱ�Ļص������¼�
		/// </summary>
		public event CaptureMouseMoveEventHandler MouseMove = null;

		/// <summary>
		/// ��겶���ڼ��ƶ�ʱ�Ļص�����
		/// </summary>
		protected virtual void OnMouseMove()
		{
			if( MouseMove != null )
				MouseMove( this , this.CreateArgs() );
		}
		/// <summary>
		/// ��겶���ڼ���ƿ���ͼ�εĻص������¼�
		/// </summary>
		public event CaptureMouseMoveEventHandler Draw = null;
		protected virtual void OnDraw()
		{
			if( Draw != null )
				Draw( this , this.CreateArgs());
		}

		/// <summary>
		/// ��겶���ڼ���ƿ���ͼ�εĻص�����
		/// </summary>
		protected virtual void OnReversibleDrawCallback()
		{
			System.Drawing.Rectangle rect = RectangleCommon.GetRectangle( this.myStartPosition , this.myCurrentPosition );
			switch( intReversibleShape )
			{
				case ReversibleShapeStyle.Line :
					System.Windows.Forms.ControlPaint.DrawReversibleLine(this.myStartPosition ,this.myCurrentPosition , System.Drawing.Color.Black );
					break;
				case ReversibleShapeStyle.Rectangle :
					System.Windows.Forms.ControlPaint.DrawReversibleFrame( rect , System.Drawing.Color.SkyBlue , System.Windows.Forms.FrameStyle.Dashed );
					break ;
				case ReversibleShapeStyle.FillRectangle :
					System.Windows.Forms.ControlPaint.FillReversibleRectangle(rect ,System.Drawing.Color.Black );
					break;
				case ReversibleShapeStyle.Custom :
					if( Draw != null )
						Draw( this , null );
					break;
			}
		}
		private ReversibleShapeStyle intReversibleShape = ReversibleShapeStyle.Custom ;
		/// <summary>
		/// ����ͼ����ʽ
		/// </summary>
		public ReversibleShapeStyle ReversibleShape
		{
			get{ return intReversibleShape ;}
			set{ intReversibleShape = value;}
		}
		private object objTag = null;
		/// <summary>
		/// �����������
		/// </summary>
		public object Tag
		{
			get{ return objTag;}
			set{ objTag = value;}
		}
		/// <summary>
		/// ���������ڲ�����
		/// </summary>
		public void Reset()
		{
			if( this.myInitStartPosition.IsEmpty )
				this.myStartPosition = this.CurMousePosition ;
			else
				this.myStartPosition = this.myInitStartPosition ;

			this.myLastPosition = myStartPosition ;
			this.myCurrentPosition = myStartPosition ;
			this.myEndPosition = myStartPosition ;
			this.myMoveSize = System.Drawing.Size.Empty ;
		}
		
		/// <summary>
		/// ��������ƶ�
		/// </summary>
		/// <returns>�Ƿ�ɹ�������˲���</returns>
		public bool CaptureMouseMove()
		{
			Reset();
			MSG msg	= new MSG();

            //2019.07.18-hdf��Ϊ0�ǻ�ȡ��ǰ�̵߳���Ϣ����Ӹ����ɸѡ����ȷ���
            IntPtr intptr = GetForegroundWindow();
            
			int MinDragSize = System.Windows.Forms.SystemInformation.DragSize.Width ;
			bool DragStartFlag = false;
			
			if( System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.None )
				return false;

			System.Drawing.Point curPoint = this.CurMousePosition ;

			// ��ʼWindows��Ϣ����
			while( WaitMessage() )
			{
				curPoint = this.CurMousePosition ;

				if( System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.None )
					break;

				if( PeekMessage(
					ref msg,
                    intptr.ToInt32(),
					0, 
					0, 
					(int)PeekMessageFlags.PM_NOREMOVE) == false ) continue ;

				// ����ǰ��ϢΪ��갴���ɿ���Ϣ���˳�ѭ��
				if( isMouseUpMessage( msg.message ))
				{
					curPoint.X = (short) ((int) msg.lParam );
					curPoint.Y = ((int) msg.lParam ) >> 0x10;
					break;
				}

                if( isMouseMoveMessage( msg.message ))
				{
					// ��Ϊ����ƶ���Ϣ����д���
					System.Drawing.Point p =  new System.Drawing.Point(
						(short) ((int) msg.lParam ) ,
                        ((int)msg.lParam) >> 0x10);

					if( p.X != this.myCurrentPosition.X || p.Y != this.myCurrentPosition.Y )
					{
						if( DragStartFlag )
						{
							this.OnDraw();
						}
						this.myCurrentPosition = p ;
						if( DragStartFlag == false)
						{
                            if (System.Math.Abs(this.myCurrentPosition.X - this.myStartPosition.X) >= MinDragSize 
								|| System.Math.Abs( this.myCurrentPosition.Y - this.myStartPosition.Y ) >= MinDragSize )
								DragStartFlag = true;
						}
						if( DragStartFlag )
						{
							this.myCurrentPosition = p ;
							this.OnDraw();
							this.OnMouseMove();
							this.myLastPosition = this.myCurrentPosition ;
						}
					}
				}
                GetMessage(ref msg, intptr.ToInt32(), 0, 0);
			}// while( User32.WaitMessage() )

			this.myCurrentPosition =  curPoint ;

			if( DragStartFlag )
				this.OnDraw();

			this.myEndPosition = this.myCurrentPosition ;
			this.myMoveSize = new System.Drawing.Size( 
				myEndPosition.X - myStartPosition.X ,
				myEndPosition.Y - myStartPosition.Y );
			if( myMoveSize.Width == 0 && myMoveSize.Height == 0 )
				return false;
			return DragStartFlag ;
		}

		public System.Drawing.Size CurrentMoveSize
		{
			get
			{
				return new System.Drawing.Size(
					myCurrentPosition.X - myStartPosition.X , 
					myCurrentPosition.Y - myStartPosition.Y );
			}
		}

		private System.Drawing.Point GetMousePosition( System.Drawing.Point p )
		{
			if( myBindControl != null )
			{
				p = myBindControl.PointToClient( p );
			}
			return RectangleCommon.MoveInto( p , this.myClipRectangle ) ;
		}
		private System.Drawing.Point CurMousePosition
		{
			get
			{
				return GetMousePosition( System.Windows.Forms.Control.MousePosition ) ;
			}

		}

		private System.Drawing.Point FixPointForControl( System.Drawing.Point p )
		{
			if( myBindControl != null )
				p = myBindControl.PointToClient( p );
			return p ;
		}

		#region Win32API��������������� **************************************

		/// <summary>
		/// �жϸ�Windows��Ϣ�Ƿ�������ƶ���Ϣ
		/// </summary>
		/// <param name="intMessage">��Ϣ����</param>
		/// <returns>�жϽ��</returns>
		private static bool isMouseMoveMessage(int intMessage)
		{
			if( intMessage == 0x0200 || intMessage  == 0x00A0 )
				return true;
			return false;
		}

		/// <summary>
		/// �жϸ�Windows��Ϣ�Ƿ�����갴���ɿ���Ϣ
		/// </summary>
		/// <param name="intMessage">��Ϣ����</param>
		/// <returns>�жϽ��</returns>
		private static bool isMouseUpMessage(int intMessage)
		{
			// ����ڿͻ����İ�ť�ɿ���Ϣ
			if( intMessage   == 0x0202 
				|| intMessage  ==0x0208
				|| intMessage  == 0x0205
				|| intMessage  == 0x020C )
				return true;
		 
			// ����ڷǿͻ����İ����ɿ���Ϣ
			if (intMessage  == 0x00A2  
				|| intMessage  == 0x00A8 
				|| intMessage  == 0x00A5 
				|| intMessage  == 0x00AC )
				return true;
			return false;
		}

        //2019.07.19-hdf
        //��ȡ��Ϣʱ��Ӿ����ʹ��Ϣɸѡ���Ӿ�ȷ
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		private static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		private static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		private static extern bool WaitMessage();

		[StructLayout(LayoutKind.Sequential)]
			private struct MSG 
		{
            //2019.07.19-hdf
            //64λ�������User32.dll��ȡwindows��Ϣ���е�MSGʱ���Լ������MSG�ṹ��Ա���Ͳ���ȫΪint��������message��lParam��wPlaram�������޷���ȷ��ȡֵ
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
			public int pt_x;
			public int pt_y;
		}

		#endregion

		//		private static System.Drawing.Point FixPoint(System.Drawing.Point SourcePoint , System.Drawing.Point p)
		//		{
		//			if( KeyHelper.HasShiftPressing())
		//			{
		//				double dblAngle = XDesignerCommon.MathCommon.Angle( SourcePoint.X , SourcePoint.Y , p.X , p.Y );
		//				int intArea = (int)System.Math.Round( ( dblAngle )/45.0) % 8 ;
		//				if( intArea == 0 || intArea == 4 )
		//				{
		//					p.Y = 0 ;
		//				}
		//				if( intArea == 2 || intArea == 6 )
		//				{
		//					p.Y -= SourcePoint.Y ;
		//					p.X = SourcePoint.X ;
		//				}
		//				if( intArea == 3 || intArea == 7 )
		//				{
		//					p.Y = SourcePoint.X - p.X ;
		//				}
		//				if( intArea == 5 || intArea == 1 )
		//					p.Y = p.X - SourcePoint.X ;
		//				p.Y += SourcePoint.Y ;
		//			}
		//			return p ;
		//		}
	}//public class MouseCapturer
}