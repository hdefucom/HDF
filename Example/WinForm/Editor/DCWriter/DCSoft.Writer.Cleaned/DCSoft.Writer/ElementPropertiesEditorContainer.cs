using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素属性编辑器容器对象
	///       </summary>
	[ComVisible(false)]
	public class ElementPropertiesEditorContainer
	{
		private Dictionary<Type, ElementPropertiesEditor> dictionary_0 = new Dictionary<Type, ElementPropertiesEditor>();

		/// <summary>
		///       设置编辑器
		///       </summary>
		/// <param name="elementType">
		/// </param>
		/// <param name="editor">
		/// </param>
		public void SetEditor(Type elementType, ElementPropertiesEditor editor)
		{
			int num = 18;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new ArgumentOutOfRangeException(elementType.FullName);
			}
			if (editor == null)
			{
				if (dictionary_0.ContainsKey(elementType))
				{
					dictionary_0.Remove(elementType);
				}
				return;
			}
			if (typeof(ElementPropertiesEditor).IsInstanceOfType(editor))
			{
				dictionary_0[elementType] = editor;
				return;
			}
			throw new InvalidCastException(editor.GetType().FullName);
		}

		/// <summary>
		///       获得指定文档元素类型使用的元素数值编辑器
		///       </summary>
		/// <param name="elementType">文档元素对象</param>
		/// <remarks>当编辑器承载在IE浏览器中可能存在TypeDescriptor.GetEditor函数无效的情况，
		///       本函数就是进行替代操作。</remarks>
		/// <returns>获得的编辑器对象</returns>
		public ElementPropertiesEditor GetEditor(Type elementType)
		{
			int num = 2;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new ArgumentOutOfRangeException(elementType.FullName);
			}
			if (dictionary_0.ContainsKey(elementType))
			{
				return dictionary_0[elementType];
			}
			ElementPropertiesEditor elementPropertiesEditor = null;
			EditorAttribute editorAttribute = (EditorAttribute)Attribute.GetCustomAttribute(elementType, typeof(EditorAttribute), inherit: true);
			if (editorAttribute != null)
			{
				Type type = Type.GetType(editorAttribute.EditorTypeName, throwOnError: false, ignoreCase: true);
				if (type != null && typeof(ElementPropertiesEditor).IsAssignableFrom(type))
				{
					elementPropertiesEditor = (ElementPropertiesEditor)Activator.CreateInstance(type);
				}
			}
			dictionary_0[elementType] = elementPropertiesEditor;
			return elementPropertiesEditor;
		}
	}
}
