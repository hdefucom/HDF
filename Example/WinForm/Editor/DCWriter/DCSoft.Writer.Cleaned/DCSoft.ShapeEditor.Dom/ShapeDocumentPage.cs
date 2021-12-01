using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       文档页面对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeDocumentPage : ShapeContainerElement
	{
		[NonSerialized]
		private ShapeSelection shapeSelection_0 = new ShapeSelection();

		private ShapeElement shapeElement_0 = null;

		/// <summary>
		///       选择的元素列表
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public ShapeSelection Selection
		{
			get
			{
				if (shapeSelection_0 == null)
				{
					shapeSelection_0 = new ShapeSelection();
				}
				return shapeSelection_0;
			}
		}

		/// <summary>
		///       当前元素
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public ShapeElement CurrentElement
		{
			get
			{
				if (shapeElement_0 == null && Selection.Count > 0)
				{
					shapeElement_0 = Selection[0];
				}
				return shapeElement_0;
			}
			set
			{
				shapeElement_0 = value;
			}
		}

		public bool method_4(ShapeElementList shapeElementList_1, bool bool_4)
		{
			int num = 17;
			if (shapeElementList_1 == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (Selection.Count == shapeElementList_1.Count)
			{
				bool flag = true;
				foreach (ShapeElement item in shapeElementList_1)
				{
					if (!Selection.Contains(item))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return false;
				}
			}
			if (!bool_4 && Selection.Count > 0 && shapeElementList_1.Count > 0 && Selection[0].Parent != shapeElementList_1[0].Parent)
			{
				bool_4 = true;
			}
			if (bool_4)
			{
				foreach (ShapeElement item2 in Selection)
				{
					item2.vmethod_15();
				}
				Selection.Clear();
				shapeElement_0 = null;
			}
			foreach (ShapeElement item3 in shapeElementList_1)
			{
				if (!Selection.Contains(item3))
				{
					Selection.Add(item3);
					item3.vmethod_15();
				}
			}
			if (Selection.Count > 0)
			{
				shapeElement_0 = Selection[0];
			}
			OwnerDocument.vmethod_23(EventArgs.Empty);
			return true;
		}

		public bool method_5(ShapeElement shapeElement_1, bool bool_4)
		{
			if (CurrentElement == shapeElement_1 && Selection.Count == 1)
			{
				return false;
			}
			if (!bool_4)
			{
				foreach (ShapeElement item in Selection)
				{
					if (item.Parent != shapeElement_1.Parent)
					{
						bool_4 = true;
						break;
					}
				}
			}
			if (bool_4)
			{
				foreach (ShapeElement item2 in Selection)
				{
					item2.vmethod_15();
				}
				Selection.Clear();
			}
			if (shapeElement_0 != null)
			{
				shapeElement_0.vmethod_15();
			}
			shapeElement_0 = shapeElement_1;
			if (shapeElement_0 != null && !Selection.Contains(shapeElement_0))
			{
				Selection.Add(shapeElement_1);
				shapeElement_0.vmethod_15();
			}
			OwnerDocument.vmethod_23(EventArgs.Empty);
			return true;
		}

		public bool method_6()
		{
			if (Selection.Count == 1 && Selection[0] == this)
			{
				return false;
			}
			bool result = false;
			if (Selection.Count > 0)
			{
				ShapeContainerElement parent = Selection[0].Parent;
				foreach (ShapeElement item in Selection)
				{
					parent.Elements.Remove(item);
					result = true;
				}
				Selection.Clear();
				shapeElement_0 = null;
				method_5(parent, bool_4: true);
				OwnerDocument.Modified = true;
				OwnerDocument.method_6();
				OwnerDocument.vmethod_23(EventArgs.Empty);
				OwnerDocument.vmethod_24(EventArgs.Empty);
			}
			return result;
		}

		public override void vmethod_6(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			base.vmethod_6(shapeRenderEventArgs_0);
			if (shapeRenderEventArgs_0.DesignMode)
			{
				method_7(shapeRenderEventArgs_0);
			}
		}

		public void method_7(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			if (Selection.Count == 0)
			{
				return;
			}
			ShapeElement shapeElement = this;
			if (shapeRenderEventArgs_0.Style == ShapeRenderStyle.Paint && OwnerDocument.EditorControl != null)
			{
				shapeElement = OwnerDocument.EditorControl.method_10();
			}
			_ = shapeRenderEventArgs_0.ViewOptions.RuntimeControlPointSize;
			ShapeElementList shapeElementList = Selection.Clone();
			shapeElementList.Remove(CurrentElement);
			shapeElementList.Add(CurrentElement);
			ShapeElementList shapeElementList2 = new ShapeElementList();
			if (CurrentElement != this)
			{
				ShapeContainerElement parent = CurrentElement.Parent;
				while (parent != null && parent != shapeElement)
				{
					shapeElementList2.Add(parent);
					parent = parent.Parent;
				}
			}
			shapeElementList.InsertRange(0, shapeElementList2);
			foreach (ShapeElement item in shapeElementList)
			{
				PointF absLocation = item.AbsLocation;
				GraphicsPath graphicsPath = item.vmethod_5();
				if (graphicsPath != null)
				{
					using (Matrix matrix = new Matrix())
					{
						matrix.Translate(absLocation.X, absLocation.Y);
						graphicsPath.Transform(matrix);
					}
					shapeRenderEventArgs_0.Graphics.DrawPath(shapeRenderEventArgs_0.ViewOptions.SelectionBorder, graphicsPath);
					graphicsPath.Dispose();
				}
				GClass330 gClass = item.vmethod_4();
				if (gClass != null && gClass.Count > 0)
				{
					foreach (GClass329 item2 in gClass)
					{
						item2.method_7(item == CurrentElement);
						shapeRenderEventArgs_0.Render.vmethod_0(item2.method_2() + absLocation.X, item2.method_4() + absLocation.Y, item2, shapeRenderEventArgs_0);
					}
				}
			}
		}

		public override void vmethod_13(ShapeLabelEditEventArgs shapeLabelEditEventArgs_0)
		{
			shapeLabelEditEventArgs_0.Cancel = true;
		}

		public override ShapeElement vmethod_17(bool bool_4)
		{
			ShapeDocumentPage shapeDocumentPage = (ShapeDocumentPage)base.vmethod_17(bool_4);
			shapeDocumentPage.shapeElement_0 = null;
			shapeDocumentPage.shapeSelection_0 = null;
			return shapeDocumentPage;
		}
	}
}
