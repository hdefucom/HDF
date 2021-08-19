using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       标题行内容布局方式
	///       </summary>
	[Guid("0C6A7CF1-8270-49D6-9708-910DC051FBD4")]
	[DocumentComment]
	[ComVisible(true)]
	public enum TitleLineLayoutType
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
