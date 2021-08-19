using DCSoftDotfuscate;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       编辑线条虚线样式的编辑器
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	public class DashStyleEditor : CustomDrawValueListBoxEditor
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		public DashStyleEditor()
		{
			base.Provider = new GClass11();
		}
	}
}
