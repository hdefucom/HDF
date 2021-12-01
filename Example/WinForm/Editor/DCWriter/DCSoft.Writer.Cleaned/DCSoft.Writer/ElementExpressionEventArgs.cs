using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素执行表达式事件参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IElementExpressionEventArgs))]
	[Guid("A4E35045-E2D5-4E05-9703-E06B1AB82B56")]
	[ComClass("A4E35045-E2D5-4E05-9703-E06B1AB82B56", "11A21CBD-0555-4AAD-BF09-0C4E2E8E0F13")]
	public class ElementExpressionEventArgs : ElementEventArgs, IElementExpressionEventArgs
	{
		internal new const string CLASSID = "A4E35045-E2D5-4E05-9703-E06B1AB82B56";

		internal new const string CLASSID_Interface = "11A21CBD-0555-4AAD-BF09-0C4E2E8E0F13";

		private string _Expression = null;

		private object _Result = null;

		/// <summary>
		///       表达式文本
		///       </summary>
		[DCPublishAPI]
		public string Expression => _Expression;

		/// <summary>
		///       运算结果
		///       </summary>
		[DCPublishAPI]
		public object Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <param name="expression">表达式文本</param>
		[DCInternal]
		public ElementExpressionEventArgs(XTextElement element, string expression)
			: base(element)
		{
			_Expression = expression;
		}
	}
}
