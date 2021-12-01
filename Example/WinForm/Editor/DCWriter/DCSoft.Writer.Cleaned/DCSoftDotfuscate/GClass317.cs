using DCSoft.Data;
using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass317
	{
		public static DCDataBaseServerType smethod_0(IDbConnection idbConnection_0)
		{
			if (idbConnection_0 == null)
			{
				return DCDataBaseServerType.Invalidate;
			}
			if (smethod_5(idbConnection_0))
			{
				return DCDataBaseServerType.MSSQLServer;
			}
			if (smethod_6(idbConnection_0))
			{
				return DCDataBaseServerType.Oracle;
			}
			if (smethod_7(idbConnection_0))
			{
				return DCDataBaseServerType.Access;
			}
			if (smethod_8(idbConnection_0))
			{
				return DCDataBaseServerType.DB2;
			}
			if (smethod_9(idbConnection_0))
			{
				return DCDataBaseServerType.MySQL;
			}
			return DCDataBaseServerType.Invalidate;
		}

		public static ParameterStyle smethod_1(DCDataBaseServerType dcdataBaseServerType_0)
		{
			switch (dcdataBaseServerType_0)
			{
			default:
				return ParameterStyle.Anonymous;
			case DCDataBaseServerType.Access:
				return ParameterStyle.SQLServerStyle;
			case DCDataBaseServerType.MSSQLServer:
				return ParameterStyle.SQLServerStyle;
			case DCDataBaseServerType.Oracle:
				return ParameterStyle.OracleStyle;
			case DCDataBaseServerType.DB2:
				return ParameterStyle.OracleStyle;
			case DCDataBaseServerType.MySQL:
				return ParameterStyle.MySQL;
			}
		}

		public static ParameterStyle smethod_2(IDbConnection idbConnection_0)
		{
			return smethod_1(smethod_0(idbConnection_0));
		}

		public static OleDbConnection smethod_3(string string_0, string string_1, bool bool_0)
		{
			int num = 1;
			if (!File.Exists(string_0))
			{
				if (bool_0)
				{
					throw new FileNotFoundException("Can not find mdb file", string_0);
				}
				return null;
			}
			string text = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + string_0;
			if (string_1 != null && string_1.Trim().Length > 0)
			{
				text = text + ";Jet OLEDB:Database password=" + string_1;
			}
			OleDbConnection oleDbConnection = new OleDbConnection(text);
			oleDbConnection.Open();
			return oleDbConnection;
		}

		public static string smethod_4(string string_0)
		{
			int num = 6;
			if (string_0 == null)
			{
				return null;
			}
			string_0 = string_0.Replace(" ", "");
			int num2 = string_0.IndexOf("Provider=", StringComparison.InvariantCultureIgnoreCase);
			if (num2 > 0)
			{
				num2 += 9;
				int num3 = string_0.IndexOf(";", num2);
				if (num3 < 0)
				{
					return string_0.Substring(num2);
				}
				return string_0.Substring(num2, num3 - num2);
			}
			return null;
		}

		public static bool smethod_5(IDbConnection idbConnection_0)
		{
			int num = 9;
			if (idbConnection_0 != null)
			{
				if (idbConnection_0 is SqlConnection)
				{
					return true;
				}
				if (idbConnection_0 is OleDbConnection)
				{
					string provider = (idbConnection_0 as OleDbConnection).Provider;
					return provider.StartsWith("SQLOLEDB");
				}
				if (idbConnection_0 is OdbcConnection)
				{
					return (idbConnection_0 as OdbcConnection).Driver.ToUpper().Equals("SQLSRV32.DLL");
				}
			}
			return false;
		}

		public static bool smethod_6(IDbConnection idbConnection_0)
		{
			int num = 1;
			if (idbConnection_0 != null)
			{
				if (idbConnection_0.GetType().FullName == "System.Data.OracleClient.OracleConnection")
				{
					return true;
				}
				if (idbConnection_0 is OleDbConnection)
				{
					string provider = (idbConnection_0 as OleDbConnection).Provider;
					return provider.StartsWith("OraOLEDB.Oracle", StringComparison.CurrentCultureIgnoreCase) || provider.StartsWith("MSDAORA", StringComparison.CurrentCultureIgnoreCase);
				}
				if (idbConnection_0 is OdbcConnection)
				{
					return (idbConnection_0 as OdbcConnection).Driver.StartsWith("SQORA32", StringComparison.CurrentCultureIgnoreCase);
				}
			}
			return false;
		}

		public static bool smethod_7(IDbConnection idbConnection_0)
		{
			int num = 9;
			if (idbConnection_0 != null)
			{
				if (idbConnection_0 is OleDbConnection)
				{
					return (idbConnection_0 as OleDbConnection).Provider.ToUpper().Equals("MICROSOFT.JET.OLEDB.4.0");
				}
				if (idbConnection_0 is OdbcConnection)
				{
					return (idbConnection_0 as OdbcConnection).Driver.ToUpper().Equals("ODBCJT32.DLL");
				}
			}
			return false;
		}

		public static bool smethod_8(IDbConnection idbConnection_0)
		{
			int num = 17;
			if (idbConnection_0 == null)
			{
				return false;
			}
			if (idbConnection_0.GetType().Name == "DB2Connection")
			{
				return true;
			}
			if (idbConnection_0 is OleDbConnection)
			{
				string provider = ((OleDbConnection)idbConnection_0).Provider;
				if (string.Compare(provider, "DB2OLEDB", ignoreCase: true) == 0)
				{
					return true;
				}
			}
			if (idbConnection_0 is OdbcConnection)
			{
				string driver = ((OdbcConnection)idbConnection_0).Driver;
				if (driver != null && driver.IndexOf("IBM DB2", StringComparison.CurrentCultureIgnoreCase) >= 0)
				{
					return true;
				}
			}
			return false;
		}

		public static bool smethod_9(IDbConnection idbConnection_0)
		{
			int num = 0;
			if (idbConnection_0 == null)
			{
				return false;
			}
			if (string.Compare(idbConnection_0.GetType().Name, "MySqlConnection", ignoreCase: true) == 0)
			{
				return true;
			}
			if (idbConnection_0 is OleDbConnection)
			{
				string provider = ((OleDbConnection)idbConnection_0).Provider;
				if (string.Compare(provider, "MySQL Provider", ignoreCase: true) == 0)
				{
					return true;
				}
			}
			if (idbConnection_0 is OdbcConnection)
			{
				string driver = ((OdbcConnection)idbConnection_0).Driver;
				if (driver.IndexOf("MySQL", StringComparison.CurrentCultureIgnoreCase) >= 0)
				{
					return true;
				}
			}
			return false;
		}

		private GClass317()
		{
		}
	}
}
