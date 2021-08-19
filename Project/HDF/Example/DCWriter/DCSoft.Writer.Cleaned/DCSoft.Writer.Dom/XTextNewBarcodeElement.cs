using DCSoft.Barcode;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       条形码输入域对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlType("NewBarcode")]
	[DCPublishAPI]
	[DocumentComment]
	[DebuggerDisplay("NewBarcode:{Name}")]
	public sealed class XTextNewBarcodeElement : XTextLabelElementBase
	{
		private DCBarcodeStyle dcbarcodeStyle_0 = DCBarcodeStyle.Code128C;

		private StringAlignment stringAlignment_0 = StringAlignment.Center;

		private bool bool_11 = true;

		public override string DomDisplayName => "Barcode:" + base.ID;

		public override bool RuntimeAutoSize => false;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "barcode";

		/// <summary>
		///       对象高度
		///       </summary>
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(125f)]
		[XmlElement]
		[Browsable(true)]
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
		///       已废除，请使用BarcodeStyle2属性。
		///       </summary>
		[DCInternal]
		[DefaultValue(BarcodeStyle.Code128C)]
		[Browsable(false)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public BarcodeStyle BarcodeStyle
		{
			get
			{
				return (BarcodeStyle)dcbarcodeStyle_0;
			}
			set
			{
				dcbarcodeStyle_0 = (DCBarcodeStyle)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       条码样式
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(DCBarcodeStyle.Code128C)]
		[Browsable(true)]
		[DCPublishAPI]
		public DCBarcodeStyle BarcodeStyle2
		{
			get
			{
				return dcbarcodeStyle_0;
			}
			set
			{
				dcbarcodeStyle_0 = (DCBarcodeStyle)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       文本对齐方式
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[DefaultValue(StringAlignment.Center)]
		[HtmlAttribute]
		[DCPublishAPI]
		public StringAlignment TextAlignment
		{
			get
			{
				return stringAlignment_0;
			}
			set
			{
				stringAlignment_0 = (StringAlignment)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       是否绘制文本
		///       </summary>
		[DefaultValue(true)]
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[HtmlAttribute]
		public bool ShowText
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextNewBarcodeElement()
		{
			Height = 150f;
			Width = 400f;
		}

		public override void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 8;
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
		///       绘制图形内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			GClass94 gClass = new GClass94();
			gClass.method_22(bool_3: true);
			gClass.method_3(method_16(args.PageIndex));
			gClass.method_7((BarcodeStyle)BarcodeStyle2);
			gClass.method_14(ShowText);
			gClass.method_16(RuntimeStyle.Font.Value);
			gClass.method_18(TextAlignment);
			RectangleF absBounds = AbsBounds;
			float num = 0f;
			if (ShowText)
			{
				num = RuntimeStyle.Font.GetHeight(args.Graphics);
			}
			List<RectangleF> list = gClass.method_23(new RectangleF(absBounds.Left, absBounds.Top, absBounds.Width, absBounds.Height - num));
			if (list != null && list.Count > 0)
			{
				Color color = RuntimeStyle.Color;
				foreach (RectangleF item in list)
				{
					args.Graphics.FillRectangle(color, item);
				}
				if (ShowText && !string.IsNullOrEmpty(gClass.method_2()))
				{
					DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
					drawStringFormatExt.Alignment = TextAlignment;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
					drawStringFormatExt.Left = absBounds.Left;
					drawStringFormatExt.Top = absBounds.Bottom - num;
					drawStringFormatExt.Width = absBounds.Width;
					drawStringFormatExt.Height = num;
					drawStringFormatExt.Color = RuntimeStyle.Color;
					drawStringFormatExt.Font = RuntimeStyle.Font;
					args.Graphics.method_2(gClass.method_2(), drawStringFormatExt);
				}
			}
			else if (!string.IsNullOrEmpty(gClass.method_5()))
			{
				DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				drawStringFormatExt.Left = absBounds.Left;
				drawStringFormatExt.Top = absBounds.Bottom - num;
				drawStringFormatExt.Width = absBounds.Width;
				drawStringFormatExt.Height = num;
				drawStringFormatExt.Alignment = StringAlignment.Near;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.Color = RuntimeStyle.Color;
				drawStringFormatExt.Font = RuntimeStyle.Font;
				args.Graphics.method_2(gClass.method_5(), drawStringFormatExt);
			}
			OwnerDocument.method_114(this, args, GEnum6.const_112);
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 1;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			if (readHTMLEventArgs_0.HtmlElement.method_13("height"))
			{
				Height = readHTMLEventArgs_0.ToLength(readHTMLEventArgs_0.HtmlElement.method_9("height"));
			}
			if (readHTMLEventArgs_0.HtmlElement.method_13("width"))
			{
				Width = readHTMLEventArgs_0.ToLength(readHTMLEventArgs_0.HtmlElement.method_9("width"));
			}
		}
	}
}
