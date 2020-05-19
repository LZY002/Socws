using GoogleMapService.bussinessObject;
using GoogleMapService.ServiceReference1;
using GoogleMapService.ServiceReference2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMap_WebService
{
    public class GoogleMapService : IGoogleMapService
    {

        static VelibServiceClient velibServiceClient = new VelibServiceClient();
        static MonitorClient monitorClient = new MonitorClient();
        private string apiKey_Google = "AIzaSyDpLd_3yEDY0lqm5LRIlDnlRCHXVUZLQcU";


        public List<double> GetTheLatAndLngOfTheLocation(string location)
        {
            double lat;
            double lng;
            List<string> locations = new List<string>(location.Split(' '));
            string result = "";
            foreach (string loa in locations)
            {
                if (result == "")
                {
                    result = loa;
                }
                result = result + '+' + loa;
            }
            WebRequest request_station = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + result + "&key=" + this.apiKey_Google);
            WebResponse response_station = request_station.GetResponse();
            //Monitor_Manager.AddRequestToVelib();
            Stream dataStream = response_station.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Root res = JsonConvert.DeserializeObject<Root>(responseFromServer);
            lat = Convert.ToDouble(res.results.ElementAt(0).geometry.location.lat);
            lng = Convert.ToDouble(res.results.ElementAt(0).geometry.location.lng);
            List<double> resLocation = new List<double>();
            resLocation.Add(lat);
            resLocation.Add(lng);
            return resLocation;




        }
        public Location GetTheNearestStation(List<Station> station_list, string location)
        {
            double lat;
            double lng;
            List<string> locations = new List<string>(location.Split(' '));
            string result = "";
            foreach (string loa in locations)
            {
                if (result == "")
                {
                    result = loa;
                }
                result = result + '+' + loa;
            }
            WebRequest request_station = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + result + "&key=" + this.apiKey_Google);
            WebResponse response_station = request_station.GetResponse();
            //Monitor_Manager.AddRequestToVelib();
            Stream dataStream = response_station.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Root res = JsonConvert.DeserializeObject<Root>(responseFromServer);
            lat = Convert.ToDouble(res.results.ElementAt(0).geometry.location.lat);
            lng = Convert.ToDouble(res.results.ElementAt(0).geometry.location.lng);
            Location origin_station = new Location();
            double mini_distance = -1;
            foreach (Station station in station_list)
            {
                if (mini_distance < 0)
                {
                    origin_station.lat = Convert.ToDouble(station.position.lat);
                    origin_station.lng = Convert.ToDouble(station.position.lng);
                    origin_station.name = station.name;

                    double station_lat = Convert.ToDouble(station.position.lat);
                    double station_lng = Convert.ToDouble(station.position.lng);
                    mini_distance = System.Math.Sqrt(Math.Pow(station_lat - lat, 2) + Math.Pow(station_lng - lng, 2));
                }
                else
                {
                    double station_lat = Convert.ToDouble(station.position.lat);
                    double station_lng = Convert.ToDouble(station.position.lng);
                    double distance = System.Math.Sqrt(Math.Pow(station_lat - lat, 2) + Math.Pow(station_lng - lng, 2));
                    if (distance < mini_distance)
                    {
                        if (station.available_bikes != 0)
                        {
                            mini_distance = distance;
                            origin_station.lat = Convert.ToDouble(station.position.lat);
                            origin_station.lng = Convert.ToDouble(station.position.lng);
                            origin_station.name = station.name;

                        }
                    }
                }

            }
            return origin_station;
        }

        public List<string> GetRouteByWalk(string origin, string destination)
        {
            List<double> originList = GetTheLatAndLngOfTheLocation(origin);
            List<double> destinationList = GetTheLatAndLngOfTheLocation(destination);
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/json?mode=walking&origin=" +
                        originList.First() + "," + originList.Last() + "&destination=" + destinationList.First() + "," + destinationList.Last() + "&key=" + apiKey_Google);
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject route = JObject.Parse(responseFromServer);
                var res = new List<string>();
                string routes = "";

                if (((string)route["geocoded_waypoints"][0]["geocoder_status"]).Equals("OK")
                    && ((string)route["geocoded_waypoints"][1]["geocoder_status"]).Equals("OK"))
                {
                    if (route["routes"].HasValues)
                    {
                        routes = "Distance: " + route["routes"][0]["legs"][0]["distance"]["text"] + "\n Duration: "
                            + route["routes"][0]["legs"][0]["duration"]["text"];
                        res.Add(routes);
                        int i = 1;
                        foreach (var step in route["routes"][0]["legs"][0]["steps"])
                        {

                            routes = i + ". " + step["html_instructions"] + "\n" + step["distance"]["text"]
                                + "\n" + step["duration"]["text"];
                            res.Add(routes);
                            i++;
                        }
                    }
                    {

                        routes = "Finish";
                        res.Add(routes);
                    }
                }
                else
                {
                    routes = "Maybe something is wrong.";
                    res.Add(routes);
                }
                return res;

            }
            catch (WebException wex)
            {
                Console.WriteLine("Web Exception" + wex);
                return null;
            }

        }

        public List<string> GetTheRouteofTheLocationToStation(Location location, string origin)
        {


            List<double> originLocation = GetTheLatAndLngOfTheLocation(origin);

            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/json?mode=walking&origin=" +
                       originLocation.First() + "," + originLocation.Last() + "&destination=" + location.lat + "," + location.lng + "&key=" + apiKey_Google);
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject route = JObject.Parse(responseFromServer);
                var res = new List<string>();
                string first = "Walk to the station " + location.name + "\n";
                res.Add(first);
                string routes = "";

                if (((string)route["geocoded_waypoints"][0]["geocoder_status"]).Equals("OK")
                    && ((string)route["geocoded_waypoints"][1]["geocoder_status"]).Equals("OK"))
                {
                    if (route["routes"].HasValues)
                    {
                        routes = "Distance: " + route["routes"][0]["legs"][0]["distance"]["text"] + "\n Duration: "
                            + route["routes"][0]["legs"][0]["duration"]["text"];
                        res.Add(routes);
                        int i = 1;
                        foreach (var step in route["routes"][0]["legs"][0]["steps"])
                        {

                            routes = i + ". " + step["html_instructions"] + "\n" + step["distance"]["text"]
                                + "\n" + step["duration"]["text"];
                            res.Add(routes);
                            i++;
                        }
                    }
                    {

                        routes = "Take the Bike";
                        res.Add(routes);
                    }
                }
                else
                {
                    routes = "Maybe something is wrong.";
                    res.Add(routes);
                }
                return res;

            }
            catch (WebException wex)
            {
                Console.WriteLine("Web Exception" + wex);
                return null;
            }

        }

        public List<string> GetTheRouteofTheStationToLocation(Location location, string origin)
        {
            List<double> originLocation = GetTheLatAndLngOfTheLocation(origin);

            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/json?mode=walking&origin=" +
                      location.lat + "," + location.lng + "&destination=" + originLocation.First() + "," + originLocation.Last() + "&key=" + apiKey_Google);
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject route = JObject.Parse(responseFromServer);
                var res = new List<string>();
                string first = "Walk to the destination\n";
                res.Add(first);
                string routes = "";

                if (((string)route["geocoded_waypoints"][0]["geocoder_status"]).Equals("OK")
                    && ((string)route["geocoded_waypoints"][1]["geocoder_status"]).Equals("OK"))
                {
                    if (route["routes"].HasValues)
                    {
                        routes = "Distance: " + route["routes"][0]["legs"][0]["distance"]["text"] + "\n Duration: "
                            + route["routes"][0]["legs"][0]["duration"]["text"];
                        res.Add(routes);
                        int i = 1;
                        foreach (var step in route["routes"][0]["legs"][0]["steps"])
                        {

                            routes = i + ". " + step["html_instructions"] + "\n" + step["distance"]["text"]
                                + "\n" + step["duration"]["text"];
                            res.Add(routes);
                            i++;
                        }
                    }
                    {

                        routes = "Finish";
                        res.Add(routes);
                    }
                }
                else
                {
                    routes = "Maybe something is wrong.";
                    res.Add(routes);
                }
                return res;

            }
            catch (WebException wex)
            {
                Console.WriteLine("Web Exception" + wex);
                return null;
            }
        }


        public List<string> GetRoute(string city, string origin, string destination)
        {
            DateTime start = DateTime.Now;
            //Monitor_Manager.AddRequestFromClientSize();
            string key = city + origin + destination;
            List<Station> station_list = new List<Station>(velibServiceClient.GetStations(city));

            Location origin_station = GetTheNearestStation(station_list, origin);
            Location destination_station = GetTheNearestStation(station_list, destination);
            if (origin_station.lat == destination_station.lat && origin_station.lng == destination_station.lng)
            {
                var resl = new List<string>();
                string info = "You should walk to the destination\n";
                List<string> walk = GetRouteByWalk(origin, destination);
                resl.Add(info);
                resl.AddRange(walk);
                return resl;
            }
            var res = new List<string>();
            List<string> orilist = GetTheRouteofTheLocationToStation(origin_station, origin);
            List<string> deslist = GetTheRouteofTheStationToLocation(destination_station, destination);
            res.AddRange(orilist);
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/json?mode=bicycling&origin=" +
                        origin_station.lat + "," + origin_station.lng + "&destination=" + destination_station.lat + "," + destination_station.lng + "&key=" + apiKey_Google);
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject route = JObject.Parse(responseFromServer);

                string routes = "";

                if (((string)route["geocoded_waypoints"][0]["geocoder_status"]).Equals("OK")
                    && ((string)route["geocoded_waypoints"][1]["geocoder_status"]).Equals("OK"))
                {
                    if (route["routes"].HasValues)
                    {
                        routes = "Distance: " + route["routes"][0]["legs"][0]["distance"]["text"] + "\n Duration: "
                            + route["routes"][0]["legs"][0]["duration"]["text"];
                        res.Add(routes);
                        int i = 1;
                        foreach (var step in route["routes"][0]["legs"][0]["steps"])
                        {

                            routes = i + ". " + step["html_instructions"] + "\n" + step["distance"]["text"]
                                + "\n" + step["duration"]["text"];
                            res.Add(routes);
                            i++;
                        }
                    }
                    {

                        routes = "Bike Finish";
                        res.Add(routes);
                    }
                }
                else
                {
                    routes = "Maybe something is wrong.";
                    res.Add(routes);
                }
                res.AddRange(deslist);
                return res;

            }
            catch (WebException wex)
            {
                Console.WriteLine("Web Exception" + wex);
                return null;
            }
        }

    }
}
