using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass113 : GInterface1
	{
		protected List<GInterface1> list_0 = new List<GInterface1>();

		private bool bool_0 = false;

		public bool InGroup
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public virtual void vmethod_0(GInterface1 ginterface1_0)
		{
			ginterface1_0.InGroup = true;
			list_0.Add(ginterface1_0);
		}

		public virtual void Undo(GEventArgs3 args)
		{
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				GInterface1 gInterface = list_0[num];
				gInterface.InGroup = true;
				gInterface.Undo(args);
			}
		}

		public virtual void Redo(GEventArgs3 args)
		{
			foreach (GInterface1 item in list_0)
			{
				item.InGroup = true;
				item.Redo(args);
			}
		}
	}
}
