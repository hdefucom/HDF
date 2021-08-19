using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class PropertyNameTable
	{
		[ComVisible(false)]
		private class Entry
		{
			internal readonly string Value;

			internal readonly int HashCode;

			internal Entry Next;

			internal Entry(string value, int hashCode, Entry next)
			{
				Value = value;
				HashCode = hashCode;
				Next = next;
			}
		}

		private static readonly int HashCodeRandomizer;

		private int _count;

		private Entry[] _entries;

		private int _mask = 31;

		static PropertyNameTable()
		{
			HashCodeRandomizer = Environment.TickCount;
		}

		public PropertyNameTable()
		{
			_entries = new Entry[_mask + 1];
		}

		public string Get(char[] char_0, int start, int length)
		{
			if (length == 0)
			{
				return string.Empty;
			}
			int num = length + HashCodeRandomizer;
			num += ((num << 7) ^ char_0[start]);
			int num2 = start + length;
			for (int i = start + 1; i < num2; i++)
			{
				num += ((num << 7) ^ char_0[i]);
			}
			num -= num >> 17;
			num -= num >> 11;
			num -= num >> 5;
			Entry entry = _entries[num & _mask];
			while (true)
			{
				if (entry != null)
				{
					if (entry.HashCode == num && TextEquals(entry.Value, char_0, start, length))
					{
						break;
					}
					entry = entry.Next;
					continue;
				}
				return null;
			}
			return entry.Value;
		}

		public string Add(string string_0)
		{
			int num = 9;
			if (string_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			int length = string_0.Length;
			if (length == 0)
			{
				return string.Empty;
			}
			int num2 = length + HashCodeRandomizer;
			for (int i = 0; i < string_0.Length; i++)
			{
				num2 += ((num2 << 7) ^ string_0[i]);
			}
			num2 -= num2 >> 17;
			num2 -= num2 >> 11;
			num2 -= num2 >> 5;
			Entry entry = _entries[num2 & _mask];
			while (true)
			{
				if (entry != null)
				{
					if (entry.HashCode == num2 && entry.Value.Equals(string_0))
					{
						break;
					}
					entry = entry.Next;
					continue;
				}
				return AddEntry(string_0, num2);
			}
			return entry.Value;
		}

		private string AddEntry(string string_0, int hashCode)
		{
			int num = hashCode & _mask;
			Entry entry = new Entry(string_0, hashCode, _entries[num]);
			_entries[num] = entry;
			if (_count++ == _mask)
			{
				Grow();
			}
			return entry.Value;
		}

		private void Grow()
		{
			Entry[] entries = _entries;
			int num = _mask * 2 + 1;
			Entry[] array = new Entry[num + 1];
			for (int i = 0; i < entries.Length; i++)
			{
				Entry entry = entries[i];
				while (entry != null)
				{
					int num2 = entry.HashCode & num;
					Entry next = entry.Next;
					entry.Next = array[num2];
					array[num2] = entry;
					entry = next;
				}
			}
			_entries = array;
			_mask = num;
		}

		private static bool TextEquals(string str1, char[] str2, int str2Start, int str2Length)
		{
			if (str1.Length != str2Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < str1.Length)
				{
					if (str1[num] != str2[str2Start + num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}
}
