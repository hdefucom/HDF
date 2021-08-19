using DCSoft.FriedmanCurveChart;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxFriedmanCurveControl 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("E04D7C01-A7B6-4A49-A302-DEFB122D2631")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IAxFriedmanCurveControl
	{
		/// <summary>属性CaretDateTime</summary>
		[DispId(48)]
		DateTime CaretDateTime
		{
			get;
			set;
		}

		/// <summary>属性CodeBaseForUpdateAssembly</summary>
		[DispId(49)]
		string CodeBaseForUpdateAssembly
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(50)]
		FriedmanCurveDocument Document
		{
			get;
			set;
		}

		/// <summary>属性DocumentConfigXml</summary>
		[DispId(51)]
		string DocumentConfigXml
		{
			get;
			set;
		}

		/// <summary>属性NumOfPages</summary>
		[DispId(52)]
		int NumOfPages
		{
			get;
		}

		/// <summary>属性PageBackColor</summary>
		[DispId(53)]
		Color PageBackColor
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(54)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性RegisterCode</summary>
		[DispId(55)]
		string RegisterCode
		{
			get;
			set;
		}

		/// <summary>属性ShowTooltip</summary>
		[DispId(56)]
		bool ShowTooltip
		{
			get;
			set;
		}

		/// <summary>属性ToolbarVisible</summary>
		[DispId(57)]
		bool ToolbarVisible
		{
			get;
			set;
		}

		/// <summary>属性ViewMode</summary>
		[DispId(58)]
		FCDocumentViewMode ViewMode
		{
			get;
			set;
		}

		/// <summary>属性XMLText</summary>
		[DispId(59)]
		string XMLText
		{
			get;
			set;
		}

		/// <summary>属性XMLTextIndented</summary>
		[DispId(60)]
		string XMLTextIndented
		{
			get;
			set;
		}

		/// <summary>方法AboutControl</summary>
		[DispId(7)]
		void AboutControl();

		/// <summary>方法AddPoint</summary>
		[DispId(8)]
		void AddPoint(string name, FCValuePoint point);

		/// <summary>方法AddPointByTimeText</summary>
		[DispId(9)]
		void AddPointByTimeText(string name, DateTime dateTime_0, string text);

		/// <summary>方法AddPointByTimeTextColor</summary>
		[DispId(10)]
		void AddPointByTimeTextColor(string name, DateTime dateTime_0, string text, string htmlColorValue);

		/// <summary>方法AddPointByTimeTextValue</summary>
		[DispId(11)]
		void AddPointByTimeTextValue(string name, DateTime dateTime_0, string text, float Value);

		/// <summary>方法AddPointByTimeValue</summary>
		[DispId(12)]
		void AddPointByTimeValue(string name, DateTime dateTime_0, float Value);

		/// <summary>方法AddPointByTimeValueLandernValue</summary>
		[DispId(13)]
		void AddPointByTimeValueLandernValue(string name, DateTime dateTime_0, float Value, float landernValue);

		/// <summary>方法BeginDeleteValuePoint</summary>
		[DispId(14)]
		void BeginDeleteValuePoint();

		/// <summary>方法BeginDragValuePointFixDate</summary>
		[DispId(15)]
		void BeginDragValuePointFixDate();

		/// <summary>方法BeginInsertValuePointFor</summary>
		[DispId(16)]
		bool BeginInsertValuePointFor(string yaxisInfoName);

		/// <summary>方法CancelEditValuePoint</summary>
		[DispId(17)]
		void CancelEditValuePoint();

		/// <summary>方法ClearData</summary>
		[DispId(18)]
		void ClearData();

		/// <summary>方法ComCreateFriedmanCurveDocument</summary>
		[DispId(19)]
		FriedmanCurveDocument ComCreateFriedmanCurveDocument();

		/// <summary>方法ComCreateHeaderLabelInfo</summary>
		[DispId(20)]
		FCHeaderLabelInfo ComCreateHeaderLabelInfo();

		/// <summary>方法ComCreateTitleLineInfo</summary>
		[DispId(21)]
		FCTitleLineInfo ComCreateTitleLineInfo();

		/// <summary>方法ComCreateValuePoint</summary>
		[DispId(22)]
		FCValuePoint ComCreateValuePoint();

		/// <summary>方法ComCreateYAxisInfo</summary>
		[DispId(23)]
		FCYAxisInfo ComCreateYAxisInfo();

		/// <summary>方法ComCreateYAxisScaleInfo</summary>
		[DispId(24)]
		FCYAxisScaleInfo ComCreateYAxisScaleInfo();

		/// <summary>方法ComDispose</summary>
		[DispId(25)]
		void ComDispose();

		/// <summary>方法CreateValuePoint</summary>
		[DispId(26)]
		FCValuePoint CreateValuePoint();

		/// <summary>方法InvalidateAll</summary>
		[DispId(27)]
		void InvalidateAll();

		/// <summary>方法LoadDocumentFormString</summary>
		[DispId(28)]
		void LoadDocumentFormString(string string_0);

		/// <summary>方法LoadDocumentFromFile</summary>
		[DispId(29)]
		void LoadDocumentFromFile(string fileName);

		/// <summary>方法PrintCurrentPage</summary>
		[DispId(30)]
		void PrintCurrentPage();

		/// <summary>方法PrintDocument</summary>
		[DispId(31)]
		void PrintDocument();

		/// <summary>方法PrintDocumentPageIndex</summary>
		[DispId(32)]
		void PrintDocumentPageIndex(string pageIndex);

		/// <summary>方法PrintDocumentSpecifyPageIndex</summary>
		[DispId(33)]
		void PrintDocumentSpecifyPageIndex(int pageIndex);

		/// <summary>方法RefreshView</summary>
		[DispId(34)]
		void RefreshView();

		/// <summary>方法RefreshViewWithoutRefreshDataSource</summary>
		[DispId(35)]
		void RefreshViewWithoutRefreshDataSource();

		/// <summary>方法RunDesigner</summary>
		[DispId(36)]
		bool RunDesigner();

		/// <summary>方法RunDesignerMax</summary>
		[DispId(37)]
		bool RunDesignerMax();

		/// <summary>方法SaveDataHtmlToFile</summary>
		[DispId(38)]
		void SaveDataHtmlToFile(string fileName);

		/// <summary>方法SaveDataHtmlToStream</summary>
		[DispId(39)]
		void SaveDataHtmlToStream(Stream stream);

		/// <summary>方法SaveDocumentToFile</summary>
		[DispId(40)]
		void SaveDocumentToFile(string fileName);

		/// <summary>方法SaveDocumentToString</summary>
		[DispId(41)]
		string SaveDocumentToString();

		/// <summary>方法SetFriedmanCurveZoneRange</summary>
		[DispId(42)]
		bool SetFriedmanCurveZoneRange(string zoneName, DateTime startTime, DateTime endTime);

		/// <summary>方法SetHeaderLableValue</summary>
		[DispId(43)]
		void SetHeaderLableValue(string title, string text);

		/// <summary>方法SetHeaderLableValueByIndex</summary>
		[DispId(44)]
		void SetHeaderLableValueByIndex(int index, string text);

		/// <summary>方法SetParameterValue</summary>
		[DispId(45)]
		void SetParameterValue(string pName, string pValue);
	}
}
