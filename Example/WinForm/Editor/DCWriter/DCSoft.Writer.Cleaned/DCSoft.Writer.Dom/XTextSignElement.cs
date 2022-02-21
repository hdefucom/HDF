using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       锁定内容的元素
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IXTextSignElement))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890016")]
	[ComVisible(true)]
	[ComClass("00012345-6789-ABCD-EF01-234567890016", "635A3879-B2B2-4299-92B2-523E6790E133")]
	[XmlType("XTextLock")]
	[DocumentComment]
	
	public sealed class XTextSignElement : XTextElement, IXTextSignElement
	{
		internal const string string_3 = "00012345-6789-ABCD-EF01-234567890016";

		internal const string string_4 = "635A3879-B2B2-4299-92B2-523E6790E133";

		private static Bitmap bitmap_0 = null;

		/// <summary>
		///       元素使用的标准图标
		///       </summary>
		public static Bitmap StandardIcon
		{
			get
			{
				if (bitmap_0 == null)
				{
					bitmap_0 = WriterResourcesCore.lockflag;
					bitmap_0.MakeTransparent();
				}
				return bitmap_0;
			}
		}

		public override string DomDisplayName => "Sign" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "sign";

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextSignElement()
		{
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			Size size = GraphicsUnitConvert.Convert(StandardIcon.Size, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
			Width = size.Width;
			Height = size.Height;
			SizeInvalid = false;
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			int num = 6;
			if (args.RenderMode == DocumentRenderMode.Paint)
			{
				RectangleF absBounds = AbsBounds;
				args.Graphics.DrawImage(StandardIcon, absBounds.Left, absBounds.Top);
				args.Graphics.LogContent("Sign");
			}
		}
	}
}
