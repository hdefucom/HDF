using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       控件配置
	///       </summary>
	[ComVisible(false)]
	public class DCCardListViewConfig
	{
		private int _BlinkTimerInterval = 500;

		private int _CardWidth = 100;

		private int _CardHeight = 100;

		private int _CardSpacing = 5;

		private int _CardLineSpacing = 10;

		private string _CardBackColor = null;

		private string _SelectedCardBackColor = null;

		private string _CardBorderColor = null;

		private int _CardBorderWith = 1;

		private int _CardRoundRadio = 5;

		private bool _ShowCardShade = true;

		private string _ItemTooltipDataFieldName = null;

		private int _ImageAnimateInterval = 400;

		private bool _EnableSupperTooltip = true;

		private int _TooltipWidth = 100;

		private int _TooltipHeight = 100;

		private bool _JustifySpacing = true;

		private DCCardContentItemList _CardTemplate = new DCCardContentItemList();

		private DCCardContentItemList _TooltipContentTemplate = new DCCardContentItemList();

		/// <summary>
		///       闪烁的时间间隔，单位毫秒。
		///       </summary>
		[DefaultValue(500)]
		[Category("Behavior")]
		public int BlinkTimerInterval
		{
			get
			{
				return _BlinkTimerInterval;
			}
			set
			{
				_BlinkTimerInterval = value;
			}
		}

		/// <summary>
		///       卡片宽度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100)]
		public int CardWidth
		{
			get
			{
				return _CardWidth;
			}
			set
			{
				_CardWidth = value;
			}
		}

		/// <summary>
		///       卡片高度
		///       </summary>
		[DefaultValue(100)]
		[Category("Layout")]
		public int CardHeight
		{
			get
			{
				return _CardHeight;
			}
			set
			{
				_CardHeight = value;
			}
		}

		/// <summary>
		///       卡片水平间距
		///       </summary>
		[DefaultValue(5)]
		[Category("Layout")]
		public int CardSpacing
		{
			get
			{
				return _CardSpacing;
			}
			set
			{
				_CardSpacing = value;
			}
		}

		/// <summary>
		///       卡片垂直间距
		///       </summary>
		[DefaultValue(10)]
		[Category("Layout")]
		public int CardLineSpacing
		{
			get
			{
				return _CardLineSpacing;
			}
			set
			{
				_CardLineSpacing = value;
			}
		}

		/// <summary>
		///       卡片背景色
		///       </summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		public string CardBackColor
		{
			get
			{
				return _CardBackColor;
			}
			set
			{
				_CardBackColor = value;
			}
		}

		/// <summary>
		///       选中的卡片的背景色
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		public string SelectedCardBackColor
		{
			get
			{
				return _SelectedCardBackColor;
			}
			set
			{
				_SelectedCardBackColor = value;
			}
		}

		/// <summary>
		///       卡片边框色
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		public string CardBorderColor
		{
			get
			{
				return _CardBorderColor;
			}
			set
			{
				_CardBorderColor = value;
			}
		}

		/// <summary>
		///       卡片边框线宽度
		///       </summary>
		[DefaultValue(1)]
		[Category("Appearance")]
		public int CardBorderWith
		{
			get
			{
				return _CardBorderWith;
			}
			set
			{
				_CardBorderWith = value;
			}
		}

		/// <summary>
		///       卡片圆角半径
		///       </summary>
		[DefaultValue(5)]
		[Localizable(false)]
		[Category("Appearance")]
		public int CardRoundRadio
		{
			get
			{
				return _CardRoundRadio;
			}
			set
			{
				_CardRoundRadio = value;
			}
		}

		/// <summary>
		///       是否启用卡片阴影
		///       </summary>
		[Localizable(false)]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowCardShade
		{
			get
			{
				return _ShowCardShade;
			}
			set
			{
				_ShowCardShade = value;
			}
		}

		/// <summary>
		///       列表项目提示文本绑定的字段名
		///       </summary>
		[DefaultValue(null)]
		[Category("Data")]
		public string ItemTooltipDataFieldName
		{
			get
			{
				return _ItemTooltipDataFieldName;
			}
			set
			{
				_ItemTooltipDataFieldName = value;
			}
		}

		/// <summary>
		///       动画图片更新时间间隔
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(400)]
		public int ImageAnimateInterval
		{
			get
			{
				return _ImageAnimateInterval;
			}
			set
			{
				_ImageAnimateInterval = value;
			}
		}

		/// <summary>
		///       是否允许超级提示信息
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool EnableSupperTooltip
		{
			get
			{
				return _EnableSupperTooltip;
			}
			set
			{
				_EnableSupperTooltip = value;
			}
		}

		/// <summary>
		///       提示区域宽度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100)]
		public int TooltipWidth
		{
			get
			{
				return _TooltipWidth;
			}
			set
			{
				_TooltipWidth = value;
			}
		}

		/// <summary>
		///       提示区域高度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100)]
		public int TooltipHeight
		{
			get
			{
				return _TooltipHeight;
			}
			set
			{
				_TooltipHeight = value;
			}
		}

		/// <summary>
		///       两端对齐间距
		///       </summary>
		[Category("Layout")]
		[DefaultValue(true)]
		public bool JustifySpacing
		{
			get
			{
				return _JustifySpacing;
			}
			set
			{
				_JustifySpacing = value;
			}
		}

		/// <summary>
		///       卡片内容信息列表
		///       </summary>
		[XmlArrayItem("Rectangle", typeof(DCCardRectangleItem))]
		[XmlArrayItem("Image", typeof(DCCardImageItem))]
		[XmlArrayItem("ImageKey", typeof(DCCardImageListKeyItem))]
		[Category("Data")]
		[XmlArrayItem("String", typeof(DCCardStringItem))]
		public DCCardContentItemList CardTemplate
		{
			get
			{
				return _CardTemplate;
			}
			set
			{
				_CardTemplate = value;
			}
		}

		/// <summary>
		///       提示文本内容信息列表
		///       </summary>
		[XmlArrayItem("Image", typeof(DCCardImageItem))]
		[XmlArrayItem("ImageKey", typeof(DCCardImageListKeyItem))]
		[Category("Data")]
		[XmlArrayItem("Rectangle", typeof(DCCardRectangleItem))]
		[XmlArrayItem("String", typeof(DCCardStringItem))]
		public DCCardContentItemList TooltipContentItems
		{
			get
			{
				if (_TooltipContentTemplate == null)
				{
					_TooltipContentTemplate = new DCCardContentItemList();
				}
				return _TooltipContentTemplate;
			}
			set
			{
				_TooltipContentTemplate = value;
			}
		}

		internal void method_0(DCCardListViewControl dccardListViewControl_0)
		{
			int num = 5;
			if (dccardListViewControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			_CardTemplate = new DCCardContentItemList();
			foreach (DCCardContentItem item in dccardListViewControl_0.CardTemplate)
			{
				_CardTemplate.Add(item.Clone());
			}
			_TooltipContentTemplate = new DCCardContentItemList();
			foreach (DCCardContentItem tooltipContentItem in dccardListViewControl_0.TooltipContentItems)
			{
				_TooltipContentTemplate.Add(tooltipContentItem.Clone());
			}
			_BlinkTimerInterval = dccardListViewControl_0.BlinkTimerInterval;
			_CardBackColor = XMLSerializeHelper.ColorToString(dccardListViewControl_0.CardBackColor, Color.White);
			_CardBorderColor = XMLSerializeHelper.ColorToString(dccardListViewControl_0.CardBorderColor, Color.Black);
			_CardBorderWith = dccardListViewControl_0.CardBorderWith;
			_CardHeight = dccardListViewControl_0.CardHeight;
			_CardLineSpacing = dccardListViewControl_0.CardLineSpacing;
			_CardRoundRadio = dccardListViewControl_0.CardRoundRadio;
			_CardSpacing = dccardListViewControl_0.CardSpacing;
			_CardWidth = dccardListViewControl_0.CardWidth;
			_EnableSupperTooltip = dccardListViewControl_0.EnableSupperTooltip;
			_ImageAnimateInterval = dccardListViewControl_0.ImageAnimateInterval;
			_ItemTooltipDataFieldName = dccardListViewControl_0.ItemTooltipDataFieldName;
			_JustifySpacing = dccardListViewControl_0.JustifySpacing;
			_SelectedCardBackColor = XMLSerializeHelper.ColorToString(dccardListViewControl_0.SelectedCardBackColor, SystemColors.Highlight);
			_ShowCardShade = dccardListViewControl_0.ShowCardShade;
			_TooltipHeight = dccardListViewControl_0.TooltipHeight;
			_TooltipWidth = dccardListViewControl_0.TooltipWidth;
		}

		internal void method_1(DCCardListViewControl dccardListViewControl_0)
		{
			int num = 17;
			if (dccardListViewControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			dccardListViewControl_0.CardTemplate.Clear();
			foreach (DCCardContentItem item in CardTemplate)
			{
				dccardListViewControl_0.CardTemplate.Add(item.Clone());
			}
			dccardListViewControl_0.TooltipContentItems.Clear();
			foreach (DCCardContentItem tooltipContentItem in TooltipContentItems)
			{
				dccardListViewControl_0.TooltipContentItems.Add(tooltipContentItem.Clone());
			}
			dccardListViewControl_0.BlinkTimerInterval = _BlinkTimerInterval;
			dccardListViewControl_0.CardBackColor = XMLSerializeHelper.StringToColor(_CardBackColor, Color.White);
			dccardListViewControl_0.CardBorderColor = XMLSerializeHelper.StringToColor(_CardBorderColor, Color.Black);
			dccardListViewControl_0.CardBorderWith = _CardBorderWith;
			dccardListViewControl_0.CardHeight = _CardHeight;
			dccardListViewControl_0.CardLineSpacing = _CardLineSpacing;
			dccardListViewControl_0.CardRoundRadio = _CardRoundRadio;
			dccardListViewControl_0.CardSpacing = _CardSpacing;
			dccardListViewControl_0.CardWidth = _CardWidth;
			dccardListViewControl_0.EnableSupperTooltip = _EnableSupperTooltip;
			dccardListViewControl_0.ImageAnimateInterval = _ImageAnimateInterval;
			dccardListViewControl_0.ItemTooltipDataFieldName = _ItemTooltipDataFieldName;
			dccardListViewControl_0.JustifySpacing = _JustifySpacing;
			dccardListViewControl_0.SelectedCardBackColor = XMLSerializeHelper.StringToColor(_SelectedCardBackColor, SystemColors.Highlight);
			dccardListViewControl_0.ShowCardShade = _ShowCardShade;
			dccardListViewControl_0.TooltipHeight = _TooltipHeight;
			dccardListViewControl_0.TooltipWidth = _TooltipWidth;
		}
	}
}
