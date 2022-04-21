using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.TemperatureChart;
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
	///       体温单对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	
	
	[XmlType("XTemperatureChart")]
	[DebuggerDisplay("TemperatureChart:{Name}")]
	[ToolboxBitmap(typeof(XTextTemperatureChartElement))]
	[ComDefaultInterface(typeof(IXTextTemperatureChartElement))]
	[ComClass("82406980-5BB3-4F86-9E84-6F43F0C5856C", "6E5FD021-473D-4328-BE4A-EFE1E44E1DC5")]
	[ComVisible(true)]
	[Guid("82406980-5BB3-4F86-9E84-6F43F0C5856C")]
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class XTextTemperatureChartElement : XTextObjectElement, IXTextTemperatureChartElement
	{
		internal const string string_9 = "82406980-5BB3-4F86-9E84-6F43F0C5856C";

		internal const string string_10 = "6E5FD021-473D-4328-BE4A-EFE1E44E1DC5";

		private TemperatureDocument temperatureDocument_0 = null;

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
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[Browsable(true)]
		[XmlElement]
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
		[Browsable(true)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
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
		///       内部的体温单文档对象
		///       </summary>
		[DefaultValue(null)]
		public TemperatureDocument Document
		{
			get
			{
				return temperatureDocument_0;
			}
			set
			{
				temperatureDocument_0 = value;
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
			XTextTemperatureChartElement xTextTemperatureChartElement = (XTextTemperatureChartElement)base.Clone(Deeply);
			if (temperatureDocument_0 != null)
			{
				xTextTemperatureChartElement.temperatureDocument_0 = temperatureDocument_0.Clone();
			}
			return xTextTemperatureChartElement;
		}

		private void method_16()
		{
			if (temperatureDocument_0 == null)
			{
				temperatureDocument_0 = new TemperatureDocument();
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
					temperatureDocument_0.DataSources[parameter.Name] = parameter.Value;
				}
				temperatureDocument_0.RefreshDataSource();
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
				temperatureDocument_0.Bounds = clientViewBounds;
				temperatureDocument_0.PageIndex = ChartPageIndex;
				temperatureDocument_0.ViewMode = DocumentViewMode.Normal;
				temperatureDocument_0.method_29(args.Graphics, args.ClipRectangle, GEnum22.const_2);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			temperatureDocument_0 = null;
		}
	}
}
