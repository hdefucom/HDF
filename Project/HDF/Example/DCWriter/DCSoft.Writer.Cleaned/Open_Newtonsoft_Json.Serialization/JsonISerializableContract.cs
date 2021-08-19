using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public class JsonISerializableContract : JsonContainerContract
	{
		/// <summary>
		///       Gets or sets the ISerializable object constructor.
		///       </summary>
		/// <value>The ISerializable object constructor.</value>
		public ObjectConstructor<object> ISerializableCreator
		{
			get;
			set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.JsonISerializableContract" /> class.
		///       </summary>
		/// <param name="underlyingType">The underlying type for the contract.</param>
		public JsonISerializableContract(Type underlyingType)
			: base(underlyingType)
		{
			ContractType = JsonContractType.Serializable;
		}
	}
}
