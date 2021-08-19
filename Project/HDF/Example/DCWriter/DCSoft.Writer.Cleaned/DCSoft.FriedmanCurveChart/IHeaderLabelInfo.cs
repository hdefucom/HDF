using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>HeaderLabelInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("92EF1663-9DED-4F24-B0BA-3DAC1F7205AC")]
	[ComVisible(true)]
	[Browsable(false)]
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
