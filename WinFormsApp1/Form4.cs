using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class Form4 : Form
{
    public Form4()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {

        var rect = Screen.AllScreens.Select(s => s.Bounds).Union();

        Bitmap bmp = new Bitmap(rect.Width, rect.Height);
        using Graphics g = Graphics.FromImage(bmp);

        foreach (var item in Screen.AllScreens)
        {
            var p = item.Bounds.Location;
            p.Offset(-rect.X, -rect.Y);


            g.CopyFromScreen(item.Bounds.Location, p, item.Bounds.Size);
        }

        myPictureBox1.Image = bmp;


    }
}



public class MyPictureBox : PictureBox
{

    protected override void OnPaint(PaintEventArgs pe)
    {
        //pe.Graphics.PageScale = 0.5f;
        pe.Graphics.ScaleTransform(0.5f, 0.5f);

        base.OnPaint(pe);


    }



}







public class ScreenShotHelper
{


    public static Bitmap GetAllScreens()
    {
        //获得所有屏幕区域的并集
        var rect = Screen.AllScreens.Select(s => s.Bounds).Union();

        Bitmap bmp = new Bitmap(rect.Width, rect.Height);
        using Graphics g = Graphics.FromImage(bmp);

        foreach (var item in Screen.AllScreens)
        {
            //获得单个屏幕区域相对整个并集区域的坐标
            var p = item.Bounds.Location;
            p.Offset(-rect.X, -rect.Y);
            //拷贝屏幕图层
            g.CopyFromScreen(item.Bounds.Location, p, item.Bounds.Size);
        }

        return bmp;
    }




}