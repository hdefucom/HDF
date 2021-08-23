using System;
using System.Windows.Forms ;
using System.Drawing ;
namespace ZYCommon
{
	
	/// <summary>
	/// 按钮组按钮按下事件委托
	/// </summary>
	public delegate void ZYButtonClickHandler( ZYButtonGroup ButtonGroup , ZYButtonGroup.ZYButton Button );

	/// <summary>
	/// 按钮组对象
	/// </summary>
	public class ZYButtonGroup : System.IDisposable
	{
		/// <summary>
		/// 表示一个按钮的类
		/// </summary>
		public class ZYButton
		{
			/// <summary>
			/// 显示的提示文本
			/// </summary>
			public string	ToolTip = null;
			/// <summary>
			/// 命令文本
			/// </summary>
			public string	Command = "" ;
			/// <summary>
			/// 命令编号
			/// </summary>
			public int		CommandID = 0 ;
			/// <summary>
			/// 从0开始的图象列表序号
			/// </summary>
			public int		ImageIndex = -1 ;
			/// <summary>
			/// 是否可见
			/// </summary>
			public bool		Visible = true;
			/// <summary>
			/// 是否可用
			/// </summary>
			public bool		Enable = true;
			/// <summary>
			/// 按钮正在被按下
			/// </summary>
			public bool		Pushing = false;
			/// <summary>
			/// 是否处于按下状态
			/// </summary>
			public bool		Pushed = false;
			/// <summary>
			/// 按钮在按钮组中的左端位置
			/// </summary>
			public int		Left = 0 ;
			/// <summary>
			/// 按钮在按钮组中的顶端位置
			/// </summary>
			public int		Top = 0 ;
			/// <summary>
			/// 按钮宽度
			/// </summary>
			public int		Width =16 ; 
			/// <summary>
			/// 按钮高度
			/// </summary>
			public int		Height =16 ;
			/// <summary>
			/// 该按钮所在的组号
			/// </summary>
			public int		GroupID = 0 ;
			/// <summary>
			/// 按钮所在的按钮组对象
			/// </summary>
			public ZYButtonGroup OwnerGroup = null;
			/// <summary>
			/// 按钮按下时的事件处理
			/// </summary>
			//public event System.EventHandler OnClick  ;
			/// <summary>
			/// 返回按钮的边框
			/// </summary>
			public System.Drawing.Rectangle ButtonRect
			{
				get{ return new System.Drawing.Rectangle( Left + OwnerGroup.Left , Top + OwnerGroup.Top , Width , Height ); }
			}
			public string LastStatus = null;

		}//public class ZYButton

		private System.Drawing.Image myButtonImage ;
		private int intICONWidth = 16 ;
		private int intICONHeight = 16 ;
		private int intDefaultButtonWidth = 20 ;
		private int	intDefaultButtonHeight = 20 ;
		private int intLeft = 0 ;
		private int intTop = 0 ;
		private int intWidth = 0 ;
		private int intHeight = 0 ;
		private System.Collections.ArrayList myButtons = new System.Collections.ArrayList();
		private ZYButton myCurrentButton = null;
		private ZYButton myLastButton = null;

		/// <summary>
		/// 程序正在忙标志
		/// </summary>
		private bool bolEnableClickEvent = true;


		/// <summary>
		/// 对象的显示高度
		/// </summary>
		private int intPerformHeight = 0 ;
		private int intPerformWidth = 0 ;
		/// <summary>
		/// 绘制对象的控件对象
		/// </summary>
		public System.Windows.Forms.Control OwnerControl = null;

		/// <summary>
		/// 按钮按下事件处理
		/// </summary>
		public event ZYButtonClickHandler OnClick = null;

		/// <summary>
		/// 对象显示的高度
		/// </summary>
		public int PerformHeight
		{
			get{ return intPerformHeight;}
		}
		/// <summary>
		/// 对象显示的宽度
		/// </summary>
		public int PerformWidth
		{
			get{ return intPerformWidth ;}
		}

		/// <summary>
		/// 绑定绘制对象的控件
		/// </summary>
		/// <param name="vControl"></param>
		public void BindControl( System.Windows.Forms.Control vControl)
		{
			OwnerControl = vControl ;
			if( OwnerControl != null)
			{
				OwnerControl.MouseDown +=new MouseEventHandler(OwnerControl_MouseDown);
				OwnerControl.MouseMove +=new MouseEventHandler(OwnerControl_MouseMove);
				OwnerControl.MouseUp +=new MouseEventHandler(OwnerControl_MouseUp);
				OwnerControl.Paint +=new PaintEventHandler(OwnerControl_Paint);
			}
		}
		/// <summary>
		/// 按钮对象集合
		/// </summary>
		public System.Collections.ArrayList Buttons
		{
			get{ return myButtons ;}
		}

		/// <summary>
		/// 添加一个新的按钮
		/// </summary>
		/// <param name="vImageIndex">按钮图标序号</param>
		/// <param name="vCommandID">按钮命令编号</param>
		/// <returns></returns>
		public ZYButton AddButton( int vImageIndex , int vCommandID )
		{
			ZYButton NewButton = new ZYButton();
			myButtons.Add( NewButton );
			NewButton.OwnerGroup	= this ;
			NewButton.Width			= intDefaultButtonWidth ;
			NewButton.Height		= intDefaultButtonHeight ;
			NewButton.ImageIndex	= vImageIndex ;
			NewButton.CommandID 	= vCommandID ;
			return NewButton ;
		}
		/// <summary>
		/// 设置图标
		/// </summary>
		/// <param name="myImg">图片对象</param>
		/// <param name="vICONWidth">图标的宽度</param>
		/// <param name="vICONHeight">图标的高度</param>
		public void SetButtonImage( System.Drawing.Image myImg , int vICONWidth , int vICONHeight )
		{
			myButtonImage = myImg ;
			intICONWidth = vICONWidth ;
			intICONHeight = vICONHeight ;
		}

		/// <summary>
		/// 获得指定序号的子图标在图片对象中的矩形区域位置,若计算错误则返回空矩形
		/// </summary>
		/// <param name="ImageIndex">从0开始的图标序号</param>
		/// <returns>图标在图片对象中的矩形区域的位置,若计算错误则返回空矩形</returns>
		public System.Drawing.Rectangle GetICONImageRange( int ImageIndex)
		{
			if( ImageIndex >= 0
				&& myButtonImage != null
				&& intICONWidth > 0 
				&&  intICONHeight > 0 
				&& myButtonImage.Size.Width > intICONWidth )
			{
				// 计算图片中每行图标的个数
				int LineNum = (int)System.Math.Floor( myButtonImage.Size.Width / (double)intICONWidth );
				if( LineNum > 0 )
				{
					System.Drawing.Rectangle myRect = new Rectangle
						( intICONWidth * ( ImageIndex % LineNum ) ,
                        //TODO:这里加了一个Convert.ToDouble()
						(int)(intICONHeight * System.Math.Floor( Convert.ToDouble(ImageIndex / LineNum) ) ),
						intICONWidth ,
						intICONHeight );
					if( myRect.Bottom <= myButtonImage.Size.Height )
						return myRect ;
				}
			}
			return System.Drawing.Rectangle.Empty ;
		}//System.Drawing.Rectangle GetICONImageRange( int ImageIndex)

		/// <summary>
		/// 按钮默认宽度
		/// </summary>
		public int DefaultButtonWidth
		{
			get{ return intDefaultButtonWidth;}
			set{ intDefaultButtonWidth = value;}
		}
		/// <summary>
		/// 按钮默认高度
		/// </summary>
		public int DefaultButtonHeight
		{
			get{ return intDefaultButtonHeight ;}
			set{ intDefaultButtonHeight = value;}
		}
		/// <summary>
		/// 对象左端位置
		/// </summary>
		public int Left
		{
			get{ return intLeft;}
			set{ intLeft = value;}
		}
		/// <summary>
		/// 对象顶端位置
		/// </summary>
		public int Top
		{
			get{ return intTop ;}
			set{ intTop = value;}
		}
		/// <summary>
		/// 对象宽度
		/// </summary>
		public int Width
		{
			get{ return intWidth;}
			set{ intWidth = value;}
		}
		/// <summary>
		/// 对象高度
		/// </summary>
		public int Height
		{
			get{ return intHeight;}
			set{ intHeight = value;}
		}
		/// <summary>
		/// 返回客户区矩形位置
		/// </summary>
		public System.Drawing.Rectangle ClientRect
		{
			get{ return new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight );}
			set
			{
				intLeft = value.Left ;
				intTop = value.Top ;
				intWidth = value.Width ;
				intHeight = value.Height ;
			}
		}
		/// <summary>
		/// 重新计算对象内部按钮的位置
		/// </summary>
		public void RefreshSize()
		{
			int TopCount	= 0  ;
			int LeftCount	= 0 ;
			int MaxHeight	= 0 ;
			int WidthCount	= 0 ;
			intPerformHeight = 0 ;
			intPerformWidth = 0 ;
			System.Collections.ArrayList LineButtons = new System.Collections.ArrayList();
			foreach(ZYButton myButton in myButtons)
			{
				if( myButton.Visible )
				{
					if( WidthCount == 0 || WidthCount + myButton.Width <= intWidth )
					{
						myButton.Left = LeftCount ;
						myButton.Top = TopCount ;
						LeftCount += myButton.Width ;
						WidthCount += myButton.Width ;
						if( MaxHeight < myButton.Height )
							MaxHeight = myButton.Height ;
					}
					else
					{
						LeftCount	=  0 ;
						TopCount	+= MaxHeight ;
						WidthCount	= myButton.Width ;
						MaxHeight = myButton.Height ;

						myButton.Left = 0 ;
						myButton.Top = TopCount ;
						LeftCount = myButton.Width ;
					}
					if( intPerformHeight < myButton.Top + myButton.Height )
						intPerformHeight = myButton.Top + myButton.Height ;
					if( intPerformWidth < myButton.Left + myButton.Width )
						intPerformWidth = myButton.Left + myButton.Width ;
				}
			}//foreach
		}//public void RefreshSize()

		/// <summary>
		/// 重新绘制对象
		/// </summary>
		/// <param name="Graph">绘制对象使用的绘图对象</param>
		/// <param name="ClipRect">绘制剪切矩形</param>
		public void RefreshView( System.Drawing.Graphics Graph , System.Drawing.Rectangle ClipRect )
		{
			if( Graph != null && ClipRect.Width > 0 && ClipRect.Height > 0 && this.ClientRect.IntersectsWith( ClipRect ) )
			{
				foreach(ZYButton myButton in myButtons )
				{
					if( myButton.Visible )
					{
						System.Drawing.Rectangle ButtonRect = myButton.ButtonRect ;
						if( ButtonRect.IntersectsWith( ClipRect ))
						{
							// 绘制边框
							System.Windows.Forms.ControlPaint.DrawButton( Graph , ButtonRect , ( myButton.Pushed ? System.Windows.Forms.ButtonState.Pushed  : System.Windows.Forms.ButtonState.Normal )); 
							// 绘制底
							if( myButton.Pushing == false && myButton.Pushed )
							{
								Graph.FillRectangle( System.Drawing.SystemBrushes.ControlLightLight  , ButtonRect.Left + 2 , ButtonRect.Top + 2 , ButtonRect.Width - 4 , ButtonRect.Height - 4 );
							}
							System.Drawing.Rectangle ICONRect = this.GetICONImageRange( myButton.ImageIndex );
							if( ICONRect.IsEmpty == false)
							{
								ButtonRect.X += ( ButtonRect.Width - ICONRect.Width ) /2 ;
								ButtonRect.Y += ( ButtonRect.Height - ICONRect.Height ) /2 ;
								ButtonRect.Width = ICONRect.Width ;
								ButtonRect.Height = ICONRect.Height ;
								if( myButton.Pushed )
								{
									ButtonRect.X += myButton.Pushing ? 2 : 1 ;
									ButtonRect.Y += myButton.Pushing ? 2 : 1 ;
								}
								Graph.DrawImage( myButtonImage , ButtonRect , ICONRect , System.Drawing.GraphicsUnit.Pixel);
							}
						}//if
					}//if
				}//foreach
			}//if
		}//public void RefreshView()

		public void RefreshButtonView(ZYButton myButton )
		{
			if( this.OwnerControl != null && myButton != null && myButton.Visible )
				this.OwnerControl.Invalidate( myButton.ButtonRect );
		}
		/// <summary>
		/// 处理鼠标按钮按下事件
		/// </summary>
		/// <param name="x">鼠标光标在用户界面中的左端位置</param>
		/// <param name="y">鼠标光标在用户界面中的顶端位置</param>
		/// <param name="Button">鼠标按钮</param>
		/// <returns>是否处理的鼠标按钮按下事件</returns>
		public bool HandleMouseDown( int x , int y , System.Windows.Forms.MouseButtons Button)
		{
			if( this.ClientRect.Contains( x , y ) && Button == System.Windows.Forms.MouseButtons.Left )
			{
				foreach( ZYButton myButton in myButtons )
				{
					if( myButton.Visible && myButton.Enable )
					{
						if( myButton.ButtonRect.Contains( x , y ))
						{
							System.Drawing.Rectangle InvaldRect = myButton.ButtonRect ;
							myButton.Pushing = true;
							myButton.Pushed = true ;
							myCurrentButton = myButton ;
							this.RefreshButtonView( myButton );
							foreach( ZYButton myButton2 in myButtons )
							{
								if( myButton2.Pushed && myButton2.Visible && myButton2 != myButton )
								{
									myButton2.Pushed = false;
									this.RefreshButtonView( myButton2 );
								}
							}
							return true;
						}
					}//if
				}//foreach
			}//if
			return false;
		}//public bool HandleMouseDown()

		public bool HandleMouseMove( int x , int y , System.Windows.Forms.MouseButtons Button )
		{
			if( myCurrentButton != null )
			{
				if( myCurrentButton.Pushing )
				{
					bool bolPushed = myCurrentButton.ButtonRect.Contains(x , y);
					if( bolPushed != myCurrentButton.Pushed )
					{
						myCurrentButton.Pushed = bolPushed ;
						this.RefreshButtonView( myCurrentButton );
					}
				}
			}
			return false;
		}

		public bool HandleMouseUp( int x , int y , System.Windows.Forms.MouseButtons Button )
		{
			if( myCurrentButton != null)
				myCurrentButton.Pushing = false;
			if( this.ClientRect.Contains( x , y ) && Button == System.Windows.Forms.MouseButtons.Left )
			{
				foreach( ZYButton myButton in myButtons)
				{
					if( myButton.Visible && myButton.Enable )
					{
						if( myButton.ButtonRect.Contains(x,y))
						{
							myButton.Pushed = true;
							myButton.Pushing = false;
							myCurrentButton = myButton ;
							this.RefreshButtonView( myButton );
							RaiseOnClick();
							myLastButton = myCurrentButton ;
							return true;
						}
					}//if
				}//foreach
			}//if
			return false;
		}//public bool HandleMouseUp()

		public int CommandID
		{
			get{ return myCurrentButton == null ? -1 : myCurrentButton.CommandID ;}
			set
			{
				foreach( ZYButton myButton in myButtons)
				{
					if( myButton.Visible && myButton.CommandID == value)
					{
						this.CurrentButton = myButton ;
						break;
					}
				}
			}
		}

		/// <summary>
		/// 上一次按下的按钮的命令编号
		/// </summary>
		public int LastCommandID
		{
			get{ return myLastButton == null ? -1 : myLastButton.CommandID  ;}
		}
		
		/// <summary>
		/// 上一次按下的按钮对象
		/// </summary>
		public ZYButton LastButton
		{
			get{ return myLastButton ;}
		}

		public ZYButton CurrentButton
		{
			get{ return myCurrentButton ;}
			set
			{
				myCurrentButton = value;
				if( myCurrentButton != null)
				{
					myCurrentButton.Pushed = true;
					myCurrentButton.Pushing = false;
					this.RefreshButtonView( myCurrentButton );
					foreach( ZYButton myButton in myButtons)
					{
						if( myButton.Visible 
							&& myButton.GroupID == myCurrentButton.GroupID 
							&& myButton != myCurrentButton 
							&& (myButton.Pushed  || myButton.Pushing ) )
						{
							myButton.Pushed = false;
							myButton.Pushing = false;
							this.RefreshButtonView( myButton );
							//break;
						}
					}//foreach
					RaiseOnClick();
					myLastButton = myCurrentButton ;
				}//if
			}//set
		}//

		public void RaiseOnClick()
		{
			if( this.bolEnableClickEvent && this.OnClick != null )
			{
				bolEnableClickEvent = false;
				this.OnClick( this , myCurrentButton );
				bolEnableClickEvent = true;
			}
		}

	
		#region IDisposable 成员*******************************************************************

		public void Dispose()
		{
			if( myButtonImage != null)
			{
				myButtonImage.Dispose();
				myButtonImage = null;
			}
		}

		#endregion

		private void OwnerControl_MouseDown(object sender, MouseEventArgs e)
		{
			this.HandleMouseDown( e.X , e.Y , e.Button );
		}

		private void OwnerControl_MouseMove(object sender, MouseEventArgs e)
		{
			this.HandleMouseMove(e.X , e.Y , e.Button );
		}

		private void OwnerControl_MouseUp(object sender, MouseEventArgs e)
		{
			this.HandleMouseUp(e.X , e.Y , e.Button );
		}

		private void OwnerControl_Paint(object sender, PaintEventArgs e)
		{
			this.RefreshView( e.Graphics , e.ClipRectangle );
		}
	}//public class ZYButtonGroup
}
