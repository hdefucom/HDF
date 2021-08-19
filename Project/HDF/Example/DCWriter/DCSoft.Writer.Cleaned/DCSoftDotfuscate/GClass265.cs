using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public abstract class GClass265 : IDisposable
	{
		[NonSerialized]
		protected IntPtr intptr_0 = IntPtr.Zero;

		private bool bool_0 = false;

		public IntPtr method_0()
		{
			vmethod_0();
			return intptr_0;
		}

		public bool method_1()
		{
			return bool_0;
		}

		public virtual void Dispose()
		{
			if (intptr_0 != IntPtr.Zero)
			{
				DeleteObject(intptr_0);
				intptr_0 = IntPtr.Zero;
				bool_0 = true;
			}
		}

		protected virtual void vmethod_0()
		{
			int num = 4;
			if (intptr_0 == IntPtr.Zero)
			{
				throw new Exception("句柄无效");
			}
		}

		public IntPtr method_2(IntPtr intptr_1)
		{
			vmethod_0();
			return SelectObject(intptr_1, intptr_0);
		}

		public IntPtr method_3(int int_0)
		{
			vmethod_0();
			return SelectObject(new IntPtr(int_0), intptr_0);
		}

		public bool method_4(IntPtr intptr_1, IntPtr intptr_2)
		{
			vmethod_0();
			IntPtr value = SelectObject(intptr_1, intptr_2);
			return value == intptr_0;
		}

		public bool method_5(int int_0, IntPtr intptr_1)
		{
			vmethod_0();
			IntPtr value = SelectObject(new IntPtr(int_0), intptr_1);
			return value == intptr_0;
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int DeleteObject(IntPtr intptr_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr intptr_1, IntPtr intptr_2);
	}
}
