using System;
using YidanSoft.Library.EmrEditor.Src.Common;
//using XDesignerCommon ;

namespace XDesignerDrawer
{
	/// <summary>
	/// DrawerUtil 的摘要说明。
	/// </summary>
	internal sealed class DrawerUtil
	{
	
		public static System.Drawing.RectangleF FixClipBounds( System.Drawing.Graphics g , float left , float top , float width , float height )
		{
			System.Drawing.GraphicsUnit unit = g.PageUnit ;
			double ratex = g.DpiX ;
			double ratey = g.DpiY ;
			switch( unit )
			{
				case System.Drawing.GraphicsUnit.Document :
					ratex = 300 ;
					ratey = 300 ;
					break;
				case System.Drawing.GraphicsUnit.Inch :
					ratex = 1 ;
					ratey = 1 ;
					break;
				case System.Drawing.GraphicsUnit.Millimeter :
					ratex = 25.4 ;
					ratey = 25.4 ;
					break;
				case System.Drawing.GraphicsUnit.Point :
					ratex = 72 ;
					ratey = 72 ;
					break;
			}
			ratex = ratex / g.DpiX ;
			ratey = ratey / g.DpiY ;

			double left2 = Math.Ceiling(  left / ratex ) * ratex ;
			double top2 = Math.Ceiling( top / ratey ) * ratey ;
			double width2 = Math.Ceiling( width / ratex ) * ratex ;
			double height2 = Math.Ceiling( height / ratey ) * ratey ;

			if( left2 > left )
			{
				left2 = left2 - ratex ;
				if( width2 < width )
					width2 += ratex ;
				width2 += ratex ;
			}
			if( top2 > top )
			{
				top2 = top - ratey ;
				if( height2 < height )
					height2 += ratey ;
				height2 += ratey ;
			}
			return new System.Drawing.RectangleF( ( float ) left2 , ( float ) top2 , ( float ) width2 , ( float ) height2 );
		}

		public static System.Drawing.Drawing2D.Matrix RotateGraphics( 
			System.Drawing.Graphics g , 
			System.Drawing.Rectangle Bounds ,
			float Angle )
		{
			//			System.Drawing.Point cp = RectangleCommon.Center( Bounds );
			//			System.Drawing.Rectangle rect = new System.Drawing.Rectangle ( 
			//				cp.X - ContentBounds.Width / 2 ,
			//				cp.Y - ContentBounds.Height / 2 ,
			//				ContentBounds.Width ,
			//				ContentBounds.Height );


			System.Drawing.Drawing2D.Matrix om = g.Transform ;
			System.Drawing.Drawing2D.Matrix nm = om.Clone();
			System.Drawing.Point p = RectangleCommon.Center( Bounds );
			nm.RotateAt( Angle , new System.Drawing.PointF( p.X , p.Y ));
			g.Transform = nm ;
			return om ;
		}
		public static System.Drawing.Drawing2D.Matrix SwapMatrix(
			System.Drawing.Graphics g , 
			System.Drawing.Drawing2D.Matrix m )
		{
			System.Drawing.Drawing2D.Matrix m2 = g.Transform ;
			g.Transform = m ;
			return m2 ;
		}

		private DrawerUtil()
		{
		}
	}
}
