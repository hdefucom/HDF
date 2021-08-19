using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls ;
using DCSoft.Drawing ;
using DCSoft.Printing ;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    /// <summary>
    /// 自定义绘制文档内容
    /// </summary>
    [ToolboxItem(false)]
    public partial class ctlCustomDrawContent : UserControl
    {
        public ctlCustomDrawContent()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EnabledControlEvent = false;
            this.timer1.Start();
        }

        private void btnUnDraw_Click(object sender, EventArgs e)
        {
            myWriterControl.Document.BeforeDrawContent = null;
            myWriterControl.Document.AfterDrawContent = null;
            myWriterControl.Invalidate(true);
        }

        private void btnDrawContent_Click(object sender, EventArgs e)
        {
            myWriterControl.Document.BeforeDrawContent = new PageDocumentPaintEventHandler(this.Func_BeforeDraw);
            myWriterControl.Document.AfterDrawContent = new PageDocumentPaintEventHandler(this.Func_AfterDraw);
            myWriterControl.Invalidate(true);
        }

        private void Func_BeforeDraw(object sender, PageDocumentPaintEventArgs args)
        {
            if (args.ContentStyle == PageContentPartyStyle.Body)
            {
                // 正在绘制页眉
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Near;
                    args.Graphics.DrawString("document.BeforeDrawContent:袁永福到此一游", this.Font, Brushes.Red, args.PageClipRectangle, format);
                }
            }
        }

        private void Func_AfterDraw(object sender, PageDocumentPaintEventArgs args)
        {
            if (args.ContentStyle == PageContentPartyStyle.Body)
            {
                // 正在绘制页脚
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Near;
                    args.Graphics.DrawString("document.AfterDrawContent:袁永福到此一游", this.Font, Brushes.Red, args.PageClipRectangle, format);
                }
            }
        }

        private System.Windows.Forms.Timer tmrSinAni = null;
        private void btnInsertSinAni_Click(object sender, EventArgs e)
        {
            XTextImageElement img = this.myWriterControl.GetElementById("sinani") as XTextImageElement;
            if (img == null)
            {
                img = new XTextImageElement();
                img.ID = "sinani";
                img.Width = 400;
                img.Height = 400;
                img.KeepWidthHeightRate = false;
                this.myWriterControl.ExecuteCommand(StandardCommandNames.InsertImage, false, img);
            }
            if (tmrSinAni == null)
            {
                tmrSinAni = new Timer();
                tmrSinAni.Interval = 100;
                tmrSinAni.Tick += new EventHandler(tmrSinAni_Tick);
            }
            tmrSinAni.Start();
        }

        float currentValue = 0;
        void tmrSinAni_Tick(object sender, EventArgs e)
        {
            if (this.myWriterControl.IsDisposed)
            {
                return;
            }
            XTextImageElement img = this.myWriterControl.GetElementById("sinani") as XTextImageElement;
            if (img != null)
            {
                currentValue += 1;
                List<PointF> ps = new List<PointF>();
                int pixelWidth = this.myWriterControl.Document.ToPixel(img.Width);
                int pixelHeight = this.myWriterControl.Document.ToPixel(img.Height);
                for (float x = 0; x < pixelWidth ; x++)
                {
                    float y = (float)(pixelHeight / 2 + Math.Sin(x *0.05 + currentValue) * pixelHeight / 2.1);
                    ps.Add(new PointF( x , y ));
                }
                Bitmap newImage = new Bitmap(pixelWidth , pixelHeight );
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage))
                {
                    g.Clear(Color.White);
                    g.DrawLines(Pens.Red, ps.ToArray());
                }
                if (img.Image == null)
                {
                    img.Image.Dispose();
                }
                img.Image = new XImageValue(newImage);
                img.InvalidateView();
            }
        }

    }
}