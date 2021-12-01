using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       撤销设置对象属性操作
	///       </summary>
	[ComVisible(false)]
	public class XTextUndoNameProperty : XTextUndoBase
	{
		private PropertyDescriptor propertyDescriptor_0;

		private PropertyInfo propertyInfo_0;

		private object object_0;

		private object object_1;

		private object object_2;

		private string PropertyName
		{
			get
			{
				if (propertyInfo_0 != null)
				{
					return propertyInfo_0.Name;
				}
				if (propertyDescriptor_0 != null)
				{
					return propertyDescriptor_0.Name;
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextUndoNameProperty(object object_3, PropertyDescriptor propertyDescriptor_1, object object_4, object object_5)
		{
			int num = 3;
			propertyDescriptor_0 = null;
			propertyInfo_0 = null;
			object_0 = null;
			object_1 = null;
			object_2 = null;
			
			if (object_3 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (propertyDescriptor_1 == null)
			{
				throw new ArgumentNullException("property");
			}
			object_0 = object_3;
			propertyDescriptor_0 = propertyDescriptor_1;
			object_1 = object_4;
			object_2 = object_5;
		}

		public XTextUndoNameProperty(object object_3, PropertyInfo propertyInfo_1, object object_4, object object_5)
		{
			int num = 8;
			propertyDescriptor_0 = null;
			propertyInfo_0 = null;
			object_0 = null;
			object_1 = null;
			object_2 = null;
			
			if (object_3 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (propertyInfo_1 == null)
			{
				throw new ArgumentNullException("property");
			}
			object_0 = object_3;
			propertyInfo_0 = propertyInfo_1;
			object_1 = object_4;
			object_2 = object_5;
		}

		public override void Redo(GEventArgs3 args)
		{
			int num = 16;
			if (propertyDescriptor_0 != null)
			{
				propertyDescriptor_0.SetValue(object_0, object_2);
			}
			else
			{
				propertyInfo_0.SetValue(object_0, object_2, null);
			}
			if (object_0 is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)object_0;
				xTextElement.SizeInvalid = true;
				base.OwnerList.RefreshElements.Add(xTextElement);
				if (xTextElement is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement;
					if (xTextFieldElementBase.StartElement != null)
					{
						base.OwnerList.RefreshElements.Add(xTextFieldElementBase.StartElement);
					}
					if (xTextFieldElementBase.EndElement != null)
					{
						base.OwnerList.RefreshElements.Add(xTextFieldElementBase.EndElement);
					}
				}
			}
			if (object_0 is XTextTableRowElement && (PropertyName == "SpecifyHeight" || PropertyName == "HeaderStyle"))
			{
				base.OwnerList.NeedInvokeMethods = (base.OwnerList.NeedInvokeMethods | UndoMethodTypes.RefreshDocument);
			}
			if (object_0 is XTextDocument && (PropertyName == "PageSettings" || PropertyName == "DefaultStyle"))
			{
				base.OwnerList.NeedInvokeMethods = (base.OwnerList.NeedInvokeMethods | UndoMethodTypes.RefreshDocument);
			}
			if (PropertyName == "Comments")
			{
				XTextDocument xTextDocument = (XTextDocument)object_0;
				if (xTextDocument.EditorControl != null)
				{
					xTextDocument.EditorControl.CommentManager.imethod_5((DocumentCommentList)object_1, (DocumentCommentList)object_2);
				}
			}
			if (object_0 is XTextInputFieldElementBase && PropertyName == "DefaultEventExpression")
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)object_0;
				xTextInputFieldElementBase.vmethod_43(bool_20: false);
			}
		}

		public override void Undo(GEventArgs3 args)
		{
			int num = 1;
			if (propertyInfo_0 != null)
			{
				propertyInfo_0.SetValue(object_0, object_1, null);
			}
			else
			{
				propertyDescriptor_0.SetValue(object_0, object_1);
			}
			if (object_0 is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)object_0;
				xTextElement.SizeInvalid = true;
				base.OwnerList.RefreshElements.Add(xTextElement);
				if (xTextElement is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement;
					if (xTextFieldElementBase.StartElement != null)
					{
						base.OwnerList.RefreshElements.Add(xTextFieldElementBase.StartElement);
					}
					if (xTextFieldElementBase.EndElement != null)
					{
						base.OwnerList.RefreshElements.Add(xTextFieldElementBase.EndElement);
					}
				}
			}
			if (object_0 is XTextTableRowElement && (PropertyName == "SpecifyHeight" || PropertyName == "HeaderStyle"))
			{
				base.OwnerList.NeedInvokeMethods = (base.OwnerList.NeedInvokeMethods | UndoMethodTypes.RefreshDocument);
			}
			if (object_0 is XTextDocument)
			{
				if (PropertyName == "PageSettings" || PropertyName == "DefaultStyle")
				{
					base.OwnerList.NeedInvokeMethods = (base.OwnerList.NeedInvokeMethods | UndoMethodTypes.RefreshDocument);
				}
				if (PropertyName == "Comments")
				{
					XTextDocument xTextDocument = (XTextDocument)object_0;
					if (xTextDocument.EditorControl != null)
					{
						xTextDocument.EditorControl.CommentManager.imethod_5((DocumentCommentList)object_1, (DocumentCommentList)object_2);
					}
				}
			}
			if (object_0 is XTextInputFieldElementBase && PropertyName == "DefaultEventExpression")
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)object_0;
				xTextInputFieldElementBase.vmethod_43(bool_20: false);
			}
		}
	}
}
