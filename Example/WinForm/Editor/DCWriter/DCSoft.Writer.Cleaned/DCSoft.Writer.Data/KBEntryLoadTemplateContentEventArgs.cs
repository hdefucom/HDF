using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       加载知识库节点模板内容事件参数
	///       </summary>
	[ComDefaultInterface(typeof(IKBEntryLoadTemplateContentEventArgs))]
	[DCPublishAPI]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("589660D3-A76E-4413-97C1-6E9E34336292", "98302397-4E8A-4679-953E-9837FF4C666C")]
	[Guid("589660D3-A76E-4413-97C1-6E9E34336292")]
	[DocumentComment]
	public class KBEntryLoadTemplateContentEventArgs : IKBEntryLoadTemplateContentEventArgs
	{
		internal const string CLASSID = "589660D3-A76E-4413-97C1-6E9E34336292";

		internal const string CLASSID_Interface = "98302397-4E8A-4679-953E-9837FF4C666C";

		private KBEntry _Entry = null;

		private KBLibrary _Library = null;

		private byte[] _Content = null;

		private string _Format = null;

		private bool _Result = false;

		/// <summary>
		///       知识节点
		///       </summary>
		[DCPublishAPI]
		public KBEntry Entry => _Entry;

		/// <summary>
		///       知识库对象
		///       </summary>
		[DCPublishAPI]
		public KBLibrary Library => _Library;

		/// <summary>
		///       文件内容
		///       </summary>
		[DCPublishAPI]
		public byte[] Content
		{
			get
			{
				return _Content;
			}
			set
			{
				_Content = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		[DCPublishAPI]
		public string Format
		{
			get
			{
				return _Format;
			}
			set
			{
				_Format = value;
			}
		}

		/// <summary>
		///       结果
		///       </summary>
		[DCPublishAPI]
		public bool Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="lib">
		/// </param>
		/// <param name="entry">
		/// </param>
		[DCPublishAPI]
		public KBEntryLoadTemplateContentEventArgs(KBLibrary kblibrary_0, KBEntry entry)
		{
			_Library = kblibrary_0;
			_Entry = entry;
		}
	}
}
