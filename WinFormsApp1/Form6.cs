using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class Form6 : Form
{
    public Form6()
    {
        InitializeComponent();
    }







    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);



        //var str3 = "💩😓😓😓🚃⛪🚋🚄🐒🐖🐿🌎【💩】\u263A";

        //var str = "\u3053\u3093\u306B\u3061\u306F \u2728";

        //string s1 = "\U0001f8ff";

        //// 3dd8 a9dc
        //var s = e.Graphics.MeasureString("💩", this.Font, 10000, new StringFormat(StringFormat.GenericTypographic)
        //{
        //    FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces,
        //});

        //e.Graphics.FillRectangle(Brushes.Red, 10, 10, s.Width, s.Height);

        //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        //e.Graphics.DrawString(str3, this.Font, Brushes.Black, 10, 10);


        //TextRenderer.DrawText(e.Graphics, str3, this.Font, new Point(10, 30), Color.Black);



        //var f = new Font("宋体", 30);

        //e.Graphics.DrawString(str, f, Brushes.Black, 10, 50);




		//List<Order> list.Where(o=>r.Desc.Contain(txtbox.text))

        var str = textBox1.Text;


        var str_utf8_2 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray());
        var str_utf8_16 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 16).PadLeft(2, '0')).ToArray());


        e.Graphics.DrawString("UTF-8", this.Font, Brushes.Black, 10, 10);
        e.Graphics.DrawString("二进制：" + str_utf8_2, this.Font, Brushes.Black, 10, 30);
        e.Graphics.DrawString("十六进制：" + str_utf8_16, this.Font, Brushes.Black, 10, 50);


        //IPAddress.NetworkToHostOrder()

        var str_unicode_2 = string.Join(" ", Encoding.Unicode.GetBytes(str)/*.Reverse()*/.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray());
        var str_unicode_16 = string.Join(" ", Encoding.Unicode.GetBytes(str)/*.Reverse()*/.Select(b => Convert.ToString(b, 16).PadLeft(2, '0')).ToArray());

        //StringReader sr = new StringReader(str);

        //var i = sr.Read();

        //while (i != -1)
        //{
        //    i = sr.Read();


        //}

        e.Graphics.DrawString("Unicode", this.Font, Brushes.Black, 10, 70);
        e.Graphics.DrawString("二进制：" + str_unicode_2, this.Font, Brushes.Black, 10, 90);
        e.Graphics.DrawString("十六进制：" + str_unicode_16, this.Font, Brushes.Black, 10, 110);




    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Invalidate();
    }
}










//[DefaultEvent("PaintSurface")]
//[DefaultProperty("Name")]
//public class SKGLControl : GLControl
//{
//	private const SKColorType colorType = SKColorType.Rgba8888;
//	private const GRSurfaceOrigin surfaceOrigin = GRSurfaceOrigin.BottomLeft;

//	private bool designMode;

//	private GRContext grContext;
//	private GRGlFramebufferInfo glInfo;
//	private GRBackendRenderTarget renderTarget;
//	private SKSurface surface;
//	private SKCanvas canvas;

//	private SKSizeI lastSize;

//	public SKGLControl()
//		: base(new GraphicsMode(new ColorFormat(8, 8, 8, 8), 24, 8))
//	{
//		Initialize();
//	}

//	public SKGLControl(GraphicsMode mode)
//		: base(mode)
//	{
//		Initialize();
//	}

//	public SKGLControl(GraphicsMode mode, int major, int minor, GraphicsContextFlags flags)
//		: base(mode, major, minor, flags)
//	{
//		Initialize();
//	}

//	private void Initialize()
//	{
//		designMode = DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

//		ResizeRedraw = true;
//	}

//	public SKSize CanvasSize => lastSize;

//	public GRContext GRContext => grContext;

//	[Category("Appearance")]
//	public event EventHandler<SKPaintGLSurfaceEventArgs> PaintSurface;

//	protected override void OnPaint(PaintEventArgs e)
//	{
//		if (designMode)
//		{
//			e.Graphics.Clear(BackColor);
//			return;
//		}

//		base.OnPaint(e);

//		MakeCurrent();

//		// create the contexts if not done already
//		if (grContext == null)
//		{
//			var glInterface = GRGlInterface.Create();
//			grContext = GRContext.CreateGl(glInterface);
//		}

//		// get the new surface size
//		var newSize = new SKSizeI(Width, Height);

//		// manage the drawing surface
//		if (renderTarget == null || lastSize != newSize || !renderTarget.IsValid)
//		{
//			// create or update the dimensions
//			lastSize = newSize;

//			GL.GetInteger(GetPName.FramebufferBinding, out var framebuffer);
//			GL.GetInteger(GetPName.StencilBits, out var stencil);
//			GL.GetInteger(GetPName.Samples, out var samples);
//			var maxSamples = grContext.GetMaxSurfaceSampleCount(colorType);
//			if (samples > maxSamples)
//				samples = maxSamples;
//			glInfo = new GRGlFramebufferInfo((uint)framebuffer, colorType.ToGlSizedFormat());

//			// destroy the old surface
//			surface?.Dispose();
//			surface = null;
//			canvas = null;

//			// re-create the render target
//			renderTarget?.Dispose();
//			renderTarget = new GRBackendRenderTarget(newSize.Width, newSize.Height, samples, stencil, glInfo);
//		}

//		// create the surface
//		if (surface == null)
//		{
//			surface = SKSurface.Create(grContext, renderTarget, surfaceOrigin, colorType);
//			canvas = surface.Canvas;
//		}

//		using (new SKAutoCanvasRestore(canvas, true))
//		{
//			// start drawing
//#pragma warning disable CS0612 // Type or member is obsolete
//			OnPaintSurface(new SKPaintGLSurfaceEventArgs(surface, renderTarget, surfaceOrigin, colorType, glInfo));
//#pragma warning restore CS0612 // Type or member is obsolete
//		}

//		// update the control
//		canvas.Flush();
//		SwapBuffers();
//	}

//	protected virtual void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
//	{
//		// invoke the event
//		PaintSurface?.Invoke(this, e);
//	}

//	protected override void Dispose(bool disposing)
//	{
//		base.Dispose(disposing);

//		// clean up
//		canvas = null;
//		surface?.Dispose();
//		surface = null;
//		renderTarget?.Dispose();
//		renderTarget = null;
//		grContext?.Dispose();
//		grContext = null;
//	}
//}




//[DefaultEvent("PaintSurface")]
//[DefaultProperty("Name")]
//public class SKControl : Control
//{
//	private readonly bool designMode;

//	private Bitmap bitmap;

//	public SKControl()
//	{
//		DoubleBuffered = true;
//		SetStyle(ControlStyles.ResizeRedraw, true);

//		designMode = DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
//	}

//	public SKSize CanvasSize => bitmap == null ? SKSize.Empty : new SKSize(bitmap.Width, bitmap.Height);

//	[Category("Appearance")]
//	public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface;

//	protected override void OnPaint(PaintEventArgs e)
//	{
//		if (designMode)
//			return;

//		base.OnPaint(e);

//		// get the bitmap
//		var info = CreateBitmap();

//		if (info.Width == 0 || info.Height == 0)
//			return;

//		var data = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

//		// create the surface
//		using (var surface = SKSurface.Create(info, data.Scan0, data.Stride))
//		{
//			// start drawing
//			OnPaintSurface(new SKPaintSurfaceEventArgs(surface, info));

//			surface.Canvas.Flush();
//		}

//		// write the bitmap to the graphics
//		bitmap.UnlockBits(data);
//		e.Graphics.DrawImage(bitmap, 0, 0);
//	}

//	protected virtual void OnPaintSurface(SKPaintSurfaceEventArgs e)
//	{
//		// invoke the event
//		PaintSurface?.Invoke(this, e);
//	}

//	protected override void Dispose(bool disposing)
//	{
//		base.Dispose(disposing);

//		FreeBitmap();
//	}

//	private SKImageInfo CreateBitmap()
//	{
//		var info = new SKImageInfo(Width, Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

//		if (bitmap == null || bitmap.Width != info.Width || bitmap.Height != info.Height)
//		{
//			FreeBitmap();

//			if (info.Width != 0 && info.Height != 0)
//				bitmap = new Bitmap(info.Width, info.Height, PixelFormat.Format32bppPArgb);
//		}

//		return info;
//	}

//	private void FreeBitmap()
//	{
//		if (bitmap != null)
//		{
//			bitmap.Dispose();
//			bitmap = null;
//		}
//	}
//}


