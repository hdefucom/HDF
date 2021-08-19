using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.FriedmanCurveChart;
using DCSoft.Writer.Data;
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
	///       产程图对象
	///       </summary>
	/// <remarks>
	/// </remarks>
	[Serializable]
	[DocumentComment]
	[Guid("74B2A5DB-7C03-4A4F-BEAC-D1E3A5AD18EC")]
	[DCPublishAPI]
	[DebuggerDisplay("FriedmanCurveChart:{Name}")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextFriedmanCurveChartElement))]
	[XmlType("XTextFriedmanCurveChart")]
	[ComClass("74B2A5DB-7C03-4A4F-BEAC-D1E3A5AD18EC", "3C399D74-B3EA-410B-B093-79F46CE0DA80")]
	[ToolboxBitmap(typeof(XTextFriedmanCurveChartElement))]
	public sealed class XTextFriedmanCurveChartElement : XTextObjectElement, IXTextFriedmanCurveChartElement
	{
		internal const string string_9 = "74B2A5DB-7C03-4A4F-BEAC-D1E3A5AD18EC";

		internal const string string_10 = "3C399D74-B3EA-410B-B093-79F46CE0DA80";

		private FriedmanCurveDocument friedmanCurveDocument_0 = null;

		private int int_8 = 0;

		public override string DomDisplayName => "TChart:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "tmp";

		[Browsable(false)]
		public override VerticalAlignStyle RuntimeVAlign => VerticalAlignStyle.Bottom;

		/// <summary>
		///       对象宽度
		///       </summary>
		[XmlElement]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[Browsable(true)]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[XmlElement]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
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
		///       产程图文档对象
		///       </summary>
		[DefaultValue(null)]
		public FriedmanCurveDocument Document
		{
			get
			{
				return friedmanCurveDocument_0;
			}
			set
			{
				friedmanCurveDocument_0 = value;
			}
		}

		/// <summary>
		///       从0开始计算的图标页码
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[DefaultValue(0)]
		public int ChartPageIndex
		{
			get
			{
				return int_8;
			}
			set
			{
				int_8 = value;
			}
		}

		public override XTextElement Clone(bool Deeply)
		{
			XTextFriedmanCurveChartElement xTextFriedmanCurveChartElement = (XTextFriedmanCurveChartElement)base.Clone(Deeply);
			if (friedmanCurveDocument_0 != null)
			{
				xTextFriedmanCurveChartElement.friedmanCurveDocument_0 = friedmanCurveDocument_0.Clone();
			}
			return xTextFriedmanCurveChartElement;
		}

		private void method_16()
		{
			if (friedmanCurveDocument_0 == null)
			{
				friedmanCurveDocument_0 = new FriedmanCurveDocument();
			}
		}

		/// <summary>
		///       文档元素加载后处理
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			method_16();
			if (OwnerDocument != null)
			{
				foreach (DocumentParameter parameter in OwnerDocument.Parameters)
				{
					friedmanCurveDocument_0.DataSources[parameter.Name] = parameter.Value;
				}
				friedmanCurveDocument_0.RefreshDataSource();
			}
		}

		/// <summary>
		///       绘制元素内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (args.RenderMode == DocumentRenderMode.PDF)
			{
				Image image_ = CreateContentImage();
				RectangleF clientViewBounds = args.ClientViewBounds;
				clientViewBounds.Width -= 1f;
				clientViewBounds.Height -= 1f;
				args.Graphics.DrawImage(image_, clientViewBounds);
			}
			else
			{
				method_16();
				RectangleF clientViewBounds = args.ClientViewBounds;
				clientViewBounds.Width -= 3f;
				clientViewBounds.Height -= 3f;
				friedmanCurveDocument_0.Bounds = clientViewBounds;
				friedmanCurveDocument_0.PageIndex = ChartPageIndex;
				friedmanCurveDocument_0.ViewMode = FCDocumentViewMode.Page;
				friedmanCurveDocument_0.method_13(args.Graphics, args.ClipRectangle, GEnum23.const_2);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			friedmanCurveDocument_0 = null;
		}
	}
}
