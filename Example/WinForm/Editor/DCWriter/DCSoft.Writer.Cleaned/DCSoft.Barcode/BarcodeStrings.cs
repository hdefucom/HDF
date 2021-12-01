using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Barcode
{
	                                                                    /// <summary>
	                                                                    ///         一个强类型的资源类，用于查找本地化的字符串等。
	                                                                    ///       </summary>
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class BarcodeStrings
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		                                                                    /// <summary>
		                                                                    ///         返回此类使用的缓存的 ResourceManager 实例。
		                                                                    ///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 9;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Barcode.BarcodeStrings", typeof(BarcodeStrings).Assembly);
				}
				return resourceManager_0;
			}
		}

		                                                                    /// <summary>
		                                                                    ///         使用此强类型资源类，为所有资源查找
		                                                                    ///         重写当前线程的 CurrentUICulture 属性。
		                                                                    ///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return cultureInfo_0;
			}
			set
			{
				cultureInfo_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///         查找类似 Codabar条码长度不得小于3，而且开头和结尾是字符'A'或'B'或'C'或'D'。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string CodabarError => ResourceManager.GetString("CodabarError", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Code11条码只能包含数字和字符'-'。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code11Error => ResourceManager.GetString("Code11Error", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 不能为Code128条码判别起始字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code128CannotDetermineStart => ResourceManager.GetString("Code128CannotDetermineStart", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 不能为Code128条码插入“{0}” 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code128CannotFind_Value => ResourceManager.GetString("Code128CannotFind_Value", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 为Code128条码插入字符错误： 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code128InsertError => ResourceManager.GetString("Code128InsertError", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Code128:错误的数据或格式. 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code128InvaliData => ResourceManager.GetString("Code128InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Code128条码中出现错误的字符“{0}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code128InvalidateCharacter_Value => ResourceManager.GetString("Code128InvalidateCharacter_Value", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 指定格式的Code128条码文本头错误。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code128UnknowStart => ResourceManager.GetString("Code128UnknowStart", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Code39条码数据错误（可尝试Code39Extended条码）。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code39InvaliData => ResourceManager.GetString("Code39InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Code93:错误的数据,包含不支持的字符. 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Code93InvaliData => ResourceManager.GetString("Code93InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 EAN13:错误的国家代码。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string EAN13InvaliCountry => ResourceManager.GetString("EAN13InvaliCountry", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 EAN13条码只能包含12或13个数字字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string EAN13InvaliData => ResourceManager.GetString("EAN13InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 EAN8:错误的数据，只能包含7或8个数字字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string EAN8InvaliData => ResourceManager.GetString("EAN8InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 I25:错误的数据，必须为偶数个数字字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string I25InvaliData => ResourceManager.GetString("I25InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 错误的条码样式. 的本地化字符串。
		                                                                    ///       </summary>
		internal static string InvaliBarcodeStyle => ResourceManager.GetString("InvaliBarcodeStyle", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 ISBN:错误的数据，必须为9，10，12或13个数字，可能需要以“978”开头。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ISBNInvaliData => ResourceManager.GetString("ISBNInvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 JAN13:必须为数字，而且要“49”开头。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string JAN13InvaliData => ResourceManager.GetString("JAN13InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 MSI:必须全部为数字字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string MSIInvaliData => ResourceManager.GetString("MSIInvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Postnet条码文本必须是长度为5、6、9或11的数字。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string PostnetError => ResourceManager.GetString("PostnetError", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 S25:必须全部为数字字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string S25InvaliData => ResourceManager.GetString("S25InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 条码文本不得为空. 的本地化字符串。
		                                                                    ///       </summary>
		internal static string TextMustNotNull => ResourceManager.GetString("TextMustNotNull", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 不支持的条码类型 的本地化字符串。
		                                                                    ///       </summary>
		internal static string UnsupportedStyle => ResourceManager.GetString("UnsupportedStyle", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 UPCA:错误的国家代码。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string UPCAInvaliCountry => ResourceManager.GetString("UPCAInvaliCountry", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 UPCA:必须为12个数字字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string UPCAInvaliData => ResourceManager.GetString("UPCAInvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 UPCE:必须为8或12个数字字符,可能需要以0或1开头。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string UPCEInvaliData => ResourceManager.GetString("UPCEInvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 UPCS2:必须为2个数字。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string UPCS2InvaliData => ResourceManager.GetString("UPCS2InvaliData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 UPCS5:必须为5个数字。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string UPCS5InvaliData => ResourceManager.GetString("UPCS5InvaliData", cultureInfo_0);

		internal BarcodeStrings()
		{
		}
	}
}
