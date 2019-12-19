using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using System.Drawing.Imaging;

namespace HDF.Framework.Common
{
    /// <summary>
    /// 操纵图片亮度对比度（项目需要unsafe编译）
    /// </summary>
    public static class ImageUpdate
    {
        //public static unsafe Bitmap SetImgBrightness(Bitmap src, int brightness)
        //{
        //    int width = src.Width;
        //    int height = src.Height;
        //    Bitmap back = new Bitmap(width, height);
        //    Rectangle rect = new Rectangle(0, 0, width, height);
        //    //这种速度最快
        //    BitmapData bmpData = src.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);//24位rgb显示一个像素，即一个像素点3个字节，每个字节是BGR分量。Format32bppRgb是用4个字节表示一个像素
        //    byte* ptr = (byte*)(bmpData.Scan0);
        //    for (int j = 0; j < height; j++)
        //    {
        //        for (int i = 0; i < width; i++)
        //        {
        //            //ptr[2]为r值，ptr[1]为g值，ptr[0]为b值
        //            int red = ptr[2] + brightness; if (red > 255) red = 255; if (red < 0) red = 0;
        //            int green = ptr[1] + brightness; if (green > 255) green = 255; if (green < 0) green = 0;
        //            int blue = ptr[0] + brightness; if (blue > 255) blue = 255; if (blue < 0) blue = 0;
        //            back.SetPixel(i, j, Color.FromArgb(red, green, blue));
        //            ptr += 3; //Format24bppRgb格式每个像素占3字节
        //        }
        //        ptr += bmpData.Stride - bmpData.Width * 3;//每行读取到最后“有用”数据时，跳过未使用空间XX
        //    }
        //    src.UnlockBits(bmpData);
        //    return back;
        //}
    }
}
