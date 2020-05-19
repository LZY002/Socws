using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VelbService.bussinessObjet
{
    [DataContract]
    public class Position
    {
        [DataMember]

        public string lat { get; set; }


        [DataMember]
        public string lng { get; set; }

        override
        public string ToString()
        {
            return "lat: " + lat + " lng: " + lng;
        }


    }
}
