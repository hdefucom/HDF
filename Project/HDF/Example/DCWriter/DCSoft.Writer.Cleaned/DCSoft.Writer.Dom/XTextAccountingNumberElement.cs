using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       条形码输入域对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[Guid("38E6EE4E-6AF9-4F69-831F-764398B76531")]
	[ComVisible(true)]
	[XmlType("XAccountingNumber")]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IXTextAccountingNumberElement))]
	[ComClass("38E6EE4E-6AF9-4F69-831F-764398B76531", "87BA328F-7682-49DC-A732-6DEAD74BD635")]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("AccountingNumber:{Name}")]
	public sealed class XTextAccountingNumberElement : XTextShapeInputFieldElement, IXTextAccountingNumberElement
	{
		internal const string string_23 = "38E6EE4E-6AF9-4F69-831F-764398B76531";

		internal const string string_24 = "87BA328F-7682-49DC-A732-6DEAD74BD635";

		private bool bool_23 = true;

		private bool bool_24 = true;

		private AccountingNumberUnitMode accountingNumberUnitMode_0 = AccountingNumberUnitMode.LowerCaseChinese;

		private int int_14 = 11;

		public override string DomDisplayName => "AccountingNumber:" + base.ID;

		/// <summary>
		///       对象宽度
		///       </summary>
		[XmlElement]
		[DefaultValue(600f)]
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
		[Browsable(true)]
		[DefaultValue(125f)]
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
		///       显示网格线
		///       </summary>
		[DefaultValue(true)]
		public bool ShowGrid
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
			}
		}

		/// <summary>
		///       是否打印网格线
		///       </summary>
		[DefaultValue(true)]
		public bool PrintGrid
		{
			get
			{
				return bool_24;
			}
			set
			{
				bool_24 = value;
			}
		}

		/// <summary>
		///       数字单位样式
		///       </summary>
		[DefaultValue(AccountingNumberUnitMode.LowerCaseChinese)]
		public AccountingNumberUnitMode UnitMode
		{
			get
			{
				return accountingNumberUnitMode_0;
			}
			set
			{
				accountingNumberUnitMode_0 = value;
			}
		}

		/// <summary>
		///       数字个数
		///       </summary>
		[DefaultValue(11)]
		public int Digitals
		{
			get
			{
				return int_14;
			}
			set
			{
				int_14 = value;
			}
		}

		/// <summary>
		///       获取或设置该元素的会计数字，以文本形式体现
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextAccountingNumberElement()
		{
			Height = 125f;
			Width = 600f;
			EnableHighlight = EnableState.Disabled;
		}

		/// <summary>
		///       绘制图形内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			CheckShapeState(updateSize: true);
			_ = args.ClientViewBounds;
			GClass447 gClass = new GClass447();
			gClass.method_1(args.Style.Font);
			gClass.method_3(Digitals);
			gClass.method_5(UnitMode);
			gClass.method_9(method_4(args.Style.Color));
			if (args.RenderMode == DocumentRenderMode.Print)
			{
				gClass.method_7(PrintGrid);
			}
			else
			{
				gClass.method_7(ShowGrid);
			}
			double result = 0.0;
			if (double.TryParse(Text, out result))
			{
				gClass.method_12(args.Graphics, result, args.ClientViewBounds);
			}
		}

		/// <summary>
		///       检查图形状态
		///       </summary>
		/// <param name="updateSize">是否更新元素大小</param>
		public override void CheckShapeState(bool updateSize)
		{
		}
	}
}
