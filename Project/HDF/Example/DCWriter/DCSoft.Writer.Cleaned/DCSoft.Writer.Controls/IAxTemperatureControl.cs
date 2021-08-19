using DCSoft.TemperatureChart;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxTemperatureControl 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("69ECCB7E-4595-4202-BD44-1C6EFF6237C7")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IAxTemperatureControl
	{
		/// <summary>属性CaretDateTime</summary>
		[DispId(55)]
		DateTime CaretDateTime
		{
			get;
			set;
		}

		/// <summary>属性CodeBaseForUpdateAssembly</summary>
		[DispId(52)]
		string CodeBaseForUpdateAssembly
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(11)]
		TemperatureDocument Document
		{
			get;
			set;
		}

		/// <summary>属性DocumentConfigXml</summary>
		[DispId(24)]
		string DocumentConfigXml
		{
			get;
			set;
		}

		/// <summary>属性NumOfPages</summary>
		[DispId(33)]
		int NumOfPages
		{
			get;
		}

		/// <summary>属性PageBackColor</summary>
		[DispId(12)]
		Color PageBackColor
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(34)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性ShowTooltip</summary>
		[DispId(14)]
		bool ShowTooltip
		{
			get;
			set;
		}

		/// <summary>属性ToolbarVisible</summary>
		[DispId(15)]
		bool ToolbarVisible
		{
			get;
			set;
		}

		/// <summary>属性ViewMode</summary>
		[DispId(16)]
		DocumentViewMode ViewMode
		{
			get;
			set;
		}

		/// <summary>属性XMLText</summary>
		[DispId(53)]
		string XMLText
		{
			get;
			set;
		}

		/// <summary>属性XMLTextIndented</summary>
		[DispId(54)]
		string XMLTextIndented
		{
			get;
			set;
		}

		/// <summary>方法AboutControl</summary>
		[DispId(2)]
		void AboutControl();

		/// <summary>方法AddPoint</summary>
		[DispId(26)]
		void AddPoint(string name, ValuePoint point);

		/// <summary>方法AddPointByTimeText</summary>
		[DispId(17)]
		void AddPointByTimeText(string name, DateTime dateTime_0, string text);

		/// <summary>方法AddPointByTimeTextColor</summary>
		[DispId(27)]
		void AddPointByTimeTextColor(string name, DateTime dateTime_0, string text, string htmlColorValue);

		/// <summary>方法AddPointByTimeTextValue</summary>
		[DispId(28)]
		void AddPointByTimeTextValue(string name, DateTime dateTime_0, string text, float Value);

		/// <summary>方法AddPointByTimeValue</summary>
		[DispId(18)]
		void AddPointByTimeValue(string name, DateTime dateTime_0, float Value);

		/// <summary>方法AddPointByTimeValueLandernValue</summary>
		[DispId(19)]
		void AddPointByTimeValueLandernValue(string name, DateTime dateTime_0, float Value, float landernValue);

		/// <summary>方法BeginDeleteValuePoint</summary>
		[DispId(47)]
		void BeginDeleteValuePoint();

		/// <summary>方法BeginDragValuePointFixDate</summary>
		[DispId(48)]
		void BeginDragValuePointFixDate();

		/// <summary>方法BeginInsertValuePointFor</summary>
		[DispId(49)]
		bool BeginInsertValuePointFor(string yaxisInfoName);

		/// <summary>方法CancelEditValuePoint</summary>
		[DispId(50)]
		void CancelEditValuePoint();

		/// <summary>方法ClearData</summary>
		[DispId(31)]
		void ClearData();

		/// <summary>方法ComCreateHeaderLabelInfo</summary>
		[DispId(3)]
		HeaderLabelInfo ComCreateHeaderLabelInfo();

		/// <summary>方法ComCreateTemperatureDocument</summary>
		[DispId(4)]
		TemperatureDocument ComCreateTemperatureDocument();

		/// <summary>方法ComCreateTitleLineInfo</summary>
		[DispId(5)]
		TitleLineInfo ComCreateTitleLineInfo();

		/// <summary>方法ComCreateValuePoint</summary>
		[DispId(6)]
		ValuePoint ComCreateValuePoint();

		/// <summary>方法ComCreateYAxisInfo</summary>
		[DispId(7)]
		YAxisInfo ComCreateYAxisInfo();

		/// <summary>方法ComCreateYAxisScaleInfo</summary>
		[DispId(8)]
		YAxisScaleInfo ComCreateYAxisScaleInfo();

		/// <summary>方法ComDispose</summary>
		[DispId(9)]
		void ComDispose();

		/// <summary>方法CreateValuePoint</summary>
		[DispId(29)]
		ValuePoint CreateValuePoint();

		/// <summary>方法LoadDocumentFormString</summary>
		[DispId(56)]
		void LoadDocumentFormString(string string_0);

		/// <summary>方法LoadDocumentFromFile</summary>
		[DispId(35)]
		void LoadDocumentFromFile(string fileName);

		/// <summary>方法PrintCurrentPage</summary>
		[DispId(20)]
		void PrintCurrentPage();

		/// <summary>方法PrintDocument</summary>
		[DispId(21)]
		void PrintDocument();

		/// <summary>方法PrintDocumentSpecifyPageIndex</summary>
		[DispId(22)]
		void PrintDocumentSpecifyPageIndex(int pageIndex);

		/// <summary>方法RefreshView</summary>
		[DispId(10)]
		void RefreshView();

		/// <summary>方法RefreshViewWithoutRefreshDataSource</summary>
		[DispId(42)]
		void RefreshViewWithoutRefreshDataSource();

		/// <summary>方法RunDesigner</summary>
		[DispId(32)]
		bool RunDesigner();

		/// <summary>方法SaveDataHtmlToFile</summary>
		[DispId(43)]
		void SaveDataHtmlToFile(string fileName);

		/// <summary>方法SaveDocumentToFile</summary>
		[DispId(36)]
		void SaveDocumentToFile(string fileName);

		/// <summary>方法SaveDocumentToString</summary>
		[DispId(57)]
		string SaveDocumentToString();

		/// <summary>方法SetHeaderLableValue</summary>
		[DispId(23)]
		void SetHeaderLableValue(string title, string text);

		/// <summary>方法SetHeaderLableValueByIndex</summary>
		[DispId(37)]
		void SetHeaderLableValueByIndex(int index, string text);

		/// <summary>方法SetParameterValue</summary>
		[DispId(44)]
		void SetParameterValue(string pName, string pValue);

		/// <summary>方法SetRegisterCode</summary>
		[DispId(30)]
		void SetRegisterCode(string registerCode);

		/// <summary>方法SetTimeLineZoneRange</summary>
		[DispId(41)]
		bool SetTimeLineZoneRange(string zoneName, DateTime startTime, DateTime endTime);
	}
}
