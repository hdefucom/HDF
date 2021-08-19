using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       矩形图形对象
	///       </summary>
	[ToolboxBitmap(typeof(RectangleDocumentImage))]
	[ToolboxItem(true)]
	[ComVisible(false)]
	public class RectangleDocumentImage : ShapeDocumentImageBase
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		public RectangleDocumentImage()
		{
			_ShapeType = GEnum0.const_1;
		}
	}
}
