using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       创建表格使用的信息对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlType]
	[ComVisible(false)]
	public class XTextTableElementProperties : GClass8, ICloneable
	{
		private string _ID = null;

		private int _RowsCount = 3;

		private int _ColumnsCount = 3;

		private float _ColumnWidth = 0f;

		private float _RowHeight = 0f;

		private int _BorderWidth = 1;

		private Color _BorderColor = Color.Black;

		private DashStyle _BorderStyle = DashStyle.Solid;

		private float _CellPaddingLeft = 15f;

		private float _CellPaddingTop = 10f;

		private float _CellPaddingRight = 15f;

		private float _CellPaddingBottom = 10f;

		/// <summary>
		///       表格ID
		///       </summary>
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       表格行数
		///       </summary>
		[DefaultValue(3)]
		public int RowsCount
		{
			get
			{
				return _RowsCount;
			}
			set
			{
				_RowsCount = value;
			}
		}

		/// <summary>
		///       表格列数
		///       </summary>
		[DefaultValue(3)]
		public int ColumnsCount
		{
			get
			{
				return _ColumnsCount;
			}
			set
			{
				_ColumnsCount = value;
			}
		}

		/// <summary>
		///       用户指定的表格列宽度,为0则自动设置,单位Document
		///       </summary>
		[DefaultValue(0f)]
		public float ColumnWidth
		{
			get
			{
				return _ColumnWidth;
			}
			set
			{
				_ColumnWidth = value;
			}
		}

		/// <summary>
		///       用户指定的表格行高度,为0则自动设置,单位Document
		///       </summary>
		[DefaultValue(0f)]
		public float RowHeight
		{
			get
			{
				return _RowHeight;
			}
			set
			{
				_RowHeight = value;
			}
		}

		/// <summary>
		///       边框宽度
		///       </summary>
		[DefaultValue(1)]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = value;
			}
		}

		/// <summary>
		///       边框色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
			}
		}

		/// <summary>
		///       边框线样式
		///       </summary>
		[DefaultValue(DashStyle.Solid)]
		public DashStyle BorderStyle
		{
			get
			{
				return _BorderStyle;
			}
			set
			{
				_BorderStyle = value;
			}
		}

		/// <summary>
		///       单元格左内边距
		///       </summary>
		[DefaultValue(15f)]
		public float CellPaddingLeft
		{
			get
			{
				return _CellPaddingLeft;
			}
			set
			{
				_CellPaddingLeft = value;
			}
		}

		/// <summary>
		///       单元格上内边距
		///       </summary>
		[DefaultValue(10f)]
		public float CellPaddingTop
		{
			get
			{
				return _CellPaddingTop;
			}
			set
			{
				_CellPaddingTop = value;
			}
		}

		/// <summary>
		///       单元格右内边距
		///       </summary>
		[DefaultValue(15f)]
		public float CellPaddingRight
		{
			get
			{
				return _CellPaddingRight;
			}
			set
			{
				_CellPaddingRight = value;
			}
		}

		/// <summary>
		///       单元格下内边距
		///       </summary>
		[DefaultValue(10f)]
		public float CellPaddingBottom
		{
			get
			{
				return _CellPaddingBottom;
			}
			set
			{
				_CellPaddingBottom = value;
			}
		}

		/// <summary>
		///       不支持
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool ReadProperties(XTextElement element)
		{
			return false;
		}

		/// <summary>
		///       绘制预览图形
		///       </summary>
		/// <param name="g">图形绘制对象</param>
		/// <param name="bounds">边界</param>
		public virtual void DrawPreview(Graphics graphics_0, Rectangle bounds)
		{
			if (RowsCount > 0 && ColumnsCount > 0)
			{
				Color color = BorderColor;
				if (color.A == 0)
				{
					color = Color.Gray;
				}
				using (Pen pen = new Pen(color, BorderWidth))
				{
					pen.DashStyle = BorderStyle;
					float num = bounds.Width / ColumnsCount;
					float num2 = bounds.Height / RowsCount;
					for (int i = 0; i < RowsCount; i++)
					{
						for (int j = 0; j < ColumnsCount; j++)
						{
							graphics_0.DrawRectangle(pen, (float)bounds.Left + num * (float)j, (float)bounds.Top + num2 * (float)i, num, num2);
						}
					}
				}
			}
		}

		/// <summary>
		///       根据对象设置创建文档表格对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>创建的表格对象</returns>
		public override XTextElement CreateElement(XTextDocument document)
		{
			if (RowsCount <= 0 || ColumnsCount <= 0)
			{
				return null;
			}
			XTextTableElement xTextTableElement = new XTextTableElement();
			ApplyToElement(document, xTextTableElement, logUndo: false);
			return xTextTableElement;
		}

		/// <summary>
		///       根据对象参数来设置文档表格对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>创建的表格对象</returns>
		public override bool ApplyToElement(XTextDocument document, XTextElement element, bool logUndo)
		{
			XTextTableElement xTextTableElement = (XTextTableElement)element;
			xTextTableElement.CompressOwnerLineSpacing = false;
			xTextTableElement.OwnerDocument = document;
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			documentContentStyle.BorderColor = BorderColor;
			documentContentStyle.BorderWidth = BorderWidth;
			documentContentStyle.BorderStyle = BorderStyle;
			documentContentStyle.BorderLeft = true;
			documentContentStyle.BorderTop = true;
			documentContentStyle.BorderRight = true;
			documentContentStyle.BorderBottom = true;
			documentContentStyle.PaddingBottom = CellPaddingBottom;
			documentContentStyle.PaddingLeft = CellPaddingLeft;
			documentContentStyle.PaddingRight = CellPaddingRight;
			documentContentStyle.PaddingTop = CellPaddingTop;
			documentContentStyle.VerticalAlign = VerticalAlignStyle.Top;
			int styleIndex = document.ContentStyles.GetStyleIndex(documentContentStyle);
			float num = ColumnWidth;
			if (num <= 0f)
			{
				num = (document.PageSettings.ViewClientWidth - 30f) / (float)ColumnsCount;
			}
			float rowHeight = RowHeight;
			float defaultLineHeight = ((DocumentContentStyle)document.ContentStyles.Default).DefaultLineHeight;
			for (int i = 0; i < ColumnsCount; i++)
			{
				XTextTableColumnElement xTextTableColumnElement = xTextTableElement.CreateColumnInstance();
				xTextTableColumnElement.Width = num;
				xTextTableElement.AppendChildElement(xTextTableColumnElement);
			}
			for (int j = 0; j < RowsCount; j++)
			{
				XTextTableRowElement xTextTableRowElement = xTextTableElement.CreateRowInstance();
				xTextTableRowElement.SpecifyHeight = rowHeight;
				xTextTableRowElement.Height = defaultLineHeight;
				xTextTableRowElement.Top = (float)j * defaultLineHeight;
				xTextTableElement.AppendChildElement(xTextTableRowElement);
				for (int i = 0; i < ColumnsCount; i++)
				{
					XTextTableCellElement xTextTableCellElement = xTextTableElement.CreateCellInstance();
					xTextTableCellElement.StyleIndex = styleIndex;
					xTextTableCellElement.Left = num * (float)i;
					xTextTableCellElement.Top = 0f;
					xTextTableRowElement.AppendChildElement(xTextTableCellElement);
					xTextTableCellElement.AppendChildElement(new XTextParagraphFlagElement());
				}
			}
			xTextTableElement.ID = ID;
			return true;
		}

		/// <summary>
		///       显示用户界面来让用户设置对象数据
		///       </summary>
		/// <param name="args">命令参数</param>
		/// <returns>用户是否确认操作</returns>
		public override bool PromptNewElement(WriterCommandEventArgs args)
		{
			using (dlgInsertTable dlgInsertTable = new dlgInsertTable())
			{
				dlgInsertTable.TableCreationInfo = this;
				if (WriterControl.UIShowDialog(args.EditorControl, dlgInsertTable, null) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       显示编辑元素属性的对话框
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool PromptEditProperties(WriterCommandEventArgs args)
		{
			throw new NotSupportedException();
		}

		object ICloneable.Clone()
		{
			return (XTextTableElementProperties)MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XTextTableElementProperties Clone()
		{
			return (XTextTableElementProperties)MemberwiseClone();
		}
	}
}
