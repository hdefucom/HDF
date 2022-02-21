using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数据源绑定信息列表
	///       </summary>
	[DocumentComment]
	
	[ComDefaultInterface(typeof(IDataSourceBindingDescriptionList))]
	[ComVisible(true)]
	[ComClass("614D20AD-4ECB-44A8-B584-706CFBAC2006", "BB9EC01B-A78C-45FD-A1CF-83C56606327D")]
	[Guid("614D20AD-4ECB-44A8-B584-706CFBAC2006")]
	[ClassInterface(ClassInterfaceType.None)]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	public class DataSourceBindingDescriptionList : List<DataSourceBindingDescription>, IDataSourceBindingDescriptionList
	{
		internal const string CLASSID = "614D20AD-4ECB-44A8-B584-706CFBAC2006";

		internal const string CLASSID_Interface = "BB9EC01B-A78C-45FD-A1CF-83C56606327D";
	}
}
