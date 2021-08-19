using DCSoft.Common;
using DCSoft.WinForms.Native;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       工具箱控件
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ToolboxItem(false)]
	[DocumentComment]
	[ComVisible(false)]
	public class DCToolBoxControl : UserControl
	{
		private ImageList _ImageList = null;

		private DCToolBoxTabList _Tabs = new DCToolBoxTabList();

		private int _ItemHeight = 0;

		private int _runtimeItemHeight = -1;

		private DCToolBoxItem _SelectedItem = null;

		private DCToolBoxItem _HoverItem = null;

		/// <summary>
		///       图标图片列表
		///       </summary>
		[DefaultValue(null)]
		public ImageList ImageList
		{
			get
			{
				return _ImageList;
			}
			set
			{
				_ImageList = value;
			}
		}

		/// <summary>
		///       分组对象列表
		///       </summary>
		[Category("Data")]
		[DefaultValue(null)]
		public DCToolBoxTabList Tabs
		{
			get
			{
				if (_Tabs == null)
				{
					_Tabs = new DCToolBoxTabList();
				}
				return _Tabs;
			}
			set
			{
				_Tabs = value;
			}
		}

		/// <summary>
		///       列表项目高度,为0表示自动计算高度
		///       </summary>
		[DefaultValue(0)]
		public int ItemHeight
		{
			get
			{
				return _ItemHeight;
			}
			set
			{
				_ItemHeight = value;
				_runtimeItemHeight = _ItemHeight;
			}
		}

		private int RuntimeItemHeight
		{
			get
			{
				if (_runtimeItemHeight <= 0)
				{
					using (Graphics graphics = CreateGraphics())
					{
						_runtimeItemHeight = (int)((double)Font.GetHeight(graphics) * 1.4);
					}
				}
				return _runtimeItemHeight;
			}
		}

		/// <summary>
		///       当前被选中的项目
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCToolBoxItem SelectedItem
		{
			get
			{
				return _SelectedItem;
			}
			set
			{
				if (_SelectedItem == value)
				{
					return;
				}
				DCToolBoxTab dCToolBoxTab = null;
				if (_SelectedItem != null)
				{
					Invalidate(_SelectedItem);
					dCToolBoxTab = GetOwnerTab(_SelectedItem);
				}
				DCToolBoxTab dCToolBoxTab2 = null;
				_SelectedItem = value;
				if (_SelectedItem != null)
				{
					Invalidate(_SelectedItem);
					dCToolBoxTab2 = GetOwnerTab(_SelectedItem);
				}
				if (dCToolBoxTab != dCToolBoxTab2)
				{
					if (dCToolBoxTab != null)
					{
						Invalidate(dCToolBoxTab, titleOnly: true);
					}
					if (dCToolBoxTab2 != null)
					{
						Invalidate(dCToolBoxTab2, titleOnly: true);
					}
				}
			}
		}

		/// <summary>
		///       鼠标悬停的项目
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCToolBoxItem HoverItem
		{
			get
			{
				return _HoverItem;
			}
			set
			{
				if (_HoverItem != value)
				{
					if (_HoverItem != null)
					{
						Invalidate(_HoverItem);
					}
					_HoverItem = value;
					if (_HoverItem != null)
					{
						Invalidate(_HoverItem);
					}
				}
			}
		}

		/// <summary>
		///       获得工具箱项目拖拽的数据事件
		///       </summary>
		public event DCToolBoxGetItemDragDataEventHandler GetItemDragData = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCToolBoxControl()
		{
			AutoScroll = true;
		}

		private int GetImageIndex(int imageIndex, string imageKey)
		{
			if (_ImageList != null)
			{
				if (imageIndex >= 0 && imageIndex < _ImageList.Images.Count)
				{
					return imageIndex;
				}
				if (!string.IsNullOrEmpty(imageKey))
				{
					return _ImageList.Images.IndexOfKey(imageKey);
				}
			}
			return -1;
		}

		public void Invalidate(DCToolBoxTab dctoolBoxTab_0, bool titleOnly)
		{
			int num = 12;
			if (dctoolBoxTab_0 == null)
			{
				throw new ArgumentNullException("tab");
			}
			if (!base.IsHandleCreated || !base.Visible)
			{
				return;
			}
			Rectangle tabTitleBounds = GetTabTitleBounds(dctoolBoxTab_0);
			if (!tabTitleBounds.IsEmpty)
			{
				if (!titleOnly && dctoolBoxTab_0.Expened && dctoolBoxTab_0.Items.Count > 0)
				{
					tabTitleBounds.Height = RuntimeItemHeight * (dctoolBoxTab_0.Items.Count + 1);
				}
				Invalidate(tabTitleBounds);
			}
		}

		public void Invalidate(DCToolBoxItem item)
		{
			int num = 19;
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (base.IsHandleCreated && base.Visible)
			{
				Rectangle toolBoxItemBounds = GetToolBoxItemBounds(item);
				if (!toolBoxItemBounds.IsEmpty)
				{
					Invalidate(toolBoxItemBounds);
				}
			}
		}

		/// <summary>
		///       触发GetItemDragData事件
		///       </summary>
		/// <param name="args">参数</param>
		protected virtual void OnGetItemDragData(DCToolBoxGetItemDragDataEventArgs args)
		{
			if (this.GetItemDragData != null)
			{
				this.GetItemDragData(this, args);
			}
		}

		/// <summary>
		///       处理鼠标按键按下事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (mevent.Button != MouseButtons.Left)
			{
				return;
			}
			object objectAt = GetObjectAt(mevent.X, mevent.Y);
			DCToolBoxTab dCToolBoxTab;
			if (objectAt is DCToolBoxItem)
			{
				SelectedItem = (DCToolBoxItem)objectAt;
			}
			else if (objectAt is DCToolBoxTab)
			{
				dCToolBoxTab = (DCToolBoxTab)objectAt;
				dCToolBoxTab.Expened = !dCToolBoxTab.Expened;
				UpdateViewState();
				Invalidate();
				return;
			}
			if (SelectedItem == null || !MouseCapturer.DragDetect(base.Handle))
			{
				return;
			}
			dCToolBoxTab = GetOwnerTab(SelectedItem);
			DCToolBoxGetItemDragDataEventArgs dCToolBoxGetItemDragDataEventArgs = new DCToolBoxGetItemDragDataEventArgs(dCToolBoxTab, SelectedItem);
			OnGetItemDragData(dCToolBoxGetItemDragDataEventArgs);
			if (dCToolBoxGetItemDragDataEventArgs.Cancel)
			{
				return;
			}
			DataObject dataObject = dCToolBoxGetItemDragDataEventArgs.DataObject;
			if (dataObject == null)
			{
				dataObject = new DataObject();
				object obj = SelectedItem.Value;
				if (obj == null)
				{
					obj = (string.IsNullOrEmpty(SelectedItem.TextValue) ? ((object)SelectedItem) : ((object)SelectedItem.TextValue));
				}
				if (!string.IsNullOrEmpty(SelectedItem.DataFormat))
				{
					dataObject.SetData(SelectedItem.DataFormat, obj);
				}
				else if (!string.IsNullOrEmpty(dCToolBoxTab.DefaultDataFormat))
				{
					dataObject.SetData(dCToolBoxTab.DefaultDataFormat, obj);
				}
				else
				{
					dataObject.SetData(obj);
				}
			}
			DoDragDrop(dataObject, DragDropEffects.Copy);
		}

		/// <summary>
		///       处理鼠标离开事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			base.OnMouseLeave(eventArgs_0);
			HoverItem = null;
		}

		/// <summary>
		///       处理鼠标移动事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			base.OnMouseMove(mevent);
			if (mevent.Button == MouseButtons.None)
			{
				object objectAt = GetObjectAt(mevent.X, mevent.Y);
				HoverItem = (objectAt as DCToolBoxItem);
			}
		}

		public Rectangle GetTabTitleBounds(DCToolBoxTab dctoolBoxTab_0)
		{
			if (dctoolBoxTab_0 == null)
			{
				return Rectangle.Empty;
			}
			Rectangle result = new Rectangle(0, base.AutoScrollPosition.Y, base.ClientSize.Width, RuntimeItemHeight);
			foreach (DCToolBoxTab tab in Tabs)
			{
				if (tab == dctoolBoxTab_0)
				{
					break;
				}
				result.Offset(0, RuntimeItemHeight);
				if (tab.Expened && tab.Items != null && tab.Items.Count > 0)
				{
					result.Offset(0, RuntimeItemHeight * tab.Items.Count);
				}
			}
			return result;
		}

		private Rectangle GetToolBoxItemBounds(DCToolBoxItem item)
		{
			int num = 19;
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			foreach (DCToolBoxTab tab in Tabs)
			{
				if (tab.Items != null && tab.Items.Contains(item))
				{
					if (tab.Expened)
					{
						Rectangle tabTitleBounds = GetTabTitleBounds(tab);
						int num2 = tab.Items.IndexOf(item);
						tabTitleBounds.Offset(0, RuntimeItemHeight * num2 + tabTitleBounds.Height);
						return tabTitleBounds;
					}
					return Rectangle.Empty;
				}
			}
			return Rectangle.Empty;
		}

		/// <summary>
		///       获得列表项目所属的分组对象
		///       </summary>
		/// <param name="item">
		/// </param>
		/// <returns>
		/// </returns>
		private DCToolBoxTab GetOwnerTab(DCToolBoxItem item)
		{
			foreach (DCToolBoxTab tab in Tabs)
			{
				if (tab.Items.Contains(item))
				{
					return tab;
				}
			}
			return null;
		}

		/// <summary>
		///       获得用户界面中指定点处的对象
		///       </summary>
		/// <param name="x">指定点X坐标</param>
		/// <param name="y">指定点Y坐标</param>
		/// <returns>获得的对象，可以为DCToolBoxTab或DCToolBoxItem对象，若为找到则返回空引用</returns>
		private object GetObjectAt(int int_0, int int_1)
		{
			if (Tabs.Count == 0)
			{
				return null;
			}
			Rectangle tabTitleBounds = GetTabTitleBounds(Tabs[0]);
			foreach (DCToolBoxTab tab in Tabs)
			{
				if (tabTitleBounds.Contains(int_0, int_1))
				{
					return tab;
				}
				if (tab.Expened && tab.Items != null && tab.Items.Count > 0)
				{
					int num = int_1 - tabTitleBounds.Bottom;
					int num2 = (int)Math.Floor((double)num / (double)RuntimeItemHeight);
					if (num2 >= 0 && num2 < tab.Items.Count)
					{
						return tab.Items[num2];
					}
					tabTitleBounds.Offset(0, RuntimeItemHeight * (tab.Items.Count + 1));
				}
				else
				{
					tabTitleBounds.Offset(0, RuntimeItemHeight);
				}
			}
			return null;
		}

		/// <summary>
		///       绘制用户界面
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnPaint(PaintEventArgs pevent)
		{
			int num = 10;
			Rectangle rect = new Rectangle(0, base.AutoScrollPosition.Y, base.ClientSize.Width, RuntimeItemHeight);
			foreach (DCToolBoxTab tab in Tabs)
			{
				if (pevent.ClipRectangle.IntersectsWith(rect))
				{
					string title = tab.Title;
					title = ((!tab.Expened) ? ("+ " + title) : ("- " + title));
					bool flag = tab.Items != null && tab.Items.Contains(SelectedItem);
					Rectangle rectangle = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
					pevent.Graphics.FillRectangle(SystemBrushes.Control, rectangle);
					DrawItem(pevent.Graphics, rectangle, title, tab.Image, tab.ImageIndex, tab.ImageKey);
					pevent.Graphics.DrawRectangle(flag ? Pens.DarkOrange : Pens.SkyBlue, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				}
				if (tab.Expened && tab.Items.Count > 0)
				{
					Rectangle rect2 = new Rectangle(rect.Left, rect.Bottom, rect.Width, RuntimeItemHeight);
					foreach (DCToolBoxItem item in tab.Items)
					{
						if (pevent.ClipRectangle.IntersectsWith(rect2))
						{
							Rectangle rectangle2 = new Rectangle(rect2.Left + 16, rect2.Top + 1, rect2.Width - 17, rect2.Height - 2);
							bool flag2;
							if (flag2 = (item == SelectedItem || HoverItem == item))
							{
								pevent.Graphics.FillRectangle(SystemBrushes.Info, rectangle2);
							}
							DrawItem(pevent.Graphics, rectangle2, item.Text, item.Image, item.ImageIndex, item.ImageKey);
							if (flag2)
							{
								pevent.Graphics.DrawRectangle(Pens.DarkOrange, rectangle2);
							}
						}
						rect2.Offset(0, RuntimeItemHeight);
					}
					rect.Y = rect2.Bottom - RuntimeItemHeight;
				}
				else
				{
					rect.Offset(0, RuntimeItemHeight);
				}
			}
			base.OnPaint(pevent);
		}

		private void DrawItem(Graphics graphics_0, Rectangle bounds, string text, Image image_0, int imageIndex, string imageKey)
		{
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
				stringFormat.Trimming = StringTrimming.EllipsisCharacter;
				Rectangle rect = new Rectangle(bounds.Left, bounds.Top + (bounds.Height - 16) / 2, 16, 16);
				if (image_0 != null)
				{
					graphics_0.DrawImage(image_0, rect);
				}
				else
				{
					int imageIndex2 = GetImageIndex(imageIndex, imageKey);
					if (imageIndex2 >= 0)
					{
						ImageList.Draw(graphics_0, rect.Left, rect.Top, rect.Width, rect.Height, imageIndex2);
					}
				}
				graphics_0.DrawString(text, Font, SystemBrushes.ControlText, new RectangleF(rect.Right, bounds.Top, bounds.Right - rect.Right, bounds.Height), stringFormat);
			}
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			if (base.IsHandleCreated)
			{
				UpdateViewState();
			}
		}

		/// <summary>
		///       更新视图状态
		///       </summary>
		public void UpdateViewState()
		{
			int num = Tabs.Count * RuntimeItemHeight;
			foreach (DCToolBoxTab tab in Tabs)
			{
				if (tab.Expened && tab.Items.Count > 0)
				{
					num += tab.Items.Count * RuntimeItemHeight;
				}
			}
			base.AutoScrollMinSize = new Size(10, num);
			Invalidate();
		}
	}
}
