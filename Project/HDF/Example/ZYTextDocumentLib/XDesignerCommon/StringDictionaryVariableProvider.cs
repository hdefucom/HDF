using System.Collections.Specialized;

namespace XDesignerCommon
{
	public class StringDictionaryVariableProvider : IVariableProvider
	{
		private StringDictionary myDictionary = null;

		public StringDictionary Dictionary
		{
			get
			{
				return myDictionary;
			}
			set
			{
				myDictionary = value;
			}
		}

		public string[] AllNames => null;

		public StringDictionaryVariableProvider()
		{
			myDictionary = new StringDictionary();
		}

		public StringDictionaryVariableProvider(StringDictionary dir)
		{
			myDictionary = dir;
		}

		public void Set(string Name, string Value)
		{
			myDictionary[Name] = Value;
		}

		public bool Exists(string Name)
		{
			return myDictionary.ContainsKey(Name);
		}

		public string Get(string Name)
		{
			return myDictionary[Name];
		}
	}
}
