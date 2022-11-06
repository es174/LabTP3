using System;
using System.ServiceModel;
using WCF_Service;

namespace ChatHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host2 = new ServiceHost(typeof(ServiceChat));

            host2.Open();
            Console.WriteLine("ServiceChat is OK");


            var host = new ServiceHost(typeof(ServiceLogin));

            host.Open();
            Console.WriteLine("ServiceLogin is OK");
            Console.ReadLine();


            /*
            using (var host2 = new ServiceHost(typeof(ServiceChat)))
            {
                host2.Open();
                Console.WriteLine("ServiceChat is OK");

            }
            using (var host = new ServiceHost(typeof(ServiceLogin)))
            {
                host.Open();
                Console.WriteLine("ServiceLogin is OK");
                Console.ReadLine();
            }
         */

        }
    }
}
