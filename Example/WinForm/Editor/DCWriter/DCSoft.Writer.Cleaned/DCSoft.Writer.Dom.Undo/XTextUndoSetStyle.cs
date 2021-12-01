namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       设置元素样式的重复/撤销操作对象
	///       </summary>
	internal class XTextUndoSetStyle : XTextUndoBase
	{
		private XTextElement xtextElement_0 = null;

		private DocumentContentStyle documentContentStyle_0 = null;

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

		public DocumentContentStyle NewStyle
		{
			get
			{
				return documentContentStyle_0;
			}
			set
			{
				documentContentStyle_0 = value;
			}
		}
	}
}
