using DCSoft.Common;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       和文档交互的控件接口
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	
	[ComVisible(false)]
	public interface IDocumentHostedObject
	{
		/// <summary>
		///       加载视图
		///       </summary>
		/// <param name="args">参数</param>
		void LoadViewState(DocumentHostElementEventArgs args);

		/// <summary>
		///       保存视图
		///       </summary>
		/// <param name="args">参数</param>
		void SaveViewState(DocumentHostElementEventArgs args);

		/// <summary>
		///       创建展现控件数据的图片对象
		///       </summary>
		/// <param name="args">参数对象</param>
		/// <returns>获得的图片对象</returns>
		Image CreatePreviewImage(DocumentHostElementEventArgs args);
	}
}
