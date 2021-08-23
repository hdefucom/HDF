using System;
using System.Drawing ;
using System.Windows.Forms;
namespace ZYCommon
{
	
	public class ZYColorSelector
	{
		private static int[] ColorTable = {0,8421504,128,32896,32768,8421376,8388608,8388736,4227200,4210688,16744448,8404992,16711744,16512,16777215,12632256,255,65535,65280,16776960,16711680,16711935,8454143,8453888,16777088,16744576,8388863,4227327};
		private int ItemSize = 15;
		private System.Drawing.Color intForeColor = System.Drawing.Color.Black ;
		private System.Drawing.Color intBackColor = System.Drawing.Color.White ;

		private int intLeft ;
		private int intTop ;
		private int intWidth ;
		private int intHeight ;
		private System.Windows.Forms.Control myOwnerControl = null;
		private int intSelectMode = 0 ;

		///<summary>
		//// 是否显示前景颜色的选择器
		///</summary>
		private bool    bolShowForeColor   = true ;

		///<summary>
		//// 是否显示背景颜色的选择器
		///</summary>
		private bool    bolShowBackColor   = true ;


		///<summary>
		//// 是否显示前景颜色的选择器
		///</summary>
		public bool ShowForeColor
		{
			get{ return bolShowForeColor ;}
			set
			{
				bolShowForeColor = value;  
				if( bolShowForeColor == false)
					this.intSelectMode = 1;
				this.UpdateView() ;

			}
		}
		
		///<summary>
		//// 是否显示背景颜色的选择器
		///</summary>
		public bool ShowBackColor
		{
			get{ return bolShowBackColor ;}
			set
			{
				bolShowBackColor = value; 
				if( bolShowBackColor == false)
					this.intSelectMode = 0 ;
				this.UpdateView() ;
			}
		}
				

		/// <summary>
		/// 选择颜色的模式 0:选择前景颜色 1:选择背景颜色
		/// </summary>
		public int SelectMode
		{
			get{ return intSelectMode ;}
			set{ intSelectMode = value; this.UpdateView() ;}
		}

		/// <summary>
		/// 绑定到某个控件
		/// </summary>
		/// <param name="vControl"></param>
		public void BindControl( System.Windows.Forms.Control vControl)
		{
			myOwnerControl = vControl ;
			if( myOwnerControl != null)
			{
				myOwnerControl.Paint +=new PaintEventHandler(myOwnerControl_Paint);
				myOwnerControl.MouseDown +=new MouseEventHandler(myOwnerControl_MouseDown);
			}
		}

		/// <summary>
		/// 当前的前景色
		/// </summary>
		public System.Drawing.Color ForeColor
		{
			get{ return intForeColor;}
			set{ intForeColor = value; this.UpdateView() ;}
		}
		/// <summary>
		/// 当前的背景色
		/// </summary>
		public System.Drawing.Color BackColor
		{
			get{ return intBackColor ;}
			set{ intBackColor = value; this.UpdateView() ;}
		}
		/// <summary>
		/// 当前颜色
		/// </summary>
		public System.Drawing.Color CurrentColor
		{
			get{ return intSelectMode == 0 ? intForeColor : intBackColor;}
			set
			{
				if( intSelectMode == 0 )
					intForeColor = value;
				else
					intBackColor = value;
				this.UpdateView();
			}
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
		/// 获得指定的颜色选择区域的方框
		/// </summary>
		/// <param name="vForeColor">是否是前景颜色</param>
		/// <returns>方框对象</returns>
		private System.Drawing.Rectangle GetColorRect( bool vForeColor)
		{
			if( ( vForeColor && bolShowForeColor ) || ( !vForeColor && bolShowBackColor ))
			{
				System.Drawing.Rectangle myRect = new Rectangle(intLeft + 5 , intTop + 5 , ItemSize-2 , ItemSize -2);
				if( !bolShowForeColor || !bolShowBackColor)
				{
					myRect.Width = ItemSize + 4 ;
					myRect.Height = ItemSize + 4 ;
				}
				if( bolShowForeColor && bolShowBackColor )
				{
					if( !vForeColor )
					{
						myRect.X = intLeft + 11 ;
						myRect.Y = intTop + 11;
					}
				}
				//				else
				//				{
				//					myRect.Width = ItemSize + 9;
				//					myRect.Height = ItemSize + 9;
				//				}
				return myRect ;
			}
			else
				return System.Drawing.Rectangle.Empty ;
		}

		public void RefreshView( System.Drawing.Graphics Graph , System.Drawing.Rectangle ClipRect )
		{
			System.Drawing.Rectangle myRect = new Rectangle( intLeft , intTop , ItemSize * 2 , ItemSize * 2 );
			if( Graph != null)
			{
				if( myRect.IntersectsWith( ClipRect ))
				{
					System.Windows.Forms.ControlPaint.DrawButton( Graph , myRect , System.Windows.Forms.ButtonState.Pushed );
					//Graph.FillRectangle( System.Drawing.SystemBrushes.ControlLightLight , myRect.Left + 2 , myRect.Top + 2 , myRect.Width - 4 , myRect.Height - 4 );
					myRect = GetColorRect(false);
					if( myRect.IsEmpty == false)
					{
						using(System.Drawing.SolidBrush myBrush = new SolidBrush( intBackColor ))
						{
							Graph.FillRectangle( myBrush , myRect );
							Graph.DrawRectangle( ( intSelectMode == 1 ? System.Drawing.Pens.Red  : System.Drawing.Pens.Black ) , myRect );
							if( intSelectMode == 1 )
								Graph.DrawRectangle( System.Drawing.Pens.Red  , myRect.Left - 1, myRect.Top -1 ,myRect.Width + 2 , myRect.Height + 2 );
						}
					}
					myRect = GetColorRect(true);
					if( myRect.IsEmpty == false)
					{
						using(System.Drawing.SolidBrush myBrush = new SolidBrush( intForeColor ))
						{
							Graph.FillRectangle( myBrush , myRect );
							Graph.DrawRectangle( ( intSelectMode == 0 ? System.Drawing.Pens.Red  : System.Drawing.Pens.Black ) , myRect );
							if( intSelectMode == 0 )
								Graph.DrawRectangle( System.Drawing.Pens.Red  , myRect.Left - 1, myRect.Top -1 ,myRect.Width + 2 , myRect.Height + 2 );
						}
					}
				}
				for(int iCount = 0 ; iCount < ColorTable.Length ; iCount ++ )
				{
					myRect = GetItemRect( iCount );
					if( myRect.IntersectsWith( ClipRect ))
					{
						System.Windows.Forms.ControlPaint.DrawButton( Graph , myRect , System.Windows.Forms.ButtonState.Pushed );
						using(System.Drawing.SolidBrush myBrush = new SolidBrush( ZYCommon.CommonFunction.ConvertToColor( ColorTable[iCount])))
						{
							Graph.FillRectangle( myBrush , myRect.Left + 2 , myRect.Top + 2 , myRect.Width - 4 , myRect.Height - 4 );
						}
					}
				}//for
			}//if
		}//public void RefreshView()

		private System.Drawing.Rectangle GetItemRect( int index)
		{
			int Div = (int) System.Math.Ceiling( ColorTable.Length / 2.0);
			return new System.Drawing.Rectangle
				( intLeft + ItemSize * ( 2 + index % Div ),
				intTop + ( index < Div ? 0 : ItemSize ) , 
				ItemSize ,
				ItemSize );
		}

		public bool HandleMouseDown( int x , int y , System.Windows.Forms.MouseButtons Button )
		{
			if( Button == System.Windows.Forms.MouseButtons.Left )
			{
				System.Drawing.Rectangle myRect = GetColorRect(true); 
				if( myRect.IsEmpty == false &&  myRect.Contains(x ,y ))
				{
					intSelectMode = 0 ;
					UpdateView();
					return true;
				}
				myRect = GetColorRect(false);
				if( myRect.IsEmpty == false && myRect.Contains(x,y))
				{
					intSelectMode = 1 ;
					UpdateView();
					return true;
				}
				for(int iCount = 0 ; iCount < ColorTable.Length ; iCount ++ )
				{
					if( GetItemRect( iCount ).Contains( x, y ))
					{
						if( intSelectMode == 0 )
							intForeColor = ZYCommon.CommonFunction.ConvertToColor( ColorTable[iCount] );
						else
							intBackColor = ZYCommon.CommonFunction.ConvertToColor( ColorTable[iCount]);
						UpdateView();
						return true;
					}
				}//for
			}//if
			return false;
		}//public bool HandleMouseDown()
		public void UpdateView()
		{
			if( myOwnerControl != null)
				myOwnerControl.Invalidate( new System.Drawing.Rectangle( intLeft , intTop , ItemSize * 2 , ItemSize * 2 ));
		}
		//
		//		public void UpdateColorArea()
		//		{
		//			if( myOwnerControl != null)
		//				myOwnerControl.Invalidate( new System.Drawing.Rectangle( intLeft , intTop 
		//		}

		private void myOwnerControl_Paint(object sender, PaintEventArgs e)
		{
			this.RefreshView( e.Graphics ,e.ClipRectangle  );
		}

		private void myOwnerControl_MouseDown(object sender, MouseEventArgs e)
		{
			this.HandleMouseDown( e.X , e.Y , e.Button );
		}
	}//public class ZYColorSelector
}
