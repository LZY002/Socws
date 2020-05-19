using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using VelbService;

namespace VelibService
{
    class Program
    {
        private static ServiceHost Host = null;

        private static ServiceHost HostTwo = null;

       

       


        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            if (Host == null)
            {
                Host = new ServiceHost(typeof(VelbService.VelibService));
                //绑定
                System.ServiceModel.Channels.Binding httpBinding = new BasicHttpBinding();
                //终结点
                Host.AddServiceEndpoint(typeof(VelbService.IVelibService), httpBinding, "http://localhost:8002/");
                if (Host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                {
                    //行为
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;

                    //元数据地址
                    behavior.HttpGetUrl = new Uri("http://localhost:8002/VelibService");
                    Host.Description.Behaviors.Add(behavior);

                    //启动
                    Host.Open();
                    
                }
            }

            if (HostTwo == null)
            {
                HostTwo = new ServiceHost(typeof(VelbService.Monitor));
                //绑定
                System.ServiceModel.Channels.Binding httpBinding = new BasicHttpBinding();
                //终结点
                HostTwo.AddServiceEndpoint(typeof(VelbService.IMonitor), httpBinding, "http://localhost:8006/");
                if (HostTwo.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                {
                    //行为
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;

                    //元数据地址
                    behavior.HttpGetUrl = new Uri("http://localhost:8006/Monitor/");
                    HostTwo.Description.Behaviors.Add(behavior);

                    //启动
                    HostTwo.Open();
                   
                }
            }
            using (WebServiceHost host = new WebServiceHost(typeof(Caching)))
                {
                  host.Open();
               
                     Console.Read();
                }

            while (true) ;
        }
    }
    
}
