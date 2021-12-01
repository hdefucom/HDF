using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       分页元素
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlType("XPageBreak")]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IXTextPageBreakElement))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-23456789001D")]
	[ComClass("00012345-6789-ABCD-EF01-23456789001D", "BC40D9FD-B2AD-462C-9C9F-9B8EC5D612CC")]
	[ComVisible(true)]
	[DocumentComment]
	public sealed class XTextPageBreakElement : XTextElement, IXTextPageBreakElement
	{
		internal const string string_3 = "00012345-6789-ABCD-EF01-23456789001D";

		internal const string string_4 = "BC40D9FD-B2AD-462C-9C9F-9B8EC5D612CC";

		private bool bool_5 = false;

		public override string DomDisplayName => "PageBreak";

		/// <summary>
		///       是否处理过了分页
		///       </summary>
		[Browsable(false)]
		internal bool Handled
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextPageBreakElement()
		{
			Height = 50f;
		}

		/// <summary>
		///       绘制分页符内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void Draw(DocumentPaintEventArgs args)
		{
			if (OwnerDocument.Options.ViewOptions.ShowPageBreak && args.RenderMode == DocumentRenderMode.Paint && args.Graphics != null)
			{
				RectangleF viewBounds = args.ViewBounds;
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					SizeF sizeF = args.Graphics.MeasureString(WriterStringsCore.PageBreak, new XFontValue(), 10000, drawStringFormatExt);
					XPenStyle xpenStyle_ = new XPenStyle(Color.Black, 1f, DashStyle.Dot);
					args.Graphics.DrawLine(xpenStyle_, viewBounds.Left, viewBounds.Top + viewBounds.Height / 2f, viewBounds.Left + viewBounds.Width / 2f - sizeF.Width / 2f, viewBounds.Top + viewBounds.Height / 2f);
					args.Graphics.DrawLine(xpenStyle_, viewBounds.Left + viewBounds.Width / 2f + sizeF.Width / 2f, viewBounds.Top + viewBounds.Height / 2f, viewBounds.Right, viewBounds.Top + viewBounds.Height / 2f);
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
					args.Graphics.DrawString(WriterStringsCore.PageBreak, new XFontValue(), Color.Black, viewBounds.Left + viewBounds.Width / 2f - sizeF.Width / 2f, viewBounds.Top + 1f);
				}
			}
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			gclass103_0.method_28("page");
		}
	}
}
