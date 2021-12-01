using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass212 : GClass163
	{
		private string string_0;

		private List<GClass223> list_0 = new List<GClass223>();

		public override string InnerText => vmethod_7();

		public override string TagName => "style";

		public override void vmethod_0(string string_1)
		{
			vmethod_8(string_1);
		}

		public override string vmethod_7()
		{
			return string_0;
		}

		public override void vmethod_8(string string_1)
		{
			string_0 = string_1;
		}

		public List<GClass223> method_46()
		{
			return list_0;
		}

		public GClass223 method_47(int int_0)
		{
			return list_0[int_0];
		}

		public GClass223 method_48(string string_1)
		{
			foreach (GClass223 item in list_0)
			{
				if (string.Compare(item.Name, string_1, ignoreCase: true) == 0)
				{
					return item;
				}
			}
			return null;
		}

		public void method_49(GClass223 gclass223_0)
		{
			list_0.Add(gclass223_0);
		}

		public void method_50(GClass223 gclass223_0)
		{
			list_0.Remove(gclass223_0);
		}

		public void method_51(string string_1)
		{
			GClass223 gClass = method_48(string_1);
			if (gClass != null)
			{
				list_0.Remove(gClass);
			}
		}

		protected override bool vmethod_6()
		{
			return true;
		}

		internal override bool vmethod_11(Class171 class171_0)
		{
			int num = 18;
			list_0.Clear();
			string_0 = class171_0.method_32(TagName);
			if (string_0 != null)
			{
				string_0 = string_0.Replace("<!--", "");
				string_0 = string_0.Replace("-->", "");
				int num2 = 0;
				for (int num3 = string_0.IndexOf("{"); num3 >= 0; num3 = string_0.IndexOf("{", num2))
				{
					int num4 = string_0.IndexOf("}", num3);
					if (num4 > num3)
					{
						string text = string_0.Substring(num2, num3 - num2);
						string string_ = string_0.Substring(num3 + 1, num4 - num3 - 1);
						GClass223 gClass = new GClass223();
						gClass.Name = text.Trim();
						gClass.method_12(string_);
						list_0.Add(gClass);
					}
					num2 = num4 + 1;
				}
			}
			return true;
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			int num = 12;
			if (htmldocument_0.WriteOptions.bool_15)
			{
				foreach (GClass223 item in list_0)
				{
					xmlWriter_0.WriteString(Environment.NewLine + item.Name + "{");
					for (int i = 0; i < item.method_3().Count; i++)
					{
						GClass229 gClass = item.method_3()[i];
						if (i > 0)
						{
							xmlWriter_0.WriteString(";");
						}
						xmlWriter_0.WriteString(Environment.NewLine + "    " + gClass.string_0 + ":" + gClass.string_1);
					}
					if (item.method_3().Count > 0)
					{
						xmlWriter_0.WriteString(Environment.NewLine + "    ");
					}
					xmlWriter_0.WriteString("}");
				}
			}
			else
			{
				foreach (GClass223 item2 in list_0)
				{
					xmlWriter_0.WriteString(Environment.NewLine + item2.Name + "{" + item2.method_11() + "}");
				}
			}
			if (list_0.Count > 0)
			{
				xmlWriter_0.WriteString(Environment.NewLine);
			}
			return true;
		}
	}
}
