using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Text
{
    internal class Print
    {
        public static void Test()
        {


            PrinterSettings pst = new PrinterSettings();

            pst.DefaultPageSettings.PaperSize = pst.PaperSizes.Cast<PaperSize>().First(p => p.Kind == PaperKind.A5);
            //PaperSize size = new PaperSize();

            pst.DefaultPageSettings.Landscape = true;


            //PageSettings ps = new PageSettings();


            using PrintDocument print = new PrintDocument();

            print.PrinterSettings = pst;

            print.PrintPage += (_, e) =>
            {
                e.Graphics.DrawString("hfaskdfhk", new Font("宋体", 24f), Brushes.Black, 0, 0);
            };


            PrintDialog dialog = new PrintDialog();

            dialog.Document = print;

            dialog.AllowCurrentPage = true;
            dialog.AllowSelection = true;
            dialog.AllowSomePages = true;


            dialog.ShowDialog();

            print.Print();



        }
    }
}
