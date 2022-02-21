using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public class GClass124
	{
		private delegate void Delegate3(string string_0);

		private static volatile List<GClass124> list_0 = new List<GClass124>();

		private static Thread thread_0 = null;

		private static GClass124 gclass124_0 = null;

		private WriterControl writerControl_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private XTextElement xtextElement_0 = null;

		private GDelegate7 gdelegate7_0 = null;

		private GDelegate7 gdelegate7_1 = null;

		private bool bool_0 = false;

		private object object_0 = null;

		private object object_1 = null;

		private object object_2 = null;

		private GEnum17 genum17_0 = GEnum17.const_2;

		private static void smethod_0(GClass124 gclass124_1)
		{
			lock (list_0)
			{
				list_0.Add(gclass124_1);
			}
			smethod_2();
		}

		private static void smethod_1()
		{
			if (thread_0 != null)
			{
				gclass124_0 = null;
				thread_0.Abort();
				thread_0 = null;
			}
		}

		private static void smethod_2()
		{
			lock (list_0)
			{
				if (list_0.Count > 0)
				{
					if (thread_0 == null)
					{
						ThreadStart start = smethod_4;
						thread_0 = new Thread(start);
						thread_0.IsBackground = true;
					}
					if (!thread_0.IsAlive)
					{
						thread_0.Start();
					}
				}
			}
		}

		private static void smethod_3(GClass124 gclass124_1)
		{
			lock (list_0)
			{
				if (gclass124_0 == gclass124_1)
				{
					if (thread_0 != null)
					{
						thread_0.Abort();
					}
					if (list_0.Count > 0)
					{
						smethod_2();
					}
				}
				else if (list_0.Contains(gclass124_1))
				{
					list_0.Remove(gclass124_1);
				}
			}
		}

		private static void smethod_4()
		{
			try
			{
				while (true)
				{
					gclass124_0 = null;
					GClass124 gClass = null;
					lock (list_0)
					{
						if (list_0.Count > 0)
						{
							gClass = list_0[0];
							list_0.RemoveAt(0);
						}
					}
					if (gClass == null)
					{
						break;
					}
					gclass124_0 = gClass;
					GClass125 gclass125_ = new GClass125(gClass);
					gClass.method_14(bool_1: false);
					if (gClass.method_22() == GEnum17.const_0)
					{
						gClass.vmethod_0(gclass125_);
						gClass.vmethod_1(gclass125_);
					}
					else
					{
						try
						{
							gClass.vmethod_0(gclass125_);
							gClass.vmethod_1(gclass125_);
						}
						catch (Exception ex)
						{
							if (gClass.method_22() == GEnum17.const_2)
							{
								gClass.method_0(ex.Message);
							}
							else if (gClass.method_22() == GEnum17.const_3)
							{
								gClass.method_0(ex.ToString());
							}
						}
					}
				}
			}
			catch (ThreadAbortException)
			{
				if (gclass124_0 != null)
				{
					gclass124_0.method_14(bool_1: true);
				}
			}
			gclass124_0 = null;
			thread_0 = null;
		}

		private void method_0(string string_0)
		{
			if (method_2() != null && method_2().IsHandleCreated)
			{
				method_2().Invoke(new Delegate3(method_1), string_0);
			}
		}

		private void method_1(string string_0)
		{
			if (method_2() != null)
			{
				method_2().UITools.ShowErrorMessageBox(method_2(), string_0);
			}
			else
			{
				MessageBox.Show(null, string_0, WriterStringsCore.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public static void smethod_5()
		{
			lock (typeof(GClass124))
			{
				smethod_1();
				list_0.Clear();
			}
		}

		public static void smethod_6(WriterControl writerControl_1)
		{
			if (writerControl_1 == null)
			{
				smethod_1();
				list_0.Clear();
			}
			else
			{
				lock (list_0)
				{
					if (gclass124_0 != null && gclass124_0.method_2() == writerControl_1)
					{
						gclass124_0 = null;
						smethod_1();
					}
					for (int num = list_0.Count - 1; num >= 0; num--)
					{
						if (list_0[num].method_2() == writerControl_1)
						{
							list_0.RemoveAt(num);
						}
					}
				}
				smethod_2();
			}
		}

		public WriterControl method_2()
		{
			return writerControl_0;
		}

		public void method_3(WriterControl writerControl_1)
		{
			writerControl_0 = writerControl_1;
		}

		public XTextDocument method_4()
		{
			return xtextDocument_0;
		}

		public void method_5(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextElement method_6()
		{
			return xtextElement_0;
		}

		public void method_7(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}

		public virtual void vmethod_0(GClass125 gclass125_0)
		{
			if (gdelegate7_0 != null)
			{
				gdelegate7_0(this, gclass125_0);
			}
		}

		public GDelegate7 method_8()
		{
			return gdelegate7_0;
		}

		public void method_9(GDelegate7 gdelegate7_2)
		{
			gdelegate7_0 = gdelegate7_2;
		}

		public virtual void vmethod_1(GClass125 gclass125_0)
		{
			if (gdelegate7_1 != null)
			{
				if (writerControl_0 != null)
				{
					writerControl_0.BeginInvoke(gdelegate7_1, this, gclass125_0);
				}
				else
				{
					gdelegate7_1(this, gclass125_0);
				}
			}
		}

		public GDelegate7 method_10()
		{
			return gdelegate7_1;
		}

		public void method_11(GDelegate7 gdelegate7_2)
		{
			gdelegate7_1 = gdelegate7_2;
		}

		public void method_12()
		{
			smethod_0(this);
		}

		public bool method_13()
		{
			return bool_0;
		}

		public void method_14(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public void method_15()
		{
			bool_0 = true;
			smethod_3(this);
		}

		public object method_16()
		{
			return object_0;
		}

		public void method_17(object object_3)
		{
			object_0 = object_3;
		}

		public object method_18()
		{
			return object_1;
		}

		public void method_19(object object_3)
		{
			object_1 = object_3;
		}

		public object method_20()
		{
			return object_2;
		}

		public void method_21(object object_3)
		{
			object_2 = object_3;
		}

		public GEnum17 method_22()
		{
			return genum17_0;
		}

		public void method_23(GEnum17 genum17_1)
		{
			genum17_0 = genum17_1;
		}
	}
}
