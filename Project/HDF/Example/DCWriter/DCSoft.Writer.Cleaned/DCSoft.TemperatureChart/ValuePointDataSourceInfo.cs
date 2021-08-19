using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       数据点数据源信息对象
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("75CDC8C4-0367-4E19-9F8D-CAB329FAA708")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[XmlType]
	[DCDescriptionResourceSource("DCSoft.TemperatureChart.DCTimeLineDescriptionResource")]
	[ComDefaultInterface(typeof(IValuePointDataSourceInfo))]
	public class ValuePointDataSourceInfo : IValuePointDataSourceInfo
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
		[Editor(typeof(dlgSQLText.GClass18), typeof(UITypeEditor))]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "SQLText")]
		[XmlElement]
		[DefaultValue(null)]
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
		[XmlAttribute]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForID")]
		[DefaultValue(null)]
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
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForLink")]
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
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForTitle")]
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
		[DefaultValue(null)]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForTime")]
		[XmlAttribute]
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
		[DefaultValue(null)]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForValue")]
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
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForLanternValue")]
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
		[XmlAttribute]
		[DCDisplayName(typeof(ValuePointDataSourceInfo), "FieldNameForText")]
		[DefaultValue(null)]
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
		public int Fill(DataTable table, ValuePointList list)
		{
			int num = 4;
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
		public int Fill(IDataReader reader, ValuePointList list)
		{
			int num = 5;
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
				ValuePoint valuePoint = new ValuePoint();
				if (fieldIndex >= 0 && !reader.IsDBNull(fieldIndex))
				{
					valuePoint.ID = Convert.ToString(reader.GetValue(fieldIndex));
				}
				if (fieldIndex6 >= 0 && !reader.IsDBNull(fieldIndex6))
				{
					valuePoint.LanternValue = Convert.ToSingle(reader.GetValue(fieldIndex6));
				}
				if (fieldIndex2 >= 0 && !reader.IsDBNull(fieldIndex2))
				{
					valuePoint.Link = Convert.ToString(reader.GetValue(fieldIndex2));
				}
				if (fieldIndex7 >= 0 && !reader.IsDBNull(fieldIndex7))
				{
					valuePoint.Text = Convert.ToString(reader.GetValue(fieldIndex7));
				}
				if (fieldIndex4 >= 0 && !reader.IsDBNull(fieldIndex4))
				{
					valuePoint.Time = Convert.ToDateTime(reader.GetValue(fieldIndex4));
				}
				if (fieldIndex3 >= 0 && !reader.IsDBNull(fieldIndex3))
				{
					valuePoint.Title = Convert.ToString(reader.GetValue(fieldIndex3));
				}
				if (fieldIndex5 >= 0 && !reader.IsDBNull(fieldIndex5))
				{
					valuePoint.Value = Convert.ToSingle(reader.GetValue(fieldIndex5));
				}
				list.Add(valuePoint);
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
