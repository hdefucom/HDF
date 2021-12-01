#define DEBUG
using DCSoft.RTF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass386 : GClass383
	{
		private bool bool_1 = false;

		private string string_0 = null;

		private string string_1 = null;

		private CultureInfo cultureInfo_0 = null;

		private CultureInfo cultureInfo_1 = null;

		private Encoding encoding_0 = Encoding.Default;

		private Encoding encoding_1 = null;

		private Encoding encoding_2 = null;

		private static string string_2 = Control.DefaultFont.Name;

		private GClass430 gclass430_0 = new GClass430();

		private GClass418 gclass418_0 = new GClass418();

		private GClass403 gclass403_0 = new GClass403();

		private GClass419 gclass419_0 = new GClass419();

		private GClass424 gclass424_0 = new GClass424();

		private string string_3 = null;

		private int int_1 = 12240;

		private int int_2 = 15840;

		private int int_3 = 1800;

		private int int_4 = 1440;

		private int int_5 = 1800;

		private int int_6 = 1440;

		private bool bool_2 = false;

		private int int_7 = 720;

		private int int_8 = 720;

		private bool bool_3 = false;

		private GDelegate23 gdelegate23_0 = null;

		private int int_9 = 0;

		private bool bool_4 = false;

		private int int_10 = 400;

		private int int_11 = 0;

		private GClass425 gclass425_0 = null;

		private Stack<GClass425> stack_0 = new Stack<GClass425>();

		private string string_4 = null;

		private Dictionary<int, Dictionary<string, string>> dictionary_0 = null;

		public GClass386()
		{
			method_7(this);
		}

		public bool method_17()
		{
			return bool_1;
		}

		public void method_18(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public string method_19()
		{
			return string_0;
		}

		public void method_20(string string_5)
		{
			string_0 = string_5;
		}

		public string method_21()
		{
			return string_1;
		}

		public void method_22(string string_5)
		{
			string_1 = string_5;
		}

		internal Encoding method_23()
		{
			if (cultureInfo_1 != null)
			{
				return Encoding.GetEncoding(cultureInfo_1.TextInfo.ANSICodePage);
			}
			if (cultureInfo_0 != null)
			{
				return Encoding.GetEncoding(cultureInfo_0.TextInfo.ANSICodePage);
			}
			if (encoding_1 != null)
			{
				return encoding_1;
			}
			if (encoding_2 != null)
			{
				return encoding_2;
			}
			return encoding_0;
		}

		public GClass430 method_24()
		{
			return gclass430_0;
		}

		public void method_25(GClass430 gclass430_1)
		{
			gclass430_0 = gclass430_1;
		}

		public GClass418 method_26()
		{
			return gclass418_0;
		}

		public void method_27(GClass418 gclass418_1)
		{
			gclass418_0 = gclass418_1;
		}

		public GClass403 method_28()
		{
			return gclass403_0;
		}

		public void method_29(GClass403 gclass403_1)
		{
			gclass403_0 = gclass403_1;
		}

		public GClass419 method_30()
		{
			return gclass419_0;
		}

		public void method_31(GClass419 gclass419_1)
		{
			gclass419_0 = gclass419_1;
		}

		public GClass424 method_32()
		{
			return gclass424_0;
		}

		public void method_33(GClass424 gclass424_1)
		{
			gclass424_0 = gclass424_1;
		}

		public string method_34()
		{
			return string_3;
		}

		public void method_35(string string_5)
		{
			string_3 = string_5;
		}

		public int method_36()
		{
			return int_1;
		}

		public void method_37(int int_12)
		{
			int_1 = int_12;
		}

		public int method_38()
		{
			return int_2;
		}

		public void method_39(int int_12)
		{
			int_2 = int_12;
		}

		public int method_40()
		{
			return int_3;
		}

		public void method_41(int int_12)
		{
			int_3 = int_12;
		}

		public int method_42()
		{
			return int_4;
		}

		public void method_43(int int_12)
		{
			int_4 = int_12;
		}

		public int method_44()
		{
			return int_5;
		}

		public void method_45(int int_12)
		{
			int_5 = int_12;
		}

		public int method_46()
		{
			return int_6;
		}

		public void method_47(int int_12)
		{
			int_6 = int_12;
		}

		public bool method_48()
		{
			return bool_2;
		}

		public void method_49(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public int method_50()
		{
			return int_7;
		}

		public void method_51(int int_12)
		{
			int_7 = int_12;
		}

		public int method_52()
		{
			return int_8;
		}

		public void method_53(int int_12)
		{
			int_8 = int_12;
		}

		public int method_54()
		{
			if (bool_2)
			{
				return int_2 - int_3 - int_5;
			}
			return int_1 - int_3 - int_5;
		}

		public bool method_55()
		{
			return bool_3;
		}

		public void method_56(bool bool_5)
		{
			bool_3 = bool_5;
		}

		public void method_57(GDelegate23 gdelegate23_1)
		{
			GDelegate23 gDelegate = gdelegate23_0;
			GDelegate23 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate23 value = (GDelegate23)Delegate.Combine(gDelegate2, gdelegate23_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate23_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_58(GDelegate23 gdelegate23_1)
		{
			GDelegate23 gDelegate = gdelegate23_0;
			GDelegate23 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate23 value = (GDelegate23)Delegate.Remove(gDelegate2, gdelegate23_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate23_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		protected bool method_59(int int_12, int int_13, string string_5)
		{
			if (gdelegate23_0 != null)
			{
				GEventArgs13 gEventArgs = new GEventArgs13(int_12, int_13, string_5);
				gdelegate23_0(this, gEventArgs);
				return gEventArgs.method_3();
			}
			return false;
		}

		public void method_60(string string_5)
		{
			using (FileStream stream_ = new FileStream(string_5, FileMode.Open, FileAccess.Read))
			{
				method_61(stream_);
			}
		}

		public void method_61(Stream stream_0)
		{
			string_4 = null;
			method_5().Clear();
			bool_4 = false;
			GClass410 gclass410_ = new GClass410(stream_0);
			GClass425 gclass425_ = new GClass425();
			gclass425_0 = null;
			method_82(gclass410_, gclass425_);
			method_74(this);
			method_66(this);
			method_64();
		}

		public void method_62(TextReader textReader_0)
		{
			string_4 = null;
			method_5().Clear();
			bool_4 = false;
			GClass410 gclass410_ = new GClass410(textReader_0);
			GClass425 gclass425_ = new GClass425();
			gclass425_0 = null;
			method_82(gclass410_, gclass425_);
			method_74(this);
			method_66(this);
			method_64();
			method_4();
		}

		public void method_63(string string_5)
		{
			StringReader textReader_ = new StringReader(string_5);
			string_4 = null;
			method_5().Clear();
			bool_4 = false;
			GClass410 gclass410_ = new GClass410(textReader_);
			GClass425 gclass425_ = new GClass425();
			gclass425_0 = null;
			method_82(gclass410_, gclass425_);
			method_74(this);
			method_66(this);
			method_64();
		}

		private void method_64()
		{
		}

		public void method_65(GClass383 gclass383_1)
		{
			GClass388 gClass = null;
			GClass409 gClass2 = new GClass409();
			foreach (GClass383 item in gclass383_1.method_5())
			{
				if (item is GClass397 || item is GClass398)
				{
					method_65(item);
					gClass = null;
					gClass2.method_2(item);
				}
				else if (item is GClass388 || item is GClass395 || item is GClass391 || item is GClass390)
				{
					gClass = null;
					gClass2.method_2(item);
				}
				else
				{
					if (gClass == null)
					{
						gClass = new GClass388();
						gClass2.method_2(gClass);
						if (item is GClass393)
						{
							gClass.method_22(((GClass393)item).method_17().method_78());
						}
					}
					gClass.method_5().method_2(item);
				}
			}
			gclass383_1.method_5().Clear();
			foreach (GClass383 item2 in gClass2)
			{
				gclass383_1.method_5().method_2(item2);
			}
		}

		private void method_66(GClass383 gclass383_1)
		{
			ArrayList arrayList = new ArrayList();
			foreach (GClass383 item in gclass383_1.method_5())
			{
				if (item is GClass388)
				{
					GClass388 gClass2 = (GClass388)item;
					if (gClass2.method_21().method_41())
					{
						gClass2.method_21().method_42(bool_17: false);
						arrayList.Add(new GClass385());
					}
				}
				if (item is GClass393)
				{
					if (arrayList.Count > 0 && arrayList[arrayList.Count - 1] is GClass393)
					{
						GClass393 gClass3 = (GClass393)arrayList[arrayList.Count - 1];
						GClass393 gClass4 = (GClass393)item;
						if (gClass3.method_19().Length == 0 || gClass4.method_19().Length == 0)
						{
							if (gClass3.method_19().Length == 0)
							{
								gClass3.method_18(gClass4.method_17().method_78());
							}
							gClass3.method_20(gClass3.method_19() + gClass4.method_19());
						}
						else if (gClass3.method_17().method_77(gClass4.method_17()))
						{
							gClass3.method_20(gClass3.method_19() + gClass4.method_19());
						}
						else
						{
							arrayList.Add(gClass4);
						}
					}
					else
					{
						arrayList.Add(item);
					}
				}
				else
				{
					arrayList.Add(item);
				}
			}
			gclass383_1.method_5().Clear();
			gclass383_1.method_13(bool_1: false);
			foreach (GClass383 item2 in arrayList)
			{
				gclass383_1.method_8(item2);
			}
			GClass383[] array = gclass383_1.method_5().method_6();
			foreach (GClass383 gClass in array)
			{
				if (gClass is GClass391)
				{
					method_78((GClass391)gClass, bool_5: true);
				}
			}
			if (method_5().Count > 1 && method_5().method_0(0) is GClass388)
			{
				GClass388 gClass2 = (GClass388)method_5().method_0(0);
				if (gClass2.method_19())
				{
					gClass2.method_20(bool_3: false);
					if (method_5().method_1() is GClass388)
					{
						((GClass388)method_5().method_1()).method_20(bool_3: true);
					}
				}
			}
			foreach (GClass383 item3 in gclass383_1.method_5())
			{
				method_66(item3);
			}
		}

		private GClass383[] method_67(bool bool_5)
		{
			List<GClass383> list = new List<GClass383>();
			GClass383 gClass = this;
			while (gClass != null && (!bool_5 || !gClass.method_12()))
			{
				list.Add(gClass);
				gClass = gClass.method_5().method_1();
			}
			if (bool_5)
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num].method_12())
					{
						list.RemoveAt(num);
					}
				}
			}
			if (list.Count == 0)
			{
				method_13(bool_1: false);
				list.Add(this);
			}
			return list.ToArray();
		}

		public GClass383 method_68(Type type_0)
		{
			GClass383[] array = method_67(bool_5: true);
			int num = array.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (type_0.IsInstanceOfType(array[num]))
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return array[num];
		}

		public GClass383 method_69(Type type_0, bool bool_5)
		{
			GClass383[] array = method_67(bool_5: true);
			int num = array.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (type_0.IsInstanceOfType(array[num]) && array[num].method_12() == bool_5)
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return array[num];
		}

		public GClass383 method_70()
		{
			GClass383[] array = method_67(bool_5: true);
			return array[array.Length - 1];
		}

		private void method_71()
		{
			GClass383 gClass = method_70();
			while (true)
			{
				if (gClass != null)
				{
					if (gClass is GClass388)
					{
						break;
					}
					gClass = gClass.method_10();
					continue;
				}
				return;
			}
			GClass388 gClass2 = (GClass388)gClass;
			gClass2.method_13(bool_1: true);
			if (gclass425_0 != null)
			{
				gClass2.method_22(gclass425_0);
				gclass425_0 = gclass425_0.method_78();
			}
			else
			{
				gclass425_0 = new GClass425();
			}
		}

		private void method_72(GClass383 gclass383_1)
		{
			GClass383[] array = method_67(bool_5: true);
			if (array.Length != 0)
			{
			}
			GClass383 gClass = null;
			if (array.Length > 0)
			{
				gClass = array[array.Length - 1];
			}
			if ((gClass is GClass386 || gClass is GClass397 || gClass is GClass398) && (gclass383_1 is GClass393 || gclass383_1 is GClass400 || gclass383_1 is GClass389 || gclass383_1 is GClass396 || gclass383_1 is GClass384))
			{
				GClass388 gClass2 = new GClass388();
				if (gClass.method_5().Count > 0)
				{
					gClass2.method_20(bool_3: true);
				}
				else if (gClass is GClass386 && gClass.method_5().Count == 0)
				{
					gClass2.method_20(bool_3: true);
				}
				if (gclass425_0 != null)
				{
					gClass2.method_22(gclass425_0);
				}
				gClass.method_8(gClass2);
				gClass2.method_5().method_2(gclass383_1);
				return;
			}
			if (array.Length != 0)
			{
			}
			GClass383 gClass3 = array[array.Length - 1];
			if (gclass383_1 != null && gclass383_1.int_0 > 0)
			{
				int num = array.Length - 1;
				while (num >= 0)
				{
					if (array[num].int_0 != gclass383_1.int_0)
					{
						num--;
						continue;
					}
					for (int i = num; i < array.Length; i++)
					{
						GClass383 gClass4 = array[i];
						if ((!(gclass383_1 is GClass393) && !(gclass383_1 is GClass400) && !(gclass383_1 is GClass389) && !(gclass383_1 is GClass396) && !(gclass383_1 is GClass384) && !(gclass383_1 is GClass394) && !(gclass383_1 is GClass401) && !(gclass383_1 is GClass392)) || gclass383_1.int_0 != gClass4.int_0 || (!(gClass4 is GClass395) && !(gClass4 is GClass390) && !(gClass4 is GClass394) && !(gClass4 is GClass388)))
						{
							array[i].method_13(bool_1: true);
						}
					}
					break;
				}
			}
			for (int num = array.Length - 1; num >= 0; num--)
			{
				if (!array[num].method_12())
				{
					gClass3 = array[num];
					if (!(gClass3 is GClass400))
					{
						break;
					}
					gClass3.method_13(bool_1: true);
				}
			}
			if (gClass3 is GClass395)
			{
				GClass390 gClass5 = new GClass390();
				gClass5.int_0 = gClass3.int_0;
				gClass3.method_8(gClass5);
				if (gclass383_1 is GClass395)
				{
					gClass5.method_5().method_2(gclass383_1);
					return;
				}
				GClass388 gClass6 = new GClass388();
				gClass6.method_22(gclass425_0.method_78());
				gClass6.int_0 = gClass5.int_0;
				gClass5.method_8(gClass6);
				if (gclass383_1 != null)
				{
					gClass6.method_8(gclass383_1);
				}
			}
			else if (gclass383_1 != null)
			{
				if (gClass3 is GClass388 && (gclass383_1 is GClass388 || gclass383_1 is GClass395))
				{
					gClass3.method_13(bool_1: true);
					gClass3.method_10().method_8(gclass383_1);
				}
				else
				{
					gClass3.method_8(gclass383_1);
				}
			}
		}

		private byte[] method_73(string string_5)
		{
			string text = "0123456789abcdef";
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			GClass413 gClass = new GClass413();
			for (int i = 0; i < string_5.Length; i++)
			{
				char c = string_5[i];
				c = char.ToLower(c);
				num = text.IndexOf(c);
				if (num >= 0)
				{
					num3++;
					num2 = num2 * 16 + num;
					if (num3 > 0 && num3 % 2 == 0)
					{
						gClass.method_3((byte)num2);
						num2 = 0;
					}
				}
			}
			return gClass.method_6();
		}

		private void method_74(GClass383 gclass383_1)
		{
			int num = 6;
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			int num2 = -1;
			GClass395 gClass = null;
			foreach (GClass383 item in gclass383_1.method_5())
			{
				if (item is GClass395)
				{
					GClass395 gClass3 = (GClass395)item;
					gClass3.method_13(bool_1: false);
					ArrayList arrayList3 = gClass3.method_17();
					if (arrayList3.Count == 0 && gClass != null && gClass.method_17().Count == gClass3.method_5().Count)
					{
						arrayList3 = gClass.method_17();
					}
					if (arrayList3.Count == gClass3.method_5().Count)
					{
						for (int i = 0; i < gClass3.method_5().Count; i++)
						{
							gClass3.method_5().method_0(i).method_1((GClass423)arrayList3[i]);
						}
					}
					bool flag;
					if (!(flag = gClass3.method_2("lastrow")))
					{
						int num3 = gclass383_1.method_5().method_4(item);
						if (num3 == gclass383_1.method_5().Count - 1)
						{
							flag = true;
						}
						else
						{
							GClass383 gClass4 = gclass383_1.method_5().method_0(num3 + 1);
							if (!(gClass4 is GClass395))
							{
								flag = true;
							}
						}
					}
					if (flag)
					{
						arrayList2.Add(gClass3);
						arrayList.Add(method_75(arrayList2));
						num2 = -1;
					}
					else
					{
						int num4 = 0;
						if (gClass3.method_2("trwWidth"))
						{
							num4 = gClass3.method_0().method_1("trwWidth");
							if (gClass3.method_2("trwWidthA"))
							{
								num4 -= gClass3.method_0().method_1("trwWidthA");
							}
						}
						else
						{
							foreach (GClass390 item2 in gClass3.method_5())
							{
								if (item2.method_2("cellx"))
								{
									num4 = Math.Max(num4, item2.method_0().method_1("cellx"));
								}
							}
						}
						if (num2 > 0 && num2 != num4 && arrayList2.Count > 0)
						{
							arrayList.Add(method_75(arrayList2));
						}
						num2 = num4;
						arrayList2.Add(gClass3);
					}
					gClass = gClass3;
				}
				else if (item is GClass390)
				{
					gClass = null;
					method_74(item);
					if (arrayList2.Count > 0)
					{
						arrayList.Add(method_75(arrayList2));
					}
					arrayList.Add(item);
					num2 = -1;
				}
				else
				{
					gClass = null;
					method_74(item);
					if (arrayList2.Count > 0)
					{
						arrayList.Add(method_75(arrayList2));
					}
					arrayList.Add(item);
					num2 = -1;
				}
			}
			if (arrayList2.Count > 0)
			{
				arrayList.Add(method_75(arrayList2));
			}
			gclass383_1.method_13(bool_1: false);
			gclass383_1.method_5().Clear();
			foreach (GClass383 item3 in arrayList)
			{
				gclass383_1.method_8(item3);
			}
		}

		private GClass391 method_75(ArrayList arrayList_0)
		{
			int num = 2;
			if (arrayList_0.Count > 0)
			{
				GClass391 gClass = new GClass391();
				int num2 = 0;
				foreach (GClass395 item in arrayList_0)
				{
					item.method_24(num2);
					num2++;
					gClass.method_8(item);
				}
				arrayList_0.Clear();
				foreach (GClass395 item2 in gClass.method_5())
				{
					foreach (GClass390 item3 in item2.method_5())
					{
						method_74(item3);
					}
				}
				return gClass;
			}
			throw new ArgumentException("rows");
		}

		public int method_76()
		{
			return int_10;
		}

		public void method_77(int int_12)
		{
			int_10 = int_12;
		}

		private void method_78(GClass391 gclass391_0, bool bool_5)
		{
			int num = 14;
			int val = 0;
			bool flag = false;
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			for (int num3 = gclass391_0.method_5().Count - 1; num3 >= 0; num3--)
			{
				GClass395 gClass = (GClass395)gclass391_0.method_5().method_0(num3);
				if (gClass.method_5().Count == 0)
				{
					gclass391_0.method_5().RemoveAt(num3);
				}
			}
			if (gclass391_0.method_5().Count == 0)
			{
				Debug.WriteLine("");
			}
			foreach (GClass395 item in gclass391_0.method_5())
			{
				int num4 = 0;
				val = Math.Max(val, item.method_5().Count);
				if (item.method_2("irow"))
				{
					item.method_24(item.method_0().method_1("irow"));
				}
				item.method_26(item.method_2("lastrow"));
				item.method_28(item.method_2("trhdr"));
				if (item.method_2("trrh"))
				{
					item.method_30(item.method_0().method_1("trrh"));
					if (item.method_29() == 0)
					{
						item.method_30(method_76());
					}
					else if (item.method_29() < 0)
					{
						item.method_30(-item.method_29());
					}
				}
				else
				{
					item.method_30(method_76());
				}
				if (item.method_2("trpaddl"))
				{
					item.method_32(item.method_0().method_1("trpaddl"));
				}
				else
				{
					item.method_32(int.MinValue);
				}
				if (item.method_2("trpaddt"))
				{
					item.method_34(item.method_0().method_1("trpaddt"));
				}
				else
				{
					item.method_34(int.MinValue);
				}
				if (item.method_2("trpaddr"))
				{
					item.method_36(item.method_0().method_1("trpaddr"));
				}
				else
				{
					item.method_36(int.MinValue);
				}
				if (item.method_2("trpaddb"))
				{
					item.method_38(item.method_0().method_1("trpaddb"));
				}
				else
				{
					item.method_38(int.MinValue);
				}
				if (item.method_2("trleft"))
				{
					num2 = item.method_0().method_1("trleft");
				}
				if (item.method_2("trcbpat"))
				{
					item.method_19().method_64(method_26().method_1(item.method_0().method_1("trcbpat"), Color.Transparent));
				}
				int num5 = 0;
				foreach (GClass390 item2 in item.method_5())
				{
					if (item2.method_2("clvmgf"))
					{
						flag = true;
					}
					if (item2.method_2("clvmrg"))
					{
						flag = true;
					}
					if (item2.method_2("clpadl"))
					{
						item2.method_22(item2.method_0().method_1("clpadl"));
					}
					else
					{
						item2.method_22(int.MinValue);
					}
					if (item2.method_2("clpadr"))
					{
						item2.method_28(item2.method_0().method_1("clpadr"));
					}
					else
					{
						item2.method_28(int.MinValue);
					}
					if (item2.method_2("clpadt"))
					{
						item2.method_25(item2.method_0().method_1("clpadt"));
					}
					else
					{
						item2.method_25(int.MinValue);
					}
					if (item2.method_2("clpadb"))
					{
						item2.method_31(item2.method_0().method_1("clpadb"));
					}
					else
					{
						item2.method_31(int.MinValue);
					}
					item2.method_35().method_4(item2.method_2("clbrdrl"));
					item2.method_35().method_6(item2.method_2("clbrdrt"));
					item2.method_35().method_8(item2.method_2("clbrdrr"));
					item2.method_35().method_10(item2.method_2("clbrdrb"));
					if (item2.method_2("brdrcf"))
					{
						item2.method_35().method_12(method_26().method_1(item2.method_3("brdrcf", 1), Color.Black));
					}
					for (int num3 = item2.method_0().Count - 1; num3 >= 0; num3--)
					{
						string name = item2.method_0().method_0(num3).Name;
						if (name == "brdrtbl" || name == "brdrnone" || name == "brdrnil")
						{
							for (int num6 = num3 - 1; num6 >= 0; num6--)
							{
								switch (item2.method_0().method_0(num6).Name)
								{
								default:
									continue;
								case "clbrdrl":
									item2.method_35().method_4(bool_17: false);
									break;
								case "clbrdrt":
									item2.method_35().method_6(bool_17: false);
									break;
								case "clbrdrr":
									item2.method_35().method_8(bool_17: false);
									break;
								case "clbrdrb":
									item2.method_35().method_10(bool_17: false);
									break;
								}
								break;
							}
						}
					}
					if (item2.method_2("clvertalt"))
					{
						item2.method_34(GEnum83.const_0);
					}
					else if (item2.method_2("clvertalc"))
					{
						item2.method_34(GEnum83.const_1);
					}
					else if (item2.method_2("clvertalb"))
					{
						item2.method_34(GEnum83.const_2);
					}
					if (item2.method_2("clcbpat"))
					{
						item2.method_35().method_64(method_26().method_1(item2.method_0().method_1("clcbpat"), Color.Transparent));
					}
					else
					{
						item2.method_35().method_64(Color.Transparent);
					}
					if (item2.method_2("clcfpat"))
					{
						item2.method_35().method_12(method_26().method_1(item2.method_0().method_1("clcfpat"), Color.Black));
					}
					int num7 = 2763;
					if (item2.method_2("cellx"))
					{
						num7 = item2.method_0().method_1("cellx") - num4;
						if (num7 < 100)
						{
							num7 = 100;
						}
					}
					int num8 = num4 + num7;
					for (int num3 = 0; num3 < arrayList.Count; num3++)
					{
						if (Math.Abs(num8 - (int)arrayList[num3]) < 45)
						{
							num8 = (int)arrayList[num3];
							num7 = num8 - num4;
							break;
						}
					}
					item2.method_40(num4);
					item2.method_42(num7);
					if (item2.method_2("cellx"))
					{
					}
					num5 += num7;
					if (!arrayList.Contains(num8))
					{
						arrayList.Add(num8);
					}
					num4 += num7;
				}
				item.method_40(num5);
			}
			if (arrayList.Count == 0)
			{
				int num9 = 1;
				foreach (GClass395 item3 in gclass391_0.method_5())
				{
					num9 = Math.Max(num9, item3.method_5().Count);
				}
				int num10 = method_54() / num9;
				for (int num3 = 0; num3 < num9; num3++)
				{
					arrayList.Add(num3 * num10 + num10);
				}
			}
			arrayList.Add(0);
			arrayList.Sort();
			for (int num3 = 1; num3 < arrayList.Count; num3++)
			{
				GClass387 gClass3 = new GClass387();
				gClass3.method_18((int)arrayList[num3] - (int)arrayList[num3 - 1]);
				gclass391_0.method_17().method_2(gClass3);
			}
			for (int i = 1; i < gclass391_0.method_5().Count; i++)
			{
				GClass395 gClass = (GClass395)gclass391_0.method_5().method_0(i);
				for (int j = 0; j < gClass.method_5().Count; j++)
				{
					GClass390 gClass2 = (GClass390)gClass.method_5().method_0(j);
					if (gClass2.method_41() == 0)
					{
						GClass395 gClass4 = (GClass395)gclass391_0.method_5().method_0(i - 1);
						if (gClass4.method_5().Count > j)
						{
							GClass390 gClass5 = (GClass390)gClass4.method_5().method_0(j);
							gClass2.method_40(gClass5.method_39());
							gClass2.method_42(gClass5.method_41());
							method_79(gClass2, gClass5.method_0());
						}
					}
				}
			}
			if (!flag)
			{
				foreach (GClass395 item4 in gclass391_0.method_5())
				{
					if (item4.method_5().Count < gclass391_0.method_17().Count)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				foreach (GClass395 item5 in gclass391_0.method_5())
				{
					if (item5.method_5().Count != gclass391_0.method_17().Count)
					{
						GClass383[] array = item5.method_5().method_6();
						GClass383[] array2 = array;
						for (int k = 0; k < array2.Length; k++)
						{
							GClass390 gClass2 = (GClass390)array2[k];
							int num11 = arrayList.IndexOf(gClass2.method_39());
							int num12 = arrayList.IndexOf(gClass2.method_39() + gClass2.method_41());
							int num13 = num12 - num11;
							bool flag2;
							if (!(flag2 = gClass2.method_2("clvmrg")))
							{
								gClass2.method_20(num13);
							}
							if (item5.method_5().method_1() == gClass2)
							{
								gClass2.method_20(gclass391_0.method_17().Count - item5.method_5().Count + 1);
								num13 = gClass2.method_19();
							}
							for (int num3 = 0; num3 < num13 - 1; num3++)
							{
								GClass390 gClass6 = new GClass390();
								gClass6.method_1(gClass2.method_0().method_9());
								item5.method_5().method_3(item5.method_5().method_4(gClass2) + 1, gClass6);
								if (flag2)
								{
									gClass6.method_0().method_2("clvmrg", 1);
									gClass6.method_46(gClass2);
								}
							}
						}
						if (item5.method_5().Count != gclass391_0.method_17().Count)
						{
							GClass390 gClass7 = (GClass390)item5.method_5().method_1();
							if (gClass7 == null)
							{
								Console.WriteLine("");
							}
							for (int num3 = item5.method_5().Count; num3 < arrayList.Count; num3++)
							{
								GClass390 gClass6 = new GClass390();
								method_79(gClass6, gClass7.method_0());
								item5.method_5().method_2(gClass6);
							}
						}
					}
				}
				foreach (GClass395 item6 in gclass391_0.method_5())
				{
					foreach (GClass390 item7 in item6.method_5())
					{
						if (item7.method_2("clvmgf"))
						{
							int j = item6.method_5().method_4(item7);
							for (int i = gclass391_0.method_5().method_4(item6) + 1; i < gclass391_0.method_5().Count; i++)
							{
								GClass395 gClass8 = (GClass395)gclass391_0.method_5().method_0(i);
								if (j >= gClass8.method_5().Count)
								{
									Console.Write("");
								}
								GClass390 gClass9 = (GClass390)gClass8.method_5().method_0(j);
								if (!gClass9.method_2("clvmrg") || gClass9.method_45() != null)
								{
									break;
								}
								GClass390 gClass10 = item7;
								gClass10.method_18(gClass10.method_17() + 1);
								gClass9.method_46(item7);
							}
						}
					}
				}
				foreach (GClass395 item8 in gclass391_0.method_5())
				{
					foreach (GClass390 item9 in item8.method_5())
					{
						if (item9.method_17() > 1 || item9.method_19() > 1)
						{
							for (int i = 1; i <= item9.method_17(); i++)
							{
								for (int j = 1; j <= item9.method_19(); j++)
								{
									int int_ = gclass391_0.method_5().method_4(item8) + i - 1;
									int int_2 = item8.method_5().method_4(item9) + j - 1;
									GClass390 gClass9 = (GClass390)gclass391_0.method_5().method_0(int_).method_5()
										.method_0(int_2);
									if (item9 != gClass9)
									{
										gClass9.method_46(item9);
									}
								}
							}
						}
					}
				}
			}
			if (bool_5 && gclass391_0.method_17().Count > 0)
			{
				GClass387 obj = (GClass387)gclass391_0.method_17().method_0(0);
				obj.method_18(obj.method_17() - num2);
			}
		}

		private void method_79(GClass390 gclass390_0, GClass423 gclass423_1)
		{
			GClass423 gClass = gclass423_1.method_9();
			gClass.method_6("clvmgf");
			gClass.method_6("clvmrg");
			gclass390_0.method_1(gClass);
		}

		public override string ToString()
		{
			return "RTFDocument:" + gclass424_0.method_2();
		}

		private bool method_80(Class201 class201_0, GClass410 gclass410_0, GClass425 gclass425_1)
		{
			if (class201_0.method_4())
			{
				string string_ = class201_0.method_5();
				class201_0.method_8();
				GClass400 gClass = (GClass400)method_68(typeof(GClass400));
				if (!(gClass?.method_12() ?? true))
				{
					gClass.method_20(method_73(string_));
					gClass.method_38(gclass425_1.method_78());
					gClass.method_32(gClass.method_27() * gClass.method_23() / 100);
					gClass.method_34(gClass.method_29() * gClass.method_25() / 100);
					gClass.method_13(bool_1: true);
					if (gclass410_0.method_6() != RTFTokenType.GroupEnd)
					{
						method_83(gclass410_0);
					}
					return true;
				}
				if (gclass425_1.bool_16 && bool_4)
				{
					GClass393 gClass2 = new GClass393();
					gClass2.int_0 = class201_0.method_6();
					gClass2.method_18(gclass425_1.method_78());
					if (gClass2.method_17().method_39() == GEnum80.const_3)
					{
						gClass2.method_17().method_40(GEnum80.const_0);
					}
					gClass2.method_20(string_);
					method_72(gClass2);
				}
			}
			return false;
		}

		private CultureInfo method_81(int int_12)
		{
			if (int_12 == 1024)
			{
				return CultureInfo.CurrentCulture;
			}
			try
			{
				return new CultureInfo(int_12);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return CultureInfo.CurrentCulture;
			}
		}

		private void method_82(GClass410 gclass410_0, GClass425 gclass425_1)
		{
			int num = 8;
			bool flag = false;
			GClass425 gClass = null;
			if (gclass425_0 == null)
			{
				gclass425_0 = new GClass425();
			}
			if (gclass425_1 == null)
			{
				gClass = new GClass425();
			}
			else
			{
				gClass = gclass425_1.method_78();
				gClass.int_10 = gclass425_1.int_10 + 1;
			}
			stack_0.Push(gClass);
			Class201 @class = new Class201(this);
			int num2 = gclass410_0.method_15();
			while (gclass410_0.method_22() != null)
			{
				if (gclass410_0.method_16() - int_11 > 100)
				{
					int_11 = gclass410_0.method_16();
					method_59(gclass410_0.method_11(), gclass410_0.method_10(), null);
				}
				if (bool_4)
				{
					if (@class.method_3(gclass410_0.method_5(), gclass410_0))
					{
						@class.method_7(gclass410_0.method_15());
						continue;
					}
					if (@class.method_4() && method_80(@class, gclass410_0, gClass))
					{
						break;
					}
				}
				if (gclass410_0.method_6() != RTFTokenType.GroupEnd)
				{
					if (gclass410_0.method_15() < num2)
					{
						break;
					}
					if (gclass410_0.method_6() == RTFTokenType.GroupStart)
					{
						method_82(gclass410_0, gClass);
						if (gclass410_0.method_15() < num2)
						{
							break;
						}
					}
					if (gclass410_0.method_6() != RTFTokenType.Control && gclass410_0.method_6() != RTFTokenType.Keyword && gclass410_0.method_6() != RTFTokenType.ExtKeyword)
					{
						continue;
					}
					switch (gclass410_0.method_7())
					{
					case "listoverride":
						method_83(gclass410_0);
						break;
					case "ansicpg":
						encoding_0 = Encoding.GetEncoding(gclass410_0.method_9());
						break;
					case "deflangfe":
						cultureInfo_0 = method_81(gclass410_0.method_9());
						break;
					case "lang":
						cultureInfo_1 = method_81(gclass410_0.method_9());
						break;
					case "langfe":
						cultureInfo_1 = method_81(gclass410_0.method_9());
						break;
					case "fonttbl":
						method_89(gclass410_0);
						break;
					case "listoverridetable":
						method_84(gclass410_0);
						break;
					case "filetbl":
						method_83(gclass410_0);
						break;
					case "stylesheet":
						method_92(gclass410_0);
						break;
					case "generator":
						method_35(method_98(gclass410_0, bool_5: true));
						break;
					case "titlepg":
						method_18(bool_5: true);
						break;
					case "headery":
						if (gclass410_0.method_8())
						{
							method_51(gclass410_0.method_9());
						}
						break;
					case "footery":
						if (gclass410_0.method_8())
						{
							method_53(gclass410_0.method_9());
						}
						break;
					case "header":
					{
						GClass397 gClass13 = new GClass397();
						gClass13.method_18(GEnum85.const_0);
						method_8(gClass13);
						method_82(gclass410_0, gclass425_1);
						gClass13.method_4();
						gClass13.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "headerl":
					{
						GClass397 gClass13 = new GClass397();
						gClass13.method_18(GEnum85.const_1);
						method_8(gClass13);
						method_82(gclass410_0, gclass425_1);
						gClass13.method_4();
						gClass13.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "headerr":
					{
						GClass397 gClass13 = new GClass397();
						gClass13.method_18(GEnum85.const_2);
						method_8(gClass13);
						method_82(gclass410_0, gclass425_1);
						gClass13.method_4();
						gClass13.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "headerf":
					{
						GClass397 gClass13 = new GClass397();
						gClass13.method_18(GEnum85.const_3);
						method_8(gClass13);
						method_82(gclass410_0, gclass425_1);
						gClass13.method_4();
						gClass13.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "footer":
					{
						GClass398 gClass12 = new GClass398();
						gClass12.method_18(GEnum85.const_3);
						method_8(gClass12);
						method_82(gclass410_0, gclass425_1);
						gClass12.method_4();
						gClass12.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "footerl":
					{
						GClass398 gClass12 = new GClass398();
						gClass12.method_18(GEnum85.const_1);
						method_8(gClass12);
						method_82(gclass410_0, gclass425_1);
						gClass12.method_4();
						gClass12.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "footerr":
					{
						GClass398 gClass12 = new GClass398();
						gClass12.method_18(GEnum85.const_2);
						method_8(gClass12);
						method_82(gclass410_0, gclass425_1);
						gClass12.method_4();
						gClass12.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "footerf":
					{
						GClass398 gClass12 = new GClass398();
						gClass12.method_18(GEnum85.const_3);
						method_8(gClass12);
						method_82(gclass410_0, gclass425_1);
						gClass12.method_4();
						gClass12.method_13(bool_1: true);
						gclass425_0 = new GClass425();
						break;
					}
					case "xmlns":
						method_83(gclass410_0);
						break;
					case "nonesttables":
						method_83(gclass410_0);
						break;
					case "paperw":
						int_1 = gclass410_0.method_9();
						break;
					case "paperh":
						int_2 = gclass410_0.method_9();
						break;
					case "margl":
						int_3 = gclass410_0.method_9();
						break;
					case "margr":
						int_5 = gclass410_0.method_9();
						break;
					case "margb":
						int_6 = gclass410_0.method_9();
						break;
					case "margt":
						int_4 = gclass410_0.method_9();
						break;
					case "landscape":
						bool_2 = true;
						break;
					case "fchars":
						method_20(method_98(gclass410_0, bool_5: true));
						break;
					case "lchars":
						method_22(method_98(gclass410_0, bool_5: true));
						break;
					case "pnseclvl":
						method_83(gclass410_0);
						break;
					case "pard":
						bool_4 = true;
						if (!flag)
						{
							gclass425_0.method_80();
						}
						break;
					case "par":
						bool_4 = true;
						if (method_68(typeof(GClass388)) == null)
						{
							GClass388 gClass9 = new GClass388();
							gClass9.method_18(bool_3: true);
							gClass9.method_22(gclass425_0);
							gclass425_0 = gclass425_0.method_78();
							method_72(gClass9);
							gClass9.method_13(bool_1: true);
						}
						else
						{
							method_71();
							GClass388 gClass9 = new GClass388();
							gClass9.method_18(bool_3: true);
							gClass9.method_22(gclass425_0);
							method_72(gClass9);
						}
						bool_4 = true;
						break;
					case "page":
						bool_4 = true;
						method_71();
						method_72(new GClass385());
						break;
					case "pagebb":
						bool_4 = true;
						gclass425_0.method_42(bool_17: true);
						break;
					case "s":
						bool_4 = true;
						gclass425_0.method_74(gclass410_0.method_9());
						break;
					case "ql":
						bool_4 = true;
						gclass425_0.method_40(GEnum80.const_0);
						break;
					case "qc":
						bool_4 = true;
						gclass425_0.method_40(GEnum80.const_1);
						break;
					case "qr":
						bool_4 = true;
						gclass425_0.method_40(GEnum80.const_2);
						break;
					case "qj":
						bool_4 = true;
						gclass425_0.method_40(GEnum80.const_3);
						break;
					case "sl":
						bool_4 = true;
						if (gclass410_0.method_9() >= 0)
						{
							gclass425_0.method_32(gclass410_0.method_9());
						}
						break;
					case "slmult":
						bool_4 = true;
						gclass425_0.method_34(gclass410_0.method_9() == 1);
						break;
					case "sb":
						bool_4 = true;
						gclass425_0.method_36(gclass410_0.method_9());
						break;
					case "sa":
						bool_4 = true;
						gclass425_0.method_38(gclass410_0.method_9());
						break;
					case "fi":
						bool_4 = true;
						gclass425_0.method_26(gclass410_0.method_9());
						break;
					case "brdrw":
						bool_4 = true;
						if (gclass410_0.method_8())
						{
							gclass425_0.method_14(gclass410_0.method_9());
						}
						break;
					case "pn":
						bool_4 = true;
						gclass425_0.method_72(-1);
						break;
					case "pnlvlbody":
						bool_4 = true;
						break;
					case "pnlvlblt":
						bool_4 = true;
						break;
					case "listtext":
					{
						bool_4 = true;
						string text = method_98(gclass410_0, bool_5: true);
						if (text != null)
						{
							text = text.Trim();
							if (text.StartsWith("l"))
							{
								int_9 = 1;
							}
							else
							{
								int_9 = 2;
							}
						}
						break;
					}
					case "ls":
						bool_4 = true;
						gclass425_0.method_72(gclass410_0.method_9());
						int_9 = 0;
						break;
					case "li":
						bool_4 = true;
						if (gclass410_0.method_8())
						{
							gclass425_0.method_28(gclass410_0.method_9());
						}
						break;
					case "outlinelevel":
						bool_4 = true;
						if (gclass410_0.method_8())
						{
							gclass425_0.method_2(gclass410_0.method_9());
						}
						break;
					case "line":
						bool_4 = true;
						if (gClass.bool_16)
						{
							GClass392 gClass16 = new GClass392();
							gClass16.int_0 = gclass410_0.method_15();
							method_72(gClass16);
						}
						break;
					case "plain":
						bool_4 = true;
						cultureInfo_1 = null;
						gClass.method_79();
						break;
					case "f":
						bool_4 = true;
						if (gClass.bool_16)
						{
							string text4 = method_24().method_2(gclass410_0.method_9());
							if (text4 != null)
							{
								text4 = text4.Trim();
							}
							if (text4 == null || text4.Length == 0)
							{
								text4 = string_2;
							}
							if (method_55() && text4 == "Times New Roman")
							{
								text4 = string_2;
							}
							gClass.method_46(text4);
						}
						encoding_1 = method_24().method_0(gclass410_0.method_9()).method_6();
						break;
					case "af":
						encoding_2 = method_24().method_0(gclass410_0.method_9()).method_6();
						break;
					case "fs":
						bool_4 = true;
						if (gClass.bool_16 && gclass410_0.method_8())
						{
							gClass.method_48((float)gclass410_0.method_9() / 2f);
						}
						break;
					case "cf":
						bool_4 = true;
						if (gClass.bool_16 && gclass410_0.method_8())
						{
							gClass.method_62(method_26().method_1(gclass410_0.method_9(), Color.Black));
						}
						break;
					case "cb":
					case "chcbpat":
						bool_4 = true;
						if (gClass.bool_16 && gclass410_0.method_8())
						{
							gClass.method_64(method_26().method_1(gclass410_0.method_9(), Color.Empty));
						}
						break;
					case "b":
						bool_4 = true;
						if (gClass.bool_16)
						{
							gClass.method_52(!gclass410_0.method_8() || gclass410_0.method_9() != 0);
						}
						break;
					case "v":
						bool_4 = true;
						if (gClass.bool_16)
						{
							if (gclass410_0.method_8() && gclass410_0.method_9() == 0)
							{
								gClass.method_60(bool_17: false);
							}
							else
							{
								gClass.method_60(bool_17: true);
							}
						}
						break;
					case "highlight":
						bool_4 = true;
						if (gClass.bool_16 && gclass410_0.method_8())
						{
							gClass.method_64(method_26().method_1(gclass410_0.method_9(), Color.Empty));
						}
						break;
					case "i":
						bool_4 = true;
						if (gClass.bool_16)
						{
							gClass.method_54(!gclass410_0.method_8() || gclass410_0.method_9() != 0);
						}
						break;
					case "ul":
						bool_4 = true;
						if (gClass.bool_16)
						{
							gClass.method_56(!gclass410_0.method_8() || gclass410_0.method_9() != 0);
						}
						break;
					case "strike":
						bool_4 = true;
						if (gClass.bool_16)
						{
							gClass.method_58(!gclass410_0.method_8() || gclass410_0.method_9() != 0);
						}
						break;
					case "sub":
						bool_4 = true;
						if (gClass.bool_16)
						{
							gClass.method_70(!gclass410_0.method_8() || gclass410_0.method_9() != 0);
						}
						break;
					case "super":
						bool_4 = true;
						if (gClass.bool_16)
						{
							gClass.method_68(!gclass410_0.method_8() || gclass410_0.method_9() != 0);
						}
						break;
					case "nosupersub":
						bool_4 = true;
						gClass.method_70(bool_17: false);
						gClass.method_68(bool_17: false);
						break;
					case "brdrb":
						bool_4 = true;
						gclass425_0.method_10(bool_17: true);
						break;
					case "brdrl":
						bool_4 = true;
						gclass425_0.method_4(bool_17: true);
						break;
					case "brdrr":
						bool_4 = true;
						gclass425_0.method_8(bool_17: true);
						break;
					case "brdrt":
						bool_4 = true;
						gclass425_0.method_10(bool_17: true);
						break;
					case "brdrcf":
					{
						bool_4 = true;
						GClass383 gClass17 = method_69(typeof(GClass395), bool_5: false);
						if (gClass17 is GClass395)
						{
							GClass395 gClass2 = (GClass395)gClass17;
							GClass423 gClass3 = null;
							if (gClass2.method_17().Count > 0)
							{
								gClass3 = (GClass423)gClass2.method_17()[gClass2.method_17().Count - 1];
								gClass3.method_4(gclass410_0.method_7(), gclass410_0.method_9());
							}
						}
						else
						{
							gclass425_0.method_12(method_26().method_1(gclass410_0.method_9(), Color.Black));
							gClass.method_12(gClass.method_11());
						}
						break;
					}
					case "brdrs":
						bool_4 = true;
						gclass425_0.method_18(bool_17: false);
						gClass.method_18(bool_17: false);
						break;
					case "brdrth":
						bool_4 = true;
						gclass425_0.method_18(bool_17: true);
						gClass.method_18(bool_17: true);
						break;
					case "brdrdot":
						bool_4 = true;
						gclass425_0.method_16(DashStyle.Dot);
						gClass.method_16(DashStyle.Dot);
						break;
					case "brdrdash":
						bool_4 = true;
						gclass425_0.method_16(DashStyle.Dash);
						gClass.method_16(DashStyle.Dash);
						break;
					case "brdrdashd":
						bool_4 = true;
						gclass425_0.method_16(DashStyle.DashDot);
						gClass.method_16(DashStyle.DashDot);
						break;
					case "brdrdashdd":
						bool_4 = true;
						gclass425_0.method_16(DashStyle.DashDotDot);
						gClass.method_16(DashStyle.DashDotDot);
						break;
					case "brdrnil":
						bool_4 = true;
						gclass425_0.method_4(bool_17: false);
						gclass425_0.method_6(bool_17: false);
						gclass425_0.method_8(bool_17: false);
						gclass425_0.method_10(bool_17: false);
						gClass.method_4(bool_17: false);
						gClass.method_6(bool_17: false);
						gClass.method_8(bool_17: false);
						gClass.method_10(bool_17: false);
						break;
					case "brsp":
						bool_4 = true;
						if (gclass410_0.method_8())
						{
							gclass425_0.method_20(gclass410_0.method_9());
						}
						break;
					case "chbrdr":
						bool_4 = true;
						gClass.method_4(bool_17: true);
						gClass.method_6(bool_17: true);
						gClass.method_8(bool_17: true);
						gClass.method_10(bool_17: true);
						break;
					case "bkmkstart":
						bool_4 = true;
						if (gClass.bool_16 && bool_4)
						{
							GClass401 gClass15 = new GClass401();
							gClass15.Name = method_98(gclass410_0, bool_5: true);
							gClass15.method_13(bool_1: true);
							method_72(gClass15);
						}
						break;
					case "bkmkend":
						flag = true;
						gClass.bool_16 = false;
						break;
					case "nonshppict":
						method_83(gclass410_0);
						break;
					case "pict":
					{
						bool_4 = true;
						GClass400 gClass14 = new GClass400();
						gClass14.int_0 = gclass410_0.method_15();
						method_72(gClass14);
						break;
					}
					case "picscalex":
						((GClass400)method_68(typeof(GClass400)))?.method_24(gclass410_0.method_9());
						break;
					case "picscaley":
						((GClass400)method_68(typeof(GClass400)))?.method_26(gclass410_0.method_9());
						break;
					case "picwgoal":
						((GClass400)method_68(typeof(GClass400)))?.method_28(gclass410_0.method_9());
						break;
					case "pichgoal":
						((GClass400)method_68(typeof(GClass400)))?.method_30(gclass410_0.method_9());
						break;
					case "blipuid":
						((GClass400)method_68(typeof(GClass400)))?.method_18(method_98(gclass410_0, bool_5: true));
						break;
					case "emfblip":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_0);
						break;
					case "pngblip":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_1);
						break;
					case "jpegblip":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_2);
						break;
					case "macpict":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_3);
						break;
					case "pmmetafile":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_4);
						break;
					case "wmetafile":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_5);
						break;
					case "dibitmap":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_6);
						break;
					case "wbitmap":
						((GClass400)method_68(typeof(GClass400)))?.method_36(GEnum86.const_7);
						break;
					case "sp":
					{
						int num4 = 0;
						string text2 = null;
						string text3 = null;
						while (gclass410_0.method_22() != null)
						{
							if (gclass410_0.method_6() == RTFTokenType.GroupStart)
							{
								num4++;
							}
							else if (gclass410_0.method_6() == RTFTokenType.GroupEnd)
							{
								num4--;
								if (num4 < 0)
								{
									break;
								}
							}
							else if (gclass410_0.method_7() == "sn")
							{
								text2 = method_98(gclass410_0, bool_5: true);
							}
							else if (gclass410_0.method_7() == "sv")
							{
								text3 = method_98(gclass410_0, bool_5: true);
							}
						}
						GClass396 gClass11 = (GClass396)method_68(typeof(GClass396));
						if (gClass11 != null)
						{
							gClass11.method_29().method_1(text2, text3);
						}
						else
						{
							((GClass384)method_68(typeof(GClass384)))?.method_17().method_1(text2, text3);
						}
						break;
					}
					case "shprslt":
						method_83(gclass410_0);
						break;
					case "shp":
					{
						bool_4 = true;
						GClass396 gClass11 = new GClass396();
						gClass11.int_0 = gclass410_0.method_15();
						method_72(gClass11);
						break;
					}
					case "shpleft":
						((GClass396)method_68(typeof(GClass396)))?.method_18(gclass410_0.method_9());
						break;
					case "shptop":
						((GClass396)method_68(typeof(GClass396)))?.method_20(gclass410_0.method_9());
						break;
					case "shpright":
					{
						GClass396 gClass11 = (GClass396)method_68(typeof(GClass396));
						gClass11?.method_22(gclass410_0.method_9() - gClass11.method_17());
						break;
					}
					case "shpbottom":
					{
						GClass396 gClass11 = (GClass396)method_68(typeof(GClass396));
						gClass11?.method_24(gclass410_0.method_9() - gClass11.method_19());
						break;
					}
					case "shplid":
						((GClass396)method_68(typeof(GClass396)))?.method_28(gclass410_0.method_9());
						break;
					case "shpz":
						((GClass396)method_68(typeof(GClass396)))?.method_26(gclass410_0.method_9());
						break;
					case "shpgrp":
					{
						GClass384 gClass10 = new GClass384();
						gClass10.int_0 = gclass410_0.method_15();
						method_72(gClass10);
						break;
					}
					case "intbl":
					case "trowd":
					case "itap":
					{
						bool_4 = true;
						GClass383[] array = method_67(bool_5: true);
						GClass383 gClass4 = null;
						GClass383 gClass5 = null;
						for (int num3 = array.Length - 1; num3 >= 0; num3--)
						{
							GClass383 gClass6 = array[num3];
							if (!gClass6.method_12())
							{
								if (gClass4 == null && !(gClass6 is GClass388))
								{
									gClass4 = gClass6;
								}
								if (gClass6 is GClass395 || gClass6 is GClass390)
								{
									gClass5 = gClass6;
									break;
								}
							}
						}
						if (gclass410_0.method_7() == "intbl")
						{
							if (gClass5 == null)
							{
								GClass395 gClass2 = new GClass395();
								gClass2.int_0 = gclass410_0.method_15();
								gClass4.method_8(gClass2);
							}
						}
						else if (gclass410_0.method_7() == "trowd")
						{
							GClass395 gClass2 = null;
							if (gClass5 == null)
							{
								gClass2 = new GClass395();
								gClass2.int_0 = gclass410_0.method_15();
								gClass4.method_8(gClass2);
							}
							else
							{
								gClass2 = (gClass5 as GClass395);
								if (gClass2 == null)
								{
									gClass2 = (GClass395)gClass5.method_10();
								}
							}
							gClass2.method_0().Clear();
							gClass2.method_17().Clear();
							gclass425_0.method_80();
						}
						else
						{
							if (!(gclass410_0.method_7() == "itap"))
							{
								break;
							}
							GClass395 gClass2 = null;
							if (gclass410_0.method_9() == 0)
							{
								break;
							}
							if (gClass5 == null)
							{
								gClass2 = new GClass395();
								gClass2.int_0 = gclass410_0.method_15();
								gClass4.method_8(gClass2);
							}
							else
							{
								gClass2 = (gClass5 as GClass395);
								if (gClass2 == null)
								{
									gClass2 = (GClass395)gClass5.method_10();
								}
							}
							if (gclass410_0.method_9() == gClass2.method_21())
							{
								break;
							}
							if (gclass410_0.method_9() > gClass2.method_21())
							{
								GClass395 gClass7 = new GClass395();
								gClass7.method_22(gclass410_0.method_9());
								GClass390 gClass8 = (GClass390)method_69(typeof(GClass390), bool_5: false);
								if (gClass8 == null)
								{
									method_72(gClass7);
								}
								else
								{
									gClass8.method_8(gClass7);
								}
							}
							else if (gclass410_0.method_9() >= gClass2.method_21())
							{
							}
						}
						break;
					}
					case "row":
					{
						bool_4 = true;
						GClass383[] array = method_67(bool_5: true);
						for (int num3 = array.Length - 1; num3 >= 0; num3--)
						{
							array[num3].method_13(bool_1: true);
							if (array[num3] is GClass395)
							{
								break;
							}
						}
						break;
					}
					case "nestrow":
					{
						bool_4 = true;
						GClass383[] array = method_67(bool_5: true);
						for (int num3 = array.Length - 1; num3 >= 0; num3--)
						{
							array[num3].method_13(bool_1: true);
							if (array[num3] is GClass395)
							{
								break;
							}
						}
						break;
					}
					case "trrh":
					case "trautofit":
					case "irowband":
					case "trhdr":
					case "trkeep":
					case "trkeepfollow":
					case "trleft":
					case "trqc":
					case "trql":
					case "trqr":
					case "trcbpat":
					case "trcfpat":
					case "trpat":
					case "trshdng":
					case "trwWidth":
					case "trwWidthA":
					case "irow":
					case "trpaddb":
					case "trpaddl":
					case "trpaddr":
					case "trpaddt":
					case "trpaddfb":
					case "trpaddfl":
					case "trpaddfr":
					case "trpaddft":
					case "lastrow":
						bool_4 = true;
						((GClass395)method_69(typeof(GClass395), bool_5: false))?.method_0().method_4(gclass410_0.method_7(), gclass410_0.method_9());
						break;
					case "clvmgf":
					case "clvmrg":
					case "cellx":
					case "clvertalt":
					case "clvertalc":
					case "clvertalb":
					case "clNoWrap":
					case "clcbpat":
					case "clcfpat":
					case "clpadl":
					case "clpadt":
					case "clpadr":
					case "clpadb":
					case "clbrdrl":
					case "clbrdrt":
					case "clbrdrr":
					case "clbrdrb":
					case "brdrtbl":
					case "brdrnone":
					{
						bool_4 = true;
						GClass395 gClass2 = (GClass395)method_69(typeof(GClass395), bool_5: false);
						GClass423 gClass3 = null;
						if (gClass2.method_17().Count > 0)
						{
							gClass3 = (GClass423)gClass2.method_17()[gClass2.method_17().Count - 1];
							if (gClass3.method_8("cellx"))
							{
								gClass3 = new GClass423();
								gClass2.method_17().Add(gClass3);
							}
						}
						if (gClass3 == null)
						{
							gClass3 = new GClass423();
							gClass2.method_17().Add(gClass3);
						}
						gClass3.method_4(gclass410_0.method_7(), gclass410_0.method_9());
						break;
					}
					case "cell":
					{
						bool_4 = true;
						method_72(null);
						method_71();
						gclass425_0.method_81();
						gClass.method_81();
						GClass383[] array = method_67(bool_5: true);
						for (int num3 = array.Length - 1; num3 >= 0; num3--)
						{
							if (!array[num3].method_12())
							{
								if (array[num3] is GClass386)
								{
									break;
								}
								array[num3].method_13(bool_1: true);
								if (array[num3] is GClass390)
								{
									break;
								}
							}
						}
						break;
					}
					case "nestcell":
					{
						bool_4 = true;
						method_72(null);
						method_71();
						GClass383[] array = method_67(bool_5: false);
						int num3 = array.Length - 1;
						while (num3 >= 0)
						{
							array[num3].method_13(bool_1: true);
							if (!(array[num3] is GClass390))
							{
								num3--;
								continue;
							}
							((GClass390)array[num3]).method_36(gClass);
							break;
						}
						break;
					}
					default:
						if (gclass410_0.method_6() == RTFTokenType.ExtKeyword && gclass410_0.method_13())
						{
							method_83(gclass410_0);
						}
						break;
					case "ansi":
					case "xmlopen":
					case "revtbl":
					case "pntext":
					case "pntxtb":
					case "pntxta":
					case "insrsid":
					case "shppict":
					case "shptxt":
					case "shpinst":
					case "nesttableprops":
						break;
					case "fromhtml":
						method_87(gclass410_0);
						return;
					case "listtable":
						method_88(gclass410_0);
						return;
					case "colortbl":
						method_93(gclass410_0);
						return;
					case "info":
						method_94(gclass410_0);
						return;
					case "field":
						bool_4 = true;
						method_97(gclass410_0, gClass);
						return;
					case "object":
						bool_4 = true;
						method_96(gclass410_0, gClass);
						return;
					}
					continue;
				}
				stack_0.Pop();
				GClass383[] array2 = method_67(bool_5: true);
				for (int num3 = 0; num3 < array2.Length; num3++)
				{
					GClass383 gClass17 = array2[num3];
					if (gClass17.int_0 >= 0 && gClass17.int_0 > gclass410_0.method_15())
					{
						for (int i = num3; i < array2.Length; i++)
						{
							array2[i].method_13(bool_1: true);
						}
						break;
					}
				}
				if (array2.Length > 1 && array2[array2.Length - 1] is GClass388)
				{
				}
				break;
			}
			if (@class.method_4())
			{
				method_80(@class, gclass410_0, gClass);
			}
		}

		private void method_83(GClass410 gclass410_0)
		{
			gclass410_0.method_23();
		}

		private void method_84(GClass410 gclass410_0)
		{
			int num = 4;
			gclass419_0 = new GClass419();
			while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
			{
				if (gclass410_0.method_6() != RTFTokenType.GroupStart)
				{
					continue;
				}
				int num2 = gclass410_0.method_15();
				GClass420 gClass = null;
				while (gclass410_0.method_22() != null && (gclass410_0.method_6() != RTFTokenType.GroupEnd || gclass410_0.method_15() >= num2))
				{
					if (gclass410_0.method_5().method_2() == "listoverride")
					{
						gClass = new GClass420();
						gclass419_0.Add(gClass);
					}
					else if (gClass != null)
					{
						switch (gclass410_0.method_5().method_2())
						{
						case "lfolevel":
							gclass410_0.method_23();
							break;
						case "ls":
							gClass.method_5(gclass410_0.method_5().method_6());
							break;
						case "listoverridecount":
							gClass.method_3(gclass410_0.method_5().method_6());
							break;
						case "listid":
							gClass.method_1(gclass410_0.method_5().method_6());
							break;
						}
					}
				}
			}
		}

		public string method_85()
		{
			return string_4;
		}

		public void method_86(string string_5)
		{
			string_4 = string_5;
		}

		private void method_87(GClass410 gclass410_0)
		{
			int num = 18;
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			while (gclass410_0.method_22() != null)
			{
				if (gclass410_0.method_7() == "htmlrtf")
				{
					flag = ((!gclass410_0.method_8() || gclass410_0.method_9() != 0) ? true : false);
				}
				else if (gclass410_0.method_7() == "htmltag")
				{
					if (gclass410_0.method_0().Peek() == 32)
					{
						gclass410_0.method_0().Read();
					}
					string value = method_99(gclass410_0, null, bool_5: true, bool_6: false, bool_7: true);
					if (!string.IsNullOrEmpty(value))
					{
						stringBuilder.Append(value);
					}
				}
				else if (gclass410_0.method_6() == RTFTokenType.Keyword || gclass410_0.method_6() == RTFTokenType.ExtKeyword)
				{
					if (!flag)
					{
						switch (gclass410_0.method_7())
						{
						case "par":
							stringBuilder.Append(Environment.NewLine);
							break;
						case "line":
							stringBuilder.Append(Environment.NewLine);
							break;
						case "tab":
							stringBuilder.Append("\t");
							break;
						case "lquote":
							stringBuilder.Append("&lsquo;");
							break;
						case "rquote":
							stringBuilder.Append("&rsquo;");
							break;
						case "ldblquote":
							stringBuilder.Append("&ldquo;");
							break;
						case "rdblquote":
							stringBuilder.Append("&rdquo;");
							break;
						case "bullet":
							stringBuilder.Append("&bull;");
							break;
						case "endash":
							stringBuilder.Append("&ndash;");
							break;
						case "emdash":
							stringBuilder.Append("&mdash;");
							break;
						case "~":
							stringBuilder.Append("&nbsp;");
							break;
						case "_":
							stringBuilder.Append("&shy;");
							break;
						}
					}
				}
				else if (gclass410_0.method_6() == RTFTokenType.Text && !flag)
				{
					stringBuilder.Append(gclass410_0.method_7());
				}
			}
			method_86(stringBuilder.ToString());
		}

		private void method_88(GClass410 gclass410_0)
		{
			int num = 13;
			gclass403_0 = new GClass403();
			while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
			{
				if (gclass410_0.method_6() != RTFTokenType.GroupStart)
				{
					continue;
				}
				bool flag = true;
				GClass404 gClass = null;
				GClass405 gClass2 = null;
				int num2 = gclass410_0.method_15();
				while (gclass410_0.method_22() != null)
				{
					if (gclass410_0.method_6() == RTFTokenType.GroupEnd)
					{
						if (gclass410_0.method_15() < num2)
						{
							break;
						}
					}
					else if (gclass410_0.method_6() == RTFTokenType.GroupStart)
					{
					}
					if (flag)
					{
						if (gclass410_0.method_5().method_2() != "list")
						{
							method_83(gclass410_0);
							gclass410_0.method_22();
							break;
						}
						gClass = new GClass404();
						gclass403_0.Add(gClass);
						flag = false;
					}
					switch (gclass410_0.method_5().method_2())
					{
					case "listlevel":
						gClass2 = new GClass405();
						gClass.method_12().Add(gClass2);
						break;
					case "listtemplateid":
						gClass.method_3(gclass410_0.method_5().method_6());
						break;
					case "listid":
						gClass.method_1(gclass410_0.method_5().method_6());
						break;
					case "listhybrid":
						gClass.method_7(bool_2: true);
						break;
					case "levelfollow":
						gClass2.method_7(gclass410_0.method_5().method_6());
						break;
					case "levelstartat":
						gClass2.method_1(gclass410_0.method_5().method_6());
						break;
					case "levelnfc":
						if (gClass2.method_2() == LevelNumberType.None)
						{
							gClass2.method_3((LevelNumberType)gclass410_0.method_5().method_6());
						}
						break;
					case "levelnfcn":
						if (gClass2.method_2() == LevelNumberType.None)
						{
							gClass2.method_3((LevelNumberType)gclass410_0.method_5().method_6());
						}
						break;
					case "leveljc":
						gClass2.method_5(gclass410_0.method_5().method_6());
						break;
					case "leveltext":
						if (string.IsNullOrEmpty(gClass2.method_10()))
						{
							string text = method_98(gclass410_0, bool_5: true);
							if (text != null && text.Length > 2)
							{
								int val = text[0];
								val = Math.Min(val, text.Length - 1);
								text = text.Substring(1, val);
							}
							gClass2.method_11(text);
						}
						break;
					case "levelnumbers":
						if (string.IsNullOrEmpty(gClass2.method_12()))
						{
							string text = method_98(gclass410_0, bool_5: true);
							gClass2.method_13(text);
						}
						break;
					case "f":
						gClass2.method_9(method_24().method_2(gclass410_0.method_5().method_6()));
						break;
					}
				}
			}
		}

		private void method_89(GClass410 gclass410_0)
		{
			int num = 4;
			gclass430_0.Clear();
			while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
			{
				if (gclass410_0.method_6() != RTFTokenType.GroupStart)
				{
					continue;
				}
				int num2 = -1;
				string text = null;
				int num3 = 1;
				bool flag = false;
				while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
				{
					if (gclass410_0.method_6() == RTFTokenType.GroupStart)
					{
						gclass410_0.method_22();
						method_83(gclass410_0);
						gclass410_0.method_22();
					}
					else if (gclass410_0.method_7() == "f" && gclass410_0.method_8())
					{
						num2 = gclass410_0.method_9();
					}
					else if (gclass410_0.method_7() == "fnil")
					{
						text = Control.DefaultFont.Name;
						flag = true;
					}
					else if (gclass410_0.method_7() == "fcharset")
					{
						num3 = gclass410_0.method_9();
					}
					else
					{
						if (!gclass410_0.method_5().method_10())
						{
							continue;
						}
						text = method_99(gclass410_0, gclass410_0.method_5(), bool_5: false, bool_6: false, bool_7: false);
						if (text != null)
						{
							text = text.Trim();
							if (text.EndsWith(";"))
							{
								text = text.Substring(0, text.Length - 1);
							}
						}
					}
				}
				if (num2 >= 0 && text != null)
				{
					if (text.EndsWith(";"))
					{
						text = text.Substring(0, text.Length - 1);
					}
					text = text.Trim();
					if (string.IsNullOrEmpty(text))
					{
						text = Control.DefaultFont.Name;
					}
					GClass431 gClass = new GClass431(num2, text);
					gClass.method_5(num3);
					gClass.method_3(flag);
					gclass430_0.method_6(gClass);
				}
			}
		}

		public Dictionary<int, Dictionary<string, string>> method_90()
		{
			return dictionary_0;
		}

		public void method_91(Dictionary<int, Dictionary<string, string>> dictionary_1)
		{
			dictionary_0 = dictionary_1;
		}

		private void method_92(GClass410 gclass410_0)
		{
			int num = 6;
			dictionary_0 = new Dictionary<int, Dictionary<string, string>>();
			while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
			{
				if (gclass410_0.method_6() != RTFTokenType.GroupStart)
				{
					continue;
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				string text = null;
				int key = 0;
				while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
				{
					if (gclass410_0.method_6() == RTFTokenType.GroupStart)
					{
						gclass410_0.method_22();
						method_83(gclass410_0);
						gclass410_0.method_22();
					}
					else if (gclass410_0.method_6() == RTFTokenType.Keyword || gclass410_0.method_6() == RTFTokenType.ExtKeyword)
					{
						if (gclass410_0.method_7() == "s")
						{
							key = gclass410_0.method_9();
						}
						else if (gclass410_0.method_8())
						{
							dictionary[gclass410_0.method_7()] = gclass410_0.method_9().ToString();
						}
						else
						{
							dictionary[gclass410_0.method_7()] = null;
						}
					}
					else
					{
						if (!gclass410_0.method_5().method_10())
						{
							continue;
						}
						text = method_99(gclass410_0, gclass410_0.method_5(), bool_5: false, bool_6: false, bool_7: false);
						if (text != null)
						{
							text = text.Trim();
							if (text.EndsWith(";"))
							{
								text = text.Substring(0, text.Length - 1);
							}
						}
						dictionary["name"] = text;
					}
				}
				if (dictionary.Count > 0)
				{
					dictionary_0[key] = dictionary;
				}
			}
		}

		private void method_93(GClass410 gclass410_0)
		{
			int num = 19;
			gclass418_0.method_8();
			gclass418_0.method_3(bool_1: false);
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
			{
				switch (gclass410_0.method_7())
				{
				case ";":
					if (num2 >= 0 && num3 >= 0 && num4 >= 0)
					{
						Color color_ = Color.FromArgb(255, num2, num3, num4);
						gclass418_0.method_4(color_);
						num2 = -1;
						num3 = -1;
						num4 = -1;
					}
					break;
				case "blue":
					num4 = gclass410_0.method_9();
					break;
				case "green":
					num3 = gclass410_0.method_9();
					break;
				case "red":
					num2 = gclass410_0.method_9();
					break;
				}
			}
			if (num2 >= 0 && num3 >= 0 && num4 >= 0)
			{
				Color color_ = Color.FromArgb(255, num2, num3, num4);
				gclass418_0.method_4(color_);
			}
		}

		private void method_94(GClass410 gclass410_0)
		{
			int num = 19;
			gclass424_0.method_47();
			int num2 = 0;
			while (gclass410_0.method_22() != null)
			{
				if (gclass410_0.method_6() == RTFTokenType.GroupStart)
				{
					num2++;
					continue;
				}
				if (gclass410_0.method_6() == RTFTokenType.GroupEnd)
				{
					num2--;
					if (num2 >= 0)
					{
						continue;
					}
					break;
				}
				switch (gclass410_0.method_7())
				{
				case "buptim":
					gclass424_0.method_45(method_95(gclass410_0));
					num2--;
					continue;
				case "printim":
					gclass424_0.method_43(method_95(gclass410_0));
					num2--;
					continue;
				case "revtim":
					gclass424_0.method_41(method_95(gclass410_0));
					num2--;
					continue;
				case "creatim":
					gclass424_0.method_39(method_95(gclass410_0));
					num2--;
					continue;
				}
				if (gclass410_0.method_7() != null)
				{
					if (gclass410_0.method_8())
					{
						gclass424_0.method_1(gclass410_0.method_7(), gclass410_0.method_9().ToString());
					}
					else
					{
						gclass424_0.method_1(gclass410_0.method_7(), method_98(gclass410_0, bool_5: true));
					}
				}
			}
		}

		private DateTime method_95(GClass410 gclass410_0)
		{
			int num = 15;
			int year = 1900;
			int month = 1;
			int day = 1;
			int hour = 0;
			int minute = 0;
			int second = 0;
			while (gclass410_0.method_22() != null && gclass410_0.method_6() != RTFTokenType.GroupEnd)
			{
				switch (gclass410_0.method_7())
				{
				case "sec":
					second = gclass410_0.method_9();
					break;
				case "min":
					minute = gclass410_0.method_9();
					break;
				case "hr":
					hour = gclass410_0.method_9();
					break;
				case "dy":
					day = gclass410_0.method_9();
					break;
				case "mo":
					month = gclass410_0.method_9();
					break;
				case "yr":
					year = gclass410_0.method_9();
					break;
				}
			}
			return new DateTime(year, month, day, hour, minute, second);
		}

		private GClass389 method_96(GClass410 gclass410_0, GClass425 gclass425_1)
		{
			int num = 12;
			GClass389 gClass = new GClass389();
			gClass.int_0 = gclass410_0.method_15();
			method_72(gClass);
			int num2 = gclass410_0.method_15();
			while (gclass410_0.method_22() != null && gclass410_0.method_15() >= num2)
			{
				if (gclass410_0.method_6() != RTFTokenType.GroupStart && gclass410_0.method_6() != RTFTokenType.GroupEnd)
				{
					if (gclass410_0.method_15() == gClass.int_0 + 1 && gclass410_0.method_7().StartsWith("attribute_"))
					{
						gClass.method_17()[gclass410_0.method_7()] = method_98(gclass410_0, bool_5: true);
					}
					switch (gclass410_0.method_7())
					{
					case "objautlink":
						gClass.method_20(GEnum81.const_2);
						break;
					case "objclass":
						gClass.method_22(method_98(gclass410_0, bool_5: true));
						break;
					case "objdata":
					{
						string string_ = method_98(gclass410_0, bool_5: true);
						gClass.method_24(method_73(string_));
						break;
					}
					case "objemb":
						gClass.method_20(GEnum81.const_0);
						break;
					case "objh":
						gClass.method_29(gclass410_0.method_9());
						break;
					case "objhtml":
						gClass.method_20(GEnum81.const_6);
						break;
					case "objicemb":
						gClass.method_20(GEnum81.const_5);
						break;
					case "objlink":
						gClass.method_20(GEnum81.const_1);
						break;
					case "objname":
						gClass.Name = method_98(gclass410_0, bool_5: true);
						break;
					case "objocx":
						gClass.method_20(GEnum81.const_7);
						break;
					case "objpub":
						gClass.method_20(GEnum81.const_4);
						break;
					case "objsub":
						gClass.method_20(GEnum81.const_3);
						break;
					case "objw":
						gClass.method_27(gclass410_0.method_9());
						break;
					case "objscalex":
						gClass.method_31(gclass410_0.method_9());
						break;
					case "objscaley":
						gClass.method_33(gclass410_0.method_9());
						break;
					case "result":
					{
						GClass399 gClass2 = new GClass399();
						gClass2.Name = "result";
						gClass.method_8(gClass2);
						method_82(gclass410_0, gclass425_1);
						gClass2.method_13(bool_1: true);
						break;
					}
					}
				}
			}
			gClass.method_13(bool_1: true);
			return gClass;
		}

		private GClass394 method_97(GClass410 gclass410_0, GClass425 gclass425_1)
		{
			int num = 4;
			GClass394 gClass = new GClass394();
			gClass.int_0 = gclass410_0.method_15();
			method_72(gClass);
			int num2 = gclass410_0.method_15();
			while (gclass410_0.method_22() != null && gclass410_0.method_15() >= num2)
			{
				if (gclass410_0.method_6() == RTFTokenType.GroupStart || gclass410_0.method_6() == RTFTokenType.GroupEnd)
				{
					continue;
				}
				switch (gclass410_0.method_7())
				{
				case "fldinst":
				{
					GClass399 gClass3 = new GClass399();
					gClass3.Name = "fldinst";
					gClass.method_8(gClass3);
					method_82(gclass410_0, gclass425_1);
					gClass3.method_13(bool_1: true);
					string text = gClass3.vmethod_0();
					if (text == null)
					{
						break;
					}
					int num3 = text.IndexOf("HYPERLINK");
					if (num3 < 0)
					{
						break;
					}
					string text2 = null;
					int num4 = text.IndexOf('"', num3);
					if (num4 <= 0 || text.Length <= num4 + 2)
					{
						break;
					}
					int num5 = text.IndexOf('"', num4 + 2);
					if (num5 <= num4)
					{
						break;
					}
					text2 = text.Substring(num4 + 1, num5 - num4 - 1);
					if (gclass425_1.method_0() != null)
					{
						if (text2.StartsWith("_Toc"))
						{
							text2 = "#" + text2;
						}
						gclass425_1.method_0().method_66(text2);
					}
					break;
				}
				case "fldrslt":
				{
					GClass399 gClass2 = new GClass399();
					gClass2.Name = "fldrslt";
					gClass.method_8(gClass2);
					method_82(gclass410_0, gclass425_1);
					gClass2.method_13(bool_1: true);
					break;
				}
				case "fldpriv":
					gClass.method_18(GEnum84.const_4);
					break;
				case "fldlock":
					gClass.method_18(GEnum84.const_3);
					break;
				case "fldedit":
					gClass.method_18(GEnum84.const_2);
					break;
				case "flddirty":
					gClass.method_18(GEnum84.const_1);
					break;
				}
			}
			gClass.method_13(bool_1: true);
			return gClass;
		}

		private string method_98(GClass410 gclass410_0, bool bool_5)
		{
			return method_99(gclass410_0, null, bool_5, bool_6: false, bool_7: false);
		}

		private string method_99(GClass410 gclass410_0, GClass412 gclass412_0, bool bool_5, bool bool_6, bool bool_7)
		{
			int num = 12;
			int num2 = 0;
			Class201 @class = new Class201(this);
			@class.method_3(gclass412_0, gclass410_0);
			while (true)
			{
				RTFTokenType rTFTokenType = gclass410_0.method_12();
				if (rTFTokenType == RTFTokenType.Eof)
				{
					break;
				}
				if (rTFTokenType == RTFTokenType.GroupStart)
				{
					num2++;
				}
				else if (rTFTokenType == RTFTokenType.GroupEnd)
				{
					num2--;
					if (num2 < 0)
					{
						break;
					}
				}
				gclass410_0.method_22();
				if (bool_5 || num2 == 0)
				{
					if (bool_7 && gclass410_0.method_7() == "par")
					{
						@class.method_2(Environment.NewLine);
					}
					else if (!@class.method_3(gclass410_0.method_5(), gclass410_0) && bool_6)
					{
						break;
					}
				}
			}
			return @class.method_5();
		}

		public override string vmethod_1()
		{
			int num = 19;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(ToString());
			stringBuilder.Append(Environment.NewLine + "   Info");
			string[] array = gclass424_0.method_46();
			foreach (string str in array)
			{
				stringBuilder.Append(Environment.NewLine + "      " + str);
			}
			stringBuilder.Append(Environment.NewLine + "   ColorTable(" + gclass418_0.method_9() + ")");
			for (int j = 0; j < gclass418_0.method_9(); j++)
			{
				Color color = gclass418_0.method_0(j);
				stringBuilder.Append(Environment.NewLine + "      " + j + ":" + color.R + " " + color.G + " " + color.B);
			}
			stringBuilder.Append(Environment.NewLine + "   FontTable(" + gclass430_0.Count + ")");
			foreach (GClass431 item in gclass430_0)
			{
				stringBuilder.Append(Environment.NewLine + "      " + item.ToString());
			}
			if (gclass403_0.Count > 0)
			{
				stringBuilder.Append(Environment.NewLine + "   ListTable(" + gclass403_0.Count + ")");
				foreach (GClass404 item2 in gclass403_0)
				{
					stringBuilder.Append(Environment.NewLine + "      " + item2.ToString());
					for (int j = 0; j < item2.method_12().Count; j++)
					{
						GClass405 gClass2 = item2.method_12()[j];
						stringBuilder.Append(Environment.NewLine + "          " + j + " Level:" + gClass2.ToString());
					}
				}
			}
			if (method_30().Count > 0)
			{
				stringBuilder.Append(Environment.NewLine + "   ListOverrideTable(" + method_30().Count + ")");
				foreach (GClass420 item3 in method_30())
				{
					stringBuilder.Append(Environment.NewLine + "      " + item3.ToString());
				}
			}
			if (method_90() != null && method_90().Count > 0)
			{
				stringBuilder.Append(Environment.NewLine + "   StyleSheets(" + method_90().Count + ")");
				foreach (int key in method_90().Keys)
				{
					Dictionary<string, string> dictionary = method_90()[key];
					stringBuilder.Append(Environment.NewLine + "      " + key + "|");
					foreach (string key2 in dictionary.Keys)
					{
						stringBuilder.Append(key2 + "=" + dictionary[key2] + ";");
					}
				}
			}
			stringBuilder.Append(Environment.NewLine + "   -----------------------");
			if (!string.IsNullOrEmpty(method_85()))
			{
				stringBuilder.Append(Environment.NewLine + "   HTMLContent:" + method_85());
				stringBuilder.Append(Environment.NewLine + "   -----------------------");
			}
			method_16(method_5(), stringBuilder, 1);
			return stringBuilder.ToString();
		}
	}
}
