using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass462 : GClass460
	{
		private GClass457 gclass457_0;

		private GClass463 gclass463_0;

		public GClass462(GClass476 gclass476_1)
			: base(gclass476_1)
		{
			gclass463_0 = new GClass463(this);
			gclass457_0 = new GClass457(this);
		}

		public override string vmethod_4()
		{
			return "Type0";
		}

		public override string vmethod_5()
		{
			return Class211.smethod_1(method_5(), bool_0: true);
		}

		public GClass463 method_7()
		{
			return gclass463_0;
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			base.vmethod_0(gclass540_0);
			gclass463_0.method_1(gclass540_0);
			gclass457_0.method_1(gclass540_0);
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			base.vmethod_1(streamWriter_0);
			gclass463_0.method_2(streamWriter_0);
			gclass457_0.method_2(streamWriter_0);
		}

		public override string vmethod_3(string string_0)
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<");
			for (int i = 0; i < string_0.Length; i++)
			{
				stringBuilder.Append(method_6().method_9(string_0[i]).ToString("X4"));
			}
			stringBuilder.Append(">");
			return stringBuilder.ToString();
		}

		public override void vmethod_2()
		{
			base.vmethod_2();
			GClass513 gClass = new GClass513();
			gClass.method_9(gclass463_0.method_3());
			method_3().method_8("DescendantFonts", gClass);
			method_3().method_9("Encoding", "Identity-H");
			gclass463_0.vmethod_2();
			method_3().method_8("ToUnicode", gclass457_0.method_3());
			gclass457_0.vmethod_2();
		}
	}
}
