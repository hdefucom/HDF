using DCSoftDotfuscate;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       重复/撤销设置元素属性的信息对象
	///       </summary>
	[ComVisible(false)]
	public class XTextUndoProperty : XTextUndoBase
	{
		protected object object_0 = null;

		protected object object_1 = null;

		protected XTextElement xtextElement_0 = null;

		protected GEnum18 genum18_0 = GEnum18.const_0;

		protected bool bool_0 = false;

		/// <summary>
		///       旧数值
		///       </summary>
		public object OldValue
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		/// <summary>
		///       新数值
		///       </summary>
		public object NewValue
		{
			get
			{
				return object_1;
			}
			set
			{
				object_1 = value;
			}
		}

		/// <summary>
		///       元素对象
		///       </summary>
		public XTextElement Element
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
			}
		}

		/// <summary>
		///       样式
		///       </summary>
		public GEnum18 Style
		{
			get
			{
				return genum18_0;
			}
			set
			{
				genum18_0 = value;
			}
		}

		/// <summary>
		///       动作执行标记,若执行了动作,使得元素状态发生改变,
		///       则该属性为 true , 若执行动作没有产生任何修改则该属性为 false 
		///       </summary>
		public bool ExecuteFlag
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
		///       初始化对象
		///       </summary>
		public XTextUndoProperty()
		{
		}

		public XTextUndoProperty(GEnum18 genum18_1, object object_2, object object_3, XTextElement xtextElement_1)
		{
			genum18_0 = genum18_1;
			object_0 = object_2;
			object_1 = object_3;
			xtextElement_0 = xtextElement_1;
		}

		public override void Undo(GEventArgs3 args)
		{
			vmethod_0(bool_1: true);
		}

		public override void Redo(GEventArgs3 args)
		{
			vmethod_0(bool_1: false);
		}

		public virtual void vmethod_0(bool bool_1)
		{
			bool_0 = false;
			switch (genum18_0)
			{
			case GEnum18.const_1:
			{
				SizeF sizeF = (SizeF)OldValue;
				SizeF sizeF2 = (SizeF)NewValue;
				if (sizeF.Width > 0f && sizeF.Height > 0f && sizeF2.Width > 0f && sizeF2.Height > 0f)
				{
					if (bool_1)
					{
						xtextElement_0.EditorSetSize(sizeF.Width, sizeF.Height, updateView: true, logUndo: false);
					}
					else
					{
						xtextElement_0.EditorSetSize(sizeF2.Width, sizeF2.Height, updateView: true, logUndo: false);
					}
					xtextElement_0.SizeInvalid = false;
					bool_0 = true;
				}
				break;
			}
			case GEnum18.const_2:
			{
				SizeF editorSize = (SizeF)object_0;
				SizeF sizeF3 = (SizeF)object_1;
				if (editorSize.Width > 0f && editorSize.Height > 0f && sizeF3.Width > 0f && sizeF3.Height > 0f && !editorSize.Equals(sizeF3))
				{
					if (bool_1)
					{
						xtextElement_0.EditorSize = editorSize;
					}
					else
					{
						xtextElement_0.EditorSize = sizeF3;
					}
					xtextElement_0.SizeInvalid = true;
					bool_0 = true;
				}
				break;
			}
			case GEnum18.const_3:
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xtextElement_0;
				float num3 = (float)object_0;
				float num4 = (float)object_1;
				if (num3 != num4 && xTextTableRowElement != null)
				{
					if (bool_1)
					{
						xTextTableRowElement.EditorSetRowSpecifyHeight(num3, logUndo: false);
					}
					else
					{
						xTextTableRowElement.EditorSetRowSpecifyHeight(num4, logUndo: false);
					}
				}
				break;
			}
			case GEnum18.const_4:
			{
				int num = (int)object_0;
				int num2 = (int)object_1;
				if (num != num2 && xtextElement_0 != null)
				{
					DocumentContentStyle documentContentStyle = xtextElement_0.RuntimeStyle.CloneParent();
					documentContentStyle.DisableDefaultValue = true;
					if (bool_1)
					{
						documentContentStyle.CreatorIndex = num;
					}
					else
					{
						documentContentStyle.CreatorIndex = num2;
					}
					xtextElement_0.StyleIndex = xtextElement_0.OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
					xtextElement_0.SizeInvalid = true;
					bool_0 = true;
				}
				break;
			}
			case GEnum18.const_5:
			{
				int num = (int)object_0;
				int num2 = (int)object_1;
				if (num != num2 && xtextElement_0 != null)
				{
					DocumentContentStyle documentContentStyle = xtextElement_0.RuntimeStyle.CloneParent();
					documentContentStyle.DisableDefaultValue = true;
					if (bool_1)
					{
						documentContentStyle.DeleterIndex = num;
					}
					else
					{
						documentContentStyle.DeleterIndex = num2;
					}
					xtextElement_0.StyleIndex = xtextElement_0.OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
					xtextElement_0.SizeInvalid = true;
					bool_0 = true;
				}
				break;
			}
			}
			if (bool_0)
			{
				base.OwnerList.RefreshElements.Add(xtextElement_0.FirstContentElementInPublicContent);
				base.OwnerList.RefreshElements.Add(xtextElement_0.LastContentElementInPublicContent);
			}
		}
	}
}
