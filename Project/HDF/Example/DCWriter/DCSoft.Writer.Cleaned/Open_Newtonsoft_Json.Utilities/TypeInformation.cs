using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class TypeInformation
	{
		public Type Type
		{
			get;
			set;
		}

		public PrimitiveTypeCode TypeCode
		{
			get;
			set;
		}
	}
}
