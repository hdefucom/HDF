using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       数据源绑定信息列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("8D66F0D9-4377-4B60-B9C6-E71DAF0A6033")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComClass("8D66F0D9-4377-4B60-B9C6-E71DAF0A6033", "BA509B64-EFC1-461C-B61A-6AACADA7D836")]
	[DocumentComment]
	[ComDefaultInterface(typeof(IFieldValueDescriptorList))]
	public class FieldValueDescriptorList : List<FieldValueDescriptor>, IFieldValueDescriptorList
	{
		internal const string CLASSID = "8D66F0D9-4377-4B60-B9C6-E71DAF0A6033";

		internal const string CLASSID_Interface = "BA509B64-EFC1-461C-B61A-6AACADA7D836";

		/// <summary>
		///       初始化对象
		///       </summary>
		public FieldValueDescriptorList()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		public FieldValueDescriptorList(XTextDocument document)
		{
			foreach (XTextInputFieldElementBase item in document.GetElementsByType(typeof(XTextInputFieldElementBase)))
			{
				FieldValueDescriptor fieldValueDescriptor = item.vmethod_41();
				if (fieldValueDescriptor != null)
				{
					Add(fieldValueDescriptor);
				}
			}
			foreach (XTextCheckBoxElementBase item2 in document.GetElementsByType(typeof(XTextCheckBoxElementBase)))
			{
				FieldValueDescriptor fieldValueDescriptor = item2.vmethod_26();
				if (fieldValueDescriptor != null)
				{
					Add(fieldValueDescriptor);
				}
			}
		}

		/// <summary>
		///       将数据填写到文档中
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>填写的有效数据个数</returns>
		public int WriteToDocument(XTextDocument document)
		{
			XTextElementList xTextElementList = new XTextElementList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FieldValueDescriptor current = enumerator.Current;
					if (current.Element is XTextInputFieldElementBase)
					{
						if (((XTextInputFieldElementBase)current.Element).vmethod_42(current, bool_20: true))
						{
							xTextElementList.Add(current.Element);
						}
					}
					else if (current.Element is XTextCheckBoxElementBase && ((XTextCheckBoxElementBase)current.Element).vmethod_27(current, bool_20: true))
					{
						xTextElementList.Add(current.Element);
					}
				}
			}
			if (xTextElementList.Count > 0)
			{
				if (document.UndoList != null)
				{
					document.UndoList.Clear();
				}
				document.Modified = false;
				if (document.EditorControl != null)
				{
					document.EditorControl.EndUpdate();
					if (xTextElementList.Count > 0)
					{
						document.EditorControl.RefreshDocument();
						document.OnSelectionChanged();
					}
				}
			}
			return xTextElementList.Count;
		}
	}
}
