using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;
using DCSoft.Drawing;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlCustomShapeElement : UserControl
    {
        public ctlCustomShapeElement()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EventDrawShapeContent += new WriterDrawShapeContentEventHandler(myWriterControl_EventDrawShapeContent);
        }


        private void btnInsertCustomShape_Click(object sender, EventArgs e)
        {
            XTextCustomShapeElement shape = new XTextCustomShapeElement();
            shape.Width = 400;
            shape.Height = 300;
            shape.ID = "aaa";
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertCustomShape, false, shape);
        }


        private void btnInsertShape2_Click(object sender, EventArgs e)
        {
            XTextCustomShapeElement shape = new XTextCustomShapeElement();
            shape.Width = 400;
            shape.Height = 300;
            shape.ID = "bbb";
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertCustomShape, false, shape);
        }


        void myWriterControl_EventDrawShapeContent(object eventSender, WriterDrawShapeContentEventArgs args)
        {
            if (args.Element.ID == "aaa")
            {
                // 绘制一种自定义图形
                RectangleF bounds = args.ViewBounds;
                if (bounds.Width > bounds.Height)
                {
                    for (int iCount = 0; iCount <= 10; iCount++)
                    {
                        args.Graphics.DrawEllipse(
                            Color.Red,
                            new RectangleF(
                                bounds.Left + (float)((bounds.Width - bounds.Height) * iCount / 10.0),
                                bounds.Top,
                                bounds.Height,
                                bounds.Height));
                    }
                }
                else
                {
                    for (int iCount = 0; iCount <= 10; iCount++)
                    {
                        args.Graphics.DrawEllipse(
                            Color.Red,
                            new RectangleF(
                                bounds.Left,
                                (float)(bounds.Top + (bounds.Height - bounds.Width) * iCount / 10.0),
                                bounds.Width,
                                bounds.Width));
                    }
                }

                args.Graphics.DrawString(
                    "袁永福到此一游",
                    new XFontValue("宋体", 20),
                    Color.Blue, 
                    args.ViewBounds,
                    StringAlignment.Center,
                    StringAlignment.Center);

                //using (StringFormat format = new StringFormat())
                //{
                //    format.Alignment = StringAlignment.Center;
                //    format.LineAlignment = StringAlignment.Center;
                //    using (Font f = new System.Drawing.Font("宋体", 20))
                //    {
                //        args.Graphics.DrawString("袁永福到此一游", f, Brushes.Blue, args.ViewBounds, format);
                //    }
                //}
            }
            else if (args.Element.ID == "bbb")
            {
                // 绘制另外一种自定义图形
                RectangleF bounds = args.ViewBounds;
                float cx = bounds.Width / 2;
                float cy =  bounds.Height / 2;
                const int spirals = 20;
                int curls = (int)(spirals * 2 * (cx + cy));
                float angle, scale;
                PointF lastPoint = PointF.Empty;
                PointF p = PointF.Empty;
                for (int i = 0; i < curls; i++)
                {
                    angle = (float)(i * 2 * Math.PI / (curls / spirals));
                    scale = 1 - (float)i / curls;
                    p.X = (float)( bounds.Left +( bounds.Width / 2 )* (1 + scale * Math.Cos(angle)));
                    p.Y = (float)( bounds.Top +( bounds.Height /2 ) * (1 + scale * Math.Sin(angle)));
                    if (i > 0)
                    {
                        args.Graphics.DrawLine(Pens.Blue, lastPoint, p);
                    }
                    lastPoint = p;
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
                for (float x = 0; x < pixelWidth; x++)
                {
                    float y = (float)(pixelHeight / 2 + Math.Sin(x * 0.05 + currentValue) * pixelHeight / 2.1);
                    ps.Add(new PointF(x, y));
                }
                Bitmap newImage = new Bitmap(pixelWidth, pixelHeight);
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