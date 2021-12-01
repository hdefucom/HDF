using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass52
	{
		private string string_0;

		private static Hashtable hashtable_0 = new Hashtable();

		private GDelegate3 gdelegate3_0;

		private GDelegate2 gdelegate2_0;

		private GDelegate1 gdelegate1_0;

		private IDictionary idictionary_0;

		public static bool smethod_0(string string_1, string string_2)
		{
			int num = 12;
			if (string_1 == string_2)
			{
				return true;
			}
			if (string_1 == null || string_2 == null)
			{
				return false;
			}
			string_1 = string_1.Replace(" ", "");
			string_2 = string_2.Replace(" ", "");
			return string.Compare(string_1, string_2, ignoreCase: true) == 0;
		}

		public GClass52(string string_1)
		{
			int num = 13;
			idictionary_0 = new Hashtable();
			
			if (string_1 == null || string_1 == string.Empty)
			{
				throw new ArgumentException("Expression can't be empty", "expression");
			}
			string_0 = string_1;
		}

		public static void smethod_1()
		{
			hashtable_0.Clear();
		}

		public GClass78 method_0(string string_1)
		{
			if (hashtable_0.ContainsKey(string_1))
			{
				return (GClass78)hashtable_0[string_1];
			}
			GClass47 ginterface10_ = new GClass47(new GClass88(string_1));
			GClass92 gClass = new GClass92(ginterface10_);
			vmethod_0(gClass.vmethod_3());
			GClass49 gClass2 = new GClass49(gClass);
			GClass78 gClass3 = (GClass78)gClass2.method_5().vmethod_3();
			hashtable_0[string_1] = gClass3;
			return gClass3;
		}

		protected virtual void vmethod_0(IList ilist_0)
		{
		}

		public virtual object vmethod_1()
		{
			GClass76 gClass = new GClass76();
			gClass.method_5(gdelegate2_0);
			gClass.method_8(gdelegate1_0);
			gClass.method_3(gdelegate3_0);
			gClass.method_12(idictionary_0);
			GClass78 gclass78_ = method_0(string_0);
			GClass55 gClass2 = GClass55.smethod_0(gclass78_);
			gClass2.vmethod_0(gClass);
			object obj = gClass.method_0();
			if (obj is Array)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (object item in (Array)obj)
				{
					if (item != null && !DBNull.Value.Equals(item))
					{
						string value = Convert.ToString(item);
						if (!string.IsNullOrEmpty(value))
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(',');
							}
							stringBuilder.Append(value);
						}
					}
				}
				return stringBuilder.ToString();
			}
			return obj;
		}

		public static GClass55 smethod_2(string string_1)
		{
			GClass52 gClass = new GClass52(string_1);
			GClass78 gclass78_ = gClass.method_0(gClass.string_0);
			return GClass55.smethod_0(gclass78_);
		}

		public List<GClass55> method_1()
		{
			GClass55 gClass = GClass55.smethod_0(method_0(string_0));
			List<GClass55> list = new List<GClass55>();
			list.Add(gClass);
			method_2(gClass, list);
			return list;
		}

		private void method_2(GClass55 gclass55_0, List<GClass55> list_0)
		{
			if (gclass55_0 is GClass59)
			{
				return;
			}
			if (gclass55_0 is GClass60)
			{
				GClass60 gClass = (GClass60)gclass55_0;
				if (gClass.method_3() != null)
				{
					GClass55[] array = gClass.method_3();
					foreach (GClass55 gClass2 in array)
					{
						list_0.Add(gClass2);
						method_2(gClass2, list_0);
					}
				}
			}
			else
			{
				if (gclass55_0 is GClass58)
				{
					return;
				}
				if (gclass55_0 is GClass57)
				{
					GClass57 gClass3 = (GClass57)gclass55_0;
					if (gClass3.method_2() != null)
					{
						list_0.Add(gClass3.method_2());
						method_2(gClass3.method_2(), list_0);
					}
					if (gClass3.method_3() != null)
					{
						list_0.Add(gClass3.method_3());
						method_2(gClass3.method_3(), list_0);
					}
				}
				else if (gclass55_0 is GClass56)
				{
					GClass56 gClass4 = (GClass56)gclass55_0;
					list_0.Add(gClass4.method_2());
					method_2(gClass4.method_2(), list_0);
				}
			}
		}

		public void method_3(GDelegate3 gdelegate3_1)
		{
			GDelegate3 gDelegate = gdelegate3_0;
			GDelegate3 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate3 value = (GDelegate3)Delegate.Combine(gDelegate2, gdelegate3_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate3_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_4(GDelegate3 gdelegate3_1)
		{
			GDelegate3 gDelegate = gdelegate3_0;
			GDelegate3 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate3 value = (GDelegate3)Delegate.Remove(gDelegate2, gdelegate3_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate3_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_5(GDelegate2 gdelegate2_1)
		{
			GDelegate2 gDelegate = gdelegate2_0;
			GDelegate2 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate2 value = (GDelegate2)Delegate.Combine(gDelegate2, gdelegate2_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate2_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_6(GDelegate2 gdelegate2_1)
		{
			GDelegate2 gDelegate = gdelegate2_0;
			GDelegate2 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate2 value = (GDelegate2)Delegate.Remove(gDelegate2, gdelegate2_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate2_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_7(GDelegate1 gdelegate1_1)
		{
			GDelegate1 gDelegate = gdelegate1_0;
			GDelegate1 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate1 value = (GDelegate1)Delegate.Combine(gDelegate2, gdelegate1_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate1_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_8(GDelegate1 gdelegate1_1)
		{
			GDelegate1 gDelegate = gdelegate1_0;
			GDelegate1 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate1 value = (GDelegate1)Delegate.Remove(gDelegate2, gdelegate1_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate1_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public IDictionary method_9()
		{
			return idictionary_0;
		}

		public void method_10(IDictionary idictionary_1)
		{
			idictionary_0 = idictionary_1;
		}
	}
}
