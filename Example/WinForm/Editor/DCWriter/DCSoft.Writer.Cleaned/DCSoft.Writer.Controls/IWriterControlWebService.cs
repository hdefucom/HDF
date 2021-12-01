using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.Writer.Data;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       WEB服务对象必须实现的接口
	///       </summary>
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(false)]
	public interface IWriterControlWebService
	{
		/// <summary>
		///       获得所有支持的WEB方法
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		WriterControlWebMethodTypes GetSupportedMethods();

		/// <summary>
		///       获得知识库对象
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		KBLibrary GetKBLibrary();

		/// <summary>
		///       查询列表项目
		///       </summary>
		/// <param name="listSourceName">列表来源名称</param>
		/// <param name="spellCode">拼音码</param>
		/// <param name="preText">前置文本</param>
		/// <param name="specifyValue">指定的数值</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		ListItem[] QueryListItems(string listSourceName, string spellCode, string preText, string specifyValue);

		[DCPublishAPI]
		ListItem[] QueryListItemsWithDocumentParameter(string listSourceName, string spellCode, string preText, string specifyValue, string documentParameters);

		/// <summary>
		///       查询快捷输入的列表项目
		///       </summary>
		/// <param name="preWord">前置文本</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		string[] QueryAssistInputItems(string preWord);

		/// <summary>
		///       保存文件内容
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="fileSystemName">文件系统名称</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="fileContent">文件内容</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		bool SaveFileContent(string fileName, string fileSystemName, string fileFormat, byte[] fileContent);

		/// <summary>
		///       为自动保存功能而保存文件内容
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="fileSystemName">文件系统名称</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="fileContent">文件内容</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		bool SaveFileContentForAutoSave(string fileName, string fileSystemName, string fileFormat, byte[] fileContent);

		/// <summary>
		///       读取文件内容
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="fileSystemName">文件系统名称</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		byte[] ReadFileContent(string fileName, string fileSystemName);

		/// <summary>
		///       开始编辑内容
		///       </summary>
		/// <param name="documentID">文档编号</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		bool UIStartEditContent(string documentID);

		/// <summary>
		///       报错
		///       </summary>
		/// <param name="errorCode">错误代码</param>
		/// <param name="message">错误消息</param>
		/// <param name="details">错误详细信息</param>
		[DCPublishAPI]
		void ReportError(int errorCode, string message, string details);

		/// <summary>
		///       按钮按下
		///       </summary>
		/// <param name="elementID">按钮元素名称</param>
		/// <param name="commandName">按钮绑定的命令名称</param>
		[DCPublishAPI]
		void ButtonClick(string elementID, string commandName);

		/// <summary>
		///       文档打印
		///       </summary>
		/// <param name="documentID">文档编号</param>
		/// <param name="states">打印状态</param>
		/// <param name="printedPages">打印的页数</param>
		/// <param name="message">消息</param>
		[DCPublishAPI]
		void DocumentPrinted(string documentID, PrintResultStates states, int printedPages, string message);

		/// <summary>
		///       准备播放视频
		///       </summary>
		/// <param name="documentID">文档编号</param>
		/// <param name="elementID">文档元素编号</param>
		/// <param name="sourceFileName">视频来源名</param>
		/// <returns>实际播放视频使用的URL</returns>
		[DCPublishAPI]
		string BeforePlayMedia(string documentID, string elementID, string sourceFileName);
	}
}
