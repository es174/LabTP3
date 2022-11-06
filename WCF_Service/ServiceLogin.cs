using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceLogin : IServiceLogin
    {
        public int Connect(string username, string password)
        {
            //todo sql

            return 1;
        }

    }
}
