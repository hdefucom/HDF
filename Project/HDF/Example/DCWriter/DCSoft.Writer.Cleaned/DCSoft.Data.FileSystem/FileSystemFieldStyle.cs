using System.Runtime.InteropServices;

namespace DCSoft.Data.FileSystem
{
	                                                                    /// <summary>
	                                                                    ///       文件系统数据读取器支持的字段类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public enum FileSystemFieldStyle
	{
		                                                                    /// <summary>
		                                                                    ///       无效字段
		                                                                    ///       </summary>
		None,
		                                                                    /// <summary>
		                                                                    ///       文件名
		                                                                    ///       </summary>
		Name,
		                                                                    /// <summary>
		                                                                    ///       文件全路径名
		                                                                    ///       </summary>
		FullName,
		                                                                    /// <summary>
		                                                                    ///       文件扩展名
		                                                                    ///       </summary>
		Extension,
		                                                                    /// <summary>
		                                                                    ///       无目录和扩展名的简单文件名
		                                                                    ///       </summary>
		SimpleName,
		                                                                    /// <summary>
		                                                                    ///       文件属性
		                                                                    ///       </summary>
		Attributes,
		                                                                    /// <summary>
		                                                                    ///       经过格式化处理的文件属性说明
		                                                                    ///       </summary>
		FormatedAttributes,
		                                                                    /// <summary>
		                                                                    ///       文件大小,单位字节
		                                                                    ///       </summary>
		Size,
		                                                                    /// <summary>
		                                                                    ///       经过格式化处理的文件大小,其样式和资源管理器中的文件大小一样
		                                                                    ///       </summary>
		FormatedSize,
		                                                                    /// <summary>
		                                                                    ///       文件创建时间
		                                                                    ///       </summary>
		CreationTime,
		                                                                    /// <summary>
		                                                                    ///       最后访问时间
		                                                                    ///       </summary>
		AccessTime,
		                                                                    /// <summary>
		                                                                    ///       最后修改时间
		                                                                    ///       </summary>
		ModifiedTime,
		                                                                    /// <summary>
		                                                                    ///       文件类型说明
		                                                                    ///       </summary>
		FileTypeDesc,
		                                                                    /// <summary>
		                                                                    ///       对象类型,若返回"D"表示文件夹,若返回"F"表示为一个文件
		                                                                    ///       </summary>
		Type,
		                                                                    /// <summary>
		                                                                    ///       图标来源
		                                                                    ///       </summary>
		Icon,
		                                                                    /// <summary>
		                                                                    ///       文件内容类型
		                                                                    ///       </summary>
		ContentType,
		                                                                    /// <summary>
		                                                                    ///       文件内容的MD5编码
		                                                                    ///       </summary>
		MD5,
		                                                                    /// <summary>
		                                                                    ///       记录的从0开始的序号
		                                                                    ///       </summary>
		Index,
		                                                                    /// <summary>
		                                                                    ///       文件二进制内容
		                                                                    ///       </summary>
		Content,
		                                                                    /// <summary>
		                                                                    ///       文件文本内容
		                                                                    ///       </summary>
		Text,
		                                                                    /// <summary>
		                                                                    ///       以ANSI编码格式获得的文本内容
		                                                                    ///       </summary>
		ANSIText,
		                                                                    /// <summary>
		                                                                    ///       以Gb2312编码格式获得的文本内容
		                                                                    ///       </summary>
		GB2312Text,
		                                                                    /// <summary>
		                                                                    ///       以UTF8编码格式获得的文本内容
		                                                                    ///       </summary>
		UTF8Text,
		                                                                    /// <summary>
		                                                                    ///       以UNICODE编码获得的文本内容
		                                                                    ///       </summary>
		UnicodeText
	}
}
