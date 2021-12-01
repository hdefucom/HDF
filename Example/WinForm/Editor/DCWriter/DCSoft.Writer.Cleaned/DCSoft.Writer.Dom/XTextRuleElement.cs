using DCSoft.Common;
using System.ComponentModel;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       标尺元素
	///       </summary>
	[DocumentComment]
	public class XTextRuleElement : XTextObjectElement
	{
		private string string_9 = null;

		private RuleScaleItemList ruleScaleItemList_0 = null;

		/// <summary>
		///       标尺刻度定义字符串
		///       </summary>
		[DefaultValue(null)]
		public string RuleScaleItemString
		{
			get
			{
				return string_9;
			}
			set
			{
				string_9 = value;
			}
		}
	}
}
