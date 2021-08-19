using DCSoft.Writer.Controls;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class111
	{
		public static void Invoke(WriterControl writerControl_0, GEnum15 genum15_0, byte[] byte_0)
		{
			int num = 4;
			switch (genum15_0)
			{
			case GEnum15.const_0:
				break;
			case GEnum15.const_1:
			{
				string @string = Encoding.UTF8.GetString(byte_0);
				int num2 = @string.IndexOf(",");
				if (num2 > 0)
				{
					@string.Substring(0, num2);
					int num3 = @string.IndexOf(",", num2 + 1);
					if (num3 <= 0)
					{
					}
					string value = @string.Substring(0, num2);
					bool result = true;
					if (!bool.TryParse(value, out result))
					{
						result = true;
					}
				}
				break;
			}
			}
		}
	}
}
