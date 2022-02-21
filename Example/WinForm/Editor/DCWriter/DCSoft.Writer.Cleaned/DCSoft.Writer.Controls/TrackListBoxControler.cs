#define DEBUG
using DCSoft.Common;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       用户痕迹信息列表控制器
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	
	public class TrackListBoxControler
	{
		private WriterControl _WriterControl = null;

		private ListBox _ListBox = null;

		private bool _Visible = false;

		private static StringFormat _MeasureStringFormat = null;

		private bool _HandlingEvent = false;

		/// <summary>
		///       控件是否可见
		///       </summary>
		public bool Visible => _Visible;

		private static StringFormat MeasureStringFormat
		{
			get
			{
				if (_MeasureStringFormat == null)
				{
					_MeasureStringFormat = new StringFormat();
					_MeasureStringFormat.Alignment = StringAlignment.Near;
					_MeasureStringFormat.LineAlignment = StringAlignment.Near;
				}
				return _MeasureStringFormat;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="lst">列表控件</param>
		/// <param name="ctl">编辑器控件</param>
		public TrackListBoxControler(ListBox listBox_0, WriterControl writerControl_0)
		{
			_ListBox = listBox_0;
			_WriterControl = writerControl_0;
		}

		/// <summary>
		///       启动控制器
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Start()
		{
			if (_ListBox == null || _WriterControl == null)
			{
				return false;
			}
			_ListBox.Resize += _ListBox_Resize;
			_ListBox.DrawMode = DrawMode.OwnerDrawVariable;
			_ListBox.MeasureItem += ListBox_MeasureItem;
			_ListBox.DrawItem += ListBox_DrawItem;
			_ListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
			_WriterControl.SelectionChanged += _WriterControl_SelectionChanged;
			_WriterControl.DocumentContentChanged += _WriterControl_DocumentContentChanged;
			_WriterControl.DocumentLoad += _WriterControl_DocumentLoad;
			return true;
		}

		private void _WriterControl_DocumentLoad(object sender, WriterEventArgs e)
		{
			Refresh();
		}

		private void _WriterControl_DocumentContentChanged(object sender, WriterEventArgs e)
		{
			Refresh();
		}

		private void _WriterControl_SelectionChanged(object sender, WriterEventArgs e)
		{
			InnerHandleWriterControlSelectionChanged();
		}

		private void _ListBox_Resize(object sender, EventArgs e)
		{
			if (!_HandlingEvent)
			{
				_HandlingEvent = true;
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(_ListBox.Items);
				_ListBox.Items.Clear();
				_ListBox.Items.AddRange(arrayList.ToArray());
				_HandlingEvent = false;
			}
		}

		/// <summary>
		///       刷新列表内容
		///       </summary>
		public void Refresh()
		{
			Refresh(FunctionControlVisibility.Visible);
		}

		/// <summary>
		///       刷新列表内容
		///       </summary>
		/// <param name="visibility">控件可见性设置</param>
		public void Refresh(FunctionControlVisibility visibility)
		{
			if (_ListBox == null || _ListBox.IsDisposed)
			{
				return;
			}
			_Visible = false;
			_ListBox.Items.Clear();
			switch (visibility)
			{
			case FunctionControlVisibility.Auto:
			{
				UserTrackInfoList userTrackInfos = _WriterControl.UserTrackInfos;
				userTrackInfos.Refresh();
				if (userTrackInfos.Count > 0)
				{
					_Visible = true;
					_ListBox.Items.AddRange(userTrackInfos.ToArray());
				}
				break;
			}
			case FunctionControlVisibility.Visible:
			{
				_ListBox.Items.Clear();
				UserTrackInfoList userTrackInfos = _WriterControl.UserTrackInfos;
				userTrackInfos.Refresh();
				if (userTrackInfos.Count > 0)
				{
					_ListBox.Items.AddRange(userTrackInfos.ToArray());
				}
				_Visible = true;
				break;
			}
			case FunctionControlVisibility.Hide:
				_Visible = false;
				break;
			}
		}

		/// <summary>
		///       处理编辑器控件的SelectionChanged事件
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★★★★★已作废")]
		public void HandleWriterControlSelectionChanged()
		{
		}

		/// <summary>
		///       处理编辑器控件的SelectionChanged事件
		///       </summary>
		private void InnerHandleWriterControlSelectionChanged()
		{
			if (_ListBox.IsHandleCreated && !_ListBox.IsDisposed && !_HandlingEvent)
			{
				_HandlingEvent = true;
				_HandlingEvent = true;
				try
				{
					if (_ListBox != null && _WriterControl != null)
					{
						UserTrackInfo current = _WriterControl.UserTrackInfos.Current;
						if (current != null)
						{
							_HandlingEvent = true;
							int num = _ListBox.Items.IndexOf(current);
							if (num >= 0)
							{
								_ListBox.SelectedIndex = num;
							}
							else
							{
								foreach (UserTrackInfo item in _ListBox.Items)
								{
									if (item.Elements != null && item.Elements.FirstElement == current.Elements.FirstElement)
									{
										_ListBox.SelectedItem = item;
										break;
									}
								}
							}
							_HandlingEvent = false;
						}
					}
				}
				finally
				{
					_HandlingEvent = false;
				}
			}
		}

		public virtual string GetDispalyTitle(UserTrackInfo info)
		{
			if (info == null)
			{
				return "";
			}
			return info.StdTitle;
		}

		/// <summary>
		///       计算项目的显示大小
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			if (e.Index >= 0 && e.Index < listBox.Items.Count)
			{
				Font font = listBox.Font;
				UserTrackInfo userTrackInfo = (UserTrackInfo)listBox.Items[e.Index];
				if (string.IsNullOrEmpty(userTrackInfo.Text))
				{
					e.ItemHeight = (int)font.GetHeight(e.Graphics) + 3;
				}
				SizeF sizeF = e.Graphics.MeasureString(userTrackInfo.Text, font, listBox.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, StringFormat.GenericDefault);
				e.ItemHeight = Math.Min(100, (int)(font.GetHeight(e.Graphics) + sizeF.Height + 10f));
			}
		}

		/// <summary>
		///       绘制项目
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			if (e.Index >= 0 && e.Index < listBox.Items.Count)
			{
				Font font = listBox.Font;
				UserTrackInfo userTrackInfo = (UserTrackInfo)listBox.Items[e.Index];
				e.DrawBackground();
				bool flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected || (e.State & DrawItemState.Focus) == DrawItemState.Focus;
				float height = font.GetHeight(e.Graphics);
				RectangleF rectangleF = new RectangleF(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, height + 3f);
				string dispalyTitle = GetDispalyTitle(userTrackInfo);
				e.Graphics.FillRectangle(flag ? Brushes.LightCyan : Brushes.Moccasin, rectangleF);
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					e.Graphics.DrawString(dispalyTitle, font, Brushes.Black, rectangleF, stringFormat);
				}
				e.Graphics.DrawRectangle(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Width - 1f, rectangleF.Height);
				if (!string.IsNullOrEmpty(userTrackInfo.Text))
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Near;
						stringFormat.LineAlignment = StringAlignment.Near;
						e.Graphics.DrawString(userTrackInfo.Text, font, flag ? SystemBrushes.HighlightText : SystemBrushes.ControlText, new RectangleF(e.Bounds.Left, rectangleF.Bottom + 2f, e.Bounds.Width, (float)e.Bounds.Bottom - rectangleF.Bottom - 2f), stringFormat);
					}
				}
			}
		}

		private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_WriterControl != null && _WriterControl.IsHandleCreated && !_WriterControl.IsDisposed && !_HandlingEvent)
			{
				_HandlingEvent = true;
				_HandlingEvent = true;
				try
				{
					UserTrackInfo info = (UserTrackInfo)_ListBox.SelectedItem;
					_WriterControl.NavigateByUserTrackInfo(info);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
				}
				finally
				{
					_HandlingEvent = false;
				}
			}
		}
	}
}
