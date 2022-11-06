using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Service
{

    [ServiceContract]
    public interface IServiceLogin
    {
        [OperationContract]
        int Connect(string username, string password);
    }
 
}
