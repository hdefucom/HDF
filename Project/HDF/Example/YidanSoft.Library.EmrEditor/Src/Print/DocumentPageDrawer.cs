using System;
using YidanSoft.Library.EmrEditor.Src.Print;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Document; //add by myc 2014-07-22 ���ԭ������Document�����ռ�
using XDesignerDrawer;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
//using XDesignerGUI ;
//using XDesignerDrawer ;

namespace XDesignerPrinting
{
	/// <summary>
	/// �ĵ�ҳ����ƶ���
	/// </summary>
	/// <remarks>
	/// ����������ʹ��ҳ��ķ�ʽ�����ĵ������ݡ�
	/// </remarks>
	public class DocumentPageDrawer
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public DocumentPageDrawer()
		{
		}
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="doc">�ĵ�����</param>
		/// <param name="pages">ҳ�漯��</param>
		public DocumentPageDrawer( IPageDocument doc , PrintPageCollection pages )
		{
			this.myDocument = doc ;
			this.myPages = pages ;
		}

		/// <summary>
		/// �����ĵ�ָ��ҳ��λͼ
		/// </summary>
		/// <param name="doc">�ĵ�����</param>
		/// <param name="pages">ҳ�漯��</param>
		/// <param name="PageIndex">ָ��ҳ�����</param>
		/// <param name="DrawBorder">�Ƿ����ҳ��߿�</param>
		/// <returns>���ɵ�BMPλͼ�ĵ�����</returns>
		public static System.Drawing.Bitmap GetPageBmp( 
			IPageDocument doc , 
			PrintPageCollection pages ,
			int PageIndex ,
			bool DrawBorder )
		{
			DocumentPageDrawer drawer = new DocumentPageDrawer();
			drawer.Document = doc ;
			drawer.Pages = pages ;
			drawer.BackColor = System.Drawing.Color.White ;
			if( DrawBorder )
				drawer.BorderColor = System.Drawing.Color.Black ;
			else
				drawer.BorderColor = System.Drawing.Color.Transparent ;
			System.Drawing.Bitmap bmp = drawer.GetPageBmp( pages[ PageIndex ] , true );
			return bmp ;
		}

//		/// <summary>
//		/// �����ĵ�ָ��ҳ��λͼ
//		/// </summary>
//		/// <param name="doc">�ĵ�����</param>
//		/// <param name="pages">ҳ�漯��</param>
//		/// <param name="PageIndex">ָ��ҳ�����</param>
//		/// <param name="DrawBorder">�Ƿ����ҳ��߿�</param>
//		/// <returns>���ɵ�BMPλͼ�ĵ�����</returns>
//		public static byte[] GetPageMetafile( 
//			IPageDocument doc , 
//			PrintPageCollection pages ,
//			int PageIndex ,
//			bool DrawBorder )
//		{
//			DocumentPageDrawer drawer = new DocumentPageDrawer();
//			drawer.Document = doc ;
//			drawer.Pages = pages ;
//			drawer.BackColor = System.Drawing.Color.White ;
//			if( DrawBorder )
//				drawer.BorderColor = System.Drawing.Color.Black ;
//			else
//				drawer.BorderColor = System.Drawing.Color.Transparent ;
//			return drawer.GetMetafile( pages[ PageIndex ] , true );
//		}

		protected IPageDocument myDocument = null;
		/// <summary>
		/// �ĵ�����
		/// </summary>
		public IPageDocument Document
		{
			get{ return myDocument ;}
			set{ myDocument = value;}
		}

		protected PrintPageCollection myPages = null;
		/// <summary>
		/// ��ҳ���϶���
		/// </summary>
		public PrintPageCollection Pages
		{
			get{ return myPages ;}
			set{ myPages = value;}
		}
		/// <summary>
		/// �Ƿ����ҳü
		/// </summary>
		protected bool bolDrawHead = true;
		/// <summary>
		/// �Ƿ����ҳü
		/// </summary>
		public bool DrawHead
		{
			get{ return bolDrawHead ;}
			set{ bolDrawHead = value;}
		}

		/// <summary>
		/// �Ƿ����ҳ��
		/// </summary>
		protected bool bolDrawFooter = true;
		/// <summary>
		/// �Ƿ����ҳ��
		/// </summary>
		public bool DrawFooter
		{
			get{ return bolDrawFooter ;}
			set{ bolDrawFooter = value;}
		}

		protected System.Drawing.Color intBackColor = System.Drawing.Color.White ;
		/// <summary>
		/// ҳ�汳����ɫ
		/// </summary>
		public System.Drawing.Color BackColor
		{
			get{ return intBackColor ;}
			set{ intBackColor = value;}
		}
		protected System.Drawing.Color intBorderColor = System.Drawing.Color.Transparent ;
		/// <summary>
		/// �߿���ɫ
		/// </summary>
		public System.Drawing.Color BorderColor
		{
			get{ return intBorderColor ;}
			set{ intBorderColor = value;}
		}


//		/// <summary>
//		/// ����ָ��ҳ��ͼԪ����
//		/// </summary>
//		/// <param name="page">ҳ�����</param>
//		/// <param name="DrawMargin">�Ƿ���Ʊ߾���</param>
//		/// <returns>����ͼԪ���ݵ��ֽ�����</returns>
//		public byte[] GetMetafile( PrintPage page , bool DrawMargin )
//		{
//			System.Drawing.Imaging.Metafile meta = null ;
//			using( Windows32.DeviceContexts dc = Windows32.DeviceContexts.CreateCompatibleDC( IntPtr.Zero ))
//			{
//				System.IO.MemoryStream stream = new System.IO.MemoryStream();
//				meta = new System.Drawing.Imaging.Metafile( 
//					stream , 
//					dc.HDC , 
//					new System.Drawing.Rectangle( 0 , 0 , myPages.PaperWidth , myPages.PaperHeight ),
//					//System.Drawing.Imaging.MetafileFrameUnit.Document );
//					PrintUtil.ConvertUnit( myDocument.DocumentGraphicsUnit ));
//				using(System.Drawing.Graphics g2 = System.Drawing.Graphics.FromImage( meta ))
//				{
//					if( intBackColor.A != 0 )
//						g2.Clear( this.intBackColor );
//
//					g2.PageUnit = myDocument.DocumentGraphicsUnit ;
//
//					PageFrameDrawer drawer = new PageFrameDrawer();
//					drawer.DrawMargin = DrawMargin ;
//					drawer.BackColor = System.Drawing.Color.Transparent ;
//					drawer.BorderColor = this.intBorderColor ;
//					drawer.BorderWidth = 1 ;
//					drawer.LeftMargin = myPages.LeftMargin ;
//					drawer.TopMargin = myPages.TopMargin ;
//					drawer.RightMargin = myPages.RightMargin ;
//					drawer.BottomMargin = myPages.BottomMargin ;
//
//					drawer.Bounds = new System.Drawing.Rectangle( 
//						0 ,
//						0 ,
//						myPages.PaperWidth , 
//						myPages.PaperHeight );
//
//					drawer.DrawPageFrame( g2 , System.Drawing.Rectangle.Empty );
//
//					DrawPage( page , g2 , page.Bounds , true );
//				}
//				meta.Dispose();
//				dc.Dispose();
//				return stream.ToArray();
//			}
//		}

		/// <summary>
		/// ���ָ��ҳ��BMPͼƬ����
		/// </summary>
		/// <param name="PageIndex">ҳ��</param>
		/// <param name="DrawMargin">�Ƿ����ҳ�߾���</param>
		/// <returns>������BMPͼƬ����</returns>
		public System.Drawing.Bitmap GetPageBmp( int PageIndex , bool DrawMargin )
		{
			return GetPageBmp( this.myPages[ PageIndex ] , DrawMargin );
		}
        /// <summary>
        /// �ڵ�ǰ���������ļ������ļ���
        /// </summary>
        /// <returns></returns>
        private string CreateFolder()
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!Directory.Exists(folder + "PrintImage\\"))
            {
                Directory.CreateDirectory(folder + "PrintImage\\");
            }
            DeleteMetaFileAll();
            return folder + "PrintImage\\";
        }
        private void DeleteMetaFileAllInner(string folder)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            foreach (FileInfo fi in dirInfo.GetFiles("*.wmf"))
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                { }
            }
        }
        private void DeleteMetaFileAll()
        {
            //ɾ��ԭ�ȱ�����C�̵��ļ�
            DeleteMetaFileAllInner(@"C:\");

            //ɾ����ӡ��Ҫ��ʸ���ļ�
            DeleteMetaFileAllInner(AppDomain.CurrentDomain.BaseDirectory + "PrintImage\\");
        }


		/// <summary>
		/// ����ָ��ҳ��BMPͼƬ����
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="DrawMargin">�Ƿ����ҳ�߾���</param>
		/// <returns>������BMPͼƬ����</returns>
        public Metafile GetPageBmp2(PrintPage page, bool DrawMargin)
		{
			double rate = GraphicsUnitConvert.GetRate( 
				myDocument.DocumentGraphicsUnit  ,
				System.Drawing.GraphicsUnit.Pixel );

			int width = ( int ) Math.Ceiling( myPages.PaperWidth / rate );
			int height = ( int ) Math.Ceiling( myPages.PaperHeight / rate );
			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap( width , height );

            Graphics g1 = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            string folder = CreateFolder();
            string m_FilePath1 = folder + Guid.NewGuid().ToString() + ".wmf";
            Metafile mf1 = new Metafile(m_FilePath1, g1.GetHdc(), rect, MetafileFrameUnit.Pixel);


			using( System.Drawing.Graphics g = System.Drawing.Graphics.FromImage( mf1 ))
			{
                //Add by wwj 2013-01-24
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

				if( intBackColor.A != 0 )
					g.Clear( this.intBackColor );

				g.PageUnit = myDocument.DocumentGraphicsUnit ;
                //Metafile mf = new Metafile(bmp,g.GetHdc(),);

				PageFrameDrawer drawer = new PageFrameDrawer();
                //Graphics gg = Graphics.FromImage(mf);

				drawer.DrawMargin = DrawMargin ;
				drawer.BackColor = System.Drawing.Color.Transparent ;
				drawer.BorderColor = this.intBorderColor ;
				drawer.BorderWidth = 1 ;
				drawer.LeftMargin = myPages.LeftMargin ;
				drawer.TopMargin = myPages.TopMargin ;
				drawer.RightMargin = myPages.RightMargin ;
				drawer.BottomMargin = myPages.BottomMargin ;

				drawer.Bounds = new System.Drawing.Rectangle( 
					0 ,
					0 ,
					myPages.PaperWidth , 
					myPages.PaperHeight );

				drawer.DrawPageFrame( g , System.Drawing.Rectangle.Empty );

				DrawPage( page , g , page.Bounds , true );
			}
            return mf1;
		}
        /// <summary>
        /// ����ָ��ҳ��BMPͼƬ����
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="DrawMargin">�Ƿ����ҳ�߾���</param>
        /// <returns>������BMPͼƬ����</returns>
        public Bitmap  GetPageBmp(PrintPage page, bool DrawMargin)
        {
            double rate = GraphicsUnitConvert.GetRate(
                myDocument.DocumentGraphicsUnit,
                System.Drawing.GraphicsUnit.Pixel);

            int width = (int)Math.Ceiling(myPages.PaperWidth / rate);
            int height = (int)Math.Ceiling(myPages.PaperHeight / rate);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(width, height);

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
            {
                //Add by wwj 2013-01-24
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                if (intBackColor.A != 0)
                    g.Clear(this.intBackColor);

                g.PageUnit = myDocument.DocumentGraphicsUnit;
                //Metafile mf = new Metafile(bmp,g.GetHdc(),);

                PageFrameDrawer drawer = new PageFrameDrawer();
                //Graphics gg = Graphics.FromImage(mf);

                drawer.DrawMargin = DrawMargin;
                drawer.BackColor = System.Drawing.Color.Transparent;
                drawer.BorderColor = this.intBorderColor;
                drawer.BorderWidth = 1;
                drawer.LeftMargin = myPages.LeftMargin;
                drawer.TopMargin = myPages.TopMargin;
                drawer.RightMargin = myPages.RightMargin;
                drawer.BottomMargin = myPages.BottomMargin;

                drawer.Bounds = new System.Drawing.Rectangle(
                    0,
                    0,
                    myPages.PaperWidth,
                    myPages.PaperHeight);

                drawer.DrawPageFrame(g, System.Drawing.Rectangle.Empty);

                DrawPage(page, g, page.Bounds, true);
            }
            return bmp;
        }


		/// <summary>
		/// ��ʼ���һ��ҳ��ǰִ�еĹ���
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="g">ͼ�λ��ƶ���</param>
		protected virtual void OnBeforeDrawPage( PrintPage page , System.Drawing.Graphics g )
		{
			myDocument.PageIndex = page.Index ;
		}

		/// <summary>
		/// ��ӡָ��ҳ��
		/// </summary>
		/// <param name="myPage">ҳ�����</param>
		/// <param name="g">��ͼ��������</param>
		/// <param name="MainClipRect">�����о���</param>
		/// <param name="PrintHead">�Ƿ��ӡҳü</param>
		/// <param name="PrintTail">�Ƿ��ӡҳ��</param>
		public virtual void DrawPage(
			PrintPage myPage ,
			System.Drawing.Graphics g ,
			System.Drawing.Rectangle MainClipRect ,
			bool UseMargin )
		{
			int LeftMargin = 0 ;
			int TopMargin = 0 ;
			int RightMargin = 0 ;
			int BottomMargin = 0 ;
			if( UseMargin )
			{
				LeftMargin = myPages.LeftMargin ;
				TopMargin = myPages.TopMargin ;
				RightMargin = myPages.RightMargin ;
				BottomMargin = myPages.BottomMargin ;
			}

			this.OnBeforeDrawPage( myPage , g );

			g.PageUnit = myDocument.DocumentGraphicsUnit ;
			System.Drawing.Rectangle ClipRect = System.Drawing.Rectangle.Empty ;
			if( this.bolDrawHead )
			{
				//if( myPages.HeadHeight > 0 )
                if(myPage.HeaderHeight > 0) //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ������Ҫ
				{
					g.ResetTransform();
					g.ResetClip();

					//ClipRect = new System.Drawing.Rectangle( 0 , 0 , myPage.Width , myPages.HeadHeight );
                    //ClipRect = new System.Drawing.Rectangle(0, 0, myPage.Width, myPage.HeaderHeight); //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ������Ҫ����>���ַ�ʽ���У�����ת������ϵ��ϵ
                    ClipRect = (myPages.OwnerDocument.OwnerControl.PagesTransform.GetHBFTransforms(0)[myPages.IndexOf(myPage)] as SimpleRectangleTransform).DescRect; //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ������Ҫ����>2014-07-24 ҳü�����ĺ�ҳ��ͳһ�����޸�

                    //g.TranslateTransform(LeftMargin, TopMargin); //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ������Ҫ
                    g.TranslateTransform(LeftMargin, TopMargin - ClipRect.Top); //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ������Ҫ

					g.SetClip( new System.Drawing.Rectangle(
						ClipRect.Left ,
						ClipRect.Top  ,
						ClipRect.Width + 1 ,
						ClipRect.Height + 1 ));

					myDocument.DrawHead( g , ClipRect );
                    //DesignPaintEventArgs e = new DesignPaintEventArgs(g, ClipRect);
                    //myDocument.RefreshView(e);
				}
				g.ResetClip();
				g.ResetTransform();
            }

            ClipRect = new System.Drawing.Rectangle(
                0,
                myPages.Top,
                myPage.Width,
                myPages.Height);
            if( ! MainClipRect.IsEmpty )
			{
				ClipRect = System.Drawing.Rectangle.Intersect( ClipRect , MainClipRect );
			}
			if( ! ClipRect.IsEmpty )
			{
                //g.TranslateTransform( 
                //    LeftMargin ,
                //    TopMargin - myPage.Top + myPages.HeadHeight );
                g.TranslateTransform(
                    LeftMargin,
                    TopMargin - myPage.Top + myPage.HeaderHeight); //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ�֮�������ĵ���

				
                //System.Drawing.Drawing2D.GraphicsPath clipPath = new System.Drawing.Drawing2D.GraphicsPath();
				//clipPath.AddRectangle( ClipRect );
				//g.SetClip( clipPath );
				
				//g.TranslateTransform( myPages.LeftMargin , myPages.TopMargin - myPage.Top + myPages.HeadHeight );
				
				System.Drawing.RectangleF rect = DrawerUtil.FixClipBounds(
					g ,
					ClipRect.Left , 
					ClipRect.Top ,
					ClipRect.Width ,
					ClipRect.Height);

                rect.Offset(-4, -4);
                //rect.Offset(-4, -100);
				rect.Width = rect.Width + 8 ;
				rect.Height = rect.Height + 8 ;
				g.SetClip( rect );

//				System.Drawing.RectangleF rect2 = g.ClipBounds ;
//				if( rect.Top < rect2.Top )
//				{
//					float dy = rect2.Top - rect.Top ;
//					rect.Y = rect.Y - dy * 2 ;
//					rect.Height = rect.Height + dy * 4 ; 
//				}
//				g.SetClip( rect );

				myDocument.DrawDocument( g , ClipRect );
				//DesignPaintEventArgs e = new DesignPaintEventArgs( g , ClipRect );
				//myDocument.RefreshView( e );
			}

			if( this.bolDrawFooter )
			{
				//if( myPages.FooterHeight > 0 )
                if (myPage.FooterHeight > 0) //add by myc 2014-07-22 ���ԭ���°�ҳ��֮������Ҫ
				{
					g.ResetClip();
					g.ResetTransform();

                    //ClipRect = new System.Drawing.Rectangle(
                    //    0,
                    //    myPages.DocumentHeight - myPages.FooterHeight,
                    //    myPage.Width,
                    //    myPages.FooterHeight);
                    //ClipRect = new System.Drawing.Rectangle(
                    //   0,
                    //   0,
                    //   myPage.Width,
                    //   myPage.FooterHeight); //add by myc 2014-07-22 ���ԭ���°�ҳ��֮������Ҫ����>���ַ�ʽ���У�����ת������ϵ��ϵ
                    ClipRect = (myPages.OwnerDocument.OwnerControl.PagesTransform.GetHBFTransforms(2)[myPages.IndexOf(myPage)] as SimpleRectangleTransform).DescRect; //add by myc 2014-07-22 ���ԭ���°�ҳ�Ż�����Ҫ����>2014-07-24 ҳü�����ĺ�ҳ��ͳһ�����޸�

                    //g.TranslateTransform(LeftMargin, TopMargin); //add by myc 2014-07-22 ���ԭ���°�ҳü���ڸİ������Ҫ
                    
					int dy = 0 ;
					if( UseMargin )
					{
						//dy = myPages.PaperHeight - myPages.BottomMargin - myPages.DocumentHeight  ;
                        dy = myPages.PaperHeight - myPages.BottomMargin - myPage.FooterHeight - ClipRect.Top; //add by myc 2014-07-22 ���ԭ���°�ҳ��֮������Ҫ
					}
					else
					{
						//dy = myPages.PaperHeight - myPages.BottomMargin - myPages.DocumentHeight - myPages.TopMargin  ;
                        dy = myPages.PaperHeight - myPages.BottomMargin - myPage.FooterHeight - myPages.TopMargin - ClipRect.Top; //add by myc 2014-07-22 ���ԭ���°�ҳ��֮������Ҫ
					}
					g.TranslateTransform( 
						LeftMargin ,
						dy );

					g.SetClip( new System.Drawing.Rectangle( 
						ClipRect.Left , 
						ClipRect.Top , 
						ClipRect.Width + 1 ,
						ClipRect.Height + 1 ));

					myDocument.DrawFooter( g , ClipRect );
					//DesignPaintEventArgs e = new DesignPaintEventArgs( g , ClipRect );
					//myDocument.RefreshView( e );
				}
			}//if( this.bolDrawFooter )
		}//public void DrawPage()
	}//public class DocumentPageDrawer
}