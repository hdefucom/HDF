using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>YAxisInfo 的COM接口</summary>
	[Guid("29F4E70C-67AB-4826-A26F-F51E867474C9")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IYAxisInfo
	{
		/// <summary>属性AllowOutofRange</summary>
		[DispId(20)]
		bool AllowOutofRange
		{
			get;
			set;
		}

		/// <summary>属性ClickToHide</summary>
		[DispId(21)]
		bool ClickToHide
		{
			get;
			set;
		}

		/// <summary>属性DataSourceName</summary>
		[DispId(2)]
		string DataSourceName
		{
			get;
			set;
		}

		/// <summary>属性LanternValueFieldName</summary>
		[DispId(3)]
		string LanternValueFieldName
		{
			get;
			set;
		}

		/// <summary>属性MaxValue</summary>
		[DispId(4)]
		float MaxValue
		{
			get;
			set;
		}

		/// <summary>属性MinValue</summary>
		[DispId(5)]
		float MinValue
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(16)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性RedLineValue</summary>
		[DispId(23)]
		float RedLineValue
		{
			get;
			set;
		}

		/// <summary>属性Scales</summary>
		[DispId(6)]
		YAxisScaleInfoList Scales
		{
			get;
			set;
		}

		/// <summary>属性ShadowName</summary>
		[DispId(17)]
		string ShadowName
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(10)]
		YAxisInfoStyle Style
		{
			get;
			set;
		}

		/// <summary>属性SymbolColor</summary>
		[DispId(7)]
		Color SymbolColor
		{
			get;
			set;
		}

		/// <summary>属性SymbolColorValue</summary>
		[DispId(8)]
		string SymbolColorValue
		{
			get;
			set;
		}

		/// <summary>属性SymbolStyle</summary>
		[DispId(9)]
		ValuePointSymbolStyle SymbolStyle
		{
			get;
			set;
		}

		/// <summary>属性TimeFieldName</summary>
		[DispId(11)]
		string TimeFieldName
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(12)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性TitleVisible</summary>
		[DispId(18)]
		bool TitleVisible
		{
			get;
			set;
		}

		/// <summary>属性ValueFieldName</summary>
		[DispId(13)]
		string ValueFieldName
		{
			get;
			set;
		}

		/// <summary>属性ValueFormatString</summary>
		[DispId(24)]
		string ValueFormatString
		{
			get;
			set;
		}

		/// <summary>属性ValueVisible</summary>
		[DispId(22)]
		bool ValueVisible
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(19)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性YSplitNum</summary>
		[DispId(15)]
		int YSplitNum
		{
			get;
			set;
		}
	}
}
