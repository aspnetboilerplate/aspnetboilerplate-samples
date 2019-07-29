using System.ServiceModel;

namespace AbpWcfDemo.Services {

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFirst" in both code and config file together.
    [ServiceContract]
    public interface ISimpleService {

        [OperationContract(Name ="MyEcho")]
        //[System.ServiceModel.Web.WebInvoke] // force working only via POST
        string Echo(string echo);

        [OperationContract(Name = "MyEchoPOST")]
        [System.ServiceModel.Web.WebInvoke] // force working only via POST
        string EchoWithPost(string echo);
    }
}
