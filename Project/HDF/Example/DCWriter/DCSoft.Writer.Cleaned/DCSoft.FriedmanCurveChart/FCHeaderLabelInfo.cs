using DCSoft.Common;
using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       标题文本信息对象
	///       </summary>
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[DCPublishAPI]
	[Guid("682A7BBC-60E0-4956-8885-3A8DFB44835B")]
	[ComDefaultInterface(typeof(IHeaderLabelInfo))]
	[ComVisible(true)]
	public class FCHeaderLabelInfo : IHeaderLabelInfo
	{
		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private string string_3 = null;

		private string string_4 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 0f;

		private float float_3 = 0f;

		private FriedmanCurveDocument friedmanCurveDocument_0 = null;

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCHeaderLabelInfo), "Title")]
		public string Title
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       数据源名称
		///       </summary>
		[DCDisplayName(typeof(FCHeaderLabelInfo), "DataSourceName")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string DataSourceName
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       文本绑定的数据字段名
		///       </summary>
		[DCDisplayName(typeof(FCHeaderLabelInfo), "ValueFieldName")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string ValueFieldName
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		/// <summary>
		///       使用的参数名
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCHeaderLabelInfo), "ParameterName")]
		[DefaultValue(null)]
		public string ParameterName
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[DCDisplayName(typeof(FCHeaderLabelInfo), "Value")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string Value
		{
			get
			{
				return string_4;
			}
			set
			{
				string_4 = value;
			}
		}

		/// <summary>
		///       左端位置
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Left
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		/// <summary>
		///       顶端位置
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Top
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		/// <summary>
		///       宽度
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public float Width
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Height
		{
			get
			{
				return float_3;
			}
			set
			{
				float_3 = value;
			}
		}

		/// <summary>
		///       对象所在的文档对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public FriedmanCurveDocument OwnerDocument
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
		///       实际绘制图形时使用的文本值
		///       </summary>
		internal string RuntimeText
		{
			get
			{
				int num = 4;
				string text = Value;
				if (OwnerDocument != null)
				{
					text = OwnerDocument.Parameters.Convert(ParameterName, text);
				}
				return Title + ":" + text;
			}
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			return Title + "  " + GetType().Name;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FCHeaderLabelInfo Clone()
		{
			return (FCHeaderLabelInfo)MemberwiseClone();
		}

		internal void method_0(DCGraphics dcgraphics_0, XFontValue xfontValue_0)
		{
			SizeF sizeF = dcgraphics_0.MeasureString(RuntimeText, xfontValue_0, 10000, DrawStringFormatExt.GenericTypographic);
			Width = sizeF.Width;
			Height = sizeF.Height;
		}

		internal void method_1(DCGraphics dcgraphics_0, XFontValue xfontValue_0, Color color_0, string string_5)
		{
			int num = 11;
			using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
			{
				drawStringFormatExt.Alignment = StringAlignment.Near;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				if (RuntimeText.IndexOf("\r\n") > 0)
				{
					string text = RuntimeText.Substring(0, RuntimeText.IndexOf(":") + 1);
					string text2 = RuntimeText.Substring(RuntimeText.IndexOf(":") + 1, RuntimeText.IndexOf("\r\n") - 1);
					string text3 = RuntimeText.Substring(RuntimeText.IndexOf("\r\n") + 1);
					if (string_5 == "Page")
					{
						SizeF sizeF = dcgraphics_0.MeasureString(text, xfontValue_0);
						dcgraphics_0.DrawString(text, xfontValue_0, color_0, new RectangleF(Left, Top, sizeF.Width, Height), drawStringFormatExt);
						dcgraphics_0.DrawString(text2, xfontValue_0, color_0, new RectangleF(width: dcgraphics_0.MeasureString(text2, xfontValue_0).Width, x: Left + sizeF.Width + 6f, y: Top - 34f, height: Height), drawStringFormatExt);
						SizeF sizeF2 = dcgraphics_0.MeasureString(text3, xfontValue_0);
						dcgraphics_0.DrawString(text3, xfontValue_0, color_0, new RectangleF(Left + sizeF.Width + 6f, Top - 25f, sizeF2.Width, sizeF2.Height), drawStringFormatExt);
					}
					else
					{
						dcgraphics_0.DrawString(text + text2, xfontValue_0, color_0, new RectangleF(Left, Top, Width, Height), drawStringFormatExt);
					}
				}
				else
				{
					dcgraphics_0.DrawString(RuntimeText, xfontValue_0, color_0, new RectangleF(Left, Top, Width, Height), drawStringFormatExt);
				}
			}
		}
	}
}
