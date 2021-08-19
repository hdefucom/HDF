using DCSoft.Common;
using DCSoft.Data;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       数据回填信息列表对象
	///       </summary>
	[DCPublishAPI]
	public class DataFeedbackInfoList : List<DataFeedbackInfo>
	{
		private class UpdateInfo
		{
			public string TableName = null;

			public SortedDictionary<string, string> FieldValues = new SortedDictionary<string, string>();

			public string KeyFieldName = null;

			public string KeyFieldValue = null;
		}

		/// <summary>
		///       更新数据
		///       </summary>
		/// <param name="conn">数据库连接对象</param>
		/// <param name="pStyle">命令参数样式</param>
		/// <returns>更新的数据库记录个数</returns>
		public int Update(IDbConnection conn, ParameterStyle pStyle)
		{
			int num = 17;
			if (base.Count == 0)
			{
				return 0;
			}
			if (conn.State != ConnectionState.Open)
			{
				conn.Open();
			}
			List<UpdateInfo> list = new List<UpdateInfo>();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataFeedbackInfo current = enumerator.Current;
					foreach (UpdateInfo item in list)
					{
						if (string.Compare(current.TableName, item.TableName, ignoreCase: true) == 0 && string.Compare(current.KeyFieldName, item.KeyFieldName, ignoreCase: true) == 0 && current.KeyFieldValue == item.KeyFieldValue)
						{
							item.FieldValues[current.FieldName] = current.FieldValue;
						}
						else
						{
							UpdateInfo updateInfo = new UpdateInfo();
							updateInfo.TableName = current.TableName;
							updateInfo.KeyFieldName = current.KeyFieldName;
							updateInfo.KeyFieldValue = current.KeyFieldValue;
							list.Add(updateInfo);
							item.FieldValues[current.FieldName] = current.FieldValue;
						}
					}
				}
			}
			int num2 = 0;
			using (IDbCommand dbCommand = conn.CreateCommand())
			{
				foreach (UpdateInfo item2 in list)
				{
					dbCommand.Parameters.Clear();
					StringBuilder stringBuilder = new StringBuilder();
					foreach (string key in item2.FieldValues.Keys)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
							stringBuilder.AppendLine();
						}
						stringBuilder.Append(key + " = " + GetRuntimeParameterName("V_" + key, item2.FieldValues[key], pStyle, dbCommand));
					}
					stringBuilder.Insert(0, "Update " + item2.TableName + " Set ");
					stringBuilder.AppendLine(" Where " + item2.KeyFieldName + "=" + GetRuntimeParameterName("Key_" + item2.KeyFieldName, item2.KeyFieldValue, pStyle, dbCommand));
					dbCommand.CommandText = stringBuilder.ToString();
					num2 += dbCommand.ExecuteNonQuery();
				}
			}
			return num2;
		}

		private string GetRuntimeParameterName(string fieldName, object fieldValue, ParameterStyle pStyle, IDbCommand idbCommand_0)
		{
			int num = 19;
			switch (pStyle)
			{
			case ParameterStyle.OracleStyle:
			{
				IDbDataParameter dbDataParameter = idbCommand_0.CreateParameter();
				dbDataParameter.ParameterName = fieldName;
				dbDataParameter.Value = fieldValue;
				idbCommand_0.Parameters.Add(dbDataParameter);
				return ":" + fieldName;
			}
			case ParameterStyle.SQLServerStyle:
			{
				IDbDataParameter dbDataParameter = idbCommand_0.CreateParameter();
				dbDataParameter.ParameterName = fieldName;
				dbDataParameter.Value = fieldValue;
				idbCommand_0.Parameters.Add(dbDataParameter);
				return "@" + fieldName;
			}
			case ParameterStyle.Anonymous:
			{
				IDbDataParameter dbDataParameter = idbCommand_0.CreateParameter();
				dbDataParameter.ParameterName = fieldName;
				dbDataParameter.Value = fieldValue;
				idbCommand_0.Parameters.Add(dbDataParameter);
				return "?";
			}
			default:
			{
				IDbDataParameter dbDataParameter = idbCommand_0.CreateParameter();
				dbDataParameter.ParameterName = fieldName;
				dbDataParameter.Value = fieldValue;
				idbCommand_0.Parameters.Add(dbDataParameter);
				return "@" + fieldName;
			}
			}
		}
	}
}
