#define DEBUG
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       文件处理类,DCWriter内部使用。
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class FileHelper
	{
		                                                                    /// <summary>
		                                                                    ///       获得指定文件内容的BASE64格式的MD5编码值
		                                                                    ///       </summary>
		                                                                    /// <param name="fileName">文件名</param>
		                                                                    /// <returns>获得的编码文本</returns>
		public static string GetFileMD5Base64String(string fileName)
		{
			int num = 10;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			using (FileStream inputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				byte[] inArray = mD5CryptoServiceProvider.ComputeHash(inputStream);
				mD5CryptoServiceProvider.Clear();
				return Convert.ToBase64String(inArray);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       释放一个程序集资源文件到本地文件中
		                                                                    ///       </summary>
		                                                                    /// <param name="t">程序集中的某个类型</param>
		                                                                    /// <param name="resourceName">资源名称</param>
		                                                                    /// <param name="localFileName">本地文件名</param>
		                                                                    /// <param name="overWrite">是佛覆盖旧文件</param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static int ReleaseResourceFile(Type type_0, string resourceName, string localFileName, bool overWrite, bool throwException)
		{
			int num = 16;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (string.IsNullOrEmpty(resourceName))
			{
				throw new ArgumentNullException("resourceName");
			}
			if (string.IsNullOrEmpty(localFileName))
			{
				throw new ArgumentNullException("localFileName");
			}
			if (!overWrite && File.Exists(localFileName))
			{
				return -1;
			}
			Stream manifestResourceStream = type_0.Assembly.GetManifestResourceStream(resourceName);
			if (manifestResourceStream != null)
			{
				if (throwException)
				{
					using (manifestResourceStream)
					{
						return SaveStreamToFile(manifestResourceStream, localFileName);
					}
				}
				try
				{
					using (manifestResourceStream)
					{
						return SaveStreamToFile(manifestResourceStream, localFileName);
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
			return -1;
		}

		                                                                    /// <summary>
		                                                                    ///       加载资源文件中的文本
		                                                                    ///       </summary>
		                                                                    /// <param name="t">资源所在程序集中的类型</param>
		                                                                    /// <param name="resourceName">资源名称</param>
		                                                                    /// <returns>加载的文本</returns>
		public static byte[] LoadResourceBinary(Type type_0, string resourceName)
		{
			int num = 2;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (string.IsNullOrEmpty(resourceName))
			{
				throw new ArgumentNullException("resourceName");
			}
			Stream manifestResourceStream = type_0.Assembly.GetManifestResourceStream(resourceName);
			if (manifestResourceStream != null)
			{
				byte[] result = LoadBinaryStream(manifestResourceStream);
				manifestResourceStream.Close();
				return result;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       加载资源文件中的文本
		                                                                    ///       </summary>
		                                                                    /// <param name="t">资源所在程序集中的类型</param>
		                                                                    /// <param name="resourceName">资源名称</param>
		                                                                    /// <param name="encoding">指定的文本编码格式</param>
		                                                                    /// <returns>加载的文本</returns>
		public static string LoadResourceString(Type type_0, string resourceName, Encoding encoding)
		{
			int num = 8;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (string.IsNullOrEmpty(resourceName))
			{
				throw new ArgumentNullException("resourceName");
			}
			Stream manifestResourceStream = type_0.Assembly.GetManifestResourceStream(resourceName);
			if (manifestResourceStream != null)
			{
				StreamReader streamReader;
				string result;
				if (encoding == null)
				{
					streamReader = new StreamReader(manifestResourceStream, detectEncodingFromByteOrderMarks: true);
					result = streamReader.ReadToEnd();
					manifestResourceStream.Close();
					return result;
				}
				streamReader = new StreamReader(manifestResourceStream, encoding);
				result = streamReader.ReadToEnd();
				manifestResourceStream.Close();
				return result;
			}
			return null;
		}

		public static byte[] GZipCompress(byte[] byte_0)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				gZipStream.Write(byte_0, 0, byte_0.Length);
				gZipStream.Close();
				return memoryStream.ToArray();
			}
		}

		public static byte[] GZipDecompress(byte[] byte_0)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			MemoryStream stream = new MemoryStream(byte_0);
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
			{
				MemoryStream memoryStream = new MemoryStream();
				byte[] array = new byte[512];
				while (true)
				{
					int num = gZipStream.Read(array, 0, array.Length);
					if (num <= 0)
					{
						break;
					}
					memoryStream.Write(array, 0, num);
				}
				return memoryStream.ToArray();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       目录复制
		                                                                    ///       </summary>
		                                                                    /// <param name="direcSource">源目录</param>
		                                                                    /// <param name="direcTarget">目标目录</param>
		                                                                    /// <param name="resetFileAttributes">是否重置复制的文件属性</param>
		public static void CopyFolder(string direcSource, string direcTarget, bool resetFileAttributes)
		{
			if (!Directory.Exists(direcTarget))
			{
				Directory.CreateDirectory(direcTarget);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(direcSource);
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				string text = Path.Combine(direcTarget, fileInfo.Name);
				fileInfo.CopyTo(text, overwrite: true);
				if (resetFileAttributes)
				{
					File.SetAttributes(text, FileAttributes.Normal);
				}
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			DirectoryInfo[] array2 = directories;
			foreach (DirectoryInfo directoryInfo2 in array2)
			{
				CopyFolder(Path.Combine(direcSource, directoryInfo2.Name), Path.Combine(direcTarget, directoryInfo2.Name), resetFileAttributes);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个文件存在而且是标记为只读的
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <returns>是否只读</returns>
		public static bool IsReadonlyFile(string strFileName)
		{
			if (strFileName == null || strFileName.Length == 0)
			{
				return false;
			}
			if (!File.Exists(strFileName))
			{
				return false;
			}
			if ((File.GetAttributes(strFileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       获得路径的长路径名
		                                                                    ///       </summary>
		                                                                    /// <param name="ShortPath">路径名,可以是短路径名</param>
		                                                                    /// <returns>获得的长路径名</returns>
		public static string GetLongPath(string ShortPath)
		{
			StringBuilder stringBuilder = new StringBuilder(260);
			new StringBuilder();
			if (0 != GetLongPathName(ShortPath, stringBuilder, (uint)stringBuilder.Capacity))
			{
				return stringBuilder.ToString();
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       获得路径的短路径名
		                                                                    ///       </summary>
		                                                                    /// <param name="Path">路径名,可以是长路径名</param>
		                                                                    /// <returns>获得的短路径名</returns>
		public static string GetShortPath(string Path)
		{
			StringBuilder stringBuilder = new StringBuilder(260);
			if (0 != GetShortPathName(Path, stringBuilder, (uint)stringBuilder.Capacity))
			{
				return stringBuilder.ToString();
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       查找文件
		                                                                    ///       </summary>
		                                                                    /// <param name="SearchPath">开始查找的目录</param>
		                                                                    /// <param name="SearchPattern">文件名匹配字符串</param>
		                                                                    /// <param name="Deeply">是否进行深入子孙目录查找文件</param>
		                                                                    /// <param name="ReturnAbsPath">是否返回绝对路径名</param>
		                                                                    /// <returns>查找到的文件名组成的数组</returns>
		public static string[] SearchFiles(string SearchPath, string SearchPattern, bool Deeply, bool ReturnAbsPath)
		{
			int num = 13;
			if (SearchPath == null)
			{
				return null;
			}
			if (!Directory.Exists(SearchPath))
			{
				return null;
			}
			if (SearchPattern == null || SearchPattern.Length == 0)
			{
				SearchPattern = "*.*";
			}
			ArrayList arrayList = new ArrayList();
			InnerSearchFiles(SearchPath, SearchPattern, arrayList, Deeply);
			if (!ReturnAbsPath)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					string text = (string)arrayList[i];
					text = text.Substring(SearchPath.Length);
					if (text.StartsWith("\\") || text.StartsWith("/"))
					{
						text = text.Substring(1);
					}
					arrayList[i] = text;
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		                                                                    /// <summary>
		                                                                    ///       保存一个文件数据到一个流中
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <param name="OutputStream">保存数据的输出流</param>
		                                                                    /// <returns>操作的字节数</returns>
		public static int SaveFileToStream(string strFileName, Stream OutputStream)
		{
			if (strFileName == null || OutputStream == null)
			{
				return 0;
			}
			if (!File.Exists(strFileName))
			{
				return 0;
			}
			using (FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
			{
				int result = CopyStream(fileStream, OutputStream);
				fileStream.Close();
				return result;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       保存流中的数据到一个文件中
		                                                                    ///       </summary>
		                                                                    /// <param name="InputStream">流对象</param>
		                                                                    /// <param name="strFileName">保存数据的文件名</param>
		                                                                    /// <returns>保存的字节数</returns>
		public static int SaveStreamToFile(Stream InputStream, string strFileName)
		{
			if (InputStream == null || strFileName == null)
			{
				return 0;
			}
			using (FileStream fileStream = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
			{
				int result = CopyStream(InputStream, fileStream);
				fileStream.Close();
				return result;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       安全的不触发异常的删除文件
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <returns>文件是否删除</returns>
		public static bool SafeDelete(string strFileName)
		{
			if (strFileName == null || strFileName.Length == 0)
			{
				return false;
			}
			try
			{
				if (File.Exists(strFileName))
				{
					File.SetAttributes(strFileName, FileAttributes.Normal);
					File.Delete(strFileName);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       将一个路径字符串拆成目录名和文件名,文件名支持通配符,函数输出一个包含两个字符串的数组
		                                                                    ///       其中第一个字符串为目录名,第二个字符串为文件名
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		                                                                    /// <returns>输出的字符串数组</returns>
		public static string[] SplitPattern(string strPath)
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
			return Encoding.Default.GetString(array, 0, num);
		}

		                                                                    /// <summary>
		                                                                    ///       格式化输出字节大小数据
		                                                                    ///       </summary>
		                                                                    /// <param name="ByteSize">字节数</param>
		                                                                    /// <returns>输出的字符串</returns>
		public static string FormatByteSize(long ByteSize)
		{
			byte[] array = new byte[30];
			StrFormatByteSize64(ByteSize, array, array.Length);
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

		                                                                    /// <summary>
		                                                                    ///       读取指定流中所有的数据，返回一个字节数组
		                                                                    ///       </summary>
		                                                                    /// <param name="stream">流对象</param>
		                                                                    /// <returns>返回的字节数组</returns>
		public static byte[] LoadBinaryStream(Stream stream)
		{
			int num = 10;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (stream is MemoryStream)
			{
				return ((MemoryStream)stream).ToArray();
			}
			byte[] array = new byte[1024];
			MemoryStream memoryStream = new MemoryStream();
			while (true)
			{
				int num2 = stream.Read(array, 0, array.Length);
				if (num2 <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num2);
			}
			return memoryStream.ToArray();
		}

		                                                                    /// <summary>
		                                                                    ///       读取文件头
		                                                                    ///       </summary>
		                                                                    /// <param name="fileName">文件名</param>
		                                                                    /// <param name="maxByteLen">读取的最大的字节数</param>
		                                                                    /// <returns>读取的数据</returns>
		public static byte[] ReadFileHeader(string fileName, int maxByteLen)
		{
			int num = 9;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			if (maxByteLen <= 0)
			{
				throw new ArgumentOutOfRangeException("maxByteLen=" + maxByteLen);
			}
			byte[] array = new byte[maxByteLen];
			using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				int num2 = fileStream.Read(array, 0, array.Length);
				if (num2 < array.Length)
				{
					byte[] array2 = new byte[num2];
					Array.Copy(array, array2, num2);
					array = array2;
				}
			}
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       读取指定二进制文件的内容并生成BASE64字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="fileName">文件名</param>
		                                                                    /// <param name="throwException">操作失败是否抛出异常</param>
		                                                                    /// <returns>获得的BASE64字符串</returns>
		public static string LoadBase64StringFromFile(string fileName, bool throwException)
		{
			byte[] array = LoadBinaryFile(fileName, throwException);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			return Convert.ToBase64String(array);
		}

		                                                                    /// <summary>
		                                                                    ///       从指定文件读取二进制数据,返回获得的字节数组,若文件不存在或读取失败则返回空引用
		                                                                    ///       </summary>
		                                                                    /// <param name="strFile">文件名</param>
		                                                                    /// <param name="throwException">发生错误是否抛出异常</param>
		                                                                    /// <returns>获得字节数组,若读取失败则返回空引用</returns>
		public static byte[] LoadBinaryFile(string strFile, bool throwException)
		{
			if (throwException)
			{
				if (strFile != null && File.Exists(strFile))
				{
					FileInfo fileInfo = new FileInfo(strFile);
					if (fileInfo.Length == 0L)
					{
						return null;
					}
					using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
					{
						byte[] array = new byte[fileStream.Length];
						fileStream.Read(array, 0, array.Length);
						fileStream.Close();
						return array;
					}
				}
				return null;
			}
			try
			{
				if (strFile != null && File.Exists(strFile))
				{
					FileInfo fileInfo = new FileInfo(strFile);
					if (fileInfo.Length != 0L)
					{
						using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
						{
							byte[] array = new byte[fileStream.Length];
							fileStream.Read(array, 0, array.Length);
							fileStream.Close();
							return array;
						}
					}
					return null;
				}
			}
			catch
			{
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       向文件保存二进制数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strFile">文件名</param>
		                                                                    /// <param name="byts">字节数组</param>
		                                                                    /// <returns>保存是否成功</returns>
		public static bool SaveBinaryFile(string strFile, byte[] byts)
		{
			try
			{
				if (strFile != null)
				{
					using (FileStream fileStream = new FileStream(strFile, FileMode.Create, FileAccess.Write))
					{
						fileStream.Write(byts, 0, byts.Length);
						fileStream.Close();
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定的文本编码格式读取一个文本文件的内容
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <param name="encoding">文本编码格式</param>
		                                                                    /// <returns>读取的文件内容</returns>
		public static string LoadTextFile(string strFileName, Encoding encoding)
		{
			int num = 12;
			if (strFileName == null)
			{
				throw new ArgumentNullException("strFileName");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (File.Exists(strFileName))
			{
				using (StreamReader streamReader = new StreamReader(strFileName, encoding))
				{
					return streamReader.ReadToEnd();
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定的文本编码格式将文本内容保存到文件中
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <param name="strText">文本内容</param>
		                                                                    /// <param name="encoding">文本编码格式</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool SaveTextFile(string strFileName, string strText, Encoding encoding)
		{
			int num = 14;
			if (strFileName == null)
			{
				throw new ArgumentNullException("strFileName");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (strText == null)
			{
				strText = "";
			}
			using (StreamWriter streamWriter = new StreamWriter(strFileName, append: false, encoding))
			{
				streamWriter.Write(strText);
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       使用GB2312编码格式读取一个文本文件的内容
		                                                                    ///       </summary>
		                                                                    /// <param name="strFile">文件名</param>
		                                                                    /// <returns>读取的文件内容，若文件不存在或发生错误则返回空引用</returns>
		public static string LoadAnsiFile(string strFile)
		{
			StreamReader streamReader = null;
			try
			{
				if (File.Exists(strFile))
				{
					streamReader = new StreamReader(strFile, Encoding.GetEncoding(936));
					string result = streamReader.ReadToEnd();
					streamReader.Close();
					return result;
				}
			}
			catch
			{
				streamReader?.Close();
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       使用GB2312编码格式保存字符串到一个文件中
		                                                                    ///       </summary>
		                                                                    /// <param name="strFile">文件名</param>
		                                                                    /// <param name="strText">字符串数据</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool SaveAnsiFile(string strFile, string strText)
		{
			using (StreamWriter streamWriter = new StreamWriter(strFile, append: false, Encoding.GetEncoding(936)))
			{
				streamWriter.Write(strText);
				streamWriter.Close();
				return true;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       使用UTF8编码格式保存文本到一个文件中
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <param name="strText">文本内容</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool SaveUTF8File(string strFileName, string strText)
		{
			using (StreamWriter streamWriter = new StreamWriter(strFileName, append: false, Encoding.UTF8))
			{
				streamWriter.Write(strText);
				streamWriter.Close();
				return true;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定编码格式从一个文本文件中读取所有行的文本内容
		                                                                    ///       </summary>
		                                                                    /// <param name="strFile">文件名</param>
		                                                                    /// <param name="myEncoding">编码格式对象</param>
		                                                                    /// <returns>读取的文本行组成的字符串数组</returns>
		public static string[] ReadLines(string strFile, Encoding myEncoding)
		{
			using (StreamReader streamReader = new StreamReader(strFile, myEncoding))
			{
				ArrayList arrayList = new ArrayList();
				for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
				{
					arrayList.Add(text);
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定编码向一个文件写入多行文本数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strFile">文件名</param>
		                                                                    /// <param name="myEncoding">编码格式对象</param>
		                                                                    /// <param name="strLines">保存多行文本数据的字符串数组</param>
		public static void SaveLines(string strFile, Encoding myEncoding, string[] strLines)
		{
			using (StreamWriter streamWriter = new StreamWriter(strFile, append: false, myEncoding))
			{
				foreach (string value in strLines)
				{
					streamWriter.WriteLine(value);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       检测文件名是否是合法的文件名
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名字符串</param>
		                                                                    /// <returns>文件名是否合法</returns>
		public static bool CheckFileNameInValidChar(string strFileName)
		{
			int num = 18;
			if (strFileName == null || strFileName.Length == 0 || strFileName.Length > 255)
			{
				return false;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < strFileName.Length)
				{
					char value = strFileName[num2];
					if ("\\/:*?\"<>|".IndexOf(value) >= 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       修整文件名
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">原始文件名</param>
		                                                                    /// <param name="InvalidReplaceChar">替换掉错误字符的字符</param>
		                                                                    /// <returns>修整后的文件名</returns>
		public static string FixFileName(string strFileName, char InvalidReplaceChar)
		{
			int num = 16;
			if (strFileName == null || strFileName.Length == 0)
			{
				return strFileName;
			}
			if ("\\/:*?\"<>|#".IndexOf(InvalidReplaceChar) >= 0)
			{
				throw new ArgumentNullException("InvalidReplaceChar");
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in strFileName)
			{
				if ("\\/:*?\"<>|#".IndexOf(value) >= 0)
				{
					if (InvalidReplaceChar > '\0')
					{
						stringBuilder.Append(InvalidReplaceChar);
					}
				}
				else
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       获得文件名的大写形式的扩展名,若没有扩展名则返回空引用
		                                                                    ///       </summary>
		                                                                    /// <remarks>文件扩展名就是文件名字符串中最后一个斜杠字符(包括/\)
		                                                                    ///       后面最后一个点号后面的部分</remarks>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <returns>文件扩展名</returns>
		public static string GetExtension(string strFileName)
		{
			int num = 13;
			if (strFileName != null && strFileName.Length > 0)
			{
				int num2 = strFileName.LastIndexOf('.');
				int num3 = strFileName.LastIndexOfAny("/\\".ToCharArray());
				if (num2 >= 0 && num2 > num3)
				{
					string text = strFileName.Substring(num2 + 1).Trim().ToUpper();
					if (text.Length > 0)
					{
						return text;
					}
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       修正文件夹字符串,保证字符串以文件夹分隔符结尾
		                                                                    ///       </summary>
		                                                                    /// <param name="strDir">文件夹字符串</param>
		                                                                    /// <returns>修正后的字符串</returns>
		public static string FixDirectoryName(string strDir)
		{
			if (strDir != null && strDir.Length > 0 && strDir[strDir.Length - 1] != Path.DirectorySeparatorChar)
			{
				strDir += Path.DirectorySeparatorChar;
			}
			return strDir;
		}

		                                                                    /// <summary>
		                                                                    ///       获得没有目录和扩展名的简单文件名
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径名</param>
		                                                                    /// <returns>简单文件名</returns>
		public static string GetSimpleName(string strPath)
		{
			string fileName = Path.GetFileName(strPath);
			int num = fileName.LastIndexOf('.');
			if (num >= 0)
			{
				return fileName.Substring(0, num);
			}
			return fileName;
		}

		                                                                    /// <summary>
		                                                                    ///       进行文件通配符的判断,支持任意个*和?,字符串匹配不区分大小写
		                                                                    ///       </summary>
		                                                                    /// <remarks>本函数调用了 SplitAny 函数</remarks>
		                                                                    /// <param name="FileName">文件名</param>
		                                                                    /// <param name="MatchPattern">包含通配符的字符串</param>
		                                                                    /// <returns>文件名是否匹配通配符字符串</returns>
		public static bool MatchFileName(string FileName, string MatchPattern)
		{
			int num = 11;
			if (FileName == null || FileName.Length == 0)
			{
				return false;
			}
			if (FileName != null)
			{
				FileName = Path.GetFileName(FileName);
				FileName = FileName.ToUpper();
			}
			if (MatchPattern != null)
			{
				MatchPattern = MatchPattern.ToUpper();
			}
			string[] array = SplitAny(MatchPattern, "*?");
			if (array != null)
			{
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					if (num3 < array.Length)
					{
						string text = array[num3];
						if (text == "*")
						{
							if (num3 == array.Length - 1)
							{
								return true;
							}
							num2 = FileName.IndexOf(array[num3 + 1], num2);
							if (num2 < 0)
							{
								return false;
							}
						}
						else if (text == "?")
						{
							num2++;
						}
						else
						{
							if (FileName.Length < num2 + text.Length || FileName.Substring(num2, text.Length) != text)
							{
								break;
							}
							num2 += text.Length;
						}
						num3++;
						continue;
					}
					return FileName.Length == num2;
				}
				return false;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       将一个流中的所有的数据输出到另一个流中
		                                                                    ///       </summary>
		                                                                    /// <param name="stream1">输出流</param>
		                                                                    /// <param name="stream2">输入流</param>
		                                                                    /// <returns>操作的字节数</returns>
		private static int CopyStream(Stream stream1, Stream stream2)
		{
			byte[] array;
			if (stream1 is MemoryStream)
			{
				MemoryStream memoryStream = (MemoryStream)stream1;
				array = memoryStream.ToArray();
				stream2.Write(array, 0, array.Length);
				return array.Length;
			}
			array = new byte[8192];
			int num = 0;
			while (true)
			{
				int num2 = stream1.Read(array, 0, array.Length);
				if (num2 <= 0)
				{
					break;
				}
				stream2.Write(array, 0, num2);
				num += num2;
			}
			return num;
		}

		                                                                    /// <summary>
		                                                                    ///       依据若干个分隔字符将一个字符串分隔为若干部分,分隔的部分包括分隔字符
		                                                                    ///       </summary>
		                                                                    /// <remarks>例如字符串"abc*def?hk",若分隔字符为"*?",
		                                                                    ///       则本函数处理返回的字符串数组为 "abc" , "*" , "def" ,
		                                                                    ///        "?" , "hk"</remarks>
		                                                                    /// <param name="strText">要处理的字符串</param>
		                                                                    /// <param name="Spliter">分隔字符组成的字符串</param>
		                                                                    /// <returns>分隔后的字符串数组</returns>
		private static string[] SplitAny(string strText, string Spliter)
		{
			if (strText == null || strText.Length == 0 || Spliter == null || Spliter.Length == 0)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			int num = 0;
			for (int i = 0; i < strText.Length; i++)
			{
				if (Spliter.IndexOf(strText[i]) >= 0)
				{
					if (i > num)
					{
						arrayList.Add(strText.Substring(num, i - num));
					}
					arrayList.Add(strText.Substring(i, 1));
					num = i + 1;
				}
			}
			if (num < strText.Length)
			{
				arrayList.Add(strText.Substring(num));
			}
			if (arrayList.Count > 0)
			{
				return (string[])arrayList.ToArray(typeof(string));
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       比较两个字符串是否相等
		                                                                    ///       </summary>
		                                                                    /// <param name="s1">
		                                                                    /// </param>
		                                                                    /// <param name="s2">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		private static bool EqualString(string string_0, string string_1)
		{
			if (string_0 == null && string_1 == null)
			{
				return true;
			}
			if (string_0 != null && string_1 != null)
			{
				return string_0 == string_1;
			}
			return false;
		}

		private static void InnerSearchFiles(string SearchPath, string SearchPattern, ArrayList list, bool Deeply)
		{
			int num = 7;
			string[] files = Directory.GetFiles(SearchPath, SearchPattern);
			string[] array;
			if (files != null)
			{
				array = files;
				foreach (string text in array)
				{
					if (text != "." || text != "..")
					{
						list.Add(text);
					}
				}
			}
			if (!Deeply)
			{
				return;
			}
			string[] directories = Directory.GetDirectories(SearchPath);
			if (directories == null)
			{
				return;
			}
			array = directories;
			foreach (string text2 in array)
			{
				if (text2 != "." || text2 != "..")
				{
					InnerSearchFiles(text2, SearchPattern, list, Deeply: true);
				}
			}
		}

		[DllImport("kernel32.dll")]
		private static extern uint GetLongPathName(string shortPath, StringBuilder buffer, uint bufLength);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern uint GetShortPathName(string longPath, StringBuilder buffer, uint bufLength);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern int GetLongPathName(string ShortPath, string LongPath, int Buffer);

		[DllImport("shlwapi.dll")]
		private static extern int StrFormatByteSizeA(int int_0, byte[] byte_0, int bufSize);

		[DllImport("shlwapi.dll")]
		private static extern int StrFormatByteSize64(long long_0, byte[] byte_0, int bufSize);

		                                                                    /// <summary>
		                                                                    ///       不对象不可实例化
		                                                                    ///       </summary>
		private FileHelper()
		{
		}
	}
}
