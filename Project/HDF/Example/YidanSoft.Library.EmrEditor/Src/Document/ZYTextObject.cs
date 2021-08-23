using System;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
namespace ZYTextDocumentLib
{
	/// <summary>
	/// 电子病历文本文档中内嵌对象的基础实现
	/// </summary>
	/// <remarks>本对象为文档可内嵌的对象类型的基础实现,
	/// 并提供关于内嵌对象的通用操作,包括在编辑器中的拖放操作</remarks>
	/// <seealso>ZYTextDocumentLib.ZYTextImage</seealso>
	/// <seealso>ZYTextDocumentLib.A_Resize</seealso>
	public class ZYTextObject : ZYTextElement 
	{
		public static int DragBoxSize = 6 ;
		/// <summary>
		/// 用户是否可以改变对象的大小
		/// </summary>
		protected bool bolCanResize = true;

		/// <summary>
		/// 对象宽度和高度的比例,若大于等于0.1则该设置有效，否则无效
		/// </summary>
		protected double dblWidthHeightRate = 0 ;

		/// <summary>
		/// 对象宽度高度比,若大于等于0.1则该设置有效，否则无效
		/// </summary>
		public double WidthHeightRate
		{
			get{ return dblWidthHeightRate ;}
			set{ dblWidthHeightRate = value ;}
		}

		/// <summary>
		/// 对象是否可以改变大小
		/// </summary>
		public bool CanResize
		{
			get{ return bolCanResize;}
			set{ bolCanResize = value;}
		}

		/// <summary>
		/// 对象的编号
		/// </summary>
		public string ID
		{
			get{ return myAttributes.GetString(ZYTextConst.c_ID );}
			set{ myAttributes.SetValue( ZYTextConst.c_ID , value);}
		}

		public override int Width
		{
			get
			{
				return intWidth ;
			}
			set
			{
				intWidth = value;
				myAttributes.SetValue(ZYTextConst.c_Width , value.ToString());
			}
		}
		public override int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
				myAttributes.SetValue(ZYTextConst.c_Height , value.ToString());
			}
		}

		/// <summary>
		/// 初始化对象
		/// </summary>
		public ZYTextObject()
		{
			 
		}

		public override void UpdateAttrubute()
		{
			base.Width = StringCommon.ToInt32Value( myAttributes.GetString( ZYTextConst.c_Width) , base.Width );
			base.Height = StringCommon.ToInt32Value( myAttributes.GetString(ZYTextConst.c_Height) ,base.Height );
			base.UpdateAttrubute();
		}


////
//		public void UpdateAttributeSize()
//		{
//			base.Width = StringCommon.ToInt32Value( myAttributes.GetString( ZYTextConst.c_Width) , base.Width );
//			base.Height = StringCommon.ToInt32Value( myAttributes.GetString(ZYTextConst.c_Height) ,base.Height );
//		}
		
		/// <summary>
		/// 已重载:鼠标按下事件,本事件中若按下了控制点则进行鼠标拖放操作来改变对象的大小
		/// </summary>
		/// <param name="x">鼠标光标在文档视图中的X坐标</param>
		/// <param name="y">鼠标光标在文档视图中的Y坐标</param>
		/// <param name="Button">鼠标按钮</param>
		/// <returns>是否进行了处理</returns>
		public override bool HandleMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
		{
			int size = myOwnerDocument.PixelToDocumentUnit( DragBoxSize );
			if( ShowDragRect())
			{
				System.Drawing.Rectangle[] DragRects =  YidanSoft.Library.EmrEditor.Src.Common.DocumentView.GetDragRects(new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width - 1 , this.Height - 1) , size , true);
				for( int iCount = 0 ; iCount < DragRects.Length ; iCount ++ )
				{
					if( DragRects[iCount].Contains(x,y))
					{
						// 若命中一个控制点则进行鼠标拖放操作来改变对象大小
						if( myOwnerDocument.OwnerControl != null)
						{
							System.Drawing.Rectangle NewRect = myOwnerDocument.OwnerControl.CaptureDragRect( this.Bounds , iCount , true , dblWidthHeightRate , true , null);
							if( NewRect.Width > 10 && NewRect.Height > 10)
							{
								//myAttributes.SetValue( ZYTextConst.c_Width ,this.Width.ToString() );
								//myAttributes.SetValue( ZYTextConst.c_Height , this.Height.ToString() );
								myOwnerDocument.BeginContentChangeLog();
								//myAttributes.SetValue(ZYTextConst.c_Width , NewRect.Width.ToString());
								//myAttributes.SetValue(ZYTextConst.c_Height , NewRect.Height.ToString());
								this.Width = NewRect.Width ;
								this.Height = NewRect.Height ;
								myOwnerDocument.EndContentChangeLog();
								myOwnerDocument.RefreshLine();
								myOwnerDocument.UpdateView();
								myOwnerDocument.Modified = true;
								return true;
							}
						}
						return true;
					}
				}
			}
			return false;
		}// HandleMouseDown

		/// <summary>
		/// 以重载:处理鼠标移动事件
		/// </summary>
		/// <param name="x">鼠标光标在文档中的X坐标</param>
		/// <param name="y">鼠标光标在文档中的Y坐标</param>
		/// <param name="Button">鼠标按键</param>
		/// <returns>是否处理了该事件</returns>
		/// <seealso>ZYTextDocumentLib.ZYTextElement.HandleMouseMove</seealso>
		public override bool HandleMouseMove(int x, int y, System.Windows.Forms.MouseButtons Button)
		{



			int size = myOwnerDocument.PixelToDocumentUnit( DragBoxSize );
			if( ShowDragRect() )
			{
				System.Drawing.Rectangle[] DragRects =  YidanSoft.Library.EmrEditor.Src.Common.DocumentView.GetDragRects(new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width - 1 , this.Height - 1) , size , true);
				for( int iCount = 0 ; iCount < DragRects.Length ; iCount ++ )
				{
					if( DragRects[iCount].Contains(x,y))
					{
						System.Windows.Forms.Cursor myCursor = YidanSoft.Library.EmrEditor.Src.Common.DocumentView.GetDragRectCursor( iCount);
                        if (myCursor != null)
                        {
                            myOwnerDocument.SetCursor(myCursor);
                            //myOwnerDocument.SetCursor(Cursors.Cross);
                            //this.OwnerDocument.OwnerControl.Cursor = myCursor;
                            Debug.WriteLine("图片的拖动光标");
                        }
						return true;
					}
				}
			}
			if( this.Bounds.Contains(x,y))
				myOwnerDocument.SetCursor( System.Windows.Forms.Cursors.Default );
			return false;
		}

		/// <summary>
		/// 处理鼠标单击事件
		/// </summary>
		/// <param name="x">鼠标光标在文档中的X坐标</param>
		/// <param name="y">鼠标光标在文档中的Y坐标</param>
		/// <param name="Button">鼠标按键</param>
		/// <returns>是否处理了该事件</returns>
		/// <seealso>ZYTextDocumentLib.ZYTextElement.HandleClick</seealso>
		public override bool HandleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
		{
            if (this.Bounds.Contains(x, y) && myOwnerDocument.Content.SelectLength == 0)
            {
                myOwnerDocument.Content.SetSelection(myOwnerDocument.IndexOf(this), 1);
                myOwnerDocument.RefreshElement(this);
                myOwnerDocument.HideCaret();
                return true;
            }
			return false;
		}
 
		/// <summary>
		/// 重新绘制对象，若对象需要显示拖拽矩形则绘制边框和拖拽矩形
		/// </summary>
		/// <returns>操作是否成功</returns>
		/// <seealso>ZYTextDocumentLib.ZYTextElement.RefreshView</seealso>
		public override bool RefreshView( )
		{
			int size = myOwnerDocument.PixelToDocumentUnit( DragBoxSize );
			if( myOwnerDocument.isSelected(this) )
			{
				if( ShowDragRect() )
				{
					myOwnerDocument.View.DrawRectangle( System.Drawing.Color.Black , new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width  - 1 , this.Height - 1));
					myOwnerDocument.View.DrawDragRect(new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width - 1 , this.Height - 1) , size , true , System.Drawing.Color.Black , System.Drawing.Color.White  );
				}
				else if( this.Deleteted == false && myOwnerDocument.Content.CurrentSelectElement == this )
					myOwnerDocument.View.DrawRectangle( System.Drawing.Color.Black ,new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width - 1, this.Height -1 ) );
				//else myOwnerDocument.View.DrawSelectionFrame( myBounds );
			}
			//myBorder.Draw(myGraph,x,y,intWidth,intHeight);
			return true;
		}

		/// <summary>
		/// 对象是否显示拖放矩形
		/// </summary>
		/// <remarks>只有文档中选择了当前对象且只有该选择选择时才显示拖放矩形，
		/// 此时用户可以用鼠标来进行拖放操作</remarks>
		/// <returns>是否显示拖放矩形</returns>
		protected bool ShowDragRect()
		{
			if( myOwnerDocument.IsLock( this ))
				return false;
			return bolCanResize  && myParent.Locked == false && (this.Deleteted == false) && ( myOwnerDocument.Content.CurrentSelectElement == this) ;
		}
	}// class ZYTextObject
}
