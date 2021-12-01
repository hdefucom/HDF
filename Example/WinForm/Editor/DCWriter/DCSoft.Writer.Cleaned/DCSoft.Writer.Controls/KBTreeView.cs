using DCSoft.Common;
using DCSoft.Data;
using DCSoft.WinForms.Native;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       知识库树状列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DCPublishAPI]
	[Guid("418A0596-D023-4638-8F12-C177FF5A872A")]
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class KBTreeView : TreeView
	{
		private bool _AllowDragContent = true;

		private KBLibrary _KBLibrary = null;

		/// <summary>
		///       允许拖拽知识节点内容
		///       </summary>
		[DefaultValue(true)]
		public bool AllowDragContent
		{
			get
			{
				return _AllowDragContent;
			}
			set
			{
				_AllowDragContent = value;
			}
		}

		/// <summary>
		///       使用的知识库对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public KBLibrary KBLibrary
		{
			get
			{
				return _KBLibrary;
			}
			set
			{
				_KBLibrary = value;
			}
		}

		/// <summary>
		///       加载知识库
		///       </summary>
		/// <param name="url">
		/// </param>
		/// <returns>
		/// </returns>
		public bool LoadKBLibrary(string string_0)
		{
			KBLibrary kBLibrary = new KBLibrary();
			UrlStream urlStream = UrlStream.smethod_0(string_0);
			if (urlStream != null)
			{
				using (urlStream)
				{
					kBLibrary.Load(urlStream);
					kBLibrary.BaseURL = GClass334.smethod_1(string_0);
					KBLibrary = kBLibrary;
					RefreshView();
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       刷新列表
		///       </summary>
		/// <returns>
		/// </returns>
		public bool RefreshView()
		{
			if (KBLibrary != null)
			{
				KBLibrary.Fill(this);
				return true;
			}
			return false;
		}

		/// <summary>
		///       鼠标按键按下事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (!AllowDragContent || mevent.Button != MouseButtons.Left)
			{
				return;
			}
			TreeViewHitTestInfo treeViewHitTestInfo = HitTest(mevent.X, mevent.Y);
			if (treeViewHitTestInfo.Location == TreeViewHitTestLocations.Image || treeViewHitTestInfo.Location == TreeViewHitTestLocations.Label)
			{
				base.SelectedNode = treeViewHitTestInfo.Node;
				KBEntry kBEntry = treeViewHitTestInfo.Node.Tag as KBEntry;
				if (kBEntry != null && (kBEntry.Style != 0 || kBEntry.SubEntries == null || kBEntry.SubEntries.Count <= 0) && MouseCapturer.DragDetect(base.Handle))
				{
					DoDragDrop(treeViewHitTestInfo.Node.Tag, DragDropEffects.Copy);
				}
			}
		}
	}
}
