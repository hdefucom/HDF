using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       字符串列表,比较不区分大小写,不会放置重复的内容和空白内容
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[Editor("DCSoft.Common.StringListEditor", typeof(UITypeEditor))]
	[ComVisible(false)]
	public class StringList : ICloneable, ICollection
	{
		private class MyEnumeartor : IEnumerator
		{
			public StringList myList = null;

			private int Position = -1;

			public int Version = 0;

			private object CurrentItem = null;

			public object Current => CurrentItem;

			public bool MoveNext()
			{
				int num = 19;
				if (Version != myList.intVersion)
				{
					throw new InvalidOperationException("List changed");
				}
				Position++;
				if (Position >= myList.Count)
				{
					return false;
				}
				CurrentItem = myList[Position];
				return true;
			}

			public void Reset()
			{
				Position = -1;
				Version = myList.intVersion;
			}
		}

		private string[] myValues = new string[16];

		private int intCount = 0;

		private int intVersion = 0;

		public string this[int index]
		{
			get
			{
				int num = 10;
				if (index < 0 || index >= intCount)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return myValues[index];
			}
		}

		public int Count => intCount;

		public bool IsSynchronized
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public object SyncRoot
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public StringList()
		{
		}

		public StringList(string MultilineText)
		{
			StringReader stringReader = new StringReader(MultilineText);
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				Add(text);
			}
			stringReader.Close();
		}

		private void CheckSize(int NewSize)
		{
			if (NewSize > myValues.Length)
			{
				string[] destinationArray = new string[(int)((double)NewSize * 1.4)];
				Array.Copy(myValues, destinationArray, intCount);
				intVersion++;
				myValues = destinationArray;
			}
		}

		public void Clear()
		{
			myValues = new string[16];
			intCount = 0;
			intVersion++;
		}

		public int Add(string item)
		{
			if (item == null)
			{
				return -1;
			}
			if (item.Trim().Length == 0)
			{
				return -1;
			}
			int num = IndexOf(item);
			if (num >= 0)
			{
				RemoveAt(num);
			}
			CheckSize(intCount + 1);
			myValues[intCount] = item;
			intCount++;
			intVersion++;
			return intCount - 1;
		}

		public void AddRange(IEnumerable items)
		{
			if (items != null)
			{
				foreach (string item in items)
				{
					Add(item);
				}
			}
		}

		public void Remove(string item)
		{
			int num = IndexOf(item);
			if (num >= 0)
			{
				RemoveAt(num);
			}
		}

		public void RemoveAt(int index)
		{
			if (index >= 0 && index < intCount)
			{
				if (index == intCount - 1)
				{
					intCount--;
				}
				else
				{
					Array.Copy(myValues, index + 1, myValues, index, intCount - index);
					intCount--;
				}
				intVersion++;
			}
		}

		public int IndexOf(string item)
		{
			int num = 0;
			while (true)
			{
				if (num < intCount)
				{
					if (string.Compare(item, myValues[num], ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public bool Contains(string item)
		{
			return IndexOf(item) >= 0;
		}

		public IEnumerator GetEnumerator()
		{
			MyEnumeartor myEnumeartor = new MyEnumeartor();
			myEnumeartor.myList = this;
			myEnumeartor.Version = intVersion;
			return myEnumeartor;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(Environment.NewLine);
					}
					stringBuilder.Append(value);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       返回列表成员组成的一个字符串数组
		                                                                    ///       </summary>
		                                                                    /// <returns>字符串数组</returns>
		public string[] ToArray()
		{
			string[] array = new string[Count];
			for (int i = 0; i < Count; i++)
			{
				array[i] = this[i];
			}
			return array;
		}

		object ICloneable.Clone()
		{
			StringList stringList = new StringList();
			stringList.myValues = new string[myValues.Length];
			Array.Copy(myValues, stringList.myValues, myValues.Length);
			stringList.intCount = intCount;
			stringList.intVersion = intVersion;
			return stringList;
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public StringList Clone()
		{
			return (StringList)((ICloneable)this).Clone();
		}

		public void CopyTo(Array array, int index)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
