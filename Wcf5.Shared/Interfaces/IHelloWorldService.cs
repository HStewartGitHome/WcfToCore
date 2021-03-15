



using System.Runtime.Serialization;
using System.ServiceModel;

namespace Shared.Interfaces
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);


        [OperationContract]
        string SayFrom();

        [OperationContract]
        DetailObject GetDetailObject(string name);

    }

    [DataContract]
    public class DetailObject
    {
        [DataMember]
        public string HelloString { get; set; }

        [DataMember]
        public string FromString { get; set; }

        [DataMember]
        public string NameString { get; set; }


        [DataMember]
        public int Count { get; set; }

    }
}