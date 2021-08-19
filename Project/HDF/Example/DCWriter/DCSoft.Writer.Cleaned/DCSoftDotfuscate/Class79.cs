using Evaluant.Calculator.Test;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class79
	{
		[STAThread]
		private static void smethod_0()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new frmTest());
		}
	}
}
