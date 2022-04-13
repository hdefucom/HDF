using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //ToolStripItemDesignerAvailabilityAttribute
            //BarItemDesignerAvailabilityAttribute


            //var gitem = new DevExpress.XtraBars.Ribbon.GalleryItem(image, Path.GetFileNameWithoutExtension(item), "");


            //DevExpress.XtraBars.BarCustomContainerItem item = new DevExpress.XtraBars.BarCustomContainerItem();






            //galleryDropDown1.Gallery.Groups[0].Items.Add(gitem);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DevExpress.XtraBars.BarButtonItem
        }











        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //DrawSelectionBorder(e.Graphics, panel1.DisplayRectangle, Color.LightGray, 10);
        }



        private void DrawSelectionBorder(Graphics g, RectangleF rect, Color c, float len)
        {
            rect.Offset(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

            GraphicsPath path = new GraphicsPath();
            path.AddBezier(rect.X - len, rect.Y, rect.X - len, rect.Y - len, rect.X, rect.Y - len, rect.X, rect.Y - len);
            path.AddLine(rect.X, rect.Y - len, rect.Right, rect.Y - len);
            path.AddBezier(rect.Right, rect.Y - len, rect.Right + len, rect.Y - len, rect.Right + len, rect.Y, rect.Right + len, rect.Y);
            path.AddLine(rect.Right + len, rect.Y, rect.Right + len, rect.Bottom);
            path.AddBezier(rect.Right + len, rect.Bottom, rect.Right + len, rect.Bottom + len, rect.Right, rect.Bottom + len, rect.Right, rect.Bottom + len);
            path.AddLine(rect.Right, rect.Bottom + len, rect.X, rect.Bottom + len);
            path.AddBezier(rect.X, rect.Bottom + len, rect.X - len, rect.Bottom + len, rect.X - len, rect.Bottom, rect.X - len, rect.Bottom);
            path.AddLine(rect.X - len, rect.Bottom, rect.X - len, rect.Y);




            //生成一个圆角矩形渐变画刷
            PathGradientBrush pb = new PathGradientBrush(path);

            //从外到内渐变颜色
            Color[] colors =
            {
               Color.Transparent,
               c,
              Color.Black,
            };

            var rate = 2 * len / (rect.Width + rect.Height);

            //从内到外渐变位置百分比
            float[] relativePositions =
            {
               0f,
               rate,
               1f,
            };

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = colors;
            colorBlend.Positions = relativePositions;

            pb.InterpolationColors = colorBlend;

            //去圆角毛刺
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(pb, path);


            rect.Inflate(-len, -len);

            //g.FillRectangle(Brushes.White, rect);
        }

        private void barEditItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
