using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass177 : GClass164
	{
		private string string_0 = null;

		public override string TagName => string_0;

		internal void method_50(string string_1)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				string_0 = string_1.ToUpper().Trim();
			}
			else
			{
				string_0 = null;
			}
		}
	}
}
