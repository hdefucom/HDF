using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       工具箱分页元素
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class DCToolBoxTab
	{
		private string _Name = null;

		private string _Title = null;

		private Image _Image = null;

		private int _ImageIndex = -1;

		private string _ImageKey = null;

		private string _EmptyText = null;

		private bool _Expened = false;

		private DCToolBoxItemList _Items = new DCToolBoxItemList();

		[NonSerialized]
		private Rectangle _Bounds = Rectangle.Empty;

		[NonSerialized]
		private Rectangle _TitleBounds = Rectangle.Empty;

		private string _DefaultDataFormat = null;

		/// <summary>
		///       名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		[DefaultValue(null)]
		public Image Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
			}
		}

		[DefaultValue(-1)]
		public int ImageIndex
		{
			get
			{
				return _ImageIndex;
			}
			set
			{
				_ImageIndex = value;
			}
		}

		[DefaultValue(null)]
		public string ImageKey
		{
			get
			{
				return _ImageKey;
			}
			set
			{
				_ImageKey = value;
			}
		}

		/// <summary>
		///       内容为空时的文本
		///       </summary>
		[DefaultValue(null)]
		public string EmptyText
		{
			get
			{
				return _EmptyText;
			}
			set
			{
				_EmptyText = value;
			}
		}

		/// <summary>
		///       对象已经展开标记
		///       </summary>
		[DefaultValue(false)]
		public bool Expened
		{
			get
			{
				return _Expened;
			}
			set
			{
				_Expened = value;
			}
		}

		/// <summary>
		///       列表对象
		///       </summary>
		[Category("Data")]
		public DCToolBoxItemList Items
		{
			get
			{
				if (_Items == null)
				{
					_Items = new DCToolBoxItemList();
				}
				return _Items;
			}
			set
			{
				_Items = value;
			}
		}

		/// <summary>
		///       对象在视图中的边界
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		internal Rectangle Bounds
		{
			get
			{
				return _Bounds;
			}
			set
			{
				_Bounds = value;
			}
		}

		/// <summary>
		///       对象标题在视图中的边界
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(null)]
		internal Rectangle TitleBounds
		{
			get
			{
				return _TitleBounds;
			}
			set
			{
				_TitleBounds = value;
			}
		}

		/// <summary>
		///       默认的数据格式
		///       </summary>
		[DefaultValue(null)]
		public string DefaultDataFormat
		{
			get
			{
				return _DefaultDataFormat;
			}
			set
			{
				_DefaultDataFormat = value;
			}
		}

		public DCToolBoxItem AddItem(string text)
		{
			DCToolBoxItem dCToolBoxItem = new DCToolBoxItem();
			dCToolBoxItem.Text = text;
			Items.Add(dCToolBoxItem);
			return dCToolBoxItem;
		}

		public DCToolBoxItem AddItem(string text, object Value)
		{
			DCToolBoxItem dCToolBoxItem = new DCToolBoxItem();
			dCToolBoxItem.Text = text;
			dCToolBoxItem.Value = Value;
			Items.Add(dCToolBoxItem);
			return dCToolBoxItem;
		}

		public DCToolBoxItem AddItem(string name, string text, string Value)
		{
			DCToolBoxItem dCToolBoxItem = new DCToolBoxItem();
			dCToolBoxItem.Name = name;
			dCToolBoxItem.Text = text;
			dCToolBoxItem.Value = Value;
			Items.Add(dCToolBoxItem);
			return dCToolBoxItem;
		}

		public DCToolBoxItem AddItem(string name, string text, Image image_0, object Value, string dataFormat)
		{
			DCToolBoxItem dCToolBoxItem = new DCToolBoxItem();
			dCToolBoxItem.Name = name;
			dCToolBoxItem.Text = text;
			dCToolBoxItem.Image = image_0;
			dCToolBoxItem.Value = Value;
			dCToolBoxItem.DataFormat = dataFormat;
			Items.Add(dCToolBoxItem);
			return dCToolBoxItem;
		}
	}
}
