using Open_Newtonsoft_Json.Serialization;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class CollectionUtils
	{
		/// <summary>
		///       Determines whether the collection is null or empty.
		///       </summary>
		/// <param name="collection">The collection.</param>
		/// <returns>
		///   <c>true</c> if the collection is null or empty; otherwise, <c>false</c>.
		///       </returns>
		public static bool IsNullOrEmpty<T>(ICollection<T> collection)
		{
			if (collection != null)
			{
				return collection.Count == 0;
			}
			return true;
		}

		/// <summary>
		///       Adds the elements of the specified collection to the specified generic IList.
		///       </summary>
		/// <param name="initial">The list to add to.</param>
		/// <param name="collection">The collection of elements to add.</param>
		public static void AddRange<T>(IList<T> initial, IEnumerable<T> collection)
		{
			int num = 9;
			if (initial == null)
			{
				throw new ArgumentNullException("initial");
			}
			if (collection != null)
			{
				foreach (T item in collection)
				{
					initial.Add(item);
				}
			}
		}

		public static void AddRange<T>(IList<T> initial, IEnumerable collection)
		{
			ValidationUtils.ArgumentNotNull(initial, "initial");
			AddRange(initial, Enumerable.Cast<T>(collection));
		}

		public static bool IsDictionaryType(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			if (typeof(IDictionary).IsAssignableFrom(type))
			{
				return true;
			}
			if (ReflectionUtils.ImplementsGenericDefinition(type, typeof(IDictionary<, >)))
			{
				return true;
			}
			return false;
		}

		public static ConstructorInfo ResolveEnumerableCollectionConstructor(Type collectionType, Type collectionItemType)
		{
			Type type = typeof(IEnumerable<>).MakeGenericType(collectionItemType);
			ConstructorInfo constructorInfo = null;
			ConstructorInfo[] constructors = collectionType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
			foreach (ConstructorInfo constructorInfo2 in constructors)
			{
				IList<ParameterInfo> parameters = constructorInfo2.GetParameters();
				if (parameters.Count == 1)
				{
					if (type == parameters[0].ParameterType)
					{
						constructorInfo = constructorInfo2;
						break;
					}
					if (constructorInfo == null && type.IsAssignableFrom(parameters[0].ParameterType))
					{
						constructorInfo = constructorInfo2;
					}
				}
			}
			return constructorInfo;
		}

		public static bool AddDistinct<T>(IList<T> list, T value)
		{
			return AddDistinct(list, value, EqualityComparer<T>.Default);
		}

		public static bool AddDistinct<T>(IList<T> list, T value, IEqualityComparer<T> comparer)
		{
			if (ContainsValue(list, value, comparer))
			{
				return false;
			}
			list.Add(value);
			return true;
		}

		public static bool ContainsValue<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
		{
			int num = 15;
			if (comparer == null)
			{
				comparer = EqualityComparer<TSource>.Default;
			}
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			foreach (TSource item in source)
			{
				if (comparer.Equals(item, value))
				{
					return true;
				}
			}
			return false;
		}

		public static bool AddRangeDistinct<T>(IList<T> list, IEnumerable<T> values, IEqualityComparer<T> comparer)
		{
			bool result = true;
			foreach (T value in values)
			{
				if (!AddDistinct(list, value, comparer))
				{
					result = false;
				}
			}
			return result;
		}

		public static int IndexOf<T>(IEnumerable<T> collection, Func<T, bool> predicate)
		{
			int num = 0;
			foreach (T item in collection)
			{
				if (predicate(item))
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		public static bool Contains(IEnumerable list, object value, IEqualityComparer comparer)
		{
			foreach (object item in list)
			{
				if (comparer.Equals(item, value))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       Returns the index of the first occurrence in a sequence by using a specified IEqualityComparer{TSource}.
		///       </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="list">A sequence in which to locate a value.</param>
		/// <param name="value">The object to locate in the sequence</param>
		/// <param name="comparer">An equality comparer to compare values.</param>
		/// <returns>The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, ?.</returns>
		public static int IndexOf<TSource>(IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer)
		{
			int num = 0;
			foreach (TSource item in list)
			{
				if (comparer.Equals(item, value))
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		private static IList<int> GetDimensions(IList values, int dimensionsCount)
		{
			IList<int> list = new List<int>();
			IList list2 = values;
			while (true)
			{
				list.Add(list2.Count);
				if (list.Count == dimensionsCount || list2.Count == 0)
				{
					break;
				}
				object obj = list2[0];
				if (!(obj is IList))
				{
					break;
				}
				list2 = (IList)obj;
			}
			return list;
		}

		private static void CopyFromJaggedToMultidimensionalArray(IList values, Array multidimensionalArray, int[] indices)
		{
			int num = 6;
			int num2 = indices.Length;
			if (num2 == multidimensionalArray.Rank)
			{
				multidimensionalArray.SetValue(JaggedArrayGetValue(values, indices), indices);
				return;
			}
			int length = multidimensionalArray.GetLength(num2);
			IList list = (IList)JaggedArrayGetValue(values, indices);
			int count = list.Count;
			if (count != length)
			{
				throw new Exception("Cannot deserialize non-cubical array as multidimensional array.");
			}
			int[] array = new int[num2 + 1];
			for (int i = 0; i < num2; i++)
			{
				array[i] = indices[i];
			}
			for (int i = 0; i < multidimensionalArray.GetLength(num2); i++)
			{
				array[num2] = i;
				CopyFromJaggedToMultidimensionalArray(values, multidimensionalArray, array);
			}
		}

		private static object JaggedArrayGetValue(IList values, int[] indices)
		{
			IList list = values;
			int num = 0;
			int index;
			while (true)
			{
				if (num < indices.Length)
				{
					index = indices[num];
					if (num == indices.Length - 1)
					{
						break;
					}
					list = (IList)list[index];
					num++;
					continue;
				}
				return list;
			}
			return list[index];
		}

		public static Array ToMultidimensionalArray(IList values, Type type, int rank)
		{
			IList<int> dimensions = GetDimensions(values, rank);
			while (dimensions.Count < rank)
			{
				dimensions.Add(0);
			}
			Array array = Array.CreateInstance(type, Enumerable.ToArray(dimensions));
			CopyFromJaggedToMultidimensionalArray(values, array, new int[0]);
			return array;
		}
	}
}
