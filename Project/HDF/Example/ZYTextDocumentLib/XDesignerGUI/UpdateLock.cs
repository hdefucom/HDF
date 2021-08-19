using System;
using System.Windows.Forms;

namespace XDesignerGUI
{
	public class UpdateLock
	{
		private Control myBindControl = null;

		private int intUpdateLevel = 0;

		private object objTag = null;

		public Control BindControl
		{
			get
			{
				return myBindControl;
			}
			set
			{
				myBindControl = value;
			}
		}

		public bool Updating => intUpdateLevel > 0;

		public object Tag
		{
			get
			{
				return objTag;
			}
			set
			{
				objTag = value;
			}
		}

		public event EventHandler Update = null;

		public void BeginUpdate()
		{
			intUpdateLevel++;
		}

		public void EndUpdate()
		{
			intUpdateLevel--;
			if (intUpdateLevel < 0)
			{
				intUpdateLevel = 0;
			}
			if (intUpdateLevel <= 0)
			{
				if (myBindControl != null)
				{
					myBindControl.Update();
				}
				if (this.Update != null)
				{
					this.Update(this, null);
				}
			}
		}

		public bool CanUpdate()
		{
			return intUpdateLevel <= 0;
		}
	}
}
