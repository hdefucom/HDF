using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法的命令标记特性
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class DCSQLMethodCommandTextAttribute : Attribute
	{
		private int _ProjectID = 0;

		private string _CommandText = null;

		/// <summary>
		///       项目编号
		///       </summary>
		public int ProjectID
		{
			get
			{
				return _ProjectID;
			}
			set
			{
				_ProjectID = value;
			}
		}

		/// <summary>
		///       SQL命令文本
		///       </summary>
		public string CommandText
		{
			get
			{
				return _CommandText;
			}
			set
			{
				_CommandText = value;
			}
		}

		/// <summary>
		///       初始化
		///       </summary>
		/// <param name="projectID">
		/// </param>
		/// <param name="commandText">
		/// </param>
		public DCSQLMethodCommandTextAttribute(int projectID, string commandText)
		{
			_ProjectID = projectID;
			_CommandText = commandText;
		}

		/// <summary>
		///       初始化
		///       </summary>
		/// <param name="commandText">
		/// </param>
		public DCSQLMethodCommandTextAttribute(string commandText)
		{
			_CommandText = commandText;
		}
	}
}
