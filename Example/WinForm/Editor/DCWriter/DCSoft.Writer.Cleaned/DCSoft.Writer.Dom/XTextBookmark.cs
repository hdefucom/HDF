using DCSoft.Common;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       书签对象
	///       </summary>
	[Serializable]
	[XmlType("XBookMark")]
	[DCInternal]
	[ComVisible(false)]
	public class XTextBookmark : XTextElement
	{
		private string string_3 = null;

		/// <summary>
		///       对象名称
		///       </summary>
		public string Name
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			int num = 18;
			if (args.Style == DocumentEventStyles.MouseMove)
			{
				args.Cursor = Cursors.Arrow;
				args.Tooltip = "Bookmark \"" + string_3 + "\"";
			}
			base.HandleDocumentEvent(args);
		}

		/// <summary>
		///       激活书签
		///       </summary>
		public void Active()
		{
			RectangleF absBounds = AbsBounds;
			if (OwnerDocument.EditorControl != null)
			{
				OwnerDocument.Content.AutoClearSelection = true;
				OwnerDocument.Content.MoveToElement(this);
				OwnerDocument.EditorControl.InnerViewControl.method_31((int)absBounds.Left, (int)absBounds.Top, (int)absBounds.Width, (int)absBounds.Height, ScrollToViewStyle.Middle);
			}
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			gclass103_0.method_42(Name);
			gclass103_0.method_43(Name);
		}
	}
}
