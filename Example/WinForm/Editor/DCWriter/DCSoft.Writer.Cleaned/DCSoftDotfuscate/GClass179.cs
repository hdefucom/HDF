using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass179 : GClass164
	{
		public override string TagName => "P";

		public string method_50()
		{
			return method_9("align");
		}

		public void method_51(string string_0)
		{
			method_11("align", string_0);
		}

		public bool method_52()
		{
			return method_13("disabled");
		}

		public void method_53(bool bool_0)
		{
			int num = 12;
			if (bool_0)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}

		public override void vmethod_20(StringBuilder stringBuilder_0)
		{
			stringBuilder_0.Append(Environment.NewLine);
			base.vmethod_20(stringBuilder_0);
		}

		protected override bool vmethod_23()
		{
			return false;
		}

		protected override bool vmethod_22(string string_0)
		{
			return string_0 != "P";
		}

		internal override bool vmethod_21(Class171 class171_0, string string_0)
		{
			if (gclass164_0 != null && string_0 == gclass164_0.TagName)
			{
				return true;
			}
			return false;
		}
	}
}
