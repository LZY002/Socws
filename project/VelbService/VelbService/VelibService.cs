using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using VelbService.bussinessObjet;
using VelibService.bussinessObjet;

namespace VelbService
{
    class VelibService : IVelibService
    {
      
        

        Caching cacheManager;

        private string apiKey_Jce = "bac8caec19d86aa0813936aa9e15ffce25357854";
        

        public VelibService()
        {
          

           
            Monitor_Manager.AddClientSize();
            cacheManager = new Caching();
        }


        public string GetAllCities()
        { 
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?&apiKey=" + apiKey_Jce);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            List<Contract> contractList = JsonConvert.DeserializeObject<List<Contract>>(responseFromServer);
            string res = "";
            foreach (Contract contract in contractList)
            {
                res = res + contract.name + "\n";
            }
            return res;

        }

        public string GetAllStationsOfCity(string city_name)
        {
            DateTime start = DateTime.Now;
            Monitor_Manager.AddRequestFromClientSize();
            WebRequest requestCache = WebRequest.Create("http://localhost:8001/cache/city/" + city_name);
            WebResponse responseCache = requestCache.GetResponse();
            Monitor_Manager.AddRequestToVelib();
            Stream dataStreamCache = responseCache.GetResponseStream();
            StreamReader readerCache = new StreamReader(dataStreamCache);
            string responseFromServerCache = readerCache.ReadToEnd();
            if(responseFromServerCache != "")
            {
                return responseFromServerCache;
            }


            try
                {
                    WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city_name + "&apiKey=" + this.apiKey_Jce);
                    WebResponse response = request.GetResponse();
                    Monitor_Manager.AddRequestToVelib();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    List<Station> stationList = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);

                    String res = "";
                    foreach (Station station in stationList)
                    {
                        res = res + station.name + "   station_number:  " + station.number + "\n";


                    }
                cacheManager.AddAllStationOfCity(city_name,res);
                    Monitor_Manager.AddCacheSize();
                    Monitor_Manager.AddDelay(DateTime.Now.Subtract(start).TotalMilliseconds);
                    return res;

                }
                catch (WebException wex)
                {
                    return "Web Exception" + wex;

                }
            
        }

        public string GetHelp()
        {
            DateTime start = DateTime.Now;
            Monitor_Manager.AddRequestFromClientSize();
            WebRequest requestCache = WebRequest.Create("http://localhost:8001/cache/help");
            WebResponse responseCache = requestCache.GetResponse();
            Monitor_Manager.AddRequestToVelib();
            Stream dataStreamCache = responseCache.GetResponseStream();
            StreamReader readerCache = new StreamReader(dataStreamCache);
            string responseFromServerCache = readerCache.ReadToEnd();
            if (responseFromServerCache != "")
            {
                return responseFromServerCache;
            }

            string res = "This is a console client. We can access to the IWS to query the information of the bikes. We also can query the route information by googleMap\n";
            cacheManager.AddHelp(res);
                Monitor_Manager.AddCacheSize();
                Monitor_Manager.AddDelay(DateTime.Now.Subtract(start).TotalMilliseconds);
                return res;
            
        }

        public string GetInfomationsOfStation(string city_name, string station_number)
        {

            DateTime start = DateTime.Now;
            Monitor_Manager.AddRequestFromClientSize();
            string postData = "station=" + station_number + "&city=" + city_name;
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
            WebRequest requestCache = WebRequest.Create("http://localhost:8001/cache/Station?station="+station_number+"&city="+city_name);
            requestCache.Method = "POST";

            requestCache.ContentLength = byteArray.Length;
            Stream newStream = requestCache.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            WebResponse responseCache = requestCache.GetResponse();
            Monitor_Manager.AddRequestToVelib();
            Stream dataStreamCache = responseCache.GetResponseStream();
            StreamReader readerCache = new StreamReader(dataStreamCache);
            string responseFromServerCache = readerCache.ReadToEnd();
            if (responseFromServerCache != "")
            {
                return responseFromServerCache;
            }


            try
                {
                    WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/" + station_number + "?contract=" + city_name + "&apiKey=" + apiKey_Jce);
                    WebResponse response = request.GetResponse();
                    Monitor_Manager.AddRequestToVelib();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Station station = JsonConvert.DeserializeObject<Station>(responseFromServer);
                cacheManager.AddStationInformation(city_name, station_number, station.ToString());
                    Monitor_Manager.AddCacheSize();
                    Monitor_Manager.AddDelay(DateTime.Now.Subtract(start).TotalMilliseconds);
                    return station.ToString();

                }
                catch (WebException wex)
                {
                    Console.WriteLine("Web Exception" + wex);
                    return "Web Exception" + wex;
                }
            
        }



        public List<Station> GetStations(string city)
        {

            WebRequest request_station = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=" + this.apiKey_Jce);
            WebResponse response_station = request_station.GetResponse();
            Monitor_Manager.AddRequestFromClientSize();
            Monitor_Manager.AddRequestToVelib();
            Stream dataStream = response_station.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            List<Station> station_list = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);
            return station_list;

        }


    }
}
