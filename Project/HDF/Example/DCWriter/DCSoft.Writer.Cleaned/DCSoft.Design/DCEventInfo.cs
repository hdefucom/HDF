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
	                                                                    ///       事件信息对象
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCEventInfo : DCMemberInfo
	{
		private DCTypeInfo myEventHandlerType = null;

		private string _EventHandlerTypeID = null;

		private bool bolIsMulticast = true;

		private bool bolIsSpecialName = false;

		                                                                    /// <summary>
		                                                                    ///       事件委托类型
		                                                                    ///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		public DCTypeInfo EventHandlerType
		{
			get
			{
				return myEventHandlerType;
			}
			set
			{
				myEventHandlerType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       事件委托类型编号
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string EventHandlerTypeID
		{
			get
			{
				if (myEventHandlerType == null)
				{
					return _EventHandlerTypeID;
				}
				return myEventHandlerType.ID;
			}
			set
			{
				_EventHandlerTypeID = value;
			}
		}

		[DefaultValue(true)]
		public bool IsMulticast
		{
			get
			{
				return bolIsMulticast;
			}
			set
			{
				bolIsMulticast = value;
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

		public override MemberTypes MemberType => MemberTypes.Event;

		public override string ToString()
		{
			return "Event:" + base.Name;
		}

		public override string ToShortString()
		{
			return base.Name;
		}

		public override string ToLongString()
		{
			int num = 1;
			new StringBuilder();
			if (EventHandlerType == null)
			{
				return "public event [VOID] " + _Name;
			}
			return "public event " + EventHandlerType.CSharpName + " " + _Name;
		}

		public override bool EqualsMark(DCMemberInfo member)
		{
			DCEventInfo dCEventInfo = member as DCEventInfo;
			if (dCEventInfo != null)
			{
				return dCEventInfo.EventHandlerType == EventHandlerType;
			}
			return false;
		}
	}
}
