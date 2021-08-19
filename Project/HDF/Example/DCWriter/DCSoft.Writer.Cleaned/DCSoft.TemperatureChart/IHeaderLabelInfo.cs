using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>HeaderLabelInfo 的COM接口</summary>
	[Guid("051E1597-9F3D-4856-AA72-5B3517EFAC5F")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IHeaderLabelInfo
	{
		/// <summary>属性DataSourceName</summary>
		[DispId(2)]
		string DataSourceName
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(3)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(4)]
		string Value
		{
			get;
			set;
		}

		/// <summary>属性ValueFieldName</summary>
		[DispId(5)]
		string ValueFieldName
		{
			get;
			set;
		}
	}
}
