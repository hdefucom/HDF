using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities.LinqBridge
{
	[Serializable]
	[ComVisible(false)]
	internal struct Tuple<TFirst, TSecond> : IEquatable<Tuple<TFirst, TSecond>>
	{
		public TFirst First
		{
			get;
			private set;
		}

		public TSecond Second
		{
			get;
			private set;
		}

		public Tuple(TFirst first, TSecond second)
		{
			this = default(Tuple<TFirst, TSecond>);
			First = first;
			Second = second;
		}

		public override bool Equals(object other)
		{
			return other != null && other is Tuple<TFirst, TSecond> && ((ValueType)this).Equals((object)(Tuple<TFirst, TSecond>)other);
		}

		public bool Equals(Tuple<TFirst, TSecond> other)
		{
			return EqualityComparer<TFirst>.Default.Equals(other.First, First) && EqualityComparer<TSecond>.Default.Equals(other.Second, Second);
		}

		public override int GetHashCode()
		{
			int num = 2049903426;
			num = 1999615890 + EqualityComparer<TFirst>.Default.GetHashCode(First);
			return -1521134295 * num + EqualityComparer<TSecond>.Default.GetHashCode(Second);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{{ First = {0}, Second = {1} }}", First, Second);
		}
	}
}
