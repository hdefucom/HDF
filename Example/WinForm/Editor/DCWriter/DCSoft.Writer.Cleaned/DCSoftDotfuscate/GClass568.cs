using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass568
	{
		public GDelegate26 gdelegate26_0;

		public GDelegate27 gdelegate27_0;

		public GDelegate29 gdelegate29_0;

		public GDelegate30 gdelegate30_0;

		public GDelegate31 gdelegate31_0;

		private GInterface24 ginterface24_0;

		private GInterface24 ginterface24_1;

		private bool bool_0;

		public GClass568(string string_0)
		{
			ginterface24_0 = new GClass544(string_0);
		}

		public GClass568(string string_0, string string_1)
		{
			ginterface24_0 = new GClass544(string_0);
			ginterface24_1 = new GClass544(string_1);
		}

		public GClass568(GInterface24 ginterface24_2)
		{
			ginterface24_0 = ginterface24_2;
		}

		public GClass568(GInterface24 ginterface24_2, GInterface24 ginterface24_3)
		{
			ginterface24_0 = ginterface24_2;
			ginterface24_1 = ginterface24_3;
		}

		private bool method_0(string string_0, Exception exception_0)
		{
			GDelegate30 gDelegate = gdelegate30_0;
			bool result;
			if (result = (gDelegate != null))
			{
				GEventArgs18 gEventArgs = new GEventArgs18(string_0, exception_0);
				gDelegate(this, gEventArgs);
				bool_0 = gEventArgs.method_1();
			}
			return result;
		}

		private bool method_1(string string_0, Exception exception_0)
		{
			GDelegate31 gDelegate = gdelegate31_0;
			bool result;
			if (result = (gDelegate != null))
			{
				GEventArgs18 gEventArgs = new GEventArgs18(string_0, exception_0);
				gdelegate31_0(this, gEventArgs);
				bool_0 = gEventArgs.method_1();
			}
			return result;
		}

		private void method_2(string string_0)
		{
			GDelegate27 gDelegate = gdelegate27_0;
			if (gDelegate != null)
			{
				GEventArgs15 gEventArgs = new GEventArgs15(string_0);
				gDelegate(this, gEventArgs);
				bool_0 = gEventArgs.method_0();
			}
		}

		private void method_3(string string_0)
		{
			GDelegate29 gDelegate = gdelegate29_0;
			if (gDelegate != null)
			{
				GEventArgs15 gEventArgs = new GEventArgs15(string_0);
				gDelegate(this, gEventArgs);
				bool_0 = gEventArgs.method_0();
			}
		}

		private void method_4(string string_0, bool bool_1)
		{
			GDelegate26 gDelegate = gdelegate26_0;
			if (gDelegate != null)
			{
				GEventArgs16 gEventArgs = new GEventArgs16(string_0, bool_1);
				gDelegate(this, gEventArgs);
				bool_0 = gEventArgs.method_0();
			}
		}

		public void method_5(string string_0, bool bool_1)
		{
			bool_0 = true;
			method_6(string_0, bool_1);
		}

		private void method_6(string string_0, bool bool_1)
		{
			try
			{
				string[] files = Directory.GetFiles(string_0);
				bool flag = false;
				for (int i = 0; i < files.Length; i++)
				{
					if (!ginterface24_0.imethod_0(files[i]))
					{
						files[i] = null;
					}
					else
					{
						flag = true;
					}
				}
				method_4(string_0, flag);
				if (bool_0 && flag)
				{
					string[] array = files;
					foreach (string text in array)
					{
						try
						{
							if (text != null)
							{
								method_2(text);
								if (!bool_0)
								{
									goto IL_00b3;
								}
							}
						}
						catch (Exception exception_)
						{
							if (!method_1(text, exception_))
							{
								throw;
							}
						}
					}
				}
			}
			catch (Exception exception_)
			{
				if (!method_0(string_0, exception_))
				{
					throw;
				}
			}
			goto IL_00b3;
			IL_00b3:
			if (bool_0 && bool_1)
			{
				try
				{
					string[] files = Directory.GetDirectories(string_0);
					string[] array = files;
					foreach (string string_ in array)
					{
						if (ginterface24_1 == null || ginterface24_1.imethod_0(string_))
						{
							method_6(string_, bool_1: true);
							if (!bool_0)
							{
								break;
							}
						}
					}
				}
				catch (Exception exception_)
				{
					if (!method_0(string_0, exception_))
					{
						throw;
					}
				}
			}
		}
	}
}
