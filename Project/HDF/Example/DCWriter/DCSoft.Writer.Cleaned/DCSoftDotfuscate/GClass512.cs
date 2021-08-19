using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass512 : GClass511
	{
		public GClass512(string string_1)
			: base(string_1)
		{
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			int num = 17;
			streamWriter_0.Write("(");
			streamWriter_0.Flush();
			streamWriter_0.BaseStream.WriteByte(254);
			streamWriter_0.BaseStream.WriteByte(byte.MaxValue);
			Class206.smethod_1(string_0);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c <= 'ÿ')
				{
					stringBuilder.Append('\0');
				}
				stringBuilder.Append(c);
			}
			stringBuilder.Append(")");
			streamWriter_0.Write(stringBuilder.ToString());
		}

		public override string ToString()
		{
			return "UnicodeText:" + method_8();
		}
	}
}
