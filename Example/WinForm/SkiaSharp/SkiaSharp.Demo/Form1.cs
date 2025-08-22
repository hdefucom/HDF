using SkiaSharp.HarfBuzz;
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
            //解决方案：安装SkiaSharp.HarfBuzz包，使用DrawShapedText提供支持






            SKPaint text_paint = new SKPaint
            {
                //FakeBoldText = true,
                TextSize = 24,
                Color = SKColors.Black,

                //TextAlign = SKTextAlign.Center,
                //宋体，不然不支持中文绘制;
                Typeface = SKTypeface.FromFamilyName("微软雅黑"),
                //Typeface = SKTypeface.FromFamilyName("Fira Code"),
                //Typeface = SKTypeface.FromFamilyName("Fira Code",
                //                                SKFontStyleWeight.Normal,
                //                                SKFontStyleWidth.Normal,
                //                                SKFontStyleSlant.Upright),
                IsAntialias = true,

            };
            var font = new SKFont
            {
                Edging = SKFontEdging.SubpixelAntialias,
                Size = 24,
                Subpixel = true,
            };

            var res = text_paint.ToFont().ContainsGlyphs("==");

            //canvas.Save();
            //逆时针旋转45度绘制
            //canvas.RotateDegrees(-45, 250, 250);
            canvas.DrawText("h啊速度hi发sad😂😂😂", new SKPoint(250, 350), text_paint);
            canvas.DrawText($"{res}==> => == ===", new SKPoint(250, 50), text_paint);
            canvas.DrawText($"{res}==> => == ===", 250, 150, font, text_paint);
            canvas.DrawShapedText($"{res}==> => == ===", 250, 250, text_paint);

            //canvas.Restore();




        }
    }
}