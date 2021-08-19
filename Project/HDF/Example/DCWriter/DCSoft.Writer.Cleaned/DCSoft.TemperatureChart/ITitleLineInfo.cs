using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>TitleLineInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("63AB8773-3A4C-4FBB-AEB3-1D0A8EB4AD0D")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface ITitleLineInfo
	{
		/// <summary>属性CircleText</summary>
		[DispId(15)]
		string CircleText
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

		/// <summary>属性LayoutType</summary>
		[DispId(16)]
		TitleLineLayoutType LayoutType
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(11)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Scales</summary>
		[DispId(13)]
		YAxisScaleInfoList Scales
		{
			get;
			set;
		}

		/// <summary>属性ShowBackColor</summary>
		[DispId(14)]
		bool ShowBackColor
		{
			get;
			set;
		}

		/// <summary>属性SpecifyHeight</summary>
		[DispId(17)]
		float SpecifyHeight
		{
			get;
			set;
		}

		/// <summary>属性StartDate</summary>
		[DispId(4)]
		DateTime StartDate
		{
			get;
			set;
		}

		/// <summary>属性StartDateKeyword</summary>
		[DispId(5)]
		string StartDateKeyword
		{
			get;
			set;
		}

		/// <summary>属性TimeFieldName</summary>
		[DispId(6)]
		string TimeFieldName
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(7)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性ValueFieldName</summary>
		[DispId(8)]
		string ValueFieldName
		{
			get;
			set;
		}

		/// <summary>属性ValueType</summary>
		[DispId(10)]
		TitleLineValueType ValueType
		{
			get;
			set;
		}
	}
}
