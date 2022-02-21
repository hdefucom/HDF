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
	[ComClass("07E8A3FA-1D49-4DCA-ABAB-9A03DB98F467", "AF81279D-7D75-4B2D-881B-FB2824C736FC")]
	[ComDefaultInterface(typeof(IWriterBeforeFieldContentEditEventArgs))]
	[Guid("07E8A3FA-1D49-4DCA-ABAB-9A03DB98F467")]
	
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	public class WriterBeforeFieldContentEditEventArgs : IWriterBeforeFieldContentEditEventArgs
	{
		internal const string CLASSID = "07E8A3FA-1D49-4DCA-ABAB-9A03DB98F467";

		internal const string CLASSID_Interface = "AF81279D-7D75-4B2D-881B-FB2824C736FC";

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

		private bool _Cancel;

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
		///       当前文本值
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
		///       当前数值
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

		/// <summary>
		///       用户取消操作标记
		///       </summary>
		[DefaultValue(false)]
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		
		public WriterBeforeFieldContentEditEventArgs()
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
			_Cancel = false;
			
		}

		
		public WriterBeforeFieldContentEditEventArgs(XTextInputFieldElement field, string selectedIndexs, ListItemCollection selectedItems, string editorTypeName)
		{
			int num = 0;
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
			_Cancel = false;
			
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			_Element = field;
			_SelectedIndexs = selectedIndexs;
			_ElementID = field.ID;
			_SelectedItems = selectedItems;
			_EditorTypeName = editorTypeName;
			_OldText = field.Text;
			_OldValue = field.InnerValue;
			_ElementName = field.Name;
		}
	}
}
