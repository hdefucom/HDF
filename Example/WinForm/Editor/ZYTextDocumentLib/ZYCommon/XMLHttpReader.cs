using System;
using System.Collections;
using System.Data;
using System.Xml;

namespace ZYCommon
{
	public class XMLHttpReader : IDataReader, IDisposable, IDataRecord
	{
		private const string c_NullFlag = "[NULL]";

		private string[] strHead = null;

		private ArrayList myRows = new ArrayList();

		private bool bolClosed = false;

		private int intRowIndex = 0;

		public int RecordsAffected => 0;

		public bool IsClosed => bolClosed;

		public int Depth => 0;

		public object this[string name] => GetString(GetIndexByName(name));

		object IDataRecord.this[int i] => GetString(i);

		public int FieldCount => strHead.Length;

		public int GetIndexByName(string strName)
		{
			if (strName == null)
			{
				return -1;
			}
			strName = strName.ToUpper().Trim();
			for (int i = 0; i < strHead.Length; i++)
			{
				if (strName.Equals(strHead[i]))
				{
					return i;
				}
			}
			return -1;
		}

		public int FromReader(IDataReader myReader)
		{
			if (myReader != null)
			{
				strHead = new string[myReader.FieldCount];
				for (int i = 0; i < myReader.FieldCount; i++)
				{
					strHead[i] = myReader.GetName(i).ToLower().Trim();
				}
				myRows.Clear();
				intRowIndex = -1;
				while (myReader.Read())
				{
					string[] array = new string[myReader.FieldCount];
					myRows.Add(array);
					for (int i = 0; i < myReader.FieldCount; i++)
					{
						if (!myReader.IsDBNull(i))
						{
							if (myReader[i] is byte[])
							{
								array[i] = Convert.ToBase64String((byte[])myReader[i]);
							}
							else
							{
								array[i] = myReader[i].ToString();
							}
						}
					}
				}
				return myRows.Count;
			}
			return -1;
		}

		public int ToXML(XmlElement RootElement)
		{
			XmlElement xmlElement = null;
			XmlElement xmlElement2 = null;
			while (RootElement.FirstChild != null)
			{
				RootElement.RemoveChild(RootElement.FirstChild);
			}
			if (strHead != null && strHead.Length > 0)
			{
				for (int i = 0; i < strHead.Length; i++)
				{
					RootElement.SetAttribute("f" + i, strHead[i]);
				}
				RootElement.SetAttribute("fieldcount", strHead.Length.ToString());
			}
			if (myRows != null && myRows.Count > 0)
			{
				XmlDocument ownerDocument = RootElement.OwnerDocument;
				for (int j = 0; j < myRows.Count; j++)
				{
					string[] array = (string[])myRows[j];
					xmlElement = ownerDocument.CreateElement("r");
					RootElement.AppendChild(xmlElement);
					for (int i = 0; i < array.Length; i++)
					{
						xmlElement2 = ownerDocument.CreateElement("f" + i);
						xmlElement.AppendChild(xmlElement2);
						if (array[i] == null)
						{
							xmlElement2.InnerText = "[NULL]";
						}
						else
						{
							xmlElement2.InnerText = array[i];
						}
					}
				}
				return myRows.Count;
			}
			return -1;
		}

		public int FromXML(XmlElement RootElement)
		{
			XmlElement xmlElement = null;
			strHead = null;
			myRows.Clear();
			intRowIndex = -1;
			if (RootElement == null)
			{
				return -1;
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < 255; i++)
			{
				if (!RootElement.HasAttribute("f" + i))
				{
					break;
				}
				string attribute = RootElement.GetAttribute("f" + i);
				arrayList.Add(attribute.ToLower().Trim());
			}
			strHead = (string[])arrayList.ToArray(typeof(string));
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				if (childNode is XmlElement)
				{
					xmlElement = (XmlElement)childNode;
					string[] array = new string[strHead.Length];
					myRows.Add(array);
					int num = 0;
					foreach (XmlNode childNode2 in xmlElement.ChildNodes)
					{
						if (childNode2 is XmlElement)
						{
							array[num] = ((childNode2.InnerText == "[NULL]") ? null : childNode2.InnerText);
							num++;
						}
					}
				}
			}
			return myRows.Count;
		}

		public bool NextResult()
		{
			if (myRows == null || intRowIndex + 1 >= myRows.Count)
			{
				return false;
			}
			return true;
		}

		public void Close()
		{
			bolClosed = true;
			strHead = null;
			myRows = null;
		}

		public bool Read()
		{
			intRowIndex++;
			if (intRowIndex >= myRows.Count)
			{
				return false;
			}
			return true;
		}

		public DataTable GetSchemaTable()
		{
			return null;
		}

		public void Dispose()
		{
		}

		public int GetInt32(int i)
		{
			return Convert.ToInt32(GetString(i));
		}

		public object GetValue(int i)
		{
			return GetString(i);
		}

		public bool IsDBNull(int i)
		{
			return GetString(i) == null;
		}

		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			byte[] array = Convert.FromBase64String(GetString(i));
			int j;
			for (j = 0; j < length && j + fieldOffset < array.Length; j++)
			{
				buffer[j + bufferoffset] = array[j + fieldOffset];
			}
			return j;
		}

		public byte GetByte(int i)
		{
			return Convert.ToByte(GetString(i));
		}

		public Type GetFieldType(int i)
		{
			return null;
		}

		public decimal GetDecimal(int i)
		{
			return Convert.ToDecimal(GetString(i));
		}

		public int GetValues(object[] values)
		{
			return 0;
		}

		public string GetName(int i)
		{
			if (i >= 0 && i < strHead.Length)
			{
				return strHead[i];
			}
			return null;
		}

		public long GetInt64(int i)
		{
			return Convert.ToInt64(GetString(i));
		}

		public double GetDouble(int i)
		{
			return Convert.ToDouble(GetString(i));
		}

		public bool GetBoolean(int i)
		{
			return Convert.ToBoolean(GetString(i));
		}

		public Guid GetGuid(int i)
		{
			return default(Guid);
		}

		public DateTime GetDateTime(int i)
		{
			return Convert.ToDateTime(GetString(i));
		}

		public int GetOrdinal(string name)
		{
			return 0;
		}

		public string GetDataTypeName(int i)
		{
			return null;
		}

		public float GetFloat(int i)
		{
			return Convert.ToSingle(GetString(i));
		}

		public IDataReader GetData(int i)
		{
			return null;
		}

		public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		public string GetString(int i)
		{
			if (intRowIndex >= 0 && intRowIndex < myRows.Count && i >= 0 && i < strHead.Length)
			{
				string[] array = (string[])myRows[intRowIndex];
				return array[i];
			}
			throw new IndexOutOfRangeException("记录表错误：行数或列数越界,Row:" + intRowIndex + " Col:" + i);
		}

		public char GetChar(int i)
		{
			return Convert.ToChar(GetString(i));
		}

		public short GetInt16(int i)
		{
			return Convert.ToInt16(GetString(i));
		}
	}
}
