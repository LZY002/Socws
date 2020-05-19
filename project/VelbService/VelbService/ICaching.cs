using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace VelbService
{
    [ServiceContract]
    public interface ICaching
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "city/{cityname}", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json)]
        string GetAllStationsOfCity(string cityname);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Station?station={stationname}&city={cityname}", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json)]

        string GetTheStationOfCity(string stationname, string  cityname);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Route?city={cityname}&origin={originname}&destination={destinationname}", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json)]

        List<string> GetTheRoute(string cityname, string originname, string destinationname);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "help", RequestFormat = WebMessageFormat.Json,
                                 ResponseFormat = WebMessageFormat.Json)]

        string GetTheHelp();




        void AddAllStationOfCity(string cityname,string infornation);

        void AddHelp(string information);

        void AddStationInformation(string cityname, string station, string information);

        void AddTheRoute(string cityname, string origin, string destination, List<string> information);

    }
}
