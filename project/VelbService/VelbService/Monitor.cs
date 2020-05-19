using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelbService
{
    public class Monitor : IMonitor
    {
        public string GetAverageDelay()
        {
            return Monitor_Manager.GetAverageDelay();
        }

        public int GetCacheNumber()
        {
            return Monitor_Manager.GetCacheSize();
        }

        public string GetRequestOfClient(string startTime, string endTime)
        {
            double start = Convert.ToDouble(startTime);
            double end = Convert.ToDouble(endTime);
            return Monitor_Manager.GetRequestFromClientSize(start, end).ToString();
        }

        public string GetRequestToVelib(string startTime, string endTime)
        {
            double start = Convert.ToDouble(startTime);
            double end = Convert.ToDouble(endTime);
            return Monitor_Manager.GetRequestNumberToVelib(start, end).ToString();
        }

        public string GetTheNumberOfClient(string startTime, string endTime)
        {
            double start = Convert.ToDouble(startTime);
            double end = Convert.ToDouble(endTime);
            return Monitor_Manager.GetTheNumberOfClient(start, end).ToString();
        }
    }
}
