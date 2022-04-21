using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器控件状态
	///       </summary>
	[ComVisible(true)]
	[Guid("ABE3650A-071D-4F43-A3A9-8BE7C8D06A32")]
	
	public class WriterControlState
	{
		private PageViewMode pageViewMode_0;

		private FormViewMode formViewMode_0;

		private bool bool_0;

		private WriterControl writerControl_0;

		private PageContentPartyStyle pageContentPartyStyle_0;

		private Point point_0;

		private int int_0;

		private int int_1;

		private XTextElement xtextElement_0;

		private XTextElement xtextElement_1;

		private XTextElement xtextElement_2;

		private XTextElement xtextElement_3;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		public WriterControlState(WriterControl writerControl_1)
		{
			int num = 15;
			pageViewMode_0 = PageViewMode.Page;
			formViewMode_0 = FormViewMode.Disable;
			bool_0 = false;
			writerControl_0 = null;
			pageContentPartyStyle_0 = PageContentPartyStyle.Body;
			point_0 = Point.Empty;
			int_0 = 0;
			int_1 = 0;
			xtextElement_0 = null;
			xtextElement_1 = null;
			xtextElement_2 = null;
			xtextElement_3 = null;
			
			if (writerControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			writerControl_0 = writerControl_1;
			formViewMode_0 = writerControl_1.FormView;
			bool_0 = writerControl_1.ReadViewMode;
			pageViewMode_0 = writerControl_1.ViewMode;
			pageContentPartyStyle_0 = writerControl_1.Document.CurrentContentPartyStyle;
			point_0 = writerControl_1.InnerViewControl.AutoScrollPosition;
			int_0 = writerControl_1.Document.Selection.StartIndex;
			int_1 = writerControl_1.Document.Selection.Length;
			if (int_0 >= 0)
			{
				xtextElement_0 = writerControl_1.Document.Content.SafeGet(int_0 - 1);
				xtextElement_1 = writerControl_1.Document.Content.SafeGet(int_0);
			}
			int num2 = int_0 + int_1;
			if (num2 >= 0)
			{
				xtextElement_2 = writerControl_1.Document.Content.SafeGet(num2 - 1);
				xtextElement_3 = writerControl_1.Document.Content.SafeGet(num2);
			}
		}

		/// <summary>
		///       恢复编辑器控件状态
		///       </summary>
		public void Restore()
		{
			writerControl_0.FormView = formViewMode_0;
			writerControl_0.ReadViewMode = bool_0;
			writerControl_0.ViewMode = pageViewMode_0;
			writerControl_0.CurrentContentPartyStyle = pageContentPartyStyle_0;
			writerControl_0.InnerViewControl.SetAutoScrollPosition(new Point(-point_0.X, -point_0.Y));
			int num = -1;
			int num2 = -1;
			if (xtextElement_1 != null)
			{
				num = writerControl_0.Document.Content.IndexOf(xtextElement_1);
			}
			if (num < 0)
			{
				num = writerControl_0.Document.Content.IndexOf(xtextElement_0);
				if (num >= 0)
				{
					num++;
				}
			}
			if (num < 0)
			{
				num = int_0;
			}
			if (xtextElement_3 != null)
			{
				num2 = writerControl_0.Document.Content.IndexOf(xtextElement_3);
			}
			if (num2 < 0)
			{
				num2 = writerControl_0.Document.Content.IndexOf(xtextElement_2);
				if (num2 >= 0)
				{
					num2++;
				}
			}
			int num3 = 0;
			num3 = ((num2 < 0) ? int_1 : (num2 - num));
			writerControl_0.Document.Content.method_47(num, num3);
			writerControl_0.UpdateTextCaretWithoutScroll();
		}
	}
}
