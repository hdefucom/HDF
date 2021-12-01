using DCSoft.Common;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表达式文档域对象
	///       </summary>
	[XmlType("XTextExpressionField")]
	[DebuggerDisplay("Expression:{ID}")]
	[Guid("00012345-6789-ABCD-EF01-2345678900bb")]
	[DocumentComment]
	public class XTextExpressionFieldElement : XTextInputFieldElementBase
	{
		private string string_23 = null;

		/// <summary>
		///       表达式
		///       </summary>
		[DefaultValue(null)]
		public string Expression
		{
			get
			{
				return string_23;
			}
			set
			{
				string_23 = value;
			}
		}

		/// <summary>
		///       初始化对象 
		///       </summary>
		public XTextExpressionFieldElement()
		{
			base.AcceptChildElementTypes2 = (ElementType.Text | ElementType.LineBreak | ElementType.ParagraphFlag);
		}
	}
}
