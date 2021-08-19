using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       设置获得自定义属性的接口
	///       </summary>
	[DCPublishAPI]
	[ComVisible(false)]
	public interface IGetSetAttribute
	{
		/// <summary>
		///       获得自定义属性值
		///       </summary>
		/// <param name="attrName">属性名</param>
		/// <returns>获得的属性值</returns>
		[DCPublishAPI]
		string GetAttribute(string attrName);

		/// <summary>
		///       设置自定义属性值
		///       </summary>
		/// <param name="attrName">属性名</param>
		/// <param name="attrValue">属性值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		bool SetAttribute(string attrName, string attrValue);
	}
}
