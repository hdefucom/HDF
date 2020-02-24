using System;

namespace HDF.Core.IOC
{
    public interface IMyContainer
    {

        void RegisterType<TType>();

        void RegisterType<TType, TImpl>();

        TType Resolve<TType>();
    }
}
