using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       能将对象数据完整的转换为一个字符串
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public interface IDCStringSerializable
	{
		                                                                    /// <summary>
		                                                                    ///       将对象序列化为字符串
		                                                                    ///       </summary>
		                                                                    /// <returns>生成的字符串</returns>
		string DCWriteString();

		                                                                    /// <summary>
		                                                                    ///       从字符串反序列化对象数据
		                                                                    ///       </summary>
		                                                                    /// <param name="text">字符串</param>
		void DCReadString(string text);
	}
}
