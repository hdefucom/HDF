using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Design;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Services.Protocols;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法执行器 
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCSQLMethodEngine
	{
		private class Class28 : IComparer<Type>
		{
			public int Compare(Type type_0, Type type_1)
			{
				return string.Compare(type_0.Name, type_1.Name);
			}
		}

		private class Class29
		{
			public string string_0 = null;

			public int int_0 = -1;

			public string string_1 = null;

			public PropertyInfo propertyInfo_0 = null;

			public string string_2 = null;
		}

		private class Class30 : List<Class29>
		{
		}

		private static DCSQLMethodEngine dcsqlmethodEngine_0 = null;

		private ParameterStyle parameterStyle_0 = ParameterStyle.Default;

		private int int_0 = 0;

		private IDBConnectionProvider idbconnectionProvider_0 = null;

		private Dictionary<string, string> dictionary_0 = null;

		private static List<DCSQLMethodInfo> list_0 = new List<DCSQLMethodInfo>();

		private bool bool_0 = false;

		private string string_0 = "";

		private bool bool_1 = true;

		private static Dictionary<string, SoapHttpClientProtocol> dictionary_1 = new Dictionary<string, SoapHttpClientProtocol>();

		/// <summary>
		///       获得对象唯一静态实例
		///       </summary>
		public static DCSQLMethodEngine Instance
		{
			get
			{
				if (dcsqlmethodEngine_0 == null)
				{
					dcsqlmethodEngine_0 = new DCSQLMethodEngine();
				}
				return dcsqlmethodEngine_0;
			}
		}

		/// <summary>
		///       所有的服务端类型
		///       </summary>
		public static Type[] AllServiceTypes
		{
			get
			{
				List<Type> list = new List<Type>();
				foreach (DCSQLMethodInfo item in list_0)
				{
					if (!list.Contains(item.NativeMethod.DeclaringType))
					{
						list.Add(item.NativeMethod.DeclaringType);
					}
				}
				list.Sort(new Class28());
				return list.ToArray();
			}
		}

		/// <summary>
		///       命令参数样式
		///       </summary>
		public ParameterStyle CommandParameterStyle
		{
			get
			{
				return parameterStyle_0;
			}
			set
			{
				parameterStyle_0 = value;
			}
		}

		/// <summary>
		///       项目编号
		///       </summary>
		public int ProjectID
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       数据库连接对象提供者
		///       </summary>
		public IDBConnectionProvider ConnectionProvider
		{
			get
			{
				return idbconnectionProvider_0;
			}
			set
			{
				idbconnectionProvider_0 = value;
			}
		}

		/// <summary>
		///       自定义的SQL语句
		///       </summary>
		public Dictionary<string, string> CustomSQLCommandTexts
		{
			get
			{
				if (dictionary_0 == null)
				{
					dictionary_0 = new Dictionary<string, string>();
				}
				return dictionary_0;
			}
			set
			{
				dictionary_0 = value;
			}
		}

		/// <summary>
		///       是否启用转向WEB服务
		///       </summary>
		public bool EnableWarpperWebService
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       WEB服务地址格式化字符串
		///       </summary>
		public string WebServiceURLFormaString
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       在重定向到WEB服务时自动修正多行文本
		///       </summary>
		public bool AutoFixMultiLineTextWhenWarpperToWebService
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		public static void smethod_0()
		{
			new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					DCSQLMethodServiceAttribute dCSQLMethodServiceAttribute = (DCSQLMethodServiceAttribute)Attribute.GetCustomAttribute(type, typeof(DCSQLMethodServiceAttribute), inherit: false);
					if (dCSQLMethodServiceAttribute != null)
					{
						smethod_4(type);
					}
				}
			}
		}

		public static void smethod_1(Assembly assembly_0)
		{
			new List<Type>();
			Type[] types = assembly_0.GetTypes();
			foreach (Type type in types)
			{
				DCSQLMethodServiceAttribute dCSQLMethodServiceAttribute = (DCSQLMethodServiceAttribute)Attribute.GetCustomAttribute(type, typeof(DCSQLMethodServiceAttribute), inherit: false);
				if (dCSQLMethodServiceAttribute != null)
				{
					smethod_4(type);
				}
			}
		}

		/// <summary>
		///       静态的执行SQL方法
		///       </summary>
		/// <param name="parameterValues">参数数组</param>
		/// <returns>查询返回值</returns>
		public static object StaticInvokeSQLMethod(object[] parameterValues)
		{
			StackTrace stackTrace = new StackTrace();
			if (stackTrace.FrameCount < 2)
			{
				return null;
			}
			MethodInfo methodInfo_ = (MethodInfo)stackTrace.GetFrame(1).GetMethod();
			return Instance.method_0(methodInfo_, parameterValues);
		}

		/// <summary>
		///       静态的执行SQL方法
		///       </summary>
		/// <param name="cmd">命令对象</param>
		/// <param name="parameterValues">参数数组</param>
		/// <returns>执行结果</returns>
		public static object StaticInvokeSQLMethod(IDbCommand idbCommand_0, object[] parameterValues)
		{
			StackTrace stackTrace = new StackTrace();
			if (stackTrace.FrameCount < 2)
			{
				return null;
			}
			MethodInfo methodInfo_ = (MethodInfo)stackTrace.GetFrame(1).GetMethod();
			return Instance.method_1(methodInfo_, idbCommand_0, parameterValues);
		}

		/// <summary>
		///       执行SQL方法
		///       </summary>
		/// <param name="parameterValues">
		/// </param>
		/// <returns>
		/// </returns>
		public object InvokeSQLMethod(object[] parameterValues)
		{
			StackTrace stackTrace = new StackTrace();
			if (stackTrace.FrameCount < 2)
			{
				return null;
			}
			MethodInfo methodInfo_ = (MethodInfo)stackTrace.GetFrame(1).GetMethod();
			return method_0(methodInfo_, parameterValues);
		}

		private object method_0(MethodInfo methodInfo_0, object[] object_0)
		{
			int num = 13;
			if (EnableWarpperWebService)
			{
				DCSQLMethodInfo dCSQLMethodInfo = smethod_2(methodInfo_0);
				if (dCSQLMethodInfo == null)
				{
					throw new ArgumentException("未定义方法" + methodInfo_0.Name);
				}
				return method_3(dCSQLMethodInfo, object_0);
			}
			if (ConnectionProvider == null)
			{
				return null;
			}
			IDbConnection connection = ConnectionProvider.GetConnection();
			if (connection != null)
			{
				try
				{
					using (IDbCommand idbCommand_ = connection.CreateCommand())
					{
						return method_1(methodInfo_0, idbCommand_, object_0);
					}
				}
				finally
				{
					ConnectionProvider.ReleaseConnection(connection);
				}
			}
			return null;
		}

		private object method_1(MethodInfo methodInfo_0, IDbCommand idbCommand_0, object[] object_0)
		{
			int num = 19;
			if (methodInfo_0 == null)
			{
				throw new ArgumentNullException("nativeMethod");
			}
			if (idbCommand_0 == null)
			{
				throw new ArgumentNullException("cmd");
			}
			DCSQLMethodInfo dCSQLMethodInfo = smethod_2(methodInfo_0);
			if (dCSQLMethodInfo == null)
			{
				throw new Exception("不是SQL方法");
			}
			int num2 = (dCSQLMethodInfo.Parameters != null) ? dCSQLMethodInfo.Parameters.Length : 0;
			int num3 = (object_0 != null) ? object_0.Length : 0;
			if (num2 != num3)
			{
				throw new Exception("参数个数不匹配");
			}
			idbCommand_0.Parameters.Clear();
			string text = null;
			if (dCSQLMethodInfo.Fixed)
			{
				text = dCSQLMethodInfo.SQLText;
				if (dCSQLMethodInfo.CommandTexts.ContainsKey(ProjectID))
				{
					text = dCSQLMethodInfo.CommandTexts[ProjectID];
				}
			}
			else
			{
				if (CustomSQLCommandTexts.ContainsKey(dCSQLMethodInfo.Name))
				{
					text = CustomSQLCommandTexts[dCSQLMethodInfo.Name];
				}
				if (string.IsNullOrEmpty(text))
				{
					text = dCSQLMethodInfo.SQLText;
					if (dCSQLMethodInfo.CommandTexts.ContainsKey(ProjectID))
					{
						text = dCSQLMethodInfo.CommandTexts[ProjectID];
					}
				}
			}
			if (object_0 != null && object_0.Length > 0 && object_0[0] is IDCCustomRecordForSQLMethod)
			{
				IDCCustomRecordForSQLMethod iDCCustomRecordForSQLMethod = (IDCCustomRecordForSQLMethod)object_0[0];
				string sQLCommandText = iDCCustomRecordForSQLMethod.GetSQLCommandText(dCSQLMethodInfo.Name);
				if (!string.IsNullOrEmpty(sQLCommandText))
				{
					text = sQLCommandText;
				}
			}
			if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.ExecuteNonQueryBatch)
			{
				IEnumerable enumerable = (IEnumerable)object_0[0];
				int num4 = 0;
				if (idbCommand_0.Connection == null)
				{
					throw new Exception("未指定数据库连接对象");
				}
				if (idbCommand_0.Connection.State != ConnectionState.Open)
				{
					idbCommand_0.Connection.Open();
				}
				foreach (object item in enumerable)
				{
					method_2(idbCommand_0, dCSQLMethodInfo, text, new object[1]
					{
						item
					}, null);
					num4 += idbCommand_0.ExecuteNonQuery();
				}
				if (dCSQLMethodInfo.ReturnType.Equals(typeof(bool)))
				{
					return num4 > 0;
				}
				return Convert.ChangeType(num4, dCSQLMethodInfo.ReturnType);
			}
			Class30 @class = new Class30();
			method_2(idbCommand_0, dCSQLMethodInfo, text, object_0, @class);
			if (idbCommand_0.Connection == null)
			{
				throw new Exception("未指定数据库连接对象");
			}
			if (idbCommand_0.Connection.State != ConnectionState.Open)
			{
				idbCommand_0.Connection.Open();
			}
			switch (dCSQLMethodInfo.RuntimeMethodType)
			{
			case DCSQLMethodType.ReadAllValues:
			{
				IDataReader dataReader = idbCommand_0.ExecuteReader();
				ArrayList arrayList2 = new ArrayList();
				int fieldCount = dataReader.FieldCount;
				while (dataReader.Read())
				{
					for (int k = 0; k < fieldCount; k++)
					{
						if (dataReader.IsDBNull(k))
						{
							arrayList2.Add(null);
						}
						else
						{
							arrayList2.Add(dataReader.GetValue(k));
						}
					}
				}
				dataReader.Close();
				Type elementType = dCSQLMethodInfo.ReturnType.GetElementType();
				if (!elementType.Equals(typeof(object)))
				{
					object defaultValue = ValueTypeHelper.GetDefaultValue(elementType);
					for (int k = 0; k < arrayList2.Count; k++)
					{
						object value = arrayList2[k];
						if (value == null || DBNull.Value.Equals(value))
						{
							arrayList2[k] = defaultValue;
						}
						else
						{
							arrayList2[k] = Convert.ChangeType(value, elementType);
						}
					}
					return arrayList2.ToArray(elementType);
				}
				return arrayList2.ToArray();
			}
			case DCSQLMethodType.ExecuteNonQuery:
			{
				int num6 = idbCommand_0.ExecuteNonQuery();
				if (dCSQLMethodInfo.ReturnType.Equals(typeof(bool)))
				{
					return num6 > 0;
				}
				return ValueTypeHelper.ConvertTo(num6, dCSQLMethodInfo.ReturnType);
			}
			default:
				throw new Exception("错误的方法类型" + dCSQLMethodInfo.MethodType);
			case DCSQLMethodType.ExecuteScalar:
			{
				object obj3 = idbCommand_0.ExecuteScalar();
				if (DBNull.Value.Equals(obj3))
				{
					return ValueTypeHelper.GetDefaultValue(dCSQLMethodInfo.ReturnType);
				}
				return ValueTypeHelper.ConvertTo(obj3, dCSQLMethodInfo.ReturnType);
			}
			case DCSQLMethodType.ReadDataTable:
			{
				IDataReader dataReader = idbCommand_0.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(dataReader);
				dataReader.Close();
				return dataTable;
			}
			case DCSQLMethodType.ReadSingInstance:
			case DCSQLMethodType.ReadInstanceArray:
			{
				Type type = dCSQLMethodInfo.ReturnType;
				if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.ReadInstanceArray)
				{
					type = ((!type.IsArray) ? DesignUtils.GetCollectionItemType(dCSQLMethodInfo.ReturnType, checkAddMethod: true) : type.GetElementType());
				}
				if (type.Equals(typeof(void)))
				{
					throw new Exception("方法返回值是void型");
				}
				if (dCSQLMethodInfo.ReturnProperties != null && dCSQLMethodInfo.ReturnProperties.Length > 0)
				{
					DCSQLMethodReturnPropertyInfo[] returnProperties = dCSQLMethodInfo.ReturnProperties;
					foreach (DCSQLMethodReturnPropertyInfo dCSQLMethodReturnPropertyInfo in returnProperties)
					{
						bool flag = false;
						foreach (Class29 item2 in @class)
						{
							if (string.Compare(item2.string_1, dCSQLMethodReturnPropertyInfo.Name, ignoreCase: true) == 0)
							{
								item2.string_0 = dCSQLMethodReturnPropertyInfo.Name;
								if (string.IsNullOrEmpty(item2.string_2))
								{
									item2.string_2 = dCSQLMethodReturnPropertyInfo.ParseFormat;
									item2.int_0 = dCSQLMethodReturnPropertyInfo.FieldIndex;
									if (string.IsNullOrEmpty(item2.string_0))
									{
										item2.string_0 = dCSQLMethodReturnPropertyInfo.FieldName;
									}
								}
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							Class29 current2 = new Class29();
							current2.string_0 = dCSQLMethodReturnPropertyInfo.FieldName;
							current2.int_0 = dCSQLMethodReturnPropertyInfo.FieldIndex;
							current2.string_2 = dCSQLMethodReturnPropertyInfo.ParseFormat;
							@class.Add(current2);
						}
					}
				}
				if (!typeof(IDCCustomRecordForSQLMethod).IsAssignableFrom(type))
				{
					foreach (Class29 item3 in @class)
					{
						item3.propertyInfo_0 = type.GetProperty(item3.string_1, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
						if (item3.propertyInfo_0 == null)
						{
							throw new Exception(string.Format(WriterStrings.PromptNotFoundProperty_Type_Name, type.FullName, item3.string_1));
						}
					}
				}
				IDataReader dataReader = null;
				dataReader = ((dCSQLMethodInfo.RuntimeMethodType != DCSQLMethodType.ReadSingInstance) ? idbCommand_0.ExecuteReader() : idbCommand_0.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow));
				int fieldCount = dataReader.FieldCount;
				for (int j = 0; j < fieldCount; j++)
				{
					string name = dataReader.GetName(j);
					bool flag = false;
					foreach (Class29 item4 in @class)
					{
						if (item4.int_0 == j)
						{
							flag = true;
							break;
						}
						if (item4.int_0 < 0)
						{
							if (!string.IsNullOrEmpty(item4.string_0))
							{
								if (SQLHelper.MatchFieldName(name, item4.string_0))
								{
									item4.int_0 = j;
									flag = true;
									break;
								}
							}
							else if (SQLHelper.MatchFieldName(name, item4.string_1))
							{
								item4.int_0 = j;
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						continue;
					}
					if (typeof(IDCCustomRecordForSQLMethod).IsAssignableFrom(type))
					{
						Class29 current2 = new Class29();
						current2.int_0 = j;
						current2.string_0 = name;
						current2.string_1 = name;
						@class.Add(current2);
						continue;
					}
					PropertyInfo property = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (property != null)
					{
						Class29 current2 = new Class29();
						current2.int_0 = j;
						current2.string_0 = name;
						current2.string_1 = property.Name;
						current2.propertyInfo_0 = property;
						@class.Add(current2);
					}
				}
				ArrayList arrayList = new ArrayList();
				int num5 = 0;
				if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.ReadSingInstance)
				{
					num5 = 1;
				}
				while (dataReader.Read())
				{
					object current = Activator.CreateInstance(type);
					foreach (Class29 item5 in @class)
					{
						if (item5.int_0 >= 0 && item5.propertyInfo_0 != null && !dataReader.IsDBNull(item5.int_0))
						{
							object value = dataReader.GetValue(item5.int_0);
							if (current is IDCCustomRecordForSQLMethod)
							{
								IDCCustomRecordForSQLMethod iDCCustomRecordForSQLMethod = (IDCCustomRecordForSQLMethod)current;
								iDCCustomRecordForSQLMethod.SetPropertyValue(item5.string_1, value);
							}
							else
							{
								Type propertyType = item5.propertyInfo_0.PropertyType;
								object obj = null;
								if (!string.IsNullOrEmpty(item5.string_2))
								{
									if (propertyType.Equals(typeof(DateTime)))
									{
										DateTime result = DateTime.MinValue;
										obj = ((!DateTime.TryParseExact(Convert.ToString(value), item5.string_2, null, DateTimeStyles.AllowWhiteSpaces, out result)) ? ((object)DateTime.MinValue) : ((object)result));
									}
									else
									{
										obj = ValueTypeHelper.ConvertTo(value, propertyType);
									}
								}
								else
								{
									obj = ValueTypeHelper.ConvertTo(value, propertyType);
								}
								item5.propertyInfo_0.SetValue(current, obj, null);
							}
						}
					}
					arrayList.Add(current);
					if (num5 > 0 && arrayList.Count >= num5)
					{
						break;
					}
				}
				dataReader.Close();
				if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.ReadSingInstance)
				{
					if (arrayList.Count > 0)
					{
						return arrayList[0];
					}
					return null;
				}
				if (dCSQLMethodInfo.ReturnType.IsArray)
				{
					return arrayList.ToArray(type);
				}
				object obj2 = Activator.CreateInstance(dCSQLMethodInfo.ReturnType);
				IList list = (IList)obj2;
				foreach (object item6 in arrayList)
				{
					list.Add(item6);
				}
				return obj2;
			}
			}
		}

		private void method_2(IDbCommand idbCommand_0, DCSQLMethodInfo dcsqlmethodInfo_0, string string_1, object[] object_0, Class30 class30_0)
		{
			int num = 6;
			idbCommand_0.Parameters.Clear();
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = VariableString.AnalyseVariableString(string_1, "[%", "%]");
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				string text = array[i];
				text = text.Trim();
				if (text.StartsWith("="))
				{
					if (class30_0 != null)
					{
						Class29 @class = new Class29();
						text = text.Substring(1);
						int num2 = text.IndexOf(":");
						if (num2 > 0)
						{
							@class.string_1 = text.Substring(0, num2).Trim();
							@class.string_2 = text.Substring(num2 + 1).Trim();
						}
						else
						{
							@class.string_1 = text;
						}
						string text2 = array[i - 1].Trim();
						num2 = text2.LastIndexOfAny(new char[5]
						{
							' ',
							'\t',
							'\r',
							'\n',
							','
						});
						if (num2 >= 0)
						{
							@class.string_0 = text2.Substring(num2 + 1).Trim();
							class30_0.Add(@class);
						}
					}
					continue;
				}
				string text3 = null;
				string text4 = null;
				int num3 = text.IndexOf(':');
				if (num3 > 0)
				{
					text4 = text.Substring(num3 + 1);
					text = text.Substring(0, num3);
				}
				num3 = text.IndexOf('.');
				if (num3 > 0)
				{
					text3 = text.Substring(num3 + 1).Trim();
					text = text.Substring(0, num3).Trim();
				}
				int parameterIndexByFieldName = dcsqlmethodInfo_0.GetParameterIndexByFieldName(text);
				if (parameterIndexByFieldName >= 0)
				{
					DCSQLMethodParameterInfo dCSQLMethodParameterInfo = dcsqlmethodInfo_0.Parameters[parameterIndexByFieldName];
					if (!string.IsNullOrEmpty(text3))
					{
						bool flag = false;
						if (dCSQLMethodParameterInfo.SubInfos != null)
						{
							foreach (DCSQLMethodParameterInfo subInfo in dCSQLMethodParameterInfo.SubInfos)
							{
								if (string.Compare(subInfo.PropertyName, text3, ignoreCase: true) == 0)
								{
									dCSQLMethodParameterInfo = subInfo;
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							DCSQLMethodParameterInfo dCSQLMethodParameterInfo2 = new DCSQLMethodParameterInfo();
							dCSQLMethodParameterInfo2.PropertyName = text3;
							if (dCSQLMethodParameterInfo.SubInfos == null)
							{
								dCSQLMethodParameterInfo.SubInfos = new List<DCSQLMethodParameterInfo>();
							}
							dCSQLMethodParameterInfo.SubInfos.Add(dCSQLMethodParameterInfo2);
							dCSQLMethodParameterInfo = dCSQLMethodParameterInfo2;
						}
					}
					object obj = object_0[parameterIndexByFieldName];
					if (!string.IsNullOrEmpty(text3))
					{
						obj = ((!(obj is IDCCustomRecordForSQLMethod)) ? ValueTypeHelper.GetPropertyValue(obj, text3, throwException: true) : ((IDCCustomRecordForSQLMethod)obj).GetPropertyValue(text3));
					}
					text = "P_" + text;
					if (!string.IsNullOrEmpty(text3))
					{
						text = text + "_" + text3;
					}
					text = text.Replace('.', '_');
					text = text.ToUpper();
					object value = obj;
					DbType dbType = DbType.Object;
					Type type;
					if (obj == null)
					{
						value = DBNull.Value;
					}
					else
					{
						if (string.IsNullOrEmpty(text4))
						{
							text4 = dCSQLMethodParameterInfo.DisplayFormat;
						}
						if (!string.IsNullOrEmpty(text4))
						{
							if (Enum.IsDefined(typeof(DCSQLMethodParameterType), text4))
							{
								dCSQLMethodParameterInfo.ValueType = (DCSQLMethodParameterType)Enum.Parse(typeof(DCSQLMethodParameterType), text4);
							}
							else if (obj is IFormattable)
							{
								value = ((IFormattable)obj).ToString(text4, null);
							}
						}
						else if (dCSQLMethodParameterInfo.ValueType == DCSQLMethodParameterType.Default)
						{
							if (obj != null)
							{
								type = obj.GetType();
								if (type.IsEnum)
								{
									value = Convert.ToInt32(obj);
									dbType = DbType.Int32;
								}
								else if (type.Equals(typeof(string)))
								{
									dbType = DbType.String;
								}
							}
						}
						else
						{
							switch (dCSQLMethodParameterInfo.ValueType)
							{
							case DCSQLMethodParameterType.Boolean:
								value = Convert.ToBoolean(obj);
								dbType = DbType.Boolean;
								break;
							case DCSQLMethodParameterType.Date:
								value = Convert.ToDateTime(obj);
								dbType = DbType.DateTime;
								break;
							case DCSQLMethodParameterType.Integer:
								value = Convert.ToInt32(obj);
								dbType = DbType.Int32;
								break;
							case DCSQLMethodParameterType.Single:
								value = Convert.ToSingle(obj);
								dbType = DbType.Single;
								break;
							case DCSQLMethodParameterType.Double:
								value = Convert.ToDouble(obj);
								dbType = DbType.Double;
								break;
							case DCSQLMethodParameterType.LongInteger:
								value = Convert.ToInt64(obj);
								dbType = DbType.Int64;
								break;
							case DCSQLMethodParameterType.String:
								value = Convert.ToString(obj);
								dbType = DbType.String;
								break;
							case DCSQLMethodParameterType.LongString:
								value = Convert.ToString(obj);
								dbType = DbType.String;
								break;
							}
						}
					}
					ParameterStyle parameterStyle = CommandParameterStyle;
					if (parameterStyle == ParameterStyle.Default)
					{
						parameterStyle = GClass317.smethod_2(idbCommand_0.Connection);
					}
					if (dCSQLMethodParameterInfo.MacroMode)
					{
						parameterStyle = ParameterStyle.Macro;
						ParameterStyle parameterStyle2 = ParameterStyle.Macro;
					}
					else
					{
						switch (parameterStyle)
						{
						case ParameterStyle.Macro:
							break;
						case ParameterStyle.Anonymous:
						{
							stringBuilder.Append(" ? ");
							IDataParameter dataParameter2 = idbCommand_0.CreateParameter();
							idbCommand_0.Parameters.Add(dataParameter2);
							dataParameter2.Value = value;
							if (dbType != DbType.Object)
							{
								dataParameter2.DbType = dbType;
							}
							idbCommand_0.Parameters.Add(dataParameter2);
							continue;
						}
						case ParameterStyle.Default:
						case ParameterStyle.SQLServerStyle:
						{
							stringBuilder.Append("@" + text);
							IDataParameter dataParameter = idbCommand_0.CreateParameter();
							dataParameter.ParameterName = text;
							dataParameter.Value = value;
							if (dbType != DbType.Object)
							{
								dataParameter.DbType = dbType;
							}
							idbCommand_0.Parameters.Add(dataParameter);
							continue;
						}
						case ParameterStyle.OracleStyle:
						{
							stringBuilder.Append(":" + text.ToUpper());
							IDataParameter dataParameter = idbCommand_0.CreateParameter();
							dataParameter.ParameterName = text.ToUpper();
							dataParameter.Value = value;
							if (dbType != DbType.Object)
							{
								dataParameter.DbType = dbType;
								if (dbType == DbType.String && dataParameter is OracleParameter)
								{
									OracleParameter oracleParameter = (OracleParameter)dataParameter;
									oracleParameter.OracleType = OracleType.NVarChar;
								}
							}
							if (dCSQLMethodParameterInfo.ValueType == DCSQLMethodParameterType.LongString && dataParameter is OracleParameter)
							{
								OracleParameter oracleParameter = (OracleParameter)dataParameter;
								oracleParameter.OracleType = OracleType.NClob;
							}
							idbCommand_0.Parameters.Add(dataParameter);
							continue;
						}
						default:
							continue;
						}
					}
					type = dcsqlmethodInfo_0.Parameters[parameterIndexByFieldName].ParameterType;
					stringBuilder.Append(Convert.ToString(value));
					continue;
				}
				throw new Exception("没找到参数" + text);
			}
			idbCommand_0.CommandText = stringBuilder.ToString();
		}

		internal static DCSQLMethodInfo smethod_2(MethodInfo methodInfo_0)
		{
			foreach (DCSQLMethodInfo item in list_0)
			{
				if (item.NativeMethod == methodInfo_0)
				{
					if (item.Invalidate)
					{
						return null;
					}
					return item;
				}
			}
			smethod_4(methodInfo_0.DeclaringType);
			foreach (DCSQLMethodInfo item2 in list_0)
			{
				if (item2.NativeMethod == methodInfo_0)
				{
					if (item2.Invalidate)
					{
						return null;
					}
					return item2;
				}
			}
			return null;
		}

		internal static DCSQLMethodInfo smethod_3(MethodInfo methodInfo_0)
		{
			int num = 12;
			DCSQLMethodInfo dCSQLMethodInfo = new DCSQLMethodInfo();
			dCSQLMethodInfo.NativeMethod = methodInfo_0;
			DCSQLMethodAttribute dCSQLMethodAttribute = (DCSQLMethodAttribute)Attribute.GetCustomAttribute(methodInfo_0, typeof(DCSQLMethodAttribute), inherit: true);
			if (dCSQLMethodAttribute == null)
			{
				dCSQLMethodInfo.Invalidate = true;
				throw new Exception("方法" + methodInfo_0.Name + "不是SQL方法");
			}
			dCSQLMethodInfo.Name = methodInfo_0.DeclaringType.Name + "." + methodInfo_0.Name;
			if (string.IsNullOrEmpty(dCSQLMethodInfo.Name))
			{
				dCSQLMethodInfo.Name = methodInfo_0.Name;
			}
			dCSQLMethodInfo.SQLText = dCSQLMethodAttribute.SQLText;
			dCSQLMethodInfo.MethodType = dCSQLMethodAttribute.MethodType;
			dCSQLMethodInfo.RuntimeMethodType = dCSQLMethodAttribute.MethodType;
			dCSQLMethodInfo.Fixed = dCSQLMethodAttribute.Fixed;
			DCSQLMethodServiceAttribute dCSQLMethodServiceAttribute = (DCSQLMethodServiceAttribute)Attribute.GetCustomAttribute(methodInfo_0.DeclaringType, typeof(DCSQLMethodServiceAttribute), inherit: false);
			if (dCSQLMethodServiceAttribute != null)
			{
				dCSQLMethodInfo.ModuleName = dCSQLMethodServiceAttribute.Name;
				if (string.IsNullOrEmpty(dCSQLMethodInfo.ModuleName))
				{
					dCSQLMethodInfo.ModuleName = methodInfo_0.DeclaringType.Name;
				}
			}
			dCSQLMethodInfo.CommandTexts = new Dictionary<int, string>();
			DCSQLMethodCommandTextAttribute[] array = (DCSQLMethodCommandTextAttribute[])Attribute.GetCustomAttributes(methodInfo_0, typeof(DCSQLMethodCommandTextAttribute), inherit: true);
			if (array != null)
			{
				DCSQLMethodCommandTextAttribute[] array2 = array;
				foreach (DCSQLMethodCommandTextAttribute dCSQLMethodCommandTextAttribute in array2)
				{
					dCSQLMethodInfo.CommandTexts[dCSQLMethodCommandTextAttribute.ProjectID] = dCSQLMethodCommandTextAttribute.CommandText;
				}
			}
			if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.ReadAllValues)
			{
				bool flag = false;
				Type returnType = methodInfo_0.ReturnType;
				if (returnType.IsArray)
				{
					Type elementType = returnType.GetElementType();
					if (!smethod_5(elementType))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					throw new Exception("ReadAllValues类型的方法必须返回基础数据类型数组。");
				}
			}
			if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.AutoDetect)
			{
				Type returnType = methodInfo_0.ReturnType;
				if (returnType.Equals(typeof(object[])))
				{
					dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ReadAllValues;
				}
				if (returnType.IsArray)
				{
					Type elementType2 = returnType.GetElementType();
					if (smethod_5(elementType2))
					{
						dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ReadAllValues;
					}
					else
					{
						dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ReadInstanceArray;
					}
				}
				else if (returnType.Equals(typeof(DataTable)))
				{
					dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ReadDataTable;
				}
				else if (returnType.Equals(typeof(int)))
				{
					dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ExecuteNonQuery;
				}
				else if (returnType.IsClass && !returnType.Equals(typeof(string)))
				{
					Type collectionItemType = DesignUtils.GetCollectionItemType(returnType, checkAddMethod: true);
					if (collectionItemType != null && collectionItemType.IsClass && !collectionItemType.IsPrimitive)
					{
						dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ReadInstanceArray;
					}
					else
					{
						dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ReadSingInstance;
					}
				}
				else
				{
					dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ExecuteScalar;
					string sQLText = dCSQLMethodInfo.SQLText;
					if (!string.IsNullOrEmpty(sQLText))
					{
						sQLText = sQLText.Trim();
						if (sQLText.StartsWith("insert", StringComparison.CurrentCultureIgnoreCase) || sQLText.StartsWith("update", StringComparison.CurrentCultureIgnoreCase) || sQLText.StartsWith("delete", StringComparison.CurrentCultureIgnoreCase))
						{
							dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ExecuteNonQuery;
						}
						else if (sQLText.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
						{
							dCSQLMethodInfo.RuntimeMethodType = DCSQLMethodType.ExecuteScalar;
						}
					}
				}
			}
			DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo_0, typeof(DescriptionAttribute), inherit: true);
			if (descriptionAttribute != null)
			{
				dCSQLMethodInfo.Description = descriptionAttribute.Description;
			}
			ParameterInfo[] parameters = methodInfo_0.GetParameters();
			if (parameters != null)
			{
				List<DCSQLMethodParameterInfo> list = new List<DCSQLMethodParameterInfo>();
				ParameterInfo[] array3 = parameters;
				foreach (ParameterInfo parameterInfo in array3)
				{
					if (Attribute.GetCustomAttribute(parameterInfo, typeof(DCSQLMethodIgnoreAttriubte), inherit: false) != null)
					{
						continue;
					}
					DCSQLMethodParameterInfo dCSQLMethodParameterInfo = new DCSQLMethodParameterInfo();
					dCSQLMethodParameterInfo.Name = parameterInfo.Name;
					dCSQLMethodParameterInfo.ParameterType = parameterInfo.ParameterType;
					if (parameterInfo.ParameterType.Equals(typeof(string)))
					{
						dCSQLMethodParameterInfo.ValueType = DCSQLMethodParameterType.String;
					}
					DCSQLMethodParameterAttribute[] array4 = (DCSQLMethodParameterAttribute[])Attribute.GetCustomAttributes(parameterInfo, typeof(DCSQLMethodParameterAttribute), inherit: false);
					if (array4 != null && array4.Length > 0)
					{
						DCSQLMethodParameterAttribute[] array5 = array4;
						foreach (DCSQLMethodParameterAttribute dCSQLMethodParameterAttribute in array5)
						{
							if (string.IsNullOrEmpty(dCSQLMethodParameterAttribute.PropertyName))
							{
								dCSQLMethodParameterInfo.DisplayFormat = dCSQLMethodParameterAttribute.DispalyFormat;
								dCSQLMethodParameterInfo.MacroMode = dCSQLMethodParameterAttribute.MacroMode;
								if (dCSQLMethodParameterAttribute.ValueType != 0)
								{
									dCSQLMethodParameterInfo.ValueType = dCSQLMethodParameterAttribute.ValueType;
								}
								continue;
							}
							if (dCSQLMethodParameterInfo.SubInfos == null)
							{
								dCSQLMethodParameterInfo.SubInfos = new List<DCSQLMethodParameterInfo>();
							}
							DCSQLMethodParameterInfo dCSQLMethodParameterInfo2 = new DCSQLMethodParameterInfo();
							dCSQLMethodParameterInfo2.DisplayFormat = dCSQLMethodParameterAttribute.DispalyFormat;
							dCSQLMethodParameterInfo2.MacroMode = dCSQLMethodParameterAttribute.MacroMode;
							if (dCSQLMethodParameterAttribute.ValueType != 0)
							{
								dCSQLMethodParameterInfo2.ValueType = dCSQLMethodParameterAttribute.ValueType;
							}
							dCSQLMethodParameterInfo2.PropertyName = dCSQLMethodParameterAttribute.PropertyName;
							dCSQLMethodParameterInfo.SubInfos.Add(dCSQLMethodParameterInfo2);
						}
					}
					list.Add(dCSQLMethodParameterInfo);
				}
				dCSQLMethodInfo.Parameters = list.ToArray();
			}
			if (dCSQLMethodInfo.RuntimeMethodType == DCSQLMethodType.ExecuteNonQueryBatch && (dCSQLMethodInfo.Parameters == null || dCSQLMethodInfo.Parameters.Length != 1))
			{
				throw new ArgumentException("批量更新的方法必须有而且只能有一个参数");
			}
			list_0.Add(dCSQLMethodInfo);
			if (dCSQLMethodInfo.Invalidate)
			{
				return null;
			}
			return dCSQLMethodInfo;
		}

		public static DCSQLMethodInfo[] smethod_4(Type type_0)
		{
			int num = 1;
			if (type_0 == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			List<DCSQLMethodInfo> list = new List<DCSQLMethodInfo>();
			MethodInfo[] methods = type_0.GetMethods(BindingFlags.Instance | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (Attribute.GetCustomAttribute(methodInfo, typeof(DCSQLMethodAttribute), inherit: false) != null)
				{
					DCSQLMethodInfo dCSQLMethodInfo = smethod_3(methodInfo);
					if (dCSQLMethodInfo != null)
					{
						list.Add(dCSQLMethodInfo);
					}
				}
			}
			return list.ToArray();
		}

		private static bool smethod_5(Type type_0)
		{
			if (type_0.IsPrimitive)
			{
				return true;
			}
			return type_0.Equals(typeof(string)) || type_0.Equals(typeof(DateTime)) || type_0.Equals(typeof(decimal));
		}

		public static void smethod_6()
		{
			list_0.Clear();
		}

		public static void smethod_7(Type type_0)
		{
			int num = 10;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			smethod_4(type_0);
		}

		private object method_3(DCSQLMethodInfo dcsqlmethodInfo_0, object[] object_0)
		{
			int num = 18;
			if (!EnableWarpperWebService)
			{
				return ValueTypeHelper.GetDefaultValue(dcsqlmethodInfo_0.ReturnType);
			}
			if (string.IsNullOrEmpty(WebServiceURLFormaString))
			{
				throw new Exception("没有配置WEB服务地址URL信息");
			}
			SoapHttpClientProtocol soapHttpClientProtocol = method_4(dcsqlmethodInfo_0.ModuleName);
			if (soapHttpClientProtocol != null)
			{
				soapHttpClientProtocol.Url = string.Format(WebServiceURLFormaString, dcsqlmethodInfo_0.ModuleName);
				MethodInfo method = soapHttpClientProtocol.GetType().GetMethod(dcsqlmethodInfo_0.NativeMethod.Name);
				if (method != null)
				{
					try
					{
						object obj = method.Invoke(soapHttpClientProtocol, object_0);
						if (AutoFixMultiLineTextWhenWarpperToWebService && obj != null && dcsqlmethodInfo_0.ReturnType.Equals(typeof(string)))
						{
							string text = Convert.ToString(obj);
							return StringFormatHelper.FixMultiLineTextForCr(text);
						}
						return obj;
					}
					catch (Exception ex)
					{
						if (ex.InnerException != null)
						{
							throw ex.InnerException;
						}
						throw ex;
					}
				}
			}
			return ValueTypeHelper.GetDefaultValue(dcsqlmethodInfo_0.ReturnType);
		}

		public SoapHttpClientProtocol method_4(string string_1)
		{
			SoapHttpClientProtocol soapHttpClientProtocol = GClass31.smethod_2(string_1);
			if (soapHttpClientProtocol == null)
			{
				foreach (DCSQLMethodInfo item in list_0)
				{
					if (!GClass31.smethod_1(item.ModuleName))
					{
						GClass32 gClass = new GClass32();
						gClass.Name = item.ModuleName;
						foreach (DCSQLMethodInfo item2 in list_0)
						{
							if (!(item2.ModuleName != gClass.Name))
							{
								GClass33 gClass2 = new GClass33();
								gClass2.Name = item2.NativeMethod.Name;
								gClass2.method_2().method_1(item2.ReturnType);
								if (item2.Parameters != null)
								{
									DCSQLMethodParameterInfo[] parameters = item2.Parameters;
									foreach (DCSQLMethodParameterInfo dCSQLMethodParameterInfo in parameters)
									{
										GClass34 gClass3 = new GClass34();
										gClass3.Name = dCSQLMethodParameterInfo.Name;
										gClass3.method_1(dCSQLMethodParameterInfo.ParameterType);
										gClass2.method_0().Add(gClass3);
									}
								}
								gClass.method_0().Add(gClass2);
							}
						}
						GClass31.smethod_0(gClass);
					}
				}
				soapHttpClientProtocol = GClass31.smethod_2(string_1);
			}
			return soapHttpClientProtocol;
		}

		public static void smethod_8(string string_1, SoapHttpClientProtocol soapHttpClientProtocol_0)
		{
			dictionary_1[string_1] = soapHttpClientProtocol_0;
		}
	}
}
