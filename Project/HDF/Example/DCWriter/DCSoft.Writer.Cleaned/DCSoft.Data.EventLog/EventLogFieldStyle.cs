using System.Runtime.InteropServices;

namespace DCSoft.Data.EventLog
{
	                                                                    /// <summary>
	                                                                    ///       系统事件数据读取器字段类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public enum EventLogFieldStyle
	{
		                                                                    /// <summary>
		                                                                    ///       无样式
		                                                                    ///       </summary>
		None,
		                                                                    /// <summary>
		                                                                    ///        获取与该项的 System.Diagnostics.EventLogEntry.CategoryNumber 关联的文本。  
		                                                                    ///       </summary>
		Category,
		                                                                    /// <summary>
		                                                                    ///        获取该项的类别号。  
		                                                                    ///       </summary>
		CategoryNumber,
		                                                                    /// <summary>
		                                                                    ///        获取与该项关联的二进制数据。 
		                                                                    ///       </summary>
		Data,
		                                                                    /// <summary>
		                                                                    ///        获取该项的事件类型。  
		                                                                    ///       </summary>
		EntryType,
		                                                                    /// <summary>
		                                                                    ///        获取该项在事件日志中的索引。  
		                                                                    ///       </summary>
		Index,
		                                                                    /// <summary>
		                                                                    ///        获取在其上生成该项的计算机的名称。 
		                                                                    ///       </summary>
		MachineName,
		                                                                    /// <summary>
		                                                                    ///        获取与该事件项关联的本地化消息。 
		                                                                    ///       </summary>
		Message,
		                                                                    /// <summary>
		                                                                    ///        获取与该项关联的替换字符串。  
		                                                                    ///       </summary>
		ReplacementStrings,
		                                                                    /// <summary>
		                                                                    ///        获取生成该事件的应用程序的名称。  
		                                                                    ///       </summary>
		Source,
		                                                                    /// <summary>
		                                                                    ///        获取生成该事件的本地时间。  
		                                                                    ///       </summary>
		TimeGenerated,
		                                                                    /// <summary>
		                                                                    ///        获取在日志中写入该事件的本地时间。  
		                                                                    ///       </summary>
		TimeWriten,
		                                                                    /// <summary>
		                                                                    ///        获取负责该事件的用户的名称。  
		                                                                    ///       </summary>
		UserName
	}
}
