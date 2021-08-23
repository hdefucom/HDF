using System;
using System.Windows.Forms ;
using System.Drawing ;
namespace ZYCommon
{
	
	/// <summary>
	/// ��ť�鰴ť�����¼�ί��
	/// </summary>
	public delegate void ZYButtonClickHandler( ZYButtonGroup ButtonGroup , ZYButtonGroup.ZYButton Button );

	/// <summary>
	/// ��ť�����
	/// </summary>
	public class ZYButtonGroup : System.IDisposable
	{
		/// <summary>
		/// ��ʾһ����ť����
		/// </summary>
		public class ZYButton
		{
			/// <summary>
			/// ��ʾ����ʾ�ı�
			/// </summary>
			public string	ToolTip = null;
			/// <summary>
			/// �����ı�
			/// </summary>
			public string	Command = "" ;
			/// <summary>
			/// ������
			/// </summary>
			public int		CommandID = 0 ;
			/// <summary>
			/// ��0��ʼ��ͼ���б����
			/// </summary>
			public int		ImageIndex = -1 ;
			/// <summary>
			/// �Ƿ�ɼ�
			/// </summary>
			public bool		Visible = true;
			/// <summary>
			/// �Ƿ����
			/// </summary>
			public bool		Enable = true;
			/// <summary>
			/// ��ť���ڱ�����
			/// </summary>
			public bool		Pushing = false;
			/// <summary>
			/// �Ƿ��ڰ���״̬
			/// </summary>
			public bool		Pushed = false;
			/// <summary>
			/// ��ť�ڰ�ť���е����λ��
			/// </summary>
			public int		Left = 0 ;
			/// <summary>
			/// ��ť�ڰ�ť���еĶ���λ��
			/// </summary>
			public int		Top = 0 ;
			/// <summary>
			/// ��ť���
			/// </summary>
			public int		Width =16 ; 
			/// <summary>
			/// ��ť�߶�
			/// </summary>
			public int		Height =16 ;
			/// <summary>
			/// �ð�ť���ڵ����
			/// </summary>
			public int		GroupID = 0 ;
			/// <summary>
			/// ��ť���ڵİ�ť�����
			/// </summary>
			public ZYButtonGroup OwnerGroup = null;
			/// <summary>
			/// ��ť����ʱ���¼�����
			/// </summary>
			//public event System.EventHandler OnClick  ;
			/// <summary>
			/// ���ذ�ť�ı߿�
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
		/// ��������æ��־
		/// </summary>
		private bool bolEnableClickEvent = true;


		/// <summary>
		/// �������ʾ�߶�
		/// </summary>
		private int intPerformHeight = 0 ;
		private int intPerformWidth = 0 ;
		/// <summary>
		/// ���ƶ���Ŀؼ�����
		/// </summary>
		public System.Windows.Forms.Control OwnerControl = null;

		/// <summary>
		/// ��ť�����¼�����
		/// </summary>
		public event ZYButtonClickHandler OnClick = null;

		/// <summary>
		/// ������ʾ�ĸ߶�
		/// </summary>
		public int PerformHeight
		{
			get{ return intPerformHeight;}
		}
		/// <summary>
		/// ������ʾ�Ŀ��
		/// </summary>
		public int PerformWidth
		{
			get{ return intPerformWidth ;}
		}

		/// <summary>
		/// �󶨻��ƶ���Ŀؼ�
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
		/// ��ť���󼯺�
		/// </summary>
		public System.Collections.ArrayList Buttons
		{
			get{ return myButtons ;}
		}

		/// <summary>
		/// ���һ���µİ�ť
		/// </summary>
		/// <param name="vImageIndex">��ťͼ�����</param>
		/// <param name="vCommandID">��ť������</param>
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
		/// ����ͼ��
		/// </summary>
		/// <param name="myImg">ͼƬ����</param>
		/// <param name="vICONWidth">ͼ��Ŀ��</param>
		/// <param name="vICONHeight">ͼ��ĸ߶�</param>
		public void SetButtonImage( System.Drawing.Image myImg , int vICONWidth , int vICONHeight )
		{
			myButtonImage = myImg ;
			intICONWidth = vICONWidth ;
			intICONHeight = vICONHeight ;
		}

		/// <summary>
		/// ���ָ����ŵ���ͼ����ͼƬ�����еľ�������λ��,����������򷵻ؿվ���
		/// </summary>
		/// <param name="ImageIndex">��0��ʼ��ͼ�����</param>
		/// <returns>ͼ����ͼƬ�����еľ��������λ��,����������򷵻ؿվ���</returns>
		public System.Drawing.Rectangle GetICONImageRange( int ImageIndex)
		{
			if( ImageIndex >= 0
				&& myButtonImage != null
				&& intICONWidth > 0 
				&&  intICONHeight > 0 
				&& myButtonImage.Size.Width > intICONWidth )
			{
				// ����ͼƬ��ÿ��ͼ��ĸ���
				int LineNum = (int)System.Math.Floor( myButtonImage.Size.Width / (double)intICONWidth );
				if( LineNum > 0 )
				{
					System.Drawing.Rectangle myRect = new Rectangle
						( intICONWidth * ( ImageIndex % LineNum ) ,
                        //TODO:�������һ��Convert.ToDouble()
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
		/// ��ťĬ�Ͽ��
		/// </summary>
		public int DefaultButtonWidth
		{
			get{ return intDefaultButtonWidth;}
			set{ intDefaultButtonWidth = value;}
		}
		/// <summary>
		/// ��ťĬ�ϸ߶�
		/// </summary>
		public int DefaultButtonHeight
		{
			get{ return intDefaultButtonHeight ;}
			set{ intDefaultButtonHeight = value;}
		}
		/// <summary>
		/// �������λ��
		/// </summary>
		public int Left
		{
			get{ return intLeft;}
			set{ intLeft = value;}
		}
		/// <summary>
		/// ���󶥶�λ��
		/// </summary>
		public int Top
		{
			get{ return intTop ;}
			set{ intTop = value;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int Width
		{
			get{ return intWidth;}
			set{ intWidth = value;}
		}
		/// <summary>
		/// ����߶�
		/// </summary>
		public int Height
		{
			get{ return intHeight;}
			set{ intHeight = value;}
		}
		/// <summary>
		/// ���ؿͻ�������λ��
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
		/// ���¼�������ڲ���ť��λ��
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
		/// ���»��ƶ���
		/// </summary>
		/// <param name="Graph">���ƶ���ʹ�õĻ�ͼ����</param>
		/// <param name="ClipRect">���Ƽ��о���</param>
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
							// ���Ʊ߿�
							System.Windows.Forms.ControlPaint.DrawButton( Graph , ButtonRect , ( myButton.Pushed ? System.Windows.Forms.ButtonState.Pushed  : System.Windows.Forms.ButtonState.Normal )); 
							// ���Ƶ�
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
		/// ������갴ť�����¼�
		/// </summary>
		/// <param name="x">��������û������е����λ��</param>
		/// <param name="y">��������û������еĶ���λ��</param>
		/// <param name="Button">��갴ť</param>
		/// <returns>�Ƿ������갴ť�����¼�</returns>
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
		/// ��һ�ΰ��µİ�ť��������
		/// </summary>
		public int LastCommandID
		{
			get{ return myLastButton == null ? -1 : myLastButton.CommandID  ;}
		}
		
		/// <summary>
		/// ��һ�ΰ��µİ�ť����
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

	
		#region IDisposable ��Ա*******************************************************************

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
