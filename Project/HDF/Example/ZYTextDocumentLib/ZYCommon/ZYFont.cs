using System.Drawing;

namespace ZYCommon
{
	public class ZYFont
	{
		public static Font DefautFont = null;

		private static int Status = 0;

		public static string GetFontNameForCurrentSystem(string nameIncluded)
		{
			FontFamily[] families = FontFamily.Families;
			foreach (FontFamily fontFamily in families)
			{
				if (fontFamily.Name.IndexOf(nameIncluded) == 0)
				{
					return fontFamily.Name;
				}
			}
			return "宋体";
		}

		public static void InitFont(string FontName, float FontSize)
		{
			if (Status != 1)
			{
				string fontNameForCurrentSystem = GetFontNameForCurrentSystem(FontName);
				DefautFont = new Font(fontNameForCurrentSystem, FontSize, FontStyle.Regular);
				Status = 1;
			}
		}
	}
}
