using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890194")]
	public interface IValueValidateStyle
	{
		                                                                    /// <summary>
		                                                                    ///       校验等级
		                                                                    ///       </summary>
		ValueValidateLevel Level
		{
			get;
			set;
		}

		                                                                    /// <summary>属性BinaryLength</summary>
		bool BinaryLength
		{
			get;
			set;
		}

		                                                                    /// <summary>
		                                                                    ///       是否检查小数点
		                                                                    ///       </summary>
		bool CheckDecimalDigits
		{
			get;
			set;
		}

		                                                                    /// <summary>
		                                                                    ///       小数最大位数
		                                                                    ///       </summary>
		int MaxDecimalDigits
		{
			get;
			set;
		}

		                                                                    /// <summary>属性CheckMaxValue</summary>
		bool CheckMaxValue
		{
			get;
			set;
		}

		                                                                    /// <summary>属性CheckMinValue</summary>
		bool CheckMinValue
		{
			get;
			set;
		}

		                                                                    /// <summary>属性ContentVersion</summary>
		int ContentVersion
		{
			get;
			set;
		}

		                                                                    /// <summary>属性CustomMessage</summary>
		string CustomMessage
		{
			get;
			set;
		}

		                                                                    /// <summary>属性DateTimeMaxValue</summary>
		DateTime DateTimeMaxValue
		{
			get;
			set;
		}

		                                                                    /// <summary>属性DateTimeMinValue</summary>
		DateTime DateTimeMinValue
		{
			get;
			set;
		}

		                                                                    /// <summary>属性ExcludeKeywords</summary>
		string ExcludeKeywords
		{
			get;
			set;
		}

		                                                                    /// <summary>属性IsEmpty</summary>
		bool IsEmpty
		{
			get;
		}

		                                                                    /// <summary>属性MaxLength</summary>
		int MaxLength
		{
			get;
			set;
		}

		                                                                    /// <summary>属性MaxValue</summary>
		double MaxValue
		{
			get;
			set;
		}

		                                                                    /// <summary>属性Message</summary>
		string Message
		{
			get;
			set;
		}

		                                                                    /// <summary>属性MinLength</summary>
		int MinLength
		{
			get;
			set;
		}

		                                                                    /// <summary>属性MinValue</summary>
		double MinValue
		{
			get;
			set;
		}

		                                                                    /// <summary>属性Range</summary>
		string Range
		{
			get;
			set;
		}

		                                                                    /// <summary>属性RegExpression</summary>
		string RegExpression
		{
			get;
			set;
		}

		                                                                    /// <summary>属性Required</summary>
		bool Required
		{
			get;
			set;
		}

		                                                                    /// <summary>属性ValueName</summary>
		string ValueName
		{
			get;
			set;
		}

		                                                                    /// <summary>属性ValueType</summary>
		ValueTypeStyle ValueType
		{
			get;
			set;
		}
	}
}
