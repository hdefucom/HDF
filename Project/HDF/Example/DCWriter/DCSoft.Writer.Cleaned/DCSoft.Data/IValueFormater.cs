using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>ValueFormater 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("3A82633F-1895-4275-8A32-BA716F70F085")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IValueFormater
	{
		                                                                    /// <summary>属性Format</summary>
		[DispId(6)]
		string Format
		{
			get;
			set;
		}

		                                                                    /// <summary>属性IsEmpty</summary>
		[DispId(7)]
		bool IsEmpty
		{
			get;
		}

		                                                                    /// <summary>属性NoneText</summary>
		[DispId(8)]
		string NoneText
		{
			get;
			set;
		}

		                                                                    /// <summary>属性Style</summary>
		[DispId(9)]
		ValueFormatStyle Style
		{
			get;
			set;
		}
	}
}
