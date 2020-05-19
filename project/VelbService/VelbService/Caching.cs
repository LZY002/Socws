using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace VelbService
{
   
   public class Caching:ICaching
    {
        static ObjectCache cache_City;
        static ObjectCache cache_Station;
        static ObjectCache cache_Route;
        static ObjectCache cache_Help;
        static CacheItemPolicy cacheItemPolicy;

        public Caching()
        {
            cache_City = MemoryCache.Default;
            cache_Station = MemoryCache.Default;
            cache_Route = MemoryCache.Default;
            cache_Help = MemoryCache.Default;

            cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(40);
        }

        public void AddAllStationOfCity(string cityname,string information)
        {
            cache_City.Set(cityname, information, cacheItemPolicy);
        }

        public void AddHelp(string information)
        {
            cache_Help.Set("help",information,cacheItemPolicy);
        }

        public void AddStationInformation(string cityname, string station, string information)
        {
            string key = cityname + "+"+station;
            cache_Station.Set(key, information, cacheItemPolicy);
        }

        public void AddTheRoute(string cityname, string origin, string destination, List<string> information)
        {
            string key = cityname + "+" + origin + "+" + destination;
            cache_Route.Set(key, information, cacheItemPolicy);
        }

        public string GetAllStationsOfCity(string cityname)
        {
            if (cache_City[cityname] != null)
            {
                return cache_City[cityname].ToString();
            }
            else
                return null;
        }

        public string GetTheHelp()
        {
            if (cache_Help["help"] != null)
            {
                return cache_Help["help"].ToString();
            }
            else
                return null;
        }

        public List<string> GetTheRoute(string cityname, string originname, string destinationname)
        {
            string key = cityname + "+" + originname + "+" + destinationname;
            if (cache_Route[key] != null)
            {
                return (List<string>)cache_Route[key];
            }
            else 
                return null;

        }

        public string GetTheStationOfCity(string cityname, string stationname)
        {
            if (cache_Station[cityname + "+" + stationname] != null)
            {
                return cache_Station[cityname + "+" + stationname].ToString();
            }
            else
                return null;
        }
    }
}
