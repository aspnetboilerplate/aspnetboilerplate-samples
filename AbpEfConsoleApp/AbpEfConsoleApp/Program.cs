using System;
using System.Data.Entity;
using System.Reflection;
using Abp;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Abp.Modules;
using Castle.Core.Logging;
using Castle.Facilities.Logging;

namespace AbpEfConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Bootstrapping ABP system
            using (var bootstrapper = new AbpBootstrapper())
            {
                bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));

                bootstrapper.Initialize();

                //Getting a Tester object from DI and running it
                var tester = IocManager.Instance.Resolve<Tester>();
                tester.Run();

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
        }
    }

    //Defining a module depends on AbpEntityFrameworkModule
    [DependsOn(typeof(AbpEntityFrameworkModule))]
    public class MyConsoleAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    //Entry class of the test. It uses constructor-injection to get a repository.
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

    //A domain entity
    public class User : Entity<Guid>
    {
        public virtual string Name { get; set; }

        public User()
        {

        }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("[User {0}] {1}", Id, Name);
        }
    }

    //EF DbContext class.
    public class MyConsoleAppDbContext : AbpDbContext
    {
        public virtual IDbSet<User> Users { get; set; }

        public MyConsoleAppDbContext()
            : base("Default")
        {

        }

        public MyConsoleAppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
