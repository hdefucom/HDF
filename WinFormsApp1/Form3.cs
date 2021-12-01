using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp1;

public partial class Form3 : Form
{
    public Form3()
    {
        InitializeComponent();

    }

    private void button1_Click(object sender, EventArgs e)
    {
        myPanel1.Invalidate();
    }






}






public class MyPanel : Panel
{

    public MyPanel()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


    }


    protected override void OnPaint(PaintEventArgs e)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();



        using GraphicsPath path = new GraphicsPath();

        path.AddString(
              "5678黄德富",
              this.Font.FontFamily,
              (int)this.Font.Style,
              //this.Font.Size,
              //9 * 96 / 72,
              20,
              this.ClientRectangle,
              StringFormat.GenericDefault);



        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        e.Graphics.DrawString("5678黄德富", this.Font, Brushes.Black, new Rectangle(0, 50, 100, 100)); ;



        e.Graphics.FillPath(Brushes.Black, path);



        sw.Stop();

        Debug.WriteLine(sw.ElapsedMilliseconds);



    }


}