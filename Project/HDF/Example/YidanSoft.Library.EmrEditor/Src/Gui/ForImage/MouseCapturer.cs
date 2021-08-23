using System;
using System.Runtime.InteropServices;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace Windows32
{
	/// <summary>
	/// 可逆图形样式
	/// </summary>
	public enum ReversibleShapeStyle
	{
		/// <summary>
		/// 可逆的直线
		/// </summary>
		Line  ,
		/// <summary>
		/// 可逆矩形边框
		/// </summary>
		Rectangle ,
		/// <summary>
		/// 可逆的填充的矩形
		/// </summary>
		FillRectangle ,
		/// <summary>
		/// 自定义
		/// </summary>
		Custom 
	}

	public delegate void CaptureMouseMoveEventHandler ( object sender , CaptureMouseMoveEventArgs e );
	/// <summary>
	/// 鼠标拖拽事件消息对象
	/// </summary>
	public class CaptureMouseMoveEventArgs : System.EventArgs
	{
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="sender">消息发送者</param>
		/// <param name="sp">开始点坐标</param>
		/// <param name="cp">当前点坐标</param>
		public CaptureMouseMoveEventArgs( MouseCapturer sender , System.Drawing.Point sp ,System.Drawing.Point cp )
		{
			this.mySender = sender ;
			this.myStartPosition = sp ;
			this.myCurrentPosition = cp ;
			this.bolCancel = false ;
		}
		private MouseCapturer mySender = null;
		/// <summary>
		/// 消息发送者
		/// </summary>
		public MouseCapturer Sender
		{
			get{ return mySender ;}
		}
		private System.Drawing.Point myStartPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// 鼠标开始拖拽的点坐标
		/// </summary>
		public System.Drawing.Point StartPosition
		{
			get{ return myStartPosition ;}
			set{ myStartPosition = value;}
		}

		private System.Drawing.Point myCurrentPosition = System.Drawing .Point.Empty ;
		/// <summary>
		/// 鼠标当前点坐标
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
		/// 是否取消拖拽
		/// </summary>
		public bool Cancel
		{
			get{ return bolCancel ;}
			set{ bolCancel = value;}
		}
	}//public class CaptureMouseMoveEventArgs

	/// <summary>
	/// 绘制矩形的鼠标拖拽对象
	/// </summary>
	public class RectangleMouseCapturer : MouseCapturer 
	{
		/// <summary>
		/// 初始化对象
		/// </summary>
		public RectangleMouseCapturer()
		{
		}
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="ctl">进行鼠标拖拽的控件对象</param>
		public RectangleMouseCapturer( System.Windows.Forms.Control ctl )
		{
			myBindControl = ctl ;
		}
		protected int intDragStyle = 0 ;
		/// <summary>
		/// 拖拽类型
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
			// 中间
			if(intDragStyle == -1 )
				rect.Offset(dx,dy);
			// 左边
			if(intDragStyle == 0 || intDragStyle == 7 || intDragStyle == 6)
			{
				rect.Offset(dx,0);
				rect.Width = rect.Width - dx;
			}
			// 顶边
			if(intDragStyle == 0 || intDragStyle == 1 || intDragStyle == 2)
			{
				rect.Offset(0,dy);
				rect.Height = rect.Height -dy;
			}
			// 右边
			if(intDragStyle == 2 || intDragStyle == 3 || intDragStyle == 4 )
			{
				rect.Width = rect.Width + dx;
			}
			// 底边
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
	/// 捕获鼠标的模块
	/// </summary>
	public class MouseCapturer
	{
		/// <summary>
		/// 无作为的初始化对象
		/// </summary>
		public MouseCapturer()
		{
		}
		/// <summary>
		/// 初始化对象并设置绑定的控件
		/// </summary>
		/// <param name="ctl">绑定的控件</param>
		public MouseCapturer( System.Windows.Forms.Control ctl )
		{
			myBindControl = ctl ;
		}
 
		protected System.Windows.Forms.Control myBindControl = null;
		/// <summary>
		/// 对象绑定的控件,若该控件有效则鼠标光标是用控件客户区坐标,否则采用屏幕坐标
		/// </summary>
		public System.Windows.Forms.Control BindControl
		{
			get{ return myBindControl;}
			set{ myBindControl = value;}
		}
		private System.Drawing.Point myInitStartPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// 初始化时的鼠标开始位置
		/// </summary>
		public System.Drawing.Point InitStartPosition
		{
			get{ return this.myInitStartPosition ;}
			set{ this.myInitStartPosition = value;}
		}
		private System.Drawing.Point myStartPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// 开始捕获时的鼠标光标的位置
		/// </summary>
		public System.Drawing.Point StartPosition
		{
			get{ return myStartPosition  ;}
		}
		private System.Drawing.Point myEndPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// 结束捕获时鼠标光标位置
		/// </summary>
		public System.Drawing.Point EndPosition
		{
			get{ return myEndPosition  ;}
		}
		private System.Drawing.Point myLastPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// 上一次处理时鼠标光标位置
		/// </summary>
		public System.Drawing.Point LastPosition
		{
			get{ return myLastPosition  ;}
		}
		private System.Drawing.Point myCurrentPosition = System.Drawing.Point.Empty ;
		/// <summary>
		/// 当前鼠标光标的位置
		/// </summary>
		public System.Drawing.Point CurrentPosition 
		{
			get{ return myCurrentPosition ;}
		}
		private System.Drawing.Size myMoveSize = System.Drawing.Size.Empty ;
		/// <summary>
		/// 整个操作中鼠标移动的距离,属性的Width值表示光标横向移动的距离,Height值表示纵向移动距离
		/// </summary>
		public System.Drawing.Size MoveSize
		{
			get{ return myMoveSize ;}
			set{ myMoveSize = value ;}
		}
		/// <summary>
		/// 整个操作中鼠标横向移动距离
		/// </summary>
		public int DX
		{
			get{ return this.myEndPosition.X - this.myStartPosition.X ;}
		}
		/// <summary>
		/// 整个操作中鼠标纵向移动距离
		/// </summary>
		public int DY
		{
			get{ return this.myEndPosition.Y - this.myStartPosition.Y ;}
		}
		/// <summary>
		/// 鼠标移动起点和终点组成的矩形区域
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
		/// 鼠标光标的活动范围
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
		/// 鼠标捕获期间移动时的回调处理事件
		/// </summary>
		public event CaptureMouseMoveEventHandler MouseMove = null;

		/// <summary>
		/// 鼠标捕获期间移动时的回调处理
		/// </summary>
		protected virtual void OnMouseMove()
		{
			if( MouseMove != null )
				MouseMove( this , this.CreateArgs() );
		}
		/// <summary>
		/// 鼠标捕获期间绘制可逆图形的回调处理事件
		/// </summary>
		public event CaptureMouseMoveEventHandler Draw = null;
		protected virtual void OnDraw()
		{
			if( Draw != null )
				Draw( this , this.CreateArgs());
		}

		/// <summary>
		/// 鼠标捕获期间绘制可逆图形的回调处理
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
		/// 可逆图形样式
		/// </summary>
		public ReversibleShapeStyle ReversibleShape
		{
			get{ return intReversibleShape ;}
			set{ intReversibleShape = value;}
		}
		private object objTag = null;
		/// <summary>
		/// 对象额外数据
		/// </summary>
		public object Tag
		{
			get{ return objTag;}
			set{ objTag = value;}
		}
		/// <summary>
		/// 重新设置内部数据
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
		/// 捕获鼠标移动
		/// </summary>
		/// <returns>是否成功的完成了操作</returns>
		public bool CaptureMouseMove()
		{
			Reset();
			MSG msg	= new MSG();

            //2019.07.18-hdf：为0是获取当前线程的消息，添加个句柄筛选更精确简便
            IntPtr intptr = GetForegroundWindow();
            
			int MinDragSize = System.Windows.Forms.SystemInformation.DragSize.Width ;
			bool DragStartFlag = false;
			
			if( System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.None )
				return false;

			System.Drawing.Point curPoint = this.CurMousePosition ;

			// 开始Windows消息处理
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

				// 若当前消息为鼠标按键松开消息则退出循环
				if( isMouseUpMessage( msg.message ))
				{
					curPoint.X = (short) ((int) msg.lParam );
					curPoint.Y = ((int) msg.lParam ) >> 0x10;
					break;
				}

                if( isMouseMoveMessage( msg.message ))
				{
					// 若为鼠标移动消息则进行处理
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

		#region Win32API函数声明定义代码 **************************************

		/// <summary>
		/// 判断该Windows消息是否是鼠标移动消息
		/// </summary>
		/// <param name="intMessage">消息编码</param>
		/// <returns>判断结果</returns>
		private static bool isMouseMoveMessage(int intMessage)
		{
			if( intMessage == 0x0200 || intMessage  == 0x00A0 )
				return true;
			return false;
		}

		/// <summary>
		/// 判断该Windows消息是否是鼠标按键松开消息
		/// </summary>
		/// <param name="intMessage">消息编码</param>
		/// <returns>判断结果</returns>
		private static bool isMouseUpMessage(int intMessage)
		{
			// 鼠标在客户区的按钮松开消息
			if( intMessage   == 0x0202 
				|| intMessage  ==0x0208
				|| intMessage  == 0x0205
				|| intMessage  == 0x020C )
				return true;
		 
			// 鼠标在非客户区的按键松开消息
			if (intMessage  == 0x00A2  
				|| intMessage  == 0x00A8 
				|| intMessage  == 0x00A5 
				|| intMessage  == 0x00AC )
				return true;
			return false;
		}

        //2019.07.19-hdf
        //获取消息时添加句柄，使消息筛选更加精确
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
            //64位程序调用User32.dll获取windows消息队列的MSG时，自己定义的MSG结构成员类型不能全为int，尤其是message、lParam、wPlaram，否则无法正确获取值
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