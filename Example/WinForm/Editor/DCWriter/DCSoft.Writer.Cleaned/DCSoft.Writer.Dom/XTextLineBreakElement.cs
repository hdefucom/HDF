using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       换行元素
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IXTextLineBreakElement))]
	
	[XmlType("XLineBreak")]
	[ComClass("FF08F8F6-2524-455A-9F15-A9DBCF338E1C", "2245E560-B282-4C3C-97B0-D0947F2FAB88")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("FF08F8F6-2524-455A-9F15-A9DBCF338E1C")]
	public sealed class XTextLineBreakElement : XTextElement, IXTextLineBreakElement
	{
		internal const string string_3 = "FF08F8F6-2524-455A-9F15-A9DBCF338E1C";

		internal const string string_4 = "2245E560-B282-4C3C-97B0-D0947F2FAB88";

		private static Bitmap bitmap_0;

		private static Bitmap bitmap_1;

		
		public override string DomDisplayName => "LineBreak";

		static XTextLineBreakElement()
		{
			bitmap_0 = null;
			bitmap_1 = null;
			bitmap_0 = DCStdImageList.Instance.BmpLinebreak;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextLineBreakElement()
		{
		}

		internal void method_13(XTextElement xtextElement_0)
		{
			float val = OwnerDocument.DefaultStyle.DefaultLineHeight;
			if (xtextElement_0 != null && xtextElement_0.Height > 0f)
			{
				val = xtextElement_0.Height;
			}
			val = (Height = Math.Max(val, OwnerDocument.PixelToDocumentUnit(10f)));
			Width = OwnerDocument.PixelToDocumentUnit(10f);
			SizeInvalid = false;
		}

		/// <summary>
		///       返回对象包含的字符串数据
		///       </summary>
		/// <returns>字符串数据</returns>
		
		public override string ToString()
		{
			return Environment.NewLine;
		}

		
		public override void vmethod_19(GClass103 gclass103_0)
		{
			gclass103_0.method_44();
		}

		
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			float num = Height = OwnerDocument.DefaultStyle.DefaultLineHeight;
			Width = OwnerDocument.PixelToDocumentUnit(10f);
			SizeInvalid = false;
		}

		
		public override void Draw(DocumentPaintEventArgs args)
		{
			int num = 11;
			if (bitmap_1 == null)
			{
				bitmap_1 = DCStdImageList.Instance.BmpLinebreak;
			}
			RectangleF absBounds = AbsBounds;
			if (OwnerDocument.Options.ViewOptions.ShowParagraphFlag && args.RenderMode == DocumentRenderMode.Paint)
			{
				Size size = bitmap_1.Size;
				size = OwnerDocument.PixelToDocumentUnit(size);
				InterpolationMode interpolationMode = args.Graphics.InterpolationMode;
				args.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				args.Graphics.DrawImage(bitmap_1, absBounds.Left, absBounds.Bottom - (float)size.Height);
				args.Graphics.InterpolationMode = interpolationMode;
				args.Graphics.LogContent("[LineBreak]");
			}
		}
	}
}
