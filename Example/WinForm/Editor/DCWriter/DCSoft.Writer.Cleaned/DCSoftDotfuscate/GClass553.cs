using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass553
	{
		[ComVisible(false)]
		public enum GEnum97
		{
			const_0,
			const_1,
			const_2
		}

		[ComVisible(false)]
		public delegate bool GDelegate25(string string_0);

		private bool bool_0;

		private byte[] byte_0;

		private GStream6 gstream6_0;

		private GClass571 gclass571_0;

		private string string_0;

		private GClass581 gclass581_0;

		private GClass581 gclass581_1;

		private GEnum97 genum97_0;

		private GDelegate25 gdelegate25_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private GClass552 gclass552_0;

		private GInterface27 ginterface27_0 = new GClass578();

		private GInterface26 ginterface26_0;

		private GEnum93 genum93_0 = GEnum93.const_2;

		private string string_1;

		public GClass553()
		{
		}

		public GClass553(GClass552 gclass552_1)
		{
			gclass552_0 = gclass552_1;
		}

		public bool method_0()
		{
			return bool_3;
		}

		public void method_1(bool bool_4)
		{
			bool_3 = bool_4;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_2)
		{
			string_1 = string_2;
		}

		public GInterface26 method_4()
		{
			return ginterface27_0.imethod_4();
		}

		public void method_5(GInterface26 ginterface26_1)
		{
			ginterface27_0.imethod_5(ginterface26_1);
		}

		public GInterface27 method_6()
		{
			return ginterface27_0;
		}

		public void method_7(GInterface27 ginterface27_1)
		{
			if (ginterface27_1 == null)
			{
				ginterface27_0 = new GClass578();
			}
			else
			{
				ginterface27_0 = ginterface27_1;
			}
		}

		public GEnum93 method_8()
		{
			return genum93_0;
		}

		public void method_9(GEnum93 genum93_1)
		{
			genum93_0 = genum93_1;
		}

		public bool method_10()
		{
			return bool_1;
		}

		public void method_11(bool bool_4)
		{
			bool_1 = bool_4;
		}

		public bool method_12()
		{
			return bool_2;
		}

		public void method_13(bool bool_4)
		{
			bool_2 = bool_4;
		}

		public void method_14(string string_2, string string_3, bool bool_4, string string_4, string string_5)
		{
			method_16(File.Create(string_2), string_3, bool_4, string_4, string_5);
		}

		public void method_15(string string_2, string string_3, bool bool_4, string string_4)
		{
			method_16(File.Create(string_2), string_3, bool_4, string_4, null);
		}

		public void method_16(Stream stream_0, string string_2, bool bool_4, string string_3, string string_4)
		{
			method_5(new GClass580(string_2));
			string_0 = string_2;
			using (gstream6_0 = new GStream6(stream_0))
			{
				if (string_1 != null)
				{
					gstream6_0.method_4(string_1);
				}
				gstream6_0.method_15(method_8());
				GClass568 gClass = new GClass568(string_3, string_4);
				gClass.gdelegate27_0 = (GDelegate27)Delegate.Combine(gClass.gdelegate27_0, new GDelegate27(method_21));
				if (method_0())
				{
					gClass.gdelegate26_0 = (GDelegate26)Delegate.Combine(gClass.gdelegate26_0, new GDelegate26(method_20));
				}
				if (gclass552_0 != null)
				{
					if (gclass552_0.gdelegate31_0 != null)
					{
						gClass.gdelegate31_0 = (GDelegate31)Delegate.Combine(gClass.gdelegate31_0, gclass552_0.gdelegate31_0);
					}
					if (gclass552_0.gdelegate30_0 != null)
					{
						gClass.gdelegate30_0 = (GDelegate30)Delegate.Combine(gClass.gdelegate30_0, gclass552_0.gdelegate30_0);
					}
				}
				gClass.method_5(string_2, bool_4);
			}
		}

		public void method_17(string string_2, string string_3, string string_4)
		{
			method_18(string_2, string_3, GEnum97.const_2, null, string_4, null, bool_1);
		}

		public void method_18(string string_2, string string_3, GEnum97 genum97_1, GDelegate25 gdelegate25_1, string string_4, string string_5, bool bool_4)
		{
			Stream stream_ = File.Open(string_2, FileMode.Open, FileAccess.Read, FileShare.Read);
			method_19(stream_, string_3, genum97_1, gdelegate25_1, string_4, string_5, bool_4, bool_5: true);
		}

		public void method_19(Stream stream_0, string string_2, GEnum97 genum97_1, GDelegate25 gdelegate25_1, string string_3, string string_4, bool bool_4, bool bool_5)
		{
			int num = 6;
			if (genum97_1 == GEnum97.const_0 && gdelegate25_1 == null)
			{
				throw new ArgumentNullException("confirmDelegate");
			}
			bool_0 = true;
			genum97_0 = genum97_1;
			gdelegate25_0 = gdelegate25_1;
			ginterface26_0 = new GClass559(string_2);
			gclass581_0 = new GClass581(string_3);
			gclass581_1 = new GClass581(string_4);
			bool_1 = bool_4;
			using (gclass571_0 = new GClass571(stream_0))
			{
				if (string_1 != null)
				{
					gclass571_0.method_3(string_1);
				}
				gclass571_0.method_7(bool_5);
				IEnumerator enumerator = gclass571_0.GetEnumerator();
				while (bool_0 && enumerator.MoveNext())
				{
					GClass577 gClass = (GClass577)enumerator.Current;
					if (gClass.method_51())
					{
						if (gclass581_1.imethod_0(Path.GetDirectoryName(gClass.Name)) && gclass581_0.imethod_0(gClass.Name))
						{
							method_24(gClass);
						}
					}
					else if (gClass.method_50() && gclass581_1.imethod_0(gClass.Name) && method_0())
					{
						method_24(gClass);
					}
				}
			}
		}

		private void method_20(object sender, GEventArgs16 e)
		{
			if (!e.method_2() && method_0())
			{
				if (gclass552_0 != null)
				{
					gclass552_0.method_4(e.Name, e.method_2());
				}
				if (e.method_0() && e.Name != string_0)
				{
					GClass577 gclass577_ = ginterface27_0.imethod_2(e.Name);
					gstream6_0.method_19(gclass577_);
				}
			}
		}

		private void method_21(object sender, GEventArgs15 e)
		{
			if (gclass552_0 != null && gclass552_0.gdelegate27_0 != null)
			{
				gclass552_0.gdelegate27_0(sender, e);
			}
			if (e.method_0())
			{
				try
				{
					using (FileStream stream_ = File.Open(e.Name, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						GClass577 gclass577_ = ginterface27_0.imethod_0(e.Name);
						gstream6_0.method_19(gclass577_);
						method_22(e.Name, stream_);
					}
				}
				catch (Exception exception_)
				{
					if (gclass552_0 == null)
					{
						bool_0 = false;
						throw;
					}
					bool_0 = gclass552_0.method_1(e.Name, exception_);
				}
			}
		}

		private void method_22(string string_2, Stream stream_0)
		{
			int num = 5;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (byte_0 == null)
			{
				byte_0 = new byte[4096];
			}
			if (gclass552_0 != null && gclass552_0.gdelegate28_0 != null)
			{
				GClass563.smethod_3(stream_0, gstream6_0, byte_0, gclass552_0.gdelegate28_0, gclass552_0.method_5(), this, string_2);
			}
			else
			{
				GClass563.smethod_2(stream_0, gstream6_0, byte_0);
			}
			if (gclass552_0 != null)
			{
				bool_0 = gclass552_0.method_3(string_2);
			}
		}

		private void method_23(GClass577 gclass577_0, string string_2)
		{
			bool flag = true;
			if (genum97_0 != GEnum97.const_2 && File.Exists(string_2))
			{
				flag = (genum97_0 == GEnum97.const_0 && gdelegate25_0 != null && gdelegate25_0(string_2));
			}
			if (flag)
			{
				if (gclass552_0 != null)
				{
					bool_0 = gclass552_0.method_2(gclass577_0.Name);
				}
				if (bool_0)
				{
					try
					{
						using (FileStream stream_ = File.Create(string_2))
						{
							if (byte_0 == null)
							{
								byte_0 = new byte[4096];
							}
							if (gclass552_0 != null && gclass552_0.gdelegate28_0 != null)
							{
								GClass563.smethod_4(gclass571_0.method_16(gclass577_0), stream_, byte_0, gclass552_0.gdelegate28_0, gclass552_0.method_5(), this, gclass577_0.Name, gclass577_0.method_30());
							}
							else
							{
								GClass563.smethod_2(gclass571_0.method_16(gclass577_0), stream_, byte_0);
							}
							if (gclass552_0 != null)
							{
								bool_0 = gclass552_0.method_3(gclass577_0.Name);
							}
						}
						if (bool_1)
						{
							File.SetLastWriteTime(string_2, gclass577_0.method_28());
						}
						if (method_12() && gclass577_0.method_16() && gclass577_0.method_13() != -1)
						{
							FileAttributes fileAttributes = (FileAttributes)gclass577_0.method_13();
							fileAttributes &= (FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive | FileAttributes.Normal);
							File.SetAttributes(string_2, fileAttributes);
						}
					}
					catch (Exception exception_)
					{
						if (gclass552_0 == null)
						{
							bool_0 = false;
							throw;
						}
						bool_0 = gclass552_0.method_1(string_2, exception_);
					}
				}
			}
		}

		private void method_24(GClass577 gclass577_0)
		{
			bool flag = gclass577_0.method_52();
			string text = gclass577_0.Name;
			if (flag)
			{
				if (gclass577_0.method_51())
				{
					text = ginterface26_0.imethod_0(text);
				}
				else if (gclass577_0.method_50())
				{
					text = ginterface26_0.imethod_1(text);
				}
				flag = (text != null && text.Length != 0);
			}
			string path = null;
			if (flag)
			{
				path = ((!gclass577_0.method_50()) ? Path.GetDirectoryName(Path.GetFullPath(text)) : text);
			}
			if (flag && !Directory.Exists(path) && (!gclass577_0.method_50() || method_0()))
			{
				try
				{
					Directory.CreateDirectory(path);
				}
				catch (Exception exception_)
				{
					flag = false;
					if (gclass552_0 == null)
					{
						bool_0 = false;
						throw;
					}
					if (gclass577_0.method_50())
					{
						bool_0 = gclass552_0.method_0(text, exception_);
					}
					else
					{
						bool_0 = gclass552_0.method_1(text, exception_);
					}
				}
			}
			if (flag && gclass577_0.method_51())
			{
				method_23(gclass577_0, text);
			}
		}

		private static int smethod_0(FileInfo fileInfo_0)
		{
			return (int)fileInfo_0.Attributes;
		}

		private static bool smethod_1(string string_2)
		{
			return string_2 != null && string_2.Length > 0 && string_2.IndexOfAny(Path.GetInvalidPathChars()) < 0;
		}
	}
}
