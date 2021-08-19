using Open_Newtonsoft_Json.Serialization;
using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Serializes and deserializes objects into and from the JSON format.
	///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> enables you to control how objects are encoded into JSON.
	///       </summary>
	[ComVisible(false)]
	public class JsonSerializer
	{
		internal TypeNameHandling _typeNameHandling;

		internal FormatterAssemblyStyle _typeNameAssemblyFormat;

		internal PreserveReferencesHandling _preserveReferencesHandling;

		internal ReferenceLoopHandling _referenceLoopHandling;

		internal MissingMemberHandling _missingMemberHandling;

		internal ObjectCreationHandling _objectCreationHandling;

		internal NullValueHandling _nullValueHandling;

		internal DefaultValueHandling _defaultValueHandling;

		internal ConstructorHandling _constructorHandling;

		internal MetadataPropertyHandling _metadataPropertyHandling;

		internal JsonConverterCollection _converters;

		internal IContractResolver _contractResolver;

		internal ITraceWriter _traceWriter;

		internal IEqualityComparer _equalityComparer;

		internal SerializationBinder _binder;

		internal StreamingContext _context;

		private IReferenceResolver _referenceResolver;

		private Formatting? _formatting;

		private DateFormatHandling? _dateFormatHandling;

		private DateTimeZoneHandling? _dateTimeZoneHandling;

		private DateParseHandling? _dateParseHandling;

		private FloatFormatHandling? _floatFormatHandling;

		private FloatParseHandling? _floatParseHandling;

		private StringEscapeHandling? _stringEscapeHandling;

		private CultureInfo _culture;

		private int? _maxDepth;

		private bool _maxDepthSet;

		private bool? _checkAdditionalContent;

		private string _dateFormatString;

		private bool _dateFormatStringSet;

		/// <summary>
		///       Gets or sets the <see cref="T:Open_Newtonsoft_Json.Serialization.IReferenceResolver" /> used by the serializer when resolving references.
		///       </summary>
		public virtual IReferenceResolver ReferenceResolver
		{
			get
			{
				return GetReferenceResolver();
			}
			set
			{
				int num = 16;
				if (value == null)
				{
					throw new ArgumentNullException("value", "Reference resolver cannot be null.");
				}
				_referenceResolver = value;
			}
		}

		/// <summary>
		///       Gets or sets the <see cref="T:System.Runtime.Serialization.SerializationBinder" /> used by the serializer when resolving type names.
		///       </summary>
		public virtual SerializationBinder Binder
		{
			get
			{
				return _binder;
			}
			set
			{
				int num = 5;
				if (value == null)
				{
					throw new ArgumentNullException("value", "Serialization binder cannot be null.");
				}
				_binder = value;
			}
		}

		/// <summary>
		///       Gets or sets the <see cref="T:Open_Newtonsoft_Json.Serialization.ITraceWriter" /> used by the serializer when writing trace messages.
		///       </summary>
		/// <value>The trace writer.</value>
		public virtual ITraceWriter TraceWriter
		{
			get
			{
				return _traceWriter;
			}
			set
			{
				_traceWriter = value;
			}
		}

		/// <summary>
		///       Gets or sets the equality comparer used by the serializer when comparing references.
		///       </summary>
		/// <value>The equality comparer.</value>
		public virtual IEqualityComparer EqualityComparer
		{
			get
			{
				return _equalityComparer;
			}
			set
			{
				_equalityComparer = value;
			}
		}

		/// <summary>
		///       Gets or sets how type name writing and reading is handled by the serializer.
		///       </summary>
		public virtual TypeNameHandling TypeNameHandling
		{
			get
			{
				return _typeNameHandling;
			}
			set
			{
				int num = 5;
				if (value < TypeNameHandling.None || value > TypeNameHandling.Auto)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_typeNameHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets how a type name assembly is written and resolved by the serializer.
		///       </summary>
		/// <value>The type name assembly format.</value>
		public virtual FormatterAssemblyStyle TypeNameAssemblyFormat
		{
			get
			{
				return _typeNameAssemblyFormat;
			}
			set
			{
				int num = 1;
				if (value < FormatterAssemblyStyle.Simple || value > FormatterAssemblyStyle.Full)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_typeNameAssemblyFormat = value;
			}
		}

		/// <summary>
		///       Gets or sets how object references are preserved by the serializer.
		///       </summary>
		public virtual PreserveReferencesHandling PreserveReferencesHandling
		{
			get
			{
				return _preserveReferencesHandling;
			}
			set
			{
				int num = 9;
				if (value < PreserveReferencesHandling.None || value > PreserveReferencesHandling.All)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_preserveReferencesHandling = value;
			}
		}

		/// <summary>
		///       Get or set how reference loops (e.g. a class referencing itself) is handled.
		///       </summary>
		public virtual ReferenceLoopHandling ReferenceLoopHandling
		{
			get
			{
				return _referenceLoopHandling;
			}
			set
			{
				int num = 1;
				if (value < ReferenceLoopHandling.Error || value > ReferenceLoopHandling.Serialize)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_referenceLoopHandling = value;
			}
		}

		/// <summary>
		///       Get or set how missing members (e.g. JSON contains a property that isn't a member on the object) are handled during deserialization.
		///       </summary>
		public virtual MissingMemberHandling MissingMemberHandling
		{
			get
			{
				return _missingMemberHandling;
			}
			set
			{
				int num = 9;
				if (value < MissingMemberHandling.Ignore || value > MissingMemberHandling.Error)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_missingMemberHandling = value;
			}
		}

		/// <summary>
		///       Get or set how null values are handled during serialization and deserialization.
		///       </summary>
		public virtual NullValueHandling NullValueHandling
		{
			get
			{
				return _nullValueHandling;
			}
			set
			{
				int num = 19;
				if (value < NullValueHandling.Include || value > NullValueHandling.Ignore)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_nullValueHandling = value;
			}
		}

		/// <summary>
		///       Get or set how null default are handled during serialization and deserialization.
		///       </summary>
		public virtual DefaultValueHandling DefaultValueHandling
		{
			get
			{
				return _defaultValueHandling;
			}
			set
			{
				int num = 6;
				if (value < DefaultValueHandling.Include || value > DefaultValueHandling.IgnoreAndPopulate)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_defaultValueHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets how objects are created during deserialization.
		///       </summary>
		/// <value>The object creation handling.</value>
		public virtual ObjectCreationHandling ObjectCreationHandling
		{
			get
			{
				return _objectCreationHandling;
			}
			set
			{
				int num = 11;
				if (value < ObjectCreationHandling.Auto || value > ObjectCreationHandling.Replace)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_objectCreationHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets how constructors are used during deserialization.
		///       </summary>
		/// <value>The constructor handling.</value>
		public virtual ConstructorHandling ConstructorHandling
		{
			get
			{
				return _constructorHandling;
			}
			set
			{
				int num = 11;
				if (value < ConstructorHandling.Default || value > ConstructorHandling.AllowNonPublicDefaultConstructor)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_constructorHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets how metadata properties are used during deserialization.
		///       </summary>
		/// <value>The metadata properties handling.</value>
		public virtual MetadataPropertyHandling MetadataPropertyHandling
		{
			get
			{
				return _metadataPropertyHandling;
			}
			set
			{
				int num = 7;
				if (value < MetadataPropertyHandling.Default || value > MetadataPropertyHandling.Ignore)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_metadataPropertyHandling = value;
			}
		}

		/// <summary>
		///       Gets a collection <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> that will be used during serialization.
		///       </summary>
		/// <value>Collection <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> that will be used during serialization.</value>
		public virtual JsonConverterCollection Converters
		{
			get
			{
				if (_converters == null)
				{
					_converters = new JsonConverterCollection();
				}
				return _converters;
			}
		}

		/// <summary>
		///       Gets or sets the contract resolver used by the serializer when
		///       serializing .NET objects to JSON and vice versa.
		///       </summary>
		public virtual IContractResolver ContractResolver
		{
			get
			{
				return _contractResolver;
			}
			set
			{
				_contractResolver = (value ?? DefaultContractResolver.Instance);
			}
		}

		/// <summary>
		///       Gets or sets the <see cref="T:System.Runtime.Serialization.StreamingContext" /> used by the serializer when invoking serialization callback methods.
		///       </summary>
		/// <value>The context.</value>
		public virtual StreamingContext Context
		{
			get
			{
				return _context;
			}
			set
			{
				_context = value;
			}
		}

		/// <summary>
		///       Indicates how JSON text output is formatted.
		///       </summary>
		public virtual Formatting Formatting
		{
			get
			{
				return _formatting ?? Formatting.None;
			}
			set
			{
				_formatting = value;
			}
		}

		/// <summary>
		///       Get or set how dates are written to JSON text.
		///       </summary>
		public virtual DateFormatHandling DateFormatHandling
		{
			get
			{
				return _dateFormatHandling ?? DateFormatHandling.IsoDateFormat;
			}
			set
			{
				_dateFormatHandling = value;
			}
		}

		/// <summary>
		///       Get or set how <see cref="T:System.DateTime" /> time zones are handling during serialization and deserialization.
		///       </summary>
		public virtual DateTimeZoneHandling DateTimeZoneHandling
		{
			get
			{
				return _dateTimeZoneHandling ?? DateTimeZoneHandling.RoundtripKind;
			}
			set
			{
				_dateTimeZoneHandling = value;
			}
		}

		/// <summary>
		///       Get or set how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON.
		///       </summary>
		public virtual DateParseHandling DateParseHandling
		{
			get
			{
				return _dateParseHandling ?? DateParseHandling.DateTime;
			}
			set
			{
				_dateParseHandling = value;
			}
		}

		/// <summary>
		///       Get or set how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text.
		///       </summary>
		public virtual FloatParseHandling FloatParseHandling
		{
			get
			{
				return _floatParseHandling ?? FloatParseHandling.Double;
			}
			set
			{
				_floatParseHandling = value;
			}
		}

		/// <summary>
		///       Get or set how special floating point numbers, e.g. <see cref="F:System.Double.NaN" />,
		///       <see cref="F:System.Double.PositiveInfinity" /> and <see cref="F:System.Double.NegativeInfinity" />,
		///       are written as JSON text.
		///       </summary>
		public virtual FloatFormatHandling FloatFormatHandling
		{
			get
			{
				return _floatFormatHandling ?? FloatFormatHandling.String;
			}
			set
			{
				_floatFormatHandling = value;
			}
		}

		/// <summary>
		///       Get or set how strings are escaped when writing JSON text.
		///       </summary>
		public virtual StringEscapeHandling StringEscapeHandling
		{
			get
			{
				return _stringEscapeHandling ?? StringEscapeHandling.Default;
			}
			set
			{
				_stringEscapeHandling = value;
			}
		}

		/// <summary>
		///       Get or set how <see cref="T:System.DateTime" /> and <see cref="T:System.DateTimeOffset" /> values are formatted when writing JSON text, and the expected date format when reading JSON text.
		///       </summary>
		public virtual string DateFormatString
		{
			get
			{
				int num = 17;
				return _dateFormatString ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
			}
			set
			{
				_dateFormatString = value;
				_dateFormatStringSet = true;
			}
		}

		/// <summary>
		///       Gets or sets the culture used when reading JSON. Defaults to <see cref="P:System.Globalization.CultureInfo.InvariantCulture" />.
		///       </summary>
		public virtual CultureInfo Culture
		{
			get
			{
				return _culture ?? JsonSerializerSettings.DefaultCulture;
			}
			set
			{
				_culture = value;
			}
		}

		/// <summary>
		///       Gets or sets the maximum depth allowed when reading JSON. Reading past this depth will throw a <see cref="T:Open_Newtonsoft_Json.JsonReaderException" />.
		///       </summary>
		public virtual int? MaxDepth
		{
			get
			{
				return _maxDepth;
			}
			set
			{
				int num = 11;
				if (value <= 0)
				{
					throw new ArgumentException("Value must be positive.", "value");
				}
				_maxDepth = value;
				_maxDepthSet = true;
			}
		}

		/// <summary>
		///       Gets a value indicating whether there will be a check for additional JSON content after deserializing an object.
		///       </summary>
		/// <value>
		///   <c>true</c> if there will be a check for additional JSON content after deserializing an object; otherwise, <c>false</c>.
		///       </value>
		public virtual bool CheckAdditionalContent
		{
			get
			{
				return _checkAdditionalContent ?? false;
			}
			set
			{
				_checkAdditionalContent = value;
			}
		}

		/// <summary>
		///       Occurs when the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> errors during serialization and deserialization.
		///       </summary>
		public virtual event EventHandler<Open_Newtonsoft_Json.Serialization.ErrorEventArgs> Error;

		internal bool IsCheckAdditionalContentSet()
		{
			return _checkAdditionalContent.HasValue;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> class.
		///       </summary>
		public JsonSerializer()
		{
			_referenceLoopHandling = ReferenceLoopHandling.Error;
			_missingMemberHandling = MissingMemberHandling.Ignore;
			_nullValueHandling = NullValueHandling.Include;
			_defaultValueHandling = DefaultValueHandling.Include;
			_objectCreationHandling = ObjectCreationHandling.Auto;
			_preserveReferencesHandling = PreserveReferencesHandling.None;
			_constructorHandling = ConstructorHandling.Default;
			_typeNameHandling = TypeNameHandling.None;
			_metadataPropertyHandling = MetadataPropertyHandling.Default;
			_context = JsonSerializerSettings.DefaultContext;
			_binder = DefaultSerializationBinder.Instance;
			_culture = JsonSerializerSettings.DefaultCulture;
			_contractResolver = DefaultContractResolver.Instance;
		}

		/// <summary>
		///       Creates a new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will not use default settings.
		///       </summary>
		/// <returns>
		///       A new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will not use default settings.
		///       </returns>
		public static JsonSerializer Create()
		{
			return new JsonSerializer();
		}

		/// <summary>
		///       Creates a new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializerSettings" />.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will not use default settings.
		///       </summary>
		/// <param name="settings">The settings to be applied to the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.</param>
		/// <returns>
		///       A new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializerSettings" />.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will not use default settings.
		///       </returns>
		public static JsonSerializer Create(JsonSerializerSettings settings)
		{
			JsonSerializer jsonSerializer = Create();
			if (settings != null)
			{
				ApplySerializerSettings(jsonSerializer, settings);
			}
			return jsonSerializer;
		}

		/// <summary>
		///       Creates a new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will use default settings.
		///       </summary>
		/// <returns>
		///       A new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will use default settings.
		///       </returns>
		public static JsonSerializer CreateDefault()
		{
			JsonSerializerSettings settings = JsonConvert.DefaultSettings?.Invoke();
			return Create(settings);
		}

		/// <summary>
		///       Creates a new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializerSettings" />.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will use default settings.
		///       </summary>
		/// <param name="settings">The settings to be applied to the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.</param>
		/// <returns>
		///       A new <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> instance using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializerSettings" />.
		///       The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> will use default settings.
		///       </returns>
		public static JsonSerializer CreateDefault(JsonSerializerSettings settings)
		{
			JsonSerializer jsonSerializer = CreateDefault();
			if (settings != null)
			{
				ApplySerializerSettings(jsonSerializer, settings);
			}
			return jsonSerializer;
		}

		private static void ApplySerializerSettings(JsonSerializer serializer, JsonSerializerSettings settings)
		{
			if (!CollectionUtils.IsNullOrEmpty(settings.Converters))
			{
				for (int i = 0; i < settings.Converters.Count; i++)
				{
					serializer.Converters.Insert(i, settings.Converters[i]);
				}
			}
			if (settings._typeNameHandling.HasValue)
			{
				serializer.TypeNameHandling = settings.TypeNameHandling;
			}
			if (settings._metadataPropertyHandling.HasValue)
			{
				serializer.MetadataPropertyHandling = settings.MetadataPropertyHandling;
			}
			if (settings._typeNameAssemblyFormat.HasValue)
			{
				serializer.TypeNameAssemblyFormat = settings.TypeNameAssemblyFormat;
			}
			if (settings._preserveReferencesHandling.HasValue)
			{
				serializer.PreserveReferencesHandling = settings.PreserveReferencesHandling;
			}
			if (settings._referenceLoopHandling.HasValue)
			{
				serializer.ReferenceLoopHandling = settings.ReferenceLoopHandling;
			}
			if (settings._missingMemberHandling.HasValue)
			{
				serializer.MissingMemberHandling = settings.MissingMemberHandling;
			}
			if (settings._objectCreationHandling.HasValue)
			{
				serializer.ObjectCreationHandling = settings.ObjectCreationHandling;
			}
			if (settings._nullValueHandling.HasValue)
			{
				serializer.NullValueHandling = settings.NullValueHandling;
			}
			if (settings._defaultValueHandling.HasValue)
			{
				serializer.DefaultValueHandling = settings.DefaultValueHandling;
			}
			if (settings._constructorHandling.HasValue)
			{
				serializer.ConstructorHandling = settings.ConstructorHandling;
			}
			if (settings._context.HasValue)
			{
				serializer.Context = settings.Context;
			}
			if (settings._checkAdditionalContent.HasValue)
			{
				serializer._checkAdditionalContent = settings._checkAdditionalContent;
			}
			if (settings.Error != null)
			{
				serializer.Error += settings.Error;
			}
			if (settings.ContractResolver != null)
			{
				serializer.ContractResolver = settings.ContractResolver;
			}
			if (settings.ReferenceResolverProvider != null)
			{
				serializer.ReferenceResolver = settings.ReferenceResolverProvider();
			}
			if (settings.TraceWriter != null)
			{
				serializer.TraceWriter = settings.TraceWriter;
			}
			if (settings.EqualityComparer != null)
			{
				serializer.EqualityComparer = settings.EqualityComparer;
			}
			if (settings.Binder != null)
			{
				serializer.Binder = settings.Binder;
			}
			if (settings._formatting.HasValue)
			{
				serializer._formatting = settings._formatting;
			}
			if (settings._dateFormatHandling.HasValue)
			{
				serializer._dateFormatHandling = settings._dateFormatHandling;
			}
			if (settings._dateTimeZoneHandling.HasValue)
			{
				serializer._dateTimeZoneHandling = settings._dateTimeZoneHandling;
			}
			if (settings._dateParseHandling.HasValue)
			{
				serializer._dateParseHandling = settings._dateParseHandling;
			}
			if (settings._dateFormatStringSet)
			{
				serializer._dateFormatString = settings._dateFormatString;
				serializer._dateFormatStringSet = settings._dateFormatStringSet;
			}
			if (settings._floatFormatHandling.HasValue)
			{
				serializer._floatFormatHandling = settings._floatFormatHandling;
			}
			if (settings._floatParseHandling.HasValue)
			{
				serializer._floatParseHandling = settings._floatParseHandling;
			}
			if (settings._stringEscapeHandling.HasValue)
			{
				serializer._stringEscapeHandling = settings._stringEscapeHandling;
			}
			if (settings._culture != null)
			{
				serializer._culture = settings._culture;
			}
			if (settings._maxDepthSet)
			{
				serializer._maxDepth = settings._maxDepth;
				serializer._maxDepthSet = settings._maxDepthSet;
			}
		}

		/// <summary>
		///       Populates the JSON values onto the target object.
		///       </summary>
		/// <param name="reader">The <see cref="T:System.IO.TextReader" /> that contains the JSON structure to reader values from.</param>
		/// <param name="target">The target object to populate values onto.</param>
		public void Populate(TextReader reader, object target)
		{
			Populate(new JsonTextReader(reader), target);
		}

		/// <summary>
		///       Populates the JSON values onto the target object.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> that contains the JSON structure to reader values from.</param>
		/// <param name="target">The target object to populate values onto.</param>
		public void Populate(JsonReader reader, object target)
		{
			PopulateInternal(reader, target);
		}

		internal virtual void PopulateInternal(JsonReader reader, object target)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			ValidationUtils.ArgumentNotNull(target, "target");
			SetupReader(reader, out CultureInfo previousCulture, out DateTimeZoneHandling? previousDateTimeZoneHandling, out DateParseHandling? previousDateParseHandling, out FloatParseHandling? previousFloatParseHandling, out int? previousMaxDepth, out string previousDateFormatString);
			TraceJsonReader traceJsonReader = (TraceWriter == null || TraceWriter.LevelFilter < TraceLevel.Verbose) ? null : new TraceJsonReader(reader);
			JsonSerializerInternalReader jsonSerializerInternalReader = new JsonSerializerInternalReader(this);
			jsonSerializerInternalReader.Populate(traceJsonReader ?? reader, target);
			if (traceJsonReader != null)
			{
				TraceWriter.Trace(TraceLevel.Verbose, traceJsonReader.GetDeserializedJsonMessage(), null);
			}
			ResetReader(reader, previousCulture, previousDateTimeZoneHandling, previousDateParseHandling, previousFloatParseHandling, previousMaxDepth, previousDateFormatString);
		}

		/// <summary>
		///       Deserializes the JSON structure contained by the specified <see cref="T:Open_Newtonsoft_Json.JsonReader" />.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> that contains the JSON structure to deserialize.</param>
		/// <returns>The <see cref="T:System.Object" /> being deserialized.</returns>
		public object Deserialize(JsonReader reader)
		{
			return Deserialize(reader, null);
		}

		/// <summary>
		///       Deserializes the JSON structure contained by the specified <see cref="T:System.IO.StringReader" />
		///       into an instance of the specified type.
		///       </summary>
		/// <param name="reader">The <see cref="T:System.IO.TextReader" /> containing the object.</param>
		/// <param name="objectType">The <see cref="T:System.Type" /> of object being deserialized.</param>
		/// <returns>The instance of <paramref name="objectType" /> being deserialized.</returns>
		public object Deserialize(TextReader reader, Type objectType)
		{
			return Deserialize(new JsonTextReader(reader), objectType);
		}

		/// <summary>
		///       Deserializes the JSON structure contained by the specified <see cref="T:Open_Newtonsoft_Json.JsonReader" />
		///       into an instance of the specified type.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> containing the object.</param>
		/// <typeparam name="T">The type of the object to deserialize.</typeparam>
		/// <returns>The instance of <typeparamref name="T" /> being deserialized.</returns>
		public T Deserialize<T>(JsonReader reader)
		{
			return (T)Deserialize(reader, typeof(T));
		}

		/// <summary>
		///       Deserializes the JSON structure contained by the specified <see cref="T:Open_Newtonsoft_Json.JsonReader" />
		///       into an instance of the specified type.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> containing the object.</param>
		/// <param name="objectType">The <see cref="T:System.Type" /> of object being deserialized.</param>
		/// <returns>The instance of <paramref name="objectType" /> being deserialized.</returns>
		public object Deserialize(JsonReader reader, Type objectType)
		{
			return DeserializeInternal(reader, objectType);
		}

		internal virtual object DeserializeInternal(JsonReader reader, Type objectType)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			SetupReader(reader, out CultureInfo previousCulture, out DateTimeZoneHandling? previousDateTimeZoneHandling, out DateParseHandling? previousDateParseHandling, out FloatParseHandling? previousFloatParseHandling, out int? previousMaxDepth, out string previousDateFormatString);
			TraceJsonReader traceJsonReader = (TraceWriter == null || TraceWriter.LevelFilter < TraceLevel.Verbose) ? null : new TraceJsonReader(reader);
			JsonSerializerInternalReader jsonSerializerInternalReader = new JsonSerializerInternalReader(this);
			object result = jsonSerializerInternalReader.Deserialize(traceJsonReader ?? reader, objectType, CheckAdditionalContent);
			if (traceJsonReader != null)
			{
				TraceWriter.Trace(TraceLevel.Verbose, traceJsonReader.GetDeserializedJsonMessage(), null);
			}
			ResetReader(reader, previousCulture, previousDateTimeZoneHandling, previousDateParseHandling, previousFloatParseHandling, previousMaxDepth, previousDateFormatString);
			return result;
		}

		private void SetupReader(JsonReader reader, out CultureInfo previousCulture, out DateTimeZoneHandling? previousDateTimeZoneHandling, out DateParseHandling? previousDateParseHandling, out FloatParseHandling? previousFloatParseHandling, out int? previousMaxDepth, out string previousDateFormatString)
		{
			if (_culture != null && !_culture.Equals(reader.Culture))
			{
				previousCulture = reader.Culture;
				reader.Culture = _culture;
			}
			else
			{
				previousCulture = null;
			}
			if (_dateTimeZoneHandling.HasValue && reader.DateTimeZoneHandling != _dateTimeZoneHandling)
			{
				previousDateTimeZoneHandling = reader.DateTimeZoneHandling;
				reader.DateTimeZoneHandling = _dateTimeZoneHandling.Value;
			}
			else
			{
				previousDateTimeZoneHandling = null;
			}
			if (_dateParseHandling.HasValue && reader.DateParseHandling != _dateParseHandling)
			{
				previousDateParseHandling = reader.DateParseHandling;
				reader.DateParseHandling = _dateParseHandling.Value;
			}
			else
			{
				previousDateParseHandling = null;
			}
			if (_floatParseHandling.HasValue && reader.FloatParseHandling != _floatParseHandling)
			{
				previousFloatParseHandling = reader.FloatParseHandling;
				reader.FloatParseHandling = _floatParseHandling.Value;
			}
			else
			{
				previousFloatParseHandling = null;
			}
			if (_maxDepthSet && reader.MaxDepth != _maxDepth)
			{
				previousMaxDepth = reader.MaxDepth;
				reader.MaxDepth = _maxDepth;
			}
			else
			{
				previousMaxDepth = null;
			}
			if (_dateFormatStringSet && reader.DateFormatString != _dateFormatString)
			{
				previousDateFormatString = reader.DateFormatString;
				reader.DateFormatString = _dateFormatString;
			}
			else
			{
				previousDateFormatString = null;
			}
			JsonTextReader jsonTextReader = reader as JsonTextReader;
			if (jsonTextReader != null)
			{
				DefaultContractResolver defaultContractResolver = _contractResolver as DefaultContractResolver;
				if (defaultContractResolver != null)
				{
					jsonTextReader.NameTable = defaultContractResolver.GetState().NameTable;
				}
			}
		}

		private void ResetReader(JsonReader reader, CultureInfo previousCulture, DateTimeZoneHandling? previousDateTimeZoneHandling, DateParseHandling? previousDateParseHandling, FloatParseHandling? previousFloatParseHandling, int? previousMaxDepth, string previousDateFormatString)
		{
			if (previousCulture != null)
			{
				reader.Culture = previousCulture;
			}
			if (previousDateTimeZoneHandling.HasValue)
			{
				reader.DateTimeZoneHandling = previousDateTimeZoneHandling.Value;
			}
			if (previousDateParseHandling.HasValue)
			{
				reader.DateParseHandling = previousDateParseHandling.Value;
			}
			if (previousFloatParseHandling.HasValue)
			{
				reader.FloatParseHandling = previousFloatParseHandling.Value;
			}
			if (_maxDepthSet)
			{
				reader.MaxDepth = previousMaxDepth;
			}
			if (_dateFormatStringSet)
			{
				reader.DateFormatString = previousDateFormatString;
			}
			JsonTextReader jsonTextReader = reader as JsonTextReader;
			if (jsonTextReader != null)
			{
				jsonTextReader.NameTable = null;
			}
		}

		/// <summary>
		///       Serializes the specified <see cref="T:System.Object" /> and writes the JSON structure
		///       to a <c>Stream</c> using the specified <see cref="T:System.IO.TextWriter" />. 
		///       </summary>
		/// <param name="textWriter">The <see cref="T:System.IO.TextWriter" /> used to write the JSON structure.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to serialize.</param>
		public void Serialize(TextWriter textWriter, object value)
		{
			Serialize(new JsonTextWriter(textWriter), value);
		}

		/// <summary>
		///       Serializes the specified <see cref="T:System.Object" /> and writes the JSON structure
		///       to a <c>Stream</c> using the specified <see cref="T:System.IO.TextWriter" />. 
		///       </summary>
		/// <param name="jsonWriter">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> used to write the JSON structure.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to serialize.</param>
		/// <param name="objectType">
		///       The type of the value being serialized.
		///       This parameter is used when <see cref="P:Open_Newtonsoft_Json.JsonSerializer.TypeNameHandling" /> is Auto to write out the type name if the type of the value does not match.
		///       Specifing the type is optional.
		///       </param>
		public void Serialize(JsonWriter jsonWriter, object value, Type objectType)
		{
			SerializeInternal(jsonWriter, value, objectType);
		}

		/// <summary>
		///       Serializes the specified <see cref="T:System.Object" /> and writes the JSON structure
		///       to a <c>Stream</c> using the specified <see cref="T:System.IO.TextWriter" />. 
		///       </summary>
		/// <param name="textWriter">The <see cref="T:System.IO.TextWriter" /> used to write the JSON structure.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to serialize.</param>
		/// <param name="objectType">
		///       The type of the value being serialized.
		///       This parameter is used when <see cref="P:Open_Newtonsoft_Json.JsonSerializer.TypeNameHandling" /> is Auto to write out the type name if the type of the value does not match.
		///       Specifing the type is optional.
		///       </param>
		public void Serialize(TextWriter textWriter, object value, Type objectType)
		{
			Serialize(new JsonTextWriter(textWriter), value, objectType);
		}

		/// <summary>
		///       Serializes the specified <see cref="T:System.Object" /> and writes the JSON structure
		///       to a <c>Stream</c> using the specified <see cref="T:Open_Newtonsoft_Json.JsonWriter" />. 
		///       </summary>
		/// <param name="jsonWriter">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> used to write the JSON structure.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to serialize.</param>
		public void Serialize(JsonWriter jsonWriter, object value)
		{
			SerializeInternal(jsonWriter, value, null);
		}

		internal virtual void SerializeInternal(JsonWriter jsonWriter, object value, Type objectType)
		{
			ValidationUtils.ArgumentNotNull(jsonWriter, "jsonWriter");
			Formatting? formatting = null;
			if (_formatting.HasValue && jsonWriter.Formatting != _formatting)
			{
				formatting = jsonWriter.Formatting;
				jsonWriter.Formatting = _formatting.Value;
			}
			DateFormatHandling? dateFormatHandling = null;
			if (_dateFormatHandling.HasValue && jsonWriter.DateFormatHandling != _dateFormatHandling)
			{
				dateFormatHandling = jsonWriter.DateFormatHandling;
				jsonWriter.DateFormatHandling = _dateFormatHandling.Value;
			}
			DateTimeZoneHandling? dateTimeZoneHandling = null;
			if (_dateTimeZoneHandling.HasValue && jsonWriter.DateTimeZoneHandling != _dateTimeZoneHandling)
			{
				dateTimeZoneHandling = jsonWriter.DateTimeZoneHandling;
				jsonWriter.DateTimeZoneHandling = _dateTimeZoneHandling.Value;
			}
			FloatFormatHandling? floatFormatHandling = null;
			if (_floatFormatHandling.HasValue && jsonWriter.FloatFormatHandling != _floatFormatHandling)
			{
				floatFormatHandling = jsonWriter.FloatFormatHandling;
				jsonWriter.FloatFormatHandling = _floatFormatHandling.Value;
			}
			StringEscapeHandling? stringEscapeHandling = null;
			if (_stringEscapeHandling.HasValue && jsonWriter.StringEscapeHandling != _stringEscapeHandling)
			{
				stringEscapeHandling = jsonWriter.StringEscapeHandling;
				jsonWriter.StringEscapeHandling = _stringEscapeHandling.Value;
			}
			CultureInfo cultureInfo = null;
			if (_culture != null && !_culture.Equals(jsonWriter.Culture))
			{
				cultureInfo = jsonWriter.Culture;
				jsonWriter.Culture = _culture;
			}
			string dateFormatString = null;
			if (_dateFormatStringSet && jsonWriter.DateFormatString != _dateFormatString)
			{
				dateFormatString = jsonWriter.DateFormatString;
				jsonWriter.DateFormatString = _dateFormatString;
			}
			TraceJsonWriter traceJsonWriter = (TraceWriter == null || TraceWriter.LevelFilter < TraceLevel.Verbose) ? null : new TraceJsonWriter(jsonWriter);
			JsonSerializerInternalWriter jsonSerializerInternalWriter = new JsonSerializerInternalWriter(this);
			jsonSerializerInternalWriter.Serialize(traceJsonWriter ?? jsonWriter, value, objectType);
			if (traceJsonWriter != null)
			{
				TraceWriter.Trace(TraceLevel.Verbose, traceJsonWriter.GetSerializedJsonMessage(), null);
			}
			if (formatting.HasValue)
			{
				jsonWriter.Formatting = formatting.Value;
			}
			if (dateFormatHandling.HasValue)
			{
				jsonWriter.DateFormatHandling = dateFormatHandling.Value;
			}
			if (dateTimeZoneHandling.HasValue)
			{
				jsonWriter.DateTimeZoneHandling = dateTimeZoneHandling.Value;
			}
			if (floatFormatHandling.HasValue)
			{
				jsonWriter.FloatFormatHandling = floatFormatHandling.Value;
			}
			if (stringEscapeHandling.HasValue)
			{
				jsonWriter.StringEscapeHandling = stringEscapeHandling.Value;
			}
			if (_dateFormatStringSet)
			{
				jsonWriter.DateFormatString = dateFormatString;
			}
			if (cultureInfo != null)
			{
				jsonWriter.Culture = cultureInfo;
			}
		}

		internal IReferenceResolver GetReferenceResolver()
		{
			if (_referenceResolver == null)
			{
				_referenceResolver = new DefaultReferenceResolver();
			}
			return _referenceResolver;
		}

		internal JsonConverter GetMatchingConverter(Type type)
		{
			return GetMatchingConverter(_converters, type);
		}

		internal static JsonConverter GetMatchingConverter(IList<JsonConverter> converters, Type objectType)
		{
			ValidationUtils.ArgumentNotNull(objectType, "objectType");
			if (converters != null)
			{
				for (int i = 0; i < converters.Count; i++)
				{
					JsonConverter jsonConverter = converters[i];
					if (jsonConverter.CanConvert(objectType))
					{
						return jsonConverter;
					}
				}
			}
			return null;
		}

		internal void OnError(Open_Newtonsoft_Json.Serialization.ErrorEventArgs errorEventArgs_0)
		{
			this.Error?.Invoke(this, errorEventArgs_0);
		}
	}
}
