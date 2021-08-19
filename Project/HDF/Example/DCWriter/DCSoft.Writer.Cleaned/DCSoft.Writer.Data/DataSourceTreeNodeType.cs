using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	[ComVisible(false)]
	public enum DataSourceTreeNodeType
	{
		/// <summary>
		///       普通文本节点
		///       </summary>
		Text,
		/// <summary>
		///       XML文档格式
		///       </summary>
		Xml,
		/// <summary>
		///       实体对象实例
		///       </summary>
		Entry,
		/// <summary>
		///       数据表
		///       </summary>
		DataTable,
		/// <summary>
		///       字典
		///       </summary>
		Dictionary,
		/// <summary>
		///       对象列表
		///       </summary>
		List,
		/// <summary>
		///       自动检测
		///       </summary>
		Auto
	}
}
