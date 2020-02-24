using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Threading;

namespace HDF.Core.IOC
{
    public class MyContainer : IMyContainer
    {
        private readonly Dictionary<string, object> ContainerDictionary = new Dictionary<string, object>();

        public void RegisterType<TType>()
        {
            RegisterType<TType, TType>();
        }

        public void RegisterType<TType, TImpl>()
        {
            if (!ContainerDictionary.ContainsKey(typeof(TType).FullName))
                ContainerDictionary.Add(typeof(TType).FullName, typeof(TImpl));
        }

        public TType Resolve<TType>()
        {
            var key = typeof(TType).FullName;
            var type = (Type)ContainerDictionary[key];
            return (TType)CreateInstance(type);
        }

        private object CreateInstance(Type type, ConstructorInfo ctor)
        {
            var parm = ctor.GetParameters();

            if (parm.Length == 0)
            {
                return Activator.CreateInstance(type);
            }

            var parmObj = new List<object>();
            foreach (var par in parm)
            {
                var parKey = par.ParameterType.FullName;
                var parType = (Type)ContainerDictionary[parKey];
                var parObj = CreateInstance(type);//递归创建依赖
                parmObj.Add(parObj);
            }

            return Activator.CreateInstance(type, parmObj.ToArray());
        }


        private object CreateInstance(Type type)
        {
            //8ThreadLocal
            var ctors = type.GetConstructors();

            //优先创建标记依赖特性的构造函数
            var ctor = ctors.FirstOrDefault(c => c.IsDefined(typeof(InjectionAttribute), true));
            if (ctor != null) return CreateInstance(type, ctor);

            ctor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
            return CreateInstance(type, ctor);
        }











    }
}
