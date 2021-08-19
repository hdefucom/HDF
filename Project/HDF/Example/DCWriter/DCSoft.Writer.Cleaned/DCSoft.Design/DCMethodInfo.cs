using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       成员方法信息对象
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCMethodInfo : DCMemberInfo
	{
		private bool bolIsAbstract = false;

		private bool bolIsAssembly = false;

		private bool bolIsConstructor = false;

		private bool bolIsFamily = false;

		private bool bolIsFinal = false;

		private bool bolIsPrivate = false;

		private bool bolIsPublic = false;

		private bool bolIsSpecialName = false;

		private bool bolIsStatic = false;

		private bool bolIsVirtual = false;

		private DCTypeInfo myReturnType = null;

		private string _ReturnTypeID = null;

		private DCParameterInfoList myParameters = null;

		[DefaultValue(false)]
		public bool IsAbstract
		{
			get
			{
				return bolIsAbstract;
			}
			set
			{
				bolIsAbstract = value;
			}
		}

		[DefaultValue(false)]
		public bool IsAssembly
		{
			get
			{
				return bolIsAssembly;
			}
			set
			{
				bolIsAssembly = value;
			}
		}

		[DefaultValue(false)]
		public bool IsConstructor
		{
			get
			{
				return bolIsConstructor;
			}
			set
			{
				bolIsConstructor = value;
			}
		}

		[DefaultValue(false)]
		public bool IsFamily
		{
			get
			{
				return bolIsFamily;
			}
			set
			{
				bolIsFamily = value;
			}
		}

		public bool IsFamilyAndAssembly => bolIsFamily && bolIsAssembly;

		public bool IsFamilyOrAssembly => bolIsFamily || bolIsAssembly;

		[DefaultValue(false)]
		public bool IsFinal
		{
			get
			{
				return bolIsFinal;
			}
			set
			{
				bolIsFinal = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPrivate
		{
			get
			{
				return bolIsPrivate;
			}
			set
			{
				bolIsPrivate = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPublic
		{
			get
			{
				return bolIsPublic;
			}
			set
			{
				bolIsPublic = value;
			}
		}

		[DefaultValue(false)]
		public bool IsSpecialName
		{
			get
			{
				return bolIsSpecialName;
			}
			set
			{
				bolIsSpecialName = value;
			}
		}

		[DefaultValue(false)]
		public bool IsStatic
		{
			get
			{
				return bolIsStatic;
			}
			set
			{
				bolIsStatic = value;
			}
		}

		[DefaultValue(false)]
		public bool IsVirtual
		{
			get
			{
				return bolIsVirtual;
			}
			set
			{
				bolIsVirtual = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       返回值数据类型
		                                                                    ///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		public DCTypeInfo ReturnType
		{
			get
			{
				return myReturnType;
			}
			set
			{
				myReturnType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       返回值数据类型编号
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[Browsable(false)]
		public string ReturnTypeID
		{
			get
			{
				if (myReturnType == null)
				{
					return _ReturnTypeID;
				}
				return myReturnType.ID;
			}
			set
			{
				_ReturnTypeID = value;
			}
		}

		public override MemberTypes MemberType => MemberTypes.Method;

		[DefaultValue(null)]
		[XmlArrayItem("Parameter", typeof(DCParameterInfo))]
		public DCParameterInfoList Parameters
		{
			get
			{
				return myParameters;
			}
			set
			{
				myParameters = value;
			}
		}

		public override bool EqualsMark(DCMemberInfo member)
		{
			DCMethodInfo dCMethodInfo = member as DCMethodInfo;
			if (dCMethodInfo != null)
			{
				return CompareMark(dCMethodInfo, equalsParameterName: false);
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       判断两个方法的签名是否相等
		                                                                    ///       </summary>
		                                                                    /// <param name="method">要比较的方法</param>
		                                                                    /// <param name="equalsParameterName">是否比较参数名称</param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public bool CompareMark(DCMethodInfo method, bool equalsParameterName)
		{
			int num = 10;
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (method == this)
			{
				return true;
			}
			if (method.ReturnType != ReturnType)
			{
				return false;
			}
			return DCParameterInfoList.EqualsMark(Parameters, method.Parameters, equalsParameterName);
		}

		                                                                    /// <summary>
		                                                                    ///       判断方法和委托
		                                                                    ///       </summary>
		                                                                    /// <param name="method">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public bool CompareMark(DCTypeInfo delegateType)
		{
			int num = 5;
			if (delegateType == null)
			{
				throw new ArgumentNullException("method");
			}
			if (delegateType.DelegateReturnType != ReturnType)
			{
				return false;
			}
			if (delegateType.DelegateParameters != null && Parameters != null && delegateType.DelegateParameters.Count == Parameters.Count)
			{
				for (int i = 0; i < Parameters.Count; i++)
				{
					DCParameterInfo dCParameterInfo = Parameters[i];
					DCParameterInfo dCParameterInfo2 = delegateType.DelegateParameters[i];
					if (dCParameterInfo.ParameterType != dCParameterInfo2.ParameterType || dCParameterInfo.IsIn != dCParameterInfo2.IsIn || dCParameterInfo.IsOut != dCParameterInfo2.IsOut || dCParameterInfo.IsOptional != dCParameterInfo2.IsOptional)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal string GetMethodPrefix()
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			if (IsPublic)
			{
				stringBuilder.Append("public ");
			}
			else if (IsAssembly)
			{
				stringBuilder.Append("internal ");
			}
			else if (IsFamily)
			{
				stringBuilder.Append("protected ");
			}
			else
			{
				stringBuilder.Append("private ");
			}
			if (IsStatic)
			{
				stringBuilder.Append("static ");
			}
			if (IsFinal)
			{
				stringBuilder.Append("sealed ");
			}
			if (IsVirtual)
			{
				stringBuilder.Append("virtual ");
			}
			if (IsAbstract)
			{
				stringBuilder.Append("abstract ");
			}
			return stringBuilder.ToString();
		}

		public override string ToShortString()
		{
			int num = 14;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(_Name);
			if (myParameters.Count == 0)
			{
				stringBuilder.Append("( )");
			}
			else
			{
				stringBuilder.Append("(");
				for (int i = 0; i < myParameters.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(" , ");
					}
					stringBuilder.Append(myParameters[i].Name);
				}
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		public override string ToLongString()
		{
			return ToLongString(includeParameterType: false, includeParamterName: false);
		}

		public string ToLongString(bool includeParameterType, bool includeParamterName)
		{
			int num = 1;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetMethodPrefix());
			if (ReturnType == null || ReturnType.Equals(typeof(void)))
			{
				stringBuilder.Append("void ");
			}
			else
			{
				stringBuilder.Append(ReturnType.CSharpName + " ");
			}
			stringBuilder.Append(_Name);
			if (myParameters.Count == 0 || !includeParameterType)
			{
				stringBuilder.Append("( )");
			}
			else
			{
				stringBuilder.Append("(");
				for (int i = 0; i < Parameters.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(" , ");
					}
					DCParameterInfo dCParameterInfo = Parameters[i];
					if (dCParameterInfo.IsIn && dCParameterInfo.IsOut)
					{
						stringBuilder.Append("ref ");
					}
					else if (dCParameterInfo.IsIn)
					{
						stringBuilder.Append("in ");
					}
					else if (dCParameterInfo.IsOut)
					{
						stringBuilder.Append("out ");
					}
					if (dCParameterInfo.ParameterType == null)
					{
						stringBuilder.Append("[VOID]");
					}
					else
					{
						stringBuilder.Append(dCParameterInfo.ParameterType.CSharpName);
					}
					if (includeParamterName)
					{
						stringBuilder.Append(" " + dCParameterInfo.Name);
					}
				}
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		public override string ToString()
		{
			return "Method:" + base.Name;
		}
	}
}
