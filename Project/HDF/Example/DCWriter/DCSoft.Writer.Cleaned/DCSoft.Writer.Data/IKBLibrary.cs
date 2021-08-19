using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>KBLibrary 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("5685CEC6-0C2C-40BE-9152-DA6B0CCCA36C")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IKBLibrary
	{
		/// <summary>属性BaseURL</summary>
		[DispId(4)]
		string BaseURL
		{
			get;
			set;
		}

		/// <summary>属性KBEntries</summary>
		[DispId(5)]
		KBEntryList KBEntries
		{
			get;
			set;
		}

		/// <summary>属性ListItemsSourceFormatString</summary>
		[DispId(6)]
		string ListItemsSourceFormatString
		{
			get;
			set;
		}

		/// <summary>属性TemplateFileFormat</summary>
		[DispId(7)]
		string TemplateFileFormat
		{
			get;
			set;
		}

		/// <summary>属性TemplateFileSystemName</summary>
		[DispId(8)]
		string TemplateFileSystemName
		{
			get;
			set;
		}

		/// <summary>属性TemplateSourceFormatString</summary>
		[DispId(9)]
		string TemplateSourceFormatString
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(10)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性UseLanguage2</summary>
		[DispId(12)]
		bool UseLanguage2
		{
			get;
			set;
		}

		/// <summary>属性Version</summary>
		[DispId(11)]
		string Version
		{
			get;
			set;
		}

		/// <summary>方法Load</summary>
		[DispId(2)]
		bool Load(string string_0);

		/// <summary>方法Save</summary>
		[DispId(3)]
		bool Save(string fileName);
	}
}
