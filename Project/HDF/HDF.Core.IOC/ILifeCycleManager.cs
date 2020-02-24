using System;
using System.Collections.Generic;
using System.Text;

namespace HDF.Core.IOC
{
    public interface ILifeCycleManager
    {
        object CreateInstance();
    }
}
