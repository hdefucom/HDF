using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>MotherTemplateInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("E9616384-7887-4071-B773-157F5E594590")]
	public interface IMotherTemplateInfo
	{
		/// <summary>属性FileName</summary>
		[DispId(2)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性FileSystemName</summary>
		[DispId(3)]
		string FileSystemName
		{
			get;
			set;
		}

		/// <summary>属性Format</summary>
		[DispId(4)]
		string Format
		{
			get;
			set;
		}

		/// <summary>属性ImportFooter</summary>
		[DispId(5)]
		bool ImportFooter
		{
			get;
			set;
		}

		/// <summary>属性ImportHeader</summary>
		[DispId(6)]
		bool ImportHeader
		{
			get;
			set;
		}

		/// <summary>属性ImportPageSettings</summary>
		[DispId(7)]
		bool ImportPageSettings
		{
			get;
			set;
		}
	}
}
