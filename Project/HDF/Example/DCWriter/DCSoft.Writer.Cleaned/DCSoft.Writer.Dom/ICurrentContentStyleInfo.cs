using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>CurrentContentStyleInfo 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("C44F242D-633B-46AF-94A6-B307DE070939")]
	public interface ICurrentContentStyleInfo
	{
		/// <summary>属性Cell</summary>
		[DispId(2)]
		DocumentContentStyle Cell
		{
			get;
			set;
		}

		/// <summary>属性Content</summary>
		[DispId(3)]
		DocumentContentStyle Content
		{
			get;
			set;
		}

		/// <summary>属性ContentStyleForNewString</summary>
		[DispId(4)]
		DocumentContentStyle ContentStyleForNewString
		{
			get;
			set;
		}

		/// <summary>属性Paragraph</summary>
		[DispId(5)]
		DocumentContentStyle Paragraph
		{
			get;
			set;
		}
	}
}
