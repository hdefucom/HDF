using DCSoft.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass449
	{
		private bool bool_0 = true;

		private DragPointPositions dragPointPositions_0 = DragPointPositions.Inner;

		private float float_0 = 8f;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public DragPointPositions method_2()
		{
			return dragPointPositions_0;
		}

		public void method_3(DragPointPositions dragPointPositions_1)
		{
			dragPointPositions_0 = dragPointPositions_1;
		}

		public float method_4()
		{
			return float_0;
		}

		public void method_5(float float_1)
		{
			float_0 = float_1;
		}
	}
}
