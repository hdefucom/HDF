using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using XDesignerPrinting;

namespace ZYCommon
{
	public static class ZYConfig
	{
		private static IDictionary<string, string> ConfigDic = new Dictionary<string, string>();

		private static string[] CopyKeys = new string[6]
		{
			"FontName",
			"FontSize",
			"ReportPrintRightMargin",
			"ReportPrintLeftMargin",
			"LineSpacing",
			"ParagraphSpacing"
		};

		private static bool isInit = false;

		public static string FontName = "宋体";

		public static float FontSize = 12f;

		public static string NewFileXml = "";

		public static bool IsShowSaveLogInsert = true;

		public static int ReportPrintRightMargin = 150;

		public static int ReportPrintLeftMargin = 150;

		public static int ParagraphSpacing;

		public static int LineSpacing;

		public static bool IsFirstPageOnly = false;

		public static void InitConfig(IDbConnection Conn)
		{
			IDbCommand dbCommand = Conn.CreateCommand();
			dbCommand.CommandText = "SELECT SETTING_NAME ,VALUE FROM ZYRISDB.dbo.REPORT_EDITCONTROL_SETTING WHERE SETTING_TYPE=1 ";
			bool flag = true;
			if (Conn.State == ConnectionState.Open)
			{
				flag = false;
			}
			try
			{
				if (flag)
				{
					Conn.Open();
				}
				IDataReader dataReader = null;
				try
				{
					dataReader = dbCommand.ExecuteReader();
					while (dataReader.Read())
					{
						ConfigDic.Add(dataReader["SETTING_NAME"].ToString(), dataReader["VALUE"].ToString());
					}
					dataReader.Close();
				}
				catch
				{
					if (!(dataReader?.IsClosed ?? true))
					{
						dataReader.Close();
					}
				}
				isInit = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				try
				{
					if (flag)
					{
						Conn.Close();
					}
				}
				catch
				{
				}
			}
		}

		public static bool InitPaperSetting(string ModalityName, IDbConnection Conn)
		{
			if (ModalityName == "")
			{
				return false;
			}
			bool result = true;
			IDbCommand dbCommand = Conn.CreateCommand();
			dbCommand.CommandText = "SELECT MODALITY_NAME ,PAPER_KIND ,PAPER_WIDTH ,PAPER_HEIGHT ,MARGIN_TOP ,MARGIN_BOTTOM ,MARGIN_LEFT ,MARGIN_RIGHT ,LANDSCAPE FROM  ZYRISDB.dbo.REPORT_PAPER_SETTING WHERE MODALITY_NAME='" + ModalityName + "'";
			bool flag = true;
			if (Conn.State == ConnectionState.Open)
			{
				flag = false;
			}
			try
			{
				if (flag)
				{
					Conn.Open();
				}
				bool flag2 = true;
				IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
				if (dataReader.Read())
				{
					ZYPublic.PaperKind = dataReader["PAPER_KIND"].ToString();
					ZYPublic.PaperWidth = Convert.ToInt32(dataReader["PAPER_WIDTH"]);
					ZYPublic.PaperHeight = Convert.ToInt32(dataReader["PAPER_HEIGHT"]);
					ZYPublic.MarginTop = Convert.ToInt32(dataReader["MARGIN_TOP"]);
					ZYPublic.MarginBottom = Convert.ToInt32(dataReader["MARGIN_BOTTOM"]);
					ZYPublic.MarginLeft = Convert.ToInt32(dataReader["MARGIN_LEFT"]);
					ZYPublic.MarginRight = Convert.ToInt32(dataReader["MARGIN_RIGHT"]);
					ZYPublic.Landscape = Convert.ToBoolean(dataReader["LANDSCAPE"]);
				}
				else
				{
					flag2 = false;
				}
				dataReader.Close();
				if (!flag2)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("INSERT INTO ZYRISDB.dbo.REPORT_PAPER_SETTING");
					stringBuilder.Append("(MODALITY_NAME ,PAPER_KIND ,PAPER_WIDTH ,PAPER_HEIGHT ,MARGIN_TOP ,MARGIN_BOTTOM ,MARGIN_LEFT ,MARGIN_RIGHT ,LANDSCAPE)VALUES");
					stringBuilder.Append("('" + ModalityName + "',");
					stringBuilder.Append("'" + ZYPublic.PaperKind + "', ");
					stringBuilder.Append("'" + ZYPublic.PaperWidth + "', ");
					stringBuilder.Append("'" + ZYPublic.PaperHeight + "', ");
					stringBuilder.Append("'" + ZYPublic.MarginTop + "', ");
					stringBuilder.Append("'" + ZYPublic.MarginBottom + "', ");
					stringBuilder.Append("'" + ZYPublic.MarginLeft + "', ");
					stringBuilder.Append("'" + ZYPublic.MarginRight + "', ");
					stringBuilder.Append("'" + Convert.ToInt32(ZYPublic.Landscape) + "')");
					dbCommand.CommandText = stringBuilder.ToString();
					dbCommand.ExecuteNonQuery();
				}
			}
			catch
			{
				result = false;
				try
				{
					if (flag)
					{
						Conn.Close();
					}
				}
				catch
				{
				}
			}
			return result;
		}

		public static bool SavePaperSetting(IDbConnection iDbConnection, XPageSettings xPageSettings, string modalityName)
		{
			if (modalityName == "")
			{
				MessageBox.Show("初始化函数中未传入检查模式信息，无法保存页面配置信息");
				return false;
			}
			bool result = true;
			IDbCommand dbCommand = iDbConnection.CreateCommand();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ZYRISDB.dbo.REPORT_PAPER_SETTING SET ");
			stringBuilder.Append(string.Concat("PAPER_KIND='", xPageSettings.PaperSize.Kind, "', "));
			stringBuilder.Append("PAPER_WIDTH='" + xPageSettings.PaperSize.Width + "', ");
			stringBuilder.Append("PAPER_HEIGHT='" + xPageSettings.PaperSize.Height + "', ");
			stringBuilder.Append("MARGIN_TOP='" + xPageSettings.Margins.Top + "', ");
			stringBuilder.Append("MARGIN_BOTTOM='" + xPageSettings.Margins.Bottom + "', ");
			stringBuilder.Append("MARGIN_LEFT='" + xPageSettings.Margins.Left + "', ");
			stringBuilder.Append("MARGIN_RIGHT='" + xPageSettings.Margins.Right + "', ");
			stringBuilder.Append("LANDSCAPE='" + Convert.ToInt32(xPageSettings.Landscape) + "' ");
			stringBuilder.Append("WHERE MODALITY_NAME='" + modalityName + "'");
			dbCommand.CommandText = stringBuilder.ToString();
			bool flag = true;
			if (iDbConnection.State == ConnectionState.Open)
			{
				flag = false;
			}
			try
			{
				if (flag)
				{
					iDbConnection.Open();
				}
				int num = dbCommand.ExecuteNonQuery();
				if (num <= 0)
				{
					result = false;
				}
			}
			catch
			{
				result = false;
				try
				{
					if (flag)
					{
						iDbConnection.Close();
					}
				}
				catch
				{
				}
			}
			return result;
		}

		public static void InitModalityConfig(IDbConnection Conn, string modalityName)
		{
			if (!(modalityName == ""))
			{
				IDbCommand dbCommand = Conn.CreateCommand();
				dbCommand.CommandText = "SELECT SETTING_NAME ,VALUE FROM ZYRISDB.dbo.REPORT_EDITCONTROL_SETTING WHERE SETTING_TYPE=2 AND MODALITY='" + modalityName + "' ";
				bool flag = true;
				if (Conn.State == ConnectionState.Open)
				{
					flag = false;
				}
				try
				{
					if (flag)
					{
						Conn.Open();
					}
					IDataReader dataReader = null;
					try
					{
						IDictionary<string, string> dictionary = new Dictionary<string, string>();
						dataReader = dbCommand.ExecuteReader();
						while (dataReader.Read())
						{
							dictionary.Add(dataReader["SETTING_NAME"].ToString(), dataReader["VALUE"].ToString());
						}
						dataReader.Close();
						for (int i = 0; i < CopyKeys.Length; i++)
						{
							if (dictionary.ContainsKey(CopyKeys[i]))
							{
								ConfigDic[CopyKeys[i]] = dictionary[CopyKeys[i]];
							}
							else
							{
								InsertModalityConfig(Conn, modalityName, CopyKeys[i], ConfigDic[CopyKeys[i]]);
							}
						}
						FontName = ConfigDic["FontName"];
						FontSize = float.Parse(ConfigDic["FontSize"]);
						NewFileXml = ConfigDic["NewFile"];
						IsShowSaveLogInsert = Convert.ToBoolean(Convert.ToInt32(ConfigDic["IsShowSaveLogInsert"]));
						ReportPrintRightMargin = Convert.ToInt32(ConfigDic["ReportPrintRightMargin"]);
						ReportPrintLeftMargin = Convert.ToInt32(ConfigDic["ReportPrintLeftMargin"]);
						ParagraphSpacing = Convert.ToInt32(ConfigDic["ParagraphSpacing"]);
						LineSpacing = Convert.ToInt32(ConfigDic["LineSpacing"]);
						IsFirstPageOnly = Convert.ToBoolean(Convert.ToInt32(ConfigDic["IsFirstPageOnly"]));
					}
					catch
					{
						if (!(dataReader?.IsClosed ?? true))
						{
							dataReader.Close();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					try
					{
						if (flag)
						{
							Conn.Close();
						}
					}
					catch
					{
					}
				}
			}
		}

		private static bool InsertModalityConfig(IDbConnection Conn, string modalityName, string key, string val)
		{
			bool flag = true;
			if (modalityName == "")
			{
				return !flag;
			}
			IDbCommand dbCommand = Conn.CreateCommand();
			string text2 = dbCommand.CommandText = "INSERT INTO ZYRISDB.dbo.REPORT_EDITCONTROL_SETTING( SETTING_NAME ,VALUE ,MEMO ,SETTING_TYPE ,MODALITY)VALUES  ( '" + key + "' ,'" + val + "' ,'自动生成配置：" + modalityName + "对应的" + key + "配置' , 2 , '" + modalityName + "' )";
			try
			{
				int num = dbCommand.ExecuteNonQuery();
				if (num <= 0)
				{
					flag = false;
				}
			}
			catch
			{
				flag = false;
			}
			return flag;
		}
	}
}
