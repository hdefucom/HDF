using System;
using System.Data;
using System.Runtime.InteropServices;

namespace DCSoft.Data.Object
{
	                                                                    /// <summary>
	                                                                    ///       简单的对象数据读取器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class SingleObjectDataReader : ObjectDataRecord, IDataReader
	{
		private bool _IsClosed = false;

		private bool _Started = false;

		public int Depth
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsClosed => _IsClosed;

		public int RecordsAffected
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">
		                                                                    /// </param>
		public SingleObjectDataReader(object instance)
			: base(instance)
		{
		}

		public void Close()
		{
			_IsClosed = true;
			base.Instance = null;
		}

		public DataTable GetSchemaTable()
		{
			throw new NotImplementedException();
		}

		public bool NextResult()
		{
			throw new NotImplementedException();
		}

		public bool Read()
		{
			int num = 9;
			if (_IsClosed)
			{
				throw new InvalidOperationException("Closed");
			}
			if (!_Started)
			{
				CheckState();
				_Started = true;
				return base.Instance != null;
			}
			return false;
		}

		public void Dispose()
		{
			Close();
		}
	}
}
