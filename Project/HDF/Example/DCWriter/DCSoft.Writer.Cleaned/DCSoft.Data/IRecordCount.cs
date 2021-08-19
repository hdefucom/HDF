using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       支持获得记录个数
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public interface IRecordCount
	{
		                                                                    /// <summary>
		                                                                    ///       记录个数
		                                                                    ///       </summary>
		int RecordCount
		{
			get;
		}
	}
}
