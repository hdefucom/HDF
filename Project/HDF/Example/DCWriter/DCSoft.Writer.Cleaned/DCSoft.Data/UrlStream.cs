using DCSoftDotfuscate;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       基于URL的文件流对象，可访问本地文件系统和WEB服务器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class UrlStream : Stream
	{
		private string string_0 = null;

		private Stream stream_0 = null;

		                                                                    /// <summary>
		                                                                    ///       是否能读
		                                                                    ///       </summary>
		public override bool CanRead => stream_0.CanRead;

		                                                                    /// <summary>
		                                                                    ///       是否能移动位置
		                                                                    ///       </summary>
		public override bool CanSeek => stream_0.CanSeek;

		                                                                    /// <summary>
		                                                                    ///       是否能写
		                                                                    ///       </summary>
		public override bool CanWrite => stream_0.CanWrite;

		                                                                    /// <summary>
		                                                                    ///       长度
		                                                                    ///       </summary>
		public override long Length => stream_0.Length;

		                                                                    /// <summary>
		                                                                    ///       当前位置
		                                                                    ///       </summary>
		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				stream_0.Position = value;
			}
		}

		public static UrlStream smethod_0(string string_1)
		{
			int num = 12;
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("url");
			}
			string_1 = string_1.Trim();
			if (string_1.Length == 0)
			{
				throw new ArgumentNullException("url");
			}
			string localPath;
			UrlStream urlStream;
			if (string_1.IndexOf(":") > 0)
			{
				Uri uri = new Uri(string_1);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					localPath = uri.LocalPath;
					if (!File.Exists(localPath))
					{
						throw new FileNotFoundException(localPath);
					}
					urlStream = new UrlStream();
					urlStream.stream_0 = new FileStream(localPath, FileMode.Open, FileAccess.Read);
					return urlStream;
				}
				using (WebClient webClient = new WebClient())
				{
					byte[] buffer = webClient.DownloadData(string_1);
					urlStream = new UrlStream();
					urlStream.stream_0 = new MemoryStream(buffer);
					return urlStream;
				}
			}
			localPath = Path.Combine(Environment.CurrentDirectory, string_1);
			urlStream = new UrlStream();
			urlStream.stream_0 = new FileStream(localPath, FileMode.Open, FileAccess.Read);
			return urlStream;
		}

		public static UrlStream smethod_1(string string_1)
		{
			int num = 5;
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("url");
			}
			string_1 = string_1.Trim();
			if (string_1.Length == 0)
			{
				throw new ArgumentNullException("url");
			}
			string localPath;
			UrlStream urlStream;
			if (string_1.IndexOf(":") > 0)
			{
				Uri uri = new Uri(string_1);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					localPath = uri.LocalPath;
					urlStream = new UrlStream();
					urlStream.stream_0 = new FileStream(localPath, FileMode.Create, FileAccess.Write);
					return urlStream;
				}
				urlStream = new UrlStream();
				urlStream.stream_0 = new MemoryStream();
				urlStream.string_0 = string_1;
				return urlStream;
			}
			localPath = Path.Combine(Environment.CurrentDirectory, string_1);
			urlStream = new UrlStream();
			urlStream.stream_0 = new FileStream(localPath, FileMode.Create, FileAccess.Write);
			return urlStream;
		}

		private UrlStream()
		{
		}

		public byte[] method_0()
		{
			if (stream_0 == null)
			{
				return null;
			}
			if (stream_0 is FileStream)
			{
				byte[] array = new byte[stream_0.Length];
				stream_0.Read(array, 0, array.Length);
				return array;
			}
			byte[] array2 = new byte[1024];
			using (GClass367 gClass = new GClass367())
			{
				while (true)
				{
					int num = stream_0.Read(array2, 0, array2.Length);
					if (num <= 0)
					{
						break;
					}
					gClass.method_4(array2, 0, num);
				}
				return gClass.method_6();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       关闭流对象
		                                                                    ///       </summary>
		public override void Close()
		{
			base.Close();
			if (stream_0 != null)
			{
				stream_0.Close();
			}
			if (!string.IsNullOrEmpty(string_0) && stream_0 is MemoryStream)
			{
				byte[] data = ((MemoryStream)stream_0).ToArray();
				using (WebClient webClient = new WebClient())
				{
					webClient.UploadData(string_0, data);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       刷新缓存
		                                                                    ///       </summary>
		public override void Flush()
		{
			stream_0.Flush();
		}

		                                                                    /// <summary>
		                                                                    ///       读取字节数据
		                                                                    ///       </summary>
		                                                                    /// <param name="buffer">
		                                                                    /// </param>
		                                                                    /// <param name="offset">
		                                                                    /// </param>
		                                                                    /// <param name="count">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream_0.Read(buffer, offset, count);
		}

		                                                                    /// <summary>
		                                                                    ///       移动位置
		                                                                    ///       </summary>
		                                                                    /// <param name="offset">
		                                                                    /// </param>
		                                                                    /// <param name="origin">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_0.Seek(offset, origin);
		}

		                                                                    /// <summary>
		                                                                    ///       设置长度
		                                                                    ///       </summary>
		                                                                    /// <param name="value">
		                                                                    /// </param>
		public override void SetLength(long value)
		{
			stream_0.SetLength(value);
		}

		                                                                    /// <summary>
		                                                                    ///       写数据
		                                                                    ///       </summary>
		                                                                    /// <param name="buffer">
		                                                                    /// </param>
		                                                                    /// <param name="offset">
		                                                                    /// </param>
		                                                                    /// <param name="count">
		                                                                    /// </param>
		public override void Write(byte[] buffer, int offset, int count)
		{
			stream_0.Write(buffer, offset, count);
		}
	}
}
