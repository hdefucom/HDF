using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DocumentEditOptions 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("9D5FE97A-2FFB-4F2E-80A1-8D6A63E80497")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDocumentEditOptions
	{
		/// <summary>属性AutoInsertTableRowWhenMoveToNextCell</summary>
		[DispId(14)]
		bool AutoInsertTableRowWhenMoveToNextCell
		{
			get;
			set;
		}

		/// <summary>属性ClearFieldValueWhenCopy</summary>
		[DispId(2)]
		bool ClearFieldValueWhenCopy
		{
			get;
			set;
		}

		/// <summary>属性CloneWithoutElementBorderStyle</summary>
		[DispId(11)]
		bool CloneWithoutElementBorderStyle
		{
			get;
			set;
		}

		/// <summary>属性CloneWithoutLogicDeletedContent</summary>
		[DispId(3)]
		bool CloneWithoutLogicDeletedContent
		{
			get;
			set;
		}

		/// <summary>属性CopyInTextFormatOnly</summary>
		[DispId(12)]
		bool CopyInTextFormatOnly
		{
			get;
			set;
		}

		/// <summary>属性CopyWithoutInputFieldStructure</summary>
		[DispId(13)]
		bool CopyWithoutInputFieldStructure
		{
			get;
			set;
		}

		/// <summary>属性FixSizeWhenInsertImage</summary>
		[DispId(15)]
		bool FixSizeWhenInsertImage
		{
			get;
			set;
		}

		/// <summary>属性FixWidthWhenInsertImage</summary>
		[DispId(4)]
		bool FixWidthWhenInsertImage
		{
			get;
			set;
		}

		/// <summary>属性FixWidthWhenInsertTable</summary>
		[DispId(5)]
		bool FixWidthWhenInsertTable
		{
			get;
			set;
		}

		/// <summary>属性GridLinePreviewText</summary>
		[DispId(6)]
		string GridLinePreviewText
		{
			get;
			set;
		}

		/// <summary>属性KeepTableWidthWhenInsertDeleteColumn</summary>
		[DispId(7)]
		bool KeepTableWidthWhenInsertDeleteColumn
		{
			get;
			set;
		}

		/// <summary>属性TabKeyToFirstLineIndent</summary>
		[DispId(8)]
		bool TabKeyToFirstLineIndent
		{
			get;
			set;
		}

		/// <summary>属性TabKeyToInsertTableRow</summary>
		[DispId(9)]
		bool TabKeyToInsertTableRow
		{
			get;
			set;
		}

		/// <summary>属性ValueValidateMode</summary>
		[DispId(10)]
		DocumentValueValidateMode ValueValidateMode
		{
			get;
			set;
		}
	}
}
