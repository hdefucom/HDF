using DCSoft.Common;
using DCSoft.Writer.Serialization.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Serialization
{
	/// <summary>
	///       文档编码器列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DCInternal]
	[DocumentComment]
	public sealed class ContentSerializerList : List<ContentSerializer>
	{
		private class ContentSerializerComparer : IComparer<ContentSerializer>
		{
			public int Compare(ContentSerializer contentSerializer_0, ContentSerializer contentSerializer_1)
			{
				int num = contentSerializer_0.Priority - contentSerializer_1.Priority;
				if (num == 0)
				{
					num = string.Compare(contentSerializer_0.Name, contentSerializer_1.Name);
				}
				return num;
			}
		}

		/// <summary>
		///       获得默认的文件编码、解码器
		///       </summary>
		public ContentSerializer DefaultSerializer
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ContentSerializer current = enumerator.Current;
						if (current.IsDefault)
						{
							return current;
						}
					}
				}
				return XMLContentSerializer.Instance;
			}
		}

		/// <summary>
		///       添加文档编码器
		///       </summary>
		/// <param name="ser">编码器对象</param>
		/// <returns>新编码器在列表中的序号</returns>
		public int AddSerializer(ContentSerializer contentSerializer_0)
		{
			int num = 17;
			if (contentSerializer_0 == null)
			{
				throw new ArgumentNullException("ser");
			}
			if (Contains(contentSerializer_0))
			{
				return IndexOf(contentSerializer_0);
			}
			Add(contentSerializer_0);
			Sort(new ContentSerializerComparer());
			return IndexOf(contentSerializer_0);
		}

		/// <summary>
		///       获得指定文件扩展名对应的文件格式名称
		///       </summary>
		/// <param name="extension">文件扩展名</param>
		/// <returns>文件格式名称</returns>
		public string GetFormatNameByFileExtension(string extension)
		{
			int num = 18;
			if (!string.IsNullOrEmpty(extension))
			{
				extension = Path.GetExtension(extension);
				if (!extension.StartsWith("."))
				{
					extension = "." + extension;
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ContentSerializer current = enumerator.Current;
						if (string.Compare(current.FileExtension, extension, ignoreCase: true) == 0)
						{
							return current.Name;
						}
					}
				}
			}
			return DefaultSerializer.Name;
		}

		/// <summary>
		///       获得指定名称的编码器，若未找到则返回默认对象
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的编码器</returns>
		public ContentSerializer GetSerializer(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ContentSerializer current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: true) == 0)
						{
							return current;
						}
					}
				}
			}
			return DefaultSerializer;
		}
	}
}
