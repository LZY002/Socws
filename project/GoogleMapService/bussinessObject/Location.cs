using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapService.bussinessObject
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lng { get; set; }

        public string name { get; set; }

    }
}
