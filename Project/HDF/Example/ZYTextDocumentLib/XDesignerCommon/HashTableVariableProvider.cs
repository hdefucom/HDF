using System;
using System.Collections;

namespace XDesignerCommon
{
	public class HashTableVariableProvider : IVariableProvider
	{
		private Hashtable myValues = null;

		public Hashtable Values => myValues;

		public string[] AllNames
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object key in myValues.Keys)
				{
					arrayList.Add(Convert.ToString(key));
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
		}

		public HashTableVariableProvider()
		{
			myValues = new Hashtable();
		}

		public HashTableVariableProvider(Hashtable vars)
		{
			myValues = vars;
		}

		public void Set(string Name, string Value)
		{
			myValues[Name] = Value;
		}

		public bool Exists(string Name)
		{
			return myValues.ContainsKey(Name);
		}

		public string Get(string Name)
		{
			return Convert.ToString(myValues[Name]);
		}
	}
}
