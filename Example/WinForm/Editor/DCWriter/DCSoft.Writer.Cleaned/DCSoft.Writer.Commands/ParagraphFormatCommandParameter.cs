using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       段落格式命令参数对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComClass("8D524B16-89EB-48E6-952E-7AEDF1B94DA5", "D148ADCD-EB51-493A-A009-44AB73BEFAF4")]
	[ComVisible(true)]
	
	[ComDefaultInterface(typeof(IParagraphFormatCommandParameter))]
	[Guid("8D524B16-89EB-48E6-952E-7AEDF1B94DA5")]
	[ClassInterface(ClassInterfaceType.None)]
	
	public class ParagraphFormatCommandParameter : IParagraphFormatCommandParameter
	{
		internal const string CLASSID = "8D524B16-89EB-48E6-952E-7AEDF1B94DA5";

		internal const string CLASSID_Interface = "D148ADCD-EB51-493A-A009-44AB73BEFAF4";

		private ParagraphListStyle _ListStyle = ParagraphListStyle.None;

		private bool _ParagraphMultiLevel = false;

		private int _OutlineLevel = -1;

		private LineSpacingStyle _LineSpacingStyle = LineSpacingStyle.SpaceSingle;

		private float _LineSpacing = 0f;

		private float _SpacingBefore = 0f;

		private float _SpacingAfter = 0f;

		private float _FirstLineIndent = 0f;

		private float _LeftIndent = 0f;

		/// <summary>
		///       段落列表样式
		///       </summary>
		public ParagraphListStyle ListStyle
		{
			get
			{
				return _ListStyle;
			}
			set
			{
				_ListStyle = value;
			}
		}

		/// <summary>
		///       多层次段落列表
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
		///       段落大纲等级
		///       </summary>
		public int OutlineLevel
		{
			get
			{
				return _OutlineLevel;
			}
			set
			{
				_OutlineLevel = value;
			}
		}

		/// <summary>
		///       行间距样式
		///       </summary>
		[DefaultValue(LineSpacingStyle.SpaceSingle)]
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
		[DefaultValue(0f)]
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
		///       段落前间距
		///       </summary>
		[DefaultValue(0f)]
		public float SpacingBefore
		{
			get
			{
				return _SpacingBefore;
			}
			set
			{
				_SpacingBefore = value;
			}
		}

		/// <summary>
		///       段落后间距
		///       </summary>
		[DefaultValue(0f)]
		public float SpacingAfter
		{
			get
			{
				return _SpacingAfter;
			}
			set
			{
				_SpacingAfter = value;
			}
		}

		/// <summary>
		///       首行缩进量
		///       </summary>
		[DefaultValue(0f)]
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
		///       段落左边缩进量
		///       </summary>
		[DefaultValue(0f)]
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
		///       从文档样式中读取设置
		///       </summary>
		/// <param name="style">文档样式</param>
		public void Read(ContentStyle style)
		{
			int num = 8;
			if (style == null)
			{
				throw new ArgumentNullException("style");
			}
			LineSpacing = style.LineSpacing;
			LeftIndent = style.LeftIndent;
			LineSpacingStyle = style.LineSpacingStyle;
			SpacingAfter = style.SpacingAfterParagraph;
			SpacingBefore = style.SpacingBeforeParagraph;
			FirstLineIndent = style.FirstLineIndent;
			OutlineLevel = style.ParagraphOutlineLevel;
			ParagraphMultiLevel = style.ParagraphMultiLevel;
			ListStyle = style.ParagraphListStyle;
		}

		/// <summary>
		///       将设置写入到文档样式中
		///       </summary>
		/// <param name="style">文档样式</param>
		public void Save(ContentStyle style)
		{
			int num = 3;
			if (style == null)
			{
				throw new ArgumentNullException("style");
			}
			style.FirstLineIndent = FirstLineIndent;
			style.LeftIndent = LeftIndent;
			style.LineSpacing = LineSpacing;
			style.LineSpacingStyle = LineSpacingStyle;
			style.SpacingAfterParagraph = SpacingAfter;
			style.SpacingBeforeParagraph = SpacingBefore;
			style.ParagraphOutlineLevel = OutlineLevel;
			style.ParagraphMultiLevel = ParagraphMultiLevel;
			style.ParagraphListStyle = ListStyle;
		}
	}
}
