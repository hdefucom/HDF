using DCSoft.Common;
using DCSoft.Writer.Expression;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       联动列表绑定信息
	///       </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("65D47CDE-B18B-4AFD-A20D-B3A94B50CB0B", "65A1AF66-AFF6-4C62-86E4-37E18958CAFA")]
	[ComVisible(true)]
	[Guid("65D47CDE-B18B-4AFD-A20D-B3A94B50CB0B")]
	[ComDefaultInterface(typeof(ILinkListBindingInfo))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	public class LinkListBindingInfo : IDCStringSerializable, ILinkListBindingInfo
	{
		internal const string CLASSID = "65D47CDE-B18B-4AFD-A20D-B3A94B50CB0B";

		internal const string CLASSID_Interface = "65A1AF66-AFF6-4C62-86E4-37E18958CAFA";

		private string _ProviderName = null;

		private string _UserFlag = null;

		private bool _IsRoot = false;

		private EventExpressionTarget _NextTarget = EventExpressionTarget.NextElement;

		private string _NextTargetID = null;

		private bool _AutoUpdateTargetElement = true;

		private bool _AutoSetFirstItems = false;

		[NonSerialized]
		private object _DataBoundItem = null;

		/// <summary>
		///       联动列表提供者名称
		///       </summary>
		[DefaultValue(null)]
		public string ProviderName
		{
			get
			{
				return _ProviderName;
			}
			set
			{
				_ProviderName = value;
				_DataBoundItem = null;
			}
		}

		/// <summary>
		///       用户自定义标记
		///       </summary>
		[DefaultValue(null)]
		public string UserFlag
		{
			get
			{
				return _UserFlag;
			}
			set
			{
				_UserFlag = value;
			}
		}

		/// <summary>
		///       是否为根列表
		///       </summary>
		[DefaultValue(false)]
		public bool IsRoot
		{
			get
			{
				return _IsRoot;
			}
			set
			{
				_IsRoot = value;
				_DataBoundItem = null;
			}
		}

		/// <summary>
		///       联动目标元素
		///       </summary>
		[DefaultValue(EventExpressionTarget.NextElement)]
		public EventExpressionTarget NextTarget
		{
			get
			{
				return _NextTarget;
			}
			set
			{
				_NextTarget = value;
			}
		}

		/// <summary>
		///       指定的联动目标元素编号,只有NextTarget属性值为NextElement时本属性才有意义。
		///       </summary>
		[DefaultValue(null)]
		public string NextTargetID
		{
			get
			{
				return _NextTargetID;
			}
			set
			{
				_NextTargetID = value;
			}
		}

		/// <summary>
		///       主动更新下一个联动目标元素的列表内容
		///       </summary>
		[DefaultValue(true)]
		public bool AutoUpdateTargetElement
		{
			get
			{
				return _AutoUpdateTargetElement;
			}
			set
			{
				_AutoUpdateTargetElement = value;
			}
		}

		/// <summary>
		///       当更新列表项目是自动设置输入域当前内容为第一个元素
		///       </summary>
		[DefaultValue(false)]
		public bool AutoSetFirstItems
		{
			get
			{
				return _AutoSetFirstItems;
			}
			set
			{
				_AutoSetFirstItems = value;
			}
		}

		/// <summary>
		///       用户自定义的绑定的数据源对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DefaultValue(null)]
		public object DataBoundItem
		{
			get
			{
				return _DataBoundItem;
			}
			set
			{
				_DataBoundItem = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public LinkListBindingInfo Clone()
		{
			return (LinkListBindingInfo)MemberwiseClone();
		}

		/// <summary>
		///       获得 表示对象内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		public string DCWriteString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}
	}
}
