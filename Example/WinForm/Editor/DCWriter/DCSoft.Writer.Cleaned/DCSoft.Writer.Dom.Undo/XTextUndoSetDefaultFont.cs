using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       设置默认字符撤销信息对象
	///       </summary>
	[ComVisible(false)]
	public class XTextUndoSetDefaultFont : XTextUndoBase
	{
		private WriterControl writerControl_0 = null;

		private XFontValue xfontValue_0 = null;

		private Color color_0 = Color.Empty;

		private XFontValue xfontValue_1 = null;

		private Color color_1 = Color.Empty;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="of">旧字体</param>
		/// <param name="oc">旧文本颜色</param>
		/// <param name="nf">新字体</param>
		/// <param name="nc">新文本颜色</param>
		public XTextUndoSetDefaultFont(WriterControl writerControl_1, XFontValue xfontValue_2, Color color_2, XFontValue xfontValue_3, Color color_3)
		{
			writerControl_0 = writerControl_1;
			xfontValue_0 = xfontValue_2;
			color_0 = color_2;
			xfontValue_1 = xfontValue_3;
			color_1 = color_3;
		}

		public override void Undo(GEventArgs3 args)
		{
			writerControl_0.EditorSetDefaultFont(xfontValue_0, color_0, updateUI: true);
		}

		public override void Redo(GEventArgs3 args)
		{
			writerControl_0.EditorSetDefaultFont(xfontValue_1, color_1, updateUI: true);
		}
	}
}
