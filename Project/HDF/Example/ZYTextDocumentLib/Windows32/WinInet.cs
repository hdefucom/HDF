using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Windows32
{
	public class WinInet : IDisposable
	{
		public const int INTERNET_FLAG_RAW_DATA = 1073741824;

		public const int INTERNET_FLAG_EXISTING_CONNECT = 536870912;

		public const int INTERNET_FLAG_ASYNC = 268435456;

		public const int INTERNET_FLAG_PASSIVE = 134217728;

		public const int INTERNET_FLAG_NO_CACHE_WRITE = 67108864;

		public const int INTERNET_FLAG_DONT_CACHE = 67108864;

		public const int INTERNET_FLAG_MAKE_PERSISTENT = 33554432;

		public const int INTERNET_FLAG_FROM_CACHE = 16777216;

		public const int INTERNET_FLAG_OFFLINE = 16777216;

		public const int INTERNET_FLAG_SECURE = 8388608;

		public const int INTERNET_FLAG_KEEP_CONNECTION = 4194304;

		public const int INTERNET_FLAG_NO_AUTO_REDIRECT = 2097152;

		public const int INTERNET_FLAG_READ_PREFETCH = 1048576;

		public const int INTERNET_FLAG_NO_COOKIES = 524288;

		public const int INTERNET_FLAG_NO_AUTH = 262144;

		public const int INTERNET_FLAG_CACHE_IF_NET_FAIL = 65536;

		public const int INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP = 32768;

		public const int INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS = 16384;

		public const int INTERNET_FLAG_IGNORE_CERT_DATE_INVALID = 8192;

		public const int INTERNET_FLAG_IGNORE_CERT_CN_INVALID = 4096;

		public const int INTERNET_FLAG_RESYNCHRONIZE = 2048;

		public const int INTERNET_FLAG_HYPERLINK = 1024;

		public const int INTERNET_FLAG_NO_UI = 512;

		public const int INTERNET_FLAG_PRAGMA_NOCACHE = 256;

		public const int INTERNET_FLAG_CACHE_ASYNC = 128;

		public const int INTERNET_FLAG_FORMS_SUBMIT = 64;

		public const int INTERNET_FLAG_NEED_FILE = 16;

		public const int INTERNET_FLAG_MUST_CACHE_REQUEST = 16;

		public const int HTTP_QUERY_MIME_VERSION = 0;

		public const int HTTP_QUERY_CONTENT_TYPE = 1;

		public const int HTTP_QUERY_CONTENT_TRANSFER_ENCODING = 2;

		public const int HTTP_QUERY_CONTENT_ID = 3;

		public const int HTTP_QUERY_CONTENT_DESCRIPTION = 4;

		public const int HTTP_QUERY_CONTENT_LENGTH = 5;

		public const int HTTP_QUERY_CONTENT_LANGUAGE = 6;

		public const int HTTP_QUERY_ALLOW = 7;

		public const int HTTP_QUERY_PUBLIC = 8;

		public const int HTTP_QUERY_DATE = 9;

		public const int HTTP_QUERY_EXPIRES = 10;

		public const int HTTP_QUERY_LAST_MODIFIED = 11;

		public const int HTTP_QUERY_MESSAGE_ID = 12;

		public const int HTTP_QUERY_URI = 13;

		public const int HTTP_QUERY_DERIVED_FROM = 14;

		public const int HTTP_QUERY_COST = 15;

		public const int HTTP_QUERY_LINK = 16;

		public const int HTTP_QUERY_PRAGMA = 17;

		public const int HTTP_QUERY_VERSION = 18;

		public const int HTTP_QUERY_STATUS_CODE = 19;

		public const int HTTP_QUERY_STATUS_TEXT = 20;

		public const int HTTP_QUERY_RAW_HEADERS = 21;

		public const int HTTP_QUERY_RAW_HEADERS_CRLF = 22;

		public const int HTTP_QUERY_CONNECTION = 23;

		public const int HTTP_QUERY_ACCEPT = 24;

		public const int HTTP_QUERY_ACCEPT_CHARSET = 25;

		public const int HTTP_QUERY_ACCEPT_ENCODING = 26;

		public const int HTTP_QUERY_ACCEPT_LANGUAGE = 27;

		public const int HTTP_QUERY_AUTHORIZATION = 28;

		public const int HTTP_QUERY_CONTENT_ENCODING = 29;

		public const int HTTP_QUERY_FORWARDED = 30;

		public const int HTTP_QUERY_FROM = 31;

		public const int HTTP_QUERY_IF_MODIFIED_SINCE = 32;

		public const int HTTP_QUERY_LOCATION = 33;

		public const int HTTP_QUERY_ORIG_URI = 34;

		public const int HTTP_QUERY_REFERER = 35;

		public const int HTTP_QUERY_RETRY_AFTER = 36;

		public const int HTTP_QUERY_SERVER = 37;

		public const int HTTP_QUERY_TITLE = 38;

		public const int HTTP_QUERY_USER_AGENT = 39;

		public const int HTTP_QUERY_WWW_AUTHENTICATE = 40;

		public const int HTTP_QUERY_PROXY_AUTHENTICATE = 41;

		public const int HTTP_QUERY_ACCEPT_RANGES = 42;

		public const int HTTP_QUERY_SET_COOKIE = 43;

		public const int HTTP_QUERY_COOKIE = 44;

		public const int HTTP_QUERY_REQUEST_METHOD = 45;

		public const int HTTP_QUERY_REFRESH = 46;

		public const int HTTP_QUERY_CONTENT_DISPOSITION = 47;

		public const int HTTP_STATUS_CONTINUE = 100;

		public const int HTTP_STATUS_SWITCH_PROTOCOLS = 101;

		public const int HTTP_STATUS_OK = 200;

		public const int HTTP_STATUS_CREATED = 201;

		public const int HTTP_STATUS_ACCEPTED = 202;

		public const int HTTP_STATUS_PARTIAL = 203;

		public const int HTTP_STATUS_NO_CONTENT = 204;

		public const int HTTP_STATUS_RESET_CONTENT = 205;

		public const int HTTP_STATUS_PARTIAL_CONTENT = 206;

		public const int HTTP_STATUS_AMBIGUOUS = 300;

		public const int HTTP_STATUS_MOVED = 301;

		public const int HTTP_STATUS_REDIRECT = 302;

		public const int HTTP_STATUS_REDIRECT_METHOD = 303;

		public const int HTTP_STATUS_NOT_MODIFIED = 304;

		public const int HTTP_STATUS_USE_PROXY = 305;

		public const int HTTP_STATUS_REDIRECT_KEEP_VERB = 307;

		public const int HTTP_STATUS_BAD_REQUEST = 400;

		public const int HTTP_STATUS_DENIED = 401;

		public const int HTTP_STATUS_PAYMENT_REQ = 402;

		public const int HTTP_STATUS_FORBIDDEN = 403;

		public const int HTTP_STATUS_NOT_FOUND = 404;

		public const int HTTP_STATUS_BAD_METHOD = 405;

		public const int HTTP_STATUS_NONE_ACCEPTABLE = 406;

		public const int HTTP_STATUS_PROXY_AUTH_REQ = 407;

		public const int HTTP_STATUS_REQUEST_TIMEOUT = 408;

		public const int HTTP_STATUS_CONFLICT = 409;

		public const int HTTP_STATUS_GONE = 410;

		public const int HTTP_STATUS_LENGTH_REQUIRED = 411;

		public const int HTTP_STATUS_PRECOND_FAILED = 412;

		public const int HTTP_STATUS_REQUEST_TOO_LARGE = 413;

		public const int HTTP_STATUS_URI_TOO_LONG = 414;

		public const int HTTP_STATUS_UNSUPPORTED_MEDIA = 415;

		public const int HTTP_STATUS_SERVER_ERROR = 500;

		public const int HTTP_STATUS_NOT_SUPPORTED = 501;

		public const int HTTP_STATUS_BAD_GATEWAY = 502;

		public const int HTTP_STATUS_SERVICE_UNAVAIL = 503;

		public const int HTTP_STATUS_GATEWAY_TIMEOUT = 504;

		public const int HTTP_STATUS_VERSION_NOT_SUP = 505;

		public const uint INTERNET_FLAG_RELOAD = 2147483648u;

		public const uint HTTP_ADDREQ_INDEX_MASK = 65535u;

		public const uint HTTP_ADDREQ_FLAGS_MASK = 4294901760u;

		public const uint HTTP_ADDREQ_FLAG_ADD_IF_NEW = 268435456u;

		public const uint HTTP_ADDREQ_FLAG_ADD = 536870912u;

		public const uint HTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA = 1073741824u;

		public const uint HTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON = 16777216u;

		public const uint HTTP_ADDREQ_FLAG_COALESCE = 1073741824u;

		public const uint HTTP_ADDREQ_FLAG_REPLACE = 2147483648u;

		private string strURLString = null;

		private int hInternetHandle = 0;

		private string strCookies = null;

		private int iContentLength = 0;

		private int iReserveLength = 0;

		private NameValueCollection myHeads = new NameValueCollection();

		private Uri myUri = null;

		public bool ThrowException = true;

		public NameValueCollection Heads => myHeads;

		public Uri Uri => myUri;

		public int InternetHandle => hInternetHandle;

		public int ContentLength => iContentLength;

		public int ReserveLength => iReserveLength;

		public string URLString => strURLString;

		public event EventHandler Downloading = null;

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int InternetOpen(string sAgent, int lAccessType, string sProxyName, string sProxyBypass, uint lFlags);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int InternetOpenUrl(int hOpen, string sUrl, string sHeaders, int lLength, int lFlags, int lContext);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int HttpOpenRequest(long hInternetSession, string sVerb, string sObjectName, string sVersion, string sReferer, char[] sAcceptTypes, long lFlags, int lContext);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int InternetConnect(int iInternetSession, string sServerName, int iProxyProt, string sUserName, string sPassword, int iService, int lFlags, int iContext);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int HttpSendRequest(int hHttpRequest, string sHeaders, int lHeadersLength, byte[] sOptional, int lOptionalLength);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int InternetReadFile(int hFile, byte[] sBuffer, int lNumbytesToRead, ref int lNumberOfBytesRead);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int InternetCloseHandle(int iInet);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern int HttpAddRequestHeaders(int iHttpRequest, string sHeaders, int lHeadersLength, uint lModifiers);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern bool HttpQueryInfo(int hRequest, int iInfoLevel, byte[] Buffer, ref int BufferLength, int pwdIndex);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern bool InternetSetCookie(string strURL, string strCookieName, string strCookieData);

		[DllImport("wininet.dll", CharSet = CharSet.Auto)]
		public static extern bool InternetGetLastResponseInfo(ref int ErrorCode, byte[] Buffer, ref int BufferLength);

		public static string GetHttpErrorText()
		{
			byte[] array = new byte[4028];
			int BufferLength = array.Length;
			int ErrorCode = 0;
			if (InternetGetLastResponseInfo(ref ErrorCode, array, ref BufferLength))
			{
				char[] chars = Encoding.Unicode.GetChars(array, 0, BufferLength);
				return new string(chars);
			}
			return null;
		}

		public static string GetHttpErrorText(int intErrorCode)
		{
			string text = null;
			switch (intErrorCode)
			{
			case 12001:
				return "No more Internet handles can be allocated";
			case 12002:
				return "The operation timed out";
			case 12003:
				return "The server returned extended information";
			case 12004:
				return "An internal error occurred in the Microsoft Internet extensions";
			case 12005:
				return "The URL is invalid";
			case 12006:
				return "The URL does not use a recognized protocol";
			case 12007:
				return "The server name or address could not be resolved";
			case 12008:
				return "A protocol with the required capabilities was not found";
			case 12009:
				return "The option is invalid";
			case 12010:
				return "The length is incorrect for the option type";
			case 12011:
				return "The option value cannot be set";
			case 12012:
				return "Microsoft Internet Extension support has been shut down";
			case 12013:
				return "The user name was not allowed";
			case 12014:
				return "The password was not allowed";
			case 12015:
				return "The login request was denied";
			case 12106:
				return "The requested operation is invalid";
			case 12017:
				return "The operation has been canceled";
			case 12018:
				return "The supplied handle is the wrong type for the requested operation";
			case 12019:
				return "The handle is in the wrong state for the requested operation";
			case 12020:
				return "The request cannot be made on a Proxy session";
			case 12021:
				return "The registry value could not be found";
			case 12022:
				return "The registry parameter is incorrect";
			case 12023:
				return "Direct Internet access is not available";
			case 12024:
				return "No context value was supplied";
			case 12025:
				return "No status callback was supplied";
			case 12026:
				return "There are outstanding requests";
			case 12027:
				return "The information format is incorrect";
			case 12028:
				return "The requested item could not be found";
			case 12029:
				return "A connection with the server could not be established";
			case 12030:
				return "The connection with the server was terminated abnormally";
			case 12031:
				return "The connection with the server was reset";
			case 12032:
				return "The action must be retried";
			case 12033:
				return "The proxy request is invalid";
			case 12034:
				return "User interaction is required to complete the operation";
			case 12036:
				return "The handle already exists";
			case 12037:
				return "The date in the certificate is invalid or has expired";
			case 12038:
				return "The host name in the certificate is invalid or does not match";
			case 12039:
				return "A redirect request will change a non-secure to a secure connection";
			case 12040:
				return "A redirect request will change a secure to a non-secure connection";
			case 12041:
				return "Mixed secure and non-secure connections";
			case 12042:
				return "Changing to non-secure post";
			case 12043:
				return "Data is being posted on a non-secure connection";
			case 12044:
				return "A certificate is required to complete client authentication";
			case 12045:
				return "The certificate authority is invalid or incorrect";
			case 12046:
				return "Client authentication has not been correctly installed";
			case 12047:
				return "An error has occurred in a Wininet asynchronous thread. You may need to restart";
			case 12048:
				return "The protocol scheme has changed during a redirect operaiton";
			case 12049:
				return "There are operations awaiting retry";
			case 12050:
				return "The operation must be retried";
			case 12051:
				return "There are no new cache containers";
			case 12052:
				return "A security zone check indicates the operation must be retried";
			case 12157:
				return "An error occurred in the secure channel support";
			case 12158:
				return "The file could not be written to the cache";
			case 12159:
				return "The TCP/IP protocol is not installed properly";
			case 12163:
				return "The computer is disconnected from the network";
			case 12164:
				return "The server is unreachable";
			case 12165:
				return "The proxy server is unreachable";
			case 12166:
				return "The proxy auto-configuration script is in error";
			case 12167:
				return "Could not download the proxy auto-configuration script file";
			case 12169:
				return "The supplied certificate is invalid";
			case 12170:
				return "The supplied certificate has been revoked";
			case 12171:
				return "The Dialup failed because file sharing was turned on and a failure was requested if security check was needed";
			case 12110:
				return "There is already an FTP request in progress on this session";
			case 12111:
				return "The FTP session was terminated";
			case 12112:
				return "FTP Passive mode is not available";
			case 12130:
				return "A gopher protocol error occurred";
			case 12131:
				return "The locator must be for a file";
			case 12132:
				return "An error was detected while parsing the data";
			case 12133:
				return "There is no more data";
			case 12134:
				return "The locator is invalid";
			case 12135:
				return "The locator type is incorrect for this operation";
			case 12136:
				return "The request must be for a gopher+ item";
			case 12137:
				return "The requested attribute was not found";
			case 12138:
				return "The locator type is not recognized";
			case 12150:
				return "The requested header was not found";
			case 12151:
				return "The server does not support the requested protocol level";
			case 12152:
				return "The server returned an invalid or unrecognized response";
			case 12153:
				return "The supplied HTTP header is invalid";
			case 12154:
				return "The request for a HTTP header is invalid";
			case 12155:
				return "The HTTP header already exists";
			case 12156:
				return "The HTTP redirect request failed";
			case 12160:
				return "The HTTP request was not redirected";
			case 12161:
				return "A cookie from the server must be confirmed by the user";
			case 12162:
				return "A cookie from the server has been declined acceptance";
			case 12168:
				return "The HTTP redirect request must be confirmed by the user";
			default:
				return "not Support ErrorCode ";
			}
		}

		public static string GetHttpStatus(int InfoLevel, int hRequest)
		{
			byte[] array = new byte[1024];
			int BufferLength = array.Length;
			HttpQueryInfo(hRequest, InfoLevel, array, ref BufferLength, 0);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < BufferLength; i++)
			{
				if (array[i] > 0)
				{
					stringBuilder.Append((char)array[i]);
				}
			}
			return stringBuilder.ToString();
		}

		public static bool IsHttpStatusOK(int hRequest)
		{
			return GetHttpStatus(19, hRequest) == "200";
		}

		public static byte[] GetBytesFromPost(string strURL, byte[] bytFormData)
		{
			string text = "Content-Type: application/x-www-form-urlencoded";
			string text2 = "Accept: */*";
			byte[] result = null;
			Uri uri = new Uri(strURL);
			int num = InternetOpen("htinc", 0, null, null, 2147483648u);
			if (num != 0)
			{
				int num2 = InternetConnect(num, uri.Host, uri.Port, null, null, 3, 0, 0);
				if (num2 != 0)
				{
					char[] array = text2.ToCharArray();
					string text3 = uri.AbsolutePath + "\0";
					byte[] bytes = Encoding.GetEncoding(936).GetBytes(text3);
					int num3 = HttpOpenRequest(num2, text3, "POST\0", null, null, null, 0L, 1);
					if (num3 != 0)
					{
						if (HttpSendRequest(num3, text, text.Length, bytFormData, bytFormData.Length) != 0 && IsHttpStatusOK(num3))
						{
							MemoryStream memoryStream = new MemoryStream();
							byte[] array2 = new byte[2048];
							int lNumberOfBytesRead = 0;
							while (true)
							{
								bool flag = true;
								int num4 = InternetReadFile(num3, array2, 2048, ref lNumberOfBytesRead);
								if (lNumberOfBytesRead > 0 && num4 != 0)
								{
									memoryStream.Write(array2, 0, lNumberOfBytesRead);
									continue;
								}
								break;
							}
							result = memoryStream.ToArray();
							memoryStream.Close();
						}
						InternetCloseHandle(num3);
					}
					InternetCloseHandle(num2);
				}
				InternetCloseHandle(num);
			}
			return result;
		}

		public bool SetCookie(string strName, string strValue)
		{
			return InternetSetCookie(myUri.AbsoluteUri, strName, strValue);
		}

		public void Open(string strURL)
		{
			Close();
			myUri = new Uri(strURL);
			hInternetHandle = InternetOpen("htinc", 0, null, null, 2147483648u);
			myHeads.Set("Host", myUri.Host + ":" + myUri.Port);
		}

		public void Close()
		{
			if (hInternetHandle != 0)
			{
				InternetCloseHandle(hInternetHandle);
				hInternetHandle = 0;
			}
		}

		public byte[] PostData(byte[] bytPostData)
		{
			bool CancelFlag = false;
			return PostData(bytPostData, ref CancelFlag);
		}

		public byte[] PostData(byte[] bytPostData, ref bool CancelFlag)
		{
			iReserveLength = 0;
			iContentLength = 0;
			byte[] result = null;
			Win32APIException ex = null;
			if (CancelFlag)
			{
				return null;
			}
			if (hInternetHandle == 0)
			{
				hInternetHandle = InternetOpen("htinc", 0, null, null, 2147483648u);
			}
			if (CancelFlag)
			{
				return null;
			}
			if (hInternetHandle != 0)
			{
				int num = InternetConnect(hInternetHandle, myUri.Host, myUri.Port, null, null, 3, 0, 0);
				if (CancelFlag)
				{
					InternetCloseHandle(num);
					return null;
				}
				if (num != 0)
				{
					string sVerb = myUri.AbsolutePath + "\0";
					int num2 = HttpOpenRequest(num, sVerb, "POST\0", null, null, null, 0L, 1);
					if (CancelFlag)
					{
						InternetCloseHandle(num2);
						InternetCloseHandle(num);
						return null;
					}
					if (num2 != 0)
					{
						StringBuilder stringBuilder = new StringBuilder();
						if (myHeads.Count > 0)
						{
							for (int i = 0; i < myHeads.Count; i++)
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append("\r\n");
								}
								stringBuilder.Append(myHeads.Keys[i]);
								stringBuilder.Append(": ");
								stringBuilder.Append(myHeads[i]);
							}
						}
						string text = stringBuilder.ToString();
						HttpAddRequestHeaders(num2, text, text.Length, 2147483648u);
						int num3 = HttpSendRequest(num2, null, 0, bytPostData, bytPostData.Length);
						if (CancelFlag)
						{
							InternetCloseHandle(num2);
							InternetCloseHandle(num);
							return null;
						}
						if (num3 != 0 && IsHttpStatusOK(num2))
						{
							strCookies = GetHttpStatus(43, num2);
							string httpStatus = GetHttpStatus(5, num2);
							try
							{
								if (httpStatus != null && httpStatus.Trim().Length > 0)
								{
									iContentLength = Convert.ToInt32(httpStatus);
								}
							}
							catch
							{
							}
							MemoryStream memoryStream = new MemoryStream();
							byte[] array = new byte[16384];
							int lNumberOfBytesRead = 0;
							while (!CancelFlag)
							{
								int num4 = InternetReadFile(num2, array, array.Length, ref lNumberOfBytesRead);
								if (lNumberOfBytesRead > 0 && num4 != 0)
								{
									memoryStream.Write(array, 0, lNumberOfBytesRead);
									iReserveLength += lNumberOfBytesRead;
								}
								else if ((num4 != 0 && lNumberOfBytesRead == 0) || num4 == 0)
								{
									break;
								}
								if (this.Downloading != null)
								{
									this.Downloading(this, null);
								}
							}
							result = memoryStream.ToArray();
							memoryStream.Close();
						}
						InternetCloseHandle(num2);
					}
					else if (ThrowException)
					{
						ex = new Win32APIException("HttpOpenRequest", num2);
						ex.ErrorMsg = GetHttpErrorText();
						InternetCloseHandle(num);
						throw ex;
					}
					InternetCloseHandle(num);
				}
				else if (ThrowException)
				{
					ex = new Win32APIException("InternetConnect", num);
					ex.ErrorMsg = GetHttpErrorText();
					throw ex;
				}
			}
			else if (ThrowException)
			{
				ex = new Win32APIException("InternetOpen", hInternetHandle);
				ex.ErrorMsg = GetHttpErrorText();
				throw ex;
			}
			return result;
		}

		public void Dispose()
		{
			if (hInternetHandle != 0)
			{
				InternetCloseHandle(hInternetHandle);
				hInternetHandle = 0;
			}
		}
	}
}
