using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies the member serialization options for the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public enum MemberSerialization
	{
		/// <summary>
		///       All public members are serialized by default. Members can be excluded using <see cref="T:Open_Newtonsoft_Json.JsonIgnoreAttribute" /> or <see cref="T:System.NonSerializedAttribute" />.
		///       This is the default member serialization mode.
		///       </summary>
		OptOut,
		/// <summary>
		///       Only members must be marked with <see cref="T:Open_Newtonsoft_Json.JsonPropertyAttribute" /> or <see cref="!:DataMemberAttribute" /> are serialized.
		///       This member serialization mode can also be set by marking the class with <see cref="!:DataContractAttribute" />.
		///       </summary>
		OptIn,
		/// <summary>
		///       All public and private fields are serialized. Members can be excluded using <see cref="T:Open_Newtonsoft_Json.JsonIgnoreAttribute" /> or <see cref="T:System.NonSerializedAttribute" />.
		///       This member serialization mode can also be set by marking the class with <see cref="T:System.SerializableAttribute" />
		///       and setting IgnoreSerializableAttribute on <see cref="T:Open_Newtonsoft_Json.Serialization.DefaultContractResolver" /> to false.
		///       </summary>
		Fields
	}
}
