using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       选择的元素列表
	///       </summary>
	[ComVisible(false)]
	public class ShapeSelection : ShapeElementList
	{
		public bool method_0(ContentStyle contentStyle_0)
		{
			if (base.Count == 0)
			{
				return false;
			}
			ShapeDocument ownerDocument = base[0].OwnerDocument;
			Dictionary<ShapeElement, int> dictionary = new Dictionary<ShapeElement, int>();
			bool flag = false;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ShapeElement current = enumerator.Current;
					ContentStyle contentStyle = current.RuntimeStyle.Clone();
					if (XDependencyObject.smethod_7(contentStyle_0, contentStyle, bool_3: true) > 0)
					{
						if (ownerDocument.LocalElementStyleMode)
						{
							flag = true;
							current.LocalStyle = contentStyle;
							current.vmethod_15();
						}
						else
						{
							int styleIndex = ownerDocument.ContentStyles.GetStyleIndex(contentStyle);
							if (styleIndex != current.StyleIndex)
							{
								flag = true;
								dictionary[current] = styleIndex;
							}
						}
					}
				}
			}
			if (flag)
			{
				if (!ownerDocument.LocalElementStyleMode)
				{
					using (Enumerator enumerator = GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ShapeElement current = enumerator.Current;
							current.StyleIndex = dictionary[current];
							current.vmethod_15();
						}
					}
				}
				ownerDocument.Modified = true;
				ownerDocument.method_6();
				if (ownerDocument.EditorControl != null)
				{
					ownerDocument.EditorControl.vmethod_8(EventArgs.Empty);
				}
				return true;
			}
			return false;
		}
	}
}
