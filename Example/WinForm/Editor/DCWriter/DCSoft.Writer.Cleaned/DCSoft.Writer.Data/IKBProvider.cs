using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识库提供者对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[Guid("00012345-6789-ABCD-EF01-234567890024")]
	
	[ComVisible(false)]
	public interface IKBProvider
	{
		/// <summary>
		///       获得子条目列表
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <param name="root">根节点对象,若为空表示获得根项目列表</param>
		/// <returns>获得的子条目列表</returns>
		KBEntryList GetSubEntries(WriterAppHost host, KBEntry root);

		/// <summary>
		///       根据知识库条目创建文档元素对象
		///       </summary>
		/// <param name="args">参数</param>
		void CreateElements(CreateElementsByKBEntryEventArgs args);
	}
}
