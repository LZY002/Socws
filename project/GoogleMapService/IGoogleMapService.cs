using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMap_WebService
{
    [ServiceContract]
    public interface IGoogleMapService
    {
        [OperationContract]

        List<string> GetRoute(string city, string origin, string destination);
    }
}
