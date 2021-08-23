using System;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
namespace ZYTextDocumentLib
{
	/// <summary>
	/// ���Ӳ����ı��ĵ�����Ƕ����Ļ���ʵ��
	/// </summary>
	/// <remarks>������Ϊ�ĵ�����Ƕ�Ķ������͵Ļ���ʵ��,
	/// ���ṩ������Ƕ�����ͨ�ò���,�����ڱ༭���е��ϷŲ���</remarks>
	/// <seealso>ZYTextDocumentLib.ZYTextImage</seealso>
	/// <seealso>ZYTextDocumentLib.A_Resize</seealso>
	public class ZYTextObject : ZYTextElement 
	{
		public static int DragBoxSize = 6 ;
		/// <summary>
		/// �û��Ƿ���Ըı����Ĵ�С
		/// </summary>
		protected bool bolCanResize = true;

		/// <summary>
		/// �����Ⱥ͸߶ȵı���,�����ڵ���0.1���������Ч��������Ч
		/// </summary>
		protected double dblWidthHeightRate = 0 ;

		/// <summary>
		/// �����ȸ߶ȱ�,�����ڵ���0.1���������Ч��������Ч
		/// </summary>
		public double WidthHeightRate
		{
			get{ return dblWidthHeightRate ;}
			set{ dblWidthHeightRate = value ;}
		}

		/// <summary>
		/// �����Ƿ���Ըı��С
		/// </summary>
		public bool CanResize
		{
			get{ return bolCanResize;}
			set{ bolCanResize = value;}
		}

		/// <summary>
		/// ����ı��
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
		/// ��ʼ������
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
		/// ������:��갴���¼�,���¼����������˿��Ƶ����������ϷŲ������ı����Ĵ�С
		/// </summary>
		/// <param name="x">��������ĵ���ͼ�е�X����</param>
		/// <param name="y">��������ĵ���ͼ�е�Y����</param>
		/// <param name="Button">��갴ť</param>
		/// <returns>�Ƿ�����˴���</returns>
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
						// ������һ�����Ƶ����������ϷŲ������ı�����С
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
		/// ������:��������ƶ��¼�
		/// </summary>
		/// <param name="x">��������ĵ��е�X����</param>
		/// <param name="y">��������ĵ��е�Y����</param>
		/// <param name="Button">��갴��</param>
		/// <returns>�Ƿ����˸��¼�</returns>
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
                            Debug.WriteLine("ͼƬ���϶����");
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
		/// ������굥���¼�
		/// </summary>
		/// <param name="x">��������ĵ��е�X����</param>
		/// <param name="y">��������ĵ��е�Y����</param>
		/// <param name="Button">��갴��</param>
		/// <returns>�Ƿ����˸��¼�</returns>
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
		/// ���»��ƶ�����������Ҫ��ʾ��ק��������Ʊ߿����ק����
		/// </summary>
		/// <returns>�����Ƿ�ɹ�</returns>
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
		/// �����Ƿ���ʾ�Ϸž���
		/// </summary>
		/// <remarks>ֻ���ĵ���ѡ���˵�ǰ������ֻ�и�ѡ��ѡ��ʱ����ʾ�Ϸž��Σ�
		/// ��ʱ�û�����������������ϷŲ���</remarks>
		/// <returns>�Ƿ���ʾ�Ϸž���</returns>
		protected bool ShowDragRect()
		{
			if( myOwnerDocument.IsLock( this ))
				return false;
			return bolCanResize  && myParent.Locked == false && (this.Deleteted == false) && ( myOwnerDocument.Content.CurrentSelectElement == this) ;
		}
	}// class ZYTextObject
}
