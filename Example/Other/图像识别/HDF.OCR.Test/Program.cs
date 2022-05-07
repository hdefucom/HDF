using PaddleOCRSharp;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HDF.OCR.Test
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            //图像文本识别
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var imagebyte = File.ReadAllBytes(ofd.FileName);
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));

            OCRModelConfig config = null;
            OCRParameter oCRParameter = new OCRParameter();

            using PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter);

            var ocrResult = engine.DetectText(bitmap);

            var str = ocrResult.Text;

            Console.WriteLine(str);


            Console.ReadKey();

        }
    }
}
