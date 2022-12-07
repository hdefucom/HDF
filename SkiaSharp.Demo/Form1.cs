using System.Windows.Forms;

namespace SkiaSharp.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void skControl1_PaintSurface(object sender, Views.Desktop.SKPaintSurfaceEventArgs e)
        {

            var canvas = e.Surface.Canvas;




            SKPaint text_paint = new SKPaint
            {
                //FakeBoldText = true,
                TextSize = 50,
                Color = SKColors.Black,



                TextAlign = SKTextAlign.Center,
                //宋体，不然不支持中文绘制;
                Typeface = SKTypeface.FromFamilyName("微软雅黑"),
                IsAntialias = true,

            };
            //canvas.Save();
            //逆时针旋转45度绘制
            //canvas.RotateDegrees(-45, 250, 250);
            canvas.DrawText("h啊速度hi发sad😂😂😂", new SKPoint(250, 250), text_paint);
            //canvas.Restore();




        }
    }
}