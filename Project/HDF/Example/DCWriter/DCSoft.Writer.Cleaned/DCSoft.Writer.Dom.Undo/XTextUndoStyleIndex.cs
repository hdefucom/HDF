using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       重复/撤销设置元素的样式编号
	///       </summary>
	internal class XTextUndoStyleIndex : XTextUndoBase
	{
		private XTextElement xtextElement_0 = null;

		private int int_0 = -1;

		private int int_1 = -1;

		public XTextElement Element
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
			}
		}

		public int OldStyleIndex
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

		public int NewStyleIndex
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
		///       初始化对象
		///       </summary>
		public XTextUndoStyleIndex()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">操作的文档元素</param>
		/// <param name="oldStyleIndex">旧样式编号</param>
		/// <param name="newStyleIndex">新样式编号</param>
		public XTextUndoStyleIndex(XTextElement xtextElement_1, int int_2, int int_3)
		{
			xtextElement_0 = xtextElement_1;
			int_0 = int_2;
			int_1 = int_3;
		}

		public override void Undo(GEventArgs3 args)
		{
			xtextElement_0.StyleIndex = int_0;
			base.OwnerList.RefreshElements.Add(xtextElement_0);
		}

		public override void Redo(GEventArgs3 args)
		{
			xtextElement_0.StyleIndex = int_1;
			base.OwnerList.RefreshElements.Add(xtextElement_0);
		}
	}
}
