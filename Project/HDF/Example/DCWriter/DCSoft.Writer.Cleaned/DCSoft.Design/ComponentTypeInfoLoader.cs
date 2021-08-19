using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       可用控件信息加载对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class ComponentTypeInfoLoader
	{
		[ComVisible(false)]
		public class GClass7 : MarshalByRefObject
		{
			private bool bool_0 = false;

			private string[] string_0 = null;

			private string[] string_1 = null;

			public bool method_0()
			{
				return bool_0;
			}

			public void method_1(bool bool_1)
			{
				bool_0 = bool_1;
			}

			public string[] method_2()
			{
				return string_0;
			}

			public void method_3(string[] string_2)
			{
				string_0 = string_2;
			}

			public string[] method_4()
			{
				return string_1;
			}

			public void method_5(string[] string_2)
			{
				string_1 = string_2;
			}

			public ComponentTypeInfo[] method_6(string string_2)
			{
				int num = 1;
				if (!File.Exists(string_2))
				{
					throw new FileNotFoundException(string_2);
				}
				AppDomainSetup appDomainSetup = new AppDomainSetup();
				appDomainSetup.ApplicationBase = Path.GetDirectoryName(string_2);
				appDomainSetup.ApplicationName = "AssemblyAnalyser.GetControlInfosCrossAppDomain";
				if (AppDomain.CurrentDomain.ApplicationTrust != null)
				{
					appDomainSetup.ApplicationTrust = AppDomain.CurrentDomain.ApplicationTrust;
				}
				AppDomain appDomain = AppDomain.CreateDomain("Domain.AssemblyAnalyser.GetControlInfosCrossAppDomain", AppDomain.CurrentDomain.Evidence, appDomainSetup);
				GClass7 gClass = (GClass7)appDomain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(GClass7).FullName);
				gClass.method_3(method_2());
				gClass.method_5(method_4());
				gClass.method_1(method_0());
				byte[] array = gClass.method_7(string_2);
				AppDomain.Unload(appDomain);
				appDomain = null;
				GC.Collect();
				ComponentTypeInfo[] result = null;
				if (array != null)
				{
					MemoryStream serializationStream = new MemoryStream(array);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					result = (ComponentTypeInfo[])binaryFormatter.Deserialize(serializationStream);
				}
				return result;
			}

			public byte[] method_7(string string_2)
			{
				Assembly assembly_ = Assembly.LoadFile(string_2);
				ComponentTypeInfo[] array = method_8(assembly_);
				if (array != null)
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, array);
					memoryStream.Close();
					return memoryStream.ToArray();
				}
				return null;
			}

			public ComponentTypeInfo[] method_8(Assembly assembly_0)
			{
				int num = 6;
				try
				{
					List<ComponentTypeInfo> list = new List<ComponentTypeInfo>();
					Type[] types = assembly_0.GetTypes();
					foreach (Type type in types)
					{
						if (type.IsPublic && !type.IsNested)
						{
							if (!method_0())
							{
								ToolboxItemAttribute toolboxItemAttribute = (ToolboxItemAttribute)Attribute.GetCustomAttribute(type, typeof(ToolboxItemAttribute), inherit: true);
								if (toolboxItemAttribute != null && string.IsNullOrEmpty(toolboxItemAttribute.ToolboxItemTypeName))
								{
									continue;
								}
							}
							ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
							if (constructor != null)
							{
								List<string> list2 = new List<string>();
								Type[] interfaces = type.GetInterfaces();
								if (interfaces != null && interfaces.Length > 0)
								{
									Type[] array = interfaces;
									foreach (Type type2 in array)
									{
										list2.Add(type2.FullName);
									}
								}
								for (Type type3 = type; type3 != null; type3 = type3.BaseType)
								{
									list2.Add(type3.FullName);
								}
								if (string_1 != null && string_1.Length > 0)
								{
									bool flag = false;
									string[] array2 = string_1;
									foreach (string strA in array2)
									{
										foreach (string item in list2)
										{
											if (string.Compare(strA, item, ignoreCase: true) == 0)
											{
												flag = true;
												break;
											}
										}
										if (flag)
										{
											break;
										}
									}
									if (flag)
									{
										continue;
									}
								}
								string text = null;
								if (string_0 != null && string_0.Length > 0)
								{
									string[] array2 = string_0;
									foreach (string strA in array2)
									{
										foreach (string item2 in list2)
										{
											if (string.Compare(strA, item2, ignoreCase: true) == 0)
											{
												text = item2;
												break;
											}
										}
										if (text != null)
										{
											break;
										}
									}
									if (text == null)
									{
										continue;
									}
								}
								ComponentTypeInfo componentTypeInfo = new ComponentTypeInfo();
								componentTypeInfo.AssemblyFullName = assembly_0.FullName;
								componentTypeInfo.Name = type.Name;
								componentTypeInfo.Namespace = type.Namespace;
								componentTypeInfo.FullName = type.FullName + "," + assembly_0.GetName().Name;
								componentTypeInfo.BaseTypeFullName = text;
								ToolboxBitmapAttribute toolboxBitmapAttribute = (ToolboxBitmapAttribute)Attribute.GetCustomAttribute(type, typeof(ToolboxBitmapAttribute), inherit: true);
								if (toolboxBitmapAttribute != null)
								{
									componentTypeInfo.ToolboxImage = toolboxBitmapAttribute.GetImage(type);
								}
								if (componentTypeInfo.ToolboxImage == null)
								{
									Stream manifestResourceStream = assembly_0.GetManifestResourceStream(type.FullName + ".bmp");
									if (manifestResourceStream != null)
									{
										try
										{
											Bitmap bitmap = new Bitmap(manifestResourceStream);
											bitmap.MakeTransparent();
											manifestResourceStream.Close();
											componentTypeInfo.ToolboxImage = bitmap;
										}
										catch (Exception ex)
										{
											Console.WriteLine(ex.Message);
											componentTypeInfo.ToolboxImage = null;
										}
									}
								}
								list.Add(componentTypeInfo);
							}
						}
					}
					list.Sort();
					return list.ToArray();
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.Message);
				}
				return null;
			}
		}

		private bool bool_0 = false;

		private Dictionary<Type, Image> dictionary_0 = new Dictionary<Type, Image>();

		private List<Type> list_0 = new List<Type>();

		                                                                    /// <summary>
		                                                                    ///       显示隐藏的控件类型
		                                                                    ///       </summary>
		public bool ShowHideControlType
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       支持的基础类型
		                                                                    ///       </summary>
		public Dictionary<Type, Image> SupportedBaseTypes
		{
			get
			{
				return dictionary_0;
			}
			set
			{
				dictionary_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       不支持的基础类型
		                                                                    ///       </summary>
		public List<Type> ExcludeBaseTypes
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       从指定的程序集中加载组件类型信息
		                                                                    ///       </summary>
		                                                                    /// <param name="asm">程序集对象</param>
		                                                                    /// <returns>获得的组件类型信息数组</returns>
		public virtual ComponentTypeInfo[] Load(Assembly assembly_0)
		{
			int num = 9;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			GClass7 gClass = new GClass7();
			method_0(gClass);
			ComponentTypeInfo[] array = gClass.method_8(assembly_0);
			method_1(array);
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       从指定名称的程序集文件中加载组件类型信息
		                                                                    ///       </summary>
		                                                                    /// <param name="fileName">程序集文件名</param>
		                                                                    /// <returns>获得的组件类型信息数组</returns>
		public ComponentTypeInfo[] Load(string fileName)
		{
			int num = 15;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			GClass7 gClass = new GClass7();
			method_0(gClass);
			ComponentTypeInfo[] array = gClass.method_6(fileName);
			method_1(array);
			return array;
		}

		private void method_0(GClass7 gclass7_0)
		{
			if (ExcludeBaseTypes != null && ExcludeBaseTypes.Count > 0)
			{
				string[] array = new string[ExcludeBaseTypes.Count];
				for (int i = 0; i < ExcludeBaseTypes.Count; i++)
				{
					array[i] = ExcludeBaseTypes[i].FullName;
				}
				gclass7_0.method_5(array);
			}
			if (SupportedBaseTypes != null && SupportedBaseTypes.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (Type key in SupportedBaseTypes.Keys)
				{
					list.Add(key.FullName);
				}
				gclass7_0.method_3(list.ToArray());
			}
			gclass7_0.method_1(ShowHideControlType);
		}

		private void method_1(ComponentTypeInfo[] componentTypeInfo_0)
		{
			if (componentTypeInfo_0 != null && componentTypeInfo_0.Length > 0)
			{
				foreach (ComponentTypeInfo componentTypeInfo in componentTypeInfo_0)
				{
					foreach (Type key in SupportedBaseTypes.Keys)
					{
						if (string.Compare(key.FullName, componentTypeInfo.BaseTypeFullName, ignoreCase: true) == 0)
						{
							componentTypeInfo.BaseType = key;
							if (componentTypeInfo.ToolboxImage == null)
							{
								componentTypeInfo.ToolboxImage = SupportedBaseTypes[key];
							}
						}
					}
				}
			}
		}
	}
}
