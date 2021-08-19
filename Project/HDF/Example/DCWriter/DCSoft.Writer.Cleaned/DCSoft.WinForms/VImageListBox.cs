using DCSoft.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class VImageListBox
	{
		private class Class10
		{
			public Image image_0 = null;

			public int int_0 = -1;

			public string string_0 = null;
		}

		private ImageList imageList_0 = null;

		private ListBox listBox_0 = null;

		private Dictionary<object, Class10> dictionary_0 = new Dictionary<object, Class10>();

		private static readonly object object_0 = new object();

		private bool bool_0 = true;

		public ImageList ImageList
		{
			get
			{
				return imageList_0;
			}
			set
			{
				imageList_0 = value;
			}
		}

		public ListBox.ObjectCollection Items => listBox_0.Items;

		/// <summary>
		///       列表项目高度
		///       </summary>
		public int ItemHeight
		{
			get
			{
				return listBox_0.ItemHeight;
			}
			set
			{
				listBox_0.ItemHeight = value;
			}
		}

		public string DisplayMember
		{
			get
			{
				return listBox_0.DisplayMember;
			}
			set
			{
				listBox_0.DisplayMember = value;
			}
		}

		public string ValueMember
		{
			get
			{
				return listBox_0.ValueMember;
			}
			set
			{
				listBox_0.ValueMember = value;
			}
		}

		/// <summary>
		///       自动销毁图片对象
		///       </summary>
		public bool AutoDisposeImage
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public VImageListBox(ListBox listBox_1)
		{
			BindingControl(listBox_1);
		}

		public void SetItemImage(object item, Image image_0)
		{
			method_0(item).image_0 = image_0;
		}

		public Image GetItemImage(object item)
		{
			return method_0(item).image_0;
		}

		public void SetItemImageIndex(object item, int imageIndex)
		{
			method_0(item).int_0 = imageIndex;
		}

		public void SetItemImageKey(object item, string imageKey)
		{
			method_0(item).string_0 = imageKey;
		}

		private Class10 method_0(object object_1)
		{
			if (object_1 == null)
			{
				object_1 = object_0;
			}
			if (dictionary_0.ContainsKey(object_1))
			{
				return dictionary_0[object_1];
			}
			Class10 @class = new Class10();
			dictionary_0[object_1] = @class;
			return @class;
		}

		public void BindingControl(ListBox listBox_1)
		{
			int num = 15;
			if (listBox_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			listBox_0 = listBox_1;
			listBox_0.DrawMode = DrawMode.OwnerDrawFixed;
			listBox_0.ItemHeight = ItemHeight;
			listBox_0.DrawItem += listBox_0_DrawItem;
			listBox_0.Disposed += listBox_0_Disposed;
		}

		private void listBox_0_Disposed(object sender, EventArgs e)
		{
			foreach (Class10 value in dictionary_0.Values)
			{
				if (value.image_0 != null)
				{
					if (AutoDisposeImage)
					{
						value.image_0.Dispose();
					}
					value.image_0 = null;
				}
			}
			dictionary_0.Clear();
		}

		private void listBox_0_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}
			e.DrawBackground();
			bool flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Image image = null;
			Class10 @class = method_0(listBox_0.Items[e.Index]);
			if (@class.image_0 != null)
			{
				image = @class.image_0;
			}
			else if (imageList_0 != null)
			{
				if (@class.int_0 >= 0 && @class.int_0 < imageList_0.Images.Count)
				{
					image = imageList_0.Images[@class.int_0];
				}
				else if (!string.IsNullOrEmpty(@class.string_0) && imageList_0.Images.ContainsKey(@class.string_0))
				{
					image = imageList_0.Images[@class.string_0];
				}
			}
			if (image != null)
			{
				DrawerUtil.DrawImageCenterAutoZoom(e.Graphics, new RectangleF(e.Bounds.Left, e.Bounds.Top, listBox_0.ItemHeight, listBox_0.ItemHeight), image);
			}
			string itemText = listBox_0.GetItemText(listBox_0.Items[e.Index]);
			if (!string.IsNullOrEmpty(itemText))
			{
				using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					RectangleF layoutRectangle = new RectangleF(e.Bounds.Left + listBox_0.ItemHeight, e.Bounds.Top, e.Bounds.Width - listBox_0.ItemHeight, e.Bounds.Height);
					e.Graphics.DrawString(itemText, listBox_0.Font, flag ? SystemBrushes.HighlightText : SystemBrushes.ControlText, layoutRectangle, stringFormat);
				}
			}
		}
	}
}
