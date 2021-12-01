using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.TDCode;
using DCSoft.WinForms;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       条形码输入域对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCPublishAPI]
	[DocumentComment]
	[Guid("9314359D-352C-4A83-860B-251C019C08C4")]
	[ComClass("9314359D-352C-4A83-860B-251C019C08C4", "FD042381-D32A-4EFD-9104-95E069725336")]
	[XmlType("XTDBarcodeField")]
	[ComDefaultInterface(typeof(IXTextTDBarcodeElement))]
	[ComVisible(true)]
	[DebuggerDisplay("TDBarcode:{Name}")]
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class XTextTDBarcodeElement : XTextLabelElementBase, IXTextTDBarcodeElement
	{
		internal const string string_10 = "9314359D-352C-4A83-860B-251C019C08C4";

		internal const string string_11 = "FD042381-D32A-4EFD-9104-95E069725336";

		private VerticalAlignStyle verticalAlignStyle_0 = VerticalAlignStyle.Bottom;

		private DCTDBarcodeType dctdbarcodeType_0 = DCTDBarcodeType.QR;

		private DCTBErroeCorrectionLevelType dctberroeCorrectionLevelType_0 = DCTBErroeCorrectionLevelType.M;

		public override string DomDisplayName => "TDBarcode:" + base.ID;

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[HtmlAttribute]
		[ComVisible(true)]
		[DefaultValue(VerticalAlignStyle.Bottom)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public VerticalAlignStyle VAlign
		{
			get
			{
				return verticalAlignStyle_0;
			}
			set
			{
				verticalAlignStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的垂直对齐方式
		///       </summary>
		public override VerticalAlignStyle RuntimeVAlign => VAlign;

		public override bool RuntimeAutoSize => false;

		/// <summary>
		///       对象可自由改变大小
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override ResizeableType Resizeable
		{
			get
			{
				return ResizeableType.WidthAndHeight;
			}
			set
			{
			}
		}

		/// <summary>
		///       条码类型
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(DCTDBarcodeType.QR)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public DCTDBarcodeType BarcodeType
		{
			get
			{
				return dctdbarcodeType_0;
			}
			set
			{
				dctdbarcodeType_0 = value;
			}
		}

		/// <summary>
		///       数据校验等级
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(DCTBErroeCorrectionLevelType.M)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public DCTBErroeCorrectionLevelType ErroeCorrectionLevel
		{
			get
			{
				return dctberroeCorrectionLevelType_0;
			}
			set
			{
				dctberroeCorrectionLevelType_0 = value;
			}
		}

		object IXTextTDBarcodeElement.Tag
		{
			get
			{
				return base.Tag;
			}
			set
			{
				base.Tag = value;
			}
		}

		XDataBinding IXTextTDBarcodeElement.ValueBinding
		{
			get
			{
				return base.ValueBinding;
			}
			set
			{
				base.ValueBinding = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextTDBarcodeElement()
		{
			Width = 100f;
			Height = 100f;
		}

		public override void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 19;
			base.OnViewMouseDblClick(elementMouseEventArgs_0);
			if (elementMouseEventArgs_0.Button == MouseButtons.Left && OwnerDocument.Options.BehaviorOptions.DesignMode)
			{
				object obj = OwnerDocument.EditorControl.ExecuteCommand("ElementProperties", showUI: true, this);
				if (obj != null)
				{
					elementMouseEventArgs_0.Handled = true;
				}
			}
		}

		/// <summary>
		///       绘制内容
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			string text = method_16(args.PageIndex);
			if (!string.IsNullOrEmpty(text))
			{
				int num = Math.Min(OwnerDocument.ToPixel(ClientWidth), OwnerDocument.ToPixel(ClientHeight));
				int int_ = num;
				int int_2 = num;
				sbyte[][] sbyte_ = (sbyte[][])smethod_2(BarcodeType, ErroeCorrectionLevel, text, ref int_, ref int_2, 0);
				smethod_1(args, sbyte_, args.ViewBounds);
				if (args.Graphics != null)
				{
					args.Graphics.LogContent(text);
				}
				OwnerDocument.method_114(this, args, GEnum6.const_113);
			}
		}

		private static sbyte[][] smethod_0(sbyte[][] sbyte_0)
		{
			int num = sbyte_0[0].Length;
			int num2 = sbyte_0.Length;
			int num3 = 0;
			int num4 = Math.Min(num, num2) / 2 - 2;
			for (int i = 0; i < num4; i++)
			{
				bool flag = false;
				for (int j = 0; j < num; j++)
				{
					if (sbyte_0[i][j] == 0 || sbyte_0[num2 - i - 1][j] == 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					for (int k = 0; k < num2; k++)
					{
						if (sbyte_0[k][i] == 0 || sbyte_0[k][num - i - 1] == 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					num3 = Math.Max(num3, i - 1);
					break;
				}
			}
			if (num3 > 0)
			{
				sbyte[][] array = new sbyte[num2 - num3 * 2][];
				for (int k = 0; k < array.Length; k++)
				{
					sbyte[] array2 = array[k] = new sbyte[num - num3 * 2];
					Array.Copy(sbyte_0[k + num3], num3, array2, 0, array2.Length);
				}
				return array;
			}
			return sbyte_0;
		}

		private static void smethod_1(DocumentPaintEventArgs documentPaintEventArgs_0, sbyte[][] sbyte_0, RectangleF rectangleF_0)
		{
			if (sbyte_0 == null)
			{
				return;
			}
			sbyte[][] array = smethod_0(sbyte_0);
			int num = array[0].Length;
			int num2 = array.Length;
			RectangleF innerRectangle = RectangleCommon.GetInnerRectangle(rectangleF_0, (float)num * 1f / (float)num2);
			if (innerRectangle.IsEmpty || !documentPaintEventArgs_0.ClipRectangle.IntersectsWith(innerRectangle))
			{
				return;
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (array[i][j] == 0)
					{
						RectangleF rect = new RectangleF(innerRectangle.Left + innerRectangle.Width * (float)j / (float)num, innerRectangle.Top + innerRectangle.Height * (float)i / (float)num2, innerRectangle.Width / (float)num, innerRectangle.Height / (float)num2);
						documentPaintEventArgs_0.Graphics.FillRectangle(Color.Black, rect);
					}
				}
			}
		}

		public static object smethod_2(DCTDBarcodeType dctdbarcodeType_1, DCTBErroeCorrectionLevelType dctberroeCorrectionLevelType_1, string string_12, ref int int_8, ref int int_9, int int_10)
		{
			if (string.IsNullOrEmpty(string_12))
			{
				return null;
			}
			GClass652 gClass = new GClass652();
			BarcodeFormat barcodeFormat_ = null;
			if (dctdbarcodeType_1 == DCTDBarcodeType.QR)
			{
				barcodeFormat_ = BarcodeFormat.barcodeFormat_0;
				switch (dctberroeCorrectionLevelType_1)
				{
				case DCTBErroeCorrectionLevelType.L:
					gClass.method_4(GClass636.gclass636_0);
					break;
				case DCTBErroeCorrectionLevelType.M:
					gClass.method_4(GClass636.gclass636_1);
					break;
				case DCTBErroeCorrectionLevelType.Q:
					gClass.method_4(GClass636.gclass636_2);
					break;
				case DCTBErroeCorrectionLevelType.H:
					gClass.method_4(GClass636.gclass636_3);
					break;
				}
			}
			Size size = new Size(0, 0);
			size = ((int_10 != 0) ? gClass.method_5(string_12, barcodeFormat_, int_8, int_9) : gClass.method_5(string_12, barcodeFormat_, 0, 0));
			int_8 = size.Width;
			int_9 = size.Height;
			switch (int_10)
			{
			case 0:
				return gClass.method_6(string_12, barcodeFormat_, int_8, int_9);
			case 1:
				return gClass.method_7(string_12, barcodeFormat_, int_8, int_9);
			default:
				return null;
			}
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			SizeF size = new SizeF(Width, Height);
			size = GraphicsUnitConvert.Convert(size, OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			using (Image image_ = CreateContentImage())
			{
				gclass103_0.method_45(image_, (int)size.Width, (int)size.Height, null, RuntimeStyle);
			}
		}
	}
}
