using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class EMRTabPage : Panel
	{
		internal EMRTabControl OwnerTabControl = null;

		internal Rectangle TagBounds = Rectangle.Empty;

		private string strCaption = null;

		public string Caption
		{
			get
			{
				return strCaption;
			}
			set
			{
				strCaption = value;
			}
		}

		public override Color BackColor
		{
			get
			{
				if (OwnerTabControl != null)
				{
					return OwnerTabControl.ClientBackColor;
				}
				return Color.White;
			}
			set
			{
			}
		}

		internal void UpdateBackColor()
		{
			if (OwnerTabControl != null)
			{
				base.BackColor = OwnerTabControl.ClientBackColor;
			}
		}
	}
}
