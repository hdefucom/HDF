using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass113 : IXTextUndo
	{
		protected List<IXTextUndo> list_0 = new List<IXTextUndo>();

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

		public virtual void vmethod_0(IXTextUndo ginterface1_0)
		{
			ginterface1_0.InGroup = true;
			list_0.Add(ginterface1_0);
		}

		public virtual void Undo(GEventArgs3 args)
		{
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				IXTextUndo gInterface = list_0[num];
				gInterface.InGroup = true;
				gInterface.Undo(args);
			}
		}

		public virtual void Redo(GEventArgs3 args)
		{
			foreach (IXTextUndo item in list_0)
			{
				item.InGroup = true;
				item.Redo(args);
			}
		}
	}
}
