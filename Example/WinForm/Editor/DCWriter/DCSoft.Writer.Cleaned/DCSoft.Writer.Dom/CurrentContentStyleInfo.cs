using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档内容当前样式信息对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComClass("A89F9DB2-E6BA-4B1E-BF50-17CC9C1D12E4", "C44F242D-633B-46AF-94A6-B307DE070939")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(ICurrentContentStyleInfo))]
	
	
	[Guid("A89F9DB2-E6BA-4B1E-BF50-17CC9C1D12E4")]
	public class CurrentContentStyleInfo : ICurrentContentStyleInfo
	{
		internal const string string_0 = "A89F9DB2-E6BA-4B1E-BF50-17CC9C1D12E4";

		internal const string string_1 = "C44F242D-633B-46AF-94A6-B307DE070939";

		private DocumentContentStyle documentContentStyle_0 = null;

		private DocumentContentStyle documentContentStyle_1 = null;

		private DocumentContentStyle documentContentStyle_2 = null;

		private DocumentContentStyle documentContentStyle_3 = null;

		/// <summary>
		///       当前文档内容样式
		///       </summary>
		public DocumentContentStyle Content
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

		/// <summary>
		///       为新增文本而使用的文档内容样式
		///       </summary>
		public DocumentContentStyle ContentStyleForNewString
		{
			get
			{
				return documentContentStyle_1;
			}
			set
			{
				documentContentStyle_1 = value;
			}
		}

		/// <summary>
		///       当前段落样式
		///       </summary>
		public DocumentContentStyle Paragraph
		{
			get
			{
				return documentContentStyle_2;
			}
			set
			{
				documentContentStyle_2 = value;
			}
		}

		/// <summary>
		///       当前单元格样式
		///       </summary>
		public DocumentContentStyle Cell
		{
			get
			{
				return documentContentStyle_3;
			}
			set
			{
				documentContentStyle_3 = value;
			}
		}

		internal void method_0(XTextDocument xtextDocument_0)
		{
			if (documentContentStyle_0 == null)
			{
				documentContentStyle_0 = (DocumentContentStyle)xtextDocument_0.InternalCurrentStyle.Clone();
				documentContentStyle_0.ValueLocked = false;
				if (xtextDocument_0.CurrentStyleElement is XTextHorizontalLineElement)
				{
					documentContentStyle_0.Color = Color.Black;
				}
				documentContentStyle_0.LayoutAlign = ContentLayoutAlign.EmbedInText;
				documentContentStyle_0.ProtectType = ContentProtectType.None;
				documentContentStyle_0.Visibility = RenderVisibility.All;
				XTextElement xTextElement = xtextDocument_0.Content.SafeGet(xtextDocument_0.Selection.AbsStartIndex - 1);
				XTextElement xTextElement2 = xtextDocument_0.Content.SafeGet(xtextDocument_0.Selection.AbsEndIndex);
				if (documentContentStyle_0.CommentIndex >= 0)
				{
					if (xTextElement != null && xTextElement.RuntimeStyle.CommentIndex < 0)
					{
						documentContentStyle_0.CommentIndex = -1;
					}
					if (xTextElement2 != null && xTextElement2.RuntimeStyle.CommentIndex < 0)
					{
						documentContentStyle_0.CommentIndex = -1;
					}
				}
			}
			ContentStyleForNewString = (DocumentContentStyle)documentContentStyle_0.Clone();
			if (xtextDocument_0.CurrentStyleElement is XTextObjectElement)
			{
				ContentStyleForNewString.Color = xtextDocument_0.DefaultStyle.Color;
				ContentStyleForNewString.BackgroundColor = xtextDocument_0.DefaultStyle.BackgroundColor;
			}
			if (documentContentStyle_0.HasVisibleBorder)
			{
				XTextElement currentStyleElement = xtextDocument_0.CurrentStyleElement;
				if (!(currentStyleElement is XTextCharElement))
				{
					XTextElement nextElement = xtextDocument_0.Content.GetNextElement(currentStyleElement);
					if (nextElement == null || !(nextElement is XTextCharElement) || !nextElement.RuntimeStyle.HasVisibleBorder)
					{
						documentContentStyle_1.BorderLeft = false;
						documentContentStyle_1.BorderTop = false;
						documentContentStyle_1.BorderRight = false;
						documentContentStyle_1.BorderBottom = false;
						documentContentStyle_1.BorderWidth = 0f;
						documentContentStyle_1.BorderColor = Color.Black;
					}
				}
			}
			documentContentStyle_0.DisableDefaultValue = true;
			documentContentStyle_0.CreatorIndex = -1;
			documentContentStyle_0.DeleterIndex = -1;
			documentContentStyle_1.DisableDefaultValue = true;
			documentContentStyle_1.CreatorIndex = -1;
			documentContentStyle_1.DeleterIndex = -1;
			method_1(xtextDocument_0);
			XTextTableCellElement currentTableCell = xtextDocument_0.CurrentTableCell;
			if (currentTableCell == null)
			{
				documentContentStyle_3 = null;
			}
			else
			{
				documentContentStyle_3 = currentTableCell.RuntimeStyle.CloneParent();
				documentContentStyle_3.ValueLocked = false;
				documentContentStyle_3.LayoutAlign = ContentLayoutAlign.EmbedInText;
				documentContentStyle_3.ProtectType = ContentProtectType.None;
				documentContentStyle_3.CreatorIndex = -1;
				documentContentStyle_3.DeleterIndex = -1;
				documentContentStyle_3.ValueLocked = true;
			}
			if (documentContentStyle_3 != null)
			{
				documentContentStyle_3.ValueLocked = false;
			}
			if (documentContentStyle_0 != null)
			{
				documentContentStyle_0.ValueLocked = false;
			}
			if (documentContentStyle_1 != null)
			{
				documentContentStyle_1.ValueLocked = false;
			}
			if (documentContentStyle_2 != null)
			{
				documentContentStyle_2.ValueLocked = false;
			}
		}

		internal void method_1(XTextDocument xtextDocument_0)
		{
			if (xtextDocument_0.CurrentParagraphEOF == null)
			{
				documentContentStyle_2 = new DocumentContentStyle();
				return;
			}
			documentContentStyle_2 = xtextDocument_0.CurrentParagraphEOF.RuntimeStyle.CloneParent();
			documentContentStyle_2.ValueLocked = false;
			documentContentStyle_2.LayoutAlign = ContentLayoutAlign.EmbedInText;
			documentContentStyle_2.ProtectType = ContentProtectType.None;
			documentContentStyle_2.Visibility = RenderVisibility.All;
			documentContentStyle_2.TitleLevel = -1;
			documentContentStyle_2.CreatorIndex = -1;
			documentContentStyle_2.DeleterIndex = -1;
			documentContentStyle_2.ValueLocked = true;
		}

		public CurrentContentStyleInfo method_2()
		{
			CurrentContentStyleInfo currentContentStyleInfo = new CurrentContentStyleInfo();
			if (documentContentStyle_3 != null)
			{
				currentContentStyleInfo.documentContentStyle_3 = (DocumentContentStyle)documentContentStyle_3.Clone();
			}
			if (documentContentStyle_0 != null)
			{
				currentContentStyleInfo.documentContentStyle_0 = (DocumentContentStyle)documentContentStyle_0.Clone();
			}
			if (documentContentStyle_2 != null)
			{
				currentContentStyleInfo.documentContentStyle_2 = (DocumentContentStyle)documentContentStyle_2.Clone();
			}
			if (documentContentStyle_1 != null)
			{
				currentContentStyleInfo.ContentStyleForNewString = (DocumentContentStyle)ContentStyleForNewString.Clone();
			}
			return currentContentStyleInfo;
		}
	}
}
