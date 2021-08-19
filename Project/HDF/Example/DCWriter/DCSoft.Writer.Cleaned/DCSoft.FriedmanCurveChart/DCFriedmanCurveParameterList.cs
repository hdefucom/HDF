using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文档参数列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCFriedmanCurveParameterList : List<DCFriedmanCurveParameter>
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
			int num = 3;
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			DCFriedmanCurveParameter dCFriedmanCurveParameter = GetParameter(name);
			if (dCFriedmanCurveParameter == null)
			{
				dCFriedmanCurveParameter = new DCFriedmanCurveParameter();
				dCFriedmanCurveParameter.Name = name;
				Add(dCFriedmanCurveParameter);
			}
			dCFriedmanCurveParameter.Value = Value;
		}

		private DCFriedmanCurveParameter GetParameter(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DCFriedmanCurveParameter current = enumerator.Current;
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
			if (parameterName != null && parameterName.Length > 0)
			{
				DCFriedmanCurveParameter parameter = GetParameter(parameterName);
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
		public DCFriedmanCurveParameterList Clone()
		{
			DCFriedmanCurveParameterList dCFriedmanCurveParameterList = new DCFriedmanCurveParameterList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCFriedmanCurveParameter current = enumerator.Current;
					dCFriedmanCurveParameterList.Add(current.Clone());
				}
			}
			return dCFriedmanCurveParameterList;
		}
	}
}
