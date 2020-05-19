using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VelbService.bussinessObjet
{
    [DataContract]
    public class Station
    {
        [DataMember]
        public int number { get; set; }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String address { get; set; }

        [DataMember]
        public Position position { get; set; }

        [DataMember]
        public Boolean banking { get; set; }

        [DataMember]
        public Boolean bonus { get; set; }

        [DataMember]
        public String status { get; set; }

        [DataMember]
        public String contract_name { get; set; }

        [DataMember]
        public int bike_stands { get; set; }

        [DataMember]
        public int available_bike_stands { get; set; }

        [DataMember]
        public int available_bikes { get; set; }

        [DataMember]
        public Int64 last_update { get; set; }




        override
       public string ToString()
        {
            return "station number: " + number + "\n" + "station position: " + position.ToString() + "\n" +
                "station name: " + name + "\n" +
                "bike stands: " + bike_stands + "\n" +
                "available bike standes: " + available_bike_stands + "\n" +
                "available bikes: " + available_bikes + "\n" +
                "banking: " + banking + "\n" +
                "last_update: " + last_update;

        }
    }
}
