using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据点数据源信息对象
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(IValuePointDataSourceInfo))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ClassInterface(ClassInterfaceType.None)]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	[Guid("D98C37F3-8D30-4D43-B78B-FEB0CD54E45D")]
	[XmlType]
	[ComVisible(true)]
	[DocumentComment]
	public class FCValuePointDataSourceInfo : IValuePointDataSourceInfo
	{
		private string _SQLText = null;

		private string _FieldNameForID = null;

		private string _FieldNameForLink = null;

		private string _FieldNameForTitle = null;

		private string _FieldNameForTime = null;

		private string _FieldNameForValue = null;

		private string _FieldNameForLanternValue = null;

		private string _FieldNameForText = null;

		/// <summary>
		///       查询数据使用的SQL语句
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "SQLText")]
		[XmlElement]
		[Editor(typeof(FCdlgSQLText.GClass19), typeof(UITypeEditor))]
		public string SQLText
		{
			get
			{
				return _SQLText;
			}
			set
			{
				_SQLText = value;
			}
		}

		/// <summary>
		///       表示ID的字段名
		///       </summary>
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForID")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string FieldNameForID
		{
			get
			{
				return _FieldNameForID;
			}
			set
			{
				_FieldNameForID = value;
			}
		}

		/// <summary>
		///       表示Link的字段名
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForLink")]
		[DefaultValue(null)]
		public string FieldNameForLink
		{
			get
			{
				return _FieldNameForLink;
			}
			set
			{
				_FieldNameForLink = value;
			}
		}

		/// <summary>
		///       表示Title的字段名
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForTitle")]
		[DefaultValue(null)]
		public string FieldNameForTitle
		{
			get
			{
				return _FieldNameForTitle;
			}
			set
			{
				_FieldNameForTitle = value;
			}
		}

		/// <summary>
		///       表示Time的字段名
		///       </summary>
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForTime")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string FieldNameForTime
		{
			get
			{
				return _FieldNameForTime;
			}
			set
			{
				_FieldNameForTime = value;
			}
		}

		/// <summary>
		///       表示Value的字段名
		///       </summary>
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForValue")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string FieldNameForValue
		{
			get
			{
				return _FieldNameForValue;
			}
			set
			{
				_FieldNameForValue = value;
			}
		}

		/// <summary>
		///       表示LanternValue的字段名
		///       </summary>
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForLanternValue")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string FieldNameForLanternValue
		{
			get
			{
				return _FieldNameForLanternValue;
			}
			set
			{
				_FieldNameForLanternValue = value;
			}
		}

		/// <summary>
		///       表示Text的字段名
		///       </summary>
		[DCDisplayName(typeof(FCValuePointDataSourceInfo), "FieldNameForText")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string FieldNameForText
		{
			get
			{
				return _FieldNameForText;
			}
			set
			{
				_FieldNameForText = value;
			}
		}

		/// <summary>
		///       填充数据
		///       </summary>
		/// <param name="table">数据表对象</param>
		/// <param name="list">数据点列表</param>
		/// <returns>填充的数据个数</returns>
		public int Fill(DataTable table, FCValuePointList list)
		{
			int num = 2;
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			DataTableReader reader = new DataTableReader(table);
			return Fill(reader, list);
		}

		/// <summary>
		///       填充数据
		///       </summary>
		/// <param name="reader">数据读取器</param>
		/// <param name="list">数据点列表</param>
		/// <returns>填充的数据个数</returns>
		public int Fill(IDataReader reader, FCValuePointList list)
		{
			int num = 19;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			int num2 = 0;
			int fieldIndex = GetFieldIndex(reader, FieldNameForID);
			int fieldIndex2 = GetFieldIndex(reader, FieldNameForLink);
			int fieldIndex3 = GetFieldIndex(reader, FieldNameForTitle);
			int fieldIndex4 = GetFieldIndex(reader, FieldNameForTime);
			int fieldIndex5 = GetFieldIndex(reader, FieldNameForValue);
			int fieldIndex6 = GetFieldIndex(reader, FieldNameForLanternValue);
			int fieldIndex7 = GetFieldIndex(reader, FieldNameForText);
			while (reader.Read())
			{
				FCValuePoint fCValuePoint = new FCValuePoint();
				if (fieldIndex >= 0 && !reader.IsDBNull(fieldIndex))
				{
					fCValuePoint.ID = Convert.ToString(reader.GetValue(fieldIndex));
				}
				if (fieldIndex6 >= 0 && !reader.IsDBNull(fieldIndex6))
				{
					fCValuePoint.LanternValue = Convert.ToSingle(reader.GetValue(fieldIndex6));
				}
				if (fieldIndex2 >= 0 && !reader.IsDBNull(fieldIndex2))
				{
					fCValuePoint.Link = Convert.ToString(reader.GetValue(fieldIndex2));
				}
				if (fieldIndex7 >= 0 && !reader.IsDBNull(fieldIndex7))
				{
					fCValuePoint.Text = Convert.ToString(reader.GetValue(fieldIndex7));
				}
				if (fieldIndex4 >= 0 && !reader.IsDBNull(fieldIndex4))
				{
					fCValuePoint.Time = Convert.ToDateTime(reader.GetValue(fieldIndex4));
				}
				if (fieldIndex3 >= 0 && !reader.IsDBNull(fieldIndex3))
				{
					fCValuePoint.Title = Convert.ToString(reader.GetValue(fieldIndex3));
				}
				if (fieldIndex5 >= 0 && !reader.IsDBNull(fieldIndex5))
				{
					fCValuePoint.Value = Convert.ToSingle(reader.GetValue(fieldIndex5));
				}
				list.Add(fCValuePoint);
				num2++;
			}
			return num2;
		}

		private int GetFieldIndex(IDataReader reader, string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return -1;
			}
			return reader.GetOrdinal(fieldName);
		}
	}
}
