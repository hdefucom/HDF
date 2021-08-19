using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass366 : IEnumerator
	{
		private IEnumerator ienumerator_0;

		public object Current => ienumerator_0.Current;

		public GClass366(IEnumerator ienumerator_1)
		{
			int num = 0;
			ienumerator_0 = null;
			
			if (ienumerator_1 == null)
			{
				throw new ArgumentNullException("baseEnum");
			}
			ienumerator_0 = ienumerator_1;
		}

		public bool MoveNext()
		{
			return ienumerator_0.MoveNext();
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}
	}
}
