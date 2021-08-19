using System;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public delegate object CreateCollectionItemInstanceHandler(object Sender, EventArgs args);
}
