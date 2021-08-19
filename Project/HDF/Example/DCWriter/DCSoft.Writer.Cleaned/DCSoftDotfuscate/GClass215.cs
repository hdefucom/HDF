using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass215 : GClass163
	{
		private string string_0;

		public override string InnerText => string_0;

		public override string TagName => "#comment";

		public override void vmethod_0(string string_1)
		{
			string_0 = string_1;
		}

		public override string vmethod_7()
		{
			return string_0;
		}

		public override void vmethod_8(string string_1)
		{
			string_0 = string_1;
		}

		protected override bool vmethod_6()
		{
			return true;
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 9;
			if (htmldocument_0.WriteOptions.bool_12 && string_0 != null && string_0.Length > 0)
			{
				string text = string_0 + " ";
				if (text.IndexOf("--") >= 0)
				{
					text = "因保存需要,将所有的\"- -\"转换为 \"@@\"符号\r\n" + text.Replace("--", "@@");
				}
				if (htmldocument_0.WriteOptions.bool_13)
				{
					myWriter.WriteStartElement("xsl:comment");
					myWriter.WriteCData(text);
					myWriter.WriteEndElement();
				}
				else
				{
					myWriter.WriteComment(text);
				}
			}
			return true;
		}
	}
}
