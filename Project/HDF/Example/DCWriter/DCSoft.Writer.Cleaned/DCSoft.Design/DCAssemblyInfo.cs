using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       程序集信息对象
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCAssemblyInfo
	{
		private string _Name = null;

		private string _FullName = null;

		private string _Version = null;

		private string _Description = null;

		private bool _ComVisible = false;

		private DCTypeInfoList _Types = new DCTypeInfoList();

		                                                                    /// <summary>
		                                                                    ///       名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       全名
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				_FullName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       版本号
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       说明
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       程序集是否COM可见
		                                                                    ///       </summary>
		[DefaultValue(false)]
		public bool ComVisible
		{
			get
			{
				return _ComVisible;
			}
			set
			{
				_ComVisible = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       程序集所含的类型信息
		                                                                    ///       </summary>
		[XmlArrayItem("Type", typeof(DCTypeInfo))]
		public DCTypeInfoList Types
		{
			get
			{
				return _Types;
			}
			set
			{
				_Types = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public DCAssemblyInfo Clone()
		{
			DCAssemblyInfo dCAssemblyInfo = (DCAssemblyInfo)MemberwiseClone();
			dCAssemblyInfo._Types = new DCTypeInfoList();
			foreach (DCTypeInfo type in _Types)
			{
				dCAssemblyInfo._Types.Add(type.Clone());
			}
			return dCAssemblyInfo;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
