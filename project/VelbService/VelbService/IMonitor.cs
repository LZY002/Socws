using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VelbService
{

    [ServiceContract]
    public interface IMonitor
    {
        [OperationContract]
        string GetRequestToVelib(string startTime, string endTime);
        [OperationContract]
        string GetTheNumberOfClient(string startTime, string endTime);

        [OperationContract]
        string GetRequestOfClient(string startTime, string endTime);

        [OperationContract]
        int GetCacheNumber();

        [OperationContract]
        string GetAverageDelay();
    }
}
