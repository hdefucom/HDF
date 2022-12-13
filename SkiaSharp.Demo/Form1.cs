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


#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
            string a = null;
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。


            //skia支持连体字符绘制，在wpf以及Chrom等程序中支持，
            //但是此处绘制不出来，不知道需要设置什么参数

            SKPaint text_paint = new SKPaint
            {
                //FakeBoldText = true,
                TextSize = 50,
                Color = SKColors.Black,




                //TextAlign = SKTextAlign.Center,
                //宋体，不然不支持中文绘制;
                //Typeface = SKTypeface.FromFamilyName("微软雅黑"),
                Typeface = SKTypeface.FromFamilyName("Fira Code"),
                //IsAntialias = true,

            };

            var res = text_paint.ToFont().ContainsGlyphs("==");

            //canvas.Save();
            //逆时针旋转45度绘制
            //canvas.RotateDegrees(-45, 250, 250);
            //canvas.DrawText("h啊速度hi发sad😂😂😂", new SKPoint(250, 250), text_paint);
            canvas.DrawText($"{res}==> => == ===", new SKPoint(250, 250), text_paint);
            //canvas.Restore();




        }
    }
}