using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelbService
{
    class Monitor_Manager
    {
        private static List<double> requestsToVelib = new List<double>();
        private static List<double> requestFromClient = new List<double>();
        private static List<double> clientNumber = new List<double>();
        private static List<double> delays = new List<double>();
        private static int cacheSize = 0;



        public static void AddClientSize()
        {
            clientNumber.Add(Convert.ToDouble(DateTime.Now.ToString("yyMMddHHmmss.ffff")));
        }
        public static int GetTheNumberOfClient(double startTime, double endTime)
        {
            int numberOfClient = 0;

            foreach (double time in clientNumber)
            {
               
                
                    numberOfClient++;
                
            }

            return numberOfClient;
        }

        public static void AddRequestToVelib()
        {
            requestsToVelib.Add(Convert.ToDouble(DateTime.Now.ToString("yyMMddHHmmss.ffff")));
        }

        public static int GetRequestNumberToVelib(double startTime, double endTime)
        {
            int numberOfRequest = 0;

            foreach (double request in requestsToVelib)
            {
                
                
                    numberOfRequest++;
               
            }

            return numberOfRequest;
        }

        public static void AddCacheSize()
        {
            cacheSize++;
        }

        public static int GetCacheSize()
        {
            return cacheSize;
        }

        public static void AddRequestFromClientSize()
        {
            requestFromClient.Add(Convert.ToDouble(DateTime.Now.ToString("yyMMddHHmmss.ffff")));

        }

        public static int GetRequestFromClientSize(double startTime, double endTime)
        {
            int numberOfRequest = 0;

            foreach (double request in requestFromClient)
            {
               
                
                    numberOfRequest++;
                
            }

            return numberOfRequest;
        }

        public static void AddDelay(double delay)
        {
            delays.Add(delay);
        }

        public static string GetAverageDelay()
        {
            double sum = 0;
            foreach (double delay in delays)
            {
                sum += delay;
            }
            return (sum / delays.Count).ToString("f4");
        }
    }
}
