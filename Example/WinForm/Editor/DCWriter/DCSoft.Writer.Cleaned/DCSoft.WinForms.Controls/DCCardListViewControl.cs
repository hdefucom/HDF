using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片式的视图列表控件
	///       </summary>
	/// <remarks>袁永福到此一游</remarks>
	[DefaultEvent("ItemClick")]
	[ToolboxItem(true)]
	[ComVisible(false)]
	[ToolboxBitmap(typeof(DCCardListViewControl))]
	public class DCCardListViewControl : UserControl
	{
		[DocumentComment]
		[ComVisible(false)]
		public static class GClass13
		{
			private class Class39
			{
				public Image image_0 = null;

				public int int_0 = 0;

				public int int_1 = 0;

				public FrameDimension frameDimension_0 = null;
			}

			private static List<Class39> list_0 = new List<Class39>();

			public static void smethod_0()
			{
				list_0.Clear();
			}

			public static bool smethod_1(Image image_0)
			{
				int num = 12;
				if (image_0 == null)
				{
					throw new ArgumentNullException("img");
				}
				foreach (Class39 item in list_0)
				{
					if (item.image_0 == image_0)
					{
						list_0.Remove(item);
						return true;
					}
				}
				return false;
			}

			public static bool smethod_2(Image image_0)
			{
				int num = 6;
				if (image_0 == null)
				{
					throw new ArgumentNullException("img");
				}
				foreach (Class39 item in list_0)
				{
					if (item.image_0 == image_0)
					{
						item.int_1++;
						item.image_0.SelectActiveFrame(item.frameDimension_0, item.int_1 % item.int_0);
						return true;
					}
				}
				return false;
			}

			public static bool smethod_3(Image image_0)
			{
				int num = 7;
				if (image_0 == null)
				{
					throw new ArgumentNullException("img");
				}
				foreach (Class39 item in list_0)
				{
					if (item.image_0 == image_0)
					{
						return true;
					}
				}
				if (ImageAnimator.CanAnimate(image_0))
				{
					Class39 current = new Class39();
					current.image_0 = image_0;
					current.frameDimension_0 = FrameDimension.Time;
					current.int_0 = image_0.GetFrameCount(current.frameDimension_0);
					list_0.Add(current);
					return true;
				}
				return false;
			}
		}

		private System.Windows.Forms.Timer timer_0 = null;

		private int int_0 = 500;

		private ImageList imageList_0 = null;

		private int int_1 = 100;

		private int int_2 = 100;

		private int int_3 = 5;

		private int int_4 = 10;

		private Color color_0 = Color.White;

		private Color color_1 = SystemColors.Highlight;

		private Color color_2 = Color.Black;

		private int int_5 = 1;

		private Image image_0 = null;

		private int int_6 = 5;

		private bool bool_0 = true;

		private object object_0 = null;

		private string string_0 = null;

		private int int_7 = 0;

		private int int_8 = 0;

		private bool bool_1 = true;

		private int int_9 = 0;

		private System.Windows.Forms.Timer timer_1 = null;

		private int int_10 = 400;

		private Dictionary<Image, bool> dictionary_0 = new Dictionary<Image, bool>();

		private DCCardListViewItemCollection dccardListViewItemCollection_0 = new DCCardListViewItemCollection();

		private DCCardListViewPaintItemEventHandler dccardListViewPaintItemEventHandler_0 = null;

		private DCCardListViewItem dccardListViewItem_0 = null;

		private DCCardListViewMouseEventHandlerForCom dccardListViewMouseEventHandlerForCom_0 = null;

		private DCCardListViewMouseEventHandler dccardListViewMouseEventHandler_0 = null;

		private DCCardListViewEventHandler dccardListViewEventHandler_0 = null;

		private DCCardListViewItem dccardListViewItem_1 = null;

		private DCCardListViewDragEventHandler dccardListViewDragEventHandler_0 = null;

		private DCCardListViewDragEventHandler dccardListViewDragEventHandler_1 = null;

		private DCCardContentItemList dccardContentItemList_0 = new DCCardContentItemList();

		private DCCardListViewItemCollection dccardListViewItemCollection_1 = new DCCardListViewItemCollection();

		private ToolTip toolTip_0 = null;

		private bool bool_2 = true;

		private int int_11 = 100;

		private int int_12 = 100;

		private DCCardContentItemList dccardContentItemList_1 = new DCCardContentItemList();

		/// <summary>
		///       闪烁的时间间隔，单位毫秒。
		///       </summary>
		[DefaultValue(500)]
		[Category("Behavior")]
		public int BlinkTimerInterval
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
				if (timer_0 != null)
				{
					timer_0.Interval = value;
				}
			}
		}

		/// <summary>
		///       图标列表
		///       </summary>
		[DefaultValue(null)]
		[Category("Appearance")]
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

		/// <summary>
		///       卡片宽度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100)]
		public int CardWidth
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		/// <summary>
		///       卡片高度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100)]
		public int CardHeight
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		/// <summary>
		///       卡片水平间距
		///       </summary>
		[Category("Layout")]
		[DefaultValue(5)]
		public int CardSpacing
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		/// <summary>
		///       卡片垂直间距
		///       </summary>
		[Category("Layout")]
		[DefaultValue(10)]
		public int CardLineSpacing
		{
			get
			{
				return int_4;
			}
			set
			{
				int_4 = value;
			}
		}

		/// <summary>
		///       卡片背景色
		///       </summary>
		[DefaultValue(typeof(Color), "White")]
		[Category("Appearance")]
		public Color CardBackColor
		{
			get
			{
				return color_0;
			}
			set
			{
				if (color_0 != value)
				{
					color_0 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       选中的卡片的背景色
		///       </summary>
		[DefaultValue(typeof(Color), "Highlight")]
		[Category("Appearance")]
		public Color SelectedCardBackColor
		{
			get
			{
				return color_1;
			}
			set
			{
				if (color_1 != value)
				{
					color_1 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       卡片边框色
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "Black")]
		public Color CardBorderColor
		{
			get
			{
				return color_2;
			}
			set
			{
				if (color_2 != value)
				{
					color_2 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
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
				return int_5;
			}
			set
			{
				if (int_5 != value)
				{
					int_5 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       卡片背景图片
		///       </summary>
		[Localizable(true)]
		[Category("Appearance")]
		[Bindable(true)]
		[DefaultValue(null)]
		public Image CardBackgroundImage
		{
			get
			{
				return image_0;
			}
			set
			{
				if (image_0 != value)
				{
					image_0 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       卡片圆角半径
		///       </summary>
		[Category("Appearance")]
		[Localizable(false)]
		[DefaultValue(5)]
		public int CardRoundRadio
		{
			get
			{
				return int_6;
			}
			set
			{
				if (int_6 != value)
				{
					int_6 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       是否启用卡片阴影
		///       </summary>
		[Category("Appearance")]
		[Localizable(false)]
		[DefaultValue(true)]
		public bool ShowCardShade
		{
			get
			{
				return bool_0;
			}
			set
			{
				if (bool_0 != value)
				{
					bool_0 = value;
					if (base.IsHandleCreated)
					{
						Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       数据源对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public object DataSource
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
				if (base.IsHandleCreated)
				{
					RefreshDataSource();
				}
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
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       视图区域宽度
		///       </summary>
		[Browsable(false)]
		public int ViewWidth => int_7;

		/// <summary>
		///       视图区域高度
		///       </summary>
		[Browsable(false)]
		public int ViewHeight => int_8;

		/// <summary>
		///       两端对齐间距
		///       </summary>
		[Category("Layout")]
		[DefaultValue(true)]
		public bool JustifySpacing
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
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
				return int_10;
			}
			set
			{
				int_10 = value;
				if (timer_1 != null)
				{
					timer_1.Interval = value;
				}
			}
		}

		/// <summary>
		///       当前鼠标光标下的列表项目
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DCCardListViewItem MouseHoverItem => dccardListViewItem_0;

		/// <summary>
		///       卡片模板配置XML字符串
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string CardTemplateConfigXml
		{
			get
			{
				DCCardListViewConfig dCCardListViewConfig = new DCCardListViewConfig();
				dCCardListViewConfig.method_0(this);
				return XMLHelper.SaveObjectToIndentXMLString(dCCardListViewConfig);
			}
			set
			{
				DCCardListViewConfig dCCardListViewConfig = (DCCardListViewConfig)XMLHelper.LoadObjectFromXMLString(typeof(DCCardListViewConfig), value);
				if (dCCardListViewConfig != null)
				{
					dCCardListViewConfig.method_1(this);
					method_4();
				}
			}
		}

		/// <summary>
		///       卡片内容信息列表
		///       </summary>
		[Category("Data")]
		public DCCardContentItemList CardTemplate
		{
			get
			{
				return dccardContentItemList_0;
			}
			set
			{
				dccardContentItemList_0 = value;
			}
		}

		/// <summary>
		///       卡片列表
		///       </summary>
		[Category("Data")]
		public DCCardListViewItemCollection Items
		{
			get
			{
				if (dccardListViewItemCollection_1 == null)
				{
					dccardListViewItemCollection_1 = new DCCardListViewItemCollection();
				}
				dccardListViewItemCollection_1._ListView = this;
				return dccardListViewItemCollection_1;
			}
			set
			{
				dccardListViewItemCollection_1 = value;
			}
		}

		/// <summary>
		///       是否允许超级提示信息
		///       </summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool EnableSupperTooltip
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
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
				return int_11;
			}
			set
			{
				int_11 = value;
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
				return int_12;
			}
			set
			{
				int_12 = value;
			}
		}

		/// <summary>
		///       提示文本内容信息列表
		///       </summary>
		[Category("Data")]
		public DCCardContentItemList TooltipContentItems
		{
			get
			{
				if (dccardContentItemList_1 == null)
				{
					dccardContentItemList_1 = new DCCardContentItemList();
				}
				return dccardContentItemList_1;
			}
			set
			{
				dccardContentItemList_1 = value;
			}
		}

		/// <summary>
		///       绘制卡片项目事件
		///       </summary>
		public event DCCardListViewPaintItemEventHandler PaintCardItem
		{
			add
			{
				DCCardListViewPaintItemEventHandler dCCardListViewPaintItemEventHandler = dccardListViewPaintItemEventHandler_0;
				DCCardListViewPaintItemEventHandler dCCardListViewPaintItemEventHandler2;
				do
				{
					dCCardListViewPaintItemEventHandler2 = dCCardListViewPaintItemEventHandler;
					DCCardListViewPaintItemEventHandler value2 = (DCCardListViewPaintItemEventHandler)Delegate.Combine(dCCardListViewPaintItemEventHandler2, value);
					dCCardListViewPaintItemEventHandler = Interlocked.CompareExchange(ref dccardListViewPaintItemEventHandler_0, value2, dCCardListViewPaintItemEventHandler2);
				}
				while ((object)dCCardListViewPaintItemEventHandler != dCCardListViewPaintItemEventHandler2);
			}
			remove
			{
				DCCardListViewPaintItemEventHandler dCCardListViewPaintItemEventHandler = dccardListViewPaintItemEventHandler_0;
				DCCardListViewPaintItemEventHandler dCCardListViewPaintItemEventHandler2;
				do
				{
					dCCardListViewPaintItemEventHandler2 = dCCardListViewPaintItemEventHandler;
					DCCardListViewPaintItemEventHandler value2 = (DCCardListViewPaintItemEventHandler)Delegate.Remove(dCCardListViewPaintItemEventHandler2, value);
					dCCardListViewPaintItemEventHandler = Interlocked.CompareExchange(ref dccardListViewPaintItemEventHandler_0, value2, dCCardListViewPaintItemEventHandler2);
				}
				while ((object)dCCardListViewPaintItemEventHandler != dCCardListViewPaintItemEventHandler2);
			}
		}

		/// <summary>
		///       为COM定制的事件
		///       </summary>
		public event DCCardListViewMouseEventHandlerForCom COMEventItemMouseClick
		{
			add
			{
				DCCardListViewMouseEventHandlerForCom dCCardListViewMouseEventHandlerForCom = dccardListViewMouseEventHandlerForCom_0;
				DCCardListViewMouseEventHandlerForCom dCCardListViewMouseEventHandlerForCom2;
				do
				{
					dCCardListViewMouseEventHandlerForCom2 = dCCardListViewMouseEventHandlerForCom;
					DCCardListViewMouseEventHandlerForCom value2 = (DCCardListViewMouseEventHandlerForCom)Delegate.Combine(dCCardListViewMouseEventHandlerForCom2, value);
					dCCardListViewMouseEventHandlerForCom = Interlocked.CompareExchange(ref dccardListViewMouseEventHandlerForCom_0, value2, dCCardListViewMouseEventHandlerForCom2);
				}
				while ((object)dCCardListViewMouseEventHandlerForCom != dCCardListViewMouseEventHandlerForCom2);
			}
			remove
			{
				DCCardListViewMouseEventHandlerForCom dCCardListViewMouseEventHandlerForCom = dccardListViewMouseEventHandlerForCom_0;
				DCCardListViewMouseEventHandlerForCom dCCardListViewMouseEventHandlerForCom2;
				do
				{
					dCCardListViewMouseEventHandlerForCom2 = dCCardListViewMouseEventHandlerForCom;
					DCCardListViewMouseEventHandlerForCom value2 = (DCCardListViewMouseEventHandlerForCom)Delegate.Remove(dCCardListViewMouseEventHandlerForCom2, value);
					dCCardListViewMouseEventHandlerForCom = Interlocked.CompareExchange(ref dccardListViewMouseEventHandlerForCom_0, value2, dCCardListViewMouseEventHandlerForCom2);
				}
				while ((object)dCCardListViewMouseEventHandlerForCom != dCCardListViewMouseEventHandlerForCom2);
			}
		}

		/// <summary>
		///       列表项目点击事件
		///       </summary>
		public event DCCardListViewMouseEventHandler EventItemMouseClick
		{
			add
			{
				DCCardListViewMouseEventHandler dCCardListViewMouseEventHandler = dccardListViewMouseEventHandler_0;
				DCCardListViewMouseEventHandler dCCardListViewMouseEventHandler2;
				do
				{
					dCCardListViewMouseEventHandler2 = dCCardListViewMouseEventHandler;
					DCCardListViewMouseEventHandler value2 = (DCCardListViewMouseEventHandler)Delegate.Combine(dCCardListViewMouseEventHandler2, value);
					dCCardListViewMouseEventHandler = Interlocked.CompareExchange(ref dccardListViewMouseEventHandler_0, value2, dCCardListViewMouseEventHandler2);
				}
				while ((object)dCCardListViewMouseEventHandler != dCCardListViewMouseEventHandler2);
			}
			remove
			{
				DCCardListViewMouseEventHandler dCCardListViewMouseEventHandler = dccardListViewMouseEventHandler_0;
				DCCardListViewMouseEventHandler dCCardListViewMouseEventHandler2;
				do
				{
					dCCardListViewMouseEventHandler2 = dCCardListViewMouseEventHandler;
					DCCardListViewMouseEventHandler value2 = (DCCardListViewMouseEventHandler)Delegate.Remove(dCCardListViewMouseEventHandler2, value);
					dCCardListViewMouseEventHandler = Interlocked.CompareExchange(ref dccardListViewMouseEventHandler_0, value2, dCCardListViewMouseEventHandler2);
				}
				while ((object)dCCardListViewMouseEventHandler != dCCardListViewMouseEventHandler2);
			}
		}

		/// <summary>
		///       列表项目双击事件
		///       </summary>
		public event DCCardListViewEventHandler EventItemDoubleClick
		{
			add
			{
				DCCardListViewEventHandler dCCardListViewEventHandler = dccardListViewEventHandler_0;
				DCCardListViewEventHandler dCCardListViewEventHandler2;
				do
				{
					dCCardListViewEventHandler2 = dCCardListViewEventHandler;
					DCCardListViewEventHandler value2 = (DCCardListViewEventHandler)Delegate.Combine(dCCardListViewEventHandler2, value);
					dCCardListViewEventHandler = Interlocked.CompareExchange(ref dccardListViewEventHandler_0, value2, dCCardListViewEventHandler2);
				}
				while ((object)dCCardListViewEventHandler != dCCardListViewEventHandler2);
			}
			remove
			{
				DCCardListViewEventHandler dCCardListViewEventHandler = dccardListViewEventHandler_0;
				DCCardListViewEventHandler dCCardListViewEventHandler2;
				do
				{
					dCCardListViewEventHandler2 = dCCardListViewEventHandler;
					DCCardListViewEventHandler value2 = (DCCardListViewEventHandler)Delegate.Remove(dCCardListViewEventHandler2, value);
					dCCardListViewEventHandler = Interlocked.CompareExchange(ref dccardListViewEventHandler_0, value2, dCCardListViewEventHandler2);
				}
				while ((object)dCCardListViewEventHandler != dCCardListViewEventHandler2);
			}
		}

		/// <summary>
		///       检测能否拖拽数据的事件
		///       </summary>
		public event DCCardListViewDragEventHandler EventDetectDragItem
		{
			add
			{
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler = dccardListViewDragEventHandler_0;
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler2;
				do
				{
					dCCardListViewDragEventHandler2 = dCCardListViewDragEventHandler;
					DCCardListViewDragEventHandler value2 = (DCCardListViewDragEventHandler)Delegate.Combine(dCCardListViewDragEventHandler2, value);
					dCCardListViewDragEventHandler = Interlocked.CompareExchange(ref dccardListViewDragEventHandler_0, value2, dCCardListViewDragEventHandler2);
				}
				while ((object)dCCardListViewDragEventHandler != dCCardListViewDragEventHandler2);
			}
			remove
			{
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler = dccardListViewDragEventHandler_0;
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler2;
				do
				{
					dCCardListViewDragEventHandler2 = dCCardListViewDragEventHandler;
					DCCardListViewDragEventHandler value2 = (DCCardListViewDragEventHandler)Delegate.Remove(dCCardListViewDragEventHandler2, value);
					dCCardListViewDragEventHandler = Interlocked.CompareExchange(ref dccardListViewDragEventHandler_0, value2, dCCardListViewDragEventHandler2);
				}
				while ((object)dCCardListViewDragEventHandler != dCCardListViewDragEventHandler2);
			}
		}

		/// <summary>
		///       拖拽数据到列表项目上的事件
		///       </summary>
		public event DCCardListViewDragEventHandler EventDragDropItem
		{
			add
			{
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler = dccardListViewDragEventHandler_1;
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler2;
				do
				{
					dCCardListViewDragEventHandler2 = dCCardListViewDragEventHandler;
					DCCardListViewDragEventHandler value2 = (DCCardListViewDragEventHandler)Delegate.Combine(dCCardListViewDragEventHandler2, value);
					dCCardListViewDragEventHandler = Interlocked.CompareExchange(ref dccardListViewDragEventHandler_1, value2, dCCardListViewDragEventHandler2);
				}
				while ((object)dCCardListViewDragEventHandler != dCCardListViewDragEventHandler2);
			}
			remove
			{
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler = dccardListViewDragEventHandler_1;
				DCCardListViewDragEventHandler dCCardListViewDragEventHandler2;
				do
				{
					dCCardListViewDragEventHandler2 = dCCardListViewDragEventHandler;
					DCCardListViewDragEventHandler value2 = (DCCardListViewDragEventHandler)Delegate.Remove(dCCardListViewDragEventHandler2, value);
					dCCardListViewDragEventHandler = Interlocked.CompareExchange(ref dccardListViewDragEventHandler_1, value2, dCCardListViewDragEventHandler2);
				}
				while ((object)dCCardListViewDragEventHandler != dCCardListViewDragEventHandler2);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCCardListViewControl()
		{
			AutoScroll = true;
			DoubleBuffered = true;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		/// <param name="disposing">
		/// </param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (toolTip_0 != null)
			{
				toolTip_0.Dispose();
				toolTip_0 = null;
			}
			if (timer_0 != null)
			{
				timer_0.Dispose();
				timer_0 = null;
			}
			if (timer_1 != null)
			{
				timer_1.Dispose();
				timer_1 = null;
			}
		}

		/// <summary>
		///       加载控件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			timer_0 = new System.Windows.Forms.Timer();
			timer_0.Interval = int_0;
			timer_0.Tick += timer_0_Tick;
			timer_0.Start();
			timer_1 = new System.Windows.Forms.Timer();
			timer_1.Interval = int_10;
			timer_1.Tick += timer_1_Tick;
			timer_1.Start();
			if (!base.DesignMode)
			{
				method_5();
			}
			base.OnLoad(eventArgs_0);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			foreach (DCCardListViewItem item in Items)
			{
				if (item.Blink)
				{
					item._BlinkHighlight = !item._BlinkHighlight;
					RePaintItem(item);
				}
			}
		}

		/// <summary>
		///       清空内容
		///       </summary>
		[ComVisible(true)]
		public void Clear()
		{
			dccardListViewItemCollection_1.Clear();
			method_0();
			dccardListViewItem_1 = null;
			dccardListViewItem_0 = null;
			int_8 = 0;
			int_7 = 0;
		}

		/// <summary>
		///       刷新数据源，重新填充内容
		///       </summary>
		public void RefreshDataSource()
		{
			if (base.IsHandleCreated)
			{
				toolTip_0.Hide(this);
			}
			Clear();
			if (object_0 == null)
			{
				return;
			}
			GClass314 gClass = new GClass314();
			gClass.method_1(DataSource);
			foreach (DCCardContentItem item in CardTemplate)
			{
				if (gClass.method_4().method_0(item.DataField) == null)
				{
					gClass.method_4().method_1(item.DataField);
				}
			}
			bool flag = false;
			if (!string.IsNullOrEmpty(ItemTooltipDataFieldName))
			{
				gClass.method_4().method_1(ItemTooltipDataFieldName);
				flag = true;
			}
			if (TooltipContentItems != null && TooltipContentItems.Count > 0)
			{
				foreach (DCCardContentItem tooltipContentItem in TooltipContentItems)
				{
					if (gClass.method_4().method_0(tooltipContentItem.DataField) == null)
					{
						gClass.method_4().method_1(tooltipContentItem.DataField);
					}
				}
			}
			gClass.method_8();
			while (gClass.method_9())
			{
				DCCardListViewItem dCCardListViewItem = new DCCardListViewItem();
				dCCardListViewItem._DataBoundItem = gClass.method_10();
				Items.Add(dCCardListViewItem);
				dCCardListViewItem.Values = new Dictionary<DCCardContentItem, object>();
				foreach (DCCardContentItem item2 in CardTemplate)
				{
					object value = gClass.method_11(item2.DataField);
					dCCardListViewItem.Values[item2] = value;
				}
				if (dccardContentItemList_1 != null && dccardContentItemList_1.Count > 0)
				{
					dCCardListViewItem.TooltipValues = new Dictionary<DCCardContentItem, object>();
					foreach (DCCardContentItem item3 in dccardContentItemList_1)
					{
						object value = gClass.method_11(item3.DataField);
						dCCardListViewItem.TooltipValues[item3] = value;
					}
				}
				if (flag)
				{
					dCCardListViewItem.ToolTip = Convert.ToString(gClass.method_11(ItemTooltipDataFieldName));
				}
			}
			ExecuteLayout();
			Invalidate();
		}

		/// <summary>
		///       刷新文档内容
		///       </summary>
		[ComVisible(true)]
		public void RefreshView()
		{
			ExecuteLayout();
			Invalidate();
		}

		/// <summary>
		///       处理控件失去焦点事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			base.OnLostFocus(eventArgs_0);
			if (toolTip_0 != null)
			{
				toolTip_0.Hide(this);
			}
		}

		/// <summary>
		///       处理控件大小改变事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			HideSupperTooltip();
			ExecuteLayout();
			Invalidate();
		}

		/// <summary>
		///       重新刷新文档内容排版
		///       </summary>
		public void ExecuteLayout()
		{
			if (CardWidth <= 0 || CardHeight <= 0)
			{
				return;
			}
			int_8 = 0;
			int_7 = 0;
			int width = base.ClientSize.Width;
			if (width <= 1)
			{
				return;
			}
			int num = (int)Math.Floor((double)(width - CardSpacing) * 1.0 / (double)(CardWidth + CardSpacing));
			if (num < 1)
			{
				num = 1;
			}
			int num2 = CardLineSpacing;
			int val = (width - (CardWidth + CardSpacing) * num + CardSpacing) / 2;
			if (JustifySpacing)
			{
				num2 = (width - CardWidth * num) / (num + 1);
				num2 = Math.Max(num2, CardSpacing);
				val = num2;
			}
			val = Math.Max(val, CardSpacing);
			int num3 = val;
			int num4 = CardLineSpacing;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < Items.Count; i++)
			{
				DCCardListViewItem dCCardListViewItem = Items[i];
				dCCardListViewItem._Index = i;
				dCCardListViewItem._ListView = this;
				if (i > 0 && (dCCardListViewItem.AutoLine || num3 + CardWidth + num2 > width))
				{
					num3 = val;
					num4 = num4 + CardHeight + CardLineSpacing;
					num5++;
					num6 = 0;
				}
				dCCardListViewItem._RowIndex = num5;
				dCCardListViewItem._ColumnIndex = num6;
				dCCardListViewItem.Left = num3;
				dCCardListViewItem.Top = num4;
				dCCardListViewItem.Width = CardWidth;
				dCCardListViewItem.Height = CardHeight;
				int_7 = Math.Max(int_7, dCCardListViewItem.Left + dCCardListViewItem.Width);
				int_8 = Math.Max(int_8, dCCardListViewItem.Top + dCCardListViewItem.Height);
				num6++;
				num3 = num3 + CardWidth + num2;
			}
			int_9 = width;
			int_7 += num2;
			int_8 += CardLineSpacing;
			Size size = new Size(int_7, int_8);
			if (base.AutoScrollMinSize != size)
			{
				AutoScroll = false;
				base.AutoScrollMinSize = new Size(size.Width + 1, size.Height + 1);
				base.AutoScrollMinSize = size;
				AutoScroll = true;
				base.AutoScrollMinSize = size;
			}
		}

		/// <summary>
		///       获得项目的客户区边界
		///       </summary>
		/// <param name="item">项目对象</param>
		/// <returns>获得的边界矩形</returns>
		public Rectangle GetItemClientBounds(DCCardListViewItem item)
		{
			int num = 0;
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			Point autoScrollPosition = base.AutoScrollPosition;
			return new Rectangle(item.Left + autoScrollPosition.X, item.Top + autoScrollPosition.Y, item.Width, item.Height);
		}

		/// <summary>
		///       获得指定位置处的项目对象
		///       </summary>
		/// <param name="x">指定位置在客户区中的X坐标值</param>
		/// <param name="y">指定位置在客户区中的Y坐标值</param>
		/// <returns>返回找到的对象，若没有找到则返回空引用</returns>
		public DCCardListViewItem GetItemAt(int int_13, int int_14)
		{
			Point autoScrollPosition = base.AutoScrollPosition;
			int_13 -= autoScrollPosition.X;
			int_14 -= autoScrollPosition.Y;
			foreach (DCCardListViewItem item in Items)
			{
				if (new Rectangle(item.Left, item.Top, item.Width, item.Height).Contains(int_13, int_14))
				{
					return item;
				}
			}
			return null;
		}

		/// <summary>
		///       指定列表项目视图无效，需要重新绘制
		///       </summary>
		/// <param name="item">列表项目对象</param>
		public void InvalidateItem(DCCardListViewItem item)
		{
			int num = 8;
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (item.Width != 0 && item.Height != 0 && base.IsHandleCreated)
			{
				Rectangle itemClientBounds = GetItemClientBounds(item);
				itemClientBounds.Inflate(6, 6);
				Invalidate(itemClientBounds);
			}
		}

		/// <summary>
		///       指定列表项目视图无效，需要重新绘制
		///       </summary>
		/// <param name="itemIndex">列表项目序号</param>
		public void InvalidateItem(int itemIndex)
		{
			if (itemIndex >= 0 && itemIndex < Items.Count)
			{
				InvalidateItem(Items[itemIndex]);
			}
		}

		/// <summary>
		///       立即重新绘制指定的列表项目
		///       </summary>
		/// <param name="item">列表项目</param>
		public void RePaintItem(DCCardListViewItem item)
		{
			int num = 16;
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			Rectangle itemClientBounds = GetItemClientBounds(item);
			if (item.Pushed)
			{
				itemClientBounds.Offset(2, 2);
			}
			if (base.ClientRectangle.IntersectsWith(itemClientBounds))
			{
				Invalidate(itemClientBounds);
			}
		}

		/// <summary>
		///       立即重新绘制指定的列表项目
		///       </summary>
		/// <param name="items">列表项目列表</param>
		public void RePaintItems(DCCardListViewItemCollection items)
		{
			int num = 7;
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			using (CreateGraphics())
			{
				foreach (DCCardListViewItem item in items)
				{
					Rectangle itemClientBounds = GetItemClientBounds(item);
					if (item.Pushed)
					{
						itemClientBounds.Offset(2, 2);
					}
					if (base.ClientRectangle.IntersectsWith(itemClientBounds))
					{
						Invalidate(itemClientBounds);
					}
				}
			}
		}

		private void method_0()
		{
			if (dictionary_0.Count > 0)
			{
				foreach (Image key in dictionary_0.Keys)
				{
					GClass13.smethod_1(key);
				}
				dictionary_0.Clear();
			}
			dccardListViewItemCollection_0.Clear();
		}

		private void timer_1_Tick(object sender, EventArgs e)
		{
			if (dictionary_0.Count > 0 && dccardListViewItemCollection_0.Count > 0)
			{
				foreach (Image key in dictionary_0.Keys)
				{
					if (dictionary_0[key])
					{
						GClass13.smethod_2(key);
					}
				}
				RePaintItems(dccardListViewItemCollection_0);
			}
		}

		internal void method_1(Image image_1, DCCardListViewItem dccardListViewItem_2)
		{
			if (image_1 == null)
			{
				return;
			}
			bool flag = false;
			if (!dictionary_0.ContainsKey(image_1))
			{
				flag = ImageAnimator.CanAnimate(image_1);
				dictionary_0[image_1] = flag;
				if (flag)
				{
					GClass13.smethod_3(image_1);
				}
			}
			else
			{
				flag = dictionary_0[image_1];
			}
			if (flag && !dccardListViewItemCollection_0.Contains(dccardListViewItem_2))
			{
				dccardListViewItemCollection_0.Add(dccardListViewItem_2);
			}
		}

		protected virtual void vmethod_0(DCCardListViewPaintItemEventArgs dccardListViewPaintItemEventArgs_0)
		{
			GraphicsPath graphicsPath = null;
			Rectangle itemBounds = dccardListViewPaintItemEventArgs_0.ItemBounds;
			Rectangle rect = Rectangle.Intersect(itemBounds, dccardListViewPaintItemEventArgs_0.ClipRectangle);
			if (CardRoundRadio > 0)
			{
				graphicsPath = ShapeDrawer.CreateRoundRectanglePath(new RectangleF(itemBounds.Left, itemBounds.Top, itemBounds.Width, itemBounds.Height), CardRoundRadio);
			}
			if (ShowCardShade && !dccardListViewPaintItemEventArgs_0.Item.Pushed)
			{
				dccardListViewPaintItemEventArgs_0.Graphics.TranslateTransform(3f, 3f);
				if (graphicsPath == null)
				{
					dccardListViewPaintItemEventArgs_0.Graphics.FillRectangle(Brushes.Silver, itemBounds);
				}
				else
				{
					dccardListViewPaintItemEventArgs_0.Graphics.FillPath(Brushes.Silver, graphicsPath);
				}
				dccardListViewPaintItemEventArgs_0.Graphics.ResetTransform();
			}
			dccardListViewPaintItemEventArgs_0.Highlight = dccardListViewPaintItemEventArgs_0.Item.Highlight;
			if (!dccardListViewPaintItemEventArgs_0.Highlight && dccardListViewPaintItemEventArgs_0.Item.Blink)
			{
				dccardListViewPaintItemEventArgs_0.Highlight = dccardListViewPaintItemEventArgs_0.Item._BlinkHighlight;
			}
			if (dccardListViewPaintItemEventArgs_0.Highlight)
			{
				if (graphicsPath == null)
				{
					dccardListViewPaintItemEventArgs_0.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
				}
				else
				{
					dccardListViewPaintItemEventArgs_0.Graphics.FillPath(SystemBrushes.Highlight, graphicsPath);
				}
			}
			else
			{
				Color color = dccardListViewPaintItemEventArgs_0.Item.BackColor;
				if (color.A == 0)
				{
					color = CardBackColor;
				}
				if (color.A != 0 && CardBackgroundImage == null)
				{
					SolidBrush brush = GClass438.smethod_0(color);
					if (dccardListViewPaintItemEventArgs_0.Item.Selected && SelectedCardBackColor.A != 0)
					{
						brush = GClass438.smethod_0(SelectedCardBackColor);
					}
					if (graphicsPath == null)
					{
						dccardListViewPaintItemEventArgs_0.Graphics.FillRectangle(brush, rect);
					}
					else
					{
						dccardListViewPaintItemEventArgs_0.Graphics.FillPath(brush, graphicsPath);
					}
				}
				if (CardBackgroundImage != null)
				{
					if (graphicsPath != null)
					{
						dccardListViewPaintItemEventArgs_0.Graphics.SetClip(graphicsPath);
					}
					dccardListViewPaintItemEventArgs_0.Graphics.DrawImage(CardBackgroundImage, itemBounds);
					if (graphicsPath != null)
					{
						dccardListViewPaintItemEventArgs_0.Graphics.ResetClip();
					}
				}
			}
			foreach (DCCardContentItem item in CardTemplate)
			{
				DCCardContentItemPaintEventArgs dCCardContentItemPaintEventArgs = new DCCardContentItemPaintEventArgs(this, dccardListViewPaintItemEventArgs_0.Graphics, dccardListViewPaintItemEventArgs_0.ClipRectangle, dccardListViewPaintItemEventArgs_0.Item, item);
				dCCardContentItemPaintEventArgs.Highlight = dccardListViewPaintItemEventArgs_0.Highlight;
				dCCardContentItemPaintEventArgs.ViewBounds = new Rectangle(item.Left + itemBounds.Left, item.Top + itemBounds.Top, item.Width, item.Height);
				if (dccardListViewPaintItemEventArgs_0.Item.Values != null && dccardListViewPaintItemEventArgs_0.Item.Values.ContainsKey(item))
				{
					dCCardContentItemPaintEventArgs.Value = dccardListViewPaintItemEventArgs_0.Item.Values[item];
				}
				item.OnPaint(dCCardContentItemPaintEventArgs);
			}
			bool flag;
			if (!(flag = dccardListViewPaintItemEventArgs_0.Item.HighlightBorder) && dccardListViewPaintItemEventArgs_0.Item == dccardListViewItem_1)
			{
				flag = true;
			}
			if (flag)
			{
				using (Pen pen = new Pen(SystemColors.Highlight, 6f))
				{
					Rectangle rect2 = itemBounds;
					rect2.Inflate(-3, -3);
					if (graphicsPath == null)
					{
						dccardListViewPaintItemEventArgs_0.Graphics.DrawRectangle(pen, rect2);
					}
					else
					{
						using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(rect2, CardRoundRadio))
						{
							dccardListViewPaintItemEventArgs_0.Graphics.DrawPath(pen, path);
						}
					}
				}
			}
			else
			{
				Color color = dccardListViewPaintItemEventArgs_0.Item.BorderColor;
				if (color.A == 0)
				{
					color = CardBorderColor;
				}
				float num = dccardListViewPaintItemEventArgs_0.Item.BorderWidth;
				if (num == 0f)
				{
					num = CardBorderWith;
				}
				if (color.A != 0 && num > 0f)
				{
					using (Pen pen = new Pen(color, num))
					{
						if (graphicsPath == null)
						{
							dccardListViewPaintItemEventArgs_0.Graphics.DrawRectangle(pen, itemBounds);
						}
						else
						{
							dccardListViewPaintItemEventArgs_0.Graphics.DrawPath(pen, graphicsPath);
						}
					}
				}
			}
			if (dccardListViewPaintItemEventHandler_0 != null)
			{
				dccardListViewPaintItemEventHandler_0(this, dccardListViewPaintItemEventArgs_0);
			}
		}

		/// <summary>
		///       绘制控件内容
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnPaint(PaintEventArgs pevent)
		{
			int num = 10;
			base.OnPaint(pevent);
			if (base.DesignMode)
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					string s = GetType().FullName + ":" + base.Name + Environment.NewLine + WinFormsResources.DCName;
					pevent.Graphics.DrawString(s, Font, Brushes.Black, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
				}
				return;
			}
			pevent.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			_ = base.AutoScrollPosition.X;
			_ = base.AutoScrollPosition.Y;
			foreach (DCCardListViewItem item in Items)
			{
				Rectangle itemClientBounds = GetItemClientBounds(item);
				if (itemClientBounds.Top > pevent.ClipRectangle.Bottom)
				{
					break;
				}
				if (item.Pushed)
				{
					itemClientBounds.Offset(2, 2);
				}
				if (!Rectangle.Intersect(itemClientBounds, pevent.ClipRectangle).IsEmpty)
				{
					DCCardListViewPaintItemEventArgs dccardListViewPaintItemEventArgs_ = new DCCardListViewPaintItemEventArgs(pevent.Graphics, pevent.ClipRectangle, item, itemClientBounds);
					vmethod_0(dccardListViewPaintItemEventArgs_);
				}
			}
		}

		private void method_2(DCCardListViewItem dccardListViewItem_2)
		{
			if (dccardListViewItem_0 != dccardListViewItem_2)
			{
				if (dccardListViewItem_0 != null && dccardListViewItem_0.Pushed)
				{
					dccardListViewItem_0.Pushed = false;
					InvalidateItem(dccardListViewItem_0);
				}
				dccardListViewItem_0 = dccardListViewItem_2;
				if (dccardListViewItem_0 != null)
				{
					InvalidateItem(dccardListViewItem_0);
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (mevent.Button == MouseButtons.Left)
			{
				DCCardListViewItem itemAt = GetItemAt(mevent.X, mevent.Y);
				if (itemAt != null && !itemAt.Pushed)
				{
					itemAt.Pushed = true;
					InvalidateItem(itemAt);
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			int num = 17;
			base.OnMouseMove(mevent);
			DCCardListViewItem itemAt = GetItemAt(mevent.X, mevent.Y);
			if (mevent.Button == MouseButtons.Left && itemAt != null)
			{
				itemAt.Pushed = true;
			}
			if (itemAt != null && dccardListViewItem_0 != itemAt)
			{
				string text = itemAt.ToolTip;
				if (EnableSupperTooltip)
				{
					toolTip_0.Tag = itemAt;
					if (dccardContentItemList_1 != null && dccardContentItemList_1.Count > 0)
					{
						text = "   ";
					}
					Rectangle itemClientBounds = GetItemClientBounds(itemAt);
					int num2 = itemClientBounds.Right + 6;
					int num3 = itemClientBounds.Top + 3;
					Rectangle bounds = Screen.GetBounds(new Point(mevent.X, mevent.Y));
					bounds.Location = PointToClient(bounds.Location);
					if (num2 + TooltipWidth > bounds.Right)
					{
						num2 = itemClientBounds.Left - TooltipWidth - 6;
					}
					if (num3 + TooltipHeight > bounds.Bottom)
					{
						num3 = itemClientBounds.Top - TooltipHeight - 6;
						num2 = itemClientBounds.Left;
					}
					toolTip_0.Show(text, this, num2, num3, 3000);
				}
				else
				{
					toolTip_0.SetToolTip(this, text);
				}
			}
			if (itemAt == null)
			{
				toolTip_0.Tag = null;
				toolTip_0.SetToolTip(this, null);
			}
			method_2(itemAt);
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			base.OnMouseLeave(eventArgs_0);
			method_2(null);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			DCCardListViewItem itemAt = GetItemAt(mevent.X, mevent.Y);
			if (itemAt != null && itemAt.Pushed)
			{
				itemAt.Pushed = false;
				InvalidateItem(itemAt);
			}
		}

		/// <summary>
		///       处理鼠标点击事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseClick(mouseEventArgs_0);
			DCCardListViewItem itemAt = GetItemAt(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			if (itemAt != null)
			{
				DCCardListViewMouseEventArgs dccardListViewMouseEventArgs_ = new DCCardListViewMouseEventArgs(itemAt, mouseEventArgs_0);
				vmethod_1(dccardListViewMouseEventArgs_);
			}
		}

		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			toolTip_0.Hide(this);
			base.OnMouseWheel(mouseEventArgs_0);
		}

		public virtual void vmethod_1(DCCardListViewMouseEventArgs dccardListViewMouseEventArgs_0)
		{
			if (dccardListViewMouseEventHandler_0 != null)
			{
				dccardListViewMouseEventHandler_0(this, dccardListViewMouseEventArgs_0);
			}
			if (dccardListViewMouseEventHandlerForCom_0 != null)
			{
				dccardListViewMouseEventHandlerForCom_0(dccardListViewMouseEventArgs_0);
			}
		}

		/// <summary>
		///       处理鼠标双击事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseDoubleClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseDoubleClick(mouseEventArgs_0);
			if (mouseEventArgs_0.Button == MouseButtons.Left)
			{
				DCCardListViewItem itemAt = GetItemAt(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				if (itemAt != null)
				{
					DCCardListViewEventArgs dccardListViewEventArgs_ = new DCCardListViewEventArgs(itemAt);
					vmethod_2(dccardListViewEventArgs_);
				}
			}
		}

		public virtual void vmethod_2(DCCardListViewEventArgs dccardListViewEventArgs_0)
		{
			if (dccardListViewEventHandler_0 != null)
			{
				dccardListViewEventHandler_0(this, dccardListViewEventArgs_0);
			}
		}

		private void method_3(DCCardListViewItem dccardListViewItem_2)
		{
			if (dccardListViewItem_1 != dccardListViewItem_2)
			{
				DCCardListViewItem dCCardListViewItem = dccardListViewItem_1;
				dccardListViewItem_1 = dccardListViewItem_2;
				if (dCCardListViewItem != null)
				{
					RePaintItem(dCCardListViewItem);
				}
				if (dccardListViewItem_2 != null)
				{
					RePaintItem(dccardListViewItem_2);
				}
			}
		}

		/// <summary>
		///       处理OLE拖拽事件
		///       </summary>
		/// <param name="drgevent">参数</param>
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver(drgevent);
			if (drgevent.Effect != 0)
			{
				Point point = PointToClient(new Point(drgevent.X, drgevent.Y));
				DCCardListViewItem itemAt = GetItemAt(point.X, point.Y);
				if (itemAt == null)
				{
					drgevent.Effect = DragDropEffects.None;
				}
				else if (dccardListViewDragEventHandler_0 != null)
				{
					DCCardListViewDragEventArgs e = new DCCardListViewDragEventArgs(this, drgevent, itemAt);
					dccardListViewDragEventHandler_0(this, e);
				}
				if (drgevent.Effect == DragDropEffects.None)
				{
					method_3(null);
				}
				else
				{
					method_3(itemAt);
				}
			}
		}

		/// <summary>
		///       处理OLE拖拽的事件
		///       </summary>
		/// <param name="drgevent">参数</param>
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			base.OnDragEnter(drgevent);
			if (drgevent.Effect != 0)
			{
				Point point = PointToClient(new Point(drgevent.X, drgevent.Y));
				DCCardListViewItem itemAt = GetItemAt(point.X, point.Y);
				if (itemAt == null)
				{
					drgevent.Effect = DragDropEffects.None;
				}
				else if (dccardListViewDragEventHandler_0 != null)
				{
					DCCardListViewDragEventArgs e = new DCCardListViewDragEventArgs(this, drgevent, itemAt);
					dccardListViewDragEventHandler_0(this, e);
				}
				if (drgevent.Effect == DragDropEffects.None)
				{
					method_3(null);
				}
				else
				{
					method_3(itemAt);
				}
			}
		}

		/// <summary>
		///       处理OLE拖拽事件
		///       </summary>
		/// <param name="drgevent">参数</param>
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			base.OnDragDrop(drgevent);
			if (drgevent.Effect != 0)
			{
				Point point = PointToClient(new Point(drgevent.X, drgevent.Y));
				DCCardListViewItem itemAt = GetItemAt(point.X, point.Y);
				if (itemAt == null)
				{
					drgevent.Effect = DragDropEffects.None;
				}
				else if (dccardListViewDragEventHandler_1 != null)
				{
					DCCardListViewDragEventArgs e = new DCCardListViewDragEventArgs(this, drgevent, itemAt);
					dccardListViewDragEventHandler_1(this, e);
				}
				method_3(null);
			}
		}

		/// <summary>
		///       声明指定序号的项目视图无效，需要重新绘制
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		[ComVisible(true)]
		public void InvalidateItemByIndex(int itemIndex)
		{
			DCCardListViewItem dCCardListViewItem = Items.SafeGetItem(itemIndex);
			if (dCCardListViewItem != null)
			{
				InvalidateItem(dCCardListViewItem);
			}
		}

		/// <summary>
		///       设置指定项目高亮度显示状态
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		/// <param name="highlight">是否高亮度</param>
		[ComVisible(true)]
		public void SetListItemHighlight(int itemIndex, bool highlight)
		{
			DCCardListViewItem dCCardListViewItem = Items.SafeGetItem(itemIndex);
			if (dCCardListViewItem != null)
			{
				dCCardListViewItem.Highlight = highlight;
				InvalidateItem(dCCardListViewItem);
			}
		}

		/// <summary>
		///       设置指定项目闪烁
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		/// <param name="blink">是否闪烁</param>
		[ComVisible(true)]
		public void SetListItemBlink(int itemIndex, bool blink)
		{
			DCCardListViewItem dCCardListViewItem = Items.SafeGetItem(itemIndex);
			if (dCCardListViewItem != null)
			{
				dCCardListViewItem.Blink = blink;
			}
		}

		/// <summary>
		///       向列表项目添加文本内容
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		/// <param name="dataFieldName">数据源名称</param>
		/// <param name="textValue">文本值</param>
		[ComVisible(true)]
		public void SetListItemStringValue(int itemIndex, string dataFieldName, string textValue)
		{
			if (itemIndex >= 0 && itemIndex < Items.Count)
			{
				DCCardListViewItem dCCardListViewItem = Items[itemIndex];
				dCCardListViewItem.SetStringValue(dataFieldName, textValue);
			}
		}

		/// <summary>
		///       向列表项目添加图片内容
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		/// <param name="dataFieldName">数据源名称</param>
		/// <param name="fileName">图片文件名</param>
		[ComVisible(true)]
		public void SetListItemImageValueByFileName(int itemIndex, string dataFieldName, string fileName)
		{
			if (itemIndex >= 0 && itemIndex < Items.Count)
			{
				DCCardListViewItem dCCardListViewItem = Items[itemIndex];
				Image value = GClass343.smethod_8(fileName);
				dCCardListViewItem.SetValue(dataFieldName, value);
			}
		}

		/// <summary>
		///       向列表项目添加图片内容
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		/// <param name="dataFieldName">数据源名称</param>
		/// <param name="base64String">BASE64字符串</param>
		[ComVisible(true)]
		public void SetListItemImageValueByBase64String(int itemIndex, string dataFieldName, string base64String)
		{
			Items.SafeGetItem(itemIndex)?.SetImageValueByBase64String(dataFieldName, base64String);
		}

		/// <summary>
		///       向列表项目添加文本内容
		///       </summary>
		/// <param name="itemIndex">项目序号</param>
		/// <param name="dataFieldName">数据源名称</param>
		/// <param name="Value">文本值</param>
		[ComVisible(false)]
		public void SetListItemValue(int itemIndex, string dataFieldName, object Value)
		{
			if (itemIndex >= 0 && itemIndex < Items.Count)
			{
				DCCardListViewItem dCCardListViewItem = Items[itemIndex];
				dCCardListViewItem.SetValue(dataFieldName, Value);
			}
		}

		/// <summary>
		///       编辑卡片模板配置XML字符串
		///       </summary>
		/// <returns>操作是否修改了配置字符串</returns>
		[ComVisible(true)]
		public bool EditCardTemplateConfigXml()
		{
			using (frmConfigXML frmConfigXML = new frmConfigXML())
			{
				frmConfigXML.XMLText = CardTemplateConfigXml;
				if (frmConfigXML.ShowDialog(this) == DialogResult.OK)
				{
					CardTemplateConfigXml = frmConfigXML.XMLText;
					RefreshView();
					return true;
				}
			}
			return false;
		}

		internal void method_4()
		{
			foreach (DCCardListViewItem item in Items)
			{
				if (CardTemplate != null && item.Values != null)
				{
					Dictionary<DCCardContentItem, object> dictionary = new Dictionary<DCCardContentItem, object>();
					foreach (DCCardContentItem key in item.Values.Keys)
					{
						foreach (DCCardContentItem item2 in CardTemplate)
						{
							if (item2.DataField == key.DataField)
							{
								dictionary[item2] = item.Values[key];
								break;
							}
						}
					}
					item.Values = dictionary;
				}
				if (TooltipContentItems != null && item.TooltipValues != null)
				{
					Dictionary<DCCardContentItem, object> dictionary = new Dictionary<DCCardContentItem, object>();
					foreach (DCCardContentItem key2 in item.TooltipValues.Keys)
					{
						foreach (DCCardContentItem tooltipContentItem in TooltipContentItems)
						{
							if (tooltipContentItem.DataField == key2.DataField)
							{
								dictionary[tooltipContentItem] = item.TooltipValues[key2];
								break;
							}
						}
					}
					item.TooltipValues = dictionary;
				}
			}
		}

		/// <summary>
		///       添加新的列表项目
		///       </summary>
		/// <returns>新项目的序号</returns>
		[ComVisible(true)]
		public int AddNewItem()
		{
			DCCardListViewItem dCCardListViewItem = new DCCardListViewItem();
			dCCardListViewItem._ListView = this;
			Items.Add(dCCardListViewItem);
			return Items.Count - 1;
		}

		/// <summary>
		///       隐藏浮动提示文本区域
		///       </summary>
		public void HideSupperTooltip()
		{
			if (toolTip_0 != null)
			{
				toolTip_0.SetToolTip(this, null);
				toolTip_0.Hide(this);
			}
		}

		private void method_5()
		{
			toolTip_0 = new ToolTip();
			toolTip_0.OwnerDraw = true;
			toolTip_0.Popup += toolTip_0_Popup;
			toolTip_0.Draw += toolTip_0_Draw;
		}

		private void toolTip_0_Draw(object sender, DrawToolTipEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			if (!EnableSupperTooltip)
			{
				e.DrawBackground();
				e.DrawText();
				e.DrawBorder();
				return;
			}
			ToolTip toolTip = (ToolTip)sender;
			Rectangle bounds = e.Bounds;
			bounds.Width--;
			bounds.Height--;
			GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(bounds, 6);
			using (LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.FromArgb(254, 254, 254), Color.FromArgb(202, 217, 239), 90f))
			{
				e.Graphics.FillRectangle(brush, e.Bounds);
			}
			_ = (DCCardListViewControl)e.AssociatedControl;
			DCCardListViewItem dCCardListViewItem = (DCCardListViewItem)toolTip.Tag;
			Rectangle bounds2 = e.Bounds;
			foreach (DCCardContentItem item in dccardContentItemList_1)
			{
				DCCardContentItemPaintEventArgs dCCardContentItemPaintEventArgs = new DCCardContentItemPaintEventArgs(this, e.Graphics, bounds2, dCCardListViewItem, item);
				dCCardContentItemPaintEventArgs.Highlight = false;
				dCCardContentItemPaintEventArgs.ViewBounds = new Rectangle(item.Left + bounds2.Left, item.Top + bounds2.Top, item.Width, item.Height);
				if (dCCardListViewItem.TooltipValues != null && dCCardListViewItem.TooltipValues.ContainsKey(item))
				{
					dCCardContentItemPaintEventArgs.Value = dCCardListViewItem.TooltipValues[item];
				}
				item.OnPaint(dCCardContentItemPaintEventArgs);
			}
			e.Graphics.DrawPath(Pens.Black, path);
		}

		private void toolTip_0_Popup(object sender, PopupEventArgs e)
		{
			e.ToolTipSize = new Size(TooltipWidth, TooltipHeight);
		}
	}
}
