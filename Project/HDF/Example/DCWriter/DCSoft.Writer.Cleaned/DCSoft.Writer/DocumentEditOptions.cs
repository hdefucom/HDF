using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器选项控制
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComClass("00012345-6789-ABCD-EF01-234567890069", "9D5FE97A-2FFB-4F2E-80A1-8D6A63E80497")]
	[DocumentComment]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDocumentEditOptions))]
	[Guid("00012345-6789-ABCD-EF01-234567890069")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[DCPublishAPI]
	public class DocumentEditOptions : ICloneable, IDocumentEditOptions
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890069";

		internal const string CLASSID_Interface = "9D5FE97A-2FFB-4F2E-80A1-8D6A63E80497";

		private bool _CopyWithoutInputFieldStructure = false;

		private bool _CopyInTextFormatOnly = false;

		private bool _CloneWithoutElementBorderStyle = true;

		private bool _CloneWithoutLogicDeletedContent = false;

		private string _GridLinePreviewText = WriterStringsCore.GridLinePreviewText;

		private bool _ClearFieldValueWhenCopy = false;

		private bool _KeepTableWidthWhenInsertDeleteColumn = true;

		private bool _FixSizeWhenInsertImage = true;

		private bool _FixWidthWhenInsertImage = true;

		private bool _FixWidthWhenInsertTable = true;

		private bool _TabKeyToFirstLineIndent = true;

		private bool _AutoInsertTableRowWhenMoveToNextCell = true;

		private bool _TabKeyToInsertTableRow = true;

		private DocumentValueValidateMode _ValueValidateMode = DocumentValueValidateMode.LostFocus;

		/// <summary>
		///       复制时去掉输入域层次结构
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentEditOptions), "CopyWithoutInputFieldStructure")]
		public bool CopyWithoutInputFieldStructure
		{
			get
			{
				return _CopyWithoutInputFieldStructure;
			}
			set
			{
				_CopyWithoutInputFieldStructure = value;
			}
		}

		/// <summary>
		///       仅仅采用纯文本格式复制内容,若为true，则只复制纯文本内容，而且忽略掉控件的CreationDataFormats属性设置.
		///       </summary>
		[DCDescription(typeof(DocumentEditOptions), "CopyInTextFormatOnly")]
		[DefaultValue(false)]
		public bool CopyInTextFormatOnly
		{
			get
			{
				return _CopyInTextFormatOnly;
			}
			set
			{
				_CopyInTextFormatOnly = value;
			}
		}

		/// <summary>
		///       复制文档时清掉文档元素的边框样式，默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentEditOptions), "CloneWithoutElementBorderStyle")]
		public bool CloneWithoutElementBorderStyle
		{
			get
			{
				return _CloneWithoutElementBorderStyle;
			}
			set
			{
				_CloneWithoutElementBorderStyle = value;
			}
		}

		/// <summary>
		///       复制文档的时候不复制已经被逻辑删除的内容，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentEditOptions), "CloneWithoutLogicDeletedContent")]
		public bool CloneWithoutLogicDeletedContent
		{
			get
			{
				return _CloneWithoutLogicDeletedContent;
			}
			set
			{
				_CloneWithoutLogicDeletedContent = value;
			}
		}

		/// <summary>
		///       预览内容网格线功能时使用的预览文字。
		///       </summary>
		[DCDescription(typeof(DocumentEditOptions), "GridLinePreviewText")]
		public string GridLinePreviewText
		{
			get
			{
				return _GridLinePreviewText;
			}
			set
			{
				_GridLinePreviewText = value;
			}
		}

		/// <summary>
		///       在复制内容时清空输入域的内容，默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentEditOptions), "ClearFieldValueWhenCopy")]
		[DefaultValue(false)]
		public bool ClearFieldValueWhenCopy
		{
			get
			{
				return _ClearFieldValueWhenCopy;
			}
			set
			{
				_ClearFieldValueWhenCopy = value;
			}
		}

		/// <summary>
		///       在插入和删除表格列时是否保持表格的总宽度不变。默认true。
		///       </summary>
		[DCDescription(typeof(DocumentEditOptions), "KeepTableWidthWhenInsertDeleteColumn")]
		[DefaultValue(true)]
		public bool KeepTableWidthWhenInsertDeleteColumn
		{
			get
			{
				return _KeepTableWidthWhenInsertDeleteColumn;
			}
			set
			{
				_KeepTableWidthWhenInsertDeleteColumn = value;
			}
		}

		/// <summary>
		///       在插入图片时自动修正图片的宽度，使得图片元素的宽度不会超过容器客户区宽度，而且高度不超过标准页高。默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentEditOptions), "FixSizeWhenInsertImage")]
		[DefaultValue(true)]
		public bool FixSizeWhenInsertImage
		{
			get
			{
				return _FixSizeWhenInsertImage;
			}
			set
			{
				_FixSizeWhenInsertImage = value;
			}
		}

		/// <summary>
		///       在插入图片时为容器元素修正图片的宽度，使得图片元素的宽度不会超过容器客户区宽度。默认为true。
		///       </summary>
		[Browsable(false)]
		[DCDescription(typeof(DocumentEditOptions), "FixWidthWhenInsertImage")]
		[DefaultValue(true)]
		[XmlIgnore]
		[Obsolete("请使用FixSizeWhenInsertImage!!!")]
		public bool FixWidthWhenInsertImage
		{
			get
			{
				return _FixWidthWhenInsertImage;
			}
			set
			{
				_FixWidthWhenInsertImage = value;
			}
		}

		/// <summary>
		///       在插入表格时为容器元素修正表格的宽度，使得表格元素的宽度不会超过容器客户区宽度，默认true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentEditOptions), "FixWidthWhenInsertTable")]
		public bool FixWidthWhenInsertTable
		{
			get
			{
				return _FixWidthWhenInsertTable;
			}
			set
			{
				_FixWidthWhenInsertTable = value;
			}
		}

		/// <summary>
		///       是否使用Tab键来设置段落首行缩进，默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentEditOptions), "TabKeyToFirstLineIndent")]
		[DefaultValue(true)]
		public bool TabKeyToFirstLineIndent
		{
			get
			{
				return _TabKeyToFirstLineIndent;
			}
			set
			{
				_TabKeyToFirstLineIndent = value;
			}
		}

		/// <summary>
		///       在移动到下一个单元格时根据需要自动插入表格行
		///       </summary>
		[DefaultValue(true)]
		public bool AutoInsertTableRowWhenMoveToNextCell
		{
			get
			{
				return _AutoInsertTableRowWhenMoveToNextCell;
			}
			set
			{
				_AutoInsertTableRowWhenMoveToNextCell = value;
			}
		}

		/// <summary>
		///       是否允许在表格中最后一个单元格中使用Tab键来新增表格行，默认为true。
		///       </summary>
		[Obsolete("本属性作废，请使用AutoInsertTableRowWhenMoveToNextCell.")]
		[DefaultValue(true)]
		[Browsable(false)]
		[DCDescription(typeof(DocumentEditOptions), "TabKeyToInsertTableRow")]
		public bool TabKeyToInsertTableRow
		{
			get
			{
				return _TabKeyToInsertTableRow;
			}
			set
			{
				_TabKeyToInsertTableRow = value;
			}
		}

		/// <summary>
		///       文档数据校验模式，默认为LostFocus。
		///       </summary>
		[DefaultValue(DocumentValueValidateMode.LostFocus)]
		[DCDescription(typeof(DocumentEditOptions), "ValueValidateMode")]
		public DocumentValueValidateMode ValueValidateMode
		{
			get
			{
				return _ValueValidateMode;
			}
			set
			{
				_ValueValidateMode = value;
			}
		}

		object ICloneable.Clone()
		{
			return (DocumentEditOptions)MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DocumentEditOptions Clone()
		{
			return (DocumentEditOptions)((ICloneable)this).Clone();
		}
	}
}
