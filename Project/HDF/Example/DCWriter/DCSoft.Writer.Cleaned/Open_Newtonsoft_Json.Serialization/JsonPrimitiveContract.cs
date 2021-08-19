using Open_Newtonsoft_Json.Utilities;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public class JsonPrimitiveContract : JsonContract
	{
		internal PrimitiveTypeCode TypeCode
		{
			get;
			set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.JsonPrimitiveContract" /> class.
		///       </summary>
		/// <param name="underlyingType">The underlying type for the contract.</param>
		public JsonPrimitiveContract(Type underlyingType)
			: base(underlyingType)
		{
			ContractType = JsonContractType.Primitive;
			TypeCode = ConvertUtils.GetTypeCode(underlyingType);
			IsReadOnlyOrFixedSize = true;
		}
	}
}
