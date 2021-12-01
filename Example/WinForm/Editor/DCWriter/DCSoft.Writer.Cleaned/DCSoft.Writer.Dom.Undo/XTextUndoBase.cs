using DCSoftDotfuscate;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       文档撤销操作对象基础类型
	///       </summary>
	[ComVisible(false)]
	public class XTextUndoBase : GInterface1
	{
		/// <summary>
		///       对象所属的文档对象
		///       </summary>
		protected XTextDocument myDocument = null;

		private bool bolInGroup = false;

		/// <summary>
		///       文档对象的撤销操作列表
		///       </summary>
		public XTextDocumentUndoList OwnerList => myDocument.UndoList;

		/// <summary>
		///       对象所属的文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return myDocument;
			}
			set
			{
				myDocument = value;
			}
		}

		/// <summary>
		///       对象名称
		///       </summary>
		public virtual string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       对象是否在一个批处理中
		///       </summary>
		public bool InGroup
		{
			get
			{
				return bolInGroup;
			}
			set
			{
				bolInGroup = value;
			}
		}

		public virtual void Undo(GEventArgs3 args)
		{
		}

		public virtual void Redo(GEventArgs3 args)
		{
		}
	}
}
