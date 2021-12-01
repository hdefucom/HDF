using System.Collections;

namespace DCSoft.WinForms
{
	public class SystemDebugKeyValueList : CollectionBase
	{
		public SystemDebugKeyValueItem this[int index] => (SystemDebugKeyValueItem)base.List[index];

		public int Add(SystemDebugKeyValueItem item)
		{
			return base.List.Add(item);
		}

		public int AddItem(string string_0, string Value)
		{
			SystemDebugKeyValueItem systemDebugKeyValueItem = new SystemDebugKeyValueItem();
			systemDebugKeyValueItem.Key = string_0;
			systemDebugKeyValueItem.Value = Value;
			return base.List.Add(systemDebugKeyValueItem);
		}
	}
}
