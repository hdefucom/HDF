using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       The default serialization binder used when resolving and loading classes from type names.
	///       </summary>
	[ComVisible(false)]
	public class DefaultSerializationBinder : SerializationBinder
	{
		[ComVisible(false)]
		internal struct TypeNameKey : IEquatable<TypeNameKey>
		{
			internal readonly string AssemblyName;

			internal readonly string TypeName;

			public TypeNameKey(string assemblyName, string typeName)
			{
				AssemblyName = assemblyName;
				TypeName = typeName;
			}

			public override int GetHashCode()
			{
				return ((AssemblyName != null) ? AssemblyName.GetHashCode() : 0) ^ ((TypeName != null) ? TypeName.GetHashCode() : 0);
			}

			public override bool Equals(object other)
			{
				if (!(other is TypeNameKey))
				{
					return false;
				}
				return Equals((TypeNameKey)other);
			}

			public bool Equals(TypeNameKey other)
			{
				return AssemblyName == other.AssemblyName && TypeName == other.TypeName;
			}
		}

		internal static readonly DefaultSerializationBinder Instance = new DefaultSerializationBinder();

		private readonly ThreadSafeStore<TypeNameKey, Type> _typeCache = new ThreadSafeStore<TypeNameKey, Type>(GetTypeFromTypeNameKey);

		private static Type GetTypeFromTypeNameKey(TypeNameKey typeNameKey)
		{
			int num = 19;
			string assemblyName = typeNameKey.AssemblyName;
			string typeName = typeNameKey.TypeName;
			if (assemblyName != null)
			{
				Assembly assembly = Assembly.LoadWithPartialName(assemblyName);
				if (assembly == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					Assembly[] array = assemblies;
					foreach (Assembly assembly2 in array)
					{
						if (assembly2.FullName == assemblyName)
						{
							assembly = assembly2;
							break;
						}
					}
				}
				if (assembly == null)
				{
					throw new JsonSerializationException(StringUtils.FormatWith("Could not load assembly '{0}'.", CultureInfo.InvariantCulture, assemblyName));
				}
				Type type = assembly.GetType(typeName);
				if (type == null)
				{
					throw new JsonSerializationException(StringUtils.FormatWith("Could not find type '{0}' in assembly '{1}'.", CultureInfo.InvariantCulture, typeName, assembly.FullName));
				}
				return type;
			}
			return Type.GetType(typeName);
		}

		/// <summary>
		///       When overridden in a derived class, controls the binding of a serialized object to a type.
		///       </summary>
		/// <param name="assemblyName">Specifies the <see cref="T:System.Reflection.Assembly" /> name of the serialized object.</param>
		/// <param name="typeName">Specifies the <see cref="T:System.Type" /> name of the serialized object.</param>
		/// <returns>
		///       The type of the object the formatter creates a new instance of.
		///       </returns>
		public override Type BindToType(string assemblyName, string typeName)
		{
			return _typeCache.Get(new TypeNameKey(assemblyName, typeName));
		}
	}
}
