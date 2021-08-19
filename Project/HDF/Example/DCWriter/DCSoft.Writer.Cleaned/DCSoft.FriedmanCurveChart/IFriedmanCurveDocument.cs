using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>FriedmanCurveDocument 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("4C126355-BF4A-44DF-A707-4A13A84CE1A0")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IFriedmanCurveDocument
	{
		/// <summary>属性BackColor</summary>
		[DispId(2)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性Bottom</summary>
		[DispId(3)]
		float Bottom
		{
			get;
		}

		/// <summary>属性Bounds</summary>
		[DispId(4)]
		RectangleF Bounds
		{
			get;
			set;
		}

		/// <summary>属性Config</summary>
		[DispId(41)]
		FriedmanCurveDocumentConfig Config
		{
			get;
			set;
		}

		/// <summary>属性ConfigXml</summary>
		[DispId(26)]
		string ConfigXml
		{
			get;
			set;
		}

		/// <summary>属性DataSources</summary>
		[DispId(5)]
		Hashtable DataSources
		{
			get;
		}

		/// <summary>属性DateFormatString</summary>
		[DispId(6)]
		string DateFormatString
		{
			get;
			set;
		}

		/// <summary>属性Days</summary>
		[DispId(27)]
		int Days
		{
			get;
		}

		/// <summary>属性FontName</summary>
		[DispId(7)]
		string FontName
		{
			get;
			set;
		}

		/// <summary>属性FontSize</summary>
		[DispId(8)]
		float FontSize
		{
			get;
			set;
		}

		/// <summary>属性FooterLines</summary>
		[DispId(9)]
		FCTitleLineInfoList FooterLines
		{
			get;
			set;
		}

		/// <summary>属性GridLineColor</summary>
		[DispId(28)]
		Color GridLineColor
		{
			get;
			set;
		}

		/// <summary>属性GridYSplitNum</summary>
		[DispId(29)]
		int GridYSplitNum
		{
			get;
			set;
		}

		/// <summary>属性HeaderLabels</summary>
		[DispId(10)]
		FCHeaderLabelInfoList HeaderLabels
		{
			get;
			set;
		}

		/// <summary>属性HeaderLines</summary>
		[DispId(11)]
		FCTitleLineInfoList HeaderLines
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(12)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ImagePixelHeight</summary>
		[DispId(37)]
		int ImagePixelHeight
		{
			get;
			set;
		}

		/// <summary>属性ImagePixelWidth</summary>
		[DispId(38)]
		int ImagePixelWidth
		{
			get;
			set;
		}

		/// <summary>属性Left</summary>
		[DispId(15)]
		float Left
		{
			get;
			set;
		}

		/// <summary>属性NumOfHoursInOnePage</summary>
		[DispId(16)]
		int NumOfHoursInOnePage
		{
			get;
			set;
		}

		/// <summary>属性NumOfPages</summary>
		[DispId(17)]
		int NumOfPages
		{
			get;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(18)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性RegisterCode</summary>
		[DispId(39)]
		string RegisterCode
		{
			get;
			set;
		}

		/// <summary>属性Right</summary>
		[DispId(19)]
		float Right
		{
			get;
		}

		/// <summary>属性ShadowPointDetectSeconds</summary>
		[DispId(40)]
		int ShadowPointDetectSeconds
		{
			get;
			set;
		}

		/// <summary>属性SymbolSize</summary>
		[DispId(20)]
		float SymbolSize
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(21)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(22)]
		float Top
		{
			get;
			set;
		}

		/// <summary>属性ViewMode</summary>
		[DispId(23)]
		FCDocumentViewMode ViewMode
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(24)]
		float Width
		{
			get;
			set;
		}

		/// <summary>属性YAxisInfos</summary>
		[DispId(25)]
		FCYAxisInfoList YAxisInfos
		{
			get;
			set;
		}

		/// <summary>方法AddPoint</summary>
		[DispId(30)]
		void AddPoint(string name, FCValuePoint point);

		/// <summary>方法AddPointByTimeText</summary>
		[DispId(31)]
		void AddPointByTimeText(string name, DateTime dateTime_0, string text);

		/// <summary>方法AddPointByTimeTextColor</summary>
		[DispId(32)]
		void AddPointByTimeTextColor(string name, DateTime dateTime_0, string text, string htmlColorValue);

		/// <summary>方法AddPointByTimeTextValue</summary>
		[DispId(33)]
		void AddPointByTimeTextValue(string name, DateTime dateTime_0, string text, float Value);

		/// <summary>方法AddPointByTimeValue</summary>
		[DispId(34)]
		void AddPointByTimeValue(string name, DateTime dateTime_0, float Value);

		/// <summary>方法AddPointByTimeValueLandernValue</summary>
		[DispId(35)]
		void AddPointByTimeValueLandernValue(string name, DateTime dateTime_0, float Value, float landernValue);

		/// <summary>方法ClearData</summary>
		[DispId(42)]
		void ClearData();

		/// <summary>方法SetHeaderLableValue</summary>
		[DispId(36)]
		void SetHeaderLableValue(string title, string text);

		/// <summary>方法SetHeaderLableValueByIndex</summary>
		[DispId(43)]
		void SetHeaderLableValueByIndex(int index, string text);
	}
}
