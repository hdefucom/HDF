using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       椭圆形图形类型
	///       </summary>
	[ToolboxBitmap(typeof(EllipseDocumentImage))]
	[ToolboxItem(true)]
	[DefaultProperty("Text")]
	[ComVisible(false)]
	public class EllipseDocumentImage : ShapeDocumentImageBase
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		public EllipseDocumentImage()
		{
			_ShapeType = GEnum0.const_0;
		}
	}
}
