using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       执行HeaderFormat命令使用的参数
	///       </summary>
	[ComClass("659E2B27-CBC2-4B6A-95E8-7611ABCBB8D0", "C1D39294-3BDF-4E1E-99BB-A64842326881")]
	[Guid("659E2B27-CBC2-4B6A-95E8-7611ABCBB8D0")]
	[DocumentComment]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IHeaderFormatCommandParameter))]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	public class HeaderFormatCommandParameter : IHeaderFormatCommandParameter
	{
		internal const string CLASSID = "659E2B27-CBC2-4B6A-95E8-7611ABCBB8D0";

		internal const string CLASSID_Interface = "C1D39294-3BDF-4E1E-99BB-A64842326881";

		private bool _VisibleInDirectory = true;

		private int _ParagraphOutlineLevel = 1;

		private bool _ParagraphMultiLevel = false;

		private ParagraphListStyle _ParagraphListStyle = ParagraphListStyle.ListNumberStyle;

		private float _LeftIndent = 0f;

		private float _FirstLineIndent = 0f;

		private string _FontName = null;

		private float _FontSize = 20f;

		private FontStyle _FontStyle = FontStyle.Bold;

		private LineSpacingStyle _LineSpacingStyle = LineSpacingStyle.SpaceSingle;

		private float _LineSpacing = 0f;

		/// <summary>
		///       在目录中是否可见
		///       </summary>
		public bool VisibleInDirectory
		{
			get
			{
				return _VisibleInDirectory;
			}
			set
			{
				_VisibleInDirectory = value;
			}
		}

		/// <summary>
		///       段落大纲层数
		///       </summary>
		public int ParagraphOutlineLevel
		{
			get
			{
				return _ParagraphOutlineLevel;
			}
			set
			{
				_ParagraphOutlineLevel = value;
			}
		}

		/// <summary>
		///       是否多层
		///       </summary>
		public bool ParagraphMultiLevel
		{
			get
			{
				return _ParagraphMultiLevel;
			}
			set
			{
				_ParagraphMultiLevel = value;
			}
		}

		/// <summary>
		///       段落列表样式
		///       </summary>
		public ParagraphListStyle ParagraphListStyle
		{
			get
			{
				return _ParagraphListStyle;
			}
			set
			{
				_ParagraphListStyle = value;
			}
		}

		/// <summary>
		///       段落左缩进量
		///       </summary>
		public float LeftIndent
		{
			get
			{
				return _LeftIndent;
			}
			set
			{
				_LeftIndent = value;
			}
		}

		/// <summary>
		///       首行缩进
		///       </summary>
		public float FirstLineIndent
		{
			get
			{
				return _FirstLineIndent;
			}
			set
			{
				_FirstLineIndent = value;
			}
		}

		/// <summary>
		///       字体名称
		///       </summary>
		public string FontName
		{
			get
			{
				return _FontName;
			}
			set
			{
				_FontName = value;
			}
		}

		/// <summary>
		///       字体大小
		///       </summary>
		public float FontSize
		{
			get
			{
				return _FontSize;
			}
			set
			{
				_FontSize = value;
			}
		}

		/// <summary>
		///       字体样式
		///       </summary>
		public FontStyle FontStyle
		{
			get
			{
				return _FontStyle;
			}
			set
			{
				_FontStyle = value;
			}
		}

		/// <summary>
		///       行间距样式
		///       </summary>
		public LineSpacingStyle LineSpacingStyle
		{
			get
			{
				return _LineSpacingStyle;
			}
			set
			{
				_LineSpacingStyle = value;
			}
		}

		/// <summary>
		///       行间距
		///       </summary>
		public float LineSpacing
		{
			get
			{
				return _LineSpacing;
			}
			set
			{
				_LineSpacing = value;
			}
		}

		/// <summary>
		///       为命令Header1创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader1()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 0;
			headerFormatCommandParameter.ParagraphMultiLevel = false;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.None;
			headerFormatCommandParameter.LeftIndent = 0f;
			headerFormatCommandParameter.FirstLineIndent = 0f;
			headerFormatCommandParameter.FontSize = 24f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 2.41f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header2创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader2()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 1;
			headerFormatCommandParameter.ParagraphMultiLevel = false;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.None;
			headerFormatCommandParameter.LeftIndent = 0f;
			headerFormatCommandParameter.FirstLineIndent = 0f;
			headerFormatCommandParameter.FontSize = 18f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.73f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header3创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader3()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 2;
			headerFormatCommandParameter.ParagraphMultiLevel = false;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.None;
			headerFormatCommandParameter.LeftIndent = 0f;
			headerFormatCommandParameter.FirstLineIndent = 0f;
			headerFormatCommandParameter.FontSize = 13f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.73f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header4创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader4()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 3;
			headerFormatCommandParameter.ParagraphMultiLevel = false;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.None;
			headerFormatCommandParameter.LeftIndent = 0f;
			headerFormatCommandParameter.FirstLineIndent = 0f;
			headerFormatCommandParameter.FontSize = 12f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.57f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header5创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader5()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 4;
			headerFormatCommandParameter.ParagraphMultiLevel = false;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.None;
			headerFormatCommandParameter.LeftIndent = 0f;
			headerFormatCommandParameter.FirstLineIndent = 0f;
			headerFormatCommandParameter.FontSize = 10f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.57f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header6创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader6()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 5;
			headerFormatCommandParameter.ParagraphMultiLevel = false;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.None;
			headerFormatCommandParameter.LeftIndent = 0f;
			headerFormatCommandParameter.FirstLineIndent = 0f;
			headerFormatCommandParameter.FontSize = 8f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.33f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header1WithMultiNumberlist创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader1WithMultiNumberlist()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 0;
			headerFormatCommandParameter.ParagraphMultiLevel = true;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
			headerFormatCommandParameter.LeftIndent = 100f;
			headerFormatCommandParameter.FirstLineIndent = -100f;
			headerFormatCommandParameter.FontSize = 24f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 2.41f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header2WithMultiNumberlist创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader2WithMultiNumberlist()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 1;
			headerFormatCommandParameter.ParagraphMultiLevel = true;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
			headerFormatCommandParameter.LeftIndent = 200f;
			headerFormatCommandParameter.FirstLineIndent = -100f;
			headerFormatCommandParameter.FontSize = 18f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.73f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header3WithMultiNumberlist创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader3WithMultiNumberlist()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 2;
			headerFormatCommandParameter.ParagraphMultiLevel = true;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
			headerFormatCommandParameter.LeftIndent = 300f;
			headerFormatCommandParameter.FirstLineIndent = -100f;
			headerFormatCommandParameter.FontSize = 13f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.73f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header4WithMultiNumberlist创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader4WithMultiNumberlist()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 3;
			headerFormatCommandParameter.ParagraphMultiLevel = true;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
			headerFormatCommandParameter.LeftIndent = 300f;
			headerFormatCommandParameter.FirstLineIndent = -100f;
			headerFormatCommandParameter.FontSize = 12f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.57f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header5WithMultiNumberlist创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader5WithMultiNumberlist()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 4;
			headerFormatCommandParameter.ParagraphMultiLevel = true;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
			headerFormatCommandParameter.LeftIndent = 400f;
			headerFormatCommandParameter.FirstLineIndent = -100f;
			headerFormatCommandParameter.FontSize = 10f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.57f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}

		/// <summary>
		///       为命令Header6WithMultiNumberlist创建参数对象
		///       </summary>
		/// <returns>创建的参数对象</returns>
		public static HeaderFormatCommandParameter CreateHeader6WithMultiNumberlist()
		{
			HeaderFormatCommandParameter headerFormatCommandParameter = new HeaderFormatCommandParameter();
			headerFormatCommandParameter.ParagraphOutlineLevel = 5;
			headerFormatCommandParameter.ParagraphMultiLevel = true;
			headerFormatCommandParameter.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
			headerFormatCommandParameter.LeftIndent = 500f;
			headerFormatCommandParameter.FirstLineIndent = -100f;
			headerFormatCommandParameter.FontSize = 8f;
			headerFormatCommandParameter.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			headerFormatCommandParameter.LineSpacing = 1.33f;
			headerFormatCommandParameter.FontStyle = FontStyle.Bold;
			return headerFormatCommandParameter;
		}
	}
}
