using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	[Serializable]
	[DCPublishAPI]
	[DebuggerDisplay("Ruler:{Name}")]
	[Guid("85C8C8E4-68CC-4228-9736-6926ED9F6ECD")]
	[ComClass("85C8C8E4-68CC-4228-9736-6926ED9F6ECD", "B453DD01-FEEE-4126-9625-F64885E82BB9")]
	[ComVisible(true)]
	[DocumentComment]
	[XmlType("XTextRuler")]
	[ComDefaultInterface(typeof(IXTextRulerElement))]
	[ClassInterface(ClassInterfaceType.None)]
	public class XTextRulerElement : XTextObjectElement, IXTextRulerElement
	{
		internal const string CLASSID = "85C8C8E4-68CC-4228-9736-6926ED9F6ECD";

		internal const string CLASSID_Interface = "B453DD01-FEEE-4126-9625-F64885E82BB9";

		private int _heightScaleMark = 60;

		private int _heightScalelong = 50;

		private int _heightScaleshort = 30;

		private int _innerPadding = 2;

		private float _pwidth = 6f;

		private int Padding = 5;

		private float _width = 1300f;

		private float _height = 220f;

		/// <summary>
		///       当前疼痛标记所使用的字体，疼痛标记使用字符“▲”表示
		///       </summary>
		public XFontValue MarkFont;

		private float _rulerValue = 0f;

		private ScalePropertyList _Scales = null;

		private int _minScale = 0;

		private int _maxScale = 10;

		private bool _crosswise;

		private XFontValue _Font = new XFontValue();

		private string _precision = "#0.00";

		private Color _lineColor = Color.Black;

		/// <summary>
		///       标尺下方数字所用的字体
		///       </summary>
		private XFontValue RulerFont;

		/// <summary>
		///       鼠标点击X坐标
		///       </summary>
		private float _mouseX;

		/// <summary>
		///       是否是鼠标点击
		///       </summary>
		private bool mouse = false;

		/// <summary>
		///       对象宽度
		///       </summary>
		[DCDisplayName(typeof(XTextRulerElement), "Width")]
		[XmlAttribute]
		[DocumentComment]
		[DefaultValue(null)]
		[Browsable(true)]
		public override float Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[XmlAttribute]
		[DocumentComment]
		[DefaultValue(null)]
		[DCDisplayName(typeof(XTextRulerElement), "Height")]
		[Browsable(true)]
		public override float Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		/// <summary>
		///       当前的疼痛分数，此处不做校验
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		[DCDisplayName(typeof(XTextRulerElement), "RulerValue")]
		[XmlAttribute]
		[DocumentComment]
		public float RulerValue
		{
			get
			{
				return _rulerValue;
			}
			set
			{
				_rulerValue = value;
			}
		}

		/// <summary>
		///       自定义的刻度信息列表
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(XTextRulerElement), "Scales")]
		[DocumentComment]
		[XmlArrayItem("Scale", typeof(ScaleProperty))]
		[Browsable(true)]
		public ScalePropertyList Scales
		{
			get
			{
				if (_Scales == null)
				{
					_Scales = new ScalePropertyList();
				}
				return _Scales;
			}
			set
			{
				_Scales = value;
			}
		}

		/// <summary>
		///       存在有效的自定义的刻度信息
		///       </summary>
		internal bool HasScales => _Scales != null && _Scales.Count > 1;

		/// <summary>
		///       最低标尺刻度，默认为0。
		///       </summary>
		[XmlAttribute]
		[DocumentComment]
		[DefaultValue(null)]
		[DCDisplayName(typeof(XTextRulerElement), "MinScale")]
		[Browsable(true)]
		public int MinScale
		{
			get
			{
				return _minScale;
			}
			set
			{
				_minScale = value;
			}
		}

		/// <summary>
		///       最高标尺刻度，默认为10。
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(XTextRulerElement), "MaxScale")]
		[Browsable(true)]
		[DocumentComment]
		[DefaultValue(null)]
		public int MaxScale
		{
			get
			{
				return _maxScale;
			}
			set
			{
				_maxScale = value;
			}
		}

		/// <summary>
		///       横向设置默认为横向
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public bool Crosswise
		{
			get
			{
				return _crosswise;
			}
			set
			{
				_crosswise = value;
			}
		}

		/// <summary>
		///       字体
		///       </summary>
		[XmlAttribute]
		[DocumentComment]
		public XFontValue Font
		{
			get
			{
				return _Font;
			}
			set
			{
				_Font = value;
			}
		}

		/// <summary>
		///       数值精度默认为#0.00
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DocumentComment]
		[DCDisplayName(typeof(XTextRulerElement), "Precision")]
		[Browsable(true)]
		public string Precision
		{
			get
			{
				return _precision;
			}
			set
			{
				_precision = value;
			}
		}

		/// <summary>
		///       刻度线颜色默认黑色
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		[DCDisplayName(typeof(XTextRulerElement), "LineColor")]
		[XmlAttribute]
		[DocumentComment]
		public Color LineColor
		{
			get
			{
				return _lineColor;
			}
			set
			{
				_lineColor = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextRulerElement()
		{
			Font defaultFont = SystemFonts.DefaultFont;
			RulerFont = new XFontValue();
			MarkFont = new XFontValue();
			RulerFont.Value = defaultFont;
			MarkFont.Value = defaultFont;
			MarkFont.Bold = true;
			Crosswise = true;
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">事件参数</param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			bool designMode;
			if (!(designMode = OwnerDocument.Options.BehaviorOptions.DesignMode))
			{
				args.Cursor = Cursors.Arrow;
			}
			switch (args.Style)
			{
			case DocumentEventStyles.MouseEnter:
				if (!designMode && !base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				if (args.Button == MouseButtons.None)
				{
					InvalidateView();
					base.HandleDocumentEvent(args);
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				break;
			case DocumentEventStyles.MouseLeave:
				if (!designMode && !base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				if (args.Button == MouseButtons.None)
				{
					InvalidateView();
					base.HandleDocumentEvent(args);
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				break;
			case DocumentEventStyles.MouseDown:
				if (designMode)
				{
					break;
				}
				args.Cursor = Cursors.Arrow;
				if (!base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
				}
				else if (args.Button == MouseButtons.Left)
				{
					InvalidateView();
					if (OwnerDocument.EditorControl == null)
					{
					}
					base.HandleDocumentEvent(args);
					args.Handled = true;
					args.CancelBubble = true;
				}
				return;
			case DocumentEventStyles.MouseClick:
				if (args.Button != MouseButtons.Left || designMode)
				{
					break;
				}
				args.Cursor = Cursors.Arrow;
				if (!base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				InvalidateView();
				if (OwnerDocument != null && OwnerDocument.DocumentControler.CanModify(this))
				{
					mouse = true;
					_mouseX = args.ViewX;
					EditorRefreshView();
				}
				else
				{
					args.Handled = true;
					args.CancelBubble = true;
				}
				return;
			case DocumentEventStyles.MouseDblClick:
				if (args.Button == MouseButtons.Left && designMode && OwnerDocument != null && OwnerDocument.EditorControl != null)
				{
					return;
				}
				break;
			}
			base.HandleDocumentEvent(args);
			if (!designMode)
			{
				args.Cursor = Cursors.Arrow;
			}
		}

		/// <summary>
		///       标尺数据重置
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			if (!HasScales)
			{
				if (MaxScale < MinScale)
				{
					MinScale = 0;
					MaxScale = 10;
				}
				else if (RulerValue < (float)MinScale || RulerValue > (float)MaxScale)
				{
					RulerValue = MinScale;
				}
			}
		}

		/// <summary>
		///       绘制标尺
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			int num = 7;
			Brush red = Brushes.Red;
			base.DrawContent(args);
			SolidBrush solidBrush = new SolidBrush(RuntimeStyle.Color);
			SizeF sizeF = args.Graphics.MeasureString("▲", MarkFont);
			SizeF sizeF2 = args.Graphics.MeasureString(_rulerValue.ToString(), MarkFont);
			SizeF sizeF3 = args.Graphics.MeasureString("8", RulerFont);
			float num2 = sizeF2.Height + sizeF.Height + sizeF3.Height + (float)(_innerPadding * 3) + (float)((_heightScaleMark >= _heightScalelong) ? _heightScaleMark : _heightScalelong);
			float num3 = (float)(Padding * 2) + num2;
			float num4 = (ClientHeight - num3) / 2f + (float)Padding;
			int num5 = _maxScale - _minScale;
			float num6 = (float)((double)(ClientWidth - (float)(Padding * 2)) / ((double)num5 + 0.8));
			float num7 = (float)((double)Padding + 0.4 * (double)num6);
			float num8 = num4 + sizeF2.Height + (float)(_heightScaleMark - _heightScalelong) + (float)_innerPadding;
			float num9 = num8 + (float)(_heightScalelong - _heightScaleshort);
			float num10 = num8 + (float)_heightScalelong + (float)_innerPadding;
			float num11 = num7 - sizeF3.Width / 2f;
			float num12 = num10 + sizeF.Height + (float)_innerPadding;
			float num13 = num4;
			float num14 = num13 + sizeF2.Height + (float)_innerPadding;
			Pen pen = new Pen(_lineColor);
			Pen pen2 = new Pen(Color.Red);
			if (HasScales)
			{
				float num15 = (float)((double)ClientWidth * 0.9);
				for (int i = 0; i < Scales.Count; i++)
				{
					ScaleProperty scaleProperty = Scales[i];
					pen.Width = _pwidth;
					if (i > 0)
					{
						if (mouse)
						{
							float num16 = (_mouseX - (float)((double)ClientWidth * 0.05) - base.ViewBounds.X) / num15;
							if (num16 >= 0f && num16 <= 1f)
							{
								if (num16 <= Scales[i - 1].ScaleRate && num16 >= Scales[i].ScaleRate)
								{
									_rulerValue = float.Parse(((Scales[i - 1].Value - Scales[i].Value) * ((num16 - Scales[i].ScaleRate) / (Scales[i - 1].ScaleRate - Scales[i].ScaleRate)) + Scales[i].Value).ToString(_precision));
									float num17 = (_rulerValue - Scales[i].Value) / (Scales[i - 1].Value - Scales[i].Value) * (Scales[i - 1].ScaleRate - Scales[i].ScaleRate) + Scales[i].ScaleRate;
									args.Graphics.DrawString("▲", MarkFont.Value, Brushes.Red, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05) - sizeF.Width / 2f, base.ViewBounds.Y + num10 + pen.Width);
									args.Graphics.DrawLine(pen2, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14 + (float)_heightScaleMark);
									args.Graphics.DrawString(_rulerValue.ToString(), MarkFont.Value, red, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05) - args.Graphics.MeasureString(_rulerValue.ToString(), MarkFont).Width / 2f, base.ViewBounds.Y + num13);
								}
								if (num16 <= Scales[i].ScaleRate && num16 >= Scales[i - 1].ScaleRate)
								{
									_rulerValue = float.Parse(((Scales[i].Value - Scales[i - 1].Value) * ((num16 - Scales[i - 1].ScaleRate) / (Scales[i].ScaleRate - Scales[i - 1].ScaleRate)) + Scales[i - 1].Value).ToString(_precision));
									float num17 = (_rulerValue - Scales[i - 1].Value) / (Scales[i].Value - Scales[i - 1].Value) * (Scales[i].ScaleRate - Scales[i - 1].ScaleRate) + Scales[i - 1].ScaleRate;
									args.Graphics.DrawString("▲", MarkFont.Value, Brushes.Red, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05) - sizeF.Width / 2f, base.ViewBounds.Y + num10 + pen.Width);
									args.Graphics.DrawLine(pen2, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14, base.ViewBounds.X + num17 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14 + (float)_heightScaleMark);
									args.Graphics.DrawString(_rulerValue.ToString(), MarkFont.Value, red, base.ViewBounds.X + num17 * scaleProperty.ScaleRate + (float)((double)ClientWidth * 0.05) - args.Graphics.MeasureString(_rulerValue.ToString(), MarkFont).Width / 2f, base.ViewBounds.Y + num13);
								}
							}
						}
						else
						{
							if (RulerValue <= Scales[i - 1].Value && RulerValue >= Scales[i].Value)
							{
								float num18 = (RulerValue - Scales[i - 1].Value) / (Scales[i].Value - Scales[i - 1].Value);
								float num19 = num18 * (Scales[i].ScaleRate - Scales[i - 1].ScaleRate) + Scales[i - 1].ScaleRate;
								args.Graphics.DrawString("▲", MarkFont.Value, Brushes.Red, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05) - sizeF.Width / 2f, base.ViewBounds.Y + num10 + pen.Width);
								args.Graphics.DrawString(RulerValue.ToString(), MarkFont.Value, red, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05) - args.Graphics.MeasureString(RulerValue.ToString(), MarkFont).Width / 2f, base.ViewBounds.Y + num13);
								args.Graphics.DrawLine(pen2, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14 + (float)_heightScaleMark);
							}
							if (RulerValue >= Scales[i - 1].Value && RulerValue <= Scales[i].Value)
							{
								float num18 = (RulerValue - Scales[i - 1].Value) / (Scales[i].Value - Scales[i - 1].Value);
								float num19 = num18 * (Scales[i].ScaleRate - Scales[i - 1].ScaleRate) + Scales[i - 1].ScaleRate;
								args.Graphics.DrawString("▲", MarkFont.Value, Brushes.Red, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05) - sizeF.Width / 2f, base.ViewBounds.Y + num10 + pen.Width);
								args.Graphics.DrawString(RulerValue.ToString(), MarkFont.Value, red, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05) - args.Graphics.MeasureString(RulerValue.ToString(), MarkFont).Width / 2f, base.ViewBounds.Y + num13);
								args.Graphics.DrawLine(pen2, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14, base.ViewBounds.X + num19 * num15 + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num14 + (float)_heightScaleMark);
							}
						}
					}
					args.Graphics.DrawLine(pen, base.ViewBounds.X + num15 * scaleProperty.ScaleRate + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num9, base.ViewBounds.X + num15 * scaleProperty.ScaleRate + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num9 + (float)_heightScaleshort);
					args.Graphics.DrawString(Scales[i].Value.ToString(), MarkFont.Value, solidBrush, base.ViewBounds.X + num15 * scaleProperty.ScaleRate + (float)((double)ClientWidth * 0.05) - args.Graphics.MeasureString(Scales[i].Value.ToString(), MarkFont).Width / 2f, base.ViewBounds.Y + num12);
				}
				args.Graphics.DrawLine(pen, base.ViewBounds.X + (float)((double)ClientWidth * 0.05), base.ViewBounds.Y + num8 + (float)_heightScalelong, base.ViewBounds.X + (float)((double)ClientWidth * 0.05) + num15, base.ViewBounds.Y + num8 + (float)_heightScalelong);
				mouse = false;
			}
			else
			{
				for (int j = 0; j <= num5; j++)
				{
					pen.Width = _pwidth;
					args.Graphics.DrawLine(pen, base.ViewBounds.X + num7 + (float)j * num6, base.ViewBounds.Y + num9, base.ViewBounds.X + num7 + (float)j * num6, base.ViewBounds.Y + num9 + (float)_heightScaleshort);
				}
				pen.Width = _pwidth;
				args.Graphics.DrawLine(pen, base.ViewBounds.X + num7, base.ViewBounds.Y + num8 + (float)_heightScalelong, base.ViewBounds.X + num7 + num6 * (float)num5, base.ViewBounds.Y + num8 + (float)_heightScalelong);
				float num20 = (_rulerValue - (float)_minScale) / (float)(_maxScale - _minScale);
				float num21 = num6 * (float)num5 * num20;
				float num22 = num7 + num21 - sizeF.Width / 2f;
				if (mouse)
				{
					float num23 = (float)_minScale + (float)(_maxScale - _minScale) * ((_mouseX - num7 - base.ViewBounds.X) / (num6 * (float)num5));
					float num24 = (float.Parse(num23.ToString(_precision)) - (float)_minScale) / (float)(_maxScale - _minScale);
					if (num23 >= (float)_minScale && num23 <= (float)_maxScale)
					{
						args.Graphics.DrawString("▲", MarkFont.Value, red, base.ViewBounds.X + num7 + num24 * num6 * (float)num5 - sizeF.Width / 2f, base.ViewBounds.Y + num10 + pen.Width);
						pen.Width = _pwidth;
						pen.Brush = red;
						args.Graphics.DrawLine(pen, base.ViewBounds.X + num7 + num24 * num6 * (float)num5, base.ViewBounds.Y + num14, base.ViewBounds.X + num7 + num24 * num6 * (float)num5, base.ViewBounds.Y + num14 + (float)_heightScaleMark);
						_rulerValue = float.Parse(num23.ToString(_precision));
						args.Graphics.DrawString(_rulerValue.ToString(), MarkFont.Value, red, base.ViewBounds.X + num7 + num24 * num6 * (float)num5 - args.Graphics.MeasureString(_rulerValue.ToString(), MarkFont).Width / 2f, base.ViewBounds.Y + num13);
					}
				}
				else
				{
					args.Graphics.DrawString("▲", MarkFont.Value, red, base.ViewBounds.X + num22, base.ViewBounds.Y + num10 + pen.Width);
					float num25 = num7 + num21;
					float num26 = num7 + num21 - sizeF2.Width / 2f;
					args.Graphics.DrawString(_rulerValue.ToString(), MarkFont.Value, red, base.ViewBounds.X + num26, base.ViewBounds.Y + num13);
					pen.Width = _pwidth;
					pen.Brush = red;
					args.Graphics.DrawLine(pen, base.ViewBounds.X + num25, base.ViewBounds.Y + num14, base.ViewBounds.X + num25, base.ViewBounds.Y + num14 + (float)_heightScaleMark);
				}
				int num27 = 0;
				for (int j = _minScale; j <= _maxScale; j++)
				{
					args.Graphics.DrawString(j.ToString(), RulerFont.Value, solidBrush, base.ViewBounds.X + num11 + (float)num27 * num6, base.ViewBounds.Y + num12);
					num27++;
				}
				mouse = false;
			}
			pen.Dispose();
			pen2.Dispose();
			solidBrush.Dispose();
		}
	}
}
