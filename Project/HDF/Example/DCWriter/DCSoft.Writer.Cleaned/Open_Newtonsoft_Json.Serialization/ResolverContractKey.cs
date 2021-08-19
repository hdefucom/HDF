using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal struct ResolverContractKey : IEquatable<ResolverContractKey>
	{
		private readonly Type _resolverType;

		private readonly Type _contractType;

		public ResolverContractKey(Type resolverType, Type contractType)
		{
			_resolverType = resolverType;
			_contractType = contractType;
		}

		public override int GetHashCode()
		{
			return _resolverType.GetHashCode() ^ _contractType.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (!(other is ResolverContractKey))
			{
				return false;
			}
			return Equals((ResolverContractKey)other);
		}

		public bool Equals(ResolverContractKey other)
		{
			return _resolverType == other._resolverType && _contractType == other._contractType;
		}
	}
}
