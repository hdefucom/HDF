using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       容器元素对象
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class ShapeContainerElement : ShapeRectangleElement
	{
		private ShapeElementList shapeElementList_0 = new ShapeElementList();

		[NonSerialized]
		private GEventArgs11 geventArgs11_1 = null;

		/// <summary>
		///       子元素列表
		///       </summary>
		[Browsable(false)]
		[XmlArray]
		public override ShapeElementList Elements
		{
			get
			{
				return shapeElementList_0;
			}
			set
			{
				shapeElementList_0 = value;
			}
		}

		public override void vmethod_0(float float_4, float float_5)
		{
			base.vmethod_0(float_4, float_5);
			foreach (ShapeElement element in Elements)
			{
				element.vmethod_0(float_4, float_5);
			}
		}

		public virtual ShapeElementList vmethod_18(bool bool_4)
		{
			ShapeElementList shapeElementList = new ShapeElementList();
			if (bool_4)
			{
				shapeElementList.Add(this);
			}
			method_1(shapeElementList);
			return shapeElementList;
		}

		private void method_1(ShapeElementList shapeElementList_1)
		{
			foreach (ShapeElement element in Elements)
			{
				shapeElementList_1.Add(element);
				if (element is ShapeContainerElement)
				{
					((ShapeContainerElement)element).method_1(shapeElementList_1);
				}
			}
		}

		public override void vmethod_3(DCGraphics dcgraphics_0)
		{
			foreach (ShapeElement element in Elements)
			{
				element.vmethod_3(dcgraphics_0);
			}
		}

		public virtual void vmethod_19(ShapeElement shapeElement_0)
		{
			int num = 2;
			if (shapeElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			shapeElement_0.Parent = this;
			Elements.Add(shapeElement_0);
		}

		public override void vmethod_1(GClass328 gclass328_0)
		{
			RectangleF rectangleF_ = new RectangleF(0f, 0f, base.Width, base.Height);
			if (rectangleF_.Contains(gclass328_0.method_4(), gclass328_0.method_6()))
			{
				if (RuntimeStyle.method_25(rectangleF_).Contains(gclass328_0.method_4(), gclass328_0.method_6()))
				{
					gclass328_0.method_9(GEnum73.const_1);
				}
				else
				{
					gclass328_0.method_9(GEnum73.const_2);
				}
			}
		}

		public ShapeElement method_2(float float_4, float float_5)
		{
			ContentStyle runtimeStyle = RuntimeStyle;
			float num = float_4 - runtimeStyle.PaddingLeft;
			float num2 = float_5 - runtimeStyle.PaddingTop;
			int num3 = Elements.Count - 1;
			ShapeElement shapeElement;
			float float_6;
			float num4;
			GClass328 gClass;
			while (true)
			{
				if (num3 >= 0)
				{
					shapeElement = Elements[num3];
					if (shapeElement.Visible)
					{
						RectangleF bounds = shapeElement.Bounds;
						float_6 = num - bounds.Left;
						num4 = num2 - bounds.Top;
						gClass = new GClass328();
						gClass.method_5(float_6);
						gClass.method_7(num4);
						shapeElement.vmethod_1(gClass);
						if (gClass.method_8() != 0)
						{
							break;
						}
					}
					num3--;
					continue;
				}
				return null;
			}
			if (shapeElement is ShapeContainerElement && gClass.method_8() == GEnum73.const_1)
			{
				ShapeElement shapeElement2 = ((ShapeContainerElement)shapeElement).method_2(float_6, num4);
				if (shapeElement2 != null)
				{
					return shapeElement2;
				}
			}
			return shapeElement;
		}

		public override void vmethod_7(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			foreach (ShapeElement element in Elements)
			{
				RectangleF clipRectangle = shapeRenderEventArgs_0.ClipRectangle;
				RectangleF absBounds = element.AbsBounds;
				clipRectangle.Offset(0f - absBounds.Left, 0f - absBounds.Top);
				if (element.vmethod_11(clipRectangle))
				{
					ShapeRenderEventArgs shapeRenderEventArgs = shapeRenderEventArgs_0.Clone();
					shapeRenderEventArgs.ClipRectangle = clipRectangle;
					element.vmethod_6(shapeRenderEventArgs);
				}
			}
		}

		public override void vmethod_2(GEventArgs11 geventArgs11_2)
		{
			if (geventArgs11_2.method_0() == GEnum76.const_3)
			{
				geventArgs11_1 = geventArgs11_2;
				geventArgs11_2.method_12().Draw += method_3;
				if (geventArgs11_2.method_12().method_2(bool_1: false))
				{
					Rectangle rectangle = RectangleCommon.GetRectangle(geventArgs11_2.method_10(), geventArgs11_2.method_12().EndPosition);
					RectangleF rectangleF = geventArgs11_2.method_6().method_21(rectangle);
					rectangleF.Location = geventArgs11_2.method_6().method_28(rectangleF.Location, this);
					rectangleF.Offset(0f - RuntimeStyle.PaddingLeft, 0f - RuntimeStyle.PaddingTop);
					ShapeElementList shapeElementList = new ShapeElementList();
					foreach (ShapeElement element in Elements)
					{
						if (element.Visible)
						{
							RectangleF bounds = element.Bounds;
							if (rectangleF.IntersectsWith(bounds))
							{
								shapeElementList.Add(element);
							}
						}
					}
					if (shapeElementList.Count == 0)
					{
						shapeElementList.Add(this);
					}
					base.OwnerPage.method_4(shapeElementList, bool_4: true);
				}
			}
			else
			{
				base.vmethod_2(geventArgs11_2);
			}
		}

		private void method_3(object sender, CaptureMouseMoveEventArgs e)
		{
			Rectangle rectangle = RectangleCommon.GetRectangle(e.method_5(), geventArgs11_1.method_10());
			geventArgs11_1.method_14().DrawRectangle(rectangle);
		}

		public override void vmethod_16(ShapeFileFormat shapeFileFormat_0)
		{
			base.vmethod_16(shapeFileFormat_0);
			foreach (ShapeElement element in Elements)
			{
				element.OwnerDocument = OwnerDocument;
				element.Parent = this;
				element.vmethod_16(shapeFileFormat_0);
			}
		}

		public virtual void vmethod_20()
		{
			foreach (ShapeElement element in Elements)
			{
				element.Parent = this;
				if (element is ShapeContainerElement)
				{
					((ShapeContainerElement)element).vmethod_20();
				}
			}
		}

		public override ShapeElement vmethod_17(bool bool_4)
		{
			ShapeContainerElement shapeContainerElement = (ShapeContainerElement)base.vmethod_17(bool_4);
			shapeContainerElement.shapeElementList_0 = shapeElementList_0.Clone();
			if (bool_4)
			{
				shapeContainerElement.shapeElementList_0 = new ShapeElementList();
				foreach (ShapeElement item in shapeElementList_0)
				{
					shapeContainerElement.shapeElementList_0.Add(item.vmethod_17(bool_3: true));
				}
			}
			return shapeContainerElement;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public override void Dispose()
		{
			foreach (ShapeElement element in Elements)
			{
				element.Dispose();
			}
		}
	}
}
