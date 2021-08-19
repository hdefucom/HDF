using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class EnumValue<T> where T : struct
	{
		private readonly string _name;

		private readonly T _value;

		public string Name => _name;

		public T Value => _value;

		public EnumValue(string name, T value)
		{
			_name = name;
			_value = value;
		}
	}
}
