using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public class GClass99
	{
		private object object_0 = null;

		private IEnumerator ienumerator_0 = null;

		private string string_0 = null;

		private XTextElement xtextElement_0 = null;

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_1)
		{
			if (object_0 != object_1)
			{
				object_0 = object_1;
				ienumerator_0 = null;
			}
		}

		private bool method_2()
		{
			if (ienumerator_0 == null && object_0 != null)
			{
				if (object_0 is IList)
				{
					ienumerator_0 = ((IList)object_0).GetEnumerator();
				}
				else if (object_0 is XmlNodeList)
				{
					ienumerator_0 = ((XmlNodeList)object_0).GetEnumerator();
				}
				else
				{
					object[] array = new object[1]
					{
						object_0
					};
					ienumerator_0 = array.GetEnumerator();
				}
				return true;
			}
			return false;
		}

		public bool method_3()
		{
			if (method_2())
			{
				return ienumerator_0.MoveNext();
			}
			return false;
		}

		public object method_4()
		{
			if (method_2())
			{
				return ienumerator_0.Current;
			}
			return null;
		}

		public string method_5()
		{
			return string_0;
		}

		public void method_6(string string_1)
		{
			string_0 = string_1;
		}

		public XTextElement method_7()
		{
			return xtextElement_0;
		}

		public void method_8(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}
	}
}
