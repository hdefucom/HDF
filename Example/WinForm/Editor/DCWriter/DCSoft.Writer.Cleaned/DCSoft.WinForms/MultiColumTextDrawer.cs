using DCSoft.Drawing;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	public class MultiColumTextDrawer
	{
		private int _MaxColumnWidth = 100;

		private int _MinColumnWidth = 10;

		private float _ContentWidth = 0f;

		private ContentAlignment _Alignment = ContentAlignment.MiddleLeft;

		private float[] _ColumnWidths = null;

		private static StringFormat _StrFormat = null;

		/// <summary>
		///       最大列宽
		///       </summary>
		public int MaxColumnWidth
		{
			get
			{
				return _MaxColumnWidth;
			}
			set
			{
				_MaxColumnWidth = value;
			}
		}

		/// <summary>
		///       最小列宽
		///       </summary>
		public int MinColumnWidth
		{
			get
			{
				return _MinColumnWidth;
			}
			set
			{
				_MinColumnWidth = value;
			}
		}

		/// <summary>
		///       视图宽度
		///       </summary>
		public float ContentWidth => _ContentWidth;

		/// <summary>
		///       文本对齐方式
		///       </summary>
		public ContentAlignment Alignment
		{
			get
			{
				return _Alignment;
			}
			set
			{
				_Alignment = value;
				if (_StrFormat != null)
				{
					_StrFormat.Dispose();
					_StrFormat = null;
				}
			}
		}

		private StringFormat StrFormat
		{
			get
			{
				if (_StrFormat == null)
				{
					_StrFormat = new StringFormat(StringFormat.GenericTypographic);
					DrawerUtil.SetStringFormatAlignment(_StrFormat, Alignment);
					_StrFormat.FormatFlags = StringFormatFlags.NoWrap;
				}
				return _StrFormat;
			}
		}

		public virtual int GetColumnNum(object item)
		{
			return 1;
		}

		public virtual string GetDisplayText(object item, int columnIndex)
		{
			if (item == null || DBNull.Value.Equals(item))
			{
				return null;
			}
			return Convert.ToString(item);
		}

		public virtual void RefreshLayout(Graphics graphics_0, IList items, Font font)
		{
			int num = 15;
			if (graphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			int num2 = 1;
			foreach (object item in items)
			{
				int columnNum = GetColumnNum(item);
				num2 = Math.Max(columnNum, num2);
			}
			_ColumnWidths = new float[num2];
			foreach (object item2 in items)
			{
				int columnNum = GetColumnNum(item2);
				for (int i = 0; i < columnNum; i++)
				{
					string displayText = GetDisplayText(item2, i);
					if (!string.IsNullOrEmpty(displayText))
					{
						SizeF sizeF = graphics_0.MeasureString(displayText, font, 100000, StrFormat);
						_ColumnWidths[i] = Math.Max(_ColumnWidths[i], sizeF.Width + 5f);
					}
				}
			}
			_ContentWidth = 0f;
			for (int i = 0; i < _ColumnWidths.Length; i++)
			{
				float num3 = _ColumnWidths[i];
				if (num3 > (float)MaxColumnWidth && MaxColumnWidth > 0)
				{
					num3 = MaxColumnWidth;
				}
				if (num3 < (float)MinColumnWidth && MinColumnWidth > 0)
				{
					num3 = MinColumnWidth;
				}
				_ColumnWidths[i] = num3;
				_ContentWidth += num3;
			}
		}

		public virtual void DrawItem(Graphics graphics_0, object item, RectangleF bounds, Font font, Color txtColor)
		{
			int columnNum = GetColumnNum(item);
			float num = bounds.Left;
			using (SolidBrush brush = new SolidBrush(txtColor))
			{
				for (int i = 0; i < columnNum; i++)
				{
					string displayText = GetDisplayText(item, i);
					if (!string.IsNullOrEmpty(displayText))
					{
						RectangleF layoutRectangle = new RectangleF(num, bounds.Top, _ColumnWidths[i], bounds.Height);
						graphics_0.DrawString(displayText, font, brush, layoutRectangle, StrFormat);
					}
					num += _ColumnWidths[i];
				}
			}
		}

		public void BindingOwnerDrawListBox(ListBox listBox_0)
		{
			int num = 10;
			if (listBox_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (listBox_0.IsDisposed)
			{
				throw new ObjectDisposedException("ctl");
			}
			using (Graphics graphics_ = listBox_0.CreateGraphics())
			{
				RefreshLayout(graphics_, listBox_0.Items, listBox_0.Font);
			}
			listBox_0.DrawMode = DrawMode.OwnerDrawFixed;
			listBox_0.DrawItem += ctl_DrawItem;
		}

		public void RefreshLayout(ListBox listBox_0)
		{
			using (Graphics graphics_ = listBox_0.CreateGraphics())
			{
				RefreshLayout(graphics_, listBox_0.Items, listBox_0.Font);
			}
		}

		private void ctl_DrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			object item = listBox.Items[e.Index];
			e.DrawBackground();
			bool flag = false;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				flag = true;
			}
			DrawItem(e.Graphics, item, e.Bounds, listBox.Font, flag ? SystemColors.HighlightText : SystemColors.ControlText);
			if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
			{
				e.DrawFocusRectangle();
			}
		}
	}
}
