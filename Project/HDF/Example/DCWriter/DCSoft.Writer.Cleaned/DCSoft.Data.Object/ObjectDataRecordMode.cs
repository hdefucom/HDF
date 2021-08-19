using System.Runtime.InteropServices;

namespace DCSoft.Data.Object
{
	                                                                    /// <summary>
	                                                                    ///       对象数据记录读取数据的模式
	                                                                    ///       </summary>
	[ComVisible(false)]
	public enum ObjectDataRecordMode
	{
		                                                                    /// <summary>
		                                                                    ///       自动判断模式
		                                                                    ///       </summary>
		Auto,
		                                                                    /// <summary>
		                                                                    ///       数组模式
		                                                                    ///       </summary>
		Array,
		                                                                    /// <summary>
		                                                                    ///       字典模式
		                                                                    ///       </summary>
		Diction,
		                                                                    /// <summary>
		                                                                    ///       指定对象成员属性模式
		                                                                    ///       </summary>
		SpecifyProperty,
		                                                                    /// <summary>
		                                                                    ///       读取对象所有成员属性模式
		                                                                    ///       </summary>
		BothProperty
	}
}
