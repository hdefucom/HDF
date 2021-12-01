using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Windows32;

namespace ZYCommon
{
	public class ZYPopupList : Form, IMessageFilter
	{
		public class ListItem
		{
			public int Style = 0;

			public string Text = null;

			public int ImageIndex = -1;

			public bool Selected = false;

			public string ToolTip = null;

			public Color ForeColor = SystemColors.WindowText;

			public Color BackColor = SystemColors.Window;

			public object obj = null;

			public Image Icon = null;

			public string ChineseSpell = null;

			public char ShortCutChar = ' ';

			public ArrayList Items = null;

			public bool HasItems = true;

			public bool Expended = false;

			internal int Left = 0;

			internal int Top = 0;

			public int Height = 0;

			internal int Layer = 0;

			internal ListItem Parent = null;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		protected struct ListItemDrawInfo
		{
		}

		protected ArrayList myItems = new ArrayList();

		protected int intDefaultItemHeight = 14;

		protected int intSelectedIndex = 0;

		private bool bolExitLoop = true;

		private bool bolUserAccept = false;

		protected bool bolMultiSelect = false;

		private int intUpdateLevel = 0;

		protected bool bolShowShortCut = true;

		protected int intLeftMargin = 8;

		protected int intRightMargin = 8;

		protected bool bolAutoClose = true;

		protected Panel pnlList = null;

		protected Label lblSpell = null;

		protected ImageList myImageList = null;

		protected char chrItemSpliter = '、';

		protected int intVisibleItems = 15;

		protected string strTitle = null;

		private int intIndent = 9;

		private bool bolShowExpendHandleRect = true;

		private int InnerExpendHandleRectWidth = 0;

		private int InnerShortCutWidth = 0;

		private int InnserIconWidth = 0;

		private int intViewHeight = 0;

		protected bool bolUserSelecting = false;

		private Message msgBack = default(Message);

		protected Rectangle myCompositionRect = Rectangle.Empty;

		public EventHandler SelectedStateChanged;

		public Rectangle CompositionRect
		{
			get
			{
				return myCompositionRect;
			}
			set
			{
				myCompositionRect = value;
			}
		}

		public bool ShowExpendHandleRect
		{
			get
			{
				return bolShowExpendHandleRect;
			}
			set
			{
				bolShowExpendHandleRect = value;
			}
		}

		public int Indent
		{
			get
			{
				return intIndent;
			}
			set
			{
				intIndent = value;
			}
		}

		public int VisibleItems
		{
			get
			{
				return intVisibleItems;
			}
			set
			{
				intVisibleItems = value;
			}
		}

		public string Title
		{
			get
			{
				return strTitle;
			}
			set
			{
				if (value != null && strTitle != value)
				{
					strTitle = value;
					lblSpell.Text = strTitle;
				}
			}
		}

		public char ItemSpliter
		{
			get
			{
				return chrItemSpliter;
			}
			set
			{
				chrItemSpliter = value;
			}
		}

		public ImageList ImageList
		{
			get
			{
				return myImageList;
			}
			set
			{
				myImageList = value;
			}
		}

		public bool AutoClose
		{
			get
			{
				return bolAutoClose;
			}
			set
			{
				bolAutoClose = value;
			}
		}

		public int LeftMargin
		{
			get
			{
				return intLeftMargin;
			}
			set
			{
				intLeftMargin = value;
			}
		}

		public int RightMargin
		{
			get
			{
				return intRightMargin;
			}
			set
			{
				intRightMargin = value;
			}
		}

		public bool ShowShortCut
		{
			get
			{
				return bolShowShortCut;
			}
			set
			{
				bolShowShortCut = value;
			}
		}

		public bool WaitingForUserSelected
		{
			get
			{
				return !bolExitLoop;
			}
			set
			{
				bolExitLoop = !value;
			}
		}

		public int DefaultItemHeight
		{
			get
			{
				return intDefaultItemHeight;
			}
			set
			{
				intDefaultItemHeight = value;
			}
		}

		public virtual bool MultiSelect
		{
			get
			{
				return bolMultiSelect;
			}
			set
			{
				bolMultiSelect = value;
				if (base.Visible)
				{
					Refresh();
				}
			}
		}

		public ArrayList Items
		{
			get
			{
				return myItems;
			}
			set
			{
				if (value != null)
				{
					myItems = value;
					RefreshViewHeight();
					pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
				}
			}
		}

		public int SelectedIndex
		{
			get
			{
				return intSelectedIndex;
			}
			set
			{
				bolUserSelecting = true;
				if (value < 0 || value >= myItems.Count)
				{
					intSelectedIndex = -1;
					if (!bolMultiSelect)
					{
						foreach (ListItem myItem in myItems)
						{
							myItem.Selected = false;
						}
					}
					pnlList.Refresh();
				}
				else if (intSelectedIndex != value)
				{
					ListItem selectedItem = SelectedItem;
					InnerSetSelectedIndex(value);
					if (intUpdateLevel <= 0)
					{
						ListItem listItem = (ListItem)myItems[intSelectedIndex];
						int num = listItem.Top + pnlList.AutoScrollPosition.Y;
						if (num < 0)
						{
							pnlList.AutoScrollPosition = new Point(0, num - pnlList.AutoScrollPosition.Y);
						}
						else if (num + listItem.Height > pnlList.ClientSize.Height)
						{
							pnlList.AutoScrollPosition = new Point(0, num + listItem.Height - pnlList.ClientSize.Height - pnlList.AutoScrollPosition.Y);
						}
						RefreshItem(selectedItem);
						RefreshItem(SelectedItem);
					}
					if (this.SelectedIndexChanged != null)
					{
						this.SelectedIndexChanged(this, null);
					}
				}
				Application.DoEvents();
				bolUserSelecting = false;
			}
		}

		public ArrayList SelectedItems
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (ListItem myItem in myItems)
				{
					if (myItem.Selected)
					{
						arrayList.Add(myItem);
					}
				}
				return arrayList;
			}
			set
			{
				if (value != null)
				{
					foreach (ListItem myItem in myItems)
					{
						myItem.Selected = value.Contains(myItem);
					}
				}
			}
		}

		public ArrayList SelectedObjects
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (ListItem myItem in myItems)
				{
					if (myItem.Selected)
					{
						arrayList.Add(myItem.obj);
					}
				}
				return arrayList;
			}
		}

		public object SelectedObject
		{
			get
			{
				if (SelectedItem != null)
				{
					return SelectedItem.obj;
				}
				return null;
			}
		}

		public ListItem SelectedItem
		{
			get
			{
				if (intSelectedIndex >= 0 && intSelectedIndex < myItems.Count)
				{
					return (ListItem)myItems[intSelectedIndex];
				}
				return null;
			}
			set
			{
				SelectedIndex = myItems.IndexOf(value);
			}
		}

		public string SelectedText
		{
			get
			{
				if (bolMultiSelect)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ListItem myItem in myItems)
					{
						if (myItem.Selected)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(chrItemSpliter);
							}
							stringBuilder.Append(myItem.Text);
						}
					}
					return stringBuilder.ToString();
				}
				if (intSelectedIndex >= 0 && intSelectedIndex < myItems.Count)
				{
					return ((ListItem)myItems[intSelectedIndex]).Text;
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					return;
				}
				if (bolMultiSelect)
				{
					ListItem listItem = null;
					string[] array = value.Split(chrItemSpliter);
					if (array != null)
					{
						foreach (ListItem myItem in myItems)
						{
							myItem.Selected = false;
							string[] array2 = array;
							foreach (string b in array2)
							{
								if (myItem.Text == b)
								{
									myItem.Selected = true;
									if (listItem == null)
									{
										listItem = myItem;
									}
									break;
								}
							}
						}
						if (listItem != null)
						{
							SetSelectIndexMiddle(myItems.IndexOf(listItem));
						}
					}
				}
				else
				{
					ListItem listItem2 = GetItemByText(value, StartsWith: false);
					if (listItem2 != null)
					{
						SetSelectIndexMiddle(myItems.IndexOf(listItem2));
					}
				}
			}
		}

		public string SelectedSpell
		{
			get
			{
				if (intSelectedIndex >= 0 && intSelectedIndex < myItems.Count)
				{
					return ((ListItem)myItems[intSelectedIndex]).ChineseSpell;
				}
				return null;
			}
			set
			{
				SelectedItem = GetItemByChineseSpell(value);
			}
		}

		public bool ShowSpell
		{
			get
			{
				return lblSpell.Visible;
			}
			set
			{
				lblSpell.Visible = value;
				if (value)
				{
					pnlList.BorderStyle = BorderStyle.Fixed3D;
				}
				else
				{
					pnlList.BorderStyle = BorderStyle.None;
				}
			}
		}

		public event EventHandler SelectedIndexChanged;

		public void SetCompositionRect(int x, int y, int height)
		{
			myCompositionRect = new Rectangle(x, y, 10, height);
		}

		public void UpdateComposition()
		{
			if (!myCompositionRect.IsEmpty)
			{
				Point point = base.Location = GetPopupPos(myCompositionRect.Left, myCompositionRect.Top, myCompositionRect.Height);
			}
		}

		protected virtual void OnLoadChildItems(ListItem myItem, ArrayList myChildItems)
		{
		}

		private bool HasShortCutCharItem()
		{
			foreach (ListItem myItem in myItems)
			{
				if (!char.IsWhiteSpace(myItem.ShortCutChar))
				{
					return true;
				}
			}
			return false;
		}

		private bool HasItemsItem()
		{
			foreach (ListItem myItem in myItems)
			{
				if (myItem.HasItems)
				{
					return true;
				}
			}
			return false;
		}

		private bool HasIconItem()
		{
			foreach (ListItem myItem in myItems)
			{
				if (myItem.Icon != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasSelectedItem()
		{
			foreach (ListItem myItem in myItems)
			{
				if (myItem.Selected)
				{
					return true;
				}
			}
			return false;
		}

		public void PopupSelection()
		{
			if (MultiSelect && myItems.Count > 14)
			{
				ArrayList selectedItems = SelectedItems;
				if (selectedItems != null && selectedItems.Count > 1)
				{
					foreach (object item in selectedItems)
					{
						myItems.Remove(item);
					}
					myItems.InsertRange(0, selectedItems);
					RefreshViewHeight();
					SelectedIndex = 0;
					Refresh();
				}
			}
		}

		public void RefreshChineseSpell(bool ResetAll)
		{
			if (ResetAll)
			{
				foreach (ListItem myItem in myItems)
				{
					myItem.ChineseSpell = StringCommon.GetChineseSpell(myItem.Text);
				}
			}
			else
			{
				foreach (ListItem myItem2 in myItems)
				{
					if (myItem2.ChineseSpell == null || myItem2.ChineseSpell.Length == 0)
					{
						myItem2.ChineseSpell = StringCommon.GetChineseSpell(myItem2.Text);
					}
				}
			}
		}

		public ListItem GetItemByText(string strText, bool StartsWith)
		{
			if (strText == null)
			{
				return null;
			}
			foreach (ListItem myItem in myItems)
			{
				if (myItem.Text != null)
				{
					if (myItem.Text == strText)
					{
						return myItem;
					}
					if (StartsWith && myItem.Text.StartsWith(strText))
					{
						return myItem;
					}
				}
			}
			return null;
		}

		public ListItem GetItemByChineseSpell(string strSpell)
		{
			foreach (ListItem myItem in myItems)
			{
				if (myItem.ChineseSpell != null && myItem.ChineseSpell.StartsWith(strSpell))
				{
					return myItem;
				}
			}
			return null;
		}

		public ListItem AddSpliter()
		{
			ListItem listItem = AddItem(null);
			listItem.Style = 1;
			return listItem;
		}

		public ListItem AddItem(string strText)
		{
			ListItem listItem = CreateListItem(strText);
			listItem.Top = intViewHeight;
			myItems.Add(listItem);
			intViewHeight += listItem.Height;
			if (intUpdateLevel <= 0)
			{
				pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
				pnlList.Refresh();
			}
			return listItem;
		}

		public ListItem CreateListItem(string strText)
		{
			ListItem listItem = new ListItem();
			listItem.Height = intDefaultItemHeight;
			listItem.Text = strText;
			listItem.ForeColor = ForeColor;
			listItem.BackColor = BackColor;
			return listItem;
		}

		public void AddStrings(string[] strItems)
		{
			foreach (string text in strItems)
			{
				ListItem listItem = new ListItem();
				listItem.Height = intDefaultItemHeight;
				listItem.Text = text;
				listItem.ForeColor = ForeColor;
				listItem.BackColor = BackColor;
				listItem.Top = intViewHeight;
				myItems.Add(listItem);
				intViewHeight += listItem.Height;
			}
			if (intUpdateLevel <= 0)
			{
				pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
				pnlList.Refresh();
			}
		}

		public void AddObjects(object[] objItems)
		{
			foreach (object obj in objItems)
			{
				ListItem listItem = new ListItem();
				listItem.Height = intDefaultItemHeight;
				listItem.ForeColor = ForeColor;
				listItem.BackColor = BackColor;
				listItem.Top = intViewHeight;
				if (obj == null)
				{
					listItem.Text = "<NULL>";
				}
				else
				{
					listItem.Text = obj.ToString();
					listItem.obj = obj;
				}
				myItems.Add(listItem);
				intViewHeight += listItem.Height;
			}
			if (intUpdateLevel <= 0)
			{
				pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
				pnlList.Refresh();
			}
		}

		public void RemoveItem(ListItem obj)
		{
			myItems.Remove(obj);
			RefreshViewHeight();
			if (intSelectedIndex >= myItems.Count)
			{
				intSelectedIndex = myItems.Count - 1;
			}
			if (intUpdateLevel <= 0)
			{
				pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
				pnlList.Refresh();
			}
		}

		public void Clear()
		{
			myItems.Clear();
			intViewHeight = 0;
			intSelectedIndex = -1;
			if (intUpdateLevel <= 0)
			{
				pnlList.AutoScrollMinSize = new Size(0, 0);
				pnlList.Refresh();
			}
		}

		public ListItem HitTest(int x, int y)
		{
			if (x >= 0 && x < pnlList.ClientSize.Width && y >= 0 && y <= pnlList.ClientSize.Height)
			{
				int num = y;
				y -= pnlList.AutoScrollPosition.Y;
				foreach (ListItem myItem in myItems)
				{
					if (y > myItem.Top && y <= myItem.Top + myItem.Height)
					{
						return myItem;
					}
				}
			}
			return null;
		}

		private void InnerSetSelectedIndex(int index)
		{
			if (index >= 0 && index < myItems.Count)
			{
				intSelectedIndex = index;
				if (!bolMultiSelect)
				{
					foreach (ListItem myItem in myItems)
					{
						myItem.Selected = false;
					}
					ListItem listItem2 = (ListItem)myItems[intSelectedIndex];
					listItem2.Selected = true;
				}
			}
		}

		public void SetSelectIndexMiddle(int index)
		{
			if (myItems != null && index >= 0 && index < myItems.Count)
			{
				bolUserSelecting = true;
				InnerSetSelectedIndex(index);
				ListItem listItem = (ListItem)myItems[index];
				pnlList.AutoScrollPosition = new Point(0, listItem.Top - (pnlList.ClientSize.Height - listItem.Height) / 2);
				pnlList.Refresh();
				if (this.SelectedIndexChanged != null)
				{
					this.SelectedIndexChanged(this, null);
				}
				Application.DoEvents();
				bolUserSelecting = false;
			}
		}

		public void SetSelectedText(string strText, bool StartsWidth)
		{
			ListItem itemByText = GetItemByText(strText, StartsWidth);
			if (itemByText != null)
			{
				SelectedIndex = myItems.IndexOf(itemByText);
			}
		}

		private void SetSelectedIndex(int index)
		{
			if (myItems.Count > 0)
			{
				if (index < 0)
				{
					index = 0;
				}
				if (index >= myItems.Count)
				{
					index = myItems.Count - 1;
				}
				SelectedIndex = index;
			}
		}

		private void RefreshViewHeight()
		{
			InnerShortCutWidth = 0;
			if (bolShowShortCut && HasShortCutCharItem())
			{
				using (Graphics graphics = pnlList.CreateGraphics())
				{
					InnerShortCutWidth = (int)graphics.MeasureString("(H)", pnlList.Font).Width + 4;
				}
			}
			InnserIconWidth = (HasIconItem() ? 19 : 0);
			InnerExpendHandleRectWidth = ((bolShowExpendHandleRect && HasItemsItem()) ? 12 : 0);
			intViewHeight = 0;
			foreach (ListItem myItem in myItems)
			{
				myItem.Top = intViewHeight;
				intViewHeight += myItem.Height;
			}
		}

		private int GetItemLeft(ListItem myItem)
		{
			return intLeftMargin + myItem.Layer * intIndent;
		}

		public void SetDefaultSize()
		{
			RefreshViewHeight();
			pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
			int num = base.Height - pnlList.ClientSize.Height;
			int num2 = DefaultItemHeight * VisibleItems + num;
			base.Height = ((intViewHeight + num > num2) ? num2 : (intViewHeight + num));
			int num3 = base.Width - pnlList.ClientSize.Width + intRightMargin + InnserIconWidth + InnerShortCutWidth;
			if (pnlList.ClientSize.Height < intViewHeight)
			{
				num3 -= User32.GetSystemMetrics(2);
			}
			int num4 = 0;
			using (Graphics graphics = pnlList.CreateGraphics())
			{
				num4 = (int)graphics.MeasureString("H", pnlList.Font, 1000, StringFormat.GenericTypographic).Width;
			}
			int num5 = 0;
			Encoding encoding = Encoding.GetEncoding(936);
			foreach (ListItem myItem in myItems)
			{
				if (myItem.Style == 0)
				{
					int num6 = encoding.GetByteCount(myItem.Text) * num4 + myItem.Layer * intIndent;
					if (num6 > num5)
					{
						num5 = num6;
					}
				}
			}
			int num7 = intLeftMargin + num5 + num3 + num4 + 3;
			num3 = base.Width - lblSpell.Width;
			if (num7 < lblSpell.PreferredWidth + num3)
			{
				num7 = lblSpell.PreferredWidth + num3;
			}
			if (num7 < 150)
			{
				num7 = 150;
			}
			if (intViewHeight > pnlList.ClientSize.Height)
			{
				base.Width = num7 + User32.GetSystemMetrics(2);
			}
			else
			{
				base.Width = num7;
			}
		}

		public void BeginUpdate()
		{
			intUpdateLevel++;
		}

		public void EndUpdate()
		{
			intUpdateLevel--;
			if (intUpdateLevel <= 0)
			{
				intUpdateLevel = 0;
				RefreshViewHeight();
				pnlList.AutoScrollMinSize = new Size(10, intViewHeight);
				pnlList.Refresh();
			}
		}

		public bool isUpdateing()
		{
			return intUpdateLevel > 0;
		}

		public void RefreshItem(ListItem myItem)
		{
			if (myItem != null)
			{
				pnlList.Invalidate(new Rectangle(0, myItem.Top + pnlList.AutoScrollPosition.Y, pnlList.ClientSize.Width, myItem.Height));
			}
		}

		private Rectangle GetItemExpendRect(ListItem myItem)
		{
			if (bolShowExpendHandleRect && myItem != null && myItem.HasItems)
			{
				return DocumentView.StaticGetExpendHandleRect2(intLeftMargin + myItem.Layer * intIndent, myItem.Top + pnlList.AutoScrollPosition.Y, myItem.Height);
			}
			return Rectangle.Empty;
		}

		private void pnlList_Paint(object sender, PaintEventArgs e)
		{
			if (myItems != null && intUpdateLevel <= 0)
			{
				Graphics graphics = e.Graphics;
				float num = pnlList.Font.GetHeight() + 1f;
				using (StringFormat stringFormat = new StringFormat())
				{
					Brush windowText = SystemBrushes.WindowText;
					stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
					Rectangle clipRectangle = e.ClipRectangle;
					SolidBrush solidBrush = null;
					int width = pnlList.ClientSize.Width;
					for (int i = 0; i < myItems.Count; i++)
					{
						ListItem listItem = (ListItem)myItems[i];
						int num2 = listItem.Top + pnlList.AutoScrollPosition.Y;
						if (num2 > clipRectangle.Bottom)
						{
							break;
						}
						if (num2 + listItem.Height >= clipRectangle.Top && num2 <= clipRectangle.Bottom)
						{
							int num3 = intLeftMargin + listItem.Layer * intIndent;
							int num4 = num3 + InnserIconWidth + InnerExpendHandleRectWidth;
							RectangleF layoutRectangle = new RectangleF(num4, (float)num2 + ((float)listItem.Height - num) / 2f, width - num4 + 111, num);
							if (listItem.Style == 0)
							{
								if (InnerExpendHandleRectWidth > 0 && listItem.HasItems)
								{
									DocumentView.StaticDrawExpendHandle(graphics, DocumentView.StaticGetExpendHandleRect2(num3, num2, listItem.Height), listItem.Expended);
								}
								if (listItem.Icon != null)
								{
									graphics.DrawImage(listItem.Icon, num3 + InnerExpendHandleRectWidth, layoutRectangle.Top, 16f, 16f);
								}
								if (listItem.Selected)
								{
									graphics.FillRectangle(SystemBrushes.Highlight, layoutRectangle.Left, layoutRectangle.Top - 1f, layoutRectangle.Width, layoutRectangle.Height);
									if (!char.IsWhiteSpace(listItem.ShortCutChar))
									{
										graphics.DrawString("(&" + listItem.ShortCutChar + ")", pnlList.Font, SystemBrushes.HighlightText, layoutRectangle.Left, layoutRectangle.Top, stringFormat);
									}
									layoutRectangle.X += InnerShortCutWidth;
									graphics.DrawString(listItem.Text, pnlList.Font, SystemBrushes.HighlightText, layoutRectangle);
								}
								else
								{
									if (!char.IsWhiteSpace(listItem.ShortCutChar))
									{
										graphics.DrawString("(&" + listItem.ShortCutChar + ")", pnlList.Font, windowText, layoutRectangle.Left, layoutRectangle.Top, stringFormat);
									}
									layoutRectangle.X += InnerShortCutWidth;
									graphics.DrawString(listItem.Text, pnlList.Font, windowText, layoutRectangle);
								}
								if (bolMultiSelect && i == intSelectedIndex)
								{
									graphics.DrawRectangle(Pens.Red, num3, num2, width - num3 - 2, listItem.Height - 1);
								}
							}
							else if (listItem.Style == 1)
							{
								using (Pen pen = new Pen(Color.Black, 2f))
								{
									int num5 = num2 + (int)((double)listItem.Height / 2.0);
									graphics.DrawLine(pen, num3 + 5, num5, width - 10, num5);
								}
							}
						}
					}
					solidBrush?.Dispose();
				}
			}
		}

		public Point GetPopupPos(int x, int y, int height)
		{
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height2 = Screen.PrimaryScreen.Bounds.Height;
			int width2 = base.Width;
			int height3 = base.Height;
			Point result = new Point(x, y + height);
			if (result.X < 0)
			{
				result.X = 0;
			}
			if (result.Y < 0)
			{
				result.Y = 0;
			}
			if (y + height + height3 > height2)
			{
				result.Y = y - height3;
			}
			if (x + width2 > width)
			{
				result.X = width - width2;
			}
			return result;
		}

		public void Show(Control ctl, int x, int y, int height)
		{
			Point p = new Point(x, y);
			if (ctl != null)
			{
				p = ctl.PointToScreen(p);
			}
			SetDefaultSize();
			p = (base.Location = GetPopupPos(p.X, p.Y, height));
			Show();
		}

		public int ShowPopupList(int x, int y, Form owner)
		{
			base.Location = new Point(x, y);
			Show();
			owner?.Activate();
			return 0;
		}

		public bool WaitUserSelected()
		{
			MSG mSG = default(MSG);
			bolExitLoop = false;
			bolUserAccept = false;
			Application.DoEvents();
			Application.AddMessageFilter(this);
			while (User32.WaitMessage())
			{
				Application.DoEvents();
				if (bolExitLoop)
				{
					break;
				}
			}
			Application.RemoveMessageFilter(this);
			lblSpell.Text = "";
			if (bolAutoClose)
			{
				Hide();
			}
			if (!bolUserAccept)
			{
				intSelectedIndex = -1;
			}
			return SelectedItem != null;
		}

		private bool ExpendItem(ListItem myItem)
		{
			if (myItem != null && myItem.HasItems)
			{
				bool flag = false;
				if (myItem.Expended)
				{
					int num = 0;
					ListItem listItem = myItem;
					for (int i = myItems.IndexOf(myItem) + 1; i < myItems.Count; i++)
					{
						ListItem listItem2 = (ListItem)myItems[i];
						if (listItem2.Parent != listItem)
						{
							listItem = listItem2.Parent;
							while (listItem != null && listItem != myItem)
							{
								listItem = listItem.Parent;
							}
							if (listItem != myItem)
							{
								break;
							}
						}
						num++;
					}
					if (num > 0)
					{
						myItems.RemoveRange(myItems.IndexOf(myItem) + 1, num);
						flag = true;
					}
				}
				else
				{
					ArrayList arrayList = new ArrayList();
					OnLoadChildItems(myItem, arrayList);
					if (arrayList.Count > 0)
					{
						foreach (ListItem item in arrayList)
						{
							item.Layer = myItem.Layer + 1;
							item.Parent = myItem;
						}
						myItems.InsertRange(myItems.IndexOf(myItem) + 1, arrayList);
						flag = true;
					}
					else
					{
						myItem.HasItems = false;
					}
				}
				myItem.Expended = !myItem.Expended;
				if (flag)
				{
					RefreshChineseSpell(ResetAll: false);
					RefreshViewHeight();
					SetDefaultSize();
					UpdateComposition();
					pnlList.Refresh();
				}
				else
				{
					RefreshItem(myItem);
				}
				return flag;
			}
			return false;
		}

		private void pnlList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem == null)
			{
				return;
			}
			Rectangle itemExpendRect = GetItemExpendRect(SelectedItem);
			if (!itemExpendRect.IsEmpty)
			{
				Point mousePosition = Control.MousePosition;
				if (pnlList.PointToClient(mousePosition).X <= itemExpendRect.Left + InnerExpendHandleRectWidth)
				{
					return;
				}
			}
			bolUserAccept = true;
			bolExitLoop = true;
		}

		private void pnlList_MouseMove(object sender, MouseEventArgs e)
		{
			if (bolUserSelecting || !WaitingForUserSelected)
			{
				return;
			}
			ListItem listItem = HitTest(e.X, e.Y);
			if (listItem != null && listItem.Style != 1)
			{
				if (listItem != null)
				{
					SelectedItem = listItem;
				}
				else
				{
					SelectedIndex = -1;
				}
			}
		}

		private void pnlList_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && bolMultiSelect)
			{
				bolExitLoop = true;
				bolUserAccept = true;
				return;
			}
			ListItem listItem = HitTest(e.X, e.Y);
			if (listItem == null || listItem.Style != 0)
			{
				return;
			}
			Rectangle itemExpendRect = GetItemExpendRect(listItem);
			if (!itemExpendRect.IsEmpty && e.X <= itemExpendRect.Left + InnerExpendHandleRectWidth)
			{
				if (itemExpendRect.Contains(e.X, e.Y))
				{
					ExpendItem(listItem);
				}
			}
			else if (bolMultiSelect)
			{
				listItem.Selected = !listItem.Selected;
				if (listItem.Selected)
				{
					SelectedIndex = myItems.IndexOf(listItem);
				}
				if (SelectedStateChanged != null)
				{
					SelectedStateChanged(this, null);
				}
				pnlList.Refresh();
			}
			else
			{
				SelectedIndex = myItems.IndexOf(listItem);
				pnlList.Refresh();
				bolUserAccept = true;
				bolExitLoop = true;
			}
		}

		public void CloseList()
		{
			bolExitLoop = true;
			lblSpell.Text = strTitle;
			Hide();
			Application.RemoveMessageFilter(this);
			if ((int)msgBack.HWnd != 0)
			{
				User32.PostMessage((int)msgBack.HWnd, msgBack.Msg, (uint)(int)msgBack.WParam, (uint)(int)msgBack.LParam);
				msgBack.HWnd = IntPtr.Zero;
			}
		}

		public bool PreFilterMessage(ref Message m)
		{
			bool result = false;
			if (base.IsDisposed || base.Disposing || !base.Visible)
			{
				Application.RemoveMessageFilter(this);
				return false;
			}
			Rectangle bounds = base.Bounds;
			if (m.Msg == 513 || m.Msg == 519 || m.Msg == 516 || m.Msg == 523)
			{
				Point pt = User32.MousePositionFromMSG((int)m.HWnd, (uint)(int)m.LParam);
				bolExitLoop = !bounds.Contains(pt);
				msgBack = m;
				result = bolExitLoop;
			}
			if (m.Msg == 161 || m.Msg == 167 || m.Msg == 164 || m.Msg == 171)
			{
				Point pt = new Point((int)m.LParam);
				bolExitLoop = !bounds.Contains(pt);
				msgBack = m;
				result = bolExitLoop;
			}
			if (m.Msg == 522)
			{
				Point pt = new Point((int)m.LParam);
				pt = PointToClient(pt);
				if (pnlList.Bounds.Contains(pt))
				{
					User32.SendMessage((int)pnlList.Handle, m.Msg, (uint)(int)m.WParam, (uint)(int)m.LParam);
				}
				result = true;
			}
			if (m.Msg == 258 && lblSpell.Visible)
			{
				bool flag = false;
				if (strTitle != null && lblSpell.Text == strTitle)
				{
					lblSpell.Text = "";
				}
				int num = (int)m.WParam;
				if (num == 8)
				{
					if (lblSpell.Text.Length > 0)
					{
						lblSpell.Text = lblSpell.Text.Substring(0, lblSpell.Text.Length - 1);
						flag = true;
					}
					else if (!OnBackSpace())
					{
						result = true;
						bolExitLoop = true;
					}
				}
				else if (!char.IsWhiteSpace((char)(int)m.WParam))
				{
					lblSpell.Text += ((char)(int)m.WParam).ToString().ToUpper();
					flag = true;
				}
				if (flag)
				{
					UpdateChineseSpell(lblSpell.Text);
				}
				if (strTitle != null && lblSpell.Text == "")
				{
					lblSpell.Text = strTitle;
				}
				result = true;
			}
			if (m.Msg == 256)
			{
				ListItem selectedItem = SelectedItem;
				result = true;
				switch ((int)m.WParam)
				{
				case 17:
					if (bolShowExpendHandleRect)
					{
						ListItem listItem = SelectedItem;
						ExpendItem(listItem);
					}
					break;
				case 37:
					result = false;
					if (bolShowExpendHandleRect && selectedItem != null)
					{
						if (selectedItem.HasItems && selectedItem.Expended)
						{
							ExpendItem(selectedItem);
							result = true;
						}
						else if (selectedItem.Parent != null)
						{
							SelectedItem = selectedItem.Parent;
							result = true;
						}
					}
					break;
				case 39:
				{
					result = false;
					if (!bolShowExpendHandleRect || selectedItem == null)
					{
						break;
					}
					if (selectedItem.HasItems && !selectedItem.Expended)
					{
						ExpendItem(selectedItem);
						result = true;
						break;
					}
					int num3 = SelectedIndex + 1;
					if (SelectedIndex >= 0 && SelectedIndex < myItems.Count - 1)
					{
						ListItem listItem2 = (ListItem)myItems[SelectedIndex + 1];
						if (listItem2.Parent == SelectedItem)
						{
							SelectedItem = listItem2;
							result = true;
						}
					}
					break;
				}
				case 38:
					SetSelectedIndex(SelectedIndex - 1);
					break;
				case 40:
					SetSelectedIndex(SelectedIndex + 1);
					break;
				case 34:
					SetSelectedIndex(SelectedIndex + 10);
					break;
				case 33:
					SetSelectedIndex(SelectedIndex - 10);
					break;
				case 32:
					result = true;
					if (MultiSelect)
					{
						ListItem listItem = SelectedItem;
						if (listItem != null)
						{
							listItem.Selected = !listItem.Selected;
							if (SelectedStateChanged != null)
							{
								SelectedStateChanged(this, null);
							}
							RefreshItem(listItem);
						}
					}
					else
					{
						bolUserAccept = true;
						bolExitLoop = true;
					}
					break;
				case 13:
					bolUserAccept = true;
					bolExitLoop = true;
					result = true;
					break;
				case 27:
					bolUserAccept = false;
					bolExitLoop = true;
					result = true;
					break;
				default:
					result = false;
					if (bolShowShortCut)
					{
						int num2 = m.WParam.ToInt32();
						foreach (ListItem myItem in myItems)
						{
							if (!char.IsWhiteSpace(myItem.ShortCutChar) && myItem.ShortCutChar == num2)
							{
								SelectedItem = myItem;
								bolUserAccept = true;
								bolExitLoop = true;
								result = true;
								break;
							}
						}
					}
					break;
				}
			}
			return result;
		}

		protected virtual void UpdateChineseSpell(string strSpell)
		{
			bolUserSelecting = true;
			foreach (ListItem myItem in myItems)
			{
				if (myItem.Layer == 0 && myItem.ChineseSpell != null && (myItem.ChineseSpell.StartsWith(strSpell) || myItem.Text.StartsWith(strSpell)))
				{
					SetSelectIndexMiddle(myItems.IndexOf(myItem));
					break;
				}
			}
			bolUserSelecting = false;
		}

		protected virtual bool OnBackSpace()
		{
			return false;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 28:
				bolExitLoop = true;
				break;
			case 33:
				m.Result = (IntPtr)3L;
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (myImageList != null)
			{
				myImageList.Dispose();
				myImageList = null;
			}
			base.Dispose(disposing);
		}

		public ZYPopupList()
		{
			base.TopMost = true;
			BackColor = SystemColors.Window;
			base.StartPosition = FormStartPosition.Manual;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.ShowInTaskbar = false;
			Text = "";
			base.ControlBox = false;
			base.Size = new Size(100, 200);
			intDefaultItemHeight = (int)Font.GetHeight() + 3;
			pnlList = new Panel();
			pnlList.BorderStyle = BorderStyle.None;
			pnlList.AutoScroll = true;
			pnlList.Dock = DockStyle.Fill;
			pnlList.Visible = true;
			pnlList.Font = Font;
			pnlList.Paint += pnlList_Paint;
			pnlList.MouseMove += pnlList_MouseMove;
			pnlList.MouseDown += pnlList_MouseDown;
			pnlList.DoubleClick += pnlList_DoubleClick;
			base.Controls.Add(pnlList);
			lblSpell = new Label();
			lblSpell.Dock = DockStyle.Top;
			lblSpell.BorderStyle = BorderStyle.None;
			lblSpell.BackColor = SystemColors.Control;
			lblSpell.TextAlign = ContentAlignment.MiddleLeft;
			lblSpell.Font = new Font("宋体", 10f);
			base.Controls.Add(lblSpell);
		}
	}
}
