using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	[ComVisible(false)]
	public class HashtableParameterProvider : IParameterProvider
	{
		private Hashtable _Values = new Hashtable();

		public ParameterDescriptorList GetDescriptors()
		{
			ParameterDescriptorList parameterDescriptorList = new ParameterDescriptorList();
			foreach (string key in _Values.Keys)
			{
				ParameterDescriptor parameterDescriptor = new ParameterDescriptor();
				parameterDescriptor.Name = key;
				object obj = _Values[key];
				if (obj == null)
				{
					parameterDescriptor.ValueType = typeof(object);
				}
				else
				{
					parameterDescriptor.ValueType = obj.GetType();
				}
				parameterDescriptorList.Add(parameterDescriptor);
			}
			return parameterDescriptorList;
		}

		public object GetParameterValue(string name)
		{
			return _Values[name];
		}

		public bool SetParameterValue(string name, object newValue)
		{
			_Values[name] = newValue;
			return true;
		}

		public bool Contains(string name)
		{
			return _Values.ContainsKey(name);
		}
	}
}
