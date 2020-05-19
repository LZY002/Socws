using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VelbService.bussinessObjet;

namespace VelbService
{
    [ServiceContract]
    public interface IVelibService
    {

        [OperationContract]
        string GetAllCities();
        [OperationContract]
        string GetAllStationsOfCity(string city_name);

        [OperationContract]
        string GetInfomationsOfStation(string city_name, string station_name);

        //[OperationContract]
        //List<string> GetRoute(string city,string origin, string destination);

        [OperationContract]
        string GetHelp();

        [OperationContract]
        List<Station> GetStations(string city);
    }
}
