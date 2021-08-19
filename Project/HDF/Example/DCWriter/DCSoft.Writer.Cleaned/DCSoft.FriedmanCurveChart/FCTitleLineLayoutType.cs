using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       标题行内容布局方式
	///       </summary>
	[Guid("6B783EA2-5C64-45B1-8D07-FC96266DEAD5")]
	[ComVisible(true)]
	[DocumentComment]
	public enum FCTitleLineLayoutType
	{
		/// <summary>
		///       普通布局模式
		///       </summary>
		Normal,
		/// <summary>
		///       自由布局模式
		///       </summary>
		Free,
		/// <summary>
		///       自由布局的文本
		///       </summary>
		FreeText,
		/// <summary>
		///       叠加布局模式
		///       </summary>
		Cascade,
		/// <summary>
		///       水平层叠布局模式
		///       </summary>
		HorizCascade,
		/// <summary>
		///       自动叠加布局模式
		///       </summary>
		AutoCascade,
		/// <summary>
		///       斜线
		///       </summary>
		Slant,
		/// <summary>
		///       斜线2
		///       </summary>
		Slant2,
		/// <summary>
		///       斜线2
		///       </summary>
		Slant3
	}
}
