using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       使用图片作为背景的文档页对象，大小固定为图片大小
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class ShapeDocumentImagePage : ShapeDocumentPage
	{
		private XImageValue ximageValue_0 = null;

		private bool bool_4 = true;

		/// <summary>
		///       当有图片内容时对象大小不能改变
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override bool Resizeable
		{
			get
			{
				if (AutoSize && Image != null && Image.HasContent)
				{
					return false;
				}
				return base.Resizeable;
			}
			set
			{
				base.Resizeable = value;
			}
		}

		/// <summary>
		///       图片对象
		///       </summary>
		[DefaultValue(null)]
		public XImageValue Image
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
		///       自动大小
		///       </summary>
		[DefaultValue(true)]
		public bool AutoSize
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		public override void vmethod_7(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			if (Image != null && Image.HasContent)
			{
				RectangleF absBounds = AbsBounds;
				RectangleF rectangleF = RectangleF.Intersect(absBounds, shapeRenderEventArgs_0.ClipRectangle);
				if (!rectangleF.IsEmpty)
				{
					rectangleF.Width += 4f;
					rectangleF.Height += 4f;
					shapeRenderEventArgs_0.Graphics.DrawImage(Image.Value, absBounds);
				}
			}
			base.vmethod_7(shapeRenderEventArgs_0);
		}

		public override void vmethod_3(DCGraphics dcgraphics_0)
		{
			if (AutoSize && Image != null && Image.HasContent)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(Image.Width, Image.Height), GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
				base.Width = sizeF.Width;
				base.Height = sizeF.Height;
			}
			base.vmethod_3(dcgraphics_0);
		}
	}
}
