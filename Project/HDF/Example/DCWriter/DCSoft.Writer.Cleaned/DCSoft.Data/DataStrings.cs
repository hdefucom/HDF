using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///         一个强类型的资源类，用于查找本地化的字符串等。
	                                                                    ///       </summary>
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class DataStrings
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		                                                                    /// <summary>
		                                                                    ///         返回此类使用的缓存的 ResourceManager 实例。
		                                                                    ///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 13;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Data.DataStrings", typeof(DataStrings).Assembly);
				}
				return resourceManager_0;
			}
		}

		                                                                    /// <summary>
		                                                                    ///         使用此强类型资源类，为所有资源查找
		                                                                    ///         重写当前线程的 CurrentUICulture 属性。
		                                                                    ///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return cultureInfo_0;
			}
			set
			{
				cultureInfo_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///         查找类似 对象已经关闭了。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string AlertClosed => ResourceManager.GetString("AlertClosed", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 请输入服务器地址和用户登录名。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string AlertInputServerAndUser => ResourceManager.GetString("AlertInputServerAndUser", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 请选择一个合适的属性，该属性必须是公开的可读写的，最好是返回一个列表。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string AlertSelectPropertyMember => ResourceManager.GetString("AlertSelectPropertyMember", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从运行中的.NET程序集中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string AssemblyConnectionDescription => ResourceManager.GetString("AssemblyConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 .NET程序集文件(*.dll,*.exe)|*.dll;*.exe 的本地化字符串。
		                                                                    ///       </summary>
		internal static string AssemblyFilter => ResourceManager.GetString("AssemblyFilter", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 不是合法的 DBF（dBase III）文件格式 的本地化字符串。
		                                                                    ///       </summary>
		internal static string BadDBFFormat => ResourceManager.GetString("BadDBFFormat", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 参数“{0}”的数据类型错误，需要的类型为“{1}”，实际数值为“{2}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string BadParameterValueType_Name_Type_Value => ResourceManager.GetString("BadParameterValueType_Name_Type_Value", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 不能对一个数据读取器定义多个索引字段。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string CanNotDefineMultiIndexInOneReader => ResourceManager.GetString("CanNotDefineMultiIndexInOneReader", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 不能定义多个主索引字段。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string CanNotDefineMultiMainIndexField => ResourceManager.GetString("CanNotDefineMultiMainIndexField", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 关闭数据库连接“{1}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string CloseConnection_String => ResourceManager.GetString("CloseConnection_String", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 数据库连接已经关闭了。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ConnectionClosed => ResourceManager.GetString("ConnectionClosed", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从CSV格式的数据文件中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string CSVConnectionDescription => ResourceManager.GetString("CSVConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 CSV数据文件(*.csv)|*.csv 的本地化字符串。
		                                                                    ///       </summary>
		internal static string CSVFilter => ResourceManager.GetString("CSVFilter", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 数据库结构 的本地化字符串。
		                                                                    ///       </summary>
		internal static string DataBaseSchema => ResourceManager.GetString("DataBaseSchema", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从Dbase III 格式的数据文件中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string DBaseConnectionDescription => ResourceManager.GetString("DBaseConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 DBF数据文件(*.dbf)|*.dbf 的本地化字符串。
		                                                                    ///       </summary>
		internal static string DBFFilter => ResourceManager.GetString("DBFFilter", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 目录 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Directory => ResourceManager.GetString("Directory", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从Windows系统的日志记录中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string EventLogConnectionDescription => ResourceManager.GetString("EventLogConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从Excel二进制文件中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ExcelBinaryConnectionDescription => ResourceManager.GetString("ExcelBinaryConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 文件 的本地化字符串。
		                                                                    ///       </summary>
		internal static string File => ResourceManager.GetString("File", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 未能找到文件“{0}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string FileNotFound_FileName => ResourceManager.GetString("FileNotFound_FileName", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从操作系统文件目录系统中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string FileSystemConnectionDescription => ResourceManager.GetString("FileSystemConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Yes,No|True,False|是,否|真,假|好,差|男,女|是,|,否 的本地化字符串。
		                                                                    ///       </summary>
		internal static string FormatSample_Boolean => ResourceManager.GetString("FormatSample_Boolean", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 00.00|大写中文|小写中文|#.00|c 的本地化字符串。
		                                                                    ///       </summary>
		internal static string FormatSample_Currency => ResourceManager.GetString("FormatSample_Currency", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 yyyy-MM-dd HH:mm:ss|yyyy-MM-dd|yyyy-MM-dd hh:mm:ss|HH:mm:ss|yyyy年MM月dd日|yyyy年MM月dd日 HH时mm分ss秒|d|D|f|F 的本地化字符串。
		                                                                    ///       </summary>
		internal static string FormatSample_DateTime => ResourceManager.GetString("FormatSample_DateTime", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 共显示{0}行{1}列数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string GridDataInfo_Rows_Cols => ResourceManager.GetString("GridDataInfo_Rows_Cols", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 从文件“{0}”加载数据集XML文档时发生错误“{1}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string LoadDataSetXMLError_File_Message => ResourceManager.GetString("LoadDataSetXMLError_File_Message", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 正在加载... 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Loading => ResourceManager.GetString("Loading", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 类型“{0}”缺少成员“{1}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string MissMember_Type_Member => ResourceManager.GetString("MissMember_Type_Member", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从 MySQL 数据库中访问数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string MySQLConnectionDescription => ResourceManager.GetString("MySQLConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 没有当前记录 的本地化字符串。
		                                                                    ///       </summary>
		internal static string NoCurrentRecord => ResourceManager.GetString("NoCurrentRecord", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 没有数据 的本地化字符串。
		                                                                    ///       </summary>
		internal static string NoData => ResourceManager.GetString("NoData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 没有任何数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string NoneData => ResourceManager.GetString("NoneData", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 未指定文件名。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string NotSpecifyFileName => ResourceManager.GetString("NotSpecifyFileName", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 打开数据库连接“{0}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string OpenConnection_String => ResourceManager.GetString("OpenConnection_String", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 从文件“{1}”读取了{0}数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ReadBytes_Bytes_Name => ResourceManager.GetString("ReadBytes_Bytes_Name", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 使用“{0}”编码格式从文件“{1}”中读取{2}个字符。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ReadChars_Encoding_Name_Length => ResourceManager.GetString("ReadChars_Encoding_Name_Length", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 数据读取器已经关闭了 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ReaderClosed => ResourceManager.GetString("ReaderClosed", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 数据读取完毕。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ReaderEOF => ResourceManager.GetString("ReaderEOF", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 未能从对象“{0}”获得任何数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string ReturnNothing_MemberName => ResourceManager.GetString("ReturnNothing_MemberName", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似   中文ABC   的本地化字符串。
		                                                                    ///       </summary>
		internal static string SampleText => ResourceManager.GetString("SampleText", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 保存数据集XML文件到“{0}”时发生错误“{1}”。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string SaveDataSetXMLError_File_Message => ResourceManager.GetString("SaveDataSetXMLError_File_Message", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 系统消息 的本地化字符串。
		                                                                    ///       </summary>
		internal static string SystemMessage => ResourceManager.GetString("SystemMessage", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 共计{0}行，{1}列。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Total_Rows_Cols => ResourceManager.GetString("Total_Rows_Cols", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 [共{0}张表，{1}个字段] 的本地化字符串。
		                                                                    ///       </summary>
		internal static string Total_Tables_Fields => ResourceManager.GetString("Total_Tables_Fields", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从WMI(Windows系统管理)中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string WMIConnectionDescription => ResourceManager.GetString("WMIConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 Excel数据文件(*.xls)|*.xls 的本地化字符串。
		                                                                    ///       </summary>
		internal static string XLSFilter => ResourceManager.GetString("XLSFilter", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 能从XML文件中获得数据。 的本地化字符串。
		                                                                    ///       </summary>
		internal static string XMLConnectionDescription => ResourceManager.GetString("XMLConnectionDescription", cultureInfo_0);

		                                                                    /// <summary>
		                                                                    ///         查找类似 XML文件(*.xml)|*.xml 的本地化字符串。
		                                                                    ///       </summary>
		internal static string XMLFilter => ResourceManager.GetString("XMLFilter", cultureInfo_0);

		internal DataStrings()
		{
		}
	}
}
