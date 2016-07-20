using System;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Castle.Core.Logging;

namespace AbpEfConsoleApp
{
    //Entry class of the test. It uses constructor-injection to get a repository and property-injection to get a Logger.
    public class Tester : ITransientDependency
    {
        public ILogger Logger { get; set; }

        private readonly IRepository<User, Guid> _userRepository;

        public Tester(IRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;

            Logger = NullLogger.Instance;
        }

        public void Run()
        {
            Logger.Debug("Started Tester.Run()");

            //GetAllList
            foreach (var user in _userRepository.GetAllList())
            {
                Console.WriteLine(user);
            }

            //Get
            Console.WriteLine("Halil: " + _userRepository.Get(new Guid("c2ee8f4e-8592-44d5-84c2-ac5fca1752fd")));

            //FirstOrDefault
            Console.WriteLine("Emre: " + _userRepository.FirstOrDefault(new Guid("b7f88a8e-736e-4708-87d5-beab34f1533b")));

            //Unknown user
            Console.WriteLine("null! " + _userRepository.FirstOrDefault(Guid.NewGuid()));

            Logger.Debug("Finished Tester.Run()");
        }
    }
}