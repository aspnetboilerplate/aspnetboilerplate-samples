using System.ServiceModel;
using Abp.Dependency;

namespace AbpWcfDemo.Wcf {

    [ServiceContract]
    public interface IAbpService : ITransientDependency {

        /// <summary>
        ///     Test echo operation: return the passes string.
        /// </summary>
        [OperationContract]
        string Echo(string echo);
    }
}
