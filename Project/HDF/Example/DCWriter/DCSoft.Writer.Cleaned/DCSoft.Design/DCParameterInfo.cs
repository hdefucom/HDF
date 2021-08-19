using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       参数信息对象
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCParameterInfo
	{
		private string strName = null;

		private bool bolIsIn = false;

		private bool bolIsLcid = false;

		private bool bolIsOptional = false;

		private bool bolIsOut = false;

		private bool bolIsRetval = false;

		private DCTypeInfo myParameterType = null;

		private string _ParameterTypeID = null;

		private int intPosition = 0;

		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		[DefaultValue(false)]
		public bool IsIn
		{
			get
			{
				return bolIsIn;
			}
			set
			{
				bolIsIn = value;
			}
		}

		[DefaultValue(false)]
		public bool IsLcid
		{
			get
			{
				return bolIsLcid;
			}
			set
			{
				bolIsLcid = value;
			}
		}

		[DefaultValue(false)]
		public bool IsOptional
		{
			get
			{
				return bolIsOptional;
			}
			set
			{
				bolIsOptional = value;
			}
		}

		[DefaultValue(false)]
		public bool IsOut
		{
			get
			{
				return bolIsOut;
			}
			set
			{
				bolIsOut = value;
			}
		}

		[DefaultValue(false)]
		public bool IsRetval
		{
			get
			{
				return bolIsRetval;
			}
			set
			{
				bolIsRetval = value;
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		public DCTypeInfo ParameterType
		{
			get
			{
				return myParameterType;
			}
			set
			{
				myParameterType = value;
			}
		}

		[DefaultValue(null)]
		[XmlElement]
		[Browsable(false)]
		public string ParameterTypeID
		{
			get
			{
				if (myParameterType == null)
				{
					return _ParameterTypeID;
				}
				return myParameterType.ID;
			}
			set
			{
				_ParameterTypeID = value;
			}
		}

		[DefaultValue(0)]
		public int Position
		{
			get
			{
				return intPosition;
			}
			set
			{
				intPosition = value;
			}
		}
	}
}
