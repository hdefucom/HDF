using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       为SQL方法提供自定义信息的记录对象接口
	///       </summary>
	
	[ComVisible(false)]
	public interface IDCCustomRecordForSQLMethod
	{
		/// <summary>
		///       设置属性值
		///       </summary>
		/// <param name="propertyName">属性名</param>
		/// <param name="propertyValue">属性值</param>
		/// <returns>操作是否成功</returns>
		bool SetPropertyValue(string propertyName, object propertyValue);

		/// <summary>
		///       获得属性值
		///       </summary>
		/// <param name="propertyName">属性名</param>
		/// <returns>属性值</returns>
		object GetPropertyValue(string propertyName);

		/// <summary>
		///       获得SQL命令文本
		///       </summary>
		/// <param name="methodName">方法名称</param>
		/// <returns>获得的SQL文本</returns>
		string GetSQLCommandText(string methodName);
	}
}
