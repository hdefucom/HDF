using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>ValuePointDataSourceInfo 的COM接口</summary>
	[Guid("08BAA955-3F05-4931-BB0E-C935FB30A93D")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IValuePointDataSourceInfo
	{
		/// <summary>属性FieldNameForID</summary>
		[DispId(2)]
		string FieldNameForID
		{
			get;
			set;
		}

		/// <summary>属性FieldNameForLanternValue</summary>
		[DispId(3)]
		string FieldNameForLanternValue
		{
			get;
			set;
		}

		/// <summary>属性FieldNameForLink</summary>
		[DispId(4)]
		string FieldNameForLink
		{
			get;
			set;
		}

		/// <summary>属性FieldNameForText</summary>
		[DispId(5)]
		string FieldNameForText
		{
			get;
			set;
		}

		/// <summary>属性FieldNameForTime</summary>
		[DispId(6)]
		string FieldNameForTime
		{
			get;
			set;
		}

		/// <summary>属性FieldNameForTitle</summary>
		[DispId(7)]
		string FieldNameForTitle
		{
			get;
			set;
		}

		/// <summary>属性FieldNameForValue</summary>
		[DispId(8)]
		string FieldNameForValue
		{
			get;
			set;
		}

		/// <summary>属性SQLText</summary>
		[DispId(9)]
		string SQLText
		{
			get;
			set;
		}
	}
}
