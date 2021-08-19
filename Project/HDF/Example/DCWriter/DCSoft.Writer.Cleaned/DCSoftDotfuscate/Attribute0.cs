using System.ComponentModel;
using System.Resources;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Attribute0 : DescriptionAttribute
	{
		private const string string_0 = "DCSoft.Writer.WriterStringsCore";

		private static ResourceManager resourceManager_0 = null;

		private bool bool_0 = false;

		private string string_1 = null;

		public override string Description
		{
			get
			{
				if (!bool_0)
				{
					bool_0 = true;
					string_1 = method_0().GetString(base.DescriptionValue);
				}
				return string_1;
			}
		}

		public Attribute0(string string_2)
			: base(string_2)
		{
		}

		private ResourceManager method_0()
		{
			int num = 11;
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new ResourceManager("DCSoft.Writer.WriterStringsCore", GetType().Assembly);
			}
			return resourceManager_0;
		}
	}
}
