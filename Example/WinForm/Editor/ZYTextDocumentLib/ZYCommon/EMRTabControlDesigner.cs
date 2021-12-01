using System.Collections;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ZYCommon
{
	public class EMRTabControlDesigner : ParentControlDesigner
	{
		private ISelectionService _selectionService = null;

		public override ICollection AssociatedComponents
		{
			get
			{
				if (base.Control is EMRTabControl)
				{
					return (base.Control as EMRTabControl).TabPages;
				}
				return base.AssociatedComponents;
			}
		}

		public ISelectionService SelectionService
		{
			get
			{
				if (_selectionService == null)
				{
					_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
				}
				return _selectionService;
			}
		}

		protected override bool DrawGrid
		{
			get
			{
				return false;
			}
			set
			{
				base.DrawGrid = value;
			}
		}

		protected override void WndProc(ref Message msg)
		{
			if (msg.Msg == 513)
			{
				EMRTabControl eMRTabControl = SelectionService.PrimarySelection as EMRTabControl;
				if (eMRTabControl != null)
				{
					int num = (short)((int)msg.LParam & 0xFFFF);
					int num2 = (short)((uint)((int)msg.LParam & -65536) >> 16);
					eMRTabControl.InnerTestClick();
				}
			}
			base.WndProc(ref msg);
		}
	}
}
