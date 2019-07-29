using System.ServiceModel;
using AbpWcfDemo.Wcf;

namespace AbpWcfDemo.Services {

    [ServiceContract]
    public interface IEventsSoapService : IAbpService {

        [OperationContract]
        string GetNextAvailable();

        // TODO: Add your service operations here

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(SearchCourse composite);

    }

}
