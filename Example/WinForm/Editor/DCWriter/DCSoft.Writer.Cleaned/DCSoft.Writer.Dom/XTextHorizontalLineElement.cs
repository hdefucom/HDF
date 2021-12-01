using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       水平线文档元素对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IXTextHorizontalLineElement))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-234567890057", "9AA99A18-54AF-4077-B44A-23CC42EEAE04")]
	[DebuggerDisplay("HorizontalLine")]
	[ToolboxBitmap(typeof(XTextHorizontalLineElement))]
	[XmlType("HorizontalLine")]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890057")]
	public class XTextHorizontalLineElement : XTextObjectElement, IXTextHorizontalLineElement
	{
		internal const string string_9 = "00012345-6789-ABCD-EF01-234567890057";

		internal const string string_10 = "9AA99A18-54AF-4077-B44A-23CC42EEAE04";

		private float float_8 = 0f;

		private float float_9 = 1f;

		public override string DomDisplayName => "HR:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "hr";

		/// <summary>
		///       以厘米单位计算的线条长度，如果为0则填充整页宽度.
		///       </summary>
		[XmlElement]
		[HtmlAttribute]
		[DefaultValue(0f)]
		[DCPublishAPI]
		public float LineLengthInCM
		{
			get
			{
				return float_8;
			}
			set
			{
				float_8 = value;
			}
		}

		/// <summary>
		///       线条高度
		///       </summary>
		[DefaultValue(1f)]
		[DCPublishAPI]
		[HtmlAttribute]
		public float LineSize
		{
			get
			{
				return float_9;
			}
			set
			{
				float_9 = value;
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[DCPublishAPI]
		[XmlElement]
		[DefaultValue(20f)]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       对象宽度是固定的
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override ResizeableType Resizeable
		{
			get
			{
				return ResizeableType.Height;
			}
			set
			{
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextHorizontalLineElement()
		{
			Height = 20f;
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			SizeInvalid = false;
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			int num = 13;
			if (!XTextDocument.smethod_13(GEnum6.const_204))
			{
				return;
			}
			RectangleF clientViewBounds = args.ClientViewBounds;
			if (LineLengthInCM > 0f)
			{
				float num2 = GraphicsUnitConvert.ConvertFromCM(LineLengthInCM, OwnerDocument.DocumentGraphicsUnit);
				if (num2 < clientViewBounds.Width)
				{
					clientViewBounds.X += (clientViewBounds.Width - num2) / 2f;
					clientViewBounds.Width = num2;
				}
			}
			float num3 = Math.Min(LineSize, clientViewBounds.Height);
			clientViewBounds.Y += (clientViewBounds.Height - num3) / 2f;
			clientViewBounds.Height = num3;
			if (args.Graphics != null)
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				if (num3 == 1f)
				{
					args.Graphics.DrawLine(method_4(runtimeStyle.Color), clientViewBounds.Left, clientViewBounds.Top, clientViewBounds.Right, clientViewBounds.Top);
				}
				else
				{
					args.Graphics.FillRectangle(method_4(runtimeStyle.Color), clientViewBounds);
				}
				args.Graphics.LogContent("-");
			}
			SizeInvalid = false;
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			using (Image image = base.CreateContentImage())
			{
				gclass103_0.method_45(image, image.Width, image.Height, null, RuntimeStyle);
			}
		}
	}
}
