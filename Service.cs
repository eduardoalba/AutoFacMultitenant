using System;

namespace AutoFacSample
{
    public class ServiceA : IService
    {
        private readonly IRepository _repository;

        public ServiceA(IRepository repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Run()
        {
            Console.WriteLine("Running ServiceA");
            _repository.GetData();
        }
    }

    public class ServiceB : IService
    {
        private readonly IRepository _repository;

        public ServiceB(IRepository repository)
        {
            _repository = repository;
        }

        public void Run()
        {
            Console.WriteLine("Running ServiceB");
            _repository.GetData();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class RepositoryA : IRepository
    {
        public void GetData()
        {
            Console.WriteLine("RepositoryA GetData");
        }
    }

    public class RepositoryB : IRepository
    {
        public void GetData()
        {
            Console.WriteLine("RepositoryB GetData");
        }
    }

}
