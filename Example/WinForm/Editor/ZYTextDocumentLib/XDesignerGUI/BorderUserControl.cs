using System;
using System.ComponentModel;
using System.Windows.Forms;
using Windows32;

namespace XDesignerGUI
{
	[Browsable(false)]
	public class BorderUserControl : UserControl
	{
		private const int WM_IME_COMPOSITION = 271;

		private int m_hImc = 0;

		public static bool DoubleBuffer = false;

		protected BorderStyle intBorderStyle = BorderStyle.Fixed3D;

		private bool ISIMEINPUT = false;

		private int IMEINPUTCOUNT = 0;

		public new BorderStyle BorderStyle
		{
			get
			{
				return intBorderStyle;
			}
			set
			{
				intBorderStyle = value;
				RecreateHandle();
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				switch (intBorderStyle)
				{
				case BorderStyle.Fixed3D:
					createParams.ExStyle |= 512;
					break;
				case BorderStyle.FixedSingle:
					createParams.ExStyle |= 131072;
					break;
				}
				return createParams;
			}
		}

		public new event EventHandler Scroll = null;

		public BorderUserControl()
		{
			AutoScroll = true;
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			if (DoubleBuffer)
			{
				SetStyle(ControlStyles.UserPaint, value: true);
				SetStyle(ControlStyles.DoubleBuffer, value: true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			}
			if (m_hImc == 0)
			{
				m_hImc = Imm32.ImmGetContext(base.Handle.ToInt32());
			}
		}

		protected virtual void OnScroll()
		{
			if (this.Scroll != null)
			{
				this.Scroll(this, null);
			}
		}

		internal void InnerOnScroll()
		{
			OnScroll();
		}

		public void SetHScroll(bool flag)
		{
			base.HScroll = flag;
		}

		public void SetVScroll(bool flag)
		{
			base.VScroll = flag;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 641:
				Imm32.ImmAssociateContext(base.Handle.ToInt32(), m_hImc);
				base.WndProc(ref m);
				break;
			case 522:
				base.WndProc(ref m);
				OnScroll();
				break;
			case 276:
				base.WndProc(ref m);
				OnScroll();
				break;
			case 277:
				base.WndProc(ref m);
				if (m.HWnd == base.Handle)
				{
					OnScroll();
				}
				break;
			case 646:
				base.WndProc(ref m);
				ISIMEINPUT = true;
				IMEINPUTCOUNT++;
				break;
			case 271:
				base.WndProc(ref m);
				break;
			case 258:
				if (ISIMEINPUT)
				{
					if (IMEINPUTCOUNT == 0)
					{
						ISIMEINPUT = false;
					}
					else
					{
						IMEINPUTCOUNT--;
					}
					if (IMEINPUTCOUNT == 0)
					{
						ISIMEINPUT = false;
					}
				}
				else
				{
					base.WndProc(ref m);
				}
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			base.Name = "BorderUserControl";
			ResumeLayout(false);
		}
	}
}
