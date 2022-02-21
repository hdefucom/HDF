using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       自定义绘图对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlType("XCustomShape")]
	[ComDefaultInterface(typeof(IXTextCustomShapeElement))]
	[ComVisible(true)]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ToolboxBitmap(typeof(XTextCustomShapeElement))]
	[Guid("C865D7BE-6061-4E8A-8E9B-7E25F2B9ACF9")]
	[DebuggerDisplay("CustomShape:{Name}")]
	[ComClass("C865D7BE-6061-4E8A-8E9B-7E25F2B9ACF9", "EDAC2210-DEF9-46DD-8431-A11DE7765F1B")]
	
	public sealed class XTextCustomShapeElement : XTextObjectElement, IXTextCustomShapeElement
	{
		internal const string string_9 = "C865D7BE-6061-4E8A-8E9B-7E25F2B9ACF9";

		internal const string string_10 = "EDAC2210-DEF9-46DD-8431-A11DE7765F1B";

		private int int_8 = 0;

		private string string_11 = null;

		[NonSerialized]
		private WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler_0 = null;

		
		public override string DomDisplayName => "CustomShape:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		
		public override string ElementIDPrefix => "shape";

		/// <summary>
		///       对象宽度
		///       </summary>
		
		[Browsable(true)]
		[XmlElement]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       从0开始计算的图标页码
		///       </summary>
		[DefaultValue(0)]
		
		public int ChartPageIndex
		{
			get
			{
				return int_8;
			}
			set
			{
				int_8 = value;
			}
		}

		/// <summary>
		///       绘制内容使用的委托对象参数名称
		///       </summary>
		[DefaultValue(null)]
		
		public string DrawContentHandlerName
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		/// <summary>
		///       绘制内容使用的委托对象
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public WriterDrawShapeContentEventHandler DrawContentHandler
		{
			get
			{
				return writerDrawShapeContentEventHandler_0;
			}
			set
			{
				writerDrawShapeContentEventHandler_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextCustomShapeElement()
		{
		}

		/// <summary>
		///       绘制元素内容
		///       </summary>
		/// <param name="args">参数</param>
		
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			int num = 16;
			if (!XTextDocument.smethod_13(GEnum6.const_75))
			{
				return;
			}
			WriterDrawShapeContentEventArgs writerDrawShapeContentEventArgs = new WriterDrawShapeContentEventArgs(OwnerDocument.EditorControl, OwnerDocument, this, args);
			if (DrawContentHandler != null)
			{
				DrawContentHandler(this, writerDrawShapeContentEventArgs);
				return;
			}
			OwnerDocument.method_47(this, "DrawContent", new object[2]
			{
				this,
				args
			});
			if (OwnerDocument != null && !string.IsNullOrEmpty(DrawContentHandlerName))
			{
				WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler = OwnerDocument.Parameters.GetValue(DrawContentHandlerName) as WriterDrawShapeContentEventHandler;
				if (writerDrawShapeContentEventHandler != null)
				{
					writerDrawShapeContentEventHandler(this, writerDrawShapeContentEventArgs);
					return;
				}
			}
			if (OwnerDocument != null && OwnerDocument.EditorControl != null)
			{
				OwnerDocument.EditorControl.vmethod_19(writerDrawShapeContentEventArgs);
			}
			OwnerDocument.method_114(this, args, GEnum6.const_75);
		}
	}
}
