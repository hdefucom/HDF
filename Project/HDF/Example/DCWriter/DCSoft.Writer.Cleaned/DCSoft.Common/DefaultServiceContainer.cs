using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       默认的服务器容器对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class DefaultServiceContainer : IServiceContainer
	{
		private Dictionary<Type, object> dictionary_0 = new Dictionary<Type, object>();

		                                                                    /// <summary>
		                                                                    ///       添加获得指定类型的服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		                                                                    /// <returns>获得的对象</returns>
		public object GetService(Type serviceType)
		{
			if (dictionary_0.ContainsKey(serviceType))
			{
				return dictionary_0[serviceType];
			}
			foreach (object value in dictionary_0.Values)
			{
				if (serviceType.IsInstanceOfType(value))
				{
					return value;
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       添加服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		                                                                    /// <param name="callback">获得对象的回调委托</param>
		                                                                    /// <param name="promote">
		                                                                    /// </param>
		public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
		{
			int num = 8;
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (callback != null)
			{
				object obj = callback(this, serviceType);
				method_0(serviceType, obj);
				dictionary_0[serviceType] = obj;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       添加服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		                                                                    /// <param name="callback">获得对象的回调委托</param>
		public void AddService(Type serviceType, ServiceCreatorCallback callback)
		{
			AddService(serviceType, callback, promote: true);
		}

		                                                                    /// <summary>
		                                                                    ///       添加服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		                                                                    /// <param name="serviceInstance">对象实例</param>
		                                                                    /// <param name="promote">
		                                                                    /// </param>
		public void AddService(Type serviceType, object serviceInstance, bool promote)
		{
			AddService(serviceType, serviceInstance);
		}

		                                                                    /// <summary>
		                                                                    ///       添加服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		                                                                    /// <param name="serviceInstance">对象实例</param>
		public void AddService(Type serviceType, object serviceInstance)
		{
			int num = 9;
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			method_0(serviceType, serviceInstance);
			dictionary_0[serviceType] = serviceInstance;
		}

		                                                                    /// <summary>
		                                                                    ///       删除指定类型的服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		                                                                    /// <param name="promote">
		                                                                    /// </param>
		public void RemoveService(Type serviceType, bool promote)
		{
			int num = 12;
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (dictionary_0.ContainsKey(serviceType))
			{
				dictionary_0.Remove(serviceType);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       删除指定类型的服务器对象
		                                                                    ///       </summary>
		                                                                    /// <param name="serviceType">服务器对象类型</param>
		public void RemoveService(Type serviceType)
		{
			int num = 4;
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (dictionary_0.ContainsKey(serviceType))
			{
				dictionary_0.Remove(serviceType);
			}
		}

		private void method_0(Type type_0, object object_0)
		{
			int num = 12;
			if (object_0 != null && !type_0.IsInstanceOfType(object_0))
			{
				throw new InvalidCastException(object_0.GetType().FullName + "!=" + type_0.FullName);
			}
		}
	}
}
