using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass199 : GClass163
	{
		public override string TagName => "ie:layoutrect";

		internal override bool vmethod_3(GClass164 gclass164_1)
		{
			return gclass164_1 is GClass171;
		}

		public string method_46()
		{
			return method_9("border");
		}

		public void method_47(string string_0)
		{
			method_11("border", string_0);
		}

		public string method_48()
		{
			return method_9("bordercolor");
		}

		public void method_49(string string_0)
		{
			method_11("bordercolor", string_0);
		}

		public string method_50()
		{
			return method_9("contentsrc");
		}

		public void method_51(string string_0)
		{
			method_11("contentsrc", string_0);
		}

		public string method_52()
		{
			return method_9("marginheight");
		}

		public void method_53(string string_0)
		{
			method_11("marginheight", string_0);
		}

		public string method_54()
		{
			return method_9("marginwidth");
		}

		public void method_55(string string_0)
		{
			method_11("marginwidth", string_0);
		}

		public string method_56()
		{
			return method_9("nextrect");
		}

		public void method_57(string string_0)
		{
			method_11("nextrect", string_0);
		}
	}
}
