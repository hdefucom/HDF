using HDF.Common.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Framework.Text
{
    internal class Font_Info
    {
        public static void Test()
        {



            var data = FontFamily.Families
                .Select(fm => new Font(fm, 72f))
                .Select(f => new
                {
                    Name = f.Name,
                    Ascent = f.GetAscent(),
                    Descent = f.GetDescent(),
                    ADSum = f.GetAscent() + f.GetDescent(),
                    EmHeight = f.GetEmHeight(),
                    LineSpacing = f.GetLineSpacing(),
                })
                .ToList();


            var str = string.Join(Environment.NewLine, data.Select(a =>
            $"{a.Name} \t {a.Ascent} \t {a.Descent} \t{a.ADSum} \t {a.EmHeight} \t {a.LineSpacing}"));





        }
    }
}
