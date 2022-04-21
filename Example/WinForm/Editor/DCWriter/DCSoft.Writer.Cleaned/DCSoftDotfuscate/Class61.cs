using DCSoft.Common;
using DCSoft.Design.Web;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Web.UI.Design;

namespace DCSoftDotfuscate
{
	[Serializable]
	
	[ComVisible(false)]
	internal class Class61
	{
		private bool bool_0 = false;

		private float float_0 = 1f;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = false;

		private int int_0 = 1;

		private DCPrintMode dcprintMode_0 = DCPrintMode.Normal;

		private string string_0 = null;

		private bool bool_4 = false;

		private bool bool_5 = false;

		private bool bool_6 = true;

		private int int_1 = 0;

		private DCBackgroundTextOutputMode dcbackgroundTextOutputMode_0 = DCBackgroundTextOutputMode.Output;

		private bool bool_7 = true;

		private bool bool_8 = false;

		private bool bool_9 = false;

		private bool bool_10 = false;

		private bool bool_11 = false;

		private string string_1 = null;

		private string string_2 = null;

		private int int_2 = 20;

		private bool bool_12 = true;

		private string string_3 = null;

		private string string_4 = null;

		private bool bool_13 = true;

		private DCOptionMode dcoptionMode_0 = DCOptionMode.AutoDetect;

		private string string_5 = null;

		private Color color_0 = SystemColors.AppWorkspace;

		private Color color_1 = Color.White;

		private int int_3 = 0;

		private bool bool_14 = false;

		private bool bool_15 = false;

		private bool bool_16 = false;

		private bool bool_17 = true;

		private string string_6 = null;

		private bool bool_18 = true;

		private bool bool_19 = true;

		private FunctionControlVisibility functionControlVisibility_0 = FunctionControlVisibility.Auto;

		private bool bool_20 = false;

		private string string_7 = null;

		private string string_8 = null;

		private WebWriterControlRenderMode webWriterControlRenderMode_0 = WebWriterControlRenderMode.PageImage;

		private bool bool_21 = false;

		private bool bool_22 = false;

		private bool bool_23 = false;

		private FormViewMode formViewMode_0 = FormViewMode.Disable;

		[DefaultValue(true)]
		public bool EnabledClientContextMenu
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		[DefaultValue(DCBackgroundTextOutputMode.Output)]
		public DCBackgroundTextOutputMode BackgroundTextOutputMode
		{
			get
			{
				return dcbackgroundTextOutputMode_0;
			}
			set
			{
				dcbackgroundTextOutputMode_0 = value;
			}
		}

		[DefaultValue(true)]
		[Category("Behavior")]
		public bool ShowMainDocumentBodyWhenMultiDocument
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		[DefaultValue(false)]
		[Category("Behavior")]
		public bool MultiDocument
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		[DefaultValue(false)]
		[Category("Appearance")]
		public bool ShowDebugInfo
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		[DefaultValue(false)]
		public bool IndentHtmlCode
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		[DefaultValue(true)]
		[Category("Appearance")]
		public bool PageShadow
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

		[DefaultValue(null)]
		[Editor(typeof(ASPXUrlEditor), typeof(UITypeEditor))]
		public string ServicePageURL
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

		[DefaultValue(null)]
		[Editor(typeof(UrlEditor), typeof(UITypeEditor))]
		public string KBLibraryUrl
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

		[DefaultValue(20)]
		public int PixelPageSpacing
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		public bool CompressSessionData
		{
			get
			{
				return bool_12;
			}
			set
			{
				bool_12 = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(null)]
		public string ExcludeKeywords
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

		[DefaultValue(null)]
		[Category("Behavior")]
		public string InsertImageButtonID
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

		[DefaultValue(true)]
		public bool AutoHeightInMobileDevice
		{
			get
			{
				return bool_13;
			}
			set
			{
				bool_13 = value;
			}
		}

		[DefaultValue(DCOptionMode.AutoDetect)]
		public DCOptionMode IsMobileDevice
		{
			get
			{
				return dcoptionMode_0;
			}
			set
			{
				dcoptionMode_0 = value;
			}
		}

		[Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string WorkspaceBackgroundImage
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		[DefaultValue(0)]
		[Category("Behavior")]
		public int MaxPageCount
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		public bool GenerateFormElement
		{
			get
			{
				return bool_14;
			}
			set
			{
				bool_14 = value;
			}
		}

		[Category("Appearance")]
		[DefaultValue(false)]
		public bool AutoZoom
		{
			get
			{
				return bool_15;
			}
			set
			{
				bool_15 = value;
			}
		}

		[DefaultValue(false)]
		[Category("Appearance")]
		public bool NarrowBorder
		{
			get
			{
				return bool_16;
			}
			set
			{
				bool_16 = value;
			}
		}

		[DefaultValue(true)]
		public bool AutoGenerateCABFile
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		[DefaultValue(true)]
		public bool AutoPostBack
		{
			get
			{
				return bool_18;
			}
			set
			{
				bool_18 = value;
			}
		}

		[DefaultValue(true)]
		public bool SerializeParameterValue
		{
			get
			{
				return bool_19;
			}
			set
			{
				bool_19 = value;
			}
		}

		[Category("Appearance")]
		[DefaultValue(FunctionControlVisibility.Auto)]
		public FunctionControlVisibility CommentVisibility
		{
			get
			{
				return functionControlVisibility_0;
			}
			set
			{
				functionControlVisibility_0 = value;
			}
		}

		[DefaultValue(false)]
		public bool EnablePermission
		{
			get
			{
				return bool_20;
			}
			set
			{
				bool_20 = value;
			}
		}

		[Editor(typeof(UrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string CABUrl
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
			}
		}

		[DefaultValue(null)]
		public string CABVersion
		{
			get
			{
				return string_8;
			}
			set
			{
				string_8 = value;
			}
		}

		[DefaultValue(WebWriterControlRenderMode.PageImage)]
		public WebWriterControlRenderMode ContentRenderMode
		{
			get
			{
				return webWriterControlRenderMode_0;
			}
			set
			{
				webWriterControlRenderMode_0 = value;
			}
		}

		[DefaultValue(false)]
		[Category("Behavior")]
		public bool Readonly
		{
			get
			{
				return bool_21;
			}
			set
			{
				bool_21 = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AutoLine
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		[DefaultValue(false)]
		[Category("Appearance")]
		public bool ShowMarginLine
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

		[Category("Behavior")]
		[DefaultValue(FormViewMode.Disable)]
		public FormViewMode FormView
		{
			get
			{
				return formViewMode_0;
			}
			set
			{
				formViewMode_0 = value;
			}
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_24)
		{
			bool_0 = bool_24;
		}

		public float method_2()
		{
			return float_0;
		}

		public void method_3(float float_1)
		{
			float_0 = float_1;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_24)
		{
			bool_1 = bool_24;
		}

		public bool method_6()
		{
			return bool_3;
		}

		public void method_7(bool bool_24)
		{
			bool_3 = bool_24;
		}

		public int method_8()
		{
			return int_0;
		}

		public void method_9(int int_4)
		{
			int_0 = int_4;
		}

		public DCPrintMode method_10()
		{
			return dcprintMode_0;
		}

		public void method_11(DCPrintMode dcprintMode_1)
		{
			dcprintMode_0 = dcprintMode_1;
		}

		public string method_12()
		{
			return string_0;
		}

		public void method_13(string string_9)
		{
			string_0 = string_9;
		}

		public bool method_14()
		{
			return bool_4;
		}

		public void method_15(bool bool_24)
		{
			bool_4 = bool_24;
		}

		public bool method_16()
		{
			return bool_5;
		}

		public void method_17(bool bool_24)
		{
			bool_5 = bool_24;
		}

		public bool method_18()
		{
			return bool_6;
		}

		public void method_19(bool bool_24)
		{
			bool_6 = bool_24;
		}

		public int method_20()
		{
			return int_1;
		}

		public void method_21(int int_4)
		{
			int_1 = int_4;
		}

		public Color method_22()
		{
			return color_0;
		}

		public void method_23(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_24()
		{
			return color_1;
		}

		public void method_25(Color color_2)
		{
			color_1 = color_2;
		}

		public string method_26()
		{
			return string_6;
		}

		public void method_27(string string_9)
		{
			string_6 = string_9;
		}

		public Class61 method_28()
		{
			return (Class61)MemberwiseClone();
		}
	}
}
