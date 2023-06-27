using System;

namespace AutoFacSample
{
    public interface IService : IDisposable
    {
        void Run();
    }

    public interface IRepository
    {
        void GetData();
    }

}
