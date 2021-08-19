using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档参数列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCTimeLineParameterList : List<DCTimeLineParameter>
	{
		/// <summary>
		///       设置参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		public string GetValue(string name)
		{
			return GetParameter(name)?.Value;
		}

		/// <summary>
		///       设置参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">参数值</param>
		public void SetValue(string name, string Value)
		{
			int num = 6;
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			DCTimeLineParameter dCTimeLineParameter = GetParameter(name);
			if (dCTimeLineParameter == null)
			{
				dCTimeLineParameter = new DCTimeLineParameter();
				dCTimeLineParameter.Name = name;
				Add(dCTimeLineParameter);
			}
			dCTimeLineParameter.Value = Value;
		}

		private DCTimeLineParameter GetParameter(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DCTimeLineParameter current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: true) == 0)
						{
							return current;
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		///       进行参数值转换
		///       </summary>
		/// <param name="parameterName">参数名</param>
		/// <param name="defaultValue">默认的文本</param>
		/// <returns>转换后的文本</returns>
		public string Convert(string parameterName, string defaultValue)
		{
			if (!string.IsNullOrEmpty(parameterName))
			{
				DCTimeLineParameter parameter = GetParameter(parameterName);
				if (parameter != null)
				{
					return parameter.Value;
				}
			}
			return defaultValue;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCTimeLineParameterList Clone()
		{
			DCTimeLineParameterList dCTimeLineParameterList = new DCTimeLineParameterList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCTimeLineParameter current = enumerator.Current;
					dCTimeLineParameterList.Add(current.Clone());
				}
			}
			return dCTimeLineParameterList;
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public DCTimeLineParameter ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public void ComSetItem(int index, DCTimeLineParameter item)
		{
			base[index] = item;
		}
	}
}
