using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms.Native;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印预览控件对象
	///       </summary>
	/// <remarks> 编制 袁永福
	///       </remarks>
	[ToolboxItem(false)]
	[ComVisible(false)]
	[DocumentComment]
	
	public class DCSimplePrintPreviewControl : UserControl
	{
		private class Class46
		{
			public Image image_0 = null;

			public Size size_0 = Size.Empty;

			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;

			public int int_3 = 0;

			public PrintPage printPage_0 = null;
		}

		private DCPrintDocumentOptions dcprintDocumentOptions_0 = null;

		private bool bool_0 = false;

		private PrintDocument printDocument_0 = null;

		private bool bool_1 = false;

		private double double_0 = 1.0;

		private EventHandler eventHandler_0 = null;

		private int int_0 = 20;

		private bool bool_2 = false;

		private Color color_0 = SystemColors.Window;

		private int int_1 = -1;

		private EventHandler eventHandler_1 = null;

		private int int_2 = 1;

		private Dictionary<PrintPage, SimpleRectangleTransform> dictionary_0 = null;

		private bool bool_3 = false;

		private bool bool_4 = false;

		private bool bool_5 = false;

		private Point point_0 = new Point(0, 0);

		private List<Class46> list_0 = null;

		private PaintEventHandler paintEventHandler_0 = null;

		private Color color_1 = Color.FromArgb(100, 0, 255, 0);

		private bool bool_6 = true;

		private bool bool_7 = true;

		private Point point_1 = Point.Empty;

		/// <summary>
		///       文档选项
		///       </summary>
		[Browsable(false)]
		public DCPrintDocumentOptions Options
		{
			get
			{
				DCPrintDocumentOptions dCPrintDocumentOptions = null;
				if (Document is XPrintDocument)
				{
					dCPrintDocumentOptions = ((XPrintDocument)Document).Options;
				}
				if (dCPrintDocumentOptions == null)
				{
					if (dcprintDocumentOptions_0 == null)
					{
						dcprintDocumentOptions_0 = new DCPrintDocumentOptions();
					}
					dCPrintDocumentOptions = dcprintDocumentOptions_0;
				}
				return dCPrintDocumentOptions;
			}
			set
			{
				dcprintDocumentOptions_0 = value;
			}
		}

		/// <summary>
		///       处于等待模式
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool WaitingMode => GClass445.smethod_8(this);

		/// <summary>
		///       允许在打印预览的时候是否允许设置续打位置
		///       </summary>
		/// <remarks>
		///       如果允许设置，则在生成打印预览内容的时候绘制全部预览内容
		///       </remarks>
		[ComVisible(true)]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool EnableSetJumpPrintPosition
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

		/// <summary>
		///       是否处于区域选择模式
		///       </summary>
		private bool BoundsSelectionMode => Options != null && Options.BoundsSelection != null && Options.BoundsSelection.Enable;

		/// <summary>
		///       是否处于续打视图模式
		///       </summary>
		private bool JumpPrintDisplayMode
		{
			get
			{
				if (EnableSetJumpPrintPosition)
				{
					return Options != null && Options.JumpPrint != null && Options.JumpPrint.Enabled;
				}
				return false;
			}
		}

		/// <summary>
		///       打印文档对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintDocument Document
		{
			get
			{
				return printDocument_0;
			}
			set
			{
				printDocument_0 = value;
				InvalidateLayout();
			}
		}

		/// <summary>
		///       当前打印结果
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public PrintResult CurrentPrintResult
		{
			get
			{
				if (Document is XPrintDocument)
				{
					XPrintDocument xPrintDocument = (XPrintDocument)Document;
					return xPrintDocument.CurrentPrintResult;
				}
				return null;
			}
			set
			{
				if (Document is XPrintDocument)
				{
					XPrintDocument xPrintDocument = (XPrintDocument)Document;
					xPrintDocument.CurrentPrintResult = value;
				}
			}
		}

		/// <summary>
		///       自动缩放
		///       </summary>
		[DefaultValue(false)]
		public bool AutoZoom
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
		///       缩放比率
		///       </summary>
		[DefaultValue(1.0)]
		public double Zoom
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
				InvalidateLayout();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		///       页面之间的间距
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(20)]
		public int PageSpacing
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
				InvalidateLayout();
			}
		}

		/// <summary>
		///       显示预览时是否启用抗锯齿效果
		///       </summary>
		[DefaultValue(false)]
		public bool UseAntiAlias
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
		///       页面背景色
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "Window")]
		public Color PageBackColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		[Browsable(false)]
		public int PageCount
		{
			get
			{
				if (list_0 == null)
				{
					return 0;
				}
				return list_0.Count;
			}
		}

		/// <summary>
		///       当前起始页码号
		///       </summary>
		[DefaultValue(-1)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int StartPage
		{
			get
			{
				return int_1;
			}
			set
			{
				if (int_1 == value)
				{
					return;
				}
				method_0();
				if (list_0 != null && value >= 0 && value < list_0.Count)
				{
					int_1 = value;
					if (base.IsHandleCreated)
					{
						Class46 @class = list_0[int_1];
						Point autoScrollPosition = base.AutoScrollPosition;
						autoScrollPosition.Y = @class.int_1;
						base.AutoScrollPosition = autoScrollPosition;
						vmethod_0(EventArgs.Empty);
					}
				}
			}
		}

		/// <summary>
		///       页面分栏数
		///       </summary>
		[DefaultValue(1)]
		[Category("Layout")]
		public int PageColumns
		{
			get
			{
				return int_2;
			}
			set
			{
				if (int_2 <= 0)
				{
					int_2 = 1;
				}
				int_2 = value;
			}
		}

		/// <summary>
		///       正在生成预览用的内容
		///       </summary>
		[Browsable(false)]
		public bool GeneratingPreviewContent => bool_3;

		/// <summary>
		///       正在执行InvalidatePreview函数
		///       </summary>
		internal bool ExecutingInvalidatePreview => bool_4;

		/// <summary>
		///       续打时使用的遮盖颜色
		///       </summary>
		[DefaultValue(typeof(Color), "100,0,0,255")]
		[Browsable(true)]
		[ComVisible(true)]
		public Color MaskColorForJumpPrint
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
			}
		}

		/// <summary>
		///       是否启用鼠标操作行为。若该属性值为true，则控件本身不响应鼠标事件，但仍然触发MouseUp,MouseDown等鼠标事件。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool EnableMouseBehavior
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       是否允许用户修改打印输出区域
		///       </summary>
		[DefaultValue(true)]
		public bool AllowUserChangePrintArea
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		/// <summary>
		///       续打位置
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public float JumpPrintPosition
		{
			get
			{
				if (Options.JumpPrint == null)
				{
					return 0f;
				}
				return Options.JumpPrint.NativePosition;
			}
			set
			{
				PrintPageCollection printPageCollection = new PrintPageCollection();
				foreach (Class46 item in list_0)
				{
					printPageCollection.Add(item.printPage_0);
				}
				JumpPrintInfo jumpPrintInfo = Options.JumpPrint.Clone();
				JumpPrintInfo jumpPrint = Options.JumpPrint;
				jumpPrint.PageIndex = -1;
				jumpPrint.Position = 0f;
				float num = 0f;
				foreach (PrintPage item2 in printPageCollection)
				{
					if (value >= num && value < num + item2.Height)
					{
						IPageDocument document = item2.Document;
						if (document != null)
						{
							jumpPrint.PageIndex = jumpPrintInfo.PageIndex;
							jumpPrint.Position = jumpPrintInfo.Position;
							jumpPrint.EndPageIndex = -1;
							jumpPrint.SetNativeEndPosition(0f);
							float num2 = value;
							foreach (PrintPage item3 in printPageCollection)
							{
								if (item3.Document == document)
								{
									break;
								}
								num2 -= item3.Height;
							}
							JumpPrintInfo jumpPrintInfo2 = document.GetJumpPrintInfo(num2);
							jumpPrint.Mode = JumpPrintMode.Normal;
							if (jumpPrintInfo2 != null)
							{
								jumpPrint.PageIndex = printPageCollection.IndexOf(jumpPrintInfo2.Page);
								jumpPrint.Position = jumpPrintInfo2.Position;
							}
							else
							{
								jumpPrint.PageIndex = printPageCollection.IndexOf(item2);
								jumpPrint.Position = num2;
							}
							Invalidate();
						}
						break;
					}
					num += item2.Height;
				}
			}
		}

		/// <summary>
		///       缩放比率发生改变事件
		///       </summary>
		public event EventHandler ZoomChanged
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       起始页发生改变事件
		///       </summary>
		public event EventHandler StartPageChanged
		{
			add
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       绘制用户界面后事件
		///       </summary>
		public event PaintEventHandler AfterPaint
		{
			add
			{
				PaintEventHandler paintEventHandler = paintEventHandler_0;
				PaintEventHandler paintEventHandler2;
				do
				{
					paintEventHandler2 = paintEventHandler;
					PaintEventHandler value2 = (PaintEventHandler)Delegate.Combine(paintEventHandler2, value);
					paintEventHandler = Interlocked.CompareExchange(ref paintEventHandler_0, value2, paintEventHandler2);
				}
				while ((object)paintEventHandler != paintEventHandler2);
			}
			remove
			{
				PaintEventHandler paintEventHandler = paintEventHandler_0;
				PaintEventHandler paintEventHandler2;
				do
				{
					paintEventHandler2 = paintEventHandler;
					PaintEventHandler value2 = (PaintEventHandler)Delegate.Remove(paintEventHandler2, value);
					paintEventHandler = Interlocked.CompareExchange(ref paintEventHandler_0, value2, paintEventHandler2);
				}
				while ((object)paintEventHandler != paintEventHandler2);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCSimplePrintPreviewControl()
		{
			base.DoubleBuffered = true;
			AutoScroll = true;
		}

		protected virtual void vmethod_0(EventArgs eventArgs_0)
		{
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, eventArgs_0);
			}
		}

		/// <summary>
		///       控件内容无效，需要重新绘制
		///       </summary>
		public void InvalidatePreview()
		{
			if (Document != null && GClass154.smethod_2(this, bool_0: true))
			{
				bool_4 = true;
				try
				{
					CurrentPrintResult = null;
					list_0 = new List<Class46>();
					PrintController printController = Document.PrintController;
					PreviewPrintController previewPrintController = new PreviewPrintController();
					Document.PrintController = previewPrintController;
					JumpPrintInfo jumpPrintInfo = null;
					try
					{
						bool_3 = true;
						if (Document is XPrintDocument)
						{
							((XPrintDocument)Document).GeneratingPreviewContent = true;
						}
						JumpPrintInfo jumpPrintInfo2 = null;
						if (Options != null)
						{
							jumpPrintInfo2 = Options.JumpPrint;
						}
						if (jumpPrintInfo2 != null)
						{
							jumpPrintInfo = jumpPrintInfo2.Clone();
						}
						if (EnableSetJumpPrintPosition && jumpPrintInfo2 != null)
						{
							jumpPrintInfo2.Enabled = false;
						}
						Update();
						try
						{
							if (Document is XPrintDocument)
							{
								((XPrintDocument)Document).ForPrintPreview = true;
							}
							Document.Print();
						}
						finally
						{
							if (Document is XPrintDocument)
							{
								((XPrintDocument)Document).ForPrintPreview = false;
							}
						}
						if (Document is XPrintDocument)
						{
							XPrintDocument xPrintDocument = (XPrintDocument)Document;
							xPrintDocument.CurrentPrintResult = null;
							dictionary_0 = new Dictionary<PrintPage, SimpleRectangleTransform>();
							foreach (PrintPage key in xPrintDocument.PageBodyContentTransform.Keys)
							{
								dictionary_0[key] = xPrintDocument.PageBodyContentTransform[key];
							}
						}
					}
					finally
					{
						if (jumpPrintInfo != null)
						{
							Options.JumpPrint = jumpPrintInfo;
						}
						Document.PrintController = printController;
						bool_3 = false;
						if (Document is XPrintDocument)
						{
							((XPrintDocument)Document).GeneratingPreviewContent = false;
						}
					}
					PrintPageCollection printPageCollection = null;
					if (Document is XPrintDocument)
					{
						XPrintDocument xPrintDocument2 = (XPrintDocument)Document;
						printPageCollection = xPrintDocument2.PrintedPages;
					}
					PreviewPageInfo[] previewPageInfo = previewPrintController.GetPreviewPageInfo();
					for (int i = 0; i < previewPageInfo.Length; i++)
					{
						PreviewPageInfo previewPageInfo2 = previewPageInfo[i];
						Class46 @class = new Class46();
						@class.image_0 = previewPageInfo2.Image;
						@class.size_0 = previewPageInfo2.PhysicalSize;
						if (printPageCollection != null && printPageCollection.Count == previewPageInfo.Length)
						{
							@class.printPage_0 = printPageCollection[i];
						}
						list_0.Add(@class);
					}
					CurrentPrintResult = null;
					InvalidateLayout();
				}
				finally
				{
					bool_4 = false;
				}
			}
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			if (!WaitingMode && !base.DesignMode)
			{
				InvalidateLayout();
			}
		}

		public void InvalidateLayout()
		{
			bool_5 = true;
			if (base.IsHandleCreated)
			{
				Invalidate();
			}
		}

		private void method_0()
		{
			if (bool_5)
			{
				bool_5 = false;
				if (list_0 != null)
				{
					Size autoScrollMinSize = new Size(0, 0);
					using (Graphics graphics = CreateGraphics())
					{
						if (UseAntiAlias)
						{
							graphics.SmoothingMode = SmoothingMode.AntiAlias;
						}
						else
						{
							graphics.SmoothingMode = SmoothingMode.Default;
						}
						int num = PageSpacing;
						int width = base.ClientSize.Width;
						PointF pointF = new PointF(0f, 0f);
						point_0.X = (int)(Zoom * (double)pointF.X * (double)graphics.DpiX / 100.0);
						point_0.Y = (int)(Zoom * (double)pointF.Y * (double)graphics.DpiY / 100.0);
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						foreach (Class46 item in list_0)
						{
							item.int_2 = (int)(Zoom * (double)item.size_0.Width * (double)graphics.DpiX / 100.0);
							item.int_3 = (int)(Zoom * (double)item.size_0.Height * (double)graphics.DpiY / 100.0);
							num4 = Math.Max(num4, item.int_2);
						}
						int num5 = Math.Min(list_0.Count, PageColumns);
						num2 = num4 * num5;
						if (width >= num2)
						{
							num3 = (width - num2) / 2;
						}
						else
						{
							num3 = PageSpacing;
							autoScrollMinSize.Width = Math.Max(autoScrollMinSize.Width, num2 + PageSpacing * 2 + PageSpacing);
						}
						int num6 = 0;
						for (int i = 0; i < list_0.Count; i++)
						{
							Class46 current = list_0[i];
							int num7 = i % num5;
							current.int_0 = num3 + num4 * num7 + (num4 - current.int_2) / 2;
							if (num7 > 0)
							{
								current.int_0 += PageSpacing * num7;
							}
							current.int_1 = num;
							num6 = Math.Max(num6, current.int_3);
							if (num5 > 1)
							{
								if (i > 0 && num7 == 1)
								{
									num = num + num6 + PageSpacing;
									num6 = 0;
								}
							}
							else
							{
								num = num + num6 + PageSpacing;
								num6 = 0;
							}
							autoScrollMinSize.Height = Math.Max(autoScrollMinSize.Height, num + num6 + PageSpacing);
						}
					}
					base.AutoScrollMinSize = autoScrollMinSize;
				}
			}
		}

		public PointF method_1(int int_3, int int_4, int int_5)
		{
			if (dictionary_0 == null)
			{
				return PointF.Empty;
			}
			int num = int_3;
			if (num < 0)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (method_8(i).Contains(int_4 - base.AutoScrollPosition.X, int_5 - base.AutoScrollPosition.Y))
					{
						num = i;
						break;
					}
				}
			}
			if (num < 0)
			{
				return Point.Empty;
			}
			Class46 @class = list_0[num];
			int_4 = int_4 - base.AutoScrollPosition.X - point_0.X;
			int_5 = int_5 - base.AutoScrollPosition.Y - point_0.Y;
			PrintPage printPage_ = @class.printPage_0;
			if (dictionary_0.ContainsKey(printPage_))
			{
				SimpleRectangleTransform gClass = dictionary_0[printPage_];
				float float_ = printPage_.PageSettings.ViewPaperWidth * (float)(int_4 - @class.int_0) / (float)@class.int_2;
				float float_2 = printPage_.PageSettings.ViewPaperHeight * (float)(int_5 - @class.int_1) / (float)@class.int_3;
				PointF pointF_ = gClass.TransformPointF(float_, float_2);
				return RectangleCommon.MoveInto(pointF_, gClass.method_25());
			}
			return Point.Empty;
		}

		public float method_2(int int_3)
		{
			if (dictionary_0 == null)
			{
				return float.NaN;
			}
			int_3 = int_3 - base.AutoScrollPosition.Y - point_0.Y;
			int num = list_0.Count - 1;
			PrintPage printPage_;
			float num2;
			while (true)
			{
				if (num >= 0)
				{
					Class46 @class = list_0[num];
					if (int_3 >= @class.int_1 - 1)
					{
						printPage_ = @class.printPage_0;
						if (int_3 >= @class.int_1 + @class.int_3 - 1)
						{
							return printPage_.Top + printPage_.Height;
						}
						num2 = (float)(int_3 - @class.int_1) / (float)@class.int_3;
						num2 = printPage_.PageSettings.ViewPaperHeight * num2;
						if (dictionary_0.ContainsKey(printPage_))
						{
							break;
						}
					}
					num--;
					continue;
				}
				return float.NaN;
			}
			SimpleRectangleTransform gClass = dictionary_0[printPage_];
			if (!(num2 < gClass.getSourceRectF().Top))
			{
			}
			return gClass.TransformPointF(0f, num2).Y;
		}

		public int method_3(int int_3, float float_0, bool bool_8)
		{
			if (dictionary_0 == null)
			{
				return int.MinValue;
			}
			Class46 @class = null;
			foreach (Class46 item in list_0)
			{
				if (item.printPage_0.GlobalIndex == int_3)
				{
					@class = item;
					break;
				}
			}
			if (@class == null)
			{
				return int.MinValue;
			}
			if (bool_8 && Math.Abs(float_0) < 2f && int_3 > 0)
			{
				Class46 class2 = list_0[int_3 - 1];
				return (class2.int_1 + class2.int_3 + @class.int_1) / 2 + base.AutoScrollPosition.Y;
			}
			PrintPage printPage_ = @class.printPage_0;
			if (dictionary_0.ContainsKey(printPage_))
			{
				XPageSettings pageSettings = printPage_.PageSettings;
				SimpleRectangleTransform gClass = dictionary_0[printPage_];
				float y = gClass.UnTransformPointF(0f, float_0 + printPage_.Top).Y;
				float num = y / pageSettings.ViewPaperHeight;
				float num2 = (float)@class.int_1 + (float)@class.int_3 * num;
				return (int)(num2 + (float)base.AutoScrollPosition.Y + (float)point_0.Y);
			}
			return int.MinValue;
		}

		public float method_4(int int_3)
		{
			if (dictionary_0 == null)
			{
				return float.NaN;
			}
			int_3 = int_3 - base.AutoScrollPosition.X - point_0.X;
			int num = list_0.Count - 1;
			PrintPage printPage_;
			float num2;
			while (true)
			{
				if (num >= 0)
				{
					Class46 @class = list_0[num];
					if (int_3 >= @class.int_0 - 1)
					{
						printPage_ = @class.printPage_0;
						if (int_3 >= @class.int_0 + @class.int_2 - 1)
						{
							return printPage_.Left + printPage_.Width;
						}
						num2 = (float)(int_3 - @class.int_0) / (float)@class.int_2;
						num2 = printPage_.PageSettings.ViewPaperWidth * num2;
						if (dictionary_0.ContainsKey(printPage_))
						{
							break;
						}
					}
					num--;
					continue;
				}
				return float.NaN;
			}
			SimpleRectangleTransform gClass = dictionary_0[printPage_];
			if (!(num2 < gClass.getSourceRectF().Top))
			{
			}
			return gClass.TransformPointF(num2, 0f).X;
		}

		public int method_5(int int_3, float float_0, bool bool_8)
		{
			if (dictionary_0 == null)
			{
				return int.MinValue;
			}
			Class46 @class = null;
			foreach (Class46 item in list_0)
			{
				if (item.printPage_0.GlobalIndex == int_3)
				{
					@class = item;
					break;
				}
			}
			if (@class == null)
			{
				return int.MinValue;
			}
			if (bool_8 && Math.Abs(float_0) < 2f && int_3 > 0)
			{
				Class46 class2 = list_0[int_3 - 1];
				return (class2.int_0 + class2.int_2 + @class.int_0) / 2 + base.AutoScrollPosition.X;
			}
			PrintPage printPage_ = @class.printPage_0;
			if (dictionary_0.ContainsKey(printPage_))
			{
				XPageSettings pageSettings = printPage_.PageSettings;
				SimpleRectangleTransform gClass = dictionary_0[printPage_];
				float x = gClass.UnTransformPointF(0f, float_0 + printPage_.Top).X;
				float num = x / pageSettings.ViewPaperWidth;
				float num2 = (float)@class.int_0 + (float)@class.int_2 * num;
				return (int)(num2 + (float)base.AutoScrollPosition.X + (float)point_0.X);
			}
			return int.MinValue;
		}

		public Point method_6(int int_3, float float_0, float float_1)
		{
			if (dictionary_0 == null)
			{
				return Point.Empty;
			}
			if (dictionary_0 == null)
			{
				return Point.Empty;
			}
			Class46 @class = null;
			if (int_3 >= 0 && int_3 < list_0.Count)
			{
				@class = list_0[int_3];
			}
			if (@class == null)
			{
				foreach (PrintPage key in dictionary_0.Keys)
				{
					SimpleRectangleTransform gClass = dictionary_0[key];
					RectangleF rectangleF = gClass.method_25();
					rectangleF.Inflate(20f, 20f);
					if (rectangleF.Contains(float_0, float_1))
					{
						foreach (Class46 item in list_0)
						{
							if (item.printPage_0 == key)
							{
								@class = item;
								break;
							}
						}
						break;
					}
				}
			}
			if (@class != null && dictionary_0.ContainsKey(@class.printPage_0))
			{
				XPageSettings pageSettings = @class.printPage_0.PageSettings;
				SimpleRectangleTransform gClass = dictionary_0[@class.printPage_0];
				PointF pointF = gClass.UnTransformPointF(float_0, float_1);
				float num = pointF.X / pageSettings.ViewPaperWidth;
				float num2 = pointF.Y / pageSettings.ViewPaperHeight;
				float num3 = (float)@class.int_0 + (float)@class.int_2 * num;
				float num4 = (float)@class.int_1 + (float)@class.int_3 * num2;
				num3 += (float)(base.AutoScrollPosition.X + point_0.X);
				num4 += (float)(base.AutoScrollPosition.Y + point_0.Y);
				return new Point((int)num3, (int)num4);
			}
			return Point.Empty;
		}

		/// <summary>
		///       绘制控件内容
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			if (!base.DesignMode)
			{
				if (GClass445.smethod_10(this, pevent))
				{
					return;
				}
				method_0();
				if (list_0 == null)
				{
					if (paintEventHandler_0 != null)
					{
						paintEventHandler_0(this, pevent);
					}
					return;
				}
				Point autoScrollPosition = base.AutoScrollPosition;
				foreach (Class46 item in list_0)
				{
					Rectangle rectangle = new Rectangle(item.int_0 + autoScrollPosition.X, item.int_1 + autoScrollPosition.Y, item.int_2, item.int_3);
					if (!Rectangle.Intersect(rectangle, pevent.ClipRectangle).IsEmpty)
					{
						using (SolidBrush brush = new SolidBrush(PageBackColor))
						{
							pevent.Graphics.FillRectangle(brush, rectangle);
						}
						RectangleF rect = new RectangleF(rectangle.Left + point_0.X, rectangle.Top + point_0.Y, rectangle.Width, rectangle.Height);
						pevent.Graphics.DrawImage(item.image_0, rect);
						pevent.Graphics.DrawRectangle(Pens.Black, rectangle);
						if (BoundsSelectionMode)
						{
							using (Region region = new Region(rectangle))
							{
								List<Rectangle> list = new List<Rectangle>();
								foreach (BoundsSelectionPrintInfoItem item2 in Options.BoundsSelection)
								{
									if (item2.PageIndex == item.printPage_0.PageIndex)
									{
										Point point = method_6(item2.PageIndex, item2.ViewBounds.Left, item2.ViewBounds.Top);
										Point point2 = method_6(item2.PageIndex, item2.ViewBounds.Right, item2.ViewBounds.Bottom);
										if (!point.IsEmpty && !point2.IsEmpty)
										{
											Rectangle rectangle2 = new Rectangle(point.X, point.Y, point2.X - point.X, point2.Y - point.Y);
											if (rectangle2.Width > 0 && rectangle2.Height > 0)
											{
												list.Add(rectangle2);
												region.Exclude(rectangle2);
											}
										}
									}
								}
								using (SolidBrush brush = new SolidBrush(Color.FromArgb(140, PageBackColor)))
								{
									pevent.Graphics.FillRegion(brush, region);
								}
								if (list.Count > 0)
								{
									foreach (Rectangle item3 in list)
									{
										pevent.Graphics.DrawRectangle(Pens.Red, item3.Left, item3.Top, item3.Width - 1, item3.Height - 1);
									}
								}
							}
						}
					}
					else if (rectangle.Top > pevent.ClipRectangle.Bottom)
					{
						break;
					}
				}
				if (JumpPrintDisplayMode)
				{
					method_7(pevent.Graphics, pevent.ClipRectangle, Options.JumpPrint, MaskColorForJumpPrint);
				}
			}
			if (paintEventHandler_0 != null)
			{
				paintEventHandler_0(this, pevent);
			}
		}

		protected void method_7(Graphics graphics_0, Rectangle rectangle_0, JumpPrintInfo jumpPrintInfo_0, Color color_2)
		{
			if ((jumpPrintInfo_0?.Enabled ?? false) && (jumpPrintInfo_0.PageIndex >= 0 || jumpPrintInfo_0.EndPageIndex >= 0))
			{
				using (SolidBrush brush = new SolidBrush(color_2))
				{
					graphics_0.ResetClip();
					graphics_0.PageUnit = GraphicsUnit.Pixel;
					graphics_0.ResetTransform();
					for (int i = 0; i < list_0.Count; i++)
					{
						Class46 @class = list_0[i];
						Rectangle a = new Rectangle(@class.int_0 + base.AutoScrollPosition.X, @class.int_1 + base.AutoScrollPosition.Y, @class.int_2, @class.int_3);
						if (i == jumpPrintInfo_0.PageIndex && Math.Abs(jumpPrintInfo_0.Position) > 1f)
						{
							int num = method_3(jumpPrintInfo_0.PageIndex, jumpPrintInfo_0.Position, bool_8: true);
							if (num != int.MinValue)
							{
								Rectangle a2 = new Rectangle(a.Left, a.Top, a.Width, num - a.Top);
								a2 = Rectangle.Intersect(a2, rectangle_0);
								if (!a2.IsEmpty)
								{
									graphics_0.FillRectangle(brush, a2);
									using (Pen pen = new Pen(Color.Blue, 2f))
									{
										graphics_0.DrawLine(pen, a.Left, num, a.Left + a.Width, num);
									}
								}
							}
						}
						if (i == jumpPrintInfo_0.EndPageIndex)
						{
							int num = method_3(jumpPrintInfo_0.EndPageIndex, jumpPrintInfo_0.EndPosition, bool_8: true);
							if (num != int.MinValue)
							{
								Rectangle a2 = new Rectangle(a.Left, num, a.Width, a.Bottom - num);
								a2 = Rectangle.Intersect(a2, rectangle_0);
								if (!a2.IsEmpty)
								{
									graphics_0.FillRectangle(brush, a2);
									using (Pen pen2 = new Pen(Color.Blue, 2f))
									{
										graphics_0.DrawLine(pen2, a2.Left, num, a2.Right, num);
									}
								}
							}
						}
						bool flag = false;
						if (jumpPrintInfo_0.PageIndex >= 0 && i < jumpPrintInfo_0.PageIndex)
						{
							flag = true;
						}
						if (jumpPrintInfo_0.EndPageIndex >= 0 && i > jumpPrintInfo_0.EndPageIndex)
						{
							flag = true;
						}
						if (flag)
						{
							Rectangle a2 = Rectangle.Intersect(a, rectangle_0);
							if (!a2.IsEmpty)
							{
								graphics_0.FillRectangle(brush, a2);
							}
						}
					}
				}
			}
		}

		/// <summary>
		///       控件滚动事件
		///       </summary>
		/// <param name="se">
		/// </param>
		protected override void OnScroll(ScrollEventArgs scrollEventArgs_0)
		{
			base.OnScroll(scrollEventArgs_0);
			if (WaitingMode)
			{
				return;
			}
			method_0();
			if (list_0 != null && list_0.Count > 0)
			{
				int num = -base.AutoScrollPosition.Y;
				Class46 @class = null;
				foreach (Class46 item in list_0)
				{
					if (item.int_1 + item.int_3 > num)
					{
						@class = item;
						break;
					}
				}
				if (@class == null)
				{
					@class = list_0[list_0.Count - 1];
				}
				int num2 = list_0.IndexOf(@class);
				if (int_1 != num2)
				{
					int_1 = num2;
					vmethod_0(EventArgs.Empty);
				}
			}
		}

		/// <summary>
		///       鼠标滚轮事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseWheel(mouseEventArgs_0);
			if (EnableMouseBehavior && !WaitingMode)
			{
				Point autoScrollPosition = base.AutoScrollPosition;
				if (mouseEventArgs_0.Delta > 0)
				{
					autoScrollPosition.Y = -autoScrollPosition.Y - 30;
				}
				else
				{
					autoScrollPosition.Y = -autoScrollPosition.Y + 30;
				}
				autoScrollPosition.X = -autoScrollPosition.X;
				base.AutoScrollPosition = autoScrollPosition;
				OnScroll(null);
			}
		}

		/// <summary>
		///       鼠标按键松开事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (EnableMouseBehavior && !WaitingMode)
			{
				point_1 = new Point(-1, -1);
				if (JumpPrintDisplayMode && AllowUserChangePrintArea)
				{
					Cursor = Cursors.Default;
				}
				else
				{
					Cursor = GClass291.smethod_4();
				}
			}
		}

		/// <summary>
		///       鼠标移动事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			base.OnMouseMove(mevent);
			if (!EnableMouseBehavior || WaitingMode)
			{
				return;
			}
			if (AllowUserChangePrintArea)
			{
				if (BoundsSelectionMode)
				{
					Cursor = Cursors.Cross;
					return;
				}
				if (JumpPrintDisplayMode)
				{
					return;
				}
			}
			if (mevent.Button == MouseButtons.Left)
			{
				if (point_1.X >= 0)
				{
					int num = mevent.X - point_1.X;
					int num2 = mevent.Y - point_1.Y;
					Point autoScrollPosition = base.AutoScrollPosition;
					autoScrollPosition.X = -autoScrollPosition.X - num;
					autoScrollPosition.Y = -autoScrollPosition.Y - num2;
					base.AutoScrollPosition = autoScrollPosition;
					OnScroll(null);
					point_1 = new Point(mevent.X, mevent.Y);
				}
			}
			else
			{
				point_1.X = -1;
			}
		}

		private Rectangle method_8(int int_3)
		{
			if (list_0 == null)
			{
				return Rectangle.Empty;
			}
			if (int_3 >= 0 && int_3 < list_0.Count)
			{
				Class46 @class = list_0[int_3];
				return new Rectangle(@class.int_0 - PageSpacing / 2, @class.int_1 - PageSpacing / 2, @class.int_2 + PageSpacing, @class.int_3 + PageSpacing);
			}
			return Rectangle.Empty;
		}

		/// <summary>
		///       鼠标按键按下事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (!EnableMouseBehavior || WaitingMode)
			{
				return;
			}
			Select();
			if (list_0 == null || list_0.Count == 0)
			{
				return;
			}
			if (BoundsSelectionMode && AllowUserChangePrintArea)
			{
				Cursor = Cursors.Cross;
				Rectangle a = MouseCapturer.smethod_0(this, mevent.X, mevent.Y);
				if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
				{
					Options.BoundsSelection.Clear();
				}
				if (!a.IsEmpty)
				{
					a.Offset(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
					for (int i = 0; i < list_0.Count; i++)
					{
						if (!method_8(i).Contains(mevent.X - base.AutoScrollPosition.X, mevent.Y - base.AutoScrollPosition.Y))
						{
							continue;
						}
						Class46 @class = list_0[i];
						Rectangle rectangle = Rectangle.Intersect(b: new Rectangle(@class.int_0, @class.int_1, @class.int_2, @class.int_3), a: a);
						if (!rectangle.IsEmpty)
						{
							PointF pointF = method_1(i, rectangle.X + base.AutoScrollPosition.X, rectangle.Y + base.AutoScrollPosition.Y);
							PointF pointF2 = method_1(i, rectangle.Right + base.AutoScrollPosition.X, rectangle.Bottom + base.AutoScrollPosition.Y);
							if (!pointF.IsEmpty && !pointF2.IsEmpty)
							{
								Options.BoundsSelection.AddItem(@class.printPage_0.PageIndex, new RectangleF(pointF.X, pointF.Y, pointF2.X - pointF.X, pointF2.Y - pointF.Y));
								Invalidate();
							}
							break;
						}
					}
				}
			}
			if (JumpPrintDisplayMode && AllowUserChangePrintArea)
			{
				Cursor = Cursors.Default;
				PrintPageCollection printPageCollection = new PrintPageCollection();
				foreach (Class46 item in list_0)
				{
					printPageCollection.Add(item.printPage_0);
				}
				JumpPrintInfo jumpPrintInfo = Options.JumpPrint.Clone();
				JumpPrintInfo jumpPrint = Options.JumpPrint;
				jumpPrint.PageIndex = -1;
				jumpPrint.Position = 0f;
				int num = mevent.Y - base.AutoScrollPosition.Y;
				int x = mevent.X - base.AutoScrollPosition.X;
				int i = list_0.Count - 1;
				Class46 class2;
				while (true)
				{
					if (i >= 0)
					{
						class2 = list_0[i];
						if (new Rectangle(class2.int_0 - PageSpacing / 2, class2.int_1 - PageSpacing / 2, class2.int_2 + PageSpacing, class2.int_3 + PageSpacing).Contains(x, num) && num > class2.int_1 - 2)
						{
							break;
						}
						i--;
						continue;
					}
					return;
				}
				PrintPage printPage_ = class2.printPage_0;
				IPageDocument document = printPage_.Document;
				if (document == null)
				{
					return;
				}
				float y = method_1(-1, mevent.X, mevent.Y).Y;
				if (Control.ModifierKeys == Keys.Control)
				{
					jumpPrint.PageIndex = jumpPrintInfo.PageIndex;
					jumpPrint.Position = jumpPrintInfo.Position;
					jumpPrint.EndPageIndex = -1;
					jumpPrint.SetNativeEndPosition(0f);
					JumpPrintInfo jumpPrintInfo2 = document.GetJumpPrintInfo(y);
					if (jumpPrintInfo2 != null && jumpPrintInfo2.NativePosition > jumpPrint.NativeEndPosition)
					{
						jumpPrint.EndPageIndex = jumpPrintInfo2.Page.GlobalIndex;
						jumpPrint.SetNativeEndPosition(y);
						jumpPrint.EndPosition = jumpPrintInfo2.Position;
					}
				}
				else
				{
					jumpPrint.PageIndex = document.Pages.IndexOf(printPage_);
					jumpPrint.SetNativePosition(y);
					jumpPrint.EndPageIndex = -1;
					jumpPrint.SetNativeEndPosition(0f);
					JumpPrintInfo jumpPrintInfo2 = document.GetJumpPrintInfo(y);
					if (jumpPrintInfo2 != null)
					{
						jumpPrint.PageIndex = jumpPrintInfo2.Page.GlobalIndex;
						jumpPrint.Position = jumpPrintInfo2.Position;
					}
					else
					{
						jumpPrint.PageIndex = printPage_.GlobalIndex;
						jumpPrint.Position = y;
					}
				}
				if (jumpPrint.PageIndex != jumpPrintInfo.PageIndex || jumpPrint.Position != jumpPrintInfo.Position || jumpPrint.EndPageIndex != jumpPrintInfo.EndPageIndex || jumpPrint.EndPosition != jumpPrintInfo.EndPosition)
				{
					Invalidate();
				}
			}
			else if (mevent.Button == MouseButtons.Left)
			{
				point_1 = new Point(mevent.X, mevent.Y);
				Cursor = GClass291.smethod_5();
			}
			else
			{
				point_1 = new Point(-1, -1);
			}
		}
	}
}
