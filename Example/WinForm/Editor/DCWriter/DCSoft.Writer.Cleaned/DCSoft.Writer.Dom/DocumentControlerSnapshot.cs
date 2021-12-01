using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       DCWriter内部使用。文档控制状态快照对象
	///       </summary>
	[ComVisible(false)]
	public class DocumentControlerSnapshot
	{
		private DocumentControler documentControler_0 = null;

		private int int_0 = 0;

		private int int_1 = 0;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2 = true;

		/// <summary>
		///       控制器对象
		///       </summary>
		public DocumentControler OwnerControler
		{
			get
			{
				return documentControler_0;
			}
			set
			{
				documentControler_0 = value;
			}
		}

		/// <summary>
		///       文档内容版本号
		///       </summary>
		public int DocumentContentVersion
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       选择区域版本号
		///       </summary>
		public int SelectionVerion
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		/// <summary>
		///       能否删除被选中的内容
		///       </summary>
		public bool CanDeleteSelection
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       能否修改被选中的内容
		///       </summary>
		public bool CanModifySelection
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       能否修改被选中的段落
		///       </summary>
		public bool CanModifyParagraphs
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}
	}
}
