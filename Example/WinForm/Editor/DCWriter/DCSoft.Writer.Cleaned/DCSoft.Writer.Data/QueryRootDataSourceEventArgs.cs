using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	[ComVisible(false)]
	
	public class QueryRootDataSourceEventArgs : EventArgs
	{
		private DataSourceTreeDocument _Document = null;

		private string _Name = null;

		private object _Result = null;

		/// <summary>
		///       数据源文档对象
		///       </summary>
		public DataSourceTreeDocument Document => _Document;

		/// <summary>
		///       名称
		///       </summary>
		public string Name => _Name;

		/// <summary>
		///       结果
		///       </summary>
		public object Result
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

		public QueryRootDataSourceEventArgs(DataSourceTreeDocument document, string name)
		{
			_Document = document;
			_Name = name;
		}
	}
}
