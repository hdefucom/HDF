using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    /// </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class CustomProperty
	{
		private string _name = string.Empty;

		private object _defaultValue = null;

		private object _value = null;

		private object _objectSource = null;

		private PropertyInfo[] _propertyInfos = null;

		private string _DisplayName = null;

		private string[] myPropertyNames = null;

		private Type myValueType = typeof(object);

		private bool bolIsReadOnly = false;

		private string strDescription = null;

		private string strCategory = null;

		private bool bolIsBrowsable = true;

		private Type myEditorType = null;

		private object objTag = null;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				if (PropertyNames == null)
				{
					PropertyNames = new string[1]
					{
						_name
					};
				}
			}
		}

		public string DisplayName
		{
			get
			{
				return _DisplayName;
			}
			set
			{
				_DisplayName = value;
			}
		}

		public string[] PropertyNames
		{
			get
			{
				return myPropertyNames;
			}
			set
			{
				myPropertyNames = value;
			}
		}

		public Type ValueType
		{
			get
			{
				return myValueType;
			}
			set
			{
				myValueType = value;
			}
		}

		public object DefaultValue
		{
			get
			{
				return _defaultValue;
			}
			set
			{
				_defaultValue = value;
				if (_defaultValue != null)
				{
					if (_value == null)
					{
						_value = _defaultValue;
					}
					if (ValueType == null)
					{
						ValueType = _defaultValue.GetType();
					}
				}
			}
		}

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				OnValueChanged();
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return bolIsReadOnly;
			}
			set
			{
				bolIsReadOnly = value;
			}
		}

		public string Description
		{
			get
			{
				return strDescription;
			}
			set
			{
				strDescription = value;
			}
		}

		public string Category
		{
			get
			{
				return strCategory;
			}
			set
			{
				strCategory = value;
			}
		}

		public bool IsBrowsable
		{
			get
			{
				return bolIsBrowsable;
			}
			set
			{
				bolIsBrowsable = value;
			}
		}

		public object ObjectSource
		{
			get
			{
				return _objectSource;
			}
			set
			{
				_objectSource = value;
				OnObjectSourceChanged();
			}
		}

		public Type EditorType
		{
			get
			{
				return myEditorType;
			}
			set
			{
				myEditorType = value;
			}
		}

		protected PropertyInfo[] PropertyInfos
		{
			get
			{
				if (_propertyInfos == null)
				{
					Type type = ObjectSource.GetType();
					_propertyInfos = new PropertyInfo[PropertyNames.Length];
					for (int i = 0; i < PropertyNames.Length; i++)
					{
						_propertyInfos[i] = type.GetProperty(PropertyNames[i]);
					}
				}
				return _propertyInfos;
			}
		}

		public object Tag
		{
			get
			{
				return objTag;
			}
			set
			{
				objTag = value;
			}
		}

		public CustomProperty()
		{
		}

		public CustomProperty(string name, object vValue)
		{
			_name = name;
			_value = vValue;
			if (vValue != null)
			{
				myValueType = vValue.GetType();
			}
		}

		public CustomProperty(string name, string category, string description, object objectSource)
			: this(name, name, null, category, description, objectSource, null)
		{
		}

		public CustomProperty(string name, string propertyName, string category, string description, object objectSource)
			: this(name, propertyName, null, category, description, objectSource, null)
		{
		}

		public CustomProperty(string name, string propertyName, string category, string description, object objectSource, Type editorType)
			: this(name, propertyName, null, category, description, objectSource, editorType)
		{
		}

		public CustomProperty(string name, string propertyName, Type valueType, string category, string description, object objectSource, Type editorType)
			: this(name, new string[1]
			{
				propertyName
			}, valueType, null, null, isReadOnly: false, isBrowsable: true, category, description, objectSource, editorType)
		{
		}

		public CustomProperty(string name, string[] propertyNames, string category, string description, object objectSource)
			: this(name, propertyNames, category, description, objectSource, null)
		{
		}

		public CustomProperty(string name, string[] propertyNames, string category, string description, object objectSource, Type editorType)
			: this(name, propertyNames, null, category, description, objectSource, editorType)
		{
		}

		public CustomProperty(string name, string[] propertyNames, Type valueType, string category, string description, object objectSource, Type editorType)
			: this(name, propertyNames, valueType, null, null, isReadOnly: false, isBrowsable: true, category, description, objectSource, editorType)
		{
		}

		public CustomProperty(string name, string[] propertyNames, Type valueType, object defaultValue, object value, bool isReadOnly, bool isBrowsable, string category, string description, object objectSource, Type editorType)
		{
			Name = name;
			PropertyNames = propertyNames;
			ValueType = valueType;
			_defaultValue = defaultValue;
			_value = value;
			IsReadOnly = isReadOnly;
			IsBrowsable = isBrowsable;
			Category = category;
			Description = description;
			ObjectSource = objectSource;
			EditorType = editorType;
		}

		protected void OnObjectSourceChanged()
		{
			if (PropertyInfos.Length != 0)
			{
				object value = PropertyInfos[0].GetValue(_objectSource, null);
				if (_defaultValue == null)
				{
					DefaultValue = value;
				}
				_value = value;
			}
		}

		protected void OnValueChanged()
		{
			if (_objectSource != null)
			{
				PropertyInfo[] propertyInfos = PropertyInfos;
				foreach (PropertyInfo propertyInfo in propertyInfos)
				{
					propertyInfo.SetValue(_objectSource, _value, null);
				}
			}
		}

		public void ResetValue()
		{
			Value = DefaultValue;
		}
	}
}
