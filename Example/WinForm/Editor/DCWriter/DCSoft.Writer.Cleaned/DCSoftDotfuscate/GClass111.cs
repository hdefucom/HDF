using DCSoft.Common;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DCInternal]
	[ComVisible(false)]
	public class GClass111 : ICloneable
	{
		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private Keys keys_0 = Keys.None;

		public static GClass111 smethod_0()
		{
			GClass111 gClass = new GClass111();
			Keys modifierKeys = Control.ModifierKeys;
			gClass.bool_1 = ((modifierKeys & Keys.Alt) == Keys.Alt);
			gClass.bool_0 = ((modifierKeys & Keys.Control) == Keys.Control);
			gClass.bool_2 = ((modifierKeys & Keys.Shift) == Keys.Shift);
			return gClass;
		}

		public GClass111()
		{
		}

		public GClass111(KeyEventArgs keyEventArgs_0)
		{
			bool_0 = keyEventArgs_0.Control;
			bool_1 = keyEventArgs_0.Alt;
			bool_2 = keyEventArgs_0.Shift;
			keys_0 = keyEventArgs_0.KeyCode;
		}

		public GClass111(Keys keys_1)
		{
			bool_0 = ((keys_1 & Keys.Control) == Keys.Control);
			bool_1 = ((keys_1 & Keys.Alt) == Keys.Alt);
			bool_2 = ((keys_1 & Keys.Shift) == Keys.Shift);
			keys_0 = (keys_1 & Keys.KeyCode);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public bool method_2()
		{
			return bool_1;
		}

		public void method_3(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public bool method_4()
		{
			return bool_2;
		}

		public void method_5(bool bool_3)
		{
			bool_2 = bool_3;
		}

		public Keys method_6()
		{
			return keys_0;
		}

		public void method_7(Keys keys_1)
		{
			keys_0 = keys_1;
		}

		public override string ToString()
		{
			int num = 4;
			StringBuilder stringBuilder = new StringBuilder();
			if (bool_0)
			{
				stringBuilder.Append("Control ");
			}
			if (bool_2)
			{
				stringBuilder.Append("Shift ");
			}
			if (bool_1)
			{
				stringBuilder.Append("Alt ");
			}
			stringBuilder.Append(keys_0.ToString());
			return stringBuilder.ToString();
		}

		object ICloneable.Clone()
		{
			GClass111 gClass = new GClass111();
			gClass.bool_1 = bool_1;
			gClass.bool_0 = bool_0;
			gClass.keys_0 = keys_0;
			gClass.bool_2 = bool_2;
			return gClass;
		}

		public GClass111 method_8()
		{
			return (GClass111)((ICloneable)this).Clone();
		}
	}
}
