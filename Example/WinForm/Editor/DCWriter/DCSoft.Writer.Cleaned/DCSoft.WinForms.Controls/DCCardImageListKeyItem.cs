using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       图片型的卡片内容项目
	///       </summary>
	
	[ComVisible(false)]
	public class DCCardImageListKeyItem : DCCardContentItem
	{
		private string _ImageKey = null;

		/// <summary>
		///       图片关键字
		///       </summary>
		[XmlAttribute]
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

		public override void OnPaint(DCCardContentItemPaintEventArgs args)
		{
			ImageList imageList = args.ListView.ImageList;
			if (imageList == null)
			{
				return;
			}
			string text = null;
			int num = -1;
			if (args.Value is int)
			{
				num = (int)args.Value;
			}
			else
			{
				text = Convert.ToString(args.Value);
				if (string.IsNullOrEmpty(text))
				{
					text = ImageKey;
				}
				if (!string.IsNullOrEmpty(text))
				{
					num = imageList.Images.IndexOfKey(text);
				}
			}
			if (num >= 0 && num < imageList.Images.Count)
			{
				imageList.Draw(args.Graphics, args.ViewBounds.Left, args.ViewBounds.Top, args.ViewBounds.Width, args.ViewBounds.Height, num);
			}
		}
	}
}
