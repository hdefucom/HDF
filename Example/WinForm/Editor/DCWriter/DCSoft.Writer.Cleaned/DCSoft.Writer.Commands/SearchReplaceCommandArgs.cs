using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       查找和替换命令参数
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(ISearchReplaceCommandArgs))]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("CFE9D9C3-ABCA-4ECC-8993-E85E69CCCB1F", "CFBE23B5-1A78-4061-A718-71712DD7B8EC")]
	[ComVisible(true)]
	[Guid("CFE9D9C3-ABCA-4ECC-8993-E85E69CCCB1F")]
	[DCPublishAPI]
	public class SearchReplaceCommandArgs : ISearchReplaceCommandArgs
	{
		internal const string CLASSID = "CFE9D9C3-ABCA-4ECC-8993-E85E69CCCB1F";

		internal const string CLASSID_Interface = "CFBE23B5-1A78-4061-A718-71712DD7B8EC";

		private string _SearchString = null;

		private bool _EnableReplaceString = false;

		private string _ReplaceString = null;

		private bool _Backward = true;

		private bool _IgnoreCase = false;

		private bool _SearchID = false;

		private int _Result = 0;

		private List<int> _MatchedIndexs = new List<int>();

		private bool _ExcludeBackgroundText = true;

		private bool _LogUndo = true;

		/// <summary>
		///       要查找的字符串
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string SearchString
		{
			get
			{
				return _SearchString;
			}
			set
			{
				_SearchString = value;
			}
		}

		/// <summary>
		///       是否启用替换模式
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool EnableReplaceString
		{
			get
			{
				return _EnableReplaceString;
			}
			set
			{
				_EnableReplaceString = value;
			}
		}

		/// <summary>
		///       要替换的字符串
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ReplaceString
		{
			get
			{
				return _ReplaceString;
			}
			set
			{
				_ReplaceString = value;
			}
		}

		/// <summary>
		///       True:向后查找；False:向前查找。
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool Backward
		{
			get
			{
				return _Backward;
			}
			set
			{
				_Backward = value;
			}
		}

		/// <summary>
		///       不区分大小写
		///       </summary>
		[DCPublishAPI]
		public bool IgnoreCase
		{
			get
			{
				return _IgnoreCase;
			}
			set
			{
				_IgnoreCase = value;
			}
		}

		/// <summary>
		///       搜索文档元素编号模式
		///       </summary>
		[DCPublishAPI]
		public bool SearchID
		{
			get
			{
				return _SearchID;
			}
			set
			{
				_SearchID = value;
			}
		}

		/// <summary>
		///       替换的次数
		///       </summary>
		[DefaultValue(0)]
		[DCPublishAPI]
		public int Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       搜索到的文本元素在文档内容中的序号
		///       </summary>
		[DCPublishAPI]
		public List<int> MatchedIndexs
		{
			get
			{
				if (_MatchedIndexs == null)
				{
					_MatchedIndexs = new List<int>();
				}
				return _MatchedIndexs;
			}
		}

		/// <summary>
		///       搜索到的字符串的个数
		///       </summary>
		[DCPublishAPI]
		public int MatchedCount
		{
			get
			{
				if (_MatchedIndexs == null)
				{
					return 0;
				}
				return _MatchedIndexs.Count;
			}
		}

		/// <summary>
		///       忽略掉背景文字
		///       </summary>
		[DefaultValue(0)]
		[DCPublishAPI]
		public bool ExcludeBackgroundText
		{
			get
			{
				return _ExcludeBackgroundText;
			}
			set
			{
				_ExcludeBackgroundText = value;
			}
		}

		/// <summary>
		///       记录撤销操作信息
		///       </summary>
		[DCPublishAPI]
		public bool LogUndo
		{
			get
			{
				return _LogUndo;
			}
			set
			{
				_LogUndo = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public SearchReplaceCommandArgs()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCPublishAPI]
		public SearchReplaceCommandArgs Clone()
		{
			return (SearchReplaceCommandArgs)MemberwiseClone();
		}
	}
}
