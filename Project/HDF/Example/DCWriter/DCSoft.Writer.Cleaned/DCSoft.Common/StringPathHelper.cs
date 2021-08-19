using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       处理路径字符串的帮助类
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class StringPathHelper
	{
		private static StringPathHelper myFilePathHelper = null;

		private static StringPathHelper myHttpPathHelper = null;

		protected char charPathSpliter = '/';

		protected bool bolSupportParent = true;

		protected string strParentSymbol = "..";

		protected string strCurrentSymbol = ".";

		protected string strCompatiblePathSpliter = "\\/";

		protected bool bolIngnoreCase = false;

		protected string strPathPrefix = null;

		                                                                    /// <summary>
		                                                                    ///       获得针对文件系统的路径字符串帮助对象
		                                                                    ///       </summary>
		public static StringPathHelper FilePathHelper
		{
			get
			{
				int num = 18;
				if (myFilePathHelper == null)
				{
					myFilePathHelper = new StringPathHelper();
					myFilePathHelper.charPathSpliter = Path.DirectorySeparatorChar;
					myFilePathHelper.strCompatiblePathSpliter = "/";
					myFilePathHelper.IngnoreCase = true;
					myFilePathHelper.bolSupportParent = true;
				}
				return myFilePathHelper;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得针对Http的URL的路径字符串帮助对象
		                                                                    ///       </summary>
		public static StringPathHelper HttpPathHelper
		{
			get
			{
				int num = 2;
				if (myHttpPathHelper == null)
				{
					myHttpPathHelper = new StringPathHelper();
					myHttpPathHelper.charPathSpliter = '/';
					myHttpPathHelper.strCompatiblePathSpliter = "\\/";
					myHttpPathHelper.IngnoreCase = true;
					myHttpPathHelper.strPathPrefix = "http:                                                                    //";
				}
				return myHttpPathHelper;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       路径前缀字符串
		                                                                    ///       </summary>
		public string PathPrefix
		{
			get
			{
				return strPathPrefix;
			}
			set
			{
				strPathPrefix = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否不区分大小写,true:不区分大小写 false:区分大小写
		                                                                    ///       </summary>
		public bool IngnoreCase
		{
			get
			{
				return bolIngnoreCase;
			}
			set
			{
				bolIngnoreCase = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       各层路径的分隔字符
		                                                                    ///       </summary>
		public char PathSpliter
		{
			get
			{
				return charPathSpliter;
			}
			set
			{
				charPathSpliter = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       兼容的路径分隔字符
		                                                                    ///       </summary>
		public string CompatiblePathSpliter
		{
			get
			{
				return strCompatiblePathSpliter;
			}
			set
			{
				strCompatiblePathSpliter = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否支持父路径
		                                                                    ///       </summary>
		public bool SupprotParent
		{
			get
			{
				return bolSupportParent;
			}
			set
			{
				bolSupportParent = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       表示父路径的符号
		                                                                    ///       </summary>
		public string ParentSymbol
		{
			get
			{
				return strParentSymbol;
			}
			set
			{
				strParentSymbol = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       表示当前路径的符号
		                                                                    ///       </summary>
		public string CurrentSymbol
		{
			get
			{
				return strCurrentSymbol;
			}
			set
			{
				strCurrentSymbol = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       合并两个路径字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="path1">路径1</param>
		                                                                    /// <param name="path2">路径2</param>
		                                                                    /// <param name="PathSpliter">路径分隔字符</param>
		                                                                    /// <param name="SupportParent">是否支持用 .. 表示父路径</param>
		                                                                    /// <returns>合并后的路径</returns>
		public static string CombinePathString(string path1, string path2, char PathSpliter, bool SupportParent)
		{
			StringPathHelper stringPathHelper = new StringPathHelper();
			stringPathHelper.PathSpliter = PathSpliter;
			stringPathHelper.SupprotParent = SupportParent;
			return stringPathHelper.Combine(path1, path2);
		}

		                                                                    /// <summary>
		                                                                    ///       合并多个路径字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="myList">路径字符串集合</param>
		                                                                    /// <param name="PathSpliter">路径分隔字符</param>
		                                                                    /// <param name="SupportParent">是否支持用..表示父路径</param>
		                                                                    /// <returns>合并后的路径</returns>
		public static string CombinePathString(IEnumerable myList, char PathSpliter, bool SupportParent)
		{
			StringPathHelper stringPathHelper = new StringPathHelper();
			stringPathHelper.PathSpliter = PathSpliter;
			stringPathHelper.SupprotParent = SupportParent;
			return stringPathHelper.Combine(myList);
		}

		                                                                    /// <summary>
		                                                                    ///       获得两个路径之间的相对路径
		                                                                    ///       </summary>
		                                                                    /// <param name="path1">起始路径</param>
		                                                                    /// <param name="path2">目标路径</param>
		                                                                    /// <param name="PathSpliter">路径分隔字符</param>
		                                                                    /// <param name="IngnoreCase">比较路径时是否区分大小写</param>
		                                                                    /// <returns>获得的相对路径</returns>
		public static string GetRelPathString(string path1, string path2, char PathSpliter, bool IngnoreCase)
		{
			StringPathHelper stringPathHelper = new StringPathHelper();
			stringPathHelper.PathSpliter = PathSpliter;
			stringPathHelper.IngnoreCase = IngnoreCase;
			return stringPathHelper.GetRelPathString(path1, path2);
		}

		                                                                    /// <summary>
		                                                                    ///       修正路径字符串,使得字符串两边不会出现路径路径分隔字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">
		                                                                    /// </param>
		                                                                    /// <param name="chrPathSpliter">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string FixPathString(string strPath, char chrPathSpliter)
		{
			StringPathHelper stringPathHelper = new StringPathHelper();
			stringPathHelper.PathSpliter = chrPathSpliter;
			return stringPathHelper.FixPathString(strPath);
		}

		public static string[] SplitPath(string strPath, char chrPathSpliter)
		{
			StringPathHelper stringPathHelper = new StringPathHelper();
			stringPathHelper.PathSpliter = chrPathSpliter;
			return stringPathHelper.SplitPath(strPath);
		}

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public StringPathHelper()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       指定分隔字符的初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="vPathSpliter">分隔字符</param>
		public StringPathHelper(char vPathSpliter)
		{
			charPathSpliter = vPathSpliter;
		}

		                                                                    /// <summary>
		                                                                    ///       合并两个路径字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="path1">路径1</param>
		                                                                    /// <param name="path2">路径2</param>
		                                                                    /// <returns>合并后的路径</returns>
		public string Combine(string path1, string path2)
		{
			if (path1 == null || path1.Length == 0)
			{
				return path2;
			}
			if (path2 == null || path2.Length == 0)
			{
				return path1;
			}
			path1 = FixPathString(path1);
			path2 = FixPathString(path2);
			if (path1.Length == 0)
			{
				return path2;
			}
			if (path2.Length == 0)
			{
				return path1;
			}
			if (bolSupportParent)
			{
				string[] c = SplitPath(path1);
				string[] array = SplitPath(path2);
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(c);
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text == strParentSymbol)
					{
						if (arrayList.Count > 0)
						{
							arrayList.RemoveAt(arrayList.Count - 1);
						}
					}
					else if (text != strCurrentSymbol)
					{
						arrayList.Add(text);
					}
				}
				return AddPrefix(Combine(arrayList));
			}
			return AddPrefix(path1 + charPathSpliter + path2);
		}

		                                                                    /// <summary>
		                                                                    ///       将各个路径名称合并起来
		                                                                    ///       </summary>
		                                                                    /// <param name="strItems">单个路径名称组成的字符串数组</param>
		                                                                    /// <returns>组合后的路径</returns>
		public string Combine(IEnumerable strItems)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string strItem in strItems)
			{
				string text = FixPathString(strItem);
				if (text != null && text.Length > 0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(charPathSpliter);
					}
					stringBuilder.Append(text);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       获得两个路径之间的相对路径
		                                                                    ///       </summary>
		                                                                    /// <param name="path1">起始路径</param>
		                                                                    /// <param name="path2">目标路径</param>
		                                                                    /// <returns>获得的相对路径</returns>
		public string GetRelPathString(string path1, string path2)
		{
			string[] array = SplitPath(path1);
			if (array == null)
			{
				return FixPathString(path2);
			}
			string[] array2 = SplitPath(path2);
			if (bolSupportParent)
			{
				ArrayList arrayList = new ArrayList();
				if (array2 == null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						arrayList.Add(strParentSymbol);
					}
					return Combine(arrayList);
				}
				int num = array.Length;
				for (int i = 0; i < array.Length && i < array2.Length; i++)
				{
					if (string.Compare(array[i], array2[i], bolIngnoreCase) != 0)
					{
						num = i;
						break;
					}
				}
				for (int i = num; i < array.Length; i++)
				{
					arrayList.Add(strParentSymbol);
				}
				for (int i = num; i < array2.Length; i++)
				{
					arrayList.Add(array2[i]);
				}
				return Combine(arrayList);
			}
			if (path1.Length < path2.Length)
			{
				return FixPathString(path2.Substring(path1.Length));
			}
			return "";
		}

		                                                                    /// <summary>
		                                                                    ///       修正路径字符串,使得字符串两边不会出现路径路径分隔字符,并处理兼容分隔字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		                                                                    /// <returns>修正后的路径字符串</returns>
		public string FixPathString(string strPath)
		{
			if (strPath == null)
			{
				return strPath;
			}
			strPath = strPath.Trim();
			if (strPath.Length == 0)
			{
				return strPath;
			}
			strPath = RemovePrefix(strPath);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(charPathSpliter);
			if (strCompatiblePathSpliter != null)
			{
				stringBuilder.Append(strCompatiblePathSpliter);
			}
			if (strPath.IndexOfAny(stringBuilder.ToString().ToCharArray()) == -1)
			{
				return strPath;
			}
			int num = -1;
			int num2 = strPath.Length;
			char[] array = strPath.ToCharArray();
			if (strCompatiblePathSpliter != null && strCompatiblePathSpliter.Length > 0)
			{
				int i;
				for (i = 0; i < array.Length; i++)
				{
					if (strCompatiblePathSpliter.IndexOf(array[i]) >= 0)
					{
						array[i] = charPathSpliter;
					}
					if (array[i] != charPathSpliter && num < 0)
					{
						num = i;
					}
				}
				i = array.Length - 1;
				while (i >= 0)
				{
					if (array[i] == charPathSpliter)
					{
						i--;
						continue;
					}
					num2 = i;
					break;
				}
			}
			if (num < 0)
			{
				num = 0;
			}
			strPath = new string(array, num, num2 - num + 1);
			return strPath;
		}

		                                                                    /// <summary>
		                                                                    ///       将路径字符串分隔成一个个路径名称
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">路径字符串</param>
		                                                                    /// <returns>单个名称组成的字符串数组</returns>
		public string[] SplitPath(string strText)
		{
			if (strText != null)
			{
				strText = RemovePrefix(strText);
				ArrayList arrayList = new ArrayList();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(charPathSpliter);
				if (strCompatiblePathSpliter != null)
				{
					stringBuilder.Append(strCompatiblePathSpliter);
				}
				string[] array = strText.Split(stringBuilder.ToString().ToCharArray(), int.MaxValue);
				string[] array2 = array;
				foreach (string text in array2)
				{
					string text2 = text.Trim();
					if (text2.Length > 0)
					{
						arrayList.Add(text2);
					}
				}
				if (arrayList.Count > 0)
				{
					return (string[])arrayList.ToArray(typeof(string));
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       删除前缀字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		                                                                    /// <returns>删除前缀字符串的路径字符串</returns>
		public string RemovePrefix(string strPath)
		{
			if (strPath != null && strPathPrefix != null && strPathPrefix.Length > 0 && strPath.StartsWith(strPathPrefix, bolIngnoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
			{
				strPath = strPath.Substring(strPathPrefix.Length);
			}
			return strPath;
		}

		                                                                    /// <summary>
		                                                                    ///       添加前缀字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strPath">路径字符串</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public string AddPrefix(string strPath)
		{
			if (strPathPrefix != null)
			{
				return strPathPrefix + strPath;
			}
			return strPath;
		}
	}
}
