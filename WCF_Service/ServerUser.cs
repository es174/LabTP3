using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Service
{
    public class ServerUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int ID { get; set; }  

        public OperationContext OperationContext { get; set; }
         
    }
}
