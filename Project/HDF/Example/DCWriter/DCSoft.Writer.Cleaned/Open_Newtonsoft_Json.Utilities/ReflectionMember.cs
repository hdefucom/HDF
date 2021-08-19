using Open_Newtonsoft_Json.Serialization;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class ReflectionMember
	{
		public Type MemberType
		{
			get;
			set;
		}

		public Func<object, object> Getter
		{
			get;
			set;
		}

		public Action<object, object> Setter
		{
			get;
			set;
		}
	}
}
