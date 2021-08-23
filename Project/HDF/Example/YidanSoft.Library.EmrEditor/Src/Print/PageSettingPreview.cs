using System;

namespace XDesignerGUI
{
	/// <summary>
	/// ҳ������Ԥ���������
	/// </summary>
	public class PageSettingPreview
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public PageSettingPreview()
		{
		}

		private System.Drawing.Printing.PaperSize myPaperSize = null;
		/// <summary>
		/// ֽ�Ŵ�С
		/// </summary>
		public System.Drawing.Printing.PaperSize PaperSize
		{
			get{ return myPaperSize ;}
			set{ myPaperSize = value;}
		}
		private System.Drawing.Printing.Margins myMargins = new System.Drawing.Printing.Margins( 100 , 100 , 100 , 100 );
		/// <summary>
		/// ҳ�߾�
		/// </summary>
		public System.Drawing.Printing.Margins Margins
		{
			get{ return myMargins ;}
			set{ myMargins = value;}
		}
		private bool bolLandscape = false;
		/// <summary>
		/// �����ӡ���
		/// </summary>
		public bool Landscape
		{
			get{ return bolLandscape ;}
			set{ bolLandscape = value;}
		}
		public void SetPagetSettings( System.Drawing.Printing.PageSettings ps )
		{
			myPaperSize = ps.PaperSize ;
			myMargins = ps.Margins ;
			bolLandscape = ps.Landscape ;
		}

		private System.Drawing.Rectangle myBounds = System.Drawing.Rectangle.Empty ;
		/// <summary>
		/// ����߽����
		/// </summary>
		public System.Drawing.Rectangle Bounds
		{
			get{ return myBounds ;}
			set{ myBounds = value;}
		}
		
		/// <summary>
		/// ����ҳ������Ԥ������
		/// </summary>
		/// <param name="sender">�¼�������</param>
		/// <param name="e">��ͼ�¼���������</param>
		public void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e )
		{
			int PageWidth = ( bolLandscape == false ? myPaperSize.Width : myPaperSize.Height );
			int PageHeight= ( bolLandscape == false ? myPaperSize.Height : myPaperSize.Width  );
			double Rate = 1 ;
			if( ( PageWidth / (double)myBounds.Width ) > ( PageHeight / (double)myBounds.Height ))
				Rate =  ( 1.1 * PageWidth / ( double ) myBounds.Width ) ;
			else
				Rate =  ( 1.1 * PageHeight /( double ) myBounds.Height );
			System.Drawing.Rectangle rect = new System.Drawing.Rectangle( 0 , 0 , ( int ) ( PageWidth / Rate ) , ( int) ( PageHeight / Rate ));
			rect.X = myBounds.Left + ( myBounds.Width - rect.Width ) /2 ;
			rect.Y = myBounds.Top + ( myBounds.Height - rect.Height ) / 2 ;
			if( rect.IntersectsWith( e.ClipRectangle ) )
			{
				e.Graphics.FillRectangle( System.Drawing.Brushes.White , rect );
				e.Graphics.DrawRectangle( System.Drawing.Pens.Black , rect );
				System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle( 
					(int)(rect.Left + myMargins.Left / Rate ),
					(int) ( rect.Top + myMargins.Top / Rate ),
					(int) ( rect.Width - ( myMargins.Left + myMargins.Right ) / Rate ),
					(int) ( rect.Height - ( myMargins.Top + myMargins.Bottom ) / Rate ));
				e.Graphics.DrawRectangle( System.Drawing.Pens.Red , rect2 );
			}
		}
	}//public class PageSettingPreview : VirtualControlBase
}