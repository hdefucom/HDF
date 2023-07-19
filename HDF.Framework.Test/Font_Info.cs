using System.Windows.Media;

namespace HDF.Framework.Text
{
    internal class Font_Info
    {
        public static void Test()
        {



            var data = System.Drawing.FontFamily.Families
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








            var families = Fonts.GetFontFamilies(@"C:\WINDOWS\Fonts\simsun.ttc");
            foreach (System.Windows.Media.FontFamily family in families)
            {
                var typefaces = family.GetTypefaces();
                foreach (Typeface typeface in typefaces)
                {
                    GlyphTypeface glyph;
                    typeface.TryGetGlyphTypeface(out glyph);
                    IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;

                    foreach (KeyValuePair<int, ushort> kvp in characterMap)
                    {
                        Console.WriteLine(String.Format("{0}:{1}", kvp.Key, kvp.Value));
                    }

                }
            }



        }
    }
}
