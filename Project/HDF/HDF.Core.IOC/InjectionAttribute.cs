using System;
using System.Collections.Generic;
using System.Text;

namespace HDF.Core.IOC
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class InjectionAttribute : Attribute
    {
    }
}
