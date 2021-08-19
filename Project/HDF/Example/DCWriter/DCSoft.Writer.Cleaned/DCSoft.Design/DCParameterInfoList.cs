using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       参数信息对象列表
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCParameterInfoList : List<DCParameterInfo>
	{
		public string ToLongString(bool includeName)
		{
			int num = 4;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < base.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(base[i].ParameterType.CSharpName);
				if (includeName)
				{
					stringBuilder.Append(" " + base[i].Name);
				}
			}
			return stringBuilder.ToString();
		}

		public bool EqualsMark(DCParameterInfoList dcparameterInfoList_0, bool equalsParameterName)
		{
			if (dcparameterInfoList_0 == this)
			{
				return true;
			}
			if (base.Count == 0 && (dcparameterInfoList_0 == null || dcparameterInfoList_0.Count == 0))
			{
				return true;
			}
			if (dcparameterInfoList_0.Count != base.Count)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					DCParameterInfo dCParameterInfo = base[num];
					DCParameterInfo dCParameterInfo2 = dcparameterInfoList_0[num];
					if (!equalsParameterName || !(dCParameterInfo.Name != dCParameterInfo2.Name))
					{
						if (dCParameterInfo.ParameterType != dCParameterInfo2.ParameterType || dCParameterInfo.IsIn != dCParameterInfo2.IsIn || dCParameterInfo.IsOut != dCParameterInfo2.IsOut || dCParameterInfo.IsOptional != dCParameterInfo2.IsOptional)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool EqualsMark(DCParameterInfoList dcparameterInfoList_0, DCParameterInfoList dcparameterInfoList_1, bool equalsParameterName)
		{
			if (dcparameterInfoList_0 == dcparameterInfoList_1)
			{
				return true;
			}
			if (dcparameterInfoList_0 == null && dcparameterInfoList_1 == null)
			{
				return true;
			}
			return dcparameterInfoList_0?.EqualsMark(dcparameterInfoList_1, equalsParameterName) ?? dcparameterInfoList_1?.EqualsMark(dcparameterInfoList_0, equalsParameterName) ?? true;
		}
	}
}
