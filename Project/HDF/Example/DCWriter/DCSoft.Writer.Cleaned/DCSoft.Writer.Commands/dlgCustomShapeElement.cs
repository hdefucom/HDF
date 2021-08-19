using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgCustomShapeElement : Form
	{
		private IContainer icontainer_0 = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCustomShapeElement()
		{
			method_0();
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			icontainer_0 = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
			Text = "dlgCustomShapeElement";
		}
	}
}
