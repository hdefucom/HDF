#define DEBUG
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Data.Object
{
	[ComVisible(false)]
	public class ObjectValueAccesser
	{
		private class AccesserInfo
		{
			private static object[] BlankArray = new object[0];

			public Type ObjectType = null;

			public string Name = null;

			public MemberInfo Member = null;

			public bool CanRead = true;

			public bool CanWrite = true;

			public Type ValueType = typeof(string);

			public object ReadValue(object Instance)
			{
				if (Member == null)
				{
					return null;
				}
				if (Member is PropertyInfo)
				{
					return ((PropertyInfo)Member).GetValue(Instance, BlankArray);
				}
				if (Member is FieldInfo)
				{
					return ((FieldInfo)Member).GetValue(Instance);
				}
				if (Member is MethodInfo)
				{
					return ((MethodInfo)Member).Invoke(Instance, BlankArray);
				}
				return null;
			}
		}

		private static ArrayList myInstances = new ArrayList();

		private Type myObjectType = null;

		private string strPath = null;

		private bool bolCanRead = true;

		private bool bolCanWrite = true;

		private Type myValueType = typeof(string);

		private string[] strSubPaths = null;

		private AccesserInfo myAccesser = null;

		private static ArrayList myAccessers = new ArrayList();

		                                                                    /// <summary>
		                                                                    ///       操作的对象类型
		                                                                    ///       </summary>
		public Type ObjectType
		{
			get
			{
				return myObjectType;
			}
			set
			{
				myObjectType = value;
				strSubPaths = null;
				myAccesser = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       操作路径
		                                                                    ///       </summary>
		public string Path
		{
			get
			{
				return strPath;
			}
			set
			{
				strPath = value;
				strSubPaths = null;
				myAccesser = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       能否读取数据
		                                                                    ///       </summary>
		public bool CanRead => bolCanRead;

		                                                                    /// <summary>
		                                                                    ///       能否写入数据
		                                                                    ///       </summary>
		public bool CanWrite => bolCanWrite;

		                                                                    /// <summary>
		                                                                    ///       数据类型
		                                                                    ///       </summary>
		public Type ValueType => myValueType;

		public static ObjectValueAccesser GetInstance(Type type_0, string path)
		{
			int num = 1;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			foreach (ObjectValueAccesser myInstance in myInstances)
			{
				if (myInstance.myObjectType.Equals(type_0) && string.Compare(myInstance.strPath, path, ignoreCase: true) == 0)
				{
					return myInstance;
				}
			}
			ObjectValueAccesser objectValueAccesser2 = new ObjectValueAccesser();
			objectValueAccesser2.myObjectType = type_0;
			objectValueAccesser2.strPath = path;
			myInstances.Add(objectValueAccesser2);
			return objectValueAccesser2;
		}

		                                                                    /// <summary>
		                                                                    ///       读取对象数据
		                                                                    ///       </summary>
		                                                                    /// <param name="Instance">对象实例</param>
		                                                                    /// <returns>读取的数据</returns>
		public object Read(object Instance)
		{
			if (Instance == null)
			{
				return null;
			}
			CheckState();
			if (myAccesser != null)
			{
				if (myAccesser.CanRead)
				{
					return myAccesser.ReadValue(Instance);
				}
				return null;
			}
			if (strSubPaths != null)
			{
				object obj = Instance;
				string[] array = strSubPaths;
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						string memberName = array[num];
						if (obj == null)
						{
							break;
						}
						AccesserInfo accesser = GetAccesser(obj.GetType(), memberName);
						obj = accesser.ReadValue(obj);
						num++;
						continue;
					}
					return obj;
				}
				return null;
			}
			return null;
		}

		private void CheckState()
		{
			int num = 6;
			if (strSubPaths != null || myAccesser != null)
			{
				return;
			}
			strSubPaths = null;
			myAccesser = null;
			if (strPath == null)
			{
				return;
			}
			int num2 = strPath.IndexOf(".");
			if (num2 >= 0)
			{
				ArrayList arrayList = new ArrayList();
				string[] array = strPath.Split('.');
				foreach (string text in array)
				{
					if (text.Trim().Length > 0)
					{
						arrayList.Add(text.Trim());
					}
				}
				strSubPaths = (string[])arrayList.ToArray(typeof(string));
			}
			else
			{
				myAccesser = GetAccesser(myObjectType, strPath);
				myValueType = myAccesser.ValueType;
			}
		}

		private static AccesserInfo GetAccesser(Type ObjectType, string MemberName)
		{
			foreach (AccesserInfo myAccesser2 in myAccessers)
			{
				if (myAccesser2.ObjectType.Equals(ObjectType) && string.Compare(myAccesser2.Name, MemberName, ignoreCase: true) == 0)
				{
					return myAccesser2;
				}
			}
			AccesserInfo accesserInfo2 = new AccesserInfo();
			accesserInfo2.ObjectType = ObjectType;
			accesserInfo2.Name = MemberName;
			myAccessers.Add(accesserInfo2);
			MemberInfo[] member = ObjectType.GetMember(MemberName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (member != null && member.Length > 0)
			{
				MemberInfo[] array = member;
				foreach (MemberInfo memberInfo in array)
				{
					if (memberInfo is PropertyInfo)
					{
						PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
						ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
						if (indexParameters == null || indexParameters.Length <= 0)
						{
							accesserInfo2.Member = propertyInfo;
							accesserInfo2.CanRead = propertyInfo.CanRead;
							accesserInfo2.CanWrite = propertyInfo.CanWrite;
							accesserInfo2.ValueType = propertyInfo.PropertyType;
							break;
						}
						continue;
					}
					if (!(memberInfo is FieldInfo))
					{
						if (!(memberInfo is MethodInfo))
						{
							continue;
						}
						MethodInfo methodInfo = (MethodInfo)memberInfo;
						if (!methodInfo.IsConstructor)
						{
							ParameterInfo[] indexParameters = methodInfo.GetParameters();
							if ((indexParameters == null || indexParameters.Length <= 0) && !methodInfo.ReturnType.Equals(typeof(void)))
							{
								accesserInfo2.Member = methodInfo;
								accesserInfo2.CanWrite = false;
								accesserInfo2.ValueType = methodInfo.ReturnType;
								break;
							}
						}
						continue;
					}
					accesserInfo2.Member = memberInfo;
					accesserInfo2.ValueType = ((FieldInfo)memberInfo).FieldType;
					break;
				}
			}
			if (accesserInfo2.Member == null)
			{
				Debug.WriteLine(string.Format(DataStrings.MissMember_Type_Member, accesserInfo2.ObjectType.FullName, accesserInfo2.Name));
			}
			return accesserInfo2;
		}
	}
}
