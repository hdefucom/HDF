using System;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       SingleValueDataReader 的摘要说明。
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	public class SingleValueDataReader : BaseDataReader
	{
		private object objValue = null;

		private bool bolReadFlag = false;

		private bool bolCloseFlag = false;

		public object Value
		{
			get
			{
				return objValue;
			}
			set
			{
				objValue = value;
			}
		}

		public override int FieldCount => 1;

		public override bool IsClosed => bolCloseFlag;

		public SingleValueDataReader()
		{
		}

		public SingleValueDataReader(object object_0)
		{
			objValue = object_0;
		}

		protected override object InnerGetValue(int index)
		{
			if (index == 0)
			{
				return objValue;
			}
			return DBNull.Value;
		}

		public override string GetName(int ordinal)
		{
			return null;
		}

		public override bool Read()
		{
			if (bolCloseFlag)
			{
				return false;
			}
			if (bolReadFlag)
			{
				return false;
			}
			bolReadFlag = true;
			return true;
		}

		public override void Close()
		{
			bolCloseFlag = true;
		}

		protected override bool InnerIsDBNull(int index)
		{
			if (index == 0)
			{
				return objValue == null || DBNull.Value.Equals(objValue);
			}
			return true;
		}
	}
}
