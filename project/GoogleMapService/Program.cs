using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapService
{
    class Program
    {

        private static ServiceHost Host = null;
        static void Main(string[] args)
        {
            if (Host == null)
            {
                Host = new ServiceHost(typeof(GoogleMap_WebService.GoogleMapService));
                //绑定
                System.ServiceModel.Channels.Binding httpBinding = new BasicHttpBinding();
                //终结点
                Host.AddServiceEndpoint(typeof(GoogleMap_WebService.IGoogleMapService), httpBinding, "http://localhost:8009/");
                if (Host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                {
                    //行为
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;

                    //元数据地址
                    behavior.HttpGetUrl = new Uri("http://localhost:8009/Gooogle");
                    Host.Description.Behaviors.Add(behavior);

                    //启动
                    Host.Open();
                }
            }
            while (true) ;
        }
    }
}
