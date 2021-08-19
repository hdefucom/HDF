using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户通过数值编辑器修改输入域内容操作之前触发的事件的参数
	///       </summary>
	[DCPublishAPI]
	[ComClass("BE8FB62C-F76E-4F18-AE0B-0FF2034C250D", "2BC86E56-454B-4C1E-912D-AAE838379536")]
	[Guid("BE8FB62C-F76E-4F18-AE0B-0FF2034C250D")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterAfterFieldContentEditEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	public class WriterAfterFieldContentEditEventArgs : IWriterAfterFieldContentEditEventArgs
	{
		internal const string CLASSID = "BE8FB62C-F76E-4F18-AE0B-0FF2034C250D";

		internal const string CLASSID_Interface = "2BC86E56-454B-4C1E-912D-AAE838379536";

		private string _EditorTypeName;

		private XTextInputFieldElement _Element;

		private ListItemCollection _SelectedItems;

		private string _ElementID;

		private string _ElementName;

		private string _SelectedIndexs;

		private string _OldText;

		private string _OldValue;

		private string _NewText;

		private string _NewValue;

		/// <summary>
		///       编辑器类型名称
		///       </summary>
		[DefaultValue(null)]
		public string EditorTypeName
		{
			get
			{
				return _EditorTypeName;
			}
			set
			{
				_EditorTypeName = value;
			}
		}

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		[XmlIgnore]
		public WriterControl WriterControl => Element.WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		[XmlIgnore]
		public XTextDocument Document => Element.OwnerDocument;

		/// <summary>
		///       输入域元素对象
		///       </summary>
		[XmlIgnore]
		public XTextInputFieldElement Element => _Element;

		/// <summary>
		///       选择的项目集合
		///       </summary>
		[XmlArrayItem("Item", typeof(ListItem))]
		[DefaultValue(null)]
		public ListItemCollection SelectedItems
		{
			get
			{
				return _SelectedItems;
			}
			set
			{
				_SelectedItems = value;
			}
		}

		/// <summary>
		///       元素编号
		///       </summary>
		[DefaultValue(null)]
		public string ElementID
		{
			get
			{
				return _ElementID;
			}
			set
			{
				_ElementID = value;
			}
		}

		/// <summary>
		///       元素名称
		///       </summary>
		[DefaultValue(null)]
		public string ElementName
		{
			get
			{
				return _ElementName;
			}
			set
			{
				_ElementName = value;
			}
		}

		/// <summary>
		///       选择的下拉列表序号列表，从0开始计算，各个序号之间用逗号分开。
		///       </summary>
		[DefaultValue(null)]
		public string SelectedIndexs
		{
			get
			{
				return _SelectedIndexs;
			}
			set
			{
				_SelectedIndexs = value;
			}
		}

		/// <summary>
		///       旧的文本值
		///       </summary>
		[DefaultValue(null)]
		public string OldText
		{
			get
			{
				return _OldText;
			}
			set
			{
				_OldText = value;
			}
		}

		/// <summary>
		///       旧的数值
		///       </summary>
		[DefaultValue(null)]
		public string OldValue
		{
			get
			{
				return _OldValue;
			}
			set
			{
				_OldValue = value;
			}
		}

		/// <summary>
		///       新文本
		///       </summary>
		[DefaultValue(null)]
		public string NewText
		{
			get
			{
				return _NewText;
			}
			set
			{
				_NewText = value;
			}
		}

		/// <summary>
		///       新数值
		///       </summary>
		[DefaultValue(null)]
		public string NewValue
		{
			get
			{
				return _NewValue;
			}
			set
			{
				_NewValue = value;
			}
		}

		[DCInternal]
		public WriterAfterFieldContentEditEventArgs()
		{
			_EditorTypeName = null;
			_Element = null;
			_SelectedItems = null;
			_ElementID = null;
			_ElementName = null;
			_SelectedIndexs = null;
			_OldText = null;
			_OldValue = null;
			_NewText = null;
			_NewValue = null;
			
		}

		[DCInternal]
		public WriterAfterFieldContentEditEventArgs(XTextInputFieldElement field, string selectedIndexs, ListItemCollection selectedItems, string editorTypeName, string oldText, string oldValue)
		{
			int num = 9;
			_EditorTypeName = null;
			_Element = null;
			_SelectedItems = null;
			_ElementID = null;
			_ElementName = null;
			_SelectedIndexs = null;
			_OldText = null;
			_OldValue = null;
			_NewText = null;
			_NewValue = null;
			
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			_Element = field;
			_SelectedIndexs = selectedIndexs;
			_ElementID = field.ID;
			_SelectedItems = selectedItems;
			_EditorTypeName = editorTypeName;
			_OldText = oldText;
			_OldValue = oldValue;
			_NewText = field.Text;
			_NewValue = field.InnerValue;
			_ElementName = field.Name;
		}
	}
}
