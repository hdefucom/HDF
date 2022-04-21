using DCSoft.Common;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public class GClass314
	{
		internal enum Enum22
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4
		}

		private object object_0 = null;

		private string string_0 = null;

		private GClass316 gclass316_0 = new GClass316();

		private bool bool_0 = false;

		private int int_0 = 0;

		private Enum22 enum22_0 = Enum22.const_2;

		private IEnumerator ienumerator_0 = null;

		public GClass314()
		{
		}

		public GClass314(object object_1)
		{
			object_0 = object_1;
		}

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_1)
		{
			object_0 = object_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public GClass316 method_4()
		{
			return gclass316_0;
		}

		public void method_5(GClass316 gclass316_1)
		{
			gclass316_0 = gclass316_1;
		}

		private void method_6()
		{
			if (!bool_0)
			{
				bool_0 = true;
				method_7();
			}
		}

		public void method_7()
		{
			int_0 = 0;
			int num = 0;
			foreach (GClass315 item in method_4())
			{
				item.int_1 = num++;
			}
			if (object_0 == null)
			{
				foreach (GClass315 item2 in method_4())
				{
					item2.bool_0 = true;
				}
				return;
			}
			if (object_0 is IDataReader)
			{
				IDataReader dataReader = (IDataReader)object_0;
				enum22_0 = Enum22.const_4;
				foreach (GClass315 item3 in method_4())
				{
					item3.int_0 = dataReader.GetOrdinal(item3.method_1());
					if (item3.int_0 >= 0)
					{
						item3.enum22_0 = Enum22.const_4;
						item3.bool_0 = false;
					}
					else
					{
						item3.bool_0 = true;
					}
				}
			}
			else if (object_0 is DataTable)
			{
				DataTable dataTable = (DataTable)object_0;
				enum22_0 = Enum22.const_0;
				ienumerator_0 = dataTable.Rows.GetEnumerator();
				foreach (GClass315 item4 in method_4())
				{
					item4.int_0 = dataTable.Columns.IndexOf(item4.method_1());
					if (item4.int_0 >= 0)
					{
						item4.enum22_0 = Enum22.const_0;
						item4.bool_0 = false;
					}
					else
					{
						item4.bool_0 = true;
					}
				}
			}
			else if (object_0 is DataView)
			{
				DataView dataView = (DataView)object_0;
				enum22_0 = Enum22.const_0;
				ienumerator_0 = dataView.GetEnumerator();
				foreach (GClass315 item5 in method_4())
				{
					item5.int_0 = dataView.Table.Columns.IndexOf(item5.method_1());
					if (item5.int_0 >= 0)
					{
						item5.enum22_0 = Enum22.const_0;
						item5.bool_0 = false;
					}
					else
					{
						item5.bool_0 = true;
					}
				}
			}
			else if (object_0 is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)object_0;
				if (!string.IsNullOrEmpty(method_2()))
				{
					XmlNodeList xmlNodeList = xmlNode.SelectNodes(method_2());
					ienumerator_0 = xmlNodeList.GetEnumerator();
				}
				else
				{
					ienumerator_0 = xmlNode.ChildNodes.GetEnumerator();
				}
				enum22_0 = Enum22.const_3;
				foreach (GClass315 item6 in method_4())
				{
					item6.bool_0 = false;
					item6.enum22_0 = Enum22.const_3;
				}
			}
			else if (object_0 is XmlNodeList)
			{
				XmlNodeList xmlNodeList = (XmlNodeList)object_0;
				enum22_0 = Enum22.const_3;
				ienumerator_0 = xmlNodeList.GetEnumerator();
				foreach (GClass315 item7 in method_4())
				{
					item7.bool_0 = false;
					item7.enum22_0 = Enum22.const_3;
				}
			}
			else if (object_0 is IEnumerable)
			{
				IEnumerable enumerable = (IEnumerable)object_0;
				ienumerator_0 = enumerable.GetEnumerator();
				enum22_0 = Enum22.const_2;
				foreach (GClass315 item8 in method_4())
				{
					item8.bool_0 = false;
					item8.enum22_0 = Enum22.const_2;
				}
			}
			foreach (GClass315 item9 in method_4())
			{
				if (string.IsNullOrEmpty(item9.method_1()))
				{
					item9.bool_0 = true;
				}
			}
		}

		public void method_8()
		{
			method_7();
			if (!(object_0 is IDataReader))
			{
			}
			if (ienumerator_0 != null)
			{
				ienumerator_0.Reset();
			}
		}

		public bool method_9()
		{
			if (object_0 is IDataReader)
			{
				IDataReader dataReader = (IDataReader)object_0;
				return dataReader.Read();
			}
			if (ienumerator_0 == null)
			{
				return false;
			}
			return ienumerator_0.MoveNext();
		}

		public object method_10()
		{
			if (object_0 is IDataReader)
			{
				return (IDataReader)object_0;
			}
			if (ienumerator_0 == null)
			{
				return null;
			}
			return ienumerator_0.Current;
		}

		public object method_11(string string_1)
		{
			GClass318 gClass = GClass318.smethod_0(method_10());
			return gClass.method_2(string_1);
		}
	}
}
