using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       成员表达式信息对象
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	
	[ComDefaultInterface(typeof(IPropertyExpressionInfo))]
	[ComClass("10B4CBFE-618D-470D-9ED0-883CE63F6F90", "BD628F91-A17B-4DBF-9519-DA77C9A252D0")]
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("10B4CBFE-618D-470D-9ED0-883CE63F6F90")]
	public class PropertyExpressionInfo : IPropertyExpressionInfo
	{
		internal const string string_0 = "10B4CBFE-618D-470D-9ED0-883CE63F6F90";

		internal const string string_1 = "BD628F91-A17B-4DBF-9519-DA77C9A252D0";

		private string string_2 = null;

		private string string_3 = null;

		private bool bool_0 = true;

		/// <summary>
		///       成员名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		
		public string Name
		{
			get
			{
				return string_2;
			}
			set
			{
				if (string_2 != value)
				{
					string_2 = value;
				}
			}
		}

		/// <summary>
		///       表达式字符串
		///       </summary>
		
		[XmlText]
		[DefaultValue(null)]
		public string Expression
		{
			get
			{
				return string_3;
			}
			set
			{
				if (string_3 != value)
				{
					string_3 = value;
				}
			}
		}

		/// <summary>
		///       允许产生后续的连锁反应
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		
		public bool AllowChainReaction
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public PropertyExpressionInfo()
		{
		}

		
		public PropertyExpressionInfo method_0()
		{
			return (PropertyExpressionInfo)MemberwiseClone();
		}

		
		public override string ToString()
		{
			return Name + "=" + Expression;
		}
	}
}
