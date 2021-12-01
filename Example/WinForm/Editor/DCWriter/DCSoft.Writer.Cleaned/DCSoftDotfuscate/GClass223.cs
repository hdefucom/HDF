using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass223 : GClass222
	{
		protected string string_5 = ".";

		private string[] string_6 = null;

		public string Name
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
				string_6 = null;
			}
		}

		public string[] method_245()
		{
			if (string_6 == null)
			{
				List<string> list = new List<string>();
				string[] array = string_5.Split(' ');
				string[] array2 = array;
				foreach (string text in array2)
				{
					string text2 = text.Trim();
					if (!string.IsNullOrEmpty(text2) || !list.Contains(text2))
					{
						list.Add(text2);
					}
				}
				string_6 = list.ToArray();
			}
			return string_6;
		}
	}
}
