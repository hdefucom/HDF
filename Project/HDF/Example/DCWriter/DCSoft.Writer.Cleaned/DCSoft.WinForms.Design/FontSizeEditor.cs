using DCSoftDotfuscate;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       编辑字体大小的编辑器
	///       </summary>
	[ComVisible(false)]
	public class FontSizeEditor : CustomDrawValueListBoxEditor
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		public FontSizeEditor()
		{
			base.Provider = new GClass12();
		}
	}
}
