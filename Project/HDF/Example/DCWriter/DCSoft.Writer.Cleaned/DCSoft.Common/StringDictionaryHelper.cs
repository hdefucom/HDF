using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    /// </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class StringDictionaryHelper
	{
		private static Dictionary<string, Hashtable> _buffer = new Dictionary<string, Hashtable>();

		public static Hashtable GetDictionary(string list)
		{
			if (_buffer.ContainsKey(list))
			{
				return _buffer[list];
			}
			Hashtable hashtable = new Hashtable();
			string[] array = StringAnalyseHelper.AnalyseStringList(list, ';', '=', AllowSameName: true);
			for (int i = 0; i < array.Length; i += 2)
			{
				hashtable[array[i]] = array[i + 1];
			}
			_buffer[list] = hashtable;
			return hashtable;
		}

		public static string GetValue(string string_0, string list)
		{
			Hashtable dictionary = GetDictionary(list);
			if (dictionary.ContainsKey(string_0))
			{
				return (string)dictionary[string_0];
			}
			return null;
		}
	}
}
