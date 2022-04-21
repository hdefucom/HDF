using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Commands;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       支持对图像进行分区标识与定义的图片文档元素
	///       </summary>
	[Serializable]
	
	[XmlInclude(typeof(ArrayList))]
	[XmlType("XPartitionImage")]
	[XmlInclude(typeof(Color))]
	[DebuggerDisplay("PartitionImage:{Name}")]
	[XmlInclude(typeof(PointF))]
	public class XTextPartitionImageElement : XTextObjectElement
	{
		private bool bool_9;

		private string string_9;

		private Color color_0;

		private bool bool_10;

		private string string_10;

		private List<XImagePartition> list_0;

		private float float_8;

		private float float_9;

		private string string_11;

		private int int_8;

		private XImageValue ximageValue_0;

		private string string_12;

		/// <summary>
		///       获取或设置分区图像是否为多选模式
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public bool IsMultiSelect
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       获取或设置用于自动将当前选区的文本值导出到目前元素的ID
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		public string ElementIDForExporting
		{
			get
			{
				return string_9;
			}
			set
			{
				string_9 = value;
			}
		}

		/// <summary>
		///       获取或设置用于标识选中区域的颜色
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		public int IdentyColorARGBValue
		{
			get
			{
				return color_0.ToArgb();
			}
			set
			{
				color_0 = Color.FromArgb(value);
			}
		}

		/// <summary>
		///       获取或设置是否使用颜色来标识选中的区域
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public bool IsIdentyPartition
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       获取或设置在多选模式下用于分隔显示多个选区文本的分隔符
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		public string DivCharForMultiMode
		{
			get
			{
				return string_10;
			}
			set
			{
				string_10 = value;
			}
		}

		/// <summary>
		///       获取或设置该分区图片元素包含的所有区域信息，不建议编码方式设置，建议用区域编辑器设置
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public List<XImagePartition> PartitionList
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		/// <summary>
		///       获取或设置图片宽度
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		public override float Width
		{
			get
			{
				return float_8;
			}
			set
			{
				float_8 = value;
			}
		}

		/// <summary>
		///       获取或设置图片高度
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public override float Height
		{
			get
			{
				return float_9;
			}
			set
			{
				float_9 = value;
			}
		}

		/// <summary>
		///       获取该文档元素选中区域所代表的文本信息TEXT
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public override string Text => string_11;

		/// <summary>
		///       获取该文档元素选中区域所代表的数值信息VALUE
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		public int Value => int_8;

		/// <summary>
		///       获取或设置图片内置的XImageValue对象
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public XImageValue XImage
		{
			get
			{
				return ximageValue_0;
			}
			set
			{
				ximageValue_0 = value;
			}
		}

		/// <summary>
		///       获取或设置图片来源URL，指定新的URL会重新设置XImageValue对象
		///       </summary>
		public string Url
		{
			get
			{
				return string_12;
			}
			set
			{
				if (File.Exists(value))
				{
					XImageValue xImageValue = new XImageValue();
					xImageValue.FormatBase64String = true;
					xImageValue.Load(value);
					if (xImageValue.HasContent)
					{
						ximageValue_0 = xImageValue;
						string_12 = value;
					}
				}
			}
		}

		public XTextPartitionImageElement()
		{
			ximageValue_0 = new XImageValue();
			ximageValue_0.FormatBase64String = true;
			list_0 = new List<XImagePartition>();
			color_0 = Color.Red;
			bool_10 = true;
			string_9 = "";
			bool_9 = false;
			string_10 = ",";
			float_8 = 300f;
			float_9 = 300f;
			string_12 = "";
			string_11 = "";
			int_8 = 0;
		}

		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			bool designMode;
			if (!(designMode = OwnerDocument.Options.BehaviorOptions.DesignMode))
			{
				args.Cursor = Cursors.Arrow;
			}
			switch (args.Style)
			{
			case DocumentEventStyles.MouseClick:
				if (designMode || !base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				if (args.Button == MouseButtons.Left)
				{
					args.Cursor = Cursors.Arrow;
					InvalidateView();
					if (OwnerDocument != null && OwnerDocument.DocumentControler.CanModify(this))
					{
						method_16(args);
						XTextElement elementById = WriterControl.GetElementById(string_9);
						if (elementById != null)
						{
							elementById.Text = Text;
						}
					}
					else
					{
						args.Handled = true;
						args.CancelBubble = true;
					}
					return;
				}
				if (args.Button != MouseButtons.Right)
				{
					break;
				}
				args.Cursor = Cursors.Arrow;
				InvalidateView();
				if (OwnerDocument != null && OwnerDocument.DocumentControler.CanModify(this))
				{
					method_17(args);
					XTextElement elementById = WriterControl.GetElementById(string_9);
					if (elementById != null)
					{
						elementById.Text = Text;
					}
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
					method_18();
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

		public override void OnViewMouseClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			base.OnViewMouseClick(elementMouseEventArgs_0);
		}

		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			method_19();
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			base.DrawContent(args);
			if (ximageValue_0.HasContent)
			{
				args.Graphics.DrawImage(ximageValue_0.Value, AbsClientBounds);
				if (bool_10)
				{
					foreach (XImagePartition item in list_0)
					{
						if (item.IsSelect)
						{
							PointF[] array = item.RatioToPointFsList.ToArray();
							byte[] array2 = new byte[array.Length];
							for (int i = 0; i < array.Length; i++)
							{
								array[i].X = base.ViewBounds.X + Width * item.RatioToPointFsList[i].X;
								array[i].Y = base.ViewBounds.Y + Height * item.RatioToPointFsList[i].Y;
								array2[i] = 1;
							}
							GraphicsPath path = new GraphicsPath(array, array2);
							args.Graphics.FillPath(color_0, path);
						}
					}
				}
			}
		}

		public override void vmethod_18(GInterface5 ginterface5_0)
		{
			int num = 15;
			ginterface5_0.imethod_8(Encoding.UTF8);
			string str = "";
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Image image = CreateContentImage();
				image.Save(memoryStream, ImageFormat.Png);
				byte[] array = new byte[memoryStream.Length];
				memoryStream.Position = 0L;
				memoryStream.Read(array, 0, (int)memoryStream.Length);
				memoryStream.Close();
				str = Convert.ToBase64String(array, Base64FormattingOptions.InsertLineBreaks);
			}
			string string_ = "<img src=\"data:image/png;base64," + str + "\"/>";
			ginterface5_0.imethod_15(string_);
		}

		private void method_16(DocumentEventArgs documentEventArgs_0)
		{
			if (bool_9)
			{
				if (list_0.Count > 0)
				{
					for (int i = 0; i < list_0.Count; i++)
					{
						if (list_0[i].region_0.IsVisible(new PointF(base.ViewBounds.X + (float)documentEventArgs_0.X, base.ViewBounds.Y + (float)documentEventArgs_0.Y)))
						{
							list_0[i].IsSelect = true;
							break;
						}
					}
				}
				string_11 = "";
				int_8 = 0;
				bool flag = true;
				foreach (XImagePartition item in list_0)
				{
					if (item.IsSelect)
					{
						if (flag)
						{
							string_11 = item.Text;
							int_8 = item.Value;
							flag = false;
						}
						else
						{
							string_11 = string_11 + string_10 + item.Text;
							int_8 |= item.Value;
						}
					}
				}
			}
			else if (list_0.Count > 0)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (list_0[i].region_0.IsVisible(new PointF(base.ViewBounds.X + (float)documentEventArgs_0.X, base.ViewBounds.Y + (float)documentEventArgs_0.Y)))
					{
						foreach (XImagePartition item2 in list_0)
						{
							item2.IsSelect = false;
						}
						list_0[i].IsSelect = true;
						string_11 = list_0[i].Text;
						int_8 = list_0[i].Value;
						break;
					}
				}
			}
			EditorRefreshView();
		}

		private void method_17(DocumentEventArgs documentEventArgs_0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				if (list_0[i].region_0.IsVisible(new PointF(base.ViewBounds.X + (float)documentEventArgs_0.X, base.ViewBounds.Y + (float)documentEventArgs_0.Y)))
				{
					list_0[i].IsSelect = false;
					break;
				}
			}
			string_11 = "";
			int_8 = 0;
			bool flag = true;
			foreach (XImagePartition item in list_0)
			{
				if (item.IsSelect)
				{
					if (flag)
					{
						string_11 = item.Text;
						int_8 = item.Value;
						flag = false;
					}
					else
					{
						string_11 = string_11 + string_10 + item.Text;
						int_8 |= item.Value;
					}
				}
			}
			EditorRefreshView();
		}

		private void method_18()
		{
			dlgImagePartitionEditor dlgImagePartitionEditor = new dlgImagePartitionEditor(ximageValue_0.Value, list_0);
			if (dlgImagePartitionEditor.ShowDialog() == DialogResult.OK)
			{
				list_0.Clear();
				list_0 = dlgImagePartitionEditor.list_0.GetRange(0, dlgImagePartitionEditor.list_0.Count);
				method_19();
			}
		}

		private void method_19()
		{
			if (list_0.Count > 0)
			{
				foreach (XImagePartition item in list_0)
				{
					PointF[] array = item.RatioToPointFsList.ToArray();
					byte[] array2 = new byte[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array[i].X = base.ViewBounds.X + Width * item.RatioToPointFsList[i].X;
						array[i].Y = base.ViewBounds.Y + Height * item.RatioToPointFsList[i].Y;
						array2[i] = 1;
					}
					item.graphicsPath_0 = new GraphicsPath(array, array2);
					item.region_0 = new Region(item.graphicsPath_0);
				}
			}
		}
	}
}
