using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	[ComVisible(false)]
	public class BinaryContentBuffer
	{
		private class Class33
		{
			public string string_0 = null;

			public byte[] byte_0 = null;

			public int int_0 = 0;
		}

		private List<Class33> list_0 = new List<Class33>();

		private int int_0 = 10485760;

		                                                                    /// <summary>
		                                                                    ///       当前缓存的数据字节数
		                                                                    ///       </summary>
		public int CurrentSize
		{
			get
			{
				lock (this)
				{
					int num = 0;
					foreach (Class33 item in list_0)
					{
						if (item.byte_0 != null)
						{
							num += item.byte_0.Length;
						}
					}
					return num;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       缓冲区最大字节数
		                                                                    ///       </summary>
		public int MaxSize
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public void Clear()
		{
			lock (this)
			{
				list_0.Clear();
				GC.Collect();
			}
		}

		public byte[] GetContent(string name)
		{
			Class33 @class = method_0(name);
			if (@class == null)
			{
				return null;
			}
			@class.int_0++;
			int num = list_0.IndexOf(@class);
			if (num >= 0)
			{
				list_0[num] = list_0[num - 1];
				list_0[num - 1] = @class;
			}
			return @class.byte_0;
		}

		public void SetContent(string name, byte[] content)
		{
			Class33 @class = method_0(name);
			if (@class != null)
			{
				list_0.Remove(@class);
			}
			if (MaxSize > 0)
			{
				int num = CurrentSize;
				if (content != null)
				{
					num += content.Length;
				}
				if (num > MaxSize)
				{
					for (int num2 = list_0.Count - 1; num2 >= 0; num2--)
					{
						Class33 class2 = list_0[num2];
						if (class2.byte_0 != null && class2.byte_0.Length > 0)
						{
							num -= class2.byte_0.Length;
							list_0.RemoveAt(num2);
							if (num < MaxSize)
							{
								break;
							}
						}
					}
				}
			}
			@class = new Class33();
			@class.string_0 = name;
			@class.byte_0 = content;
			list_0.Insert(0, @class);
		}

		public bool Contains(string name)
		{
			return method_0(name) != null;
		}

		public void Remove(string name)
		{
			Class33 @class = method_0(name);
			if (@class != null)
			{
				list_0.Remove(@class);
			}
		}

		private Class33 method_0(string string_0)
		{
			lock (this)
			{
				foreach (Class33 item in list_0)
				{
					if (item.string_0 == string_0)
					{
						return item;
					}
				}
				return null;
			}
		}

		public byte[] LoadFromUrl(string strUrl)
		{
			Class33 @class = method_0(strUrl);
			if (@class != null)
			{
				return @class.byte_0;
			}
			byte[] array = null;
			try
			{
				Uri uri = new Uri(strUrl);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					if (File.Exists(strUrl))
					{
						array = File.ReadAllBytes(strUrl);
					}
				}
				else if (uri.Scheme == Uri.UriSchemeHttp)
				{
					using (WebClient webClient = new WebClient())
					{
						array = webClient.DownloadData(strUrl);
					}
				}
				return array;
			}
			finally
			{
				SetContent(strUrl, array);
			}
		}
	}
}
