using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       参数说明
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class ParameterDescriptor
	{
		private string _Name = null;

		private string _DisplayName = null;

		private string _Description = null;

		private Type _ValueType = typeof(string);

		private bool _IsBrowsable = true;

		private bool _Readonly = false;

		                                                                    /// <summary>
		                                                                    ///       名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
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
		                                                                    ///       参数显示名称
		                                                                    ///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string DisplayName
		{
			get
			{
				return _DisplayName;
			}
			set
			{
				_DisplayName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       说明
		                                                                    ///       </summary>
		[XmlAttribute]
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
		                                                                    ///       参数类型
		                                                                    ///       </summary>
		[XmlIgnore]
		public Type ValueType
		{
			get
			{
				return _ValueType;
			}
			set
			{
				_ValueType = value;
			}
		}

		[DefaultValue(true)]
		[XmlAttribute]
		public bool IsBrowsable
		{
			get
			{
				return _IsBrowsable;
			}
			set
			{
				_IsBrowsable = value;
			}
		}

		[DefaultValue(false)]
		[XmlAttribute]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		internal Type RuntimeValueType
		{
			get
			{
				if (ValueType == null)
				{
					return typeof(string);
				}
				return ValueType;
			}
		}
	}
}
