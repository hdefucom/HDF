using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       段落列表样式
	///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("004E0478-A0A6-4D1D-9BB1-46A24B1DC567")]
	public enum ParagraphListStyle
	{
		/// <summary>
		///       无样式
		///       </summary>
		None = 0,
		/// <summary>	默认的数字样式。 	</summary>
		ListNumberStyle = 1,
		/// <summary>	阿拉伯 1 型数字样式。 	</summary>
		ListNumberStyleArabic1 = 2,
		/// <summary>	阿拉伯 2 型数字样式。 	</summary>
		ListNumberStyleArabic2 = 3,
		/// <summary>	小写字母样式。 	</summary>
		ListNumberStyleLowercaseLetter = 4,
		/// <summary>	小写罗马样式。 	</summary>
		ListNumberStyleLowercaseRoman = 5,
		/// <summary>	带圈数字样式。 	</summary>
		ListNumberStyleNumberInCircle = 6,
		/// <summary>	简体中文数字 1 样式。 	</summary>
		ListNumberStyleSimpChinNum1 = 7,
		/// <summary>	简体中文数字 2 样式。 	</summary>
		ListNumberStyleSimpChinNum2 = 8,
		/// <summary>	繁体中文数字 1 样式。 	</summary>
		ListNumberStyleTradChinNum1 = 9,
		/// <summary>	繁体中文数字 2 样式。 	</summary>
		ListNumberStyleTradChinNum2 = 10,
		/// <summary>	大写字母样式。 	</summary>
		ListNumberStyleUppercaseLetter = 11,
		/// <summary>	大写罗马样式。 	</summary>
		ListNumberStyleUppercaseRoman = 12,
		/// <summary>	Zodiac 1 样式。 	</summary>
		ListNumberStyleZodiac1 = 13,
		/// <summary>	Zodiac 2 样式。 	</summary>
		ListNumberStyleZodiac2 = 14,
		/// <summary>
		///       圆头列表
		///       </summary>
		BulletedList = 10000,
		/// <summary>
		///       方块列表
		///       </summary>
		BulletedListBlock = 10001,
		/// <summary>
		///       菱形方块列表
		///       </summary>
		BulletedListDiamond = 10002,
		/// <summary>
		///       钩子列表
		///       </summary>
		BulletedListCheck = 10003,
		/// <summary>
		///       向右的箭头列表
		///       </summary>
		BulletedListRightArrow = 10004,
		/// <summary>
		///       空心星列表
		///       </summary>
		BulletedListHollowStar = 10005
	}
}
