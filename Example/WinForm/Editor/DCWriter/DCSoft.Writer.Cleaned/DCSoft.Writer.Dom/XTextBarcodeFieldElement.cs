using DCSoft.Barcode;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       本类型已经废除了。
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IXTextBarcodeFieldElement))]
	
	[ComVisible(true)]
	[ComClass("0B72EF40-396C-4041-8C1E-072D7ECEE897", "F156FA30-D580-47B0-B870-C436D3BD9486")]
	[XmlType("XBarcodeField")]
	[ClassInterface(ClassInterfaceType.None)]
	
	[DebuggerDisplay("Barcode:{Name}")]
	[Guid("0B72EF40-396C-4041-8C1E-072D7ECEE897")]
	public sealed class XTextBarcodeFieldElement : XTextShapeInputFieldElement, IXTextBarcodeFieldElement
	{
		internal const string string_23 = "0B72EF40-396C-4041-8C1E-072D7ECEE897";

		internal const string string_24 = "F156FA30-D580-47B0-B870-C436D3BD9486";

		private string string_25 = null;

		private BarcodeStyle barcodeStyle_0 = BarcodeStyle.Code128C;

		private StringAlignment stringAlignment_1 = StringAlignment.Center;

		private bool bool_23 = true;

		private float float_7 = 7f;

		private string string_26 = null;

		[NonSerialized]
		private GClass94 gclass94_0 = null;

		public override string DomDisplayName => "Barcode:" + base.ID;

		[Browsable(false)]
		[XmlIgnore]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		public override string FormulaValue
		{
			get
			{
				return Text;
			}
			set
			{
				Text = method_12(value);
				InvalidateView();
			}
		}

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "barcode";

		/// <summary>
		///       初始化使用的文本
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[XmlIgnore]
		[Browsable(false)]
		public string InitalizeText
		{
			get
			{
				return string_25;
			}
			set
			{
				string_25 = value;
				gclass94_0 = null;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[DefaultValue(125f)]
		[Browsable(true)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[XmlElement]
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
		///       条码样式
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		[DefaultValue(BarcodeStyle.Code128C)]
		public BarcodeStyle BarcodeStyle
		{
			get
			{
				return barcodeStyle_0;
			}
			set
			{
				barcodeStyle_0 = (BarcodeStyle)WriterUtils.FixEnumValue(value);
				gclass94_0 = null;
			}
		}

		/// <summary>
		///       文本对齐方式
		///       </summary>
		[DefaultValue(StringAlignment.Center)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[HtmlAttribute]
		public StringAlignment TextAlignment
		{
			get
			{
				return stringAlignment_1;
			}
			set
			{
				stringAlignment_1 = (StringAlignment)WriterUtils.FixEnumValue(value);
				gclass94_0 = null;
			}
		}

		/// <summary>
		///       是否绘制文本
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(true)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public bool ShowText
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
				gclass94_0 = null;
			}
		}

		/// <summary>
		///       条码细条宽度
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(7f)]
		public float MinBarWidth
		{
			get
			{
				return float_7;
			}
			set
			{
				float_7 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用
		///       </summary>
		[XmlIgnore]
		[HtmlAttribute]
		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string InnerSerializeText
		{
			get
			{
				return string_26;
			}
			set
			{
				string_26 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextBarcodeFieldElement()
		{
			Height = 125f;
		}

		/// <summary>
		///       绘制图形内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			CheckShapeState(updateSize: true);
			RectangleF absBounds = AbsBounds;
			float num = 0f;
			if (ShowText)
			{
				num = RuntimeStyle.Font.GetHeight(args.Graphics);
			}
			List<RectangleF> list = gclass94_0.method_23(new RectangleF(absBounds.Left, absBounds.Top, absBounds.Width, absBounds.Height - num));
			if (list != null && list.Count > 0)
			{
				foreach (RectangleF item in list)
				{
					args.Graphics.FillRectangle(RuntimeStyle.Color, item);
				}
				if (ShowText && !string.IsNullOrEmpty(gclass94_0.method_2()))
				{
					DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
					drawStringFormatExt.Left = absBounds.Left;
					drawStringFormatExt.Top = absBounds.Bottom - num;
					drawStringFormatExt.Width = absBounds.Width;
					drawStringFormatExt.Height = num;
					drawStringFormatExt.Color = RuntimeStyle.Color;
					args.Graphics.method_2(gclass94_0.method_2(), drawStringFormatExt);
				}
			}
			else if (!string.IsNullOrEmpty(gclass94_0.method_5()))
			{
				DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				drawStringFormatExt.Left = absBounds.Left;
				drawStringFormatExt.Top = absBounds.Bottom - num;
				drawStringFormatExt.Width = absBounds.Width;
				drawStringFormatExt.Height = num;
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.Color = RuntimeStyle.Color;
				drawStringFormatExt.Font = RuntimeStyle.Font;
				args.Graphics.method_2(gclass94_0.method_5(), drawStringFormatExt);
			}
			OwnerDocument.method_114(this, args, GEnum6.const_112);
			if (args.Graphics != null)
			{
				args.Graphics.LogContent(Text);
			}
		}

		public override XTextElement Clone(bool Deeply)
		{
			XTextBarcodeFieldElement xTextBarcodeFieldElement = (XTextBarcodeFieldElement)base.Clone(Deeply);
			xTextBarcodeFieldElement.gclass94_0 = null;
			return xTextBarcodeFieldElement;
		}

		/// <summary>
		///       检查图形状态
		///       </summary>
		/// <param name="updateSize">是否更新元素大小</param>
		public override void CheckShapeState(bool updateSize)
		{
			if (gclass94_0 == null)
			{
				gclass94_0 = new GClass94();
				gclass94_0.method_1(base.ContentVersion - 1);
			}
			if (gclass94_0.method_0() != base.ContentVersion)
			{
				gclass94_0.method_3(Text);
				gclass94_0.method_7(BarcodeStyle);
				gclass94_0.method_14(ShowText);
				gclass94_0.method_12(OwnerDocument.PixelToDocumentUnit(3f));
				gclass94_0.method_1(base.ContentVersion);
				SizeInvalid = true;
			}
			if (updateSize)
			{
				gclass94_0.method_14(ShowText);
				gclass94_0.method_12(MinBarWidth);
				gclass94_0.method_16(RuntimeStyle.Font.Value);
			}
			if (updateSize && SizeInvalid)
			{
				if (gclass94_0.method_20())
				{
					Width = gclass94_0.method_19();
					if (Height == 0f)
					{
						Height = OwnerDocument.PixelToDocumentUnit(40f);
					}
				}
				SizeInvalid = false;
			}
			if (Width <= 0f)
			{
				Width = 100f;
			}
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 11;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			if (readHTMLEventArgs_0.HtmlElement.method_13("height"))
			{
				Height = readHTMLEventArgs_0.ToLength(readHTMLEventArgs_0.HtmlElement.method_9("height"));
			}
			if (!string.IsNullOrEmpty(InnerSerializeText))
			{
				XTextStringElement xTextStringElement = new XTextStringElement();
				xTextStringElement.Text = InnerSerializeText;
				Elements.Clear();
				Elements.Add(xTextStringElement);
				InnerSerializeText = null;
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			gclass94_0 = null;
			string_25 = null;
			string_26 = null;
		}
	}
}
