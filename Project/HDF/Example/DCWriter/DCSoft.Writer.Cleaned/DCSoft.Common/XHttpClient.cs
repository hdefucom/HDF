using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       HTTP客户端模块
	                                                                    ///       </summary>
	                                                                    /// <remarks>本模块用于执行HTTP客户端的处理，本模块需要依赖 XDesignerHTMLDom 库。
	                                                                    ///       编制 袁永福 2006-5-16</remarks>
	[ComVisible(false)]
	public class XHttpClient
	{
		                                                                    /// <summary>
		                                                                    ///       HTTP错误事件类型
		                                                                    ///       </summary>
		[ComVisible(false)]
		public delegate void HttpExceptionHandler(XHttpClient sender, Exception exception);

		                                                                    /// <summary>
		                                                                    ///       简单的字节数据缓冲区
		                                                                    ///       </summary>
		protected class SimpleByteBuffer
		{
			protected int intCount = 0;

			protected byte[] bsBuffer = new byte[10];

			                                                                    /// <summary>
			                                                                    ///       已经保存的字节数
			                                                                    ///       </summary>
			public virtual int Count => intCount;

			                                                                    /// <summary>
			                                                                    ///       添加一个字节
			                                                                    ///       </summary>
			                                                                    /// <param name="b">字节数据</param>
			public void Add(byte byte_0)
			{
				lock (this)
				{
					FixBuffer(intCount + 1);
					bsBuffer[intCount] = byte_0;
					intCount++;
				}
			}

			                                                                    /// <summary>
			                                                                    ///       添加字节数组
			                                                                    ///       </summary>
			                                                                    /// <param name="bs">字节数组</param>
			public void Add(byte[] byte_0)
			{
				if (byte_0 != null)
				{
					Add(byte_0, 0, byte_0.Length);
				}
			}

			                                                                    /// <summary>
			                                                                    ///       添加字节数组
			                                                                    ///       </summary>
			                                                                    /// <param name="bs">字节数组</param>
			                                                                    /// <param name="StartIndex">开始添加的序号</param>
			                                                                    /// <param name="Length">添加的长度</param>
			public void Add(byte[] byte_0, int StartIndex, int Length)
			{
				if (byte_0 != null && StartIndex >= 0 && StartIndex + Length <= byte_0.Length && Length > 0)
				{
					lock (this)
					{
						FixBuffer(intCount + Length);
						Array.Copy(byte_0, StartIndex, bsBuffer, intCount, Length);
						intCount += Length;
					}
				}
			}

			                                                                    /// <summary>
			                                                                    ///       清空对象数据
			                                                                    ///       </summary>
			public virtual void Clear()
			{
				lock (this)
				{
					bsBuffer = new byte[10];
					intCount = 0;
				}
			}

			                                                                    /// <summary>
			                                                                    ///       将保存的数据转换为字节数组
			                                                                    ///       </summary>
			                                                                    /// <returns>字节数组</returns>
			public byte[] ToArray()
			{
				lock (this)
				{
					if (intCount > 0)
					{
						byte[] array = new byte[intCount];
						Array.Copy(bsBuffer, 0, array, 0, intCount);
						return array;
					}
					return null;
				}
			}

			                                                                    /// <summary>
			                                                                    ///       返回一部分数据
			                                                                    ///       </summary>
			                                                                    /// <param name="StartIndex">返回数据的开始位置</param>
			                                                                    /// <param name="Length">数据长度</param>
			                                                                    /// <returns>字节数组</returns>
			public byte[] ToArray(int StartIndex, int Length)
			{
				if (StartIndex < 0 || Length <= 0)
				{
					return null;
				}
				lock (this)
				{
					if (!CheckRange(StartIndex, Length))
					{
						return null;
					}
					byte[] array = new byte[Length];
					Array.Copy(bsBuffer, StartIndex, array, 0, Length);
					return array;
				}
			}

			public bool CheckRange(int StartIndex, int Length)
			{
				if (StartIndex < 0 || Length <= 0)
				{
					return false;
				}
				if (StartIndex + Length > intCount)
				{
					return false;
				}
				return true;
			}

			protected void FixBuffer(int NewSize)
			{
				if (NewSize > bsBuffer.Length)
				{
					if (NewSize < (int)((double)bsBuffer.Length * 1.5))
					{
						NewSize = (int)((double)bsBuffer.Length * 1.5);
					}
					byte[] destinationArray = new byte[NewSize];
					Array.Copy(bsBuffer, 0, destinationArray, 0, bsBuffer.Length);
					bsBuffer = destinationArray;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象额外的数据
		                                                                    ///       </summary>
		[NonSerialized]
		protected object objTag = null;

		                                                                    /// <summary>
		                                                                    ///       是否使用IE的cookie数据
		                                                                    ///       </summary>
		protected bool bolUseIECookie = true;

		                                                                    /// <summary>
		                                                                    ///       每次发送或接收数据块的大小
		                                                                    ///       </summary>
		protected int intBlockSize = 512;

		                                                                    /// <summary>
		                                                                    ///       当前操作的URL的前缀，可以为 http:                                                                    // 或 https:                                                                    //
		                                                                    ///       </summary>
		protected string strPrefix = null;

		                                                                    /// <summary>
		                                                                    ///       是否锁定基础URL,若锁定则程序内部不会修改基础URL地址
		                                                                    ///       </summary>
		protected bool bolLockBaseURL = false;

		                                                                    /// <summary>
		                                                                    ///       基础URL地址
		                                                                    ///       </summary>
		protected string strBaseURL = null;

		                                                                    /// <summary>
		                                                                    ///       当前处理的URL字符串
		                                                                    ///       </summary>
		protected string strURLString = null;

		                                                                    /// <summary>
		                                                                    ///       下载的数据的建议文件名
		                                                                    ///       </summary>
		protected string strSujestFileName = null;

		                                                                    /// <summary>
		                                                                    ///       最后一次操作时服务器返回的状态字符串
		                                                                    ///       </summary>
		protected string strStatusDescription = "OK";

		                                                                    /// <summary>
		                                                                    ///       最后一次操作时服务器返回的状态码
		                                                                    ///       </summary>
		protected HttpStatusCode intStatusCode = HttpStatusCode.OK;

		                                                                    /// <summary>
		                                                                    ///       数据长度
		                                                                    ///       </summary>
		protected int intContentLength = 0;

		                                                                    /// <summary>
		                                                                    ///       完成的数据长度
		                                                                    ///       </summary>
		protected int intCompletedLength = 0;

		                                                                    /// <summary>
		                                                                    ///       数据类型
		                                                                    ///       </summary>
		protected string strContentType = null;

		                                                                    /// <summary>
		                                                                    ///       文本编码格式
		                                                                    ///       </summary>
		protected string strContentEncoding = null;

		                                                                    /// <summary>
		                                                                    ///       HTTP请求头信息
		                                                                    ///       </summary>
		protected NameValueCollection myHeaders = new NameValueCollection();

		                                                                    /// <summary>
		                                                                    ///       内部的保留Cookie的容器对象
		                                                                    ///       </summary>
		protected CookieContainer myCookieContainer = null;

		                                                                    /// <summary>
		                                                                    ///       取消当前操作标记
		                                                                    ///       </summary>
		protected bool bolCancelFlag = false;

		                                                                    /// <summary>
		                                                                    ///       IE的HTTP角色
		                                                                    ///       </summary>
		public static string IEAgent
		{
			get
			{
				int num = 14;
				string result = null;
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");
				if (registryKey != null)
				{
					result = Convert.ToString(registryKey.GetValue("User Agent"));
					registryKey.Close();
				}
				return result;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象额外的数据
		                                                                    ///       </summary>
		public object Tag
		{
			get
			{
				return objTag;
			}
			set
			{
				objTag = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否使用IE的cookie数据
		                                                                    ///       </summary>
		public bool UseIECookie
		{
			get
			{
				return bolUseIECookie;
			}
			set
			{
				bolUseIECookie = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       每次发送或接收数据块的大小
		                                                                    ///       </summary>
		public int BlockSize
		{
			get
			{
				return intBlockSize;
			}
			set
			{
				intBlockSize = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       当前操作的URL的前缀，可以为 http:                                                                    // 或 https:                                                                    //
		                                                                    ///       </summary>
		public string Prefix => strPrefix;

		                                                                    /// <summary>
		                                                                    ///       是否锁定基础URL,若锁定则程序内部不会修改基础URL地址
		                                                                    ///       </summary>
		public bool LockBaseURL
		{
			get
			{
				return bolLockBaseURL;
			}
			set
			{
				bolLockBaseURL = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       基础URL地址
		                                                                    ///       </summary>
		public string BaseURL
		{
			get
			{
				return strBaseURL;
			}
			set
			{
				strBaseURL = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       当前处理的URL字符串
		                                                                    ///       </summary>
		public string URLString => strURLString;

		                                                                    /// <summary>
		                                                                    ///       下载的数据的建议文件名
		                                                                    ///       </summary>
		public string SujestFileName => strSujestFileName;

		                                                                    /// <summary>
		                                                                    ///       最后一次操作时服务器返回的状态字符串
		                                                                    ///       </summary>
		public string StatusDescription => strStatusDescription;

		                                                                    /// <summary>
		                                                                    ///       最后一次操作时服务器返回的状态码
		                                                                    ///       </summary>
		public HttpStatusCode StatusCode => intStatusCode;

		                                                                    /// <summary>
		                                                                    ///       Cookie 集合
		                                                                    ///       </summary>
		public CookieCollection Cookies
		{
			get
			{
				if (myCookieContainer == null)
				{
					return null;
				}
				return myCookieContainer.GetCookies(new Uri(strURLString));
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数据长度
		                                                                    ///       </summary>
		public int ContentLength => intContentLength;

		                                                                    /// <summary>
		                                                                    ///       完成的数据长度
		                                                                    ///       </summary>
		public int CompletedLength => intCompletedLength;

		                                                                    /// <summary>
		                                                                    ///       数据类型
		                                                                    ///       </summary>
		public string ContentType => strContentType;

		                                                                    /// <summary>
		                                                                    ///       文本编码格式
		                                                                    ///       </summary>
		public string ContentEncoding => strContentEncoding;

		public Encoding ContentEncodingObject
		{
			get
			{
				if (strContentEncoding == null || strContentEncoding.Length == 0)
				{
					return Encoding.GetEncoding(936);
				}
				try
				{
					return Encoding.GetEncoding(strContentEncoding);
				}
				catch
				{
					return Encoding.GetEncoding(936);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       HTTP请求头信息
		                                                                    ///       </summary>
		public NameValueCollection Headers => myHeaders;

		                                                                    /// <summary>
		                                                                    ///       发生错误事件
		                                                                    ///       </summary>
		public event HttpExceptionHandler HttpException = null;

		                                                                    /// <summary>
		                                                                    ///       开始进行处理事件
		                                                                    ///       </summary>
		public event EventHandler StartProcess = null;

		                                                                    /// <summary>
		                                                                    ///       正在发送数据的事件
		                                                                    ///       </summary>
		public event EventHandler SendData = null;

		                                                                    /// <summary>
		                                                                    ///       正在下载数据的事件
		                                                                    ///       </summary>
		public event EventHandler GetData = null;

		                                                                    /// <summary>
		                                                                    ///       操作完成事件
		                                                                    ///       </summary>
		public event EventHandler Completed = null;

		                                                                    /// <summary>
		                                                                    ///       获得本地计算机保存的指定URL地址的cookie数据字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strUrl">url字符串</param>
		                                                                    /// <returns>cookie字符串，若未找到则返回空字符串</returns>
		public static string GetIECookie(string strUrl)
		{
			string text = new string('\0', 2048);
			int BufferSize = text.Length;
			if (InternetGetCookie(strUrl, null, text, ref BufferSize))
			{
				int num = text.IndexOf('\0');
				if (num > 0)
				{
					return text.Substring(0, num);
				}
			}
			return "";
		}

		                                                                    /// <summary>
		                                                                    ///       解析URL字符串，获得其中建议的文件名
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">URL字符串</param>
		                                                                    /// <returns>文件名</returns>
		public static string GetFileName(string strURL)
		{
			string prefix = GetPrefix(strURL);
			if (prefix != null)
			{
				strURL = strURL.Substring(prefix.Length);
			}
			int num = strURL.LastIndexOf('/');
			if (num > 0)
			{
				string text = strURL.Substring(num + 1);
				num = text.IndexOf('?');
				if (num > 0)
				{
					text = text.Substring(0, num);
				}
				return text;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       允许保留COOKIE
		                                                                    ///       </summary>
		public void EnableCookieContainer()
		{
			if (myCookieContainer == null)
			{
				myCookieContainer = new CookieContainer();
				myCookieContainer.Add(new CookieCollection());
			}
		}

		                                                                    /// <summary>
		                                                                    ///       根据当前基础URL地址获得绝对URL地址
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">绝对或相对URL地址</param>
		                                                                    /// <returns>绝对URL地址</returns>
		public string GetAbsoluteURL(string strURL)
		{
			int num = 11;
			if (strURL == null)
			{
				return null;
			}
			if (GetPrefix(strURL) != null)
			{
				return CombineUrl(strURL);
			}
			if (strURL[0] == '/')
			{
				int length = strBaseURL.IndexOf("/", strPrefix.Length + 1);
				strURL = strBaseURL.Substring(0, length) + strURL;
				return strURL;
			}
			return CombineUrl(strBaseURL + strURL);
		}

		                                                                    /// <summary>
		                                                                    ///       取消当前操作
		                                                                    ///       </summary>
		public void Cancel()
		{
			bolCancelFlag = true;
		}

		                                                                    /// <summary>
		                                                                    ///       从指定URL下载一个XML文档
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">URL地址</param>
		                                                                    /// <returns>生成的XML文档对象</returns>
		public XmlDocument GetXMLDocument(string strURL)
		{
			byte[] array = Get(strURL);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			XmlDocument xmlDocument = null;
			using (MemoryStream memoryStream = new MemoryStream(array))
			{
				try
				{
					xmlDocument = new XmlDocument();
					xmlDocument.Load(memoryStream);
					memoryStream.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
			return xmlDocument;
		}

		                                                                    /// <summary>
		                                                                    ///       从指定URL下载一个字符串数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">URL地址</param>
		                                                                    /// <param name="myEncoding">字符编码器</param>
		                                                                    /// <returns>获得的字符串数据</returns>
		public string GetString(string strURL, Encoding myEncoding)
		{
			byte[] array = Get(strURL);
			if (array != null)
			{
				return myEncoding.GetString(array);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       从指定URL下载数据并生成一个图片对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">URL地址</param>
		                                                                    /// <returns>图片对象</returns>
		public Image GetImage(string strURL)
		{
			byte[] array = Get(strURL);
			if (array != null)
			{
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					Image result = Image.FromStream(memoryStream);
					memoryStream.Close();
					return result;
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       通过GET方法下载数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">数据URL</param>
		                                                                    /// <returns>获得的字节数组</returns>
		public byte[] Get(string strURL)
		{
			return InnerGet(strURL, 0, 0, null);
		}

		                                                                    /// <summary>
		                                                                    ///       使用GET方法下载数据并保存到指定的文件中
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">数据URL</param>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <returns>下载的字节数</returns>
		public int Get(string strURL, string strFileName)
		{
			using (FileStream outStream = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
			{
				InnerGet(strURL, 0, 0, outStream);
			}
			return intCompletedLength;
		}

		                                                                    /// <summary>
		                                                                    ///       使用GET方法下载数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">数据URL</param>
		                                                                    /// <param name="MaxLength">数据最大长度</param>
		                                                                    /// <param name="MinLength">数据最小长度</param>
		                                                                    /// <returns>下载的字节数</returns>
		public byte[] Get(string strURL, int MaxLength, int MinLength)
		{
			return InnerGet(strURL, MaxLength, MinLength, null);
		}

		                                                                    /// <summary>
		                                                                    ///       使用GET方法下载数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">数据URL</param>
		                                                                    /// <param name="MaxLength">数据最大长度</param>
		                                                                    /// <param name="MinLength">数据最小长度</param>
		                                                                    /// <param name="OutStream">保存数据的流</param>
		                                                                    /// <returns>下载的字节数</returns>
		public int Get(string strURL, int MaxLength, int MinLength, Stream OutStream)
		{
			InnerGet(strURL, MaxLength, MinLength, OutStream);
			return intCompletedLength;
		}

		                                                                    /// <summary>
		                                                                    ///       向指定的页面发送数据并返回响应数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">页面URL</param>
		                                                                    /// <param name="PostData">要发送的数据</param>
		                                                                    /// <returns>响应数据</returns>
		public byte[] Post(string strURL, byte[] PostData)
		{
			return InnerPost(strURL, PostData, 0, 0, null, GetResponseData: true);
		}

		                                                                    /// <summary>
		                                                                    ///       向指定页面发送指定文件内的数据并返回响应数据
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">页面URL</param>
		                                                                    /// <param name="strFileName">要发送的文件名</param>
		                                                                    /// <returns>响应数据</returns>
		public byte[] PostFile(string strURL, string strFileName)
		{
			new SimpleByteBuffer();
			byte[] array = null;
			using (FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
			{
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
			}
			return InnerPost(strURL, array, 0, 0, null, GetResponseData: true);
		}

		                                                                    /// <summary>
		                                                                    ///       向指定的页码发送数据并将响应的数据写到指定流中
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">页码URL</param>
		                                                                    /// <param name="PostData">要发送的数据</param>
		                                                                    /// <param name="OutStream">保存响应数据的流对象</param>
		                                                                    /// <returns>获得的数据字节数</returns>
		public int Post(string strURL, byte[] PostData, Stream OutStream)
		{
			InnerPost(strURL, PostData, 0, 0, OutStream, GetResponseData: true);
			return intCompletedLength;
		}

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		private static extern bool InternetSetCookie(string strURL, string strCookieName, string strCookieData);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		private static extern bool InternetGetCookie(string strURL, string strCookieName, string strCookieData, ref int BufferSize);

		                                                                    /// <summary>
		                                                                    ///       内部的通过POST方法发送和接收数据的函数
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">页码URL</param>
		                                                                    /// <param name="PostData">发送的数据</param>
		                                                                    /// <param name="MaxLength">接收数据的最大字节数</param>
		                                                                    /// <param name="MinLength">接收数据的最小字节数</param>
		                                                                    /// <param name="OutStream">保存响应数据的输出流</param>
		                                                                    /// <param name="GetResponseData">是否获得返回的数据</param>
		                                                                    /// <returns>响应获得的数据</returns>
		protected byte[] InnerPost(string strURL, byte[] PostData, int MaxLength, int MinLength, Stream OutStream, bool GetResponseData)
		{
			int num = 6;
			intContentLength = 0;
			intCompletedLength = 0;
			strSujestFileName = null;
			strContentEncoding = null;
			strContentType = null;
			strURLString = null;
			try
			{
				CheckURL(strURL);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				if (PostData != null)
				{
					httpWebRequest.ContentLength = PostData.Length;
				}
				PrepareRequest(httpWebRequest);
				bolCancelFlag = false;
				OnStartProcess();
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					if (PostData != null && PostData.Length > 0)
					{
						intContentLength = PostData.Length;
						intCompletedLength = 0;
						while (intCompletedLength < PostData.Length && !bolCancelFlag)
						{
							int num2 = 0;
							num2 = ((intCompletedLength + intBlockSize > PostData.Length) ? (PostData.Length - intCompletedLength) : intBlockSize);
							stream.Write(PostData, intCompletedLength, num2);
							intCompletedLength += num2;
							OnSendData();
						}
					}
					stream.Close();
				}
				OnCompleted();
				if (bolCancelFlag)
				{
					httpWebRequest.Abort();
					return null;
				}
				OnStartProcess();
				HttpWebResponse myRes = (HttpWebResponse)httpWebRequest.GetResponse();
				byte[] result = InnerRead(httpWebRequest, myRes, MaxLength, MinLength, OutStream, GetResponseData);
				httpWebRequest.Abort();
				OnCompleted();
				return result;
			}
			catch (Exception exception_)
			{
				OnHttpException(exception_);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       内部的通过GET方法获得数据的函数
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">页码URL地址</param>
		                                                                    /// <param name="MaxLength">最大能接收的字节数</param>
		                                                                    /// <param name="MinLength">最小能接收的字节数</param>
		                                                                    /// <param name="OutStream">保存数据的输出流</param>
		                                                                    /// <returns>获得的字节数据</returns>
		protected byte[] InnerGet(string strURL, int MaxLength, int MinLength, Stream OutStream)
		{
			int num = 14;
			intContentLength = 0;
			intCompletedLength = 0;
			strSujestFileName = null;
			strContentEncoding = null;
			strContentType = null;
			strURLString = null;
			try
			{
				CheckURL(strURL);
				OnStartProcess();
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
				httpWebRequest.Method = "GET";
				PrepareRequest(httpWebRequest);
				HttpWebResponse myRes = (HttpWebResponse)httpWebRequest.GetResponse();
				byte[] result = InnerRead(httpWebRequest, myRes, MaxLength, MinLength, OutStream, ReadData: true);
				OnCompleted();
				httpWebRequest.Abort();
				return result;
			}
			catch (Exception exception_)
			{
				OnHttpException(exception_);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       对HTTP请求对象进行预处理
		                                                                    ///       </summary>
		                                                                    /// <param name="myReq">HTTP请求对象</param>
		protected void PrepareRequest(HttpWebRequest myReq)
		{
			if (myCookieContainer != null)
			{
				myReq.CookieContainer = myCookieContainer;
			}
			myReq.UserAgent = IEAgent;
			myReq.Referer = strURLString;
			Uri uri = new Uri(strURLString);
			if (!bolUseIECookie)
			{
				return;
			}
			string iECookie = GetIECookie(strURLString);
			if (iECookie != null && iECookie.Length > 0)
			{
				NameValueCollection nameValueCollection = AnalyseString(iECookie);
				if (nameValueCollection.Count > 0)
				{
					foreach (string key in nameValueCollection.Keys)
					{
						Cookie cookie = new Cookie(key, nameValueCollection[key]);
						cookie.Expires = DateTime.Now.AddDays(1.0);
						if (myCookieContainer != null)
						{
							myCookieContainer.Add(uri, cookie);
						}
					}
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       内部的从HTTP响应中获得数据的函数
		                                                                    ///       </summary>
		                                                                    /// <param name="myReq">HTTP请求对象</param>
		                                                                    /// <param name="myRes">HTTP响应对象</param>
		                                                                    /// <param name="MaxLength">最大能接收的字节数</param>
		                                                                    /// <param name="MinLength">最小能接收的字节数</param>
		                                                                    /// <param name="OutStream">保存数据的输出流</param>
		                                                                    /// <param name="ReadData">是否读取数据</param>
		                                                                    /// <returns>读取的数据</returns>
		protected byte[] InnerRead(HttpWebRequest myReq, HttpWebResponse myRes, int MaxLength, int MinLength, Stream OutStream, bool ReadData)
		{
			int num = 7;
			intStatusCode = myRes.StatusCode;
			strStatusDescription = myRes.StatusDescription;
			bool flag = true;
			if (myRes.ContentLength > 0L)
			{
				if (MaxLength > 0 && myRes.ContentLength > MaxLength)
				{
					flag = false;
				}
				if (MinLength > 0 && myRes.ContentLength < MinLength)
				{
					flag = false;
				}
			}
			if (!flag)
			{
				myRes.Close();
				myReq.Abort();
				return null;
			}
			if (myRes.Headers != null)
			{
				myHeaders.Clear();
				foreach (string key in myRes.Headers.Keys)
				{
					string strText = myRes.Headers[key];
					if (string.Compare("Content-Disposition", key, ignoreCase: true) == 0)
					{
						NameValueCollection nameValueCollection = AnalyseString(strText);
						if (nameValueCollection != null)
						{
							string text2 = nameValueCollection["filename"];
							if (text2 != null && text2.Length > 0)
							{
								strSujestFileName = text2;
							}
						}
					}
					else if (string.Compare("Content-Location", key, ignoreCase: true) == 0 && strSujestFileName == null)
					{
						strSujestFileName = GetFileName(myRes.Headers[key]);
					}
				}
			}
			strContentType = myRes.ContentType;
			strContentEncoding = myRes.ContentEncoding;
			intContentLength = (int)myRes.ContentLength;
			if (ReadData)
			{
				Stream responseStream = myRes.GetResponseStream();
				SimpleByteBuffer simpleByteBuffer = null;
				if (OutStream == null)
				{
					simpleByteBuffer = new SimpleByteBuffer();
				}
				byte[] array = new byte[intBlockSize];
				bolCancelFlag = false;
				do
				{
					int num2 = responseStream.Read(array, 0, array.Length);
					if (num2 <= 0)
					{
						break;
					}
					if (OutStream != null)
					{
						OutStream.Write(array, 0, num2);
					}
					else
					{
						simpleByteBuffer.Add(array, 0, num2);
					}
					intCompletedLength += num2;
					if (MaxLength > 0 && intCompletedLength > MaxLength)
					{
						bolCancelFlag = true;
					}
					OnGetData();
				}
				while (!bolCancelFlag);
				byte[] result = null;
				if (!bolCancelFlag && simpleByteBuffer != null)
				{
					result = simpleByteBuffer.ToArray();
				}
				responseStream.Close();
				myRes.Close();
				return result;
			}
			myRes.Close();
			return null;
		}

		protected static string CombineUrl(string strURL)
		{
			int num = 4;
			strURL.IndexOf("                                                                    //");
			string prefix = GetPrefix(strURL);
			if (prefix != null)
			{
				strURL = strURL.Substring(prefix.Length);
			}
			string[] array = strURL.Split("/\\".ToCharArray());
			ArrayList arrayList = new ArrayList();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Trim().Length != 0)
				{
					arrayList.Add(text);
				}
			}
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ("..".Equals(arrayList[j]) && j > 0)
				{
					arrayList.RemoveAt(j);
					arrayList.RemoveAt(j - 1);
					j -= 2;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in arrayList)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("/");
				}
				stringBuilder.Append(item);
			}
			if (prefix != null)
			{
				stringBuilder.Insert(0, prefix);
			}
			return stringBuilder.ToString();
		}

		protected void CheckURL(string strURL)
		{
			int num = 10;
			if (strURL == null || strURL.Length == 0)
			{
				throw new ArgumentNullException("URL地址不得为空");
			}
			Uri uri = new Uri(strURL);
			strPrefix = uri.Scheme;
			if (uri.Scheme != Uri.UriSchemeHttp)
			{
				throw new ArgumentException("URL无效，必须以 http:                                                                    // 开头");
			}
			strURLString = strURL;
			string leftPart = uri.GetLeftPart(UriPartial.Path);
			int num2 = leftPart.LastIndexOfAny("\\/".ToCharArray());
			if (num2 >= 0)
			{
				if (!bolLockBaseURL)
				{
					strBaseURL = leftPart.Substring(0, num2 + 1);
				}
				strSujestFileName = leftPart.Substring(num2 + 1);
			}
			else if (!bolLockBaseURL)
			{
				strBaseURL = leftPart;
				strSujestFileName = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断字符串是否是支持的URL字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">URL字符串</param>
		                                                                    /// <returns>是否是支持的URL字符串</returns>
		public bool IsURL(string strURL)
		{
			return GetPrefix(strURL) != null;
		}

		protected static string GetPrefix(string strURL)
		{
			int num = 2;
			if (strURL == null)
			{
				return null;
			}
			string text = strURL.ToLower();
			if (text.StartsWith("http:                                                                    //"))
			{
				return "http:                                                                    //";
			}
			if (text.StartsWith("https:                                                                    //"))
			{
				return "https:                                                                    //";
			}
			return null;
		}

		protected void OnSendData()
		{
			if (this.SendData != null)
			{
				this.SendData(this, null);
			}
		}

		protected void OnGetData()
		{
			if (this.GetData != null)
			{
				this.GetData(this, null);
			}
		}

		protected void OnCompleted()
		{
			if (this.Completed != null)
			{
				this.Completed(this, null);
			}
		}

		protected void OnStartProcess()
		{
			if (this.StartProcess != null)
			{
				this.StartProcess(this, null);
			}
		}

		protected void OnHttpException(Exception exception_0)
		{
			if (this.HttpException == null)
			{
				throw exception_0;
			}
			this.HttpException(this, exception_0);
		}

		protected NameValueCollection AnalyseString(string strText)
		{
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			string[] array = strText.Split(';');
			NameValueCollection nameValueCollection = new NameValueCollection();
			string[] array2 = array;
			foreach (string text in array2)
			{
				int num = text.IndexOf('=');
				string text2 = null;
				string text3 = null;
				if (num > 0)
				{
					text2 = text.Substring(0, num);
					text3 = text.Substring(num + 1);
				}
				else
				{
					text2 = text;
					text3 = "";
				}
				text2 = text2.Trim();
				text3 = (nameValueCollection[text2] = text3.Trim());
			}
			return nameValueCollection;
		}
	}
}
