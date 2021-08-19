using DCSoft.Common;
using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       图片型的卡片内容项目
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCCardImageItem : DCCardContentItem
	{
		private XImageValue _ImageValue = null;

		/// <summary>
		///       图片对象
		///       </summary>
		[XmlIgnore]
		public Image Image
		{
			get
			{
				if (_ImageValue == null)
				{
					return null;
				}
				return _ImageValue.Value;
			}
			set
			{
				if (value == null)
				{
					_ImageValue = null;
				}
				else
				{
					_ImageValue = new XImageValue(value);
				}
			}
		}

		/// <summary>
		///       图片对象
		///       </summary>
		[DefaultValue(null)]
		public XImageValue ImageValue
		{
			get
			{
				return _ImageValue;
			}
			set
			{
				_ImageValue = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public override DCCardContentItem Clone()
		{
			DCCardImageItem dCCardImageItem = (DCCardImageItem)MemberwiseClone();
			if (_ImageValue != null)
			{
				dCCardImageItem._ImageValue = _ImageValue.Clone();
			}
			return dCCardImageItem;
		}

		/// <summary>
		///       绘制对象
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void OnPaint(DCCardContentItemPaintEventArgs args)
		{
			Image image = Image;
			if (args.Value != null)
			{
				image = (args.Value as Image);
			}
			if (image != null)
			{
				if (args.ListView != null)
				{
					args.ListView.method_1(image, args.ListViewItem);
				}
				args.Graphics.DrawImage(image, args.ViewBounds);
			}
		}
	}
}
