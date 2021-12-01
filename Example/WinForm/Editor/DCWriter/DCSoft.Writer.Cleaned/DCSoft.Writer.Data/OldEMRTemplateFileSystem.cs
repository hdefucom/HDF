#define DEBUG
using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       旧的基于数据库的电子病历模板文件系统
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class OldEMRTemplateFileSystem : IFileSystem
	{
		private string string_0 = "ET_Document";

		[NonSerialized]
		private IDbConnection idbConnection_0 = null;

		/// <summary>
		///       操作使用的数据库的表名
		///       </summary>
		public string TableName
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
		///       数据库连接对象
		///       </summary>
		public IDbConnection DBConnection
		{
			get
			{
				return idbConnection_0;
			}
			set
			{
				idbConnection_0 = value;
			}
		}

		private void method_0()
		{
			int num = 14;
			if (idbConnection_0 == null)
			{
				throw new InvalidOperationException("DBConnection is null");
			}
			if (idbConnection_0.State != ConnectionState.Open)
			{
				idbConnection_0.Open();
			}
		}

		byte[] IFileSystem.Read(VFileSystemEventArgs args)
		{
			int num = 12;
			method_0();
			using (IDbCommand dbCommand = DBConnection.CreateCommand())
			{
				dbCommand.CommandText = "Select ObjectData From " + TableName + " where ObjectID ='" + args.FileName + "'";
				Debug.WriteLine(dbCommand.CommandText);
				object obj = dbCommand.ExecuteScalar();
				if (!DBNull.Value.Equals(obj))
				{
					string s = (string)obj;
					return Encoding.UTF8.GetBytes(s);
				}
				return null;
			}
		}

		bool IFileSystem.Write(VFileSystemEventArgs args, byte[] content)
		{
			int num = 3;
			method_0();
			using (IDbCommand dbCommand = DBConnection.CreateCommand())
			{
				dbCommand.CommandText = "Update " + TableName + " Set ObjectData = ? Where ObjectID = '" + args.FileName + "'";
				Debug.WriteLine(dbCommand.CommandText);
				IDataParameter dataParameter = dbCommand.CreateParameter();
				if (content != null && content.Length > 0)
				{
					string text = (string)(dataParameter.Value = Encoding.UTF8.GetString(content));
				}
				else
				{
					dataParameter.Value = DBNull.Value;
				}
				dbCommand.Parameters.Add(dataParameter);
				if (dbCommand.ExecuteNonQuery() > 0)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       获得文件信息
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>文件信息</returns>
		public VFileInfo GetFileInfo(VFileSystemEventArgs args)
		{
			return method_1(args.FileName);
		}

		private VFileInfo method_1(string string_1)
		{
			int num = 16;
			method_0();
			using (IDbCommand dbCommand = DBConnection.CreateCommand())
			{
				dbCommand.CommandText = "Select ObjectName From " + TableName + " Where ObjectID = '" + string_1 + "'";
				IDataReader dataReader = dbCommand.ExecuteReader();
				VFileInfo vFileInfo = new VFileInfo();
				vFileInfo.Name = string_1;
				vFileInfo.FullPath = string_1;
				vFileInfo.Format = "OldXML";
				if (dataReader.Read())
				{
					vFileInfo.Exists = true;
					vFileInfo.Title = Convert.ToString(dataReader.GetValue(0));
				}
				else
				{
					vFileInfo.Exists = false;
				}
				dataReader.Close();
				return vFileInfo;
			}
		}

		VFileInfo IFileSystem.BrowseForRead(VFileSystemEventArgs args)
		{
			int num = 18;
			method_0();
			using (dlgOldEMRTemplateBrowse dlgOldEMRTemplateBrowse = new dlgOldEMRTemplateBrowse())
			{
				using (IDbCommand dbCommand = DBConnection.CreateCommand())
				{
					dbCommand.CommandText = "Select ObjectID , ObjectName From " + TableName + " order by ObjectName";
					IDataReader dataReader = dbCommand.ExecuteReader();
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					while (dataReader.Read())
					{
						if (!dataReader.IsDBNull(0) && !dataReader.IsDBNull(1))
						{
							dictionary[dataReader.GetString(1)] = dataReader.GetString(0);
						}
					}
					dataReader.Close();
					dlgOldEMRTemplateBrowse.SelectedFileID = args.FileName;
					dlgOldEMRTemplateBrowse.FileNames = dictionary;
				}
				if (dlgOldEMRTemplateBrowse.ShowDialog(args.ParentWindow) == DialogResult.OK)
				{
					return method_1(dlgOldEMRTemplateBrowse.SelectedFileID);
				}
			}
			return null;
		}

		VFileInfo IFileSystem.BrowseForWrite(VFileSystemEventArgs args)
		{
			int num = 5;
			method_0();
			using (dlgOldEMRTemplateBrowse dlgOldEMRTemplateBrowse = new dlgOldEMRTemplateBrowse())
			{
				using (IDbCommand dbCommand = DBConnection.CreateCommand())
				{
					dbCommand.CommandText = "Select ObjectID , ObjectName From " + TableName + " Order by ObjectName ";
					IDataReader dataReader = dbCommand.ExecuteReader();
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					while (dataReader.Read())
					{
						if (!dataReader.IsDBNull(0) && !dataReader.IsDBNull(1))
						{
							dictionary[dataReader.GetString(1)] = dataReader.GetString(0);
						}
					}
					dataReader.Close();
					dlgOldEMRTemplateBrowse.SelectedFileID = args.FileName;
					dlgOldEMRTemplateBrowse.FileNames = dictionary;
				}
				if (dlgOldEMRTemplateBrowse.ShowDialog(args.ParentWindow) == DialogResult.OK)
				{
					return method_1(dlgOldEMRTemplateBrowse.SelectedFileID);
				}
			}
			return null;
		}
	}
}
