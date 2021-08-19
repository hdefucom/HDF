using DCSoft.Design;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass134
	{
		private static GClass134 gclass134_0 = null;

		private string string_0 = null;

		private DCTypeDomDocument dctypeDomDocument_0 = new DCTypeDomDocument();

		public static GClass134 smethod_0()
		{
			if (gclass134_0 == null)
			{
				gclass134_0 = new GClass134();
			}
			return gclass134_0;
		}

		public GClass134()
		{
			method_1(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DCComponentTypeLibrary.dat"));
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_2()
		{
			if (File.Exists(method_0()))
			{
				try
				{
					using (FileStream stream = new FileStream(method_0(), FileMode.Open, FileAccess.Read))
					{
						DCTypeDomDocument dCTypeDomDocument = DCTypeDomDocument.LoadBinary(stream);
						if (dCTypeDomDocument != null)
						{
							method_5(dCTypeDomDocument);
							method_4().Sort();
							return true;
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}

		public bool method_3()
		{
			using (FileStream stream = new FileStream(method_0(), FileMode.Create, FileAccess.Write))
			{
				method_4().SaveBinary(stream);
			}
			return true;
		}

		public DCTypeDomDocument method_4()
		{
			if (dctypeDomDocument_0 == null)
			{
				dctypeDomDocument_0 = new DCTypeDomDocument();
			}
			return dctypeDomDocument_0;
		}

		public void method_5(DCTypeDomDocument dctypeDomDocument_1)
		{
			dctypeDomDocument_0 = dctypeDomDocument_1;
		}

		public bool method_6(IWin32Window iwin32Window_0)
		{
			using (dlgComponentTypeLibrary dlgComponentTypeLibrary = new dlgComponentTypeLibrary())
			{
				dlgComponentTypeLibrary.ComponentDomInfo = method_4();
				if (dlgComponentTypeLibrary.ShowDialog(iwin32Window_0) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}
	}
}
