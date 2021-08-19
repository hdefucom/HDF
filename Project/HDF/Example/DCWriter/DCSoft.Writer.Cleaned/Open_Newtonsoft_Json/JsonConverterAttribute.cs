using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> to use the specified <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> when serializing the member or class.
	///       </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Parameter, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class JsonConverterAttribute : Attribute
	{
		private readonly Type _converterType;

		/// <summary>
		///       Gets the <see cref="T:System.Type" /> of the converter.
		///       </summary>
		/// <value>The <see cref="T:System.Type" /> of the converter.</value>
		public Type ConverterType => _converterType;

		/// <summary>
		///       The parameter list to use when constructing the JsonConverter described by ConverterType.  
		///       If null, the default constructor is used.
		///       </summary>
		public object[] ConverterParameters
		{
			get;
			private set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonConverterAttribute" /> class.
		///       </summary>
		/// <param name="converterType">Type of the converter.</param>
		public JsonConverterAttribute(Type converterType)
		{
			int num = 3;
			
			if (converterType == null)
			{
				throw new ArgumentNullException("converterType");
			}
			_converterType = converterType;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonConverterAttribute" /> class.
		///       </summary>
		/// <param name="converterType">Type of the converter.</param>
		/// <param name="converterParameters">Parameter list to use when constructing the JsonConverter. Can be null.</param>
		public JsonConverterAttribute(Type converterType, params object[] converterParameters)
			: this(converterType)
		{
			ConverterParameters = converterParameters;
		}
	}
}
