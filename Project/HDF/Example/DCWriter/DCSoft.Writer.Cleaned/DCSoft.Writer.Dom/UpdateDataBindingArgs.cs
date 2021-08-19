using DCSoft.Writer.Data;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	[ComVisible(false)]
	public class UpdateDataBindingArgs
	{
		private DataSourceTreeNode _DataNode = null;

		private object _DataSource = null;

		private bool _FastMode = false;

		private string[] _SpecifyParameterNames = null;

		private XTextElementList _HandledElements = null;

		private bool _DetectValueModified = false;

		private DetectResultForValueBindingModifiedList _DetectResults = null;

		/// <summary>
		///       数据节点对象
		///       </summary>
		public DataSourceTreeNode DataNode
		{
			get
			{
				return _DataNode;
			}
			set
			{
				_DataNode = value;
			}
		}

		/// <summary>
		///       数据源对象 
		///       </summary>
		public object DataSource
		{
			get
			{
				return _DataSource;
			}
			set
			{
				_DataSource = value;
			}
		}

		/// <summary>
		///       是否为快速模式
		///       </summary>
		public bool FastMode
		{
			get
			{
				return _FastMode;
			}
			set
			{
				_FastMode = value;
			}
		}

		/// <summary>
		///       指定的文档参数的名称
		///       </summary>
		public string[] SpecifyParameterNames
		{
			get
			{
				return _SpecifyParameterNames;
			}
			set
			{
				_SpecifyParameterNames = value;
			}
		}

		internal XTextElementList HandledElements => _HandledElements;

		/// <summary>
		///       用于检测是否导致文档数据发生改变
		///       </summary>
		public bool DetectValueModified
		{
			get
			{
				return _DetectValueModified;
			}
			set
			{
				_DetectValueModified = value;
			}
		}

		/// <summary>
		///       检测结果列表
		///       </summary>
		internal DetectResultForValueBindingModifiedList DetectResults => _DetectResults;

		public UpdateDataBindingArgs()
		{
		}

		public UpdateDataBindingArgs(object dataSource, bool fastMode)
		{
			_DataSource = DataSource;
			_FastMode = FastMode;
		}

		/// <summary>
		///       添加数据源绑定操作而设置过的文档元素对象
		///       </summary>
		/// <param name="element">
		/// </param>
		public void AddHandledElement(XTextElement element)
		{
			int num = 19;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (_HandledElements == null)
			{
				_HandledElements = new XTextElementList();
			}
			_HandledElements.Add(element);
		}

		public void AddDetectResult(DetectResultForValueBindingModified item)
		{
			if (_DetectResults == null)
			{
				_DetectResults = new DetectResultForValueBindingModifiedList();
			}
			_DetectResults.Add(item);
		}

		/// <summary>
		///       检查参数中的SpecifyParameterName值。
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public bool CheckForSpecifyParameterName(string dataSourceName)
		{
			if (string.IsNullOrEmpty(dataSourceName))
			{
				return true;
			}
			if (DataSource == null && SpecifyParameterNames != null && SpecifyParameterNames.Length > 0)
			{
				bool flag = false;
				bool flag2 = false;
				string[] specifyParameterNames = SpecifyParameterNames;
				foreach (string text in specifyParameterNames)
				{
					if (!string.IsNullOrEmpty(text))
					{
						flag2 = true;
						if (string.Compare(text, dataSourceName, ignoreCase: true) == 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag2 && !flag)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///       检查参数中的SpecifyParameterName值。
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public bool CheckForSpecifyParameterName(XDataBinding binding)
		{
			if (binding == null)
			{
				return true;
			}
			if (DataSource == null && SpecifyParameterNames != null && SpecifyParameterNames.Length > 0)
			{
				bool flag = false;
				bool flag2 = false;
				string[] specifyParameterNames = SpecifyParameterNames;
				foreach (string text in specifyParameterNames)
				{
					if (!string.IsNullOrEmpty(text))
					{
						flag2 = true;
						if (string.Compare(text, binding.DataSource, ignoreCase: true) == 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag2 && !flag)
				{
					return false;
				}
			}
			return true;
		}

		public UpdateDataBindingArgs Clone()
		{
			return (UpdateDataBindingArgs)MemberwiseClone();
		}
	}
}
