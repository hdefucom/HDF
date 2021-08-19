#define DEBUG
using Microsoft.Win32;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DCSoft.Data.FileSystem
{
	                                                                    /// <summary>
	                                                                    ///       文件系统的数据读取器,本对象可读取某个目录下的文件和子目录的信息
	                                                                    ///       </summary>
	                                                                    /// <remarks>
	                                                                    ///       本对象实现了 System.Data.IDataReader , 用于读取某个目录下
	                                                                    ///       的文件或子目录的信息
	                                                                    ///       Create YYF 2006</remarks>
	[ComVisible(false)]
	public class FileSystemDataReader : BaseDataReader, IRecordCount
	{
		private class ColumnInfo
		{
			internal string Name;

			internal string DisplayName;

			internal FileSystemFieldStyle Style;

			internal int FieldSize = 0;

			internal Type DataType = typeof(string);

			internal ColumnInfo(string vName)
			{
				Name = vName.Trim().ToUpper();
				Style = (FileSystemFieldStyle)Enum.Parse(typeof(FileSystemFieldStyle), Name, ignoreCase: true);
				DisplayName = vName;
				switch (Style)
				{
				default:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.Name:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.FullName:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.Extension:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.SimpleName:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.Attributes:
					DataType = typeof(int);
					FieldSize = Marshal.SizeOf(typeof(int));
					break;
				case FileSystemFieldStyle.FormatedAttributes:
					DataType = typeof(string);
					FieldSize = 10;
					break;
				case FileSystemFieldStyle.Size:
					DataType = typeof(long);
					FieldSize = Marshal.SizeOf(typeof(long));
					break;
				case FileSystemFieldStyle.FormatedSize:
					DataType = typeof(string);
					FieldSize = 30;
					break;
				case FileSystemFieldStyle.CreationTime:
					DataType = typeof(DateTime);
					FieldSize = 16;
					break;
				case FileSystemFieldStyle.AccessTime:
					DataType = typeof(DateTime);
					FieldSize = 16;
					break;
				case FileSystemFieldStyle.ModifiedTime:
					DataType = typeof(DateTime);
					FieldSize = 16;
					break;
				case FileSystemFieldStyle.FileTypeDesc:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.Type:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.Icon:
					DataType = typeof(string);
					FieldSize = 255;
					break;
				case FileSystemFieldStyle.ContentType:
					DataType = typeof(string);
					FieldSize = int.MaxValue;
					break;
				case FileSystemFieldStyle.MD5:
					DataType = typeof(byte[]);
					FieldSize = 50;
					break;
				case FileSystemFieldStyle.Index:
					DataType = typeof(int);
					FieldSize = Marshal.SizeOf(typeof(int));
					break;
				case FileSystemFieldStyle.Content:
					DataType = typeof(byte[]);
					FieldSize = int.MaxValue;
					break;
				case FileSystemFieldStyle.Text:
					DataType = typeof(string);
					FieldSize = int.MaxValue;
					break;
				case FileSystemFieldStyle.ANSIText:
					DataType = typeof(string);
					FieldSize = int.MaxValue;
					break;
				case FileSystemFieldStyle.GB2312Text:
					DataType = typeof(string);
					FieldSize = int.MaxValue;
					break;
				case FileSystemFieldStyle.UTF8Text:
					DataType = typeof(string);
					FieldSize = int.MaxValue;
					break;
				case FileSystemFieldStyle.UnicodeText:
					DataType = typeof(string);
					FieldSize = int.MaxValue;
					break;
				}
			}
		}

		private static string[] _SupportFieldNames = null;

		private int intPosition = -1;

		private string[] strFileNames = null;

		private FileSystemInfo myInfo = null;

		private int intFileStartIndex = -1;

		private bool bolSearchFile = true;

		private bool bolSearchDirectory = true;

		private Encoding myContentEncoding = Encoding.GetEncoding(936);

		private int _MaxContentLength = -1;

		                                                                    /// <summary>
		                                                                    ///       返回所有支持的字段名称
		                                                                    ///       </summary>
		public static string[] SupportFieldNames
		{
			get
			{
				int num = 8;
				if (_SupportFieldNames == null)
				{
					ArrayList arrayList = new ArrayList(Enum.GetNames(typeof(FileSystemFieldStyle)));
					arrayList.Remove("None");
					_SupportFieldNames = (string[])arrayList.ToArray(typeof(string));
				}
				return _SupportFieldNames;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       搜索文件
		                                                                    ///       </summary>
		public bool SearchFile
		{
			get
			{
				return bolSearchFile;
			}
			set
			{
				bolSearchFile = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       搜索子目录
		                                                                    ///       </summary>
		public bool SearchDirectory
		{
			get
			{
				return bolSearchDirectory;
			}
			set
			{
				bolSearchDirectory = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       文本文件编码器
		                                                                    ///       </summary>
		public Encoding ContentEncoding
		{
			get
			{
				return myContentEncoding;
			}
			set
			{
				myContentEncoding = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       读取文件内容时最大的读取字节数
		                                                                    ///       </summary>
		public int MaxContentLength
		{
			get
			{
				return _MaxContentLength;
			}
			set
			{
				_MaxContentLength = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       记录条数
		                                                                    ///       </summary>
		public int RecordCount
		{
			get
			{
				if (strFileNames == null)
				{
					return 0;
				}
				return strFileNames.Length;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断当前记录是否表示一个文件
		                                                                    ///       </summary>
		public bool IsFile => myInfo is FileInfo;

		                                                                    /// <summary>
		                                                                    ///       判断当前记录是否表示一个目录
		                                                                    ///       </summary>
		public bool IsDirecotry => myInfo is DirectoryInfo;

		                                                                    /// <summary>
		                                                                    ///       判断对象是否关闭
		                                                                    ///       </summary>
		public override bool IsClosed => strFileNames == null;

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public FileSystemDataReader()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       根据指定的目录和匹配模式初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">目录路径</param>
		                                                                    /// <param name="strSearchPattern">文件名匹配模式</param>
		public FileSystemDataReader(string strPath, string strSearchPattern)
		{
			Connect(strPath, strSearchPattern);
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定的路径初始化对象,支持通配符
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		public FileSystemDataReader(string strPath)
		{
			Connect(strPath);
		}

		                                                                    /// <summary>
		                                                                    ///       根据指定的路径加载数据,路径字符串支持通配符
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		public void Connect(string strPath)
		{
			string[] array = SplitPattern(strPath);
			Connect(array[0], array[1]);
		}

		                                                                    /// <summary>
		                                                                    ///       源自 DCSoft.Common.FileHelper
		                                                                    ///       将一个路径字符串拆成目录名和文件名,文件名支持通配符,函数输出一个包含两个字符串的数组
		                                                                    ///       其中第一个字符串为目录名,第二个字符串为文件名
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		                                                                    /// <returns>输出的字符串数组</returns>
		private static string[] SplitPattern(string strPath)
		{
			int num = 11;
			string text = null;
			string text2 = null;
			int num2 = strPath.LastIndexOfAny("/\\".ToCharArray());
			if (num2 > 0)
			{
				text = strPath.Substring(0, num2) + Path.DirectorySeparatorChar;
				text2 = strPath.Substring(num2 + 1);
			}
			else
			{
				text = null;
				text2 = strPath;
			}
			if (strPath.IndexOf('*') < 0 && strPath.IndexOf('?') < 0 && Directory.Exists(strPath))
			{
				text = strPath;
				text2 = "*";
			}
			return new string[2]
			{
				text,
				text2
			};
		}

		                                                                    /// <summary>
		                                                                    ///       根据指定的目录和匹配模式加载数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">目录路径</param>
		                                                                    /// <param name="strSearchPattern">文件名匹配模式</param>
		public void Connect(string strPath, string strSearchPattern)
		{
			int num = 16;
			try
			{
				if (strPath == null)
				{
					strPath = Environment.CurrentDirectory;
				}
				intFileStartIndex = -1;
				ArrayList arrayList = new ArrayList();
				if (bolSearchDirectory)
				{
					arrayList.AddRange(Directory.GetDirectories(strPath, strSearchPattern));
					intFileStartIndex = arrayList.Count;
				}
				if (bolSearchFile)
				{
					arrayList.AddRange(Directory.GetFiles(strPath, (strSearchPattern == null) ? "*" : strSearchPattern));
				}
				if (arrayList.Count > 0)
				{
					strFileNames = (string[])arrayList.ToArray(typeof(string));
				}
				else
				{
					strFileNames = null;
				}
				intPosition = -1;
			}
			catch (IOException ex)
			{
				Debug.WriteLine("Read '" + strPath + "' with IO Error:" + ex.Message);
				intPosition = -1;
				strFileNames = new string[0];
			}
		}

		                                                                    /// <summary>
		                                                                    ///       重置记录指针
		                                                                    ///       </summary>
		public void ResetPointer()
		{
			intPosition = -1;
		}

		                                                                    /// <summary>
		                                                                    ///       若当前记录为一个目录则为这个目录创建数据读取器
		                                                                    ///       </summary>
		                                                                    /// <param name="strSearchPattern">匹配字符串</param>
		                                                                    /// <returns>新创建的数据读取器</returns>
		public FileSystemDataReader CreateSubReader(string strSearchPattern)
		{
			DirectoryInfo directoryInfo = myInfo as DirectoryInfo;
			if (directoryInfo == null)
			{
				return null;
			}
			FileSystemDataReader fileSystemDataReader = CloneReader();
			fileSystemDataReader.Connect(directoryInfo.FullName, strSearchPattern);
			return fileSystemDataReader;
		}

		                                                                    /// <summary>
		                                                                    ///       若当前记录为一个目录则为这个目录创建数据读取器
		                                                                    ///       </summary>
		                                                                    /// <returns>新创建的数据读取器</returns>
		public FileSystemDataReader CreateSubReader()
		{
			return CreateSubReader("*");
		}

		                                                                    /// <summary>
		                                                                    ///       根据当前设置和字段结构创建一个新的数据读取器
		                                                                    ///       </summary>
		                                                                    /// <returns>新创建的数据读取器</returns>
		public FileSystemDataReader CloneReader()
		{
			FileSystemDataReader fileSystemDataReader = new FileSystemDataReader();
			fileSystemDataReader.bolSearchDirectory = bolSearchDirectory;
			fileSystemDataReader.bolSearchFile = bolSearchFile;
			fileSystemDataReader.myContentEncoding = myContentEncoding;
			foreach (ColumnInfo myColumn in myColumns)
			{
				ColumnInfo columnInfo2 = new ColumnInfo(myColumn.Name);
				columnInfo2.DisplayName = myColumn.DisplayName;
				fileSystemDataReader.myColumns.Add(columnInfo2);
			}
			return fileSystemDataReader;
		}

		public bool AddColumn(string vName)
		{
			ColumnInfo value = new ColumnInfo(vName);
			myColumns.Add(value);
			return true;
		}

		public bool AddColumn(string vName, string vDisplayName)
		{
			ColumnInfo columnInfo = new ColumnInfo(vName);
			columnInfo.DisplayName = vDisplayName;
			myColumns.Add(columnInfo);
			return true;
		}

		public string GetDisplayName(int index)
		{
			ColumnInfo columnInfo = (ColumnInfo)myColumns[index];
			return columnInfo.DisplayName;
		}

		public void SetDisplayName(int index, string vName)
		{
			((ColumnInfo)myColumns[index]).DisplayName = vName;
		}

		public void AddColumns(string[] vNames)
		{
			foreach (string vName in vNames)
			{
				AddColumn(vName);
			}
		}

		public void ClearColumn()
		{
			myColumns.Clear();
		}

		public override DataTable GetSchemaTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(SchemaTableColumn.ColumnName, typeof(string));
			dataTable.Columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.ColumnSize, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.DataType, typeof(Type));
			dataTable.Columns.Add(SchemaTableColumn.AllowDBNull, typeof(bool));
			foreach (ColumnInfo myColumn in myColumns)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = myColumn.Name;
				dataRow[1] = myColumns.IndexOf(myColumn);
				dataRow[2] = myColumn.FieldSize;
				dataRow[3] = myColumn.DataType;
				dataRow[4] = true;
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}

		protected override object InnerGetValue(int index)
		{
			ColumnInfo columnInfo = (ColumnInfo)myColumns[index];
			FileSystemInfo info = myInfo;
			if (columnInfo.Style == FileSystemFieldStyle.None || !Enum.IsDefined(typeof(FileSystemFieldStyle), columnInfo.Style))
			{
				return DBNull.Value;
			}
			if (columnInfo.Style == FileSystemFieldStyle.Index)
			{
				return intPosition;
			}
			return ReadData(info, columnInfo.Style, myContentEncoding, MaxContentLength);
		}

		public override string GetName(int ordinal)
		{
			return ((ColumnInfo)myColumns[ordinal]).DisplayName;
		}

		public override Type GetFieldType(int ordinal)
		{
			return ((ColumnInfo)myColumns[ordinal]).DataType;
		}

		protected override bool InnerIsDBNull(int index)
		{
			ColumnInfo columnInfo = (ColumnInfo)myColumns[index];
			if (columnInfo.Style == FileSystemFieldStyle.None || !Enum.IsDefined(typeof(FileSystemFieldStyle), columnInfo.Style))
			{
				return true;
			}
			if ((columnInfo.Style == FileSystemFieldStyle.Size || columnInfo.Style == FileSystemFieldStyle.FormatedSize || columnInfo.Style == FileSystemFieldStyle.AccessTime || columnInfo.Style == FileSystemFieldStyle.FileTypeDesc || columnInfo.Style == FileSystemFieldStyle.Icon || columnInfo.Style == FileSystemFieldStyle.ContentType || columnInfo.Style == FileSystemFieldStyle.MD5 || columnInfo.Style == FileSystemFieldStyle.Content || columnInfo.Style == FileSystemFieldStyle.Text || columnInfo.Style == FileSystemFieldStyle.ANSIText || columnInfo.Style == FileSystemFieldStyle.GB2312Text || columnInfo.Style == FileSystemFieldStyle.UTF8Text || columnInfo.Style == FileSystemFieldStyle.UnicodeText) && myInfo is DirectoryInfo)
			{
				return true;
			}
			return false;
		}

		public override long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			long result = 0L;
			FileInfo fileInfo = myInfo as FileInfo;
			if (fileInfo != null && fileInfo.Length > fieldOffset)
			{
				int num = (int)(fileInfo.Length - fieldOffset);
				if (num > length)
				{
					num = length;
				}
				using (FileStream fileStream = fileInfo.OpenRead())
				{
					if (fieldOffset > 0L)
					{
						fileStream.Seek(fieldOffset, SeekOrigin.Begin);
					}
					result = fileStream.Read(buffer, bufferoffset, num);
					fileStream.Close();
				}
			}
			return result;
		}

		                                                                    /// <summary>
		                                                                    ///       关闭对象
		                                                                    ///       </summary>
		public override void Close()
		{
			strFileNames = null;
			intPosition = -1;
			myInfo = null;
		}

		                                                                    /// <summary>
		                                                                    ///       移动到下一个记录
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override bool Read()
		{
			intPosition++;
			if (strFileNames != null && intPosition >= 0 && intPosition < strFileNames.Length)
			{
				string text = strFileNames[intPosition];
				if (intPosition >= intFileStartIndex)
				{
					myInfo = new FileInfo(text);
				}
				else
				{
					myInfo = new DirectoryInfo(text);
				}
				return true;
			}
			myInfo = null;
			return false;
		}

		public static object ReadData(FileSystemInfo info, FileSystemFieldStyle field, Encoding encoding, int maxContentLength)
		{
			int num = 1;
			switch (field)
			{
			case FileSystemFieldStyle.Name:
				return info.Name;
			case FileSystemFieldStyle.FullName:
				return info.FullName;
			case FileSystemFieldStyle.Extension:
				return Path.GetExtension(info.Name);
			case FileSystemFieldStyle.SimpleName:
				if (info is FileInfo)
				{
					return Path.GetFileNameWithoutExtension(info.Name);
				}
				return info.Name;
			case FileSystemFieldStyle.Attributes:
				return (int)info.Attributes;
			case FileSystemFieldStyle.FormatedAttributes:
			{
				FileAttributes attributes = info.Attributes;
				StringBuilder stringBuilder = new StringBuilder();
				if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
				{
					stringBuilder.Append("A");
				}
				if ((attributes & FileAttributes.Compressed) == FileAttributes.Compressed)
				{
					stringBuilder.Append("C");
				}
				if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
				{
					stringBuilder.Append("D");
				}
				if ((attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted)
				{
					stringBuilder.Append("E");
				}
				if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
				{
					stringBuilder.Append("H");
				}
				if ((attributes & FileAttributes.Normal) == FileAttributes.Normal)
				{
					stringBuilder.Append("N");
				}
				if ((attributes & FileAttributes.Offline) == FileAttributes.Offline)
				{
					stringBuilder.Append("O");
				}
				if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					stringBuilder.Append("R");
				}
				if ((attributes & FileAttributes.System) == FileAttributes.System)
				{
					stringBuilder.Append("S");
				}
				if ((attributes & FileAttributes.Temporary) == FileAttributes.Temporary)
				{
					stringBuilder.Append("T");
				}
				return stringBuilder.ToString();
			}
			case FileSystemFieldStyle.Size:
				if (info is FileInfo)
				{
					return ((FileInfo)info).Length;
				}
				return 0;
			case FileSystemFieldStyle.FormatedSize:
			{
				FileInfo fileInfo = info as FileInfo;
				if (fileInfo == null)
				{
					return null;
				}
				return FormatByteSize((int)fileInfo.Length);
			}
			case FileSystemFieldStyle.CreationTime:
				return info.CreationTime;
			case FileSystemFieldStyle.AccessTime:
				return info.LastAccessTime;
			case FileSystemFieldStyle.ModifiedTime:
				return info.LastWriteTime;
			case FileSystemFieldStyle.FileTypeDesc:
				if (info is FileInfo)
				{
					string extension = info.Extension;
					if (extension != null && extension.Length > 0)
					{
						string text = Path.GetExtension(info.Name);
						if (text != null && text.StartsWith("."))
						{
							text = text.Substring(1);
						}
						RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(extension);
						if (registryKey == null)
						{
							return text + " " + DataStrings.File;
						}
						extension = (string)registryKey.GetValue(null);
						if (extension == null)
						{
							return text + " " + DataStrings.File;
						}
						RegistryKey registryKey2 = Registry.ClassesRoot.OpenSubKey(extension);
						if (registryKey2 != null)
						{
							extension = (string)registryKey2.GetValue(null);
							registryKey2.Close();
						}
						registryKey.Close();
						return extension;
					}
					return DataStrings.File;
				}
				if (info is DirectoryInfo)
				{
					return DataStrings.Directory;
				}
				goto default;
			case FileSystemFieldStyle.Type:
				if (info is FileInfo)
				{
					return "F";
				}
				return "D";
			case FileSystemFieldStyle.Icon:
				if (info is FileInfo)
				{
					string extension = info.Extension;
					if (extension != null && extension.Length > 0)
					{
						RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(extension);
						if (registryKey != null)
						{
							extension = (string)registryKey.GetValue(null);
							if (extension != null && extension.Length > 0)
							{
								RegistryKey registryKey2 = Registry.ClassesRoot.OpenSubKey(extension + "\\DefaultIcon");
								if (registryKey2 != null)
								{
									extension = (string)registryKey2.GetValue(null);
									registryKey2.Close();
								}
							}
							registryKey.Close();
							return extension;
						}
					}
					return "";
				}
				goto default;
			case FileSystemFieldStyle.ContentType:
				if (info is FileInfo)
				{
					string extension = info.Extension;
					if (extension != null && extension.Length > 0)
					{
						RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(extension);
						if (registryKey != null)
						{
							extension = (string)registryKey.GetValue("Content Type");
							if (extension == null)
							{
								extension = "";
							}
							registryKey.Close();
							return extension;
						}
					}
					return "";
				}
				goto default;
			default:
				return null;
			case FileSystemFieldStyle.MD5:
			{
				FileInfo fileInfo = info as FileInfo;
				if (fileInfo == null)
				{
					return null;
				}
				using (FileStream fileStream = fileInfo.OpenRead())
				{
					MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
					byte[] array = mD5CryptoServiceProvider.ComputeHash(fileStream);
					fileStream.Close();
					mD5CryptoServiceProvider.Clear();
					return array;
				}
			}
			case FileSystemFieldStyle.Index:
				return 0;
			case FileSystemFieldStyle.Content:
			{
				FileInfo fileInfo = info as FileInfo;
				if (fileInfo == null || maxContentLength == 0)
				{
					return null;
				}
				using (FileStream fileStream = fileInfo.OpenRead())
				{
					byte[] array = null;
					array = ((maxContentLength <= 0) ? new byte[(int)fileInfo.Length] : new byte[Math.Min(maxContentLength, (int)fileInfo.Length)]);
					fileStream.Read(array, 0, array.Length);
					fileStream.Close();
					Debug.WriteLine(string.Format(DataStrings.ReadBytes_Bytes_Name, FormatByteSize(array.Length), fileInfo.FullName));
					return array;
				}
			}
			case FileSystemFieldStyle.Text:
				if (encoding == null)
				{
					encoding = Encoding.UTF8;
				}
				return ReadFileText(info, encoding, maxContentLength);
			case FileSystemFieldStyle.ANSIText:
				return ReadFileText(info, Encoding.ASCII, maxContentLength);
			case FileSystemFieldStyle.GB2312Text:
				return ReadFileText(info, Encoding.GetEncoding(936), maxContentLength);
			case FileSystemFieldStyle.UTF8Text:
				return ReadFileText(info, Encoding.UTF8, maxContentLength);
			case FileSystemFieldStyle.UnicodeText:
				return ReadFileText(info, Encoding.Unicode, maxContentLength);
			}
		}

		[DllImport("shlwapi.dll")]
		private static extern int StrFormatByteSizeA(int int_0, byte[] byte_0, int bufSize);

		                                                                    /// <summary>
		                                                                    ///       格式化输出字节大小数据
		                                                                    ///       </summary>
		                                                                    /// <param name="ByteSize">字节数</param>
		                                                                    /// <returns>输出的字符串</returns>
		public static string FormatByteSize(int ByteSize)
		{
			byte[] array = new byte[30];
			StrFormatByteSizeA(ByteSize, array, array.Length);
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (array[num] == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return Encoding.GetEncoding(936).GetString(array, 0, num);
		}

		private static string ReadFileText(object info, Encoding encoding, int maxContentLength)
		{
			FileInfo fileInfo = info as FileInfo;
			if (fileInfo != null && fileInfo.Exists && fileInfo.Length > 0L)
			{
				using (StreamReader streamReader = new StreamReader(fileInfo.OpenRead(), encoding))
				{
					string text = null;
					if (maxContentLength < 0)
					{
						text = streamReader.ReadToEnd();
					}
					else
					{
						char[] array = new char[Math.Min(maxContentLength, fileInfo.Length)];
						int length = streamReader.Read(array, 0, array.Length);
						text = new string(array, 0, length);
					}
					streamReader.Close();
					Debug.WriteLine(string.Format(DataStrings.ReadChars_Encoding_Name_Length, encoding.EncodingName, fileInfo.FullName, text.Length));
					return text;
				}
			}
			return "";
		}
	}
}
